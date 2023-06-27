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

namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for DelWS.
	/// </summary>
	public partial class DelWS : Web.PageBase
	{
		public const String MASTER_NODE_TABLE = "MasterNodeTable";
		public const String WSNAME_FIELD = "WSName";
		// initial variables
		private string UserIP ="";
		private string HostName = "";
		private string WebForm = "DelWS";
		private string actcmd = "";
		private string tmpUSERID ="";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			UserIP = Request.UserHostAddress;
			HostName = Request.UserHostName;

            if(!IsPostBack)
			{
                string Group = LoginIfNotLoggedIn();

				if (Group == "USER")
				{
					MainLabel.Text =
                        "You are not a member of the Admin group." +
                        " You are not authorized to perform this function.";
					return;
				}

                // Move panels from design position to run position.
                AutoPanel.Style["left"] = "220px";
                AutoPanel.Style["Top"] = "292px";
                pnlManual.Style["left"] = "220px";
                pnlManual.Style["Top"] = "312px";
            }

            txtboxWSName.Focus();
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

		protected void btnpnlManDelete_Click(object sender, System.EventArgs e)
		{
			if (!IsWorkstationValid(txtboxWSName.Text.ToUpper().Trim()))
			{
				lblStatus.Text = "Only disabled workstations can be deleted." +
					"<br>An error occured while deleting " + txtboxWSName.Text.Trim() +
					". Please contact the database administrator.";
				lblStatus.ForeColor = System.Drawing.Color.Red;
				return;
			}
			// assign values, actcmd may vary..
			
			if (DeleteWSFromDB(txtboxWSName.Text.ToUpper().Trim()))
			{
				lblStatus.Text = txtboxWSName.Text.Trim() + " was successfully " +
					"removed from the database.";
				lblStatus.ForeColor = System.Drawing.Color.Navy;
				logAudit(actcmd,1);
			}
			else
			{
				lblStatus.Text = "Only disabled workstations can be deleted." +
					"<br>An error occured while deleting " + txtboxWSName.Text.Trim() +
					". Please contact the database administrator.";
				lblStatus.ForeColor = System.Drawing.Color.Red;
				logAudit(actcmd,0);
			}
			txtboxWSName.Text = "";
			return;
		}

		private bool DeleteWSFromDB(string name)
		{
			bool bRet = false;
			string [] WSNameDatabaseTables = {
                "AEALiteDrvTable",
                "BGRCfgTable",
                "FileDrvTable",
                "HSSPRouteInfo", 
                "MainRouteConfigTable",
                "MasterNodeTable",
//                "MasterNodeExtraTable", // Retain for analysis purposes
                "OFEPRouteInfo",
                "OSGRouteInfo", 
                "PrintDrvTable"
            };
			string [] UserIDDatabaseTables = {
                "EmulatorCfgSettings",
                "PFKeyTbl",
                "PFKeyTbl2",
                "QIKKeyTbl",
                "QIKKeyTbl2"
            };

			Common.Database db = new Database();
			string cmd = null;
			int total = 0;
			foreach(string s in WSNameDatabaseTables)
			{
				cmd = "DELETE FROM " + s.Trim() + " WHERE WSName = '" +
					name.Trim() + "'";
                
				int i = db.MyUpdateDataExecuteNonQuery(cmd);
				total += i;
			}
			foreach(string a in UserIDDatabaseTables)
			{
				cmd = "DELETE FROM " + a.Trim() + " WHERE UserID = '" +
					name.Trim() + "'";
				int i = db.MyUpdateDataExecuteNonQuery(cmd);
				total += i;				
			}
			tmpUSERID = name;
			actcmd = "Delete workstation: " +name;
			if (total > 0)
			{
				logAudit(actcmd,1);
				bRet = true;
			}
			else
				logAudit(actcmd,0);
			db.Dispose();
			return bRet;
		}

		protected void rbManualDel_CheckedChanged(object sender, System.EventArgs e)
		{
			pnlManual.Visible = true;
			AutoPanel.Visible = false;
            //pnlManual.Style["left"] = "220px";
            //pnlManual.Style["Top"] = "312px";
			lblStatus.Text = "";
            txtboxWSName.Focus();
		}

		protected void rbDelFromList_CheckedChanged(object sender, System.EventArgs e)
		{
			pnlManual.Visible = false;
			AutoPanel.Visible = true;
            //AutoPanel.Style["left"] = "220px";
            //AutoPanel.Style["Top"] = "292px";
			FillOutAutoPanel();
            lbxWSNames.Focus();
		}

		private void FillOutAutoPanel()
		{
			Common.Database db = new Database();
			string cmd = "SELECT * FROM MasterNodeTable WHERE Enable = 0";
			DataSet myDS = db.MyFillDataSet(cmd, MASTER_NODE_TABLE);
            db.Dispose();
			if (myDS == null)
				return;
			
			DataView SupportView = myDS.Tables[MASTER_NODE_TABLE].DefaultView;

			lbxWSNames.DataSource = (ICollection)SupportView;
			lbxWSNames.DataTextField = WSNAME_FIELD;
			lbxWSNames.DataValueField = WSNAME_FIELD;
			lbxWSNames.DataBind();
		}

        protected void btnAutoDel_Click(object sender, System.EventArgs e)
		{
			string s = lbxWSNames.SelectedValue.Trim();
            if (string.IsNullOrEmpty(s))
			{
				Label2.Text = "You must select a workstation name from the disabled list " +
					"to proceed with the configuration process.";
				Label2.ForeColor = System.Drawing.Color.Red;
				return;
			}
			
			if (DeleteWSFromDB(s))
			{
				Label2.Text = s.Trim() + " was successfully removed from the database.";
				Label2.ForeColor = System.Drawing.Color.Navy;
				FillOutAutoPanel();
			}
			else
			{
				Label2.Text = "An error occured attempting to remove " + s.Trim() +
					" from the database. Please notify your database administrator.";
				Label2.ForeColor = System.Drawing.Color.Red;
			}
		}

		private bool IsWorkstationValid(string wSName)
		{
			Common.Database db = new Database();
			string cmd = "SELECT AirportZone FROM MasterNodeTable" +
                " WHERE WSName = '" + wSName + "' AND Enable = 0";
			string zone = db.MyGetDataExecuteScalar(cmd);
			db.Dispose();
            return !string.IsNullOrEmpty(zone);
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
				tmpUSERID +"','" + cmd + "','" +WebForm + "','" + UserIP + 
				"','" + HostName +	"','" + complete +"')";
			int k = db.MyUpdateDataExecuteNonQuery(logcmd);
			db.Dispose();
			return;
		}
	}
}
