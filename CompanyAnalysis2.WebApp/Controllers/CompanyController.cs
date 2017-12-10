using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyAnalysis2.Model;
using CompanyAnalysis2.WebApp.ViewModels;

namespace CompanyAnalysis2.WebApp.Controllers
{
    public class CompanyController : Controller
    {
        private CompanyAnalysis2Context db
        {
            get
            {
                CompanyAnalysis2Context context = new CompanyAnalysis2Context();
                context.Configuration.LazyLoadingEnabled = true;
                return context;
            }
        }
        //
        // GET: /Company/

        public ActionResult Index(string sort, string sortOrder)
        {
            CompanyListViewModel companyList = new CompanyListViewModel();         
            return View(companyList);
        }

        //GET
        public ActionResult Details(int id)
        {
            Company company = db.Companies.Find(id);
            ViewBag.Periods = db.Periods.Where(p => p.EndDate < DateTime.Now).OrderByDescending(p => p.EndDate).Take(21).OrderBy(p => p.EndDate).ToList();

            MvcApplication app = (MvcApplication)HttpContext.ApplicationInstance;
            ViewBag.App = app;
            ViewBag.SelectedTab = "details";
            return View(company);
        }

         //GET: /Company/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated == false)
                return RedirectToAction("index", "company");

            MvcApplication app = (MvcApplication)HttpContext.ApplicationInstance;
            ViewBag.App = app;
            return View();
        }

        //
        // POST: /Company/Create

        [HttpPost]
        public ActionResult Create(Company company)
        {
            if (Request.IsAuthenticated == false)
                return RedirectToAction("index", "company");

            if (ModelState.IsValid)
            {
                CompanyAnalysis2Context context = db;
                Company existingCompany;

                if (context.Companies.Where(c => c.Hidden && c.Name == company.Name).Count() > 0)
                {
                    existingCompany = context.Companies.Where(c => c.Name == company.Name).First();
                    existingCompany.Hidden = false;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else if (context.Companies.Where(c => c.Hidden && c.YahooFinanceSymbol == company.YahooFinanceSymbol).Count() > 0)
                {
                    existingCompany = context.Companies.Where(c => c.YahooFinanceSymbol == company.YahooFinanceSymbol).First();
                    existingCompany.Name = company.Name;
                    existingCompany.Hidden = false;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    context.Companies.Add(company);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }

            return View(company);
        }

        //
        // GET: /Company/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (Request.IsAuthenticated == false)
                return RedirectToAction("details", new { id = id });

            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }

            ViewBag.ShowSaveConfirmation = false;
            ViewBag.SelectedTab = "edit";
            return View(company);
        }

        //
        // POST: /Company/Edit/5

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            if (Request.IsAuthenticated == false)
                return RedirectToAction("details", new { id = company.Id });

            if (ModelState.IsValid)
            {
                CompanyAnalysis2Context context = db;
                Company current = context.Companies.Find(company.Id);
                current.Name = company.Name;
                current.YahooFinanceSymbol = company.YahooFinanceSymbol;
                context.SaveChanges();
                ViewBag.ShowSaveConfirmation = true;
                ViewBag.SelectedTab = "edit";
                return View(company);
            }
            else
            {
                return RedirectToAction("details", new { id = company.Id });
            }
        }

        public void EditNextReportDate(int id, string nextReportDate)
        {
            CompanyAnalysis2Context context = db;
            Company company = context.Companies.Find(id);
            DateTime nextReport;
            if (DateTime.TryParse(nextReportDate, out nextReport) && company != null)
            {
                company.NextReportDate = nextReport;
                context.SaveChanges();

            }
            else if(company != null)
            {
                company.NextReportDate = null;
                context.SaveChanges();
            }
        }

       [HttpPost]
        public ActionResult Remove(int id)
        {
            if (Request.IsAuthenticated == false)
                return RedirectToAction("details", new { id = id });

            CompanyAnalysis2Context context = db;
            Company company = context.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            company.Hidden = true;
            context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (Request.IsAuthenticated == false)
                return RedirectToAction("details", new { id = id });

            CompanyAnalysis2Context context = db;
            Company company = context.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }

            foreach (Report report in context.Reports.Where(r => r.CompanyId == company.Id))
                context.Reports.Remove(report);
            foreach (User user in context.Users)
                user.StaredCompanies.Remove(company);

            context.Companies.Remove(company);

            context.SaveChanges();
            return RedirectToAction("index");
        }

        public void StarUnStarCompany(string email, int companyId)
        {
            CompanyAnalysis2Context context = db;
            User user = context.Users.Find(email);
            Company company = context.Companies.Find(companyId);
            if(user == null || company == null)
                return;

            Company stared = user.StaredCompanies.Where(c => c.Id == company.Id).FirstOrDefault();

            if (stared != null)
            {
                user.StaredCompanies.Remove(company);
            }
            else
            {
                user.StaredCompanies.Add(company);
            }

            context.SaveChanges();
        }

        public ActionResult ImportLog(int id)
        {
            CompanyAnalysis2Context ctx = new CompanyAnalysis2Context();
            Company company = ctx.Companies.Find(id);
            ViewBag.SelectedTab = "importlog";
            return View(company);
        }

        public ActionResult _Chart(string name, int companyId)
        {
            Company company = db.Companies.Find(companyId);
            ViewBag.Periods = db.Periods.Where(p => p.EndDate < DateTime.Now).OrderByDescending(p => p.EndDate).Take(21).OrderBy(p => p.EndDate).ToList();
            name = "Charts/" + name;
            
            return PartialView(name, company);
        }

        protected override void Dispose(bool disposing)
        {
            HttpContext.ApplicationInstance.CompleteRequest();
            base.Dispose(disposing);
        }
    }
}