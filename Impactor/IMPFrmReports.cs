using Data;
using ImpactorReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Impactor
{
    public partial class FrmReports : Form
    {
        private readonly string _ConnectionString = string.Empty;
        public FrmReports(string _connecitonString)
        {
            InitializeComponent();
            _ConnectionString = _connecitonString;

            if (string.IsNullOrEmpty(_ConnectionString) == false)
            {
                string strErrorMessage = LoadCustomers();
                if (string.IsNullOrEmpty(strErrorMessage) == false)
                {
                    MessageBox.Show (strErrorMessage, "Loading Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show ("Connection String is Empty", "ReportSetup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string LoadCustomers()
        {

            ImpactorClient client = new ImpactorClient(_ConnectionString);
            List<ImpactorClient> customers = client.GetAll(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                foreach (ImpactorClient clt in customers)
                {
                    DropDownItem item = new DropDownItem(clt.ImpactorClientId, clt.ShortName);
                    cmboCustomer.Items.Add(item);

                }

                cmboCustomer.DisplayMember = "Text";
                cmboCustomer.ValueMember = "Id";
            }
            return strErrorMessage;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnRunData_Clicked(object sender, EventArgs e)
        {
            List<TestList> testList = new List<TestList>();
            DataGridViewSelectedRowCollection collection = dgvTest.SelectedRows;
            foreach ( DataGridViewRow row in collection)
            {
                TestList item = new TestList(_ConnectionString)
                {
                    TestRunNumber = row.Cells[0].Value.ToString(),
                    TestType = row.Cells[1].Value.ToString(),
                    Make = row.Cells[3].Value.ToString(),
                    Model = row.Cells[4].Value.ToString(),
                    VIN = row.Cells[5].Value.ToString(),
                };

                if ( int.TryParse(row.Cells[2].Value.ToString(), out int iTemp) == true )
                {
                    item.Year = iTemp;
                }

                if (long.TryParse(row.Cells[6].Value.ToString(), out long lTemp) == true)
                {
                    item.ImpactorTestId = lTemp;
                }

                if (long.TryParse(row.Cells[7].Value.ToString(), out lTemp) == true)
                {
                    item.SpecimenId = lTemp;
                }

                testList.Add(item);
            }

            if (testList.Count > 0)
            {
                progress.Value = 0;

                ReportSetup rpt = new ReportSetup(_ConnectionString);
                string strErrorMessage = rpt.RunDataReport(testList, txtProgress, progress);
                if (string.IsNullOrEmpty (strErrorMessage) == true )
                {
                    string message;
                    if (testList.Count > 1)
                    {
                        message = "Reports Complete";
                    }
                    else
                    {
                        message = "Report Complete";
                    }

                    txtProgress.Text += message;
                }
                else
                {
                    txtProgress.Text += "\n" + strErrorMessage;
                }

                progress.Value = 100;
            }
        }

        private void BtnRunSummary_Clicked(object sender, EventArgs e)
        {
            MessageBox.Show ("This Function is not available in this release", "Run Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnRunFinal_Clicked(object sender, EventArgs e)
        {
            MessageBox.Show("This Function is not available in this release", "Run Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CmboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( cmboCustomer.SelectedItem is DropDownItem item)
            {
                ImpactorClient client = new ImpactorClient(_ConnectionString);
                string strErrorMessage = client.Get(item.Id);
                if ( string.IsNullOrEmpty(strErrorMessage) == true )
                {
                    lblPrefix.Text = client.ClientPrefix;
                    lblCode.Text = client.ClientCode;

                    strErrorMessage = LoadModelCombo();
                    if ( string.IsNullOrEmpty(strErrorMessage) == false )
                    {
                        MessageBox.Show(strErrorMessage, "Loading Client Models", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show( strErrorMessage, "Loading Clients", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnLoadTests_Clicked(object sender, EventArgs e)
        {
            if (cmboCustomer.SelectedItem is DropDownItem item)
            {
                string Model = string.Empty;
                if (cmboModel.SelectedItem is DropDownItem selectedModel)
                {
                    if (selectedModel.Id > 0)
                    {
                        Model = selectedModel.Text;
                    }
                }

                
                TestList tests = new TestList(_ConnectionString);
                List<TestList> testList = tests.GetAllTests(item.Id, dteBegin.Value.AddDays(-1), dteEnd.Value, out string strErrorMessage);
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    dgvTest.Rows.Clear();
                    foreach (TestList iItem in testList)
                    {
                        if (Model == iItem.Model || string.IsNullOrEmpty(Model) == true)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            for (int index = 0; index < 8; index++)
                            {
                                row.Cells.Add(new DataGridViewTextBoxCell());
                            }

                            row.Cells[0].Value = iItem.TestRunNumber;
                            row.Cells[1].Value = iItem.TestType;
                            row.Cells[2].Value = iItem.Year.ToString();
                            row.Cells[3].Value = iItem.Make;
                            row.Cells[4].Value = iItem.Model;
                            row.Cells[5].Value = iItem.VIN;
                            row.Cells[6].Value = iItem.ImpactorTestId.ToString();
                            row.Cells[7].Value = iItem.SpecimenId.ToString();   

                            dgvTest.Rows.Add(row);
                        }
                    }

                    if (dgvTest.Rows.Count > 0)
                    {
                        btnData.Enabled = true;
                        btnSummary.Enabled = true;
                        btnFinal.Enabled = true;
                    }
                    else
                    {
                        btnData.Enabled = false;
                        btnSummary.Enabled = false;
                        btnFinal.Enabled = false;

                    }
                }
                else
                {
                    MessageBox.Show (strErrorMessage, "Loading Test List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string LoadModelCombo()
        {
            string strErrorMessage = string.Empty;
            if (cmboCustomer.SelectedItem is DropDownItem cust)
            {
                cmboModel.Items.Clear();

                ImpactorClient client = new ImpactorClient(_ConnectionString);
                List<ImpactorSpecimen> models = client.GetAllModels(cust.Id, out strErrorMessage);
                if (string.IsNullOrEmpty(strErrorMessage))
                {
                    DropDownItem item = new DropDownItem(-1, "All Models");
                    cmboModel.Items.Add(item);

                    foreach (ImpactorSpecimen model in models)
                    {
                        item = new DropDownItem(model.SpecimenId, model.Model);

                        if (ckShowAll.Checked == true)
                        {
                            cmboModel.Items.Add(item);
                        }
                        else
                        {
                            if (model.Active == true)
                            {
                                cmboModel.Items.Add(item);
                            }
                        }
                    }

                    cmboModel.DisplayMember = "Text";
                    cmboModel.ValueMember = "Id";
                }
            }

            return strErrorMessage;
        }
        private List<long> GetTestRunIDList()
        {
            List<long> TestIds = new List<long>();  

            foreach (DataGridViewRow row in dgvTest.SelectedRows)
            {
                if (long.TryParse(row.Cells[6].Value.ToString(), out long lTemp) == true)
                {
                    TestIds.Add(lTemp);
                }
            }

            return TestIds;
        }

        private void CkShowAll_Checked(object sender, EventArgs e)
        {
            string strErrorMessage = LoadModelCombo();
            if (string.IsNullOrEmpty(strErrorMessage) == false)
            {
                MessageBox.Show (strErrorMessage, "Loading Model Combobox", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            switch (saveDlg.ShowDialog())
            {
                case DialogResult.OK:
                    File.WriteAllText (saveDlg.FileName, txtProgress.Text);
                    break;
                    
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }
        }
    }
}
