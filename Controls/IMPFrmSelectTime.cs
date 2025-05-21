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

namespace Controls
{
    public partial class IMPFrmSelectTime : Form
    {
        private string _ConnectionString = string.Empty;
        public long ImpactorInjuryTimeId { get; set; } = long.MinValue;
        public string ShortName { get; set; } = string.Empty;
        
        public IMPFrmSelectTime(string _connectionString)
        {
            _ConnectionString = _connectionString;
            InitializeComponent();
            string strErrorMessage = LoadComboBox();
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
            }
            else
            {
                MessageBox.Show(strErrorMessage, "Loading Injusty Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnUse_Click(object sender, EventArgs e)
        {
            if (cmboTime.SelectedItem is DropDownItem item)
            {
                ImpactorInjuryTimeId = item.Id;
                ShortName = item.Text;
            }

            DialogResult = DialogResult.OK;
        }

        private string LoadComboBox() 
        {
            ImpactorInjuryTime time = new ImpactorInjuryTime(_ConnectionString);
            List<ImpactorInjuryTime> listTime = time.GetAll(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                foreach (ImpactorInjuryTime timeItem in listTime)
                {
                    DropDownItem item = new DropDownItem(timeItem.ImpactorInjuryTimeId, timeItem.ShortName);
                    cmboTime.Items.Add(item);
                }

                cmboTime.DisplayMember = "Text";
                cmboTime.ValueMember = "Id";
            }

            return strErrorMessage;
        }

        private void CmboTime_SelectionChanged(object sender, EventArgs e)
        {
            if (cmboTime.SelectedItem is DropDownItem item)
            {
                ImpactorInjuryTime time = new ImpactorInjuryTime(_ConnectionString);
                string strErrorMessage = time.Get (item.Id);
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    lblShortValue.Text = time.ShortName;
                    lblInjuryDefinitionValue.Text = time.InjuryDefinition;
                    lblDescriptionValue.Text = time.Description;
                    lblDefaultUnitsValue.Text = time.DefaultUnits;

                    ckMaxTimeUsed.Checked = time.MaxTimeUsed;
                    ckMaxValueUsed.Checked = time.MaxValueUsed;
                    ckMinTimeUsed.Checked = time.MinTimeUsed;
                    ckMinValueUsed.Checked = time.MinValueUsed;
                }
            }
        }
    }
}
