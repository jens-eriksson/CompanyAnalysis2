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
    builder.EntitySet<FinancialIndicator>("FinancialIndicators");
    builder.EntitySet<Company>("Companies"); 
    builder.EntitySet<Period>("Periods"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class FinancialIndicatorsController : ODataController
    {
        private CompanyAnalysis2Context db = new CompanyAnalysis2Context();

        // GET: odata/FinancialIndicators
        [EnableQuery]
        public IQueryable<FinancialIndicator> GetFinancialIndicators()
        {
            return db.FinancialIndicators;
        }

        // GET: odata/FinancialIndicators(5)
        [EnableQuery]
        public SingleResult<FinancialIndicator> GetFinancialIndicator([FromODataUri] int key)
        {
            return SingleResult.Create(db.FinancialIndicators.Where(financialIndicator => financialIndicator.Id == key));
        }

        // PUT: odata/FinancialIndicators(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<FinancialIndicator> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FinancialIndicator financialIndicator = db.FinancialIndicators.Find(key);
            if (financialIndicator == null)
            {
                return NotFound();
            }

            patch.Put(financialIndicator);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialIndicatorExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(financialIndicator);
        }

        // POST: odata/FinancialIndicators
        public IHttpActionResult Post(FinancialIndicator financialIndicator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FinancialIndicators.Add(financialIndicator);
            db.SaveChanges();

            return Created(financialIndicator);
        }

        // PATCH: odata/FinancialIndicators(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<FinancialIndicator> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FinancialIndicator financialIndicator = db.FinancialIndicators.Find(key);
            if (financialIndicator == null)
            {
                return NotFound();
            }

            patch.Patch(financialIndicator);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialIndicatorExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(financialIndicator);
        }

        // DELETE: odata/FinancialIndicators(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            FinancialIndicator financialIndicator = db.FinancialIndicators.Find(key);
            if (financialIndicator == null)
            {
                return NotFound();
            }

            db.FinancialIndicators.Remove(financialIndicator);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/FinancialIndicators(5)/Company
        [EnableQuery]
        public SingleResult<Company> GetCompany([FromODataUri] int key)
        {
            return SingleResult.Create(db.FinancialIndicators.Where(m => m.Id == key).Select(m => m.Company));
        }

        // GET: odata/FinancialIndicators(5)/Period
        [EnableQuery]
        public SingleResult<Period> GetPeriod([FromODataUri] int key)
        {
            return SingleResult.Create(db.FinancialIndicators.Where(m => m.Id == key).Select(m => m.Period));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FinancialIndicatorExists(int key)
        {
            return db.FinancialIndicators.Count(e => e.Id == key) > 0;
        }
    }
}
