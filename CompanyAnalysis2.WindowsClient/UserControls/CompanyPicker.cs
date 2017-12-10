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
    public partial class CompanyPicker : UserControl
    {
        private List<Company> _companies;
        public CompanyPicker()
        {
            InitializeComponent();
        }

        public void Populate(List<Company> companies)
        {
            _companies = companies;
            foreach (Company company in companies)
                txtPicker.AutoCompleteCustomSource.Add(company.Name);
            foreach (Company company in Program.LoggedOnUser.StaredCompanies)
                LoadCompany(company.Id);

            var setting = Program.LoggedOnUser.UserSettings.FirstOrDefault(s => s.Name == "SelectedCompany");
            if (setting != null)
                SelectTab(Convert.ToInt32(setting.Value));
        }

        private void txtPicker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Company company = _companies.FirstOrDefault(c => c.Name == txtPicker.Text);
                if (company != null)
                {
                    LoadCompany(company.Id);
                    SelectTab(company.Id);
                }
            }
                
        }

        private void comapnyUserControl_Close(object sender, CloseCompanyEventArgs e)
        {
            CloseCompany(e.Id);
        }

        public void LoadCompany(int id)
        {
            Company company = _companies.FirstOrDefault(c => c.Id == id);
            if (company == null)
                return;

            if (tabControlCompanies.TabPages.ContainsKey(id.ToString()))
            {
                tabControlCompanies.TabPages[id.ToString()].Select();
                return;
            }

            if (Program.LoggedOnUser.StaredCompanies.Contains(company) == false)
            {
                Program.LoggedOnUser.StaredCompanies.Add(company);
                Program.Context.SaveChanges();
            }

            tabControlCompanies.TabPages.Add(id.ToString(), company.YahooFinanceSymbol);
            SortTabPages();
            TabPage tab = tabControlCompanies.TabPages[id.ToString()];
            tab.Tag = id;
            tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CompanyUserControl userControl = new CompanyUserControl();
            userControl.Populate(company.Id);
            userControl.Dock = DockStyle.Fill;
            userControl.Close += comapnyUserControl_Close;
            tab.Controls.Add(userControl);
            txtPicker.Text = "";
        }

        public void CloseCompany(int id)
        {
            if (tabControlCompanies.TabPages.ContainsKey(id.ToString()))
            {
                tabControlCompanies.TabPages.Remove(tabControlCompanies.TabPages[id.ToString()]);                
            }

            Model.Company company = _companies.FirstOrDefault(c => c.Id == id);
            if (company == null)
                return;

            if (Program.LoggedOnUser.StaredCompanies.Contains(company) == true)
            {
                Program.LoggedOnUser.StaredCompanies.Remove(company);
                Program.Context.SaveChanges();
            }

            txtPicker.Focus();
        }

        private void iconButtonAdd_Click(object sender, EventArgs e)
        {
            EditCompanyForm form = new EditCompanyForm();
            form.ShowDialog();
            if (form.Company != null)
            {
                _companies.Add(form.Company);
                LoadCompany(form.Company.Id);
            }
                
        }

        public void SortTabPages()
        {
            int id = 0;
            if (tabControlCompanies.SelectedTab != null)
                id = Convert.ToInt32(tabControlCompanies.SelectedTab.Tag); 
            var tabList = tabControlCompanies.TabPages.Cast<TabPage>().ToList();
            tabList.Sort(new TabPageComparer());
            tabControlCompanies.TabPages.Clear();
            tabControlCompanies.TabPages.AddRange(tabList.ToArray());
            if (id != 0)
                SelectTab(id);
        }

        public void SelectTab(int id)
        {
            foreach (TabPage tab in tabControlCompanies.TabPages)
            {
                if (Convert.ToInt32(tab.Tag) == id)
                {
                    tabControlCompanies.SelectedTab = tab;
                    break;
                }
            }
        }

        private void tabControlCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlCompanies.SelectedTab != null)
            {
                UserSetting setting = Program.LoggedOnUser.UserSettings.FirstOrDefault(s => s.Name == "SelectedCompany");
                if (setting == null)
                {
                    setting = new UserSetting();
                    setting.Name = "SelectedCompany";
                    Program.LoggedOnUser.UserSettings.Add(setting);
                }

                setting.Value = tabControlCompanies.SelectedTab.Tag.ToString();
                Program.Context.SaveChanges();
            }
        }

        private void iconButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private void iconButtonList_Click(object sender, EventArgs e)
        {
            CompanyListForm form = new CompanyListForm();
            form.Populate();
            form.ShowDialog();
        }
    }

    public class TabPageComparer : IComparer<TabPage>
    {
        public int Compare(TabPage x, TabPage y)
        {
            return string.Compare(x.Text, y.Text);
        }
    }
}
