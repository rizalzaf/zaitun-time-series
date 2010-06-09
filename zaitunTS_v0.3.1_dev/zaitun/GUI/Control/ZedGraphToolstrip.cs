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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace zaitun.GUI
{
    public partial class ZedGraphToolstrip : UserControl
    {
        private ZedGraph.ZedGraphControl zedControl;
        private ZedGraph.GraphPane pane;

        public ZedGraphToolstrip()
        {
            InitializeComponent();
        }

        public void SetData(ZedGraph.ZedGraphControl zedControl, ZedGraph.GraphPane pane)
        {
            this.zedControl = zedControl;
            this.pane = pane;
        }

        private void showPointButtonClick(object sender, EventArgs e)
        {
            if (this.showPointValuesButton.Checked == false)
            {
                this.zedControl.IsShowPointValues = true;
                this.showPointValuesButton.Checked = true;
                if (this.cursorValuesButton.Checked)
                {
                    this.cursorValuesButton.Checked = false;
                    this.zedControl.IsShowCursorValues = false;
                }
            }
            else
            {                
                this.zedControl.IsShowPointValues = false;
                this.showPointValuesButton.Checked = false;
                if (this.cursorValuesButton.Checked)
                {
                    this.cursorValuesButton.Checked = false;
                    this.zedControl.IsShowCursorValues = false;
                }
            }
        }

        private void cursorValuesButton_Click(object sender, EventArgs e)
        {
            if (this.cursorValuesButton.Checked == false)
            {
                this.zedControl.IsShowCursorValues = true;
                this.cursorValuesButton.Checked = true;
                if (this.showPointValuesButton.Checked)
                {
                    this.showPointValuesButton.Checked = false;
                    this.zedControl.IsShowPointValues = false;
                }
            }
            else
            {
                this.zedControl.IsShowCursorValues = false;
                this.cursorValuesButton.Checked = false;
                if (this.showPointValuesButton.Checked)
                {
                    this.showPointValuesButton.Checked = false;
                    this.zedControl.IsShowPointValues = false;
                }
            }
        }

        private void saveImageButton_Click(object sender, EventArgs e)
        {
            this.zedControl.SaveAs();
        }

        private void copyImageButton_Click(object sender, EventArgs e)
        {
            this.zedControl.Copy(true);
        }

        private void printPreviewButton_Click(object sender, EventArgs e)
        {
            this.zedControl.DoPrintPreview();
        }

        private void pageSetupButton_Click(object sender, EventArgs e)
        {
            this.zedControl.DoPageSetup();
        }

        private void printImageButton_Click(object sender, EventArgs e)
        {
            this.zedControl.DoPrint();
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            if (this.zoomInButton.Checked == false)
            {
                this.zedControl.IsEnableHZoom = true;
                this.zedControl.IsEnableVZoom = true;
                this.zoomInButton.Checked = true;
            }
            else
            {
                this.zedControl.IsEnableHZoom = false;
                this.zedControl.IsEnableVZoom = false;
                this.zoomInButton.Checked = false;
                if (this.activateScrollButton.Checked)                {
                    this.activateScrollButton.Checked = false;
                    this.zedControl.IsScrollY2 = false;
                }
            }
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            this.zedControl.ZoomOut(pane);
        }

        private void defaultScaleButton_Click(object sender, EventArgs e)
        {
            this.zedControl.ZoomOutAll(pane);
        }

        private void activateScrollButton_Click(object sender, EventArgs e)
        {
            if (this.activateScrollButton.Checked == false)
            {
                this.zedControl.IsScrollY2 = true;
                this.activateScrollButton.Checked = true;
                this.zedControl.IsEnableHZoom = true;
                this.zedControl.IsEnableVZoom = true;
                this.zoomInButton.Checked = true;
            }
            else
            {
                this.zedControl.IsScrollY2 = false;
                this.activateScrollButton.Checked = false;
                this.zedControl.IsEnableHZoom = false;
                this.zedControl.IsEnableVZoom = false;
                this.zoomInButton.Checked = false;
                this.zedControl.IsAutoScrollRange = false;
                this.zedControl.IsShowHScrollBar = false;
                this.zedControl.IsShowVScrollBar = false;
            }
        }

    }
}
