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
        public double XAxis { get; set; } = double.MinValue;

        [XmlAttribute("YAxis")]
        public double YAxis { get; set; } = double.MinValue;

        [XmlAttribute("ZAxis")]
        public double ZAxis { get; set; } = double.MinValue;

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

                        if (double.TryParse(reader["XAxis"].ToString(), out double dTemp) == true)
                        {
                            XAxis = dTemp;
                        }

                        if (double.TryParse(reader["YAxis"].ToString(), out  dTemp) == true)
                        {
                            YAxis = dTemp;
                        }

                        if (double.TryParse(reader["ZAxis"].ToString(), out  dTemp) == true)
                        {
                            ZAxis = dTemp;
                        }

                        if( double.TryParse(reader["Alpha"].ToString(), out  dTemp) == true)
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

                            if (double.TryParse(reader["XAxis"].ToString(), out double dTemp) == true)
                            {
                                axis.XAxis = dTemp;
                            }

                            if (double.TryParse(reader["YAxis"].ToString(), out dTemp) == true)
                            {
                                axis.YAxis = dTemp;
                            }

                            if (double.TryParse(reader["ZAxis"].ToString(), out dTemp) == true)
                            {
                                axis.ZAxis = dTemp;
                            }

                            if (double.TryParse(reader["Alpha"].ToString(), out dTemp) == true)
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

                sqlCommand.Parameters.Add("@ImpactorTestId", SqlDbType.BigInt).Value = ImpactorTestId;
                sqlCommand.Parameters.Add("@ImpactorParameterId", SqlDbType.BigInt).Value = ImpactorParameterId;
                sqlCommand.Parameters.Add("@SetName", SqlDbType.VarChar).Value = SetName;

                if (XAxis == double.MinValue)
                {
                    sqlCommand.Parameters.Add("@XAxis", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    sqlCommand.Parameters.Add("@XAxis", SqlDbType.Decimal).Value = XAxis;
                }

                if (YAxis == double.MinValue)
                {
                    sqlCommand.Parameters.Add("@YAxis", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    sqlCommand.Parameters.Add("@YAxis", SqlDbType.Decimal).Value = YAxis;
                }

                if (ZAxis == double.MinValue)
                {
                    sqlCommand.Parameters.Add("@ZAxis", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    sqlCommand.Parameters.Add("@ZAxis", SqlDbType.Decimal).Value = ZAxis;
                }

                if (Alpha == double.MinValue)
                {
                    sqlCommand.Parameters.Add("@Alpha", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    sqlCommand.Parameters.Add("@Alpha", SqlDbType.Decimal).Value = Alpha;
                }

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
                if (XAxis == double.MinValue)
                {
                    cmd.Parameters.Add("@XAxis", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@XAxis", SqlDbType.Decimal).Value = XAxis;
                }

                if (YAxis == double.MinValue)
                {
                    cmd.Parameters.Add("@YAxis", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@YAxis", SqlDbType.Decimal).Value = YAxis;
                }

                if (ZAxis == double.MinValue)
                {
                    cmd.Parameters.Add("@ZAxis", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@ZAxis", SqlDbType.Decimal).Value = ZAxis;
                }

                if (Alpha == double.MinValue)
                {
                    cmd.Parameters.Add("@Alpha", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Alpha", SqlDbType.Decimal).Value = Alpha;
                }

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
