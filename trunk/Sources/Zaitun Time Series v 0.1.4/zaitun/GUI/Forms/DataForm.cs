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
using zaitun.Data;
using zaitun.ExponentialSmoothing;
using System.IO;
using zaitun.NeuralNetwork;
using zaitun.TrendAnalysis;
using zaitun.MovingAverage;
using zaitun.Decomposition;
using zaitun.Correlogram;
using FarsiLibrary.Win;

namespace zaitun.GUI
{
    public delegate void SaveAsEventHandler(object sender, System.EventArgs e);

    public partial class DataForm : Form
    {
        private SeriesData data;
        private string filePath = "";
        private SeriesDataPrinter printer;

        private bool isCurrentSaved = true;

        public event SaveAsEventHandler saveAsEvent;

        public string FilePath
        {
            get { return this.filePath; }
        }

        public DataForm()
        {
            InitializeComponent();
        }

        public bool CrateNewData()
        {
            bool success = false;

            zaitun.GUI.CreateNewProject ser = new zaitun.GUI.CreateNewProject();
            ser.ShowDialog();
            if (ser.DialogResult == DialogResult.OK)
            {
                if (ser.Frequency != SeriesData.SeriesFrequency.Undated)
                    data = new SeriesData(ser.DataName, ser.Frequency, ser.StartDate, ser.EndDate);
                else
                    data = new SeriesData(ser.DataName, ser.NumberObservations);

                seriesDataList.SetData(this.data.SeriesVariables, this.data.SeriesGroups);
                this.variableViewPane.SetData(this.data);
                this.Text = ser.DataName + " : \"Unsaved\"";
                this.initializeData();

                this.printer = new SeriesDataPrinter(this.data);

                data.Changed += new ChangedEventHandler(OnChanged);
                this.variableViewPane.Changed += new ChangedEventHandler(OnChanged);
                this.tabControlResult.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.tabControlResult_ControlAdded);
                this.tabControlResult.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tabControlResult_ControlRemoved);
                isCurrentSaved = false;

