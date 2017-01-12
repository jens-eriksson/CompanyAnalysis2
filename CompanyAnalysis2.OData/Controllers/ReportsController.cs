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
    builder.EntitySet<Report>("Reports");
    builder.EntitySet<Company>("Companies"); 
    builder.EntitySet<Period>("Periods"); 
    builder.EntitySet<User>("Users"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ReportsController : ODataController
    {
        private CompanyAnalysis2Context db = new CompanyAnalysis2Context();

        // GET: odata/Reports
        [EnableQuery]
        public IQueryable<Report> GetReports()
        {
            return db.Reports;
        }

        // GET: odata/Reports(5)
        [EnableQuery]
        public SingleResult<Report> GetReport([FromODataUri] int key)
        {
            return SingleResult.Create(db.Reports.Where(report => report.Id == key));
        }

        // PUT: odata/Reports(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Report> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Report report = db.Reports.Find(key);
            if (report == null)
            {
                return NotFound();
            }

            patch.Put(report);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(report);
        }

        // POST: odata/Reports
        public IHttpActionResult Post(Report report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reports.Add(report);
            db.SaveChanges();

            return Created(report);
        }

        // PATCH: odata/Reports(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Report> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Report report = db.Reports.Find(key);
            if (report == null)
            {
                return NotFound();
            }

            patch.Patch(report);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(report);
        }

        // DELETE: odata/Reports(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Report report = db.Reports.Find(key);
            if (report == null)
            {
                return NotFound();
            }

            db.Reports.Remove(report);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Reports(5)/Company
        [EnableQuery]
        public SingleResult<Company> GetCompany([FromODataUri] int key)
        {
            return SingleResult.Create(db.Reports.Where(m => m.Id == key).Select(m => m.Company));
        }

        // GET: odata/Reports(5)/Period
        [EnableQuery]
        public SingleResult<Period> GetPeriod([FromODataUri] int key)
        {
            return SingleResult.Create(db.Reports.Where(m => m.Id == key).Select(m => m.Period));
        }

        // GET: odata/Reports(5)/CreatedBy
        [EnableQuery]
        public SingleResult<User> GetCreatedBy([FromODataUri] int key)
        {
            return SingleResult.Create(db.Reports.Where(m => m.Id == key).Select(m => m.CreatedBy));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReportExists(int key)
        {
            return db.Reports.Count(e => e.Id == key) > 0;
        }
    }
}
