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

        [XmlAttribute("NormalImpactSpeed")]
        public double NormalImpactSpeed { get; set; } = double.MinValue;

        [XmlAttribute("NormalImpactAngle")]
        public double NormalImpactAngle { get; set; } = double.MinValue;

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

                        if (long.TryParse(reader["ImpactorTypeId"].ToString(), out lTemp) == true)
                        {
                            ImpactorTypeId = lTemp;
                        }

                        Name = reader["Name"].ToString();


                        if ( double.TryParse (reader["ImpactorMass"].ToString(), out double dTemp) == true )
                        {
                            ImpactorMass = dTemp;
                        }

                        TargetingMethod = reader["TargetingMethod"].ToString();

                        if (double.TryParse(reader["NormalImpactSpeed"].ToString(), out dTemp) == true)
                        {
                            NormalImpactSpeed = dTemp;
                        }

                        if (double.TryParse(reader["NormalImpactAngle"].ToString(), out dTemp) == true)
                        {
                            NormalImpactAngle= dTemp;
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

        public List<Protocol> GelAll(out string errorMessage)
        {
            List<Protocol> result = new List<Protocol>();
            _Connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllProtocols";

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Protocol protocol = new Protocol(_ConnectionString);

                            if (long.TryParse(reader["ProtocolId"].ToString(), out long lTemp) == true)
                            {
                                protocol.ProtocolId = lTemp;
                            }

                            if (long.TryParse(reader["ImpactorTypeId"].ToString(), out lTemp) == true)
                            {
                                protocol.ImpactorTypeId = lTemp;
                            }

                            protocol.Name = reader["Name"].ToString();


                            if (double.TryParse(reader["ImpactorMass"].ToString(), out double dTemp) == true)
                            {
                                protocol.ImpactorMass = dTemp;
                            }

                            protocol.TargetingMethod = reader["TargetingMethod"].ToString();

                            if (double.TryParse(reader["NormalImpactSpeed"].ToString(), out dTemp) == true)
                            {
                                protocol.NormalImpactSpeed = dTemp;
                            }

                            if (int.TryParse(reader["NormalImpactAngle"].ToString(), out int iTemp) == true)
                            {
                                protocol.NormalImpactAngle = iTemp;
                            }

                            result.Add(protocol);   
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

                        if (double.TryParse(reader["NormalImpactSpeed"].ToString(), out dTemp) == true)
                        {
                            NormalImpactSpeed = dTemp;
                        }

                        if (double.TryParse(reader["NormalImpactAngle"].ToString(), out dTemp) == true)
                        {
                            NormalImpactAngle = dTemp;
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
                sqlCommand.Parameters.Add("@NormalImpactSpeed", SqlDbType.Decimal).Value = NormalImpactSpeed;
                sqlCommand.Parameters.Add("@NormalImpactAngle", SqlDbType.Decimal).Value = NormalImpactAngle;

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

                cmd.Parameters.Add("@ProtocolId", SqlDbType.BigInt).Value = ProtocolId;
                cmd.Parameters.Add("@ImpactorTypeId", SqlDbType.BigInt).Value = ImpactorTypeId;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@ImpactorMass", SqlDbType.Decimal).Value = ImpactorMass;
                cmd.Parameters.Add("@TargetingMethod", SqlDbType.VarChar).Value = TargetingMethod;
                cmd.Parameters.Add("@NormalImpactSpeed", SqlDbType.Decimal).Value = NormalImpactSpeed;
                cmd.Parameters.Add("@NormalImpactAngle", SqlDbType.Decimal).Value = NormalImpactAngle;

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
