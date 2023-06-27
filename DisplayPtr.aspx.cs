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
	/// </summary>
	public partial class DisplayPtr : Web.PageBase
	{
//		public const String PRINTER_DRIVERS = "PRINTER_DRIVERS";
		public const String SESSION_PRINT_DRIVER_SELECTED = "PRINT_DRIVER_SELECTED";

		public const String SESSION_PRINTER_DEVICE_NAME = "PRINTER_DEVICE_NAME";
		private const String NEW_DEVICE = "New Device";
		public const String SESSION_DRIVER_LIST = "DRIVER_LIST";
		public const String TABLE_PRINT_DRIVER_LIST = "PrintDriverList";
		public const String SESSION_CONFIG_TABLE = "CONFIG_TABLE";
		public const String SESSION_DEBUG_LEVEL = "DEBUG_LEVEL";
		public const String SESSION_LOG_FILE_NAME = "LOG_FILE";
		public const String SESSION_MAX_FILE_SIZE = "MAX_FILE_SIZE";
		public const String COLUMN_WSNAME = "WSNAME";
		public const String COLUMN_ENABLED="ENABLED";
		public const String COLUMN_DEBUG_LEVEL = "DEBUGLEVEL";
		public const String COLUMN_MAX_FILE_SIZE = "MAXLOGFILESIZE";
		public const String COLUMN_DRIVER = "DRIVER";
		public const String COLUMN_IO_DRIVER= "IODRIVER";
		public const String COLUMN_PORT= "PORT";
		public const String COLUMN_BAUD_RATE ="BAUDRATE";
		public const String COLUMN_DATABITS ="DATABITS";
		public const String COLUMN_PARITY ="PARITY";
		public const String COLUMN_STOP_BITS ="STOPBITS";
		public const String COLUMN_FLOW_CONTROL ="FLOWCONTROL";
		public const String COLUMN_INSERT_LF= "INSERTLFAFTERCR";
		public const String COLUMN_NUM_OF_FF	= "NUMFORMFEEDS";
		public const String COLUMN_DEVICENAME= "DEVICENAME";
		public const String COLUMN_HOST_ANSWERBACK = "HOSTANSWERBACK";
		private const String COLUMN_CONFIG_PAGE= "CONFIG_PAGE";
		private const String COLUMN_DISPLAY_PAGE= "DISPLAY_PAGE";
		public const String  COLUMN_CONFIG_TABLE = "CONFIG_TABLE";
		public const String COLUMN_LOG_FILE_NAME = "LOGFILE";
		public const String DEFAULT_IO_DRIVER = "PORTS.DLL";
		public const bool DEFAULT_ENABLE = true;
		public const String DEFAULT_FORM_FEED = "0";
		public const int INSERT_LF_AFTER_CR = 1;
		public const int DEFAULT_DRIVER_INDEX = 0;
		public const String DEFAULT_LOG_FILE = "CSAPI.LOG";
		public const String DEFAULT_MAX_LOG_SIZE = "100000";
		public const int DEFAULT_DEBUG_LEVEL = 0;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            LoginIfNotLoggedIn();
            String wsName = SelectWorkstationIfNoneSelected(); // or "UserWSSelect.aspx"

			//set our label header...
			CategoryDesciptionLabel.Text = wsName.Trim() + " Printer Information";

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
			if( Page.IsPostBack == false )
			{
				LoadPrinterDriverList();
				PopulateDriverList();
			}
		}

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
/*
		private void LoadExistingDevices()
		{
			try
			{
				String szCmd = "SELECT PFKEYDATA FROM " + PFKEY_TBL +
                    " WHERE USERID = '" + userId + "'";
				Common.Database db = new ClientDeviceMgr.Common.Database();
				String data = db.MyGetDataExecuteScalar(szCmd);
                db.Dispose();
				return data;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
			}
			return "";
		}
*/
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

		protected void buttonNext_Click(object sender, System.EventArgs e)
		{
			String displayPage = "";

			String wsName = (String) Session["WSName"];
			if( wsName == null || wsName.Length == 0 )
			{
				Response.Redirect("WSSelect.aspx");
			}
			Session[SESSION_PRINT_DRIVER_SELECTED] = ddlDrivers.SelectedItem.Text;
			Session[SESSION_PRINTER_DEVICE_NAME] = TextBoxDeviecName.Text.Trim().ToUpper();
			String driver = ddlDrivers.SelectedItem.Text;
			String driverSelected = ddlDrivers.SelectedItem.Text;
			DataSet ds = (DataSet) Application[SESSION_DRIVER_LIST];
			foreach( DataRow row in ds.Tables[0].Rows)
			{
				String currentDriver = row[COLUMN_DRIVER].ToString().Trim();
				if( currentDriver == driverSelected )
				{
					displayPage = row[COLUMN_DISPLAY_PAGE].ToString().Trim();
					break;
				}
			}
			if( displayPage.Length > 0 )
			{
				Response.Redirect(displayPage);
			}
		}

		protected void ddlDeviceNames_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			String deviceNameSelected = ddlDeviceNames.SelectedItem.Text;
			if( deviceNameSelected == NEW_DEVICE )
			{
				Session["New_device"] = true;
				TextBoxDeviecName.Text = "";
				TextBoxDeviecName.Enabled = true;
				buttonNext.Enabled = false;
				
			}
			else
			{
				Session["New_Device"] = false;
				TextBoxDeviecName.Text = deviceNameSelected;
				TextBoxDeviecName.Enabled = false;
				buttonNext.Enabled = true;
				
			}
			labelStatus.Visible = false;
		}

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
                                    "SELECT " + COLUMN_DEVICENAME + " FROM " + configTable +
                                    " WHERE " + COLUMN_WSNAME + " = '" + wsName + "'";
								Common.Database db = new ClientDeviceMgr.Common.Database();
								DataSet dsDevices = db.MyFillDataSet(cmdSelectExistingDevices,configTable);
                                db.Dispose();
                                if (null == dsDevices)
                                    return;
								foreach( DataRow deviceRow in dsDevices.Tables[0].Rows )
								{
									ddlDeviceNames.Items.Add(deviceRow[COLUMN_DEVICENAME].ToString().Trim());
								}
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

		private void buttonDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				String deviceName = TextBoxDeviecName.Text.Trim();
				String configTable = (String)Session[SESSION_CONFIG_TABLE];
				String wsName = (String) Session["WSName"];
				String deleteDevice = ("DELETE FROM "+ configTable + " WHERE " + COLUMN_DEVICENAME + " = '" 
										+ deviceName + "' AND " + COLUMN_WSNAME+" = '" + wsName + "'" );
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
			}
		}
	}
}
