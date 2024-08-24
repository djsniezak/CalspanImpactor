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

            ctrlTestFilter.ImpactorTestSelected += CtrlTestFilter_ImpactorTestSelected;
            ctlTestSetUp.ImpactorTestTypeSelected += CtlTestSetUp_ImpactorTestTypeSelected;

            string strErrorMessage = LoadFilterControl();
            if ( string.IsNullOrEmpty(strErrorMessage) == false )
            {
                MessageBox.Show(strErrorMessage, "Loading Test Filter Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CtlTestSetUp_ImpactorTestTypeSelected(object sender, EventArgs e)
        {
            if ( e is ImpactorTestTypeId item)
            {
                string strErrorMessage = ctlParameters.LoadImpactorCbo ( item.SelectedTestTypeId );
                if ( string.IsNullOrEmpty(strErrorMessage) == false)
                {
                    MessageBox.Show(strErrorMessage, "Loading Impactor Types", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CtrlTestFilter_ImpactorTestSelected(object sender, EventArgs e)
        {
            if ( e is ImpactorTestId item)
            {
                TestId = item.SelectedTestId;
                string strErrorMessage = LoadTest();
                if ( string.IsNullOrEmpty(strErrorMessage) == false )
                {
                    MessageBox.Show (strErrorMessage, "Loading an Impactor Test", MessageBoxButtons.OK, MessageBoxIcon.Error );
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
            if ( string.IsNullOrEmpty(strErrorMessage) == true)
            {
                ctlParameters.LoadTest(TestId);
            }
            return strErrorMessage;
        }
        private void BtnNew(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show ("Do you want to create a New Impactor Test?", "New Impactor Test", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (Result)
            {
                case DialogResult.Yes:
                    ctlParameters.ClearAll();

                    string strErrorMessage = CreateNew();
                    if ( string.IsNullOrEmpty (strErrorMessage) == true )
                    {
                        strErrorMessage = ctlTestSetUp.CreateNewTest();
                        if ( string.IsNullOrEmpty (strErrorMessage) == true )
                        {
                            TestId = ctlTestSetUp.TestId;
                            strErrorMessage = ctrlTestFilter.LoadFilter();
                            if ( string.IsNullOrEmpty (strErrorMessage) == false )
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
                        MessageBox.Show ( strErrorMessage, "Create New Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
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
            string strErrorMessage = ctlTestSetUp.CheckforRequiredNewTestFields();
            if ( string.IsNullOrEmpty (strErrorMessage) == true)
            {

            }

            return strErrorMessage;
        }

        private void BtnSave(object sender, EventArgs e)
        {
            if (TestId != long.MinValue)
            {
                ctlTestSetUp.TestId = TestId;
                string strErrorMessage = ctlTestSetUp.Save();
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    ctlParameters.TestId = TestId;
                    strErrorMessage = ctlParameters.Save();
                }

                if (string.IsNullOrEmpty(strErrorMessage) == false)
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

        }

        private void BtnReload(object sender, EventArgs e)
        {

        }
    }
}
