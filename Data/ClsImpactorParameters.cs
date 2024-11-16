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
    [XmlRoot("ImpactorTest")]
    public class ImpactorParameters : Database
    {
        [XmlAttribute("ImpactorParametersId")]
        public long ImpactorParametersId { get; set; } = long.MinValue;

        [XmlAttribute("ImpactorParameterId")]
        public long ImpactorTestId { get; set; } = long.MinValue;

        [XmlAttribute("ImpactorTypeId")]
        public long ImpactorTypeId { get; set; } = long.MinValue;

        [XmlAttribute("Temperature")]
        public decimal Temperature { get; set; } = decimal.MinValue;

        [XmlAttribute("Humidity")]
        public decimal Humidity { get; set; } = decimal.MinValue;

        [XmlAttribute("Trigger1")]
        public int Trigger1 { get; set; } = int.MinValue;

        [XmlAttribute("Trigger2")]
        public int Trigger2 { get; set; } = int.MinValue;

        [XmlAttribute("Notes")]
        public string Notes { get; set; } = string.Empty;

        [XmlAttribute("FirePressure")]
        public decimal FirePressure { get; set; } = decimal.MinValue;

        [XmlAttribute("CylinderSpeed")]
        public int CylinderSpeed { get; set; } = int.MinValue;

        [XmlAttribute("MeasuredSpeed")]
        public int MeasuredSpeed { get; set; } = int.MinValue;

        [XmlAttribute("CylinderWithOutImpactorSetpoint")]
        public int CylinderWithOutImpactorSetpoint { get; set; } = int.MinValue;

        [XmlAttribute("AccleratorTemperature")]
        public decimal AcceleratorTemperature { get; set; } = decimal.MinValue;

        [XmlAttribute("TankTemperature")]
        public decimal TankTemperature { get; set; } = decimal.MinValue;

        [XmlAttribute("AirBag1")]
        public int AirBag1 { get; set; } = int.MinValue;

        [XmlAttribute("AirBag2")]
        public int AirBag2 { get; set; } = int.MinValue;

        [XmlAttribute("AirBag3")]
        public int AirBag3 { get; set; } = int.MinValue;

        private SqlConnection _connection = null;
        public ImpactorParameters( string _connectionString) : base(_connectionString )
        {
            _connection = Connection;
        }

        public string Get ( long impactorParametersId)
        {
             _connection = Open( out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetImpactorParameters";
                cmd.Parameters.Add("@ImpactorParametersId", SqlDbType.BigInt).Value = impactorParametersId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        if (long.TryParse(reader["ImpactorParametersId"].ToString(), out long lTemp) == true) 
                        {
                            ImpactorParametersId = lTemp;
                        }

                        if (long.TryParse(reader["ImpactorTestId"].ToString(), out lTemp) == true)
                        {
                            ImpactorTestId = lTemp;
                        }

                        if (long.TryParse(reader["ImpactorId"].ToString(), out lTemp) == true)
                        {
                            ImpactorTypeId = lTemp;
                        }
                        
                        if (decimal.TryParse(reader["Temperature"].ToString(), out decimal dTemp) == true )
                        {
                            Temperature = dTemp;
                        }

                        if (decimal.TryParse(reader["Humidity"].ToString(), out dTemp) == true)
                        {
                            Humidity = dTemp;
                        }

                        if (int.TryParse(reader["Trigger1"].ToString(), out int iTemp) == true )
                        {
                            Trigger1 = iTemp;
                        }

                        if (int.TryParse(reader["Trigger2"].ToString(), out iTemp) == true)
                        {
                            Trigger2 = iTemp;
                        }

                        Notes = reader["Notes"].ToString();

                        if (decimal.TryParse(reader["FirePressure"].ToString(), out dTemp) == true)
                        {
                            FirePressure = dTemp;
                        }

                        if (int.TryParse(reader["CylinderSpeed"].ToString(), out iTemp) == true)
                        {
                            CylinderSpeed = iTemp;
                        }

                        if (int.TryParse(reader["MeasuredSpeed"].ToString(), out iTemp) == true)
                        {
                            MeasuredSpeed = iTemp;
                        }

                        if (int.TryParse(reader["WithOutImpactorSetPoint"].ToString(), out iTemp) == true)
                        {
                            CylinderWithOutImpactorSetpoint = iTemp;
                        }

                        if (decimal.TryParse(reader["AcceleratorTemperature"].ToString(), out dTemp) == true)
                        {
                            AcceleratorTemperature = dTemp;
                        }

                        if (decimal.TryParse(reader["TankTemperature"].ToString(), out dTemp) == true)
                        {
                            TankTemperature = dTemp;
                        }

                        if (int.TryParse(reader["AirBag1"].ToString(), out iTemp) == true)
                        {
                            AirBag1 = iTemp;
                        }

                        if (int.TryParse(reader["AirBag2"].ToString(), out iTemp) == true)
                        {
                            AirBag2 = iTemp;
                        }

                        if (int.TryParse(reader["AirBag3"].ToString(), out iTemp) == true)
                        {
                            AirBag3 = iTemp;
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

        public string GetForAnImpactorTest(long impactorTestId)
        {
            _connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetImpactorParametersForAnImpactorTest";
                cmd.Parameters.Add("@ImpactorTestId", SqlDbType.BigInt).Value = impactorTestId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        if (long.TryParse(reader["ImpactorParametersId"].ToString(), out long lTemp) == true)
                        {
                            ImpactorParametersId = lTemp;
                        }

                        if (long.TryParse(reader["ImpactorTestId"].ToString(), out lTemp) == true)
                        {
                            ImpactorTestId = lTemp;
                        }

                        if (long.TryParse(reader["ImpactorTypeId"].ToString(), out lTemp) == true)
                        {
                            ImpactorTypeId = lTemp;
                        }

                        if (decimal.TryParse(reader["Temperature"].ToString(), out decimal dTemp) == true)
                        {
                            Temperature = dTemp;
                        }

                        if (decimal.TryParse(reader["Humidity"].ToString(), out dTemp) == true)
                        {
                            Humidity = dTemp;
                        }

                        if (int.TryParse(reader["Trigger1"].ToString(), out int iTemp) == true)
                        {
                            Trigger1 = iTemp;
                        }

                        if (int.TryParse(reader["Trigger2"].ToString(), out iTemp) == true)
                        {
                            Trigger2 = iTemp;
                        }

                        Notes = reader["Notes"].ToString();

                        if (decimal.TryParse(reader["FirePressure"].ToString(), out dTemp) == true)
                        {
                            FirePressure = dTemp;
                        }

                        if (int.TryParse(reader["CylinderSpeed"].ToString(), out iTemp) == true)
                        {
                            CylinderSpeed = iTemp;
                        }

                        if (int.TryParse(reader["MeasuredSpeed"].ToString(), out iTemp) == true)
                        {
                            MeasuredSpeed = iTemp;
                        }

                        if (int.TryParse(reader["WithOutImpactorSetPoint"].ToString(), out iTemp) == true)
                        {
                            CylinderWithOutImpactorSetpoint = iTemp;
                        }

                        if (decimal.TryParse(reader["AcceleratorTemperature"].ToString(), out dTemp) == true)
                        {
                            AcceleratorTemperature = dTemp;
                        }

                        if (decimal.TryParse(reader["TankTemperature"].ToString(), out dTemp) == true)
                        {
                            TankTemperature = dTemp;
                        }

                        if (int.TryParse(reader["AirBag1"].ToString(), out iTemp) == true)
                        {
                            AirBag1 = iTemp;
                        }

                        if (int.TryParse(reader["AirBag2"].ToString(), out iTemp) == true)
                        {
                            AirBag2 = iTemp;
                        }

                        if (int.TryParse(reader["AirBag3"].ToString(), out iTemp) == true)
                        {
                            AirBag3 = iTemp;
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
            _connection = Open(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "InsertImpactorParameter",
                };

                cmd.Parameters.Add("@ImpactorTestId", SqlDbType.BigInt).Value = ImpactorTestId;
                cmd.Parameters.Add("@ImpactorTypeId", SqlDbType.BigInt).Value = ImpactorTypeId;
                cmd.Parameters.Add("@Temperature", SqlDbType.Decimal).Value = Temperature;
                cmd.Parameters.Add("@Humidity", SqlDbType.Decimal).Value = Humidity;

                if (Trigger1 == int.MinValue)
                {
                    cmd.Parameters.Add("@Trigger1", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Trigger1", SqlDbType.Int).Value = Trigger1;
                }

                if (Trigger2 == int.MinValue)
                {
                    cmd.Parameters.Add("@Trigger2", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Trigger2", SqlDbType.Int).Value = Trigger2;
                }

                cmd.Parameters.Add("@Notes", SqlDbType.VarChar).Value = Notes;

                if (FirePressure == decimal.MinValue)
                {
                    cmd.Parameters.Add("@FirePressure", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@FirePressure", SqlDbType.Decimal).Value = FirePressure;
                }

                if (CylinderSpeed == int.MinValue)
                {
                    cmd.Parameters.Add("@CylinderSpeed", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@CylinderSpeed", SqlDbType.Int).Value = CylinderSpeed;
                }

                if (MeasuredSpeed == int.MinValue)
                {
                    cmd.Parameters.Add("@MeasuredSpeed", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@MeasuredSpeed", SqlDbType.Int).Value = MeasuredSpeed;
                }

                if (CylinderWithOutImpactorSetpoint == int.MinValue)
                {
                    cmd.Parameters.Add("@WithOutImpactorSetPoint", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@WithOutImpactorSetPoint", SqlDbType.Int).Value = CylinderWithOutImpactorSetpoint;
                }

                if (AcceleratorTemperature == decimal.MinValue)
                {
                    cmd.Parameters.Add("@AcceleratorTemperature", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@AcceleratorTemperature", SqlDbType.Decimal).Value = AcceleratorTemperature;
                }

                if (TankTemperature == decimal.MinValue)
                {
                    cmd.Parameters.Add("@TankTemperature", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@TankTemperature", SqlDbType.Decimal).Value = TankTemperature;
                }

                if (AirBag1 == int.MinValue)
                {
                    cmd.Parameters.Add("@Airbag1", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Airbag1", SqlDbType.Int).Value = AirBag1;
                }

                if (AirBag2 == int.MinValue)
                {
                    cmd.Parameters.Add("@Airbag2", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Airbag2", SqlDbType.Int).Value = AirBag2;

                }

                if (AirBag3 == int.MinValue)
                {
                    cmd.Parameters.Add("@Airbag3", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Airbag3", SqlDbType.Int).Value = AirBag3;
                }

                try
                {
                    object retvalue = cmd.ExecuteScalar();
                    if (long.TryParse(retvalue.ToString(), out long lTemp) == true)
                    {
                        ImpactorParametersId = lTemp;
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

        public string Update ()
        {
            _connection = Open(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "UpdateImpactorParameter",
                };

                cmd.Parameters.Add("@ImpactorParametersId", SqlDbType.BigInt).Value = ImpactorParametersId;
                cmd.Parameters.Add("@ImpactorTestId", SqlDbType.BigInt).Value = ImpactorTestId;
                cmd.Parameters.Add("@ImpactorTypeId", SqlDbType.BigInt).Value = ImpactorTypeId;
                cmd.Parameters.Add("@Temperature", SqlDbType.Decimal).Value = Temperature;
                cmd.Parameters.Add("@Humidity", SqlDbType.Decimal).Value = Humidity;
               
                if (Trigger1 == int.MinValue)
                {
                    cmd.Parameters.Add("@Trigger1", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Trigger1", SqlDbType.Int).Value = Trigger1;
                }

                if (Trigger2 == int.MinValue)
                {
                    cmd.Parameters.Add("@Trigger2", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Trigger2", SqlDbType.Int).Value = Trigger2;
                }
                
                cmd.Parameters.Add("@Notes", SqlDbType.VarChar).Value = Notes;

                if (FirePressure == decimal.MinValue)
                {
                    cmd.Parameters.Add("@FirePressure", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@FirePressure", SqlDbType.Decimal).Value = FirePressure;
                }

                if (CylinderSpeed == int.MinValue)
                {
                    cmd.Parameters.Add("@CylinderSpeed", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@CylinderSpeed", SqlDbType.Int).Value = CylinderSpeed;
                }

                if (MeasuredSpeed == int.MinValue)
                {
                    cmd.Parameters.Add("@MeasuredSpeed", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@MeasuredSpeed", SqlDbType.Int).Value = MeasuredSpeed;
                }

                if (CylinderWithOutImpactorSetpoint == int.MinValue)
                {
                    cmd.Parameters.Add("@WithOutImpactorSetPoint", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@WithOutImpactorSetPoint", SqlDbType.Int).Value = CylinderWithOutImpactorSetpoint;
                }

                if (AcceleratorTemperature == decimal.MinValue)
                {
                    cmd.Parameters.Add("@AcceleratorTemperature", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@AcceleratorTemperature", SqlDbType.Decimal).Value = AcceleratorTemperature;
                }
                
                if (TankTemperature == decimal.MinValue)
                {
                    cmd.Parameters.Add("@TankTemperature", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@TankTemperature", SqlDbType.Decimal).Value = TankTemperature;
                }
                
                if ( AirBag1 == int.MinValue)
                {
                    cmd.Parameters.Add("@Airbag1", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Airbag1", SqlDbType.Int).Value = AirBag1;
                }
                
                if ( AirBag2 == int.MinValue)
                {
                    cmd.Parameters.Add("@Airbag2", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Airbag2", SqlDbType.Int).Value = AirBag2;

                }
                
                if ( AirBag3 == int.MinValue)
                {
                    cmd.Parameters.Add("@Airbag3", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Airbag3", SqlDbType.Int).Value = AirBag3;
                }

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Update ImpactorParmetersID: " + ImpactorParametersId.ToString() + " Failed. Error Number: " + result.ToString();
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
