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
