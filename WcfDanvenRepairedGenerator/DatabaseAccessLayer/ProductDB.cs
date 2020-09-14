﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDanvenRepairedGenerator.ModelLayer;

namespace WcfDanvenRepairedGenerator.DatabaseAccessLayer {
    public class ProductDB:IProductDB {
        private string conString;
        public ProductDB() {
            conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }

        public Product GetProductByTypeInvoice(string productType, string invoice) {
            Product product = null;
            using (SqlConnection connection = new SqlConnection(conString)) {
                try {
                    connection.Open();
                    using (SqlCommand cmdGetProd = connection.CreateCommand()) {
                        cmdGetProd.CommandText = "SELECT * FROM Product WHERE  productType = @productType AND invoiceNumber = @invoiceNumber";
                        cmdGetProd.Parameters.AddWithValue("@productType", productType);
                        cmdGetProd.Parameters.AddWithValue("@invoiceNumber", invoice);
                        SqlDataReader productReader = cmdGetProd.ExecuteReader();

                        if (productReader.Read()) {
                            product = MapProduct(productReader);
                        }
                    }

                } catch (SqlException se) {
                    throw new Exception();
                }
            }
            return product;

        }

        private static Product MapProduct(IDataReader productReader) {
            return new Product {
                Id = productReader.GetInt32(0),
                ProductType = productReader.GetString(1),
                ProductSerialNumber = productReader.GetString(2),
                InvoiceNumber = productReader.GetString(3)
            };
        }
    }
}
