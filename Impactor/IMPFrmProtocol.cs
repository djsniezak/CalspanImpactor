using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impactor
{
    public partial class IMPFrmProtocol : Form
    {
        private readonly string _Connection = string.Empty;
        public IMPFrmProtocol(string connection)
        {
            InitializeComponent();
            _Connection = connection;

            string strErrorMessage = LoadProtocols();
            if (string.IsNullOrEmpty(strErrorMessage) == true ) 
            {
                strErrorMessage = LoadTestTypes();
            }

            if ( string.IsNullOrEmpty(strErrorMessage) == true ) 
            {
                DropDownItem item = new DropDownItem(1, "Aiming");
                cmboTargetingMethod.Items.Add(item);
                item = new DropDownItem(2, "PoFC");
                cmboTargetingMethod.Items.Add(item);
                cmboTargetingMethod.DisplayMember = "Text";
                cmboTargetingMethod.ValueMember = "Id";
              
                EnableDisable();
            }
            else
            {
                MessageBox.Show (strErrorMessage, "Loading Protocol Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableDisable ()
        {
            if (lstProtocols.SelectedItem == null)
            {
                btnNew.Enabled = true;
                btnAdd.Enabled = false;
            }
            else
            {
                btnNew.Enabled = false;
                btnAdd.Enabled = true;
            }
            
        }

        private bool ValidateValues ()
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(txtName.Text) == false)
            {
                if (cmboTestType.SelectedItem != null)
                {
                    if (string.IsNullOrEmpty(txtKg.Text) == false)
                    {
                        if (cmboTargetingMethod.SelectedItem != null)
                        {
                            if (string.IsNullOrEmpty (txtMetersPerSecond.Text) == false)
                            {
                                if (string.IsNullOrEmpty(txtNormalImpactAngle.Text) == false)
                                {
                                    isValid = true;
                                }
                                else
                                {
                                    MessageBox.Show("Please enter the normal impact angle", "Protocol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please enter the normal impact speed", "Protocol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a Targeting Method", "Protocol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter the mass of the impactor", "Protocol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Test Type", "Protocol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a name for the Protocol", "Protocol", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }

            return isValid;
        }
        public void ClearAll (bool full)
        {
            txtKg.Text = string.Empty;
            txtMetersPerSecond.Text = string.Empty;  
            txtNormalImpactAngle.Text = string.Empty;
            cmboTargetingMethod.SelectedIndex = -1;

            if ( full == true )
            {
                lstProtocols.SelectedIndex = -1;
                cmboTestType.SelectedIndex = -1;

                txtName.Text = string.Empty;
                txtName.Enabled = false;
                txtName.BackColor = SystemColors.Control;
                btnAdd.Enabled = false;
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            btnUpdate.Text = "Save";
            ClearAll(true);
            txtName.Enabled = true;
            txtName.BackColor = SystemColors.Window;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            btnUpdate.Text = "Save";
            btnNew.Enabled = false;
            ClearAll(false);
            cmboTestType.SelectedIndex = -1;
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string strErrorMessage;

            if (ValidateValues() == true)
            {
                Protocol protocol = new Protocol(_Connection)
                {
                    Name = txtName.Text,
                };

                if (cmboTestType.SelectedItem is DropDownItem item)
                {
                    protocol.ImpactorTypeId = item.Id;
                }

                if (cmboTargetingMethod.SelectedItem is DropDownItem tItem)
                {
                    protocol.TargetingMethod = tItem.Text;
                }

                if (decimal.TryParse(txtKg.Text, out decimal dTemp) == true)
                {
                    protocol.ImpactorMass = dTemp;
                }

                if (decimal.TryParse(txtMetersPerSecond.Text, out dTemp) == true)
                {
                    protocol.NormalImpactSpeed = dTemp;
                }

                if (int.TryParse(txtNormalImpactAngle.Text, out int iTemp) == true)
                {
                    protocol.NormalImpactAngle = iTemp;
                }

                if (btnUpdate.Text == "Save")
                {
                    strErrorMessage = protocol.Insert();
                }
                else
                {
                    if (lstProtocols.SelectedItem is DropDownItem pItem)
                    {
                        protocol.ProtocolId = pItem.Id;
                        strErrorMessage = protocol.Update();
                    }
                    else
                    {
                        strErrorMessage = "Error with the Selected Protocol - No Id.";
                    }
                }

                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    btnUpdate.Text = "Update";
                    ClearAll(true);
                    strErrorMessage = LoadProtocols();
                    if (string.IsNullOrEmpty(strErrorMessage) == false)
                    {
                        MessageBox.Show(strErrorMessage, "Loading Protocol Listbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(strErrorMessage, "Saving/Updating Protocol Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LstProtocol_SlectedIndexChanged(object sender, EventArgs e)
        {
            if ( lstProtocols.SelectedItem is DropDownItem item )
            {
                Protocol protocol = new Protocol(_Connection);
                string strErromMessage = protocol.Get(item.Id);
                if ( string.IsNullOrEmpty(strErromMessage) == true )
                {
                    txtName.Text = protocol.Name;
                    ComboFuctions.SelectCmboItem(cmboTestType, protocol.ImpactorTypeId);
                    ComboFuctions.SelectCmboItem(cmboTargetingMethod, protocol.TargetingMethod);
                    txtKg.Text = protocol.ImpactorMass.ToString("#0.0");
                    txtMetersPerSecond.Text = protocol.NormalImpactSpeed.ToString("#0.0");
                    txtNormalImpactAngle.Text = protocol.NormalImpactAngle.ToString("#0");

                    EnableDisable();
                }
                else
                {
                    MessageBox.Show ( strErromMessage, "Getting Protocol. ID: " + item.Id.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CmboTestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAll(false);
        }

        private string LoadProtocols()
        {
            Protocol protocol = new Protocol (_Connection);
            List<Protocol> protocols = protocol.GelAll(out string strErrorMessage);
            if ( string.IsNullOrEmpty(strErrorMessage) == true )
            {
                protocols = protocols.OrderBy(p => p.Name).ToList();
                lstProtocols.Items.Clear();

                foreach ( Protocol p in protocols) 
                {
                    ImpactorTestType iType = new ImpactorTestType(_Connection);
                    strErrorMessage = iType.Get(p.ImpactorTypeId);
                    if ( string.IsNullOrEmpty(strErrorMessage) == true )
                    {
                        string Name;
                        if ( p.Name.Length < 7)
                        {
                            Name = p.Name + "\t\t" + iType.TestName;
                        }
                        else
                        {
                            Name = p.Name + "\t" + iType.TestName;
                        }
                        
                        DropDownItem item = new DropDownItem( p.ProtocolId, Name);
                        lstProtocols.Items.Add(item);
                    }
                    else
                    {
                        break;
                    }
                }

                lstProtocols.DisplayMember = "Text";
                lstProtocols.ValueMember = "Id";
            }

            return strErrorMessage;
        }

        private string LoadTestTypes() 
        {
            ImpactorTestType TestType = new ImpactorTestType(_Connection);
            List<ImpactorTestType> TestTypes = TestType.GetAll ( out string strErrorMessage);
            if ( string.IsNullOrEmpty(strErrorMessage) == true ) 
            { 
                cmboTestType.Items.Clear();

                foreach ( ImpactorTestType tt in TestTypes ) 
                {
                    DropDownItem item = new DropDownItem(tt.ImpactorTestTypeId, tt.TestName);
                    cmboTestType.Items.Add( item );
                }
                cmboTestType.DisplayMember = "Text";
                cmboTestType.ValueMember = "Id";
            }

            return strErrorMessage;
        }

    }
}
