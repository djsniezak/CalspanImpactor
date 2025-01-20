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
    [XmlRoot("Tires")]
    public class Tires : Database
    {
        [XmlAttribute("TiresId")]
        public long TiresId { get; set; } = long.MinValue;
        
        [XmlAttribute("ImpactorTestId")]
        public long ImpactorTestId { get; set; } = long.MinValue;
        
        [XmlAttribute("SpecimenId")]
        public long SpecimenId { get; set; } = long.MinValue;
       
        [XmlAttribute("SpecificationFront")]
        public string SpecificationFront { get; set; } = string.Empty;
        
        [XmlAttribute("SpecificationRear")]
        public string SpecificationRear { get; set; } = string.Empty;
        
        [XmlAttribute("PressureFL")]
        public double PressureFL { get; set; } = double.MinValue;
        
        [XmlAttribute("PressureFR")]
        public double PressureFR { get; set; } = double.MinValue;
        
        [XmlAttribute("PressureRL")]
        public double PressureRL { get; set; } = double.MinValue;
        
        [XmlAttribute("PressureRR")]
        public double PressureRR { get; set; } = double.MinValue;

        [XmlAttribute("HeightFL")]
        public double HeightFL { get; set; } = double.MinValue;

        [XmlAttribute("HeightFR")]
        public double HeightFR { get; set; } = double.MinValue;

        [XmlAttribute("HeightRL")]
        public double HeightRL { get; set; } = double.MinValue;

        [XmlAttribute("HeightRR")]
        public double HeightRR { get; set; } = double.MinValue;

        [XmlAttribute("Notes")]
        public string Notes { get; set; } = string.Empty;

        private SqlConnection _connection = null;
        private readonly string _connectionString = string.Empty;
        public Tires(string connectionString) : base(connectionString)
        {
        }

        public string Get(long impactorTestId, long specimenId)
        {
            _connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetTiresRecord";
                cmd.Parameters.Add("@ImpactorTestId", SqlDbType.BigInt).Value = impactorTestId;
                cmd.Parameters.Add("@SpecimenId", SqlDbType.BigInt).Value = specimenId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        if (long.TryParse(reader["TiresId"].ToString(), out long lTemp) == true)
                        {
                            TiresId = lTemp;
                        }

                        if (long.TryParse(reader["ImpactorTestId"].ToString(), out lTemp) == true)
                        {
                            ImpactorTestId = lTemp;
                        }

                        if (long.TryParse(reader["SpecimenId"].ToString(), out lTemp) == true)
                        {
                            SpecimenId = lTemp;
                        }

                        SpecificationFront = reader["SpecificationFront"].ToString();
                        SpecificationRear = reader["SpecificationRear"].ToString();

                        if (double.TryParse(reader["PressureFL"].ToString(), out double dTemp) == true)
                        {
                            PressureFL = dTemp;
                        }

                        if (double.TryParse(reader["PressureFR"].ToString(), out dTemp) == true)
                        {
                            PressureFR = dTemp;
                        }

                        if (double.TryParse(reader["PressureRL"].ToString(), out dTemp) == true)
                        {
                            PressureRL = dTemp;
                        }

                        if (double.TryParse(reader["PressureRR"].ToString(), out dTemp) == true)
                        {
                            PressureRR = dTemp;
                        }

                        if (double.TryParse(reader["HeightFL"].ToString(), out dTemp) == true)
                        {
                            HeightFL = dTemp;
                        }

                        if (double.TryParse(reader["HeightFR"].ToString(), out dTemp) == true)
                        {
                            HeightFR = dTemp;
                        }

                        if (double.TryParse(reader["HeightRL"].ToString(), out dTemp) == true)
                        {
                            HeightRL = dTemp;
                        }

                        if (double.TryParse(reader["HeightRR"].ToString(), out dTemp) == true)
                        {
                            HeightRR = dTemp;
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
        public string Insert()
        {
            _connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "InsertTireRecord",
                };

                cmd.Parameters.Add("@ImpactorTestId", SqlDbType.BigInt).Value = ImpactorTestId;
                cmd.Parameters.Add("@SpecimenId", SqlDbType.BigInt).Value = SpecimenId;
                cmd.Parameters.Add("@SpecificationFront", SqlDbType.VarChar).Value = SpecificationFront;
                cmd.Parameters.Add("@SpecificationRear", SqlDbType.VarChar).Value = SpecificationRear;

                if (PressureFL == double.MinValue)
                {
                    cmd.Parameters.Add("@PressureFL", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@PressureFL", SqlDbType.Decimal).Value = PressureFL;
                }

                if (PressureFR == double.MinValue)
                {
                    cmd.Parameters.Add("@PressureFR", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@PressureFR", SqlDbType.Decimal).Value = PressureFR;
                }

                if (PressureRL == double.MinValue)
                {
                    cmd.Parameters.Add("@PressureRL", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@PressureRL", SqlDbType.Decimal).Value = PressureRL;
                }

                if (PressureRR == double.MinValue)
                {
                    cmd.Parameters.Add("@PressureRR", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@PressureRR", SqlDbType.Decimal).Value = PressureRR;
                }

                if (HeightFL == double.MinValue)
                {
                    cmd.Parameters.Add("@HeightFL", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@HeightFL", SqlDbType.Decimal).Value = HeightFL;
                }

                if (HeightFR == double.MinValue)
                {
                    cmd.Parameters.Add("@HeightFR", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@HeightFR", SqlDbType.Decimal).Value = HeightFR;
                }

                if (HeightRL == double.MinValue)
                {
                    cmd.Parameters.Add("@HeightRL", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@HeightRL", SqlDbType.Decimal).Value = HeightRL;
                }

                if (HeightRR == double.MinValue)
                {
                    cmd.Parameters.Add("@HeightRR", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@HeightRR", SqlDbType.Decimal).Value = HeightRR;
                }

                cmd.Parameters.Add("@Notes", SqlDbType.VarChar).Value = Notes;

                try
                {
                    object retvalue = cmd.ExecuteScalar();
                    if (long.TryParse(retvalue.ToString(), out long lTemp) == true)
                    {
                        TiresId = lTemp;
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
                cmd.CommandText = "UpdateTireRecord";
                try
                {
                    cmd.Parameters.Add("@TiresId", SqlDbType.BigInt).Value = TiresId;
                    cmd.Parameters.Add("@ImpactorTestId", SqlDbType.BigInt).Value = ImpactorTestId;
                    cmd.Parameters.Add("@SpecimenId", SqlDbType.BigInt).Value = SpecimenId;
                    cmd.Parameters.Add("@SpecificationFront", SqlDbType.VarChar).Value = SpecificationFront;
                    cmd.Parameters.Add("@SpecificationRear", SqlDbType.VarChar).Value = SpecificationRear;

                    if (PressureFL == double.MinValue)
                    {
                        cmd.Parameters.Add("@PressureFL", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@PressureFL", SqlDbType.Decimal).Value = PressureFL;
                    }

                    if (PressureFR == double.MinValue)
                    {
                        cmd.Parameters.Add("@PressureFR", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@PressureFR", SqlDbType.Decimal).Value = PressureFR;
                    }

                    if (PressureRL == double.MinValue)
                    {
                        cmd.Parameters.Add("@PressureRL", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@PressureRL", SqlDbType.Decimal).Value = PressureRL;
                    }

                    if (PressureRR == double.MinValue)
                    {
                        cmd.Parameters.Add("@PressureRR", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@PressureRR", SqlDbType.Decimal).Value = PressureRR;
                    }

                    if (HeightFL == double.MinValue)
                    {
                        cmd.Parameters.Add("@HeightFL", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@HeightFL", SqlDbType.Decimal).Value = HeightFL;
                    }

                    if (HeightFR == double.MinValue)
                    {
                        cmd.Parameters.Add("@HeightFR", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@HeightFR", SqlDbType.Decimal).Value = HeightFR;
                    }

                    if (HeightRL == double.MinValue)
                    {
                        cmd.Parameters.Add("@HeightRL", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@HeightRL", SqlDbType.Decimal).Value = HeightRL;
                    }

                    if (HeightRR == double.MinValue)
                    {
                        cmd.Parameters.Add("@HeightRR", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@HeightRR", SqlDbType.Decimal).Value = HeightRR;
                    }

                    cmd.Parameters.Add("@Notes", SqlDbType.VarChar).Value = Notes;


                    int result = cmd.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Update Tires ID: " + TiresId.ToString() + " Failed. Error Number: " + result.ToString();
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
