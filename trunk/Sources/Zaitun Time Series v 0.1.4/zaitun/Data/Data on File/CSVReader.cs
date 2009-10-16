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
