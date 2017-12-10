using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyAnalysis2.WindowsClient.UserControls.Charts;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.WindowsClient.UserControls
{
    public partial class ChartPicker : UserControl
    {
        public Company Company { get; private set; }
        private LynchChart _lynchChart;
        private RevenueTtmIncomeTtmChart _revenueTtmIncomeTtmChart;

        public ChartPicker()
        {
            InitializeComponent();

            _lynchChart = new LynchChart();
            _lynchChart.Dock = DockStyle.Fill;

            _revenueTtmIncomeTtmChart = new RevenueTtmIncomeTtmChart();
            _revenueTtmIncomeTtmChart.Dock = DockStyle.Fill;
        }

        private void cboCharts_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelChart.Controls.Clear();

            switch (cboCharts.SelectedItem.ToString())
            {
                case "PETER LYNCH CHART":
                    _lynchChart.Populate(Company);
                    panelChart.Controls.Add(_lynchChart);
                    break;
                case "REVENUE TTM | NET INCOME TTM":
                    _revenueTtmIncomeTtmChart.Populate(Company);
                    panelChart.Controls.Add(_revenueTtmIncomeTtmChart);
                    break;
                
            }
        }

        public void Populate(Model.Company company, int selectedIndex)
        {
            Company = company;
            cboCharts.SelectedIndex = selectedIndex;
            Refresh();
        }

        public override void Refresh()
        {
            if(Company != null)
            {
                _lynchChart.Populate(Company);
                _revenueTtmIncomeTtmChart.Populate(Company);
            }
            
            base.Refresh();
        }
    }
}
