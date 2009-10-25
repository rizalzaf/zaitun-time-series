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
using System.IO;
using zaitun.GUI;
using System.Data;
using ExcelLibrary.Office.Excel;

namespace zaitun.Data
{
    public class ExcelReader
    {
        
        private DataSet data;
        
        private string filePath;

        public ExcelReader(string filePath)
        {            
            this.filePath = filePath;
        }

        public DataSet ReadData()
        {            
            Workbook book = Workbook.Open(this.filePath);
            
            this.data = new DataSet();

            foreach (Worksheet sheet in book.Worksheets)
            {
                DataTable table = new DataTable(sheet.Name);
                for (int i = sheet.Cells.FirstColIndex; i <= sheet.Cells.LastColIndex; i++)
                {
                    table.Columns.Add();
                }

                for (int i = sheet.Cells.FirstRowIndex; i <= sheet.Cells.LastRowIndex; i++)
                {
                    Row xlrow = sheet.Cells.GetRow(i);
                    DataRow row = table.NewRow();
                    for (int j = xlrow.FirstColIndex; j <= xlrow.LastColIndex; j++)
                    {
                        Cell cell = xlrow.GetCell(j);
                        
                        
                        row[j - xlrow.FirstColIndex] = cell.Value;
                    }

                    table.Rows.Add(row);
                }

                this.data.Tables.Add(table);
            }


            return this.data;
        }
    }

}
