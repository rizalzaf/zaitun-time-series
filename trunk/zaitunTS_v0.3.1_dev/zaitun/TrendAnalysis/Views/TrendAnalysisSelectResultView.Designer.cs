using zaitun.GUI;
namespace zaitun.TrendAnalysis
{
    partial class TrendAnalysisSelectResultView
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
            this.label1 = new System.Windows.Forms.Label();
            this.forecastingStepTextBox = new zaitun.GUI.NumericTextBox();
            this.forecastedCheckBox = new System.Windows.Forms.CheckBox();
            this.actualPredictedResidualCheckBox = new System.Windows.Forms.CheckBox();
            this.modelSummaryCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.forecastingStepTextBox);
            this.groupBox1.Controls.Add(this.forecastedCheckBox);
            this.groupBox1.Controls.Add(this.actualPredictedResidualCheckBox);
            this.groupBox1.Controls.Add(this.modelSummaryCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tables";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "step";
            // 
            // forecastingStepTextBox
            // 
            this.forecastingStepTextBox.Enabled = false;
            this.forecastingStepTextBox.Location = new System.Drawing.Point(145, 65);
            this.forecastingStepTextBox.Name = "forecastingStepTextBox";
            this.forecastingStepTextBox.Size = new System.Drawing.Size(55, 20);
            this.forecastingStepTextBox.TabIndex = 3;
            this.forecastingStepTextBox.Text = "1";
            this.forecastingStepTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // forecastedCheckBox
            // 
            this.forecastedCheckBox.AutoSize = true;
            this.forecastedCheckBox.Location = new System.Drawing.Point(14, 67);
            this.forecastedCheckBox.Name = "forecastedCheckBox";
            this.forecastedCheckBox.Size = new System.Drawing.Size(79, 17);
            this.forecastedCheckBox.TabIndex = 2;
            this.forecastedCheckBox.Text = "Forecasted";
            this.forecastedCheckBox.UseVisualStyleBackColor = true;
            this.forecastedCheckBox.CheckedChanged += new System.EventHandler(this.forecastedCheckBox_CheckedChanged);
            // 
            // actualPredictedResidualCheckBox
            // 
            this.actualPredictedResidualCheckBox.AutoSize = true;
            this.actualPredictedResidualCheckBox.Checked = true;
            this.actualPredictedResidualCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.actualPredictedResidualCheckBox.Location = new System.Drawing.Point(14, 44);
            this.actualPredictedResidualCheckBox.Name = "actualPredictedResidualCheckBox";
            this.actualPredictedResidualCheckBox.Size = new System.Drawing.Size(172, 17);
            this.actualPredictedResidualCheckBox.TabIndex = 1;
            this.actualPredictedResidualCheckBox.Text = "Actual, Predicted and Residual";
            this.actualPredictedResidualCheckBox.UseVisualStyleBackColor = true;
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
            this.groupBox2.Controls.Add(this.residualVsPredictedCheckBox);
            this.groupBox2.Controls.Add(this.residualVsActualGraphCheckBox);
            this.groupBox2.Controls.Add(this.residualGraphCheckBox);
            this.groupBox2.Controls.Add(this.actualVsPredictedGraphCheckBox);
            this.groupBox2.Controls.Add(this.actualForecastedGraphCheckBox);
            this.groupBox2.Controls.Add(this.actualPredictedGraphCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 96);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Graphics";
            // 
            // residualVsPredictedCheckBox
            // 
            this.residualVsPredictedCheckBox.AutoSize = true;
            this.residualVsPredictedCheckBox.Location = new System.Drawing.Point(192, 67);
            this.residualVsPredictedCheckBox.Name = "residualVsPredictedCheckBox";
            this.residualVsPredictedCheckBox.Size = new System.Drawing.Size(129, 17);
            this.residualVsPredictedCheckBox.TabIndex = 6;
            this.residualVsPredictedCheckBox.Text = "Residual vs Predicted";
            this.residualVsPredictedCheckBox.UseVisualStyleBackColor = true;
            // 
            // residualVsActualGraphCheckBox
            // 
            this.residualVsActualGraphCheckBox.AutoSize = true;
            this.residualVsActualGraphCheckBox.Location = new System.Drawing.Point(192, 44);
            this.residualVsActualGraphCheckBox.Name = "residualVsActualGraphCheckBox";
            this.residualVsActualGraphCheckBox.Size = new System.Drawing.Size(114, 17);
            this.residualVsActualGraphCheckBox.TabIndex = 5;
            this.residualVsActualGraphCheckBox.Text = "Residual vs Actual";
            this.residualVsActualGraphCheckBox.UseVisualStyleBackColor = true;
            // 
            // residualGraphCheckBox
            // 
            this.residualGraphCheckBox.AutoSize = true;
            this.residualGraphCheckBox.Checked = true;
            this.residualGraphCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.residualGraphCheckBox.Location = new System.Drawing.Point(192, 21);
            this.residualGraphCheckBox.Name = "residualGraphCheckBox";
            this.residualGraphCheckBox.Size = new System.Drawing.Size(67, 17);
            this.residualGraphCheckBox.TabIndex = 4;
            this.residualGraphCheckBox.Text = "Residual";
            this.residualGraphCheckBox.UseVisualStyleBackColor = true;
            // 
            // actualVsPredictedGraphCheckBox
            // 
            this.actualVsPredictedGraphCheckBox.AutoSize = true;
            this.actualVsPredictedGraphCheckBox.Location = new System.Drawing.Point(14, 67);
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
            this.actualForecastedGraphCheckBox.Location = new System.Drawing.Point(14, 44);
            this.actualForecastedGraphCheckBox.Name = "actualForecastedGraphCheckBox";
            this.actualForecastedGraphCheckBox.Size = new System.Drawing.Size(133, 17);
            this.actualForecastedGraphCheckBox.TabIndex = 2;
            this.actualForecastedGraphCheckBox.Text = "Actual and Forecasted";
            this.actualForecastedGraphCheckBox.UseVisualStyleBackColor = true;
            // 
            // actualPredictedGraphCheckBox
            // 
            this.actualPredictedGraphCheckBox.AutoSize = true;
            this.actualPredictedGraphCheckBox.Checked = true;
            this.actualPredictedGraphCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.cmdOK.Location = new System.Drawing.Point(262, 65);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(79, 30);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(262, 111);
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
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 48);
            this.panel1.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(243, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Trend Analysis Result";
            // 
            // TrendAnalysisSelectResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TrendAnalysisSelectResultView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trend Analysis Result";
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
        private System.Windows.Forms.CheckBox actualPredictedResidualCheckBox;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
    }
}