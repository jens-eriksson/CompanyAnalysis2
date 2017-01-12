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
    builder.EntitySet<Estimate>("Estimates");
    builder.EntitySet<Company>("Companies"); 
    builder.EntitySet<Period>("Periods"); 
    builder.EntitySet<User>("Users"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EstimatesController : ODataController
    {
        private CompanyAnalysis2Context db = new CompanyAnalysis2Context();

        // GET: odata/Estimates
        [EnableQuery]
        public IQueryable<Estimate> GetEstimates()
        {
            return db.Estimates;
        }

        // GET: odata/Estimates(5)
        [EnableQuery]
        public SingleResult<Estimate> GetEstimate([FromODataUri] int key)
        {
            return SingleResult.Create(db.Estimates.Where(estimate => estimate.Id == key));
        }

        // PUT: odata/Estimates(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Estimate> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Estimate estimate = db.Estimates.Find(key);
            if (estimate == null)
            {
                return NotFound();
            }

            patch.Put(estimate);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstimateExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(estimate);
        }

        // POST: odata/Estimates
        public IHttpActionResult Post(Estimate estimate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estimates.Add(estimate);
            db.SaveChanges();

            return Created(estimate);
        }

        // PATCH: odata/Estimates(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Estimate> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Estimate estimate = db.Estimates.Find(key);
            if (estimate == null)
            {
                return NotFound();
            }

            patch.Patch(estimate);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstimateExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(estimate);
        }

        // DELETE: odata/Estimates(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Estimate estimate = db.Estimates.Find(key);
            if (estimate == null)
            {
                return NotFound();
            }

            db.Estimates.Remove(estimate);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Estimates(5)/Company
        [EnableQuery]
        public SingleResult<Company> GetCompany([FromODataUri] int key)
        {
            return SingleResult.Create(db.Estimates.Where(m => m.Id == key).Select(m => m.Company));
        }

        // GET: odata/Estimates(5)/Period
        [EnableQuery]
        public SingleResult<Period> GetPeriod([FromODataUri] int key)
        {
            return SingleResult.Create(db.Estimates.Where(m => m.Id == key).Select(m => m.Period));
        }

        // GET: odata/Estimates(5)/User
        [EnableQuery]
        public SingleResult<User> GetUser([FromODataUri] int key)
        {
            return SingleResult.Create(db.Estimates.Where(m => m.Id == key).Select(m => m.User));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstimateExists(int key)
        {
            return db.Estimates.Count(e => e.Id == key) > 0;
        }
    }
}
