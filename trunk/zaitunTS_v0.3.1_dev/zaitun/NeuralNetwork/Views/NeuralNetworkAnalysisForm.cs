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
using zaitun.NeuralNetwork;
using System.Threading;
using AForge;
using AForge.Neuro;
using AForge.Controls;
using AForge.Neuro.Learning;

namespace zaitun.NeuralNetwork
{
    /// <summary>
    /// Kelas form analisis neural network
    /// </summary>
    public partial class NeuralNetworkAnalysisForm : Form
    {
        //Data
        private SeriesVariable variable;

        //Network
        private IActivationFunction activationFunction;
        private ActivationNetwork network;
        private BackPropagationLearning learning;

        //Network Structure
        private int inputLayerNeurons = 12;
        private int hiddenLayerNeurons = 12;
        private int outputLayerNeurons = 1;

        private double learningRate = 0.05;
        private double momentum = 0.5;
        private int maxIteration = 10000;

        private ActivationFunctionEnumeration selectedActivationFunction;

        private bool withCheckingCycle = true;
        private int checkingCycle = 100;
        private double byMSEValueStopping = 0.1;
        private double byMSEChangeStopping = 0.001;
        private CheckingMethodEnumeration checkingMethod;

        private bool useAdvanceEarlyStopping = false;
        private double validationSetRatio = 0.2;
        private double generalizationLossTreshold = 2.0;
        private double pqTreshold = 1.5;
        private int strip = 5;
        private AdvanceStoppingMethodEnumeration advanceStoppingMethod;


        //Data For Network
        private double[] data;

        private double[][] networkInput;
        private double[][] networkOutput;

        private double minNormalizedData, maxNormalizedData, factor;
        private double minData, maxData;

        private double[] solutionData;
        private double[,] solutionToShow;
        private double[,] validationSolutionToShow;


        //Best weight
        private double[][][] bestNetworkWeight;
        private double[][] bestNetworkBias;
        private double[] bestSolution;
        private double bestValidationError;

        //data for read only properties
        private double error;
        private double mse;
        private double mae;

        //Thread
        private Thread learningThread;
        bool needToStop = false;

        /// <summary>
        /// spesifikasi network
        /// </summary>
        public struct NetworkSpecification
        {
            public int InputLayerNeurons;
            public int HiddenLayerNeurons;
            public int OutputLayerNeurons;

            public double LearningRate;
            public double Momentum;
            public ActivationFunctionEnumeration ActivationFunction;

            public int IncludedObservations;

            public double Error;
            public double MSE;
            public double MAE;
        }

        /// <summary>
        /// enumerasi fungsi aktivasi
        /// </summary>
        public enum ActivationFunctionEnumeration
        {
            SemiLinearFunction,
            SigmoidFunction,
            BipolarSigmoidFunction,
            HyperbolicTangentFunction
        }

        /// <summary>
        /// enumerasi metode pengecekan
        /// </summary>
        private enum CheckingMethodEnumeration
        {
            byMSEValue,
            byMSEChange
        }

        /// <summary>
        /// enumerasi metode cross validation
        /// </summary>
        private enum AdvanceStoppingMethodEnumeration
        {
            GeneralizationLoss,
            ProgressQuotient
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public NeuralNetworkAnalysisForm()
        {
            InitializeComponent();            

            seriesChart.AddDataSeries("Actual", Color.Blue, Chart.SeriesType.ConnectedDots, 1);
            seriesChart.AddDataSeries("Predicted", Color.Red, Chart.SeriesType.ConnectedDots, 1);
            seriesChart.AddDataSeries("Validation", Color.Green, Chart.SeriesType.ConnectedDots, 1);
            

            this.updateSettings();
            
        }

