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
