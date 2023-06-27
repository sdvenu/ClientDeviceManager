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
	/// Select all workstations having a given LNIATA.
	/// </summary>
	public partial class SP_ListAllTAs : Web.PageBase
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            LoginIfNotLoggedIn();

			if (!IsPostBack)
			{
				// Put user code to initialize the page here
				Common.Database db = new Database();
				string cmd = "SELECT LNIATA,WSName,LogFile,RouteName FROM HsspRouteInfo" +
					" WHERE LNIATA > '000000'" +
					" UNION SELECT LNIATA,WSName,LogFile,RouteName FROM OfepRouteInfo" +
					" WHERE LNIATA > '000000'" +
                    " ORDER BY LNIATA";
				DataSet MyDS = db.MyFillDataSet(cmd, "RouteInfotbl");
                db.Dispose();
                if (MyDS == null)
					return;

				dgAllTAs.DataSource = MyDS;
				dgAllTAs.DataBind();
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

		protected void dgAllTAs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		public void PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
		{
			Common.Database db = new Common.Database();
			string cmd = "SELECT LNIATA,WSName,LogFile,RouteName FROM HsspRouteInfo" +
				" WHERE LNIATA > '000000'" +
				" UNION SELECT LNIATA,WSName,LogFile,RouteName FROM OfepRouteInfo" +
				" WHERE LNIATA > '000000' ORDER BY LNIATA";
			DataSet MyDS = db.MyFillDataSet(cmd, "RouteInfotbl");
            db.Dispose();
            if (MyDS == null)
				return;

            dgAllTAs.CurrentPageIndex= e.NewPageIndex;
			dgAllTAs.DataSource = MyDS;
			dgAllTAs.DataBind();
		}
	}
}
