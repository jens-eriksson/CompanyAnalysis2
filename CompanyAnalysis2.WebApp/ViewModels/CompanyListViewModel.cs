using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.WebApp.ViewModels
{
    public class CompanyListViewModel : ViewModel
    {
        public List<Company> Companies { get; set; }

        public CompanyListViewModel() : base()
        {
            CompanyAnalysis2Context ctx = new CompanyAnalysis2Context();
            Companies = ctx.Companies.Where(c => c.Hidden == false).OrderBy(c => c.Name).ToList();
        }

        public bool IsStared(Company company)
        {
            if (LoggedOnUser == null)
                return false;

            if (LoggedOnUser.StaredCompanies.Contains(company))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}