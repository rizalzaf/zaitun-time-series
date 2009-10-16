using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zaitun.GUI
{
    public class ValidatedTextBoxEditingControl : DataGridViewTextBoxEditingControl
    {
        public ValidatedTextBoxEditingControl()
            : base()
        {
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-') e.KeyChar = (char)Keys.None;
            else if (e.KeyChar == '.' && this.Text.Contains(".")) e.KeyChar = (char)Keys.None;
            base.OnKeyPress(e);
        }
      
    }
}
