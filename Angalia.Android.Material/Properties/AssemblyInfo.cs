using System.Reflection;
using System.Runtime.InteropServices;
using Android.App;
using Intersoft.Crosslight;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: IntersoftLicense(@"<License><Id>d8bfdfe4-d2e1-4e95-8046-b411970a0db6</Id><Type>Subscription</Type><LicensedProducts><Product Name=""Crosslight"" Version=""5""/></LicensedProducts><Customer><Name>Louis Amenyo Adanutey</Name><Email>amenyo@teksol.com.gh</Email><Company>Teksol Limited</Company></Customer><Signature>MEUCIQDoowVNnwVAsnIR4ONa3+CUo/LzhytTvOmVlsJcW4dTegIgCiAx7qYtIH2qZ9LxNviyGuRKEvGbAM+JP+AACX5V+Ks=</Signature></License>")]

[assembly: AssemblyTitle("Angalia.Android")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Angalia.Android")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("6992d718-8be8-43a0-b6db-6e0f26d19630")]

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

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// Add some common permissions, these can be removed if not needed

[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]