using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopDanvenClient.ControlLayer;
using DesktopDanvenClient.ModelLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesktopTest {
    [TestClass]
    public class GeneratorControllerTest {
        GeneratorController generatorController;
        [TestMethod]
        public void GetAllTest() {
            //Arrange
            generatorController = new GeneratorController();

            //Act
            List<ClientGenerator> clientGenerators = generatorController.GetAll();

            //Assert
            Assert.IsTrue(clientGenerators.Count > 0);
        }

        [TestMethod]
        public void GetByIdTest() {
            //Arrange
            generatorController = new GeneratorController();
            ClientGenerator clientGenerator = null, clientGenerator1 = null;
            List<ClientGenerator> clientGenerators = generatorController.GetAll();
            if (clientGenerators.Count > 0) {
                clientGenerator = clientGenerators[0];
            }

            //Act
            clientGenerator1 = generatorController.GetById(clientGenerator.Id);

            //Assert
            Assert.AreEqual(clientGenerator.TypeNumber, clientGenerator1.TypeNumber);
        }

        [TestMethod]
        public void UpdateGeneratorTest() {
            //Arrange
            generatorController = new GeneratorController();
            ClientGenerator clientGenerator = null, clientGenerator1 = null;
            List<ClientGenerator> clientGenerators = generatorController.GetAll();
            if (clientGenerators.Count > 0) {
                clientGenerator = clientGenerators[0];
            }

            //Act
            string gamleSerialNumber = clientGenerator.SerialNumber;
            clientGenerator.SerialNumber = "Update";
            generatorController.UpdateGenerator(clientGenerator);
            clientGenerator1 = generatorController.GetById(clientGenerator.Id);

            //Assert
            Assert.AreEqual(clientGenerator1.SerialNumber, "Update");

            //Cleanup
            clientGenerator1.SerialNumber = gamleSerialNumber;
            generatorController.UpdateGenerator(clientGenerator1);
        }
    }
}
