using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impactor
{
    public partial class IMPAbout : Form
    {
        public IMPAbout()
        {
            InitializeComponent();
            Assembly asm = Assembly.GetExecutingAssembly();
            AssemblyName asmName = asm.GetName();
            Version asmVersion = asmName.Version;
            lblVersionValue.Text = asmVersion.Major.ToString() + "." + asmVersion.Minor.ToString() + "." + asmVersion.Build.ToString("000");
            
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
