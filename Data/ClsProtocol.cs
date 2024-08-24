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
    [XmlRoot("Protocol")]
    public class Protocol: Database
    {
        [XmlAttribute("ProtocolIdId")]
        public long ProtocolId { get; set; } = long.MinValue;

        [XmlAttribute("ImpactorTypeId")]
        public long ImpactorTypeId { get; set; } = long.MinValue;

        [XmlAttribute("Name")]
        public string Name { get; set; } = string.Empty;

        [XmlAttribute("ImpactorMass")]
        public double ImpactorMass { get; set; } = double.MinValue;

        [XmlAttribute("Targeting Method")]
        public string TargetingMethod { get; set; } = string.Empty;

        [XmlAttribute("ImpactSpeed")]

        public double ImpactSpeed { get; set; } = double.MinValue;

        [XmlAttribute("ImpactAngle")]
        public int ImpactAngle { get; set; } = int.MinValue;

        private readonly string _ConnectionString = string.Empty;
        private SqlConnection _Connection { get; set; } = null;
        public Protocol(string connectionString) : base(connectionString)
        {
            _ConnectionString = connectionString;
            _Connection = Connection;
        }

        public string Get(long protocolId)
        {
            _Connection = Open(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetProtocol";
                cmd.Parameters.Add("@ProtocolId", SqlDbType.BigInt).Value = protocolId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        if (long.TryParse(reader["ProtocolId"].ToString(), out long lTemp) == true)
                        {
                            ProtocolId = lTemp;
                        }

                        if (long.TryParse(reader["ImactorTypeId"].ToString(), out lTemp) == true)
                        {
                            ImpactorTypeId = lTemp;
                        }

                        Name = reader["Name"].ToString();


                        if ( double.TryParse (reader["ImpactorMass"].ToString(), out double dTemp) == true )
                        {
                            ImpactorMass = dTemp;
                        }

                        TargetingMethod = reader["TargetingMethod"].ToString();

                        if (double.TryParse(reader["ImpactSpeed"].ToString(), out dTemp) == true)
                        {
                            ImpactSpeed = dTemp;
                        }

                        if (int.TryParse(reader["ImpactAngle"].ToString(), out int iTemp) == true)
                        {
                            ImpactAngle= iTemp;
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

        public string GetParametersForProtocolAndImpactorType(string name, long impactorTypeId)
        {
            _Connection = Open(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetRecordforProtocolAndImpatorType";
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@ImpactorTypeId", SqlDbType.BigInt).Value = impactorTypeId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        if (long.TryParse(reader["ProtocolId"].ToString(), out long lTemp) == true)
                        {
                            ProtocolId = lTemp;
                        }

                        if (long.TryParse(reader["ImactorTypeId"].ToString(), out lTemp) == true)
                        {
                            ImpactorTypeId = lTemp;
                        }

                        Name = reader["Name"].ToString();


                        if (double.TryParse(reader["ImpactorMass"].ToString(), out double dTemp) == true)
                        {
                            ImpactorMass = dTemp;
                        }

                        TargetingMethod = reader["TargetingMethod"].ToString();

                        if (double.TryParse(reader["ImpactSpeed"].ToString(), out dTemp) == true)
                        {
                            ImpactSpeed = dTemp;
                        }

                        if (int.TryParse(reader["ImpactAngle"].ToString(), out int iTemp) == true)
                        {
                            ImpactAngle = iTemp;
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

        public string Insert()
        {
            _Connection = Open(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = _Connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "InsertProtocol",
                };

                sqlCommand.Parameters.Add("@ImpactorTypeId", SqlDbType.BigInt).Value = ImpactorTypeId;
                sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                sqlCommand.Parameters.Add("@ImpactorMass", SqlDbType.Decimal).Value = ImpactorMass;
                sqlCommand.Parameters.Add("@TargetingMethod", SqlDbType.VarChar).Value = TargetingMethod;
                sqlCommand.Parameters.Add("@ImpactSpeed", SqlDbType.Decimal).Value = ImpactSpeed;
                sqlCommand.Parameters.Add("@ImpactAngle", SqlDbType.Int).Value = ImpactAngle;

                try
                {
                    object retvalue = sqlCommand.ExecuteScalar();
                    if (long.TryParse(retvalue.ToString(), out long lTemp) == true)
                    {
                        ProtocolId = lTemp;
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
                cmd.CommandText = "UpdateProtocol";
                cmd.Parameters.Add("@ImpactorTypeId", SqlDbType.BigInt).Value = ImpactorTypeId;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@ImpactorMass", SqlDbType.Decimal).Value = ImpactorMass;
                cmd.Parameters.Add("@TargetingMethod", SqlDbType.VarChar).Value = TargetingMethod;
                cmd.Parameters.Add("@ImpactSpeed", SqlDbType.Decimal).Value = ImpactSpeed;
                cmd.Parameters.Add("@ImpactAngle", SqlDbType.Int).Value = ImpactAngle;

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Update ProtocolId: " + ProtocolId.ToString() + " Failed. Error Number: " + result.ToString();
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
