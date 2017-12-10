namespace CompanyAnalysis2.WindowsClient.UserControls
{
    partial class AddReportRow
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
            this.cboPeriod = new System.Windows.Forms.ComboBox();
            this.txtRevenue = new System.Windows.Forms.TextBox();
            this.btnAdd = new FontAwesome.Sharp.IconPictureBox();
            this.txtNetIncome = new System.Windows.Forms.TextBox();
            this.txtAssets = new System.Windows.Forms.TextBox();
            this.txtEquity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPeriod
            // 
            this.cboPeriod.FormattingEnabled = true;
            this.cboPeriod.Location = new System.Drawing.Point(0, 8);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(80, 21);
            this.cboPeriod.TabIndex = 3;
            // 
            // txtRevenue
            // 
            this.txtRevenue.Location = new System.Drawing.Point(80, 8);
            this.txtRevenue.Name = "txtRevenue";
            this.txtRevenue.Size = new System.Drawing.Size(80, 20);
            this.txtRevenue.TabIndex = 4;
            this.txtRevenue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.ActiveColor = System.Drawing.Color.Black;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAdd.InActiveColor = System.Drawing.Color.Gray;
            this.btnAdd.Location = new System.Drawing.Point(400, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(20, 20);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtNetIncome
            // 
            this.txtNetIncome.Location = new System.Drawing.Point(160, 8);
            this.txtNetIncome.Name = "txtNetIncome";
            this.txtNetIncome.Size = new System.Drawing.Size(80, 20);
            this.txtNetIncome.TabIndex = 5;
            this.txtNetIncome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtAssets
            // 
            this.txtAssets.Location = new System.Drawing.Point(240, 8);
            this.txtAssets.Name = "txtAssets";
            this.txtAssets.Size = new System.Drawing.Size(80, 20);
            this.txtAssets.TabIndex = 6;
            this.txtAssets.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtEquity
            // 
            this.txtEquity.Location = new System.Drawing.Point(320, 8);
            this.txtEquity.Name = "txtEquity";
            this.txtEquity.Size = new System.Drawing.Size(80, 20);
            this.txtEquity.TabIndex = 7;
            this.txtEquity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // AddReportRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEquity);
            this.Controls.Add(this.txtAssets);
            this.Controls.Add(this.txtNetIncome);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtRevenue);
            this.Controls.Add(this.cboPeriod);
            this.Name = "AddReportRow";
            this.Size = new System.Drawing.Size(457, 35);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboPeriod;
        private System.Windows.Forms.TextBox txtRevenue;
        private FontAwesome.Sharp.IconPictureBox btnAdd;
        private System.Windows.Forms.TextBox txtNetIncome;
        private System.Windows.Forms.TextBox txtAssets;
        private System.Windows.Forms.TextBox txtEquity;
    }
}
