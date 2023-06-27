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
	/// Search for the workstations that use a given LNIATA.
	/// </summary>
	public partial class AD_SearchTA : Web.PageBase
	{
		private string SearchBy;
		private string cmd;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            LoginIfNotAdmin();

			if (!IsPostBack)
			{
				// Put user code to initialize the page here
				pnlInput.Visible=true;
				pnlOutput.Visible=false;
				rbLNIATA.Checked=true;
				lblByType.Text="LNIATA: ";
				lblTitle.Text="Search workstation by: ";
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
			if (rbLNIATA.Checked)
				cmd = "SELECT LNIATA,WSName,LogFile,RouteName FROM HsspRouteInfo" +
					" WHERE LNIATA = '" + SearchBy +
					"' UNION SELECT LNIATA,WSName,LogFile,RouteName FROM OfepRouteInfo" +
					" WHERE LNIATA = '" + SearchBy +
                    "' ORDER BY LNIATA";
			else
				cmd = "SELECT LNIATA,WSName,LogFile,RouteName FROM HsspRouteInfo" +
					" WHERE LNIATA > '000000' AND RouteName = '" + SearchBy +
					"' UNION SELECT LNIATA,WSName,LogFile,RouteName FROM OfepRouteInfo" +
					" WHERE LNIATA > '000000' AND RouteName = '" + SearchBy +
                    "' ORDER BY LNIATA";
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
			if (rbLNIATA.Checked)
				cmd = "SELECT LNIATA,WSName,LogFile,RouteName FROM HsspRouteInfo" +
					" WHERE LNIATA = '" + SearchBy +
					"' UNION SELECT LNIATA,WSName,LogFile,RouteName FROM OfepRouteInfo" +
					" WHERE LNIATA = '" + SearchBy +
                    "' ORDER BY LNIATA";
			else
				cmd = "SELECT LNIATA,WSName,LogFile,RouteName FROM HsspRouteInfo" +
					" WHERE LNIATA > '000000' AND RouteName = '" + SearchBy +
					"' UNION SELECT LNIATA,WSName,LogFile,RouteName FROM OfepRouteInfo" +
					" WHERE LNIATA > '000000' AND RouteName = '" + SearchBy +
                    "' ORDER BY LNIATA";
			Common.Database db = new Database();
			DataSet MyDS = db.MyFillDataSet(cmd, "AuditLog");
            db.Dispose();
            if (MyDS == null)
			    return;
			pnlInput.Visible=false;
			pnlOutput.Visible=true;
			lblTitle.Text="LNIATAs searched by: " + SearchBy;
			dgLog.DataSource = MyDS;
			dgLog.DataBind();
		}

		protected void rbLNIATA_CheckedChanged(object sender, System.EventArgs e)
		{
			lblByType.Text="LNIATA: ";
			txbSearchBy.Text="";
            txbSearchBy.Focus();
		}

		protected void rbType_CheckedChanged(object sender, System.EventArgs e)
		{
			lblByType.Text="Route Name: ";
			txbSearchBy.Text="";
            txbSearchBy.Focus();
		}
	}
}
