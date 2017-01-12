using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyAnalysis2.WindowsClient.CustomControls
{
    public class EditableLabel : TextBox
    {
        private bool editMode = false;
        private bool isToggling = false;
        public EditableLabel() : base()
        {
            this.Click += EditableLabel_Click;
            this.KeyUp += EditableLabel_KeyUp;
            this.Leave += EditableLabel_Leave;
            this.Enter += EditableLabel_Enter;
            this.ReadOnly = true;
            this.BorderStyle = BorderStyle.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void EditableLabel_Enter(object sender, EventArgs e)
        {
            FormatEnter();
        }

        private void EditableLabel_Leave(object sender, EventArgs e)
        {
            if (isToggling == false)
            {
                if (editMode)
                    ToggleEdit();
                else
                    FormatLeave();
            }
        }

        private void EditableLabel_KeyUp(object sender, KeyEventArgs e)
        {
            if (isToggling == false)
            {
                if (editMode)
                {
                    if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
                        ToggleEdit();
             
                }
                else
                {
                    if (e.KeyCode == Keys.F2)
                        ToggleEdit();
                }
                
            } 
                
        }

        private void EditableLabel_Click(object sender, EventArgs e)
        {
            if (isToggling == false)
            {
                if (editMode == false)
                    ToggleEdit();
            }
        }

        private void ToggleEdit()
        {
            isToggling = true;

            editMode = !editMode;

            if (editMode)
            {
                FormatEditMode();
            }
            else
            {
                if (this.Focused)
                    FormatEnter();
                else
                    FormatLeave();
            }

            isToggling = false;
        }

        private void FormatLeave()
        {
            this.Enabled = false;
            this.Enabled = true;
            this.ReadOnly = true;
            this.BorderStyle = BorderStyle.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void FormatEnter()
        {
            this.Enabled = false;
            this.Enabled = true;
            this.ReadOnly = true;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void FormatEditMode()
        {
            this.ReadOnly = false;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
        }
    }
}
