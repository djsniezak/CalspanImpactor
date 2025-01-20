using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Data
{
    [XmlRoot("ImpactorSpeciment")]
    public class ImpactorSpecimen : Database
    {
        [XmlAttribute("SpecimenId")]
        public long SpecimenId { get; set; } = long.MinValue;

        [XmlAttribute("CustomerId")]
        public long CustomerId { get; set; } = long.MinValue;

        [XmlAttribute("CompanyName")]
        public string CompanyName { get; set; } = string.Empty;

        [XmlAttribute("Year")]
        public int Year { get; set; } = int.MinValue;

        [XmlAttribute("Make")]
        public string Make { get; set; } = string.Empty;

        [XmlAttribute("Model")]
        public string Model { get; set; } = string.Empty;

        [XmlAttribute("VIN")]
        public string VIN { get; set; } = string.Empty;

        [XmlAttribute("Mass")]
        public double Mass { get; set; } = double.MinValue;

        [XmlAttribute("Notes")]
        public string Notes { get; set; } = string.Empty;

        private SqlConnection _connection = null;
        private readonly string _connectionString = string.Empty;

        public ImpactorSpecimen(string connecitonString) : base(connecitonString)
        {
            _connectionString = connecitonString;
            _connection = Connection;
        }

        public string Get(long specimenId)
        {
            _connection = Open(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetASpecimen";
                cmd.Parameters.Add("@SpecimenId", SqlDbType.BigInt).Value = specimenId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        if (long.TryParse(reader["SpecimenId"].ToString(), out long lTemp) == true)
                        {
                            SpecimenId = lTemp;
                        }
                        if (long.TryParse(reader["CustomerId"].ToString(), out lTemp) == true)
                        {
                            CustomerId= lTemp;
                        }

                        CompanyName = reader["CompanyName"].ToString();

                        if (int.TryParse(reader["Year"].ToString(), out int iTemp) == true)
                        {
                            Year = iTemp;
                        }

                        Make = reader["Make"].ToString();
                        Model = reader["Model"].ToString();
                        VIN = reader["VIN"].ToString();

                        if (double.TryParse(reader["Mass"].ToString(), out double dTemp) == true)
                        {
                            Mass = dTemp;
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

        public List<ImpactorSpecimen> GetAll(out string errorMessage)
        {
            List<ImpactorSpecimen> result = new List<ImpactorSpecimen>();
            _connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllSpecimens";

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ImpactorSpecimen specimen = new ImpactorSpecimen(_connectionString);

                            if (long.TryParse(reader["SpecimenId"].ToString(), out long lTemp) == true)
                            {
                                specimen.SpecimenId = lTemp;
                            }
                            if (long.TryParse(reader["CustomerId"].ToString(), out lTemp) == true)
                            {
                                specimen.CustomerId = lTemp;
                            }

                            specimen.CompanyName = reader["CompanyName"].ToString();

                            if (int.TryParse(reader["Year"].ToString(), out int iTemp) == true)
                            {
                                specimen.Year = iTemp;
                            }

                            specimen.Make = reader["Make"].ToString();
                            specimen.Model = reader["Model"].ToString();
                            specimen.VIN = reader["VIN"].ToString();

                            if (double.TryParse(reader["Mass"].ToString(), out double dTemp) == true)
                            {
                                specimen.Mass = dTemp;
                            }

                            specimen.Notes = reader["Notes"].ToString();

                            result.Add(specimen);
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
                    CommandText = "InsertASpecimen",
                };

                sqlCommand.Parameters.Add("@CustomerId", SqlDbType.BigInt).Value = CustomerId;
                sqlCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                sqlCommand.Parameters.Add("@Make", SqlDbType.VarChar).Value = Make;
                sqlCommand.Parameters.Add("@Model", SqlDbType.VarChar).Value = Model;
                sqlCommand.Parameters.Add("@VIN", SqlDbType.VarChar).Value = VIN;
                sqlCommand.Parameters.Add("@Mass", SqlDbType.Decimal).Value = Mass;
                sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar).Value = Notes;
                

                try
                {
                    object retvalue = sqlCommand.ExecuteScalar();
                    if (long.TryParse(retvalue.ToString(), out long lTemp) == true)
                    {
                        SpecimenId = lTemp;
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
                SqlCommand sqlCommand = _connection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "UpdateASpecimen";

                sqlCommand.Parameters.Add("@SpecimenId", SqlDbType.BigInt).Value = SpecimenId;
                sqlCommand.Parameters.Add("@CustomerId", SqlDbType.BigInt).Value = CustomerId;
                sqlCommand.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
                sqlCommand.Parameters.Add("@Make", SqlDbType.VarChar).Value = Make;
                sqlCommand.Parameters.Add("@Model", SqlDbType.VarChar).Value = Model;
                sqlCommand.Parameters.Add("@VIN", SqlDbType.VarChar).Value = VIN;
                sqlCommand.Parameters.Add("@Mass", SqlDbType.Decimal).Value = Mass;
                sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar).Value = Notes;

                try
                {
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Update SpecimanId: " + SpecimenId.ToString() + " Failed. Error Number: " + result.ToString();
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
