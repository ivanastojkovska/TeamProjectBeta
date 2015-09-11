using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoTutorials.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserIndex()
        {
            return View();
        }

        public ActionResult AdminIndex()
        {
            return RedirectToAction("UnapprovedVideos", "Videos");
        }
    }
}