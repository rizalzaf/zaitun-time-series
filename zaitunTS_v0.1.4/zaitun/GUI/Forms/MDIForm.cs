// Zaitun Time Series 
// http://www.zaitunsoftware.com/
// http://code.google.com/p/zaitun-time-series/
//
// Copyright ©  2008-2009, Zaitun Time Series Developer Team and individual contributors
//
// Core Programmer: Rizal Zaini Ahmad Fathony (rizalzaf@gmail.com)
// Programmer: Suryono Hadi Wibowo, Khaerul Anas, Almaratul Sholihah, Muhamad Fuad Hasan
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
using System.IO;

namespace zaitun.GUI
{
    public partial class MDIForm : Form
    {
        private int childFormNumber = 0;

        private WelcomeScreen welcomeScreen;

        private string helpString = "zaitun.chm";
        private List<string> recentItem;

        public MDIForm()
        {
            InitializeComponent();            
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            
            // Create a new instance of the child form.
            DataForm childForm = new DataForm();
            // Make it a child of this MDI form before showing it.
            childForm.MdiParent = this;
            childForm.Disposed += new EventHandler(childForm_Disposed);
            childForm.saveAsEvent += new SaveAsEventHandler(childForm_saveAsEvent);
            childFormNumber++;
            bool success = childForm.CrateNewData();
            if (success)
            {
                if (this.childFormNumber == 1)
                    this.welcomeScreen.Hide();

                childForm.Show();
                childForm.WindowState = FormWindowState.Maximized;       
                
            }
            else
            {
                childForm.Dispose();
            }
        }

        void childForm_saveAsEvent(object sender, EventArgs e)
        {
            DataForm frm = (DataForm)sender;

            //add to recent items
            if (this.recentItem.Contains(frm.FilePath))
            {
                this.recentItem.RemoveAt(this.recentItem.IndexOf(frm.FilePath));
                this.recentItem.Add(frm.FilePath); 
            }
            else
            {
                if (this.recentItem.Count == 10) this.recentItem.RemoveAt(0);
                this.recentItem.Add(frm.FilePath);                
            }
            welcomeScreen.UpdateRecentItem();
            this.writeRecentListFile();

        }

        void childForm_Disposed(object sender, EventArgs e)
        {
            this.childFormNumber--;
            if (this.childFormNumber == 0 && this.IsHandleCreated)            
                this.welcomeScreen.Show();            
        }

        private void OpenFile(object sender, EventArgs e)
        {  
         
            // Create a new instance of the child form.
            DataForm childForm = new DataForm();
            // Make it a child of this MDI form before showing it.
            childForm.MdiParent = this;
            childForm.Disposed += new EventHandler(childForm_Disposed);
            childFormNumber++;            
            bool success = childForm.OpenFile();
            if (success)
            {
                if (this.childFormNumber == 1)
                    this.welcomeScreen.Hide();
                childForm.Show();
                childForm.WindowState = FormWindowState.Maximized;

                //add to recent items
                if (this.recentItem.Contains(childForm.FilePath))
                {
                    this.recentItem.RemoveAt(this.recentItem.IndexOf(childForm.FilePath));
                    this.recentItem.Add(childForm.FilePath);
                }
                else
                {
                    if (this.recentItem.Count == 10) this.recentItem.RemoveAt(0);
                    this.recentItem.Add(childForm.FilePath);                     
                }
                welcomeScreen.UpdateRecentItem();
                this.writeRecentListFile();
            }
            else
            {
                childForm.Dispose();
            }
        }

