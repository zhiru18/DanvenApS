using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Index(string typeNumber) {
            if (typeNumber != null && typeNumber != "") {
                ViewBag.Message = "successful";
                return View();
            }
            else {
               ViewBag.Message ="you should fill all the * options";
                return View();
            }
        }
    }
}