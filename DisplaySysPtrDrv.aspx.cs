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
	/// This webpage provide User interface to review only system printer
	/// setting in CDM database ProfileDB SysPtrDrvTable 
	/// WSName -- workstation name
	/// DeviceName -- Device name shoud be the same as route name
	/// Printer name -- system printer in operating system level
	/// margin of top, bottom, left, right
	/// Orientation = 1 --portrait, 0 -- landscape
	/// 
	public partial class DisplaySysPtrDrv : Web.PageBase
	{
		private const String NEW_DEVICE = "NEW_DEVICE";
		private const String COLUMN_PRINTER_NAME = "PrinterName";
		private const String COLUMN_ORIENTATION = "Orientation";
		private const String COLUMN_MARGIN_TOP = "MarginTop";
		private const String COLUMN_MARGIN_BOTTOM = "MarginBottom";
		private const String COLUMN_MARGIN_LEFT = "MarginLeft";
		private const String COLUMN_MARGIN_RIGHT = "MarginRight";

		// initial variables for logging
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            LoginIfNotLoggedIn();

            if( !Page.IsPostBack )
			{
				// Check for workstation has been selected, or send to select workstation page
                String wsName = SelectWorkstationIfNoneSelected();

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
				labelHeader.Text = (String) Session[ConfigurePtr.SESSION_PRINT_DRIVER_SELECTED] + " Configuration";
				txbSysPtr.Text= "";
				TextBoxMaxLogSize.Attributes["onKeyUp"]="LimitToNumeric(Form1.TextBoxMaxLogSize)";
				textBoxLogFileName.Text= ConfigurePtr.DEFAULT_LOG_FILE;
				TextBoxMaxLogSize.Text = ConfigurePtr.DEFAULT_MAX_LOG_SIZE;

				if (!(bool)Session["New_Device"] )
					getSysPtrDrv();
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

					//Form feed check box value.
					SqlParameter formFeedParam = new SqlParameter("@FormFeed", SqlDbType.SmallInt);
					formFeedParam.Direction = ParameterDirection.Output;

					//InsertLFAfterCR - Checked or Unchecked
					SqlParameter insertLFAfterCRParam = new SqlParameter("@InsertLFAfterCR", SqlDbType.SmallInt);
					insertLFAfterCRParam.Direction = ParameterDirection.Output;

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
					
					txbMarginTop.Text = Convert.ToString(marginTopParam.Value);
					txbMarginBottom.Text = Convert.ToString(marginBottomParam.Value);
					txbMarginLeft.Text = Convert.ToString(marginLeftParam.Value);
					txbMarginRight.Text = Convert.ToString(marginRightParam.Value);
					int formFeed = Convert.ToInt16(formFeedParam.Value);
					if(formFeed == 1)
					{
						cbFormFeed.Checked = true;
					}
					else
					{
						cbFormFeed.Checked = false;
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
					if(insertLFAfterCR == 1)
					{
						cbInsertLFAfterCR.Checked = true;
					}
					else
					{
						cbInsertLFAfterCR.Checked = false;
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

	}
}
