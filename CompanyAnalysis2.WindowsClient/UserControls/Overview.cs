using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyAnalysis2;
using CompanyAnalysis2.Model;
using System.Configuration;

namespace CompanyAnalysis2.WindowsClient.UserControls
{
    public partial class Overview : UserControl
    {
        private Model.Company _company;

        public Overview()
        {
            InitializeComponent();
        }

        public void Populate(Model.Company company)
        {
            _company = company;
            overviewTable1.Populate(_company);
            chartPicker1.Populate(_company, 0);
            chartPicker2.Populate(_company, 1);      
        }

        private void CompanyOverviewUserControl_Resize(object sender, EventArgs e)
        {
            panelBottomLeft.Width = this.Width / 2;
        }

        private void splitter1_DoubleClick(object sender, EventArgs e)
        {
            panelBottomLeft.Width = this.Width / 2;
        }
    }
}
