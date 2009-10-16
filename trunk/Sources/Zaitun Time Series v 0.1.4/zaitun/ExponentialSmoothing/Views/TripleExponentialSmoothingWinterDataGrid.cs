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
    public partial class TripleExponentialSmoothingWinterDataGrid : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] smoothing;
        private double[] trend;
        private double[] seasonal;
        private double[] predicted;
        private double[] residual;

        private bool isSmoothingVisible;
        private bool isTrendVisible;
        private bool isSeasonalVisible;

        public TripleExponentialSmoothingWinterDataGrid()
        {
            InitializeComponent();
            grdWinter.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

        }

        public void SetData(SeriesData data, SeriesVariable variable, bool isSmoothingVisible, bool isTrendVisible, bool isSeasonalVisible, double[] smoothing, double[] trend, double[] seasonal, double[] predicted, double[] residual)
        {
            this.data = data;
            this.variable = variable;
            this.isSmoothingVisible = isSmoothingVisible;
            this.isTrendVisible = isTrendVisible;
            this.isSeasonalVisible = isSeasonalVisible;
            this.smoothing = smoothing;
            this.trend = trend;
            this.seasonal = seasonal;
            this.predicted = predicted;
            this.residual = residual;

            this.update();
        }

        private void update()
        {
            int cell = 0;
            int notIncludedObservation = this.data.NumberObservations - this.predicted.Length;

            this.grdWinter.ColumnCount = 3;

            grdWinter.RowCount = this.data.NumberObservations;
            grdWinter.Columns[0].HeaderCell.Value = "Actual";
            grdWinter.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;

            for (int i = 0; i < data.NumberObservations; i++)
            {
                grdWinter.Rows[i].HeaderCell.Value = this.data.Time[i];
                grdWinter.Rows[i].Cells[0].Value = this.variable[i].ToString("F4");
            }

            if (this.isSmoothingVisible)
            {
                this.grdWinter.ColumnCount = this.grdWinter.ColumnCount + 1;
                grdWinter.Columns[cell + 1].HeaderCell.Value = "Smoothed";
                grdWinter.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;

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
                    grdWinter.Rows[i].Cells[cell + 1].Value = smoothingToView[i].ToString("F4");
                }

                cell = cell + 1;
            }

            if (this.isTrendVisible)
            {
                this.grdWinter.ColumnCount = this.grdWinter.ColumnCount + 1;
                grdWinter.Columns[cell + 1].HeaderCell.Value = "Trend";
                grdWinter.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;

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
                    grdWinter.Rows[i].Cells[cell + 1].Value = trendToView[i].ToString("F4");
                }

                cell = cell + 1;
            }

            if (this.isSeasonalVisible)
            {
                this.grdWinter.ColumnCount = this.grdWinter.ColumnCount + 1;
                grdWinter.Columns[cell + 1].HeaderCell.Value = "Seasonal";
                grdWinter.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;

                double[] seasonalToView = new double[this.data.NumberObservations];

                for (int i = 0; i < notIncludedObservation; i++)
                {
                    seasonalToView[i] = double.NaN;
                }

                for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
                {
                    seasonalToView[i] = this.seasonal[i - notIncludedObservation];
                }

                for (int i = 0; i < data.NumberObservations; i++)
                {
                    grdWinter.Rows[i].Cells[cell + 1].Value = seasonalToView[i].ToString("F4");
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

            grdWinter.Columns[cell + 1].HeaderCell.Value = "Predicted";
            grdWinter.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;

            grdWinter.Columns[cell + 2].HeaderCell.Value = "Residual";
            grdWinter.Columns[cell + 2].SortMode = DataGridViewColumnSortMode.Programmatic;

            for (int i = 0; i < data.NumberObservations; i++)
            {
                grdWinter.Rows[i].Cells[cell + 1].Value = predictedToView[i].ToString("F4");
                grdWinter.Rows[i].Cells[cell + 2].Value = residualToView[i].ToString("F4");
            }
        }

    }
}
