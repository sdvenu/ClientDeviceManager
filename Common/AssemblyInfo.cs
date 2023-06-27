
//===============================================================================
//
//	Duwamish7 Common Components 
//
//	Assembly Information
//
//===============================================================================
//
// Copyright (C) 2000-2001 Microsoft Corporation
// All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation. See these other
// materials for detailed information regarding Microsoft code samples.
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY 
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT 
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR 
// FITNESS FOR A PARTICULAR PURPOSE.
//
//===============================================================================






using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly:AssemblyTitle( "ClientDeviceMgr Common Components" )]
[assembly:AssemblyConfiguration( " Build" )]
[assembly:AssemblyCompany( "Electronic Data Systems Corporation" )]
[assembly:AssemblyProduct( "ClientDeviceMgr" )]
[assembly:AssemblyCopyright( "Copyright © Electronic Data Systems Corporation 2000-2001" )]
[assembly:AssemblyTrademark( "EDS® is a registered trademark of Electronic Data Systems Corporation." )]
[assembly:AssemblyCulture( "" )]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Revision
//      Build Number
//
// You can specify all the value or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
//
[assembly:AssemblyVersion( "1.0.0.0" )]

//
// In order to sign your assembly you must specify a key to use. Refer to the 
// Microsoft.NET Framework SDK documentation for more information on assembly
// signing.
//
// Use the attributes below to control which key is used for signing. 
//
// Notes: 
//
//   (*) If no key is specified - the assembly cannot be signed.
//   (*) KeyName refers to a key that has been installed in the Crypto Service
//       Provider (CSP) on your machine. 
//   (*) If the key file and a key name attributes are both specified, the 
//       following processing occurs:
//       (1) If the KeyName can be found in the CSP - that key is used.
//       (2) If the KeyName does not exist and the KeyFile does exist, the key 
//           in the file is installed into the CSP and used.
//   (*) Delay Signing is an advanced option - see the Microsoft.NET Framework 
//       SDK documentation for more information on this.
//

//
// Defaults values for component services
//
[assembly:ComVisible( false )]

[assembly:System.Security.AllowPartiallyTrustedCallers]
