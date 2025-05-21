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
    public partial class IMPFrmSelectCritical : Form
    {
        private readonly string _ConnectionString = string.Empty;
        public long CriticalInjuryNameId = long.MinValue;
        public string CriticalInjuryName = string.Empty;
        public string CriticalInjuryChannel = string.Empty;
        public IMPFrmSelectCritical(string connectionString)
        {
            InitializeComponent();
            _ConnectionString = connectionString;
            string strErrorMessage = FillCboCriticalinjury();
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
            }
            else
            {
            }
        }

        private string FillCboCriticalinjury()
        {
            ImpactorCriticalInjuryNames name = new ImpactorCriticalInjuryNames(_ConnectionString);
            List<ImpactorCriticalInjuryNames> names = name.GetAll(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                foreach (ImpactorCriticalInjuryNames impactorCriticalInjuryNames in names)
                {
                    DropDownItem item = new DropDownItem(impactorCriticalInjuryNames.ImpactorCriticalInjuryNamesId, impactorCriticalInjuryNames.TestParameterName, impactorCriticalInjuryNames.Channel);
                    cboCriticalInjury.Items.Add(item);
                }

                cboCriticalInjury.DisplayMember = "Text";
                cboCriticalInjury.ValueMember = "Id";
                
            }

            return strErrorMessage;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

        }

        private void CcoCriticalInjury_SelectionChanged(object sender, EventArgs e)
        {
            if ( cboCriticalInjury.SelectedItem is DropDownItem item )
            { 
                CriticalInjuryNameId = item.Id;
                CriticalInjuryName = item.Text;
                CriticalInjuryChannel = item.Value.ToString();
            }
        }
    }
}
