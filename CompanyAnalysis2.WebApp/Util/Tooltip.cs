using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyAnalysis2.WebApp.Util
{
    public class Tooltip
    {
        public static string Get(string id)
        { 
            string result = "";
            switch (id)
            { 
                case "InvestmentGradeR12":
                    result = "Investeringsbetyg = (1 / P/E) * E/A * 1000.\r\nInvesteringsbetyget kombinerar P/E och E/A.\r\nEtt bolag med bra värdering och bra intjäningsförmåga får ett högt investeringsbetyg.";
                    break;
                case "YieldR12":
                    result = "Earnings/Price\r\nEtt mått på hur mycket bolaget tjänar i förhållande till vad det är värt.\r\nTalar om hur prisvärd aktien är.";
                    break;
                case "ReturnOnTotalCapitalR12":
                    result = "Earnings/Assets\r\nEtt mått på hur mycket bolaget tjänar i förhållande till hur mycket kapital det behöver binda.\r\nTalar om hur bra bolaget är på att tjäna pengar.";
                    break;
            }
            return result;
        
        }
    }
}