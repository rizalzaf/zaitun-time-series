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
    public partial class DoubleExponentialSmoothingHoltDataGrid : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] smoothing;
        private double[] trend;
        private double[] predicted;
        private double[] residual;

        private bool isSmoothingVisible;
        private bool isTrendVisible;

        public DoubleExponentialSmoothingHoltDataGrid()
        {
            InitializeComponent();
            grdHolt.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

        }

        public void SetData(SeriesData data, SeriesVariable variable, bool isSmoothingVisible, bool isTrendVisible, double[] smoothing, double[] trend, double[] predicted, double[] residual)
        {
            this.data = data;
            this.variable = variable;
            this.isSmoothingVisible = isSmoothingVisible;
            this.isTrendVisible = isTrendVisible;
            this.smoothing = smoothing;
            this.trend = trend;
            this.predicted = predicted;
            this.residual = residual;

            this.update();
        }

        private void update()
        {
            int cell = 0;
            int notIncludedObservation = this.data.NumberObservations - this.predicted.Length;

            this.grdHolt.ColumnCount = 3;

            grdHolt.RowCount = this.data.NumberObservations;
            grdHolt.Columns[0].HeaderCell.Value = "Actual";
            grdHolt.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;

            for (int i = 0; i < data.NumberObservations; i++)
            {
                grdHolt.Rows[i].HeaderCell.Value = this.data.Time[i];
                grdHolt.Rows[i].Cells[0].Value = this.variable[i].ToString("F4");
            }

            if (this.isSmoothingVisible)
            {
                this.grdHolt.ColumnCount = this.grdHolt.ColumnCount + 1;
                grdHolt.Columns[cell + 1].HeaderCell.Value = "Smoothed";
                grdHolt.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;

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
                    grdHolt.Rows[i].Cells[cell + 1].Value = smoothingToView[i].ToString("F4");
                }

                cell = cell + 1;
            }

            if (this.isTrendVisible)
            {
                this.grdHolt.ColumnCount = this.grdHolt.ColumnCount + 1;
                grdHolt.Columns[cell + 1].HeaderCell.Value = "Trend";
                grdHolt.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;

                double[] trendToView = new double[this.data.NumberObservations];

                for (int i = 0; i < notIncludedObservation; i++)
                {
                    trendToView[i] = double.NaN;
                }

                for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
                {
                    trendToView[i] = this.trend[i - notIncludedObservation];
                }

                for (int i = 0; i < data.NumberObservations; i++)
                {
                    grdHolt.Rows[i].Cells[cell + 1].Value = trendToView[i].ToString("F4");
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

            grdHolt.Columns[cell + 1].HeaderCell.Value = "Predicted";
            grdHolt.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;

            grdHolt.Columns[cell + 2].HeaderCell.Value = "Residual";
            grdHolt.Columns[cell + 2].SortMode = DataGridViewColumnSortMode.Programmatic;

            for (int i = 0; i < data.NumberObservations; i++)
            {
                grdHolt.Rows[i].Cells[cell + 1].Value = predictedToView[i].ToString("F4");
                grdHolt.Rows[i].Cells[cell + 2].Value = residualToView[i].ToString("F4");
            }
        }

    }
}
