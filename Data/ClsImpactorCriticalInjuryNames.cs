using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Data
{
    [XmlRoot("ImpactorCriticalInjuryNames")]
    public class ImpactorCriticalInjuryNames : Database
    {
        [XmlAttribute("ImpactorInjuryTimeId")]
        public long ImpactorCriticalInjuryNamesId { get; set; } = long.MinValue;

        [XmlAttribute("TestParameterName")]
        public string TestParameterName { get; set; } = string.Empty;

        [XmlAttribute("Channel")]
        public string Channel { get; set; } = string.Empty;

        private string _ConnectionString = string.Empty;
        private SqlConnection _Connection = null;

        public ImpactorCriticalInjuryNames(string connectionString) : base(connectionString)
        {
            _ConnectionString = connectionString;
        }

        public string Get(long impactorCriticalInjuryNamesId)
        {
            _Connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetImpactorCriticalImpactorName";
                cmd.Parameters.Add("@CriticalInjuryNamesId", SqlDbType.BigInt).Value = impactorCriticalInjuryNamesId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        if (long.TryParse(reader["CriticalInjuryNamesId"].ToString(), out long lTemp) == true)
                        {
                            ImpactorCriticalInjuryNamesId = lTemp;
                        }

                        TestParameterName = reader["TestParameterName"].ToString();
                        Channel = reader["Channel"].ToString();
                    }
                }
                catch (SqlException sqlEx)
                {
                    strErrorMessage = sqlEx.Message;
                }
                catch (Exception ex)
                {
                    strErrorMessage = ex.Message;
                }
                finally
                {
                    cmd.Dispose();
                    strErrorMessage += Close();
                }
            }

            return strErrorMessage;
        }
        public List<ImpactorCriticalInjuryNames> GetAll(out string errorMessage)
        {
            List<ImpactorCriticalInjuryNames> result = new List<ImpactorCriticalInjuryNames >();
            _Connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllImpactorCriticalParameterNames";

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ImpactorCriticalInjuryNames IParmameterName = new ImpactorCriticalInjuryNames(_ConnectionString);

                            if (long.TryParse(reader["CriticalInjuryNamesId"].ToString(), out long lTemp) == true)
                            {
                                IParmameterName.ImpactorCriticalInjuryNamesId = lTemp;
                            }

                            IParmameterName.TestParameterName = reader["TestParameterName"].ToString();
                            IParmameterName.Channel = reader["Channel"].ToString();

                            result.Add(IParmameterName);
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    errorMessage = sqlEx.Message;
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }
                finally
                {
                    cmd.Dispose();
                    errorMessage += Close();
                }
            }

            return result;
        }
    }
}
