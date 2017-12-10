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
    public partial class NumbersForm : Form
    {
        public NumbersForm()
        {
            InitializeComponent();
        }

        public void Populate(Company company)
        {
            this.Text = company.Name + " | Numbers";
            lblCompany.Text = company.Name;
            overviewTable1.Populate(company);
        }
    }
}
