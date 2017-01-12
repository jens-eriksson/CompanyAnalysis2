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
        public static Data Data;
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
            Data = new Data();
            
            splash.SetMessage("Loading data...");
            Data.Load();
            
            MainForm mainForm = new MainForm();
            mainForm.Populate();
            splash.Close();
            Application.Run(mainForm);
        }
    }
}
