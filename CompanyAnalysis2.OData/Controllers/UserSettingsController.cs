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
    builder.EntitySet<UserSetting>("UserSettings");
    builder.EntitySet<User>("Users"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class UserSettingsController : ODataController
    {
        private CompanyAnalysis2Context db = new CompanyAnalysis2Context();

        // GET: odata/UserSettings
        [EnableQuery]
        public IQueryable<UserSetting> GetUserSettings()
        {
            return db.UserSettings;
        }

        // GET: odata/UserSettings(5)
        [EnableQuery]
        public SingleResult<UserSetting> GetUserSetting([FromODataUri] int key)
        {
            return SingleResult.Create(db.UserSettings.Where(userSetting => userSetting.UserId == key));
        }

        // PUT: odata/UserSettings(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<UserSetting> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserSetting userSetting = db.UserSettings.Find(key);
            if (userSetting == null)
            {
                return NotFound();
            }

            patch.Put(userSetting);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSettingExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(userSetting);
        }

        // POST: odata/UserSettings
        public IHttpActionResult Post(UserSetting userSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserSettings.Add(userSetting);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserSettingExists(userSetting.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(userSetting);
        }

        // PATCH: odata/UserSettings(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<UserSetting> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserSetting userSetting = db.UserSettings.Find(key);
            if (userSetting == null)
            {
                return NotFound();
            }

            patch.Patch(userSetting);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSettingExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(userSetting);
        }

        // DELETE: odata/UserSettings(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            UserSetting userSetting = db.UserSettings.Find(key);
            if (userSetting == null)
            {
                return NotFound();
            }

            db.UserSettings.Remove(userSetting);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/UserSettings(5)/User
        [EnableQuery]
        public SingleResult<User> GetUser([FromODataUri] int key)
        {
            return SingleResult.Create(db.UserSettings.Where(m => m.UserId == key).Select(m => m.User));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserSettingExists(int key)
        {
            return db.UserSettings.Count(e => e.UserId == key) > 0;
        }
    }
}
