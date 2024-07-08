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
    public partial class IMPFrmMain : Form
    {
        public IMPFrmMain()
        {
            InitializeComponent();
        }

        private void MnuExit(object sender, EventArgs e)
        {
            Close();
        }

        private void MnuImpactor_Click(object sender, EventArgs e)
        {
            IMPFrmImpactor frm = new IMPFrmImpactor()
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
    }
}
