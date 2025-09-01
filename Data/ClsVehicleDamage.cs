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
    [XmlRoot("VehicleDamage")]
    public class VehicleDamage : Database
    {
        [XmlAttribute("VehicleDamageId ")]
        public long VehicleDamageId { get; set; } = long.MinValue;

        [XmlAttribute("TestRunId")]
        public long TestRunId { get; set; } = long.MinValue;

        [XmlAttribute("VehicleDamage")]
        public string VehicleDamageText { get; set; } = string.Empty;

        private SqlConnection _connection = null;
        private readonly string _connectionString = string.Empty;
        public VehicleDamage(string connectionString) : base(connectionString)
        {
        }
        public string Get (long TestRunId )
        {
            _connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVehicleDamageRecord";
                cmd.Parameters.Add("@TestRunId", SqlDbType.BigInt).Value = TestRunId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        if (long.TryParse(reader["VehicleDamageId"].ToString(), out long lTemp) == true)
                        {
                            VehicleDamageId = lTemp;
                        }

                        if (long.TryParse(reader["TestRunId"].ToString(), out lTemp) == true)
                        {
                            TestRunId = lTemp;
                        }


                        VehicleDamageText= reader["VehicleDamage"].ToString();
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
            _connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "InsertVehicleDamageRecord",
                };

                cmd.Parameters.Add("@TestRunId", SqlDbType.BigInt).Value = TestRunId;
                cmd.Parameters.Add("@VehicleDamage", SqlDbType.VarChar).Value = VehicleDamageText;

                try
                {
                    object retvalue = cmd.ExecuteScalar();
                    if (long.TryParse(retvalue.ToString(), out long lTemp) == true)
                    {
                        VehicleDamageId = lTemp;
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

        public string Update()
        {
            _connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateVehicleDamageRecord";
                try
                {
                    cmd.Parameters.Add("@VehicleDamageId", SqlDbType.BigInt).Value = VehicleDamageId;
                    cmd.Parameters.Add("@TestRunId", SqlDbType.BigInt).Value = TestRunId;
                    cmd.Parameters.Add("@VehicleDamage", SqlDbType.VarChar).Value = VehicleDamageText;

                    int result = cmd.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Update Vehicle Damage ID: " + VehicleDamageId.ToString() + " Failed. Error Number: " + result.ToString();
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

