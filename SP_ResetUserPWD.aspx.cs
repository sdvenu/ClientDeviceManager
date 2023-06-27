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
	public partial class SP_ResetUserPWD : Web.PageBase
	{
		protected string Group;
		public const String MANAGEMENT_RIGHTS_TBL = "ManagementRightsTbl";
	
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
				MainMsg.Text = "Enter the userID and password " +
                    "you wish to reset.";
				MainMsg.ForeColor= System.Drawing.Color.Navy;
			}
			else
			{
				MainMsg.Text="";
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

		

		protected void btnResetPwd_Click(object sender, System.EventArgs e)
		{
			if (txbPassword.Text!=txbRTPassword.Text)
			{
				MainMsg.Text="Password mismatch";
				MainMsg.ForeColor=System.Drawing.Color.Red;
			}
			else
			{
				
				if (!UpdateUserPwd())
				{
					MainMsg.Text="Password reset failed, contact database administrator.";
					MainMsg.ForeColor=System.Drawing.Color.Red;
				}
				else
				{
					MainMsg.Text="User password reset succeed";
					MainMsg.ForeColor=System.Drawing.Color.Navy;
				}

			}
		}

		
		

		private bool UpdateUserPwd()
		{
			Database db = new Database();
           
			string Updatecommand = "UPDATE " + MANAGEMENT_RIGHTS_TBL + " SET Password='" +  
			 CryptStr(txbPassword.Text.Trim())+"' where UserId ='" +  txbUser.Text.ToString()+ "'";
				
			int total= (db.MyUpdateDataExecuteNonQuery(Updatecommand));
			if (total == 0)
				return false;
			txbUser.Text="";
			return true;
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
