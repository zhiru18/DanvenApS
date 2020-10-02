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

        public void SendEmail(List<string> values) {
          
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            try {
                m.From = new MailAddress("zcao16278@gmail.com");
                m.To.Add("1074160@ucn.dk");
                m.Subject = "This is a Test Mail";
                m.IsBodyHtml = true;
                m.Body = $"{values[0]}  {values[1]} ";
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