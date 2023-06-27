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

namespace ClientDeviceMgr.Web
{
    using System;
    using System.Web;
    using System.Web.UI;
    using System.ComponentModel;
    using System.Data;
    
    using ClientDeviceMgr.Common;
    using ClientDeviceMgr.SystemFramework;
    using System.Diagnostics;

    /// <summary>
    ///     The code-behind base class for all pages.
    ///     <remarks>
    ///         This class derives off of System.Web.UI.Page.
    ///     </remarks>
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            PageStateManagement();
        }

        //
        // Exception Logging constant
        //
        private const String UNHANDLED_EXCEPTION = "Unhandled Exception:";

        //
        // Session Key Constants
        //
        //private const String KEY_CACHECART = "Cache:ShoppingCart:";
        //private const String KEY_CACHECUSTOMER = "Cache:Customer:";

        public string LoginIfNotAdmin()
        {
            return LoginIfNotOfGroup("ADMIN");
        }

        public string LoginIfNotSupervisor()
        {
            return LoginIfNotOfGroup("SUPER");
        }

        public string LoginIfNotLoggedIn()
        {
            return LoginIfNotOfGroup(null);
        }

        /// <summary>
        /// Redirect to login if not logged in or not in the correct group.
        /// </summary>
        /// <param name="RequiredGroup">the required group or null</param>
        /// <returns>the group</returns>
        public string LoginIfNotOfGroup(string RequiredGroup)
        {
            string UserID = (string)Session["usrName"];
            string Group = (string)Session["Group"];

            // The client must be logged in (i.e. have a user id and group)
            // and the group must match (or be any group).
            if (string.IsNullOrEmpty(UserID) ||
                string.IsNullOrEmpty(Group) ||
                (RequiredGroup != null && Group != RequiredGroup))
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx", true);
                // The system will not return to this page.
            }

            return Group;
        }

        /// <summary>
        /// Remove Session State Data (stored in Session["name"]) that relates to
        /// one web page after the user navigates off of the web page.
        /// </summary>
        protected void PageStateManagement()
        {
            string currentPage = PageDataNamePrefix;
            object data = Session["Session:PageData"];
            string previousPage = (null == data) ? "{none}" : data.ToString();

            if (!currentPage.Equals(previousPage))
            {
                Debug.WriteLine("Page: changed from " + previousPage + " to " + currentPage);
                Session["Session:PageData"] = currentPage;

                if (!string.IsNullOrEmpty(previousPage))
                    for (int i = Session.Keys.Count - 1; 0 <= i; i--)
                        if (Session.Keys[i].StartsWith(previousPage))
                        {
                            Debug.WriteLine("  remove " + Session.Keys[i]);
                            Session.RemoveAt(i);
                        }
            }
        }

        /// <summary>
        /// Get or set page lifetime data. The data remains until the web application
        /// page changes to another page.
        /// </summary>
        /// <param name="aName">the name of the data.</param>
        /// <returns>the data.</returns>
        protected object this[string aName]
        {
            get { return Session[PageDataNamePrefix + aName]; }
            set { Session[PageDataNamePrefix + aName] = value; }
        }

        private string PageDataNamePrefix
        {
            get { return "PageData:" + this.GetType().ToString() + ":"; }
        }

        /// <summary>
        /// Redirect to select a workstation if the user has not yet selected one.
        /// </summary>
        /// <returns>the workstation name</returns>
        public string SelectWorkstationIfNoneSelected()
        {
            string WSName = (string)Session["WSName"];

            if (string.IsNullOrEmpty(WSName))
            {
                Response.Redirect("WSSelect.aspx", true);
                // The system will not return to this page.
            }

            return WSName;
        }

        /// <value>
        /// UrlSuffix is used to get the base URL for this application's web pages.
        /// </value>
        private static string UrlSuffix
        {
	        get
	        {
                // User Url.Authority instead of Url.Host to get the port reference.
		        return HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath;
//??            return HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath;
	        }
        }

        /// <value>
        /// SecureUrlBase is used to get the prefix for URLs in the Secure directory.
        /// </value>
	    public static String SecureUrlBase
	    {
		    get
		    {
			    return (ClientDeviceMgrConfiguration.EnableSsl ? @"https://": @"http://") + UrlSuffix;
		    }
	    }

        /// <value>
        /// UrlBase is used to get the prefix for URLs.
        /// </value>
	    public static String UrlBase
	    {
		    get
		    {
			    return @"http://" + UrlSuffix; 
		    }
	    }

        /// <value>
        /// Customer is used to get or set the data for the logged on customer.
        /// </value>
        //public DataSet Customer
        //{
        //    get
        //    {
        //        try
        //        {
        //            return (DataSet)(Session[KEY_CACHECUSTOMER]);
        //        }
        //        catch
        //        {
        //            return (null);  // for design time
        //        }
        //    }
        //    set
        //    {
        //        if ( null == value )
        //        {
        //            Session.Remove(KEY_CACHECUSTOMER);
        //        }
        //        else
        //        {
        //            Session[KEY_CACHECUSTOMER] = value;
        //        }
        //    }
        //}
        
        /// <summary>
        /// Retrieves the Cart for the session, forcing it to be created
        /// if it does not already exist.
        /// </summary>
        /*
		public Cart ShoppingCart()
        {
            return ShoppingCart(true);
        }
        
        
        /// <summary>
        ///     Retrieves the Cart for the session, optionally forcing it to
        ///     be created if it does not already exist.
        ///     <param name="forceCreate">Create the shopping cart if it does not exist.</param>
        /// </summary>
        public Cart ShoppingCart(bool forceCreate)
        {
            //
            // Try to get the cart from the Session
            //
            Cart returnValue = (Cart)(Session[KEY_CACHECART]);
        
            if (null == returnValue)
            {
                //
                // If there is no cart, create it now
                //
                returnValue = new Cart();
        
                //
                // Save it for later
                //
                Session.Add(KEY_CACHECART, returnValue);
            }
        
            if ( forceCreate ) returnValue.EnsureWritable();
            
            return returnValue;
        }
		*/
        
        /// <summary>
        /// Handles errors that may be encountered when displaying this page.
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// </summary>
        protected override void OnError(EventArgs e) 
        {
            ApplicationLog.WriteError(
                ApplicationLog.FormatException(
                    Server.GetLastError(),
                    UNHANDLED_EXCEPTION));
            base.OnError(e);
        }
    }
}
