using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace ImpactorControls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class CtlTestSetUp : UserControl
    {
        private string _ConnectionString = string.Empty;
        private long _TestId = long.MinValue;
        private long _ProtocolId = long.MinValue;

        public event EventHandler ImpactorTestTypeSelected;
        public CtlTestSetUp()
        {
            InitializeComponent();
            dteTestDateTime.Value = DateTime.Now;
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
                        if ( string.IsNullOrEmpty(strErrorMessage) == false ) 
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

        public string CheckforRequiredNewTestFields ()
        {
            string strErrorMessage = string.Empty;
            if ( string.IsNullOrEmpty(dteTestDateTime.Text) == false )
            {
                if (cmbClientName.SelectedIndex != -1 ) 
                {
                    if (string.IsNullOrEmpty(txtSpecimen.Text) == false)
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
            dteTestDateTime.Value = DateTime.Now;

            ImpactorTest newTest = new ImpactorTest(_ConnectionString)
            {
                RunTime = dteTestDateTime.Value,
                Specimen = txtSpecimen.Text,
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

            newTest.ImpactorRunNumber = newTest.CreateImpactorRunNumber(txtClientPrefix.Text, out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                strErrorMessage = newTest.Insert();
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    txtImpactorID.Text = newTest.ImpactorRunNumber;
                    TestId = newTest.ImpactorTestId;
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
            txtSpecimen.Text = string.Empty;
            txtEngineer.Text = string.Empty;    
            txtOperator.Text = string.Empty;    
            cboTestType.SelectedIndex = -1;
            txtNotes.Text = string.Empty;
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
                    txtSpecimen.Text = loadTest.Specimen;
                    txtEngineer.Text = loadTest.Engineer;
                    txtOperator.Text = loadTest.Operator;
                    ComboFuctions.SelectCmboItem(cboTestType, loadTest.TestTypeId);
                    txtNotes.Text = loadTest.Notes;
                    ProtocolId = loadTest.ProtocolId;
                }
            }
            else
            {
                strErrorMessage = "TestId is not valid: " + TestId.ToString();
            }

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
                    Specimen = txtSpecimen.Text,
                    Engineer = txtEngineer.Text,
                    Operator = txtOperator.Text,
                    ProtocolId = ProtocolId,
                    Notes = txtNotes.Text,
                };

                if (cmbClientName.SelectedItem != null)
                {
                    if (cmbClientName.SelectedItem is DropDownItem item)
                    {
                        saveTest.CustomerId = item.Id;  
                    }
                }

                if (cboTestType.SelectedItem != null )
                {
                    if ( cboTestType.SelectedItem is DropDownItem item )
                    {
                        saveTest.TestTypeId = item.Id;  
                    }
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
                    DropDownItem item = new DropDownItem(client.ImpactorClientId, client.ShortName);
                    cmbClientName.Items.Add(item);
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
                if (cmbClientName.SelectedItem is DropDownItem item)
                {
                    string strErrorMessage = LoadClientData(item.Id);
                    if ( string.IsNullOrEmpty(strErrorMessage) == false )
                    {
                        MessageBox.Show (strErrorMessage, "Loading Client Data", MessageBoxButtons.OK, MessageBoxIcon.Error );
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
    }
}
