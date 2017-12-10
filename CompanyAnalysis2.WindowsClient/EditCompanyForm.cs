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
    public partial class EditCompanyForm : Form
    {
        public Company Company
        {
            get { return _company; }
        }

        private Company _company;

        public EditCompanyForm()
        {
            InitializeComponent();
            this.Text = "New Company";
            txtName.Focus();
        }

        public void SetCompany(Company company)
        {
            _company = company;
            this.Text = _company.Name;
            txtName.Text = _company.Name;
            txtFinaceSymbol.Text = _company.YahooFinanceSymbol;
            txtCurrency.Text = _company.Currency;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_company == null)
            {
                _company = new Company();
                _company.CreatedByUserId = Program.LoggedOnUser.Id;
                _company.Hidden = false;
                Program.Context.Companies.Add(_company);
                Stock stock = new Stock();
                stock.Company = _company;
                stock.Name = txtFinaceSymbol.Text;
                stock.IsDefault = true;
                Program.Context.Stocks.Add(stock);
            }

            _company.Name = txtName.Text;
            _company.Currency = txtCurrency.Text;
            _company.YahooFinanceSymbol = txtFinaceSymbol.Text;

            if (_company.Stocks.FirstOrDefault(s => s.Name == _company.YahooFinanceSymbol) == null)
            {
                Stock stock = new Stock();
                stock.Company = _company;
                stock.Name = _company.YahooFinanceSymbol;
                Program.Context.Stocks.Add(stock);
            }

            Program.Context.SaveChanges();
            this.DialogResult = DialogResult.OK;
            this.Close();
           
        }
    }
}
