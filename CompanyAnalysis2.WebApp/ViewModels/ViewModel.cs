using System;
using System.Web;
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
            int userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            CompanyAnalysis2Context ctx = new CompanyAnalysis2Context();
            loggedOnUser = ctx.Users.Find(userId);
        }
    }
}