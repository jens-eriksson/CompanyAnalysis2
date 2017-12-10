using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyAnalysis2.Model;
using System.Drawing;
using FontAwesome.Sharp;

namespace CompanyAnalysis2.WindowsClient.UserControls
{
    public class ReportRow2 : Panel
    {
        public event RemoveReportEventHandler ReportRemoved;

        public Report Report { get; set; }

        public ReportRow2(Report report)
        {
            Report = report;

            this.Height = 20;
            this.Dock = DockStyle.Top;

            Label lblPeroid = new Label();
            lblPeroid.Text = report.Period.Name;
            lblPeroid.Height = 20;
            lblPeroid.Width = 80;
            lblPeroid.Location = new Point(0, 0);
            lblPeroid.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblPeroid);

            Label lblRevenue = new Label();
            lblRevenue.Height = 20;
            lblRevenue.Width = 80;
            lblRevenue.Location = new Point(80, 0);
            lblRevenue.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblRevenue);

            Label lblNetIncome = new Label();
            lblNetIncome.Height = 20;
            lblNetIncome.Width = 80;
            lblNetIncome.Location = new Point(160, 0);
            lblNetIncome.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblNetIncome);

            Label lblAssets = new Label();
            lblAssets.Height = 20;
            lblAssets.Width = 80;
            lblAssets.Location = new Point(240, 0);
            lblAssets.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblAssets);

            Label lblEquity = new Label();
            lblEquity.Height = 20;
            lblEquity.Width = 80;
            lblEquity.Location = new Point(320, 0);
            lblEquity.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblEquity);

            FontAwesome.Sharp.IconPictureBox btnRemove = new FontAwesome.Sharp.IconPictureBox();
            btnRemove.ActiveColor = System.Drawing.Color.Black;
            btnRemove.BackColor = System.Drawing.Color.Transparent;
            btnRemove.IconChar = FontAwesome.Sharp.IconChar.TrashO;
            btnRemove.InActiveColor = System.Drawing.Color.Gray;
            btnRemove.Location = new System.Drawing.Point(400, 6);
            btnRemove.Margin = new System.Windows.Forms.Padding(0);
            btnRemove.Size = new System.Drawing.Size(16, 16);
            btnRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            btnRemove.Click += btnRemove_Click;
            this.Controls.Add(btnRemove);

            if (Report == null)
            {
                lblRevenue.Text = "-";
                lblNetIncome.Text = "-";
                lblAssets.Text = "-";
                lblEquity.Text = "-";
            }
            else
            {
                lblRevenue.Text = Report.Revenue.ToString("#,##0.00");
                lblNetIncome.Text = Report.NetIncome.ToString("#,##0.00");
                lblAssets.Text = Report.Assets.ToString("#,##0.00");
                lblEquity.Text = Report.Equity.ToString("#,##0.00");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (Report != null)
            {
                Program.Context.Reports.Remove(Report);
                Program.Context.SaveChanges();
                OnRemove(new RemoveReportEventArgs(this));
            }
        }

        private void OnRemove(RemoveReportEventArgs e)
        {
            if (ReportRemoved != null)
                ReportRemoved(this, e);
        }
    }

    public delegate void RemoveReportEventHandler(object sender, RemoveReportEventArgs e);

    public class RemoveReportEventArgs : EventArgs
    {
        public ReportRow2 Row { get; set; }
        public RemoveReportEventArgs(ReportRow2 row)
        {
            Row = row;
        }
    }
}
