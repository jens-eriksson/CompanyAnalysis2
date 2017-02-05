using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAnalysis2.Model
{
    public partial class Company
    {
        public FinancialIndicator GetLatestIndicators()
        {
            return FinancialIndicators.OrderByDescending(f => f.Period.EndDate).FirstOrDefault();
        }

        public StockQuote GetLastestStockQuote()
        {
            Stock stock = Stocks.FirstOrDefault(s => s.IsDefault);
            if (stock == null)
            {
                stock = Stocks.FirstOrDefault();
            }
            if (stock == null)
            {
                return null;
            }
            else
            {
                return stock.StockQuotes.OrderByDescending(sq => sq.Date).FirstOrDefault();
            }
        }

        public StockQuote GetLastestStockQuote(Stock stock)
        {
            return stock.StockQuotes.OrderByDescending(sq => sq.Date).FirstOrDefault();
        }
    }
}