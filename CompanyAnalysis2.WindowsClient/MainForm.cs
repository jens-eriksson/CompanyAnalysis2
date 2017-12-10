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
            statusLabelLoggedOnUser.Text = Program.LoggedOnUser.FirstName + " " + Program.LoggedOnUser.LastName; 
            companyPickerUserControl.Populate(Program.Context.Companies.Where(c => c.Hidden == false).ToList());
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Program.Context = new CompanyAnalysis2Context();
            Populate();
            Cursor.Current = Cursors.Default;
        }
    }
}
