using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebDanvenClient.ControlLayer;
using WebDanvenClient.Models;

namespace WebDanvenClient.Controllers
{
    public class EftersalgsserviceController : Controller
    {
        // GET: Eftersalgsservice
        public ActionResult Index()
        {
            return View();
        }

        //This method creats a new clientGenerator and calls the method CreateGenerator from ControlGenerator to save the generator in the database and the method SendMail to inform the administrative worker.
        //Param: an FormCollection object.
        //Return: Is a view.
        [HttpPost]
        public ActionResult Index(FormCollection collection) {
            ControlGenerator controlGenerator = new ControlGenerator();
            var values = new List<string>();
            for (int i = 0; i < collection.Keys.Count; i++) {
                string value = collection[collection.Keys[i].ToString()];
                if (value != null && value != "") {
                    values.Add(value);
                } else if (i==0||i==1||i==2||i==5||i==6||i==7||i==8||i==10||i==14) {                   
                        ViewBag.Message = "you should fill all the * options";
                         return View();
                } else {
                    values.Add(value);
                }                
            }
            if (ViewBag.Message == null) {
                ClientCustomer clientCustomer = new ClientCustomer() {
                    CompanyName = values[10],
                    CompanyAddress = values[11],
                    ContactPersonName = values[12],
                    Email = values[13],
                    Telephone = values[14]
                };

                ClientProduct clientProduct = new ClientProduct() {
                    ProductType = values[5],
                    ProductSerialNumber = values[6],
                    InvoiceNumber = values[7]
                };

                ClientGenerator clientGenerator = new ClientGenerator() {
                    TypeNumber = values[0],
                    SerialNumber = values[1],
                    RunningHours = values[2],
                    InstallationDate = values[3],
                    GeneratorApplication = values[4],
                    ErrorDescription = values[8],
                    AdditionalInformation = values[9],
                    Customer = clientCustomer,
                    Product = clientProduct
                };

                ClientGenerator insertGenerator= controlGenerator.CreateGenerator(clientGenerator);
                SendEmail(values);
                if (insertGenerator == null) {
                    ViewBag.Message = "Product type or Invoice number or Telephone No. is wrong, you should check and fill again!";
                    return View();
                }
            }
            return View("SubSuccess");
        }

        public ActionResult SubSuccess() {
            return View();
        }

        public ActionResult IndexCn() {
            return View();
        }

        //This method creats a new clientGenerator and calls the method CreateGenerator from ControlGenerator to save the generator in the database and the method SendMail to inform the administrative worker.
        //Param: an FormCollection object.
        //Return: Is a view.
        [HttpPost]
        public ActionResult IndexCn(FormCollection collection) {
            ControlGenerator controlGenerator = new ControlGenerator();
            var values = new List<string>();
            for (int i = 0; i < collection.Keys.Count; i++) {
                string value = collection[collection.Keys[i].ToString()];
                if (value != null && value != "") {
                    values.Add(value);
                } else if (i == 0 || i == 1 || i == 2 || i == 5 || i == 6 || i == 7 || i == 8 || i == 10 || i == 14) {
                    ViewBag.Message = "you should fill all the * options";
                    return View();
                } else {
                    values.Add(value);
                }
            }
            if (ViewBag.Message == null) {
                ClientCustomer clientCustomer = new ClientCustomer() {
                    CompanyName = values[10],
                    CompanyAddress = values[11],
                    ContactPersonName = values[12],
                    Email = values[13],
                    Telephone = values[14]
                };

                ClientProduct clientProduct = new ClientProduct() {
                    ProductType = values[5],
                    ProductSerialNumber = values[6],
                    InvoiceNumber = values[7]
                };

                ClientGenerator clientGenerator = new ClientGenerator() {
                    TypeNumber = values[0],
                    SerialNumber = values[1],
                    RunningHours = values[2],
                    InstallationDate = values[3],
                    GeneratorApplication = values[4],
                    ErrorDescription = values[8],
                    AdditionalInformation = values[9],
                    Customer = clientCustomer,
                    Product = clientProduct
                };

                ClientGenerator insertGenerator = controlGenerator.CreateGenerator(clientGenerator);
                //SendEmail(values);
                if (insertGenerator == null) {
                    ViewBag.Message = "Product type or Invoice number or Telephone No. is wrong, you should check and fill again!";
                    return View();
                }
            }
            return View("SubSuccessCn");
        }

        public ActionResult SubSuccessCn() {
            return View();
        }
        //This method send a email fra MailAddress"zcao16278@gmail.com" to "1074160@ucn.dk
        //Param: a list of string.
        public void SendEmail(List<string> values) {

            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            try {
                m.From = new MailAddress("zcao16278@gmail.com");
                m.To.Add("1074160@ucn.dk");
                m.Subject = "New repair application";
                m.IsBodyHtml = true;
                string text = $"1. Generator identification\n Type number:{values[0]}\n Serial number:{values[1]}\n Running hours:{values[2]}\n Installation date:{values[3]}\n Application:{values[4]}\n\n" +
                    $"2. Product identification\n  Product type:{values[5]}\n Serial number:{values[6]}\n  Invoice number:{values[7]}\n\n" +
                    $"3. Error description / reason for return\n {values[8]}\n\n" +
                    $"4. Additional information\n {values[9]}\n\n" +
                    $"5. Customer data\n Company name:{values[10]}\n  Address:{values[11]}\n Company contact:{values[12]}\n Email:{values[13]}\n Tel. (direct):{values[14]}\n\n";
                text = text.Replace("\n", "<br>");
                m.Body = text;

                sc.Host = "smtp.gmail.com";
                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential("zcao16278@gmail.com", "Sam4s4a4d");

                sc.EnableSsl = true;
                sc.Send(m);
                Response.Write("Email Send successfully");
            } catch (Exception ex) {
                Response.Write(ex.Message);
            }

        }
    }
}