using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDesktopClient.GeneratorServiceReference;
using WPFDesktopClient.ModelLayer;

namespace WPFDesktopClient.ServiceLayer {
    public class GeneratorServiceAccess {
        public List<ClientGenerator> GetAll() {
            using (GeneratorServiceClient proxy = new GeneratorServiceClient()) {
                var serviceGenerators = proxy.GetAll();
                List<ClientGenerator> clientGenerators = GeneratorModelConverter.ConvertFromServicegeneratorsToClientgenerators(serviceGenerators);
                return clientGenerators;
            }
        }

        public ClientGenerator GetById(int generatorId) {
            using (GeneratorServiceClient proxy = new GeneratorServiceClient()) {
                var serviceGenerator = proxy.GetById(generatorId);
                ClientGenerator clientGenerator = GeneratorModelConverter.ConvertFromServiceGeneratorToClientGenerator(serviceGenerator);
                return clientGenerator;
            }

        }

        public ClientGenerator UpdateGenerator(ClientGenerator clientGenerator) {
            Generator serviceGenerator = GeneratorModelConverter.ConvertFromClientGeneratorToServiceGenerator(clientGenerator);
            using (GeneratorServiceClient proxy = new GeneratorServiceClient()) {
                var serviceGenerator1 = proxy.UpdateGenerator(serviceGenerator);
                ClientGenerator clientGenerator1 = GeneratorModelConverter.ConvertFromServiceGeneratorToClientGenerator(serviceGenerator1);
                return clientGenerator1;
            }
        }
    }
}
