using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Data;

namespace Controls
{
    public partial class FrmSelectTestParameter : Form
    {
        private string _Connection = string.Empty;
        public long SelectedId { get; set; } = long.MinValue;
        public string TestParameterName { get; set; } = string.Empty;

        public FrmSelectTestParameter( string connectionString )
        {
            InitializeComponent();
            _Connection = connectionString;
            string strErrorMessage = FillTestParameterNamesComboBox();
            if ( string.IsNullOrEmpty(strErrorMessage) == true )
            {

            }
            else
            {
                MessageBox.Show (strErrorMessage, "Loading Test Parameter Names", MessageBoxButtons.OK, MessageBoxIcon.Error ); 
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (cmboTestParameter.SelectedItem is DropDownItem item)
            {
                SelectedId = item.Id;
                TestParameterName = item.Text;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private string FillTestParameterNamesComboBox()
        {
            TestParameterNames names = new TestParameterNames (_Connection);
            List<TestParameterNames> nameList = names.GetAllForATest(out string strErrorMessage);
            foreach (TestParameterNames name in nameList)
            {
                DropDownItem item = new DropDownItem(name.ImpactorTestNameId, name.TestParameterName);
                cmboTestParameter.Items.Add(item); 
            }
            cmboTestParameter.DisplayMember = "Text";
            cmboTestParameter.ValueMember = "Id";

            return strErrorMessage;
        }
    }
}