                success = true;
            }
            return success;
        }

        public bool OpenFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            bool success = false;

            dlg.Title = "Open Series Data....";
            dlg.DefaultExt = ".zft";
            dlg.Filter = "zaitun Files (*.zft)|*.zft";
            //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //dlg.InitialDirectory = @"D:\";
            dlg.RestoreDirectory = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SeriesFileReader file = new SeriesFileReader(dlg.FileName);
                try
                {
                    this.data = file.ReadData();

                    seriesDataList.SetData(this.data.SeriesVariables, this.data.SeriesGroups);
                    this.variableViewPane.SetData(this.data);
                    this.Text = this.data.SeriesName + " : \"" + dlg.FileName + "\"";

                    string[] tabPageList = file.ReadViewPane();
                    foreach (string item in tabPageList)
                    {
                        this.variableViewPane.AddTabPage(item);
                    }

                    List<FATabStripItem> tmpTabPages = file.ReadResultPane(this.data);
                    foreach (FATabStripItem tp in tmpTabPages)
                    {
                        tp.IsDrawn = true;
                        this.tabControlResult.AddTab(tp);
                    }

                    success = true;
                    this.filePath = dlg.FileName;

                    this.initializeData();

                    this.printer = new SeriesDataPrinter(this.data);

                    data.Changed += new ChangedEventHandler(OnChanged);
                    this.variableViewPane.Changed += new ChangedEventHandler(OnChanged);
                    this.tabControlResult.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.tabControlResult_ControlAdded);
                    this.tabControlResult.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tabControlResult_ControlRemoved);
                }
                catch
                {
                    MessageBox.Show("File contains incorrect format", "Can't open file", MessageBoxButtons.OK);
                    success = false;
                }
                finally
                {
                    file.CloseFile();
                }
            }
            return success;
        }

        public bool OpenFile(string filePath)
        {
            bool success = false;
            if (File.Exists(filePath))
            {
                SeriesFileReader file = new SeriesFileReader(filePath);
                try
                {
                    this.data = file.ReadData();

                    seriesDataList.SetData(this.data.SeriesVariables, this.data.SeriesGroups);
                    this.variableViewPane.SetData(this.data);
                    this.Text = this.data.SeriesName + " : \"" + filePath + "\"";

                    string[] tabPageList = file.ReadViewPane();
                    foreach (string item in tabPageList)
                    {
                        this.variableViewPane.AddTabPage(item);
                    }

                    List<FATabStripItem> tmpTabPages = file.ReadResultPane(this.data);
                    foreach (FATabStripItem tp in tmpTabPages)
                    {
                        tp.IsDrawn = true;
                        this.tabControlResult.AddTab(tp);
                    }

                    success = true;
                    this.filePath = filePath;

                    this.initializeData();

                    this.printer = new SeriesDataPrinter(this.data);

                    data.Changed += new ChangedEventHandler(OnChanged);
                    this.variableViewPane.Changed += new ChangedEventHandler(OnChanged);
                    this.tabControlResult.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.tabControlResult_ControlAdded);
                    this.tabControlResult.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tabControlResult_ControlRemoved);
                }
                catch
                {
                    MessageBox.Show("File contains incorrect format", "Can't open file", MessageBoxButtons.OK);
                    success = false;
                }
                finally
                {
                    file.CloseFile();
                }
            }
            else
            {
                MessageBox.Show("File doesn't exist");
                success = false;
            }

            return success;
        }

        public bool ImportFromCSV()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            bool success = false;

            dlg.Title = "Import Data from CSV File";
            dlg.DefaultExt = ".csv";
            dlg.Filter = "Comma Separated File (*.csv)|*.csv";
            dlg.RestoreDirectory = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImportCSVDialog import = new ImportCSVDialog();
                try
                {
                    import.SetFilePath(dlg.FileName);
                    import.SetData(this.data);
                    import.ShowDialog();
                }
                catch (IOException)
                {
                    MessageBox.Show("Cannot access the file because it is being used by another process.", "Import form CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Import form CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }
                if (import.DialogResult == DialogResult.OK)
                {
                    int i = 0;
                    try
                    {
                        for (i = 0; i < import.SelectedVariables.Count; i++)
                        {
                            this.data.SeriesVariables.Add(import.SelectedVariables[i]);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Duplicate Variable Name '" + import.SelectedVariables[i].VariableName + "'", "Import form CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        success = false;
                    }
                }
            }

            return success;
        }

        public bool ImportFromExcel()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            bool success = false;

            dlg.Title = "Import Data from Excel File....";
            dlg.DefaultExt = ".xls";
            dlg.Filter = "Excel Files (*.xls)|*.xls";
            dlg.RestoreDirectory = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImportExcelDialog import = new ImportExcelDialog();
                try
                {
                    import.SetFilePath(dlg.FileName);
                    import.SetData(this.data);
                    import.ShowDialog();
                }
                catch (IOException)
                {
                    MessageBox.Show("Cannot access the file because it is being used by another process.", "Import form Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Import form Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }

                if (import.DialogResult == DialogResult.OK)
                {
                    int i = 0;
                    try
                    {
                        for (i = 0; i < import.SelectedVariables.Count; i++)
                        {
                            this.data.SeriesVariables.Add(import.SelectedVariables[i]);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Duplicate Variable Name '" + import.SelectedVariables[i].VariableName + "'", "Import form Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        success = false;
                    }
                }
            }

            return success;
        }

        private void initializeData()
        {
            this.nameLabel.Text = this.data.SeriesName;
            this.frequencyLabel.Text = this.data.Frequency.ToString();
            this.observationLabel.Text = this.data.NumberObservations.ToString();

            switch (this.data.Frequency)
            {
                case SeriesData.SeriesFrequency.Undated:
                    this.startPeriodeLabel.Text = "1";
                    this.endPeriodeLabel.Text = this.data.NumberObservations.ToString();
                    break;
                case SeriesData.SeriesFrequency.Annual:
                    this.startPeriodeLabel.Text = this.data.StartDate.Year.ToString();
                    this.endPeriodeLabel.Text = this.data.EndDate.Year.ToString();
                    break;
                case SeriesData.SeriesFrequency.SemiAnnual:
                    this.startPeriodeLabel.Text = this.data.StartDate.Year.ToString() + ":" + (this.data.StartDate.Month / 6).ToString();
                    this.endPeriodeLabel.Text = this.data.EndDate.Year.ToString() + ":" + (this.data.EndDate.Month / 6).ToString();
                    break;
                case SeriesData.SeriesFrequency.Quarterly:
                    this.startPeriodeLabel.Text = this.data.StartDate.Year.ToString() + ":" + (this.data.StartDate.Month / 3).ToString();
                    this.endPeriodeLabel.Text = this.data.EndDate.Year.ToString() + ":" + (this.data.EndDate.Month / 3).ToString();
                    break;
                case SeriesData.SeriesFrequency.Monthly:
                    this.startPeriodeLabel.Text = this.data.StartDate.Year.ToString() + ":" + this.data.StartDate.Month.ToString();
                    this.endPeriodeLabel.Text = this.data.EndDate.Year.ToString() + ":" + this.data.EndDate.Month.ToString();
                    break;
                default:
                    this.startPeriodeLabel.Text = this.data.StartDate.ToString("yy/MM/dd");
                    this.endPeriodeLabel.Text = this.data.EndDate.ToString("yy/MM/dd");
                    break;



            }

        }

        public bool SaveAsToFile()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            bool success = false;

            dlg.Title = "Save Series Data As....";
            dlg.DefaultExt = ".zft";
            dlg.Filter = "zaitun Files (*.zft)|*.zft";
            //dlg.InitialDirectory = @"D:\";
            dlg.RestoreDirectory = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SeriesFileWriter file = new SeriesFileWriter(dlg.FileName);
                try
                {
                    file.WriteData(this.data);
                    file.WriteViewPane(this.variableViewPane);
                    file.WriteResultPane(this.tabControlResult.Items);
                    success = true;
                    this.filePath = dlg.FileName;
                    this.Text = this.data.SeriesName + " : \"" + dlg.FileName + "\"";

                    this.isCurrentSaved = true;

                    //fire event
                    if (saveAsEvent != null)
                    {
                        saveAsEvent(this, System.EventArgs.Empty);
                    }
                }
                catch
                {
                    MessageBox.Show("Can't write file");
                    success = false;
                }
                finally
                {
                    file.CloseFile();
                }
            }
            return success;
        }

        public bool SaveToFile()
        {
            bool success = false;

            if (filePath == "")
            {
                this.SaveAsToFile();
            }
            else
            {
                SeriesFileWriter file = new SeriesFileWriter(this.filePath);
                try
                {
                    file.WriteData(this.data);
                    file.WriteViewPane(this.variableViewPane);
                    file.WriteResultPane(this.tabControlResult.Items);

                    this.isCurrentSaved = true;

                    success = true;
                }
                catch
                {
                    MessageBox.Show("Can't write file");
                    success = false;
                }
                finally
                {
                    file.CloseFile();
                }

            }

            return success;
        }

        public bool ExportToCSV()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            bool success = false;

            dlg.Title = "Export Series Data To...";
            dlg.DefaultExt = ".csv";
            dlg.Filter = "Comma Separated File (*.csv)|*.csv";
            //dlg.InitialDirectory = @"D:\";
            dlg.RestoreDirectory = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CSVWriter file = new CSVWriter(dlg.FileName);
                try
                {
                    file.WriteData(this.data);
                    success = true;
                }
                catch
                {
                    MessageBox.Show("I/O Write Error");
                    success = false;
                }
            }
            return success;
        }

        public bool ExportToExcel()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            bool success = false;

            dlg.Title = "Export Series Data To...";
            dlg.DefaultExt = ".xls";
            dlg.Filter = "Excel File (*.xls)|*.xls";
            //dlg.InitialDirectory = @"D:\";
            dlg.RestoreDirectory = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ExcelWriter file = new ExcelWriter(dlg.FileName);
                try
                {
                    file.WriteData(this.data);
                    success = true;
                }
                catch
                {
                    MessageBox.Show("I/O Write Error");
                    success = false;
                }
            }
            return success;
        }

        public void PrintPreview()
        {
            this.printer.PreviewDocument();
        }

        public void Print()
        {
            this.printer.PrintDocument();
        }

        public void PageSetup()
        {
            this.printer.SettingDocument();
        }

        private void cmdAddVariable_Click(object sender, EventArgs e)
        {
            SeriesVariables var = this.data.SeriesVariables;
            zaitun.GUI.CreateSeriesVariable ser = new zaitun.GUI.CreateSeriesVariable();
            ser.ShowDialog();
            if (ser.DialogResult == DialogResult.OK)
            {
                try
                {
                    SeriesVariable tmp = new SeriesVariable(ser.VariableName, ser.VariableDescription);
                    tmp.InitializeItem(this.data.NumberObservations);
                    var.Add(tmp);
                    this.seriesDataList.Refresh();
                }
                catch (DuplicateVariableException)
                {
                    MessageBox.Show("Variable '" + ser.VariableName + "' already exist", "Duplicate Variable Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmdAddGroup_Click(object sender, EventArgs e)
        {
            SeriesGroups group = this.data.SeriesGroups;
            SeriesVariables var = this.data.SeriesVariables;
            zaitun.GUI.CreateSeriesGroup ser = new zaitun.GUI.CreateSeriesGroup(var);
            ser.ShowDialog();
            if (ser.DialogResult == DialogResult.OK)
            {
                try
                {
                    SeriesGroup tmp = new SeriesGroup(ser.GroupName, ser.GroupList);
                    group.Add(tmp);
                    this.seriesDataList.Refresh();
                }
                catch (DuplicateGroupException)
                {
                    MessageBox.Show("Group '" + ser.GroupName + "' already exist", "Duplicate Group Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            SeriesDataList.Item selected = this.seriesDataList.SelectedItem;
            if (selected.Type == SeriesDataList.Type.Series && selected.ListIndex > -1)
            {
                SeriesVariable var = this.data.SeriesVariables[selected.ListIndex];

                EditSeriesVariable edit = new EditSeriesVariable();
                edit.SetVariable(var);
                edit.ShowDialog();
                string lastVariableName = var.VariableName;

                if (edit.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (edit.VariableName.ToLower() != lastVariableName.ToLower())
                        {

                            SeriesVariable varClone = (SeriesVariable)var.Clone();
                            varClone.VariableName = edit.VariableName;
                            varClone.VariableDescription = edit.VariableDescription;

                            // check group membership
                            foreach (SeriesGroup gr in this.data.SeriesGroups)
                            {
                                for (int i = 0; i < gr.GroupList.Count; i++)
                                {
                                    if (gr[i] == var) gr[i] = varClone;

                                }
                            }

                            // add and remove
                            this.data.SeriesVariables.Add(varClone);
                            this.data.SeriesVariables.Remove(var);

                            string key = "SERIES " + lastVariableName;
                            if (this.variableViewPane.variableViewCollection.TabPages.ContainsKey(key))
                            {
                                int keyIndex = this.variableViewPane.variableViewCollection.TabPages.IndexOfKey(key);
                                this.variableViewPane.variableViewCollection.TabPages.RemoveAt(keyIndex);

                                this.variableViewPane.AddTabPage("SERIES " + varClone.VariableName, keyIndex);
                            }
                        }
                        else
                        {
                            var.VariableDescription = edit.VariableDescription;
                        }
                        this.data.SeriesVariables.FireChangedEvent();
                        this.seriesDataList.Refresh();

                    }
                    catch (DuplicateVariableException)
                    {
                        MessageBox.Show("Variable '" + edit.VariableName + "' already exist", "Duplicate Variable Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (selected.Type == SeriesDataList.Type.Group && selected.ListIndex > -1)
            {
                SeriesGroup group = this.data.SeriesGroups[selected.ListIndex];

                EditSeriesGroup edit = new EditSeriesGroup(this.data.SeriesVariables);
                edit.SetGroup(group);
                edit.ShowDialog();
                string lastGroupName = group.GroupName;

                if (edit.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (edit.GroupName.ToLower() != lastGroupName.ToLower())
                        {
                            SeriesGroup groupClone = (SeriesGroup)group.Clone();
                            groupClone.GroupName = edit.GroupName;
                            groupClone.GroupList = edit.GroupList;
                            this.data.SeriesGroups.Add(groupClone);
                            this.data.SeriesGroups.Remove(group);

                            string key = "GROUP " + lastGroupName;
                            if (this.variableViewPane.variableViewCollection.TabPages.ContainsKey(key))
                            {
                                int keyIndex = this.variableViewPane.variableViewCollection.TabPages.IndexOfKey(key);
                                this.variableViewPane.variableViewCollection.TabPages.RemoveAt(keyIndex);

                                this.variableViewPane.AddTabPage("GROUP " + groupClone.GroupName, keyIndex);
                            }
                        }
                        else
                        {
                            group.GroupList = edit.GroupList;
                            string key = "GROUP " + lastGroupName;
                            if (this.variableViewPane.variableViewCollection.TabPages.ContainsKey(key))
                            {
                                int keyIndex = this.variableViewPane.variableViewCollection.TabPages.IndexOfKey(key);
                                this.variableViewPane.variableViewCollection.TabPages.RemoveAt(keyIndex);

                                this.variableViewPane.AddTabPage("GROUP " + group.GroupName, keyIndex);
                            }
                        }

                        this.data.SeriesGroups.FireChangedEvent();
                        this.seriesDataList.Refresh();

                    }
                    catch (DuplicateGroupException)
                    {
                        MessageBox.Show("Group '" + edit.GroupName + "' already exist", "Duplicate Group Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cmdDuplicate_Click(object sender, EventArgs e)
        {
            SeriesDataList.Item selected = this.seriesDataList.SelectedItem;
            if (selected.Type == SeriesDataList.Type.Series && selected.ListIndex > -1)
            {
                SeriesVariable var = this.data.SeriesVariables[selected.ListIndex];

                DuplicateDialog dlg = new DuplicateDialog();
                dlg.SetVariable(var);
                dlg.ShowDialog();

                if (dlg.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        SeriesVariable varClone = (SeriesVariable)var.Clone();
                        varClone.VariableName = dlg.NewName;
                        this.data.SeriesVariables.Add(varClone);

                        this.data.SeriesVariables.FireChangedEvent();
                        this.seriesDataList.Refresh();

                    }
                    catch (DuplicateVariableException)
                    {
                        MessageBox.Show("Variable '" + dlg.NewName + "' already exist", "Duplicate Variable Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (selected.Type == SeriesDataList.Type.Group && selected.ListIndex > -1)
            {
                SeriesGroup group = this.data.SeriesGroups[selected.ListIndex];

                DuplicateDialog dlg = new DuplicateDialog();
                dlg.SetGroup(group);
                dlg.ShowDialog();

                if (dlg.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        SeriesGroup groupClone = (SeriesGroup)group.Clone();
                        groupClone.GroupName = dlg.NewName;
                        this.data.SeriesGroups.Add(groupClone);

                        this.data.SeriesGroups.FireChangedEvent();
                        this.seriesDataList.Refresh();

                    }
                    catch (DuplicateGroupException)
                    {
                        MessageBox.Show("Group '" + dlg.NewName + "' already exist", "Duplicate Group Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            SeriesDataList.Item selected = this.seriesDataList.SelectedItem;
            if (selected.Type == SeriesDataList.Type.Series && selected.ListIndex > -1)
            {
                if (MessageBox.Show("Are you sure you want to remove variable '" +
                    this.data.SeriesVariables[selected.ListIndex].VariableName + "'?"
                    , "Delete Variable", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // check whether it's member of a group or no
                    SeriesVariable var = this.data.SeriesVariables[selected.ListIndex];
                    bool safeDelete = true;
                    foreach (SeriesGroup gr in this.data.SeriesGroups)
                    {
                        if (gr.GroupList.Contains(var))
                        {
                            safeDelete = false;
                            break;
                        }
                    }

                    if (safeDelete == false)
                    {
                        MessageBox.Show("Variable '" + var.VariableName + "' is still connected to a group\nPlease delete the group first, or remove this variable from the group"
                    , "Delete Variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // remove variable view pane
                        string key = "SERIES " + this.data.SeriesVariables[selected.ListIndex].VariableName;
                        if (this.variableViewPane.variableViewCollection.TabPages.ContainsKey(key))
                        {
                            int keyIndex = this.variableViewPane.variableViewCollection.TabPages.IndexOfKey(key);
                            this.variableViewPane.variableViewCollection.TabPages.RemoveAt(keyIndex);
                        }

                        // remove variable
                        this.data.SeriesVariables.RemoveAt(selected.ListIndex);

                        this.data.SeriesVariables.FireChangedEvent();
                        this.seriesDataList.Refresh();
                    }
                }
            }
            else if (selected.Type == SeriesDataList.Type.Group && selected.ListIndex > -1)
            {
                if (MessageBox.Show("Are you sure you want to remove group '" +
                    this.data.SeriesGroups[selected.ListIndex].GroupName + "'?"
                    , "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // remove variable view pane
                    string key = "GROUP " + this.data.SeriesGroups[selected.ListIndex].GroupName;
                    if (this.variableViewPane.variableViewCollection.TabPages.ContainsKey(key))
                    {
                        int keyIndex = this.variableViewPane.variableViewCollection.TabPages.IndexOfKey(key);
                        this.variableViewPane.variableViewCollection.TabPages.RemoveAt(keyIndex);
                    }

                    // remove groupe
                    this.data.SeriesGroups.RemoveAt(selected.ListIndex);

                    this.data.SeriesGroups.FireChangedEvent();
                    this.seriesDataList.Refresh();
                }
            }
        }

        public void TransformVariable()
        {
            SeriesVariables vars = this.data.SeriesVariables;
            zaitun.GUI.TransformVariable ser = new zaitun.GUI.TransformVariable(vars);
            ser.ShowDialog();
            if (ser.DialogResult == DialogResult.OK)
            {
                SeriesVariable tmpVar = new SeriesVariable(ser.NewVariableName,
                    ser.Transform.ToString() + " transformation" + " from \"" +
                    ser.SelectedVariable.VariableName + "\"");

                if (ser.Transform == zaitun.GUI.TransformVariable.TransformationType.Differencing)
                {
                    tmpVar.SeriesValues.Add(double.NaN);
                    for (int i = 1; i < ser.SelectedVariable.SeriesValues.Count; i++)
                    {
                        tmpVar.SeriesValues.Add(ser.SelectedVariable.SeriesValues[i] - ser.SelectedVariable.SeriesValues[i - 1]);
                    }
                }
                else if (ser.Transform == zaitun.GUI.TransformVariable.TransformationType.SeasonalDifferencing)
                {
                    for (int i = 0; i < ser.SeasonalLag; i++)
                        tmpVar.SeriesValues.Add(double.NaN);
                    for (int i = ser.SeasonalLag; i < ser.SelectedVariable.SeriesValues.Count; i++)
                    {
                        tmpVar.SeriesValues.Add(ser.SelectedVariable.SeriesValues[i] - ser.SelectedVariable.SeriesValues[i - ser.SeasonalLag]);
                    }
                }
                else if (ser.Transform == zaitun.GUI.TransformVariable.TransformationType.NaturalLogarithm)
                {
                    for (int i = 0; i < ser.SelectedVariable.SeriesValues.Count; i++)
                    {
                        tmpVar.SeriesValues.Add(Math.Log(ser.SelectedVariable.SeriesValues[i]));
                    }
                }
                else if (ser.Transform == zaitun.GUI.TransformVariable.TransformationType.Logarithm)
                {
                    for (int i = 0; i < ser.SelectedVariable.SeriesValues.Count; i++)
                    {
                        tmpVar.SeriesValues.Add(Math.Log(ser.SelectedVariable.SeriesValues[i], ser.LogarithmBase));
                    }
                }
                else if (ser.Transform == zaitun.GUI.TransformVariable.TransformationType.SquareRoot)
                {
                    for (int i = 0; i < ser.SelectedVariable.SeriesValues.Count; i++)
                    {
                        tmpVar.SeriesValues.Add(Math.Sqrt(ser.SelectedVariable.SeriesValues[i]));
                    }
                }

                try
                {
                    vars.Add(tmpVar);
                    this.seriesDataList.Refresh();
                }
                catch (DuplicateVariableException)
                {
                    MessageBox.Show("Variable '" + tmpVar.VariableName + "' already exist", "Duplicate Variable Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void seriesDataList1_DoubleClick(object sender, EventArgs e)
        {
            this.variableViewPane.AddTabPage(this.seriesDataList.SelectedItem);
            this.tabControlData.SelectedTab = this.tabPageVariable;
        }


        public void NeuralNetworkAnalysis()
        {
            SelectAnalyzedVariable dlg = new SelectAnalyzedVariable(this.data.SeriesVariables);
            dlg.ShowDialog();

            if (dlg.DialogResult == DialogResult.OK)
            {
                NeuralNetworkAnalysisForm neural = new NeuralNetworkAnalysisForm();
                neural.SetVariable(dlg.SelectedVariable);
                neural.ShowDialog();
                if (neural.DialogResult == DialogResult.Yes)
                {
                    ANNSelectResultView select = new ANNSelectResultView();
                    select.ShowDialog();
                    if (select.DialogResult == DialogResult.OK)
                    {
                        ANNResultTabPage annTabPage = new ANNResultTabPage();

                        annTabPage.Title = "Neural Network: '" + dlg.SelectedVariable.VariableName + "'";

                        if (select.IsForecastedDataGridChecked)
                        {
                            annTabPage.SetData(this.data, dlg.SelectedVariable, neural.NetworkProperties, neural.Solution, neural.Forecast(select.ForecastingStep));
                        }
                        else
                        {
                            annTabPage.SetData(this.data, dlg.SelectedVariable, neural.NetworkProperties, neural.Solution, null);
                        }

                        annTabPage.IsAnnModelSummaryVisible = select.IsAnnModelSummaryChecked;
                        annTabPage.IsActualPredictedResidualDataGridVisible = select.IsActualPredictedResidualDataGridChecked;
                        annTabPage.IsForecastedDataGridVisible = select.IsForecastedDataGridChecked;
                        annTabPage.IsActualAndPredictedGraphVisible = select.IsActualAndPredictedGraphChecked;
                        annTabPage.IsActualAndForecastedGraphVisible = select.IsActualAndForecastedGraphChecked;
                        annTabPage.IsActualVsPredictedGraphVisible = select.IsActualVsPredictedGraphChecked;
                        annTabPage.IsResidualGraphVisible = select.IsResidualGraphChecked;
                        annTabPage.IsResidualVsActualGraphVisible = select.IsResidualVsActualGraphChecked;
                        annTabPage.IsResidualVsPredictedGraphVisible = select.IsResidualVsPredictedGraphChecked;

                        annTabPage.DrawControl();

                        annTabPage.IsDrawn = true;
                        this.tabControlResult.AddTab(annTabPage);
                        this.tabControlResult.SelectedItem = annTabPage;

                        this.tabControlData.SelectedTab = this.tabPageResult;

                    }


                }
            }
        }

        public void MovingAverage()
        {
            SelectAnalyzedVariable dlg = new SelectAnalyzedVariable(this.data.SeriesVariables);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                MovingAverageForm maForm = new MovingAverageForm();
                maForm.SetVariable(dlg.SelectedVariable);
                maForm.ShowDialog();
                if (maForm.DialogResult == DialogResult.Yes)
                {

                    if (maForm.MaProperties.isSingleMA)
                    {
                        if (maForm.IsStoreSmoothed)
                        {
                            SeriesVariable var = new SeriesVariable(maForm.SmoothedName, "Smoothed Value of MA(" + maForm.MaProperties.orde +
                                ") analysis of variable '" + dlg.SelectedVariable.VariableName + "'");
                            int lag = dlg.SelectedVariable.SeriesValues.Count - maForm.MaProperties.includedObservations;
                            var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                            for (int i = 0; i < lag; i++) var[i] = double.NaN;
                            for (int i = lag; i < lag + maForm.MaProperties.orde; i++) var[i] = double.NaN;
                            for (int i = lag + maForm.MaProperties.orde; i < maForm.MaProperties.includedObservations + lag; i++) var[i] = maForm.MaTable.singleSmoothed[i - lag];
                            this.data.SeriesVariables.Add(var);
                            this.seriesDataList.Refresh();
                        }

                        if (maForm.IsStorePredicted)
                        {
                            SeriesVariable var = new SeriesVariable(maForm.PredictedName, "Predicted Value of MA(" + maForm.MaProperties.orde +
                                ") analysis of variable '" + dlg.SelectedVariable.VariableName + "'");
                            int lag = dlg.SelectedVariable.SeriesValues.Count - maForm.MaProperties.includedObservations;
                            var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                            for (int i = 0; i < lag; i++) var[i] = double.NaN;
                            for (int i = lag; i < lag + maForm.MaProperties.orde; i++) var[i] = double.NaN;
                            for (int i = lag + maForm.MaProperties.orde; i < maForm.MaProperties.includedObservations + lag; i++) var[i] = maForm.MaTable.predicted[i - lag];
                            this.data.SeriesVariables.Add(var);
                            this.seriesDataList.Refresh();
                        }

                        if (maForm.IsStoreResidual)
                        {
                            SeriesVariable var = new SeriesVariable(maForm.ResidualName, "Residual Value of MA(" + maForm.MaProperties.orde +
                                ") analysis of variable '" + dlg.SelectedVariable.VariableName + "'");
                            int lag = dlg.SelectedVariable.SeriesValues.Count - maForm.MaProperties.includedObservations;
                            var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                            for (int i = 0; i < lag; i++) var[i] = double.NaN;
                            for (int i = lag; i < lag + maForm.MaProperties.orde; i++) var[i] = double.NaN;
                            for (int i = lag + maForm.MaProperties.orde; i < maForm.MaProperties.includedObservations + lag; i++) var[i] = maForm.MaTable.residual[i - lag];
                            this.data.SeriesVariables.Add(var);
                            this.seriesDataList.Refresh();
                        }
                    }
                    else
                    {
                        if (maForm.IsStoreSmoothed)
                        {
                            SeriesVariable var = new SeriesVariable(maForm.SmoothedName, "Smoothed Value of MA(" + maForm.MaProperties.orde +
                                "X" + maForm.MaProperties.orde + ") analysis of variable '" + dlg.SelectedVariable.VariableName + "'");
                            int lag = dlg.SelectedVariable.SeriesValues.Count - maForm.MaProperties.includedObservations;
                            var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                            for (int i = 0; i < lag; i++) var[i] = double.NaN;
                            for (int i = lag; i < lag + (2 * (maForm.MaProperties.orde - 1)); i++) var[i] = double.NaN;
                            for (int i = lag + (2 * (maForm.MaProperties.orde - 1)); i < maForm.MaProperties.includedObservations + lag; i++) var[i] = maForm.MaTable.doubleSmoothed[i - lag];
                            this.data.SeriesVariables.Add(var);
                            this.seriesDataList.Refresh();
                        }
                        if (maForm.IsStorePredicted)
                        {
                            SeriesVariable var = new SeriesVariable(maForm.PredictedName, "Predicted Value of MA(" + maForm.MaProperties.orde +
                                "X" + maForm.MaProperties.orde + ") analysis of variable '" + dlg.SelectedVariable.VariableName + "'");
                            int lag = dlg.SelectedVariable.SeriesValues.Count - maForm.MaProperties.includedObservations;
                            var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                            for (int i = 0; i < lag; i++) var[i] = double.NaN;
                            for (int i = lag; i < lag + (2 * (maForm.MaProperties.orde - 1)); i++) var[i] = double.NaN;
                            for (int i = lag + (2 * (maForm.MaProperties.orde - 1)); i < maForm.MaProperties.includedObservations + lag; i++) var[i] = maForm.MaTable.predicted[i - lag];
                            this.data.SeriesVariables.Add(var);
                            this.seriesDataList.Refresh();
                        }
                        if (maForm.IsStoreResidual)
                        {
                            SeriesVariable var = new SeriesVariable(maForm.ResidualName, "Residual Value of MA(" + maForm.MaProperties.orde +
                                "," + maForm.MaProperties.orde + ") analysis of variable '" + dlg.SelectedVariable.VariableName + "'");
                            int lag = dlg.SelectedVariable.SeriesValues.Count - maForm.MaProperties.includedObservations;
                            var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                            for (int i = 0; i < lag; i++) var[i] = double.NaN;
                            for (int i = lag; i < lag + (2 * (maForm.MaProperties.orde - 1)); i++) var[i] = double.NaN;
                            for (int i = lag + (2 * (maForm.MaProperties.orde - 1)); i < maForm.MaProperties.includedObservations + lag; i++) var[i] = maForm.MaTable.residual[i - lag];
                            this.data.SeriesVariables.Add(var);
                            this.seriesDataList.Refresh();
                        }
                    }

                    MAResultTabPage maTabPage = new MAResultTabPage();

                    maTabPage.Title = "Moving Average : '" + dlg.SelectedVariable.VariableName + "'";

                    if (maForm.IsForecastedDataGridChecked)
                    {
                        if (maForm.MaProperties.isSingleMA)
                        {
                            maTabPage.SetData(this.data, dlg.SelectedVariable, maForm.MaProperties,
                                maForm.MaTable, maForm.SmaForecast(maForm.ForecastingStep));
                        }
                        else
                        {
                            maTabPage.SetData(this.data, dlg.SelectedVariable, maForm.MaProperties,
                                maForm.MaTable, maForm.DmaForecast(maForm.ForecastingStep));
                        }
                    }
                    else
                    {
                        maTabPage.SetData(this.data, dlg.SelectedVariable, maForm.MaProperties,
                            maForm.MaTable, null);
                    }
                    maTabPage.IsMaModelSummaryVisible = maForm.IsMaModelSummaryChecked;
                    maTabPage.IsSmoothingVisible = maForm.IsSmoothingChecked;
                    maTabPage.IsMovingAverageDataGridVisible = maForm.IsMovingAverageDataGridChecked;
                    maTabPage.IsForecastedDataGridVisible = maForm.IsForecastedDataGridChecked;
                    maTabPage.IsActualAndPredictedGraphVisible = maForm.IsActualAndPredictedGraphChecked;
                    maTabPage.IsActualAndPredictedGraphVisible = maForm.IsActualAndPredictedGraphChecked;
                    maTabPage.IsActualAndSmoothedGraphVisible = maForm.IsActualAndSmoothedGraphChecked;
                    maTabPage.IsActualAndForecastedGraphVisible = maForm.IsActualAndForecastedGraphChecked;
                    maTabPage.IsActualVsPredictedGraphVisible = maForm.IsActualVsPredictedGraphChecked;
                    maTabPage.IsResidualGraphVisible = maForm.IsResidualGraphChecked;
                    maTabPage.IsResidualVsActualGraphVisible = maForm.IsResidualVsActualGraphChecked;
                    maTabPage.IsResidualVsPredictedGraphVisible = maForm.IsResidualVsPredictedGraphChecked;

                    maTabPage.DrawControl();

                    maTabPage.IsDrawn = true;
                    this.tabControlResult.AddTab(maTabPage);
                    this.tabControlResult.SelectedItem = maTabPage;

                    this.tabControlData.SelectedTab = this.tabPageResult;

                }
            }
        }


        public void ExponentialSmoothing()
        {
            SelectAnalyzedVariable dlg = new SelectAnalyzedVariable(this.data.SeriesVariables);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                ExponentialSmoothingForm esForm = new ExponentialSmoothingForm();
                esForm.SetVariable(dlg.SelectedVariable);
                esForm.ShowDialog();
                if (esForm.DialogResult == DialogResult.Yes)
                {

                    if (esForm.IsStoreSmoothed)
                    {
                        SeriesVariable var = new SeriesVariable(esForm.SmoothedName, "Smoothed Value of exponential smoothing of variable '"
                            + dlg.SelectedVariable.VariableName + "'");
                        int lag = dlg.SelectedVariable.SeriesValues.Count - esForm.EsTable.predicted.Length;
                        var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                        for (int i = 0; i < lag; i++) var[i] = double.NaN;
                        for (int i = 0; i < esForm.EsTable.smoothed.Length; i++) var[i + lag] = esForm.EsTable.smoothed[i];
                        this.data.SeriesVariables.Add(var);
                        this.seriesDataList.Refresh();
                    }

                    if (esForm.IsStorePredicted)
                    {
                        SeriesVariable var = new SeriesVariable(esForm.PredictedName, "Predicted Value of exponential smoothing of variable '"
                            + dlg.SelectedVariable.VariableName + "'");
                        int lag = dlg.SelectedVariable.SeriesValues.Count - esForm.EsTable.predicted.Length;
                        var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                        for (int i = 0; i < lag; i++) var[i] = double.NaN;
                        for (int i = 0; i < esForm.EsTable.predicted.Length; i++) var[i + lag] = esForm.EsTable.predicted[i];
                        this.data.SeriesVariables.Add(var);
                        this.seriesDataList.Refresh();
                    }

                    if (esForm.IsStoreResidual)
                    {
                        SeriesVariable var = new SeriesVariable(esForm.ResidualName, "Residual Value of exponential smoothing of variable '"
                            + dlg.SelectedVariable.VariableName + "'");
                        int lag = dlg.SelectedVariable.SeriesValues.Count - esForm.EsTable.residual.Length;
                        var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                        for (int i = 0; i < lag; i++) var[i] = double.NaN;
                        for (int i = 0; i < esForm.EsTable.residual.Length; i++) var[i + lag] = esForm.EsTable.residual[i];
                        this.data.SeriesVariables.Add(var);
                        this.seriesDataList.Refresh();
                    }

                    ESResultTabPage esTabPage = new ESResultTabPage();

                    if (esForm.EsProperties.initialModel == 1)
                        esTabPage.Title = "Single ES : '" + dlg.SelectedVariable.VariableName + "'";
                    if (esForm.EsProperties.initialModel == 2)
                        esTabPage.Title = "Double ES (Brown) : '" + dlg.SelectedVariable.VariableName + "'";
                    if (esForm.EsProperties.initialModel == 3)
                        esTabPage.Title = "Double ES (Holt) : '" + dlg.SelectedVariable.VariableName + "'";
                    if (esForm.EsProperties.initialModel == 4)
                        esTabPage.Title = "Triple ES (Winter) : '" + dlg.SelectedVariable.VariableName + "'";

                    if (esForm.IsForecastedDataGridChecked)
                    {
                        if (esForm.EsProperties.initialModel == 1)
                        {
                            esTabPage.SetData(this.data, dlg.SelectedVariable, esForm.EsProperties,
                                esForm.EsTable, esForm.SesForecast(esForm.ForecastingStep));
                        }
                        if (esForm.EsProperties.initialModel == 2)
                        {
                            esTabPage.SetData(this.data, dlg.SelectedVariable, esForm.EsProperties,
                                esForm.EsTable, esForm.BrownForecast(esForm.ForecastingStep));
                        }
                        if (esForm.EsProperties.initialModel == 3)
                        {
                            esTabPage.SetData(this.data, dlg.SelectedVariable, esForm.EsProperties,
                                esForm.EsTable, esForm.HoltForecast(esForm.ForecastingStep));
                        }
                        if (esForm.EsProperties.initialModel == 4)
                        {
                            esTabPage.SetData(this.data, dlg.SelectedVariable, esForm.EsProperties,
                                esForm.EsTable, esForm.WinterForecast(esForm.ForecastingStep));
                        }
                    }

                    else
                    {
                        esTabPage.SetData(this.data, dlg.SelectedVariable, esForm.EsProperties,
                            esForm.EsTable, null);
                    }
                    esTabPage.IsEsModelSummaryVisible = esForm.IsEsModelSummaryChecked;

                    esTabPage.IsExponentialSmoothingDataGridVisible = esForm.IsExponentialSmoothingDataGridChecked;
                    esTabPage.IsSmoothingVisible = esForm.IsSmoothingChecked;
                    esTabPage.IsTrendVisible = esForm.IsTrendChecked;
                    esTabPage.IsSeasonalVisible = esForm.IsSeasonalChecked;
                    esTabPage.IsForecastedDataGridVisible = esForm.IsForecastedDataGridChecked;
                    esTabPage.IsActualAndPredictedGraphVisible = esForm.IsActualAndPredictedGraphChecked;
                    esTabPage.IsActualAndSmoothedGraphVisible = esForm.IsActualAndSmoothedGraphChecked;
                    esTabPage.IsActualAndForecastedGraphVisible = esForm.IsActualAndForecastedGraphChecked;
                    esTabPage.IsActualVsPredictedGraphVisible = esForm.IsActualVsPredictedGraphChecked;
                    esTabPage.IsResidualGraphVisible = esForm.IsResidualGraphChecked;
                    esTabPage.IsResidualVsActualGraphVisible = esForm.IsResidualVsActualGraphChecked;
                    esTabPage.IsResidualVsPredictedGraphVisible = esForm.IsResidualVsPredictedGraphChecked;

                    esTabPage.DrawControl();

                    esTabPage.IsDrawn = true;
                    this.tabControlResult.AddTab(esTabPage);
                    this.tabControlResult.SelectedItem = esTabPage;

                    this.tabControlData.SelectedTab = this.tabPageResult;


                }
            }
        }

        public void TrendAnalysis()
        {
            SelectAnalyzedVariable dlg = new SelectAnalyzedVariable(this.data.SeriesVariables);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                TrendAnalysisForm trendForm = new TrendAnalysisForm();
                trendForm.SetVariable(dlg.SelectedVariable);
                trendForm.ShowDialog();
                if (trendForm.DialogResult == DialogResult.OK)
                {

                    if (trendForm.IsStorePredicted)
                    {
                        SeriesVariable var = new SeriesVariable(trendForm.PredictedName, "Predicted Value of trend analysis of variable '"
                            + dlg.SelectedVariable.VariableName + "'");
                        int lag = dlg.SelectedVariable.SeriesValues.Count - trendForm.Predicted.Length;
                        var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                        for (int i = 0; i < lag; i++) var[i] = double.NaN;
                        for (int i = 0; i < trendForm.Predicted.Length; i++) var[i + lag] = trendForm.Predicted[i];
                        try
                        {
                            this.data.SeriesVariables.Add(var);
                        }
                        catch (DuplicateVariableException)
                        {
                            MessageBox.Show("Variable '" + var.VariableName + "' already exist", "Duplicate Variable Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        this.seriesDataList.Refresh();
                    }

                    if (trendForm.IsStoreResidual)
                    {
                        SeriesVariable var = new SeriesVariable(trendForm.ResidualName, "Residual Value of trend analysis of variable '"
                            + dlg.SelectedVariable.VariableName + "'");
                        int lag = dlg.SelectedVariable.SeriesValues.Count - trendForm.Residual.Length;
                        var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                        for (int i = 0; i < lag; i++) var[i] = double.NaN;
                        for (int i = 0; i < trendForm.Residual.Length; i++) var[i + lag] = trendForm.Residual[i];
                        try
                        {
                            this.data.SeriesVariables.Add(var);
                        }
                        catch (DuplicateVariableException)
                        {
                            MessageBox.Show("Variable '" + var.VariableName + "' already exist", "Duplicate Variable Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        this.seriesDataList.Refresh();
                    }


                    TrendAnalysisResultTabPage trendTabPage = new TrendAnalysisResultTabPage();

                    trendTabPage.Title = "Trend Analysis : '" + dlg.SelectedVariable.VariableName + "'";

                    if (trendForm.IsForecastedDataGridChecked)
                    {
                        trendTabPage.SetData(this.data, dlg.SelectedVariable, trendForm.TrendProperties, trendForm.Predicted,
                            trendForm.Forecast(trendForm.ForecastingStep), trendForm.Residual);
                    }
                    else
                    {
                        trendTabPage.SetData(this.data, dlg.SelectedVariable, trendForm.TrendProperties,
                            trendForm.Predicted, null, trendForm.Residual);
                    }

                    trendTabPage.IsTrendAnalysisModelSummaryVisible = trendForm.IsTrendAnalysisModelSummaryChecked;
                    trendTabPage.IsActualPredictedResidualDataGridVisible = trendForm.IsActualPredictedResidualDataGridChecked;
                    trendTabPage.IsForecastedDataGridVisible = trendForm.IsForecastedDataGridChecked;
                    trendTabPage.IsActualAndPredictedGraphVisible = trendForm.IsActualAndPredictedGraphChecked;
                    trendTabPage.IsActualAndForecastedGraphVisible = trendForm.IsActualAndForecastedGraphChecked;
                    trendTabPage.IsActualVsPredictedGraphVisible = trendForm.IsActualVsPredictedGraphChecked;
                    trendTabPage.IsResidualGraphVisible = trendForm.IsResidualGraphChecked;
                    trendTabPage.IsResidualVsActualGraphVisible = trendForm.IsResidualVsActualGraphChecked;
                    trendTabPage.IsResidualVsPredictedGraphVisible = trendForm.IsResidualVsPredictedGraphChecked;

                    trendTabPage.DrawControl();

                    trendTabPage.IsDrawn = true;
                    this.tabControlResult.AddTab(trendTabPage);
                    this.tabControlResult.SelectedItem = trendTabPage;

                    this.tabControlData.SelectedTab = this.tabPageResult;

                }
            }
        }

        public void Decomposition()
        {
            SelectAnalyzedVariable dlg = new SelectAnalyzedVariable(this.data.SeriesVariables);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                DecompositionForm decForm = new DecompositionForm();
                decForm.SetVariable(dlg.SelectedVariable);
                decForm.ShowDialog();
                if (decForm.DialogResult == DialogResult.Yes)
                {

                    if (decForm.IsStoreTrend)
                    {
                        SeriesVariable var = new SeriesVariable(decForm.TrendName, "Trend Value of Decomposition Classic analysis of variable '"
                            + dlg.SelectedVariable.VariableName + "'");
                        int lag = dlg.SelectedVariable.SeriesValues.Count - decForm.DecTable.trend.Length;
                        var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                        for (int i = 0; i < lag; i++) var[i] = double.NaN;
                        for (int i = 0; i < decForm.DecTable.trend.Length; i++) var[i + lag] = decForm.DecTable.trend[i];
                        this.data.SeriesVariables.Add(var);
                        this.seriesDataList.Refresh();
                    }
                    if (decForm.IsStoreDetrend)
                    {
                        SeriesVariable var = new SeriesVariable(decForm.DetrendName, "Detrended Value of Decomposition Classic analysis of variable '"
                            + dlg.SelectedVariable.VariableName + "'");
                        int lag = dlg.SelectedVariable.SeriesValues.Count - decForm.DecTable.detrend.Length;
                        var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                        for (int i = 0; i < lag; i++) var[i] = double.NaN;
                        for (int i = 0; i < decForm.DecTable.detrend.Length; i++) var[i + lag] = decForm.DecTable.detrend[i];
                        this.data.SeriesVariables.Add(var);
                        this.seriesDataList.Refresh();
                    }
                    if (decForm.IsStoreDeseasonal)
                    {
                        SeriesVariable var = new SeriesVariable(decForm.DeseasonalName, "Seasonally Adj. Value of Decomposition Classic analysis of variable '"
                            + dlg.SelectedVariable.VariableName + "'");
                        int lag = dlg.SelectedVariable.SeriesValues.Count - decForm.DecTable.deseasonal.Length;
                        var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                        for (int i = 0; i < lag; i++) var[i] = double.NaN;
                        for (int i = 0; i < decForm.DecTable.deseasonal.Length; i++) var[i + lag] = decForm.DecTable.deseasonal[i];
                        this.data.SeriesVariables.Add(var);
                        this.seriesDataList.Refresh();
                    }

                    if (decForm.IsStorePredicted)
                    {
                        SeriesVariable var = new SeriesVariable(decForm.PredictedName, "Predicted Value of Decomposition Classic analysis of variable '"
                            + dlg.SelectedVariable.VariableName + "'");
                        int lag = dlg.SelectedVariable.SeriesValues.Count - decForm.DecTable.predicted.Length;
                        var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                        for (int i = 0; i < lag; i++) var[i] = double.NaN;
                        for (int i = 0; i < decForm.DecTable.predicted.Length; i++) var[i + lag] = decForm.DecTable.predicted[i];
                        this.data.SeriesVariables.Add(var);
                        this.seriesDataList.Refresh();
                    }

                    if (decForm.IsStoreResidual)
                    {
                        SeriesVariable var = new SeriesVariable(decForm.ResidualName, "Residual Value of Decomposition Classic analysis of variable '"
                            + dlg.SelectedVariable.VariableName + "'");
                        int lag = dlg.SelectedVariable.SeriesValues.Count - decForm.DecTable.residual.Length;
                        var.InitializeItem(dlg.SelectedVariable.SeriesValues.Count);
                        for (int i = 0; i < lag; i++) var[i] = double.NaN;
                        for (int i = 0; i < decForm.DecTable.residual.Length; i++) var[i + lag] = decForm.DecTable.residual[i];
                        this.data.SeriesVariables.Add(var);
                        this.seriesDataList.Refresh();
                    }


                    DECResultTabPage decTabPage = new DECResultTabPage();

                    decTabPage.Title = "Decomposition : '" + dlg.SelectedVariable.VariableName + "'";

                    if (decForm.IsForecastedDataGridChecked)
                    {
                        decTabPage.SetData(this.data, dlg.SelectedVariable, decForm.DecProperties,
                            decForm.DecTable, decForm.Forecast(decForm.ForecastingStep));
                    }
                    else
                    {
                        decTabPage.SetData(this.data, dlg.SelectedVariable, decForm.DecProperties,
                            decForm.DecTable, null);
                    }
                    decTabPage.IsDecModelSummaryVisible = decForm.IsDecModelSummaryChecked;

                    decTabPage.IsDecompositionDataGridVisible = decForm.IsDecompositionDataGridChecked;
                    decTabPage.IsTrendVisible = decForm.IsTrendChecked;
                    decTabPage.IsDetrendVisible = decForm.IsDetrendChecked;
                    decTabPage.IsSeasonalVisible = decForm.IsSeasonalChecked;
                    decTabPage.IsDeseasonalVisible = decForm.IsDeseasonalChecked;
                    decTabPage.IsForecastedDataGridVisible = decForm.IsForecastedDataGridChecked;
                    decTabPage.IsActualPredictedAndTrendGraphVisible = decForm.IsActualPredictedAndTrendGraphChecked;
                    decTabPage.IsActualAndForecastedGraphVisible = decForm.IsActualAndForecastedGraphChecked;
                    decTabPage.IsActualVsPredictedGraphVisible = decForm.IsActualVsPredictedGraphChecked;
                    decTabPage.IsResidualGraphVisible = decForm.IsResidualGraphChecked;
                    decTabPage.IsResidualVsActualGraphVisible = decForm.IsResidualVsActualGraphChecked;
                    decTabPage.IsResidualVsPredictedGraphVisible = decForm.IsResidualVsPredictedGraphChecked;
                    decTabPage.IsDetrendGraphVisible = decForm.IsDetrendGraphChecked;
                    decTabPage.IsDeseasonalGraphVisible = decForm.IsDeseasonalGraphChecked;


                    decTabPage.DrawControl();

                    decTabPage.IsDrawn = true;
                    this.tabControlResult.AddTab(decTabPage);
                    this.tabControlResult.SelectedItem = decTabPage;

                    this.tabControlData.SelectedTab = this.tabPageResult;

                }
            }
        }

        public void Correlogram()
        {
            SelectAnalyzedVariable dlg = new SelectAnalyzedVariable(this.data.SeriesVariables);
            dlg.ShowDialog();

            if (dlg.DialogResult == DialogResult.OK)
            {
                CorrelogramForm co = new CorrelogramForm();
                co.SetVariable(dlg.SelectedVariable);
                co.ShowDialog();

                if (co.DialogResult == DialogResult.OK)
                {
                    double[] data = co.Data;
                    int lag = co.Lag;
                    bool whiteNoiseAcf = co.WhiteNoiseAcf;

                    CorrelogramResult tp = new CorrelogramResult();
                    tp.Title = "Correlogram ";

                    switch (co.Series)
                    {
                        case CorrelogramForm.CorrelogramSeries.Level:
                            tp.Title += "(Level)";
                            break;
                        case CorrelogramForm.CorrelogramSeries.FirstDifference:
                            tp.Title += "(1st diff)";
                            break;
                        case CorrelogramForm.CorrelogramSeries.SecondDifference:
                            tp.Title += "(2nd diff)";
                            break;
                    }

                    tp.Title += " : '" + dlg.SelectedVariable.VariableName + "'";
                    tp.SetData(data, lag, whiteNoiseAcf);
                    tp.DisplayResult();

                    tp.IsDrawn = true;
                    this.tabControlResult.AddTab(tp);
                    this.tabControlData.SelectedTab = this.tabPageResult;
                    this.tabControlResult.SelectedItem = tp;


                }
            }
        }

        private void DataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.isCurrentSaved)
            {
                DialogResult result = MessageBox.Show("The '" + this.data.SeriesName + "' document file has changed.\n\nDo you want to save the changes?", "Document has changed", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes) this.SaveToFile();
                else if (result == DialogResult.Cancel) e.Cancel = true;

            }
        }



        #region event
        // event changed
        void OnChanged(object sender, EventArgs e)
        {
            this.isCurrentSaved = false;
        }

        // event
        private void tabControlResult_ControlAdded(object sender, ControlEventArgs e)
        {
            this.isCurrentSaved = false;
        }

        private void tabControlResult_ControlRemoved(object sender, ControlEventArgs e)
        {
            this.isCurrentSaved = false;
        }

        private void pbVariableOptionEnter(object sender, EventArgs e)
        {
            this.pbVariableOption.BackgroundImage = zaitun.Properties.Resources.variable_option_hover1;
            this.cmdEdit.BackgroundImage = zaitun.Properties.Resources.button3;
            this.cmdDelete.BackgroundImage = zaitun.Properties.Resources.button3;
            this.cmdDuplicate.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void pbVariableOptionLeave(object sender, EventArgs e)
        {
            this.pbVariableOption.BackgroundImage = zaitun.Properties.Resources.variable_option21;
            this.cmdEdit.BackgroundImage = null;
            this.cmdDelete.BackgroundImage = null;
            this.cmdDuplicate.BackgroundImage = null;
        }

        private void pbProjectMenuEnter(object sender, EventArgs e)
        {
            this.pbProjectMenu.BackgroundImage = zaitun.Properties.Resources.project_menu_enter;
            this.cmdAddGroup.BackgroundImage = zaitun.Properties.Resources.button3;
            this.cmdAddVariable.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void pbProjectMenuLeave(object sender, EventArgs e)
        {
            this.pbProjectMenu.BackgroundImage = zaitun.Properties.Resources.project_menu31;
            this.cmdAddGroup.BackgroundImage = null;
            this.cmdAddVariable.BackgroundImage = null;
        }

        private void cmdAddVariable_Enter(object sender, EventArgs e)
        {
            this.pbProjectMenu.BackgroundImage = zaitun.Properties.Resources.project_menu_enter;
            this.cmdAddVariable.BackgroundImage = zaitun.Properties.Resources.button_selected;
            this.cmdAddGroup.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void cmdAddVariable_Leave(object sender, EventArgs e)
        {
            this.pbProjectMenu.BackgroundImage = zaitun.Properties.Resources.project_menu31;
            this.cmdAddVariable.BackgroundImage = null;
            this.cmdAddGroup.BackgroundImage = null;
        }

        private void cmdAddGroup_Enter(object sender, EventArgs e)
        {
            this.cmdAddGroup.BackgroundImage = zaitun.Properties.Resources.button_selected;
            this.pbProjectMenu.BackgroundImage = zaitun.Properties.Resources.project_menu_enter;
            this.cmdAddVariable.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void cmdAddGroup_Leave(object sender, EventArgs e)
        {
            this.pbProjectMenu.BackgroundImage = zaitun.Properties.Resources.project_menu31;
            this.cmdAddGroup.BackgroundImage = null;
            this.cmdAddVariable.BackgroundImage = null;
        }

        private void cmdEdit_Enter(object sender, EventArgs e)
        {
            this.pbVariableOption.BackgroundImage = zaitun.Properties.Resources.variable_option_hover1;
            this.cmdEdit.BackgroundImage = zaitun.Properties.Resources.button_selected;
            this.cmdDelete.BackgroundImage = zaitun.Properties.Resources.button3;
            this.cmdDuplicate.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void cmdEdit_Leave(object sender, EventArgs e)
        {
            this.pbVariableOption.BackgroundImage = zaitun.Properties.Resources.variable_option21;
            this.cmdEdit.BackgroundImage = null;
            this.cmdDelete.BackgroundImage = null;
            this.cmdDuplicate.BackgroundImage = null;
        }

        private void cmdDuplicate_Enter(object sender, EventArgs e)
        {
            this.pbVariableOption.BackgroundImage = zaitun.Properties.Resources.variable_option_hover1;
            this.cmdDuplicate.BackgroundImage = zaitun.Properties.Resources.button_selected;
            this.cmdDelete.BackgroundImage = zaitun.Properties.Resources.button3;
            this.cmdEdit.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void cmdDuplicat_Leave(object sender, EventArgs e)
        {
            this.pbVariableOption.BackgroundImage = zaitun.Properties.Resources.variable_option21;
            this.cmdEdit.BackgroundImage = null;
            this.cmdDelete.BackgroundImage = null;
            this.cmdDuplicate.BackgroundImage = null;
        }

        private void cmdDelete_Enter(object sender, EventArgs e)
        {
            this.pbVariableOption.BackgroundImage = zaitun.Properties.Resources.variable_option_hover1;
            this.cmdDelete.BackgroundImage = zaitun.Properties.Resources.button_selected;
            this.cmdEdit.BackgroundImage = zaitun.Properties.Resources.button3;
            this.cmdDuplicate.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void cmdDelete_Leave(object sender, EventArgs e)
        {
            this.pbVariableOption.BackgroundImage = zaitun.Properties.Resources.variable_option21;
            this.cmdEdit.BackgroundImage = null;
            this.cmdDelete.BackgroundImage = null;
            this.cmdDuplicate.BackgroundImage = null;
        }

        private void cmdLeave(object sender, EventArgs e)
        {
            this.pbProjectMenu.BackgroundImage = zaitun.Properties.Resources.project_menu31;
            //this.pictureBox1.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void cmdEnter(object sender, EventArgs e)
        {
            this.pbProjectMenu.BackgroundImage = zaitun.Properties.Resources.project_menu_enter;
            //this.pictureBox1.BackgroundImage = zaitun.Properties.Resources.button_selected;
        }

        #endregion

    }
}