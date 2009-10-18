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

namespace zaitun.Data
{
    public class CSVWriter
    {
        private StreamWriter csvWriter;
        private string filePath;

        public CSVWriter(string filePath)
        {
            this.csvWriter = new StreamWriter(filePath);
            this.filePath = filePath;
        }

        public void WriteData(SeriesData data)
        {
            for (int i = 0; i < data.SeriesVariables.Count - 1; i++)            
                this.csvWriter.Write(data.SeriesVariables[i].VariableName + ",");
            this.csvWriter.WriteLine(data.SeriesVariables[data.SeriesVariables.Count - 1].VariableName);

            for (int j = 0; j < data.NumberObservations; j++)
            {
                for (int i = 0; i < data.SeriesVariables.Count - 1; i++)
                {
                    this.csvWriter.Write(data.SeriesVariables[i][j].ToString("0.#############################") + ",");
                }
                this.csvWriter.WriteLine(data.SeriesVariables[data.SeriesVariables.Count - 1][j].ToString("0.#############################"));
            }

            this.csvWriter.Close();
        }
    }
}
