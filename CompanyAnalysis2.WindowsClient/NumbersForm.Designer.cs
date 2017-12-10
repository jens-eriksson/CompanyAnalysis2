namespace CompanyAnalysis2.WindowsClient
{
    partial class NumbersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumbersForm));
            this.overviewTable1 = new CompanyAnalysis2.WindowsClient.UserControls.OverviewTable();
            this.lblCompany = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // overviewTable1
            // 
            this.overviewTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overviewTable1.Location = new System.Drawing.Point(0, 33);
            this.overviewTable1.Name = "overviewTable1";
            this.overviewTable1.Size = new System.Drawing.Size(822, 492);
            this.overviewTable1.TabIndex = 0;
            // 
            // lblCompany
            // 
            this.lblCompany.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(0, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(822, 33);
            this.lblCompany.TabIndex = 2;
            this.lblCompany.Text = "Company";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumbersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 525);
            this.Controls.Add(this.overviewTable1);
            this.Controls.Add(this.lblCompany);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NumbersForm";
            this.Text = "NumbersForm";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.OverviewTable overviewTable1;
        private System.Windows.Forms.Label lblCompany;
    }
}