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
using CompanyAnalysis2.WindowsClient;

namespace CompanyAnalysis2.WindowsClient.UserControls
{
    public partial class AddStockQuoteRow : UserControl
    {
        public event AddStockQuoteEventHandler StockQuoteAdded;
        private Stock _stock;

        public AddStockQuoteRow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStockQuote();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AddStockQuote();
                return;
            }

            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.Contains('.') == false)) return;
            if ((e.KeyChar == ',') && ((sender as TextBox).SelectionLength == (sender as TextBox).TextLength)) return;

            e.Handled = true;
        }

        public void Populate(Stock stock)
        {
            _stock = stock;
            this.Dock = DockStyle.Top;
            StockQuote lastQuote = Program.Context.StockQuotes.Where(q => q.StockId == stock.Id).OrderByDescending(q => q.Date).FirstOrDefault();

            DateTime startDate = DateTime.Parse("2007-01-01");
            DateTime endDate = DateTime.Now.Date;

            if (lastQuote != null)
            {
                startDate = lastQuote.Date.AddDays(1);
                txtPrice.Text = lastQuote.Price.ToString();
                txtNumOfShares.Text = lastQuote.NumberOfSharesOutstanding.ToString();
            }

            cboDate.Items.Clear();

            do
            {
                cboDate.Items.Add(endDate);
                endDate = endDate.AddDays(-1);
            }
            while (endDate >= startDate);

            if (cboDate.Items.Count > 0)
                cboDate.SelectedIndex = cboDate.Items.Count - 1;

            txtPrice.Focus();
        }

        private void AddStockQuote()
        {
            if (_stock == null)
                return;

            DateTime date;
            if (DateTime.TryParse(cboDate.SelectedItem.ToString(), out date) == false)
            {
                MessageBox.Show("Incorrect date");
                return;
            }

            if (_stock.StockQuotes.Where(q => q.Date == date).FirstOrDefault() != null)
            {
                MessageBox.Show("Quote already exists");
                return;
            }

            double price = 0;
            long numberOfShares = 0;

            if (txtPrice.Text != "")
                price = double.Parse(txtPrice.Text);
            if (txtNumOfShares.Text != "")
                numberOfShares = long.Parse(txtNumOfShares.Text);

            StockQuote quote = new StockQuote();
            quote.Stock = _stock;
            quote.StockId = _stock.Id;
            quote.Date = date;
            quote.Price = price;
            quote.NumberOfSharesOutstanding = numberOfShares;

            Program.Context.StockQuotes.Add(quote);
            Program.Context.SaveChanges();

            OnAdd(new AddStockQuoteEventArgs(quote));
        }

        private void OnAdd(AddStockQuoteEventArgs e)
        {
            if (StockQuoteAdded != null)
                StockQuoteAdded(this, e);
        }

    }
}
