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
    builder.EntitySet<Stock>("Stocks");
    builder.EntitySet<Company>("Companies"); 
    builder.EntitySet<StockQuote>("StockQuotes"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class StocksController : ODataController
    {
        private CompanyAnalysis2Context db = new CompanyAnalysis2Context();

        // GET: odata/Stocks
        [EnableQuery]
        public IQueryable<Stock> GetStocks()
        {
            return db.Stocks;
        }

        // GET: odata/Stocks(5)
        [EnableQuery]
        public SingleResult<Stock> GetStock([FromODataUri] int key)
        {
            return SingleResult.Create(db.Stocks.Where(stock => stock.Id == key));
        }

        // PUT: odata/Stocks(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Stock> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Stock stock = db.Stocks.Find(key);
            if (stock == null)
            {
                return NotFound();
            }

            patch.Put(stock);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(stock);
        }

        // POST: odata/Stocks
        public IHttpActionResult Post(Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stocks.Add(stock);
            db.SaveChanges();

            return Created(stock);
        }

        // PATCH: odata/Stocks(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Stock> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Stock stock = db.Stocks.Find(key);
            if (stock == null)
            {
                return NotFound();
            }

            patch.Patch(stock);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(stock);
        }

        // DELETE: odata/Stocks(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Stock stock = db.Stocks.Find(key);
            if (stock == null)
            {
                return NotFound();
            }

            db.Stocks.Remove(stock);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Stocks(5)/Company
        [EnableQuery]
        public SingleResult<Company> GetCompany([FromODataUri] int key)
        {
            return SingleResult.Create(db.Stocks.Where(m => m.Id == key).Select(m => m.Company));
        }

        // GET: odata/Stocks(5)/StockQuotes
        [EnableQuery]
        public IQueryable<StockQuote> GetStockQuotes([FromODataUri] int key)
        {
            return db.Stocks.Where(m => m.Id == key).SelectMany(m => m.StockQuotes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StockExists(int key)
        {
            return db.Stocks.Count(e => e.Id == key) > 0;
        }
    }
}
