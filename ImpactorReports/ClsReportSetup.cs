using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace ImpactorReports
{
    public class ReportSetup : Database
    {
        private readonly string _ConnectionString = string.Empty;
       
        public string TestType { get; set; } = string.Empty;
        public ImpactorTest TestData { get; set; } = null;
        public ImpactorClient Client { get; set; } = null;
        public ImpactorParameters TestParameters { get; set; } = null;
        public ImpactorInjuryTimeData TestInjuryData { get; set; } = null;
        public List<ImpactorInjuryTimeData> timeData = null;
        public ImpactorTestParameters ImpactorTestParameters { get; set; } = null;
        public List<ImpactorTestParameters> testParametersList = null;
        public ImpactorCriticalInjuryData CriticalInjuryData { get; set; } = null;
        public List<ImpactorCriticalInjuryData> criticalInjuryData = null;  
        public ImpactorSpecimen Specimen { get; set; } = null;


        public ReportSetup(string connectionString) : base(connectionString)
        {
            _ConnectionString = connectionString;
        }

        public string RunDataReport (List<TestList>tests, TextBox txtProgress, ProgressBar pbar)
        {
            string strErrorMessage;

            List<ReportSetup> reportSetups = new List<ReportSetup>();
            foreach (TestList testlist in tests)
            {
                ReportSetup Test = new ReportSetup(_ConnectionString)
                {
                    TestType = testlist.TestType,
                    TestData = new ImpactorTest(_ConnectionString)
                };
                strErrorMessage = Test.TestData.Get(testlist.ImpactorTestId);
                if (string.IsNullOrEmpty(strErrorMessage) == true)
                {
                    Test.Client = new ImpactorClient(_ConnectionString);
                    strErrorMessage = Test.Client.Get(Test.TestData.CustomerId);
                    if (string.IsNullOrEmpty(strErrorMessage) == true)
                    {
                        Test.TestParameters = new ImpactorParameters(_ConnectionString);
                        strErrorMessage = Test.TestParameters.GetForAnImpactorTest(testlist.ImpactorTestId);
                        if (string.IsNullOrEmpty(strErrorMessage) == true)
                        {
                            Test.TestInjuryData = new ImpactorInjuryTimeData(_ConnectionString);
                            Test.timeData = Test.TestInjuryData.GetAllForATest(testlist.TestRunNumber, out strErrorMessage);
                            if (string.IsNullOrEmpty(strErrorMessage) == true)
                            {
                                Test.ImpactorTestParameters = new ImpactorTestParameters(_ConnectionString);
                                Test.testParametersList = Test.ImpactorTestParameters.GetAllForATest(testlist.TestRunNumber, out strErrorMessage);
                                if (string.IsNullOrEmpty(strErrorMessage) == true)
                                {
                                    Test.CriticalInjuryData = new ImpactorCriticalInjuryData(_ConnectionString);
                                    Test.criticalInjuryData = Test.CriticalInjuryData.GetAll (testlist.TestRunNumber, out strErrorMessage);
                                    if (string.IsNullOrEmpty(strErrorMessage) == true)
                                    {
                                        reportSetups.Add(Test);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            strErrorMessage = ImpactorDataReport.BuildImpactorData(reportSetups, txtProgress, pbar);

            return strErrorMessage;
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
        public long SpecimenId { get; set; } = long.MinValue;   

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

                            if (long.TryParse(reader["SpecimenId"].ToString(), out iLong) == true)
                            {
                                listMember.SpecimenId = iLong;
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

        public static string UpdateBookmark(Document activeDocument, string bookmarkName, string text)
        {
            string strErrorMessage = string.Empty;
            try
            {
                Range l_BookmarkRange = activeDocument.Bookmarks[bookmarkName].Range;
                l_BookmarkRange.Text = text;
                activeDocument.Bookmarks.Add(bookmarkName, l_BookmarkRange);
            }
            catch (Exception ex) 
            { 
                strErrorMessage = "Exception inserting " + text + " bookmark: " + bookmarkName + ". The exception is: " + ex.Message;
            }

            return strErrorMessage;
        }
    }
}


