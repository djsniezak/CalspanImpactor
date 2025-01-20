using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                MessageBox.Show ("Connection String is Empty", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            List<long> TestIds = GetTestRunIDList();
        }

        private void BtnRunSummary_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnRunFinal_Clicked(object sender, EventArgs e)
        {

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
                }
            }
        }

        private void BtnLoadTests_Clicked(object sender, EventArgs e)
        {
            if (cmboCustomer.SelectedItem is DropDownItem item)
            {
                TestList tests = new TestList(_ConnectionString);
                List<TestList> testList = tests.GetAllTests(item.Id, dteBegin.Value, dteEnd.Value, out string strErrorMessage);
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    dgvTest.Rows.Clear();
                    foreach (TestList iItem in testList)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        for (int index = 0; index < 7; index++)
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

                        dgvTest.Rows.Add(row);
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
    }
}
