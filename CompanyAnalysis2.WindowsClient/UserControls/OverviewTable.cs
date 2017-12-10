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
    public partial class OverviewTable : UserControl
    {
        List<Panel> _periods;

        public OverviewTable()
        {
            InitializeComponent();
            _periods = new List<Panel>();
        }

        public void Populate(Model.Company company)
        {
            foreach (Panel peroid in _periods)
                panelPeriods.Controls.Remove(peroid);

            foreach (FinancialIndicator indicator in company.FinancialIndicators.OrderByDescending(i => i.Period.EndDate))
                AddPeriod(indicator);

            panelPeriods.HorizontalScroll.Value = panelPeriods.HorizontalScroll.Maximum;
        }

        private void AddPeriod(FinancialIndicator indicator)
        {
            Panel period = new Panel();
            _periods.Add(period);
            period.Dock = DockStyle.Left;
            period.Width = 80;
            int labelHeight = 14;

            Label heading = new Label();
            heading.Text = indicator.Period.Name;
            heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            heading.Location = new Point(0, 0);
            heading.Width = period.Width;
            heading.Height = labelHeight;
            heading.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(heading);

            Panel panelHr = new Panel();
            panelHr.Location = new Point(0, 24);
            panelHr.Height = 1;
            panelHr.Width = period.Width;
            panelHr.BackColor = Color.Black;
            period.Controls.Add(panelHr);

            Label revenue = new Label();
            revenue.Text = indicator.Revenue.ToString("#,##0");
            revenue.Location = new Point(0, 28);
            revenue.Width = period.Width;
            revenue.Height = labelHeight;
            revenue.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(revenue);

            Label netIncome = new Label();
            netIncome.Text = indicator.NetIncome.ToString("#,##0");
            netIncome.Location = new Point(0, 46);
            netIncome.Width = period.Width;
            netIncome.Height = labelHeight;
            netIncome.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(netIncome);

            Label profitMagrin = new Label();
            profitMagrin.Text = (indicator.ProfitMargin * 100).ToString("#,##0.00") + "%";
            profitMagrin.Location = new Point(0, 64);
            profitMagrin.Width = period.Width;
            profitMagrin.Height = labelHeight;
            profitMagrin.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(profitMagrin);

            Label revenueTtm = new Label();
            revenueTtm.Text = indicator.RevenueTTM.ToString("#,##0");
            revenueTtm.Location = new Point(0, 88);
            revenueTtm.Width = period.Width;
            revenueTtm.Height = labelHeight;
            revenueTtm.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(revenueTtm);

            Label netIncomeTtm = new Label();
            netIncomeTtm.Text = indicator.NetIncomeTTM.ToString("#,##0");
            netIncomeTtm.Location = new Point(0, 106);
            netIncomeTtm.Width = period.Width;
            netIncomeTtm.Height = labelHeight;
            netIncomeTtm.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(netIncomeTtm);

            Label profitMagrinTtm = new Label();
            profitMagrinTtm.Text = (indicator.ProfitMarginTTM * 100).ToString("#,##0.00") + "%";
            profitMagrinTtm.Location = new Point(0, 124);
            profitMagrinTtm.Width = period.Width;
            profitMagrinTtm.Height = labelHeight;
            profitMagrinTtm.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(profitMagrinTtm);

            Label assets = new Label();
            assets.Text = indicator.Assets.ToString("#,##0");
            assets.Location = new Point(0, 148);
            assets.Width = period.Width;
            assets.Height = labelHeight;
            assets.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(assets);

            Label equity = new Label();
            equity.Text = indicator.Equity.ToString("#,##0");
            equity.Location = new Point(0, 166);
            equity.Width = period.Width;
            equity.Height = labelHeight;
            equity.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(equity);

            Label solidity = new Label();
            solidity.Text = (indicator.Solidity * 100).ToString("#,##0.00") + "%";
            solidity.Location = new Point(0, 184);
            solidity.Width = period.Width;
            solidity.Height = labelHeight;
            solidity.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(solidity);

            Label returnOnAssetsTtm = new Label();
            returnOnAssetsTtm.Text = (indicator.ReturnOnAssetsTTM * 100).ToString("#,##0.00") + "%";
            returnOnAssetsTtm.Location = new Point(0, 208);
            returnOnAssetsTtm.Width = period.Width;
            returnOnAssetsTtm.Height = labelHeight;
            returnOnAssetsTtm.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(returnOnAssetsTtm);

            Label peTtm = new Label();
            peTtm.Text = indicator.PeTTM.ToString("#,##0.0");
            peTtm.Location = new Point(0, 226);
            peTtm.Width = period.Width;
            peTtm.Height = labelHeight;
            peTtm.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(peTtm);

            Label marketCap = new Label();
            marketCap.Text = indicator.MarketCap.ToString("#,##0");
            marketCap.Location = new Point(0, 244);
            marketCap.Width = period.Width;
            marketCap.Height = labelHeight;
            marketCap.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(marketCap);

            Label revenueGrowthTtm = new Label();
            revenueGrowthTtm.Text = (indicator.RevenueGrowthTTM * 100).ToString("#,##0.00") + "%";
            revenueGrowthTtm.Location = new Point(0, 268);
            revenueGrowthTtm.Width = period.Width;
            revenueGrowthTtm.Height = labelHeight;
            revenueGrowthTtm.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(revenueGrowthTtm);

            Label netIncomeGrowthTtm = new Label();
            netIncomeGrowthTtm.Text = (indicator.NetIncomeGrowthTTM * 100).ToString("#,##0.00") + "%";
            netIncomeGrowthTtm.Location = new Point(0, 286);
            netIncomeGrowthTtm.Width = period.Width;
            netIncomeGrowthTtm.Height = labelHeight;
            netIncomeGrowthTtm.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(netIncomeGrowthTtm);

            Label equityGrowthTtm = new Label();
            equityGrowthTtm.Text = (indicator.EqutiyGrowthTTM * 100).ToString("#,##0.00") + "%";
            equityGrowthTtm.Location = new Point(0, 304);
            equityGrowthTtm.Width = period.Width;
            equityGrowthTtm.Height = labelHeight;
            equityGrowthTtm.TextAlign = ContentAlignment.MiddleRight;
            period.Controls.Add(equityGrowthTtm);

            panelPeriods.Controls.Add(period);
            
        }

        private void OverviewTable_Load(object sender, EventArgs e)
        {
            panelPeriods.HorizontalScroll.Value = panelPeriods.HorizontalScroll.Maximum;
        }
    }
}
