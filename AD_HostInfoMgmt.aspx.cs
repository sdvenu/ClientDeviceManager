namespace ClientDeviceMgr
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Assign the HOSTINFO definition to a workstation.
    /// </summary>
    public partial class AD_HostInfoMgmt : Web.PageBase
    {
        /// <summary>
        /// The current item.
        /// </summary>
        protected HostInfoData CurrentHostInfo;

        /// <summary>
        /// The HostInfo name assigned to the workstation.
        /// </summary>
        protected string WorkstationHostInfoName;

        /// <summary>
        /// The current workstation.
        /// </summary>
        protected string WSName;

        // For audit logging.
        private string UserIP;
        private string HostName;
        private string WebForm = "AD_HostInfoMgmt";

        /// <summary>
        /// Loads the HOSTINFO definitions page.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            UserIP = Request.UserHostAddress;
            HostName = Request.UserHostName;

            // Be sure the user is an administrator.
            LoginIfNotAdmin();
            WSName = SelectWorkstationIfNoneSelected();

            if (!IsPostBack)
            {
                lblWSName.Text = WSName;
                LoadHostInfoList(
                    LoadWorkstationHostInfoName(WSName));
                gvHostInfoNames.Focus();
            }

            // Acquire remembered data.

            WorkstationHostInfoName = this["WorkstationHostInfoName"] as string;
            CurrentHostInfo = this["UseHostInfo"] as HostInfoData;
        }

        /// <summary>
        /// Remembers page information.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Unload(object sender, EventArgs e)
        {
            this["WorkstationHostInfoName"] = WorkstationHostInfoName;
            this["UseHostInfo"] = CurrentHostInfo;
        }

        /// <summary>
        /// Assigns the selected HOSTINFO to the workstation.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void AssignHostInfo(object sender, ImageClickEventArgs e)
        {
            if (null == WSName)
                WSName = SelectWorkstationIfNoneSelected();

            if (null == CurrentHostInfo)
            {
                SayError("No HOSTINFO has been selected.");
                return;
            }

            AssignHostInfoForWorkstation(WSName, CurrentHostInfo);
            AssignSSLForWorkstationRoutes(WSName);

            // Change the displayed HOSTINFO name.
            WorkstationHostInfoName = CurrentHostInfo.Name;
            lblHostInfoName.Text = WorkstationHostInfoName;
            lblWSName.Text = WSName;
        }

        /// <summary>
        /// Move among the pages of HOSTINFO definitions.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void OnPageOfNamesChanging(object sender, GridViewPageEventArgs e)
        {
            Say(string.Empty);
            gvHostInfoNames.EditIndex = -1;
            gvHostInfoNames.SelectedIndex = -1;
            gvHostInfoNames.PageIndex = e.NewPageIndex;
            gvHostInfoNames.DataSource = this["Names"] as List<string>;
            gvHostInfoNames.DataBind();
        }

        /// <summary>
        /// Select the entire row when clicking anywhere within it.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] =
                    ClientScript.GetPostBackClientHyperlink(
                        gvHostInfoNames,
                        "Select$" + e.Row.RowIndex);
            }
        }

        /// <summary>
        /// Finish selecting a HOSTINFO definition.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void OnSelectedNameIndexChanged(object sender, EventArgs e)
        {
            GetHostInfoBySelectedIndex();
        }

        /// <summary>
        /// Start selecting a HOSTINFO definition.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="GridViewSelectEventArgs"/> instance containing the event data.</param>
        protected void OnSelectedNameIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Say(null);
            gvHostInfoNames.SelectedIndex = e.NewSelectedIndex;
        }

        /// <summary>
        /// Accesses the page's DetailsView's controls.
        /// </summary>
        /// <param name="aDetailsView">a details view.</param>
        /// <param name="nameControl">The name control.</param>
        /// <param name="descriptionControl">The description control.</param>
        /// <param name="contentControl">The content control.</param>
        /// <returns>true if the controls are found.</returns>
        private bool AccessDetailsViewControls(
            DetailsView aDetailsView,
            out TextBox nameControl,
            out TextBox descriptionControl,
            out TextBox contentControl)
        {
            if (null == aDetailsView)
            {
                nameControl = null;
                descriptionControl = null;
                contentControl = null;
                return false;
            }

            nameControl = aDetailsView.FindControl("txtName") as TextBox;
            descriptionControl = aDetailsView.FindControl("txtDescription") as TextBox;
            contentControl = aDetailsView.FindControl("txtContents") as TextBox;

            return
                (null != nameControl) &&
                (null != descriptionControl) &&
                (null != contentControl);
        }

        /// <summary>
        /// Assigns the indicated HOSTINFO to the workstation.
        /// </summary>
        /// <param name="aWorkstation">A workstation.</param>
        /// <param name="aHostInfo">A host information.</param>
        private void AssignHostInfoForWorkstation(string aWorkstation, HostInfoData aHostInfo)
        {
            try
            {
                Common.Database database = new Common.Database();

                string dbCommand =
                    // Update the entry or insert a new entry.
                    "UPDATE MasterNodeExtraTable SET" +
                    " HostInfo = " + CurrentHostInfo.ID.ToString() +
                    " WHERE WSName = '" + WSName + "'" +
                    "; IF @@ROWCOUNT = 0 " +
                    "INSERT INTO MasterNodeExtraTable (" +
                    "WSName," +
                    "HostInfo" +
                    ") VALUES (" +
                    "'" + WSName + "'," +
                    CurrentHostInfo.ID.ToString() + ")";

                if (0 < database.MyUpdateDataExecuteNonQuery(dbCommand))
                    Audit(dbCommand);

                database.Dispose();
            }
            catch (Exception ex)
            {
                SayError("Error assigning workstation HOSTINFO name: " + ex.Message);
            }
        }

        /// <summary>
        /// Assigns SSL On for all of a workstation's routes.
        /// </summary>
        /// <param name="aWorkstation">A workstation.</param>
        private void AssignSSLForWorkstationRoutes(string aWorkstation)
        {
            try
            {
                Common.Database database = new Common.Database();

                string dbCommand =
                    // Update all the routes with SSL turned on.
                    "UPDATE HSSPRouteInfo" +
                    " SET SSL = '1'" +
                    " WHERE WSName = '" + aWorkstation + "'";

                if (0 < database.MyUpdateDataExecuteNonQuery(dbCommand))
                    Audit(dbCommand);

                database.Dispose();
            }
            catch (Exception ex)
            {
                SayError("Error assigning SSL for workstation: " + ex.Message);
            }
        }

        /// <summary>
        /// Provide an audit trail of a command.
        /// </summary>
        /// <param name="aCommand">A command.</param>
        /// <param name="isSuccessful">Successful if set to <c>true</c>.</param>
        private void Audit(string aCommand, bool isSuccessful = true)
        {
            if (string.IsNullOrEmpty(aCommand))
                return;

            try
            {
                string cleanCommand = aCommand.Replace('\'', '`');

                Common.Database db = new Common.Database();

                string auditLog = "INSERT INTO AuditLogtbl("
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
                    + cleanCommand
                    + "','" + WebForm
                    + "','" + UserIP
                    + "','" + HostName
                    + "','" + (isSuccessful ? "1" : "0")
                    + "')";

                db.MyUpdateDataExecuteNonQuery(auditLog);

                db.Dispose();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Get the definition of the HOSTINFO currently selected in the list.
        /// </summary>
        /// <returns>The index.</returns>
        private int GetHostInfoBySelectedIndex()
        {
            int index = -1;
            List<string> list = null;

            try
            {
                list = this["Names"] as List<string>;
                index = (gvHostInfoNames.PageIndex * gvHostInfoNames.PageSize) + gvHostInfoNames.SelectedIndex;

                if (null != list && 0 < list.Count &&
                    0 <= index && index < list.Count)
                    GetHostInfoByName(list[index]);
                else
                    GetHostInfoByName(null);
            }
            catch (Exception ex)
            {
                SayError("Error getting selected HOSTINFO[" + index.ToString() + "]: " + ex.Message);
                GetHostInfoByName(null);
            }

            gvHostInfoNames.DataSource = list;
            if (0 < index)
            {
                gvHostInfoNames.SelectedIndex = index % gvHostInfoNames.PageSize;
                gvHostInfoNames.PageIndex = index / gvHostInfoNames.PageSize;
            }
            else
            {
                gvHostInfoNames.SelectedIndex = index;
                gvHostInfoNames.PageIndex = 0;
            }
            gvHostInfoNames.DataBind();
            return index;
        }

        /// <summary>
        /// Get the definition of the named HOSTINFO.
        /// </summary>
        /// <param name="aName">The HOSTINFO name.</param>
        /// <returns>The name.</returns>
        private string GetHostInfoByName(string aName)
        {
            string name = null;

            if (string.IsNullOrEmpty(aName))
                CurrentHostInfo = new HostInfoData(null);
            else
            {
                name = aName.Trim();
                try
                {
                    Common.Database database = new Common.Database();

                    string dbCommand =
                        "SELECT *" +
                        " FROM HostInfo" +
                        " WHERE Name = '" + name + "'";

                    CurrentHostInfo = new HostInfoData(database.MyGetDataTable(dbCommand));
                    database.Dispose();
                }
                catch (Exception ex)
                {
                    SayError("Error getting \"" + name + "\" HOSTINFO: " + ex.Message);
                    CurrentHostInfo = new HostInfoData(null);
                }
            }

            this["UseHostInfo"] = CurrentHostInfo;
            dvHostInfo.DataSource = CurrentHostInfo.Table;
            dvHostInfo.DataBind();
            return name;
        }

        /// <summary>
        /// Load the list of HOSTINFO definitions.
        /// </summary>
        private void LoadHostInfoList(string aSelectedName)
        {
            try
            {
                Common.Database database = new Common.Database();

                string dbCommand =
                    "SELECT Name FROM HostInfo ORDER BY Name";

                DataTable dbTable = database.MyGetDataTable(dbCommand);

                database.Dispose();

                // Make the names a simple list.
                List<string> list = new List<string>(dbTable.Rows.Count);
                foreach (DataRow row in dbTable.Rows)
                    list.Add(row.Field<string>("Name"));

                // Remember the list.
                this["Names"] = list;

                // Select the indicated item.
                SelectHostInfoByName(aSelectedName);
            }
            catch (Exception ex)
            {
                SayError("Error getting HOSTINFO names: " + ex.Message);
            }
        }

        /// <summary>
        /// Load the name of the workstation's assigned HOSTINFO.
        /// </summary>
        private string LoadWorkstationHostInfoName(string aWorkstationName)
        {
            WorkstationHostInfoName = null;
            this["WorkstationHostInfoName"] = WorkstationHostInfoName;

            try
            {
                Common.Database database = new Common.Database();

                string dbCommand =
                    "SELECT HostInfo.Name FROM HostInfo" +
                    " INNER JOIN MasterNodeExtraTable" +
                    " ON MasterNodeExtraTable.HostInfo = HostInfo.ID" +
                    " WHERE MasterNodeExtraTable.WSName = '" + aWorkstationName + "'";

                DataTable dbTable = database.MyGetDataTable(dbCommand);

                database.Dispose();

                if (null != dbTable && 0 < dbTable.Rows.Count)
                    WorkstationHostInfoName = dbTable.Rows[0].Field<string>("Name");
                else
                    WorkstationHostInfoName = "Ignore";

                this["WorkstationHostInfoName"] = WorkstationHostInfoName;
            }
            catch (Exception ex)
            {
                SayError("Error getting workstation HOSTINFO name: " + ex.Message);
            }

            lblHostInfoName.Text = WorkstationHostInfoName;
            return WorkstationHostInfoName;
        }

        /// <summary>
        /// Display a message.
        /// </summary>
        /// <param name="aMessage">a message.</param>
        private void Say(string aMessage = null)
        {
            lblErrorMessage.Text = string.Empty;
            lblMessage.Text = aMessage ?? string.Empty;
        }

        /// <summary>
        /// Display an error message.
        /// </summary>
        /// <param name="aMessage">a message.</param>
        private void SayError(string aMessage)
        {
            lblMessage.Text = string.Empty;
            lblErrorMessage.Text = aMessage;
        }

        /// <summary>
        /// Select the HOSTINFO in the list whose name is given.
        /// </summary>
        /// <param name="aName">The name of a definition.</param>
        /// <returns>The index.</returns>
        private int SelectHostInfoByName(string aName)
        {
            int index = -1;
            List<string> list = null;
            string name = null;

            try
            {
                list = this["Names"] as List<string>;
                name = aName.Trim();

                if (null != list)
                    index = list.IndexOf(aName);

                GetHostInfoByName(name);
            }
            catch (Exception ex)
            {
                SayError("Error selecting the \"" + name + "\" HOSTINFO: " + ex.Message);
            }

            gvHostInfoNames.DataSource = list;
            if (0 < index)
            {
                gvHostInfoNames.SelectedIndex = index % gvHostInfoNames.PageSize;
                gvHostInfoNames.PageIndex = index / gvHostInfoNames.PageSize;
            }
            else
            {
                gvHostInfoNames.SelectedIndex = index;
                gvHostInfoNames.PageIndex = 0;
            }
            gvHostInfoNames.DataBind();
            return index;
        }
    }
}