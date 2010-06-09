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
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace zaitun.Data
{
    public class SeriesDataPrinter
    {
        private PrintDocument document;        
        private PrinterSettings printSettings;
        private PageSettings pageSettings;
        
        private SeriesData data;
        private Font printFont;

        private int countAll = 0;

        public SeriesDataPrinter(SeriesData data)
        {
            this.data = data;
            this.document = new PrintDocument();
            this.document.DocumentName = data.SeriesName + "document";
            this.printFont = new Font("Arial", 10);
            this.printSettings = new PrinterSettings();
            this.pageSettings = new PageSettings();
            this.document.PrinterSettings = this.printSettings;
            this.document.DefaultPageSettings = this.pageSettings;
            this.document.PrintPage += new PrintPageEventHandler(document_PrintPage);
            this.document.BeginPrint += new PrintEventHandler(document_BeginPrint);
        }

        public void document_BeginPrint(object sender, PrintEventArgs e)
        {
            this.countAll = 0;
        }

        private void document_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;            
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            int count = 0;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            // print header
            yPos = topMargin + (count *
                   printFont.GetHeight(ev.Graphics));
            string rowText = "";
            for (int i = 0; i < this.data.SeriesVariables.Count - 1; i++)
                rowText += this.data.SeriesVariables[i].VariableName+ "\t";
            rowText += this.data.SeriesVariables[this.data.SeriesVariables.Count - 1].VariableName;
            ev.Graphics.DrawString(rowText, printFont, Brushes.Black,
               leftMargin, yPos, new StringFormat());            
            count++;

            // Print each line of the file. 
            while (count < linesPerPage &&
               (countAll < this.data.NumberObservations))
            {
                yPos = topMargin + (count *
                   printFont.GetHeight(ev.Graphics));

                rowText = "";
                for (int i = 0; i < this.data.SeriesVariables.Count - 1; i++)
                    rowText += this.data.SeriesVariables[i][countAll].ToString("G4") + "\t";
                rowText += this.data.SeriesVariables[this.data.SeriesVariables.Count - 1][countAll].ToString("G4");

                ev.Graphics.DrawString(rowText, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                countAll++;
                count++;
            }

            // If more lines exist, print another page.
            if (countAll < this.data.NumberObservations)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

        public void PreviewDocument()
        {
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = this.document;
            dlg.ShowDialog();
            
        }

        public void PrintDocument()
        {
            PrintDialog dlg = new PrintDialog();
            dlg.Document = this.document;
            
            dlg.PrinterSettings = this.printSettings;
            if (dlg.ShowDialog() == DialogResult.OK)
            {   
                this.document.Print();
            }
            
        }

        public void SettingDocument()
        {
            PageSetupDialog setup = new PageSetupDialog();
            setup.Document = this.document;
            setup.PageSettings = this.pageSettings;
            setup.PrinterSettings = this.printSettings;
            setup.ShowDialog();
            
        }
        
    }
}
