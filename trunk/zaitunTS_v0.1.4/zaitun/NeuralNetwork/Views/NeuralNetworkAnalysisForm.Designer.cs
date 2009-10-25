using zaitun.GUI;

namespace zaitun.NeuralNetwork
{
    partial class NeuralNetworkAnalysisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.StoppingGroupBox = new System.Windows.Forms.GroupBox();
            this.byMSEChangeBox = new zaitun.GUI.DecimalTextBox();
            this.byMSEValueBox = new zaitun.GUI.DecimalTextBox();
            this.byMSEChangeRadio = new System.Windows.Forms.RadioButton();
            this.byMSEValueRadio = new System.Windows.Forms.RadioButton();
            this.withCheckingCycleCheck = new System.Windows.Forms.CheckBox();
            this.checkingCycleBox = new zaitun.GUI.NumericTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.hyperbolicTangentRadio = new System.Windows.Forms.RadioButton();
            this.bipolarSigmoidRadio = new System.Windows.Forms.RadioButton();
            this.sigmoidRadio = new System.Windows.Forms.RadioButton();
            this.semiLinearRadio = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.learningRateBox = new zaitun.GUI.DecimalTextBox();
            this.momentumBox = new zaitun.GUI.DecimalTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.maxIterationBox = new zaitun.GUI.NumericTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.outputLayerBox = new zaitun.GUI.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hiddenLayerBox = new zaitun.GUI.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputLayerBox = new zaitun.GUI.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.seriesGraph = new GraphLib.PlotterGraphPaneEx();
            this.validationSetLabel = new System.Windows.Forms.Label();
            this.validationSetLine = new System.Windows.Forms.Label();
            this.observationLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.maeBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.iterationBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mseBox = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.advanceGroupBox = new System.Windows.Forms.GroupBox();
            this.PQRadio = new System.Windows.Forms.RadioButton();
            this.generalizationLossRadio = new System.Windows.Forms.RadioButton();
            this.stripBox = new zaitun.GUI.NumericTextBox();
            this.generalizationLossTresholdBox = new zaitun.GUI.DecimalTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.PQTresholdBox = new zaitun.GUI.DecimalTextBox();
            this.validationSetRatioBox = new zaitun.GUI.DecimalTextBox();
            this.advanceViewGroupBox = new System.Windows.Forms.GroupBox();
            this.pqBox = new zaitun.GUI.DecimalTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.generalizationLossBox = new zaitun.GUI.DecimalTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.learningErrorBox = new zaitun.GUI.DecimalTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.validationErrorBox = new zaitun.GUI.DecimalTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.validationSetRatioLabel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.useAdvanceCheck = new System.Windows.Forms.CheckBox();
            this.startButton = new System.Windows.Forms.Button();
            this.viewResultButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.StoppingGroupBox.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.advanceGroupBox.SuspendLayout();
            this.advanceViewGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Neural Network Structure";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.StoppingGroupBox);
            this.groupBox6.Controls.Add(this.withCheckingCycleCheck);
            this.groupBox6.Controls.Add(this.checkingCycleBox);
            this.groupBox6.Location = new System.Drawing.Point(523, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(201, 109);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Stopping Condition";
            // 
            // StoppingGroupBox
            // 
            this.StoppingGroupBox.Controls.Add(this.byMSEChangeBox);
            this.StoppingGroupBox.Controls.Add(this.byMSEValueBox);
            this.StoppingGroupBox.Controls.Add(this.byMSEChangeRadio);
            this.StoppingGroupBox.Controls.Add(this.byMSEValueRadio);
            this.StoppingGroupBox.Location = new System.Drawing.Point(6, 42);
            this.StoppingGroupBox.Name = "StoppingGroupBox";
            this.StoppingGroupBox.Size = new System.Drawing.Size(188, 62);
            this.StoppingGroupBox.TabIndex = 24;
            this.StoppingGroupBox.TabStop = false;
            // 
            // byMSEChangeBox
            // 
            this.byMSEChangeBox.Location = new System.Drawing.Point(129, 37);
            this.byMSEChangeBox.Name = "byMSEChangeBox";
            this.byMSEChangeBox.ReadOnly = true;
            this.byMSEChangeBox.Size = new System.Drawing.Size(51, 20);
            this.byMSEChangeBox.TabIndex = 22;
            this.byMSEChangeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // byMSEValueBox
            // 
            this.byMSEValueBox.Location = new System.Drawing.Point(129, 11);
            this.byMSEValueBox.Name = "byMSEValueBox";
            this.byMSEValueBox.Size = new System.Drawing.Size(51, 20);
            this.byMSEValueBox.TabIndex = 21;
            this.byMSEValueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // byMSEChangeRadio
            // 
            this.byMSEChangeRadio.AutoSize = true;
            this.byMSEChangeRadio.Location = new System.Drawing.Point(16, 39);
            this.byMSEChangeRadio.Name = "byMSEChangeRadio";
            this.byMSEChangeRadio.Size = new System.Drawing.Size(101, 17);
            this.byMSEChangeRadio.TabIndex = 5;
            this.byMSEChangeRadio.Text = "by MSE change";
            this.byMSEChangeRadio.UseVisualStyleBackColor = true;
            this.byMSEChangeRadio.CheckedChanged += new System.EventHandler(this.byMSEChangeRadio_CheckedChanged);
            // 
            // byMSEValueRadio
            // 
            this.byMSEValueRadio.AutoSize = true;
            this.byMSEValueRadio.Checked = true;
            this.byMSEValueRadio.Location = new System.Drawing.Point(16, 11);
            this.byMSEValueRadio.Name = "byMSEValueRadio";
            this.byMSEValueRadio.Size = new System.Drawing.Size(91, 17);
            this.byMSEValueRadio.TabIndex = 4;
            this.byMSEValueRadio.TabStop = true;
            this.byMSEValueRadio.Text = "by MSE value";
            this.byMSEValueRadio.UseVisualStyleBackColor = true;
            this.byMSEValueRadio.CheckedChanged += new System.EventHandler(this.byMSEValueRadio_CheckedChanged);
            // 
            // withCheckingCycleCheck
            // 
            this.withCheckingCycleCheck.AutoSize = true;
            this.withCheckingCycleCheck.Checked = true;
            this.withCheckingCycleCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.withCheckingCycleCheck.Location = new System.Drawing.Point(6, 22);
            this.withCheckingCycleCheck.Name = "withCheckingCycleCheck";
            this.withCheckingCycleCheck.Size = new System.Drawing.Size(122, 17);
            this.withCheckingCycleCheck.TabIndex = 23;
            this.withCheckingCycleCheck.Text = "with Checking Cycle";
            this.withCheckingCycleCheck.UseVisualStyleBackColor = true;
            this.withCheckingCycleCheck.CheckedChanged += new System.EventHandler(this.withCheckingCycleCheck_CheckedChanged);
            // 
            // checkingCycleBox
            // 
            this.checkingCycleBox.Location = new System.Drawing.Point(135, 19);
            this.checkingCycleBox.Name = "checkingCycleBox";
            this.checkingCycleBox.Size = new System.Drawing.Size(52, 20);
            this.checkingCycleBox.TabIndex = 3;
            this.checkingCycleBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.hyperbolicTangentRadio);
            this.groupBox5.Controls.Add(this.bipolarSigmoidRadio);
            this.groupBox5.Controls.Add(this.sigmoidRadio);
            this.groupBox5.Controls.Add(this.semiLinearRadio);
            this.groupBox5.Location = new System.Drawing.Point(352, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(163, 109);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Activation Function";
            // 
            // hyperbolicTangentRadio
            // 
            this.hyperbolicTangentRadio.AutoSize = true;
            this.hyperbolicTangentRadio.Location = new System.Drawing.Point(9, 88);
            this.hyperbolicTangentRadio.Name = "hyperbolicTangentRadio";
            this.hyperbolicTangentRadio.Size = new System.Drawing.Size(118, 17);
            this.hyperbolicTangentRadio.TabIndex = 3;
            this.hyperbolicTangentRadio.Text = "Hyperbolic Tangent";
            this.hyperbolicTangentRadio.UseVisualStyleBackColor = true;
            // 
            // bipolarSigmoidRadio
            // 
            this.bipolarSigmoidRadio.AutoSize = true;
            this.bipolarSigmoidRadio.Checked = true;
            this.bipolarSigmoidRadio.Location = new System.Drawing.Point(9, 65);
            this.bipolarSigmoidRadio.Name = "bipolarSigmoidRadio";
            this.bipolarSigmoidRadio.Size = new System.Drawing.Size(97, 17);
            this.bipolarSigmoidRadio.TabIndex = 2;
            this.bipolarSigmoidRadio.TabStop = true;
            this.bipolarSigmoidRadio.Text = "Bipolar Sigmoid";
            this.bipolarSigmoidRadio.UseVisualStyleBackColor = true;
            // 
            // sigmoidRadio
            // 
            this.sigmoidRadio.AutoSize = true;
            this.sigmoidRadio.Location = new System.Drawing.Point(9, 42);
            this.sigmoidRadio.Name = "sigmoidRadio";
            this.sigmoidRadio.Size = new System.Drawing.Size(62, 17);
            this.sigmoidRadio.TabIndex = 1;
            this.sigmoidRadio.Text = "Sigmoid";
            this.sigmoidRadio.UseVisualStyleBackColor = true;
            // 
            // semiLinearRadio
            // 
            this.semiLinearRadio.AutoSize = true;
            this.semiLinearRadio.Location = new System.Drawing.Point(9, 19);
            this.semiLinearRadio.Name = "semiLinearRadio";
            this.semiLinearRadio.Size = new System.Drawing.Size(80, 17);
            this.semiLinearRadio.TabIndex = 0;
            this.semiLinearRadio.Text = "Semi Linear";
            this.semiLinearRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.learningRateBox);
            this.groupBox4.Controls.Add(this.momentumBox);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.maxIterationBox);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(183, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(161, 109);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Learning";
            // 
            // learningRateBox
            // 
            this.learningRateBox.Location = new System.Drawing.Point(98, 18);
            this.learningRateBox.Name = "learningRateBox";
            this.learningRateBox.Size = new System.Drawing.Size(51, 20);
            this.learningRateBox.TabIndex = 20;
            this.learningRateBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // momentumBox
            // 
            this.momentumBox.Location = new System.Drawing.Point(98, 44);
            this.momentumBox.Name = "momentumBox";
            this.momentumBox.Size = new System.Drawing.Size(51, 20);
            this.momentumBox.TabIndex = 19;
            this.momentumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(9, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(141, 2);
            this.label12.TabIndex = 18;
            // 
            // maxIterationBox
            // 
            this.maxIterationBox.Location = new System.Drawing.Point(98, 78);
            this.maxIterationBox.Name = "maxIterationBox";
            this.maxIterationBox.Size = new System.Drawing.Size(52, 20);
            this.maxIterationBox.TabIndex = 7;
            this.maxIterationBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Max Iteration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Momentum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Learning Rate";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.outputLayerBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.hiddenLayerBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.inputLayerBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(14, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(161, 109);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Neurons Count";
            // 
            // outputLayerBox
            // 
            this.outputLayerBox.Location = new System.Drawing.Point(96, 75);
            this.outputLayerBox.Name = "outputLayerBox";
            this.outputLayerBox.ReadOnly = true;
            this.outputLayerBox.Size = new System.Drawing.Size(52, 20);
            this.outputLayerBox.TabIndex = 5;
            this.outputLayerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Output Layer";
            // 
            // hiddenLayerBox
            // 
            this.hiddenLayerBox.Location = new System.Drawing.Point(96, 49);
            this.hiddenLayerBox.Name = "hiddenLayerBox";
            this.hiddenLayerBox.Size = new System.Drawing.Size(52, 20);
            this.hiddenLayerBox.TabIndex = 3;
            this.hiddenLayerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hidden Layer";
            // 
            // inputLayerBox
            // 
            this.inputLayerBox.Location = new System.Drawing.Point(96, 23);
            this.inputLayerBox.Name = "inputLayerBox";
            this.inputLayerBox.Size = new System.Drawing.Size(52, 20);
            this.inputLayerBox.TabIndex = 1;
            this.inputLayerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Layer";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.seriesGraph);
            this.groupBox3.Controls.Add(this.validationSetLabel);
            this.groupBox3.Controls.Add(this.validationSetLine);
            this.groupBox3.Controls.Add(this.observationLabel);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(13, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(741, 315);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Graph";
            // 
            // seriesGraph
            // 
            this.seriesGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seriesGraph.Location = new System.Drawing.Point(6, 20);
            this.seriesGraph.Name = "seriesGraph";
            this.seriesGraph.Size = new System.Drawing.Size(728, 272);
            this.seriesGraph.TabIndex = 26;
            // 
            // validationSetLabel
            // 
            this.validationSetLabel.AutoSize = true;
            this.validationSetLabel.Location = new System.Drawing.Point(371, 296);
            this.validationSetLabel.Name = "validationSetLabel";
            this.validationSetLabel.Size = new System.Drawing.Size(120, 13);
            this.validationSetLabel.TabIndex = 25;
            this.validationSetLabel.Text = "Predicted Validation Set";
            // 
            // validationSetLine
            // 
            this.validationSetLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.validationSetLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.validationSetLine.Location = new System.Drawing.Point(315, 300);
            this.validationSetLine.Name = "validationSetLine";
            this.validationSetLine.Size = new System.Drawing.Size(50, 2);
            this.validationSetLine.TabIndex = 24;
            // 
            // observationLabel
            // 
            this.observationLabel.Location = new System.Drawing.Point(529, 296);
            this.observationLabel.Name = "observationLabel";
            this.observationLabel.Size = new System.Drawing.Size(197, 16);
            this.observationLabel.TabIndex = 23;
            this.observationLabel.Text = "Observations: 100";
            this.observationLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(210, 296);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Predicted";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Red;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(154, 300);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 2);
            this.label16.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(68, 296);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Actual";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Blue;
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(12, 300);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 2);
            this.label13.TabIndex = 19;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(680, 601);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 34);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.maeBox);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.errorBox);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.iterationBox);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.mseBox);
            this.groupBox7.Location = new System.Drawing.Point(14, 596);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(472, 39);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Criterion";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(240, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "MAE:";
            // 
            // maeBox
            // 
            this.maeBox.Location = new System.Drawing.Point(279, 13);
            this.maeBox.Name = "maeBox";
            this.maeBox.ReadOnly = true;
            this.maeBox.Size = new System.Drawing.Size(64, 20);
            this.maeBox.TabIndex = 6;
            this.maeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(130, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Error:";
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(167, 13);
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(64, 20);
            this.errorBox.TabIndex = 4;
            this.errorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Iteration:";
            // 
            // iterationBox
            // 
            this.iterationBox.Location = new System.Drawing.Point(60, 13);
            this.iterationBox.Name = "iterationBox";
            this.iterationBox.ReadOnly = true;
            this.iterationBox.Size = new System.Drawing.Size(64, 20);
            this.iterationBox.TabIndex = 2;
            this.iterationBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "MSE:";
            // 
            // mseBox
            // 
            this.mseBox.Location = new System.Drawing.Point(390, 13);
            this.mseBox.Name = "mseBox";
            this.mseBox.ReadOnly = true;
            this.mseBox.Size = new System.Drawing.Size(64, 20);
            this.mseBox.TabIndex = 0;
            this.mseBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.advanceGroupBox);
            this.groupBox8.Controls.Add(this.validationSetRatioBox);
            this.groupBox8.Controls.Add(this.advanceViewGroupBox);
            this.groupBox8.Controls.Add(this.validationSetRatioLabel);
            this.groupBox8.Controls.Add(this.label21);
            this.groupBox8.Controls.Add(this.useAdvanceCheck);
            this.groupBox8.Location = new System.Drawing.Point(13, 200);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(741, 74);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Cross-Validation Early Stopping";
            // 
            // advanceGroupBox
            // 
            this.advanceGroupBox.Controls.Add(this.PQRadio);
            this.advanceGroupBox.Controls.Add(this.generalizationLossRadio);
            this.advanceGroupBox.Controls.Add(this.stripBox);
            this.advanceGroupBox.Controls.Add(this.generalizationLossTresholdBox);
            this.advanceGroupBox.Controls.Add(this.label23);
            this.advanceGroupBox.Controls.Add(this.PQTresholdBox);
            this.advanceGroupBox.Location = new System.Drawing.Point(178, 8);
            this.advanceGroupBox.Name = "advanceGroupBox";
            this.advanceGroupBox.Size = new System.Drawing.Size(227, 63);
            this.advanceGroupBox.TabIndex = 32;
            this.advanceGroupBox.TabStop = false;
            this.advanceGroupBox.Visible = false;
            // 
            // PQRadio
            // 
            this.PQRadio.AutoSize = true;
            this.PQRadio.Location = new System.Drawing.Point(6, 41);
            this.PQRadio.Name = "PQRadio";
            this.PQRadio.Size = new System.Drawing.Size(84, 17);
            this.PQRadio.TabIndex = 38;
            this.PQRadio.Text = "PQ Treshold";
            this.PQRadio.UseVisualStyleBackColor = true;
            this.PQRadio.CheckedChanged += new System.EventHandler(this.PQRadio_CheckedChanged);
            // 
            // generalizationLossRadio
            // 
            this.generalizationLossRadio.AutoSize = true;
            this.generalizationLossRadio.Checked = true;
            this.generalizationLossRadio.Location = new System.Drawing.Point(6, 14);
            this.generalizationLossRadio.Name = "generalizationLossRadio";
            this.generalizationLossRadio.Size = new System.Drawing.Size(161, 17);
            this.generalizationLossRadio.TabIndex = 37;
            this.generalizationLossRadio.TabStop = true;
            this.generalizationLossRadio.Text = "Generalization Loss Treshold";
            this.generalizationLossRadio.UseVisualStyleBackColor = true;
            this.generalizationLossRadio.CheckedChanged += new System.EventHandler(this.generalizationLossRadio_CheckedChanged);
            // 
            // stripBox
            // 
            this.stripBox.Location = new System.Drawing.Point(183, 41);
            this.stripBox.Name = "stripBox";
            this.stripBox.ReadOnly = true;
            this.stripBox.Size = new System.Drawing.Size(38, 20);
            this.stripBox.TabIndex = 36;
            this.stripBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // generalizationLossTresholdBox
            // 
            this.generalizationLossTresholdBox.Location = new System.Drawing.Point(170, 13);
            this.generalizationLossTresholdBox.Name = "generalizationLossTresholdBox";
            this.generalizationLossTresholdBox.Size = new System.Drawing.Size(51, 20);
            this.generalizationLossTresholdBox.TabIndex = 21;
            this.generalizationLossTresholdBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(149, 44);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(28, 13);
            this.label23.TabIndex = 35;
            this.label23.Text = "Strip";
            // 
            // PQTresholdBox
            // 
            this.PQTresholdBox.Location = new System.Drawing.Point(92, 41);
            this.PQTresholdBox.Name = "PQTresholdBox";
            this.PQTresholdBox.ReadOnly = true;
            this.PQTresholdBox.Size = new System.Drawing.Size(51, 20);
            this.PQTresholdBox.TabIndex = 34;
            this.PQTresholdBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // validationSetRatioBox
            // 
            this.validationSetRatioBox.Location = new System.Drawing.Point(121, 47);
            this.validationSetRatioBox.Name = "validationSetRatioBox";
            this.validationSetRatioBox.Size = new System.Drawing.Size(51, 20);
            this.validationSetRatioBox.TabIndex = 21;
            this.validationSetRatioBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.validationSetRatioBox.Visible = false;
            // 
            // advanceViewGroupBox
            // 
            this.advanceViewGroupBox.Controls.Add(this.pqBox);
            this.advanceViewGroupBox.Controls.Add(this.label24);
            this.advanceViewGroupBox.Controls.Add(this.generalizationLossBox);
            this.advanceViewGroupBox.Controls.Add(this.label20);
            this.advanceViewGroupBox.Controls.Add(this.learningErrorBox);
            this.advanceViewGroupBox.Controls.Add(this.label19);
            this.advanceViewGroupBox.Controls.Add(this.validationErrorBox);
            this.advanceViewGroupBox.Controls.Add(this.label18);
            this.advanceViewGroupBox.Location = new System.Drawing.Point(412, 8);
            this.advanceViewGroupBox.Name = "advanceViewGroupBox";
            this.advanceViewGroupBox.Size = new System.Drawing.Size(323, 63);
            this.advanceViewGroupBox.TabIndex = 31;
            this.advanceViewGroupBox.TabStop = false;
            this.advanceViewGroupBox.Visible = false;
            // 
            // pqBox
            // 
            this.pqBox.Location = new System.Drawing.Point(266, 36);
            this.pqBox.Name = "pqBox";
            this.pqBox.ReadOnly = true;
            this.pqBox.Size = new System.Drawing.Size(51, 20);
            this.pqBox.TabIndex = 30;
            this.pqBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(238, 39);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(22, 13);
            this.label24.TabIndex = 29;
            this.label24.Text = "PQ";
            // 
            // generalizationLossBox
            // 
            this.generalizationLossBox.Location = new System.Drawing.Point(266, 10);
            this.generalizationLossBox.Name = "generalizationLossBox";
            this.generalizationLossBox.ReadOnly = true;
            this.generalizationLossBox.Size = new System.Drawing.Size(51, 20);
            this.generalizationLossBox.TabIndex = 28;
            this.generalizationLossBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(161, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 13);
            this.label20.TabIndex = 27;
            this.label20.Text = "Generalization Loss";
            // 
            // learningErrorBox
            // 
            this.learningErrorBox.Location = new System.Drawing.Point(95, 10);
            this.learningErrorBox.Name = "learningErrorBox";
            this.learningErrorBox.ReadOnly = true;
            this.learningErrorBox.Size = new System.Drawing.Size(51, 20);
            this.learningErrorBox.TabIndex = 26;
            this.learningErrorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 39);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(78, 13);
            this.label19.TabIndex = 25;
            this.label19.Text = "Validation Error";
            // 
            // validationErrorBox
            // 
            this.validationErrorBox.Location = new System.Drawing.Point(95, 36);
            this.validationErrorBox.Name = "validationErrorBox";
            this.validationErrorBox.ReadOnly = true;
            this.validationErrorBox.Size = new System.Drawing.Size(51, 20);
            this.validationErrorBox.TabIndex = 24;
            this.validationErrorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 13);
            this.label18.TabIndex = 23;
            this.label18.Text = "Learning Error";
            // 
            // validationSetRatioLabel
            // 
            this.validationSetRatioLabel.AutoSize = true;
            this.validationSetRatioLabel.Location = new System.Drawing.Point(15, 50);
            this.validationSetRatioLabel.Name = "validationSetRatioLabel";
            this.validationSetRatioLabel.Size = new System.Drawing.Size(100, 13);
            this.validationSetRatioLabel.TabIndex = 0;
            this.validationSetRatioLabel.Text = "Validation Set Ratio";
            this.validationSetRatioLabel.Visible = false;
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label21.Location = new System.Drawing.Point(408, 11);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(2, 60);
            this.label21.TabIndex = 30;
            // 
            // useAdvanceCheck
            // 
            this.useAdvanceCheck.AutoSize = true;
            this.useAdvanceCheck.Location = new System.Drawing.Point(10, 21);
            this.useAdvanceCheck.Name = "useAdvanceCheck";
            this.useAdvanceCheck.Size = new System.Drawing.Size(168, 17);
            this.useAdvanceCheck.TabIndex = 29;
            this.useAdvanceCheck.Text = "Use Cross-Validation Stopping";
            this.useAdvanceCheck.UseVisualStyleBackColor = true;
            this.useAdvanceCheck.CheckedChanged += new System.EventHandler(this.useAdvanceCheck_CheckedChanged);
            // 
            // startButton
            // 
            this.startButton.Image = global::zaitun.Properties.Resources.run;
            this.startButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startButton.Location = new System.Drawing.Point(493, 601);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(78, 34);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // viewResultButton
            // 
            this.viewResultButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.viewResultButton.Image = global::zaitun.Properties.Resources.result;
            this.viewResultButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewResultButton.Location = new System.Drawing.Point(577, 601);
            this.viewResultButton.Name = "viewResultButton";
            this.viewResultButton.Size = new System.Drawing.Size(97, 34);
            this.viewResultButton.TabIndex = 4;
            this.viewResultButton.Text = "View Result";
            this.viewResultButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.viewResultButton.UseVisualStyleBackColor = true;
            this.viewResultButton.Click += new System.EventHandler(this.viewResultButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 48);
            this.panel1.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(269, 25);
            this.label10.TabIndex = 0;
            this.label10.Text = "Neural Network Analysis";
            // 
            // NeuralNetworkAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 644);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.viewResultButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "NeuralNetworkAnalysisForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Neural Network Analysis Form : ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NeuralNetworkAnalysisForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.StoppingGroupBox.ResumeLayout(false);
            this.StoppingGroupBox.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.advanceGroupBox.ResumeLayout(false);
            this.advanceGroupBox.PerformLayout();
            this.advanceViewGroupBox.ResumeLayout(false);
            this.advanceViewGroupBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button viewResultButton;
        private System.Windows.Forms.Label label1;
        private NumericTextBox inputLayerBox;
        private NumericTextBox outputLayerBox;
        private System.Windows.Forms.Label label3;
        private NumericTextBox hiddenLayerBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton hyperbolicTangentRadio;
        private System.Windows.Forms.RadioButton bipolarSigmoidRadio;
        private System.Windows.Forms.RadioButton sigmoidRadio;
        private System.Windows.Forms.RadioButton semiLinearRadio;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox mseBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox iterationBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox errorBox;
        private NumericTextBox checkingCycleBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox maeBox;
        private System.Windows.Forms.RadioButton byMSEChangeRadio;
        private System.Windows.Forms.RadioButton byMSEValueRadio;
        private NumericTextBox maxIterationBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private zaitun.GUI.DecimalTextBox learningRateBox;
        private zaitun.GUI.DecimalTextBox momentumBox;
        private zaitun.GUI.DecimalTextBox byMSEChangeBox;
        private zaitun.GUI.DecimalTextBox byMSEValueBox;
        private System.Windows.Forms.CheckBox withCheckingCycleCheck;
        private System.Windows.Forms.GroupBox StoppingGroupBox;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label validationSetRatioLabel;
        private zaitun.GUI.DecimalTextBox validationSetRatioBox;
        private System.Windows.Forms.Label label18;
        private zaitun.GUI.DecimalTextBox generalizationLossBox;
        private System.Windows.Forms.Label label20;
        private zaitun.GUI.DecimalTextBox learningErrorBox;
        private System.Windows.Forms.Label label19;
        private zaitun.GUI.DecimalTextBox validationErrorBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox useAdvanceCheck;
        private System.Windows.Forms.GroupBox advanceGroupBox;
        private System.Windows.Forms.GroupBox advanceViewGroupBox;
        private zaitun.GUI.DecimalTextBox generalizationLossTresholdBox;
        private NumericTextBox stripBox;
        private System.Windows.Forms.Label label23;
        private zaitun.GUI.DecimalTextBox PQTresholdBox;
        private zaitun.GUI.DecimalTextBox pqBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.RadioButton generalizationLossRadio;
        private System.Windows.Forms.RadioButton PQRadio;
        private System.Windows.Forms.Label observationLabel;
        private System.Windows.Forms.Label validationSetLabel;
        private System.Windows.Forms.Label validationSetLine;
        private GraphLib.PlotterGraphPaneEx seriesGraph;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
    }
}