using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.WindowsClient
{
    public partial class CompanyListForm : Form
    {
        public CompanyListForm()
        {
            InitializeComponent();
            progressBar.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Populate()
        {
            companyList1.Populate();
        }

        private void btnRecalculate_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            Cursor = Cursors.WaitCursor;
            progressBar.Value = 0;
            progressBar.Maximum = Program.LoggedOnUser.StaredCompanies.Count;

            foreach (Company company in Program.LoggedOnUser.StaredCompanies)
            {
                Calculations.CreateOrUpdateIndicator(company, company.Reports.OrderByDescending(r => r.Period.EndDate).FirstOrDefault(), Program.Context);
                progressBar.Value++;
                Application.DoEvents();
            }

            Populate();
            progressBar.Visible = false;
            Cursor = Cursors.Default;
        }
    }
}
