﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfDanvenRepairedGenerator.DatabaseAccessLayer;
using WcfDanvenRepairedGenerator.ModelLayer;
using WcfDanvenRepairedGenerator.ServiceAccessLayer;

namespace GeneratorServiceTest {
    [TestClass]
    public class GeneratorServiceTest {
        GeneratorService generatorService;
        [TestMethod]
        public void CreateGeneratorTest() {
            //Arrange
            generatorService = new GeneratorService();
            IGeneratorDB generatorDB = new GeneratorDB();
            ICustomerDB customerDB= new CustomerDB();
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
                AdditionalInformation ="",
                Customer = customer,
                Product = product
            };

            //Act
            var gen = generatorService.CreateGenerator(generator);
            var gen2 = generatorDB.GetGeneratorByType(generator.TypeNumber);

            //Assert
            Assert.AreEqual(gen2.TypeNumber, "Test");

            //Cleanup
           generatorDB.Delete(gen2);
        }

        [TestMethod]
        public void GetByIdTest() {
            // Arrange
            generatorService = new GeneratorService();
            IGeneratorDB generatorDB = new GeneratorDB();
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
            Generator generator2 = generatorService.GetById(generator1.Id);

            //Assert
            Assert.AreEqual(generator2.TypeNumber, "Test");

        }

        [TestMethod]
        public void UpdateGeneratorTest() {
            // Arrange
            generatorService = new GeneratorService();
            IGeneratorDB generatorDB = new GeneratorDB();
            Generator generator1 = generatorDB.GetGeneratorByType("Test");

            //Act
            generator1.SerialNumber = "Update";
            generatorService.UpdateGenerator(generator1);
            var gen2 = generatorDB.GetGeneratorByType("Test");

            //Assert
            Assert.AreEqual(gen2.SerialNumber, "Update");
            //Cleanup
            generatorDB.Delete(gen2);
        }

        [TestMethod]
        public void GetAllTest() {
            //Arrange
            generatorService = new GeneratorService();

            //Act
            var generators = generatorService.GetAll();

            //Assert
            Assert.IsNotNull(generators.Count());
        }
    }
}
