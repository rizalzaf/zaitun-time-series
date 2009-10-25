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
    public class CSVReader
    {
        private StreamReader csvReader;
        private string filePath;

        private int rowCount;
        private int columnCount;

        private string[][] stringData;
        private double[][] doubleData;
        private string[] stringHeader;

        public CSVReader(string filePath)
        {
            this.csvReader = new StreamReader(filePath);
            this.filePath = filePath;
        }

        public string[][] ReadDataToString()
        {
            List<string> stringList = new List<string>();

            while (!this.csvReader.EndOfStream)
            {
                stringList.Add(this.csvReader.ReadLine());
            }

            rowCount = stringList.Count;
            columnCount = stringList[0].Split(',').Length;

            this.stringData = new string[rowCount][];

            for (int i = 0; i < rowCount; i++)            
                this.stringData[i] = stringList[i].Split(',');

            this.csvReader.Close();
            
            return this.stringData;
        }

        public double[][] ConvertStringToDouble(bool firstRowAsHeaders)
        {
            if (firstRowAsHeaders)
            {
                this.stringHeader = new string[this.columnCount];
                for (int j = 0; j < this.columnCount; j++)
                {
                    this.stringHeader[j] = this.stringData[0][j];
                }

                this.doubleData = new double[this.rowCount - 1][];
                for (int i = 0; i < this.rowCount-1; i++)
                {
                    this.doubleData[i] = new double[this.columnCount];
                    for (int j = 0; j < this.columnCount; j++)
                    {
                        this.doubleData[i][j] = double.Parse(this.stringData[i + 1][j]);
                    }
                }
            }
            else
            {
                this.doubleData = new double[this.rowCount][];
                for (int i = 0; i < this.rowCount; i++)
                {
                    this.doubleData[i] = new double[this.columnCount];
                    for (int j = 0; j < this.columnCount; j++)
                    {
                        this.doubleData[i][j] = double.Parse(this.stringData[i][j]);
                    }
                }
            }

            return this.doubleData;            
        }

        public double[][] ReadDataToDouble(bool firstRowAsHeaders)
        {
            this.ReadDataToString();
            return this.ConvertStringToDouble(firstRowAsHeaders);
        }

        public string[][] StringData
        {
            get { return this.stringData; }
        }

        public double[][] DoubleData
        {
            get { return this.doubleData; }
        }

        public string[] StringHeader
        {
            get { return this.stringHeader; }
        }

        public int RowCount
        {
            get { return this.rowCount; }
        }

        public int ColumnCount
        {
            get { return this.columnCount; }
        }
        
    }
}
