using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAnalysis2.Model
{
    public class Calculations
    {
        public static void CreateOrUpdateIndicator(Company company, CompanyAnalysis2Context ctx)
        {
            foreach (Report report in company.Reports)
                CreateOrUpdateIndicator(company, report, ctx);
        }

        public static void CreateOrUpdateIndicator(Company company, Report report, CompanyAnalysis2Context ctx)
        {
            if (company == null || report == null)
                return;
            
            FinancialIndicator financialIndicator = company.FinancialIndicators.Where(f => f.Period == report.Period).FirstOrDefault();
            
            if (report.Revenue == 0 && report.NetIncome == 0 && report.Assets == 0 && report.Equity == 0)
            {
                if (financialIndicator != null)
                    ctx.FinancialIndicators.Remove(financialIndicator);
                return;
            }

            double marketCap = 0;

            foreach (Stock stock in company.Stocks)
            {
                StockQuote quote = ctx.StockQuotes.Find(report.Period.EndDate, stock.Id);
                if (quote == null)
                    continue;
                if (quote.NumberOfSharesOutstanding.HasValue == false)
                    continue;
                marketCap += quote.NumberOfSharesOutstanding.Value * quote.Price / 1000000;
            }

            if (financialIndicator == null)
            {
                financialIndicator = new FinancialIndicator();
                ctx.FinancialIndicators.Add(financialIndicator);
            }
            financialIndicator.Period = report.Period;
            financialIndicator.Company = company;
            financialIndicator.MarketCap = marketCap;

            //Calculate period numbers
            financialIndicator.NetIncome = report.NetIncome;
            financialIndicator.Revenue = report.Revenue;
            financialIndicator.Assets = report.Assets;
            financialIndicator.Equity = report.Equity;
            if (report.Revenue == 0)
                financialIndicator.ProfitMargin = 0;
            else
                financialIndicator.ProfitMargin = report.NetIncome / report.Revenue;
            if (report.Assets == 0)
                financialIndicator.Solidity = 0;
            else
                financialIndicator.Solidity = report.Equity / report.Assets;

            financialIndicator.RevenueTTM = 0;
            financialIndicator.NetIncomeTTM = 0;
            financialIndicator.ProfitMarginTTM = 0;
            financialIndicator.ReturnOnAssetsTTM = 0;
            financialIndicator.ReturnOnEquityTTM = 0;
            financialIndicator.PeTTM = 0;
            financialIndicator.InvestmentGradeTTM = 0;
            financialIndicator.EqutiyGrowthTTM = 0;
            financialIndicator.NetIncomeGrowthTTM = 0;
            financialIndicator.RevenueGrowthTTM = 0;

            //Calculate TTM numbers
            List<Report> reports = company.Reports.Where(r => r.Period.EndDate <= report.Period.EndDate).ToList();
            if (reports.Count() >= 4)
            {
                financialIndicator.RevenueTTM = reports.OrderByDescending(r => r.Period.StartDate).Take(4).Sum(r => r.Revenue);
                financialIndicator.NetIncomeTTM = reports.OrderByDescending(r => r.Period.StartDate).Take(4).Sum(r => r.NetIncome);
                if (financialIndicator.RevenueTTM == 0)
                    financialIndicator.ProfitMarginTTM = 0;
                else
                    financialIndicator.ProfitMarginTTM = financialIndicator.NetIncomeTTM / financialIndicator.RevenueTTM;
                if (financialIndicator.Assets == 0)
                    financialIndicator.ReturnOnAssetsTTM = 0;
                else
                    financialIndicator.ReturnOnAssetsTTM = financialIndicator.NetIncomeTTM / financialIndicator.Assets;
                if (financialIndicator.Equity == 0)
                    financialIndicator.ReturnOnEquityTTM = 0;
                else
                    financialIndicator.ReturnOnEquityTTM = financialIndicator.NetIncomeTTM / financialIndicator.Equity;
                if (financialIndicator.NetIncomeTTM == 0)
                    financialIndicator.PeTTM = 0;
                else
                    financialIndicator.PeTTM = financialIndicator.MarketCap / financialIndicator.NetIncomeTTM;
                financialIndicator.InvestmentGradeTTM = financialIndicator.ReturnOnAssetsTTM * (1/financialIndicator.PeTTM) * 1000;

                //Calculate growth numbers
                FinancialIndicator previousPeroid = ctx.FinancialIndicators.Where(fi => fi.Company.Id == company.Id && fi.Period.EndDate < report.Period.EndDate).OrderByDescending(fi => fi.Period.EndDate).FirstOrDefault();
                if (previousPeroid != null)
                {
                    if (previousPeroid.Equity != 0)
                        financialIndicator.EqutiyGrowthTTM = financialIndicator.Equity / previousPeroid.Equity - 1;
                    if (previousPeroid.NetIncomeTTM != 0)
                        financialIndicator.NetIncomeGrowthTTM = financialIndicator.NetIncomeTTM / previousPeroid.NetIncomeTTM - 1;
                    if (previousPeroid.RevenueTTM != 0)
                        financialIndicator.RevenueGrowthTTM = financialIndicator.RevenueTTM / previousPeroid.RevenueTTM - 1;
                }
            }

            //Latest valuation
            marketCap = 0;

            foreach (Stock stock in company.Stocks)
            {
                StockQuote quote = ctx.StockQuotes.Where(q => q.StockId == stock.Id).OrderByDescending(q => q.Date).FirstOrDefault();
                if (quote == null)
                    continue;
                if (quote.NumberOfSharesOutstanding.HasValue == false)
                    continue;
                marketCap += quote.NumberOfSharesOutstanding.Value * quote.Price / 1000000;
            }

            company.MarketCap = marketCap;
            company.PeTTM = 0;

            financialIndicator = company.FinancialIndicators.OrderByDescending(fi => fi.Period.EndDate).FirstOrDefault();

            if (financialIndicator != null && financialIndicator.NetIncomeTTM != 0)
                company.PeTTM = marketCap / financialIndicator.NetIncomeTTM;

            company.Recalculated = DateTime.Now;

            ctx.SaveChanges();
        }
    }
}
