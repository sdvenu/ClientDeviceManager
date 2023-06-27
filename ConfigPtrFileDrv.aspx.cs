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
	/// Summary description for ConfigPtrFileDrv.
	/// </summary>
	public partial class ConfigPtrFileDrv : Web.PageBase
	{
		public const int SINGLE_FILE = 0;
		public const int MULTIPLE_FILES = 1;
		public const int TIME_STAMP = 0;
		public const int FILE_INCREMENT = 1;
		public const String COLUMN_MULTIPLEFILES = "MULTIPLEFILES";
		public const String COLUMN_FILEPATH = "FILEPATH";
		public const String COLUMN_FILENAME = "FILENAME";
		public const String COLUMN_APPENDDATATOFILE = "APPENDDATATOFILE";
		public const String COLUMN_MAXFILESTOCREATE = "MAXFILESTOCREATE";
		public const String COLUMN_FILEEXT = "FILEEXT";
		public const String COLUMN_EOM = "EOM";
		public const String COLUMN_INCREMENTFILECOUNT ="INCREMENTFILECOUNT";
		public const String COLUMN_MAXFILE_SIZE = "MAXFILESIZE";
		private const String NEW_DEVICE = "NEW_DEVICE";
		// initial variables for logging
		private string UserIP ="";
		private string HostName = "";
		private string WebForm = "ConfigPtrFileDrv";
		private string actcmd ="";

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			textboxMaxFileSize.Attributes["onKeyUp"]="LimitToNumeric(Form1.textboxMaxFileSize)";
//			string UserID = (string)Session["usrName"];
//			string Group = (string)Session["Group"];
			// assign values, actcmd may vary..
			UserIP = Request.UserHostAddress;
			HostName = Request.UserHostName;

            LoginIfNotLoggedIn();
            SelectWorkstationIfNoneSelected();

            if( !Page.IsPostBack )
			{
                String selectedDriver = (String) Session[ConfigurePtr.SESSION_PRINT_DRIVER_SELECTED];
				String deviceName = (String) Session[ConfigurePtr.SESSION_PRINTER_DEVICE_NAME];
				if( selectedDriver == null || selectedDriver.Length == 0 )
				{
					Response.Redirect("ConfigurePtr.aspx");
				}

				// set defaults
				textboxDeviceName.Text = deviceName;
				rbEnabled.Checked = true;
				labelHeader.Text = (String) Session[ConfigurePtr.SESSION_PRINT_DRIVER_SELECTED] + " Configuration";
				textboxMaxFileSize.Attributes["onKeyUp"]="LimitToNumeric(Form1.textboxMaxFileSize)";
				textboxFileExtention.Attributes["onKeyUp"]="LimitToUppercase(Form1.textboxFileExtention)";
				textboxFileLocation.Attributes["onKeyUp"]="LimitToFilePath(Form1.textboxFileLocation)";
				textboxMaxFiles.Attributes["onKeyUp"]="LimitToNumeric(Form1.textboxMaxFiles)";
				textboxFileName.Attributes["onKeyUp"]="LimitToUppercase(Form1.textboxFileName)";
				TextBoxMaxLogSize.Attributes["onKeyUp"]="LimitToNumeric(Form1.TextBoxMaxLogSize)";
				EnableForSingleOrMultipleOption();
				LoadCurrentConfiguration();
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

		protected void rbSingleFile_CheckedChanged(object sender, System.EventArgs e)
		{
			rbMultipleFile.Checked = false;
			EnableForSingleOrMultipleOption();
		}

		protected void rbMultipleFile_CheckedChanged(object sender, System.EventArgs e)
		{
			rbSingleFile.Checked = false;
			EnableForSingleOrMultipleOption();
		}
		private void EnableForSingleOrMultipleOption()
		{
			bool singleFileEnable = rbSingleFile.Checked;
			textboxMaxFileSize.Enabled = singleFileEnable;
			textboxFileExtention.Enabled = singleFileEnable;
			textboxEOMLabel.Enabled = singleFileEnable;
			cbAppedData.Enabled = singleFileEnable;
			rbTimeStamp.Enabled = !singleFileEnable;
			rbIncrement.Enabled = !singleFileEnable;
			textboxMaxFiles.Enabled = !singleFileEnable;
		}

		protected void rbTimeStamp_CheckedChanged(object sender, System.EventArgs e)
		{
			rbIncrement.Checked = false;
			textboxMaxFiles.Enabled = false;
		}

		protected void rbIncrement_CheckedChanged(object sender, System.EventArgs e)
		{
			rbTimeStamp.Checked = false;
			textboxMaxFiles.Enabled = true;
		}

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
				String logFileName = textBoxLogFileName.Text.Trim();
				String wsName = (String) Session["WSName"];
				String deviceName = (String) Session[ConfigurePtr.SESSION_PRINTER_DEVICE_NAME];
				String enabled = (Convert.ToInt32(rbEnabled.Checked)).ToString();
				String configTable = (String) Session[ConfigurePtr.COLUMN_CONFIG_TABLE];
				bool newDevice = (bool)Session[NEW_DEVICE];
				String insertLF = Convert.ToInt32(cbInsertLFAfterCr.Checked).ToString();
				String executionCommand;
				String printerDriver = (String)Session[ConfigurePtr.SESSION_PRINT_DRIVER_SELECTED];

				String maxOutputFileSize = textboxMaxFileSize.Text;
				int fileType = Convert.ToInt32(rbSingleFile.Checked != true );
				String fileLocation = textboxFileLocation.Text;
				if( !fileLocation.EndsWith("\\") )
				{
					fileLocation += "\\";
				}
				String fileNameWithoutExtn = textboxFileName.Text;
				int appendDataToFile = Convert.ToInt32( cbAppedData.Checked == true );
				String fileExtention = textboxFileExtention.Text;
				String eomLabel = textboxEOMLabel.Text;
				int timeStampOrIncrement = Convert.ToInt32(rbTimeStamp.Checked != true );
				String maxFileToCreate = textboxMaxFiles.Text;
				String maxLogSize = TextBoxMaxLogSize.Text;
				int insertLFAfterCr = Convert.ToInt32(cbInsertLFAfterCr.Checked);

				if( newDevice )
				{
					executionCommand = "INSERT INTO " + configTable + " ( ";
					executionCommand += ( 
						ConfigurePtr.COLUMN_DEVICENAME + " , " +
						ConfigurePtr.COLUMN_DRIVER + " , " +
						ConfigurePtr.COLUMN_WSNAME + " , " +
						ConfigurePtr.COLUMN_DEBUG_LEVEL+ " , " + 
						ConfigurePtr.COLUMN_MAX_FILE_SIZE+ " , " + 
						ConfigurePtr.COLUMN_ENABLED+ " , " + 
						ConfigurePtr.COLUMN_LOG_FILE_NAME+  " , " +

						COLUMN_MAXFILE_SIZE + " , " +
						COLUMN_MULTIPLEFILES + " , " +
						COLUMN_FILEPATH + " , " +
						COLUMN_FILENAME + " , " +
						COLUMN_APPENDDATATOFILE + " , " +
						COLUMN_MAXFILESTOCREATE + " , " +
						COLUMN_FILEEXT + " , " +
						COLUMN_EOM + " , " +
						ConfigurePtr.COLUMN_INSERT_LF + " , " +
						COLUMN_INCREMENTFILECOUNT + 
						", rowguid ) " +
						" VALUES ( '" +
						deviceName + "', '" +
						printerDriver +"', '" +
						wsName + "', '" +
						debugLevel+ "', '"+
						maxLogSize+ "', '"+
						enabled + "', '"+
						logFileName+ "', '"+

						maxOutputFileSize+ "', '"+
						fileType+ "', '"+
						fileLocation+ "', '"+
						fileNameWithoutExtn+ "', '"+
						appendDataToFile+ "', '"+
						maxFileToCreate+ "', '"+
						fileExtention+ "', '"+
						eomLabel+ "', '"+
						insertLFAfterCr+ "', '"+
						timeStampOrIncrement+ "',"+
						" newid()) " 
						);
				}
				else
				{
					executionCommand = "UPDATE " + configTable + " SET  ";
					executionCommand += ( 
						ConfigurePtr.COLUMN_DEVICENAME+ " = '" + deviceName + "', " +


						ConfigurePtr.COLUMN_DRIVER + " = '"+ printerDriver+ "', " +
						ConfigurePtr.COLUMN_WSNAME + " = '"+ wsName + "', " +
						ConfigurePtr.COLUMN_DEBUG_LEVEL+ " = '" +debugLevel+ "', " +
						ConfigurePtr.COLUMN_MAX_FILE_SIZE+ " = '"+ maxLogSize+ "', " +
						ConfigurePtr.COLUMN_ENABLED+ " = '" + enabled + "', " +
						ConfigurePtr.COLUMN_LOG_FILE_NAME+  " = '"+ logFileName+ "', " +
						ConfigurePtr.COLUMN_INSERT_LF + " = '" + insertLFAfterCr + "', " +

						COLUMN_MAXFILE_SIZE + " = '" + maxOutputFileSize + "', " +
						COLUMN_MULTIPLEFILES + " = '"+fileType + "', " +
						COLUMN_FILEPATH + " = '"+ fileLocation + "', " +
						COLUMN_FILENAME + " = '"+ fileNameWithoutExtn + "', " +
						COLUMN_APPENDDATATOFILE + " = '"+ appendDataToFile + "', " +
						COLUMN_MAXFILESTOCREATE + " = '"+ maxFileToCreate + "', " +
						COLUMN_FILEEXT + " = '"+ fileExtention + "', " +
						COLUMN_EOM + " = '"+ eomLabel + "', " +
						COLUMN_INCREMENTFILECOUNT + " = '"+ timeStampOrIncrement + "' "
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
					Response.Redirect("ConfigurePtr.aspx");
				}
				catch(Exception ex )
				{
					labelHeader.Text = ex.Message;
				}
			}
			catch
			{
			}
		}

		private void LoadCurrentConfiguration()
		{
			bool enabled = ConfigurePtr.DEFAULT_ENABLE;
			int debugLevel = ConfigurePtr.DEFAULT_DEBUG_LEVEL;
			String maxLogSize = ConfigurePtr.DEFAULT_MAX_LOG_SIZE;
			//			String ioDriver = ConfigurePtr.DEFAULT_IO_DRIVER;
			//			String port = ConfigurePtr.DEFAULT_PORT;
			bool insertLFAfterCr = true;
			//			String noOfFF = ConfigurePtr.DEFAULT_FORM_FEED;
			String logFile = ConfigurePtr.DEFAULT_LOG_FILE;
			int fileType = SINGLE_FILE;
			String configTable = (String) Session[ConfigurePtr.COLUMN_CONFIG_TABLE];
			String deviceName = (String) Session[ConfigurePtr.SESSION_PRINTER_DEVICE_NAME];
			String wsName = (String) Session["WSName"];
            String fileLocation = Global.ConfigurationFolder;
			String fileNameWithoutExtn = "DEFAULT";
			String maxOutputFileSize = "100000";
			String fileExtention = "PTR";
			String eomLabel = textboxEOMLabel.Text;
			bool appendDataToFile = true;
			String maxFileToCreate = "1000";
			int timeStampOrIncrement = MULTIPLE_FILES;
			String cmdSelectExistingDevices = "SELECT * FROM " + configTable +
                " WHERE " + ConfigurePtr.COLUMN_DEVICENAME + " = '" + deviceName +
                "' AND " + ConfigurePtr.COLUMN_WSNAME + " = '" + wsName + "'"; 
			Common.Database db = new ClientDeviceMgr.Common.Database();

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
							maxLogSize = row[ConfigurePtr.COLUMN_MAX_FILE_SIZE].ToString().Trim();
							logFile = row[ConfigurePtr.COLUMN_LOG_FILE_NAME].ToString().Trim();
							fileType =  Convert.ToInt32(row[COLUMN_MULTIPLEFILES].ToString().Trim());
							fileLocation = row[COLUMN_FILEPATH].ToString().Trim();
							fileNameWithoutExtn = row[COLUMN_FILENAME].ToString().Trim();
							appendDataToFile = Convert.ToBoolean( Convert.ToInt32((String)row[COLUMN_APPENDDATATOFILE]) );
							maxOutputFileSize =  row[COLUMN_MAXFILE_SIZE].ToString().Trim();
							fileExtention = row[COLUMN_FILEEXT].ToString().Trim();
							eomLabel =  row[COLUMN_EOM].ToString().Trim();
							timeStampOrIncrement = Convert.ToInt32((String) row[COLUMN_INCREMENTFILECOUNT]);
							maxFileToCreate = row[COLUMN_MAXFILESTOCREATE].ToString().Trim();
							insertLFAfterCr = Convert.ToBoolean(Convert.ToInt32(row[ConfigurePtr.COLUMN_INSERT_LF].ToString().Trim()));
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
			textboxDeviceName.Text = deviceName;
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
			rbEnabled.Checked = enabled;
			rbDisabled.Checked = !enabled;
			textboxMaxFileSize.Text = maxOutputFileSize;
			textBoxLogFileName.Text = logFile;
			rbSingleFile.Checked = (fileType==SINGLE_FILE);
			rbMultipleFile.Checked = (fileType!=SINGLE_FILE);
			textboxFileLocation.Text = fileLocation;
			textboxFileName.Text = fileNameWithoutExtn;
			cbAppedData.Checked = appendDataToFile;
			textboxFileExtention.Text = fileExtention;
			textboxEOMLabel.Text = eomLabel;
			rbTimeStamp.Checked = (timeStampOrIncrement == TIME_STAMP);
			rbIncrement.Checked = !rbTimeStamp.Checked;
			textboxMaxFiles.Enabled = rbIncrement.Checked;
			textboxMaxFiles.Text = maxFileToCreate;
			TextBoxMaxLogSize.Text = maxLogSize;
			cbInsertLFAfterCr.Checked = insertLFAfterCr;
			EnableForSingleOrMultipleOption();
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
