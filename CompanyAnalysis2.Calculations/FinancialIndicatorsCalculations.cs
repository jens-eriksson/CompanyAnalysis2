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
        private CompanyAnalysis2Context _ctx;

        public FinancialIndicatorsCalculations(CompanyAnalysis2Context context)
        {
            _ctx = context;
        }
        public void Calculate(int companyId)
        {  
            foreach (Period period in _ctx.Periods.OrderBy(p => p.EndDate))
                CreateOrUpdateIndicator(companyId, period.Id);
            _ctx.SaveChanges();
        }
        public void Calculate(int companyId, int periodId)
        {
            CreateOrUpdateIndicator(companyId, periodId);
            _ctx.SaveChanges();
        }

        private void CreateOrUpdateIndicator(int companyId, int periodId)
        {
            Company company = _ctx.Companies.Find(companyId);
            Period period = _ctx.Periods.Find(periodId);
            Report report = company.Reports.Where(r => r.Period.Id == periodId).FirstOrDefault();
            FinancialIndicator financialIndicator = company.FinancialIndicators.Where(c => c.Period.Id == periodId).FirstOrDefault();

            if (company == null || report == null || period == null)
                return;
            if (report.Revenue == 0 && report.NetIncome == 0 && report.Assets == 0 && report.Equity == 0)
            {
                if (financialIndicator != null)
                    company.FinancialIndicators.Remove(financialIndicator);
                return;
            }

            double marketCap = 0;

            foreach (Stock stock in company.Stocks)
            {
                StockQuote quote = _ctx.StockQuotes.Find(period.EndDate, stock.Id);
                if (quote == null)
                    return;
                if (quote.NumberOfSharesOutstanding.HasValue == false)
                    return;
                marketCap += quote.NumberOfSharesOutstanding.Value * quote.Price / 1000000;
            }
            
            if (financialIndicator == null)
            {
                financialIndicator = new FinancialIndicator();
                _ctx.FinancialIndicators.Add(financialIndicator);
            }
            financialIndicator.PeriodId = periodId;
            financialIndicator.CompanyId = companyId;
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
            List<Report> reports = company.Reports.Where(r => r.Period.EndDate <= period.EndDate).ToList();
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
                financialIndicator.InvestmentGradeTTM = financialIndicator.ReturnOnAssetsTTM * financialIndicator.PeTTM * 10;

                //Calculate growth numbers
                FinancialIndicator previousPeroid = _ctx.FinancialIndicators.Where(fi => fi.CompanyId == companyId && fi.Period.EndDate < period.EndDate).OrderByDescending(fi => fi.Period.EndDate).FirstOrDefault();
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
        }
    }
}