        public void OpenFile(string filePath)
        {

            // Create a new instance of the child form.
            DataForm childForm = new DataForm();
            // Make it a child of this MDI form before showing it.
            childForm.MdiParent = this;
            childForm.Disposed += new EventHandler(childForm_Disposed);
            childFormNumber++;
            bool success = childForm.OpenFile(filePath);
            if (success)
            {
                if (this.childFormNumber == 1)
                    this.welcomeScreen.Hide();
                childForm.Show();
                childForm.WindowState = FormWindowState.Maximized;

                //add to recent items
                if (this.recentItem.Contains(childForm.FilePath))
                {
                    this.recentItem.RemoveAt(this.recentItem.IndexOf(childForm.FilePath));
                    this.recentItem.Add(childForm.FilePath);
                }
                else
                {
                    if (this.recentItem.Count == 10) this.recentItem.RemoveAt(0);
                    this.recentItem.Add(childForm.FilePath);
                }
                welcomeScreen.UpdateRecentItem();
                this.writeRecentListFile();
            }
            else
            {
                childForm.Dispose();
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.SaveAsToFile();
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard.GetText() or System.Windows.Forms.GetData to retrieve information from the clipboard.
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIForm_Load(object sender, EventArgs e)
        {

            welcomeScreen = new WelcomeScreen();
            welcomeScreen.MdiParent = this;
            welcomeScreen.Show();
            welcomeScreen.lblOpen.Click += new EventHandler(this.OpenFile);
            welcomeScreen.lblCreate.Click += new EventHandler(this.ShowNewForm);

            welcomeScreen.lblRecent1.Click += new EventHandler(lblRecent_Click);
            welcomeScreen.lblRecent2.Click += new EventHandler(lblRecent_Click);
            welcomeScreen.lblRecent3.Click += new EventHandler(lblRecent_Click);
            welcomeScreen.lblRecent4.Click += new EventHandler(lblRecent_Click);
            welcomeScreen.lblRecent5.Click += new EventHandler(lblRecent_Click);
            welcomeScreen.lblRecent6.Click += new EventHandler(lblRecent_Click);
            welcomeScreen.lblRecent7.Click += new EventHandler(lblRecent_Click);
            welcomeScreen.lblRecent8.Click += new EventHandler(lblRecent_Click);
            welcomeScreen.lblRecent9.Click += new EventHandler(lblRecent_Click);
            welcomeScreen.lblRecent10.Click += new EventHandler(lblRecent_Click);

            this.readRecentListFile();

            welcomeScreen.SetRecentItem(this.recentItem);
            welcomeScreen.UpdateRecentItem();
        }

        void lblRecent_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            this.OpenFile(this.recentItem[this.recentItem.Count - welcomeScreen.LblCurrentList.IndexOf(lbl) - 1]);
        }

        private void readRecentListFile()
        {
            this.recentItem = new List<string>();
            //open recent file
            if (File.Exists(Application.StartupPath + "\\recent.dat"))
            {
                StreamReader reader = new StreamReader(Application.StartupPath + "\\recent.dat");
                while (!reader.EndOfStream)
                {
                    try
                    {
                        this.recentItem.Add(reader.ReadLine());
                    }
                    catch
                    {
                        MessageBox.Show("Error reading recent items file");
                    }
                }

                reader.Close();
            }            
        }

        private void writeRecentListFile()
        {
            if (File.Exists(Application.StartupPath + "\\recent.dat"))
            {
                File.Delete("recent.dat");
            }

            StreamWriter writer = new StreamWriter(Application.StartupPath + "\\recent.dat");
            try
            {
                for (int i = 0; i < this.recentItem.Count; i++)
                {
                    writer.WriteLine(this.recentItem.ToArray()[i]);
                }
            }
            catch
            {
                MessageBox.Show("Error writing recent items file");
            }
            finally
            {
                writer.Close();
            }
        }

        private void importFromCSVStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.ImportFromCSV();
            }
        }

        private void importFromExcelStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.ImportFromExcel();
            }
        }

        private void exportToCSVStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.ExportToCSV();
            }
        }

        private void printPreviewStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.PrintPreview();
            }
        }

        private void printStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.Print();
            }
        }

        private void pageSetupStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.PageSetup();
            }
        }

        private void exportToExcelStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.ExportToExcel();
            }
        }

        private void transformStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.TransformVariable();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.SaveToFile();
            }
        }

        private void neuralNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.NeuralNetworkAnalysis();
            }
        }        

        private void trendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.TrendAnalysis();
            }
        }

        private void decompositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.Decomposition();
            }
        }

        private void movingAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.MovingAverage();
            }
        }

        private void singleExpSmootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.ExponentialSmoothing();
            }
        }

        
        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Help.ShowHelp(this, this.helpString);
            try { System.Diagnostics.Process.Start("www.zaitunsoftware.com/download-zaitun-time-series"); }
            catch { }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            //Help.ShowHelp(this, this.helpString);
            try { System.Diagnostics.Process.Start("www.zaitunsoftware.com/download-zaitun-time-series"); }
            catch { }
        }

        private void corellogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild != this.welcomeScreen)
            {
                DataForm activeForm = (DataForm)this.ActiveMdiChild;
                activeForm.Correlogram();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm frm = new AboutForm();
            frm.ShowDialog();
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("www.zaitunsoftware.com/donate-zaitun-software"); }
            catch { }
        }
    }
}
