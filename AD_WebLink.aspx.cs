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
using ClientDeviceMgr.SystemFramework;

namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for Emul.
	/// </summary>
	public partial class AD_WebLink : Web.PageBase
	{
		private string Group = null;

        public const String EMUL_CFG_TABLE = "EmulatorCfgSettings";
		public const String USER_ID = "UserID";
		public const String EMUL_PARAMS = "EmulParams";
		// initial variables for logging
		private string UserIP ="";
		private string HostName = "";
		private string WebForm = "AD_WebLink";
		private string actcmd = "";
		// variables for web link section
		//		protected string EmulData ="";
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			UserIP = Request.UserHostAddress;
			HostName = Request.UserHostName;
            Group = LoginIfNotLoggedIn();
            
            // Put user code to initialize the page here
			if (!IsPostBack)
			{
				if (Group == "USER")
				{
					lblMessage.Text = "Select the profile to view.";
					//set the Tooltip text...
					lblMessage.ToolTip = "You must select a profile to " +
						"view the configuration information associated with an Emulator instance.";
				}
				else
				{
					lblMessage.Text = "Select the profile to modify.";
					//set the Tooltip text...
					lblMessage.ToolTip = "You must select a profile to perform updates or " +
						"view the configuration information associated with an Emulator instance.";
				}

                // Move the panels from design position to run position.
                AutoPanel.Style["left"] = "220px";
                AutoPanel.Style["Top"] = "275px";
                EmulPanel.Style["left"] = "220px";
                EmulPanel.Style["Top"] = "275px";
                ManualPanel.Style["left"] = "220px";
                ManualPanel.Style["Top"] = "275px";
                pnlStatus.Style["left"] = "220px";
                pnlStatus.Style["Top"] = "275px";

				AutoPanel.Visible = false;
				ManualPanel.Visible = true;
				EmulPanel.Visible = false;
                txtboxWSName.Focus();
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

		protected void ManualSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			if (Group == "USER")
			{
				lblMessage.Text = "Select the profile to view.";
				//set the Tooltip text...
				lblMessage.ToolTip = "You must select a profile to " +
					"view the configuration information associated with an Emulator instance.";
			}
			else
			{
				lblMessage.Text = "Select the profile to modify.";
				//set the Tooltip text...
				lblMessage.ToolTip = "You must select a profile to perform updates or " +
					"view the configuration information associated with an Emulator instance.";
			}

			if (ManualSelection.Checked == true)
			{
				pnlStatus.Visible = false;
				AutoPanel.Visible = false;
				ManualPanel.Visible = true;
                //ManualPanel.Style["left"] = "220px";
                //ManualPanel.Style["Top"] = "275px";
				lbxWSNames.ClearSelection();
				EmulPanel.Visible = false;
			}
            //else
            //{
            //    pnlStatus.Visible = false;
            //    AutoPanel.Visible = true;
            //    ManualPanel.Visible = false;
            //    //AutoPanel.Style["left"] = "220px";
            //    //AutoPanel.Style["Top"] = "275px";
            //    FillOutAutoPanel();
            //    EmulPanel.Visible = false;
            //}		
		}

		protected void AutoSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			if (Group == "USER")
			{
				lblMessage.Text = "Select the profile to view.";
				//set the Tooltip text...
				lblMessage.ToolTip = "You must select a profile to " +
					"view the configuration information associated with an Emulator instance.";
			}
			else
			{
				lblMessage.Text = "Select the profile to modify.";
				//set the Tooltip text...
				lblMessage.ToolTip = "You must select a profile to perform updates or " +
					"view the configuration information associated with an Emulator instance.";
			}

			if (AutoSelection.Checked == true)
            //{
            //    pnlStatus.Visible = false;
            //    AutoPanel.Visible = false;
            //    ManualPanel.Visible = true;
            //    ManualPanel.Style["left"] = "220px";
            //    ManualPanel.Style["Top"] = "275px";
            //    EmulPanel.Visible = false;
            //}
            //else
			{
				pnlStatus.Visible = false;
				AutoPanel.Visible = true;
				ManualPanel.Visible = false;
                //AutoPanel.Style["left"] = "220px";
                //AutoPanel.Style["Top"] = "275px";
				EmulPanel.Visible = false;
				FillOutAutoPanel();
			}		
		}

		private void FillOutAutoPanel()
		{
			Common.Database db = new Database();
			string cmd = "SELECT * FROM " + EMUL_CFG_TABLE;
			DataSet myDS = db.MyFillDataSet(cmd, EMUL_CFG_TABLE);
            db.Dispose();
			if (myDS == null)
				return;
			
			DataView SupportView = myDS.Tables[EMUL_CFG_TABLE].DefaultView;

			lbxWSNames.DataSource = (ICollection)SupportView;
			lbxWSNames.DataTextField = USER_ID;
			lbxWSNames.DataValueField = USER_ID;
			lbxWSNames.DataBind();
		}

		protected void btnManual_Click(object sender, System.EventArgs e)
		{
			string Msg = null;
			Group = (string)Session["Group"];

            if (string.IsNullOrEmpty(Group))
			{
				Response.Redirect("Login.aspx", true);
				return;
			}
			if (!IsProfileValid(txtboxWSName.Text.Trim()))
			{
				if (Group.Trim() == "ADMIN")
				{
					Msg = "You have entered a profile name that does not exist. " +
						"Please verify the profile name you entered is correct.";
				}
				else
				{
					Msg = "You have entered a profile name that does not exist. " +
						"Please verify the profile name you entered is correct.";
				}
				lblMessage.Text = Msg;
				lblMessage.ForeColor = System.Drawing.Color.Red;
				return;
			}

			//let's send down our HTE file into the HTE Edit Panel...
            lblMessage.Text = "";
			AutoPanel.Visible = false;
			ManualPanel.Visible = false;
			Session["ProfileName"] = txtboxWSName.Text.Trim();
			SendDownHTEFile(txtboxWSName.Text.Trim());
		}

		protected void btnAuto_Click(object sender, System.EventArgs e)
		{
			string s = lbxWSNames.SelectedValue.Trim();
            if (string.IsNullOrEmpty(s))
			{
				lblMessage.Text = "You must select a profile name from the list " +
					"to proceed with the configuration process.";
				lblMessage.ForeColor = System.Drawing.Color.Red;
				return;
			}
            lblMessage.Text = "";
			Session["ProfileName"] = s.Trim();
			AutoPanel.Visible = false;
			ManualPanel.Visible = false;
            //pnlStatus.Style["left"] = "220px";
            //pnlStatus.Style["Top"] = "275px";
			pnlStatus.Visible = false;
			SendDownHTEFile(s);
		}

		private bool IsProfileValid(string profileName)
		{
			Common.Database db = new Database();
			string cmd = "SELECT PasswordRequired FROM " + EMUL_CFG_TABLE +
                " WHERE UserID = '" + profileName + "'";
			string zone = db.MyGetDataExecuteScalar(cmd);
            db.Dispose();
            return !string.IsNullOrEmpty(zone);
		}

		private void SendDownHTEFile(string profileName)
		{
			EmulPanel.Visible = true;
            //EmulPanel.Style["left"] = "220px";
            //EmulPanel.Style["Top"] = "275px";
			lblMessage.Text = "You are viewing the Host Terminal Emulator web link settings for " +
				"profile " + profileName.Trim();
			Common.Database db = new Database();
			string cmd = "SELECT * FROM " + EMUL_CFG_TABLE +
                " WHERE UserID = '" + profileName.Trim() + "'";
			string data = db.MyGetDataExecuteScalar(cmd);
            db.Dispose();

			txtboxEmulSettings.Text = GetWebLinks(data);
            txtboxEmulSettings.Focus();
			//			EmulData = data;
		}

		protected void btnApply_Click(object sender, System.EventArgs e)
		{
			//Ok let's update the HTE file information under the profile name
			//we have established...

			string profilename = (string)Session["ProfileName"];
			Common.Database db = new Database();
			string EmulData = SetWebLinks(txtboxEmulSettings.Text);
			string cmd = "UPDATE " + EMUL_CFG_TABLE + " SET " + EMUL_PARAMS +
				" = '" + EmulData + "' WHERE UserID = '" +
				profilename.Trim() + "'";
			int i = db.MyUpdateDataExecuteNonQuery(cmd);
			for(int k=0;k<cmd.Length;k++)
			{
				if (cmd[k] != '\'')
					actcmd += cmd[k];
			}
		
			AutoPanel.Visible = false;
			ManualPanel.Visible = false;
			EmulPanel.Visible = false;
            //pnlStatus.Style["left"] = "220px";
            //pnlStatus.Style["Top"] = "275px";
			pnlStatus.Visible = true;
			if (i > 0)
			{
				pnlStatus.Text = "Your update request for profile name: " + profilename.Trim() +
					" was processed successfully.";
				pnlStatus.ForeColor = System.Drawing.Color.Navy;
				logAudit(actcmd,1);
			}
			else
			{
				pnlStatus.Text = "The update request for profile name: " + profilename.Trim() +
					" was unsuccessful. Please notify your database administrator.";
				pnlStatus.ForeColor = System.Drawing.Color.Red;
				logAudit(actcmd,0);
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session.Remove("ProfileName");
			Response.Redirect("AD_WebLink.aspx", true);
		}
		
		private string GetWebLinks(String emulParams)
		{
            string sRet = "";			                        	// find start of section
			int before = emulParams.IndexOf("[web]", StringComparison.OrdinalIgnoreCase);
			if (before == -1)										// no [Web] section!
				return sRet;
			else
				before += 7;										// bump past [Web]\r\n
			int during;
			int end = emulParams.IndexOf("[", before);				// find end of section
 
			if (end == -1)											// it's the end of the string
			{ 
				during = emulParams.Length - before;
				sRet = emulParams.Substring(before, during);
			}
			else
			{
				end -= 2;											// back up past \r\n
				during = end - before;
				sRet = emulParams.Substring(before, during);
			}
			return sRet;
		}

		private string SetWebLinks(string webLinks)
		{
			string profilename = (string)Session["ProfileName"];
			Common.Database db = new Database();
			string cmd = "SELECT * FROM " + EMUL_CFG_TABLE +
                " WHERE UserID = '" + profilename.Trim() + "'";
			string EmulParams = db.MyGetDataExecuteScalar(cmd);
            db.Dispose();

            // find start of section
			int before = EmulParams.IndexOf("[Web]", StringComparison.OrdinalIgnoreCase);
			int after;
			if (before == -1)
			{
				EmulParams = EmulParams + "\r\n[Web]\r\n" + webLinks;
			}
			else
			{
                before += 7;   										// bump past [Web]\r\n
				int end = EmulParams.IndexOf("[", before);			// find end of section
                if (end == -1)										// it's the end of the string
				{
					EmulParams = EmulParams.Substring(0, before) + "\r\n" + webLinks;
				}
				else
				{
                    end -= 2;										// back up past \r\n
					after = EmulParams.Length - end;
					EmulParams = EmulParams.Substring(0, before) + webLinks + 
						EmulParams.Substring(end, after);
				}
			}
			return EmulParams;
		} 

		private void logAudit(string cmd, int complete)
		{
			// function insert log into audit table, 
			// where UserID can be WSName or UserID(which is created or deleted)
			// UserName is current login userID in Session["UsrName"]
			// action log for future auditing
			int cmdLength =cmd.Length;
			if (cmdLength > 900)
				cmd = cmd.Substring(0,50) + cmd.Substring((cmdLength-50),50);
			Common.Database db = new Database();
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
