using System.Web.Http;
using System.Web.OData;
using CompanyAnalysis2.Model;
using System.Web.OData.Routing;
using System.Linq;
using System.Collections.Generic;

namespace CompanyAnalysis2.WebApi.Controllers
{
    public class ReportController : ODataController
    {
        private readonly CompanyAnalysis2Context _ctx = new CompanyAnalysis2Context();

        [HttpGet]
        [ODataRoute("Report")]
        public List<Report> GetReports()
        {
            return _ctx.Reports.ToList(); //Ok(_ctx.Reports);
        }

        [HttpGet]
        [ODataRoute("Report({id})")]
        public IHttpActionResult GetReport([FromODataUri] long id)
        {
            var report = _ctx.Reports.Find(id);

            if (report == null)
                return NotFound();

            return Ok(report);
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
            base.Dispose(disposing);
        }

    }
}