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
    public partial class CompanyUserControl : UserControl
    {
        public event CloseCompanyEventHandler Close;
        private Company _company;

        public CompanyUserControl()
        {
            InitializeComponent();
        }

        public void Populate(int companyId)
        {
            _company = Program.Context.Companies.Find(companyId);
            lblCompanyName.Text = _company.Name.ToUpper();
            lblCompanyInfo.Text = _company.YahooFinanceSymbol + " ("+ _company.Currency + ")";
            if (_company.PeTTM != null)
                lblPeTTM.Text = "P/E TTM: " + Math.Round(_company.PeTTM.Value, 2).ToString();
            if (_company.MarketCap != null)
                lblMarketCap.Text = "Market cap: " + Math.Round(_company.MarketCap.Value, 2).ToString();
            if (_company.Recalculated != null)
                lblRecalculated.Text = "Recalculated: " + _company.Recalculated.Value.ToShortDateString() + " " + _company.Recalculated.Value.ToLongTimeString();

            overview.Populate(_company);
            reports.Populate(_company);
            stocks.Populate(_company);
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            if(_company != null)
                OnClose(new CloseCompanyEventArgs(_company.Id));
        }

        private void OnClose(CloseCompanyEventArgs e)
        {
            if (Close != null)
                Close(this, e);
        }

        private void iconButtonCharts_Click(object sender, EventArgs e)
        {
            ChartForm chartForm = new ChartForm();
            chartForm.Populate(_company);
            chartForm.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            NumbersForm numbersForm = new NumbersForm();
            numbersForm.Populate(_company);
            numbersForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditCompanyForm form = new EditCompanyForm();
            form.SetCompany(_company);
            DialogResult result = form.ShowDialog();
            if(result == DialogResult.OK)
                Populate(_company.Id);
        }

        private void btnCalculateNumbers_Click(object sender, EventArgs e)
        {
            if (_company != null)
            {
                Cursor = Cursors.WaitCursor;
                Calculations.CreateOrUpdateIndicator(_company, Program.Context);
                Program.Context.SaveChanges();
                Populate(_company.Id);
                tabControl.SelectedTab = tabPageOverview;
                Cursor = Cursors.Default;
            }
        }
    }

    public delegate void CloseCompanyEventHandler(object sender, CloseCompanyEventArgs e);
    public class CloseCompanyEventArgs : EventArgs
    {
        public int Id { get; set; }
        public CloseCompanyEventArgs(int id)
        {
            Id = id;
        }
    }
}
