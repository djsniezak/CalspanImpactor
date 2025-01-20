using Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Impactor
{
    public partial class IMPFrmTestType : Form
    {
        private readonly string _ConnectionString = string.Empty;
        private long TestTypeId = long.MinValue;
        public IMPFrmTestType( string _connectionString)
        {
            _ConnectionString = _connectionString;

            InitializeComponent();
            btnUpdate.Enabled = false;

            string strErrorMessage = LoadTestTypeList();
            if ( string.IsNullOrEmpty(strErrorMessage) == false ) 
            { 
                MessageBox.Show (strErrorMessage, "Loading Test Type Listbox", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private string LoadTestTypeList ()
        {
            ImpactorTestType testType = new ImpactorTestType (_ConnectionString);
            List<ImpactorTestType> testTypes = testType.GetAll(out string strErrorMessage);
            if ( string.IsNullOrEmpty(strErrorMessage) == true ) 
            { 
                lstTestType.Items.Clear();

                foreach (ImpactorTestType type in testTypes)
                {
                    DropDownItem dropDownItem = new DropDownItem( type.ImpactorTestTypeId, type.TestName);
                    lstTestType.Items.Add( dropDownItem );  
                }

                lstTestType.DisplayMember = "Text";
                lstTestType.ValueMember = "Id";
            }

            return strErrorMessage;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ClearControls ()
        {
            txtTestName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        private bool ValidateValues()
        {
            bool isValid = false;

            if (string.IsNullOrEmpty(txtTestName.Text) == true)
            {
                MessageBox.Show("Please enter a test type name", "Saving/Updating Test Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                isValid = true;
            }
            return isValid;
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string strErrorMessage;
            if (ValidateValues() == true)
            {
                ImpactorTestType type = new ImpactorTestType(_ConnectionString)
                {
                    TestName = txtTestName.Text,
                    Description = txtDescription.Text,
                };

                if (btnUpdate.Text == "Save")
                {
                    strErrorMessage = type.Insert();
                }
                else
                {
                    if ( TestTypeId != long.MinValue )
                    {
                        type.ImpactorTestTypeId = TestTypeId;
                        strErrorMessage = type.Update();
                    }
                    else
                    {
                        strErrorMessage = "Test Type Id is undefined.";
                    }
                }

                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    ClearControls();
                    strErrorMessage = LoadTestTypeList();
                    if (string.IsNullOrEmpty(strErrorMessage) == true)
                    {
                        btnNew.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(strErrorMessage, "Loading Test Type Listbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(strErrorMessage, "Updating or Saving Test Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            btnUpdate.Text = "Save";
            btnUpdate.Enabled = true;
        }

        private void LstTestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( lstTestType.SelectedItem is DropDownItem item ) 
            { 
                ImpactorTestType type = new ImpactorTestType(_ConnectionString);
                string strErrorMessage = type.Get (item.Id);
                if ( string.IsNullOrEmpty(strErrorMessage) == true ) 
                { 
                    txtTestName.Text = type.TestName;
                    txtDescription.Text = type.Description; 
                    TestTypeId = type.ImpactorTestTypeId;
                    btnNew.Enabled = false;
                    btnUpdate.Text = "Update";
                    btnUpdate.Enabled = true;
                }
                else
                {
                    MessageBox.Show( strErrorMessage, "Loading Test Type Id:" + item.Id, MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }
    }
}
