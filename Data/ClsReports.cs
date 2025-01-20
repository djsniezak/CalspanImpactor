using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Reports : Database
    {
        private string _ConnectionString = string.Empty;
        private SqlConnection _connection = null;


        public Reports(string connectionString) : base(connectionString)
        {
            _ConnectionString = connectionString;
        }
    }

    public class TestList : Database
    {
        public string _ConnectionString = string.Empty;
        private SqlConnection _connection = null;

        public string TestRunNumber { get; set; } = string.Empty;
        public string TestType {  get; set; } = string.Empty;   
        public int Year { get; set; } = int.MinValue;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string VIN { get; set; } = string.Empty;
        public long ImpactorTestId { get; set; } = long.MinValue;

        public TestList(string connectionString) : base(connectionString)
        {
            _ConnectionString = connectionString;
        }

        public List<TestList> GetAllTests(long customerId, DateTime from, DateTime to, out string errorMessage)
        {
            List<TestList> tests = new List<TestList>();
            _connection = Open(out errorMessage);

            if (string.IsNullOrEmpty(errorMessage) == true)
            {
                SqlDataReader reader;
                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetReportsTestListByCustomerAndDate";
                cmd.Parameters.Add("@CustomerId", SqlDbType.BigInt).Value = customerId;
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = from;
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = to;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            TestList listMember = new TestList(_ConnectionString)
                            {
                                TestRunNumber = reader["TestRunNumber"].ToString(),
                                TestType = reader["TestName"].ToString(),
                                Make = reader["Make"].ToString(),
                                Model = reader["Model"].ToString(),
                                VIN = reader["VIN"].ToString()
                            };

                            if (int.TryParse(reader["Year"].ToString(), out int iTemp) == true)
                            {
                                listMember.Year = iTemp;
                            }

                            if (long.TryParse(reader["ImpactorTestId"].ToString(), out long iLong) == true)
                            {
                                listMember.ImpactorTestId = iLong;
                            }

                            tests.Add(listMember);
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

            return tests;
        }
    }
}


