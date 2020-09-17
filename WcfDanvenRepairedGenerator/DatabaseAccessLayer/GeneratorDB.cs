using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDanvenRepairedGenerator.ModelLayer;

namespace WcfDanvenRepairedGenerator.DatabaseAccessLayer {
    public class GeneratorDB : IGeneratorDB {
        private string conString;
        private static ICustomerDB customerDB;
        private static IProductDB productDB;
        public GeneratorDB() {
            conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
            customerDB = new CustomerDB();
            productDB = new ProductDB();
        }
        public Generator Insert(Generator generator) {
            Generator insertGenerator = null;         
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
                            insertGenerator = generator;
                        }
                    } catch (SqlException se) {
                        throw new Exception();
                    }
                }
            }
            return insertGenerator;
        }
        public IEnumerable<Generator> GetAll() {
            List<Generator> generators = new List<Generator>();
            using (SqlConnection con = new SqlConnection(conString)) {
                con.Open();
                using (SqlCommand cmdGetGenerator = con.CreateCommand()) {
                    cmdGetGenerator.CommandText = "SELECT * FROM RepairedGenerator";
                    SqlDataReader generatorReader = cmdGetGenerator.ExecuteReader();

                    while (generatorReader.Read()) {
                        generators.Add(MapGenerator(generatorReader));
                    }
                }
            }
            return generators;
        }

        private static Generator MapGenerator(IDataReader generatorReader) {
            int customerId = generatorReader.GetInt32(10);
            int productId = generatorReader.GetInt32(9);
            Generator generator = new Generator {
               Id = generatorReader.GetInt32(0),
               IsRepaired = generatorReader.GetBoolean(1),
               TypeNumber = generatorReader.GetString(2),
               SerialNumber = generatorReader.GetString(3),
               RunningHours = generatorReader.GetString(4),
               InstallationDate = generatorReader.GetString(5),
               GeneratorApplication = generatorReader.GetString(6),
               ErrorDescription = generatorReader.GetString(7),
               AdditionalInformation = generatorReader.GetString(8)
            };
            Customer customer = customerDB.GetCustomerById(customerId);
            Product product = productDB.GetProductById(productId);
            generator.Customer = customer;
            generator.Product = product;

            return generator;
        }

        public void UpdateGenerator(Generator generator) {
            throw new NotImplementedException();
        }

        public Generator GetById(int id) {
            Generator generator = null;
            using (SqlConnection con = new SqlConnection(conString)) {
                con.Open();
                using (SqlCommand cmdGetGenerator = con.CreateCommand()) {
                    cmdGetGenerator.CommandText = "SELECT * FROM RepairedGenerator WHERE id = @id";
                    cmdGetGenerator.Parameters.AddWithValue("@id", id);
                   SqlDataReader generatorReader = cmdGetGenerator.ExecuteReader();

                    if (generatorReader.Read()) {
                       generator= MapGenerator(generatorReader);
                    }
                }
            }
            return generator;
        }
    }
}
