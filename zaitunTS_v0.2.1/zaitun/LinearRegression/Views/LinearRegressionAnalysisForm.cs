// Zaitun Time Series 
// http://www.zaitunsoftware.com/
// http://code.google.com/p/zaitun-time-series/
//
// Copyright ©  2008-2009, Zaitun Time Series Developer Team and individual contributors
//
// Leader: Rizal Zaini Ahmad Fathony (rizalzaf@gmail.com)
// Members: Suryono Hadi Wibowo (ryonoha@gmail.com), Khaerul Anas (anasikova@gmail.com), 
//          Lia Amelia (afifahlia@gmail.com), Almaratul Sholihah, Muhamad Fuad Hasan
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using zaitun.Data;
using zaitun.MatrixVector;

namespace zaitun.LinearRegression
{
    /// <summary>
    /// Class for selecting regression variables
    /// </summary>
    public partial class LinearRegressionAnalysisForm : Form
    {
        #region Fields
        private LRSpecification lrProperties;
        private LRComponent lrTable;

        private SeriesData data;
        private SeriesVariable dependentVariable;
        private SeriesVariables independentVariables;
        private double[] forcasted;
        private double[,] testValues;
        private string[] time;
        private int forcastingStep;

        private bool isStorePredicted = false;
        private bool isStoreResidual = false;
        private string predictedName = "";
        private string residualName = "";

        private bool isAnovaTableChecked = true;
        private bool isCorrelationAndCovarianceTableChecked = false;
        private bool isCoefficientTableChecked = true;
        private bool isDataTableChecked = false;
        private bool isForcastedTableChecked = false;
        private bool isConfidenceIntervalForParametersChecked = false;
        private bool isPartialCorrelationChecked = false;
        private bool isVIFForPredictorsChecked = false;
        private bool isDurbinWatsonChecked = false;
        private bool isResidualVsPredictedGraphChecked = false;
        private bool isResidualGraphChecked = false;
        private bool isNormalProbabilityPlotChecked = false;
        #endregion

        public struct LRSpecification
        {
            public int IncludedObservations;
            public bool IsMultiple;
            public double R;
            public double RSquare;
            public double AdjRSquare;
            public double StandardError;
            public double DurbinWatson;
            public double F;
            public double SigOfF;
            public double SSE;
            public double SSR;
            public double SST;
            public double MSE;
            public double MSR;
            public double[] Parameters;
            public double[] StandardErrorOfParameters;
            public double[] t;
            public double[] SigOfT;
            public double[] LowerBoundForParameters;
            public double[] UpperBoundForParameters;
            public double[] VIFForpredictors;
            public double[] Correlations;
            public double[] PartialCorrelations;
        }

        public struct LRComponent
        {
            public double[] Actual;
            public double[] Predicted;
            public double[] Residual;
            public double[] ExpectedResidual;
        }


        #region Constructor

        public LinearRegressionAnalysisForm(SeriesData data)
        {
            InitializeComponent();
            this.data = data;
            foreach (SeriesVariable var in this.data.SeriesVariables)
            {
                this.lstVariables.Items.Add(var);
            }
            this.lstVariables.SelectedIndex = 0;
        }

        #endregion

        #region Procedure Member

