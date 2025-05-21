using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Controls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class CtlProtocol : UserControl
    {
        private string _ConnectionString = string.Empty;
        private long _TestType = long.MinValue;

        public event EventHandler ProtocolSelected;
        public CtlProtocol()
        {
            InitializeComponent();
        }
        public string ConnectionString
        {
            set { _ConnectionString = value; }
        }

        public long TestType
        {
            get { return _TestType; }
            set { _TestType = value; }
        }

        public string LoadTest ( long ProtocolId)
        {
            string strErrorMessage = string.Empty;
            if ( ProtocolId != long.MinValue ) 
            {
                ComboFuctions.SelectCmboItem (cboProtocol, ProtocolId);
            }
            else
            {
                strErrorMessage = "Impactor Id not defined in Protocol";
            }
            return strErrorMessage;
        }

        public void ClearAll()
        {
            cboProtocol.Items.Clear();
            lblKgValue.Text = string.Empty;
            lblAimingValue.Text = string.Empty;
            lblNormalImpactSpeedValue.Text = string.Empty;  
            lblNormalImpactAngleValue.Text = string.Empty;
        }
        public string LoadProtocol()
        {
            return LoadProtocolCbo();
        }

        public string Save( long protocolId )
        {
            string strErrorMessage = string.Empty;

            return strErrorMessage;
        }

        private string LoadProtocolCbo()
        {
            cboProtocol.Items.Clear();

            Protocol protocol = new Protocol(_ConnectionString);
            List<Protocol> protocols = protocol.GelAll(out string strErrorMessage);
            if ( string.IsNullOrEmpty ( strErrorMessage) == true ) 
            { 
                protocols = protocols.OrderBy(p => p.Name).ToList();

                foreach ( Protocol p in protocols ) 
                {
                    ImpactorTestType impactor = new ImpactorTestType(_ConnectionString);
                    if (p.ImpactorTypeId == TestType)
                    {
                        strErrorMessage = impactor.Get(p.ImpactorTypeId);
                        if (string.IsNullOrEmpty(strErrorMessage) == true)
                        {
                            DropDownItem item = new DropDownItem(p.ProtocolId, p.Name + "-" + impactor.TestName);
                            cboProtocol.Items.Add(item);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                cboProtocol.DisplayMember = "Text";
                cboProtocol.ValueMember = "Id";
            }

            return strErrorMessage;
        }

        private void CboProtocolIndexChanged(object sender, EventArgs e)
        {
            if (cboProtocol.SelectedItem is DropDownItem item)
            {
                Protocol p = new Protocol(_ConnectionString);
                string strErrorMessage = p.Get(item.Id);
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    lblKgValue.Text = p.ImpactorMass.ToString("#0.0");
                    lblAimingValue.Text = p.TargetingMethod;
                    lblNormalImpactSpeedValue.Text = p.NormalImpactSpeed.ToString("#0.0");
                    lblNormalImpactAngleValue.Text = p.NormalImpactAngle.ToString("#0");

                    EventHandler handler = ProtocolSelected;
                    e = new ProtocolId
                    {
                        SelectedProtocolId = item.Id,
                    };

                    handler?.Invoke(this, e);
                }
                else
                {
                    MessageBox.Show(strErrorMessage, "Loading Protocol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
