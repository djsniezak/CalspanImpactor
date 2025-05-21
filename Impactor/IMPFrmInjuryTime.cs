using Data;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impactor
{
   
    public partial class IMPFrmInjuryTime : Form
    {
        private readonly string _ConnectionString = string.Empty;
        public IMPFrmInjuryTime(string connectionString)
        {
            InitializeComponent();
            _ConnectionString = connectionString; 
            LoadStatusCombo();
            string strErrorMessage = LoadInjuryTypeListbox();
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                EnableDisable(false);
                btnNew.Enabled = true;
                btnSaveUpdate.Enabled = false;
            }
            else
            {
                MessageBox.Show (strErrorMessage, "Loading Injury Types", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Text == "Close")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                ClearAll();
                btnNew.Enabled = true;
                btnSaveUpdate.Text = string.Empty;
                btnClose.Text = "Close";
            }
        }

        private void LoadStatusCombo ()
        {
            DropDownItem item = new DropDownItem(true, "Active");
            cmboStatus.Items.Add(item);
            item = new DropDownItem (false, "Not Active");
            cmboStatus.Items.Add(item);
            cmboStatus.DisplayMember = "Text";
            cmboStatus.ValueMember = "Id";
        }

        private string LoadInjuryTypeListbox()
        {
            ImpactorInjuryTime iType = new ImpactorInjuryTime(_ConnectionString);
            List<ImpactorInjuryTime> iTypeList = iType.GetAll(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true )
            {
                lstInjuryType.Items.Clear();

                foreach (ImpactorInjuryTime lType in iTypeList)
                {
                    DropDownItem lItem = new DropDownItem(lType.ImpactorInjuryTimeId, lType.ShortName);
                    if (lType.Status == true || ckShowAll.Checked == true)
                    {
                        lstInjuryType.Items.Add(lItem);
                    }
                }

                lstInjuryType.DisplayMember = "Text";
                lstInjuryType.ValueMember = "Id";
            }

            return strErrorMessage;
        }

        private void ClearAll()
        {
            lblInjuryTimeIdValue.Text = string.Empty;
            txtShortName.Text = string.Empty;
            txtInjuryDefinition.Text = string.Empty;
            txtDescription.Text = string.Empty; 
            txtDefaultUnits.Text = string.Empty;
            cmboStatus.SelectedIndex = -1;
            ckMaxTime.Checked = false;
            ckMinTime.Checked = false;  
            ckMaxValue.Checked = false; 
            ckMinValue.Checked = false; 
        }

        private void BtnNew_Clicked(object sender, EventArgs e)
        {
            ClearAll();
            EnableDisable(true);
            btnNew.Enabled = false;
            btnSaveUpdate.Text = "Save";
            btnSaveUpdate.Enabled = true;
            ComboFuctions.SelectCmboItem (cmboStatus, true);
            btnClose.Text = "Clear";
        }

        private void BtnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            string strErrorMessage = string.Empty;
            string Title = string.Empty;

            ImpactorInjuryTime iType = new ImpactorInjuryTime(_ConnectionString)
            {
                ShortName = txtShortName.Text,
                InjuryDefinition = txtInjuryDefinition.Text,
                Description = txtDescription.Text,
                DefaultUnits = txtDefaultUnits.Text,
                MaxValueUsed = ckMaxValue.Checked,
                MinValueUsed = ckMinValue.Checked,
                MaxTimeUsed = ckMaxTime.Checked,
                MinTimeUsed = ckMinTime.Checked,
            };

            if (cmboStatus.SelectedItem is DropDownItem item)
            {
                iType.Status = item.BoolValue;
            }

            if (string.IsNullOrEmpty(lblInjuryTimeIdValue.Text) == false)
            {
                if (long.TryParse(lblInjuryTimeIdValue.Text, out long tLong) == true)
                {
                    Title = "Updateing Injury Type with InjuryTypeId: " + tLong.ToString();
                    iType.ImpactorInjuryTimeId = tLong;
                    strErrorMessage = iType.Update();
                }
            }
            else
            {
                Title = "Inserting New Injury Type";
                strErrorMessage = iType.Insert();
            }
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                strErrorMessage = LoadInjuryTypeListbox();
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    ClearAll();
                    EnableDisable(false);
                    btnNew.Enabled = true;
                    btnSaveUpdate.Text = string.Empty;
                    btnSaveUpdate.Enabled = false;
                    btnClose.Text = "Close";
                    MessageBox.Show(iType.ShortName + " was saved successfully.", "New/Update Injury Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(strErrorMessage, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show (strErrorMessage, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EnableDisable (bool value)
        {
            txtShortName.Enabled = value;
            txtInjuryDefinition.Enabled = value;
            txtDescription.Enabled = value; 
            txtDefaultUnits.Enabled = value;    
            cmboStatus.Enabled = value;
            ckMaxTime.Enabled = value;
            ckMaxValue.Enabled = value;
            ckMinTime.Enabled = value;
            ckMinValue.Enabled = value;
        }

        private void LstInjuryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstInjuryType.SelectedItem is DropDownItem item)
            {
                EnableDisable(true);
                btnNew.Enabled = false;
                btnSaveUpdate.Text = "Update";
                btnSaveUpdate.Enabled = true;
                btnClose.Text = "Clear";

                ImpactorInjuryTime iType = new ImpactorInjuryTime(_ConnectionString);
                string strErrorMessage = iType.Get (item.Id);
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    lblInjuryTimeIdValue.Text = iType.ImpactorInjuryTimeId.ToString();
                    txtShortName.Text = iType.ShortName;
                    txtInjuryDefinition.Text = iType.InjuryDefinition;
                    txtDescription.Text = iType.Description;
                    txtDefaultUnits.Text = iType.DefaultUnits;
                    ComboFuctions.SelectCmboItem(cmboStatus, iType.Status);
                    ckMaxValue.Checked = iType.MaxValueUsed;
                    ckMaxTime.Checked = iType.MaxTimeUsed;
                    ckMinValue.Checked = iType.MinValueUsed;
                    ckMinTime.Checked = iType.MinTimeUsed;
                }
            }
        }

        private void CkShow_All_CheckChanged(object sender, EventArgs e)
        {
            string strErrorMessage = LoadInjuryTypeListbox();
            if (string.IsNullOrEmpty(strErrorMessage) == false)
            {
                MessageBox.Show (strErrorMessage, "Loading Injury Type Listbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
