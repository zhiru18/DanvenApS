using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopDanvenClient.GeneratorServiceReference;
using DesktopDanvenClient.ModelLayer;

namespace DesktopDanvenClient.ServiceLayer {
    public class GeneratorServiceAccess {
        public List<ClientGenerator> GetAll() {
            using (GeneratorServiceClient proxy = new GeneratorServiceClient()) {
                var serviceGenerators = proxy.GetAll();
                List<ClientGenerator> clientGenerators = GeneratorModelConverter.ConvertFromServicegeneratorsToClientgenerators(serviceGenerators);
                return clientGenerators;
            }
        }
    }
}
