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
    builder.EntitySet<User>("Users");
    builder.EntitySet<Report>("Reports"); 
    builder.EntitySet<UserSetting>("UserSettings"); 
    builder.EntitySet<Company>("Companies"); 
    builder.EntitySet<Estimate>("Estimates"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class UsersController : ODataController
    {
        private CompanyAnalysis2Context db = new CompanyAnalysis2Context();

        // GET: odata/Users
        [EnableQuery]
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: odata/Users(5)
        [EnableQuery]
        public SingleResult<User> GetUser([FromODataUri] int key)
        {
            return SingleResult.Create(db.Users.Where(user => user.Id == key));
        }

        // PUT: odata/Users(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<User> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = db.Users.Find(key);
            if (user == null)
            {
                return NotFound();
            }

            patch.Put(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(user);
        }

        // POST: odata/Users
        public IHttpActionResult Post(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return Created(user);
        }

        // PATCH: odata/Users(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<User> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = db.Users.Find(key);
            if (user == null)
            {
                return NotFound();
            }

            patch.Patch(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(user);
        }

        // DELETE: odata/Users(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            User user = db.Users.Find(key);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Users(5)/Reports
        [EnableQuery]
        public IQueryable<Report> GetReports([FromODataUri] int key)
        {
            return db.Users.Where(m => m.Id == key).SelectMany(m => m.CreatedReports);
        }

        // GET: odata/Users(5)/UserSettings
        [EnableQuery]
        public IQueryable<UserSetting> GetUserSettings([FromODataUri] int key)
        {
            return db.Users.Where(m => m.Id == key).SelectMany(m => m.UserSettings);
        }

        // GET: odata/Users(5)/Companies
        [EnableQuery]
        public IQueryable<Company> GetCompanies([FromODataUri] int key)
        {
            return db.Users.Where(m => m.Id == key).SelectMany(m => m.StaredCompanies);
        }

        // GET: odata/Users(5)/Estimates
        [EnableQuery]
        public IQueryable<Estimate> GetEstimates([FromODataUri] int key)
        {
            return db.Users.Where(m => m.Id == key).SelectMany(m => m.Estimates);
        }

        [HttpPost]
        public IHttpActionResult CreateRef(int key, string navigationProperty, [FromBody] Uri link)
        {
            int relatedKey = Helpers.GetKeyFromUri<int>(Request, link);
            return CreateRef(key, relatedKey, navigationProperty);
        }

        [HttpPost]
        public IHttpActionResult CreateRef(int key, int relatedKey, string navigationProperty)
        {
            var user = db.Users.SingleOrDefault(u => u.Id == key);
            if (user == null)
            {
                return NotFound();
            }
            switch (navigationProperty)
            {
                case "StaredCompanies":
                    var company = db.Companies.SingleOrDefault(c => c.Id == relatedKey);
                    if (company == null)
                    {
                        return NotFound();
                    }
                    user.StaredCompanies.Add(company);
                    break;
                case "CreatedReports":
                    var report = db.Reports.SingleOrDefault(r => r.Id == relatedKey);
                    if (report == null)
                    {
                        return NotFound();
                    }
                    user.CreatedReports.Add(report);
                    break;
                case "Estimates":
                    var estimate = db.Estimates.SingleOrDefault(e => e.Id == relatedKey);
                    if (estimate == null)
                    {
                        return NotFound();
                    }
                    user.Estimates.Add(estimate);
                    break;
                default:
                    return StatusCode(HttpStatusCode.NotImplemented);
            }
            db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteRef(int key, string navigationProperty, [FromBody] Uri link)
        {
            int relatedKey = Helpers.GetKeyFromUri<int>(Request, link);
            return DeleteRef(key, relatedKey, navigationProperty);
        }

        [HttpDelete]
        public IHttpActionResult DeleteRef(int key, int relatedKey, string navigationProperty)
        {
            var user = db.Users.SingleOrDefault(u => u.Id == key);
            if (user == null)
            {
                return NotFound();
            }
            switch (navigationProperty)
            {
                case "StaredCompanies":
                    var company = db.Companies.SingleOrDefault(c => c.Id == relatedKey);
                    if (company == null)
                    {
                        return NotFound();
                    }
                    user.StaredCompanies.Remove(company);
                    break;
                case "CreatedReports":
                    var report = db.Reports.SingleOrDefault(r => r.Id == relatedKey);
                    if (report == null)
                    {
                        return NotFound();
                    }
                    user.CreatedReports.Remove(report);
                    break;
                case "Estimates":
                    var estimate = db.Estimates.SingleOrDefault(e => e.Id == relatedKey);
                    if (estimate == null)
                    {
                        return NotFound();
                    }
                    user.Estimates.Remove(estimate);
                    break;
                default:
                    return StatusCode(HttpStatusCode.NotImplemented);
            }
            db.SaveChangesAsync();
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

        private bool UserExists(int key)
        {
            return db.Users.Count(e => e.Id == key) > 0;
        }
    }
}
