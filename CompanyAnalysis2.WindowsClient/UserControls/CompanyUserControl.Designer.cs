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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyUserControl));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageOverview = new System.Windows.Forms.TabPage();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.tabPageStockQuotes = new System.Windows.Forms.TabPage();
            this.panelStocksTop = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.btnClose = new FontAwesome.Sharp.IconPictureBox();
            this.btnCalculateNumbers = new FontAwesome.Sharp.IconButton();
            this.btnEdit = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButtonCharts = new FontAwesome.Sharp.IconButton();
            this.panelHr2 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblRecalculated = new System.Windows.Forms.Label();
            this.lblMarketCap = new System.Windows.Forms.Label();
            this.lblPeTTM = new System.Windows.Forms.Label();
            this.lblCompanyInfo = new System.Windows.Forms.Label();
            this.panelHr1 = new System.Windows.Forms.Panel();
            this.overview = new CompanyAnalysis2.WindowsClient.UserControls.Overview();
            this.reports = new CompanyAnalysis2.WindowsClient.UserControls.Reports();
            this.stocks = new CompanyAnalysis2.WindowsClient.UserControls.Stocks();
            this.tabControl.SuspendLayout();
            this.tabPageOverview.SuspendLayout();
            this.tabPageReports.SuspendLayout();
            this.tabPageStockQuotes.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageOverview);
            this.tabControl.Controls.Add(this.tabPageReports);
            this.tabControl.Controls.Add(this.tabPageStockQuotes);
            this.tabControl.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl.Location = new System.Drawing.Point(3, 71);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1063, 488);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            // 
            // tabPageOverview
            // 
            this.tabPageOverview.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageOverview.Controls.Add(this.overview);
            this.tabPageOverview.Location = new System.Drawing.Point(4, 34);
            this.tabPageOverview.Name = "tabPageOverview";
            this.tabPageOverview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOverview.Size = new System.Drawing.Size(1055, 450);
            this.tabPageOverview.TabIndex = 0;
            this.tabPageOverview.Text = "Overview";
            // 
            // tabPageReports
            // 
            this.tabPageReports.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageReports.Controls.Add(this.reports);
            this.tabPageReports.Location = new System.Drawing.Point(4, 34);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReports.Size = new System.Drawing.Size(1055, 450);
            this.tabPageReports.TabIndex = 1;
            this.tabPageReports.Text = "Reports";
            // 
            // tabPageStockQuotes
            // 
            this.tabPageStockQuotes.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStockQuotes.Controls.Add(this.stocks);
            this.tabPageStockQuotes.Controls.Add(this.panelStocksTop);
            this.tabPageStockQuotes.Location = new System.Drawing.Point(4, 34);
            this.tabPageStockQuotes.Name = "tabPageStockQuotes";
            this.tabPageStockQuotes.Size = new System.Drawing.Size(1055, 450);
            this.tabPageStockQuotes.TabIndex = 2;
            this.tabPageStockQuotes.Text = "Stock Quotes";
            // 
            // panelStocksTop
            // 
            this.panelStocksTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStocksTop.Location = new System.Drawing.Point(0, 0);
            this.panelStocksTop.Name = "panelStocksTop";
            this.panelStocksTop.Size = new System.Drawing.Size(1055, 10);
            this.panelStocksTop.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblCompanyName);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 1);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1066, 39);
            this.panelTop.TabIndex = 1;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(7, 10);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(133, 18);
            this.lblCompanyName.TabIndex = 16;
            this.lblCompanyName.Text = "[CompanyName]";
            // 
            // btnClose
            // 
            this.btnClose.ActiveColor = System.Drawing.Color.Black;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnClose.InActiveColor = System.Drawing.Color.Gray;
            this.btnClose.Location = new System.Drawing.Point(1038, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 7;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCalculateNumbers
            // 
            this.btnCalculateNumbers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCalculateNumbers.Icon = FontAwesome.Sharp.IconChar.Calculator;
            this.btnCalculateNumbers.IconColor = System.Drawing.Color.Black;
            this.btnCalculateNumbers.IconSize = 16;
            this.btnCalculateNumbers.Image = ((System.Drawing.Image)(resources.GetObject("btnCalculateNumbers.Image")));
            this.btnCalculateNumbers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalculateNumbers.Location = new System.Drawing.Point(3, 6);
            this.btnCalculateNumbers.Name = "btnCalculateNumbers";
            this.btnCalculateNumbers.Size = new System.Drawing.Size(98, 24);
            this.btnCalculateNumbers.TabIndex = 6;
            this.btnCalculateNumbers.Text = "Recalculate..";
            this.btnCalculateNumbers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalculateNumbers.UseVisualStyleBackColor = true;
            this.btnCalculateNumbers.Click += new System.EventHandler(this.btnCalculateNumbers_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Icon = FontAwesome.Sharp.IconChar.PencilSquareO;
            this.btnEdit.IconColor = System.Drawing.Color.Black;
            this.btnEdit.IconSize = 16;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(265, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(51, 24);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButton1.Icon = FontAwesome.Sharp.IconChar.Table;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconSize = 16;
            this.iconButton1.Image = ((System.Drawing.Image)(resources.GetObject("iconButton1.Image")));
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(181, 6);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(78, 24);
            this.iconButton1.TabIndex = 4;
            this.iconButton1.Text = "Numbers";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconButtonCharts
            // 
            this.iconButtonCharts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButtonCharts.Icon = FontAwesome.Sharp.IconChar.BarChart;
            this.iconButtonCharts.IconColor = System.Drawing.Color.Black;
            this.iconButtonCharts.IconSize = 16;
            this.iconButtonCharts.Image = ((System.Drawing.Image)(resources.GetObject("iconButtonCharts.Image")));
            this.iconButtonCharts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonCharts.Location = new System.Drawing.Point(106, 6);
            this.iconButtonCharts.Name = "iconButtonCharts";
            this.iconButtonCharts.Size = new System.Drawing.Size(68, 24);
            this.iconButtonCharts.TabIndex = 3;
            this.iconButtonCharts.Text = "Charts";
            this.iconButtonCharts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButtonCharts.UseVisualStyleBackColor = true;
            this.iconButtonCharts.Click += new System.EventHandler(this.iconButtonCharts_Click);
            // 
            // panelHr2
            // 
            this.panelHr2.BackColor = System.Drawing.SystemColors.MenuText;
            this.panelHr2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHr2.Location = new System.Drawing.Point(0, 40);
            this.panelHr2.Name = "panelHr2";
            this.panelHr2.Size = new System.Drawing.Size(1066, 1);
            this.panelHr2.TabIndex = 5;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnCalculateNumbers);
            this.panelMain.Controls.Add(this.lblRecalculated);
            this.panelMain.Controls.Add(this.btnEdit);
            this.panelMain.Controls.Add(this.iconButton1);
            this.panelMain.Controls.Add(this.lblMarketCap);
            this.panelMain.Controls.Add(this.iconButtonCharts);
            this.panelMain.Controls.Add(this.lblPeTTM);
            this.panelMain.Controls.Add(this.lblCompanyInfo);
            this.panelMain.Controls.Add(this.tabControl);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 41);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1066, 555);
            this.panelMain.TabIndex = 6;
            // 
            // lblRecalculated
            // 
            this.lblRecalculated.AutoSize = true;
            this.lblRecalculated.Location = new System.Drawing.Point(358, 43);
            this.lblRecalculated.Name = "lblRecalculated";
            this.lblRecalculated.Size = new System.Drawing.Size(73, 13);
            this.lblRecalculated.TabIndex = 15;
            this.lblRecalculated.Text = "Recalculated:";
            // 
            // lblMarketCap
            // 
            this.lblMarketCap.AutoSize = true;
            this.lblMarketCap.Location = new System.Drawing.Point(233, 43);
            this.lblMarketCap.Name = "lblMarketCap";
            this.lblMarketCap.Size = new System.Drawing.Size(64, 13);
            this.lblMarketCap.TabIndex = 14;
            this.lblMarketCap.Text = "Market cap:";
            // 
            // lblPeTTM
            // 
            this.lblPeTTM.AutoSize = true;
            this.lblPeTTM.Location = new System.Drawing.Point(124, 43);
            this.lblPeTTM.Name = "lblPeTTM";
            this.lblPeTTM.Size = new System.Drawing.Size(52, 13);
            this.lblPeTTM.TabIndex = 13;
            this.lblPeTTM.Text = "P/E TTM";
            // 
            // lblCompanyInfo
            // 
            this.lblCompanyInfo.AutoSize = true;
            this.lblCompanyInfo.Location = new System.Drawing.Point(5, 43);
            this.lblCompanyInfo.Name = "lblCompanyInfo";
            this.lblCompanyInfo.Size = new System.Drawing.Size(51, 13);
            this.lblCompanyInfo.TabIndex = 9;
            this.lblCompanyInfo.Text = "Company";
            // 
            // panelHr1
            // 
            this.panelHr1.BackColor = System.Drawing.SystemColors.MenuText;
            this.panelHr1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHr1.Location = new System.Drawing.Point(0, 0);
            this.panelHr1.Margin = new System.Windows.Forms.Padding(0);
            this.panelHr1.Name = "panelHr1";
            this.panelHr1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panelHr1.Size = new System.Drawing.Size(1066, 1);
            this.panelHr1.TabIndex = 17;
            // 
            // overview
            // 
            this.overview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overview.Location = new System.Drawing.Point(3, 3);
            this.overview.Name = "overview";
            this.overview.Size = new System.Drawing.Size(1049, 444);
            this.overview.TabIndex = 0;
            // 
            // reports
            // 
            this.reports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reports.Location = new System.Drawing.Point(3, 3);
            this.reports.Name = "reports";
            this.reports.Size = new System.Drawing.Size(1049, 444);
            this.reports.TabIndex = 0;
            // 
            // stocks
            // 
            this.stocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stocks.Location = new System.Drawing.Point(0, 10);
            this.stocks.Name = "stocks";
            this.stocks.Size = new System.Drawing.Size(1055, 440);
            this.stocks.TabIndex = 0;
            // 
            // CompanyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHr2);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelHr1);
            this.Name = "CompanyUserControl";
            this.Size = new System.Drawing.Size(1066, 596);
            this.tabControl.ResumeLayout(false);
            this.tabPageOverview.ResumeLayout(false);
            this.tabPageReports.ResumeLayout(false);
            this.tabPageStockQuotes.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageOverview;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.TabPage tabPageStockQuotes;
        private Overview overview;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelHr2;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblCompanyInfo;
        private FontAwesome.Sharp.IconButton iconButtonCharts;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Reports reports;
        private Stocks stocks;
        private FontAwesome.Sharp.IconButton btnEdit;
        private System.Windows.Forms.Label lblMarketCap;
        private System.Windows.Forms.Label lblPeTTM;
        private FontAwesome.Sharp.IconButton btnCalculateNumbers;
        private System.Windows.Forms.Panel panelStocksTop;
        private FontAwesome.Sharp.IconPictureBox btnClose;
        private System.Windows.Forms.Label lblRecalculated;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Panel panelHr1;
    }
}
