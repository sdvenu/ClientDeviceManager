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
using System.IO;
using System.Text;

namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for AddWS.
	/// </summary>
	public partial class SP_ChangePWD : Web.PageBase
	{
		protected string Group;
		protected const String MANAGEMENT_RIGHTS_TBL = "ManagementRightsTbl";
	
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
				MainMsg.Text = "Enter the password you wish to change.";
				MainMsg.ForeColor= System.Drawing.Color.Navy;
			}
			else
			{
				MainMsg.Text="";
			}

            txbOldPassword.Focus();
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

		protected void btnResetPwd_Click(object sender, System.EventArgs e)
		{
			if (txbPassword.Text!=txbRTPassword.Text)
			{
				MainMsg.Text="Password mismatch, try again.";
				MainMsg.ForeColor=System.Drawing.Color.Red;
				return;
			}
			Common.Database db = new Database();
			string cmd = "SELECT * FROM " + MANAGEMENT_RIGHTS_TBL +
                " WHERE UserID = '" + (string)Session["usrName"] +
                "' AND Password ='" + CryptStr(txbOldPassword.Text.Trim()) + "'";
				
			DataSet myDS = db.MyFillDataSet(cmd, "UserInfo");
            db.Dispose();
			if (myDS == null)
			{
				MainMsg.Text = "Cannot access the database, try again.";
				MainMsg.ForeColor=System.Drawing.Color.Red;
				return;
			}
			DataTable cfgTable = myDS.Tables["UserInfo"];
			if (cfgTable.Rows.Count == 0)
			{
				MainMsg.Text = "Unknown user id, try again.";
				MainMsg.ForeColor=System.Drawing.Color.Red;
				return;
			}

			string Updatecommand = "UPDATE " + MANAGEMENT_RIGHTS_TBL +
                " SET Password = '" + CryptStr(txbPassword.Text.Trim()) +
                "' WHERE UserId ='" +  Session["usrName"].ToString() + "'";
				
			int total= (db.MyUpdateDataExecuteNonQuery(Updatecommand));
			if (total == 0)
			{
				MainMsg.Text="Password reset failed, try again.";
				MainMsg.ForeColor=System.Drawing.Color.Red;
				return;
			}
			db.Dispose();
			txbOldPassword.Text="";
			MainMsg.Text="User password successfully changed";
			MainMsg.ForeColor=System.Drawing.Color.Navy;
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
		

	
	}
}
