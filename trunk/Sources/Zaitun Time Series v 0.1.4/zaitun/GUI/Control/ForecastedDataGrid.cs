using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using zaitun.GUI;
using zaitun.Data;

namespace zaitun.GUI
{
    public partial class ForecastedDataGrid : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] forecasted;
        

        public ForecastedDataGrid()
        {
            InitializeComponent();
            grdForecasted.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;            
            
        }

        public void SetData(SeriesData data, SeriesVariable variable, double[] forecasted)
        {
            this.data = data;
            this.variable = variable;
            this.forecasted = forecasted;            
          
            this.update();
        }

        private void update()
        {
            string[] time = this.getForecastedTime();
            
            grdForecasted.RowCount = this.forecasted.Length;
            for (int i = 0; i < this.forecasted.Length; i++)
            {
                grdForecasted.Rows[i].HeaderCell.Value = time[i];
                grdForecasted.Rows[i].Cells[0].Value = this.forecasted[i].ToString("F4");

            }


        }

        private string[] getForecastedTime()
        {
            string[] result = new string[this.forecasted.Length];

            DateTime currentDate = new DateTime();

            switch (this.data.Frequency)
            {
                case zaitun.Data.SeriesData.SeriesFrequency.Annual:                    
                    for (int i = 0; i < this.forecasted.Length; i++)
                    {
                        currentDate = this.data.EndDate.AddYears(i + 1);
                        result[i] = currentDate.Year.ToString();
                    }
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.SemiAnnual:
                    for (int i = 0; i < this.forecasted.Length; i++)
                    {
                        currentDate = this.data.EndDate.AddMonths(6 * (i + 1));
                        result[i] = "Pertengahan " + (currentDate.Month / 2) + " " +
                            currentDate.Year.ToString();
                    }                    
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.Quarterly:
                    for (int i = 0; i < this.forecasted.Length; i++)
                    {
                        currentDate = this.data.EndDate.AddMonths(3 * (i + 1));
                        result[i] = "Triwulan " + (currentDate.Month / 3) + " " +
                            currentDate.Year.ToString();
                    }                        
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.Monthly:
                    for (int i = 0; i < this.forecasted.Length; i++)
                    {
                        currentDate = this.data.EndDate.AddMonths(i + 1);
                        result[i] = SeriesData.ConvertIntToMonth(currentDate.Month)
                            + " " + currentDate.Year.ToString();
                    }                      
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.Weekly:
                    for (int i = 0; i < this.forecasted.Length; i++)
                    {
                        currentDate = this.data.EndDate.AddDays(7 * (i + 1));
                        result[i] = currentDate.ToString("dd/MM/yy");
                    }                     
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.Daily:
                    for (int i = 0; i < this.forecasted.Length; i++)
                    {
                        currentDate = this.data.EndDate.AddDays(i + 1);
                        result[i] = currentDate.ToString("dd/MM/yy");
                    }                        
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.Daily6:
                    {
                        int i = 0;
                        currentDate = this.data.EndDate;
                        while (i < this.forecasted.Length)
                        {
                            currentDate = currentDate.AddDays(1);
                            if (currentDate.DayOfWeek != DayOfWeek.Sunday)
                            {
                                result[i] = currentDate.ToString("dd/MM/yy");
                                i++;
                            }
                        }
                    }
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.Daily5:
                    {
                        int i = 0;
                        currentDate = this.data.EndDate;
                        while (i < this.forecasted.Length)
                        {
                            currentDate = currentDate.AddDays(1);
                            if (currentDate.DayOfWeek != DayOfWeek.Sunday &&
                                currentDate.DayOfWeek != DayOfWeek.Saturday)
                            {
                                result[i] = currentDate.ToString("dd/MM/yy");
                                i++;
                            }
                        }
                    }
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.Undated:
                    {
                        for (int i = 0; i < this.forecasted.Length; i++)
                        {
                            int current = this.data.NumberObservations + i + 1;
                            result[i] = current.ToString();
                        }
                    }
                    break;
            }

            return result;
        }
    }
}
