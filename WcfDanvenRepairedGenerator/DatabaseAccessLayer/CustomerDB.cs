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
    public class CustomerDB : ICustomerDB {
        private string conString;
        public CustomerDB() {
            conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }
        public Customer GetCustomerByTelephone(string telephone) {
            Customer customer = null;
            using (SqlConnection connection = new SqlConnection(conString)) {
                try {
                    connection.Open();
                    using (SqlCommand cmdGetCustomer = connection.CreateCommand()) {
                        cmdGetCustomer.CommandText = "SELECT * FROM Customer WHERE telephone = @telephone";
                        cmdGetCustomer.Parameters.AddWithValue("@telephone", telephone);
                        SqlDataReader customerReader = cmdGetCustomer.ExecuteReader();

                        if (customerReader.Read()) {
                            customer = MapCustomer(customerReader);
                        }
                    }

                } catch (SqlException se) {
                    throw new Exception();
                }
            }
            return customer; 
        }

        private static Customer MapCustomer(IDataReader customerReader) {
            return new Customer {
                Id = customerReader.GetInt32(0),
                CompanyName = customerReader.GetString(1),
                CompanyAddress = customerReader.GetString(2),
                ContactPersonName= customerReader.GetString(3),
                Email = customerReader.GetString(4),
                Telephone = customerReader.GetString(5)
            };
        }

        public Customer GetCustomerById(int customerId) {
            Customer customer = null;
            using (SqlConnection connection = new SqlConnection(conString)) {
                try {
                    connection.Open();
                    using (SqlCommand cmdGetCustomer = connection.CreateCommand()) {
                        cmdGetCustomer.CommandText = "SELECT * FROM Customer WHERE id = @id";
                        cmdGetCustomer.Parameters.AddWithValue("@id", customerId);
                        SqlDataReader customerReader = cmdGetCustomer.ExecuteReader();

                        if (customerReader.Read()) {
                            customer = MapCustomer(customerReader);
                        }
                    }

                } catch (SqlException se) {
                    throw new Exception();
                }
            }
            return customer;
        }

        public void UpdateCustomer(Customer customer) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                using (SqlCommand cmdUpdateCustomer = connection.CreateCommand()) {
                    cmdUpdateCustomer.CommandText = "UPDATE Customer SET companyName = @companyName, companyAddress = @companyAddress, contactPersonName = @contactPersonName," +
                    "companyEmail=@companyEmail, telephone=@telephone  WHERE id = @id;";
                    cmdUpdateCustomer.Parameters.AddWithValue("@id", customer.Id);
                    cmdUpdateCustomer.Parameters.AddWithValue("@companyName", customer.CompanyName);
                    cmdUpdateCustomer.Parameters.AddWithValue("@companyAddress", customer.CompanyAddress);
                    cmdUpdateCustomer.Parameters.AddWithValue("@contactPersonName", customer.ContactPersonName);
                    cmdUpdateCustomer.Parameters.AddWithValue("@companyEmail", customer.Email);
                    cmdUpdateCustomer.Parameters.AddWithValue("@telephone", customer.Telephone);
                    cmdUpdateCustomer.ExecuteNonQuery();
                }
            }
        }
    }
}
