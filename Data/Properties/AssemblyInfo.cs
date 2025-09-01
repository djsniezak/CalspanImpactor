using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Data")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Data")]
[assembly: AssemblyCopyright("Copyright © 2024-2025")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("a731d6c1-586b-4b29-980c-2af5f56e69f6")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
//
// Version 1.0.0
//          July 23, 2024 - Added Database, Impactor Test, Imapctor Parameters
//          July 27, 2024 - Added Impactor Axis
//          August 24, 2024 - Add rest of classes
//          Stored Not Released August 24, 2024 - Version 1.002
//  Version 1.1.0
//          December 12, 2024 - changed the starting Run Number from "000" to "001"
//          December 12, 2024 - Added ConvertMPerSecToKPH to Conversions
//          December 12, 2024 - Added ListBoxItem
// Version 1.2.0
//          December 26, 2024 - Added DryFires to the ImpactorParameters
//          December 28, 2024 - Changed Axis X,Y, and Z to double
//          December 28, 2024 - Changed the speeds in Paramater to doubles
//          December 28, 2024 - ConvertMPerSecToKPH(double MPerSec) from int formal parameter
//          January 2, 2025 - Added Specimen class
//          January 4, 2025 - Added Tires class
//          January 5, 2025 - Changed Accelerator Temperture to Accumulator Temperature
//          Released January 20, 2025
// Version 1.3.0
//          February 9, 2025 - Add GetAll Models
//          February 14, 2025 - Added Active to Specimen class
//          February 17, 2025 - Added Injury Type Class
//          February 17, 2025 - Added SelectComboBox using boolean value
//          February 17, 2025 - Added ClsReports
//          March 8, 2025 - Added Impactor Injury Time
//          March 8, 2025 - Added Impactor Injury Time Data
//          April 27, 2025 - Added Impactor Critial Injury Names and Impactor Critical Injury Data
//          April 27, 2025 - Added Value (object) to DropdownList class
//          May 21, 2025 - Released
// Version 1.3.1
//          July 6, 2025 - Made active true on Specimen Insert.
//          July 6, 2025 - Released
// Version 1.4.0
//          August 9, 2025 - Added Launcher
//          August 29, 2025 - add Vehicle Damage class
//          August 31, 2025 - Add Head Impact Speed 
//          Released Septeber 1, 2025
[assembly: AssemblyVersion("1.4.0")]
[assembly: AssemblyFileVersion("1.4.0")]
