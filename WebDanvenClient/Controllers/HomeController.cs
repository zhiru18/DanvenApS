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

        public ActionResult StandardSeries(int? id) { 
            ViewBag.Message = "Your application description page.";
            if (id != null & id > 0) {
                ViewBag.Situation = id;
                }           
            return View();
        }

        public ActionResult Eftersalgsservice(int? id) {
            ViewBag.Message = "Your application description page.";
            if (id != null & id > 0) {
                ViewBag.Situation = id;
            } else {
                ViewBag.Situation = 0;
            }
            return View();
        }
        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}