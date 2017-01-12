namespace CompanyAnalysis2.WindowsClient.UserControls
{
    partial class CompanyPickerUserControl
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
            this.tabControlCompanies = new System.Windows.Forms.TabControl();
            this.txtPicker = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tabControlCompanies
            // 
            this.tabControlCompanies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCompanies.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlCompanies.ItemSize = new System.Drawing.Size(200, 30);
            this.tabControlCompanies.Location = new System.Drawing.Point(0, 26);
            this.tabControlCompanies.Name = "tabControlCompanies";
            this.tabControlCompanies.SelectedIndex = 0;
            this.tabControlCompanies.Size = new System.Drawing.Size(707, 502);
            this.tabControlCompanies.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlCompanies.TabIndex = 1;
            // 
            // txtPicker
            // 
            this.txtPicker.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPicker.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPicker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPicker.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPicker.Location = new System.Drawing.Point(0, 0);
            this.txtPicker.Name = "txtPicker";
            this.txtPicker.Size = new System.Drawing.Size(707, 26);
            this.txtPicker.TabIndex = 3;
            this.txtPicker.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPicker_KeyUp);
            // 
            // CompanyPickerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlCompanies);
            this.Controls.Add(this.txtPicker);
            this.Name = "CompanyPickerUserControl";
            this.Size = new System.Drawing.Size(707, 528);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlCompanies;
        private System.Windows.Forms.TextBox txtPicker;
    }
}
