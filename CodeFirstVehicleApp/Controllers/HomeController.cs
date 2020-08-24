using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstVehicleApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your car collection home!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us at anytime!";

            return View();
        }
    }
}