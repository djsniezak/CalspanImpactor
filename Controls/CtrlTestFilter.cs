using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace ImpactorControls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class CtrlTestFilter : UserControl
    {
        private string _ConnectionString = string.Empty;

        public event EventHandler ImpactorTestSelected;   
        public CtrlTestFilter()
        {
            InitializeComponent();
        }

        public string ConnectionString
        {
            set
            {
                _ConnectionString = value;
            }
        }

        public string LoadFilter()
        {
            lstTests.Items.Clear(); 

            Cursor = Cursors.WaitCursor;
            ImpactorTest ImTest = new ImpactorTest(_ConnectionString);
            List<ImpactorTest> list = ImTest.GetAll(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true )
            {
                list = list.OrderByDescending (X=>X.RunTime).ToList();

                foreach (ImpactorTest test in list) 
                { 
                    DropDownItem item = new DropDownItem(test.ImpactorTestId, test.ImpactorRunNumber + " (" + test.RunTime.ToString() + ")");  
                    lstTests.Items.Add(item);
                }

                lstTests.DisplayMember = "Text";
                lstTests.ValueMember = "Id";
            }

            Cursor = Cursors.Default;
            return strErrorMessage;
        }

        private void LstTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTests.SelectedItem is DropDownItem item)
            {
                EventHandler handler = ImpactorTestSelected;
                e = new ImpactorTestId
                {
                    SelectedTestId = item.Id,
                };

                handler?.Invoke(this, e);
            }
        }
       
       
    }
}
