using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;


namespace ImpactorControls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class CtlParameters : UserControl
    {
        private string _ConnectionString = string.Empty;
        private long _TestId = long.MinValue;
        private long _ParametersId = long.MinValue;
        private long _TestTypeId = long.MinValue;

        public event EventHandler ImpactorIdChanged;
        public CtlParameters()
        {
            InitializeComponent();
            AddDgvLines();
        }

        public string ConnectionString
        {
            set 
            {
                _ConnectionString = value;
            }
        }

        public long TestId
        {
            get { return _TestId; }
            set { _TestId = value; }
        }

        public long ImpactorParametersId
        {
            get { return _ParametersId; }
            set { _ParametersId = value; }
        }
      
        public long TestTypeId
        {
            get { return _TestTypeId; }
            set { _TestTypeId = value; }
        }

        public string LoadTest (long testId)
        {
            ImpactorParameters parms = new ImpactorParameters(_ConnectionString);
            string strErrorMessage = parms.GetForAnImpactorTest (testId);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                ImpactorParametersId = parms.ImpactorParametersId;
                ComboFuctions.SelectCmboItem(cboImpactor, parms.ImpactorTypeId);
                txtTemperature.Text = Conversion.FormatDouble(parms.Temperature, "##0.#0");
                txtHumidity.Text = Conversion.FormatDouble(parms.Humidity, "##0.0");
                txtTrigger1.Text = Conversion.FormatInt (parms.Trigger1,"##0");
                txtTrigger2.Text = Conversion.FormatInt(parms.Trigger2, "##0");
                txtNotes.Text = parms.Notes;
                txtFirePressure.Text = Conversion.FormatDouble(parms.FirePressure, "###0.0");
                txtCylinderSpeed.Text = Conversion.FormatDouble(parms.CylinderSpeed,"#0.##0");
                txtCylenderKPH.Text = Conversion.ConvertMPerSecToKPH(parms.CylinderSpeed).ToString("#0.##0");
                txtMeasuredSpeed.Text = Conversion.FormatDouble(parms.MeasuredSpeed,"#0.##0");
                txtMeasuredKPH.Text = Conversion.FormatDouble (Conversion.ConvertMPerSecToKPH(parms.MeasuredSpeed),"#0.##0");
                txtCylinderwithout.Text = Conversion.FormatDouble(parms.CylinderWithOutImpactorSetpoint, "#0.##0");
                txtAccumulatorTemperature.Text = Conversion.FormatDouble(parms.AccumulatorTemperature, "#0.#0");
                txtTankTemperature.Text = Conversion.FormatDouble(parms.TankTemperature, "#0.#0");
                txtAirbag1.Text = Conversion.FormatInt(parms.AirBag1,"###0");
                txtAirbag2.Text = Conversion.FormatInt(parms.AirBag2,"###0");
                txtAirbag3.Text = Conversion.FormatInt(parms.AirBag3,"###0");
                txtDryFires.Text = Conversion.FormatInt(parms.DryFires,"###0");

                NameAxis();

                strErrorMessage = LoadAxisGrid(testId);
            }
            
            return strErrorMessage; 
        }

        public string LoadImpactorCbo(long impactorTestTypeId)
        {
            ImpactorType type = new ImpactorType(_ConnectionString);
            List<ImpactorType> types = type.GetAllForATestType( impactorTestTypeId, out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                cboImpactor.Items.Clear();

                foreach (ImpactorType items in types)
                {
                    DropDownItem dropDownItem = new DropDownItem(items.ImpactorTypeId, items.Owner + " (" + items.SerialNumber + ")");
                    cboImpactor.Items.Add(dropDownItem);
                }

                cboImpactor.DisplayMember = "Text";
                cboImpactor.ValueMember = "Id";
            }

            return strErrorMessage;
        }
        public string Save(bool isAfterCopy )
        {
            ImpactorParameters parms = new ImpactorParameters(_ConnectionString);

            string strErrorMessage = VerifyRequiredFields(isAfterCopy);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                if (TestId != long.MinValue)
                {
                    parms.ImpactorTestId = TestId;
                    
                    if (isAfterCopy == true )
                    {
                        parms.ImpactorParametersId = long.MinValue;
                    }
                    else
                    {
                        parms.ImpactorParametersId = ImpactorParametersId;
                    }

                    if (cboImpactor.SelectedItem is DropDownItem item)
                    {
                        parms.ImpactorTypeId = item.Id;
                    }

                    if (double.TryParse(txtTemperature.Text, out double value) == true)
                    {
                        parms.Temperature = value;
                    }
                    if (double.TryParse(txtHumidity.Text, out value) == true)
                    {
                        parms.Humidity = value;
                    }

                    parms.Notes = txtNotes.Text;

                    if (isAfterCopy == false)
                    {
                        if (int.TryParse(txtTrigger1.Text, out int iTemp) == true)
                        {
                            parms.Trigger1 = iTemp;
                        }

                        if (int.TryParse(txtTrigger2.Text, out iTemp) == true)
                        {
                            parms.Trigger2 = iTemp;
                        }

                        if (double.TryParse(txtFirePressure.Text, out value) == true)
                        {
                            parms.FirePressure = value;
                        }
                        if (double.TryParse(txtCylinderSpeed.Text, out value) == true)
                        {
                            parms.CylinderSpeed = value;
                        }

                        if (double.TryParse(txtMeasuredSpeed.Text, out value) == true)
                        {
                            parms.MeasuredSpeed = value;
                        }

                        if (double.TryParse(txtCylinderwithout.Text, out value) == true)
                        {
                            parms.CylinderWithOutImpactorSetpoint = value;
                        }

                        if (double.TryParse(txtAccumulatorTemperature.Text, out value) == true)
                        {
                            parms.AccumulatorTemperature = value;
                        }

                        if (double.TryParse(txtTankTemperature.Text, out value) == true)
                        {
                            parms.TankTemperature = value;
                        }

                        if (int.TryParse(txtAirbag1.Text, out iTemp) == true)
                        {
                            parms.AirBag1 = iTemp;
                        }

                        if (int.TryParse(txtAirbag2.Text, out iTemp) == true)
                        {
                            parms.AirBag2 = iTemp;
                        }

                        if (int.TryParse(txtAirbag3.Text, out iTemp) == true)
                        {
                            parms.AirBag3 = iTemp;
                        }

                        if (int.TryParse(txtDryFires.Text, out iTemp) == true)
                        {
                            parms.DryFires = iTemp;
                        }
                    }

                    if (parms.ImpactorParametersId == long.MinValue)
                    {
                        strErrorMessage = parms.Insert();
                    }
                    else
                    {
                        strErrorMessage = parms.Update();
                    }

                    if (string.IsNullOrEmpty(strErrorMessage) == true)
                    {
                        if (isAfterCopy == false)
                        {
                            strErrorMessage = InsertOrUpdateAxis(TestId, parms.ImpactorParametersId);
                        }
                    }
                }
                else
                {
                    strErrorMessage = "TestId is not valid in Parmeters Save";
                }
            }

            return strErrorMessage;
        }

        public void ClearAll () 
        {
            cboImpactor.SelectedItem = null;
            txtTemperature.Text = string.Empty;
            txtHumidity.Text = string.Empty;
            txtTrigger1.Text = string.Empty;
            txtTrigger2.Text = string.Empty;
            AddDgvLines();
            txtNotes.Text = string.Empty;
            txtFirePressure.Text = string.Empty;
            txtCylinderSpeed.Text = string.Empty;
            txtCylenderKPH.Text = string.Empty;
            txtMeasuredSpeed.Text = string.Empty;
            txtMeasuredKPH.Text= string.Empty;
            txtCylinderwithout.Text = string.Empty;
            txtAccumulatorTemperature.Text = string.Empty;
            txtTankTemperature.Text = string.Empty;
            txtAirbag1.Text = string.Empty;
            txtAirbag2.Text = string.Empty;
            txtAirbag3.Text = string.Empty;
            txtDryFires.Text = string.Empty;
        }

        public void ClearControl(string name)
        {
            if (string.IsNullOrEmpty(name) == false)
            {
                Control[] found = Controls.Find(name, true);
                foreach (Control ctrl in found)
                {
                    if (ctrl is TextBox txt)
                    {
                        txt.Text = string.Empty;
                    }
                    if (ctrl is ComboBox cmb)
                    {
                        cmb.SelectedItem = null;
                    }

                }
            }
        }

        public void ClearAxis()
        {
            AddDgvLines();
        }
        private string VerifyRequiredFields (bool isAfterCopy)
        {
            string strVerified;
            if (cboImpactor.SelectedItem != null)
            {
                if (txtTemperature.Text != string.Empty)
                {
                    if (txtHumidity.Text != string.Empty)
                    {
                        if (isAfterCopy == false)
                        {
                            if (txtFirePressure.Text != string.Empty)
                            {
                                if (txtCylinderSpeed.Text != string.Empty)
                                {
                                    if (txtMeasuredSpeed.Text != string.Empty)
                                    {
                                        if (txtCylinderwithout.Text != string.Empty)
                                        {
                                            if (txtAccumulatorTemperature.Text != string.Empty)
                                            {
                                                if (txtTankTemperature.Text != string.Empty)
                                                {
                                                    strVerified = string.Empty;
                                                }
                                                else
                                                {
                                                    strVerified = "Please enter the Tank Temperature";
                                                }
                                            }
                                            else
                                            {
                                                strVerified = "Please enter the Accumulator Temperature";
                                            }
                                        }
                                        else
                                        {
                                            strVerified = "Please enter the Cylinder without Impactor Set Point";
                                        }
                                    }
                                    else
                                    {
                                        strVerified = "Please enter the Measured Speed";
                                    }
                                }
                                else
                                {
                                    strVerified = "Please enter the Cylinder Speed";
                                }
                            }
                            else
                            {
                                strVerified = "Please enter the Fire Pressue";
                            }
                        }
                        else
                        {
                            strVerified = string.Empty;
                        }
                    }
                    else
                    {
                        strVerified = "Please enter the Humidity";
                    }
                }
                else
                {
                    strVerified = "Please enter the Temperature";
                }
            }
            else
            {
                strVerified = "Please select an Impactor";
            }

            return strVerified;
        }
        private string LoadAxisGrid(long testid)
        {
            ImpactorAxis axis = new ImpactorAxis(_ConnectionString)
            {
                ImpactorTestId = testid,
            };
        
            dgAxis.Rows.Clear();
            AddDgvLines();

            List<ImpactorAxis> axisList = axis.GetAll(testid, out string strErroMessage);
            if (string.IsNullOrEmpty(strErroMessage) == true)
            {
                if (axisList.Count > 0)
                {
                    int RowCount = 0;
                    foreach (ImpactorAxis loadAxis in axisList)
                    {
                        if (RowCount < dgAxis.Rows.Count)
                        {
                            DataGridViewRow Row = dgAxis.Rows[RowCount];

                            Row.Cells[0].Value = loadAxis.SetName;
                            Row.Cells[1].Value = Conversion.FormatDouble(loadAxis.XAxis, "##0.0").ToString();
                            Row.Cells[2].Value = Conversion.FormatDouble(loadAxis.YAxis, "##0.0").ToString();
                            Row.Cells[3].Value = Conversion.FormatDouble(loadAxis.ZAxis, "##0.0").ToString();
                            if (loadAxis.Alpha > 0)
                            {
                                Row.Cells[4].Value = Conversion.FormatDouble(loadAxis.Alpha, "#0.0").ToString();
                            }
                            Row.Cells[5].Value = loadAxis.ImpactorAxisId.ToString();
                            RowCount++;
                        }
                    }
                }
            }

            return strErroMessage;
        }

        private string InsertOrUpdateAxis(long TestId, long ParmetersId)
        {
            string strErrorMessage = string.Empty;

            foreach (DataGridViewRow row in dgAxis.Rows)
            {
                if (row.Cells[5].Value == null)
                {
                    strErrorMessage = InsertAxis(TestId, ParmetersId, row);
                }
                else
                {
                    strErrorMessage = UpdateAxis(TestId, ParmetersId, row);
                }

                if ( string.IsNullOrEmpty(strErrorMessage) == false )
                {
                    break;
                }
            }

            return strErrorMessage;
        }
        private string InsertAxis(long TestId, long ParmetersId, DataGridViewRow row)
        {
            string strErrorMessage;

            ImpactorAxis axis = new ImpactorAxis(_ConnectionString)
            {
                ImpactorTestId = TestId,
                ImpactorParameterId = ParmetersId,
                SetName = row.Cells[0].Value.ToString(),
            };

            if (row.Cells[1].Value != null)
            {
                if (double.TryParse(row.Cells[1].Value.ToString(), out double val) == true)
                {
                    axis.XAxis = val;
                }

            }

            if (row.Cells[2].Value != null)
            {
                if (double.TryParse(row.Cells[2].Value.ToString(), out double val) == true)
                {
                    axis.YAxis = val;
                }
            }

            if (row.Cells[3].Value != null)
            {
                if (double.TryParse(row.Cells[3].Value.ToString(), out double val) == true)
                {
                    axis.ZAxis = val;
                }
            }

            if (row.Cells[4].Value != null)
            {
                if (double.TryParse(row.Cells[4].Value.ToString(), out double dTemp) == true)
                {
                    axis.Alpha = dTemp;
                }
            }
            else
            {
                axis.Alpha = 0;
            }

            strErrorMessage = axis.Insert();

            return strErrorMessage;
        }

        private string UpdateAxis(long TestId, long ParmetersId, DataGridViewRow row)
        {
            string strErrorMessage;

            ImpactorAxis axis = new ImpactorAxis(_ConnectionString)
            {
                ImpactorTestId = TestId,
                ImpactorParameterId = ParmetersId,

                SetName = row.Cells[0].Value.ToString(),
            };

            if (row.Cells[1].Value != null)
            {
                if (double.TryParse(row.Cells[1].Value.ToString(), out double val) == true)
                {
                    axis.XAxis = val;
                }
            }
            else
            {
                axis.XAxis = -1;
            }

            if (row.Cells[2].Value != null)
            {
                if (double.TryParse(row.Cells[2].Value.ToString(), out double val) == true)
                {
                    axis.YAxis = val;
                }
            }
            else
            {
                axis.YAxis = -1;
            }

            if (row.Cells[3].Value != null)
            {
                if (double.TryParse(row.Cells[3].Value.ToString(), out double val) == true)
                {
                    axis.ZAxis = val;
                }
            }
            else
            {
                axis.ZAxis = -1;
            }

            if (row.Cells[4].Value != null)
            {
                if (double.TryParse(row.Cells[4].Value.ToString(), out double dTemp) == true)
                {
                    axis.Alpha = dTemp;
                }
            }
            else
            {
                axis.Alpha = -1;
            }

            if (row.Cells[5].Value != null)
            {
                if (long.TryParse(row.Cells[5].Value.ToString(), out long lTemp) == true)
                {
                    axis.ImpactorAxisId = lTemp;
                }
            }

            strErrorMessage = axis.Update();

            return strErrorMessage;

        }

        private void AddDgvLines()
        {
            dgAxis.Rows.Clear();

            for (int index = 1; index < 5; index++)
            {
                DataGridViewRow Row = new DataGridViewRow();
                Row.Cells.Add(new DataGridViewTextBoxCell());
                Row.Cells[0].ReadOnly = true;
                dgAxis.Rows.Add(Row);
            }

            NameAxis();
        }

        public void NameAxis()
        {
            bool isHead = false;
            if (string.IsNullOrEmpty(_ConnectionString) == false && TestTypeId != long.MinValue)
            {
                string strErrorMessage;
                ImpactorTestType tType = new ImpactorTestType(_ConnectionString);
                strErrorMessage = tType.Get(TestTypeId);
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    if (tType.Description.Contains("Head") == true)
                    {
                        isHead = true;
                    }

                    for (int index = 0; index < 4; ++index)
                    {
                        if (isHead == true)
                        {
                            if (index == 0)
                            {
                                dgAxis.Rows[index].Cells[0].Value = "P1 (AP)";
                            }
                            else if (index == 1)
                            {
                                dgAxis.Rows[index].Cells[0].Value = "P1 (CP)";
                            }
                            else
                            {
                                dgAxis.Rows[index].Cells[0].Value = "P" + (index + 1).ToString();
                            }
                        }
                        else
                        {
                            dgAxis.Rows[index].Cells[0].Value = "P" + (index + 1).ToString();
                        }
                    }
                }
            }
        }
        private void TxtCylinderSpeed_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(txtCylinderSpeed.Text, out double value) == true)
            {
                txtCylenderKPH.Text = Conversion.ConvertMPerSecToKPH(value).ToString("#.###0");
            }
        }

        private void TxtMeasuredSpeed_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(txtMeasuredSpeed.Text, out double value) == true)
            {
                txtMeasuredKPH.Text = Conversion.ConvertMPerSecToKPH(value).ToString ("#.###0");
            }
        }

        private void CboImpactorIndexChanged(object sender, EventArgs e)
        {
            if (cboImpactor.SelectedItem is DropDownItem item)
            {
                EventHandler handler = ImpactorIdChanged;
                e = new ImpactorId
                {
                    SelectedImpactorId = item.Id,
                };

                handler?.Invoke(this, e);

                NameAxis();
            }
        }

        private void BtnAddDryFire_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDryFires.Text) == true)
            {
                txtDryFires.Text = "0";
            }

            if (int.TryParse(txtDryFires.Text, out int value) == true)
            {
                txtDryFires.Text = Conversion.FormatInt(++value, "##0");
            }
        }
    }
}
