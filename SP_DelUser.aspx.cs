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
	public partial class SP_DelUser : Web.PageBase
	{
		public const String UserNAME_FIELD = "UserName";
		// initial variables for logging
		private string UserIP ="";
		private string HostName = "";
		private string WebForm = "SP_DellUser";
		private string tmpUSERID ="";

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            LoginIfNotSupervisor();

            // Put user code to initialize the page here
			if( !IsPostBack )
			{
                txtboxUserName.Focus();
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

		protected void btnpnlManDelete_Click(object sender, System.EventArgs e)
		{
			if (DeleteUserFromDB(txtboxUserName.Text.ToUpper().Trim()))
			{
				lblStatus.Text = txtboxUserName.Text.Trim() + " was successfully" +
					" deleted from the database.";
				lblStatus.ForeColor = System.Drawing.Color.Navy;
			}
			else
			{
				lblStatus.Text = "An error occured while deleting " + txtboxUserName.Text.Trim() +
					". Please contact the database administrator.";
				lblStatus.ForeColor = System.Drawing.Color.Red;
			}
			txtboxUserName.Text = "";
		}

		private bool DeleteUserFromDB(string name)
		{
			bool bRet = false;
			Common.Database db = new Database();
			string cmd = null;
			int total = 0;
			cmd = "DELETE FROM ManagementRightsTbl"  + " WHERE UserID = '" +
				name.Trim() + "'";
			int i = db.MyUpdateDataExecuteNonQuery(cmd);
			total += i;				
			
			if (total > 0)
				bRet = true;
			// assign values, actcmd may vary..then call log function
			UserIP = Request.UserHostAddress;
			HostName = Request.UserHostName;
			tmpUSERID = name;
			string actcmd = "Delete user: " + name;
			if (bRet ==true)
				logAudit(actcmd,1);
			else
				logAudit(actcmd,0);
			return bRet;
		}

		protected void rbManualDel_CheckedChanged(object sender, System.EventArgs e)
		{
			pnlManual.Visible = true;
			AutoPanel.Visible = false;
			pnlManual.Style["left"] = "220px";
			pnlManual.Style["Top"] = "312px";
			lblStatus.Text = "";
            txtboxUserName.Focus();
		}

		protected void rbDelFromList_CheckedChanged(object sender, System.EventArgs e)
		{
			pnlManual.Visible = false;
			AutoPanel.Visible = true;
			AutoPanel.Style["left"] = "220px";
			AutoPanel.Style["Top"] = "292px";
			FillOutAutoPanel();
            lbxUserNames.Focus();
		}

		private void FillOutAutoPanel()
		{
			Common.Database db = new Database();
			string cmd = "SELECT * FROM ManagementRightsTbl ORDER BY UserID";
			DataSet myDS = db.MyFillDataSet(cmd, "ManagementRightsTbl");
            db.Dispose();
			if (myDS == null)
				return;
			
			DataView SupportView = myDS.Tables["ManagementRightsTbl"].DefaultView;

			lbxUserNames.DataSource = (ICollection)SupportView;
			lbxUserNames.DataTextField = "UserID";
			lbxUserNames.DataValueField = "UserID";
			lbxUserNames.DataBind();
		}
		protected void btnAutoDel_Click(object sender, System.EventArgs e)
		{
			string s = lbxUserNames.SelectedValue;
			if (string.IsNullOrEmpty(s))
			{
				Label2.Text =
                    "You must select a user name from the list" +
					" to proceed with deletion.";
				Label2.ForeColor = System.Drawing.Color.Red;
				return;
			}
			if (DeleteUserFromDB(s))
			{
				Label2.Text = s.Trim() + " was successfully removed from the database.";
				Label2.ForeColor = System.Drawing.Color.Navy;
				FillOutAutoPanel();
			}
			else
			{
				Label2.Text =
                    "An error occured attempting to remove " + s.Trim() +
					" from the database. Please notify your database administrator.";
				Label2.ForeColor = System.Drawing.Color.Red;
			}
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
