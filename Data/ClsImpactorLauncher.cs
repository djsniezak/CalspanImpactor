using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{
    [XmlRoot("Launcher")]
    public class Launcher : Database
    {
        [XmlAttribute("LauncherId")]
        public long LauncherId { get; set; } = long.MinValue;

        [XmlAttribute("Name")]
        public string Name { get; set; } = string.Empty;
        [XmlAttribute("Active")]
        public bool Active { get; set; } = true;

        private SqlConnection _connection = null;
        private readonly string _connectionString = string.Empty;
        public Launcher(string connectionString) : base(connectionString)
        {
        }

        public string Get(long LauncherId )
        {
            _connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLauncher";
                cmd.Parameters.Add("@LauncherId", SqlDbType.BigInt).Value = LauncherId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        if (long.TryParse(reader["LauncherId"].ToString(), out long lTemp) == true)
                        {
                            LauncherId = lTemp;
                        }


                        Name = reader["Name"].ToString();

                        if ( bool.TryParse (reader["Active"].ToString(), out bool btemp) == true)
                        {
                            Active = btemp;
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

        public List<Launcher> GetAll(out string errorMessage)
        {
            List<Launcher> result = new List<Launcher>();
            _connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllLaunchers";

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Launcher launcher = new Launcher(_connectionString);

                            if (long.TryParse(reader["LauncherId"].ToString(), out long lTemp) == true)
                            {
                                launcher.LauncherId = lTemp;
                            }


                            launcher.Name = reader["Name"].ToString();

                            if (bool.TryParse(reader["Active"].ToString(), out bool btemp) == true)
                            {
                                launcher.Active = btemp;
                            }

                            result.Add(launcher);
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
            _connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = _connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "InsertLauncher",
                };

                sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                sqlCommand.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;

                try
                {
                    object retvalue = sqlCommand.ExecuteScalar();
                    if (long.TryParse(retvalue.ToString(), out long lTemp) == true)
                    {
                        LauncherId = lTemp;
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
            _connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateLauncher";
                cmd.Parameters.Add("@LauncherId", SqlDbType.BigInt).Value = LauncherId;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Update Launcher ID: " + LauncherId.ToString() + " Failed. Error Number: " + result.ToString();
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
