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
    public partial class Reports : UserControl
    {
        private Model.Company _company;

        public Reports()
        {
            InitializeComponent();
            addReportRow1.ReportAdded += addRow_ReportAdded;
        }

        public void Populate(Model.Company company)
        {
            Cursor = Cursors.WaitCursor;
            _company = company;
            addReportRow1.Populate(_company);

            panelRows.Controls.Clear();

            foreach (Report report in company.Reports.OrderByDescending(r=> r.Period.EndDate))
            {
                ReportRow2 row = new ReportRow2(report);
                row.ReportRemoved += reportRow_ReportRemoved;
                panelRows.Controls.Add(row);
                row.BringToFront();
            }

            Cursor = Cursors.Default;
        }

        private void iconButtonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if(result == DialogResult.OK && dialog.FileName != "")
            {
                ExcelInterop.ImportReports(dialog.FileName, _company);
                Program.Context.SaveChanges();
                Populate(_company);
            }
        }

        public void AddRow(Report report)
        {
            ReportRow2 reportRow = new ReportRow2(report);
            reportRow.ReportRemoved += reportRow_ReportRemoved;
            panelRows.Controls.Add(reportRow);
            reportRow.SendToBack();
            addReportRow1.Populate(_company);
        }

        public void RemoveRow(ReportRow2 row)
        {
            panelRows.Controls.Remove(row);
            addReportRow1.Populate(_company);
        }

        private void addRow_ReportAdded(object sender, AddReportEventArgs e)
        {
            AddRow(e.Report);
        }

        private void reportRow_ReportRemoved(object sender, RemoveReportEventArgs e)
        {
            RemoveRow(e.Row);
        }

        private void dtpNextReportDate_ValueChanged(object sender, EventArgs e)
        {
            _company.NextReportDate = dtpNextReportDate.Value;
            Program.Context.SaveChanges();
        }

        private void iconButtonExport_Click(object sender, EventArgs e)
        {
            ExcelInterop.ExportReports(_company);
        }
    }
}
