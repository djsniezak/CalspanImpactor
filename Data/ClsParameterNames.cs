using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{
    [XmlRoot("ImpactorTestParametersNames")]
    public class TestParameterNames : Database
    {
        [XmlAttribute("ImpactorTestNameId")]
        public long ImpactorTestNameId { get; set; } = long.MinValue;

        [XmlAttribute("TestParameterName")]
        public string TestParameterName { get; set; } = string.Empty;

        [XmlAttribute("Active")]
        public bool Active { get; set; } = true;

        private readonly string _ConnectionString = string.Empty;
        private SqlConnection _Connection { get; set; } = null;
        public TestParameterNames (string connectionString) : base(connectionString)
        {
            _ConnectionString = connectionString;
        }

        public string Get (long impactorTestNameId)
        {
            _Connection = Open(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetImpactorTestParameter";
                cmd.Parameters.Add("@ImpactorTestNameId", SqlDbType.BigInt).Value = impactorTestNameId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        if (long.TryParse(reader["ImpactorTestNameId"].ToString(), out long lTemp) == true)
                        {
                            ImpactorTestNameId = lTemp;
                        }

                        TestParameterName = reader["TestParameterName"].ToString();
                        if (bool.TryParse(reader["Active"].ToString(), out bool tBool) == true)
                        {
                            Active = tBool;
                        }
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

        public List<TestParameterNames> GetAllForATest(out string errorMessage)
        {
            List<TestParameterNames> result = new List<TestParameterNames>();
            _Connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand sqlCommand = _Connection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetTestParameterNames";
               
                try
                {
                    reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            TestParameterNames Itype = new TestParameterNames(_ConnectionString);

                            if (long.TryParse(reader["ImpactorTestNameId"].ToString(), out long lTemp) == true)
                            {
                                Itype.ImpactorTestNameId = lTemp;
                            }

                            Itype.TestParameterName = reader["TestParameterName"].ToString();

                            if (bool.TryParse(reader["Active"].ToString(), out bool bTemp) == true)
                            {
                                Itype.Active = bTemp;
                            }

                            result.Add(Itype);
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
                    sqlCommand.Dispose();
                    errorMessage += Close();
                }
            }

            return result;
        }

    }
}
