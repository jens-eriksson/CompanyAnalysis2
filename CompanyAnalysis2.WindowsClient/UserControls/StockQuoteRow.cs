using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyAnalysis2.Model;
using System.Drawing;
using FontAwesome.Sharp;

namespace CompanyAnalysis2.WindowsClient.UserControls
{
    public class StockQuoteRow : Panel
    {
        public Stock Stock;
        public DateTime Date;
        public StockQuote Quote;

        private TextBox txtPrice;
        private TextBox txtNumberOfShares;

        private bool isPopulating = false;

        public StockQuoteRow(Stock stock, DateTime date)
        {
            Stock = stock;
            Date = date;
            Quote = Program.Context.StockQuotes.FirstOrDefault(q => q.Date == Date && q.StockId == Stock.Id);

            txtPrice = new TextBox();
            txtNumberOfShares = new TextBox();
            
            this.Height = 20;
            this.Dock = DockStyle.Top;

            Label lblDate = new Label();
            lblDate.Text = Date.ToShortDateString();
            lblDate.Height = 25;
            lblDate.Width = 80;
            lblDate.TextAlign = ContentAlignment.MiddleLeft;
            lblDate.Dock = DockStyle.Left;
            this.Controls.Add(lblDate);

            txtPrice.Width = 80;
            txtPrice.Dock = DockStyle.Left;
            txtPrice.KeyPress += txt_KeyPress;
            txtPrice.LostFocus += txt_LostFocus;
            txtPrice.TextChanged += txt_TextChanged;
            this.Controls.Add(txtPrice);
            txtPrice.BringToFront();

            txtNumberOfShares.Width = 180;
            txtNumberOfShares.Dock = DockStyle.Left;
            txtNumberOfShares.Tag = Quote;
            txtNumberOfShares.KeyPress += txt_KeyPress;
            txtNumberOfShares.LostFocus += txt_LostFocus;
            txtNumberOfShares.TextChanged += txt_TextChanged;
            this.Controls.Add(txtNumberOfShares);
            txtNumberOfShares.BringToFront();

            Populate();
        }

        public void Populate()
        {
            isPopulating = true;

            if (Quote == null)
            {
                txtPrice.Text = "0";
                txtNumberOfShares.Text = "0";
            }
            else
            {
                txtPrice.Text = Quote.Price.ToString();
                txtNumberOfShares.Text = Quote.NumberOfSharesOutstanding.ToString();                
            }

            isPopulating = false;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            UpdateQuote();
        }

        private void txt_LostFocus(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "") (sender as TextBox).Text = "0";
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.Contains('.') == false)) return;
            if ((e.KeyChar == ',') && ((sender as TextBox).SelectionLength == (sender as TextBox).TextLength)) return;

            e.Handled = true;
        }

        private void UpdateQuote()
        {
            if (isPopulating)
                return;

            if ((txtPrice.Text == "0" | txtPrice.Text == "") && (txtNumberOfShares.Text == "0" | txtNumberOfShares.Text == ""))
            {
                if(Quote != null)
                {
                    Program.Context.StockQuotes.Remove(Quote);
                    Quote = null;
                }
                
            }
            else
            {
                if (Quote == null)
                {
                    Quote = new StockQuote();
                    Quote.StockId = Stock.Id;
                    Quote.Date = Date;
                    Program.Context.StockQuotes.Add(Quote);
                }

                if (txtPrice.Text != "")
                    Quote.Price = Convert.ToDouble(txtPrice.Text);
                else
                    Quote.Price = 0;

                if (txtNumberOfShares.Text != "")
                    Quote.NumberOfSharesOutstanding = Convert.ToInt64(txtNumberOfShares.Text);
                else
                    Quote.NumberOfSharesOutstanding = 0;

            }

        }

    }
}
