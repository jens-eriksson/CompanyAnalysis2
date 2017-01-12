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
    builder.EntitySet<StockQuote>("StockQuotes");
    builder.EntitySet<Stock>("Stocks"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class StockQuotesController : ODataController
    {
        private CompanyAnalysis2Context db = new CompanyAnalysis2Context();

        // GET: odata/StockQuotes
        [EnableQuery]
        public IQueryable<StockQuote> GetStockQuotes()
        {
            return db.StockQuotes;
        }

        // GET: odata/StockQuotes(5)
        [EnableQuery]
        public SingleResult<StockQuote> GetStockQuote([FromODataUri] DateTime key)
        {
            return SingleResult.Create(db.StockQuotes.Where(stockQuote => stockQuote.Date == key));
        }

        // PUT: odata/StockQuotes(5)
        public IHttpActionResult Put([FromODataUri] DateTime key, Delta<StockQuote> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StockQuote stockQuote = db.StockQuotes.Find(key);
            if (stockQuote == null)
            {
                return NotFound();
            }

            patch.Put(stockQuote);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockQuoteExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(stockQuote);
        }

        // POST: odata/StockQuotes
        public IHttpActionResult Post(StockQuote stockQuote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StockQuotes.Add(stockQuote);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StockQuoteExists(stockQuote.Date))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(stockQuote);
        }

        // PATCH: odata/StockQuotes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] DateTime key, Delta<StockQuote> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StockQuote stockQuote = db.StockQuotes.Find(key);
            if (stockQuote == null)
            {
                return NotFound();
            }

            patch.Patch(stockQuote);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockQuoteExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(stockQuote);
        }

        // DELETE: odata/StockQuotes(5)
        public IHttpActionResult Delete([FromODataUri] DateTime key)
        {
            StockQuote stockQuote = db.StockQuotes.Find(key);
            if (stockQuote == null)
            {
                return NotFound();
            }

            db.StockQuotes.Remove(stockQuote);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/StockQuotes(5)/Stock
        [EnableQuery]
        public SingleResult<Stock> GetStock([FromODataUri] DateTime key)
        {
            return SingleResult.Create(db.StockQuotes.Where(m => m.Date == key).Select(m => m.Stock));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StockQuoteExists(DateTime key)
        {
            return db.StockQuotes.Count(e => e.Date == key) > 0;
        }
    }
}
