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
using LiveCharts.Wpf;
using LiveCharts;

namespace CompanyAnalysis2.WindowsClient.UserControls.Charts
{
    public partial class RevenueTtmIncomeTtmChart : UserControl
    {
        public RevenueTtmIncomeTtmChart()
        {
            InitializeComponent();
        }

        public void Populate(Model.Company company)
        {
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
            Axis axisY = new Axis();
            axisY.Title = "";
            axisY.LabelFormatter = value => value.ToString("#,##0");
            axisY.Separator = new Separator
            {
                StrokeThickness = 0.5,
                StrokeDashArray = new System.Windows.Media.DoubleCollection(4),
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
            };
            cartesianChart.AxisY.Clear();
            cartesianChart.AxisY.Add(axisY);

            //Series
            ColumnSeries netIncomeTTM = new ColumnSeries();
            netIncomeTTM.Title = "Net Income TTM (M" + company.Currency.ToUpper() + ")";
            netIncomeTTM.Values = new ChartValues<double>();
            netIncomeTTM.Fill = System.Windows.Media.Brushes.Green;
                        
            ColumnSeries revenueTtm = new ColumnSeries();
            revenueTtm.Values = new ChartValues<double>();
            revenueTtm.Title = "Revenue TTM (M" + company.Currency.ToUpper() + ")";

            cartesianChart.Series = new SeriesCollection();
            cartesianChart.Series.Add(revenueTtm);
            cartesianChart.Series.Add(netIncomeTTM);

            //Values
            foreach (FinancialIndicator indicator in company.FinancialIndicators.Where(fi => fi.NetIncomeTTM != 0 && fi.RevenueTTM != 0).OrderBy(f => f.Period.EndDate))
            {
                axisX.Labels.Add(indicator.Period.Name);
                netIncomeTTM.Values.Add(indicator.NetIncomeTTM);
                revenueTtm.Values.Add(indicator.RevenueTTM);
            }

            cartesianChart.LegendLocation = LegendLocation.Top;
        }
    }
}
