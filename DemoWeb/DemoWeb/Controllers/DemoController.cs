using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWeb.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateStep()
        {
            return View();
        }


        public string ChaoMung()
        {
            return "Chao mung den voi web";
        }
    }
}