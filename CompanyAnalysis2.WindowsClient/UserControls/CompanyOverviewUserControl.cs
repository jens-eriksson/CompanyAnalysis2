using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyAnalysis2;
using CompanyAnalysis2.Model;
using System.Configuration;

namespace CompanyAnalysis2.WindowsClient.UserControls
{
    public partial class CompanyOverviewUserControl : UserControl
    {
        private Company _company;
        public CompanyOverviewUserControl()
        {
            InitializeComponent();
        }

        public void Populate(Company company)
        {
            _company = company;
            FinancialIndicator financialIndicator = _company.FinancialIndicators.OrderByDescending(fi => fi.Period.EndDate).FirstOrDefault();
            if (financialIndicator != null)
            {
                lblPeriod.Text = financialIndicator.Period.Name;
                lblNetIncomeTtmValue.Text = financialIndicator.NetIncomeTTM.ToString();
            }
        }

        private void btnCalculateNumbers_Click(object sender, EventArgs e)
        {
            Program.DataContainer.CalculateFinacialInicators(_company.Id).Execute();
        }
    }
}
