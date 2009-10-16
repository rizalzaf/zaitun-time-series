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
