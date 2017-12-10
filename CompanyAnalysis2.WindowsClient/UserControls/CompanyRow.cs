using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyAnalysis2.Model;
using System.Drawing;
using FontAwesome.Sharp;

namespace CompanyAnalysis2.WindowsClient.UserControls
{
    public class CompanyRow : Panel
    {
        public Company Company { get; set; }

        public CompanyRow(Company company)
        {
            Company = company;
            FinancialIndicator latestIndicator = company.FinancialIndicators.OrderByDescending(f => f.Period.EndDate).FirstOrDefault();
            Stock defaultStock = company.Stocks.Where(s => s.IsDefault).FirstOrDefault();
            StockQuote latestQuote = null;
            if (defaultStock != null)
                latestQuote = defaultStock.StockQuotes.OrderByDescending(q => q.Date).FirstOrDefault();

            this.Height = 20;
            this.Dock = DockStyle.Top;

            Label lblName = new Label();
            lblName.Text = Company.Name;
            lblName.Height = 20;
            lblName.Width = 160;
            lblName.Location = new Point(0, 0);
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblName);

            Label lblPeTTm = new Label();
            lblPeTTm.Height = 20;
            lblPeTTm.Width = 80;
            lblPeTTm.Location = new Point(160, 0);
            lblPeTTm.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblPeTTm);

            Label lblRoaTTM = new Label();
            lblRoaTTM.Height = 20;
            lblRoaTTM.Width = 80;
            lblRoaTTM.Location = new Point(240, 0);
            lblRoaTTM.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblRoaTTM);

            Label lblStockPrice = new Label();
            lblStockPrice.Height = 20;
            lblStockPrice.Width = 80;
            lblStockPrice.Location = new Point(320, 0);
            lblStockPrice.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblStockPrice);

            Label lblQuoteDate = new Label();
            lblQuoteDate.Height = 20;
            lblQuoteDate.Width = 80;
            lblQuoteDate.Location = new Point(400, 0);
            lblQuoteDate.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblQuoteDate);

            Label lblReportPeriod = new Label();
            lblReportPeriod.Height = 20;
            lblReportPeriod.Width = 80;
            lblReportPeriod.Location = new Point(480, 0);
            lblReportPeriod.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblReportPeriod);

            Label lblRecalculated = new Label();
            lblRecalculated.Height = 20;
            lblRecalculated.Width = 80;
            lblRecalculated.Location = new Point(560, 0);
            lblRecalculated.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblRecalculated);

            Label lblGrade = new Label();
            lblGrade.Height = 20;
            lblGrade.Width = 80;
            lblGrade.Location = new Point(640, 0);
            lblGrade.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblGrade);

            if (latestIndicator == null)
            {
                lblPeTTm.Text = "-";
                lblRoaTTM.Text = "-";
                lblReportPeriod.Text = "-";
                lblGrade.Text = "-";
            }
            else
            {
                lblPeTTm.Text = latestIndicator.PeTTM.ToString("#,##0.00");
                lblRoaTTM.Text = (latestIndicator.ReturnOnAssetsTTM * 100).ToString("#,##0.00") + "%";
                lblReportPeriod.Text = latestIndicator.Period.Name;
                lblGrade.Text = latestIndicator.InvestmentGradeTTM.ToString("#,##0.00");
            }

            if (latestQuote == null)
            {
                lblStockPrice.Text = "-";
                lblQuoteDate.Text = "-";
            }
            else
            {
                lblStockPrice.Text = latestQuote.Price.ToString("#,##0.00");
                lblQuoteDate.Text = latestQuote.Date.ToShortDateString();
            }

            if (Company.Recalculated == null)
            {
                lblRecalculated.Text = "-";
            }
            else
            {
                lblRecalculated.Text = company.Recalculated.Value.ToShortDateString() + " " + company.Recalculated.Value.ToShortTimeString();
            }
            
        }
    }

}
