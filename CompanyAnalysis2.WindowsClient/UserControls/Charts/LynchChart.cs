using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.WindowsClient.UserControls.Charts
{
    public partial class LynchChart : UserControl
    {
        public LynchChart()
        {
            InitializeComponent();
        }

        public void Populate(Model.Company company)
        {
            if (company.FinancialIndicators.Count == 0)
                return;

            double maxNetIncome = Math.Ceiling(company.FinancialIndicators.Max(fi => fi.NetIncomeTTM)) * 10;
            double max = Math.Ceiling(company.FinancialIndicators.Max(fi => fi.MarketCap));
            if (company.MarketCap != null)
                if (company.MarketCap > max)
                    max = company.MarketCap.Value;
            if (maxNetIncome > max)
                max = maxNetIncome;

            max = Math.Ceiling(max / 100) * 100;
            double step = max / 10;
            step = Math.Ceiling(step / 1000) * 1000;

            //X axis
            Axis axisX = new Axis();
            axisX.Labels = new List<string>();
            axisX.LabelsRotation = -45;
            axisX.Title = "";
            axisX.Separator = new Separator // force the separator step to 1, so it always display all labels
            {
                Step = 1,
                IsEnabled = false //disable it to make it invisible.
            };
            cartesianChart.AxisX.Clear();
            cartesianChart.AxisX.Add(axisX);

            //Y axis
            cartesianChart.AxisY.Clear();

            Axis axisYNetIncome = new Axis();
            axisYNetIncome.Title = "";
            axisYNetIncome.LabelFormatter = value => value.ToString("#,##0");
            axisYNetIncome.MinValue = 0;
            axisYNetIncome.MaxValue = max / 10;
            axisYNetIncome.Separator = new Separator
            {
                StrokeThickness = 0.5,
                StrokeDashArray = new System.Windows.Media.DoubleCollection(4),
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86)),
                Step = Convert.ToInt32(step / 10)              
            };
            cartesianChart.AxisY.Add(axisYNetIncome);

            Axis axisYMarketCap = new Axis();
            axisYMarketCap.Title = "";
            axisYMarketCap.LabelFormatter = value => value.ToString("#,##0");
            axisYMarketCap.Position = AxisPosition.RightTop;
            axisYMarketCap.MinValue = 0;
            axisYMarketCap.MaxValue = max;
            axisYMarketCap.Separator = new Separator
            {
                StrokeThickness = 0.5,
                StrokeDashArray = new System.Windows.Media.DoubleCollection(4),
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86)),
                Step = Convert.ToInt32(step)
            };
            cartesianChart.AxisY.Add(axisYMarketCap);

            //Series
            LineSeries netIncomeTTM = new LineSeries();
            netIncomeTTM.Title = "Net Income TTM (M" + company.Currency.ToUpper() + ")";
            netIncomeTTM.Values = new ChartValues<double>();
            netIncomeTTM.LineSmoothness = 0;
            netIncomeTTM.ScalesYAt = 0;

            LineSeries marketCap = new LineSeries();
            marketCap.Values = new ChartValues<double>();
            marketCap.LineSmoothness = 0;
            marketCap.Title = "Market Cap (M" + company.Currency.ToUpper() + ")";
            marketCap.ScalesYAt = 1;
            
            cartesianChart.Series = new SeriesCollection();
            cartesianChart.Series.Add(netIncomeTTM);
            cartesianChart.Series.Add(marketCap);

            //Values
            foreach (FinancialIndicator indicator in company.FinancialIndicators.Where(fi => fi.NetIncomeTTM != 0 && fi.RevenueTTM != 0).OrderBy(f => f.Period.EndDate))
            {
                axisX.Labels.Add(indicator.Period.Name);
                netIncomeTTM.Values.Add(indicator.NetIncomeTTM);
                marketCap.Values.Add(indicator.MarketCap);
            }

            //Latest valuation
            axisX.Labels.Add("Current");
            if(company.MarketCap != null)
                marketCap.Values.Add(company.MarketCap);

            cartesianChart.LegendLocation = LegendLocation.Top;
        }
    }
}
