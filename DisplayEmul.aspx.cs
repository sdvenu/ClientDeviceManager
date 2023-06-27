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
using System.Collections.Generic;

namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for Emul.
	/// </summary>
	public partial class DisplayEmul : Web.PageBase
	{
		private string Group = null;
		public const String EMUL_CFG_TABLE = "EmulatorCfgSettings";
		public const String USER_ID = "UserID";
		public const String EMUL_PARAMS = "EmulParams";
			
		protected void Page_Load(object sender, System.EventArgs e)
		{
            Group = LoginIfNotLoggedIn();

			if (!IsPostBack)
			{
                SaySelectView();
                LoadCurrentConfiguration();

				AutoPanel.Visible = false;
				ManualPanel.Visible = true;
				EmulPanel.Visible = false;
                txtProfile.Focus();
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

        protected void SaySelectView()
        {
            if ("USER" == Group)
            {
                lblMessage.Text = "Select the profile or HOSTINFO to view.";
                lblMessage.ForeColor = System.Drawing.Color.Navy;
                lblMessage.ToolTip = "Make a selection to view the configuration.";
            }
            else
            {
                lblMessage.Text = "Select the profile or HOSTINFO to view or modify.";
                lblMessage.ForeColor = System.Drawing.Color.Navy;
                lblMessage.ToolTip = "Make a selection to view or update the configuration.";
            }
        }

        protected void LoadCurrentConfiguration()
        {
            string WSName = (string)Session["WSName"];
            string profile = null;
            string hostinfo = null;
            Common.Database database = new Database();
            string dbCommand;
            DataTable myTable;

            // If no workstaion is selected, there is no sepcific configuration.
            if (string.IsNullOrEmpty(WSName))
            {
                lblWorkstation.Text = "No workstation selected";
                lblProfile.Text = string.Empty;
                lblHostInfo.Text = string.Empty;
            }
            else
            {
                // Show the workstation's configuration.
                lblWorkstation.Text = WSName + " selected";

                dbCommand =
                    "SELECT M.AirportZone, H.Name" +
                    " FROM MasterNodeTable AS M" +
                    "  LEFT JOIN MasterNodeExtraTable AS E" +
                    "   ON M.WSName = E.WSName" +
                    "  LEFT JOIN HostInfo AS H" +
                    "   ON E.HostInfo = H.ID" +
                    " WHERE M.WSName = '" + WSName + "'";
                myTable = database.MyGetDataTable(dbCommand);
                if (null == myTable || 0 == myTable.Rows.Count)
                {
                    lblProfile.Text = "error getting configuration";
                    lblHostInfo.Text = string.Empty;
                    return;
                }

                profile = myTable.Rows[0].Field<string>(0);
                this["ProfileName"] = profile;
                hostinfo = myTable.Rows[0].Field<string>(1);
                this["HostInfoName"] = hostinfo;

                lblProfile.Text = ("Profile " + profile) ?? "no profile";
                lblHostInfo.Text = ("HOSTINFO " + hostinfo) ?? "no HOSTINFO";
            }

            // Get the list of HOSTINFO definitions.
            dbCommand =
                "SELECT Name FROM HostInfo" +
                " ORDER BY Name ASC";
            myTable = database.MyGetDataTable(dbCommand);
            if (null != myTable && 0 < myTable.Rows.Count)
            {
                // Make the list form the rows.
                List<string> list = new List<string>(myTable.Rows.Count);
                for (int i = 0; i < myTable.Rows.Count; i++)
                    list.Add(myTable.Rows[i].Field<string>(0));

                // Place the lsit into the dropdown.
                HostInfoList.DataSource = list;
                HostInfoList.SelectedValue = hostinfo ?? "DEFAULT";
                HostInfoList.DataBind();
            }

            database.Dispose();

            txtProfile.Text = profile ?? "DEFAULT";
        }

		protected void ManualSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ManualSelection.Checked)
			{
				AutoPanel.Visible = false;
				ManualPanel.Visible = true;

                lbxWSNames.ClearSelection();
                txtProfile.Text = (string)this["ProfileName"] ?? "DEFAULT";
                txtProfile.Focus();
			}
            //else
            //{
            //    AutoPanel.Visible = true;
            //    ManualPanel.Visible = false;

            //    FillOutAutoPanel(null);
            //}

            pnlStatus.Visible = false;
            EmulPanel.Visible = false;
        }

		protected void AutoSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			if (AutoSelection.Checked)
            {
                AutoPanel.Visible = true;
                ManualPanel.Visible = false;

                FillOutAutoPanel((string)this["ProfileName"]);

                lbxWSNames.Focus();
            }
            //else
            //{
            //    AutoPanel.Visible = false;
            //    ManualPanel.Visible = true;

            //    lbxWSNames.ClearSelection();
            //}

            pnlStatus.Visible = false;
            EmulPanel.Visible = false;
        }

		private void FillOutAutoPanel(string aSelected)
		{
            Common.Database database = new Database();
            string dbCommand =
                "SELECT UserID FROM " + EMUL_CFG_TABLE +
                " ORDER BY UserID ASC";
            DataTable dbTable = database.MyGetDataTable(dbCommand);
            if (null == dbTable || 0 == dbTable.Rows.Count)
                return;

            List<string> list = new List<string>(dbTable.Rows.Count);
            foreach (DataRow row in dbTable.Rows)
                list.Add(row.Field<string>(0));

            lbxWSNames.DataSource = list;
            lbxWSNames.SelectedValue = aSelected ?? "DEFAULT";
            lbxWSNames.DataBind();
            //Common.Database db = new Database();
            //string cmd = "SELECT * FROM " + EMUL_CFG_TABLE;
            //DataSet myDS = db.MyFillDataSet(cmd, EMUL_CFG_TABLE);
            //db.Dispose();
            //if (null == myDS)
            //    return;
			
            //DataView SupportView = myDS.Tables[EMUL_CFG_TABLE].DefaultView;

            //lbxWSNames.DataSource = (ICollection)SupportView;
            //lbxWSNames.DataTextField = USER_ID;
            //lbxWSNames.DataValueField = USER_ID;
            //lbxWSNames.DataBind();
		}

		protected void btnManual_Click(object sender, System.EventArgs e)
		{
            string selected = txtProfile.Text.Trim();
            if (!IsProfileValid(selected))
			{
				lblMessage.Text =
                    "You have entered a profile name that does not exist. " +
                    "Please verify the profile name you entered is correct.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.ToolTip = string.Empty;
				return;
			}

			// Get the profile.
            lblMessage.Text = string.Empty;
            lblMessage.ToolTip = string.Empty;

			AutoPanel.Visible = false;
			ManualPanel.Visible = false;
            pnlStatus.Visible = false;

			this["ProfileName"] = selected;
			SendDownHTEFile(selected);
            txtboxSlate.Focus();
		}

		protected void btnAuto_Click(object sender, System.EventArgs e)
		{
			string selected = lbxWSNames.SelectedValue.Trim();
            if (string.IsNullOrEmpty(selected))
			{
				lblMessage.Text = "You must select a profile name from the list " +
					"to proceed with the configuration process.";
				lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.ToolTip = string.Empty;
				return;
			}

            lblMessage.Text = string.Empty;
            lblMessage.ToolTip = string.Empty;

			AutoPanel.Visible = false;
			ManualPanel.Visible = false;
			pnlStatus.Visible = false;

            this["ProfileName"] = selected;
            SendDownHTEFile(selected);
            txtboxSlate.Focus();
		}

		private bool IsProfileValid(string profileName)
		{
			Common.Database db = new Database();
			string cmd = "SELECT PasswordRequired FROM EmulatorCfgSettings" +
                " WHERE UserID = '" + txtProfile.Text.Trim() + "'";
			string zone = db.MyGetDataExecuteScalar(cmd);
            db.Dispose();
            return !string.IsNullOrEmpty(zone);
		}

		private void SendDownHTEFile(string profileName)
		{
			EmulPanel.Visible = true;
            bool isUser = ("USER" == Group);

            SaySelectView();

			Common.Database db = new Database();
			string cmd = "SELECT EmulParams FROM " + EMUL_CFG_TABLE +
                " WHERE UserID = '" + profileName.Trim() + "'";
			string data = db.MyGetDataExecuteScalar(cmd);
            db.Dispose();

            lblSlateTitle.Text = "Profile " + profileName.Trim();
            lblSlateComment.Text = "[Section]s have keyword=value entries. \";\" begins comment lines.";
			txtboxSlate.Text = data;
            txtboxSlate.ReadOnly = isUser;
            txtboxSlate.Focus();
            btnApply.Visible = !isUser;
            btnApply.Enabled = !isUser;
		}

		protected void btnApply_Click(object sender, System.EventArgs e)
		{
			// Update the profile.
            string profilename = (string)this["ProfileName"];
            if (string.IsNullOrEmpty(profilename))
                return;
            else
                profilename = profilename.Trim();

            Common.Database db = new Database();
			string cmd =
                "UPDATE " + EMUL_CFG_TABLE +
                " SET " + EMUL_PARAMS + " = '" + txtboxSlate.Text.Trim() + "'" +
                " WHERE UserID = '" + profilename + "'";
            pnlStatus.Visible = true;
            if (0 < db.MyUpdateDataExecuteNonQuery(cmd))
			{
				pnlStatus.Text = "Profile " + profilename + " was successfully updated.";
				pnlStatus.ForeColor = System.Drawing.Color.Navy;
			}
			else
			{
				pnlStatus.Text = "Profile " + profilename + " was not updated." +
                    " Please notify your database administrator.";
				pnlStatus.ForeColor = System.Drawing.Color.Red;
			}

            AutoPanel.Visible = false;
            ManualPanel.Visible = false;
            EmulPanel.Visible = false;
        }

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session.Remove("ProfileName");
			Response.Redirect("DisplayEmul.aspx", true);
		}

        protected void HostInfoSelection_CheckedChanged(object sender, EventArgs e)
        {
            if (!HostInfoSelection.Checked)
                return;

            string hostinfo = HostInfoList.SelectedValue;

            AutoPanel.Visible = false;
            ManualPanel.Visible = false;
            EmulPanel.Visible = true;
            pnlStatus.Visible = false;

            Common.Database database = new Database();
            string dbCommand =
                "SELECT Contents FROM HostInfo" +
                " WHERE Name = '" + hostinfo + "'";

            string content = database.MyGetDataExecuteScalar(dbCommand);
            if (string.IsNullOrEmpty(content))
                txtboxSlate.Text = "Error getting HOSTINFO definition";
            else
                txtboxSlate.Text = content;

            lblSlateTitle.Text = "HOSTINFO " + hostinfo;
            lblSlateComment.Text = "Entries are chng-chng-name ; host-URL ; cluster.";
            txtboxSlate.ReadOnly = true;
            txtboxSlate.Focus();
            btnApply.Visible = false;
            btnApply.Enabled = false;
        }
	}
}
