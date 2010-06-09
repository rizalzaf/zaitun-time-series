namespace zaitun.LinearRegression
{
    partial class LRSelectResultView
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
            this.chkActualPredictedAndResidual = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.forcastingStepTextBox = new zaitun.GUI.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetValues = new System.Windows.Forms.Button();
            this.chkAnova = new System.Windows.Forms.CheckBox();
            this.chkForcasted = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDurbinWatson = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPartialCorrelation = new System.Windows.Forms.CheckBox();
            this.chkCoefficient = new System.Windows.Forms.CheckBox();
            this.chkVIF = new System.Windows.Forms.CheckBox();
            this.chkConfidenceIntervals = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkResidualVsPredictedGraph = new System.Windows.Forms.CheckBox();
            this.chkNPPForResidual = new System.Windows.Forms.CheckBox();
            this.chkResidualGraph = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkActualPredictedAndResidual
            // 
            this.chkActualPredictedAndResidual.AutoSize = true;
            this.chkActualPredictedAndResidual.Location = new System.Drawing.Point(9, 213);
            this.chkActualPredictedAndResidual.Name = "chkActualPredictedAndResidual";
            this.chkActualPredictedAndResidual.Size = new System.Drawing.Size(172, 17);
            this.chkActualPredictedAndResidual.TabIndex = 2;
            this.chkActualPredictedAndResidual.Text = "Actual, predicted, and residual ";
            this.chkActualPredictedAndResidual.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(268, 72);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(54, 28);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(268, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(54, 28);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 48);
            this.panel1.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(285, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Linear Regression  Result";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.forcastingStepTextBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnSetValues);
            this.groupBox3.Controls.Add(this.chkAnova);
            this.groupBox3.Controls.Add(this.chkForcasted);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.chkActualPredictedAndResidual);
            this.groupBox3.Location = new System.Drawing.Point(12, 54);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 273);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Table";
            // 
            // forcastingStepTextBox
            // 
            this.forcastingStepTextBox.Enabled = false;
            this.forcastingStepTextBox.Location = new System.Drawing.Point(121, 240);
            this.forcastingStepTextBox.Name = "forcastingStepTextBox";
            this.forcastingStepTextBox.Size = new System.Drawing.Size(26, 20);
            this.forcastingStepTextBox.TabIndex = 25;
            this.forcastingStepTextBox.Text = "1";
            this.forcastingStepTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "step";
            // 
            // btnSetValues
            // 
            this.btnSetValues.Enabled = false;
            this.btnSetValues.Location = new System.Drawing.Point(153, 238);
            this.btnSetValues.Name = "btnSetValues";
            this.btnSetValues.Size = new System.Drawing.Size(77, 23);
            this.btnSetValues.TabIndex = 23;
            this.btnSetValues.Text = "Set Values...";
            this.btnSetValues.UseVisualStyleBackColor = true;
            this.btnSetValues.Click += new System.EventHandler(this.btnSetValues_Click);
            // 
            // chkAnova
            // 
            this.chkAnova.AutoSize = true;
            this.chkAnova.Location = new System.Drawing.Point(9, 94);
            this.chkAnova.Name = "chkAnova";
            this.chkAnova.Size = new System.Drawing.Size(63, 17);
            this.chkAnova.TabIndex = 22;
            this.chkAnova.Text = "ANOVA";
            this.chkAnova.UseVisualStyleBackColor = true;
            // 
            // chkForcasted
            // 
            this.chkForcasted.AutoSize = true;
            this.chkForcasted.Location = new System.Drawing.Point(9, 242);
            this.chkForcasted.Name = "chkForcasted";
            this.chkForcasted.Size = new System.Drawing.Size(73, 17);
            this.chkForcasted.TabIndex = 21;
            this.chkForcasted.Text = "Forcasted";
            this.chkForcasted.UseVisualStyleBackColor = true;
            this.chkForcasted.CheckedChanged += new System.EventHandler(this.chkForcasted_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Location = new System.Drawing.Point(6, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(224, 70);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Model Summary";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDurbinWatson);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 43);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Residuals";
            // 
            // chkDurbinWatson
            // 
            this.chkDurbinWatson.AutoSize = true;
            this.chkDurbinWatson.Location = new System.Drawing.Point(9, 19);
            this.chkDurbinWatson.Name = "chkDurbinWatson";
            this.chkDurbinWatson.Size = new System.Drawing.Size(103, 17);
            this.chkDurbinWatson.TabIndex = 0;
            this.chkDurbinWatson.Text = "Durbin - Watson";
            this.chkDurbinWatson.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPartialCorrelation);
            this.groupBox1.Controls.Add(this.chkCoefficient);
            this.groupBox1.Controls.Add(this.chkVIF);
            this.groupBox1.Controls.Add(this.chkConfidenceIntervals);
            this.groupBox1.Location = new System.Drawing.Point(6, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 90);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    Regression Coefficients";
            // 
            // chkPartialCorrelation
            // 
            this.chkPartialCorrelation.AutoSize = true;
            this.chkPartialCorrelation.Location = new System.Drawing.Point(9, 66);
            this.chkPartialCorrelation.Name = "chkPartialCorrelation";
            this.chkPartialCorrelation.Size = new System.Drawing.Size(107, 17);
            this.chkPartialCorrelation.TabIndex = 24;
            this.chkPartialCorrelation.Text = "Partial correlation";
            this.chkPartialCorrelation.UseVisualStyleBackColor = true;
            // 
            // chkCoefficient
            // 
            this.chkCoefficient.AutoSize = true;
            this.chkCoefficient.Location = new System.Drawing.Point(5, 0);
            this.chkCoefficient.Name = "chkCoefficient";
            this.chkCoefficient.Size = new System.Drawing.Size(15, 14);
            this.chkCoefficient.TabIndex = 23;
            this.chkCoefficient.UseVisualStyleBackColor = true;
            this.chkCoefficient.CheckedChanged += new System.EventHandler(this.chkCoefficient_CheckedChanged);
            // 
            // chkVIF
            // 
            this.chkVIF.AutoSize = true;
            this.chkVIF.Location = new System.Drawing.Point(9, 43);
            this.chkVIF.Name = "chkVIF";
            this.chkVIF.Size = new System.Drawing.Size(42, 17);
            this.chkVIF.TabIndex = 2;
            this.chkVIF.Text = "VIF";
            this.chkVIF.UseVisualStyleBackColor = true;
            // 
            // chkConfidenceIntervals
            // 
            this.chkConfidenceIntervals.AutoSize = true;
            this.chkConfidenceIntervals.Location = new System.Drawing.Point(9, 20);
            this.chkConfidenceIntervals.Name = "chkConfidenceIntervals";
            this.chkConfidenceIntervals.Size = new System.Drawing.Size(122, 17);
            this.chkConfidenceIntervals.TabIndex = 1;
            this.chkConfidenceIntervals.Text = "Confidence intervals";
            this.chkConfidenceIntervals.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkResidualVsPredictedGraph);
            this.groupBox4.Controls.Add(this.chkNPPForResidual);
            this.groupBox4.Controls.Add(this.chkResidualGraph);
            this.groupBox4.Location = new System.Drawing.Point(12, 333);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(236, 94);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Graphic";
            // 
            // chkResidualVsPredictedGraph
            // 
            this.chkResidualVsPredictedGraph.AutoSize = true;
            this.chkResidualVsPredictedGraph.Location = new System.Drawing.Point(9, 42);
            this.chkResidualVsPredictedGraph.Name = "chkResidualVsPredictedGraph";
            this.chkResidualVsPredictedGraph.Size = new System.Drawing.Size(158, 17);
            this.chkResidualVsPredictedGraph.TabIndex = 3;
            this.chkResidualVsPredictedGraph.Text = "Residual vs predicted graph";
            this.chkResidualVsPredictedGraph.UseVisualStyleBackColor = true;
            // 
            // chkNPPForResidual
            // 
            this.chkNPPForResidual.AutoSize = true;
            this.chkNPPForResidual.Location = new System.Drawing.Point(9, 65);
            this.chkNPPForResidual.Name = "chkNPPForResidual";
            this.chkNPPForResidual.Size = new System.Drawing.Size(183, 17);
            this.chkNPPForResidual.TabIndex = 2;
            this.chkNPPForResidual.Text = "Normal probability plot for residual";
            this.chkNPPForResidual.UseVisualStyleBackColor = true;
            // 
            // chkResidualGraph
            // 
            this.chkResidualGraph.AutoSize = true;
            this.chkResidualGraph.Location = new System.Drawing.Point(9, 19);
            this.chkResidualGraph.Name = "chkResidualGraph";
            this.chkResidualGraph.Size = new System.Drawing.Size(100, 17);
            this.chkResidualGraph.TabIndex = 4;
            this.chkResidualGraph.Text = "Residual  graph";
            this.chkResidualGraph.UseVisualStyleBackColor = true;
            // 
            // LRSelectResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 440);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LRSelectResultView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Linear Regression Select Result View";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkActualPredictedAndResidual;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkNPPForResidual;
        private System.Windows.Forms.CheckBox chkResidualGraph;
        private System.Windows.Forms.CheckBox chkResidualVsPredictedGraph;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkVIF;
        private System.Windows.Forms.CheckBox chkConfidenceIntervals;
        private System.Windows.Forms.CheckBox chkForcasted;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkDurbinWatson;
        private System.Windows.Forms.CheckBox chkAnova;
        private System.Windows.Forms.CheckBox chkCoefficient;
        private System.Windows.Forms.Button btnSetValues;
        private System.Windows.Forms.CheckBox chkPartialCorrelation;
        private System.Windows.Forms.Label label1;
        private zaitun.GUI.NumericTextBox forcastingStepTextBox;
    }
}