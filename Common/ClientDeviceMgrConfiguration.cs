//----------------------------------------------------------------
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
//----------------------------------------------------------------


namespace ClientDeviceMgr.Common
{
    using System;
    using System.Collections;
    using System.Configuration;
    using System.Xml;
    
    using ClientDeviceMgr.SystemFramework;
    using System.Collections.Specialized;
    /// <summary>
    ///     This class handles Duwamish-specific configuration settings in
    ///     Config.Web.
    ///     <remarks>
    ///         Special considerations:
    ///         The Duwamish application's configuaration settings are kept in 
    ///         the DuwamishConfiguration section of the Config.web file. A new
    ///         instance of this class is created automatically whenever the
    ///         settings file changes, so there is no need to cache any values.
    ///     </remarks>
    /// </summary>
    public class ClientDeviceMgrConfiguration : IConfigurationSectionHandler
    {
        //
        // Constant values for all expected entries in the ClientDeviceMgrConfiguration section
        //
        private const String WEB_ENABLEPAGECACHE           = "ClientDeviceMgr.Web.EnablePageCache";
        private const String WEB_PAGECACHEEXPIRESINSECONDS = "ClientDeviceMgr.Web.PageCacheExpiresInSeconds";
        private const String DATAACCESS_CONNECTIONSTRING   = "ClientDeviceMgr.DataAccess.ConnectionString";
        private const String WEB_ENABLESSL                 = "ClientDeviceMgr.Web.EnableSsl";
        //
        // Static member variables. These contain the application settings
        //   from Config.Web, or the default values.
        //
        private static String dbConnectionString;
        private static bool   enablePageCache;
        private static int    pageCacheExpiresInSeconds;
        private static bool   enableSsl;
        //
        // Constant values for all of the default settings.
        //
        private const bool   WEB_ENABLEPAGECACHE_DEFAULT           = true;
        private const int    WEB_PAGECACHEEXPIRESINSECONDS_DEFAULT = 3600;
        private const String DATAACCESS_CONNECTIONSTRING_DEFAULT   = "server=localhost; User ID=sa;pwd=Passw0rd;database=USAirways";
        private const bool   WEB_ENABLESSL_DEFAULT                 = false;
        
        /// <summary>
        ///     Called by ASP+ before the application starts to initialize
        ///     settings from the Config.Web file(s). 
        ///     <remarks>
        ///         The app domain will restart if these settings change, so 
        ///         there is no reason to read these values more than once. This 
        ///         function uses the NameValueSectionHandler base class to generate 
        ///         a hashtable from the XML, which is then used to store the current 
        ///         settings. Because all settings are read here, we do not actually 
        ///         store the generated hashtable object for later retrieval by
        ///         Context.GetConfig. The application should use the accessor
        ///         functions directly.
        ///     </remarks>
        ///     <param name="parent">
        ///         An object created by processing a section with this name
        ///         in a Config.Web file in a parent directory.
        ///     </param>
        ///     <param name="configContext">An array of Xml information.</param>
        ///     <param name="section">
        ///         The Path of the Config.Web file relative to the root
        ///         of the web server.
        ///     </param>
        ///     <returns>
        ///		    <para>
        ///             A ConfigOutput object, which we leave empty because all settings
        ///             are stored at this point.
        ///		    </para>
    	///	    </returns>
        /// </summary>
        public Object Create(Object parent, object configContext, XmlNode section)
        {
            
            NameValueCollection settings;
            
            try
            {
        		NameValueSectionHandler baseHandler = new NameValueSectionHandler();
                settings = (NameValueCollection)baseHandler.Create(parent, configContext, section);
            }
            catch
            {
                settings = null;
            }
            
            if ( settings == null )
            {
                dbConnectionString        = DATAACCESS_CONNECTIONSTRING_DEFAULT;
                pageCacheExpiresInSeconds = WEB_PAGECACHEEXPIRESINSECONDS_DEFAULT;
                enablePageCache           = WEB_ENABLEPAGECACHE_DEFAULT;
                enableSsl                 = WEB_ENABLESSL_DEFAULT;
            }
            else
            {
                dbConnectionString        = ApplicationConfiguration.ReadSetting(settings, DATAACCESS_CONNECTIONSTRING, DATAACCESS_CONNECTIONSTRING_DEFAULT);
                pageCacheExpiresInSeconds = ApplicationConfiguration.ReadSetting(settings, WEB_PAGECACHEEXPIRESINSECONDS, WEB_PAGECACHEEXPIRESINSECONDS_DEFAULT);
                enablePageCache           = ApplicationConfiguration.ReadSetting(settings, WEB_ENABLEPAGECACHE, WEB_ENABLEPAGECACHE_DEFAULT);
                enableSsl                 = ApplicationConfiguration.ReadSetting(settings, WEB_ENABLESSL, WEB_ENABLESSL_DEFAULT);
            }
            
            return settings;
        }
        
        /// <value>
        ///     Property EnablePageCache is used to get Duwamish's page cache setting. 
        ///     <remarks>Returns true if page caching is enabled, false otherwise.</remarks>
        /// </value>
        public static bool EnablePageCache
        {
            get
            {
                return enablePageCache;
            }
        }
        
        /// <value>
        ///     Property PageCacheExpiresInSeconds is used to get Duwamish's page cache expiration timeout setting.  
        ///     <remarks>The number of seconds before a page cache should expire.</remarks>
        /// </value>
        public static int PageCacheExpiresInSeconds
        {
            get
            {
                return pageCacheExpiresInSeconds;
            }
        }
        
        /// <value>
        ///     Property ConnectionString is used to get Duwamish's database connection string.
        ///     <remarks>The database connection string.</remarks>
        /// </value>
        public static String ConnectionString
        {
            get
            {
                return dbConnectionString;
            }
        }
    
        /// <value>
        ///     Property EnableSsl is used to get Duwamish's SSL setting. 
        ///     <remarks>True if SSL is enabled, false otherwise.</remarks>
        /// </value>
        public static bool EnableSsl
        {
            get
            {
                return enableSsl;
            }
        }
        
    } //class DuwamishConfiguration
    
} //namespace Duwamish7.Common
