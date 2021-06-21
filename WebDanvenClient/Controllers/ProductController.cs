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
                        product.Id = 2;
                        product.Name = "Low chlorine series";
                        product.products.Add("T05-LC");
                        product.products.Add("T15-LC");
                        product.products.Add("T25-LC");
                        break;
                    case 3:
                        product.Id = 3;
                        product.Name = "Horticultural series";
                        product.products.Add("T15-HC");
                        product.products.Add("T25-HC");
                        break;
                }
            } else {
                ViewBag.Situation = 0;
            }
                return View(product);
        }
        public ActionResult IndexCn(int? id) {
            Product product = new Product();
            ViewBag.Message = "Your application description page.";
            if (id != null & id > 0) {
                ViewBag.Situation = id;
                switch (id) {
                    case 1:
                        product.Id = 1;
                        product.Name = "标准系列";
                        product.products.Add("T05-STD");
                        product.products.Add("T15-STD");
                        product.products.Add("T25-STD");

                        break;
                    case 2:
                        product.Id = 2;
                        product.Name = "低氮系列";
                        product.products.Add("T05-LC");
                        product.products.Add("T15-LC");
                        product.products.Add("T25-LC");
                        break;
                    case 3:
                        product.Id = 3;
                        product.Name = "园艺系列";
                        product.products.Add("T15-HC");
                        product.products.Add("T25-HC");
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

        public ActionResult LowChlorineSeries(int? id) {
            ViewBag.Message = "Your application description page.";
            if (id != null & id > 0) {
                ViewBag.Situation = id;
            }
            return View();
        }

        public ActionResult HorticulturalSeries(int? id) {
            ViewBag.Message = "Your application description page.";
            if (id != null & id > 0) {
                ViewBag.Situation = id;
            }
            return View();
        }
        public ActionResult StandardSeriesCn(int? id) {
            ViewBag.Message = "Your application description page.";
            if (id != null & id > 0) {
                ViewBag.Situation = id;
            }
            return View();
        }

        public ActionResult LowChlorineSeriesCn(int? id) {
            ViewBag.Message = "Your application description page.";
            if (id != null & id > 0) {
                ViewBag.Situation = id;
            }
            return View();
        }

        public ActionResult HorticulturalSeriesCn(int? id) {
            ViewBag.Message = "Your application description page.";
            if (id != null & id > 0) {
                ViewBag.Situation = id;
            }
            return View();
        }
    }
}