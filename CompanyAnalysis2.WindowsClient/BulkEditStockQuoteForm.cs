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
    public partial class BulkEditStockQuoteForm : Form
    {
        public Stock Stock { get; set; }
        public bool Cancel { get; set; }

        public BulkEditStockQuoteForm(Stock stock)
        {
            InitializeComponent();
            Stock = stock;
            this.Text = "Bulk edit | " + stock.Name;
            StockQuote lastQuote = stock.StockQuotes.OrderByDescending(q => q.Date).FirstOrDefault();
            if (lastQuote != null)
            {
                dateTimePickerSharesFrom.Value = lastQuote.Date;
                dateTimePickerSharesTo.Value = lastQuote.Date;
                dateTimePickerPriceFrom.Value = lastQuote.Date;
                dateTimePickerPriceTo.Value = lastQuote.Date;
                txtNumberOfShares.Text = lastQuote.NumberOfSharesOutstanding.ToString();
                txtPrice.Text = lastQuote.Price.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel = true;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Cancel = true;

            if (Stock != null)
            { 
                DateTime fromDate = dateTimePickerSharesFrom.Value.Date;
                DateTime toDate = dateTimePickerSharesTo.Value.Date;

                List<StockQuote> quotes = Program.Context.StockQuotes.Where(q => q.StockId == Stock.Id && q.Date >= fromDate && q.Date <= toDate).ToList();
                foreach (StockQuote quote in quotes)
                    quote.NumberOfSharesOutstanding = long.Parse(txtNumberOfShares.Text);

                fromDate = dateTimePickerPriceFrom.Value.Date;
                toDate = dateTimePickerPriceTo.Value.Date;

                quotes = Program.Context.StockQuotes.Where(q => q.StockId == Stock.Id && q.Date >= fromDate && q.Date <= toDate).ToList();
                foreach (StockQuote quote in quotes)
                    quote.Price = double.Parse(txtPrice.Text);
                
                Program.Context.SaveChanges();
                Cancel = false;
            }

            this.Close();
           
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.Contains('.') == false)) return;
            if ((e.KeyChar == ',') && ((sender as TextBox).SelectionLength == (sender as TextBox).TextLength)) return;

            e.Handled = true;
        }
    }
}
