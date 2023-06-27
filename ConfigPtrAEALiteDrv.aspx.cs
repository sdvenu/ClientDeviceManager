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
	/// Summary description for ConfigPtrAEALiteDrv.
	/// </summary>
	public partial class ConfigPtrAEALiteDrv : Web.PageBase
	{
		private const String NEW_DEVICE = "NEW_DEVICE";
		private const String DROP_PP_CTC = "DROPPCCTC";
		protected ComPortCtrl ComPortCtrl1;
		// initial variables for logging
		private string UserIP ="";
		private string HostName = "";
		private string WebForm = "ConfigPtrAEALiteDrv";
		private string actcmd ="";


	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			textboxNoOfFF.Attributes["onKeyUp"]="LimitToNumeric(Form1.textboxNoOfFF)";
			textBoxMaxFileSize.Attributes["onKeyUp"]="LimitToNumeric(Form1.textBoxMaxFileSize)";

            // assign values, actcmd may vary..
			UserIP = Request.UserHostAddress;
			HostName = Request.UserHostName;

            LoginIfNotLoggedIn();
            SelectWorkstationIfNoneSelected();

            if( !Page.IsPostBack )
			{
				String selectedDriver = (String) Session[ConfigurePtr.SESSION_PRINT_DRIVER_SELECTED];
				if( selectedDriver.StartsWith("AEALiteDrv.dll" ))
				{
					cbDopPPCCTC.Enabled = true;
				}
				else
				{
					cbDopPPCCTC.Enabled = false;
				}
				if( selectedDriver.StartsWith("ATB2Drv.dll" ))
				{
					cbHostAnswerback.Enabled = true;
				}
				else
				{
					textboxNoOfFF.Text = "1";
				}
				String deviceName = (String) Session[ConfigurePtr.SESSION_PRINTER_DEVICE_NAME];
				if( selectedDriver == null || selectedDriver.Length == 0 )
				{
					Response.Redirect("ConfigurePtr.aspx");
				}
				// set defaults
				rbEnabled.Checked = true;
				labelHeader.Text = (String) Session[ConfigurePtr.SESSION_PRINT_DRIVER_SELECTED] + " Configuration";
				LoadCurrentConfiguration();

                textboxDeviceName.Focus();
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

		protected void rbDisabled_CheckedChanged(object sender, System.EventArgs e)
		{
			rbEnabled.Checked = false;
		}

		protected void rbEnabled_CheckedChanged(object sender, System.EventArgs e)
		{
			rbDisabled.Checked = false;
		}

		private void textboxNoOfFF_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void PopulateForm(bool enabled, int debugLevel, String ioDriver,
			bool insertLFAfterCr, String noOfFF,String maxLogSize, String logFile)
		{
			String deviceName = (String) Session[ConfigurePtr.SESSION_PRINTER_DEVICE_NAME];
			textboxDeviceName.Text = deviceName;
			textboxNoOfFF.Text = noOfFF;
			ddlIoDriver.SelectedItem.Text = ioDriver;
			ResetAllRadioButtons();
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
			rbEnabled.Checked = enabled;
			rbDisabled.Checked = !enabled;
			textBoxMaxFileSize.Text = maxLogSize;
			textBoxLogFileName.Text = logFile;
			this.cbInsertLFAfterCR.Checked = insertLFAfterCr;
			
		}

		private void LoadCurrentConfiguration()
		{
			bool enabled = ConfigurePtr.DEFAULT_ENABLE;
			int debugLevel = ConfigurePtr.DEFAULT_DEBUG_LEVEL;
			String maxLogSize = ConfigurePtr.DEFAULT_MAX_LOG_SIZE;
			String ioDriver = ConfigurePtr.DEFAULT_IO_DRIVER;
			String port="";

			String baudRate="";
			String dataBits="";
			String parity="";
			String stopBit="";
			String flowControl="";


			bool insertLFAfterCr = true;
			cbDopPPCCTC.Checked = false;
			String noOfFF = ConfigurePtr.DEFAULT_FORM_FEED;
			String selectedDriver = (String) Session[ConfigurePtr.SESSION_PRINT_DRIVER_SELECTED];
			if( selectedDriver.StartsWith("ATB2Drv.dll" ))
			{
				noOfFF = "0";
			}
			else
			{
				noOfFF = "1";
			}
			String logFile = ConfigurePtr.DEFAULT_LOG_FILE;
			String configTable = (String) Session[ConfigurePtr.COLUMN_CONFIG_TABLE];
			String deviceName = (String) Session[ConfigurePtr.SESSION_PRINTER_DEVICE_NAME];
			String wsName = (String) Session["WSName"];
			String cmdSelectExistingDevices = "SELECT * FROM " + configTable +
                " WHERE " + ConfigurePtr.COLUMN_DEVICENAME + " = '" + deviceName +
                "' AND " + ConfigurePtr.COLUMN_WSNAME + " = '" + wsName + "'"; 
			Common.Database db = new ClientDeviceMgr.Common.Database();
			cbDopPPCCTC.Checked = true;
			cbHostAnswerback.Checked = false;
			bool newDevice = true;
			try
			{
				DataSet dsDeviceInfo = db.MyFillDataSet(cmdSelectExistingDevices,configTable);
                db.Dispose();
				if( dsDeviceInfo != null && dsDeviceInfo.Tables[0].Rows.Count > 0 )
				{
					newDevice = false;
					try
					{
						foreach( DataRow row in dsDeviceInfo.Tables[0].Rows)
						{
							enabled = Convert.ToBoolean(Convert.ToInt32(row[ConfigurePtr.COLUMN_ENABLED].ToString().Trim()));
							debugLevel = Convert.ToInt32( row[ConfigurePtr.COLUMN_DEBUG_LEVEL].ToString().Trim());
							ioDriver = row[ConfigurePtr.COLUMN_IO_DRIVER].ToString().Trim();
							port = row[ConfigurePtr.COLUMN_PORT].ToString().Trim();
							try
							{
								// these followings are added recently, if they are null in database, it is ok
								baudRate = row[ConfigurePtr.COLUMN_BAUD_RATE].ToString().Trim();
								dataBits = row[ConfigurePtr.COLUMN_DATABITS].ToString().Trim();
								parity = row[ConfigurePtr.COLUMN_PARITY].ToString().Trim();
								stopBit = row[ConfigurePtr.COLUMN_STOP_BITS].ToString().Trim();
								flowControl = row[ConfigurePtr.COLUMN_FLOW_CONTROL].ToString().Trim();
							}
							catch
							{
							}
							noOfFF = row[ConfigurePtr.COLUMN_NUM_OF_FF].ToString().Trim();
							insertLFAfterCr = Convert.ToBoolean(Convert.ToInt32(row[ConfigurePtr.COLUMN_INSERT_LF].ToString().Trim()));
							maxLogSize = row[ConfigurePtr.COLUMN_MAX_FILE_SIZE].ToString().Trim();
							logFile = row[ConfigurePtr.COLUMN_LOG_FILE_NAME].ToString().Trim();
							cbDopPPCCTC.Checked = Convert.ToBoolean(Convert.ToInt32(row[DROP_PP_CTC].ToString().Trim()));
							cbHostAnswerback.Checked = Convert.ToBoolean(Convert.ToInt32(row[ConfigurePtr.COLUMN_HOST_ANSWERBACK].ToString().Trim()));
							break;
						}
					}
					catch(Exception ex)
					{
						Console.WriteLine(ex);
					}
				}
			}
			catch
			{
			}
			Session[NEW_DEVICE] = newDevice;
			PopulateForm( enabled, debugLevel, ioDriver, insertLFAfterCr, noOfFF,maxLogSize,logFile);
			if( newDevice == false )
			{
				ComPortCtrl1.SetPortData( port, baudRate, dataBits, parity, stopBit, flowControl);
			}
			else
			{
				ComPortCtrl1.SetDefault(selectedDriver);
			}
		}

		protected void buttonSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				int debugLevel = 0;
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
				String maxLogSize = textBoxMaxFileSize.Text.Trim();
				String logFileName = textBoxLogFileName.Text.Trim().ToUpper();
				String wsName = Session["WSName"].ToString().ToUpper();
				String deviceName = Session[ConfigurePtr.SESSION_PRINTER_DEVICE_NAME].ToString().ToUpper();
				String enabled = (Convert.ToInt32(rbEnabled.Checked)).ToString();
				String dropPCCTC = Convert.ToInt32(cbDopPPCCTC.Checked).ToString();
				String noOfFF = textboxNoOfFF.Text.Trim();
				String portSelected;
				String baudRate;
				String dataBits;
				String parity;
				String stopBit;
				String flowControl;
				ComPortCtrl1.GetPortData(out portSelected, out baudRate, out dataBits, out parity, out stopBit, out flowControl);
				String ioDriver = ddlIoDriver.SelectedItem.Text;
				String configTable = (String) Session[ConfigurePtr.COLUMN_CONFIG_TABLE];
				bool newDevice = (bool)Session[NEW_DEVICE];
				String insertLF = Convert.ToInt32(cbInsertLFAfterCR.Checked).ToString();
				String executionCommand;
				String printerDriver = (String)Session[ConfigurePtr.SESSION_PRINT_DRIVER_SELECTED];
				String hostAnswerback = Convert.ToInt32(cbHostAnswerback.Checked).ToString();
				if( newDevice )
				{
					executionCommand = "INSERT INTO " + configTable + " ( ";
					executionCommand += ( 
						ConfigurePtr.COLUMN_DEVICENAME + " , " +
						ConfigurePtr.COLUMN_NUM_OF_FF + " , " +
						ConfigurePtr.COLUMN_PORT  + " , " +
						ConfigurePtr.COLUMN_BAUD_RATE  + " , " +
						ConfigurePtr.COLUMN_DATABITS  + " , " +
						ConfigurePtr.COLUMN_PARITY  + " , " +
						ConfigurePtr.COLUMN_STOP_BITS  + " , " +
						ConfigurePtr.COLUMN_FLOW_CONTROL  + " , " +
						ConfigurePtr.COLUMN_IO_DRIVER + " , " +
						ConfigurePtr.COLUMN_DRIVER + " , " +
						ConfigurePtr.COLUMN_WSNAME + " , " +
						ConfigurePtr.COLUMN_INSERT_LF + " , " +
						ConfigurePtr.COLUMN_DEBUG_LEVEL+ " , " + 
						ConfigurePtr.COLUMN_MAX_FILE_SIZE+ " , " + 
						ConfigurePtr.COLUMN_ENABLED+ " , " + 
						DROP_PP_CTC + " , " +
						ConfigurePtr.COLUMN_HOST_ANSWERBACK + " , " +
						ConfigurePtr.COLUMN_LOG_FILE_NAME+ 	" ) " +
						" VALUES ( '" +
						deviceName + "', '" +
						noOfFF + "', '" +
						portSelected + "', '" +
						baudRate + "', '" +
						dataBits + "', '" +
						parity + "', '" +
						stopBit + "', '" +
						flowControl + "', '" +
						ioDriver + "', '" +
						printerDriver +"', '" +
						wsName + "', '" +
						insertLF + "', '"+
						debugLevel+ "', '"+
						maxLogSize+ "', '"+
						enabled + "', '"+
						dropPCCTC + "', '" +
						hostAnswerback + "', '"+
						logFileName+ "') " 
						);
				}
				else
				{
					executionCommand = "UPDATE " + configTable + " SET  ";
					executionCommand += ( 
						ConfigurePtr.COLUMN_DEVICENAME+ " = '" + deviceName + "', " +
						ConfigurePtr.COLUMN_NUM_OF_FF+ " = '" + noOfFF + "', " +
						ConfigurePtr.COLUMN_PORT + " = '" + portSelected + "', " +
						ConfigurePtr.COLUMN_BAUD_RATE + " = '" + baudRate + "', " +
						ConfigurePtr.COLUMN_DATABITS + " = '" + dataBits + "', " +
						ConfigurePtr.COLUMN_PARITY + " = '" + parity + "', " +
						ConfigurePtr.COLUMN_STOP_BITS + " = '" + stopBit + "', " +
						ConfigurePtr.COLUMN_FLOW_CONTROL + " = '" + flowControl + "', " +
						ConfigurePtr.COLUMN_IO_DRIVER+ " = '" + ioDriver + "', " +
						ConfigurePtr.COLUMN_WSNAME + " = '" + wsName + "', " +
						ConfigurePtr.COLUMN_INSERT_LF + " = '" + insertLF + "', " +
						ConfigurePtr.COLUMN_DEBUG_LEVEL + " = '" + debugLevel + "', " +
						ConfigurePtr.COLUMN_MAX_FILE_SIZE+ " = '" + maxLogSize+ "', " +
						ConfigurePtr.COLUMN_ENABLED + " = '" + enabled+ "', " +
						DROP_PP_CTC						 + " = '" + dropPCCTC + "', " +
						ConfigurePtr.COLUMN_LOG_FILE_NAME+ " = '" + logFileName + "' " 
						);
					executionCommand += (" WHERE " + ConfigurePtr.COLUMN_WSNAME + " = '" + wsName +
						"' AND " + ConfigurePtr.COLUMN_DEVICENAME + " = '" + deviceName + "'");
				}

				for(int k=0;k<executionCommand.Length;k++)
				{
					if (executionCommand[k] != '\'')
						actcmd += executionCommand[k];
				}

				Common.Database database = new ClientDeviceMgr.Common.Database();
				try
				{
					int result = database.MyUpdateDataExecuteNonQuery(executionCommand);
					if (result >0)
						logAudit(actcmd,1);
					else
						logAudit(actcmd,0);
				}
				catch(Exception ex )
				{
					labelHeader.Text = ex.Message;
					return;
				}
			}
			catch
			{
			}
			Response.Redirect("ConfigurePtr.aspx");
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
		
		}

		protected void rbDebugDisabled_CheckedChanged(object sender, System.EventArgs e)
		{
			ResetAllRadioButtons();
			rbDebugDisabled.Checked = true;
		}

		protected void rbLogToFile_CheckedChanged(object sender, System.EventArgs e)
		{
			ResetAllRadioButtons();
			rbLogToFile.Checked = true;
		}

		protected void rbDebugWindowEnabled_CheckedChanged(object sender, System.EventArgs e)
		{
			ResetAllRadioButtons();
			rbDebugWindowEnabled.Checked = true;
		}

		protected void rbDebugFileAndWindowEnabled_CheckedChanged(object sender, System.EventArgs e)
		{
			ResetAllRadioButtons();
			rbDebugFileAndWindowEnabled.Checked = true;
		}

		private void ResetAllRadioButtons()
		{
			rbDebugDisabled.Checked = false;
			rbLogToFile.Checked = false;
			rbDebugWindowEnabled.Checked = false;
			rbDebugFileAndWindowEnabled.Checked = false;
		}

		protected void textBoxMaxFileSize_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void cbInsertLFAfterCR_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}
		private void logAudit(string cmd, int complete)
		{
			// function insert log into audit table, 
			// where UserID can be WSName or UserID(which is created or deleted)
			// UserName is current login userID in Session["UsrName"]
			// action log for future auditing
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
