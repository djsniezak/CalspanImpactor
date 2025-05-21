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
    [XmlRoot("ImpactorTestParameters")]
    public class ImpactorTestParameters : Database
    {
        [XmlAttribute("ImpactorTestParameterId")]
        public long ImpactorTestParameterId { get; set; } = long.MinValue;

        [XmlAttribute("TestRunNumber")]
        public string TestRunNumber { get; set; } = string.Empty;

        [XmlAttribute("ParameterNameId")]
        public long ParameterNameId { get; set; } = long.MinValue;

        [XmlAttribute("ParameterName")]
        public string ParameterName {  get; set; } = string.Empty;  

        [XmlAttribute("Value")]
        public float Value { get; set; } = float.MinValue;

        [XmlAttribute("TimeOne")]
        public float TimeOne { get; set; } = float.MinValue;

        [XmlAttribute("TimeTwo")]
        public float TimeTwo { get; set; } = float.MinValue;

        [XmlAttribute("Duration")]
        public float Duration { get; set; } = float.MinValue;

        private readonly string _ConnectionString = string.Empty;
        private SqlConnection _Connection { get; set; } = null;
        public ImpactorTestParameters(string connectionString) : base(connectionString)
        {
            _ConnectionString = connectionString;
        }

        public ImpactorTestParameters FindName(List<ImpactorTestParameters> parameters, string searchString)
        {
            ImpactorTestParameters found = null;
            if (parameters != null)
            {
                foreach (ImpactorTestParameters param in parameters)
                {
                    if (param.ParameterName == searchString)
                    {
                        found = param;
                        break;
                    }
                }
            }
            return found;
        }

        public List<ImpactorTestParameters> GetAllForATest(string TestRunNumber, out string errorMessage)
        {
            List<ImpactorTestParameters> result = new List<ImpactorTestParameters>();
            _Connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand sqlCommand = _Connection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetTestParametersForATestRun";
                sqlCommand.Parameters.Add("@TestRunNumber", SqlDbType.VarChar).Value = TestRunNumber;

                try
                {
                    reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ImpactorTestParameters Params = new ImpactorTestParameters(_ConnectionString);

                            if (long.TryParse(reader["ImpactorTestParameterId"].ToString(), out long lTemp) == true)
                            {
                                Params.ImpactorTestParameterId = lTemp;
                            }

                            Params.TestRunNumber = reader["TestRunNumber"].ToString();

                            if (long.TryParse(reader["ParameterNameId"].ToString(), out lTemp) == true)
                            {
                                Params.ParameterNameId = lTemp;
                            }

                            Params.ParameterName = reader["TestParameterName"].ToString();

                            if (float.TryParse(reader["Value"].ToString(), out float fTemp) == true)
                            {
                                Params.Value = fTemp;
                            }

                            if (float.TryParse(reader["TimeOne"].ToString(), out fTemp) == true)
                            {
                                Params.TimeOne = fTemp;
                            }

                            if (float.TryParse(reader["TimeTwo"].ToString(), out fTemp) == true)
                            {
                                Params.TimeTwo = fTemp;
                            }

                            if (float.TryParse(reader["Duration"].ToString(), out fTemp) == true)
                            {
                                Params.Duration = fTemp;
                            }

                            result.Add(Params);
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

        public string Insert()
        {
            _Connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = _Connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "InsertTestParameterRecord",
                };

                sqlCommand.Parameters.Add("@TestRunNumber", SqlDbType.VarChar).Value = TestRunNumber;
                sqlCommand.Parameters.Add("@ParameterNameId", SqlDbType.BigInt).Value = ParameterNameId;
                sqlCommand.Parameters.Add("@Value", SqlDbType.Float).Value = Value;
                sqlCommand.Parameters.Add("@TimeOne", SqlDbType.Float).Value = TimeOne;
                sqlCommand.Parameters.Add("@TimeTwo", SqlDbType.Float).Value = TimeTwo;
                sqlCommand.Parameters.Add("@Duration", SqlDbType.Float).Value = Duration;
                
                try
                {
                    object retvalue = sqlCommand.ExecuteScalar();
                    if (long.TryParse(retvalue.ToString(), out long lTemp) == true)
                    {
                        ImpactorTestParameterId = lTemp;
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
                    sqlCommand.Dispose();
                    strErrorMessage += Close();
                }
            }
            return strErrorMessage;

        }

        public string DeleteTestRun(string testRunNumber)
        {
            _Connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = _Connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DeleteTestParameterRecordForATestRun",
                };

                sqlCommand.Parameters.Add("@TestRunNumber", SqlDbType.VarChar).Value = testRunNumber;


                try
                {
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Delete Test Run Number: " + testRunNumber + " Failed. Error Number: " + result.ToString();
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
                    sqlCommand.Dispose();
                    strErrorMessage += Close();
                }
            }
            return strErrorMessage;
        }

        public string Delete(long impactorTestParameterId)
        {
            _Connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = _Connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DeleteTestParameterRecord",
                };

                sqlCommand.Parameters.Add("@ImpactorTestParameterId", SqlDbType.BigInt).Value = impactorTestParameterId;


                try
                {
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Delete An Impactor Injury Time Data Record: " + impactorTestParameterId.ToString() + " Failed. Error Number: " + result.ToString();
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
                    sqlCommand.Dispose();
                    strErrorMessage += Close();
                }
            }
            return strErrorMessage;
        }
    }
}
