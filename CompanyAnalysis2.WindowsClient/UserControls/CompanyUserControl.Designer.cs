namespace CompanyAnalysis2.WindowsClient.UserControls
{
    partial class CompanyUserControl
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageOverview = new System.Windows.Forms.TabPage();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.tabPageStockQuotes = new System.Windows.Forms.TabPage();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCalculateNumbers = new System.Windows.Forms.Button();
            this.companyOverviewUserControl1 = new CompanyAnalysis2.WindowsClient.UserControls.CompanyOverviewUserControl();
            this.tabControl.SuspendLayout();
            this.tabPageOverview.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageOverview);
            this.tabControl.Controls.Add(this.tabPageReports);
            this.tabControl.Controls.Add(this.tabPageStockQuotes);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 29);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(495, 426);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageOverview
            // 
            this.tabPageOverview.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageOverview.Controls.Add(this.companyOverviewUserControl1);
            this.tabPageOverview.Location = new System.Drawing.Point(4, 22);
            this.tabPageOverview.Name = "tabPageOverview";
            this.tabPageOverview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOverview.Size = new System.Drawing.Size(487, 400);
            this.tabPageOverview.TabIndex = 0;
            this.tabPageOverview.Text = "Overview";
            // 
            // tabPageReports
            // 
            this.tabPageReports.Location = new System.Drawing.Point(4, 22);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReports.Size = new System.Drawing.Size(487, 400);
            this.tabPageReports.TabIndex = 1;
            this.tabPageReports.Text = "Reports";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // tabPageStockQuotes
            // 
            this.tabPageStockQuotes.Location = new System.Drawing.Point(4, 22);
            this.tabPageStockQuotes.Name = "tabPageStockQuotes";
            this.tabPageStockQuotes.Size = new System.Drawing.Size(487, 400);
            this.tabPageStockQuotes.TabIndex = 2;
            this.tabPageStockQuotes.Text = "Stock Quotes";
            this.tabPageStockQuotes.UseVisualStyleBackColor = true;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.btnCalculateNumbers);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(495, 29);
            this.panelTop.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(417, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCalculateNumbers
            // 
            this.btnCalculateNumbers.Location = new System.Drawing.Point(3, 3);
            this.btnCalculateNumbers.Name = "btnCalculateNumbers";
            this.btnCalculateNumbers.Size = new System.Drawing.Size(160, 23);
            this.btnCalculateNumbers.TabIndex = 1;
            this.btnCalculateNumbers.Text = "Calculate Financial Indicators";
            this.btnCalculateNumbers.UseVisualStyleBackColor = true;
            this.btnCalculateNumbers.Click += new System.EventHandler(this.btnCalculateNumbers_Click);
            // 
            // companyOverviewUserControl1
            // 
            this.companyOverviewUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.companyOverviewUserControl1.Location = new System.Drawing.Point(3, 3);
            this.companyOverviewUserControl1.Name = "companyOverviewUserControl1";
            this.companyOverviewUserControl1.Size = new System.Drawing.Size(481, 394);
            this.companyOverviewUserControl1.TabIndex = 0;
            // 
            // CompanyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelTop);
            this.Name = "CompanyUserControl";
            this.Size = new System.Drawing.Size(495, 455);
            this.tabControl.ResumeLayout(false);
            this.tabPageOverview.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageOverview;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.TabPage tabPageStockQuotes;
        private CompanyOverviewUserControl companyOverviewUserControl1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCalculateNumbers;
    }
}
