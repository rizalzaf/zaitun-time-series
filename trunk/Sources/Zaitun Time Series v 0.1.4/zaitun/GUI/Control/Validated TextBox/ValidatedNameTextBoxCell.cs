using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zaitun.GUI
{
    public class ValidatedNameTextBoxCell : DataGridViewTextBoxCell
    {
        public ValidatedNameTextBoxCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            ValidatedNameTextBoxEditingControl vtb =
            DataGridView.EditingControl as ValidatedNameTextBoxEditingControl;
            vtb.Text = (string)initialFormattedValue;

        }    

        public override Type EditType
        {
            get
            {
                return typeof(ValidatedNameTextBoxEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(string);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return "";
            }
        }
    }

   
}
