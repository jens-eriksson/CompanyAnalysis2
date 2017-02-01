using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.WindowsClient
{
    static class Program
    {
        public static List<Period> Periods;
        public static List<Company> Companies;
        public static User LoggedOnUser;
        public static CompanyAnalysis2Container DataContainer;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SplashForm splash = new SplashForm();
            splash.Show();
            Application.DoEvents();
            DataContainer = new CompanyAnalysis2Container(new Uri(ConfigurationManager.AppSettings["ODataUri"]));
            splash.SetMessage("Loading data...");
            LoadData();
            MainForm mainForm = new MainForm();
            mainForm.Populate();
            splash.Close();
            Application.Run(mainForm);
        }

        static void LoadData()
        {
            LoggedOnUser = DataContainer.Users.ByKey(1).Expand("StaredCompanies").GetValue();
            Periods = DataContainer.Periods.Execute().ToList();
            Companies = DataContainer.Companies.Execute().ToList();
        }
    }
}
