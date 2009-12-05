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
using System.Threading;

namespace zaitun.GUI
{
    public partial class ImportSeriesStock : Form
    {
        private SeriesData sourceData;        
        private SeriesVariable openVariable;
        private SeriesVariable closeVariable;
        private SeriesVariable highVariable;
        private SeriesVariable lowVariable;
        private SeriesVariable volumeVariable;


        private List<string> date;
        private List<double> open;
        private List<double> high;
        private List<double> low;
        private List<double> close;
        private List<double> volume;
        private List<double> adjClose;

        private int nullCount;
        private Thread downloadThread;
        
        public ImportSeriesStock(SeriesData sourceData)
        {
            InitializeComponent();
            this.sourceData= sourceData;

            this.lblFrequency.Text = sourceData.Frequency.ToString();            
            switch (this.sourceData.Frequency)
            {                
                case SeriesData.SeriesFrequency.Monthly:                    
                    this.lblTime.Text = sourceData.StartDate.Year.ToString() + ":" + sourceData.StartDate.Month.ToString() + " -> " + sourceData.EndDate.Year.ToString() + ":" + sourceData.EndDate.Month.ToString();
                    break;
                default:                    
                    this.lblTime.Text = sourceData.StartDate.ToString("yyyy-MM-dd") + " -> " + sourceData.EndDate.ToString("yyyy-MM-dd");
                    break;
            }

            this.cmbServer.SelectedIndex = 0;
            this.enableControl(false);
            this.viewProgress(false);
        }

        public SeriesVariable OpenVariable
        {
            get { return this.openVariable; }
        }

        public SeriesVariable CloseVariable
        {
            get { return this.closeVariable; }
        }

        public SeriesVariable HighVariable
        {
            get { return this.highVariable; }
        }

        public SeriesVariable LowVariable
        {
            get { return this.lowVariable; }
        }

        public SeriesVariable VolumeVariable
        {
            get { return this.volumeVariable; }
        }

        public string StockName
        {
            get { return this.txtName.Text; }
        }

        public string StockDescription
        {
            get { return this.txtDescription.Text; }
        }

        private void enableControl(bool enabled)
        {
            this.txtDescription.Enabled = enabled;
            this.txtName.Enabled = enabled;
            this.cmdOK.Enabled = enabled;
        }

