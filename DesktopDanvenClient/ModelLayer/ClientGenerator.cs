using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDanvenClient.ModelLayer {
    public class ClientGenerator {
        public int Id { get; set; }
        public bool IsRepaired { get; set; }
        public string TypeNumber { get; set; }
        public string SerialNumber { get; set; }
        public string RunningHours { get; set; }
        public string InstallationDate { get; set; }
        public string GeneratorApplication { get; set; }
        public string ErrorDescription { get; set; }
        public string AdditionalInformation { get; set; }
        public ClientCustomer Customer { get; set; }
        public ClientProduct Product { get; set; }

        public ClientGenerator(string typeNumber, string serialNumber, string runningHours) {
            this.TypeNumber = typeNumber;
            this.SerialNumber = serialNumber;
            this.RunningHours = runningHours;
            this.IsRepaired = false;
        }

        public ClientGenerator() {
            this.IsRepaired = false;
        }
        public override string ToString() {
            return $"{Id}  {TypeNumber} Repaired:{IsRepaired}";
        }
    }
}
