using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{
    [XmlRoot("ImpactorAxis")]
    public class ImpactorAxis :Database
    {
        [XmlAttribute("ImpactorAxisId")]
        public long ImpactorAxisId { get; set; } = long.MinValue;

        [XmlAttribute("ImpactorTestId")]
        public long ImpactorTestId { get; set; } = long.MinValue;

        [XmlAttribute("ImpactorParameterId")]
        public long ImpactorParameterId { get; set; } = long.MinValue;

        [XmlAttribute("SetName")]
        public string SetName { get; set; } = string.Empty;

        [XmlAttribute("XAxis")]
        public int XAxis { get; set; } = int.MinValue;

        [XmlAttribute("YAxis")]
        public int YAxis { get; set; } = int.MinValue;

        [XmlAttribute("ZAxis")]
        public int ZAxis { get; set; } = int.MinValue;

        [XmlAttribute("Alpha")]
        public double Alpha { get; set; } = double.MinValue;

        private SqlConnection _connection = null;
        private readonly string  _connectionString = string.Empty;
        public ImpactorAxis( string connectionString ) : base( connectionString )
        { 
            
        }

        public string Get(long impactorAxisId, string setName)
        {
            _connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAnImpactorAxis";
                cmd.Parameters.Add("@ImpactorAxisId", SqlDbType.BigInt).Value = impactorAxisId;
                cmd.Parameters.Add("@SetName", SqlDbType.VarChar).Value = setName;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (long.TryParse(reader["ImpactorAxisId"].ToString(), out long lTemp) == true)
                        {
                            ImpactorAxisId = lTemp;
                        }

                        if (long.TryParse(reader["ImpactorTestId"].ToString(), out lTemp) == true)
                        {
                            ImpactorTestId = lTemp;
                        }

                        if (long.TryParse(reader["ImpactorParameterId"].ToString(), out lTemp) == true)
                        {
                            ImpactorParameterId = lTemp;
                        }

                        SetName = reader["SetName"].ToString();

                        if (int.TryParse(reader["XAxis"].ToString(), out int iTemp) == true)
                        {
                            XAxis = iTemp;
                        }

                        if (int.TryParse(reader["YAxis"].ToString(), out  iTemp) == true)
                        {
                            YAxis = iTemp;
                        }

                        if (int.TryParse(reader["ZAxis"].ToString(), out  iTemp) == true)
                        {
                            ZAxis = iTemp;
                        }

                        if( double.TryParse(reader["Alpha"].ToString(), out double dTemp) == true)
                        {
                            Alpha = dTemp;
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

        public List<ImpactorAxis> GetAll( long impactorTestId, out string errorMessage)
        {
            List<ImpactorAxis > result = new List<ImpactorAxis>();
            _connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAxisForImpactorTest";
                cmd.Parameters.Add("@ImpactorTestId", SqlDbType.BigInt).Value = impactorTestId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ImpactorAxis axis = new ImpactorAxis(_connectionString);

                            if (long.TryParse(reader["ImpactorAxisId"].ToString(), out long lTemp) == true)
                            {
                                axis.ImpactorAxisId = lTemp;
                            }

                            if (long.TryParse(reader["ImpactorTestId"].ToString(), out lTemp) == true)
                            {
                                ImpactorTestId = lTemp;
                            }

                            if (long.TryParse(reader["ImpactorParameterId"].ToString(), out lTemp) == true)
                            {
                                axis.ImpactorParameterId = lTemp;
                            }

                            axis.SetName = reader["SetName"].ToString();

                            if (int.TryParse(reader["XAxis"].ToString(), out int iTemp) == true)
                            {
                                axis.XAxis = iTemp;
                            }

                            if (int.TryParse(reader["YAxis"].ToString(), out iTemp) == true)
                            {
                                axis.YAxis = iTemp;
                            }

                            if (int.TryParse(reader["ZAxis"].ToString(), out iTemp) == true)
                            {
                                axis.ZAxis = iTemp;
                            }

                            if (double.TryParse(reader["Alpha"].ToString(), out double dTemp) == true)
                            {
                                axis.Alpha = dTemp;
                            }

                            result.Add(axis);
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
        public string Insert ()
        {
            _connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = _connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "InsertImpactorAxis",
                };

                sqlCommand.Parameters.Add("@ImpactorTestId", SqlDbType.VarChar).Value = ImpactorTestId;
                sqlCommand.Parameters.Add("@ImpactorParameterId", SqlDbType.VarChar).Value = ImpactorParameterId;
                sqlCommand.Parameters.Add("@SetName", SqlDbType.VarChar).Value = SetName;
                sqlCommand.Parameters.Add("@XAxis", SqlDbType.Int).Value = XAxis;
                sqlCommand.Parameters.Add("@YAxis", SqlDbType.Int).Value = YAxis;
                sqlCommand.Parameters.Add("@ZAxis", SqlDbType.Int).Value = ZAxis;
                sqlCommand.Parameters.Add("@Alpha", SqlDbType.Decimal).Value = Alpha;

                try
                {
                    object retvalue = sqlCommand.ExecuteScalar();
                    if (long.TryParse(retvalue.ToString(), out long lTemp) == true)
                    {
                        ImpactorAxisId = lTemp;
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
                cmd.CommandText = "UpdateImpactorAxisRecord";
                cmd.Parameters.Add("@ImpactorAxisId", SqlDbType.BigInt).Value = ImpactorAxisId;
                cmd.Parameters.Add("@ImpactorTestId", SqlDbType.BigInt).Value = ImpactorTestId;
                cmd.Parameters.Add("@ImpactorParameterId", SqlDbType.BigInt).Value = ImpactorParameterId;
                cmd.Parameters.Add("@SetName", SqlDbType.VarChar).Value = SetName;
                cmd.Parameters.Add("@XAxis", SqlDbType.Int).Value = XAxis;  
                cmd.Parameters.Add("@YAxis", SqlDbType.Int).Value = YAxis;
                cmd.Parameters.Add("@ZAxis", SqlDbType.Int).Value = ZAxis;
                cmd.Parameters.Add("@Alpha", SqlDbType.Decimal).Value = Alpha;

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Update ImpactorAxis ID: " + ImpactorAxisId.ToString() + " Failed. Error Number: " + result.ToString();
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
