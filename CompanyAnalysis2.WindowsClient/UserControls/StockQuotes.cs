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
    public partial class StockQuotes : UserControl
    {
        public Stock Stock { get; set; }
        private Panel panelRows;

        public StockQuotes()
        {
            InitializeComponent();
            dtpFrom.Value = DateTime.Now.Date.AddMonths(-3);
            dtpTo.Value = DateTime.Now.Date;
            panelRows = new Panel();
            panelRows.Dock = DockStyle.Fill;
            panelRows.AutoScroll = true;
            panelMain.Controls.Add(panelRows);
            panelRows.BringToFront();

            addStockQuoteRow1.StockQuoteAdded += addRowStockQuoteAdded;
            
        }

        public StockQuotes(Stock stock)
        {
            InitializeComponent();
            Stock = stock;
            dtpFrom.Value = DateTime.Now.Date.AddMonths(-3);
            StockQuote latestQuote = stock.StockQuotes.OrderByDescending(q => q.Date).FirstOrDefault();
            if (latestQuote != null)
                dtpFrom.Value = latestQuote.Date.AddMonths(-3);
            dtpTo.Value = DateTime.Now.Date;
            panelRows = new Panel();
            panelRows.Dock = DockStyle.Fill;
            panelRows.AutoScroll = true;
            panelMain.Controls.Add(panelRows);
            panelRows.BringToFront();

            addStockQuoteRow1.StockQuoteAdded += addRowStockQuoteAdded;

        }

        private void addRowStockQuoteAdded(object sender, AddStockQuoteEventArgs e)
        {
            AddRow(e.StockQuote);
        }

        public void Populate(Stock stock)
        {
            Cursor = Cursors.WaitCursor;
            Stock = stock;
            addStockQuoteRow1.Populate(stock);
           
            panelRows.Controls.Clear();

            foreach (StockQuote quote in Stock.StockQuotes.Where(q => q.Date >= dtpFrom.Value && q.Date <= dtpTo.Value).OrderByDescending(q => q.Date))
            { 
                StockQuoteRow2 quoteRow = new StockQuoteRow2(Stock, quote.Date);
                quoteRow.StockQuoteRemoved += quoteRowStockQuoteRemoved;
                panelRows.Controls.Add(quoteRow);
                quoteRow.BringToFront();
            }

            Cursor = Cursors.Default;
            
        }

        private void quoteRowStockQuoteRemoved(object sender, RemoveStockQuoteEventArgs e)
        {
            RemoveRow(e.Row);
        }

        public void AddRow(StockQuote quote)
        {
            StockQuoteRow2 quoteRow = new StockQuoteRow2(Stock, quote.Date);
            quoteRow.StockQuoteRemoved += quoteRowStockQuoteRemoved;
            panelRows.Controls.Add(quoteRow);
            quoteRow.SendToBack();
            addStockQuoteRow1.Populate(Stock);
        }

        public void RemoveRow(StockQuoteRow2 row)
        {
            panelRows.Controls.Remove(row);
            addStockQuoteRow1.Populate(Stock);
        }

        private void iconButtonRefresh_Click(object sender, EventArgs e)
        {
            Populate(Stock);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadStockQuoteForm form = new DownloadStockQuoteForm(Stock);
            form.StockQuoteAdded += StockQuoteAdded;
            form.ShowDialog();
            Program.Context = new CompanyAnalysis2Context();
            Stock = Program.Context.Stocks.Find(Stock.Id);
            Populate(Stock);
        }

        private void StockQuoteAdded(object sender, AddStockQuoteEventArgs e)
        {
            AddRow(e.StockQuote);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BulkEditStockQuoteForm form = new BulkEditStockQuoteForm(Stock);
            form.ShowDialog();
            if(form.Cancel == false)
                Populate(Stock);
        }

        private void iconButtonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK && dialog.FileName != "")
            {
                Cursor = Cursors.WaitCursor;
                ExcelInterop.ImportStockQuotes(dialog.FileName, Stock);
                Program.Context = new CompanyAnalysis2Context();
                Stock = Program.Context.Stocks.Find(Stock.Id);
                Populate(Stock);
                Cursor = Cursors.Default;
            }
        }

        private void iconButtonExport_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ExcelInterop.ExportStockQuotes(Stock, dtpFrom.Value, dtpTo.Value);
            Cursor = Cursors.Default;
        }
    }
}
