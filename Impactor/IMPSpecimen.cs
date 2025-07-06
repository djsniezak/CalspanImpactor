using Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Impactor
{
    public partial class IMPSpecimen : Form
    {
        private readonly string _ConnectionString = string.Empty;
        public IMPSpecimen(string connectionString)
        {
            InitializeComponent();
            _ConnectionString = connectionString;
            string strErrorMessage = LoadSpecimenList(false);
            if ( string.IsNullOrEmpty(strErrorMessage) == true)
            {
                strErrorMessage = LoadCustomerCbo();
                if ( string.IsNullOrEmpty(strErrorMessage) == false )
                {
                    MessageBox.Show (strErrorMessage, "Loading Customer ComboBox", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
            else
            {
                MessageBox.Show(strErrorMessage, "Loading Specimen Listbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string LoadSpecimenList( bool showAll)
        {
            ImpactorSpecimen spec = new ImpactorSpecimen(_ConnectionString);
            List<ImpactorSpecimen> specimens = spec.GetAll(out string strErrorMessage);
            if ( string.IsNullOrEmpty(strErrorMessage) == true )
            {
                lstSpecimens.Items.Clear();

                foreach (ImpactorSpecimen specimen in specimens)
                {
                    DropDownItem item = new DropDownItem(specimen.SpecimenId, specimen.Make + " " + specimen.Model + " " + specimen.VIN);

                    if (showAll == true)
                    {
                        lstSpecimens.Items.Add(item);
                    }
                    else
                    {
                        if (specimen.Active == true )
                        {
                            lstSpecimens.Items.Add(item);
                        }
                    }
                }

                lstSpecimens.DisplayMember = "Text";
                lstSpecimens.ValueMember = "Id";
            }
            return strErrorMessage;
        }

        private string LoadCustomerCbo()
        {
            ImpactorClient cli = new ImpactorClient(_ConnectionString);
            List<ImpactorClient> clients = cli.GetAll(out string strErrorMessage);
            if ( string.IsNullOrEmpty(strErrorMessage) == true )
            {
                foreach (ImpactorClient client in clients)
                {
                    DropDownItem item = new DropDownItem(client.ImpactorClientId, client.CompanyName);
                    cmboCustomer.Items.Add( item );
                }

                cmboCustomer.DisplayMember = "Text";
                cmboCustomer.ValueMember = "Id";
            }
            return strErrorMessage;
        }

        private void ClearAll ()
        {
            lstSpecimens.SelectedItem = null;
            cmboCustomer.SelectedItem = null;
            txtYear.Text = string.Empty;
            txtMake.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtVIN.Text = string.Empty;
            txtMass.Text = string.Empty;
            txtNotes.Text = string.Empty;
            ckActive.Checked = false;
            ckShowAll.Checked = false;

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnUpdateSave.Text = "Save";
            btnUpdateSave.Enabled = true;
            cmboCustomer.Enabled = true;
            txtYear.Enabled = true;
            txtMake.Enabled = true;
            txtModel.Enabled = true;
            txtVIN.Enabled = true;
            txtMass.Enabled = true;
            txtNotes.Enabled = true;
        }

        private void LstSpecimen_SelectIndexChanged(object sender, EventArgs e)
        {
            btnUpdateSave.Text = "Update";
            btnUpdateSave.Enabled = true;
            cmboCustomer.Enabled = true;
            txtYear.Enabled = true;
            txtMake.Enabled = true;
            txtModel.Enabled = true;
            txtVIN.Enabled = true;
            txtMass.Enabled = true;
            txtNotes.Enabled = true;

            if (lstSpecimens.SelectedItem is DropDownItem item)
            {
                ImpactorSpecimen spec = new ImpactorSpecimen(_ConnectionString);
                string strErrorMessage = spec.Get (item.Id);
                if ( string.IsNullOrEmpty(strErrorMessage) == true )
                {
                    ComboFuctions.SelectCmboItem (cmboCustomer, spec.CustomerId);
                    txtYear.Text = spec.Year.ToString();
                    txtMake.Text = spec.Make.ToString();
                    txtModel.Text = spec.Model.ToString();
                    txtVIN.Text = spec.VIN.ToString();
                    txtMass.Text = spec.Mass.ToString("###0.0");
                    txtNotes.Text = spec.Notes.ToString();
                    ckActive.Checked = spec.Active;

                }
                else
                {
                    MessageBox.Show(strErrorMessage, "Loading Specimen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void BtnUpdateSave_Click(object sender, EventArgs e)
        {
            string strErrorMessage;

            ImpactorSpecimen spec = new ImpactorSpecimen(_ConnectionString)
            {
                Make = txtMake.Text,
                Model = txtModel.Text,
                VIN = txtVIN.Text,
                Notes = txtNotes.Text,
                Active = ckActive.Checked,
            };

            if ( cmboCustomer.SelectedItem is DropDownItem item )
            {
                spec.CustomerId = item.Id;
            }

            if (int.TryParse(txtYear.Text, out int year) == true)
            {
                spec.Year = year;
            }

            if (double.TryParse (txtMass.Text, out double mass) == true)
            {
                spec.Mass = mass;
            }

            if (lstSpecimens.SelectedItem is DropDownItem lstItem)
            {
                spec.SpecimenId = lstItem.Id;
                strErrorMessage = spec.Update();
            }
            else
            {
                strErrorMessage = spec.Insert();
            }

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                strErrorMessage = LoadSpecimenList(false);
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    MessageBox.Show("Specimen Save Successfully", "Saving Specimen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(strErrorMessage, "Loading Specimen List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(strErrorMessage, "Saving Specimen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearAll();
        }

        private void CkShowAll_Clicked(object sender, EventArgs e)
        {
            string strErrorMessage = LoadSpecimenList(ckShowAll.Checked);
            if ( string.IsNullOrEmpty(strErrorMessage) == false )
            {
                MessageBox.Show (strErrorMessage, "Showing Specimen List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
