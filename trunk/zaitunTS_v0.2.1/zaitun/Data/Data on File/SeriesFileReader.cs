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
using System.Xml;
using zaitun.GUI;
using System.Windows.Forms;
using zaitun.ExponentialSmoothing;
using zaitun.MatrixVector;
using zaitun.NeuralNetwork;
using zaitun.TrendAnalysis;
using zaitun.MovingAverage;
using zaitun.Decomposition;
using FarsiLibrary.Win;
using zaitun.Correlogram;
using zaitun.LinearRegression;

namespace zaitun.Data
{
    /// <summary>
    /// Kelas untuk membaca file .zft
    /// file .zft ditulis dalam format xml
    /// </summary>
    public class SeriesFileReader
    {
        /// <summary>
        /// Pembaca file xml
        /// </summary>
        private XmlReader seriesDataReader;

        private string filePath;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filePath">path file yang akan dibaca</param>
        public SeriesFileReader(string filePath)
        {
            this.filePath = filePath;
            XmlReaderSettings xmlSetting = new XmlReaderSettings();
            xmlSetting.IgnoreWhitespace = true;
            seriesDataReader = XmlReader.Create(filePath,xmlSetting);
        }

        /// <summary>
        /// Membaca data
        /// </summary>
        /// <returns>Series Data hasil pembacaan</returns>
        public SeriesData ReadData()
        {
            SeriesData tmpData;
            seriesDataReader.ReadToFollowing("SeriesData");
            seriesDataReader.ReadStartElement();
            {
                string seriesName = seriesDataReader.ReadElementContentAsString();
                SeriesData.SeriesFrequency freq = (SeriesData.SeriesFrequency)seriesDataReader.ReadElementContentAsInt();
                DateTime startDate = new DateTime();
                DateTime endDate = new DateTime();
                if (freq != SeriesData.SeriesFrequency.Undated)
                {
                    startDate = XmlConvert.ToDateTime(seriesDataReader.ReadElementContentAsString(), "dd/MM/yyyy");
                    endDate = XmlConvert.ToDateTime(seriesDataReader.ReadElementContentAsString(), "dd/MM/yyyy");
                }
                else
                {
                    seriesDataReader.Skip();
                    seriesDataReader.Skip();
                }
                int numberObservations = seriesDataReader.ReadElementContentAsInt();

                if (freq != SeriesData.SeriesFrequency.Undated)
                    tmpData = new SeriesData(seriesName, freq, startDate, endDate);
                else
                    tmpData = new SeriesData(seriesName, numberObservations);
            }

            seriesDataReader.ReadStartElement();
            while (seriesDataReader.IsStartElement("SeriesVariable"))
            {                
                SeriesVariable tmpVariable;
                seriesDataReader.ReadStartElement();
                {
                    string variableName = seriesDataReader.ReadElementContentAsString();
                    string variableDescription = seriesDataReader.ReadElementContentAsString();
                    tmpVariable = new SeriesVariable(variableName, variableDescription);
                }
                seriesDataReader.ReadStartElement();
                for (int i = 0; i < tmpData.NumberObservations; i++)
                {
                    tmpVariable.SeriesValues.Add(seriesDataReader.ReadElementContentAsDouble());
                }
                seriesDataReader.ReadEndElement();
                tmpData.SeriesVariables.Add(tmpVariable);
                seriesDataReader.ReadEndElement();
            }
            
            seriesDataReader.ReadToFollowing("SeriesGroups");
            seriesDataReader.ReadStartElement();
            while (seriesDataReader.IsStartElement("SeriesGroup"))
            {
                SeriesGroup tmpGroup;
                SeriesVariables tmpGroupList= new SeriesVariables();
                seriesDataReader.ReadStartElement();                
                string groupName = seriesDataReader.ReadElementContentAsString();                                                        
                seriesDataReader.ReadStartElement();
                while (seriesDataReader.IsStartElement("SeriesVariableItem"))
                {
                    SeriesVariable tmpVariableItem;
                    string variableName = seriesDataReader.ReadElementContentAsString();
                    tmpVariableItem = tmpData.SeriesVariables[VariableFinder.FindVariableIndex(tmpData.SeriesVariables, variableName)];
                    tmpGroupList.Add(tmpVariableItem);
                    
                }
                tmpGroup = new SeriesGroup(groupName, tmpGroupList);                
                seriesDataReader.ReadEndElement();
                tmpData.SeriesGroups.Add(tmpGroup);
                seriesDataReader.ReadEndElement();
            }
            seriesDataReader.ReadEndElement();

            if (seriesDataReader.IsStartElement("SeriesStocks"))
            {
                seriesDataReader.ReadStartElement();
                while (seriesDataReader.IsStartElement("SeriesStock"))
                {
                    SeriesStock tmpStock;
                    seriesDataReader.ReadStartElement();
                    string stockName = seriesDataReader.ReadElementContentAsString();
                    string stockDescription = seriesDataReader.ReadElementContentAsString();
                    string openVariableName = seriesDataReader.ReadElementContentAsString();
                    string highVariableName = seriesDataReader.ReadElementContentAsString();
                    string lowVariableName = seriesDataReader.ReadElementContentAsString();
                    string closeVariableName = seriesDataReader.ReadElementContentAsString();
                    string volumeVariableName = seriesDataReader.ReadElementContentAsString();

                    SeriesVariable openVariable = tmpData.SeriesVariables[VariableFinder.FindVariableIndex(tmpData.SeriesVariables, openVariableName)];
                    SeriesVariable highVariable = tmpData.SeriesVariables[VariableFinder.FindVariableIndex(tmpData.SeriesVariables, highVariableName)];
                    SeriesVariable lowVariable = tmpData.SeriesVariables[VariableFinder.FindVariableIndex(tmpData.SeriesVariables, lowVariableName)];
                    SeriesVariable closeVariable = tmpData.SeriesVariables[VariableFinder.FindVariableIndex(tmpData.SeriesVariables, closeVariableName)];
                    SeriesVariable volumeVariable = tmpData.SeriesVariables[VariableFinder.FindVariableIndex(tmpData.SeriesVariables, volumeVariableName)];

                    tmpStock = new SeriesStock(stockName, stockDescription, openVariable, closeVariable, highVariable, lowVariable, volumeVariable);

                    tmpData.SeriesStocks.Add(tmpStock);
                    seriesDataReader.ReadEndElement();
                }
            }
            

            return tmpData;
        }

