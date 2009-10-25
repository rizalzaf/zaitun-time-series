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
    /// Kelas kumpulan (list) dari variable 
    /// turunan dari kelas ListWithOnChanged
    /// </summary>
    public class SeriesVariables:ListWithOnChanged<SeriesVariable>
    {
        /// <summary>
        /// Apakah variabel baru duplikat
        /// </summary>
        /// <param name="item">variabel baru yang dimaksud</param>
        /// <returns>Apakah nama variabel baru sudah ada dipakai oleh variabel
        /// lain dalam list</returns>
        private bool isDuplicateName(SeriesVariable item)
        {
            bool b=false ;
            foreach (SeriesVariable var in Inner)
            {
                // non case sensitive
                if (var.VariableName.ToLower() == item.VariableName.ToLower())
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        /// <summary>
        /// Apakah suatu kumpulan variabel mempunyai variabel duplikat
        /// </summary>
        /// <param name="item">kumpulan variabel dimaksud</param>
        /// <returns>Apakah ada nama variabel dalam suatu kumpulan variabel 
        /// sudah ada dipakai oleh variabel
        /// lain dalam list</returns>
        private bool isEnumerableDuplicateName(IEnumerable<SeriesVariable> item)
        {
            bool b = false;
            foreach (SeriesVariable s in item)
            {
                foreach (SeriesVariable var in Inner)
                {
                    // non case sensitive
                    if (var.VariableName.ToLower() == s.VariableName.ToLower())
                    {
                        b = true;
                        break;
                    }
                }
                if (!b) break;
            }
            return b;
        }
        
        /// <summary>
        /// Menambah variabel baru kedalm list
        /// </summary>
        /// <param name="item">variabel baru</param>
        public override void Add(SeriesVariable item)
        {
            if (isDuplicateName(item))
            {
                throw new DuplicateVariableException();
            }
            else
            {
                base.Add(item);
                item.Changed += new ChangedEventHandler(OnChanged);
            }
        }        

        /// <summary>
        /// Menambah kumpulan variabel ke list
        /// </summary>
        /// <param name="stuff">kumpulan variabel</param>
        public override void AddRange(IEnumerable<SeriesVariable> stuff)
        {
            if (isEnumerableDuplicateName(stuff))
            {
                throw new DuplicateVariableException();
            }
            else
            {
                base.AddRange(stuff);
                foreach (SeriesVariable item in stuff)
                {
                    item.Changed += new ChangedEventHandler(OnChanged);
                }
            }
        }

        /// <summary>
        /// Menyisipkan variabel baru ke list
        /// </summary>
        /// <param name="index">index yang akan disisipi</param>
        /// <param name="item">variabel baru</param>
        public override void Insert(int index, SeriesVariable item)
        {
            if (isDuplicateName(item))
            {
                throw new DuplicateVariableException();
            }
            else
            {
                base.Insert(index, item);
                item.Changed += new ChangedEventHandler(OnChanged);
            }
        }

        /// <summary>
        /// Menyisipkan kumpulan variabel baru ke list
        /// </summary>
        /// <param name="index">index yang akan disisipi</param>
        /// <param name="stuff">kumpulan variabel</param>
        public override void InsertRange(int index, IEnumerable<SeriesVariable> stuff)
        {
            if (isEnumerableDuplicateName(stuff))
            {
                throw new DuplicateVariableException();
            }
            else
            {
                base.InsertRange(index, stuff);
                foreach (SeriesVariable item in stuff)
                {
                    item.Changed += new ChangedEventHandler(OnChanged);
                }
            }
        }

        /// <summary>
        /// Indexer. mengakses variabel pada list dengan index tertentu
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>variabel dituju</returns>
        public override SeriesVariable this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                if (isDuplicateName(value))
                {
                    throw new DuplicateVariableException();
                }
                else
                {
                    base[index] = value;
                    value.Changed += new ChangedEventHandler(OnChanged);
                }
            }
        }
        
        /// <summary>
        /// Mengkloning objek
        /// </summary>
        /// <returns>objek baru hasil kloning</returns>
        public override object Clone()
        {
            SeriesVariables clone = new SeriesVariables();
            SeriesVariable[] arr = this.ToArray();
            clone.AddRange(arr);
            return clone;
        }

        void OnChanged(object sender, EventArgs e)
        {
            this.OnChanged(e);
        }
    }
}
