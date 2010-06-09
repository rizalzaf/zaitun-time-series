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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using zaitun.GUI;
using zaitun.Data;
using System.IO;

namespace zaitun.GUI
{
    public partial class StockListDialog : Form
    {

        public StockListDialog()
        {
            InitializeComponent();   
        }

        private enum stateEnum
        {
            add,
            edit
        }

        private stateEnum state;


        public string StockSymbol
        {
            get { return this.txtSymbol.Text; }
        }

        public string StockDescription
        {
            get { return this.txtDescription.Text; }
        }

        private void editText(bool edit)
        {
            this.txtSymbol.ReadOnly = !edit;
            this.txtDescription.ReadOnly = !edit;
            cmdAdd.Enabled = !edit;
            cmdEdit.Enabled = !edit;
            cmdDelete.Enabled = !edit;
            stockListView.Enabled = !edit;
            cmdTextOK.Enabled = edit;
            cmdTextCancel.Enabled = edit;
        }

        private void readStockListFile()
        {
            this.stockListView.Items.Clear();
            //open list file
            if (File.Exists(Application.UserAppDataPath + "\\stocklist.dat"))
            {
                try
                {
                    StreamReader reader = new StreamReader(Application.UserAppDataPath + "\\stocklist.dat");
                    while (!reader.EndOfStream)
                    {
                        try
                        {
                            string str = reader.ReadLine();
                            string[] strArr = str.Split('|');
                            ListViewItem item = new ListViewItem(strArr);
                            this.stockListView.Items.Add(item);
                        }
                        catch
                        {
                            MessageBox.Show("Error reading recent items file");
                        }
                    }

                    reader.Close();
                }
                catch
                {
                    MessageBox.Show("Couldn't create the recent items file");
                }
            }
        }

        private void writeStockListFile()
        {
            try
            {
                if (File.Exists(Application.UserAppDataPath + "\\stocklist.dat"))
                {
                    File.Delete("stocklist.dat");
                }
            }
            catch
            {
                MessageBox.Show("Error accessing the recent items file");
            }

            StreamWriter writer;
            try
            {
                writer = new StreamWriter(Application.UserAppDataPath + "\\stocklist.dat");

                for (int i = 0; i < this.stockListView.Items.Count; i++)
                {
                    writer.WriteLine(this.stockListView.Items[i].Text + "|" + this.stockListView.Items[i].SubItems[1].Text);
                }
                writer.Close();
            }
            catch
            {
                MessageBox.Show("Error writing the recent items file");
            }
           
        }

        
        private void cmdOK_Click(object sender, EventArgs e)
        {
        
        }

        private void StockListDialog_Load(object sender, EventArgs e)
        {
            this.readStockListFile();
            this.editText(false);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            this.editText(true);
            this.txtSymbol.Text = "";
            this.txtDescription.Text = "";
            this.state = stateEnum.add; 
        }

        private void cmdTextCancel_Click(object sender, EventArgs e)
        {
            this.editText(false);
        }

        private void cmdTextOK_Click(object sender, EventArgs e)
        {
            if (this.state == stateEnum.add)
            {
                string[] strItem = new string[2];
                strItem[0] = txtSymbol.Text;
                strItem[1] = txtDescription.Text;

                ListViewItem item = new ListViewItem(strItem);
                stockListView.Items.Add(item);                
            }
            else if (this.state == stateEnum.edit)
            {
                stockListView.SelectedItems[0].Text = txtSymbol.Text;
                stockListView.SelectedItems[0].SubItems[1].Text = txtDescription.Text;
            }
            this.txtSymbol.Text = "";
            this.txtDescription.Text = "";
            this.editText(false);
        }

        private void stockListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stockListView.SelectedItems.Count > 0)
            {
                txtSymbol.Text = stockListView.SelectedItems[0].Text;
                txtDescription.Text = stockListView.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (stockListView.SelectedItems.Count > 0)
            {
                this.editText(true);
                this.state = stateEnum.edit;
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (stockListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete " + stockListView.SelectedItems[0].Text + " from the list?", "Delete stock list", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.stockListView.Items.Remove(this.stockListView.SelectedItems[0]);
                }
            }
        }

        private void StockListDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.writeStockListFile();
        }

    }
}