        private void viewProgress(bool enabled)
        {
            this.previewTextBox.Visible = !enabled;
            this.progressBar.Visible = enabled;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                this.openVariable = new SeriesVariable(txtName.Text + "_open", txtName.Text + "_open", this.sourceData.NumberObservations);
                this.highVariable = new SeriesVariable(txtName.Text + "_high", txtName.Text + "_high", this.sourceData.NumberObservations);
                this.lowVariable = new SeriesVariable(txtName.Text + "_low", txtName.Text + "_low", this.sourceData.NumberObservations);
                this.closeVariable = new SeriesVariable(txtName.Text + "_close", txtName.Text + "_close", this.sourceData.NumberObservations);
                this.volumeVariable = new SeriesVariable(txtName.Text + "_volume", txtName.Text + "_volume", this.sourceData.NumberObservations);

                int i = 0;
                int j = this.date.Count - 1;

                if (this.sourceData.Frequency == SeriesData.SeriesFrequency.Daily5)
                {
                    while (i < this.sourceData.NumberObservations)
                    {
                        string day = this.sourceData.XTime[i].ToString("yyyy-MM-dd");
                        if (j >= 0)
                        {
                            if (day == this.date[j])
                            {
                                this.openVariable[i] = this.open[j];
                                this.highVariable[i] = this.high[j];
                                this.lowVariable[i] = this.low[j];
                                this.closeVariable[i] = this.close[j];
                                this.volumeVariable[i] = this.volume[j];
                                j--;
                            }
                            else
                            {
                                this.openVariable[i] = double.NaN;
                                this.highVariable[i] = double.NaN;
                                this.lowVariable[i] = double.NaN;
                                this.closeVariable[i] = double.NaN;
                                this.volumeVariable[i] = double.NaN;
                            }
                        }
                        else
                        {
                            this.openVariable[i] = double.NaN;
                            this.highVariable[i] = double.NaN;
                            this.lowVariable[i] = double.NaN;
                            this.closeVariable[i] = double.NaN;
                            this.volumeVariable[i] = double.NaN;
                        }
                        i++;
                    }
                }
                else if (this.sourceData.Frequency == SeriesData.SeriesFrequency.Weekly)
                {
                    while (i < this.sourceData.NumberObservations)
                    {     
                        if (j >= 0)
                        {
                            int dayOfDate = int.Parse(this.date[j].Substring(8, 2));
                            int monthOfDate = int.Parse(this.date[j].Substring(5, 2));
                            int yearOfDate = int.Parse(this.date[j].Substring(0, 4));
                            DateTime dateofDate = new DateTime(yearOfDate, monthOfDate, dayOfDate);

                            if (this.isSameWeek(dateofDate, this.sourceData.XTime[i]))
                            {
                                this.openVariable[i] = this.open[j];
                                this.highVariable[i] = this.high[j];
                                this.lowVariable[i] = this.low[j];
                                this.closeVariable[i] = this.close[j];
                                this.volumeVariable[i] = this.volume[j];
                                j--;
                            }
                            else
                            {
                                this.openVariable[i] = double.NaN;
                                this.highVariable[i] = double.NaN;
                                this.lowVariable[i] = double.NaN;
                                this.closeVariable[i] = double.NaN;
                                this.volumeVariable[i] = double.NaN;
                            }
                        }
                        else
                        {
                            this.openVariable[i] = double.NaN;
                            this.highVariable[i] = double.NaN;
                            this.lowVariable[i] = double.NaN;
                            this.closeVariable[i] = double.NaN;
                            this.volumeVariable[i] = double.NaN;
                        }
                        i++;
                    }
                }
                else if (this.sourceData.Frequency == SeriesData.SeriesFrequency.Monthly)
                {
                    while (i < this.sourceData.NumberObservations)
                    {                        
                        if (j >= 0)
                        {
                            string day = this.sourceData.XTime[i].ToString("yyyy-MM");
                            string dayOfDate = this.date[j].Substring(0, 7);

                            if (day == dayOfDate)
                            {
                                this.openVariable[i] = this.open[j];
                                this.highVariable[i] = this.high[j];
                                this.lowVariable[i] = this.low[j];
                                this.closeVariable[i] = this.close[j];
                                this.volumeVariable[i] = this.volume[j];
                                j--;
                            }
                            else
                            {
                                this.openVariable[i] = double.NaN;
                                this.highVariable[i] = double.NaN;
                                this.lowVariable[i] = double.NaN;
                                this.closeVariable[i] = double.NaN;
                                this.volumeVariable[i] = double.NaN;
                            }
                        }
                        else
                        {
                            this.openVariable[i] = double.NaN;
                            this.highVariable[i] = double.NaN;
                            this.lowVariable[i] = double.NaN;
                            this.closeVariable[i] = double.NaN;
                            this.volumeVariable[i] = double.NaN;
                        }
                        i++;
                    }
                }

                this.nullCount = this.sourceData.NumberObservations - this.date.Count;
                if (this.nullCount > 0)
                {
                    if (MessageBox.Show("There are some days which the data are not available\n" +
                    "It is occured when the server doesn't provide the data at these days\n or the market was closed on these days (e.g. because of holiday)\nDo you want to continue importing this data?", "Import Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.No) this.DialogResult = DialogResult.None;
                }

                if (txtDescription.Text.Length < 1)
                {
                    this.txtDescription.Text = this.txtName.Text;
                }
            }
            else
            {
                MessageBox.Show("Please type the stock's name");
                this.DialogResult = DialogResult.None;
            }
        }

        private bool isSameWeek(DateTime date1, DateTime date2)
        {
            bool result = false;

            DayOfWeek day1 = date1.DayOfWeek;

            DateTime leftDate = date1.AddDays(-(double)day1);
            DateTime rightDate = date1.AddDays(6-(double)day1);

            if (date2 >= leftDate && date2 <= rightDate)
            {
                result = true;
            }

            return result;
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (txtSymbol.Text != "")
            {
                this.viewProgress(true);
                this.downloadThread = new Thread(new ThreadStart(this.getQuote));
                this.downloadThread.Start();
            }
        }

        private void getQuote()
        {
            try
            {
                string url = "";
                switch (this.sourceData.Frequency)
                {
                    case SeriesData.SeriesFrequency.Daily5:
                        url = "http://ichart.finance.yahoo.com/table.csv?s=" + txtSymbol.Text.Trim() + "&a=" + (this.sourceData.StartDate.Month - 1).ToString() + "&b=" + this.sourceData.StartDate.Day.ToString() + "&c=" + this.sourceData.StartDate.Year.ToString() + "&d=" + (this.sourceData.EndDate.Month - 1).ToString() + "&e=" + this.sourceData.EndDate.Day.ToString() + "&f=" + this.sourceData.EndDate.Year.ToString() + "&g=d&ignore=.csv";
                        break;
                    case SeriesData.SeriesFrequency.Weekly:
                        url = "http://ichart.finance.yahoo.com/table.csv?s=" + txtSymbol.Text.Trim() + "&a=" + (this.sourceData.StartDate.Month - 1).ToString() + "&b=" + this.sourceData.StartDate.Day.ToString() + "&c=" + this.sourceData.StartDate.Year.ToString() + "&d=" + (this.sourceData.EndDate.Month - 1).ToString() + "&e=" + this.sourceData.EndDate.Day.ToString() + "&f=" + this.sourceData.EndDate.Year.ToString() + "&g=w&ignore=.csv";
                        break;
                    case SeriesData.SeriesFrequency.Monthly:
                        url = "http://ichart.finance.yahoo.com/table.csv?s=" + txtSymbol.Text.Trim() + "&a=" + (this.sourceData.StartDate.Month - 1).ToString() + "&b=" + this.sourceData.StartDate.Day.ToString() + "&c=" + this.sourceData.StartDate.Year.ToString() + "&d=" + (this.sourceData.EndDate.Month - 1).ToString() + "&e=" + this.sourceData.EndDate.Day.ToString() + "&f=" + this.sourceData.EndDate.Year.ToString() + "&g=m&ignore=.csv";
                        break;
                }

                HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(url);
                http.Timeout = 240000;

                HttpWebResponse resp = (HttpWebResponse)http.GetResponse();

                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = resp.GetResponseStream();
                    Encoding encode = System.Text.Encoding.UTF8;

                    StreamReader reader = new StreamReader(responseStream, encode);

                    this.date = new List<string>();
                    this.open = new List<double>();
                    this.high = new List<double>();
                    this.low = new List<double>();
                    this.close = new List<double>();
                    this.volume = new List<double>();
                    this.adjClose = new List<double>();

                    this.previewTextBox.Clear();

                    if (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        string[] rows = line.Split(',');
                        this.previewTextBox.AppendText(rows[0] + "\t\t" + rows[1] + "\t" + rows[2] + "\t" + rows[3] + "\t" + rows[4] + "\t" + rows[5] + "\t" + rows[6] + "\n");

                    }

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        string[] rows = line.Split(',');
                        this.date.Add(rows[0]);
                        this.open.Add(double.Parse(rows[1]));
                        this.high.Add(double.Parse(rows[2]));
                        this.low.Add(double.Parse(rows[3]));
                        this.close.Add(double.Parse(rows[4]));
                        this.volume.Add(double.Parse(rows[5]));
                        this.adjClose.Add(double.Parse(rows[6]));

                        this.previewTextBox.AppendText(rows[0] + "\t" + rows[1] + "\t" + rows[2] + "\t" + rows[3] + "\t" + rows[4] + "\t" + rows[5] + "\t" + rows[6] + "\n");

                    }

                    if (txtName.Text == "") txtName.Text = txtSymbol.Text;
                                        
                    this.enableControl(true);
                }
                else
                {
                    MessageBox.Show("Couldn't connect to the server.");
                }
            }
            catch (WebException we)
            {
                if (we.Response != null)
                {
                    MessageBox.Show("Couldn't find symbol \'" + txtSymbol.Text + "\' in the server");
                }
                else
                {
                    MessageBox.Show("Couldn't connect to the server. " + we.Message + ".");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't connect to the server. " + ex.Message + ".");
            }

            this.viewProgress(false);
            
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // check if worker thread is running
            if ((downloadThread != null) && (downloadThread.IsAlive))
            {
                // stop worker thread                
                downloadThread.Join();
                downloadThread = null;
            }
        }

        private void cmdList_Click(object sender, EventArgs e)
        {
            StockListDialog dlg = new StockListDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtSymbol.Text = dlg.StockSymbol;
                this.txtName.Text = dlg.StockSymbol;
                this.txtDescription.Text = dlg.StockDescription;
            }
        }
    }
}