using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopDanvenClient.ModelLayer;
using DesktopDanvenClient.ServiceLayer;

namespace DesktopDanvenClient.ControlLayer {
    public class GeneratorController {
        GeneratorServiceAccess generatorServiceAccess = new GeneratorServiceAccess();

        public List<ClientGenerator> GetAll() {
            return generatorServiceAccess.GetAll();
        }

        public ClientGenerator GetById(int generatorId) {
            return generatorServiceAccess.GetById(generatorId);
            
        }
    }
}
