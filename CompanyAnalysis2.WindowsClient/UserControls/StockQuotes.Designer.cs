namespace CompanyAnalysis2.WindowsClient.UserControls
{
    partial class StockQuotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockQuotes));
            this.panelHeadings = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.panelHr = new System.Windows.Forms.Panel();
            this.lblStockQuote = new System.Windows.Forms.Label();
            this.lblNumberOfShares = new System.Windows.Forms.Label();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.btnEdit = new FontAwesome.Sharp.IconButton();
            this.iconButtonRefresh = new FontAwesome.Sharp.IconButton();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnDownload = new FontAwesome.Sharp.IconButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.addStockQuoteRow1 = new CompanyAnalysis2.WindowsClient.UserControls.AddStockQuoteRow();
            this.iconButtonExport = new FontAwesome.Sharp.IconButton();
            this.iconButtonImport = new FontAwesome.Sharp.IconButton();
            this.panelHeadings.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeadings
            // 
            this.panelHeadings.Controls.Add(this.lblDate);
            this.panelHeadings.Controls.Add(this.panelHr);
            this.panelHeadings.Controls.Add(this.lblStockQuote);
            this.panelHeadings.Controls.Add(this.lblNumberOfShares);
            this.panelHeadings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeadings.Location = new System.Drawing.Point(0, 73);
            this.panelHeadings.Name = "panelHeadings";
            this.panelHeadings.Size = new System.Drawing.Size(819, 20);
            this.panelHeadings.TabIndex = 4;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(0, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 15);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelHr
            // 
            this.panelHr.BackColor = System.Drawing.Color.Black;
            this.panelHr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelHr.Location = new System.Drawing.Point(0, 19);
            this.panelHr.Name = "panelHr";
            this.panelHr.Size = new System.Drawing.Size(819, 1);
            this.panelHr.TabIndex = 4;
            // 
            // lblStockQuote
            // 
            this.lblStockQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockQuote.Location = new System.Drawing.Point(80, 0);
            this.lblStockQuote.Name = "lblStockQuote";
            this.lblStockQuote.Size = new System.Drawing.Size(80, 15);
            this.lblStockQuote.TabIndex = 1;
            this.lblStockQuote.Text = "Price";
            this.lblStockQuote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNumberOfShares
            // 
            this.lblNumberOfShares.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfShares.Location = new System.Drawing.Point(160, 0);
            this.lblNumberOfShares.Name = "lblNumberOfShares";
            this.lblNumberOfShares.Size = new System.Drawing.Size(180, 15);
            this.lblNumberOfShares.TabIndex = 0;
            this.lblNumberOfShares.Text = "Number of shares outstanding";
            this.lblNumberOfShares.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelToolbar
            // 
            this.panelToolbar.Controls.Add(this.iconButtonExport);
            this.panelToolbar.Controls.Add(this.iconButtonImport);
            this.panelToolbar.Controls.Add(this.btnEdit);
            this.panelToolbar.Controls.Add(this.iconButtonRefresh);
            this.panelToolbar.Controls.Add(this.dtpTo);
            this.panelToolbar.Controls.Add(this.lblTo);
            this.panelToolbar.Controls.Add(this.dtpFrom);
            this.panelToolbar.Controls.Add(this.lblFrom);
            this.panelToolbar.Controls.Add(this.btnDownload);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(819, 73);
            this.panelToolbar.TabIndex = 5;
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Icon = FontAwesome.Sharp.IconChar.PencilSquareO;
            this.btnEdit.IconColor = System.Drawing.Color.Black;
            this.btnEdit.IconSize = 16;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(256, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 24);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Bulk edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // iconButtonRefresh
            // 
            this.iconButtonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButtonRefresh.Icon = FontAwesome.Sharp.IconChar.Refresh;
            this.iconButtonRefresh.IconColor = System.Drawing.Color.Black;
            this.iconButtonRefresh.IconSize = 16;
            this.iconButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("iconButtonRefresh.Image")));
            this.iconButtonRefresh.Location = new System.Drawing.Point(485, 36);
            this.iconButtonRefresh.Name = "iconButtonRefresh";
            this.iconButtonRefresh.Size = new System.Drawing.Size(30, 24);
            this.iconButtonRefresh.TabIndex = 5;
            this.iconButtonRefresh.UseVisualStyleBackColor = true;
            this.iconButtonRefresh.Click += new System.EventHandler(this.iconButtonRefresh_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(278, 38);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(248, 41);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(36, 38);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 2;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(6, 41);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From";
            // 
            // btnDownload
            // 
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDownload.Icon = FontAwesome.Sharp.IconChar.Download;
            this.btnDownload.IconColor = System.Drawing.Color.Black;
            this.btnDownload.IconSize = 16;
            this.btnDownload.Image = ((System.Drawing.Image)(resources.GetObject("btnDownload.Image")));
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownload.Location = new System.Drawing.Point(164, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(85, 24);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "Download";
            this.btnDownload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 128);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(819, 417);
            this.panelMain.TabIndex = 6;
            // 
            // addStockQuoteRow1
            // 
            this.addStockQuoteRow1.Dock = System.Windows.Forms.DockStyle.Top;
            this.addStockQuoteRow1.Location = new System.Drawing.Point(0, 93);
            this.addStockQuoteRow1.Name = "addStockQuoteRow1";
            this.addStockQuoteRow1.Size = new System.Drawing.Size(819, 35);
            this.addStockQuoteRow1.TabIndex = 7;
            // 
            // iconButtonExport
            // 
            this.iconButtonExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButtonExport.Icon = FontAwesome.Sharp.IconChar.FileExcelO;
            this.iconButtonExport.IconColor = System.Drawing.Color.Black;
            this.iconButtonExport.IconSize = 16;
            this.iconButtonExport.Image = ((System.Drawing.Image)(resources.GetObject("iconButtonExport.Image")));
            this.iconButtonExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonExport.Location = new System.Drawing.Point(87, 3);
            this.iconButtonExport.Name = "iconButtonExport";
            this.iconButtonExport.Size = new System.Drawing.Size(69, 24);
            this.iconButtonExport.TabIndex = 17;
            this.iconButtonExport.Text = "Export";
            this.iconButtonExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButtonExport.UseVisualStyleBackColor = true;
            this.iconButtonExport.Click += new System.EventHandler(this.iconButtonExport_Click);
            // 
            // iconButtonImport
            // 
            this.iconButtonImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButtonImport.Icon = FontAwesome.Sharp.IconChar.FileExcelO;
            this.iconButtonImport.IconColor = System.Drawing.Color.Black;
            this.iconButtonImport.IconSize = 16;
            this.iconButtonImport.Image = ((System.Drawing.Image)(resources.GetObject("iconButtonImport.Image")));
            this.iconButtonImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonImport.Location = new System.Drawing.Point(9, 3);
            this.iconButtonImport.Name = "iconButtonImport";
            this.iconButtonImport.Size = new System.Drawing.Size(69, 24);
            this.iconButtonImport.TabIndex = 16;
            this.iconButtonImport.Text = "Import";
            this.iconButtonImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButtonImport.UseVisualStyleBackColor = true;
            this.iconButtonImport.Click += new System.EventHandler(this.iconButtonImport_Click);
            // 
            // StockQuotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.addStockQuoteRow1);
            this.Controls.Add(this.panelHeadings);
            this.Controls.Add(this.panelToolbar);
            this.Name = "StockQuotes";
            this.Size = new System.Drawing.Size(819, 545);
            this.panelHeadings.ResumeLayout(false);
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelHeadings;
        private System.Windows.Forms.Panel panelHr;
        private System.Windows.Forms.Label lblStockQuote;
        private System.Windows.Forms.Label lblNumberOfShares;
        private System.Windows.Forms.Panel panelToolbar;
        private FontAwesome.Sharp.IconButton btnDownload;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblFrom;
        private FontAwesome.Sharp.IconButton iconButtonRefresh;
        private System.Windows.Forms.Panel panelMain;
        private FontAwesome.Sharp.IconButton btnEdit;
        private System.Windows.Forms.Label lblDate;
        private AddStockQuoteRow addStockQuoteRow1;
        private FontAwesome.Sharp.IconButton iconButtonExport;
        private FontAwesome.Sharp.IconButton iconButtonImport;
    }
}
