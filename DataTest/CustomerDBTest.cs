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
    public class CustomerDBTest {
        CustomerDB customerDB;
       
        [TestMethod]
        public void GetCustomerByIdTest() {
            // Arrange
            customerDB = new CustomerDB();
            Customer customer = null, customer1 = null;
            customer = customerDB.GetCustomerByTelephone("12121212");


            //Act
            customer1 = customerDB.GetCustomerById(customer.Id);

            //Assert
            Assert.AreEqual(customer.CompanyName, customer1.CompanyName);
        }

        [TestMethod]
        public void UpdateGeneratorTest() {
            // Arrange
            customerDB = new CustomerDB();
            Customer customer = customerDB.GetCustomerById(2);
            //Act
            customer.CompanyName = "Update Company";
            customerDB.UpdateCustomer(customer);
            var customer1 = customerDB.GetCustomerById(2);

            //Assert
            Assert.AreEqual(customer1.CompanyName, "Update Company");

            //Cleanup
            customer1.CompanyName = "Test Company";
            customerDB.UpdateCustomer(customer1);
        }

        [TestMethod]
        public void GetCustomerByTelephoneTest() {
            // Arrange
            customerDB = new CustomerDB();
            Customer customer= null, customer1 = null;
            customer = customerDB.GetCustomerById(2);


            //Act
            customer1 = customerDB.GetCustomerByTelephone(customer.Telephone);

            //Assert
            Assert.AreEqual(customer.CompanyName, customer1.CompanyName);
        }     
    }
}
