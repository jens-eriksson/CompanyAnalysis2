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

namespace CompanyAnalysis2.OData.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using CompanyAnalysis2.Model;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Period>("Periods");
    builder.EntitySet<Report>("Reports"); 
    builder.EntitySet<Estimate>("Estimates"); 
    builder.EntitySet<FinancialIndicator>("FinancialIndicators"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PeriodsController : ODataController
    {
        private CompanyAnalysis2Context db = new CompanyAnalysis2Context();

        // GET: odata/Periods
        [EnableQuery]
        public IQueryable<Period> GetPeriods()
        {
            return db.Periods;
        }

        // GET: odata/Periods(5)
        [EnableQuery]
        public SingleResult<Period> GetPeriod([FromODataUri] int key)
        {
            return SingleResult.Create(db.Periods.Where(period => period.Id == key));
        }

        // PUT: odata/Periods(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Period> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Period period = db.Periods.Find(key);
            if (period == null)
            {
                return NotFound();
            }

            patch.Put(period);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(period);
        }

        // POST: odata/Periods
        public IHttpActionResult Post(Period period)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Periods.Add(period);
            db.SaveChanges();

            return Created(period);
        }

        // PATCH: odata/Periods(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Period> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Period period = db.Periods.Find(key);
            if (period == null)
            {
                return NotFound();
            }

            patch.Patch(period);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(period);
        }

        // DELETE: odata/Periods(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Period period = db.Periods.Find(key);
            if (period == null)
            {
                return NotFound();
            }

            db.Periods.Remove(period);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Periods(5)/Reports
        [EnableQuery]
        public IQueryable<Report> GetReports([FromODataUri] int key)
        {
            return db.Periods.Where(m => m.Id == key).SelectMany(m => m.Reports);
        }

        // GET: odata/Periods(5)/Estimates
        [EnableQuery]
        public IQueryable<Estimate> GetEstimates([FromODataUri] int key)
        {
            return db.Periods.Where(m => m.Id == key).SelectMany(m => m.Estimates);
        }

        // GET: odata/Periods(5)/FinancialIndicators
        [EnableQuery]
        public IQueryable<FinancialIndicator> GetFinancialIndicators([FromODataUri] int key)
        {
            return db.Periods.Where(m => m.Id == key).SelectMany(m => m.FinancialIndicators);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeriodExists(int key)
        {
            return db.Periods.Count(e => e.Id == key) > 0;
        }
    }
}
