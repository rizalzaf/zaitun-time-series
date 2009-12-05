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
    /// Group yang akan dicari
    /// </summary>
    public static class GroupFinder
    {
        /// <summary>
        /// Group yang akan dicari
        /// </summary>
        private static SeriesGroup groupToFind;

        /// <summary>
        /// Mencari index group pada list
        /// </summary>
        /// <param name="variableCollection">list group</param>
        /// <param name="name">nama group</param>
        /// <returns>index</returns>
        public static int FindGroupIndex(SeriesGroups groupCollection, string name)
        {
            SeriesVariables a = new SeriesVariables();
            groupToFind = new SeriesGroup(name, a);
            System.Predicate<SeriesGroup> search = findGroupPredicate;

            return groupCollection.FindIndex(search);
        }

        /// <summary>
        /// Predicate untuk pencarian group
        /// </summary>
        /// <param name="search">group yang akan dicari</param>
        /// <returns>apakah nama group match</returns>
        private static bool findGroupPredicate(SeriesGroup search)
        {
            return search.GroupName.Equals(groupToFind.GroupName);
        }
    }
}
