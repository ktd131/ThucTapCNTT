using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TTCNTT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session.Add("Quyen", "quyengiaovien");
            return View();
        }

        public ActionResult Intro()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}