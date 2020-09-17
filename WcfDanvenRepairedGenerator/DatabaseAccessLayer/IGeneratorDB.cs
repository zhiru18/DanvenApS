using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDanvenRepairedGenerator.ModelLayer;

namespace WcfDanvenRepairedGenerator.DatabaseAccessLayer {
    interface IGeneratorDB {
        Generator Insert(Generator generator);
        void UpdateGenerator(Generator generator);
        IEnumerable<Generator> GetAll();
        Generator GetById(int id);
    }
}
