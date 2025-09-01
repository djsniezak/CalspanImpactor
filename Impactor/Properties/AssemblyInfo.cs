using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Impactor")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Impactor")]
[assembly: AssemblyCopyright("Copyright © 2024-2025")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("00aed292-66e8-482d-b5e9-4841f6c76c98")]

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
//  Version 1.0.001 - Released July 7, 2023
//  Version 1.0.001 
//      August 24, 2024 - Stored Verson 1.002
//  Version 1.0.003
//      September 8, 2024 - Added Client Dialog
//      September 9, 2024 - Added Test Type Dialog
//      September 9, 2024 - Added Impactor Type Dialog
//      September 16, 2024 - Added Protocol Dialog
//      October 6, 2024 - Added Saving and Loading Protocol
//      November 16, 2024 - Released
//      November 23, 2024 - Installed
//  Version 1.0.004
//      December 12, 2024 - Modified Client to not allow duplicated Client Prefixes
//      December 12, 2024 - changed the starting Run Number from "000" to "001"
//      December 12, 2024 - Added ConvertMPerSecToKPH to Conversions
//      December 12, 2024 - Added ListBoxItem
//      December 12, 2024 - Changed Cylinder Speeds from mm/s => m/s
//      December 12, 2024 - Changed the lables Accelerator Temperature to Accumulator Temperature - supporting code NOT changed
//      Released December 12, 2024
// Version 1.0.005
//      December 26, 2024 - Added DryFires to the ImpactorParameters
//      December 26, 2024 - Modifed CtlTestSetup to allow the Impactor Test Id to be modifed by the user.
//      December 26, 2024 - Add DryFires to the Parameter Screen and back Office code
//      December 28, 2024 - Changed Axis X,Y, and Z to double
//      December 28, 2024 - Changed the speeds in Paramater to doubles
//      December 28, 2024 - ConvertMPerSecToKPH(double MPerSec) from int formal parameter
//      December 28, 2024 - In Parameters changed speeds to double, in Axis change X,Y,Z axis tp double
//      January 3, 2025 - Added Specimen Form
//      January 11, 2025 - Added ReportSetup
//      January 18, 2025 - Changed Save Order so parameters are last.
//      Released January 20, 2025
// Version 1.0.006
//      February 9, 2025 - Added Tires to Clear All
//      Febraruy 14, 2025 - Added Active to Specimen
//      February 17, 2025 - Added Injury Type
//      May 3, 2025 - Updated Report Screen to add Error Reporting Text Box
//      May 21, 2025 - Released
//  Version 1.0.007
//      July 6, 2025 - Fixed Speciman not showing new specimans
//      July 6, 2025 - Released
//  Version 1.0.008
//      July 20, 2025 - Fixed a bug in the Axis system that was causing crashes
//      July 20, 2025 - Released
//  Version 1.0.009
//      August 9, 2025 - Added Launcher Dialog
//      August 29, 2025 - Added Vehicle Damage
//      August 31, 2025 - Added head impact speed.
//      Released Septeber 1, 2025
[assembly: AssemblyVersion("1.0.009")]
[assembly: AssemblyFileVersion("1.0.009")]
