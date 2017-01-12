using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyAnalysis2;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.WindowsClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void Populate()
        {
            statusLabelLoggedOnUser.Text = Program.Data.LoggedOnUser.FirstName + " " + Program.Data.LoggedOnUser.LastName; 
            companyPickerUserControl.Populate(Program.Data.Companies.ToList());
        }

    }
}