        /// <summary>
        /// Membaca variabel yang ditampilkan di Variable View
        /// </summary>
        /// <returns>array nama variabel yang ditampilkan di Variable View</returns>
        public string[] ReadViewPane()
        {
            List<string> tempString = new List<string>();
            
            seriesDataReader.ReadToFollowing("ViewPane");
            seriesDataReader.ReadStartElement();
            
            while (seriesDataReader.IsStartElement("TabPage"))
            {
                tempString.Add(seriesDataReader.ReadElementContentAsString());
            }
            
            return tempString.ToArray();
        }

        /// <summary>
        /// Membaca hasil pada Result View
        /// </summary>
        /// <param name="data">Series Data rujukan</param>
        /// <returns>Tab Page yang akan ditampilkan pada Result View</returns>
        public List<FATabStripItem> ReadResultPane(SeriesData data)
        {
            List<FATabStripItem> result = new List<FATabStripItem>();
            string tmpString;

            seriesDataReader.ReadToFollowing("ResultPane");
            seriesDataReader.ReadStartElement();

            while (seriesDataReader.IsStartElement("TabPage"))
            {
                seriesDataReader.ReadStartElement();
                tmpString = seriesDataReader.ReadElementContentAsString();
                if (tmpString == "Neural Network")
                {
                    ANNResultTabPage annTp = new ANNResultTabPage();
                    string title = seriesDataReader.ReadElementContentAsString();
                    tmpString = seriesDataReader.ReadElementContentAsString();                    
                    int index = VariableFinder.FindVariableIndex(data.SeriesVariables, tmpString);                    

                    NeuralNetworkAnalysisForm.NetworkSpecification tmpNetSpec = new NeuralNetworkAnalysisForm.NetworkSpecification();
                    seriesDataReader.ReadStartElement();
                    tmpNetSpec.InputLayerNeurons = seriesDataReader.ReadElementContentAsInt();
                    tmpNetSpec.HiddenLayerNeurons = seriesDataReader.ReadElementContentAsInt();
                    tmpNetSpec.OutputLayerNeurons = seriesDataReader.ReadElementContentAsInt();
                    tmpNetSpec.ActivationFunction = (NeuralNetworkAnalysisForm.ActivationFunctionEnumeration)seriesDataReader.ReadElementContentAsInt();
                    tmpNetSpec.LearningRate = seriesDataReader.ReadElementContentAsDouble();
                    tmpNetSpec.Momentum = seriesDataReader.ReadElementContentAsDouble();
                    tmpNetSpec.IncludedObservations = seriesDataReader.ReadElementContentAsInt();
                    tmpNetSpec.Error = seriesDataReader.ReadElementContentAsDouble();
                    tmpNetSpec.MSE = seriesDataReader.ReadElementContentAsDouble();
                    tmpNetSpec.MAE = seriesDataReader.ReadElementContentAsDouble();
                    seriesDataReader.ReadEndElement();

                    List<double> tmpPredicted = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpPredicted.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();

                    List<double> tmpForecasted = new List<double>();
                    if (seriesDataReader.IsStartElement("Forecasted"))
                    {
                        seriesDataReader.ReadStartElement();
                        while (seriesDataReader.IsStartElement("Value"))
                        {
                            tmpForecasted.Add(seriesDataReader.ReadElementContentAsDouble());
                        }
                        seriesDataReader.ReadEndElement();
                    }

                    annTp.SetData(data, data.SeriesVariables[index], tmpNetSpec, tmpPredicted.ToArray(), tmpForecasted.ToArray());
                    
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("View"))
                    {
                        tmpString = seriesDataReader.ReadElementContentAsString();
                        if (tmpString == "AnnModelSummary") annTp.IsAnnModelSummaryVisible = true;
                        else if (tmpString == "ActualPredictedResidualDataGrid") annTp.IsActualPredictedResidualDataGridVisible = true;
                        else if (tmpString == "ForecastedDataGrid") annTp.IsForecastedDataGridVisible = true;
                        else if (tmpString == "ActualAndPredictedGraph") annTp.IsActualAndPredictedGraphVisible = true;                        
                        else if (tmpString == "ActualAndForecastedGraph") annTp.IsActualAndForecastedGraphVisible = true;
                        else if (tmpString == "ActualVsPredictedGraph") annTp.IsActualVsPredictedGraphVisible = true;
                        else if (tmpString == "ResidualGraph") annTp.IsResidualGraphVisible = true;
                        else if (tmpString == "ResidualVsActualGraph") annTp.IsResidualVsActualGraphVisible = true;
                        else if (tmpString == "ResidualVsPredictedGraph") annTp.IsResidualVsPredictedGraphVisible = true;
                    }
                    seriesDataReader.ReadEndElement();

                    annTp.Title = title;
                    annTp.DrawControl();
                    result.Add(annTp);
                    seriesDataReader.ReadEndElement();
                }                
                else if (tmpString == "Moving Average")
                {
                    MAResultTabPage maTp = new MAResultTabPage();
                    string title = seriesDataReader.ReadElementContentAsString();
                    tmpString = seriesDataReader.ReadElementContentAsString();
                    int index = VariableFinder.FindVariableIndex(data.SeriesVariables, tmpString);

                    MovingAverageForm.MASpecification tmpMaSpec = new MovingAverageForm.MASpecification();
                    seriesDataReader.ReadStartElement();
                    tmpMaSpec.includedObservations = seriesDataReader.ReadElementContentAsInt();
                    tmpMaSpec.isSingleMA = seriesDataReader.ReadElementContentAsBoolean();
                    tmpMaSpec.orde = seriesDataReader.ReadElementContentAsInt();
                    tmpMaSpec.sseMA = seriesDataReader.ReadElementContentAsDouble();
                    tmpMaSpec.mseMA = seriesDataReader.ReadElementContentAsDouble();
                    tmpMaSpec.maeMA = seriesDataReader.ReadElementContentAsDouble();
                    tmpMaSpec.mpeMA = seriesDataReader.ReadElementContentAsDouble();
                    tmpMaSpec.mapeMA = seriesDataReader.ReadElementContentAsDouble();
                    seriesDataReader.ReadEndElement();

                    MovingAverageForm.MAComponent tmpMaComp = new MovingAverageForm.MAComponent();

                    List<double> tmpSingleMA = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpSingleMA.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpMaComp.singleSmoothed = tmpSingleMA.ToArray();

                    List<double> tmpDoubleMA = new List<double>();
                    if (seriesDataReader.IsStartElement("DoubleMA"))
                    {
                        seriesDataReader.ReadStartElement();
                        while (seriesDataReader.IsStartElement("Value"))
                        {
                            tmpDoubleMA.Add(seriesDataReader.ReadElementContentAsDouble());
                        }
                        seriesDataReader.ReadEndElement();
                     tmpMaComp.doubleSmoothed = tmpDoubleMA.ToArray();
                    }

                    List<double> tmpPredicted = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpPredicted.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpMaComp.predicted = tmpPredicted.ToArray();

                    List<double> tmpResidual = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpResidual.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpMaComp.residual = tmpResidual.ToArray();

                    List<double> tmpForecasted = new List<double>();
                    if (seriesDataReader.IsStartElement("Forecasted"))
                    {
                        seriesDataReader.ReadStartElement();
                        while (seriesDataReader.IsStartElement("Value"))
                        {
                            tmpForecasted.Add(seriesDataReader.ReadElementContentAsDouble());
                        }
                        seriesDataReader.ReadEndElement();
                    }

                    maTp.SetData(data, data.SeriesVariables[index], tmpMaSpec, tmpMaComp, tmpForecasted.ToArray());

                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("View"))
                    {
                        tmpString = seriesDataReader.ReadElementContentAsString();
                        if (tmpString == "MAModelSummary") maTp.IsMaModelSummaryVisible = true;
                        else if (tmpString == "MovingAverageDataGrid") maTp.IsMovingAverageDataGridVisible = true;
                        else if (tmpString == "Smoothing") maTp.IsSmoothingVisible = true;
                        //else if (tmpString == "ActualPredictedResidualDataGrid") maTp.IsActualPredictedResidualDataGridVisible = true;
                        else if (tmpString == "ForecastedDataGrid") maTp.IsForecastedDataGridVisible = true;
                        else if (tmpString == "ActualAndPredictedGraph") maTp.IsActualAndPredictedGraphVisible = true;
                        else if (tmpString == "ActualAndSmoothedGraph") maTp.IsActualAndSmoothedGraphVisible = true;                        
                        else if (tmpString == "ActualAndForecastedGraph") maTp.IsActualAndForecastedGraphVisible = true;
                        else if (tmpString == "ActualVsPredictedGraph") maTp.IsActualVsPredictedGraphVisible = true;
                        else if (tmpString == "ResidualGraph") maTp.IsResidualGraphVisible = true;
                        else if (tmpString == "ResidualVsActualGraph") maTp.IsResidualVsActualGraphVisible = true;
                        else if (tmpString == "ResidualVsPredictedGraph") maTp.IsResidualVsPredictedGraphVisible = true;
                    }
                    seriesDataReader.ReadEndElement();

                    maTp.Title = title;
                    maTp.DrawControl();
                    result.Add(maTp);
                    seriesDataReader.ReadEndElement();
                }
                else if (tmpString == "Exponential Smoothing")
                {
                    ESResultTabPage esTp = new ESResultTabPage();
                    string title = seriesDataReader.ReadElementContentAsString();
                    tmpString = seriesDataReader.ReadElementContentAsString();
                    int index = VariableFinder.FindVariableIndex(data.SeriesVariables, tmpString);

                    ExponentialSmoothingForm.ESSpecification tmpEsSpec = new ExponentialSmoothingForm.ESSpecification();
                    seriesDataReader.ReadStartElement();
                    tmpEsSpec.includedObservations = seriesDataReader.ReadElementContentAsInt();
                    tmpEsSpec.alpha = seriesDataReader.ReadElementContentAsDouble();
                    tmpEsSpec.gamma = seriesDataReader.ReadElementContentAsDouble();
                    tmpEsSpec.beta = seriesDataReader.ReadElementContentAsDouble();
                    tmpEsSpec.seasonalLength = seriesDataReader.ReadElementContentAsInt();
                    tmpEsSpec.sseES = seriesDataReader.ReadElementContentAsDouble();
                    tmpEsSpec.mseES = seriesDataReader.ReadElementContentAsDouble();
                    tmpEsSpec.maeES = seriesDataReader.ReadElementContentAsDouble();
                    tmpEsSpec.mpeES = seriesDataReader.ReadElementContentAsDouble();
                    tmpEsSpec.mapeES = seriesDataReader.ReadElementContentAsDouble();
                    tmpEsSpec.initialModel = seriesDataReader.ReadElementContentAsInt();
                    tmpEsSpec.isMultiplicative = seriesDataReader.ReadElementContentAsBoolean();
                    seriesDataReader.ReadEndElement();

                    ExponentialSmoothingForm.ESComponent tmpEsComp = new ExponentialSmoothingForm.ESComponent();

                    List<double> tmpSmoothed = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpSmoothed.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpEsComp.smoothed = tmpSmoothed.ToArray();

                    List<double> tmpTrend = new List<double>();
                    if (seriesDataReader.IsStartElement("Trend"))
                    {
                        seriesDataReader.ReadStartElement();
                        while (seriesDataReader.IsStartElement("Value"))
                        {
                            tmpTrend.Add(seriesDataReader.ReadElementContentAsDouble());
                        }
                        seriesDataReader.ReadEndElement();
                        tmpEsComp.trend = tmpTrend.ToArray();
                    }

                    List<double> tmpSeasonal = new List<double>();
                    if (seriesDataReader.IsStartElement("Seasonal"))
                    {
                        seriesDataReader.ReadStartElement();
                        while (seriesDataReader.IsStartElement("Value"))
                        {
                            tmpSeasonal.Add(seriesDataReader.ReadElementContentAsDouble());
                        }
                        seriesDataReader.ReadEndElement();
                        tmpEsComp.seasonal = tmpSeasonal.ToArray();
                    }

                    List<double> tmpPredicted = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpPredicted.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpEsComp.predicted = tmpPredicted.ToArray();

                    List<double> tmpResidual = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpResidual.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpEsComp.residual = tmpResidual.ToArray();

                    List<double> tmpForecasted = new List<double>();
                    if (seriesDataReader.IsStartElement("Forecasted"))
                    {
                        seriesDataReader.ReadStartElement();
                        while (seriesDataReader.IsStartElement("Value"))
                        {
                            tmpForecasted.Add(seriesDataReader.ReadElementContentAsDouble());
                        }
                        seriesDataReader.ReadEndElement();
                    }

                    esTp.SetData(data, data.SeriesVariables[index], tmpEsSpec, tmpEsComp, tmpForecasted.ToArray());

                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("View"))
                    {
                        tmpString = seriesDataReader.ReadElementContentAsString();
                        if (tmpString == "ESModelSummary") esTp.IsEsModelSummaryVisible = true;
                        else if (tmpString == "ExponentialSmoothingDataGrid") esTp.IsExponentialSmoothingDataGridVisible = true;
                        else if (tmpString == "Smoothing") esTp.IsSmoothingVisible = true;
                        else if (tmpString == "Trend") esTp.IsSmoothingVisible = true;
                        else if (tmpString == "Seasonal") esTp.IsSmoothingVisible = true;
                        //else if (tmpString == "ActualPredictedResidualDataGrid") maTp.IsActualPredictedResidualDataGridVisible = true;
                        else if (tmpString == "ForecastedDataGrid") esTp.IsForecastedDataGridVisible = true;
                        else if (tmpString == "ActualAndPredictedGraph") esTp.IsActualAndPredictedGraphVisible = true;
                        else if (tmpString == "ActualAndSmoothedGraph") esTp.IsActualAndSmoothedGraphVisible = true;                        
                        else if (tmpString == "ActualAndForecastedGraph") esTp.IsActualAndForecastedGraphVisible = true;
                        else if (tmpString == "ActualVsPredictedGraph") esTp.IsActualVsPredictedGraphVisible = true;
                        else if (tmpString == "ResidualGraph") esTp.IsResidualGraphVisible = true;
                        else if (tmpString == "ResidualVsActualGraph") esTp.IsResidualVsActualGraphVisible = true;
                        else if (tmpString == "ResidualVsPredictedGraph") esTp.IsResidualVsPredictedGraphVisible = true;
                    }
                    seriesDataReader.ReadEndElement();

