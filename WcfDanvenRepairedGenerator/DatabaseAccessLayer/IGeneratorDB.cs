using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDanvenRepairedGenerator.ModelLayer;

namespace WcfDanvenRepairedGenerator.DatabaseAccessLayer {
    public interface IGeneratorDB {
        Generator Insert(Generator generator);
        Generator UpdateGenerator(Generator generator);
        IEnumerable<Generator> GetAll();
        Generator GetById(int id);
        Generator GetGeneratorByType(string typeNumber);
        void Delete(Generator generator);
    }
}
