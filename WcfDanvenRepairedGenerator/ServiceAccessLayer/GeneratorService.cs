using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfDanvenRepairedGenerator.ControlLayer;
using WcfDanvenRepairedGenerator.ModelLayer;

namespace WcfDanvenRepairedGenerator.ServiceAccessLayer {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class GeneratorService : IGeneratorService {
        GeneratorController generatorController = new GeneratorController();
        public Generator CreateGenerator(Generator generator) {
            if (generator== null) {
                throw new ArgumentNullException();
            }else { return generatorController.CreateGenerator(generator); 
            }         
        }

        public IEnumerable<Generator> GetAll() {
            return generatorController.GetAll();
        }

        public Generator GetById(int id) {
            if (id == 0) {
                throw new ArgumentException();
            } else { return generatorController.GetById(id); 
            }           
        }

        public Generator UpdateGenerator(Generator generator) {
            if (generator == null) {
                throw new ArgumentNullException();
            } else {return generatorController.UpdateGenerator(generator); 
            }           
        }
    }
}
