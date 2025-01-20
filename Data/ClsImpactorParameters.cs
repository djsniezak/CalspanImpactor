using System;
using System.Data;
using System.Data.SqlClient;
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
        public double Temperature { get; set; } = double.MinValue;

        [XmlAttribute("Humidity")]
        public double Humidity { get; set; } = double.MinValue;

        [XmlAttribute("Trigger1")]
        public int Trigger1 { get; set; } = int.MinValue;

        [XmlAttribute("Trigger2")]
        public int Trigger2 { get; set; } = int.MinValue;

        [XmlAttribute("Notes")]
        public string Notes { get; set; } = string.Empty;

        [XmlAttribute("FirePressure")]
        public double FirePressure { get; set; } = double.MinValue;

        [XmlAttribute("CylinderSpeed")]
        public double CylinderSpeed { get; set; } = double.MinValue;

        [XmlAttribute("MeasuredSpeed")]
        public double MeasuredSpeed { get; set; } = double.MinValue;

        [XmlAttribute("CylinderWithOutImpactorSetpoint")]
        public double CylinderWithOutImpactorSetpoint { get; set; } = double.MinValue;

        [XmlAttribute("AccumulatorTemperature")]
        public double AccumulatorTemperature { get; set; } = double.MinValue;

        [XmlAttribute("TankTemperature")]
        public double TankTemperature { get; set; } = double.MinValue;

        [XmlAttribute("AirBag1")]
        public int AirBag1 { get; set; } = int.MinValue;

        [XmlAttribute("AirBag2")]
        public int AirBag2 { get; set; } = int.MinValue;

        [XmlAttribute("AirBag3")]
        public int AirBag3 { get; set; } = int.MinValue;

        [XmlAttribute("DryFires")]
        public int DryFires { get; set; } = int.MinValue;

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
                        
                        if (double.TryParse(reader["Temperature"].ToString(), out double dTemp) == true )
                        {
                            Temperature = dTemp;
                        }

                        if (double.TryParse(reader["Humidity"].ToString(), out dTemp) == true)
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

                        if (double.TryParse(reader["FirePressure"].ToString(), out dTemp) == true)
                        {
                            FirePressure = dTemp;
                        }

                        if (double.TryParse(reader["CylinderSpeed"].ToString(), out dTemp) == true)
                        {
                            CylinderSpeed = iTemp;
                        }

                        if (double.TryParse(reader["MeasuredSpeed"].ToString(), out dTemp) == true)
                        {
                            MeasuredSpeed = iTemp;
                        }

                        if (double.TryParse(reader["WithOutImpactorSetPoint"].ToString(), out dTemp) == true)
                        {
                            CylinderWithOutImpactorSetpoint = iTemp;
                        }

                        if (double.TryParse(reader["AccumulatorTemperature"].ToString(), out dTemp) == true)
                        {
                            AccumulatorTemperature = dTemp;
                        }

                        if (double.TryParse(reader["TankTemperature"].ToString(), out dTemp) == true)
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

                        if (int.TryParse(reader["DryFires"].ToString(), out iTemp) == true)
                        {
                            DryFires = iTemp;
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

                        if (double.TryParse(reader["Temperature"].ToString(), out double dTemp) == true)
                        {
                            Temperature = dTemp;
                        }

                        if (double.TryParse(reader["Humidity"].ToString(), out dTemp) == true)
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

                        if (double.TryParse(reader["FirePressure"].ToString(), out dTemp) == true)
                        {
                            FirePressure = dTemp;
                        }

                        if (double.TryParse(reader["CylinderSpeed"].ToString(), out dTemp) == true)
                        {
                            CylinderSpeed = iTemp;
                        }

                        if (double.TryParse(reader["MeasuredSpeed"].ToString(), out dTemp) == true)
                        {
                            MeasuredSpeed = iTemp;
                        }

                        if (double.TryParse(reader["WithOutImpactorSetPoint"].ToString(), out dTemp) == true)
                        {
                            CylinderWithOutImpactorSetpoint = iTemp;
                        }

                        if ( double.TryParse(reader["AccumulatorTemperature"].ToString(), out dTemp) == true)
                        {
                            AccumulatorTemperature = dTemp;
                        }

                        if (double.TryParse(reader["TankTemperature"].ToString(), out dTemp) == true)
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

                        if (int.TryParse(reader["DryFires"].ToString(), out iTemp) == true)
                        {
                            DryFires = iTemp;
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

                if (FirePressure == double.MinValue)
                {
                    cmd.Parameters.Add("@FirePressure", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@FirePressure", SqlDbType.Decimal).Value = FirePressure;
                }

                if (CylinderSpeed == double.MinValue)
                {
                    cmd.Parameters.Add("@CylinderSpeed", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@CylinderSpeed", SqlDbType.Decimal).Value = CylinderSpeed;
                }

                if (MeasuredSpeed == double.MinValue)
                {
                    cmd.Parameters.Add("@MeasuredSpeed", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@MeasuredSpeed", SqlDbType.Decimal).Value = MeasuredSpeed;
                }

                if (CylinderWithOutImpactorSetpoint == double.MinValue)
                {
                    cmd.Parameters.Add("@WithOutImpactorSetPoint", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@WithOutImpactorSetPoint", SqlDbType.Int).Value = CylinderWithOutImpactorSetpoint;
                }

                if (AccumulatorTemperature == double.MinValue)
                {
                    cmd.Parameters.Add("@AccumulatorTemperature", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@AccumulatorTemperature", SqlDbType.Decimal).Value = AccumulatorTemperature;
                }

                if (TankTemperature == double.MinValue)
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

                if (DryFires == int.MinValue)
                {
                    cmd.Parameters.Add("@DryFires", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@DryFires", SqlDbType.Int).Value = DryFires;
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

                if (FirePressure == double.MinValue)
                {
                    cmd.Parameters.Add("@FirePressure", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@FirePressure", SqlDbType.Decimal).Value = FirePressure;
                }

                if (CylinderSpeed == double.MinValue)
                {
                    cmd.Parameters.Add("@CylinderSpeed", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@CylinderSpeed", SqlDbType.Decimal).Value = CylinderSpeed;
                }

                if (MeasuredSpeed == double.MinValue)
                {
                    cmd.Parameters.Add("@MeasuredSpeed", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@MeasuredSpeed", SqlDbType.Decimal).Value = MeasuredSpeed;
                }

                if (CylinderWithOutImpactorSetpoint == double.MinValue)
                {
                    cmd.Parameters.Add("@WithOutImpactorSetPoint", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@WithOutImpactorSetPoint", SqlDbType.Decimal).Value = CylinderWithOutImpactorSetpoint;
                }

                if (AccumulatorTemperature == double.MinValue)
                {
                    cmd.Parameters.Add("@AccumulatorTemperature", SqlDbType.Decimal).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@AccumulatorTemperature", SqlDbType.Decimal).Value = AccumulatorTemperature;
                }
                
                if (TankTemperature == double.MinValue)
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

                if (DryFires == int.MinValue)
                {
                    cmd.Parameters.Add("@DryFires", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@DryFires", SqlDbType.Int).Value = DryFires;
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
