﻿using System;
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
        public void CreateGenerator(Generator generator) {
            generatorController.CreateGenerator(generator);
        }

        public IEnumerable<Generator> GetAll() {
            throw new NotImplementedException();
        }
        public void UpdateGenerator(Generator generator) {
            throw new NotImplementedException();
        }
    }
}
