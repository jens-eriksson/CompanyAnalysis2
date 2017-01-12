using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using CompanyAnalysis2.Model;
using CompanyAnalysis2.Calculations;

namespace CompanyAnalysis2.OData.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using CompanyAnalysis2.Model;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Company>("Companies");
    builder.EntitySet<Report>("Reports"); 
    builder.EntitySet<Stock>("Stocks"); 
    builder.EntitySet<User>("Users"); 
    builder.EntitySet<Estimate>("Estimates"); 
    builder.EntitySet<FinancialIndicator>("FinancialIndicators"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CompaniesController : ODataController
    {
        private CompanyAnalysis2Context db = new CompanyAnalysis2Context();

        // GET: odata/Companies
        [EnableQuery]
        public IQueryable<Company> GetCompanies()
        {
            return db.Companies;
        }

        // GET: odata/Companies(5)
        [EnableQuery]
        public SingleResult<Company> GetCompany([FromODataUri] int key)
        {
            return SingleResult.Create(db.Companies.Where(company => company.Id == key));
        }

        // PUT: odata/Companies(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Company> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Company company = db.Companies.Find(key);
            if (company == null)
            {
                return NotFound();
            }

            patch.Put(company);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(company);
        }

        // POST: odata/Companies
        public IHttpActionResult Post(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Companies.Add(company);
            db.SaveChanges();

            return Created(company);
        }

        // PATCH: odata/Companies(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Company> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Company company = db.Companies.Find(key);
            if (company == null)
            {
                return NotFound();
            }

            patch.Patch(company);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(company);
        }

        // DELETE: odata/Companies(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Company company = db.Companies.Find(key);
            if (company == null)
            {
                return NotFound();
            }

            db.Companies.Remove(company);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Companies(5)/Reports
        [EnableQuery]
        public IQueryable<Report> GetReports([FromODataUri] int key)
        {
            return db.Companies.Where(m => m.Id == key).SelectMany(m => m.Reports);
        }

        // GET: odata/Companies(5)/Stocks
        [EnableQuery]
        public IQueryable<Stock> GetStocks([FromODataUri] int key)
        {
            return db.Companies.Where(m => m.Id == key).SelectMany(m => m.Stocks);
        }

        // GET: odata/Companies(5)/Users
        [EnableQuery]
        public IQueryable<User> GetUsers([FromODataUri] int key)
        {
            return db.Companies.Where(m => m.Id == key).SelectMany(m => m.Users);
        }

        // GET: odata/Companies(5)/Estimates
        [EnableQuery]
        public IQueryable<Estimate> GetEstimates([FromODataUri] int key)
        {
            return db.Companies.Where(m => m.Id == key).SelectMany(m => m.Estimates);
        }

        // GET: odata/Companies(5)/FinancialIndicators
        [EnableQuery]
        public IQueryable<FinancialIndicator> GetFinancialIndicators([FromODataUri] int key)
        {
            return db.Companies.Where(m => m.Id == key).SelectMany(m => m.FinancialIndicators);
        }
        [HttpPost]
        [ODataRoute("CalculateFinacialInicators")]
        public IHttpActionResult CalculateFinacialInicators(ODataActionParameters parameters)
        {
            int companyId;
            object output;
            if (!parameters.TryGetValue("companyId", out output))
            {
                return NotFound();
            }

            if (!int.TryParse(output.ToString(), out companyId))
            {
                return NotFound();
            }

            FinancialIndicatorsCalculations calc = new FinancialIndicatorsCalculations();
            calc.Calculate(companyId);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpPost]
        [ODataRoute("CalculateFinacialInicatorsByPeriod")]
        public IHttpActionResult CalculateFinacialInicatorsByPeriod(ODataActionParameters parameters)
        {
            int companyId;
            int periodId;
            object output;
            if (!parameters.TryGetValue("companyId", out output))
            {
                return NotFound();
            }

            if (!int.TryParse(output.ToString(), out companyId))
            {
                return NotFound();
            }

            if (!parameters.TryGetValue("periodId", out output))
            {
                return NotFound();
            }

            if (!int.TryParse(output.ToString(), out periodId))
            {
                return NotFound();
            }

            FinancialIndicatorsCalculations calc = new FinancialIndicatorsCalculations();
            calc.Calculate(companyId, periodId);
            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int key)
        {
            return db.Companies.Count(e => e.Id == key) > 0;
        }
    }
}
