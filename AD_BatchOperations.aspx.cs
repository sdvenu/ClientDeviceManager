namespace ClientDeviceMgr
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Perform batch operations on multiple workstations.
    /// </summary>
    /// <seealso cref="ClientDeviceMgr.Web.PageBase"/>
    public partial class AD_BatchOperations : Web.PageBase
    {
        /// <summary>
        /// The HOSTINFO from which to migrate.
        /// </summary>
        protected HostInfoData FromHostInfo;

        /// <summary>
        /// The name of the HOSTINFO from which to migrate.
        /// </summary>
        protected string FromHostInfoName;

        /// <summary>
        /// The names of all the HOSTINFO definitions.
        /// </summary>
        protected List<string> HostInfoList;

        /// <summary>
        /// The text area.
        /// </summary>
        protected string Slate;

        /// <summary>
        /// The HOSTINFO to which to migrate.
        /// </summary>
        protected HostInfoData ToHostInfo;

        /// <summary>
        /// The name of the HOSTINFO to which to migrate.
        /// </summary>
        protected string ToHostInfoName;

        /// <summary>
        /// The HOSTINFO to use for assignment or display.
        /// </summary>
        protected HostInfoData UseHostInfo;

        /// <summary>
        /// The name of the HOSTINFO to use for assignment or display.
        /// </summary>
        protected string UseHostInfoName;

        /// <summary>
        /// The Zone to use for assignment or display.
        /// </summary>
        protected string UseZone;

        /// <summary>
        /// The names of all the Zone definitions.
        /// </summary>
        protected List<string> ZoneList;

        // For audit logging.
        private string UserIP;
        private string HostName;
        private string WebForm = "AD_BatchOperations";

        /// <summary>
        /// Load the page.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            UserIP = Request.UserHostAddress;
            HostName = Request.UserHostName;

            // Be sure the user is an administrator.
            LoginIfNotAdmin();

            if (!IsPostBack)
            {
                if (IsAllowedBatchOperations())
                {
                    pnlMain.Enabled = true;
                    LoadData();
                    BindData();
                }
                else
                {
                    pnlMain.Enabled = false;
                    lblErrorMessage.Text = "A Supervisor has not authorized you to perform Batch Operations.";
                }
            }
            else
            {
                LoadData();
            }
        }

        /// <summary>
        /// Remembers page information.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Unload(object sender, EventArgs e)
        {
            ;
        }

        /// <summary>
        /// Assigns the selected HOSTINFO to all the workstations.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void AssignHostInfo(object sender, ImageClickEventArgs e)
        {
            bool isProcessed = true;

            // Get a list of all the workstations entered.
            string[] workstations;
            if (!ParseWords("workstations", Slate, out workstations))
                return;

            // Get the HOSTINFO to assign.
            UseHostInfo = GetHostInfoByName(UseHostInfoName);
            if (null == UseHostInfo)
            {
                SayError("No HOSTINFO has been selected.");
                return;
            }

            List<string> workstationsChanged = new List<string>();
            List<string> workstationsFailed = new List<string>();
            Common.Database database = new Common.Database();

            try
            {
                foreach (string workstation in workstations)
                {
                    try
                    {
                        string dbCommand =
                            // Update the entry, or
                            "UPDATE MasterNodeExtraTable SET" +
                            " HostInfo = " + UseHostInfo.ID.ToString() +
                            " WHERE WSName = '" + workstation + "'" +
                            // if it can't update,
                            "; IF @@ROWCOUNT = 0 " +
                            // be sure there is a workstation and
                            " IF (SELECT COUNT(*) FROM MasterNodeTable" +
                            "  WHERE WSName = '" + workstation + "') > 0 " +
                            // insert a new entry.
                            "INSERT INTO MasterNodeExtraTable (" +
                            "WSName," +
                            "HostInfo" +
                            ") VALUES (" + 
                            "'" + workstation + "'," +
                            UseHostInfo.ID.ToString() + ");";

                        if (0 < database.MyUpdateDataExecuteNonQuery(dbCommand))
                            workstationsChanged.Add(workstation);
                        else
                            workstationsFailed.Add(workstation);

                        // Set SSL On for all of the workstation's routes.
                        dbCommand =
                            "UPDATE HSSPRouteInfo" +
                            " SET SSL = '1'" +
                            " WHERE WSName = '" + workstation + "'";
                        database.MyUpdateDataExecuteNonQuery(dbCommand);
                    }
                    catch
                    {
                        workstationsFailed.Add(workstation);
                    }
                }
            }
            catch (Exception ex)
            {
                SayError("Error accessing the database for batch HOSTINFO operations: " + ex.Message);
                isProcessed = false;
            }

            database.Dispose();

            if (isProcessed)
            {
                if (0 == workstationsFailed.Count)
                {
                    Say("All " +
                        workstationsChanged.Count.ToString() +
                        " workstations are set to use the " +
                        UseHostInfo.Name +
                        " HOSTINFO.");
                }
                else
                {
                    SayError(
                        "The following " +
                        workstationsFailed.Count.ToString() +
                        " workstations failed to be given the new " +
                        UseHostInfo.Name +
                        " HOSTINFO.");

                    LoadSlate(workstationsFailed);
                }
            }

            AuditWorkstations(
                UseHostInfo.Name,
                "HOSTINFO",
                workstationsChanged);
        }

        /// <summary>
        /// Assign the migrated DefaultHost for each workstation.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void AssignMigrationsWithHostInfo(object sender, ImageClickEventArgs e)
        {
            ProcessHostInfoMigrations(
                true,
                cbForTerminals.Checked,
                cbForPrinters.Checked);
        }

        /// <summary>
        /// Assigns the selected Zone to all the workstations.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void AssignZone(object sender, ImageClickEventArgs e)
        {
            bool isProcessed = true;

            if (null == UseZone)
            {
                SayError("No Zone has been selected.");
                return;
            }

            // Get a list of all the workstations entered.
            string[] workstations;
            if (!ParseWords("workstations", Slate, out workstations))
                return;

            List<string> workstationsChanged = new List<string>();
            List<string> workstationsFailed = new List<string>();
            Common.Database database = new Common.Database();

            try
            {
                foreach (string workstation in workstations)
                {
                    try
                    {
                        string dbCommand =
                            // Update the entry, and don't insert anything new.
                            "UPDATE MasterNodeTable SET" +
                            " AirportZone = '" + UseZone + "'" +
                            " WHERE WSName = '" + workstation + "'";

                        if (0 < database.MyUpdateDataExecuteNonQuery(dbCommand))
                            workstationsChanged.Add(workstation);
                        else
                            workstationsFailed.Add(workstation);
                    }
                    catch
                    {
                        workstationsFailed.Add(workstation);
                    }
                }
            }
            catch (Exception ex)
            {
                SayError("Error accessing the database for batch Zone operations: " + ex.Message);
                isProcessed = false;
            }

            database.Dispose();

            if (isProcessed)
            {
                if (0 == workstationsFailed.Count)
                    Say("All " +
                        workstationsChanged.Count.ToString() +
                        " workstations are set to use the " +
                        UseZone +
                        " Zone.");
                else
                {
                    SayError(
                        "The following " +
                        workstationsFailed.Count.ToString() +
                        " workstations failed to be given the new " +
                        UseZone +
                        " Zone.");

                    LoadSlate(workstationsFailed);
                }
            }

            AuditWorkstations(
                UseZone,
                "Zone",
                workstationsChanged);
        }

        /// <summary>
        /// Displays the DefaultHost that would be migrated for each workstation.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void DisplayMigrationsWithHostInfo(object sender, ImageClickEventArgs e)
        {
            ProcessHostInfoMigrations(
                false,
                cbForTerminals.Checked,
                cbForPrinters.Checked);
        }

        /// <summary>
        /// Displays the table mapping old DefaultHosts to new DefaultHosts
        /// for the from- and to- HOSTINFOs selected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void DisplayMigrationTable(object sender, ImageClickEventArgs e)
        {
            FromHostInfo = GetHostInfoByName(FromHostInfoName);
            ToHostInfo = GetHostInfoByName(ToHostInfoName);

            if (null == FromHostInfo || null == ToHostInfo)
                return;

            List<string> list = GenerateMigrationList(FromHostInfo.Contents, ToHostInfo.Contents);

            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < list.Count; i += 2)
            {
                if (null != list[i] && null != list[i + 1])
                    buffer.AppendFormat(
                        "{0,-32} to {1}",
                        list[i],
                        list[i + 1]);
                else if (null == list[i])
                    buffer.AppendFormat(
                        "{0,-32} can remain",
                        list[i + 1]);
                else
                    buffer.AppendFormat(
                        "{0,-32} is unmapped, so cannot change",
                        list[i]);

                buffer.AppendLine();
            }

            LoadSlate(buffer.ToString());

            Say("DefaultHost migrations from " +
                FromHostInfoName +
                " to " +
                ToHostInfoName);
        }

        /// <summary>
        /// Displays the workstation's HOSTINFO and Zone assignments.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void DisplayWorkstationsAssignments(object sender, ImageClickEventArgs e)
        {
            bool isDisplaying = true;
            List<string> list = new List<string>();

            string[] workstations;
            if (!ParseWords("workstations", Slate, out workstations))
                return;

            // Start the listing with a header.
            list.Add(string.Format(ASSIGNMENT_FORMAT,
                "// Workstation",
                "Zone",
                "HOSTINFO"));

            Common.Database database = new Common.Database();

            try
            {
                // Get assignments for each workstation.
                foreach (string workstation in workstations)
                {
                    try
                    {
                        string dbCommand =
                            "SELECT M.AirportZone, H.Name" +
                            " FROM MasterNodeTable AS M" +
                            "  FULL JOIN MasterNodeExtraTable AS E" +
                            "   ON M.WSName = E.WSName" +
                            "  FULL JOIN HostInfo AS H" +
                            "   ON E.HostInfo = H.ID" +
                            " WHERE M.WSName = '" + workstation + "'";

                        DataTable dbTable = database.MyGetDataTable(dbCommand);

                        if (null != dbTable && 0 < dbTable.Rows.Count)
                        {
                            string zone = dbTable.Rows[0].Field<string>(0);
                            string hostinfo = dbTable.Rows[0].Field<string>(1);

                            // Add an entry for this workstation.
                            list.Add(string.Format(ASSIGNMENT_FORMAT,
                                workstation,
                                zone ?? string.Empty,
                                hostinfo ?? string.Empty));
                        }
                        else
                            list.Add(string.Format(ASSIGNMENT_FORMAT,
                                workstation,
                                "{workstation not found}",
                                string.Empty));
                    }
                    catch
                    {
                        // There was a problem, so give this workstation a blank entry.
                        list.Add(string.Format(ASSIGNMENT_FORMAT,
                            workstation,
                            "{db error}",
                            string.Empty));
                    }
                }
            }
            catch (Exception ex)
            {
                SayError("Error accessing the database to display batch HOSTINFO assignments: " + ex.Message);
                isDisplaying = false;
            }

            database.Dispose();

            if (isDisplaying)
            {
                Say("Assignments for " +
                    (list.Count - 1).ToString() + // Minus one for the header
                    " workstations.");

                LoadSlate(list);
            }
            else
                LoadSlate(string.Empty);
        }
        private const string ASSIGNMENT_FORMAT = "{0,-32} // {1,-32} // {2}";

        /// <summary>
        /// Displays the workstations that have the selected HostInfo assigned.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void DisplayWorkstationsWithHostInfo(object sender, ImageClickEventArgs e)
        {
            bool isDisplaying = true;
            List<string> list = new List<string>();

            if (null == UseHostInfoName)
            {
                SayError("No HOSTINFO selected");
                return;
            }

            try
            {
                Common.Database database = new Common.Database();

                string dbCommand =
                    "SELECT WSName" +
                    " FROM MasterNodeExtraTable" +
                    " WHERE HostInfo = " +
                    " (SELECT ID FROM HostInfo" +
                    "  WHERE Name = '" + UseHostInfoName + "')";

                // Get the list of workstations having the selected HostInfo.
                DataTable names = database.MyGetDataTable(dbCommand);
                if (null == names || 0 == names.Rows.Count)
                {
                    Say("No workstations have been assigned the " + UseHostInfoName + " HOSTINFO.");
                    isDisplaying = false;
                }
                else
                {
                    // Make the database rows into a list.
                    foreach (DataRow row in names.Rows)
                        list.Add(row.Field<string>(0));
                }

                database.Dispose();
            }
            catch (Exception ex)
            {
                SayError("Error finding HOSTINFOs for workstations: " + ex.Message);
                isDisplaying = false;
            }

            if (isDisplaying)
            {
                Say("These are the " +
                    list.Count.ToString() +
                    " workstations with the " +
                    UseHostInfoName + " HOSTINFO.");

                LoadSlate(list);
            }
            else
                LoadSlate(string.Empty);
        }

        /// <summary>
        /// Displays the workstations that have the selected Zone assigned.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void DisplayWorkstationsWithZone(object sender, ImageClickEventArgs e)
        {
            bool isDisplaying = true;
            List<string> list = new List<string>();

            if (null == UseZone)
            {
                SayError("No Zone selected");
                return;
            }

            try
            {
                Common.Database database = new Common.Database();

                string dbCommand =
                    "SELECT WSName" +
                    " FROM MasterNodeTable" +
                    " WHERE AirportZone = '" + UseZone + "'";

                // Get the workstations having the selected zone.
                DataTable dbTable = database.MyGetDataTable(dbCommand);
                if (null == dbTable || 0 == dbTable.Rows.Count)
                {
                    SayError("The " + UseZone + " Zone is not in use.");
                    isDisplaying = false;
                }
                else
                {
                    // Make the database rows into a list.
                    foreach (DataRow row in dbTable.Rows)
                        list.Add(row.Field<string>(0));
                }

                database.Dispose();
            }
            catch (Exception ex)
            {
                SayError("Error finding workstation Zones: " + ex.Message);
                isDisplaying = false;
            }

            if (isDisplaying)
            {
                Say("These are the " +
                    list.Count.ToString() +
                    " workstations with the " +
                    UseZone + " Zone.");

                LoadSlate(list);
            }
            else
                LoadSlate(string.Empty);
        }

        /// <summary>
        /// Migrate the DefaultHost for each workstation.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
        protected void MigrateHostInfo(object sender, ImageClickEventArgs e)
        {
            Say("Migrate from " +
                FromHostInfoName +
                " to " +
                ToHostInfoName);
        }

        ///////////////////////////////////////////////////////////////
        
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
        /// Add items to the migration list if they are not already represented.
        /// </summary>
        /// <remarks>
        /// The migration list is pairs of items:
        /// old-item, new-item => migrate from the old-item to the new-item
        /// null, old-item => retain the old-item
        /// old-item, null => no new migration item for the old item
        /// </remarks>
        /// <param name="aList">A migration list.</param>
        /// <param name="anOldItem">A from item.</param>
        /// <param name="aNewItem">A to item.</param>
        private void AddToMigrationList(
            List<string> aList,
            string anOldItem,
            string aNewItem)
        {
            bool adding = true;

            // The list must exist and be pairs of items.
            for (int i = 0; i < aList.Count - 1; i += 2)
            {
                if (anOldItem == aList[i] && aNewItem == aList[i + 1])
                {
                    // The item pair is already accounted for.
                    adding = false;
                    break;
                }
                else if (null != anOldItem && null == aNewItem && // no match
                         null == aList[i] && anOldItem == aList[i + 1]) // can remain
                {
                    // The old item is allowed to remain.
                    adding = false;
                    break;
                }
            }

            if (adding)
            {
                aList.Add(anOldItem);
                aList.Add(aNewItem);
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
                string cleanCommand =
                    aCommand.Replace('\'', '`').Substring(0, AUDIT_LIMIT);

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
        /// Provide an audit trail of the workstations that changed.
        /// </summary>
        /// <param name="aName">A name.</param>
        /// <param name="aType">The type of name.</param>
        /// <param name="aList">A list of workstations.</param>
        private void AuditWorkstations(
            string aName,
            string aType,
            List<string> aList)
        {
            const int LINE_LIMIT = AUDIT_LIMIT - 32;

            if (null == aName || null == aType || null == aList || 0 == aList.Count)
                return;

            StringBuilder buffer = new StringBuilder(LINE_LIMIT + 32);

            foreach(string workstation in aList)
            {
                // Begin each audit entry with the change being made.
                if (0 == buffer.Length)
                    buffer
                        .Append("Set ")
                        .Append(aName)
                        .Append(" ")
                        .Append(aType)
                        .Append(" for ");
                else
                    buffer.Append(",");

                // Add the workstation name.
                buffer.Append(workstation);

                // Write the audit log when the line is full.
                if (LINE_LIMIT < buffer.Length)
                {
                    Audit(buffer.ToString());
                    buffer.Remove(0, buffer.Length);
                }
            }

            // Write the last unwritten audit log.
            if (0 < buffer.Length)
                Audit(buffer.ToString());
        }

        /// <summary>
        /// Binds all of the page's controls.
        /// </summary>
        private void BindData()
        {
            BindHostInfo();
            BindSlate();
            BindZone();
        }

        /// <summary>
        /// Binds the HOSTINFO values to the controls.
        /// </summary>
        private void BindHostInfo()
        {
            ctlUseHostInfo.DataBind();
            ctlFromHostInfo.DataBind();
            ctlToHostInfo.DataBind();
        }

        /// <summary>
        /// Binds the Slate to the controls.
        /// </summary>
        private void BindSlate()
        {
            ctlSlate.DataBind();
        }

        /// <summary>
        /// Binds the Zone values to the controls.
        /// </summary>
        private void BindZone()
        {
            ctlUseZone.DataBind();
        }

        /// <summary>
        /// Generates the HOSTINFO migration list.
        /// </summary>
        /// <remarks>
        /// A list is created where the nth entry is a DNS name from
        /// which to migrate and the (n+1)th entry is where to migrate.
        /// Each HOSTINFO string has lines of name;DNS;cluster.
        /// So the list is the From-DNS and To-DNS where the name matches.
        /// </remarks>
        /// <param name="aFromHostInfo">From HOSTINFO.</param>
        /// <param name="aToHostInfo">To HOSTINFO.</param>
        /// <returns>The migration list.</returns>
        private List<string> GenerateMigrationList(
            string aFromHostInfo,
            string aToHostInfo)
        {
            // There must be something to migrate from and to.
            if (string.IsNullOrEmpty(aFromHostInfo) ||
                string.IsNullOrEmpty(aToHostInfo) ||
                "ignore".Equals(aFromHostInfo, StringComparison.OrdinalIgnoreCase) ||
                "none".Equals(aToHostInfo, StringComparison.OrdinalIgnoreCase))
                return null;

            // Starting at 0, get [n]=name, [n+1]=DNS, [n+2]=cluster, etc.
            string[] fromItems = aFromHostInfo.Split(DELIMITERS, StringSplitOptions.RemoveEmptyEntries);
            string[] toItems = aToHostInfo.Split(DELIMITERS, StringSplitOptions.RemoveEmptyEntries);

            List<string> list = new List<string>();

            // Add the from/to that match by name.

            // Be sure you can access the n and n+1 from-items.
            for (int i = 0; i < fromItems.Length - 1; i += 3)
            {
                bool migrated = false;

                // Be sure you can access the n and n+1 to-items.
                for (int j = 0; j < toItems.Length - 1; j += 3)
                {
                    // Be sure the to-item wasn't already migrated.
                    if (null != toItems[j + 1])
                    {
                        if (fromItems[i] == toItems[j])
                        {
                            // Is the from-item the same as the to-item?
                            if (fromItems[i + 1] == toItems[j + 1])
                            {
                                // The to-item can remain.
                                AddToMigrationList(list, null, toItems[j + 1]);
                                //list.Add(null);
                                //list.Add(toItems[j + 1]);
                            }
                            else
                            {
                                // Change the from-item to the to-item.
                                AddToMigrationList(list, fromItems[i + 1], toItems[j + 1]);
                                //list.Add(fromItems[i + 1]);
                                //list.Add(toItems[j + 1]);
                            }

                            // This to-item has been used for migration.
                            toItems[j + 1] = null;
                            migrated = true;
                            break;
                        }
                    }
                }

                if (!migrated)
                {
                    AddToMigrationList(list, fromItems[i + 1], null);
                    //for (int j = 0; j < list.Count; j += 2)
                    //{
                    //    // See if the from-item is already migrated.
                    //    if (list[j] == fromItems[i + 1])
                    //    {
                    //        migrated = true;
                    //        break;
                    //    }
                    //}

                    //if (!migrated)
                    //{
                    //    // There is no to-item to change to.
                    //    list.Add(fromItems[i + 1]);
                    //    list.Add(null);
                    //}
                }
            }

            // Check for unmigrated to-items. Since you could have
            // migrated to them, they can remain.

            // Be sure you can access the n and n+1 to-items.
            for (int j = 0; j < toItems.Length - 1; j += 3)
            {
                // Be sure the to-item wasn't already migrated.
                if (null != toItems[j + 1])
                {
                    AddToMigrationList(list, null, toItems[j + 1]);
                //    bool migrated = false;

                //    for (int k = 0; k < list.Count; k += 2)
                //    {
                //        // See if the to-item is already migrating
                //        // or already allowed to remain.
                //        if (list[k] == toItems[j + 1] ||
                //            list[k + 1] == toItems[j + 1])
                //        {
                //            migrated = true;
                //            break;
                //        }
                //    }

                //    if (!migrated)
                //    {
                //        // The to-item can remain.
                //        list.Add(null);
                //        list.Add(toItems[j + 1]);
                //    }
                }
            }

            // The list now contains pairs of entries:
            // [n]=old  & [n+1]=new  means change old to new
            // [n]=null & [n+1]=new  means the item can remain
            // [n]=old  & [n+1]=null means there's no new value
            return list;
        }

        /// <summary>
        /// Gets the control's selected entry, or loads and selects.
        /// </summary>
        /// <param name="aDropDown">A drop down.</param>
        /// <param name="aDefaultList">A default list.</param>
        /// <param name="aDefaultString">A default string.</param>
        /// <returns>The currently selected item, or null.</returns>
        private string GetControlData(
            DropDownList aDropDown,
            List<string> aDefaultList = null,
            string aDefaultString = null)
        {
            if (null == aDropDown)
                return null;

            // Set the control's list if there isn't one.
            if (null == aDropDown.Items || 0 == aDropDown.Items.Count)
                aDropDown.DataSource = aDefaultList;

            int index;
            index = aDropDown.SelectedIndex;
            if (-1 < index)
                // Gets the selected item.
                return aDropDown.SelectedValue;
            else
            {
                // Selects a default item.
                if (Select<string>(aDropDown, aDefaultString))
                    return aDefaultString;
                else
                    return null;
            }
        }

        /// <summary>
        /// Get or set the text in the textbox.
        /// </summary>
        /// <param name="aTextBox">A text box.</param>
        /// <param name="aDefaultString">A default string.</param>
        /// <returns>The text in the text box.</returns>
        private string GetControlData(
            TextBox aTextBox,
            string aDefaultString = null)
        {
            if (null == aTextBox)
                return null;

            if (string.IsNullOrEmpty(aTextBox.Text))
                aTextBox.Text = aDefaultString;

            return aTextBox.Text;
        }

        /// <summary>
        /// Get the definition of the named HOSTINFO.
        /// </summary>
        /// <param name="aName">The HOSTINFO name.</param>
        /// <returns>The HOSTINFO.</returns>
        private HostInfoData GetHostInfoByName(string aName)
        {
            string name;
            HostInfoData result = null;

            if (string.IsNullOrEmpty(aName))
                result = new HostInfoData(null);
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

                    result = new HostInfoData(database.MyGetDataTable(dbCommand));
                    database.Dispose();
                }
                catch (Exception ex)
                {
                    SayError("Error getting \"" + name + "\" HOSTINFO: " + ex.Message);
                    result = new HostInfoData(null);
                }
            }

            return result;
        }

        /// <summary>
        /// Determines if the current user is allowed batch operations.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the user is allowed batch operations; otherwise, <c>false</c>.
        /// </returns>
        private bool IsAllowedBatchOperations()
        {
            bool IsAllowed = false;

            try
            {
                Common.Database database = new Common.Database();

                string dbCommand =
                    "SELECT IsAllowedBatchOperations" +
                    " FROM ManagementRightsExtraTbl " +
                    " WHERE UserID = '" + (string)Session["usrName"] + "'";

                DataTable dbTable = database.MyGetDataTable(dbCommand);
                database.Dispose();
                if (null != dbTable && 0 < dbTable.Rows.Count)
                    IsAllowed = (bool)dbTable.Rows[0][0];
            }
            catch
            {
                IsAllowed = false;
            }

            return IsAllowed;
        }

        /// <summary>
        /// Loads the page's data.
        /// </summary>
        private void LoadData()
        {
            const string DefaultHostInfo = "DEFAULT";
            const string DefaultZone = "DEFAULT";

            HostInfoList = LoadHostInfoList();
            UseHostInfoName = GetControlData(ctlUseHostInfo, HostInfoList, DefaultHostInfo);
            FromHostInfoName = GetControlData(ctlFromHostInfo, HostInfoList, DefaultHostInfo);
            ToHostInfoName = GetControlData(ctlToHostInfo, HostInfoList, DefaultHostInfo);

            ZoneList = LoadZoneList();
            UseZone = GetControlData(ctlUseZone, ZoneList, DefaultZone);

            Slate = GetControlData(ctlSlate);
        }

        /// <summary>
        /// Load the list of HOSTINFO definitions.
        /// </summary>
        private List<string> LoadHostInfoList()
        {
            // Get the remembered list.
            List<string> list = this["HostInfoList"] as List<string>;

            if (null == list)
            {
                try
                {
                    // Get the list from the database.
                    Common.Database database = new Common.Database();

                    string dbCommand =
                        "SELECT Name FROM HostInfo ORDER BY Name";

                    DataTable dbTable = database.MyGetDataTable(dbCommand);

                    database.Dispose();

                    // Make the names a simple list.
                    list = new List<string>(dbTable.Rows.Count);
                    foreach (DataRow row in dbTable.Rows)
                        list.Add(row.Field<string>(0));
                }
                catch (Exception ex)
                {
                    SayError("Error getting HOSTINFO definitions: " + ex.Message);

                    if (null == list)
                        list = new List<string>();
                }

                // Remember the list.
                this["HostInfoList"] = list;
            }

            return list;
        }

        /// <summary>
        /// Get the text loaded in the Slate.
        /// </summary>
        private string LoadSlate()
        {
            if (string.IsNullOrEmpty(ctlSlate.Text))
                return string.Empty;
            else
                return ctlSlate.Text;
        }

        /// <summary>
        /// Load the Slate with a string.
        /// </summary>
        private void LoadSlate(string aString)
        {
            if (string.IsNullOrEmpty(aString))
                ctlSlate.Text = string.Empty;
            else
                ctlSlate.Text = aString;
        }

        /// <summary>
        /// Loads the Slate with the given list items as lines.
        /// </summary>
        /// <param name="aList">A list.</param>
        private void LoadSlate(List<string> aList)
        {
            ctlSlate.Text = string.Join("\r\n", aList.ToArray());
        }

        /// <summary>
        /// Load the list of Zone profiles.
        /// </summary>
        private List<string> LoadZoneList()
        {
            // Get the remembered list.
            List<string> list = this["ZoneList"] as List<string>;

            if (null == list)
            {
                try
                {
                    // Get the list from the database.
                    Common.Database database = new Common.Database();

                    string dbCommand =
                        "SELECT UserID FROM EmulatorCfgSettings ORDER BY UserID";

                    DataTable dbTable = database.MyGetDataTable(dbCommand);

                    database.Dispose();

                    // Make the names a simple list.
                    list = new List<string>(dbTable.Rows.Count);
                    foreach (DataRow row in dbTable.Rows)
                        list.Add(row.Field<string>(0));
                }
                catch (Exception ex)
                {
                    SayError("Error getting Zone profiles: " + ex.Message);

                    if (null == list)
                        list = new List<string>();
                }

                // Remember the list.
                this["ZoneList"] = list;
            }

            return list;
        }

        /// <summary>
        /// Gathers the delimited words, removing optional comments, from the string.
        /// </summary>
        /// <param name="aTitle">The kind of words.</param>
        /// <param name="aString">A string of delimited words.</param>
        /// <param name="aList">A list of the words.</param>
        /// <returns>true if the list is gathered, otherwise false.</returns>
        private bool ParseWords(
            string aTitle,
            string aString,
            out string[] aList)
        {
            string cleanString = RemoveComments(aString);
            if (string.IsNullOrEmpty(cleanString))
            {
                SayError("A list of " + aTitle + " must be supplied.");
                aList = null;
                return false;
            }
            else
            {
                Say();
                aList = cleanString.Split(DELIMITERS, StringSplitOptions.RemoveEmptyEntries);
                return true;
            }
        }

        /// <summary>
        /// Assign or display the migrated DefaultHost for each workstation.
        /// </summary>
        /// <param name="aMigrating">true if migrating, fallse if displaying.</param>
        /// <param name="aForTerminals">true if terminal routes are migrating.</param>
        /// <param name="aForPrinters">true if printer routes are migrating.</param>
        private void ProcessHostInfoMigrations(
            bool aMigrating,
            bool aForTerminals,
            bool aForPrinters)
        {
            FromHostInfo = GetHostInfoByName(FromHostInfoName);
            ToHostInfo = GetHostInfoByName(ToHostInfoName);

            if (null == FromHostInfo || null == ToHostInfo)
                return;

            // Get a list of all the workstations entered.
            string[] workstations;
            if (!ParseWords("workstations", Slate, out workstations))
                return;

            // Get a list of the migrations that may occur.
            StringBuilder display = new StringBuilder();
            string migratedHost = null;
            List<string> list = GenerateMigrationList(FromHostInfo.Contents, ToHostInfo.Contents);

            string dbCommand;
            Common.Database database = new Common.Database();

            // Get information for each workstation.
            foreach (string workstation in workstations)
            {
                try
                {
                    // Get the terminal routes and their default host.
                    dbCommand =
                        "SELECT DEFAULTHOST, RouteName, DEVTYPE FROM HsspRouteInfo" +
                        " WHERE WSName = '" + workstation + "'" +
                        " ORDER BY DEVTYPE DESC, RouteName ASC";

                    display.Append(workstation);

                    DataTable dbTable = database.MyGetDataTable(dbCommand);
                    if (null == dbTable || 0 == dbTable.Rows.Count)
                    {
                        display.AppendLine(" // no routes");
                        continue;
                    }

                    // Check each route.
                    foreach (DataRow row in dbTable.Rows)
                    {
                        bool matched = false;
                        migratedHost = null;

                        string host = row.Field<string>(0);
                        string route = row.Field<string>(1);
                        string devtype = row.Field<string>(2);

                        // Skip any device routes that shold not be migrated.
                        if ((!aForPrinters && "PRINTER".Equals(devtype)) ||
                            (!aForTerminals && "TERMINAL".Equals(devtype)))
                        {
                            display.AppendFormat(
                                " // {0} {1} {2} skipped",
                                route,
                                devtype,
                                host);
                            display.AppendLine();
                            continue;
                        }

                        // See if there is a matching migration.
                        for (int i = 0; i < list.Count; i += 2)
                        {
                            if (host == list[i])
                            {
                                migratedHost = list[i + 1];
                                display.AppendFormat(
                                    " // {0} {1} {2} => {3}",
                                    route,
                                    devtype,
                                    host,
                                    migratedHost);

                                matched = true;
                                break;
                            }
                        }

                        if (!matched)
                        {
                            // No matching migration.
                            migratedHost = null;
                            display.AppendFormat(
                                " // {0} {1} {2} no migration",
                                route,
                                devtype,
                                host);
                        }

                        if (aMigrating && (null != migratedHost))
                        {
                            // Change the default host and set SSL On.
                            dbCommand =
                                "UPDATE HsspRouteInfo SET" +
                                " DEFAULTHOST = '" + migratedHost + "'," +
                                " SSL = '1'" +
                                " WHERE" +
                                " RouteName = '" + route + "' AND" +
                                " WSName = '" + workstation + "'";

                            if (0 == database.MyUpdateDataExecuteNonQuery(dbCommand))
                                display.Append(" // error updating");
                            else
                                Audit(dbCommand);
                        }

                        display.AppendLine();
                    }
                }
                catch
                {
                    display.AppendLine(" // error migrating");
                }
            }

            LoadSlate(display.ToString());

            Say((aMigrating ? "Migrate" : "Display migrations") +
                " from " +
                FromHostInfoName +
                " to " +
                ToHostInfoName);
        }

        /// <summary>
        /// Selects the specified object in a drop down.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aDropDown">A drop down.</param>
        /// <param name="anObject">An object.</param>
        /// <returns>true if the object is selected.</returns>
        private bool Select<T>(
            DropDownList aDropDown,
            T anObject)
        {
            if (null == aDropDown || null == aDropDown.DataSource || null == anObject)
                return false;

            List<T> list = aDropDown.DataSource as List<T>;
            if (null == list)
                return false;

            int index = list.IndexOf(anObject);
            if (-1 == index)
                return false;

            aDropDown.SelectedIndex = index;
            return true;
        }

        /// <summary>
        /// Remove comments from the string.
        /// </summary>
        /// <param name="aString">A string</param>
        /// <returns>A string without comments.</returns>
        private string RemoveComments(string aString)
        {
            if (string.IsNullOrEmpty(aString))
                return aString;

            // Locate the first comment.
            int segment = 0;
            int comment = aString.IndexOf("//");
            if (comment < 0)
                return aString;

            // Make a buffer to hold the non-commented text.
            StringBuilder buffer = new StringBuilder(aString.Length);

            while (true)
            {
                // Keep the part before the comment.
                buffer.Append(aString.Substring(segment, comment - segment));
                buffer.AppendLine();

                // Locate the end of the line after the comment.
                segment = aString.IndexOf("\r\n", comment);
                if (segment < 0)
                    break;

                // Locate the next comment.
                comment = aString.IndexOf("//", segment);
                if (comment < 0)
                {
                    buffer.Append(aString.Substring(segment));
                    break;
                }
            }

            return buffer.ToString();
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
        /// The delimiters between entries, whether workstations or HOSTINFO lists.
        /// </summary>
        private readonly string[] DELIMITERS = { " ", "\t", ",", ";", "\r\n", "\r", "\n" };

        /// <summary>
        /// The limit on audit strings.
        /// </summary>
        private const int AUDIT_LIMIT = 1000;
    }
}
