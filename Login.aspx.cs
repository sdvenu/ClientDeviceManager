using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ClientDeviceMgr.Common;
using System.IO;
using System.Text;

namespace ClientDeviceMgr
{
    /// <summary>
    /// Summary description for WebForm1.
    /// </summary>
    public partial class WebForm1 : Web.PageBase
    {
        protected string RootID = "S003233";
        protected string RootPassword = "|ys{DRj";

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                txtBoxUserID.Focus();
            }
            else
            {
                txtBoxPassword.Focus();
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

        protected void btnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                Common.Database db = new Database();

                if (IsRootLogin(db))
                {
                    db.Dispose();
                    Response.Redirect("SP_Welcome.aspx");
                    return;
                }

                string cmd = "SELECT * FROM ManagementRightsTbl" +
                    " WHERE UserID = '" + txtBoxUserID.Text.Trim() + "'";
                DataSet myDS = db.MyFillDataSet(cmd, "UserInfo");
                db.Dispose();
                if (myDS == null)
                {
                    lblErrorMsg.Text = "The database cannot be accessed";
                    //lblErrorMsg.Text = "The database cannot be accessed: " + db.MyDbConnectionString();
                    txtBoxUserID.Text = "";
                    return;
                }
                DataTable cfgTable = myDS.Tables["UserInfo"];
                if (cfgTable == null)
                {
                    lblErrorMsg.Text = "No login information in the database";
                    txtBoxUserID.Text = "";
                    return;
                }

                //Ok let's see if the user matched...
                if (cfgTable.Rows.Count == 0)
                {
                    NoteUserAccess(db, txtBoxUserID.Text, false);

                    lblErrorMsg.Text = "No user named " + txtBoxUserID.Text;
                    //logDebug.Debug("Incorrect User Name Supplied " + txtBoxUserID.Text);

                    txtBoxUserID.Text = "";
                    txtBoxPassword.Text = "";

                    return;
                }

                //Ok let's see if our password matched...
                if (txtBoxPassword.Text.Trim() != CryptStr(cfgTable.Rows[0][1].ToString().Trim()))
                {
                    NoteUserAccess(db, txtBoxUserID.Text, false);

                    lblErrorMsg.Text = "Incorrect Password supplied.";
                    //logDebug.Debug("Incorrect Password Supplied");

                    txtBoxPassword.Text = "";

                    return;
                }

                NoteUserAccess(db, txtBoxUserID.Text, true);

                //logDebug.Debug("User Logged In. " + txtBoxUserID.Text);
                txtBoxPassword.Text = "";

                //let's set up our session variables for use later...
                Session["usrName"] = cfgTable.Rows[0][0].ToString().Trim();
                Session["Group"] = cfgTable.Rows[0][2].ToString().Trim();

                //OK send down the correct page...
                if ((string)Session["Group"] == "USER")
                    Response.Redirect("UserWelcome.aspx", true);
                if ((string)Session["Group"] == "ADMIN")
                    Response.Redirect("Welcome.aspx", true);
                if ((string)Session["GROUP"] == "SUPER")
                    Response.Redirect("SP_Welcome.aspx");
                else
                    lblErrorMsg.Text = "Unknown group for user";
            }
            catch(Exception ex)
            {
                lblErrorMsg.Text = "Login exception occurred: " + ex.Message;
                txtBoxPassword.Text = "";
            }
        }

        private bool IsRootLogin(Database db)
        {
            if ((txtBoxUserID.Text.ToString() == RootID) &&
                (CryptStr(txtBoxPassword.Text.Trim()) == RootPassword))
            {
                Session["usrName"] = RootID;
                Session["Group"] = "SUPER";

                NoteUserAccess(db, RootID, true);
                return true;
            }
            else
                return false;
        }

        private void NoteUserAccess(Database db, string UserID, bool Success)
        {
            if (string.IsNullOrEmpty(UserID))
                return;

            try
            {
                // Get the time when the user attempted login.
                string Current = DateTime.Now.ToUniversalTime().ToString("u");

                // Get the IP address of the client.
                string Identity = HttpContext.Current.Request.UserHostAddress ?? "Unknown";

                string Command;

                if (Success)
                    Command =
                        // Update the entry or insert a new successful login entry.
                        "UPDATE ManagementRightsExtraTbl SET " +
                        "LoginTime = '" + Current + "', " +
                        "LoginAddress = '" + Identity + "', " +
                        "LoginFailures = 0" +
                        " WHERE UserID = '" + UserID + "'" +
                        "; IF @@ROWCOUNT = 0 " +
                        "INSERT INTO ManagementRightsExtraTbl " +
                        "(UserID, IsEnabled, LoginFailures, LoginTime, LoginAddress) VALUES ('" + 
                        UserID + "', 1, 0, '" + Current + "', '" + Identity + "')";
                else
                    Command =
                        // Update the entry or insert a new failed login entry.
                        "UPDATE ManagementRightsExtraTbl SET " +
                        "LoginFailures = LoginFailures + 1, " +
                        "LoginFailedTime = '" + Current + "', " +
                        "LoginFailedAddress = '" + Identity + "'" +
                        " WHERE UserID = '" + UserID + "'" +
                        "; IF @@ROWCOUNT = 0 " +
                        "INSERT INTO ManagementRightsExtraTbl " +
                        "(UserID, IsEnabled, LoginFailures, LoginFailedTime, LoginFailedAddress) VALUES ('" +
                        UserID + "', 1, 1, '" + Current + "', '" + Identity + "')";

                // Try to record the information.
                db.MyUpdateDataExecuteNonQuery(Command);
            }
            catch (Exception e)
            {
                //logDebug.Error("NoteWorkstationAccess exception", e);
                string msg = e.Message;
            }
        }

        private string CryptStr(string strIn)
        {
            XorCrypt xor = new XorCrypt();
            MemoryStream instream = new MemoryStream();
            MemoryStream outstream = new MemoryStream();
            byte[] bufin = new byte[strIn.Length];
            for (int i = 0; i < strIn.Length; i++)
            {
                bufin[i] = ((byte)strIn[i]);
            }

            instream.Write(bufin, 0, bufin.Length);
            instream.Position = 0;
            xor.XorStream(instream, outstream);
            outstream.Position = 0;
            byte[] bufout = outstream.ToArray();
            StringBuilder result = new StringBuilder(8);
            foreach (byte b in bufout)
                result.Append(Convert.ToChar(b & 0x7f));
            return result.ToString();
            //?? return Encoding.ASCII.GetString(bufout);
        }
    }
}

