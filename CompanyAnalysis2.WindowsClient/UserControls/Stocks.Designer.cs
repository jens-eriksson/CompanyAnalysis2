namespace CompanyAnalysis2.WindowsClient.UserControls
{
    partial class Stocks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stocks));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.panelTop = new System.Windows.Forms.Panel();
            this.iconButtonDelete = new FontAwesome.Sharp.IconButton();
            this.iconButtonAdd = new FontAwesome.Sharp.IconButton();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(0, 25);
            this.tabControl.Location = new System.Drawing.Point(0, 36);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(499, 401);
            this.tabControl.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.iconButtonDelete);
            this.panelTop.Controls.Add(this.iconButtonAdd);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(499, 36);
            this.panelTop.TabIndex = 1;
            // 
            // iconButtonDelete
            // 
            this.iconButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButtonDelete.Icon = FontAwesome.Sharp.IconChar.TrashO;
            this.iconButtonDelete.IconColor = System.Drawing.Color.Black;
            this.iconButtonDelete.IconSize = 16;
            this.iconButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("iconButtonDelete.Image")));
            this.iconButtonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonDelete.Location = new System.Drawing.Point(97, 1);
            this.iconButtonDelete.Name = "iconButtonDelete";
            this.iconButtonDelete.Size = new System.Drawing.Size(94, 24);
            this.iconButtonDelete.TabIndex = 7;
            this.iconButtonDelete.Text = "Delete Stock";
            this.iconButtonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButtonDelete.UseVisualStyleBackColor = true;
            this.iconButtonDelete.Click += new System.EventHandler(this.iconButtonDelete_Click);
            // 
            // iconButtonAdd
            // 
            this.iconButtonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButtonAdd.Icon = FontAwesome.Sharp.IconChar.Plus;
            this.iconButtonAdd.IconColor = System.Drawing.Color.Black;
            this.iconButtonAdd.IconSize = 16;
            this.iconButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("iconButtonAdd.Image")));
            this.iconButtonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonAdd.Location = new System.Drawing.Point(7, 1);
            this.iconButtonAdd.Name = "iconButtonAdd";
            this.iconButtonAdd.Size = new System.Drawing.Size(83, 24);
            this.iconButtonAdd.TabIndex = 6;
            this.iconButtonAdd.Text = "New Stock";
            this.iconButtonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButtonAdd.UseVisualStyleBackColor = true;
            this.iconButtonAdd.Click += new System.EventHandler(this.iconButtonAdd_Click);
            // 
            // Stocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelTop);
            this.Name = "Stocks";
            this.Size = new System.Drawing.Size(499, 437);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Panel panelTop;
        private FontAwesome.Sharp.IconButton iconButtonDelete;
        private FontAwesome.Sharp.IconButton iconButtonAdd;
    }
}
