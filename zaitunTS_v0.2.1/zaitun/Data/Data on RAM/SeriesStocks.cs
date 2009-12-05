// Zaitun Time Series 
// http://www.zaitunsoftware.com/
// http://code.google.com/p/zaitun-time-series/
//
// Copyright ©  2008-2009, Zaitun Time Series Developer Team and individual contributors
//
// Leader: Rizal Zaini Ahmad Fathony (rizalzaf@gmail.com)
// Members: Suryono Hadi Wibowo (ryonoha@gmail.com), Khaerul Anas (anasikova@gmail.com), 
//          Lia Amelia (afifahlia@gmail.com), Almaratul Sholihah, Muhamad Fuad Hasan
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
    /// Class represent the collection of Stock object
    /// inherit from ListWithOnChanged class
    /// </summary>
    public class SeriesStocks : ListWithOnChanged<SeriesStock>
    {
        /// <summary>
        /// Apakah stock baru duplikat
        /// </summary>
        /// <param name="item">stock baru yang dimaksud</param>
        /// <returns>Apakah nama stock baru sudah ada dipakai oleh stock
        /// lain dalam list</returns>
        private bool isDuplicateName(SeriesStock item)
        {
            bool b = false;
            foreach (SeriesStock stock in Inner)
            {
                // non case sensitive
                if (stock.StockName.ToLower() == item.StockName.ToLower())
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        /// <summary>
        /// Apakah suatu kumpulan stock mempunyai stock duplikat
        /// </summary>
        /// <param name="item">kumpulan stock dimaksud</param>
        /// <returns>Apakah ada nama stock dalam suatu kumpulan stock 
        /// sudah ada dipakai oleh stock
        /// lain dalam list</returns>
        private bool isEnumerableDuplicateName(IEnumerable<SeriesStock> item)
        {
            bool b = false;
            foreach (SeriesStock s in item)
            {
                foreach (SeriesStock var in Inner)
                {
                    // non case sensitive
                    if (var.StockName.ToLower() == s.StockName.ToLower())
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
        /// Menambah stock baru kedalm list
        /// </summary>
        /// <param name="item">stock baru</param>
        public override void Add(SeriesStock item)
        {
            if (isDuplicateName(item))
            {
                throw new DuplicateStockException();
            }
            else
            {
                base.Add(item);
                item.Changed += new ChangedEventHandler(OnChanged);
            }
        }

        /// <summary>
        /// Menambah kumpulan stock ke list
        /// </summary>
        /// <param name="stuff">kumpulan stock</param>
        public override void AddRange(IEnumerable<SeriesStock> stuff)
        {
            if (isEnumerableDuplicateName(stuff))
            {
                throw new DuplicateStockException();
            }
            else
            {
                base.AddRange(stuff);
                foreach (SeriesStock item in stuff)
                {
                    item.Changed += new ChangedEventHandler(OnChanged);
                }
            }
        }

        /// <summary>
        /// Menyisipkan stock baru ke list
        /// </summary>
        /// <param name="index">index yang akan disisipi</param>
        /// <param name="item">stock baru</param>
        public override void Insert(int index, SeriesStock item)
        {
            if (isDuplicateName(item))
            {
                throw new DuplicateStockException();
            }
            else
            {
                base.Insert(index, item);
                item.Changed += new ChangedEventHandler(OnChanged);
            }
        }

        /// <summary>
        /// Menyisipkan kumpulan stock baru ke list
        /// </summary>
        /// <param name="index">index yang akan disisipi</param>
        /// <param name="stuff">kumpulan stock</param>
        public override void InsertRange(int index, IEnumerable<SeriesStock> stuff)
        {
            if (isEnumerableDuplicateName(stuff))
            {
                throw new DuplicateStockException();
            }
            else
            {
                base.InsertRange(index, stuff);
                foreach (SeriesStock item in stuff)
                {
                    item.Changed += new ChangedEventHandler(OnChanged);
                }
            }
        }

        /// <summary>
        /// Indexer. mengakses stock pada list dengan index tertentu
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>stock dituju</returns>
        public override SeriesStock this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                if (isDuplicateName(value))
                {
                    throw new DuplicateStockException();
                }
                else
                {
                    base[index] = value;
                    value.Changed += new ChangedEventHandler(OnChanged);
                }
            }
        }

        void OnChanged(object sender, EventArgs e)
        {
            this.OnChanged(e);
        }
    }
}
