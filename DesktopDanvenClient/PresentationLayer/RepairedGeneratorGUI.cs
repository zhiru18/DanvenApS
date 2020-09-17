using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopDanvenClient.ControlLayer;
using DesktopDanvenClient.ModelLayer;

namespace DesktopDanvenClient {
    public partial class Form1 : Form {
        private GeneratorController generatorController;
        public Form1() {
            InitializeComponent();
            generatorController = new GeneratorController();
            UpdateGeneratorListBox();
            ReComboBox.Items.Add("True");
            ReComboBox.Items.Add("False");

        }

        private void UpdateGeneratorListBox() {
            var allGenerators = generatorController.GetAll();
           RepairedGeneratorListBox.Items.Clear();
            foreach (ClientGenerator cg in allGenerators) {
                RepairedGeneratorListBox.Items.Add(cg);
            }
        }

        private void generatorListBox_SelectedIndexChanged(object sender, EventArgs e) {
            UpLabel.Text = "";
            string generatorText = RepairedGeneratorListBox.Text;
            string id = generatorText.Substring(0, 2);
            int generatorId = Int32.Parse(id);
            ClientGenerator clientGenerator = generatorController.GetById(generatorId);
            GIdTextBox.Text = clientGenerator.Id+"";
            ReComboBox.Text = clientGenerator.IsRepaired.ToString();
            GTyTextBox.Text = clientGenerator.TypeNumber;
            GSNTextBox.Text = clientGenerator.SerialNumber;
            GRHTextBox.Text = clientGenerator.RunningHours;
            ISDTextBox.Text = clientGenerator.InstallationDate;
            APTextBox.Text = clientGenerator.GeneratorApplication;
            PIdTextBox.Text = clientGenerator.Product.Id + "";
            PTTextBox.Text = clientGenerator.Product.ProductType;
            PSNTextBox.Text = clientGenerator.Product.ProductSerialNumber;
            InvTextBox.Text = clientGenerator.Product.InvoiceNumber;
            ErDTextBox.Text = clientGenerator.ErrorDescription;
            AdtTextBox.Text = clientGenerator.AdditionalInformation;
            CIdTextBox.Text = clientGenerator.Customer.Id + "";
            CNTextBox.Text = clientGenerator.Customer.CompanyName;
            AddTextBox.Text = clientGenerator.Customer.CompanyAddress;
            ContTextBox.Text = clientGenerator.Customer.ContactPersonName;
            EmTextBox.Text = clientGenerator.Customer.Email;
            TelTextBox.Text = clientGenerator.Customer.Telephone;
        }    
    }
}
