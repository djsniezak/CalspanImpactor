using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace ImpactorControls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class CtlTestSetUp : UserControl
    {
        private string _ConnectionString = string.Empty;
        private long _TestId = long.MinValue;
        private long _ProtocolId = long.MinValue;
        private long _SelectedSpecimen = long.MinValue;
        private bool _Loading = false;
        private List<ImpactorTest>_Tests = new List<ImpactorTest>();

        public event EventHandler ImpactorTestTypeSelected;
        public event EventHandler SpecimenIndexSelected;

        public CtlTestSetUp()
        {
            InitializeComponent();
            dteTestDateTime.Value = DateTime.Now;
            btnUnlock.Visible = false;
        }

        public string ConnectionString
        {
            set 
            { 
                _ConnectionString = value;
                if (string.IsNullOrEmpty(_ConnectionString ) == false ) 
                {
                    string strErrorMessage = LoadClientCombo();
                    if (string.IsNullOrEmpty(strErrorMessage) == true)
                    {
                        strErrorMessage = LoadTestTypeCombo();
                        if ( string.IsNullOrEmpty(strErrorMessage) == true )
                        {
                            strErrorMessage = LoadSpecimenCombo();
                            if ( string.IsNullOrEmpty(strErrorMessage) == true )
                            {

                            }
                            else
                            {
                                MessageBox.Show(strErrorMessage, "Loading Specimens", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(strErrorMessage, "Loading Test Type Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(strErrorMessage, "Loading Client Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public long TestId
        {
            get { return _TestId; }
            set { _TestId = value;}
        }

        public long ProtocolId
        {
            get { return _ProtocolId; }
            set { _ProtocolId = value; }
        }

        public string TestNumber
        {
            get
            {
                string Id = "Not Assigned";
                if (string.IsNullOrEmpty(txtImpactorID.Text) == false)
                {
                    Id = txtImpactorID.Text;
                }

                return Id;
            }
            
        }

        public long SelectedSpecimen
        {
            get { return _SelectedSpecimen; }
        }

        public string CheckforRequiredNewTestFields ()
        {
            string strErrorMessage = string.Empty;
            if ( string.IsNullOrEmpty(dteTestDateTime.Text) == false )
            {
                if (cmbClientName.SelectedIndex != -1 ) 
                {
                    if (cmboSpecimen.SelectedItem is DropDownItem)
                    {
                        if (cboTestType.SelectedIndex == -1)
                        {
                            strErrorMessage = "Please Select a Test Type.";
                        }
                    }
                    else
                    {
                        strErrorMessage = "Please add a Specimen";
                    }
                }
                else
                {
                    strErrorMessage = "Please select a Customer";
                }
            }
            else
            {
                strErrorMessage = "Please Enter Test Date and Time";
            }
            return strErrorMessage;
        }

        public string CreateNewTest()
        {
            string strErrorMessage;
            dteTestDateTime.Value = DateTime.Now;

            ImpactorTest newTest = new ImpactorTest(_ConnectionString)
            {
                RunTime = dteTestDateTime.Value,
                Engineer = txtEngineer.Text,
                Operator = txtOperator.Text,
                Notes = txtNotes.Text
            };

            if (cmbClientName.SelectedItem is DropDownItem item)
            {
                newTest.CustomerId = item.Id;
            }

            if (cboTestType.SelectedItem is DropDownItem Typeitem)
            {
                newTest.TestTypeId = Typeitem.Id;
            }

            if ( cmboSpecimen.SelectedItem is DropDownItem SpecimenItem)
            {
                newTest.SpecimenId = SpecimenItem.Id;
            }

            newTest.ImpactorRunNumber = newTest.CreateImpactorRunNumber(txtClientPrefix.Text, out strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                if (IsImpactorIdDuplicated(newTest.ImpactorRunNumber) == false)
                {
                    strErrorMessage = newTest.Insert();
                    if (string.IsNullOrEmpty(strErrorMessage) == true)
                    {
                        txtImpactorID.Text = newTest.ImpactorRunNumber;
                        TestId = newTest.ImpactorTestId;
                    }
                }
                else
                {
                    strErrorMessage = "The Impactor Test ID " + newTest.ImpactorRunNumber + " is already being used.";
                }
            }

            return strErrorMessage;
        }

        public void ClearAll()
        {
            txtImpactorID.Text = string.Empty;
            dteTestDateTime.Value = DateTime.Now;
            cmbClientName.SelectedIndex = -1;  
            txtClientCode.Text = string.Empty;
            txtClientPrefix.Text = string.Empty; 
            cmboSpecimen.SelectedItem = null;
            txtEngineer.Text = string.Empty;    
            txtOperator.Text = string.Empty;    
            cboTestType.SelectedIndex = -1;
            txtNotes.Text = string.Empty;
            txtImpactorID.Enabled = true;
            txtImpactorID.BackColor = SystemColors.Window;
            btnUnlock.Visible = false;
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
                }
            }
        }
        public string LoadTest (long TestId )
        {
            _Loading = true;
            string strErrorMessage;
            if ( TestId != long.MinValue )
            {
                ImpactorTest loadTest = new ImpactorTest(_ConnectionString);
                strErrorMessage = loadTest.Get (TestId);
                if (string.IsNullOrEmpty( strErrorMessage) == true )
                {
                    txtImpactorID.Text = loadTest.ImpactorRunNumber;
                    dteTestDateTime.Value = loadTest.RunTime;
                    ComboFuctions.SelectCmboItem(cmbClientName, loadTest.CustomerId);
                    ComboFuctions.SelectCmboItem(cmboSpecimen, loadTest.SpecimenId);
                    txtEngineer.Text = loadTest.Engineer;
                    txtOperator.Text = loadTest.Operator;
                    ComboFuctions.SelectCmboItem(cboTestType, loadTest.TestTypeId);
                    txtNotes.Text = loadTest.Notes;
                    ProtocolId = loadTest.ProtocolId;
                    txtImpactorID.Enabled = false;
                    txtImpactorID.BackColor = SystemColors.ButtonFace;
                    btnUnlock.Visible = true;
                }

                _Tests.Clear();
                loadTest = new ImpactorTest(_ConnectionString);
                _Tests = loadTest.GetAll(out strErrorMessage);
            }
            else
            {
                strErrorMessage = "TestId is not valid: " + TestId.ToString();
            }

            _Loading = false;
            return strErrorMessage;
        }
        public string Save()
        {
            string strErrorMessage = string.Empty;
            if (TestId != long.MinValue)
            {
                ImpactorTest saveTest = new ImpactorTest(_ConnectionString)
                {
                    ImpactorTestId = TestId,
                    ImpactorRunNumber = txtImpactorID.Text,
                    RunTime = dteTestDateTime.Value,
                    Engineer = txtEngineer.Text,
                    Operator = txtOperator.Text,
                    ProtocolId = ProtocolId,
                    Notes = txtNotes.Text,
                };

                if (cmbClientName.SelectedItem is DropDownItem cItem)
                {
                    saveTest.CustomerId = cItem.Id;
                }

                if (cmboSpecimen.SelectedItem is DropDownItem sItem)
                {
                    saveTest.SpecimenId = sItem.Id;
                }

                if (cboTestType.SelectedItem is DropDownItem tTItem)
                {
                    saveTest.TestTypeId = tTItem.Id;
                }

                strErrorMessage = saveTest.Update();
            }
            return strErrorMessage;
        }
        private string LoadClientCombo()
        {
            ImpactorClient impactorClient = new ImpactorClient(_ConnectionString);
            List<ImpactorClient> clients = impactorClient.GetAll(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true )
            {
                foreach (ImpactorClient client in clients)
                {
                    if (client.Status == true)
                    {
                        DropDownItem item = new DropDownItem(client.ImpactorClientId, client.ShortName);
                        cmbClientName.Items.Add(item);
                    }
                }

                cmbClientName.DisplayMember = "Text";
                cmbClientName.ValueMember = "Id";
            }
            return strErrorMessage ;
        }

        private void CmbClientIndex_Changed(object sender, EventArgs e)
        {
            if (cmbClientName.SelectedItem != null) 
            {
                string strErrorMessage = strErrorMessage = LoadSpecimenCombo();
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    if (cmbClientName.SelectedItem is DropDownItem item)
                    {
                        strErrorMessage = LoadClientData(item.Id);
                        if (string.IsNullOrEmpty(strErrorMessage) == false)
                        {
                            MessageBox.Show(strErrorMessage, "Loading Client Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private string LoadClientData(long clientId)
        {
            ImpactorClient client = new ImpactorClient(_ConnectionString);
            string strErrorMessage = client.Get(clientId);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                txtClientCode.Text = client.ClientCode;
                txtClientPrefix.Text = client.ClientPrefix;
            }

            return strErrorMessage;
        }

        private string LoadTestTypeCombo()
        {
            ImpactorTestType testType = new ImpactorTestType(_ConnectionString);
            List<ImpactorTestType> types = testType.GetAll(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true) 
            { 
                foreach (ImpactorTestType type in types ) 
                { 
                    DropDownItem item = new DropDownItem( type.ImpactorTestTypeId, type.TestName);
                    cboTestType.Items.Add(item);
                }

                cboTestType.DisplayMember = "Text";
                cboTestType.ValueMember = "Id";
            }

            return strErrorMessage;
        }

        private string LoadSpecimenCombo()
        {
            ImpactorSpecimen spec = new ImpactorSpecimen(_ConnectionString);
            List<ImpactorSpecimen> specimens = spec.GetAll(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true )
            {
                if (cmbClientName.SelectedItem is DropDownItem item)
                {
                    cmboSpecimen.Items.Clear();

                    foreach (ImpactorSpecimen type in specimens)
                    {
                        if (type.CustomerId == item.Id)
                        {
                            if (type.Active == true)
                            {
                                DropDownItem specimenItem = new DropDownItem(type.SpecimenId, type.Make + " " + type.Model + " " + type.VIN);
                                cmboSpecimen.Items.Add(specimenItem);
                            }
                        }
                    }
                }

                cmboSpecimen.DisplayMember = "Text";
                cmboSpecimen.ValueMember = "Id";
            }
            return strErrorMessage;
        }

        private void CboTestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTestType.SelectedItem is DropDownItem item)
            {
                EventHandler handler = ImpactorTestTypeSelected;
                e = new ImpactorTestTypeId
                {
                    SelectedTestTypeId = item.Id,
                };

                handler?.Invoke(this, e);
            }
        }

        private void TxtImpactor_TextChanged(object sender, EventArgs e)
        {
            if (_Loading == false)
            {
                if (IsImpactorIdDuplicated(txtImpactorID.Text) == true)
                {
                    MessageBox.Show("The Impactor Test ID " + txtImpactorID.Text + " already exists.", "Impactor Test Id Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsImpactorIdDuplicated (string impactorId)
        {
            bool isDuplicated = false;
            foreach (ImpactorTest tst in _Tests)
            {
                if (tst.ImpactorRunNumber == impactorId)
                {
                    isDuplicated = true;
                    break;
                }
            }

            return isDuplicated;
        }

        private void BtnUnlock_Clicked(object sender, EventArgs e)
        {
            txtImpactorID.Enabled = true;
            txtImpactorID.BackColor = SystemColors.Window;
            btnUnlock.Visible = false;  
        }

        private void CmboSpecimen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmboSpecimen.SelectedItem is DropDownItem item)
            {
                EventHandler handler = SpecimenIndexSelected;
                e = new SpecimenId
                {
                    SelectedSpecimenId = item.Id,
                };

                handler?.Invoke(this, e);
            }
        }
    }
}
