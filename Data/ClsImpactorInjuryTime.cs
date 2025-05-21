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
    [XmlRoot("ImpactorInjuryTime")]
    public class ImpactorInjuryTime : Database
    {
        [XmlAttribute("ImpactorInjuryTimeId")]
        public long ImpactorInjuryTimeId { get; set; } = long.MinValue;

        [XmlAttribute("ShortName")]
        public string ShortName { get; set; } = string.Empty;

        [XmlAttribute("InjuryDefinition")]
        public string InjuryDefinition {  get; set; } = string.Empty;

        [XmlAttribute("Description")]
        public string Description {  get; set; } = string.Empty;

        [XmlAttribute("DefaultUnits")]
        public string DefaultUnits {  get; set; } = string.Empty;

        [XmlAttribute("MaxValueUsed")]
        public bool MaxValueUsed { get; set; } = false;

        [XmlAttribute("MaxTimeUsed")]
        public bool MaxTimeUsed { get; set; } = false;

        [XmlAttribute("MinValueUsed")]
        public bool MinValueUsed { get; set; } = false;

        [XmlAttribute("MinTimeUsed")]
        public bool MinTimeUsed { get; set; } = false;

       [XmlAttribute("Status")]
        public bool Status { get; set; } = false;

        private SqlConnection _Connection = null;
        private readonly string _ConnectionString = string.Empty;

        public ImpactorInjuryTime (string connectionString) : base (connectionString)
        {
            _ConnectionString = connectionString;
        }

        public string Get(long impactorInjuryTypeId)
        {
            _Connection = Open(out string strErrorMessage);

            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAnInjuryTimeRecord";
                cmd.Parameters.Add("@InjuryTypeId", SqlDbType.BigInt).Value = impactorInjuryTypeId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        if (long.TryParse(reader["ImpactorInjuryTimeId"].ToString(), out long lTemp) == true)
                        {
                            ImpactorInjuryTimeId = lTemp;
                        }

                        ShortName = reader["ShortName"].ToString();
                        InjuryDefinition = reader["InjuryDefinition"].ToString();
                        Description = reader["Description"].ToString();
                        DefaultUnits = reader["DefaultUnits"].ToString();

                        if (bool.TryParse (reader["MaxValueUsed"].ToString(), out bool bTemp) == true )
                        {
                            MaxValueUsed = bTemp;
                        }

                        if (bool.TryParse(reader["MaxTimeUsed"].ToString(), out bTemp) == true)
                        {
                            MaxTimeUsed = bTemp;
                        }

                        if (bool.TryParse(reader["MinValueUsed"].ToString(), out bTemp) == true)
                        {
                            MinValueUsed = bTemp;
                        }

                        if (bool.TryParse(reader["MinTimeUsed"].ToString(), out bTemp) == true)
                        {
                            MinTimeUsed = bTemp;
                        }

                        if (bool.TryParse(reader["Status"].ToString(), out bTemp) == true)
                        {
                            Status = bTemp;
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

        public List<ImpactorInjuryTime> GetAll(out string errorMessage)
        {
            List<ImpactorInjuryTime> result = new List<ImpactorInjuryTime>();
            _Connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllInjuryTimeRecords";

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ImpactorInjuryTime Itype = new ImpactorInjuryTime(_ConnectionString);

                            if (long.TryParse(reader["ImpactorInjuryTimeId"].ToString(), out long lTemp) == true)
                            {
                                Itype.ImpactorInjuryTimeId = lTemp;
                            }

                            Itype.ShortName = reader["ShortName"].ToString();
                            Itype.InjuryDefinition = reader["InjuryDefinition"].ToString();
                            Itype.Description = reader["Description"].ToString();

                            if (bool.TryParse(reader["MaxValueUsed"].ToString(), out bool bTemp) == true)
                            {
                                Itype.MaxValueUsed = bTemp;
                            }

                            if (bool.TryParse(reader["MaxTimeUsed"].ToString(), out bTemp) == true)
                            {
                                Itype. MaxTimeUsed = bTemp;
                            }

                            if (bool.TryParse(reader["MinValueUsed"].ToString(), out bTemp) == true)
                            {
                                Itype.MinValueUsed = bTemp;
                            }

                            if (bool.TryParse(reader["MinTimeUsed"].ToString(), out bTemp) == true)
                            {
                                Itype.MinTimeUsed = bTemp;
                            }

                            if (bool.TryParse(reader["Status"].ToString(), out bTemp) == true)
                            {
                                Itype.Status = bTemp;
                            }

                            result.Add(Itype);
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
                    CommandText = "InsertInjuryTimeRecord",
                };

                sqlCommand.Parameters.Add("@ShortName", SqlDbType.VarChar).Value = ShortName;
                sqlCommand.Parameters.Add("@InjuryDefinition", SqlDbType.VarChar).Value = InjuryDefinition;
                sqlCommand.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;
                sqlCommand.Parameters.Add("@DefaultUnits", SqlDbType.VarChar).Value = DefaultUnits;
                sqlCommand.Parameters.Add("@MaxValueUsed", SqlDbType.Bit).Value = MaxValueUsed;
                sqlCommand.Parameters.Add("@MaxTimeUsed", SqlDbType.Bit).Value = MaxTimeUsed;
                sqlCommand.Parameters.Add("@MinValueUsed", SqlDbType.Bit).Value = MinValueUsed;
                sqlCommand.Parameters.Add("@MinTimeUsed", SqlDbType.Bit).Value = MinTimeUsed;
                sqlCommand.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;

                try
                {
                    object retvalue = sqlCommand.ExecuteScalar();
                    if (long.TryParse(retvalue.ToString(), out long lTemp) == true)
                    {
                        ImpactorInjuryTimeId = lTemp;
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
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = _Connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "UpdateInjuryTimeRecord",
                };

                sqlCommand.Parameters.Add("@ImpactorInjuryTimeId", SqlDbType.BigInt).Value = ImpactorInjuryTimeId;
                sqlCommand.Parameters.Add("@ShortName", SqlDbType.VarChar).Value = ShortName;
                sqlCommand.Parameters.Add("@InjuryDefinition", SqlDbType.VarChar).Value = InjuryDefinition;
                sqlCommand.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;
                sqlCommand.Parameters.Add("@DefaultUnits", SqlDbType.VarChar).Value = DefaultUnits;
                sqlCommand.Parameters.Add("@MaxValueUsed", SqlDbType.Bit).Value = MaxValueUsed;
                sqlCommand.Parameters.Add("@MaxTimeUsed", SqlDbType.Bit).Value = MaxTimeUsed;
                sqlCommand.Parameters.Add("@MinValueUsed", SqlDbType.Bit).Value = MinValueUsed;
                sqlCommand.Parameters.Add("@MinTimeUsed", SqlDbType.Bit).Value = MinTimeUsed;
                sqlCommand.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;

                try
                {
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Update InjuryType ID: " + ImpactorInjuryTimeId.ToString() + " Failed. Error Number: " + result.ToString();
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
    }
}

