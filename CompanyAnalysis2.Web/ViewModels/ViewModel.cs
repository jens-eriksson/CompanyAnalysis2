using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyAnalysis;

namespace CompanyAnalysis2.ViewModels
{
    public abstract class ViewModel
    {
        public List<KeyValuePair<int, string>> Companies { get; set; }

        public ViewModel()
        {
            CompanyAnalysisContext ctx = new CompanyAnalysisContext();
            Companies = new List<KeyValuePair<int, string>>();
            foreach (Company company in ctx.Companies)
                Companies.Add(new KeyValuePair<int, string>(company.Id, company.Name));
        }

    }
}