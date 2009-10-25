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
using ExcelLibrary.Office.Excel;

namespace zaitun.Data
{
    public class ExcelWriter
    {
        
        private string filePath;

        public ExcelWriter(string filePath)
        {            
            this.filePath = filePath;
        }

        public void WriteData(SeriesData data)
        {

            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet(data.SeriesName);
            
            for (int i = 0; i < data.SeriesVariables.Count; i++)
            {
                worksheet.Cells[0, i] = new Cell(data.SeriesVariables[i].VariableName);                
            }

            for (int j = 0; j < data.NumberObservations; j++)
            {
                for (int i = 0; i < data.SeriesVariables.Count; i++)
                {
                    worksheet.Cells[j + 1, i] = new Cell(data.SeriesVariables[i][j]);                    
                }                
            }

            workbook.Worksheets.Add(worksheet);
            workbook.Save(this.filePath);
            
        }
    }
}