        /// <summary>
        /// Mengupdate setting neural network
        /// </summary>
        private void updateSettings()
        {
            this.inputLayerBox.Text = this.inputLayerNeurons.ToString();
            this.hiddenLayerBox.Text = this.hiddenLayerNeurons.ToString();
            this.outputLayerBox.Text = this.outputLayerNeurons.ToString();

            this.learningRateBox.Text = this.learningRate.ToString();
            this.momentumBox.Text = this.momentum.ToString();
            this.maxIterationBox.Text = this.maxIteration.ToString();

            this.checkingCycleBox.Text = this.checkingCycle.ToString();
            this.byMSEValueBox.Text = this.byMSEValueStopping.ToString();
            this.byMSEChangeBox.Text = this.byMSEChangeStopping.ToString();

            this.validationSetRatioBox.Text = this.validationSetRatio.ToString();
            this.generalizationLossTresholdBox.Text = this.generalizationLossTreshold.ToString();
            this.PQTresholdBox.Text = this.pqTreshold.ToString();
            this.stripBox.Text = this.strip.ToString();
        }

        /// <summary>
        /// Mengeset variabel yang aka dianalisis
        /// </summary>
        /// <param name="variable">variabel yang aka dianalisis</param>
        public void SetVariable(SeriesVariable variable)
        {
            this.variable = variable;

            this.data = variable.SeriesValuesNoNaN.ToArray();

            double[,] actualSeries = new double[variable.Observations,2];

            for (int i = 0; i < variable.Observations; i++)
            {
                actualSeries[i, 0] = i;
                actualSeries[i, 1] = variable.SeriesValuesNoNaN[i];                
            }

            seriesChart.RangeX = new DoubleRange(0, variable.Observations - 1);
           
            seriesChart.UpdateDataSeries("Actual", actualSeries);
            seriesChart.UpdateDataSeries("Predicted", null);

            this.observationLabel.Text = "Observations : " + variable.Observations.ToString();
            this.Text = "Neural Network Analysis Form : " + variable.VariableName;

        }      

        /// <summary>
        /// Event handler withCheckingCycleCheck_CheckedChanged
        /// </summary>        
        private void withCheckingCycleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                this.checkingCycleBox.ReadOnly = false;
                this.StoppingGroupBox.Visible = true;
                if (this.useAdvanceCheck.Checked == true) this.useAdvanceCheck.Checked = false;
            }
            else
            {
                this.checkingCycleBox.ReadOnly = true;
                this.StoppingGroupBox.Visible = false;
            }
        }

