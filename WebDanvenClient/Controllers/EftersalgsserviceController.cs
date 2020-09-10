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
        public ActionResult Index(FormCollection collection) {
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
            return View("SubSuccess");
        }

        public ActionResult SubSuccess() {
            return View();
        }
    }
}