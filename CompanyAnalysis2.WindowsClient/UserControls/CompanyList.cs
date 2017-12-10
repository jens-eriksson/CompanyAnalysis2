using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.WindowsClient.UserControls
{
    public partial class CompanyList : UserControl
    {
        public CompanyList()
        {
            InitializeComponent();
        }

        public void Populate()
        {
            panelRows.Controls.Clear();
            List<Company> stared = Program.LoggedOnUser.StaredCompanies.ToList();
            stared = stared.OrderBy(c => c.FinancialIndicators.OrderByDescending(f => f.Period.EndDate).FirstOrDefault().InvestmentGradeTTM).ToList();

            foreach (Company c in stared)
            {
                CompanyRow row = new CompanyRow(c);
                panelRows.Controls.Add(row);
                row.SendToBack();
            }
        }
    }
}
