using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDanvenClient.Models;

namespace WebDanvenClient.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index(int? id)
        {
            Product product = new Product();
            ViewBag.Message = "Your application description page.";
            if (id != null & id > 0) {
                ViewBag.Situation = id;
                switch (id) {
                    case 1:
                        product.Id = 1;
                        product.Name = "Standard series";
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
            } else {
                ViewBag.Situation = 0;
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
    }
}