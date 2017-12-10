namespace CompanyAnalysis2.WindowsClient.UserControls
{
    partial class Overview
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottomLeft = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelBottomRight = new System.Windows.Forms.Panel();
            this.chartPicker2 = new CompanyAnalysis2.WindowsClient.UserControls.ChartPicker();
            this.chartPicker1 = new CompanyAnalysis2.WindowsClient.UserControls.ChartPicker();
            this.overviewTable1 = new CompanyAnalysis2.WindowsClient.UserControls.OverviewTable();
            this.panelTop.SuspendLayout();
            this.panelBottomLeft.SuspendLayout();
            this.panelBottomRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.overviewTable1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(799, 371);
            this.panelTop.TabIndex = 11;
            // 
            // panelBottomLeft
            // 
            this.panelBottomLeft.Controls.Add(this.chartPicker1);
            this.panelBottomLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBottomLeft.Location = new System.Drawing.Point(0, 371);
            this.panelBottomLeft.Name = "panelBottomLeft";
            this.panelBottomLeft.Size = new System.Drawing.Size(341, 161);
            this.panelBottomLeft.TabIndex = 12;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Location = new System.Drawing.Point(341, 371);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 161);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            this.splitter1.DoubleClick += new System.EventHandler(this.splitter1_DoubleClick);
            // 
            // panelBottomRight
            // 
            this.panelBottomRight.Controls.Add(this.chartPicker2);
            this.panelBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomRight.Location = new System.Drawing.Point(346, 371);
            this.panelBottomRight.Name = "panelBottomRight";
            this.panelBottomRight.Size = new System.Drawing.Size(453, 161);
            this.panelBottomRight.TabIndex = 14;
            // 
            // chartPicker2
            // 
            this.chartPicker2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPicker2.Location = new System.Drawing.Point(0, 0);
            this.chartPicker2.Name = "chartPicker2";
            this.chartPicker2.Size = new System.Drawing.Size(453, 161);
            this.chartPicker2.TabIndex = 0;
            // 
            // chartPicker1
            // 
            this.chartPicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPicker1.Location = new System.Drawing.Point(0, 0);
            this.chartPicker1.Name = "chartPicker1";
            this.chartPicker1.Size = new System.Drawing.Size(341, 161);
            this.chartPicker1.TabIndex = 0;
            // 
            // overviewTable1
            // 
            this.overviewTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overviewTable1.Location = new System.Drawing.Point(0, 0);
            this.overviewTable1.Name = "overviewTable1";
            this.overviewTable1.Size = new System.Drawing.Size(799, 371);
            this.overviewTable1.TabIndex = 0;
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBottomRight);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelBottomLeft);
            this.Controls.Add(this.panelTop);
            this.Name = "Overview";
            this.Size = new System.Drawing.Size(799, 532);
            this.Resize += new System.EventHandler(this.CompanyOverviewUserControl_Resize);
            this.panelTop.ResumeLayout(false);
            this.panelBottomLeft.ResumeLayout(false);
            this.panelBottomRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottomLeft;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panelBottomRight;
        private OverviewTable overviewTable1;
        private ChartPicker chartPicker1;
        private ChartPicker chartPicker2;
    }
}
