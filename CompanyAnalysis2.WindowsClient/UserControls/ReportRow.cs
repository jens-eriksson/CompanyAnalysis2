using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyAnalysis2.Model;
using System.Drawing;

namespace CompanyAnalysis2.WindowsClient.UserControls
{
    public class ReportRow : Panel
    {
        public Company Company { get; set; }
        public Report Report { get; set; }
        public Period Period { get; set; }

        private TextBox txtRevenue;
        private TextBox txtNetIncome;
        private TextBox txtAssets;
        private TextBox txtEquity;

        private bool isPopulating = false;

        public ReportRow(Model.Company company, Period period)
        {
            Company = company;
            Period = period;
            Report = Program.Context.Reports.Where(r => r.CompanyId == Company.Id && r.PeriodId == Period.Id).FirstOrDefault();
            
            txtRevenue = new TextBox();
            txtNetIncome = new TextBox();
            txtAssets = new TextBox();
            txtEquity = new TextBox();
            
            this.Height = 20;
            this.Dock = DockStyle.Top;

            Label lblPeriod = new Label();
            lblPeriod.Text = period.Name;
            lblPeriod.Height = 25;
            lblPeriod.Width = 60;
            lblPeriod.TextAlign = ContentAlignment.MiddleLeft;
            lblPeriod.Dock = DockStyle.Left;
            this.Controls.Add(lblPeriod);

            txtRevenue.Width = 80;
            txtRevenue.Dock = DockStyle.Left;
            txtRevenue.KeyPress += txt_KeyPress;
            txtRevenue.LostFocus += txt_LostFocus;
            txtRevenue.TextChanged += txt_TextChanged;
            this.Controls.Add(txtRevenue);
            txtRevenue.BringToFront();

            txtNetIncome.Width = 80;
            txtNetIncome.Dock = DockStyle.Left;
            txtNetIncome.KeyPress += txt_KeyPress;
            txtNetIncome.LostFocus += txt_LostFocus;
            txtNetIncome.TextChanged += txt_TextChanged;
            this.Controls.Add(txtNetIncome);
            txtNetIncome.BringToFront();

            txtAssets.Width = 80;
            txtAssets.Dock = DockStyle.Left;
            txtAssets.Tag = this;
            txtAssets.KeyPress += txt_KeyPress;
            txtAssets.LostFocus += txt_LostFocus;
            txtAssets.TextChanged += txt_TextChanged;
            this.Controls.Add(txtAssets);
            txtAssets.BringToFront();

            txtEquity.Width = 80;
            txtEquity.Dock = DockStyle.Left;
            txtEquity.KeyPress += txt_KeyPress;
            txtEquity.LostFocus += txt_LostFocus;
            txtEquity.TextChanged += txt_TextChanged;
            this.Controls.Add(txtEquity);
            txtEquity.BringToFront();

            Populate();
        }

        public void Populate()
        {
            isPopulating = true;

            if (Report == null)
            {
                txtRevenue.Text = "0";
                txtNetIncome.Text = "0";
                txtAssets.Text = "0";
                txtEquity.Text = "0";
            }
            else
            {
                txtRevenue.Text = Report.Revenue.ToString();

                if (Report != null)
                    txtNetIncome.Text = Report.NetIncome.ToString();
                else
                    txtNetIncome.Text = "0";

                if (Report != null)
                    txtAssets.Text = Report.Assets.ToString();
                else
                    txtAssets.Text = "0";

                if (Report != null)
                    txtEquity.Text = Report.Equity.ToString();
                else
                    txtAssets.Text = "0";
            }

            isPopulating = false;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            UpdateReport();
        }

        private void txt_LostFocus(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "") (sender as TextBox).Text = "0";
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.Contains('.') == false)) return;
            if ((e.KeyChar == ',') && ((sender as TextBox).SelectionLength == (sender as TextBox).TextLength)) return;

            e.Handled = true;
        }

        private void UpdateReport()
        {
            if (isPopulating)
                return;

            if ((txtRevenue.Text == "0" | txtRevenue.Text == "") && (txtNetIncome.Text == "0" | txtNetIncome.Text == "") &&
                (txtAssets.Text == "0" | txtAssets.Text == "") && (txtEquity.Text == "0" | txtEquity.Text == ""))
            {
                if(Report != null)
                {
                    Program.Context.Reports.Remove(Report);
                    Report = null;
                }
                
            }
            else
            {
                if (Report == null)
                {
                    Report = new Report();
                    Report.CompanyId = Company.Id;
                    Report.PeriodId = Period.Id;
                    Program.Context.Reports.Add(Report);
                }

                if (txtRevenue.Text != "")
                    Report.Revenue = Convert.ToDouble(txtRevenue.Text);
                else
                    Report.Revenue = 0;

                if (txtNetIncome.Text != "")
                    Report.NetIncome = Convert.ToDouble(txtNetIncome.Text);
                else
                    Report.NetIncome = 0;

                if (txtAssets.Text != "")
                    Report.Assets = Convert.ToDouble(txtAssets.Text);
                else
                    Report.Assets = 0;

                if (txtEquity.Text != "")
                    Report.Equity = Convert.ToDouble(txtEquity.Text);
                else
                    Report.Equity = 0;
            }

        }

    }
}
