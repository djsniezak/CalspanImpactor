using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;


namespace Controls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class CtlInjuryTimeData : UserControl
    {
        private string _ConnectionString = string.Empty;
        private List<ImpactorInjuryTimeData> _dataList = null;
        private List<ImpactorTestParameters> _testParameters = null;
        private List<ImpactorCriticalInjuryData> _criticalInjuryData = null;
        private string _RunTestNumber = string.Empty;

        public CtlInjuryTimeData()
        {
            InitializeComponent();
           
            dgvTestParms.AutoGenerateColumns = false;
            dgvCriticalInjury.AutoGenerateColumns = false;
            dgvInjuryData.AutoGenerateColumns = false;

            DataGridViewCellStyle style = dgvTestParms.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dgvTestParms.Font, FontStyle.Bold);
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            style = dgvCriticalInjury.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dgvCriticalInjury.Font, FontStyle.Bold);
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            style = dgvInjuryData.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dgvInjuryData.Font, FontStyle.Bold);
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public string ConnectionString
        {
            set { _ConnectionString = value; }
        }

        public string LoadData(string RunTestNumber)
        {
            _RunTestNumber = RunTestNumber;

            string strErrorMessage = FillDvgInjuryData(RunTestNumber);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                strErrorMessage = FillDgvTestParms(RunTestNumber);
                if (string.IsNullOrEmpty(strErrorMessage) == true )
                {
                    strErrorMessage = FillDgvCrtitalInjury (RunTestNumber);
                }
            }

            return strErrorMessage;
        }

        public void ClearAll()
        {
            dgvInjuryData.DataSource = null;
        }

        public string Save()
        {
            string strErrorMessage = SaveInjuryTimeData();
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                strErrorMessage = SaveTestParameters();
                if (string.IsNullOrEmpty(strErrorMessage) == true )
                {
                    strErrorMessage = SaveCriticalInjuryData();
                }
            }

            return strErrorMessage;
        }

        private string SaveInjuryTimeData()
        {
            string strErrorMessage = string.Empty;
            if (_dataList != null)
            {
                if (_dataList.Count > 0)
                {
                    ImpactorInjuryTimeData time = new ImpactorInjuryTimeData(_ConnectionString);
                    strErrorMessage = time.DeleteTestRun(_RunTestNumber);
                    if (string.IsNullOrEmpty(strErrorMessage) == true)
                    {
                        foreach (ImpactorInjuryTimeData data in _dataList)
                        {
                            ImpactorInjuryTimeData saveTime = new ImpactorInjuryTimeData(_ConnectionString)
                            {
                                ImpactorInjuryTimeDataId = data.ImpactorInjuryTimeDataId,
                                TestRunNumber = data.TestRunNumber,
                                ImpactorInjuryTimeId = data.ImpactorInjuryTimeId,
                                MaxTime = data.MaxTime,
                                MaxValue = data.MaxValue,
                                MinTime = data.MinTime,
                                MinValue = data.MinValue,
                                Units = data.Units,
                                TimeStamp = data.TimeStamp,
                                Notes = data.Notes
                            };

                            strErrorMessage = saveTime.Insert();
                        }
                    }
                }
            }

            return strErrorMessage;
        }

        private string SaveTestParameters()
        {
            string strErrorMessage = string.Empty;
            if (_testParameters != null)
            {
                if (_testParameters.Count > 0)
                {
                    ImpactorTestParameters delParm = new ImpactorTestParameters(_ConnectionString);
                    strErrorMessage = delParm.DeleteTestRun(_RunTestNumber);
                    if (string.IsNullOrEmpty(strErrorMessage) == true)
                    {
                        foreach (ImpactorTestParameters parm in _testParameters)
                        {
                            ImpactorTestParameters saveParm = new ImpactorTestParameters(_ConnectionString)
                            {
                                TestRunNumber = _RunTestNumber,
                                ParameterNameId = parm.ParameterNameId,
                                ParameterName = parm.ParameterName,
                                Value = parm.Value,
                                TimeOne = parm.TimeOne,
                                TimeTwo = parm.TimeTwo,
                                Duration = parm.Duration
                            };

                            strErrorMessage = saveParm.Insert();
                        }
                    }
                }
            }
            return strErrorMessage;
        }

        private string SaveCriticalInjuryData()
        {
            string strErrorMessage = string.Empty;
            if (_criticalInjuryData != null)
            {
                if (_criticalInjuryData.Count > 0)
                {
                    ImpactorCriticalInjuryData delCriticalInjuryData = new ImpactorCriticalInjuryData(_ConnectionString);
                    strErrorMessage = delCriticalInjuryData.DeleteTestRun(_RunTestNumber);
                    if (string.IsNullOrEmpty(strErrorMessage) == true)
                    {
                        foreach (ImpactorCriticalInjuryData criticalInjuryData in _criticalInjuryData)
                        {
                            ImpactorCriticalInjuryData saveCriticalInjuryData = new ImpactorCriticalInjuryData (_ConnectionString)
                            {
                                TestRun = _RunTestNumber,
                                ImpactorCriticalInjuryNameId = criticalInjuryData.ImpactorCriticalInjuryNameId,
                                Value = criticalInjuryData.Value,
                                Time = criticalInjuryData.Time
                            };

                            strErrorMessage = saveCriticalInjuryData.Insert();
                        }
                    }
                }
            }
            return strErrorMessage;

        }
        private string FillDvgInjuryData(string RunTestNumber)
        {
            ImpactorInjuryTimeData Injury = new ImpactorInjuryTimeData(_ConnectionString);
            List<ImpactorInjuryTimeData> data = Injury.GetAllForATest(RunTestNumber, out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                dgvInjuryData.DataSource = data;
                _dataList = data;
            }

            if (dgvInjuryData.Rows.Count == 0)
            {
                btnDelete.Enabled = false;
            }

            return strErrorMessage;
        }

        private string FillDgvTestParms(string RunTestNumber)
        {
            ImpactorTestParameters parms = new ImpactorTestParameters(_ConnectionString);
            List<ImpactorTestParameters> parmList = parms.GetAllForATest(RunTestNumber, out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                dgvTestParms.DataSource = parmList;
                _testParameters = parmList;
            }

            return strErrorMessage;
        }

        private string FillDgvCrtitalInjury(string RunTestNumber)
        {
            
            ImpactorCriticalInjuryData crd = new ImpactorCriticalInjuryData(_ConnectionString);
            List< ImpactorCriticalInjuryData> crtitcalInjuryData = crd.GetAll ( RunTestNumber, out string strErrorMessage);
            if (string.IsNullOrEmpty (strErrorMessage) == true )
            {
                dgvCriticalInjury.DataSource = crtitcalInjuryData;
                _criticalInjuryData = crtitcalInjuryData;
            }

            return strErrorMessage;
        }

        private void AddARecord(long impactorInjuryTimeId, string shortName)
        {
            ImpactorInjuryTimeData timeData = new ImpactorInjuryTimeData(_ConnectionString)
            {
                ImpactorInjuryTimeId = impactorInjuryTimeId,
                ShortName = shortName,
                TestRunNumber = _RunTestNumber,
                MaxValue = 0,
                MaxTime = 0,
                MinValue = 0,
                MinTime = 0,
                TimeStamp = DateTime.Now
            };

            ImpactorInjuryTime time = new ImpactorInjuryTime(_ConnectionString);
            string strErrorMessage = time.Get(impactorInjuryTimeId);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                timeData.Units = time.DefaultUnits;

                _dataList.Add(timeData);
                List<ImpactorInjuryTimeData> data = new List<ImpactorInjuryTimeData>();
                data.AddRange(_dataList);

                dgvInjuryData.DataSource = null;
                dgvInjuryData.Rows.Clear();
                dgvInjuryData.DataSource = data;
            }
        }

        private void AddTestParameter(long selectedId, string testParmName)
        {
            ImpactorTestParameters testParm = new ImpactorTestParameters(_ConnectionString)
            {
                TestRunNumber = _RunTestNumber,
                ParameterNameId = selectedId,
                Value = 0,
                TimeOne = 0,
                TimeTwo = 0,
                Duration = 0
            };

            TestParameterNames name = new TestParameterNames(_ConnectionString);
            string strErrorMessage = name.Get(selectedId);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                testParm.ParameterName = name.TestParameterName;
            }

            _testParameters.Add(testParm);
            List<ImpactorTestParameters> data = new List<ImpactorTestParameters>();
            data.AddRange(_testParameters);

            dgvTestParms.DataSource = null;
            dgvTestParms.Rows.Clear();
            dgvTestParms.DataSource = data;
        }

        private void AddCriticalInjury(long selectedId, string testParmName, string channel)
        {
            ImpactorCriticalInjuryData AddRecord = new ImpactorCriticalInjuryData(_ConnectionString)
            {
                TestRun = _RunTestNumber,
                ImpactorCriticalInjuryNameId = selectedId,
                Value = string.Empty,
                Time = 0
            };

            ImpactorCriticalInjuryNames name = new ImpactorCriticalInjuryNames(_ConnectionString);
            string strErrorMessage = name.Get(selectedId);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                AddRecord.TestParameterName = name.TestParameterName;
                AddRecord.Channel = name.Channel;

                _criticalInjuryData.Add(AddRecord);
                List<ImpactorCriticalInjuryData> data = new List<ImpactorCriticalInjuryData>();
                data.AddRange(_criticalInjuryData);

                dgvCriticalInjury.DataSource = null;
                dgvCriticalInjury.Rows.Clear();
                dgvCriticalInjury.DataSource = data;
            }
        }
        private void DgvInjusryDate_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInjuryData.Rows.Count > 0)
            {
                btnDelete.Enabled = true;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            IMPFrmSelectTime selectTime = new IMPFrmSelectTime(_ConnectionString);
            switch (selectTime.ShowDialog())
            {
                case DialogResult.OK:
                    AddARecord(selectTime.ImpactorInjuryTimeId, selectTime.ShortName);
                    break;
                case DialogResult.Cancel:
                    break;
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvInjuryData.SelectedRows;
            if (rows.Count > 0)
            {
                if (rows[0].Cells[6].Value != null)
                {
                    if (long.TryParse(rows[0].Cells[6].Value.ToString(), out long lTemp) == true)
                    {
                        ImpactorInjuryTimeData time = new ImpactorInjuryTimeData(_ConnectionString);
                        string strErrorMessage = time.Delete(lTemp);
                        if (string.IsNullOrEmpty(strErrorMessage) == true)
                        {
                            dgvInjuryData.DataSource = null;
                            dgvInjuryData.Rows.Clear();
                            strErrorMessage = FillDvgInjuryData(_RunTestNumber);
                            if (string.IsNullOrEmpty(strErrorMessage) == true)
                            {
                                MessageBox.Show("Record Deleted Successfully", "Delete an Impactor Injury Data Time Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(strErrorMessage, "Loading Impactor Injury Data for " + _RunTestNumber, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show(strErrorMessage, "Deleting an Impactor Injury Time Data Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
        }

        private void BtnExAdd_Click(object sender, EventArgs e)
        {
            FrmSelectTestParameter frm = new FrmSelectTestParameter(_ConnectionString);
            switch (frm.ShowDialog())
            {
                case DialogResult.OK:
                    AddTestParameter(frm.SelectedId, frm.TestParameterName);
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        private void BtnExDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvTestParms.SelectedRows;
            if (rows.Count > 0)
            {
                if (rows[0].Cells[5].Value != null)
                {
                    if ( long.TryParse (rows[0].Cells[5].Value.ToString(), out long lTemp) == true )
                    {
                        ImpactorTestParameters parms = new ImpactorTestParameters(_ConnectionString);
                        string strErrorMessage = parms.Delete (lTemp);
                        if (string.IsNullOrEmpty(strErrorMessage) == true)
                        {
                            dgvTestParms.DataSource = null;
                            dgvTestParms.Rows.Clear();
                            strErrorMessage = FillDgvTestParms(_RunTestNumber);
                            if (string.IsNullOrEmpty(strErrorMessage) == true)
                            {
                                MessageBox.Show("Record Deleted Successfully", "Delete an Impactor Test Parameter Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(strErrorMessage, "Loading Impactor Test Parameter Data for " + _RunTestNumber, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(strErrorMessage, "Deleting an Impactor Test Parameter Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void BtnCriticalAdd_Click(object sender, EventArgs e)
        {
            IMPFrmSelectCritical frm = new IMPFrmSelectCritical(_ConnectionString);
            switch (frm.ShowDialog())
            {
                case DialogResult.OK:
                    AddCriticalInjury(frm.CriticalInjuryNameId, frm.CriticalInjuryName, frm.CriticalInjuryChannel);
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        private void BtnCriticalDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvCriticalInjury.SelectedRows;
            if (rows.Count > 0)
            {
                if (rows[0].Cells[4].Value != null)
                {
                    if (long.TryParse(rows[0].Cells[4].Value.ToString(), out long lTemp) == true)
                    {
                        ImpactorCriticalInjuryData delCriticalInjuryData = new ImpactorCriticalInjuryData(_ConnectionString);
                        string strErrorMessage = delCriticalInjuryData.Delete(lTemp);
                        if (string.IsNullOrEmpty(strErrorMessage) == true)
                        {
                            dgvCriticalInjury.DataSource = null;
                            dgvCriticalInjury.Rows.Clear();
                            strErrorMessage = FillDgvCrtitalInjury(_RunTestNumber);
                            if (string.IsNullOrEmpty(strErrorMessage) == true)
                            {
                                MessageBox.Show("Record Deleted Successfully", "Delete an Impactor Critical Injury Data Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(strErrorMessage, "Loading Impactor Critical Injury Data for " + _RunTestNumber, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(strErrorMessage, "Deleting an Impactor Critical Injury Data Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
