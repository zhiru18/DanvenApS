using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDesktopClient.ModelLayer;
using WPFDesktopClient.ServiceLayer;

namespace WPFDesktopClient.ControlLayer {
    public class GeneratorController {
        GeneratorServiceAccess generatorServiceAccess = new GeneratorServiceAccess();

        public List<ClientGenerator> GetAll() {
            return generatorServiceAccess.GetAll();
        }

        public ClientGenerator GetById(int generatorId) {
            return generatorServiceAccess.GetById(generatorId);

        }

        public ClientGenerator UpdateGenerator(ClientGenerator clientGenerator) {
            return generatorServiceAccess.UpdateGenerator(clientGenerator);
        }
    }
}
