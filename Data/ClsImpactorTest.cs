using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace Data
{
    [XmlRoot("ImpactorTest")]
    public class ImpactorTest : Database 
    {
        [XmlAttribute("ImpactorParameterId")]
        public long ImpactorTestId { get; set; } = long.MinValue;

        [XmlAttribute("ImpactorRun")]
        public string ImpactorRunNumber { get; set; } = string.Empty;

        [XmlAttribute("RunTime")]
        public DateTime RunTime { get; set; } = DateTime.MinValue;

        [XmlAttribute("CustomerId")]
        public long CustomerId { get; set; } = long.MinValue;

        [XmlAttribute("Specimen")]
        public string Specimen { get; set; } = string.Empty;

        [XmlAttribute("Engineer")]
        public string Engineer { get; set; } = string.Empty;

        [XmlAttribute("Operator")]
        public string Operator { get; set; } = string.Empty;

        [XmlAttribute("TestTypeId")]
        public long TestTypeId { get; set; } = long.MinValue;

        [XmlAttribute("Notes")]
        public string Notes { get; set; }  = string.Empty;

        private SqlConnection _connection = null;
        private readonly string _connectionString = string.Empty;

        public ImpactorTest (string connecitonString ) : base ( connecitonString )
        {
            _connectionString = connecitonString;
            _connection = Connection;

        }

        public string CreateImpactorRunNumber (string CustomerPrefix, out string errorMessage )
        {
            string strNewRunNumber = string.Empty;
            string year = DateTime.Today.Year.ToString().Substring(2);
            string strSearch = CustomerPrefix + "-" + "AL" + year;
            int LastNumber = GetLastRun(strSearch, out errorMessage);
            if (LastNumber > -1 )
            {
                strNewRunNumber = strSearch + "-" + LastNumber.ToString("000");
            }


            return strNewRunNumber;
        }
        public string Get ( long ImpactorId )
        {
            _connection = Open(out string strErrorMessage);
            if ( string.IsNullOrEmpty(strErrorMessage) == true )
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetImpactorTest";
                cmd.Parameters.Add ("@ImpactorTestId", SqlDbType.BigInt).Value = ImpactorId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if ( reader.HasRows)
                    {
                        reader.Read();

                        if (long.TryParse(reader["ImpactorTestId"].ToString(), out long lTemp) == true )
                        {
                            ImpactorTestId = lTemp;
                        }

                        ImpactorRunNumber = reader["TestRunNumber"].ToString();

                        if ( DateTime.TryParse (reader["RunTime"].ToString(), out DateTime dte) == true )
                        {
                            RunTime = dte;
                        }

                        if (long.TryParse(reader["CustomerId"].ToString(), out lTemp) == true)
                        {
                            CustomerId = lTemp;
                        }

                        Specimen = reader["Specimen"].ToString();
                        Engineer = reader["Engineer"].ToString();
                        Operator = reader["Operator"].ToString();

                        if ( long.TryParse (reader["TestTypeId"].ToString(), out lTemp) == true )
                        {
                            TestTypeId = lTemp;
                        }

                        Notes = reader["Notes"].ToString();
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
        public List<ImpactorTest> GetAll(out string errorMessage)
        {
            List<ImpactorTest> result = new List<ImpactorTest>();
            _connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllImpactorTests";

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ImpactorTest test = new ImpactorTest(_connectionString);

                            if (long.TryParse(reader["ImpactorTestId"].ToString(), out long lTemp) == true)
                            {
                                test.ImpactorTestId = lTemp;
                            }

                            test.ImpactorRunNumber = reader["TestRunNumber"].ToString();

                            if (DateTime.TryParse(reader["RunTime"].ToString(), out DateTime dte) == true)
                            {
                                test.RunTime = dte;
                            }

                            if (long.TryParse(reader["CustomerId"].ToString(), out lTemp) == true)
                            {
                                test.CustomerId = lTemp;
                            }

                            test.Specimen = reader["Specimen"].ToString();
                            test.Engineer = reader["Engineer"].ToString();
                            test.Operator = reader["Operator"].ToString();

                            if (long.TryParse(reader["TestTypeId"].ToString(), out lTemp) == true)
                            {
                                test.TestTypeId = lTemp;
                            }

                            test.Notes = reader["Notes"].ToString();
                            result.Add(test);
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


        public string Insert ( )
        {
            _connection = Open(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = _connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "InsertImpactorTest",
                };

                sqlCommand.Parameters.Add("@TestRunNumber", SqlDbType.VarChar).Value = ImpactorRunNumber;
                sqlCommand.Parameters.Add("@RunTime", SqlDbType.DateTime).Value = RunTime;
                sqlCommand.Parameters.Add("@CustomerId", SqlDbType.BigInt).Value = CustomerId;
                sqlCommand.Parameters.Add("@Specimen", SqlDbType.VarChar).Value = Specimen;
                sqlCommand.Parameters.Add("@Engineer", SqlDbType.VarChar).Value = Engineer;
                sqlCommand.Parameters.Add("@Operator", SqlDbType.VarChar).Value = Operator;
                sqlCommand.Parameters.Add("@TestTypeId", SqlDbType.Decimal).Value = TestTypeId;
                sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar).Value = Notes;

                try
                {
                    object retvalue = sqlCommand.ExecuteScalar();
                    if (long.TryParse (retvalue.ToString(), out long lTemp) == true )
                    {
                        ImpactorTestId = lTemp;
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

        public string Update (  ) 
        {
            _connection = Open(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateImpactorTest";
                cmd.Parameters.Add("@ImpactorTestId", SqlDbType.BigInt).Value = ImpactorTestId;
                cmd.Parameters.Add("@TestRunNumber", SqlDbType.VarChar).Value = ImpactorRunNumber;
                cmd.Parameters.Add("@RunTime", SqlDbType.DateTime).Value = RunTime;
                cmd.Parameters.Add("@CustomerId", SqlDbType.BigInt).Value = CustomerId;
                cmd.Parameters.Add("@Specimen", SqlDbType.VarChar).Value = Specimen;
                cmd.Parameters.Add("@Engineer", SqlDbType.VarChar).Value = Engineer;
                cmd.Parameters.Add("@Operator", SqlDbType.VarChar).Value = Operator;
                cmd.Parameters.Add("@TestTypeId", SqlDbType.Decimal).Value = TestTypeId;
                cmd.Parameters.Add("@Notes", SqlDbType.VarChar).Value = Notes;

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if ( result != -1 )
                    {
                        strErrorMessage = "Update ImpactorTestId: " + ImpactorTestId.ToString() + " Failed. Error Number: " + result.ToString();
                    }
                }
                catch ( SqlException sqlEx)
                {
                    strErrorMessage = sqlEx.Message;
                }
                catch ( Exception ex ) 
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
        private int GetLastRun ( string Search, out string errorString)
        {
            int NextRun = int.MinValue;
            string Result = string.Empty;
            _connection = Open(out errorString);

            if (string.IsNullOrEmpty(errorString) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLastRunNumber";
                cmd.Parameters.Add("@RunNumber", SqlDbType.VarChar).Value = Search;
                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Result = reader["TestRunNumber"].ToString();
                    }
                }
                catch (SqlException sqlEx)
                {
                    errorString = sqlEx.Message;
                }                   
                catch (Exception ex)
                {
                    errorString = ex.Message;
                }
                finally
                {
                    cmd.Dispose( );
                    cmd.Connection.Close();
                }

                if (string.IsNullOrEmpty(Result) == false)
                {
                    int position = Result.LastIndexOf("-");
                    if (position > -1) 
                    {
                        if ( int.TryParse (Result.Substring(position + 1), out NextRun ) == false ) 
                        {
                            NextRun = -1;
                        }
                        else
                        {
                            NextRun++;
                        }
                    }
                }
                else
                {
                    NextRun = 0;
                }
            }

            return NextRun;
        }
    }
}
