using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.WebApp.Util
{
    public class ExcelImport
    {
        public static void ImportReports(int cid, HttpPostedFileBase fileUpload)
        {
            //CompanyAnalysis2Context context = new CompanyAnalysis2Context();
            //Company company = context.Companies.Find(cid);
            //string extention = fileUpload.FileName.Split((".").ToCharArray()).Last();
            //IExcelDataReader excelReader = null;
            //if (extention == "xlsx")
            //    excelReader = ExcelReaderFactory.CreateOpenXmlReader(fileUpload.InputStream);
            //else
            //    throw new Exception("Invalid file type");
            //excelReader.Read();

            //while (excelReader.Read())
            //{
            //    if (excelReader[0] != null && excelReader[1] != null && excelReader[2] != null && excelReader[3] != null && excelReader[4] != null && excelReader[5] != null && excelReader[6] != null)
            //    {
            //        int year = Convert.ToInt32(excelReader[0]);
            //        int quarter = Convert.ToInt32(excelReader[1]);
            //        double revenue = Convert.ToDouble(excelReader[2].ToString().Replace(".", ","));
            //        double netIncome = Convert.ToDouble(excelReader[3].ToString().Replace(".", ","));
            //        double assets = Convert.ToDouble(excelReader[4].ToString().Replace(".", ","));
            //        double equity = Convert.ToDouble(excelReader[5].ToString().Replace(".", ","));
            //        long numberOfShares = Convert.ToInt64(excelReader[6]);
                    
            //        Period period = context.Periods.Where(p => p.Quarter == quarter & p.Year == year).First();

            //        Report report = null;

            //        if (context.Reports.Where(r => r.CompanyId == cid & r.PeriodId == period.Id).Count() > 0)
            //            report = context.Reports.Where(r => r.CompanyId == cid & r.PeriodId == period.Id).First();

            //        if (report == null)
            //        {
            //            report = new Report();
            //            context.Reports.Add(report);
            //        }

            //        report.Company = company;
            //        report.Period = period;
            //        report.Revenue = revenue;
            //        report.NetIncome = netIncome;
            //        report.Assets = assets;
            //        report.Equity = equity;

            //        if (excelReader[7] != null)
            //        {
            //            StockPrice stockPrice = context.StockPrices.Find(period.EndDate, company.Id);
            //            if (stockPrice == null)
            //            {
            //                stockPrice = new StockPrice();
            //                stockPrice.Date = period.EndDate.Value;
            //                stockPrice.Company = company;
            //                stockPrice.Price = Convert.ToDouble(excelReader[7].ToString().Replace(".", ","));
            //                context.StockPrices.Add(stockPrice);
            //            }
            //            else
            //            {
            //                stockPrice.Price = Convert.ToDouble(excelReader[7].ToString().Replace(".", ","));
            //            }
            //        }
            //    }
            //}

            //foreach (Report report in company.Reports.OrderBy(r => r.Period.StartDate))
            //    report.UpdateNumbers();
            //company.UpdateNumbers();

            //context.SaveChanges();
        }

        public static void ImportStockPrices(int cid, HttpPostedFileBase fileUpload)
        {
            //CompanyAnalysis2Context context = new CompanyAnalysis2Context();
            //string extention = fileUpload.FileName.Split((".").ToCharArray()).Last();
            //IExcelDataReader excelReader = null;
            //if (extention == "xlsx")
            //    excelReader = ExcelReaderFactory.CreateOpenXmlReader(fileUpload.InputStream);
            //else
            //    throw new Exception("Invalid file type");
            //excelReader.Read();

            //while (excelReader.Read())
            //{
            //    if (excelReader[0] != null)
            //    {
            //        DateTime date = Convert.ToDateTime(excelReader[0]);
            //        double price = Convert.ToDouble(excelReader[1].ToString().Replace(".", ","));

            //        StockPrice stockPrice = context.StockPrices.Find(date, cid);
            //        if (stockPrice == null)
            //        {
            //            stockPrice = new StockPrice();
            //            stockPrice.CompanyId = cid;
            //            stockPrice.Date = date;
            //            context.StockPrices.Add(stockPrice);
            //        }

            //        stockPrice.Price = price;
            //    }
            //}

            //context.SaveChanges();

        }
    }
}