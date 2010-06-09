namespace zaitun.LinearRegression
{
    partial class LRStorageForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.residualNameBox = new zaitun.GUI.NameTextBox();
            this.predictedNameBox = new zaitun.GUI.NameTextBox();
            this.isStoreResidualCheckBox = new System.Windows.Forms.CheckBox();
            this.isStorePredictedCheckBox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.residualNameBox);
            this.groupBox3.Controls.Add(this.predictedNameBox);
            this.groupBox3.Controls.Add(this.isStoreResidualCheckBox);
            this.groupBox3.Controls.Add(this.isStorePredictedCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 146);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Linear Regression Storage Options";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LimeGreen;
            this.panel2.Location = new System.Drawing.Point(0, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 25);
            this.panel2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LimeGreen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LimeGreen;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Variable Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LimeGreen;
            this.panel1.Location = new System.Drawing.Point(0, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 30);
            this.panel1.TabIndex = 10;
            // 
            // residualNameBox
            // 
            this.residualNameBox.Enabled = false;
            this.residualNameBox.Location = new System.Drawing.Point(109, 81);
            this.residualNameBox.Name = "residualNameBox";
            this.residualNameBox.Size = new System.Drawing.Size(136, 20);
            this.residualNameBox.TabIndex = 8;
            // 
            // predictedNameBox
            // 
            this.predictedNameBox.Enabled = false;
            this.predictedNameBox.Location = new System.Drawing.Point(109, 55);
            this.predictedNameBox.Name = "predictedNameBox";
            this.predictedNameBox.Size = new System.Drawing.Size(136, 20);
            this.predictedNameBox.TabIndex = 6;
            // 
            // isStoreResidualCheckBox
            // 
            this.isStoreResidualCheckBox.AutoSize = true;
            this.isStoreResidualCheckBox.Location = new System.Drawing.Point(6, 83);
            this.isStoreResidualCheckBox.Name = "isStoreResidualCheckBox";
            this.isStoreResidualCheckBox.Size = new System.Drawing.Size(67, 17);
            this.isStoreResidualCheckBox.TabIndex = 7;
            this.isStoreResidualCheckBox.Text = "Residual";
            this.isStoreResidualCheckBox.UseVisualStyleBackColor = true;
            this.isStoreResidualCheckBox.CheckedChanged += new System.EventHandler(this.isStoreResidualCheckBox_CheckedChanged);
            // 
            // isStorePredictedCheckBox
            // 
            this.isStorePredictedCheckBox.AutoSize = true;
            this.isStorePredictedCheckBox.Location = new System.Drawing.Point(6, 57);
            this.isStorePredictedCheckBox.Name = "isStorePredictedCheckBox";
            this.isStorePredictedCheckBox.Size = new System.Drawing.Size(71, 17);
            this.isStorePredictedCheckBox.TabIndex = 5;
            this.isStorePredictedCheckBox.Text = "Predicted";
            this.isStorePredictedCheckBox.UseVisualStyleBackColor = true;
            this.isStorePredictedCheckBox.CheckedChanged += new System.EventHandler(this.isStorePredictedCheckBox_CheckedChanged);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(344, 74);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(54, 28);
            this.okButton.TabIndex = 26;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(344, 110);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(54, 28);
            this.cancelButton.TabIndex = 27;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(-1, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(424, 48);
            this.panel3.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(293, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Linear Regression Storage";
            // 
            // LRStorageForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(410, 218);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox3);
            this.Name = "LRStorageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Linear Regression Storage Form";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private zaitun.GUI.NameTextBox residualNameBox;
        private zaitun.GUI.NameTextBox predictedNameBox;
        private System.Windows.Forms.CheckBox isStoreResidualCheckBox;
        private System.Windows.Forms.CheckBox isStorePredictedCheckBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
    }
}