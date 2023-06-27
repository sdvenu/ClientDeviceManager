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
using ClientDeviceMgr.Common;
using ClientDeviceMgr.Web;
using ClientDeviceMgr.Common.Data;
using ClientDeviceMgr.SystemFramework;

namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for BGRConfig.
	/// </summary>
	public partial class DisplayBGR : Web.PageBase
	{
		protected string WSName = null;
		protected System.String BGR_INFO_TBL = "BGRCfgTable";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string Group = LoginIfNotLoggedIn();
            WSName = SelectWorkstationIfNoneSelected();

			if (!IsPostBack)
			{
				WelcomeMsg.Text = "BGR Application settings for" +
					" workstation name: " + WSName.Trim();
				WelcomeMsg.ForeColor = System.Drawing.Color.Navy;

				if (Group != "ADMIN")
				{
                    txtboxHostSys.Enabled = false;
					txtboxNumBGRs.Enabled = false;
					ckboxHostVal.Enabled = false;
					ckboxLogging.Enabled = false;
					ckboxNOLED.Enabled = false;
					btnOK.Visible = false;
				}

				//let's fill out our config form...
				Common.Database db = new Database();
				string cmd = "SELECT * FROM " + BGR_INFO_TBL +
                    " WHERE WSNAME = '" + WSName.Trim() + "'";
				DataSet myDS = db.MyFillDataSet(cmd, BGR_INFO_TBL);
                db.Dispose();
				if (myDS == null)
					return ;

				DataTable dt = myDS.Tables[BGR_INFO_TBL];
				if (dt.Rows.Count == 0)
					return;

				// Set for defaults
				try
				{
					tbAirlineId.Text = dt.Rows[0]["AIRLINE_ID"].ToString().Trim();
					cbTesting.Checked = (Convert.ToInt32(dt.Rows[0]["TESTING"].ToString().Trim())==1);
					cbDebugWindow.Checked = (Convert.ToInt32(dt.Rows[0]["DEBUG_WINDOW"].ToString().Trim())==1);
					tbHostReceiveTimeout.Text = dt.Rows[0]["HOSTRECV_TIMEOUT"].ToString().Trim();
					tbHostUpdateInterval.Text = dt.Rows[0]["HOSTUPDATE_INTERVAL"].ToString().Trim();
					tbInactivityInterval.Text = dt.Rows[0]["INACTIVITY_INTERVAL"].ToString().Trim();
					tbMaxLogDataSize.Text = dt.Rows[0]["MAX_LOGDATA_SIZE"].ToString().Trim();
					tbBGR1PortName.Text = dt.Rows[0]["BGR1_PORTNAME"].ToString().Trim();
					tbBGR2PortName.Text = dt.Rows[0]["BGR2_PORTNAME"].ToString().Trim();
					tbBGR3PortName.Text = dt.Rows[0]["BGR3_PORTNAME"].ToString().Trim();
					tbBGR4PortName.Text = dt.Rows[0]["BGR4_PORTNAME"].ToString().Trim();
					txtboxNumBGRs.Text = dt.Rows[0]["BGR_DEVICES"].ToString().Trim();
					txtboxHostSys.Text = dt.Rows[0]["BGR_SYSTEM"].ToString().Trim();

					ckboxLogging.Checked =((dt.Rows[0]["BGR_DEBUGMODE"].ToString().Trim()) == "1");
					ckboxHostVal.Checked =((dt.Rows[0]["HOSTVAL"].ToString().Trim()) == "1");
					ckboxNOLED.Checked = ((dt.Rows[0]["NOBGRLED"].ToString().Trim()) == "1");
					ckboxSCEdit.Checked = ((dt.Rows[0]["SC_EDIT_CHECK"].ToString().Trim()) == "1");
					ckboxProfileChk.Checked = ((dt.Rows[0]["SC_PROFILE_CHECK"].ToString().Trim()) == "1");
					ckboxAddCollect.Checked = ((dt.Rows[0]["ADD_COLLECT_DUE_CHECK"].ToString().Trim()) == "1");
					cbRemote.Checked = ((dt.Rows[0]["REMOTE_INSTANCE"].ToString().Trim()) == "1");
//					if (dt.Rows[0]["BGR_DEBUGMODE"].ToString().Trim() == "1")
//						ckboxLogging.Checked = true;
//
//					if (dt.Rows[0]["HOSTVAL"].ToString().Trim() == "1")
//						ckboxHostVal.Checked = true;
//					else
//						ckboxHostVal.Checked = false;
//
//					if (dt.Rows[0]["NOBGRLED"].ToString().Trim() == "1")
//						ckboxNOLED.Checked = true;
//
//					if (dt.Rows[0]["SC_EDIT_CHECK"].ToString().Trim() == "1")
//						ckboxSCEdit.Checked = true;
//
//					if (dt.Rows[0]["SC_PROFILE_CHECK"].ToString().Trim() == "1")
//						ckboxProfileChk.Checked = true;
//
//					if (dt.Rows[0]["ADD_COLLECT_DUE_CHECK"].ToString().Trim() == "1")
//						ckboxAddCollect.Checked = true;
//					if (dt.Rows[0]["REMOTE_INSTANCE"].ToString().Trim() == "1")
//						cbRemote.Checked = true;
				}
				catch
				{
				}
			}
			tbAirlineId_TextChanged(null,null);

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

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			string devices = txtboxNumBGRs.Text.Trim();
            if (string.IsNullOrEmpty(devices))
				devices = "1";
			string system = txtboxHostSys.Text.Trim();
            if (string.IsNullOrEmpty(system))
				system = "RES";
			string debug = "0";
			if (ckboxLogging.Checked == true)
				debug = "1";
			string hostval = "0";
			if (ckboxHostVal.Checked == true)
				hostval = "1";
			string NoLED = "0";
			if (ckboxNOLED.Checked == true)
				NoLED = "1";
			string SCEdit = "0";
			if (ckboxSCEdit.Checked == true)
				SCEdit = "1";
            string SCProfile = "0";
			if (ckboxProfileChk.Checked == true)
				SCProfile = "1";
			string AddCollect = "0";
			if (ckboxAddCollect.Checked == true)
				AddCollect = "1";

			String airlineId = tbAirlineId.Text.Trim().ToUpper();
			String testing = Convert.ToInt32(cbTesting.Checked).ToString();
			String debugWindow = Convert.ToInt32(cbDebugWindow.Checked).ToString();
//			String scEditCheck = Convert.ToInt32(cbSCEditCheck.Checked).ToString();
//			String scProfileCheck = Convert.ToInt32(cbSCProfileCheck.Checked).ToString();
//			String addCollectDueCheck = Convert.ToInt32(cbAddCollectDueCheck.Checked).ToString();
			String hostReceiveTimeout = tbHostReceiveTimeout.Text.Trim().ToUpper();
			String hostUpdateInterval = tbHostUpdateInterval.Text.Trim().ToUpper();
			String inactivityInterval = tbInactivityInterval.Text.Trim().ToUpper();
			String maxLogDataSize = tbMaxLogDataSize.Text.Trim().ToUpper();
			String bgr1PortName = tbBGR1PortName.Text.Trim().ToUpper();
			String bgr2PortName = tbBGR2PortName.Text.Trim().ToUpper();
			String bgr3PortName = tbBGR3PortName.Text.Trim().ToUpper();
			String bgr4PortName = tbBGR4PortName.Text.Trim().ToUpper();
			
			String remoteInstance = Convert.ToInt32(cbRemote.Checked).ToString();

			Common.Database db = new Database();
			string querycmd = "SELECT * FROM " + BGR_INFO_TBL +
                " WHERE WSNAME = '" + WSName.Trim() + "'";
//			string insertcommand = "INSERT INTO " + BGR_INFO_TBL +
//				" VALUES('123','" + devices.Trim() + "','" + system.Trim() +
//				"','" + debug.Trim() + "','" + hostval.Trim() + "','" +
//				NoLED.Trim() + "','" + WSName.Trim() + "','" + SCEdit.Trim() 
//				+ "','" + SCProfile.Trim() 
//				+ "','" + AddCollect.Trim() 
//				+ "','" + remoteInstance
//				+ "','" + airlineId
//				+ "','" + testing
//				+ "','" + debugWindow
//				+ "','" + hostReceiveTimeout
//				+ "','" + hostUpdateInterval
//				+ "','" + inactivityInterval
//				+ "','" + maxLogDataSize
//				+ "','" + bgr1PortName
//				+ "','" + bgr2PortName
//				+ "','" + bgr3PortName
//				+ "','" + bgr4PortName
//				+ "',newid())";
			string insertcommand = "INSERT INTO " + BGR_INFO_TBL +
				"(AIRLINE_CODE," 
					+ "BGR_DEVICES,"
					+ "BGR_SYSTEM," 
					+ "BGR_DEBUGMODE,"
					+ "HOSTVAL,NOBGRLED,"
					+ "WSName,"
					+ "SC_EDIT_CHECK,"
					+ "SC_PROFILE_CHECK,"
					+ "ADD_COLLECT_DUE_CHECK,"
					+ "REMOTE_INSTANCE," 
					+ "AIRLINE_ID,"
					+ "TESTING,"
					+ "DEBUG_WINDOW,"
					+ "HOSTRECV_TIMEOUT,"
					+ "HOSTUPDATE_INTERVAL," 
					+ "INACTIVITY_INTERVAL,"
					+ "MAX_LOGDATA_SIZE,"
					+ "BGR1_PORTNAME,"
					+ "BGR2_PORTNAME," 
					+ "BGR3_PORTNAME,"
					+ "BGR4_PORTNAME)" +
				" VALUES('123','" 
					+ devices.Trim() 
					+ "','" + system.Trim() 
					+ "','" + debug.Trim() 
					+ "','" + hostval.Trim() 
					+ "','" + NoLED.Trim() 
					+ "','" + WSName.Trim() 
					+ "','" + SCEdit.Trim() 
					+ "','" + SCProfile.Trim() 
					+ "','" + AddCollect.Trim() 
					+ "','" + remoteInstance
					+ "','" + airlineId
					+ "','" + testing
					+ "','" + debugWindow
					+ "','" + hostReceiveTimeout
					+ "','" + hostUpdateInterval
					+ "','" + inactivityInterval
					+ "','" + maxLogDataSize
					+ "','" + bgr1PortName
					+ "','" + bgr2PortName
					+ "','" + bgr3PortName
					+ "','" + bgr4PortName
					+ "')";

			try
			{
				if (!db.CreateTableIfNotExist(querycmd, insertcommand, BGR_INFO_TBL))
				{
					WelcomeMsg.Text = "Error updating BGR configuration information." +
						"Please notify your database administrator.";
					WelcomeMsg.ForeColor = System.Drawing.Color.Red;
					return;
				}
			}
			catch
			{
			}

			string updatecmd = "UPDATE " + BGR_INFO_TBL + " SET AIRLINE_CODE = '123', " +
				"BGR_DEVICES = '" + devices.Trim() + "', BGR_SYSTEM = '" + system.Trim() +
				"', BGR_DEBUGMODE = '" + debug.Trim() + "', HOSTVAL = '" + hostval.Trim() +
				"', NOBGRLED = '" + NoLED.Trim() + "', WSName = '" + WSName.Trim() +
				"', SC_EDIT_CHECK = '" + SCEdit.Trim() + "', SC_PROFILE_CHECK = '" + SCProfile.Trim() +
				"', ADD_COLLECT_DUE_CHECK = '" + AddCollect.Trim() +
				"', REMOTE_INSTANCE = '" + remoteInstance +

				"', AIRLINE_ID = '" + airlineId+
				"', TESTING = '"+ testing+
				"', DEBUG_WINDOW = '"+ debugWindow+
				"', HOSTRECV_TIMEOUT = '"+ hostReceiveTimeout+
				"', HOSTUPDATE_INTERVAL = '"+ hostUpdateInterval+
				"', INACTIVITY_INTERVAL = '"+ inactivityInterval+
				"', MAX_LOGDATA_SIZE = '"+ maxLogDataSize+
				"', BGR1_PORTNAME = '"+ bgr1PortName+
				"', BGR2_PORTNAME = '"+ bgr2PortName+
				"', BGR3_PORTNAME = '"+ bgr3PortName+
				"', BGR4_PORTNAME = '"+ bgr4PortName+

				"' WHERE WSName = '" + WSName.Trim() +"'";

			try
			{
				int result = db.MyUpdateDataExecuteNonQuery(updatecmd);
				if (result > 0)
				{
					WelcomeMsg.Text = "BGR Configuration update was completed successfully.";
					WelcomeMsg.ForeColor = System.Drawing.Color.Navy;
					return;
				}
			}
			catch
			{
			}

			WelcomeMsg.Text = "Error updating BGR configuration information." +
				"Please notify your database administrator.";
			WelcomeMsg.ForeColor = System.Drawing.Color.Red;
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
            Response.Redirect("Welcome.aspx", true);		
		}

		protected void tbAirlineId_TextChanged(object sender, System.EventArgs e)
		{
			String airlineId = tbAirlineId.Text.ToUpper().Trim();
			bool enableFlag = true;
			if( airlineId == "US" )
			{
				enableFlag = false;
			}
			cbTesting.Enabled = enableFlag;
			tbHostReceiveTimeout.Enabled = enableFlag;
			tbHostUpdateInterval.Enabled = enableFlag;
			tbInactivityInterval.Enabled = enableFlag;
			tbMaxLogDataSize.Enabled = enableFlag;
			tbBGR1PortName.Enabled = enableFlag;
			tbBGR2PortName.Enabled = enableFlag;
			tbBGR3PortName.Enabled = enableFlag;
			tbBGR4PortName.Enabled = enableFlag;
		}
	}
}
