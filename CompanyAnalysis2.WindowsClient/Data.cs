using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyAnalysis2.Model;
using CompanyAnalysis2;
using System.Configuration;

namespace CompanyAnalysis2.WindowsClient
{

    public class Data
    {
        private CompanyAnalysis2Container _container;
        public User LoggedOnUser { get; set; }
        public IEnumerable<Period> Periods { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        
        public Data()
        {
            _container = new CompanyAnalysis2Container(new Uri(ConfigurationManager.AppSettings["ODataUri"]));
            _container.MergeOption = Microsoft.OData.Client.MergeOption.OverwriteChanges;
        }

        public void Load()
        {
            LoggedOnUser = _container.Users.ByKey(1).GetValue();
            Periods = _container.Periods.Execute();
            Companies = _container.Companies.Expand("FinancialIndicators($expand = Period)").Execute();
        }

        public void CalculateFinacialInicators(int companyId)
        {
            _container.CalculateFinacialInicators(companyId).Execute();
        }
    }
}
