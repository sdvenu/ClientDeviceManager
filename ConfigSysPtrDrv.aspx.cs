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
/*	File 		: ConfigSysPtrDrv.aspx.cs                                  */
/***************************************************************************/

/***************************************************************************/
/*																		   */
/*	Written By 	    : Kim Shu                                              */
/*	Organization	: EDS                        						   */
/*	Date Created	: Mar 22, 2005                                         */
/*                                                                         */
/***************************************************************************/

//***************************************************************************
//** Filename: 		                                                        *
//** $Workfile::                                                            $
//**									                                    *
/***************************************************************************/
/** Last Modified By:                                                       *
//** $Author::                                                              $
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
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for ConfigPtrFileDrv.
	/// </summary>
	/// This webpage provide Administrator interface to create/reconfig system printer
	/// setting in CDM database ProfileDB SysPtrDrvTable 
	/// WSName -- workstation name
	/// DeviceName -- Device name shoud be the same as route name
	/// Printer name -- system printer in operating system level
	/// margin of top, bottom, left, right
	/// Orientation = 1 --portrait, 0 -- landscape
	/// 
	public partial class ConfigSysPtrDrv : Web.PageBase
	{
		//Constants Definition
		private const string NEW_DEVICE = "NEW_DEVICE";
		private const string COLUMN_PRINTER_NAME = "PrinterName";
		private const string COLUMN_ORIENTATION = "Orientation";
		private const string COLUMN_MARGIN_TOP = "MarginTop";
		private const string COLUMN_MARGIN_BOTTOM = "MarginBottom";
		private const string COLUMN_MARGIN_LEFT = "MarginLeft";
		private const string COLUMN_MARGIN_RIGHT = "MarginRight";
		protected System.Web.UI.WebControls.RequiredFieldValidator rfdPrinterName;

		// initial variables for logging
		private string UserIP = "";
		private string HostName = "";
		private string WebForm = "ConfigSysPtrDrv";
		private int actcomplete = 1;
		
		private string actcmd = "";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// assign values, actcmd may vary..
			// UserIp pass user ip address to loagaudit()
			UserIP = Request.UserHostAddress;
			// HostName pass workstation name to logaudit()
			HostName = Request.UserHostName;

            // Check valid user login and role = ADMIN
            LoginIfNotAdmin();

			if( !Page.IsPostBack )
			{
				// Check for workstation has been selected, or sent to select workstation page
                SelectWorkstationIfNoneSelected();

                // driver should be SysPtr.dll for this option
				String selectedDriver = (String) Session[ConfigurePtr.SESSION_PRINT_DRIVER_SELECTED];
				String deviceName = (String) Session[ConfigurePtr.SESSION_PRINTER_DEVICE_NAME];
				if( selectedDriver == null || selectedDriver.Length == 0 )
				{
					Response.Redirect("ConfigurePtr.aspx");
				}
				// set defaults
				txbDeviceName.Text = deviceName;
				rbEnabled.Checked = true;
				labelHeader.Text = (String) Session[ConfigurePtr.SESSION_PRINT_DRIVER_SELECTED] + 
					" Configuration";
				txbSysPtr.Text= "";
				TextBoxMaxLogSize.Attributes["onKeyUp"]="LimitToNumeric(Form1.TextBoxMaxLogSize)";
				textBoxLogFileName.Text= ConfigurePtr.DEFAULT_LOG_FILE;
				TextBoxMaxLogSize.Text = ConfigurePtr.DEFAULT_MAX_LOG_SIZE;
				// only to retrieve existing device configuration
				if (!(bool)Session["New_Device"] )
					getSysPtrDrv();

                txbDeviceName.Focus();
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




		protected void rbEnabled_CheckedChanged(object sender, System.EventArgs e)
		{
			rbDisabled.Checked = false;
		}

		protected void rbDisabled_CheckedChanged(object sender, System.EventArgs e)
		{
			rbEnabled.Checked = false;
		}

		protected void rbDebugDisabled_CheckedChanged(object sender, System.EventArgs e)
		{
			ResetAllDebugRadioButtons();
			rbDebugDisabled.Checked = true;
		}

		protected void rbLogToFile_CheckedChanged(object sender, System.EventArgs e)
		{
			ResetAllDebugRadioButtons();
			rbLogToFile.Checked = true;
		}

		protected void rbDebugWindowEnabled_CheckedChanged(object sender, System.EventArgs e)
		{
			ResetAllDebugRadioButtons();
			rbDebugWindowEnabled.Checked = true;
		}

		protected void rbDebugFileAndWindowEnabled_CheckedChanged(object sender, System.EventArgs e)
		{
			ResetAllDebugRadioButtons();
			rbDebugFileAndWindowEnabled.Checked = true;
		}

		private void ResetAllDebugRadioButtons()
		{
			rbDebugDisabled.Checked = false;
			rbLogToFile.Checked = false;
			rbDebugWindowEnabled.Checked = false;
			rbDebugFileAndWindowEnabled.Checked = false;
		}

		/// <summary>
		/// This private method inserts SysPtrDrvTable data. The method creates connection,
		/// defines all the SqlParameter which needs to be inserted and calls SqlHelper
		/// to insert the data. Finally it will cleanup database connection. 
		/// Stored Procedure Name - dbo.InsertSysPtrDrv
		/// IN Parameter - WSName, DeviceName, Driver, Enabled, PrinterName,
		/// Font, Orientation, Margin Top, Bottom, Left, Right, FontSize, Bold, Italic
		/// DebugLevel, LogFile, MaxLogSize, FormFeed.
		/// </summary>
		/// <exception cref="SqlException">SqlException if cannot create connection or
		/// Sql error
		/// </exception>
		/// <returns>void</returns>
		private void insertSysPtr()
		{
			int debugLevel = 0;
			string configTable = "";
			string orientation ="1";
			string enabled = "1";
			int formFeed = 0;
			int insertLFAfterCR = 1;

			if(Session != null && Session[ConfigurePtr.COLUMN_CONFIG_TABLE] != null)
			{
				configTable = (String) Session[ConfigurePtr.COLUMN_CONFIG_TABLE];
			}

			if (rbEnabled.Checked)
			{
				enabled = "1";
			}
			if (rbDisabled.Checked)
			{
				enabled = "0";
			}

			if(!cbInsertLFAfterCR.Checked)
			{
				insertLFAfterCR = 0;
			}

			if( rbDebugDisabled.Checked == true )
			{
				debugLevel = 0;
			}
			else if ( rbLogToFile.Checked == true )
			{
				debugLevel = 1;
			}
			else if(rbDebugWindowEnabled.Checked == true )
			{
				debugLevel = 2;
			}
			else if ( rbDebugFileAndWindowEnabled.Checked == true)
			{
				debugLevel = 3;
			}

			if(cbFormFeed.Checked)
			{
				formFeed = 1;
			}
			if (rbPortrait.Checked)
			{
				orientation = "1";
			}
			else
			{
				orientation = "0";
			}
			
			//Create database
			Common.Database db = new Common.Database();
			//Get database connection
			SqlConnection sql = db.GetSqlConnectionUp();

			using (SqlTransaction trans = sql.BeginTransaction())
			{
				//Workstation name value
				SqlParameter wsNameParam = new SqlParameter("@WSName", SqlDbType.VarChar, 32);
				wsNameParam.Value = (string) Session["WSName"];

				//DeviceName
				SqlParameter deviceNameParam = new SqlParameter("@DeviceName", SqlDbType.VarChar, 32);
				deviceNameParam.Value = (string) Session[ConfigurePtr.SESSION_PRINTER_DEVICE_NAME];

				//Printer driver - SYSPTRDRV.DLL
				SqlParameter driverParam = new SqlParameter("@Driver", SqlDbType.VarChar, 20);
				driverParam.Value = (string)Session[ConfigurePtr.SESSION_PRINT_DRIVER_SELECTED].ToString().ToUpper();

				//If this configuration is enabled or disabled. If disabled, PtrCfgService will ignore
				//printer configuration.
				SqlParameter enabledParam = new SqlParameter("@Enabled", SqlDbType.SmallInt);
				enabledParam.Value = enabled;

				//Name of the Printer to print to.
				SqlParameter printerNameParam = new SqlParameter("@PrinterName", SqlDbType.VarChar, 60);
				printerNameParam.Value = txbSysPtr.Text.ToUpper();

				//Font cannot be configured, so default value is added
				SqlParameter fontParam = new SqlParameter("@Font", SqlDbType.VarChar, 60);
				//fontParam.Value = "";

				//Orientation - Portrait or Landscape
				SqlParameter orientationParam = new SqlParameter("@Orientation", SqlDbType.SmallInt);
				orientationParam.Value = orientation;

				//InsertLFAfterCR - Checked or Unchecked
				SqlParameter insertLFAfterCRParam = new SqlParameter("@InsertLFAfterCR", SqlDbType.SmallInt);
				insertLFAfterCRParam.Value = insertLFAfterCR;
				
				//Margin Top-Bottom-Left-Right
				SqlParameter marginTopParam = new SqlParameter("@MarginTop", SqlDbType.Decimal);
				if(txbMarginTop.Text != null && txbMarginTop.Text.Trim().Length > 0)
				{
					marginTopParam.Value = txbMarginTop.Text;
				}

				SqlParameter marginBottomParam = new SqlParameter("@MarginBottom", SqlDbType.Decimal);
				if(txbMarginBottom.Text != null && txbMarginBottom.Text.Trim().Length > 0)
				{
					marginBottomParam.Value = txbMarginBottom.Text;
				}

				SqlParameter marginLeftParam = new SqlParameter("@MarginLeft", SqlDbType.Decimal);
				if(txbMarginLeft.Text != null && txbMarginLeft.Text.Trim().Length > 0)
				{
					marginLeftParam.Value = txbMarginLeft.Text;
				}

				SqlParameter marginRightParam = new SqlParameter("@MarginRight", SqlDbType.Decimal);
				if(txbMarginRight.Text != null && txbMarginRight.Text.Trim().Length > 0)
				{
					marginRightParam.Value = txbMarginRight.Text;
				}

				//Font cannot be configured, so no value is set. But because the stored proc has it
				//will leave for future expansion. It is same for all commented values.
				SqlParameter fontSizeParam = new SqlParameter("@FontSize", SqlDbType.Int);
				//fontSizeParam.Value = "";

				//Font cannot be configured, so default value is added
				SqlParameter boldParam = new SqlParameter("@Bold", SqlDbType.SmallInt);
				//boldParam.Value = "";

				//Font cannot be configured, so default value is added
				SqlParameter italicParam = new SqlParameter("@Italic", SqlDbType.SmallInt);
				//italicParam.Value = "";

				//Debug Level 1 through 5 values.
				SqlParameter debugLevelParam = new SqlParameter("@DebugLevel", SqlDbType.SmallInt);
				debugLevelParam.Value = debugLevel;

				//Log file name along with location of file.
				SqlParameter logFileParam = new SqlParameter("@LogFile", SqlDbType.Text);
				logFileParam.Value = textBoxLogFileName.Text.Trim();
				
				//Maximum file size, after which it will create a new one.
				SqlParameter maxLogFileSizeParam = new SqlParameter("@MaxLogFileSize", SqlDbType.Int);
				maxLogFileSizeParam.Value = TextBoxMaxLogSize.Text.Trim();

				//Maximum file size, after which it will create a new one.
				SqlParameter formFeedParam = new SqlParameter("@FormFeed", SqlDbType.SmallInt);
				formFeedParam.Value = formFeed; //Change this when check box added

				try
				{
					//Call SqlHelper from Data Access library
					SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "insertSysPtrDrv", 
						wsNameParam, deviceNameParam, driverParam, enabledParam,printerNameParam, 
						fontParam, orientationParam, insertLFAfterCRParam, marginTopParam, marginBottomParam, 
						marginLeftParam, marginRightParam, fontSizeParam,boldParam, italicParam,
						debugLevelParam, logFileParam,maxLogFileSizeParam, formFeedParam);
					// this string will pass to logaudit() log as action taken
					actcmd += "insertSysPtrDrv " + wsNameParam.Value+deviceNameParam.Value + " " + printerNameParam.Value;
					trans.Commit();
					
				}
				catch(SqlException sqlExcep)
				{
					//If exception roll back transaction
					actcomplete =0;
					trans.Rollback();
					throw sqlExcep;
				}
				finally
				{
					//Close the connection.
					db.TearDownSqlConnections();
				}
			}
		}
 
		/// <summary>
		/// This private method updates SysPtrDrvTable data. The method creates connection,
		/// defines all the SqlParameter which needs to be updated and calls SqlHelper
		/// to update the data. Before the data is updated, the methods calls to retreive
		/// data for a given work station, if the data is there it will proceed further to
		/// update the data else will throw exception. Finally it will cleanup database
		/// connection. 
		/// Stored Procedure Name - dbo.UpdateSysPtrDrv
		/// IN Parameter - WSName, DeviceName, Driver, Enabled, PrinterName,
		/// Font, Orientation, Margin Top, Bottom, Left, Right, FontSize, Bold, Italic
		/// DebugLevel, LogFile, MaxLogSize.
		/// </summary>
		/// <exception cref="SqlException">SqlException if cannot create connection or
		/// Sql error
		/// </exception>
		/// <returns>void</returns>
		private void updateSysPtr()
		{
			int debugLevel = 0;
			string orientation ="1";
			int formFeed = 0;
			int insertLFAfterCR = 1;
			

			DataSet ds = new DataSet();
			Common.Database db = new Common.Database();
			SqlConnection sql = db.GetSqlConnectionUp();

			if( rbDebugDisabled.Checked == true )
			{
				debugLevel = 0;
			}
			else if ( rbLogToFile.Checked == true )
			{
				debugLevel = 1;
			}
			else if(rbDebugWindowEnabled.Checked == true )
			{
				debugLevel = 2;
			}
			else if ( rbDebugFileAndWindowEnabled.Checked == true)
			{
				debugLevel = 3;
			}
			if(cbFormFeed.Checked)
			{
				formFeed = 1;
			}
			if (rbPortrait.Checked)
			{
				orientation = "1";
			}
			else
			{
				orientation = "0";
			}

			if(!cbInsertLFAfterCR.Checked)
			{
				insertLFAfterCR = 0;
			}
				
			try
			{
				//Use Transaction to update, if the update fails Rollback changes.
				using (SqlTransaction trans = sql.BeginTransaction())
				{
					SqlParameter wsParam = new SqlParameter("@WSName", SqlDbType.VarChar,32);
					wsParam.Value = (string) Session["WSNAME"];

					//DeviceName
					SqlParameter deviceNameParam = new SqlParameter("@DeviceName", SqlDbType.VarChar, 32);
					deviceNameParam.Value = (string) Session[ConfigurePtr.SESSION_PRINTER_DEVICE_NAME];

					//Printer driver - SYSPTR.DLL
					SqlParameter driverParam = new SqlParameter("@Driver", SqlDbType.VarChar, 20);
					driverParam.Value = (string)Session[ConfigurePtr.SESSION_PRINT_DRIVER_SELECTED];

					//If this configuration is enabled or disabled. If disabled, PtrCfgService will ignore
					//printer configuration.
					SqlParameter enabledParam = new SqlParameter("@Enabled", SqlDbType.SmallInt);
					enabledParam.Value = Convert.ToInt16(rbEnabled.Checked);

					//Name of the Printer to print to.
					SqlParameter printerNameParam = new SqlParameter("@PrinterName", SqlDbType.VarChar, 60);
					printerNameParam.Value = txbSysPtr.Text.ToUpper();

					//Font cannot be configured, so no value is set. But because the stored proc has it
					//will leave for future expansion. It is same for all commented values.
					SqlParameter fontParam = new SqlParameter("@Font", SqlDbType.VarChar, 60);
					//fontParam.Value = "";

					//Orientation - Portrait or Landscape
					SqlParameter orientationParam = new SqlParameter("@Orientation", SqlDbType.SmallInt);
					orientationParam.Value = orientation;

					//InsertLFAfterCR - Checked or Unchecked
					SqlParameter insertLFAfterCRParam = new SqlParameter("@InsertLFAfterCR", SqlDbType.SmallInt);
					insertLFAfterCRParam.Value = insertLFAfterCR;

					//Margin Top-Bottom-Left-Right
					SqlParameter marginTopParam = new SqlParameter("@MarginTop", SqlDbType.Decimal);
					if(txbMarginTop.Text != null && txbMarginTop.Text.Trim().Length > 0)
					{
						marginTopParam.Value = txbMarginTop.Text;
					}

					SqlParameter marginBottomParam = new SqlParameter("@MarginBottom", SqlDbType.Decimal);
					if(txbMarginBottom.Text != null && txbMarginBottom.Text.Trim().Length > 0)
					{
						marginBottomParam.Value = txbMarginBottom.Text;
					}

					SqlParameter marginLeftParam = new SqlParameter("@MarginLeft", SqlDbType.Decimal);
					if(txbMarginLeft.Text != null && txbMarginLeft.Text.Trim().Length > 0)
					{
						marginLeftParam.Value = txbMarginLeft.Text;
					}

					SqlParameter marginRightParam = new SqlParameter("@MarginRight", SqlDbType.Decimal);
					if(txbMarginRight.Text != null && txbMarginRight.Text.Trim().Length > 0)
					{
						marginRightParam.Value = txbMarginRight.Text;
					}
					//Font cannot be configured, so default value is added
					SqlParameter fontSizeParam = new SqlParameter("@FontSize", SqlDbType.Int);
					//fontSizeParam.Value = "";

					//Font cannot be configured, so default value is added
					SqlParameter boldParam = new SqlParameter("@Bold", SqlDbType.SmallInt);
					//boldParam.Value = "";

					//Font cannot be configured, so default value is added
					SqlParameter italicParam = new SqlParameter("@Italic", SqlDbType.SmallInt);
					//italicParam.Value = "";

					//Debug Level 1 through 5 values.
					SqlParameter debugLevelParam = new SqlParameter("@DebugLevel", SqlDbType.SmallInt);
					debugLevelParam.Value = debugLevel;

					//Log file name along with location of file.
					SqlParameter logFileParam = new SqlParameter("@LogFile", SqlDbType.Text);
					logFileParam.Value = textBoxLogFileName.Text.Trim();
			
					//Maximum file size, after which it will create a new one.
					SqlParameter maxLogFileSizeParam = new SqlParameter("@MaxLogFileSize", SqlDbType.Int);
					maxLogFileSizeParam.Value = TextBoxMaxLogSize.Text.Trim();

					//Maximum file size, after which it will create a new one.
					SqlParameter formFeedParam = new SqlParameter("@FormFeed", SqlDbType.SmallInt);
					formFeedParam.Value = formFeed;

					//Call SqlHelper from Data Access library
					SqlHelper.ExecuteDataset(
						trans, "updateSysPtrDrv", wsParam, deviceNameParam,
						driverParam, enabledParam,printerNameParam, fontParam, 
						orientationParam, insertLFAfterCRParam, marginTopParam, 
						marginBottomParam, marginLeftParam, marginRightParam, 
						fontSizeParam,boldParam, italicParam,debugLevelParam, 
						logFileParam,maxLogFileSizeParam, formFeedParam);

					actcmd += "updateSysPtrDrv " + 
						wsParam.Value+deviceNameParam.Value+ " " + printerNameParam.Value;
					trans.Commit();
				}
			}
			catch(SqlException sqlExcep)
			{
				actcomplete = 0;
				throw sqlExcep;
			}
			finally
			{
				db.TearDownSqlConnections();
			}
		}

		/// <summary>
		/// this private method is called when save botton clicked
		/// is to collect user interfaced input and save into database by
		/// if new device insert new record calling insertSysPtr()
		/// or existing device update existing record calling updateSysPtr()
		/// then logAudit() is called to log above activity
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void buttonSave_Click(object sender, System.EventArgs e)
		{
			if(Session != null)
			{
				//check Device is new or not. 
				if(Session[NEW_DEVICE] != null)
				{
					if((bool)Session[NEW_DEVICE])
					{
						//New device is being added, call insertSysPtr() to add new
						//System Printer device information.
						insertSysPtr();
						// call logaudit() to log insert new device
						logAudit(actcmd,actcomplete);
					}
					else
					{
						//Existing Device will perform update call updateSysPtr()
						updateSysPtr();
						// call logaudit() to log update existing device
						logAudit(actcmd,actcomplete);
					}
				}
				else
				{
					//Call update method to update the data from screen.
					updateSysPtr();
					// call logaudit() to log update existing device
					logAudit(actcmd,actcomplete);
				}
				// when finish sent back to ConfigurePtr page
				Response.Redirect("ConfigurePtr.aspx");
			}
			else
				// session not valid, login is required
				Response.Redirect("Login.aspx");
				
		}

		/// <summary>
		/// This private method retrieves SysPtrDrvTable data for a given workstation and
		/// device name. The method creates connection,
		/// defines all the SqlParameter which needs to be retrieved and calls SqlHelper
		/// to retrieve the data. The method explicitly defined OUTPUT parameter as the
		/// stored procedures have been defined to take this parameters as OUTPUT.
		/// Procedure Name - dbo.SelectSysPtrDrv
		/// IN Param - WSName, DeviceName
		/// OUT Param -  Enabled, PrinterName, Font, Orientation,Margin Top,
		/// Bottom, Left, Right, FontSize, Bold, Italic, DebugLevel, LogFile, MaxLogSize.
		/// </summary>
		/// <exception cref="SqlException"> Connection exception or Sql error
		/// </exception>
		/// <returns>void</returns>
		private void getSysPtrDrv()
		{
			//Intantiate Database object
			Common.Database db = new Common.Database();

			if(Session != null)
			{
				try
				{
					DataSet ds = new DataSet();

					//Get database connection
					SqlConnection sql = db.GetSqlConnectionUp();

					//Set parameters. Set values for WSName and DeviceName to select the data
					//from table. All other params are going to be as Output, define the 
					//Direction as Output.
					SqlParameter wsParam = new SqlParameter("@WSName", SqlDbType.VarChar, 32);
					wsParam.Value = (string)Session["WSNAME"];;
					
					SqlParameter deviceNameParam = new SqlParameter("@DeviceName", SqlDbType.VarChar, 32);
					deviceNameParam.Value = (string) Session[ConfigurePtr.SESSION_PRINTER_DEVICE_NAME];

					//Printer driver - SYSPTR.DLL
					SqlParameter driverParam = new SqlParameter("@Driver", SqlDbType.VarChar, 20);
					driverParam.Direction = ParameterDirection.Output;

					//If this configuration is enabled or disabled. If disabled, PtrCfgService will ignore
					//printer configuration.
					SqlParameter enabledParam = new SqlParameter("@Enabled", SqlDbType.SmallInt);
					enabledParam.Direction = ParameterDirection.Output;

					//Name of the Printer to print to.
					SqlParameter printerNameParam = new SqlParameter("@PrinterName", SqlDbType.VarChar, 60);
					printerNameParam.Direction = ParameterDirection.Output;

					//Font cannot be configured, so default value is added
					SqlParameter fontParam = new SqlParameter("@Font", SqlDbType.VarChar, 60);
					fontParam.Direction = ParameterDirection.Output;

					//Orientation - Portrait or Landscape
					SqlParameter orientationParam = new SqlParameter("@Orientation", SqlDbType.SmallInt);
					orientationParam.Direction = ParameterDirection.Output;

					//InsertLFAfterCR - Checked or Unchecked
					SqlParameter insertLFAfterCRParam = new SqlParameter("@InsertLFAfterCR", SqlDbType.SmallInt);
					insertLFAfterCRParam.Direction = ParameterDirection.Output;
					

					//Margin Top-Bottom-Left-Right
					//This are OUT Parameter with Precision 10 and Scale of 2.
					SqlParameter marginTopParam = new SqlParameter("@MarginTop", SqlDbType.Decimal);
					marginTopParam.Direction = ParameterDirection.Output;
					marginTopParam.Precision = 10;
					marginTopParam.Scale = 2;

					SqlParameter marginBottomParam = new SqlParameter("@MarginBottom", SqlDbType.Decimal);
					marginBottomParam.Direction = ParameterDirection.Output;
					marginBottomParam.Precision = 10;
					marginBottomParam.Scale = 2;

					SqlParameter marginLeftParam = new SqlParameter("@MarginLeft", SqlDbType.Decimal);
					marginLeftParam.Direction = ParameterDirection.Output;
					marginLeftParam.Precision = 10;
					marginLeftParam.Scale = 2;

					SqlParameter marginRightParam = new SqlParameter("@MarginRight", SqlDbType.Decimal);
					marginRightParam.Direction = ParameterDirection.Output;
					marginRightParam.Precision = 10;
					marginRightParam.Scale = 2;

					//Font cannot be configured, so default value is added
					SqlParameter fontSizeParam = new SqlParameter("@FontSize", SqlDbType.Int);
					fontSizeParam.Direction = ParameterDirection.Output;

					//Font cannot be configured, so default value is added
					SqlParameter boldParam = new SqlParameter("@Bold", SqlDbType.SmallInt);
					boldParam.Direction = ParameterDirection.Output;

					//Font cannot be configured, so default value is added
					SqlParameter italicParam = new SqlParameter("@Italic", SqlDbType.SmallInt);
					italicParam.Direction = ParameterDirection.Output;

					//Debug Level 1 through 5 values.
					SqlParameter debugLevelParam = new SqlParameter("@DebugLevel", SqlDbType.SmallInt);
					debugLevelParam.Direction = ParameterDirection.Output;

					//Log file name along with location of file.
					SqlParameter logFileParam = new SqlParameter("@LogFile", SqlDbType.VarChar,256);
					logFileParam.Direction = ParameterDirection.Output;
					
					//Maximum file size, after which it will create a new one.
					SqlParameter maxLogFileSizeParam = new SqlParameter("@MaxLogFileSize", SqlDbType.Int);
					maxLogFileSizeParam.Direction = ParameterDirection.Output;

					//Maximum file size, after which it will create a new one.
					SqlParameter formFeedParam = new SqlParameter("@FormFeed", SqlDbType.SmallInt);
					formFeedParam.Direction = ParameterDirection.Output;

					//Call SQLHelper to run select query.
					SqlHelper.FillDataset(sql, CommandType.StoredProcedure, "SelectSysPtrDrv", ds, new string[] {"SysPtrDrvTable"}, 
						wsParam, deviceNameParam, driverParam,  enabledParam,
						printerNameParam, fontParam, orientationParam, 
						insertLFAfterCRParam, marginTopParam, 
						marginBottomParam, marginLeftParam, marginRightParam,
						fontSizeParam, boldParam, italicParam,debugLevelParam, 
						logFileParam,maxLogFileSizeParam, formFeedParam);

					//Retrieve data from each param and set in approriate controls.
					string WSName = (string)wsParam.Value;
					txbDeviceName.Text = (string)deviceNameParam.Value;
					string Driver = (string)driverParam.Value;
					int enabled = Convert.ToInt16(enabledParam.Value);
					int debugLevel = Convert.ToInt16(debugLevelParam.Value);
					string driver = (string)driverParam.Value;
					txbSysPtr.Text = (string)printerNameParam.Value;
					int orientation = Convert.ToInt16(orientationParam.Value);
					int insertLFAfterCR = Convert.ToInt16(insertLFAfterCRParam.Value);
					
					if(marginTopParam.Value != null)
					{
						txbMarginTop.Text = Convert.ToString(marginTopParam.Value);
					}
					if(marginBottomParam.Value != null)
					{
						txbMarginBottom.Text = Convert.ToString(marginBottomParam.Value);
					}
					if(marginLeftParam.Value != null)
					{
						txbMarginLeft.Text = Convert.ToString(marginLeftParam.Value);
					}
					if(marginRightParam.Value != null)
					{
						txbMarginRight.Text = Convert.ToString(marginRightParam.Value);
					}
					
					int formFeed = Convert.ToInt16(formFeedParam.Value);
					if(formFeed == 1)
					{
						cbFormFeed.Checked = true;
					}
					else
					{
						cbFormFeed.Checked = false;
					}

					if(insertLFAfterCR == 1)
					{
						cbInsertLFAfterCR.Checked = true;
					}
					else
					{
						cbInsertLFAfterCR.Checked = false;
					}
					textBoxLogFileName.Text = (string) logFileParam.Value;
					TextBoxMaxLogSize.Text = Convert.ToString(maxLogFileSizeParam.Value);
					ResetAllDebugRadioButtons();
					switch( debugLevel )
					{
						case 0 :
							rbDebugDisabled.Checked = true;
							break;
						case 1 :
							rbLogToFile.Checked = true;
							break;
						case 2 :
							rbDebugWindowEnabled.Checked = true;
							break;
						case 3 :
							rbDebugFileAndWindowEnabled.Checked = true;
							break;
					}
					rbEnabled.Checked = (enabled == 1);
					rbDisabled.Checked = (enabled ==0);
					rbPortrait.Checked = (orientation == 1);
					rbLandscape.Checked = (orientation == 0 );
				}
				catch(SqlException sqlExcep)
				{
					throw sqlExcep;
				}
				finally
				{
					db.TearDownSqlConnections();
				}
			}
		}

		
		/// <summary>
		/// this private function is called to insert log into audit table, 
		/// where UserID can be WSName or UserID(which is created or deleted)
		/// UserName is current login userID in Session["UsrName"]
		/// action log for future auditing
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="complete"></param>
		private void logAudit(string cmd, int complete)
		{
			Common.Database db = new Common.Database();

			string logcmd = "INSERT INTO AuditLogtbl(UserName,UserID,commandStr,WebForm," +
				"UserIP,HostName,Completion) VALUES('" + (string)Session["UsrName"] +"','" +
				(string)Session["WSName"] +"','" + cmd + "','" + WebForm + "','" + UserIP + 
				"','" + HostName +	"','" + complete +"')";
			// call MyUpdateDataExecuteNonQuery() to insert log  record
			int k = db.MyUpdateDataExecuteNonQuery(logcmd);
			// clean up
			db.Dispose();
			return;
		}
	}
}
