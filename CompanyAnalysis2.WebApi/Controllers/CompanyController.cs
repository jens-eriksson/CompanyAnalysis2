using System.Web.Http;
using System.Web.OData;
using CompanyAnalysis2.Model;
using System.Web.OData.Routing;
using System.Web.OData.Query;

namespace CompanyAnalysis2.WebApi.Controllers
{
    public class CompanyController : ODataController
    {
        private readonly CompanyAnalysis2Context _ctx = new CompanyAnalysis2Context();

        [HttpGet]
        [ODataRoute("Company")]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]

        public IHttpActionResult GetCompanies()
        {
            return Ok(_ctx.Companies);
        }

        [HttpGet]
        [ODataRoute("Company({id})")]
        public IHttpActionResult GetCompany([FromODataUri] long id)
        {
            var company = _ctx.Companies.Find(id);

            if (company == null)
                return NotFound();

            return Ok(company);
        }                

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
            base.Dispose(disposing);
        }
    }
}