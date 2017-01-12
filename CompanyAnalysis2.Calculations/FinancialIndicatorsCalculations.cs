using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.Calculations
{
    public class FinancialIndicatorsCalculations
    {
        public void Calculate(int companyId)
        {
            CompanyAnalysis2Context ctx = new CompanyAnalysis2Context();
            foreach (Period period in ctx.Periods.OrderBy(p => p.EndDate))
                Calculate(companyId, period.Id);
        }
        public void Calculate(int companyId, int periodId)
        {
            CompanyAnalysis2Context ctx = new CompanyAnalysis2Context();
            Company company = ctx.Companies.Find(companyId);
            Period period = ctx.Periods.Find(periodId);
            Report report = company.Reports.Where(r => r.Period.Id == periodId).FirstOrDefault();
            if (company == null || report == null || period == null)
                return;

            double marketCap = 0;

            foreach (Stock stock in company.Stocks)
            {
                StockQuote quote = ctx.StockQuotes.Find(period.EndDate, stock.Id);
                if (quote == null)
                    return;
                if (quote.NumberOfSharesOutstanding.HasValue == false)
                    return;
                marketCap += quote.NumberOfSharesOutstanding.Value * quote.Price;
            }
                        
            FinancialIndicator financialIndicator = company.FinancialIndicators.Where(c => c.Period.Id == periodId).FirstOrDefault();
            if (financialIndicator == null)
            {
                financialIndicator = new FinancialIndicator();
                ctx.FinancialIndicators.Add(financialIndicator);
            }
            financialIndicator.PeriodId = periodId;
            financialIndicator.CompanyId = companyId;
            financialIndicator.MarketCap = marketCap;

            //Calculate period numbers
            financialIndicator.NetIncome = report.NetIncome;
            financialIndicator.Revenue = report.Revenue;
            financialIndicator.Assets = report.Assets;
            financialIndicator.Equity = report.Equity;
            financialIndicator.ProfitMargin = report.NetIncome / report.Revenue;
            financialIndicator.Solidity = report.Equity / report.Assets;

            //Calculate TTM numbers
            List<Report> reports = company.Reports.Where(r => r.Period.EndDate <= period.EndDate).ToList();
            if (reports.Count() >= 4)
            {
                financialIndicator.RevenueTTM = reports.OrderByDescending(r => r.Period.StartDate).Take(4).Sum(r => r.Revenue);
                financialIndicator.NetIncomeTTM = reports.OrderByDescending(r => r.Period.StartDate).Take(4).Sum(r => r.NetIncome);
                financialIndicator.ProfitMarginTTM = financialIndicator.NetIncomeTTM / financialIndicator.RevenueTTM;
                financialIndicator.ReturnOnAssetsTTM = financialIndicator.NetIncomeTTM / financialIndicator.Assets;
                financialIndicator.ReturnOnEquityTTM = financialIndicator.NetIncomeTTM / financialIndicator.Equity;
                financialIndicator.PeTTM = financialIndicator.MarketCap / financialIndicator.NetIncomeTTM;
                financialIndicator.InvestmentGradeTTM = financialIndicator.ReturnOnAssetsTTM * financialIndicator.PeTTM * 10;

                //Calculate growth numbers
                FinancialIndicator previousYear = ctx.FinancialIndicators.Where(fi => fi.Period.EndDate < period.EndDate).OrderByDescending(fi => fi.Period.EndDate).Take(4).OrderBy(fi => fi.Period.EndDate).FirstOrDefault();
                if (previousYear != null)
                {
                    if (previousYear.Equity.HasValue)
                        financialIndicator.EqutiyGrowthTTM = financialIndicator.Equity / previousYear.Equity - 1;
                    if (previousYear.NetIncomeTTM.HasValue)
                        financialIndicator.NetIncomeGrowthTTM = financialIndicator.NetIncomeTTM / previousYear.NetIncomeTTM - 1;
                    if (previousYear.RevenueTTM.HasValue)
                        financialIndicator.RevenueGrowthTTM = financialIndicator.RevenueTTM / previousYear.RevenueTTM - 1;
                }
            }

            ctx.SaveChanges();
        }

    }
}
