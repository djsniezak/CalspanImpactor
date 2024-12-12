using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data
{
    public class DropDownItem
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public DropDownItem() { }
        public DropDownItem(long id, string text)
        {
            Id = id;
            Text = text;
        }
    }

    public class ListBoxItem
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public object Item { get; set; }
        public ListBoxItem() { }
        public ListBoxItem(long id, string text, object item)
        {
            Id = id;
            Text = text;
            Item = item;
        }
    }


    public class ComboFuctions
    {
        public static void SelectCmboItem(ComboBox cmbo, long Id)
        {
            foreach (object obj in cmbo.Items)
            {
                if (obj is DropDownItem item)
                {
                    if (item.Id == Id)
                    {
                        cmbo.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        public static void SelectCmboItem(ComboBox cmbo, string Text)
        {
            foreach (object obj in cmbo.Items)
            {
                if (obj is DropDownItem item)
                {
                    if (item.Text == Text)
                    {
                        cmbo.SelectedItem = item;
                        break;
                    }
                }
            }
        }
    }

    public class Conversion
    {
        private const double MMToKPH = 0.0036;
        public static double ConvertMMPerSecToKPH(int MmPerSec)
        {
            if (MmPerSec != int.MinValue)
            {
                return MmPerSec * MMToKPH;
            }
            else
            {
                return 0.0;
            }
        }

        private const double MToKPH = 3.6;
        public static double ConvertMPerSecToKPH(int MPerSec)
        {
            if (MPerSec != int.MinValue)
            {
                return MPerSec * MToKPH;
            }
            else
            {
                return 0.0;
            }
        }

        public static string FormatDecimal(decimal value, string format)
        {
            string returnValue = "";
            if (value != decimal.MinValue)
            {
                returnValue = value.ToString(format);
            }
            return returnValue;
        }

        public static string FormatInt(int value, string format)
        {
            string returnValue = "";
            if (value != int.MinValue)
            {
                returnValue = value.ToString(format);
            }

            return returnValue;
        }

        public static string FormatFloat(float value, string format)
        {
            string returnValue = "";

            if (value != float.MinValue)
            {
                returnValue = value.ToString(format);
            }

            return returnValue;
        }

        public static string FormatDouble(double value, string format)
        {
            string returnValue = "";

            if (value != double.MinValue)
            {
                returnValue = value.ToString(format);
            }

            return returnValue;
        }

    }
    public class ImpactorTestId : EventArgs
    {
        public long SelectedTestId { get; set; } = long.MinValue;
    }

    public class ImpactorTestTypeId : EventArgs
    {
        public long SelectedTestTypeId { get; set; } = long.MinValue;
    }

    public class ImpactorId : EventArgs
    {
        public long SelectedImpactorId { get; set; } = long.MinValue;
    }

    public class ProtocolId : EventArgs
    {
        public long SelectedProtocolId { get; set; } = long.MinValue;
    }

    public class SaveOptions : EventArgs
    {
        public bool isAfterCopy { get; set; } = false;
    }
}
