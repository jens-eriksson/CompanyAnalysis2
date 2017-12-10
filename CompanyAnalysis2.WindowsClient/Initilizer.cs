using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyAnalysis2.Model;
using System.Configuration;

namespace CompanyAnalysis2.WindowsClient
{
    public class Initilizer
    {
        public static void UpdateStockQutoes(List<Company> companies)
        {
            foreach (Company company in companies)
            {
                StockQuotesClient client = new StockQuotesClient();
                try
                {
                    foreach (Stock stock in company.Stocks)
                    {
                        StockQuote lastQuote = stock.StockQuotes.OrderByDescending(q => q.Date).FirstOrDefault();
                        long numberOfShares = 0;
                        if (lastQuote != null && lastQuote.NumberOfSharesOutstanding.HasValue)
                            numberOfShares = lastQuote.NumberOfSharesOutstanding.Value;
                        string url = ConfigurationManager.AppSettings["StockQuoteUrl"] + stock.Name;
                        string response = client.Download(stock, url);
                        List<StockQuote> qoutes = client.Parse(response, stock, numberOfShares);
                        client.SaveQuotes(qoutes, false);
                    }
                }
                catch
                {
                }
            }
        }

        public static void RecalculateIndicators(List<Company> companies)
        {
            foreach (Company company in companies)
                try
                {
                    Calculations.CreateOrUpdateIndicator(company, Program.Context);
                }
                catch
                { }
        }

        public static void CheckAndCreateNewPeriods()
        {
            DateTime date = DateTime.Now;
            Period lastPeriod = Program.Context.Periods.OrderByDescending(p => p.EndDate).FirstOrDefault();

            if (lastPeriod == null)
            {
                lastPeriod = new Period();
                lastPeriod.Name = "2007 Q1";
                lastPeriod.Quarter = 1;
                lastPeriod.StartDate = DateTime.Parse("2007-01-01");
                lastPeriod.EndDate = DateTime.Parse("2007-03-31");
                Program.Context.Periods.Add(lastPeriod);
            }

            if (date.Year > lastPeriod.EndDate.Year)
            {
                int diff = date.Year - lastPeriod.EndDate.Year;
                for (int i = 1; i<=diff; i++)
                {
                    string year = (lastPeriod.EndDate.Year + i).ToString();

                    Period q1 = new Period();
                    q1.Name = year + " Q1";
                    q1.Quarter = 1;
                    q1.StartDate = DateTime.Parse(year + "-01-01");
                    q1.EndDate = DateTime.Parse(year + "-03-31");
                    Program.Context.Periods.Add(q1);

                    Period q2 = new Period();
                    q2.Name = year + " Q2";
                    q2.Quarter = 2;
                    q2.StartDate = DateTime.Parse(year + "-04-01");
                    q2.EndDate = DateTime.Parse(year + "-06-30");
                    Program.Context.Periods.Add(q2);

                    Period q3 = new Period();
                    q3.Name = year + " Q3";
                    q3.Quarter = 3;
                    q3.StartDate = DateTime.Parse(year + "-07-01");
                    q3.EndDate = DateTime.Parse(year + "-09-30");
                    Program.Context.Periods.Add(q3);

                    Period q4 = new Period();
                    q4.Name = year + " Q4";
                    q4.Quarter = 4;
                    q4.StartDate = DateTime.Parse(year + "-10-01");
                    q4.EndDate = DateTime.Parse(year + "-12-31");
                    Program.Context.Periods.Add(q4);

                }
            }

            Program.Context.SaveChanges();
        }
    }
}
