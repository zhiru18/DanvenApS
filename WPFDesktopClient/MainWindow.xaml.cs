using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFDesktopClient.ControlLayer;
using WPFDesktopClient.ModelLayer;

namespace WPFDesktopClient {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private GeneratorController generatorController;
        public MainWindow() {
            InitializeComponent();
            generatorController = new GeneratorController();
            UpdateTable();
            repCombox.Items.Add("True");
            repCombox.Items.Add("False");
        }

        private void UpdateTable() {
            var allGenerators = generatorController.GetAll();
           repairedGenData.Items.Clear();
            foreach (ClientGenerator cg in allGenerators) {
                repairedGenData.Items.Add(cg);
            }
        }

        private void repairedGenData_SelectionChanged(object sender, SelectionChangedEventArgs e) {    
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            if (row != null) {
                UpLabel.Content = "";
                DataGridCell RowColumn0 = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                DataGridCell RowColumn1 = dataGrid.Columns[1].GetCellContent(row).Parent as DataGridCell;
                DataGridCell RowColumn2 = dataGrid.Columns[2].GetCellContent(row).Parent as DataGridCell;
                string id = ((TextBlock)RowColumn0.Content).Text;
                int generatorId = Int32.Parse(id);
                ClientGenerator clientGenerator = generatorController.GetById(generatorId);
                genId.Text = id;
                repCombox.Text = ((TextBlock)RowColumn2.Content).Text;
                typNr.Text = ((TextBlock)RowColumn1.Content).Text;
                serNr.Text = clientGenerator.SerialNumber;
                runH.Text = clientGenerator.RunningHours;
                instDa.Text = clientGenerator.InstallationDate;
                appl.Text = clientGenerator.GeneratorApplication;
                erDes.Text = clientGenerator.ErrorDescription;
                add.Text = clientGenerator.AdditionalInformation;
                proId.Text = clientGenerator.Product.Id + "";
                proTy.Text = clientGenerator.Product.ProductType;
                proSerNr.Text = clientGenerator.Product.ProductSerialNumber;
                invNr.Text = clientGenerator.Product.InvoiceNumber;
                cumId.Text = clientGenerator.Customer.Id + "";
                comNa.Text = clientGenerator.Customer.CompanyName;
                addr.Text = clientGenerator.Customer.CompanyAddress;
                comCon.Text = clientGenerator.Customer.ContactPersonName;
                email.Text = clientGenerator.Customer.Email;
                telep.Text = clientGenerator.Customer.Telephone;
            }
        }

        private void upBtn_Click(object sender, RoutedEventArgs e) {
            if (genId.Text != "") {
                ClientCustomer clientCustomer = new ClientCustomer {
                    Id = Int32.Parse(cumId.Text),
                    CompanyName = comNa.Text,
                    CompanyAddress = addr.Text,
                    ContactPersonName = comCon.Text,
                    Email = email.Text,
                    Telephone = telep.Text
                };

                ClientProduct clientProduct = new ClientProduct {
                    Id = Int32.Parse(proId.Text),
                    ProductType = proTy.Text,
                    ProductSerialNumber = proSerNr.Text,
                    InvoiceNumber = invNr.Text
                };

                ClientGenerator clientGenerator = new ClientGenerator {
                    Id = Int32.Parse(genId.Text),
                    IsRepaired = bool.Parse(repCombox.Text),
                    TypeNumber = typNr.Text,
                    SerialNumber = serNr.Text,
                    RunningHours = runH.Text,
                    InstallationDate = instDa.Text,
                    GeneratorApplication = appl.Text,
                    ErrorDescription = erDes.Text,
                    AdditionalInformation = add.Text,
                    Customer = clientCustomer,
                    Product = clientProduct
                };
                ClientGenerator generator = generatorController.UpdateGenerator(clientGenerator);
                if (generator != null) {
                    UpLabel.Foreground = Brushes.Green;
                    UpLabel.Content = "Generator is upadteded " + "Generator Id:" + generator.Id + "Generator Type:" + generator.TypeNumber + clientGenerator.IsRepaired.ToString();
                    UpdateTable();
                } else {
                    UpLabel.Foreground = Brushes.Red;
                    UpLabel.Content = "Input valid Generator Id or Product Id or Customer Id!";
                }             
            } else {
                UpLabel.Foreground = Brushes.Red;
                UpLabel.Content = "Input valid Generator Id or Product Id or Customer Id!";
            }
        }
    }
 }

