using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDanvenClient.GeneratorServiceReference;
using WebDanvenClient.Models;

namespace WebDanvenClient.ServiceLayer {
    public class GeneratorServiceAccess {

        public ClientGenerator CreateGenerator(ClientGenerator clientGenerator) {
            ClientGenerator insertClientGenerator = null;
            using (GeneratorServiceClient proxy = new GeneratorServiceClient()) {
                GeneratorServiceReference.Generator generator = GeneratorModelConverter.ConvertFromClientGeneratorToServiceGenerator(clientGenerator);
                GeneratorServiceReference.Generator insertGennerator = proxy.CreateGenerator(generator); 
                if (insertGennerator != null) {
                    insertClientGenerator = GeneratorModelConverter.ConvertFromServiceGeneratorToClientGenerator(insertGennerator);
                }
            }
            return insertClientGenerator;
        }
    }
}