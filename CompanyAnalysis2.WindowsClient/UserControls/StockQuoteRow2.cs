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
    public class StockQuoteRow2 : Panel
    {
        public event RemoveStockQuoteEventHandler StockQuoteRemoved;

        public Stock Stock;
        public DateTime Date;
        public StockQuote Quote;

        public StockQuoteRow2(Stock stock, DateTime date)
        {
            Stock = stock;
            Date = date;
            Quote = Program.Context.StockQuotes.FirstOrDefault(q => q.Date == Date && q.StockId == Stock.Id);

            this.Height = 20;
            this.Dock = DockStyle.Top;

            Label lblDate = new Label();
            lblDate.Text = Date.ToShortDateString();
            lblDate.Height = 20;
            lblDate.Width = 80;
            lblDate.Location = new Point(0, 0);
            lblDate.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblDate);

            Label lblPrice = new Label();
            lblPrice.Height = 20;
            lblPrice.Width = 80;
            lblPrice.Location = new Point(80, 0);
            lblPrice.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblPrice);

            Label lblNumberOfShares = new Label();
            lblNumberOfShares.Height = 20;
            lblNumberOfShares.Width = 180;
            lblNumberOfShares.Location = new Point(160, 0);
            lblNumberOfShares.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblNumberOfShares);

            FontAwesome.Sharp.IconPictureBox btnRemove = new FontAwesome.Sharp.IconPictureBox();
            btnRemove.ActiveColor = System.Drawing.Color.Black;
            btnRemove.BackColor = System.Drawing.Color.Transparent;
            btnRemove.IconChar = FontAwesome.Sharp.IconChar.TrashO;
            btnRemove.InActiveColor = System.Drawing.Color.Gray;
            btnRemove.Location = new System.Drawing.Point(346, 6);
            btnRemove.Margin = new System.Windows.Forms.Padding(0);
            btnRemove.Size = new System.Drawing.Size(16, 16);
            btnRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            btnRemove.Click += btnRemove_Click;
            this.Controls.Add(btnRemove);

            if (Quote == null)
            {
                lblPrice.Text = "-";
                lblNumberOfShares.Text = "-";
            }
            else
            {
                lblPrice.Text = Math.Round(Quote.Price, 2).ToString("#,##0.00");
                if (Quote.NumberOfSharesOutstanding.HasValue)
                    lblNumberOfShares.Text = Quote.NumberOfSharesOutstanding.Value.ToString("#,##0");
                else
                    lblNumberOfShares.Text = "-";
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (Quote != null)
            {
                Program.Context.StockQuotes.Remove(Quote);
                Program.Context.SaveChanges();
                OnRemove(new RemoveStockQuoteEventArgs(this));
            }
        }

        private void OnRemove(RemoveStockQuoteEventArgs e)
        {
            if (StockQuoteRemoved != null)
                StockQuoteRemoved(this, e);
        }
    }

    public delegate void RemoveStockQuoteEventHandler(object sender, RemoveStockQuoteEventArgs e);

    public class RemoveStockQuoteEventArgs : EventArgs
    {
        public StockQuoteRow2 Row { get; set; }
        public RemoveStockQuoteEventArgs(StockQuoteRow2 row)
        {
            Row = row;
        }
    }
}
