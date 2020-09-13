using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfDanvenRepairedGenerator.ModelLayer {
    [DataContract]
    public class Customer {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string CompanyAddress { get; set; }
        [DataMember]
        public string ContactPersonName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Telephone { get; set; }

        public Customer(string companyName, string telephone) {
            this.CompanyName = companyName;
            this.Telephone = telephone;
        }

        public Customer() {

        }
    }   
}
