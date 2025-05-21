using Data;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace ImpactorReports
{
    public class ImpactorDataReport
    {
        public static string BuildImpactorData (List<ReportSetup>reports, TextBox txtProgress, ProgressBar pBar)
        {
            int total = reports.Count;
            int step = 100/total;
            pBar.Step = step;   

            Microsoft.Office.Interop.Word.Application WordApp = LoadWordApplication(out string strErrorMessage);
            if (string.IsNullOrEmpty(strErrorMessage) == true)
            {
                WordApp.Visible = true;
                string message;
                if ( reports.Count == 1 )
                {
                    message = "Report Started" + Environment.NewLine;
                }
                else
                {
                    message = "Reports Started" + Environment.NewLine;
                }
                
                txtProgress.Text = message;

                foreach (ReportSetup setup in reports)
                {
                    switch (setup.TestType)
                    {
                        case "Small Guided (Upper Legform)":
                            strErrorMessage = BuildUpperLeg(setup, WordApp, pBar, step);

                            if ( string.IsNullOrEmpty(strErrorMessage) == true )
                            {
                                txtProgress.Text += "Data - Upper Legform Complete" + Environment.NewLine;
                            }
                            else 
                            {
                                txtProgress.Text += strErrorMessage + Environment.NewLine;
                            }
                            
                            break;
                        case "Lower Leg":
                            strErrorMessage = BuildLowerLeg(setup, WordApp, pBar, step);

                            if (string.IsNullOrEmpty(strErrorMessage) == true)
                            {
                                txtProgress.Text += "Data - Lower Legform Complete" + Environment.NewLine;
                            }
                            else
                            {
                                txtProgress.Text += strErrorMessage + Environment.NewLine;
                            }

                            break;
                        case "Adult Headform":
                        case "Child Headform":
                            strErrorMessage = BuildHeadform(setup, WordApp, pBar, step);

                            if (string.IsNullOrEmpty(strErrorMessage) == true)
                            {
                                txtProgress.Text += "Data - Headform Complete" + Environment.NewLine;
                            }
                            else
                            {
                                txtProgress.Text += strErrorMessage + Environment.NewLine;
                            }

                            break;
                        default:
                            strErrorMessage = "There is no method for the " + setup.TestType + Environment.NewLine;
                            break;
                    }
                }

                WordApp.Quit();
            }

            return strErrorMessage; 
        }

        private static string BuildLowerLeg(ReportSetup setup, Microsoft.Office.Interop.Word.Application wordApp, ProgressBar pbar, int step)
        {
            object TemplatePath = ConfigurationManager.AppSettings["TemplatePath"] + "\\Lower Leg.dotx";
            Document document;

            int miniStep = step / 4;
            document = OpenDocument(wordApp, TemplatePath, out string strErrorMessage);
            if (document != null)
            {
                document.Activate();

                // Header
                FillInHeader(document, setup);
                pbar.Value += miniStep;

                //Test Parameters
                string[] TestParmNames = { "Impact Velocity From Integration", "Impact Velocity From Speed Trap" };
                FillTestParameters(TestParmNames, setup, wordApp, document);
                pbar.Value += miniStep;
                System.Windows.Forms.Application.DoEvents();

                //Critical Injury Values
                string[] CriticalInjury = { "Max Tibia", "MCL Elongation", "ACL Threshold", "PCL Threshold" };
                FillCriticalInjury(CriticalInjury, setup, wordApp, document);
                pbar.Value += miniStep;
                System.Windows.Forms.Application.DoEvents();

                string[] MaxMin = new string[] { "FlexPLI Acceleration","Upper Tibia Moment", "Middle Upper Tibia Moment", "Middle Lower Tibia Moment", "Lower Tibia Moment",
                                                     "Upper Femur Moment", "Middle Femur Moment", "Lower Femur Moment", "ACL Displacement", "MCL Displacement", "PCL Displacement", "LCL Displacement" };
                // Min/Max
                FillMinMaxTable(MaxMin, 3, setup, wordApp, document);
                pbar.Value += miniStep;
                System.Windows.Forms.Application.DoEvents();
            }
            return strErrorMessage;
        }

        private static string BuildUpperLeg(ReportSetup setup, Microsoft.Office.Interop.Word.Application wordApp, ProgressBar pbar, int step)
        {
            object TemplatePath = ConfigurationManager.AppSettings["TemplatePath"] + "\\Upper Leg.dotx";
            Document document;

            int miniStep = step / 4;
            document = OpenDocument(wordApp, TemplatePath, out string strErrorMessage);
            if (document != null)
            {
                document.Activate();

                // Header
                FillInHeader(document, setup);
                UpdateProgressBar(pbar, miniStep);

                //Test Parameters
                string[] TestParmNames = { "Impact Velocity From Speed Trap" };
                FillTestParameters(TestParmNames, setup, wordApp, document);
                UpdateProgressBar(pbar, miniStep);

                //Critical Injury Values
                string[] CriticalInjury = { "Sum of Femur Force" };
                FillCriticalInjury(CriticalInjury, setup, wordApp, document);
                UpdateProgressBar(pbar, miniStep);

                // Max/Min Table
                string[] MaxMin = new string[] { "Upper Femur Moment", "Middle Femur Moment", "Lower Femur Moment", "Upper Femur Force", "Lower Femur Force" };
                FillMinMaxTable(MaxMin, 3, setup, wordApp, document);
                UpdateProgressBar(pbar, miniStep);
            }

            return strErrorMessage;
        }

        private static string BuildHeadform(ReportSetup setup, Microsoft.Office.Interop.Word.Application wordApp, ProgressBar pbar, int step)
        {
            object TemplatePath = ConfigurationManager.AppSettings["TemplatePath"] + "\\Headform.dotx";
            Document document;

            int miniStep = step / 3;
            document = OpenDocument(wordApp, TemplatePath, out string strErrorMessage);

            if (document != null)
            {

                //Load Header
                FillInHeader(document, setup);
                UpdateProgressBar(pbar, miniStep);

                //Test Parameters
                string[] TestParmNames = { "HIC15", "Impact Velocity From Integration", "Impact Velocity From Speed Trap" };
                FillTestParameters(TestParmNames, setup, wordApp, document);
                UpdateProgressBar(pbar, miniStep);

                // Max/Min Table
                string[] MaxMin = new string[] { "Head X Acceleration", "Head Y Acceleration", "Lower Femur Moment", "Head Z Acceleration", "Head Resultant Acceleration" };
                FillMinMaxTable(MaxMin, 2, setup, wordApp, document);
                UpdateProgressBar(pbar, miniStep);
            }

            return strErrorMessage;
        }

        private static void FillInHeader (Document document, ReportSetup setup)
        {
            // Header
            TestList.UpdateBookmark(document, "CustomerShortName", setup.Client.ShortName);
            TestList.UpdateBookmark(document, "TestRunNumber", setup.TestData.ImpactorRunNumber);
            TestList.UpdateBookmark(document, "TestDate", setup.TestData.RunTime.ToShortDateString());
        }

        private static void FillTestParameters (string[] names, ReportSetup setup, Microsoft.Office.Interop.Word.Application wordApp, Document document)
        {
            Table TestParms = document.Tables[1];
            
            for (int index = 0; index < names.Length; index++)
            {
                ImpactorTestParameters value = setup.ImpactorTestParameters.FindName(setup.testParametersList, names[index]);
                if (value != null)
                {
                    TestList.UpdateBookmark(document, "TestParmTestParameter", value.ParameterName);
                    if ( value.ParameterName.Contains ("Velocity"))
                    {
                        string kph = Conversion.ConvertFloatToString(value.Value, "#0.0#");
                        if (kph == "--")
                        {
                            TestList.UpdateBookmark(document, "TestParmValue", kph);
                        }
                        else
                        {
                            TestList.UpdateBookmark(document, "TestParmValue", kph + " kph");
                        }
                    }
                    else
                    {
                        TestList.UpdateBookmark(document, "TestParmValue", Conversion.ConvertFloatToString(value.Value, "#0.0#"));
                    }

                    TestList.UpdateBookmark(document, "TestParmTime1", Conversion.ConvertFloatToString(value.TimeOne, "#0.0#"));
                    TestList.UpdateBookmark(document, "TestParmTime2", Conversion.ConvertFloatToString(value.TimeTwo, "#0.0#"));
                    TestList.UpdateBookmark(document, "TestParmDuration", Conversion.ConvertFloatToString(value.Duration, "#0.0#"));
                }

                TestParms.Rows.Last.Select();
                wordApp.Selection.Copy();
                TestParms.Rows.Last.Select();
                wordApp.Selection.Paste();
            }
            TestParms.Rows.Last.Delete();
        }

        private static void FillCriticalInjury(string[] names, ReportSetup setup, Microsoft.Office.Interop.Word.Application wordApp, Document document)
        {
            Table TestParms = document.Tables[2];

            for (int index = 0; index < names.Length; index++)
            {
                ImpactorCriticalInjuryData value = setup.CriticalInjuryData.FindName (setup.criticalInjuryData, names [index]);
                if (value != null)
                {
                    TestList.UpdateBookmark(document, "CriticalTestParameter", value.TestParameterName);
                    TestList.UpdateBookmark(document, "CriticalTestChannel", value.Channel);
                    if (char.IsDigit(value.Value[0]) == false)
                    {
                        TestList.UpdateBookmark(document, "CriticalTestValue", value.Value);
                    }
                    else
                    {
                        TestList.UpdateBookmark(document, "CriticalTestValue", value.Value + " N");
                    }

                    string time = Conversion.ConvertFloatToString(value.Time, "#0.0#");
                    if ( time == "--")
                    {
                        TestList.UpdateBookmark(document, "CriticalTestTime", time);
                    }
                    else
                    {
                        TestList.UpdateBookmark(document, "CriticalTestTime", time + " ms");
                    }
                    

                    TestParms.Rows.Last.Select();
                    wordApp.Selection.Copy();
                    TestParms.Rows.Last.Select();
                    wordApp.Selection.Paste();
                }
            }
            TestParms.Rows.Last.Delete();
        }
        private static void FillMinMaxTable (string[] names, int tableIndex, ReportSetup setup, Microsoft.Office.Interop.Word.Application wordApp, Document document)
        {
            Table MaxMinTable = document.Tables[tableIndex];
            for (int index = 0; index < names.Length; index++)
            {
                ImpactorInjuryTimeData TimeValue = setup.TestInjuryData.FindName(setup.timeData, names[index]);
                if (TimeValue != null)
                {
                    TestList.UpdateBookmark(document, "MaxMinChannel", TimeValue.ShortName);
                    TestList.UpdateBookmark(document, "MaxMinUnit", TimeValue.Units);
                    TestList.UpdateBookmark(document, "MaxMinMax", Conversion.ConvertFloatToString(TimeValue.MaxValue, "#0.0#"));
                    TestList.UpdateBookmark(document, "MaxMinMaxTime", Conversion.ConvertFloatToString(TimeValue.MaxTime, "#0.0#"));
                    TestList.UpdateBookmark(document, "MaxMinMin", Conversion.ConvertFloatToString(TimeValue.MinValue, "#0.0#"));
                    TestList.UpdateBookmark(document, "MaxMinMinTime", Conversion.ConvertFloatToString(TimeValue.MinTime, "#0.0#"));

                    MaxMinTable.Rows.Last.Select();
                    wordApp.Selection.Copy();
                    MaxMinTable.Rows.Last.Select();
                    wordApp.Selection.Paste();
                }
            }
            MaxMinTable.Rows.Last.Delete();
        }
        private static Microsoft.Office.Interop.Word.Application LoadWordApplication(out string errorMessage)
        {
            Microsoft.Office.Interop.Word.Application WordApp = null;
            errorMessage = string.Empty;

            try
            {
                 WordApp = new Microsoft.Office.Interop.Word.Application();
            }
            catch (Exception ex)
            {
                errorMessage = "An exception occured attempting to load the Word Applcation. The Exception: " + ex.Message + Environment.NewLine;
            }

            return WordApp;
        }

        private static Document OpenDocument(Microsoft.Office.Interop.Word.Application wordApp, object templatePath, out string errorMessage)
        {
            Document document = null;
            errorMessage = string.Empty;

            try
            {
                document = wordApp.Documents.Add(templatePath);
            }
            catch (Exception ex)
            {
                errorMessage = "An exception has occured trying to Load: " + templatePath + "\nThe exception: " + ex.Message;
            }

            if (document != null)
            {
                document.BuiltInDocumentProperties("Title").value = "Document 1";
                document.Activate();
            }

            return document;
        }

        private static void UpdateProgressBar (ProgressBar progressBar, int step)
        {
            progressBar.Value += step;
            System.Windows.Forms.Application.DoEvents();
        }
    }
}
