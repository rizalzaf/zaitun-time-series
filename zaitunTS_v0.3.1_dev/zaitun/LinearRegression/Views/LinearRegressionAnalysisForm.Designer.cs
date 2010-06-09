namespace zaitun.LinearRegression
{
    partial class LinearRegressionAnalysisForm
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
            this.lstVariables = new System.Windows.Forms.ListBox();
            this.btnDependent = new System.Windows.Forms.Button();
            this.btnIndependent = new System.Windows.Forms.Button();
            this.lstDependent = new System.Windows.Forms.ListBox();
            this.lstIndependents = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnResults = new System.Windows.Forms.Button();
            this.btnStorage = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstVariables
            // 
            this.lstVariables.FormattingEnabled = true;
            this.lstVariables.Location = new System.Drawing.Point(8, 19);
            this.lstVariables.Name = "lstVariables";
            this.lstVariables.Size = new System.Drawing.Size(147, 225);
            this.lstVariables.TabIndex = 0;
            this.lstVariables.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstVariables_MouseClick);
            this.lstVariables.SelectedIndexChanged += new System.EventHandler(this.lstVariables_SelectedIndexChanged);
            // 
            // btnDependent
            // 
            this.btnDependent.Location = new System.Drawing.Point(182, 67);
            this.btnDependent.Name = "btnDependent";
            this.btnDependent.Size = new System.Drawing.Size(36, 28);
            this.btnDependent.TabIndex = 2;
            this.btnDependent.Text = ">";
            this.btnDependent.UseVisualStyleBackColor = true;
            this.btnDependent.Click += new System.EventHandler(this.btnDependent_Click);
            // 
            // btnIndependent
            // 
            this.btnIndependent.Location = new System.Drawing.Point(182, 154);
            this.btnIndependent.Name = "btnIndependent";
            this.btnIndependent.Size = new System.Drawing.Size(36, 28);
            this.btnIndependent.TabIndex = 3;
            this.btnIndependent.Text = ">";
            this.btnIndependent.UseVisualStyleBackColor = true;
            this.btnIndependent.Click += new System.EventHandler(this.btnIndependent_Click);
            // 
            // lstDependent
            // 
            this.lstDependent.FormattingEnabled = true;
            this.lstDependent.Location = new System.Drawing.Point(6, 19);
            this.lstDependent.Name = "lstDependent";
            this.lstDependent.Size = new System.Drawing.Size(146, 17);
            this.lstDependent.TabIndex = 5;
            this.lstDependent.SelectedIndexChanged += new System.EventHandler(this.lstDependent_SelectedIndexChanged);
            // 
            // lstIndependents
            // 
            this.lstIndependents.FormattingEnabled = true;
            this.lstIndependents.Location = new System.Drawing.Point(6, 14);
            this.lstIndependents.Name = "lstIndependents";
            this.lstIndependents.Size = new System.Drawing.Size(146, 134);
            this.lstIndependents.TabIndex = 6;
            this.lstIndependents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstIndependents_MouseClick);
            this.lstIndependents.SelectedIndexChanged += new System.EventHandler(this.lstIndependents_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(400, 62);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(54, 28);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(400, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(54, 28);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnResults
            // 
            this.btnResults.Location = new System.Drawing.Point(224, 270);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(73, 28);
            this.btnResults.TabIndex = 12;
            this.btnResults.Text = "&Results...";
            this.btnResults.UseVisualStyleBackColor = true;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // btnStorage
            // 
            this.btnStorage.Location = new System.Drawing.Point(303, 270);
            this.btnStorage.Name = "btnStorage";
            this.btnStorage.Size = new System.Drawing.Size(73, 28);
            this.btnStorage.TabIndex = 13;
            this.btnStorage.Text = "&Storage...";
            this.btnStorage.UseVisualStyleBackColor = true;
            this.btnStorage.Click += new System.EventHandler(this.btnStorage_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(400, 96);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(54, 28);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 48);
            this.panel1.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(300, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Linear Regression Analysis";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstVariables);
            this.groupBox1.Location = new System.Drawing.Point(10, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 250);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of Variables";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstDependent);
            this.groupBox2.Location = new System.Drawing.Point(224, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(161, 50);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dependent";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstIndependents);
            this.groupBox3.Location = new System.Drawing.Point(224, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(161, 154);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Independent(s)";
            // 
            // LinearRegressionAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 313);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStorage);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnIndependent);
            this.Controls.Add(this.btnDependent);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LinearRegressionAnalysisForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Linear Regression Analysis";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstVariables;
        private System.Windows.Forms.Button btnDependent;
        private System.Windows.Forms.Button btnIndependent;
        private System.Windows.Forms.ListBox lstDependent;
        private System.Windows.Forms.ListBox lstIndependents;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnResults;
        private System.Windows.Forms.Button btnStorage;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}