using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyAnalysis2.WindowsClient.CustomControls;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.WindowsClient.UserControls
{
    public partial class CompanyUserControl : UserControl
    {
        public CloseCompanyEventHandler Close;
        private Company _company;

        public CompanyUserControl()
        {
            InitializeComponent();
        }

        public void Populate(int companyId)
        {
            _company = Program.DataContainer.Companies
                            .ByKey(companyId)
                            .Expand("FinancialIndicators($expand=Period)")
                            .GetValue();
            companyOverviewUserControl1.Populate(_company);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(_company != null)
                OnClose(new CloseCompanyEventArgs(_company.Name));
        }

        private void OnClose(CloseCompanyEventArgs e)
        {
            if (Close != null)
                Close(this, e);
        }

        private void btnCalculateNumbers_Click(object sender, EventArgs e)
        {
            if (_company != null)
                Program.DataContainer.CalculateFinacialInicators(_company.Id).Execute();
        }
    }

    public delegate void CloseCompanyEventHandler(object sender, CloseCompanyEventArgs e);
    public class CloseCompanyEventArgs : EventArgs
    {
        public string Name { get; set; }
        public CloseCompanyEventArgs(string name)
        {
            Name = name;
        }
    }
}
