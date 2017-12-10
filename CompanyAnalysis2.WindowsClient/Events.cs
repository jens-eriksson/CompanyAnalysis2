using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.WindowsClient
{
    public delegate void AddReportEventHandler(object sender, AddReportEventArgs e);

    public class AddReportEventArgs : EventArgs
    {
        public Report Report { get; set; }
        public AddReportEventArgs(Report report)
        {
            Report = report;
        }
    }

    public delegate void AddStockQuoteEventHandler(object sender, AddStockQuoteEventArgs e);

    public class AddStockQuoteEventArgs : EventArgs
    {
        public StockQuote StockQuote { get; set; }
        public AddStockQuoteEventArgs(StockQuote quote)
        {
            StockQuote = quote;
        }
    }
}
