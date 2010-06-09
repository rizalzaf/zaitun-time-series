namespace zaitun.GUI
{
    partial class StockListDialog
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.stockListView = new System.Windows.Forms.ListView();
            this.symbolColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.descriptionColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdTextOK = new System.Windows.Forms.Button();
            this.cmdTextCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(380, 449);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(77, 25);
            this.cmdCancel.TabIndex = 19;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(297, 449);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(77, 25);
            this.cmdOK.TabIndex = 18;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // stockListView
            // 
            this.stockListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.symbolColumnHeader,
            this.descriptionColumnHeader});
            this.stockListView.FullRowSelect = true;
            this.stockListView.Location = new System.Drawing.Point(6, 13);
            this.stockListView.MultiSelect = false;
            this.stockListView.Name = "stockListView";
            this.stockListView.Size = new System.Drawing.Size(434, 321);
            this.stockListView.TabIndex = 31;
            this.stockListView.UseCompatibleStateImageBehavior = false;
            this.stockListView.View = System.Windows.Forms.View.Details;
            this.stockListView.SelectedIndexChanged += new System.EventHandler(this.stockListView_SelectedIndexChanged);
            // 
            // symbolColumnHeader
            // 
            this.symbolColumnHeader.Text = "Symbol";
            this.symbolColumnHeader.Width = 77;
            // 
            // descriptionColumnHeader
            // 
            this.descriptionColumnHeader.Text = "Description";
            this.descriptionColumnHeader.Width = 350;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(6, 364);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(40, 20);
            this.cmdAdd.TabIndex = 32;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(46, 364);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(40, 20);
            this.cmdEdit.TabIndex = 33;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(86, 364);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(46, 20);
            this.cmdDelete.TabIndex = 34;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // txtSymbol
            // 
            this.txtSymbol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSymbol.Location = new System.Drawing.Point(6, 338);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(82, 20);
            this.txtSymbol.TabIndex = 35;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(94, 338);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(346, 20);
            this.txtDescription.TabIndex = 36;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdTextOK);
            this.groupBox1.Controls.Add(this.cmdTextCancel);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtSymbol);
            this.groupBox1.Controls.Add(this.stockListView);
            this.groupBox1.Controls.Add(this.cmdDelete);
            this.groupBox1.Controls.Add(this.cmdEdit);
            this.groupBox1.Controls.Add(this.cmdAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 393);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // cmdTextOK
            // 
            this.cmdTextOK.Location = new System.Drawing.Point(348, 364);
            this.cmdTextOK.Name = "cmdTextOK";
            this.cmdTextOK.Size = new System.Drawing.Size(40, 20);
            this.cmdTextOK.TabIndex = 37;
            this.cmdTextOK.Text = "OK";
            this.cmdTextOK.UseVisualStyleBackColor = true;
            this.cmdTextOK.Click += new System.EventHandler(this.cmdTextOK_Click);
            // 
            // cmdTextCancel
            // 
            this.cmdTextCancel.Location = new System.Drawing.Point(389, 364);
            this.cmdTextCancel.Name = "cmdTextCancel";
            this.cmdTextCancel.Size = new System.Drawing.Size(50, 20);
            this.cmdTextCancel.TabIndex = 38;
            this.cmdTextCancel.Text = "Cancel";
            this.cmdTextCancel.UseVisualStyleBackColor = true;
            this.cmdTextCancel.Click += new System.EventHandler(this.cmdTextCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 48);
            this.panel1.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Stock List";
            // 
            // StockListDialog
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(463, 483);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdCancel);
            this.Name = "StockListDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock List";
            this.Load += new System.EventHandler(this.StockListDialog_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockListDialog_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView stockListView;
        private System.Windows.Forms.ColumnHeader symbolColumnHeader;
        private System.Windows.Forms.ColumnHeader descriptionColumnHeader;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdTextOK;
        private System.Windows.Forms.Button cmdTextCancel;
    }
}