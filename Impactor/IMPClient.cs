﻿using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impactor
{
    public partial class IMPClient : Form
    {
        private readonly string _ConnectionString = string.Empty;

        public IMPClient( string connectionString )
        {
            InitializeComponent();
            _ConnectionString = connectionString;

            string strErrorMessage = LoadClientListBox();
            if ( string.IsNullOrEmpty (strErrorMessage) == false)
            {
                MessageBox.Show (strErrorMessage, "Loading Client Listbox", MessageBoxButtons.OK, MessageBoxIcon.Error );   
            }
        }


        private string LoadClientListBox () 
        { 
            ImpactorClient client = new ImpactorClient(_ConnectionString);

            List<ImpactorClient> clients = client.GetAll(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                lstClient.Items.Clear();

                foreach ( ImpactorClient cl in clients ) 
                { 
                    DropDownItem item = new DropDownItem( cl.ImpactorClientId, cl.CompanyName );
                    lstClient.Items.Add ( item );
                }

                lstClient.DisplayMember = "Text";
                lstClient.ValueMember = "Id";
            }

            return strErrorMessage; 
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LstClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClient.SelectedIndex > -1) 
            { 
                if ( lstClient.SelectedItem is DropDownItem item ) 
                {
                    ClearControls();
                    btnUpdate.Text = "Update";
                    btnNew.Enabled = false;

                    ImpactorClient client = new ImpactorClient(_ConnectionString);
                    string strErrorMessage = client.Get(item.Id);
                    if (string.IsNullOrEmpty(strErrorMessage) == true )
                    {
                        txtCompanyName.Text = client.CompanyName;
                        txtShortName.Text = client.ShortName;
                        txtClientPrefix.Text = client.ClientPrefix;
                        txtClientCode.Text = client.ClientCode;
                        txtAddress1.Text = client.Address1;
                        txtAddress2.Text = client.Address2;
                        txtCity.Text = client.City;
                        txtState.Text = client.State;
                        txtZip.Text = client.Zip;

                        string formattedNumber = Regex.Replace(client.PhoneNumber, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
                        txtPhone.Text = formattedNumber;
                        ckActive.Checked = client.Status;
                    }
                }
            }
        }

        private void ClearControls ()
        {
            txtCompanyName.Text = string.Empty;
            txtShortName.Text = string.Empty;
            txtClientPrefix.Text = string.Empty;
            txtClientCode.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtZip.Text = string.Empty;
            txtPhone.Text = string.Empty;
            ckActive.Checked = false;
        }

        private bool ValidateControls ()
        {
            bool IsValid = false;
            if (txtCompanyName.Text != string.Empty)
            {
                if (txtShortName.Text != string.Empty)
                {
                    if (txtClientPrefix.Text != string.Empty)
                    {
                        IsValid = true;
                    }
                    else
                    {
                        MessageBox.Show("Please enter the Client Prefix", "Clients", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the Company Short Name", "Clients", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show ("Please enter the Company Name", "Clients", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return IsValid;
        }
        private void BtnNew_Clicked(object sender, EventArgs e)
        {
            ClearControls();
            btnUpdate.Text = "Save";
            ckActive.Checked = true;
        }

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (ValidateControls() == true)
            {
                ImpactorClient client = new ImpactorClient(_ConnectionString)
                {
                    CompanyName = txtCompanyName.Text,
                    ShortName = txtShortName.Text,
                    ClientPrefix = txtClientPrefix.Text,
                    ClientCode = txtClientCode.Text,
                    Address1 = txtAddress1.Text,
                    Address2 = txtAddress2.Text,
                    City = txtCity.Text,
                    State = txtState.Text,
                    Zip = txtZip.Text,
                    Status = ckActive.Checked,
                };

                string input = txtPhone.Text;
                string pattern = @"[^\d]";
                string replacement = "";

                string result = Regex.Replace(input, pattern, replacement);
                client.PhoneNumber = result;

                string strErrorMessage = string.Empty;
                if (btnUpdate.Text == "Save")
                {
                    strErrorMessage = client.Insert();
                }
                else
                {
                    if (lstClient.SelectedItem is DropDownItem item)
                    {
                        client.ImpactorClientId = item.Id;
                        strErrorMessage = client.Update();
                    }
                }

                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    strErrorMessage = LoadClientListBox();
                    if (string.IsNullOrEmpty(strErrorMessage) == true)
                    {
                        ClearControls();
                        btnNew.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(strErrorMessage, "Loading Client Listbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(strErrorMessage, "Updateing Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
