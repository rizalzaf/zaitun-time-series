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
using System.Text;
using zaitun.GUI;
using System.Xml;
using System.Windows.Forms;
using zaitun.NeuralNetwork;
using zaitun.TrendAnalysis;
using zaitun.MovingAverage;
using zaitun.Decomposition;
using zaitun.ExponentialSmoothing;
using FarsiLibrary.Win;
using zaitun.Correlogram;

namespace zaitun.Data
{
    /// <summary>
    /// Kelas untuk menulis file .zft
    /// file .zft ditulis dalam format xml
    /// </summary>
    public class SeriesFileWriter
    {
        /// <summary>
        /// Penulis file xml
        /// </summary>
        private XmlWriter seriesXmlWriter;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filePath">path file yang akan ditulis</param>
        public SeriesFileWriter(string filePath)
        {
            XmlWriterSettings xmlSetting = new XmlWriterSettings();
            xmlSetting.Indent = true;
            seriesXmlWriter = XmlWriter.Create(filePath, xmlSetting);
        }

        /// <summary>
        /// Menulis data
        /// </summary>
        /// <param name="data">Series Data yang akan ditulis</param>
        public void WriteData(SeriesData data)
        {
            seriesXmlWriter.WriteStartDocument();
            seriesXmlWriter.WriteStartElement("zaitunDataFile");
            seriesXmlWriter.WriteStartElement("SeriesData");
            seriesXmlWriter.WriteElementString("SeriesName",data.SeriesName);
            seriesXmlWriter.WriteElementString("Frequency", ((int)data.Frequency).ToString());
            seriesXmlWriter.WriteElementString("StartDate", data.StartDate.ToString("dd/MM/yyyy"));
            seriesXmlWriter.WriteElementString("EndDate", data.EndDate.ToString("dd/MM/yyyy"));
            seriesXmlWriter.WriteElementString("NumberObservations", data.NumberObservations.ToString());

            //seriesXmlWriter.WriteStartElement("Time");
            //foreach (string str in data.Time)           
            //    seriesXmlWriter.WriteElementString("TimeString", str);
            //seriesXmlWriter.WriteEndElement();

            seriesXmlWriter.WriteStartElement("SeriesVariables");
            foreach (SeriesVariable var in data.SeriesVariables)
            {
                seriesXmlWriter.WriteStartElement("SeriesVariable");
                seriesXmlWriter.WriteElementString("VariableName", var.VariableName);
                seriesXmlWriter.WriteElementString("VariableDescription", var.VariableDescription);
                seriesXmlWriter.WriteStartElement("SeriesValue");
                foreach (double value in var.SeriesValues)
                    seriesXmlWriter.WriteElementString("Value", value.ToString());
                seriesXmlWriter.WriteEndElement();
                seriesXmlWriter.WriteEndElement();
            }
            seriesXmlWriter.WriteFullEndElement();

            seriesXmlWriter.WriteStartElement("SeriesGroups");
            foreach (SeriesGroup group in data.SeriesGroups)
            {
                seriesXmlWriter.WriteStartElement("SeriesGroup");
                seriesXmlWriter.WriteElementString("GroupName", group.GroupName);
                seriesXmlWriter.WriteStartElement("GroupList");
                foreach(SeriesVariable var in group.GroupList)
                    seriesXmlWriter.WriteElementString("SeriesVariableItem", var.VariableName);
                seriesXmlWriter.WriteEndElement();
                seriesXmlWriter.WriteEndElement();
            }
            seriesXmlWriter.WriteFullEndElement();

            seriesXmlWriter.WriteFullEndElement();
                        
            seriesXmlWriter.Flush();            
        }

        /// <summary>
        /// Menulis vaiabel yang ditampilkan pada Variable View
        /// </summary>
        /// <param name="viewPane">Panel Variable View</param>
        public void WriteViewPane(VariableViewPane viewPane)
        {
            seriesXmlWriter.WriteStartElement("ViewPane");

            foreach (TabPage tabPage in viewPane.VariableViewCollection.TabPages)
                seriesXmlWriter.WriteElementString("TabPage", tabPage.Name);

            seriesXmlWriter.WriteFullEndElement();

            //seriesXmlWriter.WriteEndElement();
            //seriesXmlWriter.WriteEndDocument();
            //seriesXmlWriter.Flush();            
        }

