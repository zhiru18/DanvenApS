using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDanvenClient.Models;
using WebDanvenClient.ServiceLayer;

namespace WebDanvenClient.ControlLayer {
    public class ControlGenerator {
        GeneratorServiceAccess generatorServiceAccess = new GeneratorServiceAccess();
        public ClientGenerator CreateGenerator(ClientGenerator clientGenerator) {
            return generatorServiceAccess.CreateGenerator(clientGenerator);
           
        }
    }
}