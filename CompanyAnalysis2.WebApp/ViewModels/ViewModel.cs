using System;
using System.Web;
using System.Linq;
using CompanyAnalysis2.Model;


namespace CompanyAnalysis2.WebApp.ViewModels
{
    public abstract class ViewModel
    {
        private User loggedOnUser;
        public User LoggedOnUser
        {
            get
            {
                return loggedOnUser;
            }
        }

        public ViewModel()
        {
            CompanyAnalysis2Context ctx = new CompanyAnalysis2Context();
            loggedOnUser = ctx.Users.FirstOrDefault(u => u.Email == HttpContext.Current.User.Identity.Name);
        }
    }
}