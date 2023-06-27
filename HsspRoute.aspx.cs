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
	public partial class HsspRoute : Web.PageBase
	{
		protected string WSName = null;
		protected string RouteName = null;
		protected int g_iState = 0;
		protected const String HSSP_ROUTE_INFO_TBL = "HsspRouteInfo";
		protected const String MAIN_ROUTE_INFO_TBL = "MainRouteConfigTable";
		// initial variables for logging
		private string UserIP = "";
		private string HostName = "";
		private string WebForm = "HsspRoute";
		private string actcmd = "";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			UserIP = Request.UserHostAddress;
			HostName = Request.UserHostName;

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
            Panel[] AllPanels = new Panel[] { pnlGeneral, pnlNetwork, pnlDebug, pnlEncryption };

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

		protected void rbHostPooling_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbHostPooling.Checked == true)
			{
                txtboxLNIATA.Text = "000000";
				EnableHostPooling();
				DisableAgencyPooling();
			}
		}

		protected void rbAgencyPooling_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbAgencyPooling.Checked == true)
			{
                txtboxLNIATA.Text = "000000";
                DisableHostPooling();
				EnableAgencyPooling();
			}
		}

		protected void rbPrinter_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbPrinter.Checked == true)
			{
				rbTerminal.Checked = false;
				DisableHostPooling();
				DisableAgencyPooling();
				rbHostPooling.Enabled = false;
				rbAgencyPooling.Enabled = false;
			}
		}

		protected void rbTerminal_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbTerminal.Checked == true)
			{
				rbPrinter.Checked = false;
				rbHostPooling.Enabled = true;
				rbAgencyPooling.Enabled = true;
			}
		}

		private void DeleteSessionRouteKey()
		{
            // The key will be automatically deleted when user moves off of this page.
            //string SessKey = RouteName.Trim() + WSName.Trim() + "HsspRouteDataTable";
            //try
            //{
            //    Session.Remove(SessKey);
            //}
            //catch(Exception e)
            //{
            //    string msg = e.ToString();
            //}
		}

		private void UpdateRouteDataSet(DataTable dt)
		{
			string SessKey = RouteName.Trim() + WSName.Trim() + "HsspRouteDataTable";
			this[SessKey] = dt;
		}

		private DataTable GetRouteDataSet()
		{
			string SessKey = RouteName.Trim() + WSName.Trim() + "HsspRouteDataTable";
			DataTable dt = null;
			try
			{
				dt = (DataTable)this[SessKey];
			}
			catch(Exception e)
			{
				string s = e.ToString();
				dt = null;
			}
			if ((dt != null) && (0 < dt.Rows.Count))
				return dt;

            try
            {
                Common.Database db = new Database();
                string cmd = "SELECT * FROM HsspRouteInfo" +
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
            txtboxLNIATA.Focus();
		}

		private void EnableAgencyPooling()
		{
			txtboxBCC.ReadOnly = false;
			txtboxBCC.BackColor = System.Drawing.Color.White;
			txtboxBranchPCC.ReadOnly = false;
			txtboxBranchPCC.BackColor = System.Drawing.Color.White;
			rbAgencyPooling.Checked = true;

            txtboxBCC.Focus();
		}

		private void DisableAgencyPooling()
		{
			txtboxBCC.ReadOnly = true;
			txtboxBranchPCC.ReadOnly = true;
			txtboxBCC.BackColor = System.Drawing.Color.Gray;
			txtboxBranchPCC.BackColor = System.Drawing.Color.Gray;
			rbAgencyPooling.Checked = false;
		}

		private void EnableHostPooling()
		{
			txtboxHostPoolName.ReadOnly = false;
			txtboxHostPoolName.BackColor = System.Drawing.Color.White;
			txtboxProfileKey.ReadOnly = false;
			txtboxProfileKey.BackColor = System.Drawing.Color.White;
			txtboxCityCode.ReadOnly = false;
			txtboxCityCode.BackColor = System.Drawing.Color.White;
			txtboxPartition.ReadOnly = false;
			txtboxPartition.BackColor = System.Drawing.Color.White;

            rbHostPooling.Checked = true;

			DataTable dt = GetRouteDataSet();
            if ((null != dt) && (0 < dt.Rows.Count))
            {
                txtboxHostPoolName.Text = dt.Rows[0]["POOLNAME"].ToString().Trim();
                txtboxProfileKey.Text = dt.Rows[0]["KEYNAME"].ToString().Trim();
                txtboxCityCode.Text = dt.Rows[0]["CITYCODE"].ToString().Trim();
                txtboxPartition.Text = dt.Rows[0]["PARTITION"].ToString().Trim();
            }

            txtboxHostPoolName.Focus();
		}

		private void DisableHostPooling()
		{
			txtboxHostPoolName.ReadOnly = true;
			txtboxHostPoolName.BackColor = System.Drawing.Color.Gray;
			txtboxProfileKey.ReadOnly = true;
			txtboxProfileKey.BackColor = System.Drawing.Color.Gray;
			txtboxCityCode.ReadOnly = true;
			txtboxCityCode.BackColor = System.Drawing.Color.Gray;
			txtboxPartition.ReadOnly = true;
			txtboxPartition.BackColor = System.Drawing.Color.Gray;

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
            if (!string.IsNullOrEmpty(field) && "PRINTER" == field)
            {
                rbTerminal.Checked = false;
                rbPrinter.Checked = true;
            }
            else
            {
                rbTerminal.Checked = true;
                rbPrinter.Checked = false;
            }

            //let's get our LNIATA information...
            field = RouteTable.Rows[0]["LNIATA"].ToString().Trim();
            if (string.IsNullOrEmpty(field))
            {
                txtboxLNIATA.Text = "000000";
                EnableHostPooling();
                DisableAgencyPooling();
            }
            else
            {
                txtboxLNIATA.Text = field;
                if ("000000" != field)
                {
                    DisableAllPooling();
                }
                else
                {
                    //let's figure out what pooling mode we are in...
                    field = RouteTable.Rows[0]["POOLTYPE"].ToString().Trim().ToUpper();
                    if (!string.IsNullOrEmpty(field) &&
                        (("AGENCY" == field) || ("EXTAGENCY" == field)))
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

        protected void pnlGeneral_OK_Click(object sender, System.EventArgs e)
        {
            pnlGeneral_UpdateData(sender, e);

            if (UpdateConfigurationInformation())
            {
                this["HSSPRoutePageState"] = 0;
                DeleteSessionRouteKey();
                Response.Redirect("ConfigureRoute.aspx", true);
            }
        }

        protected void pnlGeneral_Cancel_Click(object sender, System.EventArgs e)
		{
            this["HSSPRoutePageState"] = 1;
            DeleteSessionRouteKey();
			Response.Redirect("ConfigureRoute.aspx", true);
		}

        protected void pnlGeneral_Next_Click(object sender, System.EventArgs e)
        {
            // Forward to the next page.
            this["HSSPRoutePageState"] = 2;

            pnlGeneral_UpdateData(sender, e);

            string URL = "HsspRoute.aspx?ROUTENAME=" + RouteName.Trim();
            Response.Redirect(URL, true);
        }

        protected bool pnlGeneral_UpdateData(object sender, System.EventArgs e)
        {
            // Update the database table.
            DataTable RouteTable = GetRouteDataSet();
            if ((null == RouteTable) || (0 == RouteTable.Rows.Count))
                return false;

            RouteTable.Rows[0]["LNIATA"] = txtboxLNIATA.Text.Trim().ToUpper();
            RouteTable.Rows[0]["POOLNAME"] = txtboxHostPoolName.Text.Trim();
            RouteTable.Rows[0]["KEYNAME"] = txtboxProfileKey.Text.Trim();
            RouteTable.Rows[0]["CITYCODE"] = txtboxCityCode.Text.Trim();
            RouteTable.Rows[0]["PARTITION"] = txtboxPartition.Text.Trim();
            RouteTable.Rows[0]["DEVTYPE"] = rbTerminal.Checked ? "TERMINAL" : "PRINTER";

            if (rbHostPooling.Checked == true)
            {
                string pooltype = "";
                if (string.IsNullOrEmpty(RouteTable.Rows[0]["POOLNAME"].ToString()))
                {
                    pooltype = "HOST9";
                }
                else if (
                    string.IsNullOrEmpty(RouteTable.Rows[0]["KEYNAME"].ToString()) &&
                    string.IsNullOrEmpty(RouteTable.Rows[0]["CITYCODE"].ToString()) &&
                    string.IsNullOrEmpty(RouteTable.Rows[0]["PARTITION"].ToString()))
                {
                    pooltype = "HOST9";
                }
                else if (
                    !string.IsNullOrEmpty(RouteTable.Rows[0]["KEYNAME"].ToString()) &&
                    string.IsNullOrEmpty(RouteTable.Rows[0]["CITYCODE"].ToString()) &&
                    string.IsNullOrEmpty(RouteTable.Rows[0]["PARTITION"].ToString()))
                {
                    pooltype = "EXTHOST9";
                }
                else
                {
                    pooltype = "TOTALHOST9";
                }

                RouteTable.Rows[0]["POOLTYPE"] = pooltype;
            }

            UpdateRouteDataSet(RouteTable);
            return true;
        }

        private void pnlNetwork_Init()
        {
            DataTable RouteTable = GetRouteDataSet();
            if ((null == RouteTable) || (0 == RouteTable.Rows.Count))
                return;

            string field;

            // Let's setup our default host.
            field = RouteTable.Rows[0]["DEFAULTHOST"].ToString().Trim();
            txtboxDefaultHost.Text =
                string.IsNullOrEmpty(field)
                ? Global.DefaultHost
                : field;

            txtboxDefaultHost.Focus();

            // Let's get our Segment Override.
            field = RouteTable.Rows[0]["SEGMENTOVERRIDE"].ToString().Trim();
            ckboxSegOverride.Checked =
                !string.IsNullOrEmpty(field) && ("1" == field);

            // Let's get our Session Persistence.
            field = RouteTable.Rows[0]["KEEPALIVE"].ToString().Trim();
            ckboxSessionPersistent.Checked =
                !string.IsNullOrEmpty(field) && ("1" == field);

            // Let's get our LDAP setting.
            // Use LDAP if NOLDAP="0"; do not use LDAP if NOLDAP="1"
            field = RouteTable.Rows[0]["NOLDAP"].ToString().Trim();
            ckboxLDAP.Checked =
                !string.IsNullOrEmpty(field) && ("0" == field);

            // See if this and all host connections should be encrypted.
            // TLS Enhancement
            field = RouteTable.Rows[0]["SSL"].ToString().Trim();
            ckboxSSL.Checked =
                string.IsNullOrEmpty(field) || ("1" == field);
        }

        protected void pnlNetwork_OK_Click(object sender, System.EventArgs e)
		{
            pnlNetwork_UpdataData(sender, e);

            if (UpdateConfigurationInformation())
			{
				this["HSSPRoutePageState"] = 0;
                DeleteSessionRouteKey();
                Response.Redirect("ConfigureRoute.aspx", true);
			}		
		}

		protected void pnlNetwork_Cancel_Click(object sender, System.EventArgs e)
		{
			this["HSSPRoutePageState"] = 1;
			DeleteSessionRouteKey();
			Response.Redirect("ConfigureRoute.aspx", true);		
		}

		protected void pnlNetwork_Back_Click(object sender, System.EventArgs e)
		{
            // Back to the previous page.
			this["HSSPRoutePageState"] = 1;

            pnlNetwork_UpdataData(sender, e);

            string URL = "HsspRoute.aspx?ROUTENAME=" + RouteName.Trim();
			Response.Redirect(URL, true);            		
		}

		protected void pnlNetwork_Next_Click(object sender, System.EventArgs e)
		{
            // Forward to the next page.
			this["HSSPRoutePageState"] = 3;

            pnlNetwork_UpdataData(sender, e);

            string URL = "HsspRoute.aspx?ROUTENAME=" + RouteName.Trim();
            Response.Redirect(URL, true);
        }

        protected bool pnlNetwork_UpdataData(object sender, System.EventArgs e)
        {
			// Update the database table.
			DataTable RouteTable = GetRouteDataSet();
            if ((null == RouteTable) || (0 == RouteTable.Rows.Count))
                return false;

            string field;
            
            field = txtboxDefaultHost.Text.Trim();
            RouteTable.Rows[0]["DEFAULTHOST"] =
                string.IsNullOrEmpty(field)
                ? Global.DefaultHost
                : field;

            RouteTable.Rows[0]["SEGMENTOVERRIDE"] =
                ckboxSegOverride.Checked ? "1" : "0";

            RouteTable.Rows[0]["KEEPALIVE"] =
    			ckboxSessionPersistent.Checked ? "1" : "0";

            // Use LDAP if NOLDAP="0"; do not use LDAP if NOLDAP="1"
            RouteTable.Rows[0]["NOLDAP"] =
                ckboxLDAP.Checked ? "0" : "1";

            // TLS Enhancement
            RouteTable.Rows[0]["SSL"] =
                ckboxSSL.Checked ? "1" : "0";

            UpdateRouteDataSet(RouteTable);
            return true;
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

            ckboxTracing.Focus();

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

        protected void pnlDebug_OK_Click(object sender, System.EventArgs e)
		{
            pnlDebug_UpdateData(sender, e);

            if (UpdateConfigurationInformation())
			{
				this["HSSPRoutePageState"] = 0;
                DeleteSessionRouteKey();
                Response.Redirect("ConfigureRoute.aspx", true);
			}
		}

		protected void pnlDebug_Cancel_Click(object sender, System.EventArgs e)
		{
			this["HSSPRoutePageState"] = 1;
			DeleteSessionRouteKey();
			Response.Redirect("ConfigureRoute.aspx", true);		
		}

		protected void pnlDebug_Back_Click(object sender, System.EventArgs e)
		{
			this["HSSPRoutePageState"] = 2;

            pnlDebug_UpdateData(sender, e);

            string URL = "HsspRoute.aspx?ROUTENAME=" + RouteName.Trim();
			Response.Redirect(URL, true);     		
		}

        protected void pnlDebug_Next_Click(object sender, System.EventArgs e)
        {
            this["HSSPRoutePageState"] = 4;

            pnlDebug_UpdateData(sender, e);

            string URL = "HsspRoute.aspx?ROUTENAME=" + RouteName.Trim();
            Response.Redirect(URL, true);
        }

        protected bool pnlDebug_UpdateData(object sender, System.EventArgs e)
        {
            // Update the database table.
            DataTable RouteTable = GetRouteDataSet();
            if ((null == RouteTable) || (0 == RouteTable.Rows.Count))
                return false;

            string field;

            RouteTable.Rows[0]["LOGGING"] =
                ckboxTracing.Checked ? "1" : "0";

            // Let's get our NOFEP tracing value.
            RouteTable.Rows[0]["DEBUG"] =
                ckboxOpt7Tracing.Checked ? "1" : "0";

            // Let's get our E2E logging state.
            RouteTable.Rows[0]["ENDTOENDLOGGING"] =
                ckboxE2ETracing.Checked ? "1" : "0";

            // Let's get the location of our logfile.
            field = txtboxLogFilePath.Text.Trim();
            RouteTable.Rows[0]["LOGFILE"] =
                string.IsNullOrEmpty(field)
                ? (Global.ConfigurationFolder + "HSSP.LOG")
                : field;

            int fieldSize = 0;
            field = txtboxLogFileSize.Text.Trim();
            RouteTable.Rows[0]["MAXLOGFILESIZE"] =
                (string.IsNullOrEmpty(field) ||
                 !int.TryParse(field, out fieldSize))
                ? "1000000" // 1 megabyte
                : (fieldSize * 1000).ToString();

            UpdateRouteDataSet(RouteTable);
            return true;
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

            ckboxSSLLogging.Focus();

            // Get the file specification of the SSL logfile.
            field = RouteTable.Rows[0]["SSLLOGFILE"].ToString().Trim();
            txtboxSSLLogFile.Text =
                string.IsNullOrEmpty(field)
                ? (Global.ConfigurationFolder + "SSL.LOG")
                : field;

            // Get the maximum size of the SSL logfile.
            field = RouteTable.Rows[0]["SSLMAXLOGFILESIZE"].ToString().Trim();
            int tempSize = 0;
            txtboxSSLMaxLogFileSize.Text =
                (string.IsNullOrEmpty(field) ||
                 !int.TryParse(field, out tempSize))
                ? "1000" // 1 megabyte in kilobytes
                : (tempSize / 1000).ToString(); // megabytes in kilobytes

            // Get the time to wait for SSL handshaking.
            field = RouteTable.Rows[0]["SSLHANDSHAKETIMEOUT"].ToString().Trim();
            tempSize = 0;
            txtboxSSLHandshakeTimeout.Text =
                (string.IsNullOrEmpty(field) ||
                 !int.TryParse(field, out tempSize) ||
                 tempSize <= 0 ||
                 9999 < tempSize)
                ? "" // use the built-in default
                : tempSize.ToString(); // milliseconds
        }

        protected void pnlEncryption_OK_Click(object sender, System.EventArgs e)
        {
            pnlEncryption_UpdateData(sender, e);

            if (UpdateConfigurationInformation())
            {
                this["HSSPRoutePageState"] = 0;
                DeleteSessionRouteKey();
                Response.Redirect("ConfigureRoute.aspx", true);
            }
        }

        protected void pnlEncryption_Cancel_Click(object sender, System.EventArgs e)
        {
            this["HSSPRoutePageState"] = 1;
            DeleteSessionRouteKey();
            Response.Redirect("ConfigureRoute.aspx", true);
        }

        protected void pnlEncryption_Back_Click(object sender, System.EventArgs e)
        {
            // Back to the previous page.
            this["HSSPRoutePageState"] = 3;

            pnlEncryption_UpdateData(sender, e);

            string URL = "HsspRoute.aspx?ROUTENAME=" + RouteName.Trim();
            Response.Redirect(URL, true);
        }

        protected bool pnlEncryption_UpdateData(object sender, System.EventArgs e)
        {
            // Update the database table.
            DataTable RouteTable = GetRouteDataSet();
            if ((null == RouteTable) || (0 == RouteTable.Rows.Count))
                return false;

            RouteTable.Rows[0]["SSLLOGGING"] =
                ckboxSSLLogging.Checked ? "1" : "0";

            int tempSize = 0;
            string field = txtboxSSLMaxLogFileSize.Text.Trim();
            RouteTable.Rows[0]["SSLMAXLOGFILESIZE"] =
                (string.IsNullOrEmpty(field) ||
                 !int.TryParse(field, out tempSize))
                ? "1000000" // 1 megabyte as bytes
                : (tempSize * 1000).ToString(); // kilobytes to bytes

            field = txtboxSSLLogFile.Text.Trim();
            RouteTable.Rows[0]["SSLLOGFILE"] =
                string.IsNullOrEmpty(field)
                ? (Global.ConfigurationFolder + "SSL.LOG")
                : field;

            field = txtboxSSLHandshakeTimeout.Text.Trim();
            tempSize = 0;
            RouteTable.Rows[0]["SSLHANDSHAKETIMEOUT"] =
                (string.IsNullOrEmpty(field) ||
                 !int.TryParse(field, out tempSize) ||
                 tempSize <= 0 ||
                 9999 < tempSize)
                ? "" // use the built-in default
                : tempSize.ToString(); // milliseconds

            UpdateRouteDataSet(RouteTable);
            return true;
        }

        private bool UpdateConfigurationInformation()
		{
			Common.Database db = new Database();
			DataTable dt = GetRouteDataSet();
            if ((null == dt) || (0 == dt.Rows.Count))
                return false;

			string tempbuffer = "";
			string cmd = null;
			string devtype = "TERMINAL";
			string noldap = "1";
			string debug = "0";
			string maxlogfilesize = "1000000";
			string logging = "0";
			string logfile = Global.ConfigurationFolder + "HSSP.LOG";
			string e2e = "0";
			string segoverride = "0";
			string keepalive = "0";
			string defaulthost = Global.DefaultHost;
			string pooltype = "";
			string poolname = "";
			string keyname = "";
			string citycode = "";
			string partition = "";
			string port = "";
			string lniata = "";
            // TLS Enhancements
            string ssl = "";
            string ssllogging = "0";
            string ssllogfile = Global.ConfigurationFolder + "SSL.LOG";
            string sslmaxlogfilesize = "1000000";
            string sslhandshaketimeout = "";

            // TLS Enhancement - SSL
            ssl = dt.Rows[0]["SSL"].ToString().Trim();

            // TLS Enhancement - SSLMAXLOGFILESIZE
            string tempBuffer = txtboxSSLMaxLogFileSize.Text;
            int tempSize = 0;
            sslmaxlogfilesize =
                (string.IsNullOrEmpty(tempBuffer) ||
                 !int.TryParse(tempBuffer, out tempSize))
                 ? "1000000"
                 : (tempSize * 1000).ToString();

            // TLS Enhancement - SSLLOGGING
            ssllogging = ckboxSSLLogging.Checked ? "1" : "0";

            // TLS Enhancement - SSLLOGFILE
            ssllogfile = txtboxSSLLogFile.Text.Trim();

            // TLS Enhancement - SSLHANDSHAKETIMEOUT
            tempBuffer = txtboxSSLHandshakeTimeout.Text;
            tempSize = 0;
            sslhandshaketimeout =
                (string.IsNullOrEmpty(tempBuffer) ||
                 !int.TryParse(tempBuffer, out tempSize) ||
                 tempSize <= 0 ||
                 9999 < tempSize)
                ? "" // use the built-in default
                : tempSize.ToString(); // milliseconds

            devtype = dt.Rows[0]["DEVTYPE"].ToString().Trim();

            noldap = dt.Rows[0]["NOLDAP"].ToString().Trim();

            debug = ckboxOpt7Tracing.Checked ? "1" : "0";

			tempBuffer = txtboxLogFileSize.Text;
            tempSize = 0;
			if (string.IsNullOrEmpty(tempBuffer) ||
                !int.TryParse(tempBuffer, out tempSize))
			{
				maxlogfilesize = "1000000";
			}
			else
			{
                maxlogfilesize = (tempSize * 1000).ToString();
			}

            logging = ckboxTracing.Checked ? "1" : "0";

			logfile = txtboxLogFilePath.Text.Trim();

            e2e = ckboxE2ETracing.Checked ? "1" : "0";

			segoverride = dt.Rows[0]["SEGMENTOVERRIDE"].ToString().Trim();

			keepalive = dt.Rows[0]["KEEPALIVE"].ToString().Trim();

			tempbuffer = dt.Rows[0]["DEFAULTHOST"].ToString().Trim().ToUpper();
            if (string.IsNullOrEmpty(tempbuffer))
                defaulthost = Global.DefaultHost;
            else
                defaulthost = tempbuffer;

			tempbuffer = "";

			lniata = dt.Rows[0]["LNIATA"].ToString().Trim();
			if (lniata == null)
				lniata = "";

			if (lniata == "000000")
			{
				if ((dt.Rows[0]["POOLTYPE"].ToString() == "AGENCY") ||
					(dt.Rows[0]["POOLTYPE"].ToString() == "EXTAGENCY"))
				{
					port = "30032";
				}
				else if (
                    (dt.Rows[0]["POOLTYPE"].ToString() == "HOST9") ||
					(dt.Rows[0]["POOLTYPE"].ToString() == "EXTHOST9") ||
					(dt.Rows[0]["POOLTYPE"].ToString() == "TOTALHOST9"))
				{
					string hosttemp = "";
                    hosttemp = dt.Rows[0]["POOLNAME"].ToString().Trim();
					if (string.IsNullOrEmpty(hosttemp))
						hosttemp = "";
					poolname = hosttemp;

                    hosttemp = "";
					hosttemp = dt.Rows[0]["KEYNAME"].ToString().Trim();
					if (string.IsNullOrEmpty(hosttemp))
						hosttemp = "";
					keyname = hosttemp;

                    hosttemp = "";
					hosttemp = dt.Rows[0]["CITYCODE"].ToString().Trim();
					if (string.IsNullOrEmpty(hosttemp))
						hosttemp = "";
                    citycode = hosttemp;

                    hosttemp = "";
					hosttemp = dt.Rows[0]["PARTITION"].ToString().Trim();
					if (string.IsNullOrEmpty(hosttemp))
						hosttemp = "";
					partition = hosttemp;

                    //let's figure out what pooling mode we are in...
					if (string.IsNullOrEmpty(poolname))
					{
						pooltype = "HOST9";
                        poolname = "QUANTM"; // versus "DFLT01";
					}
					else if (
                        string.IsNullOrEmpty(keyname) &&
						string.IsNullOrEmpty(citycode) &&
						string.IsNullOrEmpty(partition))
					{
						pooltype = "HOST9";
					}
					else if (
                        !string.IsNullOrEmpty(keyname) &&
						string.IsNullOrEmpty(citycode) &&
						string.IsNullOrEmpty(partition))
					{
						pooltype = "EXTHOST9";
					}
					else
					{
						pooltype = "TOTALHOST9";
					}
					port = "30030";
				}
				else
				{
					pooltype = "";
					port = "30030";
				}
			}
			else
			{
				pooltype = "";
                port = (devtype.Trim() == "TERMINAL") ? "30031" : "30051";
			}

			string RouteQuerycmd = "SELECT * FROM " + HSSP_ROUTE_INFO_TBL
                + " WHERE WSName = '" + WSName.Trim() +
				"' AND RouteName = '" + RouteName.Trim() +
                "' ORDER BY DEVTYPE DESC, RouteName DESC";

			//let's create our database entry and populate the values...
			string RouteInsertcmd = "INSERT INTO " + HSSP_ROUTE_INFO_TBL +
				"(LNIATA,"
                + "DEVTYPE,"
                + "NOLDAP,"
                + "DEBUG,"
                + "MAXLOGFILESIZE,"
                + "LOGGING,"
                + "LOGFILE,"
                + "ENDTOENDLOGGING,"
                + "SEGMENTOVERRIDE,"
                + "KEEPALIVE,"
                + "DEFAULTHOST,"
                + "POOLTYPE,"
                + "POOLNAME,"
                + "KEYNAME,"
                + "CITYCODE,"
                + "PARTITION,"
                + "PORT,"
                + "SSL," // TLS Enhancement
                + "SSLLOGGING," // TLS Enhancement
                + "SSLLOGFILE," // TLS Enhancement
                + "SSLMAXLOGFILESIZE," // TLS Enhancement
                + "SSLHANDSHAKETIMEOUT," // TLS Enhancement
                + "RouteName,"
                + "WSNAME)"
				+ " VALUES('"
                + lniata.Trim()
                + "','" + devtype.Trim()
                + "','" + noldap.Trim()
                + "','" + debug.Trim()
                + "','" + maxlogfilesize.Trim()
                + "','" + logging.Trim()
                + "','" + logfile.Trim()
                + "','" + e2e.Trim()
                + "','" + segoverride.Trim()
                + "','" + keepalive.Trim()
                + "','" + defaulthost.Trim()
                + "','" + pooltype.Trim()
                + "','" + poolname.Trim()
                + "','" + keyname.Trim()
                + "','" + citycode.Trim()
                + "','" + partition.Trim()
                + "','" + port.Trim()
                + "','" + ssl.Trim() // TLS Enhancement
                + "','" + ssllogging.Trim() // TLS Enhancement
                + "','" + ssllogfile.Trim() // TLS Enhancement
                + "','" + sslmaxlogfilesize.Trim() // TLS Enhancement
                + "','" + sslhandshaketimeout.Trim() // TLS Enhancement
                + "','" + RouteName.Trim()
                + "','" + WSName.Trim()
                + "')";

			string MainRouteQueryCmd = "SELECT * FROM " + MAIN_ROUTE_INFO_TBL
                + " WHERE WSName = '" + WSName.Trim() +
				"' AND RouteName = '" + RouteName.Trim() + "'";

			string MainRouteInsertCmd = "INSERT INTO " + MAIN_ROUTE_INFO_TBL +
				"(RouteName,"
                + "Enabled,"
                + "WSNAME,"
                + "PROTOCOL)"
				+ " VALUES('"
                + RouteName.Trim()
                + "','1','"
                + WSName.Trim()
                + "','HSSP')";

			if (!db.CreateTableIfNotExist(RouteQuerycmd, RouteInsertcmd, HSSP_ROUTE_INFO_TBL))
				return false;

			if (!db.CreateTableIfNotExist(MainRouteQueryCmd, MainRouteInsertCmd, MAIN_ROUTE_INFO_TBL))
				return false;

			//now let's build up our update command...
			
			cmd = "UPDATE " + HSSP_ROUTE_INFO_TBL
                + " SET LNIATA = '" + lniata.Trim()
                + "', DEVTYPE ='" + devtype.Trim()
                + "', NOLDAP = '" + noldap.Trim()
                + "', DEBUG = '" + debug.Trim()
                + "', MAXLOGFILESIZE = '" + maxlogfilesize.Trim()
                + "', LOGGING = '" + logging.Trim()
                + "', LOGFILE = '" + logfile.Trim()
                + "', ENDTOENDLOGGING = '" + e2e.Trim()
                + "', SEGMENTOVERRIDE = '" + segoverride.Trim()
                + "', KEEPALIVE = '" + keepalive.Trim()
                + "', DEFAULTHOST = '" + defaulthost.Trim()
                + "', POOLTYPE = '" + pooltype.Trim()
                + "', POOLNAME = '" + poolname.Trim()
                + "', KEYNAME = '" + keyname.Trim()
                + "', CITYCODE = '" + citycode.Trim()
                + "', PARTITION = '" + partition.Trim()
                + "', PORT = '" + port.Trim()
                + "', SSL = '" + ssl.Trim() // TLS Enhancement
                + "', SSLLOGGING = '" + ssllogging.Trim() // TLS Enhancement
                + "', SSLLOGFILE = '" + ssllogfile.Trim() // TLS Enhancement
                + "', SSLMAXLOGFILESIZE = '" + sslmaxlogfilesize.Trim() // TLS Enhancement
                + "', SSLHANDSHAKETIMEOUT = '" + sslhandshaketimeout.Trim() // TLS Enhancement
                + "' WHERE RouteName = '" + RouteName.Trim()
                + "' AND WSName = '" + WSName.Trim() + "'";

			for(int k=0;k<cmd.Length;k++)
			{
				if (cmd[k] != '\'')
					actcmd += cmd[k];
			}

			int result = db.MyUpdateDataExecuteNonQuery(cmd);
			if (result > 0)
			{
				logAudit(actcmd,1);
				return true;
			}
			else
				logAudit(actcmd,0);

			return false;
		}

		private void logAudit(string cmd, int complete)
		{
			// function insert log into audit table, 
			// where UserID can be WSName or UserID(which is created or deleted)
			// UserName is current login userID in Session["UsrName"]
			// action log for future auditing
			Common.Database db = new Database();

            string logcmd = "INSERT INTO AuditLogtbl("
                + "UserName,"
                + "UserID,"
                + "commandStr,"
                + "WebForm,"
                + "UserIP,"
                + "HostName,"
                + "Completion)"
                + " VALUES('"
                + (string)Session["UsrName"] + "','"
                + (string)Session["WSName"] + "','"
                + cmd
                + "','" + WebForm
                + "','" + UserIP
				+ "','" + HostName
                + "','" + complete
                + "')";
			int k = db.MyUpdateDataExecuteNonQuery(logcmd);
			db.Dispose();
		}
	}
}
