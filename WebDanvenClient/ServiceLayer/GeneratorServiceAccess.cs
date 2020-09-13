using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDanvenClient.GeneratorServiceReference;
using WebDanvenClient.Models;

namespace WebDanvenClient.ServiceLayer {
    public class GeneratorServiceAccess {

        public void CreateGenerator(ClientGenerator clientGenerator) {
            using (GeneratorServiceClient proxy = new GeneratorServiceClient()) {
                GeneratorServiceReference.Generator generator = GeneratorModelConverter.ConvertFromClientGeneratorToServiceGenerator(clientGenerator);
                proxy.CreateGenerator(generator);                            
            }
        }
    }
}