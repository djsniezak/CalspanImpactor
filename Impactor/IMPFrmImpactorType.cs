using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impactor
{
    public partial class IMPFrmImpactorType : Form
    {
        private readonly string _ConnectionString = string.Empty;
        public IMPFrmImpactorType( string connectionString)
        {
            InitializeComponent();
            _ConnectionString = connectionString;

            string strErrorMessage = LoadImpactorTypeList();
            if ( string.IsNullOrEmpty(strErrorMessage) == true ) 
            {
                strErrorMessage = LoadImpactorTestTypeCombo();
                if ( string.IsNullOrEmpty(strErrorMessage) == true ) 
                { 
                }
                else
                {
                    MessageBox.Show (strErrorMessage, "Loading TestType Dropdown", MessageBoxButtons.OK, MessageBoxIcon.Error );    
                }
            }
            else
            {
                MessageBox.Show(strErrorMessage, "Loading Impactor Type Listbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string LoadImpactorTypeList()
        {
            ImpactorType ImpactorType = new ImpactorType(_ConnectionString);
            List<ImpactorType> ImpactorTypes = ImpactorType.GelAll(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true )
            {
                lstImpactorType.Items.Clear();

                foreach (ImpactorType TypeImpactor in ImpactorTypes)
                {
                    ImpactorTestType TestType = new ImpactorTestType (_ConnectionString);
                    strErrorMessage = TestType.Get (TypeImpactor.ImpactorTestTypeId);
                    if ( string.IsNullOrEmpty(strErrorMessage) == true)
                    {
                        DropDownItem DropDownItem = new DropDownItem (TypeImpactor.ImpactorTypeId, TestType.TestName + " - " + TypeImpactor.SerialNumber);
                        lstImpactorType.Items.Add ( DropDownItem );
                    }
                    else
                    {
                        break;
                    }
                }

                lstImpactorType.DisplayMember = "Text";
                lstImpactorType.ValueMember = "Id";
            }


            return strErrorMessage;
        }

        private void ClearControls()
        {
            txtOwner.Text = string.Empty;
            txtSerialNumber.Text = string.Empty;
            cmboImpactorTestType.SelectedIndex = -1;
        }

        private string LoadImpactorTestTypeCombo()
        {
            ImpactorTestType TestType = new ImpactorTestType(_ConnectionString);   
            List<ImpactorTestType> testTypes = TestType.GetAll(out string strErrorMessage);
            if ( string.IsNullOrEmpty (strErrorMessage) == true )
            {
                cmboImpactorTestType.Items.Clear();

                foreach ( ImpactorTestType type in testTypes )
                {
                    DropDownItem item = new DropDownItem(type.ImpactorTestTypeId, type.TestName);
                    cmboImpactorTestType.Items.Add(item);
                }

                cmboImpactorTestType.DisplayMember = "Text";
                cmboImpactorTestType.ValueMember = "Id";
            }

            return strErrorMessage;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void EnableDisableControls () { }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            btnUpdate.Text = "Save";
            ClearControls();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string strErrorMessage = string.Empty;
            ImpactorType type = new ImpactorType(_ConnectionString)
            {
                Owner = txtOwner.Text,
                SerialNumber = txtSerialNumber.Text,
            };

            if (cmboImpactorTestType.SelectedItem is DropDownItem item)
            {
                type.ImpactorTestTypeId = item.Id;

                if ( btnUpdate.Text == "Save")
                {
                    strErrorMessage = type.Insert();
                }
                else
                {
                    if (lstImpactorType.SelectedItem is DropDownItem lstitem)
                    {
                        type.ImpactorTypeId = lstitem.Id;
                        strErrorMessage = type.Update();
                    }
                }
            }
            else
            {
                strErrorMessage = "Please Select a Test Type.";
            }

            if ( string.IsNullOrEmpty(strErrorMessage) == true )
            {
                ClearControls();
                strErrorMessage = LoadImpactorTypeList();
                if ( string.IsNullOrEmpty(strErrorMessage) == false )
                {
                    MessageBox.Show(strErrorMessage, "Loading the Test Type Listbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show( strErrorMessage, "Updating or Saving Test Type", MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
        }

        private void LstImpactorType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstImpactorType.SelectedItem is DropDownItem item)
            {
                ImpactorType type = new ImpactorType(_ConnectionString);
                string strErrorMessage = type.Get(item.Id);
                if ( string.IsNullOrEmpty (strErrorMessage) == true ) 
                {
                    txtOwner.Text = type.Owner;
                    txtSerialNumber.Text = type.SerialNumber;
                    ComboFuctions.SelectCmboItem(cmboImpactorTestType, type.ImpactorTestTypeId);

                    btnUpdate.Text = "Update";
                }
            }
        }
    }
}
