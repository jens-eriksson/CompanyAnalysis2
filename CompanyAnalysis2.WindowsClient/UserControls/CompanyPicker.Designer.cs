namespace CompanyAnalysis2.WindowsClient.UserControls
{
    partial class CompanyPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyPicker));
            this.tabControlCompanies = new System.Windows.Forms.TabControl();
            this.txtPicker = new System.Windows.Forms.TextBox();
            this.iconButtonAdd = new FontAwesome.Sharp.IconButton();
            this.panelTop = new System.Windows.Forms.Panel();
            this.iconButtonDelete = new FontAwesome.Sharp.IconButton();
            this.iconButtonList = new FontAwesome.Sharp.IconButton();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlCompanies
            // 
            this.tabControlCompanies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCompanies.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlCompanies.ItemSize = new System.Drawing.Size(150, 30);
            this.tabControlCompanies.Location = new System.Drawing.Point(0, 68);
            this.tabControlCompanies.Name = "tabControlCompanies";
            this.tabControlCompanies.SelectedIndex = 0;
            this.tabControlCompanies.Size = new System.Drawing.Size(707, 460);
            this.tabControlCompanies.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlCompanies.TabIndex = 1;
            this.tabControlCompanies.SelectedIndexChanged += new System.EventHandler(this.tabControlCompanies_SelectedIndexChanged);
            // 
            // txtPicker
            // 
            this.txtPicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPicker.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPicker.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPicker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPicker.Location = new System.Drawing.Point(6, 36);
            this.txtPicker.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.txtPicker.Name = "txtPicker";
            this.txtPicker.Size = new System.Drawing.Size(695, 26);
            this.txtPicker.TabIndex = 3;
            this.txtPicker.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPicker_KeyUp);
            // 
            // iconButtonAdd
            // 
            this.iconButtonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButtonAdd.Icon = FontAwesome.Sharp.IconChar.Plus;
            this.iconButtonAdd.IconColor = System.Drawing.Color.Black;
            this.iconButtonAdd.IconSize = 16;
            this.iconButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("iconButtonAdd.Image")));
            this.iconButtonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonAdd.Location = new System.Drawing.Point(6, 6);
            this.iconButtonAdd.Name = "iconButtonAdd";
            this.iconButtonAdd.Size = new System.Drawing.Size(101, 24);
            this.iconButtonAdd.TabIndex = 5;
            this.iconButtonAdd.Text = "New Company";
            this.iconButtonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButtonAdd.UseVisualStyleBackColor = true;
            this.iconButtonAdd.Click += new System.EventHandler(this.iconButtonAdd_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.iconButtonList);
            this.panelTop.Controls.Add(this.iconButtonDelete);
            this.panelTop.Controls.Add(this.txtPicker);
            this.panelTop.Controls.Add(this.iconButtonAdd);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(707, 68);
            this.panelTop.TabIndex = 7;
            // 
            // iconButtonDelete
            // 
            this.iconButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButtonDelete.Icon = FontAwesome.Sharp.IconChar.TrashO;
            this.iconButtonDelete.IconColor = System.Drawing.Color.Black;
            this.iconButtonDelete.IconSize = 16;
            this.iconButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("iconButtonDelete.Image")));
            this.iconButtonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonDelete.Location = new System.Drawing.Point(113, 6);
            this.iconButtonDelete.Name = "iconButtonDelete";
            this.iconButtonDelete.Size = new System.Drawing.Size(112, 24);
            this.iconButtonDelete.TabIndex = 8;
            this.iconButtonDelete.Text = "Delete Company";
            this.iconButtonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButtonDelete.UseVisualStyleBackColor = true;
            this.iconButtonDelete.Click += new System.EventHandler(this.iconButtonDelete_Click);
            // 
            // iconButtonList
            // 
            this.iconButtonList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButtonList.Icon = FontAwesome.Sharp.IconChar.Bars;
            this.iconButtonList.IconColor = System.Drawing.Color.Black;
            this.iconButtonList.IconSize = 16;
            this.iconButtonList.Image = ((System.Drawing.Image)(resources.GetObject("iconButtonList.Image")));
            this.iconButtonList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonList.Location = new System.Drawing.Point(231, 6);
            this.iconButtonList.Name = "iconButtonList";
            this.iconButtonList.Size = new System.Drawing.Size(100, 24);
            this.iconButtonList.TabIndex = 9;
            this.iconButtonList.Text = "Company List";
            this.iconButtonList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButtonList.UseVisualStyleBackColor = true;
            this.iconButtonList.Click += new System.EventHandler(this.iconButtonList_Click);
            // 
            // CompanyPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlCompanies);
            this.Controls.Add(this.panelTop);
            this.Name = "CompanyPicker";
            this.Size = new System.Drawing.Size(707, 528);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlCompanies;
        private System.Windows.Forms.TextBox txtPicker;
        private FontAwesome.Sharp.IconButton iconButtonAdd;
        private System.Windows.Forms.Panel panelTop;
        private FontAwesome.Sharp.IconButton iconButtonDelete;
        private FontAwesome.Sharp.IconButton iconButtonList;
    }
}
