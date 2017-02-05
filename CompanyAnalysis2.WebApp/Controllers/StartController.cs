using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyAnalysis2.WebApp.Controllers
{
    public class StartController : Controller
    {
        [HttpGet]
        public ActionResult Start()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("index", "company");
            }
            else
            {
                return RedirectToAction("about", "start");
            }
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

    }
}
