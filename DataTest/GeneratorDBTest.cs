using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfDanvenRepairedGenerator.DatabaseAccessLayer;
using WcfDanvenRepairedGenerator.ModelLayer;

namespace DataTest {
    [TestClass]
    public class GeneratorDBTest {
        GeneratorDB generatorDB;
        [TestMethod]
        public void InsertTest() {
            //Arrange 
            generatorDB = new GeneratorDB();
            ICustomerDB customerDB = new CustomerDB();
            IProductDB productDB = new ProductDB();
            Customer customer = customerDB.GetCustomerById(1);
            Product product = productDB.GetProductById(1);
            Generator generator = new Generator {
                TypeNumber = "Test",
                SerialNumber = "10000",
                RunningHours = "3600",
                InstallationDate = "10-10-2010",
                GeneratorApplication = "",
                ErrorDescription = "motor wrong",
                AdditionalInformation = "",
                Customer = customer,
                Product = product
            };

            //Act
            var gen = generatorDB.Insert(generator);
            var gen2 = generatorDB.GetGeneratorByType(generator.TypeNumber);

            //Assert
            Assert.AreEqual(gen2.TypeNumber, "Test");

            //Cleanup
            generatorDB.Delete(gen2);
        }

        [TestMethod]
        public void GetAllTest() {
            //Arrange
            generatorDB = new GeneratorDB();

            //Act
            var generators = generatorDB.GetAll().ToList();

            //Assert
            Assert.IsNotNull(generators.Count);
        }

        [TestMethod]
        public void GetByIdTest() {
            // Arrange
            generatorDB = new GeneratorDB();
            ICustomerDB customerDB = new CustomerDB();
            IProductDB productDB = new ProductDB();
            Customer customer = customerDB.GetCustomerById(1);
            Product product = productDB.GetProductById(1);
            Generator generator = new Generator {
                TypeNumber = "Test",
                SerialNumber = "10000",
                RunningHours = "3600",
                InstallationDate = "10-10-2010",
                GeneratorApplication = "",
                ErrorDescription = "motor wrong",
                AdditionalInformation = "",
                Customer = customer,
                Product = product
            };
            generatorDB.Insert(generator);
            Generator generator1 = generatorDB.GetGeneratorByType(generator.TypeNumber);

            // Act
            Generator generator2 = generatorDB.GetById(generator1.Id);

            //Assert
            Assert.AreEqual(generator2.TypeNumber, "Test");

        }

        [TestMethod]
        public void UpdateGeneratorTest() {
            // Arrange
             generatorDB = new GeneratorDB();
            Generator generator1 = generatorDB.GetGeneratorByType("Test");

            //Act
            generator1.SerialNumber = "Update";
            generatorDB.UpdateGenerator(generator1);
            var gen2 = generatorDB.GetGeneratorByType("Test");

            //Assert
            Assert.AreEqual(gen2.SerialNumber, "Update");

            //Cleanup
            generatorDB.Delete(gen2);
        }

        [TestMethod]
        public void GetGeneratorByTypeTest() {
            // Arrange
            generatorDB = new GeneratorDB();
            Generator generator = null, generator1=null;
            var generators = generatorDB.GetAll().ToList();
            if (generators.Count > 0) {
                generator = generators[0];
            }

            //Act
            generator1 = generatorDB.GetGeneratorByType(generator.TypeNumber);

            //Assert
            Assert.AreEqual(generator.SerialNumber, generator1.SerialNumber);
        }

        [TestMethod]
        public void DeleteTest() {
            // Arrange
            generatorDB = new GeneratorDB();
            ICustomerDB customerDB = new CustomerDB();
            IProductDB productDB = new ProductDB();
            Customer customer = customerDB.GetCustomerById(1);
            Product product = productDB.GetProductById(1);
            Generator generator = new Generator {
                TypeNumber = "Test",
                SerialNumber = "10000",
                RunningHours = "3600",
                InstallationDate = "10-10-2010",
                GeneratorApplication = "",
                ErrorDescription = "motor wrong",
                AdditionalInformation = "",
                Customer = customer,
                Product = product
            };
            generatorDB.Insert(generator);
            Generator generator1 = generatorDB.GetGeneratorByType("Test");

            //Act
            generatorDB.Delete(generator1);
            var gen2 = generatorDB.GetGeneratorByType("Test");

            //Assert
            Assert.IsNull(gen2);
        }
    }
 }

