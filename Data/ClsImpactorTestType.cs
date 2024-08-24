using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{
    [XmlRoot("ImpactorTestType")]
    public class ImpactorTestType :Database 
    {
        [XmlAttribute("ImpactorTestTypeId")]
        public long ImpactorTestTypeId { get; set; } = long.MinValue;

        [XmlAttribute("TestName")]
        public string TestName { get; set; } = string.Empty;

        [XmlAttribute("Description")]
        public string Description { get; set; } = string.Empty;

        private readonly string _ConnectionString = string.Empty;
        private SqlConnection _Connection = null;
        public ImpactorTestType(string connectionString ) : base( connectionString ) 
        { 
            _ConnectionString = connectionString;
            _Connection = base.Connection;
        }

        public string Get(long impactorTestTypeId)
        {
            _Connection = Open(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetImpactorTestType";
                cmd.Parameters.Add("@ImpactorParameterId", SqlDbType.BigInt).Value = impactorTestTypeId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (long.TryParse(reader["ImactorTestId"].ToString(), out long lTemp) == true)
                        {
                            ImpactorTestTypeId = lTemp;
                        }

                        TestName = reader["TestName"].ToString();
                        Description = reader["Description"].ToString();
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

        public List<ImpactorTestType> GetAll(out string errorMessage)
        {
            List<ImpactorTestType> result = new List<ImpactorTestType>();
            _Connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllImpactorTestTypes";

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ImpactorTestType testType = new ImpactorTestType(_ConnectionString);

                            if (long.TryParse(reader["ImpactorTestTypeId"].ToString(), out long lTemp) == true)
                            {
                                testType.ImpactorTestTypeId = lTemp;
                            }

                            testType.TestName = reader["TestName"].ToString();
                            testType.Description = reader["Description"].ToString();

                            result.Add(testType);
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

        public string Insert()
        {
            _Connection = Open(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = _Connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "InsertImpactorTestType",
                };

                sqlCommand.Parameters.Add("@TestName", SqlDbType.VarChar).Value = TestName;
                sqlCommand.Parameters.Add("@Description", SqlDbType.DateTime).Value = Description;

                try
                {
                    object retvalue = sqlCommand.ExecuteScalar();
                    if (long.TryParse(retvalue.ToString(), out long lTemp) == true)
                    {
                        ImpactorTestTypeId = lTemp;
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
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateImpactorTypeTest";
                cmd.Parameters.Add("@ImpactorTestTypeId", SqlDbType.BigInt).Value = ImpactorTestTypeId;
                cmd.Parameters.Add("@TestName", SqlDbType.VarChar).Value = TestName;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Update ImpactorTypeId: " + ImpactorTestTypeId.ToString() + " Failed. Error Number: " + result.ToString();
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
}
