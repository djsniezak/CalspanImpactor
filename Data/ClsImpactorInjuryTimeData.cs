using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace Data
{
    [XmlRoot("ImpactorInjuryTimeData")]
    public class ImpactorInjuryTimeData : Database
    {
        [XmlAttribute("ImpactorInjuryTimeDataId")]
        public long ImpactorInjuryTimeDataId { get; set; } = long.MinValue;

        [XmlAttribute("TestRunNumber")]
        public string TestRunNumber { get; set; } = string.Empty;

        [XmlAttribute("ImpactorInjuryTimeId")]
        public long ImpactorInjuryTimeId { get; set; } = long.MinValue;

        [XmlAttribute("ShortName")]
        public string ShortName { get; set; } = string.Empty;

        [XmlAttribute("MaxValue")]
        public float MaxValue { get; set; } = float.MinValue;

        [XmlAttribute("MaxTime")]
        public float MaxTime { get; set; } = float.MinValue;

        [XmlAttribute("MinValue")]
        public float MinValue { get; set; } = float.MinValue;

        [XmlAttribute("MinTime")]
        public float MinTime { get; set; } = float.MinValue;

        [XmlAttribute("Units")]
        public string Units {  get; set; } = string.Empty;

        [XmlAttribute("TimeStamp")]
        public DateTime TimeStamp {  get; set; } = DateTime.MinValue;

        [XmlAttribute("Notes")]
        public string Notes { get; set; } = string.Empty ;

        private readonly string _ConnectionString = string.Empty;
        private SqlConnection _Connection { get; set; } = null;
        public ImpactorInjuryTimeData (string connectionString) : base(connectionString)
        {
            _ConnectionString = connectionString;
        }

        public List<ImpactorInjuryTimeData> GetAllForATest(string TestRunNumber, out string errorMessage)
        {
            List<ImpactorInjuryTimeData> result = new List<ImpactorInjuryTimeData>();
            _Connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand sqlCommand = _Connection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetImpactorInjuryTimeDataForATest";
                sqlCommand.Parameters.Add("@TestRunNumber", SqlDbType.VarChar).Value = TestRunNumber;

                try
                {
                    reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ImpactorInjuryTimeData Itype = new ImpactorInjuryTimeData(_ConnectionString);

                            if (long.TryParse(reader["ImpactorInjuryTimeDataId"].ToString(), out long lTemp) == true)
                            {
                                Itype.ImpactorInjuryTimeDataId = lTemp;
                            }

                            Itype.TestRunNumber = reader["TestRunNumber"].ToString();

                            if (long.TryParse(reader["ImpactorInjuryTimeId"].ToString(), out lTemp) == true)
                            {
                                Itype.ImpactorInjuryTimeId = lTemp;
                            }

                            Itype.ShortName = reader["ShortName"].ToString();

                            if (float.TryParse(reader["MaxValue"].ToString(), out float fTemp) == true)
                            {
                                Itype.MaxValue = fTemp;
                            }

                            if (float.TryParse(reader["MaxTime"].ToString(), out fTemp) == true)
                            {
                                Itype.MaxTime = fTemp;
                            }

                            if (float.TryParse(reader["MinValue"].ToString(), out fTemp) == true)
                            {
                                Itype.MinValue = fTemp;
                            }

                            if (float.TryParse(reader["MinTime"].ToString(), out fTemp) == true)
                            {
                                Itype.MinTime = fTemp;
                            }

                            Itype.Units = reader["Units"].ToString();

                            if (DateTime.TryParse(reader["TimeStamp"].ToString(), out DateTime dte) == true)
                            {
                                Itype.TimeStamp = dte;
                            }

                            Itype.Notes = reader["Notes"].ToString();


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

        public ImpactorInjuryTimeData FindName(List<ImpactorInjuryTimeData> parameters, string searchString)
        {
            ImpactorInjuryTimeData found = null;
            if (parameters != null)
            {
                foreach (ImpactorInjuryTimeData param in parameters)
                {
                    if (param.ShortName == searchString)
                    {
                        found = param;
                        break;
                    }
                }
            }
            return found;
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
                    CommandText = "InsertInjuryTimeDataRecord",
                };

                sqlCommand.Parameters.Add("@TestRunNumber", SqlDbType.VarChar).Value = TestRunNumber;
                sqlCommand.Parameters.Add("@ImpactorInjuryTimeId", SqlDbType.BigInt).Value = ImpactorInjuryTimeId;
                sqlCommand.Parameters.Add("@MaxValue", SqlDbType.Float).Value = MaxValue;
                sqlCommand.Parameters.Add("@MaxTime", SqlDbType.Float).Value = MaxTime;
                sqlCommand.Parameters.Add("@MinValue", SqlDbType.Float).Value = MinValue;
                sqlCommand.Parameters.Add("@MinTime", SqlDbType.Float).Value = MinTime;
                sqlCommand.Parameters.Add("@Units", SqlDbType.VarChar).Value = Units;
                sqlCommand.Parameters.Add("@TimeStamp", SqlDbType.DateTime).Value = TimeStamp;
                sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar).Value = Notes;

                try
                {
                    object retvalue = sqlCommand.ExecuteScalar();
                    if (long.TryParse(retvalue.ToString(), out long lTemp) == true)
                    {
                        ImpactorInjuryTimeDataId = lTemp;
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
        public string Update()
        {
            _Connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = _Connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "UpdateInjuryTimeDataRecord",
                };

                sqlCommand.Parameters.Add("@ImpactorInjuryTimeDataId", SqlDbType.BigInt).Value = ImpactorInjuryTimeDataId;
                sqlCommand.Parameters.Add("@TestRunNumber", SqlDbType.VarChar).Value = TestRunNumber;
                sqlCommand.Parameters.Add("@ImpactorInjuryTimeId", SqlDbType.BigInt).Value = ImpactorInjuryTimeId;
                sqlCommand.Parameters.Add("@MaxValue", SqlDbType.Float).Value = MaxValue;
                sqlCommand.Parameters.Add("@MaxTime", SqlDbType.Float).Value = MaxTime;
                sqlCommand.Parameters.Add("@MinValue", SqlDbType.Float).Value = MinValue;
                sqlCommand.Parameters.Add("@MinTime", SqlDbType.Float).Value = MinTime;
                sqlCommand.Parameters.Add("@Units", SqlDbType.VarChar).Value = Units;
                sqlCommand.Parameters.Add("@TimeStamp", SqlDbType.DateTime).Value = TimeStamp;
                sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar).Value = Notes;

                try
                {
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Update ImpactorInjuryTimeData ID: " + ImpactorInjuryTimeId.ToString() + " Failed. Error Number: " + result.ToString();
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

        public string DeleteTestRun (string testRunNumber)
        {
            _Connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = _Connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DeleteInjuryTimeDataForATestRun",
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

        public string Delete (long impactorInjuryTimeDataId)
        {
            _Connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = _Connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DeleteAnImpactorInjuryTimeDataRecord",
                };

                sqlCommand.Parameters.Add("@ImpactorInjuryTimeDataId", SqlDbType.BigInt).Value = impactorInjuryTimeDataId;


                try
                {
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Delete An Impactor Injury Time Data Record: " + impactorInjuryTimeDataId.ToString() + " Failed. Error Number: " + result.ToString();
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
