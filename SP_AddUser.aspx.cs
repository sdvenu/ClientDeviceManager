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
using System.Configuration;
using System.Text;
using System.IO;

namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for AddWS.
	/// </summary>
	public partial class SP_AddUser : Web.PageBase
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator RFVUserId;
		protected string Group;
		public const String MANAGEMENT_RIGHTS_TBL = "ManagementRightsTbl";
		private string UserIP ="";
		private string HostName = "";
		private string WebForm = "SP_AddUser";
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Group = (string)Session["Group"];
			if (Group != "SUPER")
			{
				Session.RemoveAll();
				Response.Redirect("Login.aspx", true);
				return;
			}

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				MainMsg.Text = "Enter the user id and password you wish " +
					"to add to manage Client Device Management.<br> User ID must add leading capital" +
					"<br>U  for User <br>S   for Supervisor <br>A   for Administrator<br>" ;
				MainMsg.ForeColor=System.Drawing.Color.Navy;
			}
			else
			{
				MainMsg.Text="User ID must add leading capital<br>U   for User " +
					"<br>S   for Supervisor <br>A   for Administrator<br>";
			}

            txbUser.Focus();
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

		

		protected void btnCreateUser_Click(object sender, System.EventArgs e)
		{
			
			string Msg = null;
			if (!ValidUserID())
			{
				MainMsg.Text += "<br>Invalid User ID, try again." ;
				MainMsg.ForeColor=System.Drawing.Color.Red;
				return;
			}
			
			if (txbPassword.Text!=txbRTPassword.Text)
			{
				MainMsg.Text += "<br>Password mismatch";
				MainMsg.ForeColor = System.Drawing.Color.Red;
				return;
			}
			else
			{
				if (IsUserExist(txbUser.Text.Trim()))
				{
					Msg="<br>User already exist.";
					MainMsg.Text += Msg;
					MainMsg.ForeColor = System.Drawing.Color.Red;
					return;
				}
				UserIP = Request.UserHostAddress;
				HostName = Request.UserHostName;
				string actcmd = "Create User:" + txbUser.Text.ToString();
				if (!CreateNewUserInDB())
				{
					MainMsg.Text="Cannot add user: " + txbUser.Text.ToString() + " try again.";
					MainMsg.ForeColor=System.Drawing.Color.Red;
					logAudit(actcmd,0);

				}
				else
				{
					MainMsg.Text="User: "+ txbUser.Text.ToString().ToUpper()+ " add to database succeed." ;
					MainMsg.ForeColor = System.Drawing.Color.Navy;
					logAudit(actcmd,1);
					txbUser.Text="";
				}

			}
		}

		private void ddlRole_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private bool CreateNewUserInDB()
		{
			Database db = new Database();
            
			string querycmd = "SELECT * FROM " + MANAGEMENT_RIGHTS_TBL +
                " WHERE UserID = '" + txbUser.Text.Trim().ToUpper() + "'" ;

			string insertcommand = "INSERT INTO " + MANAGEMENT_RIGHTS_TBL + 
				"(UserID,Password,UserGroup)" +
				" VALUES('" + txbUser.Text.Trim().ToUpper()
                + "','" + CryptStr(txbPassword.Text.Trim()) +
                "','" + ddlRole.SelectedValue +"')";

            return db.CreateTableIfNotExist(querycmd, insertcommand, SP_AddUser.MANAGEMENT_RIGHTS_TBL);
		}

		private string CryptStr(string strIn)
		{
			XorCrypt xor = new XorCrypt();
			MemoryStream instream = new MemoryStream();
			MemoryStream outstream = new MemoryStream();
			byte [] bufin = new byte[strIn.Length];
			for (int i=0;i < strIn.Length; i++)
			{
				bufin[i] =((byte)strIn[i]);  
			}
		
			instream.Write(bufin, 0, bufin.Length);
			instream.Position=0;
			xor.XorStream(instream,outstream);
			outstream.Position=0;
			byte [] bufout = outstream.ToArray();
            StringBuilder result = new StringBuilder(8);
            foreach (byte b in bufout)
                result.Append(Convert.ToChar(b & 0x7f));
            return result.ToString();
            //?? return Encoding.ASCII.GetString(bufout);
        }
		
		private bool IsUserExist(string userID)
		{
			Common.Database db = new Database();
			string cmd = "SELECT UserId FROM ManagementRightsTbl" +
                " WHERE UserId = '" + txbUser.Text.Trim() + "'";
			string strUser = db.MyGetDataExecuteScalar(cmd);
            db.Dispose();
			return !string.IsNullOrEmpty(strUser);
		}

		private bool ValidUserID()
		{
			bool bRet = false;
			string LeadingUID = txbUser.Text.ToString();
			string LeadingRole = ddlRole.SelectedValue.ToString();
			if ((LeadingUID[0] == LeadingRole[0]) && (LeadingUID.Length > 2))
				bRet = true;
			return bRet;
		}

		private void logAudit(string cmd, int complete)
		{
			// action log for future auditing
			Common.Database db = new Database();
			string logcmd = "INSERT INTO AuditLogtbl(UserName,UserID,commandStr,WebForm," +
				"UserIP,HostName,Completion) VALUES('" + (string)Session["UsrName"] +"','" +
				txbUser.Text.Trim() +"','" + cmd + "','" +WebForm + "','" + UserIP + 
				"','" + HostName +	"','" + complete +"')";
			int k = db.MyUpdateDataExecuteNonQuery(logcmd);
			db.Dispose();
			return;
		}
	}
}
