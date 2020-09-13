﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfDanvenRepairedGenerator.ModelLayer;

namespace WcfDanvenRepairedGenerator.ServiceAccessLayer {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGeneratorService {
        [OperationContract]
        void CreateGenerator(Generator generator);
        [OperationContract]
        void UpdateGenerator(Generator generator);
        [OperationContract]
        IEnumerable<Generator> GetAll();
    }
}
