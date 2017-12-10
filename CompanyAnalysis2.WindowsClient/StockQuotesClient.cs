using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyAnalysis2.Model;
using System.Net;
using System.Data.SqlClient;
using System.Configuration;

namespace CompanyAnalysis2.WindowsClient
{
    public class StockQuotesClient
    {
        public event AddStockQuoteEventHandler StockQuoteAdded;

        public string Download(Stock stock, string url)
        {
            StockQuote lastQuote = stock.StockQuotes.OrderByDescending(s => s.Date).FirstOrDefault();
            long numberOfShares = 0;
            if (lastQuote != null)
            {
                if(lastQuote.NumberOfSharesOutstanding.HasValue)
                    numberOfShares = lastQuote.NumberOfSharesOutstanding.Value;
            }
                
            WebClient webClient = new WebClient();
            string response = webClient.DownloadString(url);
            return response;
        }

        public List<StockQuote> Parse(string response, Stock stock, long defaultNumberOfShares)
        {
            string[] rows = response.Split("\r\n".ToCharArray());

            List<StockQuote> result = new List<StockQuote>();

            for (int i = 1; i < rows.Length - 1; i++)
            {
                string[] values = rows[i].Split(",".ToCharArray());
                DateTime date = DateTime.Parse(values[0]);
                double price = double.Parse(values[4].Replace(".", ","));

                StockQuote quote = new StockQuote();
                quote.Date = date;
                quote.Price = price;
                quote.Stock = stock;
                quote.StockId = stock.Id;
                quote.NumberOfSharesOutstanding = defaultNumberOfShares;

                result.Add(quote);
            }

            if (result.Count == 0)
                return result;

            DateTime startDate = result.OrderBy(q => q.Date).FirstOrDefault().Date;
            DateTime endDate = result.OrderByDescending(q => q.Date).FirstOrDefault().Date;
            StockQuote previous = null;
            do
            {
                StockQuote quote = result.FirstOrDefault(q => q.Date == startDate);

                if (quote == null && previous != null)
                {
                    quote = new StockQuote();
                    quote.Date = startDate;
                    quote.NumberOfSharesOutstanding = previous.NumberOfSharesOutstanding;
                    quote.Price = previous.Price;
                    quote.Stock = stock;
                    quote.StockId = previous.StockId;
                    result.Add(quote);
                }

                previous = quote;
                startDate = startDate.AddDays(1);
            }
            while (startDate <= endDate);

            return result;
        }

        public void SaveQuotes(List<StockQuote> quotes, bool update)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CompanyAnalysis2"].ConnectionString);
            conn.Open();

            foreach(StockQuote quote in quotes)
            {
                SqlCommand selectCommand = new SqlCommand("SELECT * FROM StockQuote WHERE [Date] = '" + quote.Date.ToShortDateString() + "' AND StockId = " + quote.StockId.ToString());
                selectCommand.Connection = conn;

                SqlDataReader reader = selectCommand.ExecuteReader();
                bool exists = reader.HasRows;
                reader.Close();

                if (exists)
                {
                    if (update)
                    {
                        string sql = "UPDATE StockQuote SET Price = " + quote.Price.ToString().Replace(",", ".") + " WHERE [Date] = '" + quote.Date.ToShortDateString() + "' AND StockId = " + quote.StockId.ToString();
                        SqlCommand updateCommand = new SqlCommand(sql);
                        updateCommand.Connection = conn;
                        updateCommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    string sql = "INSERT StockQuote([Date], StockId, Price, NumberOfSharesOutstanding) VALUES('" + quote.Date.ToShortDateString() + "', " + quote.StockId.ToString() + ", " + quote.Price.ToString().Replace(",", ".") + ", " + quote.NumberOfSharesOutstanding.ToString() + ")";
                    SqlCommand insertCommand = new SqlCommand(sql);
                    insertCommand.Connection = conn;
                    insertCommand.ExecuteNonQuery();
                    //OnStockQuoteAdded(quote);
                }


                //StockQuote existingQuote = Program.Context.StockQuotes.Find(quote.Date, quote.Stock.Id);
                //if (existingQuote != null)
                //{
                //    if(update)
                //    {
                //        existingQuote.Price = quote.Price;
                //        Program.Context.SaveChanges();
                //    }

                //}
                //else
                //{
                //    Program.Context.StockQuotes
                //    Program.Context.SaveChanges();
                //    OnStockQuoteAdded(quote);
                //}

            }

            conn.Close();
        }

        private void OnStockQuoteAdded(StockQuote quote)
        {
            //Program.Context.StockQuotes.Attach(quote);
            //Program.Context.Entry(quote).Reload();

            if (StockQuoteAdded != null)
                StockQuoteAdded(this, new AddStockQuoteEventArgs(quote));
        }
    }
}
