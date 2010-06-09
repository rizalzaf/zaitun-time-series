namespace zaitun.GUI
{
    partial class VariableViewPane
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.variableViewCollection = new System.Windows.Forms.TabControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdStatistics = new System.Windows.Forms.Button();
            this.cmdGraphic = new System.Windows.Forms.Button();
            this.cmdSpreadSheet = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // variableViewCollection
            // 
            this.variableViewCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variableViewCollection.Location = new System.Drawing.Point(0, 103);
            this.variableViewCollection.Name = "variableViewCollection";
            this.variableViewCollection.SelectedIndex = 0;
            this.variableViewCollection.Size = new System.Drawing.Size(732, 415);
            this.variableViewCollection.TabIndex = 0;
            this.variableViewCollection.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.variableViewCollection_ControlAdded);
            this.variableViewCollection.Enter += new System.EventHandler(this.variableViewCollection_Enter);
            this.variableViewCollection.SelectedIndexChanged += new System.EventHandler(this.variableViewCollection_SelectedIndexChanged);
            this.variableViewCollection.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.variableViewCollection_ControlRemoved);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.ForestGreen;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(732, 15);
            this.panel5.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::zaitun.Properties.Resources.header_bg_small2;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 15);
            this.panel3.Name = "panel3";
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel3.Size = new System.Drawing.Size(732, 88);
            this.panel3.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.Pane_New;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.cmdAdd);
            this.panel1.Controls.Add(this.cmdDelete);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(154, 82);
            this.panel1.TabIndex = 12;
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            // 
            // cmdAdd
            // 
            this.cmdAdd.BackColor = System.Drawing.Color.Transparent;
            this.cmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAdd.FlatAppearance.BorderSize = 0;
            this.cmdAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAdd.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.Image = global::zaitun.Properties.Resources.ico_alpha_5_24X24;
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdAdd.Location = new System.Drawing.Point(5, 6);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(69, 53);
            this.cmdAdd.TabIndex = 8;
            this.cmdAdd.Text = "Add Pane";
            this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.MouseLeave += new System.EventHandler(this.cmdAddPane_Leave);
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            this.cmdAdd.MouseEnter += new System.EventHandler(this.cmdAddPane_Enter);
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.Color.Transparent;
            this.cmdDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdDelete.FlatAppearance.BorderSize = 0;
            this.cmdDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDelete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Image = global::zaitun.Properties.Resources.ico_alpha_Delete_24x24;
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdDelete.Location = new System.Drawing.Point(79, 6);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(69, 53);
            this.cmdDelete.TabIndex = 9;
            this.cmdDelete.Text = "Remove";
            this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.MouseLeave += new System.EventHandler(this.cmdDelete_MouseLeave);
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            this.cmdDelete.MouseEnter += new System.EventHandler(this.cmdDelete_MouseEnter);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::zaitun.Properties.Resources.Variable_View_New;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.cmdStatistics);
            this.panel2.Controls.Add(this.cmdGraphic);
            this.panel2.Controls.Add(this.cmdSpreadSheet);
            this.panel2.Location = new System.Drawing.Point(160, 4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(233, 82);
            this.panel2.TabIndex = 13;
            this.panel2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            // 
            // cmdStatistics
            // 
            this.cmdStatistics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdStatistics.Enabled = false;
            this.cmdStatistics.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdStatistics.FlatAppearance.BorderSize = 0;
            this.cmdStatistics.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdStatistics.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdStatistics.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStatistics.Image = global::zaitun.Properties.Resources.SIGMA;
            this.cmdStatistics.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdStatistics.Location = new System.Drawing.Point(162, 6);
            this.cmdStatistics.Name = "cmdStatistics";
            this.cmdStatistics.Size = new System.Drawing.Size(66, 53);
            this.cmdStatistics.TabIndex = 12;
            this.cmdStatistics.Text = "Statistics";
            this.cmdStatistics.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdStatistics.UseVisualStyleBackColor = true;
            this.cmdStatistics.MouseLeave += new System.EventHandler(this.cmdStatistics_Leave);
            this.cmdStatistics.Click += new System.EventHandler(this.cmdStatistics_Click);
            this.cmdStatistics.MouseEnter += new System.EventHandler(this.cmdStatistics_Enter);
            // 
            // cmdGraphic
            // 
            this.cmdGraphic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdGraphic.Enabled = false;
            this.cmdGraphic.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdGraphic.FlatAppearance.BorderSize = 0;
            this.cmdGraphic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdGraphic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdGraphic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdGraphic.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGraphic.Image = global::zaitun.Properties.Resources.Ico_alpha_RarelyUsedPrograms_32x32;
            this.cmdGraphic.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdGraphic.Location = new System.Drawing.Point(99, 6);
            this.cmdGraphic.Name = "cmdGraphic";
            this.cmdGraphic.Size = new System.Drawing.Size(58, 53);
            this.cmdGraphic.TabIndex = 11;
            this.cmdGraphic.Text = "Graphic";
            this.cmdGraphic.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdGraphic.UseVisualStyleBackColor = true;
            this.cmdGraphic.MouseLeave += new System.EventHandler(this.cmdGraphic_Leave);
            this.cmdGraphic.Click += new System.EventHandler(this.cmdGraphic_Click);
            this.cmdGraphic.MouseEnter += new System.EventHandler(this.cmdGraphic_Enter);
            // 
            // cmdSpreadSheet
            // 
            this.cmdSpreadSheet.BackColor = System.Drawing.Color.Transparent;
            this.cmdSpreadSheet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdSpreadSheet.Enabled = false;
            this.cmdSpreadSheet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdSpreadSheet.FlatAppearance.BorderSize = 0;
            this.cmdSpreadSheet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdSpreadSheet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdSpreadSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSpreadSheet.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSpreadSheet.Image = global::zaitun.Properties.Resources.ico_alpha_ColumnCheck_32x32;
            this.cmdSpreadSheet.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSpreadSheet.Location = new System.Drawing.Point(4, 6);
            this.cmdSpreadSheet.Name = "cmdSpreadSheet";
            this.cmdSpreadSheet.Size = new System.Drawing.Size(90, 53);
            this.cmdSpreadSheet.TabIndex = 10;
            this.cmdSpreadSheet.Text = "Spreadsheet";
            this.cmdSpreadSheet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSpreadSheet.UseVisualStyleBackColor = true;
            this.cmdSpreadSheet.Click += new System.EventHandler(this.cmdSpreadsheet_Click);
            this.cmdSpreadSheet.MouseEnter += new System.EventHandler(this.cmdSpreadsheet_Enter);
            // 
            // VariableViewPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.variableViewCollection);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Name = "VariableViewPane";
            this.Size = new System.Drawing.Size(732, 518);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl variableViewCollection;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button cmdSpreadSheet;
        private System.Windows.Forms.Button cmdStatistics;
        private System.Windows.Forms.Button cmdGraphic;
    }
}
