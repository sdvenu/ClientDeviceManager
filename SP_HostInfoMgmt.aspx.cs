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
    /// Manage the contents of various HOSTINFO.TXT file definitions.
    /// </summary>
    public partial class SP_HostInfoMgmt : Web.PageBase
    {
        /// <summary>
        /// Is the HOSTINFO definition being edited?
        /// </summary>
        protected bool IsEditing
        {
            get { return DetailsViewMode.Edit == dvHostInfo.CurrentMode; }
            set { if (value) dvHostInfo.ChangeMode(DetailsViewMode.Edit); }
        }

        /// <summary>
        /// Is a HOSTINFO definition being added?
        /// </summary>
        protected bool IsInserting
        {
            get { return DetailsViewMode.Insert == dvHostInfo.CurrentMode; }
            set { if (value) dvHostInfo.ChangeMode(DetailsViewMode.Insert); }
        }

        /// <summary>
        /// Is a HOSTINFO definition being viewed?
        /// </summary>
        protected bool IsViewing
        {
            get { return DetailsViewMode.ReadOnly == dvHostInfo.CurrentMode; }
            set { if (value) dvHostInfo.ChangeMode(DetailsViewMode.ReadOnly); }
        }

        /// <summary>
        /// The current item.
        /// </summary>
        protected HostInfoData CurrentHostInfo;

        // For audit logging.
        private string UserIP;
        private string HostName;
        private string WebForm = "SP_HostInfoMgmt";

        /// <summary>
        /// Loads the HOSTINFO definitions page.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            UserIP = Request.UserHostAddress;
            HostName = Request.UserHostName;

            // Be sure the user is a supervisor.
            LoginIfNotSupervisor();

            if (!IsPostBack)
            {
                LoadHostInfoList("DEFAULT");
                gvHostInfoNames.Focus();
            }

            // Acquire remembered data.

            CurrentHostInfo = this["UseHostInfo"] as HostInfoData;
        }

        /// <summary>
        /// Augments the page information.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            // Augment the controls.

            TextBox contentsControl = dvHostInfo.FindControl("txtContents") as TextBox;
            if (null != contentsControl)
                contentsControl.Attributes["onKeyUp"] = "LimitToUppercase(dvHostInfo_txtContents)";
        }

        /// <summary>
        /// Remembers page information.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Unload(object sender, EventArgs e)
        {
            this["UseHostInfo"] = CurrentHostInfo;
        }

        /// <summary>
        /// Add a new HOSTINFO definition.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DetailsViewInsertEventArgs"/> instance containing the event data.</param>
        protected void OnDetailsAdding(object sender, DetailsViewInsertEventArgs e)
        {
            bool isInserting = true;
            string name = null;

            TextBox nameControl;
            TextBox descriptionControl;
            TextBox contentsControl;

            // Get the information from the controls.
            isInserting =
                AccessDetailsViewControls(
                    sender as DetailsView,
                    out nameControl,
                    out descriptionControl,
                    out contentsControl)
                &&
                ValidateDetailsViewControls(
                    nameControl,
                    descriptionControl,
                    contentsControl);

            if (isInserting)
            {
                name = nameControl.Text;

                // See whether the new name exists.
                if (HostInfo.DoesNameExist(name))
                {
                    SayError(name + " already exists. Choose another name.");
                    isInserting = false;
                }
            }

            if (isInserting)
            {
                try
                {
                    Common.Database database = new Common.Database();

                    // Insert the item.
                    string dbCommand =
                        "INSERT INTO HostInfo" +
                        " (Name, Description, Contents)" +
                        " VALUES ('" + name + "'," +
                        " '" + descriptionControl.Text + "'," +
                        " '" + contentsControl.Text + "')";

                    if (0 == database.MyUpdateDataExecuteNonQuery(dbCommand))
                    {
                        SayError(name + " could not be added.");
                        isInserting = false;
                    }
                    else
                    {
                        Say(name + " has been added.");
                        Audit(dbCommand);
                    }

                    database.Dispose();
                }
                catch (Exception ex)
                {
                    SayError("Error inserting " + name + " HOSTINFO: " + ex.Message);
                    isInserting = false;
                }
            }

            if (isInserting)
            {
                IsViewing = true;

                // Select the inserted item.
                LoadHostInfoList(name);
            }
            else
            {
                // Return to inserting.
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Prepopulate a new HOSTINFO definition from the current one.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs" /> instance containing the event data.</param>
        protected void OnDetailsCreated(object sender, EventArgs e)
        {
            if (DetailsViewMode.Insert == dvHostInfo.CurrentMode &&
                null != CurrentHostInfo)
            {
                TextBox nameControl;
                TextBox descriptionControl;
                TextBox contentsControl;

                if (AccessDetailsViewControls(
                        sender as DetailsView,
                        out nameControl,
                        out descriptionControl,
                        out contentsControl))
                {
                    nameControl.Text = "New" + CurrentHostInfo.Name;
                    descriptionControl.Text = "New " + CurrentHostInfo.Description;
                    contentsControl.Text = CurrentHostInfo.Contents;
                    contentsControl.Attributes["onKeyUp"] = "LimitToUppercase(dvHostInfo_txtContents)";
                }
            }
        }

        /// <summary>
        /// Delete a HOSTINFO definition.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DetailsViewDeleteEventArgs"/> instance containing the event data.</param>
        protected void OnDetailsDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            bool isDeleting = true;
            string name = null;

            TextBox nameControl;
            TextBox descriptionControl;
            TextBox contentsControl;

            // This code is designed to work with specific controls.
            isDeleting =
                AccessDetailsViewControls(
                    sender as DetailsView,
                    out nameControl,
                    out descriptionControl,
                    out contentsControl);

            if (isDeleting)
            {
                name = nameControl.Text;

                // Be sure the definition is deletable.
                if (!CurrentHostInfo.IsNameChangeable)
                {
                    SayError("The " + name + " configuration cannot be deleted");
                    isDeleting = false;
                }
            }

            if (isDeleting)
            {
                try
                {
                    Common.Database database = new Common.Database();

                    // See if any workstations are using the definition.
                    string dbCommand =
                        "SELECT COUNT(WSName) FROM MasterNodeExtraTable" +
                        " WHERE HostInfo = " + CurrentHostInfo.ID.ToString();

                    int count = database.MyGetDataExecuteScalarInt(dbCommand);
                    if (0 < count)
                    {
                        SayError(name + " is in use by " + count.ToString() + " workstations. Remove from workstations before deleting.");
                        isDeleting = false;
                    }

                    database.Dispose();
                }
                catch (Exception ex)
                {
                    SayError("Error counting HOSTINFO use: " + ex.Message);
                    isDeleting = false;
                }
            }

            if (isDeleting)
            {
                try
                {
                    Common.Database database = new Common.Database();

                    // Delete the item.
                    string dbCommand =
                        "DELETE FROM HostInfo" +
                        " WHERE Name = '" + name + "'";

                    if (0 == database.MyUpdateDataExecuteNonQuery(dbCommand))
                    {
                        SayError(name + " was not found, so could not be deleted.");
                        isDeleting = false;
                    }
                    else
                    {
                        Say(name  + " has been deleted.");
                        Audit(dbCommand);
                    }

                    database.Dispose();
                }
                catch (Exception ex)
                {
                    SayError("Error deleting " + name + " HOSTINFO: " + ex.Message);
                    isDeleting = false;
                }
            }

            if (isDeleting)
            {
                IsViewing = true;

                // Load the next definition after this one.
                LoadHostInfoList(GetHostInfoNameNext());
            }
            else
            {
                // Return to viewing.
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Change a HOSTINFO definition.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DetailsViewUpdateEventArgs"/> instance containing the event data.</param>
        protected void OnDetailsUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            bool isRenaming = false;
            bool isUpdating = true;
            string name = null;

            TextBox nameControl;
            TextBox descriptionControl;
            TextBox contentsControl;

            // Get the information from the controls.
            isUpdating =
                AccessDetailsViewControls(
                    sender as DetailsView,
                    out nameControl,
                    out descriptionControl,
                    out contentsControl)
                &&
                ValidateDetailsViewControls(
                    nameControl,
                    descriptionControl,
                    contentsControl);

            if (isUpdating)
            {
                name = nameControl.Text;

                // See if the item is being renamed and whether the new name exists.
                isRenaming = !name.Equals(CurrentHostInfo.Name, StringComparison.OrdinalIgnoreCase);
                if (isRenaming)
                {
                    if (HostInfo.DoesNameExist(name))
                    {
                        SayError(name + " already exists. Choose another name.");
                        isRenaming = false;
                        isUpdating = false;
                    }
                }
            }

            if (isUpdating)
            {
                try
                {
                    Common.Database database = new Common.Database();

                    // Update the item.
                    string dbCommand =
                        "UPDATE HostInfo SET" +
                        " Name = '" + name + "'," +
                        " Description = '" + descriptionControl.Text + "'," +
                        " Contents = '" + contentsControl.Text + "'" +
                        " WHERE Name = '" + CurrentHostInfo.Name + "'";

                    if (0 == database.MyUpdateDataExecuteNonQuery(dbCommand))
                    {
                        SayError(name + " could not be updated.");
                        isUpdating = false;
                    }
                    else
                    {
                        Say(name + " has been updated.");
                        Audit(dbCommand);
                    }

                    database.Dispose();
                }
                catch (Exception ex)
                {
                    SayError("Error updating " + name + " HOSTINFO: " + ex.Message);
                    isUpdating = false;
                }
            }

            if (isUpdating)
            {
                IsViewing = true;

                if (isRenaming)
                    // Select the renamed item.
                    LoadHostInfoList(name);
                else
                    GetHostInfoBySelectedIndex();
            }
            else
            {
                // Return to editing.
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Manage the HOSTINFO definitions.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DetailsViewModeEventArgs"/> instance containing the event data.</param>
        protected void OnDetailsModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.CancelingEdit)
            {
                Say(string.Empty);
                txtErrorList.Text = string.Empty;
                IsViewing = true;
                e.Cancel = true;
            }
            else
            {
                if (DetailsViewMode.Edit == e.NewMode)
                    IsEditing = true;
                else if (DetailsViewMode.Insert == e.NewMode)
                    IsInserting = true;
                else
                    IsViewing = true;
            }

            GetHostInfoBySelectedIndex();
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
            gvHostInfoNames.DataSource = this["HostInfoList"] as List<string>;
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
            if (IsEditing)
            {
                SayError("Cancel or Update before selecting another configuration");
                e.Cancel = true;
            }
            else
            {
                Say(null);
                gvHostInfoNames.SelectedIndex = e.NewSelectedIndex;
            }
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
                list = this["HostInfoList"] as List<string>;
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
        /// Get the next HOSTINFO name after the current one.
        /// </summary>
        /// <returns>The next name or the default.</returns>
        private string GetHostInfoNameNext()
        {
            int index = -1;
            List<string> list = null;
            string name = null;
            bool valid = true;

            if (null == CurrentHostInfo)
                valid = false;

            if (valid)
            {
                name = CurrentHostInfo.Name;
                if (null == name)
                    valid = false;
            }

            if (valid)
            {
                try
                {
                    list = this["HostInfoList"] as List<string>;

                    if (null == list || 0 == list.Count)
                        valid = false;
                }
                catch (Exception ex)
                {
                    SayError("Error getting the HOSTINFO list: " + ex.Message);
                }
            }

            if (valid)
            {
                index = list.IndexOf(name);
                if (0 <= index && index < list.Count - 1)
                    ++index;
                else
                    valid = false;
            }

            if (valid)
                name = list[index];
            else
                name = "DEFAULT";

            return name;
        }

        /// <summary>
        /// Be sure the basic HOSTINFO definitions are present.
        /// </summary>
        /// <param name="aRowCount">How many definitions currently exist.</param>
        private void InitializeHostInfos(int aRowCount)
        {
            try
            {
                Common.Database database = new Common.Database();

                string baseCommand = "INSERT INTO HostInfo (Name, Description, Contents) VALUES ({0})";

                if (aRowCount < 1)
                    database.MyUpdateDataExecuteNonQuery(
                        string.Format(
                            baseCommand,
                            "'Ignore', 'Do not create, erase, overwrite, or modify any HostInfo file'"));
                if (aRowCount < 2)
                    database.MyUpdateDataExecuteNonQuery(
                        string.Format(
                            baseCommand,
                            "'None', 'No HostInfo file for the workstation'"));
                if (aRowCount < 3)
                    database.MyUpdateDataExecuteNonQuery(
                        string.Format(
                            baseCommand,
                            "'DEFAULT', 'The default for most workstations'"));

                database.Dispose();
            }
            catch (Exception ex)
            {
                SayError("Error initializing HOSTINFO: " + ex.Message);
            }
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

                // Be sure the basic definitions are present.
                if (dbTable.Rows.Count < 3)
                {
                    InitializeHostInfos(dbTable.Rows.Count);
                    dbTable = database.MyGetDataTable(dbCommand);
                }
                database.Dispose();

                // Make the names a simple list.
                List<string> list = new List<string>(dbTable.Rows.Count);
                foreach (DataRow row in dbTable.Rows)
                    list.Add(row.Field<string>("Name"));

                // Remember the list.
                this["HostInfoList"] = list;

                // Select the indicated item.
                SelectHostInfoByName(aSelectedName);
            }
            catch (Exception ex)
            {
                SayError("Error getting HOSTINFO names: " + ex.Message);
            }
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
                list = this["HostInfoList"] as List<string>;
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

        /// <summary>
        /// Validates the page's DetailsVew's controls.
        /// </summary>
        /// <param name="aNameControl">a name control.</param>
        /// <param name="aContentsControl">a description control.</param>
        /// <param name="aContentsControl">a contents control.</param>
        /// <returns>true if the controls data is valid.</returns>
        private bool ValidateDetailsViewControls(
            TextBox aNameControl,
            TextBox aDescriptionControl,
            TextBox aContentsControl)
        {
            string message;
            string parsed;
            bool valid = true;

            // Be sure the Name is valid.
            if (HostInfo.ParseName(aNameControl.Text, out parsed, out message))
                aNameControl.Text = aNameControl.Text.Trim();
            else
            {
                valid = false;
                SayError(message);
            }

            // Be sure the Contents are valid.
            if (HostInfo.ParseContents(aContentsControl.Text, out parsed, out message))
            {
                // Update the Contents with the parsed Contents.
                aContentsControl.Text = parsed;
                txtErrorList.Text = string.Empty;
            }
            else
            {
                if (valid)
                    SayError("Correct the HOSTINFO errors and then Update");
                valid = false;
                txtErrorList.Text = message;
            }

            if (valid)
                Say();
            return valid;
        }
    }
}