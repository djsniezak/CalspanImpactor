using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImpactorControls;
using static ImpactorControls.CtrlTestFilter;
using Data;


namespace Impactor
{
    public partial class IMPFrmImpactor : Form
    {
        private long TestId = long.MinValue;

        public IMPFrmImpactor( string _ConnectionString)
        {
            InitializeComponent();
            ctlParameters.ConnectionString = _ConnectionString;
            ctlTestSetUp.ConnectionString = _ConnectionString;
            ctrlTestFilter.ConnectionString = _ConnectionString;
            ctlProtocol.ConnectionString = _ConnectionString;

            ctrlTestFilter.ImpactorTestSelected += CtrlTestFilter_ImpactorTestSelected;
            ctlTestSetUp.ImpactorTestTypeSelected += CtlTestSetUp_ImpactorTestTypeSelected;
            ctlProtocol.ProtocolSelected += CtlProtocol1_ProtocolSelected;
            

            string strErrorMessage = LoadFilterControl();
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                ctlParameters.Enabled = false;
                ctlProtocol.Enabled = false;
                btnCopy.Enabled = false;
                btnReload.Enabled = false;
                btnSave.Enabled = false;
                btnClearAll.Enabled = false;
            }
            else
            {
                MessageBox.Show(strErrorMessage, "Loading Test Filter Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CtlProtocol1_ProtocolSelected(object sender, EventArgs e)
        {
            if (e is ProtocolId item)
            {
                ctlTestSetUp.ProtocolId = item.SelectedProtocolId;
            }
        }

        private void CtlTestSetUp_ImpactorTestTypeSelected(object sender, EventArgs e)
        {
            if (e is ImpactorTestTypeId item)
            {
                string strErrorMessage = ctlParameters.LoadImpactorCbo(item.SelectedTestTypeId);
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    ctlProtocol.TestType = item.SelectedTestTypeId;
                    strErrorMessage = ctlProtocol.LoadProtocol();
                    if ( string.IsNullOrEmpty(strErrorMessage) == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show(strErrorMessage, "Loading Protocols", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(strErrorMessage, "Loading Impactor Types", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CtrlTestFilter_ImpactorTestSelected(object sender, EventArgs e)
        {
            if (e is ImpactorTestId item)
            {
                TestId = item.SelectedTestId;
                string strErrorMessage = LoadTest();
                if (string.IsNullOrEmpty(strErrorMessage) == false)
                {
                    MessageBox.Show(strErrorMessage, "Loading an Impactor Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string LoadFilterControl ()
        {
            string strErrorMessage = ctrlTestFilter.LoadFilter();
            return strErrorMessage;
        }

        private string LoadTest()
        {
            string strErrorMessage = ctlTestSetUp.LoadTest(TestId);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                strErrorMessage = ctlParameters.LoadTest(TestId);
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    if (ctlTestSetUp.ProtocolId != long.MinValue)
                    {
                        strErrorMessage = ctlProtocol.LoadTest(ctlTestSetUp.ProtocolId);
                        if ( string.IsNullOrEmpty(strErrorMessage) == true )
                        {

                        }
                        else
                        {
                            MessageBox.Show(strErrorMessage, "Loading an Impactor Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    ctlParameters.Enabled = true;
                    ctlProtocol.Enabled = true;
                    btnCopy.Enabled = true;
                    btnReload.Enabled = true;
                    btnSave.Enabled = true; 
                    btnClearAll.Enabled = true;
                }
            }
            return strErrorMessage;
        }

        private void ClearAll()
        {
            ctlTestSetUp.ClearAll();
            ctlParameters.ClearAll();
            ctlProtocol.ClearAll();
        }
        private void BtnNew(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to create a New Impactor Test?", "New Impactor Test", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (Result)
            {
                case DialogResult.Yes:
                    ctlParameters.ClearAll();

                    string strErrorMessage = CreateNew();
                    if (string.IsNullOrEmpty(strErrorMessage) == true)
                    {
                        strErrorMessage = ctlTestSetUp.CreateNewTest();
                        if (string.IsNullOrEmpty(strErrorMessage) == true)
                        {
                            TestId = ctlTestSetUp.TestId;
                            strErrorMessage = ctrlTestFilter.LoadFilter();
                            if (string.IsNullOrEmpty(strErrorMessage) == true)
                            {
                                strErrorMessage = LoadTest();
                                if ( string.IsNullOrEmpty(strErrorMessage) == true)
                                {

                                }
                                else
                                {
                                    MessageBox.Show(strErrorMessage, "Loading New Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show(strErrorMessage, "Loading New Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show(strErrorMessage, "Create New Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show(strErrorMessage, "Create New Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    break;

            }
        }

        private string CreateNew ()
        {
            return ctlTestSetUp.CheckforRequiredNewTestFields();
        }

        private void BtnSave(object sender, EventArgs e)
        {
            if (TestId != long.MinValue)
            {
                ctlTestSetUp.TestId = TestId;
                string strErrorMessage = ctlTestSetUp.Save();
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    bool after = false;
                    if ( e is SaveOptions options )
                    {
                        after = options.isAfterCopy;
                    }
                    ctlParameters.TestId = TestId;
                    strErrorMessage = ctlParameters.Save( after );
                    if ( string.IsNullOrEmpty(strErrorMessage) == true )
                    {
                        MessageBox.Show( "Saving Test Id: " + ctlTestSetUp.TestNumber + " was successful", "Save Impactor Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(strErrorMessage, "Save Impactor Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(strErrorMessage, "Save Impactor Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No Impactor Test Selected to Save.", "Save Impactor Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCopy(object sender, EventArgs e)
        {
            ctlParameters.ClearControl("txtTrigger1");
            ctlParameters.ClearControl("txtTrigger2");
            ctlParameters.ClearControl("txtFirePressure");
            ctlParameters.ClearControl("txtCylinderSpeed");
            ctlParameters.ClearControl("txtMeasureSpeed");
            ctlParameters.ClearControl("txtCylinderwithout");
            ctlParameters.ClearControl("txtAcceleratorTemperature");
            ctlParameters.ClearControl("txtTankTemperature");
            ctlParameters.ClearAxis();
            ctlParameters.ClearControl("txtAirbag1");
            ctlParameters.ClearControl("txtAirbag2");
            ctlParameters.ClearControl("txtAirbag3");

            string strErrorMessage = CreateNew();
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                strErrorMessage = ctlTestSetUp.CreateNewTest();
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    TestId = ctlTestSetUp.TestId;
                    strErrorMessage = ctrlTestFilter.LoadFilter();
                    if (string.IsNullOrEmpty(strErrorMessage) == true)
                    {
                        SaveOptions options = new SaveOptions()
                        {
                            isAfterCopy = true,
                        };

                        BtnSave(null, options);
                    }
                    else
                    {
                        MessageBox.Show(strErrorMessage, "Loading New Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show(strErrorMessage, "Create New Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void BtnReload(object sender, EventArgs e)
        {
            ImpactorTestId ne = new ImpactorTestId()
            {
                SelectedTestId = TestId,
            };

            CtrlTestFilter_ImpactorTestSelected(null, ne);
        }

        private void BrnClearAll_Click(object sender, EventArgs e)
        {
            ClearAll();
            ctlParameters.Enabled = false;
            ctlProtocol.Enabled = false;    
            btnClearAll.Enabled = false;
            btnReload.Enabled = false;  
            btnSave.Enabled = false;
            btnCopy.Enabled = false;
        }
    }
}
