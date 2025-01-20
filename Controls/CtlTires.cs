using Data;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Controls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class CtlTires : UserControl
    {

        private string _ConnectionString = string.Empty;
        private long _SpecimenId = long.MinValue;
        private long _TestId = long.MinValue;
        private long _TiresId = long.MinValue;

        public CtlTires()
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

        public long Specimen
        {
            get { return _SpecimenId; }
            set { _SpecimenId = value; }
        }

        public long TestId
        {
            get { return _TestId; }
            set { _TestId = value; }
        }

        public string LoadTest(long impactorTestId, long specimenId)
        {
            Specimen = specimenId;
            TestId = impactorTestId;

            string strErrorMessage;
            if (string.IsNullOrEmpty(_ConnectionString) == false)
            {
                Tires tire = new Tires(_ConnectionString);
                strErrorMessage = tire.Get(TestId, Specimen);
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    _TiresId = tire.TiresId;

                    txtSpecificationFront.Text = tire.SpecificationFront;
                    txtSpecificationRear.Text = tire.SpecificationRear;
                    txtPFL.Text = Conversion.FormatDouble(tire.PressureFL, "##0.0");
                    txtPFR.Text = Conversion.FormatDouble(tire.PressureFR, "##0.0");
                    txtPRL.Text = Conversion.FormatDouble(tire.PressureRL, "##0.0");
                    txtPRR.Text = Conversion.FormatDouble(tire.PressureRR, "##0.0");
                    txtHFL.Text = Conversion.FormatDouble(tire.HeightFL, "###0.0");
                    txtHFR.Text = Conversion.FormatDouble(tire.HeightFR, "###0.0");
                    txtHRL.Text = Conversion.FormatDouble(tire.HeightRL, "###0.0");
                    txtHRR.Text = Conversion.FormatDouble(tire.HeightRR, "###0.0");
                    txtNotes.Text = tire.Notes;
                }
            }
            else
            {
                strErrorMessage = "Connnection String is NULL";
            }

            return strErrorMessage;
        }

        public string Save()
        {
            string strErrorMessage;
            if (TestId != long.MinValue)
            {
                if (Specimen != long.MinValue)
                {
                    Tires tire = new Tires(_ConnectionString)
                    {
                        ImpactorTestId = TestId,
                        SpecimenId = Specimen,
                        SpecificationFront = txtSpecificationFront.Text,
                        SpecificationRear = txtSpecificationRear.Text,
                        Notes = txtNotes.Text
                    };

                    if (double.TryParse(txtPFL.Text, out double dTemp) == true)
                    {
                        tire.PressureFL = dTemp;
                    }

                    if (double.TryParse(txtPFR.Text, out dTemp) == true)
                    {
                        tire.PressureFR = dTemp;
                    }

                    if (double.TryParse(txtPRL.Text, out dTemp) == true)
                    {
                        tire.PressureRL = dTemp;
                    }

                    if (double.TryParse(txtPRR.Text, out dTemp) == true)
                    {
                        tire.PressureRR = dTemp;
                    }

                    if (double.TryParse(txtHFL.Text, out dTemp) == true)
                    {
                        tire.HeightFL = dTemp;
                    }

                    if (double.TryParse(txtHFR.Text, out dTemp) == true)
                    {
                        tire.HeightFR = dTemp;
                    }

                    if (double.TryParse(txtHRL.Text, out dTemp) == true)
                    {
                        tire.HeightRL = dTemp;
                    }

                    if (double.TryParse(txtHRR.Text, out dTemp) == true)
                    {
                        tire.HeightRR = dTemp;
                    }

                    if (_TiresId != long.MinValue)
                    {
                        tire.TiresId = _TiresId;
                        strErrorMessage = tire.Update();
                    }
                    else
                    {
                        strErrorMessage = tire.Insert();
                    }
                }
                else
                {
                    strErrorMessage = "SpecimenId not Defined in Tires";
                }
            }
            else
            {
                strErrorMessage = "TestId not Defined in Tires";
            }

            return strErrorMessage;
        }
    }
}
