namespace zaitun.GUI
{
    partial class SeriesDataList
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Variable", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Group", System.Windows.Forms.HorizontalAlignment.Left);
            this.lstSeriesData = new System.Windows.Forms.ListView();
            this.NameColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.TypeColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.DescriptionColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lstSeriesData
            // 
            this.lstSeriesData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumnHeader,
            this.TypeColumnHeader,
            this.DescriptionColumnHeader});
            this.lstSeriesData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSeriesData.FullRowSelect = true;
            listViewGroup1.Header = "Variable";
            listViewGroup1.Name = "VariableListViewGroup";
            listViewGroup2.Header = "Group";
            listViewGroup2.Name = "GroupListViewGroup";
            this.lstSeriesData.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lstSeriesData.HideSelection = false;
            this.lstSeriesData.Location = new System.Drawing.Point(0, 0);
            this.lstSeriesData.MultiSelect = false;
            this.lstSeriesData.Name = "lstSeriesData";
            this.lstSeriesData.ShowGroups = false;
            this.lstSeriesData.Size = new System.Drawing.Size(527, 217);
            this.lstSeriesData.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstSeriesData.TabIndex = 0;
            this.lstSeriesData.UseCompatibleStateImageBehavior = false;
            this.lstSeriesData.View = System.Windows.Forms.View.Details;
            this.lstSeriesData.DoubleClick += new System.EventHandler(this.lstSeriesData_DoubleClick);
            // 
            // NameColumnHeader
            // 
            this.NameColumnHeader.Text = "Name";
            this.NameColumnHeader.Width = 150;
            // 
            // TypeColumnHeader
            // 
            this.TypeColumnHeader.Text = "Type";
            this.TypeColumnHeader.Width = 100;
            // 
            // DescriptionColumnHeader
            // 
            this.DescriptionColumnHeader.Text = "Description";
            this.DescriptionColumnHeader.Width = 300;
            // 
            // SeriesDataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstSeriesData);
            this.Name = "SeriesDataList";
            this.Size = new System.Drawing.Size(527, 217);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader NameColumnHeader;
        private System.Windows.Forms.ColumnHeader TypeColumnHeader;
        private System.Windows.Forms.ColumnHeader DescriptionColumnHeader;
        public System.Windows.Forms.ListView lstSeriesData;

    }
}
