using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WcfDanvenRepairedGenerator.DatabaseAccessLayer;
using WcfDanvenRepairedGenerator.ModelLayer;

namespace WcfDanvenRepairedGenerator.ControlLayer {
    public class GeneratorController {
        private IGeneratorDB generatorDB; 
        
        public GeneratorController() {
            generatorDB = new GeneratorDB();
        }
        public Generator CreateGenerator(Generator generator) {
            return generatorDB.Insert(generator);
        }

        public IEnumerable<Generator> GetAll() {
            return generatorDB.GetAll();
        }
    }
}
