namespace CompanyAnalysis2.WindowsClient.UserControls
{
    partial class CompanyOverviewUserControl
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
            this.lblNetIcomeTtm = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.lblNetIncomeTtmValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNetIcomeTtm
            // 
            this.lblNetIcomeTtm.AutoSize = true;
            this.lblNetIcomeTtm.Location = new System.Drawing.Point(3, 46);
            this.lblNetIcomeTtm.Name = "lblNetIcomeTtm";
            this.lblNetIcomeTtm.Size = new System.Drawing.Size(88, 13);
            this.lblNetIcomeTtm.TabIndex = 1;
            this.lblNetIcomeTtm.Text = "Net Income TTM";
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(3, 8);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(59, 18);
            this.lblPeriod.TabIndex = 2;
            this.lblPeriod.Text = "[Period]";
            // 
            // lblNetIncomeTtmValue
            // 
            this.lblNetIncomeTtmValue.AutoSize = true;
            this.lblNetIncomeTtmValue.Location = new System.Drawing.Point(112, 46);
            this.lblNetIncomeTtmValue.Name = "lblNetIncomeTtmValue";
            this.lblNetIncomeTtmValue.Size = new System.Drawing.Size(19, 13);
            this.lblNetIncomeTtmValue.TabIndex = 3;
            this.lblNetIncomeTtmValue.Text = "[0]";
            // 
            // CompanyOverviewUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNetIncomeTtmValue);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.lblNetIcomeTtm);
            this.Name = "CompanyOverviewUserControl";
            this.Size = new System.Drawing.Size(520, 346);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNetIcomeTtm;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label lblNetIncomeTtmValue;
    }
}
