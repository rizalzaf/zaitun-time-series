using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zaitun.GUI
{
    public class NameTextBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) e.KeyChar = (char)Keys.None;            
            base.OnKeyPress(e);
        }
    }
}
