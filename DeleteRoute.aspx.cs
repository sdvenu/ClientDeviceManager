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
using ClientDeviceMgr.SystemFramework;

namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for DeleteRoute.
	/// </summary>
	public partial class DeleteRoute : Web.PageBase
	{
		private String RouteName;
		private String WSName;
		// initial variables for logging
		private string UserIP ="";
		private string HostName = "";
		private string WebForm = "DeleteRoute";
		private string actcmd ="";

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			WSName = (string)Session["WSName"];
			ReadQueryString(out RouteName);
			// assign values, actcmd may vary..
			UserIP = Request.UserHostAddress;
			HostName = Request.UserHostName;

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				MainLabel.Text = "Delete Route: " + RouteName.Trim() +
					" from workstation: " + WSName.Trim() + "?";
			}
		}

		private bool ReadQueryString(out string route)
		{
			bool bRet = false;
			route = Request.QueryString["ROUTENAME"].ToString().Trim();
			if (route != null && route.Trim().Length > 0)
				bRet = true;

			return bRet;
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

		protected void btnNo_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConfigureRoute.aspx", true);		
		}

		protected void btnYes_Click(object sender, System.EventArgs e)
		{
			WSName = (string)Session["WSName"];
			ReadQueryString(out RouteName);
			if (DeleteWorkstationRoute())
			{
				Response.Redirect("ConfigureRoute.aspx", true);
			}
			else
			{
				MainLabel.Text = "Error deleting Route " + RouteName.Trim() +
					"for workstation " + WSName.Trim() +
					" from the database.Please notify your database administrator.";
				MainLabel.ForeColor = System.Drawing.Color.Red;
				btnNo.Visible = false;
				btnYes.Visible = false;
			}
		}

		private bool DeleteWorkstationRoute()
		{
			bool bRet = false;
			int total = 0;
			string cmd = null;
			string [] WSNameDatabaseTables = {
                "HSSPRouteInfo", 
                "MainRouteConfigTable",
                "OFEPRouteInfo",
                "OSGRouteInfo" };
			Common.Database db = new Database();
			
			//let's get it out of our mainroute table...
			foreach(string s in WSNameDatabaseTables)
			{
				cmd = "DELETE FROM " + s.Trim() + " WHERE WSName = '" +
					WSName.Trim() + "' AND RouteName = '" + RouteName.Trim() + "'";
                
				int i = db.MyUpdateDataExecuteNonQuery(cmd);
				total += i;
			}
			actcmd = "DELETE Route where WSName=" + WSName.Trim() +" and RouteName =" + RouteName.Trim();
			if (total > 0)
			{
				logAudit(actcmd,1);
				bRet = true;
			}
			else
				logAudit(actcmd,0);

			return bRet;
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
