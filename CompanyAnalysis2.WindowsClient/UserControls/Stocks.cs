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
    public partial class Stocks : UserControl
    {
        private Model.Company _company;

        public Stocks()
        {
            InitializeComponent();
        }

        public void Populate(Model.Company company)
        {
            _company = company;

            tabControl.TabPages.Clear();

            foreach(Stock stock in company.Stocks)
            {
                TabPage stockPage = new TabPage(stock.Name);
                StockQuotes quotes = new StockQuotes(stock);
                quotes.Populate(stock);
                quotes.Dock = DockStyle.Fill;
                stockPage.Controls.Add(quotes);
                tabControl.TabPages.Add(stockPage);
            }
        }

        private void iconButtonAdd_Click(object sender, EventArgs e)
        {
            NewStockForm form = new NewStockForm(_company);
            form.ShowDialog();
            Populate(_company);
        }

        private void iconButtonDelete_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab != null)
            {
                StockQuotes quotes = (StockQuotes)tabControl.SelectedTab.Controls[0];
                DialogResult result = MessageBox.Show("Are you sure you want to delete " + quotes.Stock.Name + "?", "Delete " + quotes.Stock.Name, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Program.Context.Stocks.Remove(quotes.Stock);
                    Program.Context.SaveChanges();
                    Populate(_company);
                }
            }
            
        }
    }
}
