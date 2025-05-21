using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace Data
{
    [XmlRoot("ImpactorCriticalInjuryData")]
    public class ImpactorCriticalInjuryData : Database
    {
        [XmlAttribute("ImpactorCriticalInjuryDataId")]
        public long ImpactorCriticalInjuryDataId { get; set; } = long.MinValue;

        [XmlAttribute("TestRun")]
        public string TestRun {  get; set; } = string.Empty;

        [XmlAttribute("ImpactorCriticalInjuryNameId")]
        public long ImpactorCriticalInjuryNameId { get; set; } = long.MinValue;

        [XmlAttribute("TestParameterName")]
        public string TestParameterName { get; set; } = string.Empty;

        [XmlAttribute("Channel")]
        public string Channel { get; set; } = string.Empty;

        [XmlAttribute("Value")]
        public string Value { get; set; } = string.Empty;

        [XmlAttribute("Time")]
        public float Time { get; set; } = float.MinValue;

        private string _ConnectionString = string.Empty;
        private SqlConnection _Connection = null;

        public ImpactorCriticalInjuryData(string connectionString) : base(connectionString)
        {
            _ConnectionString = connectionString;
        }

        public List<ImpactorCriticalInjuryData> GetAll ( string testRun, out string errorMessage)
        {
            List<ImpactorCriticalInjuryData> result = new List<ImpactorCriticalInjuryData>();
            _Connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllCriticalInjuryDataForaTestRun";
                cmd.Parameters.Add("@TestRun", SqlDbType.VarChar).Value = testRun;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ImpactorCriticalInjuryData IinjuryData = new ImpactorCriticalInjuryData(_ConnectionString);

                            if (long.TryParse(reader["ImpactorCriticalInjuryDataId"].ToString(), out long lTemp) == true)
                            {
                                IinjuryData.ImpactorCriticalInjuryDataId  = lTemp;
                            }

                            IinjuryData.TestRun = reader["TestRun"].ToString();

                            if (long.TryParse(reader["ImpactorCriticalInjuryNameId"].ToString(), out lTemp) == true)
                            {
                                IinjuryData.ImpactorCriticalInjuryNameId = lTemp;
                            }

                            IinjuryData.TestParameterName = reader["TestParameterName"].ToString();
                            IinjuryData.Channel = reader["Channel"].ToString();
                            IinjuryData.Value = reader["Value"].ToString();

                            if ( float.TryParse (reader["Time"].ToString(), out float fTemp) == true )
                            {
                                IinjuryData.Time = fTemp;
                            }

                            result.Add(IinjuryData);
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

        public string Get(long impactorCriticalInjuryDataId)
        {
            {
                _Connection = Open(out string strErrorMessage);

                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    SqlDataReader reader;
                    SqlCommand cmd = _Connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetImpactorInjuryTimeDataForATest";
                    cmd.Parameters.Add("@CriticalInjuryNamesId", SqlDbType.BigInt).Value = impactorCriticalInjuryDataId;

                    try
                    {
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();

                            if (long.TryParse(reader["ImpactorCriticalInjuryDataId"].ToString(), out long lTemp) == true)
                            {
                                ImpactorCriticalInjuryDataId = lTemp;
                            }

                            TestRun = reader["TestRun"].ToString();

                            if (long.TryParse(reader["ImpactorCriticalInjuryNameId"].ToString(), out lTemp) == true)
                            {
                                ImpactorCriticalInjuryNameId = lTemp;
                            }

                            TestParameterName = reader["TestParameterName"].ToString();
                            Channel = reader["Channel"].ToString();
                            Value = reader["Value"].ToString();

                            if (float.TryParse(reader["Time"].ToString(), out float fTemp) == true)
                            {
                                Time = fTemp;
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
                    CommandText = "InsertImpactorCriticalInjuryData",
                };

                sqlCommand.Parameters.Add("@TestrUN", SqlDbType.VarChar).Value = TestRun;
                sqlCommand.Parameters.Add("@ImpactorCriticalInjuryNameId", SqlDbType.BigInt).Value = ImpactorCriticalInjuryNameId;
                sqlCommand.Parameters.Add("@Value", SqlDbType.VarChar).Value = Value;
                sqlCommand.Parameters.Add("@Time", SqlDbType.Float).Value = Time;

                try
                {
                    object retvalue = sqlCommand.ExecuteScalar();
                    if (long.TryParse(retvalue.ToString(), out long lTemp) == true)
                    {
                        ImpactorCriticalInjuryDataId = lTemp;
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
                    CommandText = "DeleteImpactorCriticalInjuryDataForATestRun",
                };

                sqlCommand.Parameters.Add("@TestRun", SqlDbType.VarChar).Value = testRunNumber;


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


        public string Delete(long impactorCriticalInjuryDataId)
        {
            _Connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = _Connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DeleteImpactorCriticalInjuryDataRecord",
                };

                sqlCommand.Parameters.Add("@ImpactorCriticalInjuryDataId ", SqlDbType.BigInt).Value = impactorCriticalInjuryDataId;


                try
                {
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Delete An Impactor Injury Time Data Record: " + impactorCriticalInjuryDataId.ToString() + " Failed. Error Number: " + result.ToString();
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
        public ImpactorCriticalInjuryData FindName(List<ImpactorCriticalInjuryData> criticalInjuryData, string searchString)
        {
            ImpactorCriticalInjuryData found = null;
            if (criticalInjuryData != null)
            {
                foreach (ImpactorCriticalInjuryData criticalData in criticalInjuryData)
                {
                    if (criticalData.TestParameterName == searchString)
                    {
                        found = criticalData;
                        break;
                    }
                }
            }
            return found;
        }

    }
}
