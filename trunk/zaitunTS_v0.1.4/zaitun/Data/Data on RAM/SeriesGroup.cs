// Zaitun Time Series 
// http://www.zaitunsoftware.com/
// http://code.google.com/p/zaitun-time-series/
//
// Copyright ©  2008-2009, Zaitun Time Series Developer Team and individual contributors
//
// Core Programmer: Rizal Zaini Ahmad Fathony (rizalzaf@gmail.com)
// Programmer: Suryono Hadi Wibowo, Khaerul Anas, Almaratul Sholihah, Muhamad Fuad Hasan
//
// This is free software; you can redistribute it and/or modify it
// under the terms of the GNU General Public License as
// published by the Free Software Foundation; either version 3 of
// the License, or (at your option) any later version.
//
// This software is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// General Public License for more details.
//
// You should have received a copy of the GNU General Public
// License along with this software; if not, write to the Free
// Software Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
// 02110-1301 USA, or see the FSF site: http://www.fsf.org.

using System;
using System.Collections.Generic;
using System.Text;

namespace zaitun.Data
{
    /// <summary>
    /// Kelas untuk menyimpan data sebuah group
    /// </summary>
    public class SeriesGroup : ICloneable
    {
        private string groupName;
        private SeriesVariables groupList;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">nama group</param>
        /// <param name="groupList">list variabel anggota group</param>
        public SeriesGroup(string name, SeriesVariables groupList)
        {
            this.groupName = name;
            this.groupList = groupList;
            groupList.Changed += new ChangedEventHandler(groupList_Changed);
        }

        void groupList_Changed(object sender, EventArgs e)
        {
            OnChanged(System.EventArgs.Empty);
        }

        /// <summary>
        /// Nama group
        /// </summary>
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; OnChanged(System.EventArgs.Empty); }
        }

        /// <summary>
        /// List variabel anggota group
        /// </summary>
        public SeriesVariables GroupList
        {
            get { return groupList; }
            set { groupList = value; OnChanged(System.EventArgs.Empty); }
        }
        
        /// <summary>
        /// Indexer. mengakses variabel anggota pada index tertentu
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>variabel yang dituju</returns>
        public SeriesVariable this[int index]
        {
            get { return this.groupList[index]; }
            set { this.groupList[index] = value; OnChanged(System.EventArgs.Empty); }
        }

        #region override

        /// <summary>
        /// Nilai string yang mewakili objek
        /// </summary>
        /// <returns>String nama group</returns>
        public override string ToString()
        {
            return this.groupName;
        }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Mengkloning group
        /// </summary>
        /// <returns>group baru dengan nilai sama dengan group asal</returns>
        public object Clone()
        {
            SeriesGroup clone = new SeriesGroup(this.groupName, (SeriesVariables)this.groupList.Clone());
            return clone;
        }

        #endregion

        #region Event
        public event ChangedEventHandler Changed;

        protected virtual void OnChanged(System.EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }

        #endregion
    }
}
