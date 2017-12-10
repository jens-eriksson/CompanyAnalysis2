namespace CompanyAnalysis2.WindowsClient
{
    partial class BulkEditStockQuoteForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNumberOfShares = new System.Windows.Forms.Label();
            this.txtNumberOfShares = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dateTimePickerSharesFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSharesTo = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagePrice = new System.Windows.Forms.TabPage();
            this.tabPageNumberOfShares = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerPriceTo = new System.Windows.Forms.DateTimePicker();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.dateTimePickerPriceFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPagePrice.SuspendLayout();
            this.tabPageNumberOfShares.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumberOfShares
            // 
            this.lblNumberOfShares.AutoSize = true;
            this.lblNumberOfShares.Location = new System.Drawing.Point(6, 9);
            this.lblNumberOfShares.Name = "lblNumberOfShares";
            this.lblNumberOfShares.Size = new System.Drawing.Size(92, 13);
            this.lblNumberOfShares.TabIndex = 0;
            this.lblNumberOfShares.Text = "Number of Shares";
            // 
            // txtNumberOfShares
            // 
            this.txtNumberOfShares.Location = new System.Drawing.Point(122, 6);
            this.txtNumberOfShares.Name = "txtNumberOfShares";
            this.txtNumberOfShares.Size = new System.Drawing.Size(220, 20);
            this.txtNumberOfShares.TabIndex = 1;
            this.txtNumberOfShares.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(282, 149);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(201, 149);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dateTimePickerSharesFrom
            // 
            this.dateTimePickerSharesFrom.Location = new System.Drawing.Point(122, 35);
            this.dateTimePickerSharesFrom.Name = "dateTimePickerSharesFrom";
            this.dateTimePickerSharesFrom.Size = new System.Drawing.Size(220, 20);
            this.dateTimePickerSharesFrom.TabIndex = 8;
            // 
            // dateTimePickerSharesTo
            // 
            this.dateTimePickerSharesTo.Location = new System.Drawing.Point(122, 61);
            this.dateTimePickerSharesTo.Name = "dateTimePickerSharesTo";
            this.dateTimePickerSharesTo.Size = new System.Drawing.Size(220, 20);
            this.dateTimePickerSharesTo.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageNumberOfShares);
            this.tabControl1.Controls.Add(this.tabPagePrice);
            this.tabControl1.ItemSize = new System.Drawing.Size(46, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(360, 143);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPagePrice
            // 
            this.tabPagePrice.Controls.Add(this.label3);
            this.tabPagePrice.Controls.Add(this.dateTimePickerPriceTo);
            this.tabPagePrice.Controls.Add(this.txtPrice);
            this.tabPagePrice.Controls.Add(this.dateTimePickerPriceFrom);
            this.tabPagePrice.Controls.Add(this.label4);
            this.tabPagePrice.Controls.Add(this.label5);
            this.tabPagePrice.Location = new System.Drawing.Point(4, 29);
            this.tabPagePrice.Name = "tabPagePrice";
            this.tabPagePrice.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrice.Size = new System.Drawing.Size(378, 110);
            this.tabPagePrice.TabIndex = 0;
            this.tabPagePrice.Text = "Price";
            this.tabPagePrice.UseVisualStyleBackColor = true;
            // 
            // tabPageNumberOfShares
            // 
            this.tabPageNumberOfShares.Controls.Add(this.lblNumberOfShares);
            this.tabPageNumberOfShares.Controls.Add(this.dateTimePickerSharesTo);
            this.tabPageNumberOfShares.Controls.Add(this.txtNumberOfShares);
            this.tabPageNumberOfShares.Controls.Add(this.dateTimePickerSharesFrom);
            this.tabPageNumberOfShares.Controls.Add(this.label1);
            this.tabPageNumberOfShares.Controls.Add(this.label2);
            this.tabPageNumberOfShares.Location = new System.Drawing.Point(4, 29);
            this.tabPageNumberOfShares.Name = "tabPageNumberOfShares";
            this.tabPageNumberOfShares.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNumberOfShares.Size = new System.Drawing.Size(352, 110);
            this.tabPageNumberOfShares.TabIndex = 1;
            this.tabPageNumberOfShares.Text = "Number of Shares";
            this.tabPageNumberOfShares.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Price";
            // 
            // dateTimePickerPriceTo
            // 
            this.dateTimePickerPriceTo.Location = new System.Drawing.Point(122, 61);
            this.dateTimePickerPriceTo.Name = "dateTimePickerPriceTo";
            this.dateTimePickerPriceTo.Size = new System.Drawing.Size(220, 20);
            this.dateTimePickerPriceTo.TabIndex = 15;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(122, 6);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(220, 20);
            this.txtPrice.TabIndex = 11;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // dateTimePickerPriceFrom
            // 
            this.dateTimePickerPriceFrom.Location = new System.Drawing.Point(122, 35);
            this.dateTimePickerPriceFrom.Name = "dateTimePickerPriceFrom";
            this.dateTimePickerPriceFrom.Size = new System.Drawing.Size(220, 20);
            this.dateTimePickerPriceFrom.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "To";
            // 
            // BulkEditStockQuoteForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(360, 184);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BulkEditStockQuoteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bulk edit";
            this.tabControl1.ResumeLayout(false);
            this.tabPagePrice.ResumeLayout(false);
            this.tabPagePrice.PerformLayout();
            this.tabPageNumberOfShares.ResumeLayout(false);
            this.tabPageNumberOfShares.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumberOfShares;
        private System.Windows.Forms.TextBox txtNumberOfShares;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DateTimePicker dateTimePickerSharesFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerSharesTo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPagePrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerPriceTo;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.DateTimePicker dateTimePickerPriceFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPageNumberOfShares;
    }
}