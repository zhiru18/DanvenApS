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

        }

      
    }
}
