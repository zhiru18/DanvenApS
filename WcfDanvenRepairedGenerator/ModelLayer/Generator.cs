using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfDanvenRepairedGenerator.ModelLayer {
    [DataContract]
    public class Generator {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string TypeNumber { get; set; }
        [DataMember]
        public string SerialNumber { get; set; }
        [DataMember]
        public string RunningHours { get; set; }
        [DataMember]
        public string InstallationDate { get; set; }
        [DataMember]
        public string GeneratorApplication { get; set; }
        [DataMember]
        public string ErrorDescription { get; set; }
        [DataMember]
        public string AdditionalInformation { get; set; }
        [DataMember]
        public Customer Customer { get; set; }
        [DataMember]
        public Product product { get; set; }

        public Generator(string typeNumber, string serialNumber, string runningHours) {
            this.TypeNumber = typeNumber;
            this.SerialNumber = serialNumber;
            this.RunningHours = runningHours;
        }
    }
}
