using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDesktopClient.ModelLayer {
   public class ClientCustomer {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string ContactPersonName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public ClientCustomer(string companyName, string telephone) {
            this.CompanyName = companyName;
            this.Telephone = telephone;
        }

        public ClientCustomer() {

        }
    }
}
