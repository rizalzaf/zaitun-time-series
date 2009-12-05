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
    /// Pencari Stock
    /// </summary>
    public static class StockFinder
    {
        /// <summary>
        /// Stock yang akan dicari
        /// </summary>
        private static SeriesStock stockToFind;

        /// <summary>
        /// Mencari index stock pada list
        /// </summary>
        /// <param name="variableCollection">list stock</param>
        /// <param name="name">nama stock</param>
        /// <returns>index</returns>
        public static int FindStockIndex(SeriesStocks stockCollection, string name)
        {            
            stockToFind = new SeriesStock(name, "");
            System.Predicate<SeriesStock> search = findStockPredicate;

            return stockCollection.FindIndex(search);
        }

        /// <summary>
        /// Predicate untuk pencarian stock
        /// </summary>
        /// <param name="search">stock yang akan dicari</param>
        /// <returns>apakah nama stock match</returns>
        private static bool findStockPredicate(SeriesStock search)
        {
            return search.StockName.Equals(stockToFind.StockName);
        }
    }
}
