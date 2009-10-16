using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using zaitun.GUI;
using zaitun.Data;
using zaitun.ExponentialSmoothing;

namespace zaitun.ExponentialSmoothing
{
    public partial class ESModelSummary : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;
        private ExponentialSmoothingForm.ESSpecification esProperties;
        
        public ESModelSummary()
        {
            InitializeComponent();
            grdModelSummary.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;            
        }

        public void SetData(SeriesData data, SeriesVariable variable, ExponentialSmoothingForm.ESSpecification esProperties)
        {
            this.data = data;
            this.variable = variable;
            this.esProperties = esProperties;
            this.lblVariable.Text = variable.VariableName;            
            this.update();
        }

        private void update()
        {
            int i = 0;
            switch (esProperties.initialModel)
            {
                case 1:
                    {
                        grdModelSummary.RowCount = 12;
                        grdModelSummary.Rows[0].HeaderCell.Value = "Variable";
                        grdModelSummary.Rows[0].Cells[0].Value = this.variable.VariableName;
                        grdModelSummary.Rows[1].HeaderCell.Value = "Included Observation";
                        grdModelSummary.Rows[1].Cells[0].Value = this.esProperties.includedObservations;

                        grdModelSummary.Rows[3].HeaderCell.Value = "Smoothing Constant";
                        grdModelSummary.Rows[4].HeaderCell.Value = "Alpha (for data)";
                        grdModelSummary.Rows[4].Cells[0].Value = this.esProperties.alpha.ToString("F3");
                        i = 6;
                        break;
                    }
                case 2:
                    {
                        grdModelSummary.RowCount = 12;
                        grdModelSummary.Rows[0].HeaderCell.Value = "Variable";
                        grdModelSummary.Rows[0].Cells[0].Value = this.variable.VariableName;
                        grdModelSummary.Rows[1].HeaderCell.Value = "Included Observation";
                        grdModelSummary.Rows[1].Cells[0].Value = this.esProperties.includedObservations;

                        grdModelSummary.Rows[3].HeaderCell.Value = "Smoothing Constant";
                        grdModelSummary.Rows[4].HeaderCell.Value = "Alpha (for data)";
                        grdModelSummary.Rows[4].Cells[0].Value = this.esProperties.alpha.ToString("F3");
                        i = 6;
                        break;
                    }
                case 3:
                    {
                        grdModelSummary.RowCount = 13;
                        grdModelSummary.Rows[0].HeaderCell.Value = "Variable";
                        grdModelSummary.Rows[0].Cells[0].Value = this.variable.VariableName;
                        grdModelSummary.Rows[1].HeaderCell.Value = "Included Observation";
                        grdModelSummary.Rows[1].Cells[0].Value = this.esProperties.includedObservations;

                        grdModelSummary.Rows[3].HeaderCell.Value = "Smoothing Constant";
                        grdModelSummary.Rows[4].HeaderCell.Value = "Alpha (for data)";
                        grdModelSummary.Rows[4].Cells[0].Value = this.esProperties.alpha.ToString("F3");
                        grdModelSummary.Rows[5].HeaderCell.Value = "Gamma (for trend)";
                        grdModelSummary.Rows[5].Cells[0].Value = this.esProperties.gamma.ToString("F3");
                        i = 7;
                        break;
                    }
                case 4:
                    {
                        grdModelSummary.RowCount = 16;
                        grdModelSummary.Rows[0].HeaderCell.Value = "Variable";
                        grdModelSummary.Rows[0].Cells[0].Value = this.variable.VariableName;
                        grdModelSummary.Rows[1].HeaderCell.Value = "Model Type";
                        if (this.esProperties.isMultiplicative)
                            grdModelSummary.Rows[1].Cells[0].Value = "Multiplicative";
                        else
                            grdModelSummary.Rows[1].Cells[0].Value = "Additive";

                        grdModelSummary.Rows[2].HeaderCell.Value = "Included Observation";
                        grdModelSummary.Rows[2].Cells[0].Value = this.esProperties.includedObservations;
                        grdModelSummary.Rows[3].HeaderCell.Value = "Seasonal Length";
                        grdModelSummary.Rows[3].Cells[0].Value = this.esProperties.seasonalLength;

                        grdModelSummary.Rows[5].HeaderCell.Value = "Smoothing Constant";
                        grdModelSummary.Rows[6].HeaderCell.Value = "Alpha (for data)";
                        grdModelSummary.Rows[6].Cells[0].Value = this.esProperties.alpha.ToString("F3");
                        grdModelSummary.Rows[7].HeaderCell.Value = "Gamma (for trend)";
                        grdModelSummary.Rows[7].Cells[0].Value = this.esProperties.gamma.ToString("F3");
                        grdModelSummary.Rows[8].HeaderCell.Value = "Beta (for seasonal)";
                        grdModelSummary.Rows[8].Cells[0].Value = this.esProperties.beta.ToString("F3");
                        i = 10;
                        break;
                    }
            }

            grdModelSummary.Rows[i].HeaderCell.Value = "Accuracy Measures";

            grdModelSummary.Rows[i + 1].HeaderCell.Value = "Mean Absolute Error (MAE)";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.esProperties.maeES.ToString("F6");
            i++;
            grdModelSummary.Rows[i + 1].HeaderCell.Value = "Sum Square Error (SSE)";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.esProperties.sseES.ToString("F6");
            i++;
            grdModelSummary.Rows[i + 1].HeaderCell.Value = "Mean Squared Error (MSE)";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.esProperties.mseES.ToString("F6");
            i++;
            grdModelSummary.Rows[i + 1].HeaderCell.Value = "Mean Percentage Error (MPE)";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.esProperties.mpeES.ToString("F6");
            i++;
            grdModelSummary.Rows[i + 1].HeaderCell.Value = "Mean Absolute Percentage Error (MAPE)";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.esProperties.mapeES.ToString("F6");
        }     
    }
}