                    esTp.Title = title;
                    esTp.DrawControl();
                    result.Add(esTp);
                    seriesDataReader.ReadEndElement();
                }
                else if (tmpString == "Decomposition")
                {
                    DECResultTabPage decTp = new DECResultTabPage();
                    string title = seriesDataReader.ReadElementContentAsString();
                    tmpString = seriesDataReader.ReadElementContentAsString();
                    int index = VariableFinder.FindVariableIndex(data.SeriesVariables, tmpString);

                    DecompositionForm.DECSpecification tmpDecSpec = new DecompositionForm.DECSpecification();
                    seriesDataReader.ReadStartElement();
                    tmpDecSpec.includedObservations = seriesDataReader.ReadElementContentAsInt();
                    tmpDecSpec.seasonalLength = seriesDataReader.ReadElementContentAsInt();
                    tmpDecSpec.sseDEC = seriesDataReader.ReadElementContentAsDouble();
                    tmpDecSpec.mseDEC = seriesDataReader.ReadElementContentAsDouble();
                    tmpDecSpec.maeDEC = seriesDataReader.ReadElementContentAsDouble();
                    tmpDecSpec.mpeDEC = seriesDataReader.ReadElementContentAsDouble();
                    tmpDecSpec.mapeDEC = seriesDataReader.ReadElementContentAsDouble();
                    tmpDecSpec.isMultiplikatif = seriesDataReader.ReadElementContentAsBoolean();
                    tmpDecSpec.initialTrend = seriesDataReader.ReadElementContentAsInt();
                    seriesDataReader.ReadEndElement();

                    List<double> tmpParameters = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpParameters.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpDecSpec.parameters = tmpParameters.ToArray();

                    List<double> tmpSeasonalIdx = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpSeasonalIdx.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpDecSpec.seasonalIdx = tmpSeasonalIdx.ToArray();

                    DecompositionForm.DECComponent tmpDecComp = new DecompositionForm.DECComponent();

                    List<double> tmpTrend = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpTrend.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpDecComp.trend = tmpTrend.ToArray();

                    List<double> tmpDetrend = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpDetrend.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpDecComp.detrend = tmpDetrend.ToArray();

                    List<double> tmpSeasonal = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpSeasonal.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpDecComp.seasonal = tmpSeasonal.ToArray();

                    List<double> tmpDeseasonal = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpDeseasonal.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpDecComp.deseasonal = tmpDeseasonal.ToArray();

                    List<double> tmpPredicted = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpPredicted.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpDecComp.predicted = tmpPredicted.ToArray();

                    List<double> tmpResidual = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpResidual.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpDecComp.residual = tmpResidual.ToArray();

                    List<double> tmpForecasted = new List<double>();
                    if (seriesDataReader.IsStartElement("Forecasted"))
                    {
                        seriesDataReader.ReadStartElement();
                        while (seriesDataReader.IsStartElement("Value"))
                        {
                            tmpForecasted.Add(seriesDataReader.ReadElementContentAsDouble());
                        }
                        seriesDataReader.ReadEndElement();
                    }

                    decTp.SetData(data, data.SeriesVariables[index], tmpDecSpec, tmpDecComp, tmpForecasted.ToArray());

                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("View"))
                    {
                        tmpString = seriesDataReader.ReadElementContentAsString();
                        if (tmpString == "DECModelSummary") decTp.IsDecModelSummaryVisible = true;
                        else if (tmpString == "DecompositionDataGrid") decTp.IsDecompositionDataGridVisible = true;
                        else if (tmpString == "Trend") decTp.IsTrendVisible = true;
                        else if (tmpString == "Detrend") decTp.IsDetrendVisible = true;
                        else if (tmpString == "Seasonal") decTp.IsSeasonalVisible = true;
                        else if (tmpString == "Deseasonal") decTp.IsDeseasonalVisible = true;
                        //else if (tmpString == "ActualPredictedResidualDataGrid") maTp.IsActualPredictedResidualDataGridVisible = true;
                        else if (tmpString == "ForecastedDataGrid") decTp.IsForecastedDataGridVisible = true;
                        else if (tmpString == "ActualPredictedAndTrendGraph") decTp.IsActualPredictedAndTrendGraphVisible = true;                        
                        else if (tmpString == "ActualAndForecastedGraph") decTp.IsActualAndForecastedGraphVisible = true;
                        else if (tmpString == "ActualVsPredictedGraph") decTp.IsActualVsPredictedGraphVisible = true;
                        else if (tmpString == "ResidualGraph") decTp.IsResidualGraphVisible = true;
                        else if (tmpString == "ResidualVsActualGraph") decTp.IsResidualVsActualGraphVisible = true;
                        else if (tmpString == "ResidualVsPredictedGraph") decTp.IsResidualVsPredictedGraphVisible = true;
                        else if (tmpString == "DetrendGraph") decTp.IsDetrendGraphVisible = true;
                        else if (tmpString == "DeseasonalGraph") decTp.IsDeseasonalGraphVisible = true;
                    }
                    seriesDataReader.ReadEndElement();

