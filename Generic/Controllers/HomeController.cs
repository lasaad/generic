using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;

namespace Generic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.GoogleApiKey = WebConfigurationManager.AppSettings["ApiGoogleKey"];
            ViewBag.locX = "46.414382";
            ViewBag.locY = "10.013988";
            ViewBag.heading = "210";
            ViewBag.pitch = "10";
            ViewBag.fov = "35";

            return View();
        }
    }
}