        private void estimateParameters()
        {
            LinearRegressionModel lrModel = new LinearRegressionModel(this.dependentVariable, this.independentVariables);
            
            this.lrProperties.IncludedObservations = this.dependentVariable.Observations;
            this.lrProperties.R = lrModel.LSE.R;
            this.lrProperties.RSquare = lrModel.LSE.RSquare;
            this.lrProperties.AdjRSquare = lrModel.LSE.AdjRSquare;
            this.lrProperties.StandardError = lrModel.LSE.StandardError;
            this.lrProperties.DurbinWatson = lrModel.DurbinWatson;

            this.lrProperties.SSR = lrModel.LSE.SSR;
            this.lrProperties.SST = lrModel.LSE.SSTO;
            this.lrProperties.SSE = lrModel.LSE.SSE;
            this.lrProperties.MSE = lrModel.LSE.MSE;
            this.lrProperties.MSR = lrModel.LSE.MSR;
            this.lrProperties.F = lrModel.F;
            this.lrProperties.SigOfF = lrModel.SigOfF;

            this.lrProperties.Parameters = lrModel.LSE.B.GetData();
            this.lrProperties.StandardErrorOfParameters = lrModel.StandardErrorOfParameters;
            this.lrProperties.t = lrModel.T;
            this.lrProperties.SigOfT = lrModel.SigOfT;
            this.lrProperties.LowerBoundForParameters = lrModel.LowerBoundCIForParameters;
            this.lrProperties.UpperBoundForParameters = lrModel.UpperBoundCIForParameters;
            this.lrProperties.VIFForpredictors = lrModel.VifForPredictors;
            this.lrProperties.PartialCorrelations = lrModel.PartialCorrelation;
            this.lrProperties.Correlations = lrModel.Correlations;

            this.lrTable.Actual = lrModel.LSE.Y.GetData();
            this.lrTable.Predicted = lrModel.LSE.YCap.GetData();
            this.lrTable.Residual = lrModel.LSE.E.GetData();
            this.lrTable.ExpectedResidual = lrModel.ExpectedResidual;
        }

        private void forcast()
        {
            int p = this.lrProperties.Parameters.Length;
            this.forcasted = new double[this.forcastingStep];
            for (int i = 0; i < this.forcastingStep; i++)
            {
                this.forcasted[i] = this.lrProperties.Parameters[0];
                for (int j = 1; j < p;j++ )
                {
                    this.forcasted[i] += this.lrProperties.Parameters[j] * this.testValues[j - 1, i];
                }
            }
        }
        private void getSelectedVariable()
        {
            this.dependentVariable = (SeriesVariable)this.lstDependent.Items[0];
            this.independentVariables = new SeriesVariables();
            foreach (Object item in this.lstIndependents.Items)
            {
                this.independentVariables.Add((SeriesVariable)item);
            }
        }
        #endregion

        #region btnReset
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (this.lstIndependents.Items.Count > 0 || this.lstDependent.Items.Count==1)
            {
                this.lstVariables.Items.Clear();
                this.lstIndependents.Items.Clear();
                this.lstDependent.Items.Clear();
                this.lstVariables.ClearSelected();
                foreach (SeriesVariable var in this.data.SeriesVariables)
                {
                    this.lstVariables.Items.Add(var);
                }
                this.lstVariables.SelectedIndex = 0;
                if (this.btnDependent.Text == "<") this.btnDependent.Text = ">";
            }
            if (this.btnOK.Enabled) this.btnOK.Enabled = false;
        }
        #endregion

