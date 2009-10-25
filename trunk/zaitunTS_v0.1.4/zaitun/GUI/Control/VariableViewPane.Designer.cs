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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VariableViewPane));
            this.variableViewCollection = new System.Windows.Forms.TabControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbSelectView = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // variableViewCollection
            // 
            this.variableViewCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variableViewCollection.Location = new System.Drawing.Point(3, 50);
            this.variableViewCollection.Name = "variableViewCollection";
            this.variableViewCollection.SelectedIndex = 0;
            this.variableViewCollection.Size = new System.Drawing.Size(726, 465);
            this.variableViewCollection.TabIndex = 0;
            this.variableViewCollection.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.variableViewCollection_ControlRemoved);
            this.variableViewCollection.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.variableViewCollection_ControlAdded);
            this.variableViewCollection.SelectedIndexChanged += new System.EventHandler(this.variableViewCollection_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::zaitun.Properties.Resources.variable_view;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.cmbSelectView);
            this.panel2.Location = new System.Drawing.Point(224, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(181, 50);
            this.panel2.TabIndex = 13;
            this.panel2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            // 
            // cmbSelectView
            // 
            this.cmbSelectView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectView.FormattingEnabled = true;
            this.cmbSelectView.Location = new System.Drawing.Point(3, 5);
            this.cmbSelectView.Name = "cmbSelectView";
            this.cmbSelectView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbSelectView.Size = new System.Drawing.Size(175, 21);
            this.cmbSelectView.TabIndex = 10;
            this.cmbSelectView.SelectedIndexChanged += new System.EventHandler(this.cmbSelectView_SelectedIndexChanged);
            this.cmbSelectView.MouseEnter += new System.EventHandler(this.cmbSelectView_MouseEnter);
            this.cmbSelectView.MouseLeave += new System.EventHandler(this.cmbSelectView_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.cmdAdd);
            this.panel1.Controls.Add(this.cmdDelete);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 50);
            this.panel1.TabIndex = 12;
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            // 
            // cmdAdd
            // 
            this.cmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAdd.FlatAppearance.BorderSize = 0;
            this.cmdAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.Image = global::zaitun.Properties.Resources.add;
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(3, 5);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(103, 26);
            this.cmdAdd.TabIndex = 8;
            this.cmdAdd.Text = "Add Pane";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            this.cmdAdd.MouseEnter += new System.EventHandler(this.cmdAddPane_Enter);
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdDelete.FlatAppearance.BorderSize = 0;
            this.cmdDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Image = global::zaitun.Properties.Resources.deletePane;
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(112, 5);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(103, 26);
            this.cmdDelete.TabIndex = 9;
            this.cmdDelete.Text = "Remove Pane";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.MouseLeave += new System.EventHandler(this.cmdDelete_MouseLeave);
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            this.cmdDelete.MouseEnter += new System.EventHandler(this.cmdDelete_MouseEnter);
            // 
            // VariableViewPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.variableViewCollection);
            this.Name = "VariableViewPane";
            this.Padding = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.Size = new System.Drawing.Size(732, 518);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl variableViewCollection;
        private System.Windows.Forms.ComboBox cmbSelectView;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
