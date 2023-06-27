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
	/// Summary description for WSSelect.
	/// </summary>
	public partial class SP_SearchAuditLog : Web.PageBase
	{
		private string SearchBy;
		private string cmd;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            LoginIfNotSupervisor();

			if (!IsPostBack)
			{
				// Put user code to initialize the page here
				pnlInput.Visible=true;
				pnlOutput.Visible=false;
				rbWSName.Checked=true;
				lblByType.Text="Workstation Name: ";
				lblTitle.Text="List audit log searched by : ";
                txbSearchBy.Focus();
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

		protected void dgLog_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		public void PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
		{
			SearchBy = txbSearchBy.Text.ToUpper();
			if (rbWSName.Checked)
				cmd = "SELECT UserName,ActionTime,CommandStr,WebForm,UserIP,HostName,Completion" +
					" FROM AuditLogtbl" +
                    " WHERE UserID='" + SearchBy +
                    "' ORDER BY ActionTime DESC";
			else
				cmd = "SELECT UserID,ActionTime,CommandStr,WebForm,UserIP,HostName,Completion" +
					" FROM AuditLogtbl" +
                    " WHERE UserName = '" + SearchBy +
                    "' ORDER BY ActionTime DESC";
			Common.Database db = new Common.Database();
			DataSet MyDS = db.MyFillDataSet(cmd, "AuditLog");
            db.Dispose();
            if (MyDS == null)
				return;

			dgLog.CurrentPageIndex= e.NewPageIndex;
			dgLog.DataSource = MyDS;
			dgLog.DataBind();
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			SearchBy = txbSearchBy.Text.ToUpper();
			if (rbWSName.Checked)
				cmd = "SELECT UserName,ActionTime,CommandStr,WebForm,UserIP,HostName,Completion" +
					" FROM AuditLogtbl" +
                    " WHERE UserID = '" + SearchBy +
                    "' ORDER BY ActionTime DESC";
			else
				cmd = "SELECT UserID,ActionTime,CommandStr,WebForm,UserIP,HostName,Completion" +
					" FROM AuditLogtbl" +
                    " WHERE UserName = '" + SearchBy +
                    "' ORDER BY ActionTime DESC";

			Common.Database db = new Database();
			DataSet MyDS = db.MyFillDataSet(cmd, "AuditLog");
            db.Dispose();
			if (MyDS == null)
			    return;

			pnlInput.Visible=false;
			pnlOutput.Visible=true;
			lblTitle.Text="Audit log searched by: " + SearchBy;
			dgLog.DataSource = MyDS;
			dgLog.DataBind();
		}

		protected void rbUser_CheckedChanged(object sender, System.EventArgs e)
		{
			lblByType.Text="User ID: ";
			txbSearchBy.Text="";
            txbSearchBy.Focus();
        }

		protected void rbWSName_CheckedChanged(object sender, System.EventArgs e)
		{
			lblByType.Text="Workstation Name: ";
			txbSearchBy.Text="";
            txbSearchBy.Focus();
        }
	}
}
