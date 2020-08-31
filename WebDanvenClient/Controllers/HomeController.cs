using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDanvenClient.Models;

namespace WebDanvenClient.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Products() {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Product_view(int? id) {

            Product product = new Product();
            ViewBag.Message = "Your application description page.";
            if (id != null & id > 0) {
                ViewBag.Situation = id;
                switch (id) {
                    case 1:
                        product.Id = 1;
                        product.products.Add("T05-STD");
                        product.products.Add("T15-STD");
                        product.products.Add("T25-STD");

                        break;
                    case 2:
                        Console.WriteLine("Tuesday");
                        break;
                    case 3:
                        Console.WriteLine("Wednesday");
                        break;
                }
            }
            return View(product);
        }

        public ActionResult StandardSeries(int? id) { 
            ViewBag.Message = "Your application description page.";
            if (id != null & id > 0) {
                ViewBag.Situation = id;
                }           
            return View();
        }

        public ActionResult Eftersalgsservice() {
            ViewBag.Message = "Your application description page.";
            return View();

        }
        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}