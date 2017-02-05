using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyAnalysis2.WebApp
{
    public static class CustomHelpers
    {
        public static IDisposable Accordion(this HtmlHelper helper, string heading)
        {
            string html = "<div class=\"accordion\">";
            html += "<label class=\"accordion-heading float-left\">";
            html += heading;
            html += "</label><img class=\"cursor-pointer float-right display-block show-hide-button\" src=\"" + UrlHelper.GenerateContentUrl("~/images/up.png", helper.ViewContext.HttpContext) + "\" />";
            html += "<br class=\"clear\" />";
            html += "<hr />";
            html += "<div class=\"accordion-content\">";

            helper.ViewContext.Writer.Write(html);

            return new AccordionEnd(helper);
        }

        class AccordionEnd : IDisposable
        {
            private HtmlHelper helper;

            public AccordionEnd(HtmlHelper helper)
            {
                this.helper = helper;
            }

            public void Dispose()
            {
                string html = "</div><br /><br /></div>";
                this.helper.ViewContext.Writer.Write(html);
            }
        }

    }
}