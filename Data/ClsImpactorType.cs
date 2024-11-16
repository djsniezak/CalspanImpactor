using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Data
{
    [XmlRoot("ImpactorType")]
    public class ImpactorType :Database
    {
        [XmlAttribute("ImpactorTypeId")]
        public long ImpactorTypeId { get; set; } = long.MinValue;

        [XmlAttribute("ImpactorTestTypeId")]
        public long ImpactorTestTypeId { get; set; } = long.MinValue;

        [XmlAttribute("SerialNumber")]
        public string SerialNumber { get; set; } = string.Empty;

        [XmlAttribute("Owner")]
        public string Owner { get; set; } = string.Empty;


        private readonly string _ConnectionString = string.Empty;
        private SqlConnection _Connection { get; set; } = null;
        public ImpactorType ( string connectionString ): base ( connectionString )
        {
            _ConnectionString = connectionString;
            _Connection = Connection;
        }

        public string Get (long impactorTypeId)
        {
            _Connection = Open(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetImpactorType";
                cmd.Parameters.Add("@ImpactorTypeId", SqlDbType.BigInt).Value = impactorTypeId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (long.TryParse(reader["ImpactorTypeId"].ToString(), out long lTemp) == true)
                        {
                            ImpactorTypeId = lTemp;
                        }

                        if (long.TryParse(reader["ImpactorTestTypeId"].ToString(), out lTemp) == true)
                        {
                            ImpactorTestTypeId = lTemp;
                        }

                        SerialNumber = reader["SerialNumber"].ToString();
                        Owner = reader["Owner"].ToString();
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

        public List<ImpactorType> GetAllForATestType ( long impactorTestTypeId, out string errorMessage )
        {
            List<ImpactorType> result = new List<ImpactorType>();
            _Connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetImpactorTypeForATestType";
                cmd.Parameters.Add("@ImpactorTestTypeId", SqlDbType.BigInt).Value = impactorTestTypeId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ImpactorType testType = new ImpactorType(_ConnectionString);

                            if (long.TryParse(reader["ImpactorTypeId"].ToString(), out long lTemp) == true)
                            {
                                testType.ImpactorTypeId = lTemp;
                            }

                            if (long.TryParse(reader["ImpactorTestTypeId"].ToString(), out lTemp) == true)
                            {
                                testType.ImpactorTestTypeId = lTemp;
                            }

                            testType.SerialNumber = reader["SerialNumber"].ToString();
                            testType.Owner = reader["Owner"].ToString();

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

        public List<ImpactorType> GelAll ( out string errorMessage )
        {
            List<ImpactorType> result = new List<ImpactorType>();
            _Connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllImpactorTypes";

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ImpactorType testType = new ImpactorType(_ConnectionString);

                            if (long.TryParse(reader["ImpactorTypeId"].ToString(), out long lTemp) == true)
                            {
                                testType.ImpactorTypeId = lTemp;
                            }

                            if (long.TryParse(reader["ImpactorTestTypeId"].ToString(), out lTemp) == true)
                            {
                                testType.ImpactorTestTypeId = lTemp;
                            }

                            testType.SerialNumber = reader["SerialNumber"].ToString();
                            testType.Owner = reader["Owner"].ToString();

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
                    CommandText = "InsertImpactorType",
                };

                sqlCommand.Parameters.Add("@ImpactorTestTypeId", SqlDbType.BigInt).Value = ImpactorTestTypeId;
                sqlCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber;
                sqlCommand.Parameters.Add("@Owner", SqlDbType.VarChar).Value = Owner;

                try
                {
                    object retvalue = sqlCommand.ExecuteScalar();
                    if (long.TryParse(retvalue.ToString(), out long lTemp) == true)
                    {
                        ImpactorTypeId = lTemp;
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
                cmd.CommandText = "UpdateImpactorType";
                cmd.Parameters.Add("@ImpactorTypeId", SqlDbType.BigInt).Value = ImpactorTypeId;
                cmd.Parameters.Add("@ImpactorTestTypeId", SqlDbType.BigInt).Value = ImpactorTestTypeId;
                cmd.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber;
                cmd.Parameters.Add("@Owner", SqlDbType.VarChar).Value = Owner;

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Update ImpactorTypeId: " + ImpactorTypeId.ToString() + " Failed. Error Number: " + result.ToString();
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
