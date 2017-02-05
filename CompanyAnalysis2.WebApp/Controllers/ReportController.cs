using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyAnalysis2.Model;
using CompanyAnalysis2.WebApp.Util;

namespace CompanyAnalysis2.WebApp.Controllers
{
    public class ReportController : Controller
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
        // GET: /Report/

        public ActionResult Index(int cid, bool? showListLinks=true)
        {
            Company company = db.Companies.Find(cid);

            ViewBag.ShowListLinks = showListLinks;
            ViewBag.Periods = db.Periods.Where(p => p.EndDate < DateTime.Now).OrderByDescending(p => p.EndDate).ToList();
            ViewBag.SelectedTab = "reports";
            return View(company);
        }

        //
        // GET: /Report/Create

        public ActionResult Create(int cid, int pid)
        {
            if (Request.IsAuthenticated == false)
                return RedirectToAction("index", new { cid = cid });
            Report report = new Report();
            report.Company = db.Companies.Find(cid);
            report.Period = db.Periods.Find(pid);

            report.CompanyId = report.Company.Id;
            report.PeriodId = report.Period.Id;
            ViewBag.SelectedTab = "reports";

            return View(report);
        }

        //
        // POST: /Report/Create

        [HttpPost]
        public ActionResult Create(Report report)
        {
            if (Request.IsAuthenticated == false)
                return RedirectToAction("index", new { cid = report.CompanyId });

            CompanyAnalysis2Context context = db;
            report.Company = context.Companies.Find(report.CompanyId);
            report.Period = context.Periods.Find(report.PeriodId);

            context.SaveChanges();
            return RedirectToAction("index", new { cid = report.CompanyId });

        }

        public ActionResult Import(int cid)
        {
            if (Request.IsAuthenticated == false)
                return RedirectToAction("index", new { cid = cid });
            return View(db.Companies.Find(cid));
        }

        //
        // POST: /Report/Create

        [HttpPost]
        public ActionResult Import(int cid, HttpPostedFileBase fileUpload)
        {
            if (Request.IsAuthenticated == false)
                return RedirectToAction("index", new { cid = cid });
            ExcelImport.ImportReports(cid, fileUpload);
            return RedirectToAction("Index", new { cid = cid });
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            CompanyAnalysis2Context context = db;
            Report report = context.Reports.Find(id);
            context.Reports.Remove(report);
            context.SaveChanges();
            return RedirectToAction("index", new {cid=report.CompanyId});
        }

        //
        // GET: /Report/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAuthenticated == false)
                return RedirectToAction("index", new { cid = report.CompanyId });
            return View(report);
        }

        //
        // POST: /Report/Edit/5

        [HttpPost]
        public ActionResult Edit(Report report)
        {
            if (Request.IsAuthenticated == false)
                return RedirectToAction("index", new { cid = report.CompanyId });

            if (ModelState.IsValid && Request["stockprice"] != "")
            {
                CompanyAnalysis2Context context = db;
                Report current = context.Reports.Find(report.Id);
                current.Assets = report.Assets;
                current.Equity = report.Equity;
                current.NetIncome = report.NetIncome;
                current.Revenue = report.Revenue;
                current.CEO = report.CEO;
               
                context.SaveChanges();
                return RedirectToAction("Index", new { cid=current.CompanyId });
            }
            ViewBag.SelectedTab = "reports";
            return View(report);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}