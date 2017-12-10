namespace CompanyAnalysis2.WindowsClient.UserControls
{
    public partial class Reports
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.panelHeadings = new System.Windows.Forms.Panel();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.panelHr = new System.Windows.Forms.Panel();
            this.lblEquity = new System.Windows.Forms.Label();
            this.lblAssets = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.lblNetIncome = new System.Windows.Forms.Label();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.iconButtonImport = new FontAwesome.Sharp.IconButton();
            this.panelRows = new System.Windows.Forms.Panel();
            this.dtpNextReportDate = new System.Windows.Forms.DateTimePicker();
            this.lblNextReportDate = new System.Windows.Forms.Label();
            this.iconButtonExport = new FontAwesome.Sharp.IconButton();
            this.addReportRow1 = new CompanyAnalysis2.WindowsClient.UserControls.AddReportRow();
            this.panelHeadings.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeadings
            // 
            this.panelHeadings.Controls.Add(this.lblPeriod);
            this.panelHeadings.Controls.Add(this.panelHr);
            this.panelHeadings.Controls.Add(this.lblEquity);
            this.panelHeadings.Controls.Add(this.lblAssets);
            this.panelHeadings.Controls.Add(this.lblRevenue);
            this.panelHeadings.Controls.Add(this.lblNetIncome);
            this.panelHeadings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeadings.Location = new System.Drawing.Point(0, 75);
            this.panelHeadings.Name = "panelHeadings";
            this.panelHeadings.Size = new System.Drawing.Size(721, 20);
            this.panelHeadings.TabIndex = 1;
            // 
            // lblPeriod
            // 
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 0);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(60, 15);
            this.lblPeriod.TabIndex = 5;
            this.lblPeriod.Text = "Period";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelHr
            // 
            this.panelHr.BackColor = System.Drawing.Color.Black;
            this.panelHr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelHr.Location = new System.Drawing.Point(0, 19);
            this.panelHr.Name = "panelHr";
            this.panelHr.Size = new System.Drawing.Size(721, 1);
            this.panelHr.TabIndex = 4;
            // 
            // lblEquity
            // 
            this.lblEquity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquity.Location = new System.Drawing.Point(320, 0);
            this.lblEquity.Name = "lblEquity";
            this.lblEquity.Size = new System.Drawing.Size(80, 15);
            this.lblEquity.TabIndex = 3;
            this.lblEquity.Text = "Equity";
            this.lblEquity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAssets
            // 
            this.lblAssets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssets.Location = new System.Drawing.Point(240, 0);
            this.lblAssets.Name = "lblAssets";
            this.lblAssets.Size = new System.Drawing.Size(80, 15);
            this.lblAssets.TabIndex = 2;
            this.lblAssets.Text = "Assets";
            this.lblAssets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRevenue
            // 
            this.lblRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenue.Location = new System.Drawing.Point(80, 0);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(80, 15);
            this.lblRevenue.TabIndex = 1;
            this.lblRevenue.Text = "Revenue";
            this.lblRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNetIncome
            // 
            this.lblNetIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetIncome.Location = new System.Drawing.Point(160, 0);
            this.lblNetIncome.Name = "lblNetIncome";
            this.lblNetIncome.Size = new System.Drawing.Size(80, 15);
            this.lblNetIncome.TabIndex = 0;
            this.lblNetIncome.Text = "Net Income";
            this.lblNetIncome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelToolbar
            // 
            this.panelToolbar.Controls.Add(this.iconButtonExport);
            this.panelToolbar.Controls.Add(this.dtpNextReportDate);
            this.panelToolbar.Controls.Add(this.lblNextReportDate);
            this.panelToolbar.Controls.Add(this.iconButtonImport);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(721, 75);
            this.panelToolbar.TabIndex = 2;
            // 
            // iconButtonImport
            // 
            this.iconButtonImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButtonImport.Icon = FontAwesome.Sharp.IconChar.FileExcelO;
            this.iconButtonImport.IconColor = System.Drawing.Color.Black;
            this.iconButtonImport.IconSize = 16;
            this.iconButtonImport.Image = ((System.Drawing.Image)(resources.GetObject("iconButtonImport.Image")));
            this.iconButtonImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonImport.Location = new System.Drawing.Point(3, 4);
            this.iconButtonImport.Name = "iconButtonImport";
            this.iconButtonImport.Size = new System.Drawing.Size(69, 24);
            this.iconButtonImport.TabIndex = 1;
            this.iconButtonImport.Text = "Import";
            this.iconButtonImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButtonImport.UseVisualStyleBackColor = true;
            this.iconButtonImport.Click += new System.EventHandler(this.iconButtonImport_Click);
            // 
            // panelRows
            // 
            this.panelRows.AutoScroll = true;
            this.panelRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRows.Location = new System.Drawing.Point(0, 130);
            this.panelRows.Name = "panelRows";
            this.panelRows.Size = new System.Drawing.Size(721, 291);
            this.panelRows.TabIndex = 3;
            // 
            // dtpNextReportDate
            // 
            this.dtpNextReportDate.CustomFormat = "";
            this.dtpNextReportDate.Location = new System.Drawing.Point(71, 36);
            this.dtpNextReportDate.Name = "dtpNextReportDate";
            this.dtpNextReportDate.Size = new System.Drawing.Size(200, 20);
            this.dtpNextReportDate.TabIndex = 14;
            this.dtpNextReportDate.ValueChanged += new System.EventHandler(this.dtpNextReportDate_ValueChanged);
            // 
            // lblNextReportDate
            // 
            this.lblNextReportDate.AutoSize = true;
            this.lblNextReportDate.Location = new System.Drawing.Point(1, 38);
            this.lblNextReportDate.Name = "lblNextReportDate";
            this.lblNextReportDate.Size = new System.Drawing.Size(64, 13);
            this.lblNextReportDate.TabIndex = 13;
            this.lblNextReportDate.Text = "Next Report";
            // 
            // iconButtonExport
            // 
            this.iconButtonExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButtonExport.Icon = FontAwesome.Sharp.IconChar.FileExcelO;
            this.iconButtonExport.IconColor = System.Drawing.Color.Black;
            this.iconButtonExport.IconSize = 16;
            this.iconButtonExport.Image = ((System.Drawing.Image)(resources.GetObject("iconButtonExport.Image")));
            this.iconButtonExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonExport.Location = new System.Drawing.Point(83, 4);
            this.iconButtonExport.Name = "iconButtonExport";
            this.iconButtonExport.Size = new System.Drawing.Size(69, 24);
            this.iconButtonExport.TabIndex = 15;
            this.iconButtonExport.Text = "Export";
            this.iconButtonExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButtonExport.UseVisualStyleBackColor = true;
            this.iconButtonExport.Click += new System.EventHandler(this.iconButtonExport_Click);
            // 
            // addReportRow1
            // 
            this.addReportRow1.Dock = System.Windows.Forms.DockStyle.Top;
            this.addReportRow1.Location = new System.Drawing.Point(0, 95);
            this.addReportRow1.Name = "addReportRow1";
            this.addReportRow1.Size = new System.Drawing.Size(721, 35);
            this.addReportRow1.TabIndex = 4;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRows);
            this.Controls.Add(this.addReportRow1);
            this.Controls.Add(this.panelHeadings);
            this.Controls.Add(this.panelToolbar);
            this.Name = "Reports";
            this.Size = new System.Drawing.Size(721, 421);
            this.panelHeadings.ResumeLayout(false);
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelHeadings;
        private System.Windows.Forms.Panel panelHr;
        private System.Windows.Forms.Label lblEquity;
        private System.Windows.Forms.Label lblAssets;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label lblNetIncome;
        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.Panel panelRows;
        private FontAwesome.Sharp.IconButton iconButtonImport;
        private System.Windows.Forms.Label lblPeriod;
        private AddReportRow addReportRow1;
        private System.Windows.Forms.DateTimePicker dtpNextReportDate;
        private System.Windows.Forms.Label lblNextReportDate;
        private FontAwesome.Sharp.IconButton iconButtonExport;
    }
}