                    decTp.Title = title;
                    decTp.DrawControl();
                    result.Add(decTp);
                    seriesDataReader.ReadEndElement();
                }
                else if (tmpString == "Trend Analysis")
                {
                    TrendAnalysisResultTabPage trendTp = new TrendAnalysisResultTabPage();
                    string title = seriesDataReader.ReadElementContentAsString();
                    tmpString = seriesDataReader.ReadElementContentAsString();
                    int index = VariableFinder.FindVariableIndex(data.SeriesVariables, tmpString);

                    TrendAnalysisForm.TrendSpecification tmpTrendSpec = new TrendAnalysisForm.TrendSpecification();
                    seriesDataReader.ReadStartElement();
                    tmpTrendSpec.includedObservations = seriesDataReader.ReadElementContentAsInt();
                    tmpTrendSpec.r = seriesDataReader.ReadElementContentAsDouble();
                    tmpTrendSpec.rSquare = seriesDataReader.ReadElementContentAsDouble();
                    tmpTrendSpec.rSquareAdjusted = seriesDataReader.ReadElementContentAsDouble();
                    tmpTrendSpec.sse = seriesDataReader.ReadElementContentAsDouble();
                    tmpTrendSpec.mse = seriesDataReader.ReadElementContentAsDouble();
                    tmpTrendSpec.initialModel = seriesDataReader.ReadElementContentAsInt();
                    seriesDataReader.ReadEndElement();

                    List<double> tmpParameters = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpParameters.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();
                    tmpTrendSpec.parameters = tmpParameters.ToArray();

                    List<double> tmpPredicted = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpPredicted.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();

                    List<double> tmpResidual = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpResidual.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();

                    List<double> tmpForecasted = new List<double>();
                    if (seriesDataReader.IsStartElement("Forecasted"))
                    {
                        seriesDataReader.ReadStartElement();
                        while (seriesDataReader.IsStartElement("Value"))
                        {
                            tmpForecasted.Add(seriesDataReader.ReadElementContentAsDouble());
                        }
                        seriesDataReader.ReadEndElement();
                    }

                    trendTp.SetData(data, data.SeriesVariables[index], tmpTrendSpec, tmpPredicted.ToArray(), tmpForecasted.ToArray(), tmpResidual.ToArray());

                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("View"))
                    {
                        tmpString = seriesDataReader.ReadElementContentAsString();
                        if (tmpString == "TrendAnalysisModelSummary") trendTp.IsTrendAnalysisModelSummaryVisible = true;
                        else if (tmpString == "ActualPredictedResidualDataGrid") trendTp.IsActualPredictedResidualDataGridVisible = true;
                        else if (tmpString == "ForecastedDataGrid") trendTp.IsForecastedDataGridVisible = true;
                        else if (tmpString == "ActualAndPredictedGraph") trendTp.IsActualAndPredictedGraphVisible = true;
                        else if (tmpString == "ActualAndForecastedGraph") trendTp.IsActualAndForecastedGraphVisible = true;
                        else if (tmpString == "ActualVsPredictedGraph") trendTp.IsActualVsPredictedGraphVisible = true;
                        else if (tmpString == "ResidualGraph") trendTp.IsResidualGraphVisible = true;
                        else if (tmpString == "ResidualVsActualGraph") trendTp.IsResidualVsActualGraphVisible = true;
                        else if (tmpString == "ResidualVsPredictedGraph") trendTp.IsResidualVsPredictedGraphVisible = true;
                    }
                    seriesDataReader.ReadEndElement();

                    trendTp.Title = title;
                    trendTp.DrawControl();
                    result.Add(trendTp);
                    seriesDataReader.ReadEndElement();
                }
                else if (tmpString == "Correlogram")
                {
                    CorrelogramResult cTp = new CorrelogramResult();
                    string title = seriesDataReader.ReadElementContentAsString();
                    
                    //string lag = seriesDataReader.ReadContentAsString();
                    int lag = seriesDataReader.ReadElementContentAsInt();
                    bool whiteNoise = seriesDataReader.ReadElementContentAsBoolean();

                    //seriesDataReader.ReadStartElement();
                    //string lag = seriesDataReader.ReadElementContentAsString();

                    List<double> tmpData = new List<double>();
                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        tmpData.Add(seriesDataReader.ReadElementContentAsDouble());
                    }
                    seriesDataReader.ReadEndElement();

                    cTp.SetData(tmpData.ToArray(), lag, whiteNoise);
                    cTp.DisplayResult();
                    cTp.Title = title;
                    result.Add(cTp);
                    seriesDataReader.ReadEndElement();

                }
                else if (tmpString == "Linear Regression")
                {
                    LRResultTabPage tp = new LRResultTabPage();
                    string title = seriesDataReader.ReadElementContentAsString();
                    tmpString = seriesDataReader.ReadElementContentAsString();
                    int index = VariableFinder.FindVariableIndex(data.SeriesVariables, tmpString);
                    SeriesVariable dependentVariable = data.SeriesVariables[index];
                    SeriesVariables independentVariables = new SeriesVariables();

                    seriesDataReader.ReadStartElement();
                    while (seriesDataReader.IsStartElement("Variable"))
                    {
                        tmpString = seriesDataReader.ReadElementContentAsString();
                        index = VariableFinder.FindVariableIndex(data.SeriesVariables, tmpString);
                        SeriesVariable var = data.SeriesVariables[index];
                        independentVariables.Add(var);
                    }
                    seriesDataReader.ReadEndElement();

                    tp.IsDurbinWatsonVisible = seriesDataReader.ReadElementContentAsBoolean();
                    tp.IsPartialCorrelationVisible = seriesDataReader.ReadElementContentAsBoolean();
                    tp.IsVIFForPredictorsVisible = seriesDataReader.ReadElementContentAsBoolean();
                    tp.IsConfidenceIntervalForParametersVisible = seriesDataReader.ReadElementContentAsBoolean();

                    seriesDataReader.ReadStartElement();
                    LinearRegressionAnalysisForm.LRSpecification lrProperties = new LinearRegressionAnalysisForm.LRSpecification();
                    lrProperties.IncludedObservations = seriesDataReader.ReadElementContentAsInt();
                    lrProperties.IsMultiple = seriesDataReader.ReadElementContentAsBoolean();
                    lrProperties.R = seriesDataReader.ReadElementContentAsDouble();
                    lrProperties.RSquare = seriesDataReader.ReadElementContentAsDouble();
                    lrProperties.AdjRSquare = seriesDataReader.ReadElementContentAsDouble();
                    lrProperties.StandardError = seriesDataReader.ReadElementContentAsDouble();
                    lrProperties.DurbinWatson = seriesDataReader.ReadElementContentAsDouble();
                    lrProperties.F = seriesDataReader.ReadElementContentAsDouble();
                    lrProperties.SigOfF = seriesDataReader.ReadElementContentAsDouble();
                    lrProperties.SSE = seriesDataReader.ReadElementContentAsDouble();
                    lrProperties.SSR = seriesDataReader.ReadElementContentAsDouble();
                    lrProperties.SST = seriesDataReader.ReadElementContentAsDouble();
                    lrProperties.MSE = seriesDataReader.ReadElementContentAsDouble();
                    lrProperties.MSR = seriesDataReader.ReadElementContentAsDouble();
                    seriesDataReader.ReadStartElement();
                    List<double> parameters = new List<double>();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        double val = seriesDataReader.ReadElementContentAsDouble();
                        parameters.Add(val);
                    }
                    lrProperties.Parameters = parameters.ToArray();
                    seriesDataReader.ReadEndElement();
                    seriesDataReader.ReadStartElement();
                    List<double> standardErrorOfParameters = new List<double>();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        double val = seriesDataReader.ReadElementContentAsDouble();
                        standardErrorOfParameters.Add(val);
                    }
                    lrProperties.StandardErrorOfParameters = standardErrorOfParameters.ToArray();
                    seriesDataReader.ReadEndElement();
                    seriesDataReader.ReadStartElement();
                    List<double> t = new List<double>();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        double val = seriesDataReader.ReadElementContentAsDouble();
                        t.Add(val);
                    }
                    lrProperties.t = t.ToArray();
                    seriesDataReader.ReadEndElement();
                    seriesDataReader.ReadStartElement();
                    List<double> sigOfT = new List<double>();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        double val = seriesDataReader.ReadElementContentAsDouble();
                        sigOfT.Add(val);
                    }
                    lrProperties.SigOfT = sigOfT.ToArray();
                    seriesDataReader.ReadEndElement();
                    seriesDataReader.ReadStartElement();
                    List<double> lowerBoundForParameters = new List<double>();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        double val = seriesDataReader.ReadElementContentAsDouble();
                        lowerBoundForParameters.Add(val);
                    }
                    lrProperties.LowerBoundForParameters = lowerBoundForParameters.ToArray();
                    seriesDataReader.ReadEndElement();
                    seriesDataReader.ReadStartElement();
                    List<double> upperBoundForParameters = new List<double>();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        double val = seriesDataReader.ReadElementContentAsDouble();
                        upperBoundForParameters.Add(val);
                    }
                    lrProperties.UpperBoundForParameters = upperBoundForParameters.ToArray();
                    seriesDataReader.ReadEndElement();
                    seriesDataReader.ReadStartElement();
                    List<double> vifForpredictors = new List<double>();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        double val = seriesDataReader.ReadElementContentAsDouble();
                        vifForpredictors.Add(val);
                    }
                    lrProperties.VIFForpredictors = vifForpredictors.ToArray();
                    seriesDataReader.ReadEndElement();
                    seriesDataReader.ReadStartElement();
                    List<double> correlations = new List<double>();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        double val = seriesDataReader.ReadElementContentAsDouble();
                        correlations.Add(val);
                    }
                    lrProperties.Correlations = correlations.ToArray();
                    seriesDataReader.ReadEndElement();
                    seriesDataReader.ReadStartElement();
                    List<double> partialCorrelations = new List<double>();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        double val = seriesDataReader.ReadElementContentAsDouble();
                        partialCorrelations.Add(val);
                    }
                    lrProperties.PartialCorrelations = partialCorrelations.ToArray();
                    seriesDataReader.ReadEndElement();
                    seriesDataReader.ReadEndElement();

                    seriesDataReader.ReadStartElement();
                    LinearRegressionAnalysisForm.LRComponent lrTable = new LinearRegressionAnalysisForm.LRComponent();
                    seriesDataReader.ReadStartElement();
                    List<double> actual = new List<double>();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        double val = seriesDataReader.ReadElementContentAsDouble();
                        actual.Add(val);
                    }
                    lrTable.Actual = actual.ToArray();
                    seriesDataReader.ReadEndElement();
                    seriesDataReader.ReadStartElement();
                    List<double> predicted = new List<double>();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        double val = seriesDataReader.ReadElementContentAsDouble();
                        predicted.Add(val);
                    }
                    lrTable.Predicted = predicted.ToArray();
                    seriesDataReader.ReadEndElement();
                    seriesDataReader.ReadStartElement();
                    List<double> residual = new List<double>();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        double val = seriesDataReader.ReadElementContentAsDouble();
                        residual.Add(val);
                    }
                    lrTable.Residual = residual.ToArray();
                    seriesDataReader.ReadEndElement();
                    seriesDataReader.ReadStartElement();
                    List<double> expectedResidual = new List<double>();
                    while (seriesDataReader.IsStartElement("Value"))
                    {
                        double val = seriesDataReader.ReadElementContentAsDouble();
                        expectedResidual.Add(val);
                    }
                    lrTable.ExpectedResidual = expectedResidual.ToArray();
                    seriesDataReader.ReadEndElement();
                    seriesDataReader.ReadEndElement();

                    double[,] testValues = null;
                    double[] forcasted = null;
                    string[] time = null;
                    if (seriesDataReader.IsStartElement("LRForcasting"))
                    {
                        seriesDataReader.ReadStartElement();
                        int forcastingStep = seriesDataReader.ReadElementContentAsInt();
                        testValues = new double[independentVariables.Count, forcastingStep];
                        seriesDataReader.ReadStartElement();
                        for (int i = 0; i < independentVariables.Count; i++)
                        {
                            seriesDataReader.ReadStartElement();
                            for (int j = 0; j < forcastingStep; j++)
                            {
                                testValues[i, j] = seriesDataReader.ReadElementContentAsDouble();
                            }
                            seriesDataReader.ReadEndElement();
                        }
                        seriesDataReader.ReadEndElement();

                        seriesDataReader.ReadStartElement();
                        seriesDataReader.ReadStartElement();
                        forcasted = new double[forcastingStep];
                        for (int i = 0; i < forcastingStep; i++)
                        {
                            forcasted[i] = seriesDataReader.ReadElementContentAsDouble();
                        }
                        seriesDataReader.ReadEndElement();
                        seriesDataReader.ReadEndElement();

                        seriesDataReader.ReadStartElement();
                        time = new string[forcastingStep];
                        for (int i = 0; i < forcastingStep; i++)
                        {
                            time[i] = seriesDataReader.ReadElementContentAsString();
                        }
                        seriesDataReader.ReadEndElement();
                        seriesDataReader.ReadEndElement();
                    }
                    if (seriesDataReader.IsStartElement("VisibleView"))
                    {
                        seriesDataReader.ReadStartElement();
                        while (seriesDataReader.IsStartElement("View"))
                        {
                            tmpString = seriesDataReader.ReadElementContentAsString();
                            if (tmpString == "LRAnova") tp.IsAnovaTableVisible = true;
                            else if (tmpString == "LRCoefficients") tp.IsCoefficientTableVisible = true;
                            else if (tmpString == "LRActualPredictedResidual") tp.IsDataTableVisible = true;
                            else if (tmpString == "Forcasted") tp.IsForcastedTableVisible = true;
                            else if (tmpString == "LRResidualGraph") tp.IsResidualGraphVisible = true;
                            else if (tmpString == "LRResidualVsPredictedGraph") tp.IsResidualVsPredictedGraphVisible = true;
                            else if (tmpString == "LRNormalProbabilityPlot") tp.IsNormalProbabilityPlotVisible = true;
                        }
                    }
                    seriesDataReader.ReadEndElement();
                    tp.Title = title;
                    tp.SetData(data, dependentVariable, independentVariables,
                        lrProperties, lrTable, testValues, time, forcasted);
                    tp.DrawControl();
                    result.Add(tp);
                    seriesDataReader.ReadEndElement();
                }
                
            }

            seriesDataReader.ReadEndElement();

            return result;
        }

        /// <summary>
        /// Menutup koneksi ke file
        /// </summary>
        public void CloseFile()
        {
            seriesDataReader.Close();
        }
    }
}
