using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfDanvenRepairedGenerator.ModelLayer {
    [DataContract]
    public class Product {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ProductType { get; set; }
        [DataMember]
        public string ProductSerialNumber { get; set; }
        [DataMember]
        public string InvoiceNumber { get; set; }

        public Product(string productType, string productSerialNumber, string invoiceNumber) {
            this.ProductType = productType;
            this.ProductSerialNumber = productSerialNumber;
            this.InvoiceNumber = invoiceNumber;
        }

    }
}