        /// <summary>
        /// Event handler useAdvanceCheck_CheckedChanged
        /// </summary>
        private void useAdvanceCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                this.advanceGroupBox.Visible = true;
                this.advanceViewGroupBox.Visible = true;
                this.validationSetRatioLabel.Visible = true;
                this.validationSetRatioBox.Visible = true;
                if (this.withCheckingCycleCheck.Checked == true) this.withCheckingCycleCheck.Checked = false;
            }
            else
            {
                this.advanceGroupBox.Visible = false;
                this.advanceViewGroupBox.Visible = false;
                this.validationSetRatioLabel.Visible = false;
                this.validationSetRatioBox.Visible = false;
            }
        }

        /// <summary>
        /// Event handler byMSEValueRadio_CheckedChanged
        /// </summary>
        private void byMSEValueRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true) this.byMSEValueBox.ReadOnly = false;
            else this.byMSEValueBox.ReadOnly = true;
        }

        /// <summary>
        /// Event handler byMSEChangeRadio_CheckedChanged
        /// </summary>
        private void byMSEChangeRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true) this.byMSEChangeBox.ReadOnly = false;
            else this.byMSEChangeBox.ReadOnly = true;
        }

        /// <summary>
        /// Event handler generalizationLossRadio_CheckedChanged
        /// </summary>
        private void generalizationLossRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true) this.generalizationLossTresholdBox.ReadOnly = false;
            else this.generalizationLossTresholdBox.ReadOnly = true;
        }

        /// <summary>
        /// Event handler PQRadio_CheckedChanged
        /// </summary>
        private void PQRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true) { this.PQTresholdBox.ReadOnly = false; this.stripBox.ReadOnly = false; }
            else { this.PQTresholdBox.ReadOnly = true; this.stripBox.ReadOnly = true; }
        }

        /// <summary>
        /// Event handler startButton_Click
        /// </summary>
        private void startButton_Click(object sender, EventArgs e)
        {
            if (this.startButton.Text == "Start")
            {               

                // get input neuron
                try { this.inputLayerNeurons = Math.Max(1, Math.Min(48, Math.Min(this.variable.Observations / 2, int.Parse(this.inputLayerBox.Text)))); }
                catch { this.inputLayerNeurons = Math.Min(this.variable.Observations / 2, 12); }

                if (this.variable.SeriesValuesNoNaN.Count - this.inputLayerNeurons < 8)
                {
                    MessageBox.Show("Unsufficent number of observations\nModel cannot be estimated with these variable",
                        "Neural Network Analysis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (this.variable.SeriesValuesNoNaN.Count - this.inputLayerNeurons < 28)
                {
                    MessageBox.Show("Too few number of observations\nModel may be not adequate",
                        "Neural Network Analysis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                // get hidden neuron
                try { this.hiddenLayerNeurons = Math.Max(1, Math.Min(48, int.Parse(this.hiddenLayerBox.Text))); }
                catch { this.hiddenLayerNeurons = 12; }

                // get learning rate
                try { this.learningRate = Math.Max(0.00001, Math.Min(1, double.Parse(this.learningRateBox.Text))); }
                catch { this.learningRate = 0.05; }

                // get momentum
                try { this.momentum = Math.Max(0.00, Math.Min(1, double.Parse(this.momentumBox.Text))); }
                catch { this.momentum = 0.5; }

                // get max iteration
                try { this.maxIteration = Math.Max(10, Math.Min(1000000, int.Parse(this.maxIterationBox.Text))); }
                catch { this.maxIteration = 10000; }

                //get activationfunction
                if (this.semiLinearRadio.Checked == true) this.selectedActivationFunction = ActivationFunctionEnumeration.SemiLinearFunction;
                else if (this.sigmoidRadio.Checked == true) this.selectedActivationFunction = ActivationFunctionEnumeration.SigmoidFunction;
                else if (this.bipolarSigmoidRadio.Checked == true) this.selectedActivationFunction = ActivationFunctionEnumeration.BipolarSigmoidFunction;
                else if (this.hyperbolicTangentRadio.Checked == true) this.selectedActivationFunction = ActivationFunctionEnumeration.HyperbolicTangentFunction;

                //get with checking cycle
                this.withCheckingCycle = this.withCheckingCycleCheck.Checked;

                //get checking cycle
                try { this.checkingCycle = Math.Max(1, Math.Min(10000, int.Parse(this.checkingCycleBox.Text))); }
                catch { this.checkingCycle = 100; }

                //get checking method
                if (this.byMSEValueRadio.Checked == true) this.checkingMethod = CheckingMethodEnumeration.byMSEValue;
                else if (this.byMSEChangeRadio.Checked == true) this.checkingMethod = CheckingMethodEnumeration.byMSEChange;

                //get bymsevalue
                try { this.byMSEValueStopping = Math.Max(0.000001, double.Parse(this.byMSEValueBox.Text)); }
                catch { this.byMSEValueStopping = 0.1; }

                //get bymsechange
                try { this.byMSEChangeStopping = Math.Max(0.0000001, double.Parse(this.byMSEChangeBox.Text)); }
                catch { this.byMSEChangeStopping = 0.01; }

                //get use advance early stopping
                this.useAdvanceEarlyStopping = this.useAdvanceCheck.Checked;

                //get advance early stopping method
                if (this.generalizationLossRadio.Checked == true) this.advanceStoppingMethod = AdvanceStoppingMethodEnumeration.GeneralizationLoss;
                else if (this.PQRadio.Checked == true) this.advanceStoppingMethod = AdvanceStoppingMethodEnumeration.ProgressQuotient;

                // get validation set ratio
                try { this.validationSetRatio = Math.Max(0.0, Math.Min(0.5, double.Parse(this.validationSetRatioBox.Text))); }
                catch { this.validationSetRatio = 0.3; }

                // get generalization loss treshold
                try { this.generalizationLossTreshold = Math.Max(0.0, Math.Min(90.0, double.Parse(this.generalizationLossTresholdBox.Text))); }
                catch { this.generalizationLossTreshold = 2.0; }

                // get PQ treshold
                try { this.pqTreshold = Math.Max(0.0, Math.Min(90.0, double.Parse(this.PQTresholdBox.Text))); }
                catch { this.pqTreshold = 1.5; }

                //get strip
                try { this.strip = Math.Max(2, Math.Min(20, int.Parse(this.stripBox.Text))); }
                catch { this.strip = 5; }

                this.updateSettings();

                this.enableControls(false);
                this.setProgressView();

                needToStop = false;
                this.learningThread = new Thread(new ThreadStart(this.searchSolution));
                this.learningThread.Start();

                
            }
            else
            {
                // check if worker thread is running
                if ((learningThread != null) && (learningThread.IsAlive))
                {
                    // stop worker thread
                    needToStop = true;
                    learningThread.Join();
                    learningThread = null;
                }

                this.enableControls(true);                
            }
            
        }

        private void setProgressView()
        {
            if (this.previewGrapicRadio.Checked)
            {
                this.seriesChart.Visible = true;
                this.txtProgress.Visible = false;
            }
            else if (this.previewTextRadio.Checked)
            {
                this.seriesChart.Visible = false;
                this.txtProgress.Visible = true;
                this.txtProgress.Clear();
            }
            else if (this.previewNoneRadio.Checked)
            {
                this.seriesChart.Visible = false;
                this.txtProgress.Visible = false;                
            }

        }

        /// <summary>
        /// Event handler NeuralNetworkAnalysisForm_FormClosing
        /// </summary>
        private void NeuralNetworkAnalysisForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // check if worker thread is running
            if ((learningThread != null) && (learningThread.IsAlive))
            {
                // stop worker thread
                needToStop = true;
                learningThread.Join();
                learningThread = null;
            }            
        }
        
        /// <summary>
        /// Mengatur property enable dari controls 
        /// </summary>
        /// <param name="enable">property enable</param>
        private void enableControls(bool enable)
        {
            this.inputLayerBox.Enabled = enable;
            this.hiddenLayerBox.Enabled = enable;
            this.outputLayerBox.Enabled = enable;

            this.learningRateBox.Enabled = enable;
            this.momentumBox.Enabled = enable;
            this.maxIterationBox.Enabled = enable;

            this.semiLinearRadio.Enabled = enable;
            this.sigmoidRadio.Enabled = enable;
            this.bipolarSigmoidRadio.Enabled = enable;
            this.hyperbolicTangentRadio.Enabled = enable;

            this.withCheckingCycleCheck.Enabled = enable;
            this.checkingCycleBox.Enabled = enable;
            this.byMSEChangeRadio.Enabled = enable;
            this.byMSEValueRadio.Enabled = enable;
            this.byMSEValueBox.Enabled = enable;            
            this.byMSEChangeBox.Enabled = enable;

            this.useAdvanceCheck.Enabled = enable;
            this.validationSetRatioBox.Enabled = enable;
            this.generalizationLossTresholdBox.Enabled = enable;
            this.PQTresholdBox.Enabled = enable;
            this.stripBox.Enabled = enable;
            this.generalizationLossRadio.Enabled = enable;
            this.PQRadio.Enabled = enable;

            this.previewGrapicRadio.Enabled = enable;
            this.previewTextRadio.Enabled = enable;
            this.previewNoneRadio.Enabled = enable;

            if (enable)
            {
                this.startButton.Text = "Start";
                this.startButton.Image = global::zaitun.Properties.Resources.run;
            }
            else 
            { 
                this.startButton.Text = "Stop"; 
                this.startButton.Image = global::zaitun.Properties.Resources.stop; 
            }
        }

        /// <summary>
        /// Transformasi data ke range minimum dan maksimum
        /// </summary>
        /// <param name="min">nilai minimum</param>
        /// <param name="max">nilai maksimum</param>
        private void normalizeData(double min, double max)
        {
            double length = max - min;
            double maxData = double.MinValue;
            double minData = double.MaxValue;

            int dataCount = this.data.Length;
            int lag = this.inputLayerNeurons;

            for (int i = 0; i < dataCount; i++)
            {
                if (this.data[i] > maxData) maxData = this.data[i];
                if (this.data[i] < minData) minData = this.data[i];
            }

            double factor = length / (maxData - minData);
            this.factor = factor;
            this.minNormalizedData = min;
            this.maxNormalizedData = max;
            this.minData = minData;
            this.maxData = maxData;

            // normalized input for network
            this.networkInput = new double[dataCount - lag][];
            for (int i = 0; i < dataCount - lag; i++)
                this.networkInput[i] = new double[lag];

            for (int i = 0; i < dataCount - lag; i++)
            {
                for (int j = 0; j < lag; j++)
                {
                    this.networkInput[i][j] = (this.data[i + j] - minData) * factor + min;
                }
            }

            // normalized output for network
            this.networkOutput = new double[dataCount - lag][];
            for (int i = 0; i < dataCount - lag; i++)
                this.networkOutput[i] = new double[1];

            for (int i = 0; i < dataCount - lag; i++)
            {
                this.networkOutput[i][0] = (this.data[i + lag] - minData) * factor + min;
            }
        }

        /// <summary>
        /// Mencari solusi model neural network
        /// </summary>
        private void searchSolution()
        {          

            // Normalize Data
            switch (this.selectedActivationFunction)
            {
                case ActivationFunctionEnumeration.SemiLinearFunction:
                    this.activationFunction = new SemiLinearFunction();
                    this.normalizeData(0.1, 0.9);
                    break;
                case ActivationFunctionEnumeration.SigmoidFunction:
                    this.activationFunction = new SigmoidFunction();
                    this.normalizeData(0.1, 0.9);
                    break;
                case ActivationFunctionEnumeration.BipolarSigmoidFunction:
                    this.activationFunction = new BipolarSigmoidFunction();
                    this.normalizeData(-0.9, 0.9);
                    break;
                case ActivationFunctionEnumeration.HyperbolicTangentFunction:
                    this.activationFunction = new HyperbolicTangentFunction();
                    this.normalizeData(-0.9, 0.9);
                    break;
                default:
                    this.activationFunction = new BipolarSigmoidFunction();
                    this.normalizeData(-0.9, 0.9);
                    break;
            }

            //create network
            this.network = new ActivationNetwork
                (this.activationFunction, this.inputLayerNeurons, this.hiddenLayerNeurons, this.outputLayerNeurons);
            this.network.Randomize();

            this.learning = new BackPropagationLearning(this.network);
            this.learning.LearningRate = this.learningRate;
            this.learning.Momentum = this.momentum;


            //variable for looping
            //needToStop = false;
            double mse = 0.0, error = 0.0, mae=0.0;
            int iteration = 1;

            double msle = 0.0, mspe = 0.0, generalizationLoss = 0.0, pq = 0.0;
            double[] trainingErrors = new double[this.strip];
            for (int i = 0; i < this.strip; i++) trainingErrors[i] = double.MaxValue / strip;

            double lastMSE = double.MaxValue;

            int n = this.data.Length - this.network.InputsCount;
            int validationSet = (int)Math.Round(this.validationSetRatio * n);
            int trainingSet = n - validationSet;
            double[][] networkTrainingInput = new double[trainingSet][];
            double[][] networkTrainingOutput = new double[trainingSet][];
            for (int i = 0; i < trainingSet; i++)
            {
                networkTrainingInput[i] = new double[this.network.InputsCount];
                networkTrainingOutput[i] = new double[1];
            }
            for (int i = 0; i < trainingSet; i++)
            {
                for (int j = 0; j < this.network.InputsCount; j++)
                {
                    networkTrainingInput[i][j] = this.networkInput[i][j];
                }
                networkTrainingOutput[i][0] = this.networkOutput[i][0];
            }

            double[] solutionValidation = new double[validationSet];
            double[] inputForValidation = new double[this.network.InputsCount];
            double[] inputForValidationNetwork = new double[this.network.InputsCount];

            this.bestValidationError = double.MaxValue;
            this.bestNetworkWeight = new double[this.network.LayersCount][][];
            this.bestNetworkBias = new double[this.network.LayersCount][];
            this.bestSolution = new double[n];
            for (int i = 0; i < this.network.LayersCount; i++)
            {
                this.bestNetworkWeight[i] = new double[this.network[i].NeuronsCount][];
                this.bestNetworkBias[i] = new double[this.network[i].NeuronsCount];
                for (int j = 0; j < this.network[i].NeuronsCount; j++)
                {
                    this.bestNetworkWeight[i][j] = new double[this.network[i][j].InputsCount];                    
                }
            }
            //best network criterion
            double bestNetworkError = double.MaxValue, bestNetworkMSE = double.MaxValue, bestNetworkMAE = double.MaxValue;            

            //training
            while (!needToStop)
            {
                double sse = 0.0;
                double sae = 0.0;
                double ssle = 0.0;
                double sspe = 0.0;
                if (this.useAdvanceEarlyStopping)
                    error = this.learning.RunEpoch(networkTrainingInput, networkTrainingOutput);
                else
                    error = this.learning.RunEpoch(this.networkInput, this.networkOutput);                

                this.solutionData = new double[n];
                this.solutionToShow = new double[n, 2];

                if (this.useAdvanceEarlyStopping)
                {
                    //validation
                    //for (int j = 0; j < this.network.InputsCount; j++)
                    //{
                    //    inputForValidation[this.network.InputsCount - 1 - j] = this.data[this.data.Length - validationSet - 1 - j];
                    //}
                }
                else
                {
                    seriesChart.UpdateDataSeries("Validation", null);
                }
                
                this.validationSolutionToShow = new double[validationSet, 2];

                for (int i = 0; i < n; i++)
                {
                    this.solutionData[i] = (this.network.Compute(this.networkInput[i])[0]
                        - this.minNormalizedData) / this.factor + this.minData;

                    this.solutionToShow[i, 0] = i + this.network.InputsCount;
                    this.solutionToShow[i,1] = this.solutionData[i];

                    sse += Math.Pow(this.solutionData[i] - this.data[i + this.network.InputsCount], 2);
                    sae += Math.Abs(this.solutionData[i] - this.data[i + this.network.InputsCount]);

                    //calculate advance early stopping
                    if (this.useAdvanceEarlyStopping)
                    {
                        if (i < n - validationSet)
                        {
                            ssle += Math.Pow(this.solutionData[i] - this.data[i + this.network.InputsCount], 2);
                        }
                        else
                        {

                            if (i == n - validationSet)
                            {
                                for (int j = 0; j < this.network.InputsCount; j++)
                                {
                                    inputForValidation[this.network.InputsCount - 1 - j] = this.data[this.data.Length - (n - i) - 1 - j];
                                }
                            }

                            for (int j = 0; j < this.network.InputsCount; j++)
                            {
                                inputForValidationNetwork[j] = (inputForValidation[j] - this.minData) * this.factor + this.minNormalizedData;
                            }
                            
                            solutionValidation[i - n + validationSet] = (this.network.Compute(inputForValidationNetwork)[0] - this.minNormalizedData) / this.factor + this.minData;

                            this.validationSolutionToShow[i - n + validationSet, 0] = i + this.network.InputsCount;
                            this.validationSolutionToShow[i - n + validationSet, 1] = solutionValidation[i - n + validationSet];

                            sspe += Math.Pow(this.data[i + this.network.InputsCount] - solutionValidation[i - n + validationSet], 2);

                            for (int j = 0; j < this.network.InputsCount - 1; j++)
                            {
                                inputForValidation[j] = inputForValidation[j + 1];
                            }

                            inputForValidation[this.network.InputsCount - 1] = solutionValidation[i - n + validationSet];


                        }
                    }

                }                

                mse = sse / this.solutionData.Length;
                mae = sae / this.solutionData.Length;

                //Display it
                this.iterationBox.Text = iteration.ToString();
                this.maeBox.Text = mae.ToString("F5");
                this.mseBox.Text = mse.ToString("F5");
                this.errorBox.Text = error.ToString("F5");

                if (this.previewGrapicRadio.Checked)
                {
                    seriesChart.UpdateDataSeries("Predicted", this.solutionToShow);
                }
                else if (this.previewTextRadio.Checked)
                {
                    if (!this.useAdvanceEarlyStopping)
                    {
                        txtProgress.AppendText("Iteration: " + iteration.ToString() + "\tError: " + error.ToString("F5") + "\tMAE: " + mae.ToString("F5") + "\tMSE: " + mse.ToString("F5") + "\n");
                        txtProgress.ScrollToCaret();
                    }
                }
                

                if (this.useAdvanceEarlyStopping)
                {
                    //calculate advance early stopping 2
                    mspe = sspe / validationSet;
                    msle = ssle / (this.solutionData.Length - validationSet);

                    //save best weight
                    if (this.bestValidationError > mspe)
                    {
                        this.bestValidationError = mspe;
                        this.bestSolution = this.solutionData;

                        for (int i = 0; i < this.network.LayersCount; i++)
                            for (int j = 0; j < this.network[i].NeuronsCount; j++)
                                for (int k = 0; k < this.network[i][j].InputsCount; k++)
                                    this.bestNetworkWeight[i][j][k] = this.network[i][j][k];

                        for (int i = 0; i < this.network.LayersCount; i++)
                            for (int j = 0; j < this.network[i].NeuronsCount; j++)
                                this.bestNetworkBias[i][j] = this.network[i][j].Threshold;

                        bestNetworkError = error;
                        bestNetworkMAE = mae;
                        bestNetworkMSE = mse;

                    }
                    //calculate generalization loss &pq
                    generalizationLoss = 100 * (mspe / this.bestValidationError - 1);

                    trainingErrors[(iteration - 1) % this.strip] = msle;
                    double minStripTrainingError = double.MaxValue, sumStripTrainingError = 0.0;
                    for (int i = 0; i < this.strip; i++)
                    {
                        sumStripTrainingError += trainingErrors[i];
                        if (trainingErrors[i] < minStripTrainingError) minStripTrainingError = trainingErrors[i];
                    }
                    double trainingProgress = 1000 * ((sumStripTrainingError / (this.strip * minStripTrainingError)) - 1);
                    pq = generalizationLoss / trainingProgress;
                    
                    //display advance early stopping
                    this.learningErrorBox.Text = msle.ToString("F5");
                    this.validationErrorBox.Text = mspe.ToString("F5");
                    this.generalizationLossBox.Text = generalizationLoss.ToString("F5");
                    this.pqBox.Text = pq.ToString("F5");
                    seriesChart.UpdateDataSeries("Validation", this.validationSolutionToShow);

                    if (this.previewTextRadio.Checked)
                    {

                        txtProgress.AppendText("Iteration: " + iteration.ToString() + "\tError: " + error.ToString("F5") + "\tMAE: " + mae.ToString("F5") + "\tMSE: " + mse.ToString("F5") + "\tLearning Error: " + msle.ToString("F5") + "\tValidation Error: " + mspe.ToString("F5") + "\tGeneralization Loss: " + generalizationLoss.ToString("F5") + "\tPQ: " + pq.ToString("F5") + "\n");
                        txtProgress.ScrollToCaret();

                    }

                    //stopping
                    switch (this.advanceStoppingMethod)
                    {
                        case AdvanceStoppingMethodEnumeration.GeneralizationLoss:
                            if (generalizationLoss > this.generalizationLossTreshold) needToStop = true;
                            break;
                        case AdvanceStoppingMethodEnumeration.ProgressQuotient:
                            if (pq > this.pqTreshold) needToStop = true;
                            break;
                    }
                    
                }

                if (this.withCheckingCycle && iteration % this.checkingCycle == 0)
                {
                    switch (this.checkingMethod)
                    {
                        case CheckingMethodEnumeration.byMSEValue:
                            if (mse <= this.byMSEValueStopping) needToStop = true;
                            break;
                        case CheckingMethodEnumeration.byMSEChange:
                            if (lastMSE - mse <= this.byMSEChangeStopping) needToStop = true;
                            break;
                    }
                    lastMSE = mse;
                }
                if (iteration >= this.maxIteration)
                {
                    needToStop = true;
                }

                iteration++;
            }
            
            //restore weight
            if (this.useAdvanceEarlyStopping)
            {
                this.solutionData = this.bestSolution;

                for (int i = 0; i < this.network.LayersCount; i++)
                    for (int j = 0; j < this.network[i].NeuronsCount; j++)
                        for (int k = 0; k < this.network[i][j].InputsCount; k++)
                            this.network[i][j][k] = this.bestNetworkWeight[i][j][k];

                for (int i = 0; i < this.network.LayersCount; i++)
                    for (int j = 0; j < this.network[i].NeuronsCount; j++)
                        this.network[i][j].Threshold = this.bestNetworkBias[i][j];


                //best network criterion
                this.error = bestNetworkError;
                this.mse = bestNetworkMSE;
                this.mae = bestNetworkMAE;
            }
            else
            {
                this.error = error;
                this.mse = mse;
                this.mae = mae;
            }

            this.enableControls(true);

        }

        /// <summary>
        /// Solusi model neural network
        /// </summary>
        public double[] Solution
        {
            get { return this.solutionData; }
        }

        /// <summary>
        /// Meramalkan data
        /// </summary>
        /// <param name="step">step peramalan</param>
        /// <returns>hasil peramalan</returns>
        public double[] Forecast(int step)
        {
            if (step < 1) step = 1;

            int inputsCount = this.network.InputsCount;
            double[] result = new double[step];
            double[] inputForOut = new double[inputsCount];
            double[] inputForOutNetwork = new double[inputsCount];

            //input for forecasting
            for (int j = 0; j < inputsCount; j++)
            {
                inputForOut[inputsCount - 1 - j] = this.data[this.data.Length - 1 - j];
            }

            //forecast
            for (int i = 0; i < step; i++)
            {
                for (int j = 0; j < inputsCount; j++)
                {
                    inputForOutNetwork[j] = (inputForOut[j] - this.minData) * this.factor + this.minNormalizedData;
                }

                // evalue the function
                result[i] = (this.network.Compute(inputForOutNetwork)[0] - this.minNormalizedData) / this.factor + this.minData;

                for (int j = 0; j < inputsCount - 1; j++)
                {
                    inputForOut[j] = inputForOut[j + 1];
                }

                inputForOut[inputsCount - 1] = result[i];
            }

            return result;
        }

        /// <summary>
        /// Property neural network
        /// </summary>
        public NetworkSpecification NetworkProperties
        {
            get 
            {
                NetworkSpecification result = new NetworkSpecification();
                result.InputLayerNeurons = this.inputLayerNeurons;
                result.HiddenLayerNeurons = this.hiddenLayerNeurons;
                result.OutputLayerNeurons = this.outputLayerNeurons;

                result.LearningRate = this.learningRate;
                result.Momentum = this.momentum;
                result.ActivationFunction = this.selectedActivationFunction;

                result.IncludedObservations = this.solutionData.Length;

                result.Error = this.error;
                result.MSE = this.mse;
                result.MAE = this.mae;

                return result;
            }
        }
              
        /// <summary>
        /// Event handler viewResultButton_Click
        /// </summary>
        private void viewResultButton_Click(object sender, EventArgs e)
        {
            if (this.network == null)
            {
                MessageBox.Show("Train the network first!", "Neural Network Analysis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
  
    }
}