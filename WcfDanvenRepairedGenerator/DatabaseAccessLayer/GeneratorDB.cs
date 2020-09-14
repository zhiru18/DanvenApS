using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDanvenRepairedGenerator.ModelLayer;

namespace WcfDanvenRepairedGenerator.DatabaseAccessLayer {
    public class GeneratorDB : IGeneratorDB {
        private string conString;
        public GeneratorDB() {
            conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }
        public Generator Insert(Generator generator) {
            Generator insertGenenrator = null;
            CustomerDB customerDB = new CustomerDB();
            ProductDB productDB = new ProductDB();
            string telephone = generator.Customer.Telephone;
            string productType = generator.Product.ProductType;
            string invoice = generator.Product.InvoiceNumber;
            Product product = productDB.GetProductByTypeInvoice(productType, invoice);
            Customer customer = customerDB.GetCustomerByTelephone(telephone);
            if (product != null & customer != null) {
                using (SqlConnection connection = new SqlConnection(conString)) {
                    try {
                        connection.Open();
                        using (SqlCommand cmdInsertGenerator = connection.CreateCommand()) {
                            cmdInsertGenerator.CommandText = "INSERT INTO RepairedGenerator(isRepaired,typeNumber,serialNumber,runningHours," +
                                "installationDate,generatorApplication,errorDescription,additionalInformation,productId,customerId) " +
                                "VALUES(@isRepaired,@typeNumber,@serialNumber,@runningHours,@installationDate,@generatorApplication," +
                                "@errorDescription,@additionalInformation,@productId,@customerId)";

                            int p = product.Id;
                            int c = customer.Id;
                            cmdInsertGenerator.Parameters.AddWithValue("@isRepaired", generator.IsRepaired);
                            cmdInsertGenerator.Parameters.AddWithValue("@typeNumber", generator.TypeNumber);
                            cmdInsertGenerator.Parameters.AddWithValue("@serialNumber", generator.SerialNumber);
                            cmdInsertGenerator.Parameters.AddWithValue("@runningHours", generator.RunningHours);
                            cmdInsertGenerator.Parameters.AddWithValue("@installationDate", generator.InstallationDate);
                            cmdInsertGenerator.Parameters.AddWithValue("@generatorApplication", generator.GeneratorApplication);
                            cmdInsertGenerator.Parameters.AddWithValue("@errorDescription", generator.ErrorDescription);
                            cmdInsertGenerator.Parameters.AddWithValue("@additionalInformation", generator.AdditionalInformation);
                            cmdInsertGenerator.Parameters.AddWithValue("@productId", p);
                            cmdInsertGenerator.Parameters.AddWithValue("@customerId", c);
                            cmdInsertGenerator.ExecuteNonQuery();
                            generator.Product = product;
                            generator.Customer = customer;
                            insertGenenrator = generator;
                        }
                    } catch (SqlException se) {
                        throw new Exception();
                    }
                }
            }
            return insertGenenrator;
        }
        public IEnumerable<Generator> GetAll() {
            throw new NotImplementedException();
        }

        public void UpdateGenerator(Generator generator) {
            throw new NotImplementedException();
        }
    }
}
