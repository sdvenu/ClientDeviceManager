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
	public partial class AD_AuditLog : Web.PageBase
	{
		private string cmd;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            LoginIfNotAdmin();
            string WSName = SelectWorkstationIfNoneSelected();

            cmd = "SELECT ActionTime,CommandStr,WebForm,Completion FROM AuditLogtbl" +
                " WHERE UserID = '" + WSName +
                "' ORDER BY ActionTime DESC";

            if (!IsPostBack)
			{
				// Put user code to initialize the page here
				Common.Database db = new Database();
				DataSet MyDS = db.MyFillDataSet(cmd, "AuditLog");
                db.Dispose();
                if (MyDS == null)
					return;

				dgLog.DataSource = MyDS;
				dgLog.DataBind();
			}

            dgLog.Focus();
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
			Common.Database db = new Common.Database();
			DataSet MyDS = db.MyFillDataSet(cmd, "AuditLog");
            db.Dispose();
            if (MyDS == null)
				return;
			dgLog.CurrentPageIndex= e.NewPageIndex;
			dgLog.DataSource = MyDS;
			dgLog.DataBind();
		}
	}
}
