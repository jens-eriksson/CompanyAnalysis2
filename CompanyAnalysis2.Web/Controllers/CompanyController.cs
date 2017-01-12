using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyAnalysis2.ViewModels;

namespace CompanyAnalysis2.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            CompanyViewModel viewModel = new CompanyViewModel();
            return View(viewModel);
        }

        public ActionResult Company(int id)
        {
            return View();
        }
    }
}