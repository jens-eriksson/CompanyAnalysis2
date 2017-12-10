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
using System.Configuration;

namespace CompanyAnalysis2.WindowsClient
{
    public partial class DownloadStockQuoteForm : Form
    {
        public event AddStockQuoteEventHandler StockQuoteAdded;

        public Stock Stock { get; set; }
        public StockQuotesClient Client { get; set; }
        private string _response;

        public DownloadStockQuoteForm()
        {
            InitializeComponent();
        }

        public DownloadStockQuoteForm(Stock stock)
        {
            InitializeComponent();
            Stock = stock;
            txtUrl.Text = ConfigurationManager.AppSettings["StockQuoteUrl"] +  stock.Name;
            Client = new StockQuotesClient();
            //Client.StockQuoteAdded += Client_StockQuoteAdded;
            Download();
        }

        private void Client_StockQuoteAdded(object sender, AddStockQuoteEventArgs e)
        {
            OnStockQuoteAdded(e.StockQuote);
        }

        private void Download()
        {
            _response = Client.Download(Stock, txtUrl.Text);
            txtResponse.Text = _response.Replace("\n", "\r\n");
        }

        private void Import()
        {
            if(txtResponse.Text != "")
            {
                long defaultNumberOfShares = 0;
                StockQuote latestQuote = Stock.StockQuotes.OrderByDescending(q => q.Date).FirstOrDefault();

                if (latestQuote != null && latestQuote.NumberOfSharesOutstanding.HasValue)
                    defaultNumberOfShares = latestQuote.NumberOfSharesOutstanding.Value;

                Client.SaveQuotes(Client.Parse(_response, Stock, defaultNumberOfShares), chkUpdate.Checked);
            }
        }

        private void OnStockQuoteAdded(StockQuote quote)
        {
            if (StockQuoteAdded != null)
                StockQuoteAdded(this, new AddStockQuoteEventArgs(quote));
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Download();
            MessageBox.Show("Import completed successfully");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Import();
            Cursor = Cursors.Default;
            this.Close();
        }
    }
}
