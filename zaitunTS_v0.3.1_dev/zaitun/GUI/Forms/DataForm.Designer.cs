namespace zaitun.GUI
{
    partial class DataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataForm));
            this.tabControlData = new System.Windows.Forms.TabControl();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.cmdAddStock = new System.Windows.Forms.Button();
            this.cmdImportStock = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdDuplicate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdAddVariable = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdAddGroup = new System.Windows.Forms.Button();
            this.endPeriodeLabel = new System.Windows.Forms.Label();
            this.pbProjectMenu = new System.Windows.Forms.PictureBox();
            this.seriesDataList = new zaitun.GUI.SeriesDataList();
            this.startPeriodeLabel = new System.Windows.Forms.Label();
            this.pbVariableOption = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.observationLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.pbProjectInformation = new System.Windows.Forms.PictureBox();
            this.tabPageVariable = new System.Windows.Forms.TabPage();
            this.variableViewPane = new zaitun.GUI.VariableViewPane();
            this.tabPageResult = new System.Windows.Forms.TabPage();
            this.tabControlResult = new FarsiLibrary.Win.FATabStrip();
            this.faTabStripItem1 = new FarsiLibrary.Win.FATabStripItem();
            this.tabControlData.SuspendLayout();
            this.tabPageData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProjectMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVariableOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProjectInformation)).BeginInit();
            this.tabPageVariable.SuspendLayout();
            this.tabPageResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlData
            // 
            this.tabControlData.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlData.Controls.Add(this.tabPageData);
            this.tabControlData.Controls.Add(this.tabPageVariable);
            this.tabControlData.Controls.Add(this.tabPageResult);
            this.tabControlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlData.Location = new System.Drawing.Point(0, 0);
            this.tabControlData.Name = "tabControlData";
            this.tabControlData.SelectedIndex = 0;
            this.tabControlData.Size = new System.Drawing.Size(845, 545);
            this.tabControlData.TabIndex = 1;
            // 
            // tabPageData
            // 
            this.tabPageData.BackColor = System.Drawing.Color.Transparent;
            this.tabPageData.BackgroundImage = global::zaitun.Properties.Resources.bg;
            this.tabPageData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageData.Controls.Add(this.cmdAddStock);
            this.tabPageData.Controls.Add(this.cmdImportStock);
            this.tabPageData.Controls.Add(this.label8);
            this.tabPageData.Controls.Add(this.label5);
            this.tabPageData.Controls.Add(this.label4);
            this.tabPageData.Controls.Add(this.cmdDuplicate);
            this.tabPageData.Controls.Add(this.label6);
            this.tabPageData.Controls.Add(this.cmdDelete);
            this.tabPageData.Controls.Add(this.label3);
            this.tabPageData.Controls.Add(this.cmdAddVariable);
            this.tabPageData.Controls.Add(this.label7);
            this.tabPageData.Controls.Add(this.cmdEdit);
            this.tabPageData.Controls.Add(this.label2);
            this.tabPageData.Controls.Add(this.cmdAddGroup);
            this.tabPageData.Controls.Add(this.endPeriodeLabel);
            this.tabPageData.Controls.Add(this.pbProjectMenu);
            this.tabPageData.Controls.Add(this.seriesDataList);
            this.tabPageData.Controls.Add(this.startPeriodeLabel);
            this.tabPageData.Controls.Add(this.pbVariableOption);
            this.tabPageData.Controls.Add(this.label1);
            this.tabPageData.Controls.Add(this.observationLabel);
            this.tabPageData.Controls.Add(this.nameLabel);
            this.tabPageData.Controls.Add(this.label10);
            this.tabPageData.Controls.Add(this.label9);
            this.tabPageData.Controls.Add(this.frequencyLabel);
            this.tabPageData.Controls.Add(this.pbProjectInformation);
            this.tabPageData.Location = new System.Drawing.Point(4, 4);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3, 140, 3, 3);
            this.tabPageData.Size = new System.Drawing.Size(837, 519);
            this.tabPageData.TabIndex = 0;
            this.tabPageData.Text = "Project View";
            // 
            // cmdAddStock
            // 
            this.cmdAddStock.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAddStock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAddStock.FlatAppearance.BorderSize = 0;
            this.cmdAddStock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAddStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAddStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAddStock.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddStock.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdAddStock.Image = global::zaitun.Properties.Resources.stock;
            this.cmdAddStock.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdAddStock.Location = new System.Drawing.Point(290, 29);
            this.cmdAddStock.Name = "cmdAddStock";
            this.cmdAddStock.Size = new System.Drawing.Size(83, 42);
            this.cmdAddStock.TabIndex = 17;
            this.cmdAddStock.Text = "Add Stock";
            this.cmdAddStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdAddStock.UseVisualStyleBackColor = true;
            this.cmdAddStock.MouseLeave += new System.EventHandler(this.cmdAddStock_Leave);
            this.cmdAddStock.Click += new System.EventHandler(this.cmdAddStock_Click);
            this.cmdAddStock.MouseEnter += new System.EventHandler(this.cmdAddStock_Enter);
            // 
            // cmdImportStock
            // 
            this.cmdImportStock.BackColor = System.Drawing.Color.Transparent;
            this.cmdImportStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdImportStock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdImportStock.FlatAppearance.BorderSize = 0;
            this.cmdImportStock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdImportStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdImportStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdImportStock.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImportStock.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdImportStock.Image = global::zaitun.Properties.Resources.stock_import;
            this.cmdImportStock.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdImportStock.Location = new System.Drawing.Point(290, 73);
            this.cmdImportStock.Name = "cmdImportStock";
            this.cmdImportStock.Size = new System.Drawing.Size(83, 41);
            this.cmdImportStock.TabIndex = 18;
            this.cmdImportStock.Text = "Import Stock";
            this.cmdImportStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdImportStock.UseVisualStyleBackColor = true;
            this.cmdImportStock.MouseLeave += new System.EventHandler(this.cmdImportStock_Leave);
            this.cmdImportStock.Click += new System.EventHandler(this.cmdImportStock_Click);
            this.cmdImportStock.MouseEnter += new System.EventHandler(this.cmdImportStock_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "End Period";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Start Period";
            // 
            // cmdDuplicate
            // 
            this.cmdDuplicate.BackColor = System.Drawing.Color.Transparent;
            this.cmdDuplicate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdDuplicate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdDuplicate.FlatAppearance.BorderSize = 0;
            this.cmdDuplicate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdDuplicate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdDuplicate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDuplicate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDuplicate.Image = global::zaitun.Properties.Resources.copyTo;
            this.cmdDuplicate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDuplicate.Location = new System.Drawing.Point(385, 61);
            this.cmdDuplicate.Name = "cmdDuplicate";
            this.cmdDuplicate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmdDuplicate.Size = new System.Drawing.Size(81, 25);
            this.cmdDuplicate.TabIndex = 9;
            this.cmdDuplicate.Text = "Duplicate";
            this.cmdDuplicate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDuplicate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDuplicate.UseVisualStyleBackColor = false;
            this.cmdDuplicate.MouseLeave += new System.EventHandler(this.cmdDuplicat_Leave);
            this.cmdDuplicate.Click += new System.EventHandler(this.cmdDuplicate_Click);
            this.cmdDuplicate.MouseEnter += new System.EventHandler(this.cmdDuplicate_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = ":";
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
            this.cmdDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Image = global::zaitun.Properties.Resources.deletePane;
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(385, 88);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmdDelete.Size = new System.Drawing.Size(81, 26);
            this.cmdDelete.TabIndex = 7;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.MouseLeave += new System.EventHandler(this.cmdDelete_Leave);
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            this.cmdDelete.MouseEnter += new System.EventHandler(this.cmdDelete_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Observations";
            // 
            // cmdAddVariable
            // 
            this.cmdAddVariable.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddVariable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAddVariable.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAddVariable.FlatAppearance.BorderSize = 0;
            this.cmdAddVariable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAddVariable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAddVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAddVariable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddVariable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdAddVariable.Image = global::zaitun.Properties.Resources.variable;
            this.cmdAddVariable.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdAddVariable.Location = new System.Drawing.Point(204, 29);
            this.cmdAddVariable.Name = "cmdAddVariable";
            this.cmdAddVariable.Size = new System.Drawing.Size(83, 42);
            this.cmdAddVariable.TabIndex = 4;
            this.cmdAddVariable.Text = "Add Variable";
            this.cmdAddVariable.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdAddVariable.UseVisualStyleBackColor = true;
            this.cmdAddVariable.MouseLeave += new System.EventHandler(this.cmdAddVariable_Leave);
            this.cmdAddVariable.Click += new System.EventHandler(this.cmdAddVariable_Click);
            this.cmdAddVariable.MouseEnter += new System.EventHandler(this.cmdAddVariable_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(80, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = ":";
            // 
            // cmdEdit
            // 
            this.cmdEdit.BackColor = System.Drawing.Color.Transparent;
            this.cmdEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdEdit.FlatAppearance.BorderSize = 0;
            this.cmdEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEdit.Image = global::zaitun.Properties.Resources.edit;
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(385, 29);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmdEdit.Size = new System.Drawing.Size(81, 30);
            this.cmdEdit.TabIndex = 6;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = false;
            this.cmdEdit.MouseLeave += new System.EventHandler(this.cmdEdit_Leave);
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            this.cmdEdit.MouseEnter += new System.EventHandler(this.cmdEdit_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Frequency";
            // 
            // cmdAddGroup
            // 
            this.cmdAddGroup.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAddGroup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAddGroup.FlatAppearance.BorderSize = 0;
            this.cmdAddGroup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAddGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.cmdAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAddGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdAddGroup.Image = global::zaitun.Properties.Resources.group;
            this.cmdAddGroup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdAddGroup.Location = new System.Drawing.Point(204, 73);
            this.cmdAddGroup.Name = "cmdAddGroup";
            this.cmdAddGroup.Size = new System.Drawing.Size(83, 41);
            this.cmdAddGroup.TabIndex = 5;
            this.cmdAddGroup.Text = "Add Group";
            this.cmdAddGroup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdAddGroup.UseVisualStyleBackColor = true;
            this.cmdAddGroup.MouseLeave += new System.EventHandler(this.cmdAddGroup_Leave);
            this.cmdAddGroup.Click += new System.EventHandler(this.cmdAddGroup_Click);
            this.cmdAddGroup.MouseEnter += new System.EventHandler(this.cmdAddGroup_Enter);
            // 
            // endPeriodeLabel
            // 
            this.endPeriodeLabel.AutoSize = true;
            this.endPeriodeLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endPeriodeLabel.Location = new System.Drawing.Point(88, 96);
            this.endPeriodeLabel.Name = "endPeriodeLabel";
            this.endPeriodeLabel.Size = new System.Drawing.Size(58, 13);
            this.endPeriodeLabel.TabIndex = 14;
            this.endPeriodeLabel.Text = "End Period";
            // 
            // pbProjectMenu
            // 
            this.pbProjectMenu.BackColor = System.Drawing.Color.Transparent;
            this.pbProjectMenu.BackgroundImage = global::zaitun.Properties.Resources.project_menu31;
            this.pbProjectMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbProjectMenu.Location = new System.Drawing.Point(201, 22);
            this.pbProjectMenu.Name = "pbProjectMenu";
            this.pbProjectMenu.Size = new System.Drawing.Size(178, 114);
            this.pbProjectMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProjectMenu.TabIndex = 15;
            this.pbProjectMenu.TabStop = false;
            this.pbProjectMenu.MouseLeave += new System.EventHandler(this.pbProjectMenuLeave);
            this.pbProjectMenu.MouseEnter += new System.EventHandler(this.pbProjectMenuEnter);
            // 
            // seriesDataList
            // 
            this.seriesDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seriesDataList.Location = new System.Drawing.Point(3, 140);
            this.seriesDataList.Name = "seriesDataList";
            this.seriesDataList.Size = new System.Drawing.Size(831, 376);
            this.seriesDataList.TabIndex = 3;
            this.seriesDataList.DoubleClick += new System.EventHandler(this.seriesDataList1_DoubleClick);
            // 
            // startPeriodeLabel
            // 
            this.startPeriodeLabel.AutoSize = true;
            this.startPeriodeLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startPeriodeLabel.Location = new System.Drawing.Point(88, 79);
            this.startPeriodeLabel.Name = "startPeriodeLabel";
            this.startPeriodeLabel.Size = new System.Drawing.Size(64, 13);
            this.startPeriodeLabel.TabIndex = 13;
            this.startPeriodeLabel.Text = "Start Period";
            // 
            // pbVariableOption
            // 
            this.pbVariableOption.BackColor = System.Drawing.Color.Transparent;
            this.pbVariableOption.BackgroundImage = global::zaitun.Properties.Resources.variable_option21;
            this.pbVariableOption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbVariableOption.Location = new System.Drawing.Point(382, 22);
            this.pbVariableOption.Name = "pbVariableOption";
            this.pbVariableOption.Size = new System.Drawing.Size(91, 114);
            this.pbVariableOption.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVariableOption.TabIndex = 16;
            this.pbVariableOption.TabStop = false;
            this.pbVariableOption.MouseLeave += new System.EventHandler(this.pbVariableOptionLeave);
            this.pbVariableOption.MouseEnter += new System.EventHandler(this.pbVariableOptionEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // observationLabel
            // 
            this.observationLabel.AutoSize = true;
            this.observationLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.observationLabel.Location = new System.Drawing.Point(89, 63);
            this.observationLabel.Name = "observationLabel";
            this.observationLabel.Size = new System.Drawing.Size(71, 13);
            this.observationLabel.TabIndex = 12;
            this.observationLabel.Text = "Observations";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(89, 30);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(34, 13);
            this.nameLabel.TabIndex = 10;
            this.nameLabel.Text = "Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(79, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = ":";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(79, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = ":";
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frequencyLabel.Location = new System.Drawing.Point(89, 47);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(58, 13);
            this.frequencyLabel.TabIndex = 11;
            this.frequencyLabel.Text = "Frequency";
            // 
            // pbProjectInformation
            // 
            this.pbProjectInformation.BackColor = System.Drawing.Color.Transparent;
            this.pbProjectInformation.BackgroundImage = global::zaitun.Properties.Resources.project_information;
            this.pbProjectInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbProjectInformation.Location = new System.Drawing.Point(3, 22);
            this.pbProjectInformation.Name = "pbProjectInformation";
            this.pbProjectInformation.Size = new System.Drawing.Size(195, 114);
            this.pbProjectInformation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProjectInformation.TabIndex = 12;
            this.pbProjectInformation.TabStop = false;
            // 
            // tabPageVariable
            // 
            this.tabPageVariable.Controls.Add(this.variableViewPane);
            this.tabPageVariable.Location = new System.Drawing.Point(4, 4);
            this.tabPageVariable.Name = "tabPageVariable";
            this.tabPageVariable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVariable.Size = new System.Drawing.Size(837, 519);
            this.tabPageVariable.TabIndex = 1;
            this.tabPageVariable.Text = "Variable View";
            this.tabPageVariable.UseVisualStyleBackColor = true;
            // 
            // variableViewPane
            // 
            this.variableViewPane.BackColor = System.Drawing.Color.Transparent;
            this.variableViewPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variableViewPane.Location = new System.Drawing.Point(3, 3);
            this.variableViewPane.Name = "variableViewPane";
            this.variableViewPane.Padding = new System.Windows.Forms.Padding(3);
            this.variableViewPane.Size = new System.Drawing.Size(831, 513);
            this.variableViewPane.TabIndex = 0;
            // 
            // tabPageResult
            // 
            this.tabPageResult.Controls.Add(this.tabControlResult);
            this.tabPageResult.Location = new System.Drawing.Point(4, 4);
            this.tabPageResult.Name = "tabPageResult";
            this.tabPageResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageResult.Size = new System.Drawing.Size(837, 519);
            this.tabPageResult.TabIndex = 2;
            this.tabPageResult.Text = "Result View";
            this.tabPageResult.UseVisualStyleBackColor = true;
            // 
            // tabControlResult
            // 
            this.tabControlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlResult.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tabControlResult.Location = new System.Drawing.Point(3, 3);
            this.tabControlResult.Name = "tabControlResult";
            this.tabControlResult.Size = new System.Drawing.Size(831, 513);
            this.tabControlResult.TabIndex = 0;
            this.tabControlResult.Text = "Result";
            // 
            // faTabStripItem1
            // 
            this.faTabStripItem1.IsDrawn = true;
            this.faTabStripItem1.Name = "faTabStripItem1";
            this.faTabStripItem1.Selected = true;
            this.faTabStripItem1.Size = new System.Drawing.Size(829, 492);
            this.faTabStripItem1.TabIndex = 0;
            this.faTabStripItem1.Title = "TabStrip Page 1";
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(255)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(845, 545);
            this.Controls.Add(this.tabControlData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataForm";
            this.ShowIcon = false;
            this.Text = "Project Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataForm_FormClosing);
            this.tabControlData.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.tabPageData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProjectMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVariableOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProjectInformation)).EndInit();
            this.tabPageVariable.ResumeLayout(false);
            this.tabPageResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlData;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.TabPage tabPageVariable;
        private VariableViewPane variableViewPane;
        private System.Windows.Forms.TabPage tabPageResult;
        private System.Windows.Forms.Button cmdAddGroup;
        private System.Windows.Forms.Button cmdAddVariable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label observationLabel;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label endPeriodeLabel;
        private System.Windows.Forms.Label startPeriodeLabel;
        private FarsiLibrary.Win.FATabStrip tabControlResult;
        private SeriesDataList seriesDataList;
        private System.Windows.Forms.PictureBox pbProjectInformation;
        private System.Windows.Forms.Button cmdDuplicate;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.PictureBox pbProjectMenu;
        private System.Windows.Forms.PictureBox pbVariableOption;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem1;
        private System.Windows.Forms.Button cmdAddStock;
        private System.Windows.Forms.Button cmdImportStock;
    }
}