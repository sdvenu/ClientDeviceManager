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
	/// Summary description for HsspRoute.
	/// </summary>
	public partial class DisplayHsspRoute : Web.PageBase
	{
		protected string WSName = null;
		protected string RouteName = null;
		protected int g_iState = 0;
		protected const String HSSP_ROUTE_INFO_TBL = "HsspRouteInfo";
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
				Response.Redirect("DisplayRoute.aspx", true);
				return;
			}

			int iPageState = 0;

			try
			{
                object item = this["HSSPRoutePageState"];
                if (null == item)
    				this["HSSPRoutePageState"] = 1;
                else
    				iPageState = (int)item;
			}
			catch(Exception a)
			{
				string s = a.ToString();
				iPageState = 0;
				this["HSSPRoutePageState"] = 1;
			}

			if (iPageState <= 0)
				iPageState = 1;

			if (!IsPostBack)
			{
				SetupPages(iPageState);			
			}
		}

		private bool ReadQueryString(out string route)
		{
			route = Request.QueryString["ROUTENAME"].ToString().Trim();
            return !string.IsNullOrEmpty(route);
		}

		private void SetupPages(int iState)
		{
            Panel[] AllPanels = new Panel[] { pnlBasic, pnlNetwork, pnlDebug, pnlEncryption };

            if (iState <= 0 || AllPanels.Length < iState)
                iState = 1;

            // Select the panel to be visible.
            foreach (Panel pnl in AllPanels)
                pnl.Visible = false;
            AllPanels[iState-1].Visible = true;

            // Position the panel on the page.
            AllPanels[iState-1].Style["Left"] = "220px";
            AllPanels[iState-1].Style["Top"] = "100px";

            switch (iState)
			{
			case 1:
				pnlGeneral_Init();
				break;

			case 2:
				pnlNetwork_Init();
				break;

			case 3:
				pnlDebug_Init();
				break;

            case 4:
                pnlEncryption_Init();
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

        private void DeleteSessionRouteKey()
        {
            // The key will be automatically deleted when user moves off of this page.
            //string SessKey = RouteName.Trim() + WSName.Trim() + "HsspRouteDataTable";
            //try
            //{
            //    Session.Remove(SessKey);
            //}
            //catch (Exception e)
            //{
            //    string msg = e.ToString();
            //}
        }

        private DataTable GetRouteDataSet()
        {
            string SessKey = RouteName.Trim() + WSName.Trim() + "HsspRouteDataTable";
            DataTable dt = null;
            try
            {
                dt = (DataTable)this[SessKey];
            }
            catch (Exception e)
            {
                string s = e.ToString();
                dt = null;
            }
            if ((dt != null) && (dt.Rows.Count > 0))
                return dt;

            try
            {
                Common.Database db = new Database();
                string cmd = "SELECT * FROM " + HSSP_ROUTE_INFO_TBL +
                    " WHERE RouteName = '" + RouteName.Trim() +
                    "' AND WSNAME = '" + WSName.Trim() +
                    "' ORDER BY DEVTYPE DESC, RouteName DESC";
                DataSet myDS = db.MyFillDataSet(cmd, HSSP_ROUTE_INFO_TBL);
                db.Dispose();
                if (null == myDS)
                {
                    dt = null;
                }
                else
                {
                    dt = myDS.Tables[HSSP_ROUTE_INFO_TBL];
                    if (0 < dt.Rows.Count)
                        this[SessKey] = dt;
                    else
                    {
                        //let's build our data table to operate upon...
                        DataRow myRow = dt.NewRow();
                        dt.Rows.Add(myRow);
                        dt.AcceptChanges();
                        this[SessKey] = dt;
                    }
                }
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        private void DisableAllPooling()
        {
            DisableAgencyPooling();
            DisableHostPooling();
        }

        private void EnableAgencyPooling()
        {
            //txtboxBCC.ReadOnly = false;
            //txtboxBCC.BackColor = System.Drawing.Color.White;
            //txtboxBranchPCC.ReadOnly = false;
            //txtboxBranchPCC.BackColor = System.Drawing.Color.White;
            rbAgencyPooling.Checked = true;
        }

        private void DisableAgencyPooling()
        {
            //txtboxBCC.ReadOnly = true;
            //txtboxBranchPCC.ReadOnly = true;
            //txtboxBCC.BackColor = System.Drawing.Color.Gray;
            //txtboxBranchPCC.BackColor = System.Drawing.Color.Gray;
            rbAgencyPooling.Checked = false;
        }

        private void EnableHostPooling()
        {
            //txtboxHostPoolName.ReadOnly = false;
            //txtboxHostPoolName.BackColor = System.Drawing.Color.White;
            //txtboxProfileKey.ReadOnly = false;
            //txtboxProfileKey.BackColor = System.Drawing.Color.White;
            //txtboxCityCode.ReadOnly = false;
            //txtboxCityCode.BackColor = System.Drawing.Color.White;
            //txtboxPartition.ReadOnly = false;
            //txtboxPartition.BackColor = System.Drawing.Color.White;
            rbHostPooling.Checked = true;
            DataTable dt = GetRouteDataSet();
            if ((null != dt) && (0 < dt.Rows.Count))
            {
                txtboxHostPoolName.Text = dt.Rows[0]["POOLNAME"].ToString().Trim();
                txtboxProfileKey.Text = dt.Rows[0]["KEYNAME"].ToString().Trim();
                txtboxCityCode.Text = dt.Rows[0]["CITYCODE"].ToString().Trim();
                txtboxPartition.Text = dt.Rows[0]["PARTITION"].ToString().Trim();
            }
        }

        private void DisableHostPooling()
        {
            //txtboxHostPoolName.ReadOnly = true;
            //txtboxHostPoolName.BackColor = System.Drawing.Color.Gray;
            //txtboxProfileKey.ReadOnly = true;
            //txtboxProfileKey.BackColor = System.Drawing.Color.Gray;
            //txtboxCityCode.ReadOnly = true;
            //txtboxCityCode.BackColor = System.Drawing.Color.Gray;
            //txtboxPartition.ReadOnly = true;
            //txtboxPartition.BackColor = System.Drawing.Color.Gray;
            rbHostPooling.Checked = false;
        }

        private void pnlGeneral_Init()
        {
            DataTable RouteTable = GetRouteDataSet();
            if ((null == RouteTable) || (0 == RouteTable.Rows.Count))
                return;

            string field = "";

            //OK let's see what we need to populate for the Device Type...
            field = RouteTable.Rows[0]["DEVTYPE"].ToString().Trim();
            if ((field != null) && (field.Trim().Length != 0))
            {
                if (field.Trim() == "TERMINAL")
                {
                    rbTerminal.Checked = true;
                    rbPrinter.Checked = false;
                }
                else if (field.Trim() == "PRINTER")
                {
                    rbTerminal.Checked = false;
                    rbPrinter.Checked = true;
                }
                else
                {
                    rbTerminal.Checked = false;
                    rbPrinter.Checked = false;
                }
            }
            //let's get our LNIATA information...
            field = RouteTable.Rows[0]["LNIATA"].ToString().Trim();
            if (!string.IsNullOrEmpty(field))
            {
                txtboxLNIATA.Text = field;
                if (field != "000000")
                {
                    DisableAllPooling();
                }
                else
                {
                    //let's figure out what pooling mode we are in...
                    field = RouteTable.Rows[0]["POOLTYPE"].ToString().Trim().ToUpper();
                    if ((field == "AGENCY") || (field == "EXTAGENCY"))
                    {
                        EnableAgencyPooling();
                        DisableHostPooling();
                    }
                    else
                    {
                        EnableHostPooling();
                        DisableAgencyPooling();
                    }
                }
            }
        }

        protected void pnlGeneral_Cancel_Click(object sender, System.EventArgs e)
        {
            this["HSSPRoutePageState"] = 1;
            DeleteSessionRouteKey();
            Response.Redirect("DisplayRoute.aspx", true);
        }

        protected void pnlGeneral_Next_Click(object sender, System.EventArgs e)
		{
			//OK let's forward our page to the next page...
			this["HSSPRoutePageState"] = 2;
            string URL = "DisplayHsspRoute.aspx?ROUTENAME=" + RouteName.Trim();
            Response.Redirect(URL, true);
        }

        private void pnlNetwork_Init()
        {
            DataTable RouteTable = GetRouteDataSet();
            if ((null == RouteTable) || (0 == RouteTable.Rows.Count))
                return;

            string field = "";

            //let's setup our default host stuff...
            field = RouteTable.Rows[0]["DEFAULTHOST"].ToString().Trim();
            txtboxDefaultHost.Text =
                string.IsNullOrEmpty(field)
                ? Global.DefaultHost
                : field;

            //let's get our Segment Override values...
            field = RouteTable.Rows[0]["SEGMENTOVERRIDE"].ToString().Trim();
            ckboxSegOverride.Checked =
                !string.IsNullOrEmpty(field) && ("1" == field);

            //let's get our Session Persistence stuff...
            field = RouteTable.Rows[0]["KEEPALIVE"].ToString().Trim();
            ckboxSessionPersistent.Checked =
                !string.IsNullOrEmpty(field) && ("1" == field);

            //let's get our LDAP setting...
            field = RouteTable.Rows[0]["NOLDAP"].ToString().Trim();
            ckboxLDAP.Checked =
                !string.IsNullOrEmpty(field) && ("0" == field);

            // See if this and all host connections should be encrypted.
            // TLS Enhancement
            field = RouteTable.Rows[0]["SSL"].ToString().Trim();
            ckboxSSL.Checked =
                !string.IsNullOrEmpty(field) && ("1" == field);
        }

        protected void pnlNetwork_Cancel_Click(object sender, System.EventArgs e)
        {
            this["HSSPRoutePageState"] = 1;
            DeleteSessionRouteKey();
            Response.Redirect("DisplayRoute.aspx", true);
        }

        protected void pnlNetwork_Back_Click(object sender, System.EventArgs e)
        {
            this["HSSPRoutePageState"] = 1;
            string URL = "DisplayHsspRoute.aspx?ROUTENAME=" + RouteName.Trim();
            Response.Redirect(URL, true);
        }

        protected void pnlNetwork_Next_Click(object sender, System.EventArgs e)
        {
            this["HSSPRoutePageState"] = 3;
            string URL = "DisplayHsspRoute.aspx?ROUTENAME=" + RouteName.Trim();
            Response.Redirect(URL, true);
        }

        private void pnlDebug_Init()
        {
            DataTable RouteTable = GetRouteDataSet();
            if ((null == RouteTable) || (0 == RouteTable.Rows.Count))
                return;

            string field = "";

            // Let's get the state of our logging.
            field = RouteTable.Rows[0]["LOGGING"].ToString().Trim();
            ckboxTracing.Checked =
                (!string.IsNullOrEmpty(field) && (field == "1"));

            // Let's get our NOFEP tracing.
            field = RouteTable.Rows[0]["DEBUG"].ToString().Trim();
            ckboxOpt7Tracing.Checked =
                (!string.IsNullOrEmpty(field) && (field == "1"));

            // Let's get our E2E logging state.
            field = RouteTable.Rows[0]["ENDTOENDLOGGING"].ToString().Trim();
            ckboxE2ETracing.Checked =
                (!string.IsNullOrEmpty(field) && (field == "1"));

            // Let's get the location of our logfile.
            field = RouteTable.Rows[0]["LOGFILE"].ToString().Trim();
            txtboxLogFilePath.Text =
                string.IsNullOrEmpty(field)
                ? (Global.ConfigurationFolder + "HSSP.LOG")
                : field;

            // Let's get the max size of our logfile.
            field = RouteTable.Rows[0]["MAXLOGFILESIZE"].ToString().Trim();
            int fieldSize = 0;
            txtboxLogFileSize.Text =
                (string.IsNullOrEmpty(field) ||
                 !int.TryParse(field, out fieldSize))
                ? "1000" // 1 megabyte
                : (fieldSize / 1000).ToString();
        }

        protected void pnlDebug_Cancel_Click(object sender, System.EventArgs e)
        {
            this["HSSPRoutePageState"] = 1;
            DeleteSessionRouteKey();
            Response.Redirect("DisplayRoute.aspx", true);
        }

        protected void pnlDebug_Back_Click(object sender, System.EventArgs e)
        {
            this["HSSPRoutePageState"] = 2;
            string URL = "DisplayHsspRoute.aspx?ROUTENAME=" + RouteName.Trim();
            Response.Redirect(URL, true);
        }

        protected void pnlDebug_Next_Click(object sender, System.EventArgs e)
        {
            this["HSSPRoutePageState"] = 4;
            string URL = "DisplayHsspRoute.aspx?ROUTENAME=" + RouteName.Trim();
            Response.Redirect(URL, true);
        }

        // TLS Enhancement
        private void pnlEncryption_Init()
        {
            DataTable RouteTable = GetRouteDataSet();
            if ((null == RouteTable) || (0 == RouteTable.Rows.Count))
                return;

            string field = "";

            // See if the SSL logfile should be written.
            field = RouteTable.Rows[0]["SSLLOGGING"].ToString().Trim();
            ckboxSSLLogging.Checked =
                !string.IsNullOrEmpty(field) && (field == "1");

            // Get the file specification of the SSL logfile.
            field = RouteTable.Rows[0]["SSLLOGFILE"].ToString().Trim();
            txtboxSSLLogFile.Text =
                string.IsNullOrEmpty(field)
                ? (Global.ConfigurationFolder + "SSL.LOG")
                : field;

            // Get the maximum size of the SSL logfile.
            field = RouteTable.Rows[0]["SSLMAXLOGFILESIZE"].ToString().Trim();
            int tempSize = 0;
            txtboxLogFileSize.Text =
                (string.IsNullOrEmpty(field) ||
                 !int.TryParse(field, out tempSize))
                ? "1000" // 1 megabyte as kilobytes
                : (tempSize / 1000).ToString(); // megabytes to kilobytes

            // Get the time to wait for SSL handshaking.
            field = RouteTable.Rows[0]["SSLHANDSHAKETIMEOUT"].ToString().Trim();
            tempSize = 0;
            txtboxLogFileSize.Text =
                (string.IsNullOrEmpty(field) ||
                 !int.TryParse(field, out tempSize) ||
                 tempSize < 1 ||
                 9999 < tempSize)
                ? "" // use the built-in default
                : tempSize.ToString(); // milliseconds
        }

        protected void pnlEncryption_Cancel_Click(object sender, System.EventArgs e)
        {
            this["HSSPRoutePageState"] = 1;
            DeleteSessionRouteKey();
            Response.Redirect("ConfigureRoute.aspx", true);
        }

        protected void pnlEncryption_Back_Click(object sender, System.EventArgs e)
        {
            this["HSSPRoutePageState"] = 3;
            string URL = "DisplayHsspRoute.aspx?ROUTENAME=" + RouteName.Trim();
            Response.Redirect(URL, true);
        }
	}
}
