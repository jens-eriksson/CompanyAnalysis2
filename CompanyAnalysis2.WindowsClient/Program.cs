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
        public static User LoggedOnUser { get; set; }
        public static CompanyAnalysis2Context Context { get; set; }
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
            splash.SetMessage("Initializing...");
            
            Context = new CompanyAnalysis2Context();
            LoggedOnUser = Context.Users.Find(1);
            Initilizer.CheckAndCreateNewPeriods();

            MainForm mainForm = new MainForm();
            mainForm.Populate();
            
            splash.Close();
            Application.Run(mainForm);
        }
    }
}
