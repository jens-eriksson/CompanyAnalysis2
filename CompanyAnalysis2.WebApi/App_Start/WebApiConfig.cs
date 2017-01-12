using CompanyAnalysis2.Model;
using System.Web.OData.Extensions;
using System.Web.Http;
using Microsoft.OData.Edm;
using System.Web.OData.Builder;

namespace CompanyAnalysis2.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //OData routes
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            config.MapODataServiceRoute("ODataRoute", "api", GetEdmModel());
            config.EnsureInitialized();
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.Namespace = "CompanyAnalysis2";
            builder.ContainerName = "CompanyAnalysis2Container";

            builder.EntitySet<Report>("Report");
            builder.EntitySet<Company>("Company");
            builder.EntitySet<Estimate>("Estimate");
            builder.EntitySet<Period>("Periods");
            builder.EntitySet<Report>("Reports");
            builder.EntitySet<Estimate>("Estimates");
            builder.EntitySet<FinancialIndicator>("FinancialIndicators");

            return builder.GetEdmModel();
        }
    }
}
