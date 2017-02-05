using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public User LoggedOnUser
        {
            get
            {
                if (Request.IsAuthenticated)
                    return Db.Users.Find(HttpContext.Current.User.Identity.Name);
                else
                    return null;
            }
        }

        public CompanyAnalysis2Context Db
        {
            get
            {
                CompanyAnalysis2Context context = new CompanyAnalysis2Context();
                context.Configuration.LazyLoadingEnabled = true;
                return context;
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
