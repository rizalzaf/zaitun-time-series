// Zaitun Time Series 
// http://www.zaitunsoftware.com/
// http://code.google.com/p/zaitun-time-series/
//
// Copyright ©  2008-2009, Zaitun Time Series Developer Team and individual contributors
//
// Leader: Rizal Zaini Ahmad Fathony (rizalzaf@gmail.com)
// Members: Suryono Hadi Wibowo (ryonoha@gmail.com), Khaerul Anas (anasikova@gmail.com), 
//          Lia Amelia (afifahlia@gmail.com), Almaratul Sholihah, Muhamad Fuad Hasan
//
// This is free software; you can redistribute it and/or modify it
// under the terms of the GNU General Public License as
// published by the Free Software Foundation; either version 3 of
// the License, or (at your option) any later version.
//
// This software is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// General Public License for more details.
//
// You should have received a copy of the GNU General Public
// License along with this software; if not, write to the Free
// Software Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
// 02110-1301 USA, or see the FSF site: http://www.fsf.org.

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zaitun.GUI
{
    public class GridMenuStrip : ContextMenuStrip
    {
        public GridMenuStrip() : base() { this.initialize(); }
        public GridMenuStrip(System.ComponentModel.IContainer container) : base(container) { this.initialize(); }

        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyWithHeaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;

        private void initialize()
        {
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyWithHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // mnuGrid
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.copyWithHeaderToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator1,
            this.selectAllToolStripMenuItem});
            this.Name = "mnuGrid";
            this.Size = new System.Drawing.Size(157, 98);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Enabled = false;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            //this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Image = global::zaitun.Properties.Resources.cut;
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            //this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            this.copyToolStripMenuItem.Image = global::zaitun.Properties.Resources.copy;
            // 
            // copyWithHeaderToolStripMenuItem
            // 
            this.copyWithHeaderToolStripMenuItem.Name = "copyToolStripMenuItem";
            //this.copyWithHeaderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.copyWithHeaderToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.copyWithHeaderToolStripMenuItem.Text = "Copy With Headers";
            this.copyWithHeaderToolStripMenuItem.Click += new EventHandler(copyWithHeaderToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            //this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Image = global::zaitun.Properties.Resources.paste;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            //this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
        }

        void copyWithHeaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGrid = (DataGridView)this.SourceControl;

            StringBuilder sb = new StringBuilder();

            int firstRowIndex = dataGrid.RowCount;
            int lastRowIndex = 0;
            int firstColIndex = dataGrid.ColumnCount;
            int lastColIndex = 0;
            for (int i = 0; i < dataGrid.SelectedCells.Count; i++)
            {
                if (dataGrid.SelectedCells[i].RowIndex < firstRowIndex) firstRowIndex = dataGrid.SelectedCells[i].RowIndex;
                if (dataGrid.SelectedCells[i].RowIndex > lastRowIndex) lastRowIndex = dataGrid.SelectedCells[i].RowIndex;

                if (dataGrid.SelectedCells[i].ColumnIndex < firstColIndex) firstColIndex = dataGrid.SelectedCells[i].ColumnIndex;
                if (dataGrid.SelectedCells[i].ColumnIndex > lastColIndex) lastColIndex = dataGrid.SelectedCells[i].ColumnIndex;
            }

            sb.Append("\t");
            for (int j = firstColIndex; j <= lastColIndex; j++)
            {
                try { sb.Append(dataGrid.Columns[j].HeaderText); }
                catch (NullReferenceException) { }
                if (j != lastColIndex) sb.Append("\t");
                else sb.Append("\r\n");
            }

            for (int i = firstRowIndex; i <= lastRowIndex; i++)
            {
                try { sb.Append(dataGrid.Rows[i].HeaderCell.Value.ToString()); }
                catch (NullReferenceException) { }
                sb.Append("\t");
                for (int j = firstColIndex; j <= lastColIndex; j++)
                {
                    try { sb.Append(dataGrid[j, i].Value.ToString()); }
                    catch (NullReferenceException) { }
                    if (j != lastColIndex) sb.Append("\t");                
                }
                if (i != lastRowIndex) sb.Append("\r\n");
            }

            Clipboard.SetDataObject(sb.ToString(), true);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGrid = (DataGridView)this.SourceControl;

            StringBuilder sb = new StringBuilder();

            int firstRowIndex = dataGrid.RowCount;
            int lastRowIndex = 0;
            int firstColIndex = dataGrid.ColumnCount;
            int lastColIndex = 0;
            for (int i = 0; i < dataGrid.SelectedCells.Count; i++)
            {
                if (dataGrid.SelectedCells[i].RowIndex < firstRowIndex) firstRowIndex = dataGrid.SelectedCells[i].RowIndex;
                if (dataGrid.SelectedCells[i].RowIndex > lastRowIndex) lastRowIndex = dataGrid.SelectedCells[i].RowIndex;

                if (dataGrid.SelectedCells[i].ColumnIndex < firstColIndex) firstColIndex = dataGrid.SelectedCells[i].ColumnIndex;
                if (dataGrid.SelectedCells[i].ColumnIndex > lastColIndex) lastColIndex = dataGrid.SelectedCells[i].ColumnIndex;
            }

            for (int i = firstRowIndex; i <= lastRowIndex; i++)
            {
                for (int j = firstColIndex; j <= lastColIndex; j++)
                {
                    if (dataGrid[j, i].Selected)
                    {
                        try { sb.Append(dataGrid[j, i].Value.ToString()); }
                        catch (NullReferenceException) { }
                        if (j != lastColIndex) sb.Append("\t");
                    }
                }
                if (i != lastRowIndex) sb.Append("\r\n");
            }

            Clipboard.SetDataObject(sb.ToString(), true);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataGridView dataGrid = (DataGridView)this.SourceControl;
            dataGrid.SelectAll();
        }
    }
}
