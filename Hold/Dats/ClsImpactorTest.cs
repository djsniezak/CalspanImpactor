using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data.SqlClient;
using Dats;

namespace Data
{
    [XmlRoot("ImpactorTest")]
    public class ImpactorTest : Database 
    {
        [XmlAttribute("ImpactorTestId")]
        public long ImpactorTestId { get; set; } = long.MinValue;

        [XmlAttribute("ImpactorRun")]
        public string ImpactorRunNumber { get; set; } = string.Empty;

        [XmlAttribute("RunTime")]
        public DateTime RunTime { get; set; } = DateTime.MinValue;

        [XmlAttribute("CustomerId")]
        public long CustomerId { get; set; } = long.MinValue;

        [XmlAttribute("Engineer")]
        public string Engineer { get; set; } = string.Empty;

        [XmlAttribute("Operator")]
        public string Operator { get; set; } = string.Empty;

        [XmlAttribute("Temperature")]
        public decimal Temperature { get; set; } = decimal.MinValue;

        [XmlAttribute("Humidity")]
        public decimal Humidity { get; set; } = decimal.MinValue;

        [XmlAttribute("Notes")]
        public string Notes { get; set; }  = string.Empty;

        public ImpactorTest ()
        {

        }

        public string Load ( SqlConnection connection, long ImpactorId )
        {
            string strErrorMessage = string.Empty;
            return strErrorMessage;
        }

        public string Insert ( SqlConnection connection )
        {
            string strErrorMessage = string.Empty;
            return strErrorMessage;
        }

        public string Update ( SqlConnection connection ) 
        {
            string strErrorMessage = string.Empty;
            return strErrorMessage;
        }

        private string OpenDatabase ()
        {
            return Open();
        }
    }
}
