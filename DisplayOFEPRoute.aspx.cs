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
using ClientDeviceMgr.SystemFramework;


namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for OFEPRoute.
	/// </summary>
	public partial class DisplayOFEPRoute : Web.PageBase
	{
		protected string WSName = null;
		protected string RouteName = null;
		protected int g_iState = 0;
		protected const String OFEP_ROUTE_INFO_TBL = "OfepRouteInfo";
		protected const String MAIN_ROUTE_INFO_TBL = "MainRouteConfigTable";

		protected void Page_Load(object sender, System.EventArgs e)
		{
            LoginIfNotLoggedIn();
            WSName = SelectWorkstationIfNoneSelected();

			try
			{
				RouteName = (string)Session["RouteName"];
			}
			catch(Exception b)
			{
				string msg = b.ToString();
				RouteName = null;
			}

            //now lets get our RouteName out of the query string...
			if (!ReadQueryString(out RouteName))
			{
				Response.Redirect("ConfigureRoute.aspx", true);
				return;
			}

			int iPageState = 0;

			try
			{
                object item = Session["OFEPRoutePageState"];
                if (null == item)
    				Session["OFEPRoutePageState"] = 1;
                else
    				iPageState = (int)item;
			}
			catch(Exception a)
			{
				string s = a.ToString();
				iPageState = 0;
				Session["OFEPRoutePageState"] = 1;
			}

			if (iPageState == 0)
				iPageState = 1;

			if (!IsPostBack)
			{
                SetupPages(iPageState);			
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

		private void SetupPages(int iState)
		{
			switch(iState)
			{
				case 1:
				{
					// Put user code to initialize the page here
					PanelBasic.Visible = true;
					PanelNetwork.Visible = false;
					PanelDebug.Visible = false;
					PanelBasic.Style["left"] = "220px";
					PanelBasic.Style["Top"] = "100px";
					InitBasicForm();
				}
					break;

				case 2:
				{
					PanelBasic.Visible = false;
					PanelNetwork.Visible = true;
					PanelDebug.Visible = false;
					PanelNetwork.Style["left"] = "220px";
					PanelNetwork.Style["Top"] = "100px";
					InitNetworkForm();
				}
					break;

				case 3:
				{
					PanelBasic.Visible = false;
					PanelNetwork.Visible = false;
					PanelDebug.Visible = true;
					PanelDebug.Style["left"] = "220px";
					PanelDebug.Style["Top"] = "100px";
					InitDebugForm();
				}
					break;

				default:
					break;
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

		protected void btnbaicCancel_Click(object sender, System.EventArgs e)
		{
			DeleteSessionRouteKey();
			Response.Redirect("ConfigureRoute.aspx", true);
		}

		protected void btnbasicNext_Click(object sender, System.EventArgs e)
		{
			//OK let's forward our page to the next page...
			Session["OFEPRoutePageState"] = 2;

			//let's update what we have into our session variable...
			DataTable RouteTable = GetRouteDataSet();

            RouteTable.Rows[0]["LNIATA"] = txtboxLNIATA.Text.Trim().ToUpper();
			RouteTable.Rows[0]["POOLCLASS"] = txtboxClassName.Text.Trim().ToUpper();
            RouteTable.Rows[0]["KEEPALIVE"] =
                ckboxKeepAlive.Checked ? "1" : "0";

			UpdateRouteDataSet(RouteTable);
			string URL = "OfepRoute.aspx?ROUTENAME=" + RouteName.Trim();
			Response.Redirect(URL, true);
		}

		private void InitDebugForm()
		{
			DataTable RouteTable = GetRouteDataSet();
			if (RouteTable == null)
				return;

			string Temp = "";
			Temp = RouteTable.Rows[0]["LOGGING"].ToString().Trim();
            if (string.IsNullOrEmpty(Temp))
			{
				ckboxTraceActive.Checked = false;
			}
			else
			{
				if (Temp.Trim() == "1")
					ckboxTraceActive.Checked = true;
				else
					ckboxTraceActive.Checked = false;
			}
			//let's get the max size of our logfile...
			Temp = RouteTable.Rows[0]["MAXLOGFILESIZE"].ToString().Trim();
            if (string.IsNullOrEmpty(Temp))
			{
				txtboxLogSize.Text = "1000"; //1 megabyte...
			}
			else
			{
				int iSize = Int32.Parse(Temp.Trim());
				iSize = (iSize / 1000);
				Temp = string.Concat(iSize);				
				txtboxLogSize.Text = Temp.Trim();
			}
			//Let's get the location of our logfile...
			Temp = RouteTable.Rows[0]["LOGFILE"].ToString().Trim();
            if (string.IsNullOrEmpty(Temp))
			{
				txtboxLogFilePath.Text = Global.ConfigurationFolder + "OFEP.LOG";
			}
			else
			{
				txtboxLogFilePath.Text = Temp.Trim();
			}
		}

		private void InitNetworkForm()
		{
			DataTable RouteTable = GetRouteDataSet();
			if (RouteTable == null)
				return;

			string Temp = "";

			Temp = RouteTable.Rows[0]["LB1"].ToString().Trim();
            if (string.IsNullOrEmpty(Temp))
			{
				txtlb1.Text = "LB1.DCS.AMRCORP.COM";
			}
			else
			{
				txtlb1.Text = Temp.Trim();
			}
			Temp = RouteTable.Rows[0]["LB2"].ToString().Trim();
            if (string.IsNullOrEmpty(Temp))
			{
				txtlb2.Text = "LB2.DCS.AMRCORP.COM";
			}
			else
			{
				txtlb2.Text = Temp.Trim();
			}
			Temp = RouteTable.Rows[0]["LBPORT"].ToString().Trim();
            if (string.IsNullOrEmpty(Temp))
			{
				txtboxTCPPort.Text = "12001";
			}
			else
			{
				txtboxTCPPort.Text = Temp.Trim();
			}
		}

		private void InitBasicForm()
		{
			DataTable RouteTable = GetRouteDataSet();
			if ((RouteTable == null) || (RouteTable.Rows.Count == 0))
				return;

			string Temp = "";

			//let's get our LNIATA information...
			Temp = RouteTable.Rows[0]["LNIATA"].ToString().Trim();
			if (!string.IsNullOrEmpty(Temp))
			{
				txtboxLNIATA.Text = Temp;
			}
			
			//let's get our ClassName...
			Temp = RouteTable.Rows[0]["POOLCLASS"].ToString().Trim();
			if (!string.IsNullOrEmpty(Temp))
			{
				txtboxClassName.Text = Temp;
			}

			//let's get our keep alive value...
			Temp = RouteTable.Rows[0]["KEEPALIVE"].ToString().Trim();
			if (!string.IsNullOrEmpty(Temp))
			{
                ckboxKeepAlive.Checked = (Temp.Trim() == "1");
			}
			else
				ckboxKeepAlive.Checked = false;
		}

		private void UpdateRouteDataSet(DataTable dt)
		{
			string SessKey = RouteName.Trim() + WSName.Trim() + "OfepRouteDataTable";
			Session[SessKey.Trim()] = dt;
		}

		private DataTable GetRouteDataSet()
		{
			string SessKey = RouteName.Trim() + WSName.Trim() + "OfepRouteDataTable";
			DataTable dt = null;
			try
			{
				dt = (DataTable) Session[SessKey.Trim()];
			}
			catch(Exception e)
			{
				string s = e.ToString();
				dt = null;
			}
			if ((dt != null) && (dt.Rows.Count > 0))
				return dt;

			Common.Database db = new Database();
			string cmd = "SELECT * FROM OfepRouteInfo WHERE RouteName = '" +
				RouteName.Trim() + "' AND WSNAME = '" + WSName.Trim() +
                "' ORDER BY RouteName DESC";
            DataSet myDS = db.MyFillDataSet(cmd, OFEP_ROUTE_INFO_TBL);
            db.Dispose();
			if (myDS == null)
				return null;

			dt = myDS.Tables[OFEP_ROUTE_INFO_TBL];
			if (dt.Rows.Count > 0)
				Session[SessKey] = dt;
			else
			{
				//let's build our data table to operate upon...
				DataRow myRow = dt.NewRow();
				dt.Rows.Add(myRow);
				dt.AcceptChanges();
				Session[SessKey] = dt;
				

			}
			return dt;
		}

		private void DeleteSessionRouteKey()
		{
			string SessKey = RouteName.Trim() + WSName.Trim() + "OfepRouteDataTable";
			try
			{
				Session.Remove(SessKey);
			}
			catch(Exception e)
			{
				string msg = e.ToString();
			}
		}

		protected void pnlNetworkNext_Click(object sender, System.EventArgs e)
		{
			Session["OFEPRoutePageState"] = 3;
			//let's update what we have into our session variable...
			DataTable RouteTable = GetRouteDataSet();
			string temp = txtlb1.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(temp))
			{
				RouteTable.Rows[0]["LB1"] = "LB1.DCS.AMRCORP.COM";
			}
			else
			{
				RouteTable.Rows[0]["LB1"] = temp;
			}
			temp = txtlb2.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(temp))
			{
				RouteTable.Rows[0]["LB2"] = "LB2.DCS.AMRCORP.COM";
			}
			else
			{
				RouteTable.Rows[0]["LB2"] = temp;
			}
			temp = txtboxTCPPort.Text.Trim();
            if (string.IsNullOrEmpty(temp))
			{
				RouteTable.Rows[0]["LBPORT"] = "12001";
			}
			else
			{
				RouteTable.Rows[0]["LBPORT"] = temp;
			}
			string URL = "OfepRoute.aspx?ROUTENAME=" + RouteName.Trim();
			Response.Redirect(URL, true);     		
		}

		protected void pnlNetworkBack_Click(object sender, System.EventArgs e)
		{
			Session["OFEPRoutePageState"] = 1;
			//let's update what we have into our session variable...
			DataTable RouteTable = GetRouteDataSet();
			string temp = txtlb1.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(temp))
			{
				RouteTable.Rows[0]["LB1"] = "LB1.DCS.AMRCORP.COM";
			}
			else
			{
				RouteTable.Rows[0]["LB1"] = temp;
			}
			temp = txtlb2.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(temp))
			{
				RouteTable.Rows[0]["LB2"] = "LB2.DCS.AMRCORP.COM";
			}
			else
			{
				RouteTable.Rows[0]["LB2"] = temp;
			}
			temp = txtboxTCPPort.Text.Trim();
            if (string.IsNullOrEmpty(temp))
			{
				RouteTable.Rows[0]["LBPORT"] = "12001";
			}
			else
			{
				RouteTable.Rows[0]["LBPORT"] = temp;
			}
			string URL = "OfepRoute.aspx?ROUTENAME=" + RouteName.Trim();
			Response.Redirect(URL, true);            		
		}

		protected void pnlNetworkCancel_Click(object sender, System.EventArgs e)
		{
			Session["OFEPRoutePageState"] = 1;
			DeleteSessionRouteKey();
			Response.Redirect("ConfigureRoute.aspx", true);		
		}

		protected void btnDbgOK_Click(object sender, System.EventArgs e)
		{
			DataTable dt = GetRouteDataSet();
			if (ckboxTraceActive.Checked == true)
			{
				dt.Rows[0]["LOGGING"] = "1";
			}
			else
			{
				dt.Rows[0]["LOGGING"] = "0";
			}

			dt.Rows[0]["MAXLOGFILESIZE"] = txtboxLogSize.Text.Trim();

			dt.Rows[0]["LOGFILE"] = txtboxLogFilePath.Text.Trim();

			if (UpdateConfigurationInformation())
			{
				DeleteSessionRouteKey();
				Session["OFEPRoutePageState"] = 0;
				Response.Redirect("ConfigureRoute.aspx", true);
			}

		
		}

		protected void btnDbgCancel_Click(object sender, System.EventArgs e)
		{
			Session["OFEPRoutePageState"] = 1;
			DeleteSessionRouteKey();
			Response.Redirect("ConfigureRoute.aspx", true);				
		}

		protected void btnDbgBack_Click(object sender, System.EventArgs e)
		{
			Session["OFEPRoutePageState"] = 2;
			string URL = "OfepRoute.aspx?ROUTENAME=" + RouteName.Trim();
			Response.Redirect(URL, true);
		}

		private bool UpdateConfigurationInformation()
		{
			Common.Database db = new Database();
			DataTable dt = GetRouteDataSet();
			string tempbuffer = "";
			string cmd = null;
			string maxlogfilesize = "1000000";
			string logging = "0";
			string logfile = Global.ConfigurationFolder + "OFEP.LOG";
			string lniata = "";
			string LB1 = "";
			string LB2 = "";
			string LBPort = "12001";
			string poolclass = "";
			string keepalive = "0";

			keepalive = dt.Rows[0]["KEEPALIVE"].ToString().Trim();
			poolclass = dt.Rows[0]["POOLCLASS"].ToString().Trim();

			tempbuffer = dt.Rows[0]["MAXLOGFILESIZE"].ToString().Trim();
            if (string.IsNullOrEmpty(tempbuffer))
			{
				maxlogfilesize = "1000000";
			}
			else
			{
				int tempsize = Int32.Parse(tempbuffer);
				tempsize = (tempsize * 1000);
				maxlogfilesize = string.Concat(tempsize);
			}
            
			logging = dt.Rows[0]["LOGGING"].ToString().Trim();
			logfile = dt.Rows[0]["LOGFILE"].ToString().Trim();
			lniata = dt.Rows[0]["LNIATA"].ToString().Trim();
            if (string.IsNullOrEmpty(lniata))
				lniata = "000000";

			LBPort = dt.Rows[0]["LBPORT"].ToString().Trim();
            if (string.IsNullOrEmpty(LBPort))
				LBPort = "12001";

			LB1 = dt.Rows[0]["LB1"].ToString().Trim();
            if (string.IsNullOrEmpty(LB1))
				LB1 = "LB1.DCS.AMRCORP.COM";

			LB2 = dt.Rows[0]["LB2"].ToString().Trim();
            if (string.IsNullOrEmpty(LB2))
				LB2 = "LB2.DCS.AMRCORP.COM";

			string RouteQuerycmd = "SELECT * FROM " + OFEP_ROUTE_INFO_TBL +
                " WHERE WSName = '" + WSName.Trim() +
				"' AND RouteName = '" + RouteName.Trim() +
                "' ORDER BY RouteName DESC";

			string RouteInsertcmd = "INSERT INTO " + OFEP_ROUTE_INFO_TBL +
				"(LNIATA,LB1,LB2,LBPORT,MAXLOGFILESIZE,LOGGING,LOGFILE,POOLCLASS,KEEPALIVE,RouteName,WSNAME)" +
				" VALUES('" + lniata.Trim() 
				+ "','" + LB1.Trim() 
				+ "','" + LB2.Trim() 
				+ "','" + LBPort.Trim() 
				+ "','" + maxlogfilesize.Trim() 
				+ "','" + logging.Trim() 
				+ "','" + logfile.Trim() 
				+ "','" + poolclass.Trim() 
				+ "','" + keepalive.Trim() 
				+ "','" + RouteName.Trim() 
				+ "','" + WSName.Trim() + "')";

			string MainRouteQueryCmd = "SELECT * FROM " + MAIN_ROUTE_INFO_TBL +
                " WHERE WSName = '" + WSName.Trim() +
				"' AND RouteName = '" + RouteName.Trim() + "'";

			string MainRouteInsertCmd = "INSERT INTO " + MAIN_ROUTE_INFO_TBL +
				"(RouteName,Enabled,WSNAME,PROTOCOL)" +
				" VALUES('"
                + RouteName.Trim()
                + "','1','"
                + WSName.Trim()
                + "','OFEP')";

			cmd = "DELETE FROM " + MAIN_ROUTE_INFO_TBL +
                " WHERE WSName = '" + WSName.Trim() +
				"' AND RouteName = '" + RouteName.Trim() + "'";

			db.MyUpdateDataExecuteNonQuery(cmd);

			if (!db.CreateTableIfNotExist(RouteQuerycmd, RouteInsertcmd, OFEP_ROUTE_INFO_TBL))
				return false;

			if (!db.CreateTableIfNotExist(MainRouteQueryCmd, MainRouteInsertCmd, MAIN_ROUTE_INFO_TBL))
				return false;

			//now let's build up our update command...
			cmd = "UPDATE " + OFEP_ROUTE_INFO_TBL + " SET LNIATA = '" +
				lniata.Trim() + "', LB1 = '" + LB1.Trim() + "', LB2 = '" +
				LB2.Trim() + "', LBPORT = '" + LBPort.Trim() + "', MAXLOGFILESIZE = '" +
				maxlogfilesize.Trim() + "', LOGGING = '" + logging.Trim() +
				"', LOGFILE = '" + logfile.Trim() + "', POOLCLASS = '" + 
				poolclass.Trim() + "', KEEPALIVE = '" + keepalive.Trim() +
				"' WHERE RouteName = '" + RouteName.Trim() + "' AND WSNAME = '" +
				WSName.Trim() + "'";

			int result = db.MyUpdateDataExecuteNonQuery(cmd);
			if (result > 0)
				return true;

			return false;
		}

	}
}
