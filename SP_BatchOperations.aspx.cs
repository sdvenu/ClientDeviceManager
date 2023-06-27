namespace ClientDeviceMgr
{
    using ClientDeviceMgr.Common;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Web.UI.WebControls;

    public partial class SP_BatchOperations : Web.PageBase
    {
        public class AdminInfo
        {
            public string UserID { get; set; }
            public bool IsAllowed { get; set; }

            public AdminInfo(string aUserID, bool? anIsAllowed)
            {
                UserID = aUserID;
                IsAllowed = anIsAllowed.HasValue ? anIsAllowed.Value : false;
            }
        }

        public List<AdminInfo> administratorsList = new List<AdminInfo>();

        public List<AdminInfo> cachedAdministrators
        {
            get { return (List<AdminInfo>)this[KEY_ADMINISTRATORS]; }
            set { this[KEY_ADMINISTRATORS] = (List<AdminInfo>)value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoginIfNotSupervisor();

            if (!IsPostBack)
            {
                LoadAdministrators();
                txtSearch.Attributes["onKeyUp"] = "LimitToUppercase(BatchOperationsMgmt.txtSearch)";
                txtSearch.Focus();
            }
        }

        protected void LoadAdministrators()
        {
            cachedAdministrators = administratorsList;

            try
            {
                Common.Database database = new Common.Database();

                string dbCommand =
                    "SELECT A.UserID, B.IsAllowedBatchOperations" +
                    " FROM ManagementRightsTbl AS A " +
                    " LEFT JOIN ManagementRightsExtraTbl AS B " +
                    " ON A.UserID = B.UserID" +
                    " WHERE A.UserGroup = 'ADMIN'";

                DataTable dbTable = database.MyGetDataTable(dbCommand);
                database.Dispose();
                if (null != dbTable)
                {
                    foreach(DataRow row in dbTable.Rows)
                    {
                        string userID = row["UserID"].ToString().Trim();
                        bool? dbIsAllowed = row.Field<bool?>("IsAllowedBatchOperations");
                        bool isAllowed =
                            dbIsAllowed.HasValue
                                ? dbIsAllowed.Value
                                : false;

                        cachedAdministrators.Add(
                            new AdminInfo(userID, isAllowed));
                    }

                    Say(cachedAdministrators.Count.ToString() + " Administrators");
                }
            }
            catch (Exception)
            {
                SayError("Error getting Administrator information.");
            }

            gvAdministrators.DataSource = cachedAdministrators;
            gvAdministrators.DataBind();
        }

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Say(string.Empty);
            gvAdministrators.EditIndex = -1;
            gvAdministrators.SelectedIndex = -1;
            gvAdministrators.PageIndex = e.NewPageIndex;
            gvAdministrators.DataSource = cachedAdministrators;
            gvAdministrators.DataBind();
        }

        protected void RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAdministrators.EditIndex = -1;
            gvAdministrators.DataSource = cachedAdministrators;
            gvAdministrators.DataBind();
        }

        protected void RowEditing(object sender, GridViewEditEventArgs e)
        {
            Say(string.Empty);
            gvAdministrators.SelectedIndex = -1;
            gvAdministrators.EditIndex = e.NewEditIndex;
            gvAdministrators.DataSource = cachedAdministrators;
            gvAdministrators.DataBind();
        }

        protected void RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvAdministrators.Rows[e.RowIndex];
            string userID = (row.FindControl("UserID") as Label).Text;
            bool isAllowed = (row.FindControl("IsAllowed") as CheckBox).Checked;

            if (!string.IsNullOrEmpty(userID))
            {
                // Find the administrator's information.
                AdminInfo adminInfo = cachedAdministrators.Find(x => x.UserID.Equals(userID));
                if (null != adminInfo)
                {
                    // Update only if the setting has changed.
                    if (adminInfo.IsAllowed != isAllowed)
                    {
                        if (UpdateAdministrator(userID, isAllowed))
                        {
                            Say("Administrator " + userID + " updated");
                            adminInfo.IsAllowed = isAllowed;
                        }
                        else
                            SayError("Error updating Administrator " + userID);
                    }
                }
            }

            gvAdministrators.EditIndex = -1;
            gvAdministrators.DataSource = cachedAdministrators;
            gvAdministrators.DataBind();
        }

        protected void Search(object sender, EventArgs e)
        {
            string userID = txtSearch.Text.ToUpper().Trim();
            if (string.IsNullOrEmpty(userID))
                SayError("Nothing to search for");
            else
            {
                int index = cachedAdministrators.FindIndex(x => x.UserID.Equals(userID));
                if (index < 0)
                    SayError("That Administrator ID was not found");
                else
                {
                    // With 10 entries per displayed page, calculate the
                    // page offset and the index within the page.
                    gvAdministrators.EditIndex = -1;
                    gvAdministrators.PageIndex = index / 10;
                    gvAdministrators.SelectedIndex = index % 10;

                    gvAdministrators.DataSource = cachedAdministrators;
                    gvAdministrators.DataBind();
                }
            }
        }

        private void Say(string aMessage)
        {
            lblErrorMessage.Text = string.Empty;
            lblMessage.Text = aMessage;
        }

        private void SayError(string aMessage)
        {
            lblMessage.Text = string.Empty;
            lblErrorMessage.Text = aMessage;
        }

        private bool UpdateAdministrator(string aUserID, bool anIsAllowed)
        {
            Common.Database database = new Common.Database();

            string dbCommand =
                "UPDATE ManagementRightsExtraTbl " +
                " SET IsAllowedBatchOperations = '" +
                anIsAllowed.ToString() + "'" +
                " WHERE UserID = '" +
                aUserID + "'";

            int count = database.MyUpdateDataExecuteNonQuery(dbCommand);

            database.Dispose();

            return 0 < count;
        }

        private const string KEY_ADMINISTRATORS = "Administrators";
    }
}