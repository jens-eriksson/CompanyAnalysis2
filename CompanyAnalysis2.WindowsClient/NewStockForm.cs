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
    public partial class NewStockForm : Form
    {
        public Company Company { get; set; }

        public NewStockForm()
        {
            InitializeComponent();
        }

        public NewStockForm(Company company)
        {
            InitializeComponent();
            Company = company;
            this.Text = "New Stock | " + Company.Name;
            if (company.Stocks.Where(s => s.IsDefault).Count() == 0)
                chkIsDefault.Checked = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFinaceSymbol.Text != "" && Company != null)
            {
                if (chkIsDefault.Checked)
                    foreach (Stock s in Company.Stocks)
                        s.IsDefault = false;

                Stock stock = new Stock();
                stock.Company = Company;
                stock.CompanyId = Company.Id;
                stock.IsDefault = chkIsDefault.Checked;
                stock.Name = txtFinaceSymbol.Text;

                Program.Context.Stocks.Add(stock);
                Program.Context.SaveChanges();
                this.Close();
            }

            
           
        }
    }
}
