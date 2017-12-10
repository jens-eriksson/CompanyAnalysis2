namespace CompanyAnalysis2.WindowsClient.UserControls
{
    partial class AddStockQuoteRow
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
            this.cboDate = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtNumOfShares = new System.Windows.Forms.TextBox();
            this.btnAdd = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDate
            // 
            this.cboDate.FormattingEnabled = true;
            this.cboDate.Location = new System.Drawing.Point(0, 8);
            this.cboDate.Name = "cboDate";
            this.cboDate.Size = new System.Drawing.Size(80, 21);
            this.cboDate.TabIndex = 3;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(80, 8);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(80, 20);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtNumOfShares
            // 
            this.txtNumOfShares.Location = new System.Drawing.Point(160, 8);
            this.txtNumOfShares.Name = "txtNumOfShares";
            this.txtNumOfShares.Size = new System.Drawing.Size(180, 20);
            this.txtNumOfShares.TabIndex = 5;
            this.txtNumOfShares.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.ActiveColor = System.Drawing.Color.Black;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAdd.InActiveColor = System.Drawing.Color.Gray;
            this.btnAdd.Location = new System.Drawing.Point(347, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(20, 20);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddStockQuoteRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtNumOfShares);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.cboDate);
            this.Name = "AddStockQuoteRow";
            this.Size = new System.Drawing.Size(400, 35);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboDate;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtNumOfShares;
        private FontAwesome.Sharp.IconPictureBox btnAdd;
    }
}
