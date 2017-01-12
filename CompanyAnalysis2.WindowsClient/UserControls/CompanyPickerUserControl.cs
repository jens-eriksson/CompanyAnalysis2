using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyAnalysis2.Model;

namespace CompanyAnalysis2.WindowsClient.UserControls
{
    public partial class CompanyPickerUserControl : UserControl
    {
        private List<Company> _companies;
        public CompanyPickerUserControl()
        {
            InitializeComponent();
        }

        public void Populate(List<Company> companies)
        {
            _companies = companies;
            foreach (Company company in companies)
                txtPicker.AutoCompleteCustomSource.Add(company.Name);
            foreach (Company company in Program.Data.LoggedOnUser.Companies)
                LoadCompany(company.Name);
        }

        private void txtPicker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadCompany(txtPicker.Text);
        }

        private void comapnyUserControl_Close(object sender, CloseCompanyEventArgs e)
        {
            CloseCompany(e.Name);
        }

        public void LoadCompany(string name)
        {
            Company company = _companies.Where(c => c.Name == name).FirstOrDefault();
            if (company == null)
                return;

            if (tabControlCompanies.TabPages.ContainsKey(name))
            {
                tabControlCompanies.TabPages[name].Select();
                return;
            }

            tabControlCompanies.TabPages.Add(name, name);
            TabPage tab = tabControlCompanies.TabPages[name];
            tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CompanyUserControl userControl = new CompanyUserControl();
            userControl.Populate(company);
            userControl.Dock = DockStyle.Fill;
            userControl.Close += comapnyUserControl_Close;
            tab.Controls.Add(userControl);
            tabControlCompanies.SelectedTab = tab;
            txtPicker.Text = "";
        }

        public void CloseCompany(string name)
        {
            if (tabControlCompanies.TabPages.ContainsKey(name))
            {
                tabControlCompanies.TabPages.Remove(tabControlCompanies.TabPages[name]);                
            }
            txtPicker.Focus();
        }

    }
}
