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
    public partial class IMPFrmVehicleDamage : Form
    {
        private readonly string _ConnectionString = string.Empty;
        private readonly long _TestRunId = long.MinValue;
        private long _VehicleDamageId = long.MinValue;
        private bool _IsDirty = false;
        public IMPFrmVehicleDamage( string connectionString, long testRunId)
        {
            _ConnectionString = connectionString;
            _TestRunId = testRunId;

            InitializeComponent();
            string strErrorMessage = LoadVehicleDamage();
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
            }
            else
            {
                MessageBox.Show(strErrorMessage, "Issue Reading Vehicle Damage for " + testRunId.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            if (_IsDirty == true)
            {
                DialogResult = MessageBox.Show ("The text has changed.\nDo you want to save before closing?", "Text has Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    BtnSave_Click(this, null);
                }
            }
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            string strErrorMessage;

            VehicleDamage vehicleDamage = new VehicleDamage(_ConnectionString)
            {
                TestRunId = _TestRunId,
                VehicleDamageText = txtVehicalDamage.Text,
            };

            if (_VehicleDamageId == long.MinValue)
            {
                strErrorMessage = vehicleDamage.Insert();
            }
            else
            {
                vehicleDamage.VehicleDamageId = _VehicleDamageId;
                strErrorMessage = vehicleDamage.Update();
            }

            if (string.IsNullOrEmpty (strErrorMessage) == true) 
            {
                _IsDirty = false;
            }
            else
            {
                MessageBox.Show (strErrorMessage, "Issues Saving Vehicle Damage for Test Run" + _TestRunId.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string LoadVehicleDamage()
        {
            string strErrorMessage;

            if (_TestRunId != long.MinValue)
            {
                VehicleDamage vehicleDamage = new VehicleDamage(_ConnectionString);
                strErrorMessage = vehicleDamage.Get(_TestRunId);
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    txtVehicalDamage.Text = vehicleDamage.VehicleDamageText;
                    _VehicleDamageId = vehicleDamage.VehicleDamageId;
                }
            }
            else
            {
                strErrorMessage = "Please load a test before attempting to load the Vehicle Damage screen";
            }

            return strErrorMessage;
        }

        private void TxtVehicleDamage_TextChanged(object sender, EventArgs e)
        {
            _IsDirty = true;
        }
    }
}
