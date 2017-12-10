namespace CompanyAnalysis2.WindowsClient.UserControls
{
    partial class ChartPicker
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
            this.cboCharts = new System.Windows.Forms.ComboBox();
            this.panelChart = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // cboCharts
            // 
            this.cboCharts.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboCharts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCharts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCharts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCharts.FormattingEnabled = true;
            this.cboCharts.Items.AddRange(new object[] {
            "PETER LYNCH CHART",
            "REVENUE TTM | NET INCOME TTM"});
            this.cboCharts.Location = new System.Drawing.Point(0, 0);
            this.cboCharts.Name = "cboCharts";
            this.cboCharts.Size = new System.Drawing.Size(669, 26);
            this.cboCharts.TabIndex = 0;
            this.cboCharts.SelectedIndexChanged += new System.EventHandler(this.cboCharts_SelectedIndexChanged);
            // 
            // panelChart
            // 
            this.panelChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChart.Location = new System.Drawing.Point(0, 26);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(669, 368);
            this.panelChart.TabIndex = 1;
            // 
            // ChartPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelChart);
            this.Controls.Add(this.cboCharts);
            this.Name = "ChartPicker";
            this.Size = new System.Drawing.Size(669, 394);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCharts;
        private System.Windows.Forms.Panel panelChart;
    }
}
