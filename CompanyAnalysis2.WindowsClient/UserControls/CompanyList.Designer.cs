namespace CompanyAnalysis2.WindowsClient.UserControls
{
    partial class CompanyList
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblPeTTM = new System.Windows.Forms.Label();
            this.lblReturnOnAssetsTTM = new System.Windows.Forms.Label();
            this.panelHr = new System.Windows.Forms.Panel();
            this.lblStockPrice = new System.Windows.Forms.Label();
            this.lblRecalculated = new System.Windows.Forms.Label();
            this.lblLatestQuote = new System.Windows.Forms.Label();
            this.lblLatestReport = new System.Windows.Forms.Label();
            this.panelRows = new System.Windows.Forms.Panel();
            this.lblInvestmentGrade = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblInvestmentGrade);
            this.panelHeader.Controls.Add(this.lblLatestReport);
            this.panelHeader.Controls.Add(this.lblLatestQuote);
            this.panelHeader.Controls.Add(this.lblRecalculated);
            this.panelHeader.Controls.Add(this.lblStockPrice);
            this.panelHeader.Controls.Add(this.lblPeTTM);
            this.panelHeader.Controls.Add(this.lblReturnOnAssetsTTM);
            this.panelHeader.Controls.Add(this.panelHr);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1056, 29);
            this.panelHeader.TabIndex = 0;
            // 
            // lblPeTTM
            // 
            this.lblPeTTM.AutoSize = true;
            this.lblPeTTM.Location = new System.Drawing.Point(160, 12);
            this.lblPeTTM.Name = "lblPeTTM";
            this.lblPeTTM.Size = new System.Drawing.Size(52, 13);
            this.lblPeTTM.TabIndex = 2;
            this.lblPeTTM.Text = "P/E TTM";
            // 
            // lblReturnOnAssetsTTM
            // 
            this.lblReturnOnAssetsTTM.AutoSize = true;
            this.lblReturnOnAssetsTTM.Location = new System.Drawing.Point(240, 12);
            this.lblReturnOnAssetsTTM.Name = "lblReturnOnAssetsTTM";
            this.lblReturnOnAssetsTTM.Size = new System.Drawing.Size(56, 13);
            this.lblReturnOnAssetsTTM.TabIndex = 1;
            this.lblReturnOnAssetsTTM.Text = "ROA TTM";
            // 
            // panelHr
            // 
            this.panelHr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHr.Location = new System.Drawing.Point(0, 28);
            this.panelHr.Name = "panelHr";
            this.panelHr.Size = new System.Drawing.Size(1056, 1);
            this.panelHr.TabIndex = 0;
            // 
            // lblStockPrice
            // 
            this.lblStockPrice.AutoSize = true;
            this.lblStockPrice.Location = new System.Drawing.Point(320, 12);
            this.lblStockPrice.Name = "lblStockPrice";
            this.lblStockPrice.Size = new System.Drawing.Size(67, 13);
            this.lblStockPrice.TabIndex = 3;
            this.lblStockPrice.Text = "Stock Quote";
            // 
            // lblRecalculated
            // 
            this.lblRecalculated.AutoSize = true;
            this.lblRecalculated.Location = new System.Drawing.Point(560, 12);
            this.lblRecalculated.Name = "lblRecalculated";
            this.lblRecalculated.Size = new System.Drawing.Size(70, 13);
            this.lblRecalculated.TabIndex = 4;
            this.lblRecalculated.Text = "Recalculated";
            // 
            // lblLatestQuote
            // 
            this.lblLatestQuote.AutoSize = true;
            this.lblLatestQuote.Location = new System.Drawing.Point(400, 12);
            this.lblLatestQuote.Name = "lblLatestQuote";
            this.lblLatestQuote.Size = new System.Drawing.Size(62, 13);
            this.lblLatestQuote.TabIndex = 5;
            this.lblLatestQuote.Text = "Quote Date";
            // 
            // lblLatestReport
            // 
            this.lblLatestReport.AutoSize = true;
            this.lblLatestReport.Location = new System.Drawing.Point(480, 12);
            this.lblLatestReport.Name = "lblLatestReport";
            this.lblLatestReport.Size = new System.Drawing.Size(72, 13);
            this.lblLatestReport.TabIndex = 6;
            this.lblLatestReport.Text = "Report Period";
            // 
            // panelRows
            // 
            this.panelRows.AutoScroll = true;
            this.panelRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRows.Location = new System.Drawing.Point(0, 29);
            this.panelRows.Name = "panelRows";
            this.panelRows.Size = new System.Drawing.Size(1056, 361);
            this.panelRows.TabIndex = 1;
            // 
            // lblInvestmentGrade
            // 
            this.lblInvestmentGrade.AutoSize = true;
            this.lblInvestmentGrade.Location = new System.Drawing.Point(640, 12);
            this.lblInvestmentGrade.Name = "lblInvestmentGrade";
            this.lblInvestmentGrade.Size = new System.Drawing.Size(62, 13);
            this.lblInvestmentGrade.TabIndex = 7;
            this.lblInvestmentGrade.Text = "Grade TTM";
            // 
            // CompanyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRows);
            this.Controls.Add(this.panelHeader);
            this.Name = "CompanyList";
            this.Size = new System.Drawing.Size(1056, 390);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblPeTTM;
        private System.Windows.Forms.Label lblReturnOnAssetsTTM;
        private System.Windows.Forms.Panel panelHr;
        private System.Windows.Forms.Label lblLatestReport;
        private System.Windows.Forms.Label lblLatestQuote;
        private System.Windows.Forms.Label lblRecalculated;
        private System.Windows.Forms.Label lblStockPrice;
        private System.Windows.Forms.Panel panelRows;
        private System.Windows.Forms.Label lblInvestmentGrade;
    }
}
