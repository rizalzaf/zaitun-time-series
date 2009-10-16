using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zaitun.GUI
{
    public class ValidatedTextBoxCell : DataGridViewTextBoxCell
    {
        public ValidatedTextBoxCell()
            : base()
        {
            
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {            
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            ValidatedTextBoxEditingControl vtb =
            DataGridView.EditingControl as ValidatedTextBoxEditingControl;
            vtb.Text = (string)initialFormattedValue;           
            
        }
        
        public override Type EditType
        {
            get
            {
                return typeof(ValidatedTextBoxEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(double);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return 0.0D;
            }
        }
    }

   
}
