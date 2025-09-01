using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impactor
{
    public partial class IMPFrmLauncher : Form
    {
        private readonly string  _ConnectionString = string.Empty;
        public IMPFrmLauncher( string connectionString )
        {
            _ConnectionString = connectionString;
            InitializeComponent();

            btnUpdateSave.Enabled = false;
            txtName.Enabled = false;
            grpActive.Enabled = false;

            string strErrorMessage = LoadLauncherListBox();
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
            }
            else
            {
                MessageBox.Show (strErrorMessage, "Loading Launchers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string LoadLauncherListBox()
        {
            lstLaunchers.Items.Clear();

            Launcher launchers = new Launcher(_ConnectionString);
            List<Launcher> launcherList = launchers.GetAll(out string strErrorMessage);
            foreach (Launcher launcher in launcherList)
            { 
                DropDownItem item = new DropDownItem(launcher.LauncherId, launcher.Name);
                lstLaunchers.Items.Add(item);
            }

            lstLaunchers.DisplayMember = "Text";
            lstLaunchers.ValueMember = "Id";

            return strErrorMessage;
        }
         
        private void ClearControls()
        {
            txtName.Text = string.Empty;
            rdoTrue.Checked = true;
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            btnUpdateSave.Text = "Save";
            btnUpdateSave.Enabled = true;
            txtName.Enabled = true;
            grpActive.Enabled = true;
        }

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            string strErrorMessage = string.Empty;

            Launcher launcher = new Launcher(_ConnectionString)
            {
                Name = txtName.Text,
                Active = rdoTrue.Checked,
            };

            if (btnUpdateSave.Text == "Save")
            {
                strErrorMessage = launcher.Insert();
            }
            else
            {
                if (lstLaunchers.SelectedItem is DropDownItem item)
                {
                    launcher.LauncherId = item.Id;
                    strErrorMessage = launcher.Update();
                }

            }

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                MessageBox.Show("New Launcher Saved Successfully", "Launchers", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(strErrorMessage, "Launchers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnUpdateSave.Text = string.Empty;
            btnUpdateSave.Enabled = false;
            grpActive.Enabled = false;
            txtName.Enabled= false; 

            strErrorMessage = LoadLauncherListBox();
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
            }
            else
            {
                MessageBox.Show(strErrorMessage, "Loading Launchers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LstLauncers_SelectedItemChanged(object sender, EventArgs e)
        {
            string strErrorMessage = string.Empty;

            if (lstLaunchers.SelectedItem is DropDownItem item)
            {
                Launcher launcher = new Launcher(_ConnectionString);
                strErrorMessage = launcher.Get(item.Id);
                if ( string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    txtName.Text = launcher.Name;
                    if (launcher.Active == true)
                    {
                        rdoTrue.Checked = true;
                    }
                    else
                    {
                        rdoFalse.Checked = true;    
                    }
                    btnUpdateSave.Text = "Update";
                    btnUpdateSave.Enabled = true;
                    txtName.Enabled = true;
                    grpActive.Enabled = true;

                }
            }

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
            }
            else
            {
                MessageBox.Show(strErrorMessage, "Loading a Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
