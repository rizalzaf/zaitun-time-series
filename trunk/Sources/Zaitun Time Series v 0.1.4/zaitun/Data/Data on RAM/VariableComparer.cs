using System;
using System.Collections.Generic;
using System.Text;

namespace zaitun.Data
{
    class VariableComparer : IComparer<SeriesVariable>
    {
        #region IComparer<SeriesVariable> Members

        int IComparer<SeriesVariable>.Compare(SeriesVariable x, SeriesVariable y)
        {
            return x.VariableName.CompareTo(y.VariableName);
        }       
        #endregion       
    }
}
