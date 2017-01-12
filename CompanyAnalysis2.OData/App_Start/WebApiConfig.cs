using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CompanyAnalysis2.Model;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace CompanyAnalysis2.OData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "CompanyAnalysis2";
            builder.ContainerName = "CompanyAnalysis2Container";
            builder.EntitySet<Company>("Companies");
            builder.EntitySet<Estimate>("Estimates");
            builder.EntitySet<FinancialIndicator>("FinancialIndicators");
            builder.EntitySet<Period>("Periods");
            builder.EntitySet<Report>("Reports");
            builder.EntitySet<StockQuote>("StockQuotes");
            builder.EntitySet<Stock>("Stocks");
            builder.EntitySet<User>("Users");
            builder.EntitySet<UserSetting>("UserSettings");
            builder.Action("CalculateFinacialInicators").Parameter<int>("companyId");
            ActionConfiguration actionConfig = builder.Action("CalculateFinacialInicatorsByPeriod");
            actionConfig.Parameter<int>("companyId");
            actionConfig.Parameter<int>("periodId");
            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