        #region lstVariables
        private void lstVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstVariables.SelectedIndex >= 0 && this.lstVariables.SelectedIndex < this.lstVariables.Items.Count)
            {
                if (this.btnIndependent.Text == "<") this.btnIndependent.Text = ">";
                if (!this.btnIndependent.Enabled) this.btnIndependent.Enabled = true;
                if (this.lstDependent.Items.Count == 0)
                {
                    if (!this.btnDependent.Enabled) this.btnDependent.Enabled = true;
                }
                else
                {
                    if (this.btnDependent.Enabled) this.btnDependent.Enabled = false;
                }
            }
            else
            {
                if (this.btnIndependent.Text == ">")
                    if (this.btnIndependent.Enabled) this.btnIndependent.Enabled = false;
                if (this.btnDependent.Enabled) this.btnDependent.Enabled = false;
            }
        }
        #endregion

        #region lstIndependents
        private void lstIndependents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstIndependents.SelectedIndex >= 0 && this.lstIndependents.SelectedIndex < this.lstIndependents.Items.Count)
            {
                if (this.btnIndependent.Text == ">") this.btnIndependent.Text = "<";
                if (!this.btnIndependent.Enabled) this.btnIndependent.Enabled = true;
            }
            else
            {
                if (this.btnIndependent.Text == "<")
                    if (this.btnIndependent.Enabled) this.btnIndependent.Enabled = false;
            }
        }
        private void lstIndependents_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.lstIndependents.IndexFromPoint(e.X, e.Y) < 0)
            {
                this.lstIndependents.ClearSelected();
                if (this.btnIndependent.Enabled) this.btnIndependent.Enabled = false;
                if (this.btnDependent.Enabled) this.btnDependent.Enabled = false;
            }
            if (this.btnIndependent.Text == ">") this.btnIndependent.Text = "<";
            this.lstVariables.ClearSelected();
            this.lstDependent.ClearSelected();
        }
        #endregion

        #region btnIndependent
        private void btnIndependent_Click(object sender, EventArgs e)
        {
            if (this.btnIndependent.Text == ">")
            {
                this.lstIndependents.Items.Add(this.lstVariables.SelectedItem);
                this.lstVariables.Items.Remove(this.lstVariables.SelectedItem);
                this.lstIndependents.SelectedIndex = this.lstIndependents.Items.Count - 1;
                this.lstVariables.ClearSelected();
            }
            else
            {
                bool isInserted = false;
                int index = this.data.SeriesVariables.IndexOf((SeriesVariable)this.lstIndependents.SelectedItem);
                for (int i = 0; i < this.lstVariables.Items.Count; i++)
                {
                    if (index < this.data.SeriesVariables.IndexOf((SeriesVariable)this.lstVariables.Items[i]))
                    {
                        this.lstVariables.Items.Insert(i, this.lstIndependents.SelectedItem);
                        index = i;
                        isInserted = true;
                        break;
                    }

                }
                if (!isInserted)
                {
                    this.lstVariables.Items.Add(this.lstIndependents.SelectedItem);
                    this.lstVariables.SelectedIndex = this.lstVariables.Items.Count - 1;
                }
                else
                {
                    this.lstVariables.SelectedIndex = index;
                }
                this.lstIndependents.Items.Remove(this.lstIndependents.SelectedItem);
                this.lstIndependents.ClearSelected();

            }
            if (this.lstIndependents.Items.Count > 0 && this.lstDependent.Items.Count == 1)
            {
                if (!this.btnOK.Enabled) this.btnOK.Enabled = true;
            }
            else
            {
                if (this.btnOK.Enabled) this.btnOK.Enabled = false;
            }
        }
        #endregion

        #region btnCancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region lstVariables
        private void lstVariables_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.lstVariables.IndexFromPoint(e.X, e.Y) < 0)
            {
                this.lstVariables.ClearSelected();
                if (this.btnIndependent.Enabled) this.btnIndependent.Enabled = false;
                if (this.btnDependent.Enabled) this.btnDependent.Enabled = false;
            }
            if (this.btnIndependent.Text == "<") this.btnIndependent.Text = ">";
            if (this.btnDependent.Text == "<") this.btnDependent.Text = ">";
            this.lstIndependents.ClearSelected();
            this.lstDependent.ClearSelected();
        }
        #endregion

        #region btnDependent
        private void btnDependent_Click(object sender, EventArgs e)
        {
            if (this.btnDependent.Text == ">")
            {
                this.lstDependent.Items.Add(this.lstVariables.SelectedItem);
                this.btnDependent.Text = "<";
                this.btnDependent.Enabled = false;
                //this.selectedIndexDependentVariable = this.seriesVariables.IndexOf((SeriesVariable)this.lstVariables.SelectedItem);
                this.lstVariables.Items.Remove(this.lstVariables.SelectedItem);
                this.lstDependent.SelectedIndex = 0;
                if (this.lstIndependents.Items.Count > 1)
                    if (!this.btnOK.Enabled) this.btnOK.Enabled = true;
            }
            else
            {
                bool isInserted = false;
                int index = this.data.SeriesVariables.IndexOf((SeriesVariable)this.lstDependent.SelectedItem);
                for (int i = 0; i < this.lstVariables.Items.Count; i++)
                {
                    if (index < this.data.SeriesVariables.IndexOf((SeriesVariable)this.lstVariables.Items[i]))
                    {
                        this.lstVariables.Items.Insert(i, this.data.SeriesVariables[index]);
                        index = i;
                        isInserted = true;
                        break;
                    }

                }
                if (!isInserted)
                {
                    this.lstVariables.Items.Add(this.data.SeriesVariables[index]);
                    this.lstVariables.SelectedIndex = this.lstVariables.Items.Count - 1;
                }
                else
                {
                    this.lstVariables.SelectedIndex = index;
                }
                this.lstDependent.Items.Clear();
                this.btnDependent.Text = ">";
                if (!this.btnDependent.Enabled) this.btnDependent.Enabled = true;
                if (this.btnOK.Enabled) this.btnOK.Enabled = false;
            }
        }
        #endregion

        #region lstDependent
        private void lstDependent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstDependent.SelectedIndex == 0)
            {
                this.lstVariables.ClearSelected();
                this.lstIndependents.ClearSelected();
                if (!this.btnDependent.Enabled) this.btnDependent.Enabled = true;
                if (this.btnDependent.Text == ">") this.btnDependent.Text = "<";
            }
            else
            {
                if (this.btnDependent.Enabled) this.btnDependent.Enabled = false;
            }
        }
        #endregion

        #region btnOK
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Cursor = Cursors.WaitCursor;
            getSelectedVariable();

            if (this.independentVariables.Count > 1)
                this.lrProperties.IsMultiple = true;
            else 
                this.lrProperties.IsMultiple = false;

            try
            {
                this.estimateParameters();
                if (isForcastedTableChecked)
                {
                    forcast();
                }
            }
            catch (SingularMatrixException)
            {
                MessageBox.Show("The model has a singular matrix. The computation cannot be done");
                this.DialogResult = DialogResult.None;
            }
            catch (Exception)
            {
                MessageBox.Show("Computation Error");
                this.DialogResult = DialogResult.None;
            }
            
           
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region btnResults
        private void btnResults_Click(object sender, EventArgs e)
        {
            LRSelectResultView resultsDlg = new LRSelectResultView();
            resultsDlg.IsAnovaTableChecked = isAnovaTableChecked;
            resultsDlg.IsCoefficientTableChecked = isCoefficientTableChecked;
            resultsDlg.IsConfidenceIntervalsChecked = isConfidenceIntervalForParametersChecked;
            resultsDlg.IsVIFChecked = isVIFForPredictorsChecked;
            resultsDlg.IsPartialCorrelationChecked = isPartialCorrelationChecked;
            resultsDlg.IsDurbinWatsonChecked = isDurbinWatsonChecked;
            resultsDlg.IsForcastedTableChecked = isForcastedTableChecked;
            resultsDlg.IsForcastedTableEnabled = this.btnOK.Enabled;
            resultsDlg.IsActualPredictedAndResidualChecked = isDataTableChecked;
            resultsDlg.IsResidualVsPredictedGraphChecked = isResidualVsPredictedGraphChecked;
            resultsDlg.IsResidualGraphChecked = isResidualGraphChecked;
            resultsDlg.IsNormalProbabilityPlotChecked = isNormalProbabilityPlotChecked;
            getSelectedVariable();
            resultsDlg.SetData(this.data, this.independentVariables);
            if (resultsDlg.ShowDialog() == DialogResult.OK)
            {
                isAnovaTableChecked = resultsDlg.IsAnovaTableChecked;
                isCoefficientTableChecked = resultsDlg.IsCoefficientTableChecked;
                isConfidenceIntervalForParametersChecked = resultsDlg.IsConfidenceIntervalsChecked;
                isVIFForPredictorsChecked = resultsDlg.IsVIFChecked;
                isPartialCorrelationChecked = resultsDlg.IsPartialCorrelationChecked;
                isDurbinWatsonChecked = resultsDlg.IsDurbinWatsonChecked;
                isForcastedTableChecked = resultsDlg.IsForcastedTableChecked;
                isDataTableChecked = resultsDlg.IsActualPredictedAndResidualChecked;
                isResidualVsPredictedGraphChecked = resultsDlg.IsResidualVsPredictedGraphChecked;
                isResidualGraphChecked = resultsDlg.IsResidualGraphChecked;
                isNormalProbabilityPlotChecked = resultsDlg.IsNormalProbabilityPlotChecked;
                if (isForcastedTableChecked)
                {
                    this.forcastingStep = resultsDlg.ForcastingStep;
                    this.testValues = resultsDlg.TestValues;
                    this.time = resultsDlg.ForcastedTime;
                }
            }
        }
        #endregion

        #region btnStorage
        private void btnStorage_Click(object sender, EventArgs e)
        {
            LRStorageForm storageDlg = new LRStorageForm();
            storageDlg.IsStorePredicted = isStorePredicted;
            storageDlg.IsStoreResidual = isStoreResidual;
            storageDlg.PredictedName = predictedName;
            storageDlg.ResidualName = residualName;
            if (storageDlg.ShowDialog() == DialogResult.OK)
            {
                isStorePredicted = storageDlg.IsStorePredicted;
                isStoreResidual = storageDlg.IsStoreResidual;
                predictedName = storageDlg.PredictedName;
                residualName = storageDlg.ResidualName;
            }
        }
        #endregion

        #region Properties
        public LRSpecification LRProperties
        {
            get { return this.lrProperties; }
        }

        public LRComponent LRTable
        {
            get { return this.lrTable; }
        }

        public SeriesVariables IndependentVariables
        {
            get { return this.independentVariables; }
        }

        public SeriesVariable DependentVariable
        {
            get { return this.dependentVariable; }
        }
        public double[,] TestValues
        {
            get { return this.testValues; }
        }
        public string[] ForcastedTime
        {
            get { return this.time; }
        }
        public double[] ForcastedData
        {
            get { return this.forcasted; }
        }
        public bool IsStorePredicted
        {
            get { return this.isStorePredicted; }
        }

        public bool IsStoreResidual
        {
            get { return this.isStoreResidual; }
        }


        public string PredictedName
        {
            get { return this.predictedName; }
        }

        public string ResidualName
        {
            get { return this.residualName; }
        }
        public bool IsAnovaTableChecked
        {
            get { return this.isAnovaTableChecked; }
        }
        public bool IsCoefficientTableChecked
        {
            get { return this.isCoefficientTableChecked; }
        }
        public bool IsCorrelationAndCovarianceTableChecked
        {
            get { return this.isCorrelationAndCovarianceTableChecked; }
        }
        public bool IsDataTableChecked
        {
            get { return this.isDataTableChecked; }
        }

        public bool IsDurbinWatsonChecked
        {
            get { return this.isDurbinWatsonChecked; }
        }
        public bool IsForcastedTableChecked
        {
            get { return this.isForcastedTableChecked; }
        }
        public bool IsConfidenceIntervalForParametersChecked
        {
            get { return this.isConfidenceIntervalForParametersChecked; }
        }
        public bool IsVIFForPredictorsChecked
        {
            get { return this.isVIFForPredictorsChecked; }
        }
        public bool IsPartialCorrelationCecked
        {
            get { return this.isPartialCorrelationChecked; }
        }
        public bool IsResidualVsPredictedGraphChecked
        {
            get { return this.isResidualVsPredictedGraphChecked; }
        }

        public bool IsResidualGraphChecked
        {
            get { return this.isResidualGraphChecked; }
        }
        public bool IsNormalProbabilityPlotChecked
        {
            get { return this.isNormalProbabilityPlotChecked; }
        }
        #endregion

    }
}