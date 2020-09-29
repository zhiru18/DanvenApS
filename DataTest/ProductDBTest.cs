using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfDanvenRepairedGenerator.DatabaseAccessLayer;
using WcfDanvenRepairedGenerator.ModelLayer;

namespace DataTest {
    [TestClass]
    public class ProductDBTest {
        ProductDB productDB;
        [TestMethod]
        public void GetProductByIdTest() {
            // Arrange
            productDB = new ProductDB();
            Product product = null, product1 = null;
            product = productDB.GetProductByTypeInvoice("Test prod", "test inv");

            //Act
            product1 = productDB.GetProductById(2);

            //Assert
            Assert.AreEqual(product.InvoiceNumber, product1.InvoiceNumber);
        }

        [TestMethod]
        public void UpdateGeneratorTest() {
            // Arrange
            productDB = new ProductDB();
            Product product = productDB.GetProductById(2);
            //Act
            product.ProductType = "Update prod";
            productDB.UpdateProduct(product);
            var product1 = productDB.GetProductById(2);

            //Assert
            Assert.AreEqual(product1.ProductType, "Update prod");

            //Cleanup
            product1.ProductType = "Test prod";
            productDB.UpdateProduct(product1);
        }

        [TestMethod]
        public void GetProductByTypeInvoiceTest() {
            // Arrange
            productDB = new ProductDB();
            Product product = null, product1 = null;
            product = productDB.GetProductById(2);

            //Act
            product1 = productDB.GetProductByTypeInvoice(product.ProductType, product.InvoiceNumber);

            //Assert
            Assert.AreEqual(product1.ProductSerialNumber, product.ProductSerialNumber);
        }
    }
}
