using zaitun.GUI;
namespace zaitun.MovingAverage
{
    partial class MASelectResultView
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
            this.actualPredictedAndResidualCheckBox = new System.Windows.Forms.CheckBox();
            this.smoothingCheckBox = new System.Windows.Forms.CheckBox();
            this.movingAverageCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.forecastingStepTextBox = new zaitun.GUI.NumericTextBox();
            this.forecastedCheckBox = new System.Windows.Forms.CheckBox();
            this.modelSummaryCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.actualSmoothedGraphCheckBox = new System.Windows.Forms.CheckBox();
            this.residualVsPredictedCheckBox = new System.Windows.Forms.CheckBox();
            this.residualVsActualGraphCheckBox = new System.Windows.Forms.CheckBox();
            this.residualGraphCheckBox = new System.Windows.Forms.CheckBox();
            this.actualVsPredictedGraphCheckBox = new System.Windows.Forms.CheckBox();
            this.actualForecastedGraphCheckBox = new System.Windows.Forms.CheckBox();
            this.actualPredictedGraphCheckBox = new System.Windows.Forms.CheckBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.actualPredictedAndResidualCheckBox);
            this.groupBox1.Controls.Add(this.smoothingCheckBox);
            this.groupBox1.Controls.Add(this.movingAverageCheckBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.forecastingStepTextBox);
            this.groupBox1.Controls.Add(this.forecastedCheckBox);
            this.groupBox1.Controls.Add(this.modelSummaryCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(14, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Table";
            // 
            // actualPredictedAndResidualCheckBox
            // 
            this.actualPredictedAndResidualCheckBox.AutoSize = true;
            this.actualPredictedAndResidualCheckBox.Checked = true;
            this.actualPredictedAndResidualCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.actualPredictedAndResidualCheckBox.Enabled = false;
            this.actualPredictedAndResidualCheckBox.Location = new System.Drawing.Point(39, 90);
            this.actualPredictedAndResidualCheckBox.Name = "actualPredictedAndResidualCheckBox";
            this.actualPredictedAndResidualCheckBox.Size = new System.Drawing.Size(175, 17);
            this.actualPredictedAndResidualCheckBox.TabIndex = 9;
            this.actualPredictedAndResidualCheckBox.Text = "Actual, Predicted, and Residual";
            this.actualPredictedAndResidualCheckBox.UseVisualStyleBackColor = true;
            // 
            // smoothingCheckBox
            // 
            this.smoothingCheckBox.AutoSize = true;
            this.smoothingCheckBox.Location = new System.Drawing.Point(39, 67);
            this.smoothingCheckBox.Name = "smoothingCheckBox";
            this.smoothingCheckBox.Size = new System.Drawing.Size(74, 17);
            this.smoothingCheckBox.TabIndex = 8;
            this.smoothingCheckBox.Text = "Smoothed";
            this.smoothingCheckBox.UseVisualStyleBackColor = true;
            // 
            // movingAverageCheckBox
            // 
            this.movingAverageCheckBox.AutoSize = true;
            this.movingAverageCheckBox.Checked = true;
            this.movingAverageCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.movingAverageCheckBox.Location = new System.Drawing.Point(14, 44);
            this.movingAverageCheckBox.Name = "movingAverageCheckBox";
            this.movingAverageCheckBox.Size = new System.Drawing.Size(134, 17);
            this.movingAverageCheckBox.TabIndex = 5;
            this.movingAverageCheckBox.Text = "Moving Average Table";
            this.movingAverageCheckBox.UseVisualStyleBackColor = true;
            this.movingAverageCheckBox.CheckedChanged += new System.EventHandler(this.movingAverageCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "step";
            // 
            // forecastingStepTextBox
            // 
            this.forecastingStepTextBox.Enabled = false;
            this.forecastingStepTextBox.Location = new System.Drawing.Point(145, 111);
            this.forecastingStepTextBox.Name = "forecastingStepTextBox";
            this.forecastingStepTextBox.Size = new System.Drawing.Size(55, 20);
            this.forecastingStepTextBox.TabIndex = 3;
            this.forecastingStepTextBox.Text = "1";
            this.forecastingStepTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // forecastedCheckBox
            // 
            this.forecastedCheckBox.AutoSize = true;
            this.forecastedCheckBox.Location = new System.Drawing.Point(14, 113);
            this.forecastedCheckBox.Name = "forecastedCheckBox";
            this.forecastedCheckBox.Size = new System.Drawing.Size(79, 17);
            this.forecastedCheckBox.TabIndex = 2;
            this.forecastedCheckBox.Text = "Forecasted";
            this.forecastedCheckBox.UseVisualStyleBackColor = true;
            this.forecastedCheckBox.CheckedChanged += new System.EventHandler(this.forecastedCheckBox_CheckedChanged);
            // 
            // modelSummaryCheckBox
            // 
            this.modelSummaryCheckBox.AutoSize = true;
            this.modelSummaryCheckBox.Checked = true;
            this.modelSummaryCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.modelSummaryCheckBox.Enabled = false;
            this.modelSummaryCheckBox.Location = new System.Drawing.Point(14, 21);
            this.modelSummaryCheckBox.Name = "modelSummaryCheckBox";
            this.modelSummaryCheckBox.Size = new System.Drawing.Size(101, 17);
            this.modelSummaryCheckBox.TabIndex = 0;
            this.modelSummaryCheckBox.Text = "Model Summary";
            this.modelSummaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.actualSmoothedGraphCheckBox);
            this.groupBox2.Controls.Add(this.residualVsPredictedCheckBox);
            this.groupBox2.Controls.Add(this.residualVsActualGraphCheckBox);
            this.groupBox2.Controls.Add(this.residualGraphCheckBox);
            this.groupBox2.Controls.Add(this.actualVsPredictedGraphCheckBox);
            this.groupBox2.Controls.Add(this.actualForecastedGraphCheckBox);
            this.groupBox2.Controls.Add(this.actualPredictedGraphCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(14, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 119);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Graph";
            // 
            // actualSmoothedGraphCheckBox
            // 
            this.actualSmoothedGraphCheckBox.AutoSize = true;
            this.actualSmoothedGraphCheckBox.Location = new System.Drawing.Point(14, 44);
            this.actualSmoothedGraphCheckBox.Name = "actualSmoothedGraphCheckBox";
            this.actualSmoothedGraphCheckBox.Size = new System.Drawing.Size(128, 17);
            this.actualSmoothedGraphCheckBox.TabIndex = 7;
            this.actualSmoothedGraphCheckBox.Text = "Actual and Smoothed";
            this.actualSmoothedGraphCheckBox.UseVisualStyleBackColor = true;
            // 
            // residualVsPredictedCheckBox
            // 
            this.residualVsPredictedCheckBox.AutoSize = true;
            this.residualVsPredictedCheckBox.Location = new System.Drawing.Point(190, 67);
            this.residualVsPredictedCheckBox.Name = "residualVsPredictedCheckBox";
            this.residualVsPredictedCheckBox.Size = new System.Drawing.Size(129, 17);
            this.residualVsPredictedCheckBox.TabIndex = 6;
            this.residualVsPredictedCheckBox.Text = "Residual vs Predicted";
            this.residualVsPredictedCheckBox.UseVisualStyleBackColor = true;
            // 
            // residualVsActualGraphCheckBox
            // 
            this.residualVsActualGraphCheckBox.AutoSize = true;
            this.residualVsActualGraphCheckBox.Location = new System.Drawing.Point(190, 44);
            this.residualVsActualGraphCheckBox.Name = "residualVsActualGraphCheckBox";
            this.residualVsActualGraphCheckBox.Size = new System.Drawing.Size(114, 17);
            this.residualVsActualGraphCheckBox.TabIndex = 5;
            this.residualVsActualGraphCheckBox.Text = "Residual vs Actual";
            this.residualVsActualGraphCheckBox.UseVisualStyleBackColor = true;
            // 
            // residualGraphCheckBox
            // 
            this.residualGraphCheckBox.AutoSize = true;
            this.residualGraphCheckBox.Location = new System.Drawing.Point(190, 21);
            this.residualGraphCheckBox.Name = "residualGraphCheckBox";
            this.residualGraphCheckBox.Size = new System.Drawing.Size(67, 17);
            this.residualGraphCheckBox.TabIndex = 4;
            this.residualGraphCheckBox.Text = "Residual";
            this.residualGraphCheckBox.UseVisualStyleBackColor = true;
            // 
            // actualVsPredictedGraphCheckBox
            // 
            this.actualVsPredictedGraphCheckBox.AutoSize = true;
            this.actualVsPredictedGraphCheckBox.Location = new System.Drawing.Point(14, 90);
            this.actualVsPredictedGraphCheckBox.Name = "actualVsPredictedGraphCheckBox";
            this.actualVsPredictedGraphCheckBox.Size = new System.Drawing.Size(118, 17);
            this.actualVsPredictedGraphCheckBox.TabIndex = 3;
            this.actualVsPredictedGraphCheckBox.Text = "Actual vs Predicted";
            this.actualVsPredictedGraphCheckBox.UseVisualStyleBackColor = true;
            // 
            // actualForecastedGraphCheckBox
            // 
            this.actualForecastedGraphCheckBox.AutoSize = true;
            this.actualForecastedGraphCheckBox.Enabled = false;
            this.actualForecastedGraphCheckBox.Location = new System.Drawing.Point(14, 67);
            this.actualForecastedGraphCheckBox.Name = "actualForecastedGraphCheckBox";
            this.actualForecastedGraphCheckBox.Size = new System.Drawing.Size(133, 17);
            this.actualForecastedGraphCheckBox.TabIndex = 2;
            this.actualForecastedGraphCheckBox.Text = "Actual and Forecasted";
            this.actualForecastedGraphCheckBox.UseVisualStyleBackColor = true;
            // 
            // actualPredictedGraphCheckBox
            // 
            this.actualPredictedGraphCheckBox.AutoSize = true;
            this.actualPredictedGraphCheckBox.Location = new System.Drawing.Point(14, 21);
            this.actualPredictedGraphCheckBox.Name = "actualPredictedGraphCheckBox";
            this.actualPredictedGraphCheckBox.Size = new System.Drawing.Size(125, 17);
            this.actualPredictedGraphCheckBox.TabIndex = 0;
            this.actualPredictedGraphCheckBox.Text = "Actual and Predicted";
            this.actualPredictedGraphCheckBox.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(264, 66);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(79, 30);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(264, 112);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(79, 30);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 48);
            this.panel1.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Moving Average Result";
            // 
            // MASelectResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 341);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MASelectResultView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moving Average Select Result View";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox modelSummaryCheckBox;
        private System.Windows.Forms.CheckBox forecastedCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox actualForecastedGraphCheckBox;
        private System.Windows.Forms.CheckBox actualPredictedGraphCheckBox;
        private System.Windows.Forms.CheckBox residualVsPredictedCheckBox;
        private System.Windows.Forms.CheckBox residualVsActualGraphCheckBox;
        private System.Windows.Forms.CheckBox residualGraphCheckBox;
        private System.Windows.Forms.CheckBox actualVsPredictedGraphCheckBox;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label1;
        private NumericTextBox forecastingStepTextBox;
        private System.Windows.Forms.CheckBox movingAverageCheckBox;
        private System.Windows.Forms.CheckBox smoothingCheckBox;
        private System.Windows.Forms.CheckBox actualPredictedAndResidualCheckBox;
        private System.Windows.Forms.CheckBox actualSmoothedGraphCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
    }
}