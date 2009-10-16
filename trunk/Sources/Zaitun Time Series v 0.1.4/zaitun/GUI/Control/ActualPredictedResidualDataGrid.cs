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
    public partial class ActualPredictedResidualDataGrid : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] predicted;
        private double[] residual;
        
        public ActualPredictedResidualDataGrid()
        {
            InitializeComponent();
            grdActualPredictedResidual.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;            
            
        }

        public void SetData(SeriesData data, SeriesVariable variable, double[] predicted, double[] residual)
        {
            this.data = data;
            this.variable = variable;
            this.predicted = predicted;
            this.residual = residual;
          
            this.update();
        }

        private void update()
        {
            int notIncludedObservation = this.data.NumberObservations - this.predicted.Length;
            double[] predictedToView = new double[this.data.NumberObservations];
            double[] residualToView = new double[this.data.NumberObservations];           

            for (int i = 0; i < notIncludedObservation; i++)
            {
                predictedToView[i] = double.NaN;
                residualToView[i] = double.NaN;
            }

            for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
            {
                predictedToView[i] = this.predicted[i - notIncludedObservation];
                residualToView[i] = this.residual[i - notIncludedObservation];             
            }


            grdActualPredictedResidual.RowCount = this.data.NumberObservations;
            for (int i = 0; i < data.NumberObservations; i++)
            {
                grdActualPredictedResidual.Rows[i].HeaderCell.Value = this.data.Time[i];
                grdActualPredictedResidual.Rows[i].Cells[0].Value = this.variable[i].ToString("F4");
                grdActualPredictedResidual.Rows[i].Cells[1].Value = predictedToView[i].ToString("F4");
                grdActualPredictedResidual.Rows[i].Cells[2].Value = residualToView[i].ToString("F4");

            }


        }      
        
    }
}