        /// <summary>
        /// Menulis Result View
        /// </summary>
        /// <param name="tabPages">tab page pada result view</param>
        public void WriteResultPane(FATabStripItemCollection tabPages)
        {
            seriesXmlWriter.WriteStartElement("ResultPane");

            foreach (FATabStripItem tp in tabPages)
            {
                seriesXmlWriter.WriteStartElement("TabPage");

                if (tp is ANNResultTabPage)
                {
                    ANNResultTabPage annTp = (ANNResultTabPage)tp;
                    seriesXmlWriter.WriteElementString("Type", "Neural Network");
                    seriesXmlWriter.WriteElementString("Title", annTp.Title);
                    seriesXmlWriter.WriteElementString("SeriesVariable", annTp.Variable.VariableName);

                    seriesXmlWriter.WriteStartElement("NetworkSpecification");
                    seriesXmlWriter.WriteElementString("InputLayerNeurons", annTp.NetworkProperties.InputLayerNeurons.ToString());
                    seriesXmlWriter.WriteElementString("HiddenLayerNeurons", annTp.NetworkProperties.HiddenLayerNeurons.ToString());
                    seriesXmlWriter.WriteElementString("OutputLayerNeurons", annTp.NetworkProperties.OutputLayerNeurons.ToString());
                    seriesXmlWriter.WriteElementString("ActivationFunction", ((int)(annTp.NetworkProperties.ActivationFunction)).ToString());
                    seriesXmlWriter.WriteElementString("LearningRate", annTp.NetworkProperties.LearningRate.ToString());
                    seriesXmlWriter.WriteElementString("Momentum", annTp.NetworkProperties.Momentum.ToString());
                    seriesXmlWriter.WriteElementString("IncludedObservations", annTp.NetworkProperties.IncludedObservations.ToString());
                    seriesXmlWriter.WriteElementString("Error", annTp.NetworkProperties.Error.ToString());
                    seriesXmlWriter.WriteElementString("MSE", annTp.NetworkProperties.MSE.ToString());
                    seriesXmlWriter.WriteElementString("MAE", annTp.NetworkProperties.MAE.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("Predicted");
                    foreach (double value in annTp.Predicted)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    if (annTp.Forecasted != null)
                    {
                        seriesXmlWriter.WriteStartElement("Forecasted");
                        foreach (double value in annTp.Forecasted)
                            seriesXmlWriter.WriteElementString("Value", value.ToString());
                        seriesXmlWriter.WriteFullEndElement();
                    }

                    seriesXmlWriter.WriteStartElement("VisibleView");
                    if (annTp.IsAnnModelSummaryVisible) seriesXmlWriter.WriteElementString("View", "AnnModelSummary");
                    if (annTp.IsActualPredictedResidualDataGridVisible) seriesXmlWriter.WriteElementString("View", "ActualPredictedResidualDataGrid");
                    if (annTp.IsForecastedDataGridVisible) seriesXmlWriter.WriteElementString("View", "ForecastedDataGrid");
                    if (annTp.IsActualAndPredictedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualAndPredictedGraph");                    
                    if (annTp.IsActualAndForecastedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualAndForecastedGraph");
                    if (annTp.IsActualVsPredictedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualVsPredictedGraph");
                    if (annTp.IsResidualGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualGraph");
                    if (annTp.IsResidualVsActualGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualVsActualGraph");
                    if (annTp.IsResidualVsPredictedGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualVsPredictedGraph");
                    seriesXmlWriter.WriteFullEndElement();

                }                
                else if (tp is MAResultTabPage)
                {
                    MAResultTabPage maTp = (MAResultTabPage)tp;
                    seriesXmlWriter.WriteElementString("Type", "Moving Average");
                    seriesXmlWriter.WriteElementString("Title", maTp.Title);
                    seriesXmlWriter.WriteElementString("SeriesVariable", maTp.Variable.VariableName);

                    seriesXmlWriter.WriteStartElement("MASpecification");
                    seriesXmlWriter.WriteElementString("includedObservations", maTp.MaProperties.includedObservations.ToString());
                    seriesXmlWriter.WriteElementString("isSingleMA", maTp.MaProperties.isSingleMA.ToString().ToLower());
                    seriesXmlWriter.WriteElementString("orde", maTp.MaProperties.orde.ToString());
                    seriesXmlWriter.WriteElementString("sseMA", maTp.MaProperties.sseMA.ToString());
                    seriesXmlWriter.WriteElementString("mseMA", maTp.MaProperties.mseMA.ToString());
                    seriesXmlWriter.WriteElementString("maeMA", maTp.MaProperties.maeMA.ToString());
                    seriesXmlWriter.WriteElementString("mpeMA", maTp.MaProperties.mpeMA.ToString());
                    seriesXmlWriter.WriteElementString("mapeMA", maTp.MaProperties.mapeMA.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("SingleMA");
                    foreach (double value in maTp.MaTable.singleSmoothed)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    if (maTp.MaProperties.isSingleMA == false)
                    {
                        seriesXmlWriter.WriteStartElement("DoubleMA");
                        foreach (double value in maTp.MaTable.doubleSmoothed)
                            seriesXmlWriter.WriteElementString("Value", value.ToString());
                        seriesXmlWriter.WriteFullEndElement();
                    }

                    seriesXmlWriter.WriteStartElement("Predicted");
                    foreach (double value in maTp.MaTable.predicted)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("Residual");
                    foreach (double value in maTp.MaTable.residual)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    if (maTp.Forecasted != null)
                    {
                        seriesXmlWriter.WriteStartElement("Forecasted");
                        foreach (double value in maTp.Forecasted)
                            seriesXmlWriter.WriteElementString("Value", value.ToString());
                        seriesXmlWriter.WriteFullEndElement();
                    }

                    seriesXmlWriter.WriteStartElement("VisibleView");
                    if (maTp.IsMaModelSummaryVisible) seriesXmlWriter.WriteElementString("View", "MAModelSummary");
                    if (maTp.IsMovingAverageDataGridVisible) seriesXmlWriter.WriteElementString("View", "MovingAverageDataGrid");
                    if (maTp.IsSmoothingVisible) seriesXmlWriter.WriteElementString("View", "Smoothing");
                    //if (maTp.IsActualPredictedResidualDataGridVisible) seriesXmlWriter.WriteElementString("View", "ActualPredictedResidualDataGrid");
                    if (maTp.IsForecastedDataGridVisible) seriesXmlWriter.WriteElementString("View", "ForecastedDataGrid");
                    if (maTp.IsActualAndPredictedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualAndPredictedGraph");
                    if (maTp.IsActualAndSmoothedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualAndSmoothedGraph");                    
                    if (maTp.IsActualAndForecastedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualAndForecastedGraph");
                    if (maTp.IsActualVsPredictedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualVsPredictedGraph");
                    if (maTp.IsResidualGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualGraph");
                    if (maTp.IsResidualVsActualGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualVsActualGraph");
                    if (maTp.IsResidualVsPredictedGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualVsPredictedGraph");
                    seriesXmlWriter.WriteFullEndElement();

                }
                else if (tp is ESResultTabPage)
                {
                    ESResultTabPage esTp = (ESResultTabPage)tp;
                    seriesXmlWriter.WriteElementString("Type", "Exponential Smoothing");
                    seriesXmlWriter.WriteElementString("Title", esTp.Title);
                    seriesXmlWriter.WriteElementString("SeriesVariable", esTp.Variable.VariableName);

                    seriesXmlWriter.WriteStartElement("ESSpecification");
                    seriesXmlWriter.WriteElementString("includedObservations", esTp.EsProperties.includedObservations.ToString());
                    seriesXmlWriter.WriteElementString("alpha", esTp.EsProperties.alpha.ToString());
                    seriesXmlWriter.WriteElementString("gamma", esTp.EsProperties.gamma.ToString());
                    seriesXmlWriter.WriteElementString("beta", esTp.EsProperties.beta.ToString());
                    seriesXmlWriter.WriteElementString("seasonalLength", esTp.EsProperties.seasonalLength.ToString());
                    seriesXmlWriter.WriteElementString("sseES", esTp.EsProperties.sseES.ToString());
                    seriesXmlWriter.WriteElementString("mseES", esTp.EsProperties.mseES.ToString());
                    seriesXmlWriter.WriteElementString("maeES", esTp.EsProperties.maeES.ToString());
                    seriesXmlWriter.WriteElementString("mpeES", esTp.EsProperties.mpeES.ToString());
                    seriesXmlWriter.WriteElementString("mapeES", esTp.EsProperties.mapeES.ToString());
                    seriesXmlWriter.WriteElementString("initialModel", esTp.EsProperties.initialModel.ToString());
                    seriesXmlWriter.WriteElementString("isMultiplicative", esTp.EsProperties.isMultiplicative.ToString().ToLower());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("Smoothed");
                    foreach (double value in esTp.EsTable.smoothed)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    if (esTp.EsProperties.initialModel != 1 && esTp.EsProperties.initialModel != 2)
                    {
                        seriesXmlWriter.WriteStartElement("Trend");
                        foreach (double value in esTp.EsTable.trend)
                            seriesXmlWriter.WriteElementString("Value", value.ToString());
                        seriesXmlWriter.WriteFullEndElement();
                    }

                    if (esTp.EsProperties.initialModel == 4)
                    {
                        seriesXmlWriter.WriteStartElement("Seasonal");
                        foreach (double value in esTp.EsTable.seasonal)
                            seriesXmlWriter.WriteElementString("Value", value.ToString());
                        seriesXmlWriter.WriteFullEndElement();
                    }

                    seriesXmlWriter.WriteStartElement("Predicted");
                    foreach (double value in esTp.EsTable.predicted)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("Residual");
                    foreach (double value in esTp.EsTable.residual)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    if (esTp.Forecasted != null)
                    {
                        seriesXmlWriter.WriteStartElement("Forecasted");
                        foreach (double value in esTp.Forecasted)
                            seriesXmlWriter.WriteElementString("Value", value.ToString());
                        seriesXmlWriter.WriteFullEndElement();
                    }

                    seriesXmlWriter.WriteStartElement("VisibleView");
                    if (esTp.IsEsModelSummaryVisible) seriesXmlWriter.WriteElementString("View", "ESModelSummary");
                    if (esTp.IsExponentialSmoothingDataGridVisible) seriesXmlWriter.WriteElementString("View", "ExponentialSmoothingDataGrid");
                    if (esTp.IsSmoothingVisible) seriesXmlWriter.WriteElementString("View", "Smoothing");
                    if (esTp.IsTrendVisible) seriesXmlWriter.WriteElementString("View", "Trend");
                    if (esTp.IsSeasonalVisible) seriesXmlWriter.WriteElementString("View", "Seasonal");
                    //if (maTp.IsActualPredictedResidualDataGridVisible) seriesXmlWriter.WriteElementString("View", "ActualPredictedResidualDataGrid");
                    if (esTp.IsForecastedDataGridVisible) seriesXmlWriter.WriteElementString("View", "ForecastedDataGrid");
                    if (esTp.IsActualAndPredictedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualAndPredictedGraph");
                    if (esTp.IsActualAndSmoothedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualAndSmoothedGraph");
                    
                    if (esTp.IsActualAndForecastedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualAndForecastedGraph");
                    if (esTp.IsActualVsPredictedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualVsPredictedGraph");
                    if (esTp.IsResidualGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualGraph");
                    if (esTp.IsResidualVsActualGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualVsActualGraph");
                    if (esTp.IsResidualVsPredictedGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualVsPredictedGraph");
                    seriesXmlWriter.WriteFullEndElement();

                }
                else if (tp is DECResultTabPage)
                {
                    DECResultTabPage decTp = (DECResultTabPage)tp;
                    seriesXmlWriter.WriteElementString("Type", "Decomposition");
                    seriesXmlWriter.WriteElementString("Title", decTp.Title);
                    seriesXmlWriter.WriteElementString("SeriesVariable", decTp.Variable.VariableName);

                    seriesXmlWriter.WriteStartElement("DECSpecification");
                    seriesXmlWriter.WriteElementString("includedObservations", decTp.DecProperties.includedObservations.ToString());
                    seriesXmlWriter.WriteElementString("seasonalLength", decTp.DecProperties.seasonalLength.ToString());
                    seriesXmlWriter.WriteElementString("sseDEC", decTp.DecProperties.sseDEC.ToString());
                    seriesXmlWriter.WriteElementString("mseDEC", decTp.DecProperties.mseDEC.ToString());
                    seriesXmlWriter.WriteElementString("maeDEC", decTp.DecProperties.maeDEC.ToString());
                    seriesXmlWriter.WriteElementString("mpeDEC", decTp.DecProperties.mpeDEC.ToString());
                    seriesXmlWriter.WriteElementString("mapeDEC", decTp.DecProperties.mapeDEC.ToString());
                    seriesXmlWriter.WriteElementString("isMultiplicative", decTp.DecProperties.isMultiplikatif.ToString().ToLower());
                    seriesXmlWriter.WriteElementString("initialTrend", decTp.DecProperties.initialTrend.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("Parameters");
                    foreach (double value in decTp.DecProperties.parameters)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("SeasonalIndex");
                    foreach (double value in decTp.DecProperties.seasonalIdx)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("Trend");
                    foreach (double value in decTp.DecTable.trend)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("Detrend");
                    foreach (double value in decTp.DecTable.detrend)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("Seasonal");
                    foreach (double value in decTp.DecTable.seasonal)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("Deseasonal");
                    foreach (double value in decTp.DecTable.deseasonal)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("Predicted");
                    foreach (double value in decTp.DecTable.predicted)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("Residual");
                    foreach (double value in decTp.DecTable.residual)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    if (decTp.Forecasted != null)
                    {
                        seriesXmlWriter.WriteStartElement("Forecasted");
                        foreach (double value in decTp.Forecasted)
                            seriesXmlWriter.WriteElementString("Value", value.ToString());
                        seriesXmlWriter.WriteFullEndElement();
                    }

                    seriesXmlWriter.WriteStartElement("VisibleView");
                    if (decTp.IsDecModelSummaryVisible) seriesXmlWriter.WriteElementString("View", "DECModelSummary");
                    if (decTp.IsDecompositionDataGridVisible) seriesXmlWriter.WriteElementString("View", "DecompositionDataGrid");
                    if (decTp.IsTrendVisible) seriesXmlWriter.WriteElementString("View", "Trend");
                    //if (maTp.IsActualPredictedResidualDataGridVisible) seriesXmlWriter.WriteElementString("View", "ActualPredictedResidualDataGrid");
                    if (decTp.IsDetrendVisible) seriesXmlWriter.WriteElementString("View", "Detrend");
                    if (decTp.IsSeasonalVisible) seriesXmlWriter.WriteElementString("View", "Seasonal");
                    if (decTp.IsDeseasonalVisible) seriesXmlWriter.WriteElementString("View", "Deseasonal");
                    if (decTp.IsForecastedDataGridVisible) seriesXmlWriter.WriteElementString("View", "ForecastedDataGrid");
                    if (decTp.IsActualPredictedAndTrendGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualPredictedAndTrendGraph");                    
                    if (decTp.IsActualAndForecastedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualAndForecastedGraph");
                    if (decTp.IsActualVsPredictedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualVsPredictedGraph");
                    if (decTp.IsResidualGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualGraph");
                    if (decTp.IsResidualVsActualGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualVsActualGraph");
                    if (decTp.IsResidualVsPredictedGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualVsPredictedGraph");
                    if (decTp.IsDetrendGraphVisible) seriesXmlWriter.WriteElementString("View", "DetrendGraph");
                    if (decTp.IsDeseasonalVisible) seriesXmlWriter.WriteElementString("View", "DeseasonalGraph");
                    seriesXmlWriter.WriteFullEndElement();

                }
                else if (tp is TrendAnalysisResultTabPage)
                {
                    TrendAnalysisResultTabPage trendTp = (TrendAnalysisResultTabPage)tp;
                    seriesXmlWriter.WriteElementString("Type", "Trend Analysis");
                    seriesXmlWriter.WriteElementString("Title", trendTp.Title);
                    seriesXmlWriter.WriteElementString("SeriesVariable", trendTp.Variable.VariableName);

                    seriesXmlWriter.WriteStartElement("TrendAnalysisSpecification");
                    seriesXmlWriter.WriteElementString("includedObservations", trendTp.TrendProperties.includedObservations.ToString());
                    seriesXmlWriter.WriteElementString("R", trendTp.TrendProperties.r.ToString());
                    seriesXmlWriter.WriteElementString("RSquare", trendTp.TrendProperties.rSquare.ToString());
                    seriesXmlWriter.WriteElementString("RSquareAdjusted", trendTp.TrendProperties.rSquareAdjusted.ToString());
                    seriesXmlWriter.WriteElementString("sse", trendTp.TrendProperties.sse.ToString());
                    seriesXmlWriter.WriteElementString("mse", trendTp.TrendProperties.mse.ToString());
                    seriesXmlWriter.WriteElementString("initialModel", trendTp.TrendProperties.initialModel.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("Parameters");
                    foreach (double value in trendTp.TrendProperties.parameters)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("Predicted");
                    foreach (double value in trendTp.Predicted)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    seriesXmlWriter.WriteStartElement("Residual");
                    foreach (double value in trendTp.Residual)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();

                    if (trendTp.Forecasted != null)
                    {
                        seriesXmlWriter.WriteStartElement("Forecasted");
                        foreach (double value in trendTp.Forecasted)
                            seriesXmlWriter.WriteElementString("Value", value.ToString());
                        seriesXmlWriter.WriteFullEndElement();
                    }

                    seriesXmlWriter.WriteStartElement("VisibleView");
                    if (trendTp.IsTrendAnalysisModelSummaryVisible) seriesXmlWriter.WriteElementString("View", "TrendAnalysisModelSummary");
                    if (trendTp.IsActualPredictedResidualDataGridVisible) seriesXmlWriter.WriteElementString("View", "ActualPredictedResidualDataGrid");
                    if (trendTp.IsForecastedDataGridVisible) seriesXmlWriter.WriteElementString("View", "ForecastedDataGrid");
                    if (trendTp.IsActualAndPredictedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualAndPredictedGraph");                    
                    if (trendTp.IsActualAndForecastedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualAndForecastedGraph");
                    if (trendTp.IsActualVsPredictedGraphVisible) seriesXmlWriter.WriteElementString("View", "ActualVsPredictedGraph");
                    if (trendTp.IsResidualGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualGraph");
                    if (trendTp.IsResidualVsActualGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualVsActualGraph");
                    if (trendTp.IsResidualVsPredictedGraphVisible) seriesXmlWriter.WriteElementString("View", "ResidualVsPredictedGraph");
                    seriesXmlWriter.WriteFullEndElement();
                }
                else if (tp is CorrelogramResult)
                {
                    CorrelogramResult cTp = (CorrelogramResult)tp;
                    seriesXmlWriter.WriteElementString("Type", "Correlogram");
                    seriesXmlWriter.WriteElementString("Title", cTp.Title);

                    seriesXmlWriter.WriteElementString("Lag", cTp.Lag.ToString());
                    seriesXmlWriter.WriteElementString("WhiteNoise", cTp.WhiteNoiseAcf.ToString().ToLower());

                    seriesXmlWriter.WriteStartElement("Data");
                    foreach (double value in cTp.Data)
                        seriesXmlWriter.WriteElementString("Value", value.ToString());
                    seriesXmlWriter.WriteFullEndElement();
                }
                
                seriesXmlWriter.WriteFullEndElement();  
            }

            seriesXmlWriter.WriteFullEndElement();


            seriesXmlWriter.WriteEndElement();
            seriesXmlWriter.WriteEndDocument();
            seriesXmlWriter.Flush();
        }        

        /// <summary>
        /// Menutup akses ke file
        /// </summary>
        public void CloseFile()
        {
            seriesXmlWriter.Close();
        }
    }
}
