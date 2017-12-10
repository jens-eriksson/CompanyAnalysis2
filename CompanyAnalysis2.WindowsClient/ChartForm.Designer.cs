namespace CompanyAnalysis2.WindowsClient
{
    partial class ChartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            this.lblCompany = new System.Windows.Forms.Label();
            this.chartPicker1 = new CompanyAnalysis2.WindowsClient.UserControls.ChartPicker();
            this.SuspendLayout();
            // 
            // lblCompany
            // 
            this.lblCompany.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(0, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(746, 33);
            this.lblCompany.TabIndex = 1;
            this.lblCompany.Text = "Company";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartPicker1
            // 
            this.chartPicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPicker1.Location = new System.Drawing.Point(0, 33);
            this.chartPicker1.Name = "chartPicker1";
            this.chartPicker1.Size = new System.Drawing.Size(746, 471);
            this.chartPicker1.TabIndex = 0;
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 504);
            this.Controls.Add(this.chartPicker1);
            this.Controls.Add(this.lblCompany);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ChartPicker chartPicker1;
        private System.Windows.Forms.Label lblCompany;
    }
}