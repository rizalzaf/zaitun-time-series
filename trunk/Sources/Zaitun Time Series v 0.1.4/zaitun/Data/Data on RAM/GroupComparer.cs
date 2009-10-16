using System;
using System.Collections.Generic;
using System.Text;

namespace zaitun.Data
{
    class GroupComparer : IComparer<SeriesGroup>
    {
        #region IComparer<SeriesGroup> Members

        int IComparer<SeriesGroup>.Compare(SeriesGroup x, SeriesGroup y)
        {
            return x.GroupName.CompareTo(y.GroupName);
        }

        #endregion
    }
}
