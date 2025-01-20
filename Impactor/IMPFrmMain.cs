using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Impactor
{
    public partial class IMPFrmMain : Form
    {
        private readonly string _ConnectionString = string.Empty;
        public IMPFrmMain()
        {
            InitializeComponent();
            _ConnectionString = ConfigurationManager.ConnectionStrings["Impactor"].ConnectionString;
        }

        private void MnuExit(object sender, EventArgs e)
        {
            Close();
        }

        private void MnuImpactor_Click(object sender, EventArgs e)
        {
            IMPFrmImpactor frm = new IMPFrmImpactor(_ConnectionString)
            {
                MdiParent = this
            };

            frm.Show();
        }

        private void MnuAbout_Click(object sender, EventArgs e)
        {
            IMPAbout frm = new IMPAbout();
            frm.ShowDialog();
        }

        private void MnuClient_Click(object sender, EventArgs e)
        {
            IMPClient frm = new IMPClient(_ConnectionString);

            switch (frm.ShowDialog())
            {
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;

            }
        }

        private void MnuTestType_Click(object sender, EventArgs e)
        {
            IMPFrmTestType frm = new IMPFrmTestType (_ConnectionString);

            switch (frm.ShowDialog())
            {
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }
        }

        private void MnuImpactorType_Click(object sender, EventArgs e)
        {
            IMPFrmImpactorType frm = new IMPFrmImpactorType(_ConnectionString);
            switch (frm.ShowDialog())
            {
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }
        }

        private void MnuProtocil_Click(object sender, EventArgs e)
        {
            IMPFrmProtocol frm = new IMPFrmProtocol (_ConnectionString);

            switch (frm.ShowDialog()) 
            { 
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }
        }

        private void MnuSpecimen_Click(object sender, EventArgs e)
        {
            IMPSpecimen frm = new IMPSpecimen(_ConnectionString);

            switch (frm.ShowDialog())
            {
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }
        }

        private void MnuRunReports_Clicked(object sender, EventArgs e)
        {
            FrmReports frm = new FrmReports(_ConnectionString);
            switch (frm.ShowDialog())
            {
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }
        }
    }
}
