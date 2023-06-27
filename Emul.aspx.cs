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
	public partial class Emul : Web.PageBase
	{
		private string Group = null;
		public const String EMUL_CFG_TABLE = "EmulatorCfgSettings";
		public const String USER_ID = "UserID";
		public const String EMUL_PARAMS = "EmulParams";
		// initial variables for logging
		private string UserIP ="";
		private string HostName = "";
		private string WebForm = "Emul";
		private string actcmd ="";
			
		protected void Page_Load(object sender, System.EventArgs e)
		{
            Group = LoginIfNotLoggedIn();

            // Put user code to initialize the page here
			if (!IsPostBack)
			{
				// assign values, actcmd may vary..
				UserIP = Request.UserHostAddress;
				HostName = Request.UserHostName;

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
				AutoPanel.Visible = false;
				ManualPanel.Visible = true;
				EmulPanel.Visible = false;
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
				lblMessage.ToolTip = "You must select a profile name to " +
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
				ManualPanel.Style["left"] = "220px";
				ManualPanel.Style["Top"] = "262px";
				lbxWSNames.ClearSelection();
				EmulPanel.Visible = false;
			}
			else
			{
				pnlStatus.Visible = false;
				AutoPanel.Visible = true;
				ManualPanel.Visible = false;
				AutoPanel.Style["left"] = "220px";
				AutoPanel.Style["Top"] = "262px";
				FillOutAutoPanel();
				EmulPanel.Visible = false;
			}		
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

			if (AutoSelection.Checked == false)
			{
				pnlStatus.Visible = false;
				AutoPanel.Visible = false;
				ManualPanel.Visible = true;
				ManualPanel.Style["left"] = "220px";
				ManualPanel.Style["Top"] = "262px";
				EmulPanel.Visible = false;
			}
			else
			{
				pnlStatus.Visible = false;
				AutoPanel.Visible = true;
				ManualPanel.Visible = false;
				AutoPanel.Style["left"] = "220px";
				AutoPanel.Style["Top"] = "262px";
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
						"Verify the profile name you entered is correct.";
				}
				else
				{
					Msg = "You have entered a profile name that does not exist. " +
						"Verify the profile name you entered is correct.";
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
			string s = lbxWSNames.SelectedValue;
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
			pnlStatus.Style["left"] = "220px";
			pnlStatus.Style["Top"] = "262px";
			pnlStatus.Visible = false;
			SendDownHTEFile(s);
		}

		private bool IsProfileValid(string profileName)
		{
			Common.Database db = new Database();
			string cmd = "SELECT PasswordRequired FROM EmulatorCfgSettings" +
                " WHERE UserID = '" + txtboxWSName.Text.Trim() + "'";
			string zone = db.MyGetDataExecuteScalar(cmd);
            db.Dispose();
			return !string.IsNullOrEmpty(zone);
		}

		private void SendDownHTEFile(string profileName)
		{
			EmulPanel.Visible = true;
			EmulPanel.Style["left"] = "220px";
			EmulPanel.Style["Top"] = "262px";
			lblMessage.Text = "You are viewing the Host Terminal Emulator settings for " +
				"profile " + profileName.Trim();
			Common.Database db = new Database();
			string cmd = "SELECT * FROM " + EMUL_CFG_TABLE +
                " WHERE UserID = '" + profileName.Trim() + "'";
			string data = db.MyGetDataExecuteScalar(cmd);
            db.Dispose();

			txtboxEmulSettings.Text = data;
            txtboxEmulSettings.Focus();
		}

		protected void btnApply_Click(object sender, System.EventArgs e)
		{
			//Ok let's update the HTE file information under the profile name
			//we have established...
			Common.Database db = new Database();
			string profilename = (string)Session["ProfileName"];
			string cmd = "UPDATE " + EMUL_CFG_TABLE + " SET " + EMUL_PARAMS +
				" = '" + txtboxEmulSettings.Text.Trim() + "' WHERE UserID = '" +
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
			pnlStatus.Style["left"] = "220px";
			pnlStatus.Style["Top"] = "262px";
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
			Response.Redirect("Emul.aspx", true);
		}

		private void logAudit(string cmd, int complete)
		{
			// function insert log into audit table, 
			// where UserID can be WSName or UserID(which is created or deleted)
			// UserName is current login userID in Session["UsrName"]
			// action log for future auditing
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
