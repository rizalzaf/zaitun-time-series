using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using zaitun.MatrixVector;
using FarsiLibrary.Win;

namespace zaitun.Correlogram
{
    /// <summary>
    /// Menampilkan output correlogram
    /// </summary>
    public partial class CorrelogramResult : FATabStripItem
    {

        private double[] data;
        private int lag;
        private bool whiteNoiseAcf = true;

        public CorrelogramResult()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Mengeset nilai-nilai yang akan ditampilkan
        /// </summary>
        public void SetData(double[] data, int lag, bool whiteNoiseAcf)
        {
            this.data = data;
            this.lag = lag;
            this.whiteNoiseAcf = whiteNoiseAcf;
        }        

        public void DisplayResult()
        {
            Vector Y = new Vector(data, data.Length);

            Boundaries k = new Boundaries(data, lag, this.whiteNoiseAcf);            

            LjungBoxQTest Q = new LjungBoxQTest(Y, lag);

            //I GRAFIK ACF
            //Mengeset nilai pada grafik sumbu x
            double[] xAxis = new double[lag];
            for (int i = 0; i < lag; i++) xAxis[i] = i + 1.0;

            //mengeset nilai-nilai ACF pada sumbu y
            double[] yAxis = new double[lag];
            for (int i = 0; i < lag; i++) yAxis[i] = Q.ACF[i];

            GraphPane variablePane = this.zedGraphControl1.GraphPane;

            //Memberi nama pada grafik
            variablePane.Title.Text = "ACF Graph";

            string whiteNoiseText="";
            //if (this.whiteNoiseAcf) whiteNoiseText += "(white noise)";
                                    
            variablePane.XAxis.Title.Text = "Lag";
            variablePane.YAxis.Title.Text = "ACF";

            //Menampilkan grafik batas atas dan batas bawah

            variablePane.AddCurve("Upper Bound " + whiteNoiseText, xAxis, k.ACFUp, Color.Blue, SymbolType.None);
            variablePane.AddCurve("Lower Bound " + whiteNoiseText, xAxis, k.ACFDown, Color.Blue, SymbolType.None);

            //Menampilkan grafik ACF
            BarItem myCurve = variablePane.AddBar("ACF", xAxis, yAxis, Color.Red);
            //myCurve.Line.Width = 5.0f;

            //Batas max dan min sumbu y
            variablePane.YAxis.Scale.Min = -1;
            variablePane.YAxis.Scale.Max = 1;

            variablePane.XAxis.Scale.Min = 0;
            variablePane.XAxis.Scale.Max = lag + 1;

            //Memberi warna pada grafik
            variablePane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                        Color.FromArgb(255, 255, 190), 90F);
            variablePane.Fill = new Fill(Color.White, Color.LightBlue, 135.0f);

            zedGraphControl1.AxisChange();

            //II GRAFIK PACF
            //Mengeset nilai pada grafik sumbu x
            double[] xAxis1 = new double[lag];
            for (int i = 0; i < lag; i++) xAxis1[i] = i + 1.0;

            //mengeset nilai-nilai PACF pada sumbu y
            double[] yAxis1 = new double[lag];
            for (int i = 0; i < lag; i++) yAxis1[i] = Q.PACF[i, i];

            GraphPane variablePane1 = this.zedGraphControl2.GraphPane;

            //Memberi nama pada grafik
            variablePane1.Title.Text = "PACF Graph";
            variablePane1.XAxis.Title.Text = "Lag";
            variablePane1.YAxis.Title.Text = "PACF";

            //Menampilkan grafik batas atas dan batas bawah
            LineItem cv1 = variablePane1.AddCurve("Upper Bound", xAxis, k.PACFUp, Color.Blue, SymbolType.None);
            LineItem cv2 = variablePane1.AddCurve("lower Bound", xAxis, k.PACFDown, Color.Blue, SymbolType.None);

            //Menampilkan grafik PACF
            BarItem myCurve1 = variablePane1.AddBar("PACF", xAxis1, yAxis1, Color.Red);
            //myCurve1.Line.Width = 5.0f;

            //Batas max dan min sumbu y
            variablePane1.YAxis.Scale.Min = -1;
            variablePane1.YAxis.Scale.Max = 1;
            variablePane1.XAxis.Scale.Min = 0;
            variablePane1.XAxis.Scale.Max = lag + 1;

            //Memberi warna pada grafik
            variablePane1.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                        Color.FromArgb(255, 255, 190), 90F);
            variablePane1.Fill = new Fill(Color.White, Color.LightBlue, 135.0f);

            zedGraphControl2.AxisChange();

            dataGridView2.RowCount = lag;

            dataGridView2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            //Menampilkan tabel yang berisi nilai ACF, PACF, Statistik Q, PValue
            for (int i = 0; i < lag; i++)
            {
                dataGridView2.Rows[i].HeaderCell.Value = "" + (i + 1);
                dataGridView2[0, i].Value = Q.ACF[i].ToString("F4");
                dataGridView2[1, i].Value = Q.PACF[i, i].ToString("F4");
                dataGridView2[2, i].Value = Q.LB[i].ToString("F4");                

                if (Q.PValue[i].ToString() == "NaN")
                { dataGridView2[3, i].Value = ""; }
                else
                    dataGridView2[3, i].Value = Q.PValue[i].ToString("F3");

            }
        }

        private void zedGraphControl2_Load(object sender, EventArgs e)
        {

        }


        public double[] Data
        {
            get { return data; }
        }


        public int Lag
        {
            get { return lag; }
        }

        public bool WhiteNoiseAcf
        {
            get { return this.whiteNoiseAcf; }
        }

       

       
    }
}