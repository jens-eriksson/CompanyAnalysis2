using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.WindowsClient
{
    public class ExcelInterop
    {
        public static void ImportReports(string fileName, Company company)
        {
            var excelApp = new Excel.Application();

            Excel.Workbook workbook = excelApp.Workbooks.Open(fileName); //, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Excel.Worksheet sheet = workbook.Worksheets[1];

            for (int i = 2; i <= sheet.UsedRange.Rows.Count; i++)
            {
                string periodName = ((Excel.Range)sheet.Cells[i, 1]).Value2;
                var revenue = ((Excel.Range)sheet.Cells[i, 2]).Value2;
                var netIncome = ((Excel.Range)sheet.Cells[i, 3]).Value2;
                var assets = ((Excel.Range)sheet.Cells[i, 4]).Value2;
                var equity = ((Excel.Range)sheet.Cells[i, 5]).Value2;
                var ceo = ((Excel.Range)sheet.Cells[i, 6]).Value2;

                string[] array = periodName.Split(" ".ToCharArray());

                if (array[0].Length == 2)
                    periodName = array[1] + " " + array[0];

                Period period = Program.Context.Periods.FirstOrDefault(p => p.Name == periodName);
                if (period == null)
                    continue;

                Report report = Program.Context.Reports.FirstOrDefault(r => r.Period.Name == periodName && r.CompanyId == company.Id);
                if (report == null)
                {
                    report = new Report();
                    report.Company = company;
                    report.CompanyId = company.Id;
                    report.PeriodId = period.Id;
                    Program.Context.Reports.Add(report);
                }

                report.Revenue = revenue;
                report.NetIncome = netIncome;
                report.Assets = assets;
                report.Equity = equity;
                report.CreatedByUserId = Program.LoggedOnUser.Id;
            }

            workbook.Close();
            excelApp.Quit();
        }

        public static void ExportReports(Company company)
        {
            var excelApp = new Excel.Application();
            excelApp.Visible = true;

            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet sheet = workbook.Worksheets[1];

            ((Excel.Range)sheet.Cells[1, 1]).Value2 = "Period";
            ((Excel.Range)sheet.Cells[1, 2]).Value2 = "Revenue";
            ((Excel.Range)sheet.Cells[1, 3]).Value2 = "Net Income";
            ((Excel.Range)sheet.Cells[1, 4]).Value2 = "Assets";
            ((Excel.Range)sheet.Cells[1, 5]).Value2 = "Equity";

            int counter = 2;

            foreach (Report report in company.Reports.OrderByDescending(r => r.Period.EndDate))
            {
                ((Excel.Range)sheet.Cells[counter, 1]).Value2 = report.Period.Name;
                ((Excel.Range)sheet.Cells[counter, 2]).Value2 = report.Revenue;
                ((Excel.Range)sheet.Cells[counter, 3]).Value2 = report.NetIncome;
                ((Excel.Range)sheet.Cells[counter, 4]).Value2 = report.Assets;
                ((Excel.Range)sheet.Cells[counter, 5]).Value2 = report.Equity;

                counter++;
            }
        }

        public static void ImportStockQuotes(string fileName, Stock stock)
        {
            var excelApp = new Excel.Application();

            Excel.Workbook workbook = excelApp.Workbooks.Open(fileName);
            Excel.Worksheet sheet = workbook.Worksheets[1];

            List<StockQuote> quotes = new List<StockQuote>();

            for (int i = 2; i <= sheet.UsedRange.Rows.Count; i++)
            {
                var dateVal = ((Excel.Range)sheet.Cells[i, 1]).Value;
                var priceVal = ((Excel.Range)sheet.Cells[i, 2]).Value;
                var numOfSharesVal = ((Excel.Range)sheet.Cells[i, 3]).Value;

                DateTime date;
                if (DateTime.TryParse(dateVal.ToString(), out date) == false)
                    continue;
                double price;
                if (double.TryParse(priceVal.ToString(), out price) == false)
                    continue;
                long numOfShares;
                if (long.TryParse(numOfSharesVal.ToString(), out numOfShares) == false)
                    continue;

                StockQuote quote = new StockQuote();
                quote.Stock = stock;
                quote.StockId = stock.Id;
                quote.Date = date;
                quote.Price = price;
                quote.NumberOfSharesOutstanding = numOfShares;

                quotes.Add(quote);

            }

            StockQuotesClient client = new StockQuotesClient();
            client.SaveQuotes(quotes, true);

            workbook.Close();
            excelApp.Quit();
        }

        public static void ExportStockQuotes(Stock stock, DateTime fromDate, DateTime toDate)
        {
            var excelApp = new Excel.Application();

            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet sheet = workbook.Worksheets[1];

            ((Excel.Range)sheet.Cells[1, 1]).Value2 = "Date";
            ((Excel.Range)sheet.Cells[1, 2]).Value2 = "Price";
            ((Excel.Range)sheet.Cells[1, 3]).Value2 = "Number Of Shares";

            int counter = 2;

            foreach (StockQuote quote in stock.StockQuotes.Where(q => q.Date >= fromDate && q.Date <= toDate).OrderByDescending(q => q.Date))
            {
                ((Excel.Range)sheet.Cells[counter, 1]).Value2 = quote.Date.ToShortDateString();
                ((Excel.Range)sheet.Cells[counter, 2]).Value2 = quote.Price;
                ((Excel.Range)sheet.Cells[counter, 3]).Value2 = quote.NumberOfSharesOutstanding;

                counter++;
            }

            excelApp.Visible = true;
        }
    }
}
