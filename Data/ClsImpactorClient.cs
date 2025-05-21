using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace Data
{
    [XmlRoot("ImpactorClient")]
    public class ImpactorClient : Database
    {
        [XmlAttribute("ImpactorClientId")]
        public long ImpactorClientId { get; set; } = long.MinValue;

        [XmlAttribute("CompanyName")]
        public string CompanyName { get; set; } = string.Empty;

        [XmlAttribute("ShortName")]
        public string ShortName { get; set; } = string.Empty;

        [XmlAttribute("ClientPrefix")]
        public string ClientPrefix { get; set; } = string.Empty;

        [XmlAttribute("ClientCode")]
        public string ClientCode { get; set; } = string.Empty;

        [XmlAttribute("Address1")]
        public string Address1 { get; set; } = string.Empty;

        [XmlAttribute("Address2")]
        public string Address2 { get; set; } = string.Empty;

        [XmlAttribute("City")]
        public string City { get; set; } = string.Empty;

        [XmlAttribute("State")]
        public string State { get; set; } = string.Empty;

        [XmlAttribute("Zip")]
        public string Zip { get; set; } = string.Empty;

        [XmlAttribute("PhoneNumber")]
        public string PhoneNumber { get; set; } = string.Empty;

        [XmlAttribute("Status")]
        public bool Status { get; set; } = false;

        private SqlConnection _connection = null;
        private readonly string _connectionString = string.Empty;
        public ImpactorClient(string connecitonString) : base(connecitonString)
        {
            _connectionString = connecitonString;
            _connection = Connection;
        }

        public string Get(long impactorClientId)
        {
            _connection = Open(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetImpactorClient";
                cmd.Parameters.Add("@ImpactorClientId", SqlDbType.BigInt).Value = impactorClientId;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        if (long.TryParse(reader["ImpactorClientId"].ToString(), out long lTemp) == true)
                        {
                            ImpactorClientId = lTemp;
                        }

                        CompanyName = reader["CompanyName"].ToString();
                        ShortName = reader["ShortName"].ToString();
                        ClientPrefix = reader["ClientPrefix"].ToString();
                        ClientCode = reader["ClientCode"].ToString();
                        Address1 = reader["Address1"].ToString();
                        Address2 = reader["Address2"].ToString();
                        City = reader["City"].ToString();
                        State = reader["State"].ToString();
                        Zip = reader["Zip"].ToString();
                        PhoneNumber = reader["PhoneNumber"].ToString();

                        if ( bool.TryParse(reader["Status"].ToString().Trim(), out bool bRet) == true ) 
                        {   
                            Status = bRet;
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

        public List<ImpactorClient> GetAll( out string errorMessage)
        {
            List<ImpactorClient> result = new List<ImpactorClient>();
            _connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllImpactorClients";

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        

                        while (reader.Read())
                        {
                            ImpactorClient client = new ImpactorClient(_connectionString);

                            if ( long.TryParse(reader["ImpactorClientId"].ToString(), out long lTemp) == true ) 
                            { 
                                client.ImpactorClientId = lTemp;
                            }

                            client.CompanyName = reader["CompanyName"].ToString();
                            client.ShortName = reader["ShortName"].ToString();
                            client.ClientPrefix = reader["ClientPrefix"].ToString();
                            client.ClientCode = reader["ClientCode"].ToString();
                            client.Address1 = reader["Address1"].ToString();
                            client.Address2 = reader["Address2"].ToString();
                            client.City = reader["City"].ToString();
                            client.State = reader["State"].ToString();
                            client.Zip = reader["Zip"].ToString();
                            client.PhoneNumber = reader["PhoneNumber"].ToString();

                            if ( bool.TryParse(reader["Status"].ToString(), out bool bTemp) == true )
                            {
                                client.Status = bTemp;
                            }

                            result.Add(client);
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

        public List<ImpactorSpecimen> GetAllModels(long custId, out string errorMessage)
        {
            List<ImpactorSpecimen> result = new List<ImpactorSpecimen>();
            _connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetModelsforCustomer";
                cmd.Parameters.Add("@ImpactorClientId", SqlDbType.BigInt).Value = custId;

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

                            specimen.Model = reader["Model"].ToString();
                            if (bool.TryParse(reader["Active"].ToString(), out bool bTemp) == true)
                            {
                                specimen.Active = bTemp;
                            }
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
                    CommandText = "InsertImpactorClient",
                };

                sqlCommand.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = CompanyName;
                sqlCommand.Parameters.Add("@ShortName", SqlDbType.VarChar).Value = ShortName;
                sqlCommand.Parameters.Add("@ClientPrefix", SqlDbType.VarChar).Value = ClientPrefix;
                sqlCommand.Parameters.Add("@ClientCode", SqlDbType.VarChar).Value = ClientCode;
                sqlCommand.Parameters.Add("@Address1", SqlDbType.VarChar).Value = Address1;
                sqlCommand.Parameters.Add("@Address2", SqlDbType.VarChar).Value = Address2;
                sqlCommand.Parameters.Add("@City", SqlDbType.VarChar).Value = City;
                sqlCommand.Parameters.Add("@State", SqlDbType.VarChar).Value = State;
                sqlCommand.Parameters.Add("@Zip", SqlDbType.VarChar).Value = Zip;
                sqlCommand.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = PhoneNumber;
                sqlCommand.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;

                try
                {
                    object retvalue = sqlCommand.ExecuteScalar();
                    if (long.TryParse(retvalue.ToString(), out long lTemp) == true)
                    {
                        ImpactorClientId = lTemp;
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
                cmd.CommandText = "UpdateImpactorClient";
                cmd.Parameters.Add("@ImpactorClientId", SqlDbType.BigInt).Value = ImpactorClientId;
                cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = CompanyName;
                cmd.Parameters.Add("@ShortName", SqlDbType.VarChar).Value = ShortName;
                cmd.Parameters.Add("@ClientPrefix", SqlDbType.VarChar).Value = ClientPrefix;
                cmd.Parameters.Add("@ClientCode", SqlDbType.VarChar).Value = ClientCode;
                cmd.Parameters.Add("@Address1", SqlDbType.VarChar).Value = Address1;
                cmd.Parameters.Add("@Address2", SqlDbType.VarChar).Value = Address2;
                cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = City;
                cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = State;
                cmd.Parameters.Add("@Zip", SqlDbType.VarChar).Value = Zip;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = PhoneNumber;
                cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != -1)
                    {
                        strErrorMessage = "Update ImpactorClientId: " + ImpactorClientId.ToString() + " Failed. Error Number: " + result.ToString();
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
