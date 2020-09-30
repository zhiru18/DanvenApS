using System;
using System.Collections.Generic;
using DesktopDanvenClient.ModelLayer;
using DesktopDanvenClient.ServiceLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesktopTest {
    [TestClass]
    public class GeneratorServiceAccessTest {
        GeneratorServiceAccess generatorServiceAccess;
        [TestMethod]
        public void GetAllTest() {
            //Arrange
            generatorServiceAccess = new GeneratorServiceAccess();

            //Act
            List<ClientGenerator> clientGenerators = generatorServiceAccess.GetAll();

            //Assert
            Assert.IsTrue(clientGenerators.Count > 0);
        }

        [TestMethod]
        public void GetByIdTest() {
            //Arrange
            generatorServiceAccess = new GeneratorServiceAccess();
            ClientGenerator clientGenerator = null, clientGenerator1 = null;
            List<ClientGenerator> clientGenerators = generatorServiceAccess.GetAll();
            if (clientGenerators.Count > 0) {
                clientGenerator = clientGenerators[0];
            }

            //Act
            clientGenerator1 = generatorServiceAccess.GetById(clientGenerator.Id);

            //Assert
            Assert.AreEqual(clientGenerator.TypeNumber, clientGenerator1.TypeNumber);
        }

        [TestMethod]
        public void UpdateGeneratorTest() {
            //Arrange
            generatorServiceAccess = new GeneratorServiceAccess();
            ClientGenerator clientGenerator = null, clientGenerator1 = null;
            List<ClientGenerator> clientGenerators = generatorServiceAccess.GetAll();
            if (clientGenerators.Count > 0) {
                clientGenerator = clientGenerators[0];
            }

            //Act
            string gamleSerialNumber = clientGenerator.SerialNumber;
            clientGenerator.SerialNumber = "Update";
            generatorServiceAccess.UpdateGenerator(clientGenerator);
            clientGenerator1 = generatorServiceAccess.GetById(clientGenerator.Id);

            //Assert
            Assert.AreEqual(clientGenerator1.SerialNumber, "Update");

            //Cleanup
            clientGenerator1.SerialNumber = gamleSerialNumber;
            generatorServiceAccess.UpdateGenerator(clientGenerator1);
        }
    } 
}
