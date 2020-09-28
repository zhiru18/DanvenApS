using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDanvenRepairedGenerator.ModelLayer;

namespace WcfDanvenRepairedGenerator.DatabaseAccessLayer {
    public interface ICustomerDB {
        Customer GetCustomerByTelephone(string telephone);
        Customer GetCustomerById(int customerId);
        void UpdateCustomer(Customer customer);
    }
}
