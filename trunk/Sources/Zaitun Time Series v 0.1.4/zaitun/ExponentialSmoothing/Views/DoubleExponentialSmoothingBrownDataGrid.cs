using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using zaitun.GUI;
using zaitun.Data;

namespace zaitun.ExponentialSmoothing
{
    public partial class DoubleExponentialSmoothingBrownDataGrid : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] smoothing;
        private double[] predicted;
        private double[] residual;

        private bool isSmoothingVisible;

        public DoubleExponentialSmoothingBrownDataGrid()
        {
            InitializeComponent();
            grdBrown.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }

        public void SetData(SeriesData data, SeriesVariable variable, bool isSmoothingVisible, double[] smoothing, double[] predicted, double[] residual)
        {
            this.data = data;
            this.variable = variable;
            this.isSmoothingVisible = isSmoothingVisible;
            this.smoothing = smoothing;
            this.predicted = predicted;
            this.residual = residual;

            this.update();
        }

        private void update()
        {
            int cell = 0;
            int notIncludedObservation = this.data.NumberObservations - this.predicted.Length;

            this.grdBrown.ColumnCount = 3;

            grdBrown.RowCount = this.data.NumberObservations;
            grdBrown.Columns[0].HeaderCell.Value = "Actual";
            grdBrown.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;

            for (int i = 0; i < data.NumberObservations; i++)
            {
                grdBrown.Rows[i].HeaderCell.Value = this.data.Time[i];
                grdBrown.Rows[i].Cells[0].Value = this.variable[i].ToString("F4");
            }

            if (this.isSmoothingVisible)
            {
                this.grdBrown.ColumnCount = this.grdBrown.ColumnCount + 1;
                grdBrown.Columns[1].HeaderCell.Value = "Smoothed";
                grdBrown.Columns[1].SortMode = DataGridViewColumnSortMode.Programmatic;

                double[] smoothingToView = new double[this.data.NumberObservations];

                for (int i = 0; i < notIncludedObservation; i++)
                {
                    smoothingToView[i] = double.NaN;
                }

                for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
                {
                    smoothingToView[i] = this.smoothing[i - notIncludedObservation];
                }

                for (int i = 0; i < data.NumberObservations; i++)
                {
                    grdBrown.Rows[i].Cells[1].Value = smoothingToView[i].ToString("F4");
                }

                cell = cell + 1;
            }

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
                residualToView[i] = this.variable[i] - this.predicted[i - notIncludedObservation];
            }

            grdBrown.Columns[cell + 1].HeaderCell.Value = "Predicted";
            grdBrown.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;

            grdBrown.Columns[cell + 2].HeaderCell.Value = "Residual";
            grdBrown.Columns[cell + 2].SortMode = DataGridViewColumnSortMode.Programmatic;

            for (int i = 0; i < data.NumberObservations; i++)
            {
                grdBrown.Rows[i].Cells[cell + 1].Value = predictedToView[i].ToString("F4");
                grdBrown.Rows[i].Cells[cell + 2].Value = residualToView[i].ToString("F4");
            }
        }
    }
}
