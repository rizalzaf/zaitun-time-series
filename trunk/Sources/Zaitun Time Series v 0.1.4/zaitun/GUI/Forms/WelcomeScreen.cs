using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zaitun.GUI
{   
    public partial class WelcomeScreen : Form
    {       
        private List<Label> lblCurrentList;
        private List<PictureBox> pictureCurrentList;

        private List<string> recentItem;

        public WelcomeScreen()
        {
            InitializeComponent();

            this.lblCurrentList = new List<Label>();
            this.lblCurrentList.Add(lblRecent1);
            this.lblCurrentList.Add(lblRecent2);
            this.lblCurrentList.Add(lblRecent3);
            this.lblCurrentList.Add(lblRecent4);
            this.lblCurrentList.Add(lblRecent5);
            this.lblCurrentList.Add(lblRecent6);
            this.lblCurrentList.Add(lblRecent7);
            this.lblCurrentList.Add(lblRecent8);
            this.lblCurrentList.Add(lblRecent9);
            this.lblCurrentList.Add(lblRecent10);

            this.pictureCurrentList = new List<PictureBox>();
            this.pictureCurrentList.Add(pictureRecent1);
            this.pictureCurrentList.Add(pictureRecent2);
            this.pictureCurrentList.Add(pictureRecent3);
            this.pictureCurrentList.Add(pictureRecent4);
            this.pictureCurrentList.Add(pictureRecent5);
            this.pictureCurrentList.Add(pictureRecent6);
            this.pictureCurrentList.Add(pictureRecent7);
            this.pictureCurrentList.Add(pictureRecent8);
            this.pictureCurrentList.Add(pictureRecent9);
            this.pictureCurrentList.Add(pictureRecent10);

     
        }

        public void SetRecentItem(List<string> recentItem)
        {
            this.recentItem = recentItem;
        }

        public void UpdateRecentItem()
        {
            for (int i = 0; i < this.recentItem.Count; i++)
            {
                if (this.recentItem[i].Length > 45)
                {
                    string[] str = this.recentItem[i].Split('\\');
                    int m = str.Length - 1;
                    string tempString = str[m];
                    m--;
                    if (tempString.Length < 40)
                    {
                        while ((str[m] + tempString).Length < 40 && m > 0)
                        {
                            tempString = (str[m] + "\\" + tempString);
                            m--;
                        }
                        tempString = str[0] + "\\...\\" + tempString;
                    }
                    else
                    {
                        tempString = str[0] + "\\..." + str[str.Length - 1].Substring(str[str.Length - 1].Length - 40);
                    }
                    this.lblCurrentList[this.recentItem.Count - 1 - i].Text = tempString;
                }
                else
                {
                    this.lblCurrentList[this.recentItem.Count - 1 - i].Text = this.recentItem[i];
                }                
                this.lblCurrentList[this.recentItem.Count - 1 - i].Visible = true;
                this.pictureCurrentList[this.recentItem.Count - 1 - i].Visible = true;
            }
            for (int i = this.recentItem.Count; i < 10; i++)
            {
                this.lblCurrentList[i].Visible = false;
                this.pictureCurrentList[i].Visible = false;
            }
        }

        public List<Label> LblCurrentList
        {
            get { return this.lblCurrentList; }
        }

        private void openMouseEnter(object sender, EventArgs e)
        {
            this.openPictureBox.Image = zaitun.Properties.Resources.genericFolder_selected;
        }

        private void openMouseLeave(object sender, EventArgs e)
        {
            this.openPictureBox.Image = zaitun.Properties.Resources.genericFolder;
        }

        private void createMouseEnter(object sender, EventArgs e)
        {
            this.createNewPictureBox.Image = zaitun.Properties.Resources.filetype_zft_selected;
        }

        private void createMouseLeave(object sender, EventArgs e)
        {
            this.createNewPictureBox.Image = zaitun.Properties.Resources.filetype_zft;
        }

    }
}