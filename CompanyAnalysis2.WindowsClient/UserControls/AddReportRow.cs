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
using CompanyAnalysis2.WindowsClient;

namespace CompanyAnalysis2.WindowsClient.UserControls
{
    public partial class AddReportRow : UserControl
    {
        public event AddReportEventHandler ReportAdded;
        private Model.Company _comapny;

        public AddReportRow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddReport();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AddReport();
                return;
            }

            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.Contains('.') == false)) return;
            if ((e.KeyChar == ',') && ((sender as TextBox).SelectionLength == (sender as TextBox).TextLength)) return;
            e.Handled = true;
        }

        public void Populate(Model.Company company)
        {
            _comapny = company;

            List<Period> periods = new List<Period>();
            foreach (Report report in _comapny.Reports)
                periods.Add(report.Period);

            List<Period> unReportedPeriods = new List<Period>();
            foreach (Period period in Program.Context.Periods)
                if (periods.Contains(period) == false)
                    unReportedPeriods.Add(period);

            cboPeriod.Items.Clear();
            Report lastReport = _comapny.Reports.OrderByDescending(r => r.Period.EndDate).FirstOrDefault();
            int selectedIndex = 0;

            foreach (Period period in unReportedPeriods.OrderByDescending(p => p.EndDate))
            {
                int index = cboPeriod.Items.Add(period.Name);
                if (lastReport != null && period.StartDate == lastReport.Period.EndDate.AddDays(1))
                    selectedIndex = index;
            }

            if (cboPeriod.Items.Count > 0)
                cboPeriod.SelectedIndex = selectedIndex;

            txtRevenue.Focus();                
        }

        public void AddReport()
        {
            if (_comapny == null)
                return;

            if (cboPeriod.SelectedItem == null || txtRevenue.Text == "" || txtNetIncome.Text == "" || txtAssets.Text == "" || txtEquity.Text == "")
            {
                MessageBox.Show("Enter values in all fields");
                return;
            }

            Period period = Program.Context.Periods.FirstOrDefault(p => p.Name == cboPeriod.SelectedItem.ToString());
            if (period == null)
            {
                MessageBox.Show("Invalid period");
                return;
            }

            Report report = new Report();
            report.Company = _comapny;
            report.CompanyId = _comapny.Id;
            report.Period = period;
            report.PeriodId = period.Id;
            report.Revenue = double.Parse(txtRevenue.Text);
            report.NetIncome = double.Parse(txtNetIncome.Text);
            report.Equity = double.Parse(txtEquity.Text);
            report.Assets = double.Parse(txtAssets.Text);
            report.CreatedByUserId = Program.LoggedOnUser.Id;

            Program.Context.Reports.Add(report);
            Program.Context.SaveChanges();

            txtRevenue.Text = "";
            txtNetIncome.Text = "";
            txtAssets.Text = "";
            txtEquity.Text = "";
            txtRevenue.Focus();

            OnAdd(new AddReportEventArgs(report));
        } 

        private void OnAdd(AddReportEventArgs e)
        {
            if (ReportAdded != null)
                ReportAdded(this, e);
        }

    }

    
}
