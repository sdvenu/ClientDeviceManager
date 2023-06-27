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

using System;
using System.Web;
using System.Web.UI;
using System.ComponentModel;
using System.Data;

using ClientDeviceMgr.Common;
//using Duwamish7.Common.Data;
using ClientDeviceMgr.SystemFramework;

namespace ClientDeviceMgr.Web
{

    /// <summary>
    ///     The code-behind base class for all user control modules.
    ///     <remarks>
    ///         This class derives off of UserControl. 
    ///     </remarks>
    /// </summary>
    public class ModuleBase : UserControl
    {
        //
        // Exception Logging constant
        //
        //private const String UNHANDLED_EXCEPTION = "Unhandled Exception:";
        //
        // Session Key Constants
        //
        //private const String KEY_CACHECART = "Cache:ShoppingCart:";
        //private const String KEY_CACHECUSTOMER = "Cache:Customer:";
    
        //private String basePathPrefix;

        /// <value>
        ///     Property PathPrefix is used to get or set the file path prefix to be used by the control.
        ///     <remarks> 
        ///         Sets the value PathPrefix. 
        ///         Gets the value PathPrefix. 
        ///     </remarks>
        /// </value>
        //[Browsable(false)]		
        //public String PathPrefix
        //{
        //    get
        //    {
        //        if (null == basePathPrefix && HttpContext.Current != null)
        //        {
        //            basePathPrefix = PageBase.UrlBase;
        //        }
            
        //        return basePathPrefix;
        //    }
        //    set
        //    {
        //        basePathPrefix = value;
        //    }
        //}
        
        /// <value>
        ///     Property Customer is used to get or set the data for the logged on customer.
        ///     <remarks> 
        ///         Sets the value Customer. 
        ///         Gets the value Customer. 
        ///     </remarks>
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
        ///     Retrieves the Cart for the session, forcing it to be created
        ///     if it does not already exist.
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
        
            if (forceCreate) returnValue.EnsureWritable();
            
            return returnValue;
        }
		*/
    }
}