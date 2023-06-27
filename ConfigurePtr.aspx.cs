/*-------------------------------------------------------------------------*/
/*            COPYRIGHT NOTICE - SOFTWARE                                  */   
/*                                                                         */
/* 			  Copyright 2005 EDS,                                          */
/*                                                                         */
/* This software is the confidential and proprietary intellectual	       */
/* property of EDS.  Any unauthorized use, reproduction, preparation of	   */
/* derivative works, performance, or display of this software without the  */
/* express written permission of EDS is strictly prohibited.		       */
/* This software is an unpublished work of EDS and is subject to	       */
/* 		LIMITED DISTRIBUTION AND RESTRICTED DISCLOSURE only.               */
/* 			  ALL RIGHTS RESERVED.                                         */
/*-------------------------------------------------------------------------*/
/***************************************************************************/
/*	File 		: ConfigurePtr.aspx.cs                                     */
/***************************************************************************/

/***************************************************************************/
/*																		   */
/*	Written By 	    : Kevin Tucker                                         */
/*	Organization	: EDS                        						   */
/*	Date Created	:                                                      */
/*                                                                         */
/***************************************************************************/

//***************************************************************************
//** Filename: 		                                                        *
//** $Workfile::                                                            $
//**									                                    *
/***************************************************************************/
/** Last Modified By:                                                       *
//** $Author:: Kim Shu                                                      $
//**                                                                        *
//** Last Check in Date of this module:                                     *
//** $Date::                                                                $
//**                                                                        *
//** Current Version:                                                       *
//** $Revision::                                                            $
//**                                                                        *
//***************************************************************************
//** Revision History Information:                                          *
//** $History::                                                             $
//**
//**                                                                        *
//***************************************************************************
///////////////////////////////////////////////////////////////////////////*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for ConfigPtr.
	/// this page is called from ADMIN's menu PrinterConfiguration
	/// if no worksatioon selected, will redirect WSSelect page
	/// will display a list of printer driver for select
	/// then Admin either input a new device name (must be the same of a route name) 
	/// or select an existing device 
	/// when Next button clicked, depend on driver choosen will open different configuration page for 
	/// that specific driver
	/// allone with WSName and DeviceName and/or a Session["New_Device"] to indicate new device or not
	/// this class also define a group of constants for related classes to use
	/// </summary>
	public partial class ConfigurePtr : Web.PageBase
	{
		//		public const String PRINTER_DRIVERS = "PRINTER_DRIVERS";
		public const String SESSION_PRINT_DRIVER_SELECTED = "PRINT_DRIVER_SELECTED";
		public const string SESSION_PRINTER_DEVICE_NAME = "PRINTER_DEVICE_NAME";
		private const string NEW_DEVICE = "New Device";
		public const string SESSION_DRIVER_LIST = "DRIVER_LIST";
		public const string TABLE_PRINT_DRIVER_LIST = "PrintDriverList";
		public const string SESSION_CONFIG_TABLE = "CONFIG_TABLE";
		public const string SESSION_DEBUG_LEVEL = "DEBUG_LEVEL";
		public const string SESSION_LOG_FILE_NAME = "LOG_FILE";
		public const string SESSION_MAX_FILE_SIZE = "MAX_FILE_SIZE";
		public const string COLUMN_WSNAME = "WSNAME";
		public const string COLUMN_ENABLED="ENABLED";
		public const string COLUMN_DEBUG_LEVEL = "DEBUGLEVEL";
		public const string COLUMN_MAX_FILE_SIZE = "MAXLOGFILESIZE";
		public const string COLUMN_DRIVER = "DRIVER";
		public const string COLUMN_IO_DRIVER= "IODRIVER";
		public const string COLUMN_PORT= "PORT";
		public const string COLUMN_BAUD_RATE ="BAUDRATE";
		public const string COLUMN_DATABITS ="DATABITS";
		public const string COLUMN_PARITY ="PARITY";
		public const string COLUMN_STOP_BITS ="STOPBITS";
		public const string COLUMN_FLOW_CONTROL ="FLOWCONTROL";
		public const string COLUMN_INSERT_LF= "INSERTLFAFTERCR";
		public const string COLUMN_NUM_OF_FF	= "NUMFORMFEEDS";
		public const string COLUMN_DEVICENAME= "DEVICENAME";
		public const string COLUMN_HOST_ANSWERBACK = "HOSTANSWERBACK";
		private const string COLUMN_CONFIG_PAGE= "CONFIG_PAGE";
		public const string  COLUMN_CONFIG_TABLE = "CONFIG_TABLE";
		public const string COLUMN_LOG_FILE_NAME = "LOGFILE";
		public const string DEFAULT_IO_DRIVER = "PORTS.DLL";
		public const bool DEFAULT_ENABLE = true;
		public const string DEFAULT_FORM_FEED = "0";
		public const int INSERT_LF_AFTER_CR = 1;
		public const int DEFAULT_DRIVER_INDEX = 0;
		public const string DEFAULT_LOG_FILE = Global.ConfigurationFolder + "HSSP.LOG";
		public const string DEFAULT_MAX_LOG_SIZE = "100000";
		public const int DEFAULT_DEBUG_LEVEL = 0;
		public const string DEVICE_LIST = "DEVICE_LIST";


		// initial variables for logging
		private string UserIP ="";
		private string HostName = "";
		private string WebForm = "ConfigurePtr";
		private int actcomplete = 1;
		private string actcmd ="";
		//Contains list of devices
		private ArrayList deviceList = new ArrayList(); 

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			// verify login userID and role = ADMIN
			// if not redirect back to login page.

            // Check valid user login and role = ADMIN
            LoginIfNotAdmin();
            SelectWorkstationIfNoneSelected();

            // this script is to convert input letter to upper case
			String []myScript = 
			{
				"<script language=\"JavaScript\">",
				"function DoKeyUp()",
				"{",
				"	var len = 0;",
				"	len=Form1.TextBoxDeviecName.value.length;",
				"	if( len > 0 ) ",
				"	{ ",
				"		Form1.buttonNext.disabled = false;",
				"		Form1.TextBoxDeviecName.value = Form1.TextBoxDeviecName.value.toUpperCase();",
				"	} ",
				"	else",
				"	{ ",
				"		Form1.buttonNext.disabled = true;",
				"	} ",
				"}",
				"</script>"
			};
			String scriptString="";
			for( int i = 0; i < myScript.Length; i++ )
			{
				scriptString += myScript[i];
				scriptString += "\n";
			}
			if(!this.ClientScript.IsClientScriptBlockRegistered("clientScript"))
				this.ClientScript.RegisterClientScriptBlock(this.GetType(), "clientScript", scriptString);
			TextBoxDeviecName.Attributes["onKeyUp"]="DoKeyUp()";
			// assign values, actcmd may vary..
			UserIP = Request.UserHostAddress;
			HostName = Request.UserHostName;

			if( Page.IsPostBack == false )
			{
				// call updateSysPtr method
				LoadPrinterDriverList();
				// populate printer driver list
				PopulateDriverList();

                ddlDrivers.Focus();
			}
		}
		/// <summary>
		/// this private method is call to load printer driver into dataset 
		/// and stored as an application variable Application[SESSION_DRIVER_LIST]
		/// driver list from table TABLE_PRINT_DRIVER_LIST which is PrintDriverList
		/// </summary>
		private void LoadPrinterDriverList()
		{
			try
			{
				DataSet ds = (DataSet) Application[SESSION_DRIVER_LIST];
				if( ds == null )
				{
					String szCmd = "SELECT * FROM " + TABLE_PRINT_DRIVER_LIST;
					Common.Database db = new ClientDeviceMgr.Common.Database();
					ds = db.MyFillDataSet(szCmd,TABLE_PRINT_DRIVER_LIST);
                    db.Dispose();

					Application.Lock();
					Application[SESSION_DRIVER_LIST] = ds;
					Application.UnLock();
				}
			}
			catch
			{
			}
		}
		/// <summary>
		/// this private method is called to populate printer driver drop down list ddlDrivers
		/// </summary>
		private void PopulateDriverList()
		{
			try
			{
				if( Application[SESSION_DRIVER_LIST] == null )
				{
					LoadPrinterDriverList();
				}
				DataSet ds = (DataSet) Application[SESSION_DRIVER_LIST];
				int totalRow = ds.Tables[0].Rows.Count;
				foreach( DataRow row in ds.Tables[0].Rows)
				{
					ddlDrivers.Items.Add(row[COLUMN_DRIVER].ToString().Trim());
				}
				ddlDrivers_SelectedIndexChanged(null,null);
			}
			catch
			{
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void TextBoxDeviecName_TextChanged(object sender, System.EventArgs e)
		{
			if( TextBoxDeviecName.Text.Length > 0 )
			{
				buttonNext.Enabled = true;
			}
			else
			{
				buttonNext.Enabled = false;
			}
		}
		/// <summary>
		///  this method is called when Next botton clicked
		///  will redirect to next configuration page depend on the driver selected 
		///  which are pre-defined in DB profileDB/PrinterDriverList
		///  each driver point to its own table for configuration data record
		///  and a configuration page for role Admin 
		///  or a display page for role User 
		///  example FileDrv.dll/FileDrvTable/ConfigPtrFileDrv.aspx/DisplayPtrFile.aspx           
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void buttonNext_Click(object sender, System.EventArgs e)
		{
			
			String wsName = (String) Session["WSName"];
			if( wsName == null || wsName.Length == 0 )
			{
				Response.Redirect("WSSelect.aspx");
			}
			Session[SESSION_PRINT_DRIVER_SELECTED] = ddlDrivers.SelectedItem.Text;
			Session[SESSION_PRINTER_DEVICE_NAME] = TextBoxDeviecName.Text.Trim().ToUpper();
			deviceList = (ArrayList)Session[DEVICE_LIST];
			if(!deviceList.Contains((string)TextBoxDeviecName.Text.Trim().ToUpper()))
			{
				Session["New_Device"]=true;
			}
			else
			{
				Session["New_Device"]=false;
			}
			string driver = ddlDrivers.SelectedItem.Text;
			string driverSelected = ddlDrivers.SelectedItem.Text;
			// printer driver list is in Application[SESSION_DRIVER_LIST]
			DataSet ds = (DataSet) Application[SESSION_DRIVER_LIST];
			string configPage = "";
			// to decide next configuration page 
			foreach( DataRow row in ds.Tables[0].Rows)
			{
				string currentDriver = row[COLUMN_DRIVER].ToString().Trim();
				if( currentDriver == driverSelected )
				{
					configPage = row[COLUMN_CONFIG_PAGE].ToString().Trim();
					break;
				}
			}
			if( configPage.Length > 0 )
			{
				// call next configuration page with 
				// workstation name is in Session["WSName"]
				// device name is in Session[SESSION_PRINTER_DEVICE_NAME]
				Response.Redirect(configPage);
			}
		}
		/// <summary>
		/// this private method is called when select item changed in device name drop down list ddlDeviceName
		/// is to enable or disable Next button and Delete button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ddlDeviceNames_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			String deviceNameSelected = ddlDeviceNames.SelectedItem.Text;
			if( deviceNameSelected == NEW_DEVICE )
			{
				Session["New_Device"] = true;
				TextBoxDeviecName.Text = "";
				TextBoxDeviecName.Enabled = true;
				buttonNext.Enabled = false;
				buttonDelete.Enabled = false;
			}
			else
			{
				Session["New_Device"] = false;
				TextBoxDeviecName.Text = deviceNameSelected;
				TextBoxDeviecName.Enabled = false;
				buttonNext.Enabled = true;
				buttonDelete.Enabled = true;
			}
			labelStatus.Visible = false;
		}

		/// <summary>
		/// This private method is called when select item changed in printer driver drop down list ddlDrivers
		/// is to repopulate device name drop down list ddlDeviceName to reflect selected driver
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ddlDrivers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				TextBoxDeviecName.Text = "";
				ddlDeviceNames.Items.Clear();
				ddlDeviceNames.Items.Add(NEW_DEVICE);
				String driverSelected = ddlDrivers.SelectedItem.Text;
				try
				{
					DataSet ds = (DataSet) Application[SESSION_DRIVER_LIST];
					foreach( DataRow row in ds.Tables[0].Rows)
					{
						String currentDriver = row[COLUMN_DRIVER].ToString().Trim();
						if( currentDriver == driverSelected )
						{
							String configTable = (String)row[COLUMN_CONFIG_TABLE];
							Session[SESSION_CONFIG_TABLE] = configTable;
							if( configTable != null && configTable.Length > 0 )
							{
								String wsName = (String) Session["WSName"];
								if( wsName == null || wsName.Length == 0 )
								{
									Response.Redirect("WSSelect.aspx");
								}
								String cmdSelectExistingDevices =
                                    "SELECT " + COLUMN_DEVICENAME + " FROM "
                                    + configTable +
                                    " WHERE " + COLUMN_WSNAME + " = '" + wsName + "'";
								Common.Database db = new ClientDeviceMgr.Common.Database();
								DataSet dsDevices = db.MyFillDataSet(cmdSelectExistingDevices,configTable);
                                db.Dispose();
                                deviceList.Clear();
                                if (null == dsDevices)
                                    return;
								foreach( DataRow deviceRow in dsDevices.Tables[0].Rows )
								{
									deviceList.Add((string)deviceRow[COLUMN_DEVICENAME].ToString().Trim());
									ddlDeviceNames.Items.Add(deviceRow[COLUMN_DEVICENAME].ToString().Trim());
								}
								
								Session[DEVICE_LIST] = deviceList;
							}
							break;
						}
					}
				}
				catch
				{
				}
				ddlDeviceNames_SelectedIndexChanged(null,null);
			}
			catch
			{
			}
		}
		/// <summary>
		/// this private method is called when delete button clicked
		/// is to provide delete device from database function
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void buttonDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				String deviceName = TextBoxDeviecName.Text.Trim();
				String configTable = (String)Session[SESSION_CONFIG_TABLE];
				String wsName = (String) Session["WSName"];
				String deleteDevice = ("DELETE FROM "+ configTable + " WHERE " + COLUMN_DEVICENAME + " = '" 
					+ deviceName + "' AND " + COLUMN_WSNAME+" = '" + wsName + "'" );
				actcmd = "";
				for(int k=0;k<deleteDevice.Length;k++)
				{
					if (deleteDevice[k] != '\'')
						actcmd += deleteDevice[k];
				}
				Common.Database database = new ClientDeviceMgr.Common.Database();
				database.MyUpdateDataExecuteNonQuery(deleteDevice);
				ddlDrivers_SelectedIndexChanged(null,null);
				labelStatus.Visible = true;
				labelStatus.Text = "Deleted device : " + deviceName;
			}
			catch(Exception ex)
			{
				labelStatus.Text = "Exception : "  + ex.Message;
				labelStatus.Visible = true;
				actcomplete = 0;
			}
			logAudit(actcmd,actcomplete);
		}
		/// <summary>
		/// function insert log into audit table, 
		/// where UserID can be WSName or UserID(which is created or deleted)
		/// UserName is current login userID in Session["UsrName"]
		/// action log for future auditing
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="Complete"></param>
		private void logAudit(string cmd, int complete)
		{
			Common.Database db = new Common.Database();
			string logcmd = "INSERT INTO AuditLogtbl(UserName,UserID,commandStr,WebForm," +
				"UserIP,HostName,Completion) VALUES('" + (string)Session["UsrName"] +"','" +
				(string)Session["WSName"] +"','" + cmd + "','" +WebForm + "','" + UserIP + 
				"','" + HostName +	"','" + complete +"')";
			int k = db.MyUpdateDataExecuteNonQuery(logcmd);
			db.Dispose();
			return;
		}
	}
}
