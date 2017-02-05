using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.WebApp.Util
{
    public class Sorter
    {
        public static List<Company> SortCompanyList(string sort, string sortOrder)
        {
            CompanyAnalysis2Context context = new CompanyAnalysis2Context();
            List<Company> companies;

            if (HttpContext.Current.Request.IsAuthenticated)
            {
                MvcApplication app = (MvcApplication)HttpContext.Current.ApplicationInstance;
                companies = Sort(app.LoggedOnUser.StaredCompanies.Where(c => c.Hidden == false).ToList(), sort, sortOrder);

                UserSetting userSetting = app.LoggedOnUser.UserSettings.Where(us => us.Name == "CompanyListFilter").FirstOrDefault();
                string filter = "";
                if (userSetting != null)
                    filter = userSetting.Value;

                List<Company> unstared = new List<Company>();
                foreach (Company c in context.Companies.Where(c => c.Hidden == false))
                {
                    if (companies.Where(stared => stared.Id == c.Id).Count() == 0)
                        unstared.Add(c);
                }

                switch (filter)
                { 
                    case "all":
                        companies.AddRange(Sort(unstared, sort, sortOrder));
                        break;
                    case "stared":
                        break;
                    default:
                        companies.AddRange(Sort(unstared, sort, sortOrder));
                        break;
                }
                                
                return companies;
            }
            else
            {
                companies = context.Companies.Where(c => c.Hidden == false).OrderBy(c => c.Name).ToList();
                return Sort(companies, sort, sortOrder);
            }

        }

        private static List<Company> Sort(List<Company> companies, string sort, string sortOrder)
        {
            if (sortOrder == "DESC")
            {
                switch (sort)
                {
                    case "Company.Name":
                        companies = companies.OrderByDescending(c => c.Name).ToList();
                        break;
                    //case "InvestmentGradeR12":
                    //    companies = companies.OrderByDescending(c => c.InvestmentGradeR12).ToList();
                    //    break;
                    //case "YieldR12":
                    //    companies = companies.OrderByDescending(c => c.YieldR12).ToList();
                    //    break;
                    //case "ReturnOnEquityR12":
                    //    companies = companies.OrderByDescending(c => c.ReturnOnEquityR12).ToList();
                    //    break;
                    //case "ReturnOnTotalCapitalR12":
                    //    companies = companies.OrderByDescending(c => c.ReturnOnTotalCapitalR12).ToList();
                    //    break;
                    //case "NetIncomeGrowthR12":
                    //    companies = companies.OrderByDescending(c => c.NetIncomeGrowthR12).ToList();
                    //    break;
                    //case "Solidity":
                    //    companies = companies.OrderByDescending(c => c.Solidity).ToList();
                    //    break;
                    //case "MarginR12":
                    //    companies = companies.OrderByDescending(c => c.MarginR12).ToList();
                    //    break;
                    //case "PeR12":
                    //    companies = companies.OrderByDescending(c => c.PeR12).ToList();
                    //    break;
                    //case "StockPrice":
                    //    companies = companies.OrderByDescending(c => c.StockPrice).ToList();
                    //    break;
                    //case "Currency":
                    //    companies = companies.OrderByDescending(c => c.Currency).ToList();
                    //    break;
                    //case "NextReportDate":
                    //    companies = companies.OrderByDescending(c => c.NextReportDate).ToList();
                    //    break;
                    //case "CompanyValue":
                    //    companies = companies.OrderByDescending(c => c.CompanyValue).ToList();
                    //    break;
                    //case "NetIncomeR12":
                    //    companies = companies.OrderByDescending(c => c.NetIncomeR12).ToList();
                    //    break;
                }
            }
            else
            {
                switch (sort)
                {
                    case "Company.Name":
                        companies = companies.OrderBy(c => c.Name).ToList();
                        break;
                    //case "InvestmentGradeR12":
                    //    companies = companies.OrderBy(c => c.InvestmentGradeR12).ToList();
                    //    break;
                    //case "YieldR12":
                    //    companies = companies.OrderBy(c => c.YieldR12).ToList();
                    //    break;
                    //case "ReturnOnEquityR12":
                    //    companies = companies.OrderBy(c => c.ReturnOnEquityR12).ToList();
                    //    break;
                    //case "ReturnOnTotalCapitalR12":
                    //    companies = companies.OrderBy(c => c.ReturnOnTotalCapitalR12).ToList();
                    //    break;
                    //case "NetIncomeGrowthR12":
                    //    companies = companies.OrderBy(c => c.NetIncomeGrowthR12).ToList();
                    //    break;
                    //case "Solidity":
                    //    companies = companies.OrderBy(c => c.Solidity).ToList();
                    //    break;
                    //case "MarginR12":
                    //    companies = companies.OrderBy(c => c.MarginR12).ToList();
                    //    break;
                    //case "PeR12":
                    //    companies = companies.OrderBy(c => c.PeR12).ToList();
                    //    break;
                    //case "StockPrice":
                    //    companies = companies.OrderBy(c => c.StockPrice).ToList();
                    //    break;
                    //case "Currency":
                    //    companies = companies.OrderBy(c => c.Currency).ToList();
                    //    break;
                    //case "NextReportDate":
                    //    List<Company> tmp = companies.Where(c => c.NextReportDate.HasValue).OrderBy(c => c.NextReportDate).ToList();
                    //    tmp.AddRange(companies.Where(c => c.NextReportDate.HasValue == false).ToList());
                    //    companies = tmp;
                    //    break;
                    //case "CompanyValue":
                    //    companies = companies.OrderBy(c => c.CompanyValue).ToList();
                    //    break;
                    //case "NetIncomeR12":
                    //    companies = companies.OrderBy(c => c.NetIncomeR12).ToList();
                    //    break;
                }
            }

            return companies;
        }
    }
}