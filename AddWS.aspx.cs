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
using ClientDeviceMgr.Web;
using ClientDeviceMgr.Common.Data;
using ClientDeviceMgr.SystemFramework;
using System.Configuration;

namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for AddWS.
	/// </summary>
	public partial class AddWS : Web.PageBase
	{
		//		protected System.String MASTER_NODE_TBL = "MasterNodeTable";
		protected System.String EMUL_SETTINGS_TBL = "EmulatorCfgSettings";
		protected System.String PFKEY_SETTINGS_TBL = "PFKeyTbl";
		protected System.String QKEY_SETTINGS_TBL = "QIKKeyTbl";
		protected const String COLUMN_AIRPORT_ZONE = "AIRPORTZONE";
		private string UserIP ="";
		private string HostName = "";
		private string WebForm = "AddWS";

		//		private bool m_bTestBox = false;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//			string TestBox = ConfigurationSettings.AppSettings["TESTBOX"];
			//			if ((TestBox !=null) && (TestBox =="1"))
			//				m_bTestBox=true;
			if (!IsPostBack)
			{
				MainMsg.Text = "Enter the name of the workstation you wish " +
					"to add to the database.";
				LoadAirportZoneList();
				ZoneRadioToggled(true);
				tbNewZone.Text="";
                WSNameToCreate.Focus();
			}
			else
			{
			}
			WSNameToCreate.Attributes["onKeyUp"]="LimitToUppercase(AddWSForm.WSNameToCreate)";
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

		protected void btnCreate_Click(object sender, System.EventArgs e)
		{
			//String selected = lbAirportZone.SelectedIndex.ToString();
			WSNameToCreate.Text = WSNameToCreate.Text.ToUpper().Trim();
			if( rbDefaultAZ.Checked == true )
			{
				tbNewZone.Text = WSNameToCreate.Text;
			}
			tbNewZone.Text = tbNewZone.Text.Trim().ToUpper();

			UserIP = Request.UserHostAddress;
			HostName = Request.UserHostName;
			string actcmd = "Add workstation " + WSNameToCreate.Text.Trim().ToUpper();
			if (CreateNewUserInDB())
			{
				Label1.Text = WSNameToCreate.Text.Trim().ToUpper() + " with Zone " +
					tbNewZone.Text+ " was successfully added to the master database.";
				Label1.ForeColor = System.Drawing.Color.Navy;
				logAudit(actcmd,1);
			}
			else
			{
				Label1.Text = "An error occured while attempting to create workstation " +
					WSNameToCreate.Text.Trim() + " with zone : " + tbNewZone.Text +
					". Please notify your database administrator.";
				Label1.ForeColor = System.Drawing.Color.Red;
				logAudit(actcmd,0);
			}
			return;
		}

		private bool CreateNewUserInDB()
		{
			Database db = new Database();
            
			string querycmd = "SELECT * FROM " + WSSelect.MASTER_NODE_TABLE +
                " where WSName = '" + WSNameToCreate.Text.Trim() + "'";

			string insertcommand = "INSERT INTO " + WSSelect.MASTER_NODE_TABLE + 
				"(WSName," + "AirportZone)" +
				" VALUES('"	+ WSNameToCreate.Text.Trim() + "','" + tbNewZone.Text.Trim() + "')";
			//string insertcommand = "INSERT INTO " + WSSelect.MASTER_NODE_TABLE + " VALUES('" +
			//	WSNameToCreate.Text.Trim() + "','" + tbNewZone.Text.Trim() +
			//	"',newid())";

			if (!db.CreateTableIfNotExist(querycmd, insertcommand, WSSelect.MASTER_NODE_TABLE))
				return false;

			if (!CreateEmulSettings(db))
				return false;

			if (!CreatePFKeyDefaults(db))
				return false;

			if (!CreateQIKKeyDefaults(db))
				return false;

			return true;
		}

		private string GetEmulSettings(Database db)
		{
			string EmulStuff = "";

			string cmd = "SELECT EmulParams FROM " + EMUL_SETTINGS_TBL +
                " WHERE UserID = '" + tbNewZone.Text + "'";
			EmulStuff = db.MyGetDataExecuteScalar(cmd);
			if( EmulStuff == null ) // then selected zone does not exist
			{
				cmd = "SELECT EmulParams FROM " + EMUL_SETTINGS_TBL +
                    " WHERE UserID = 'DEFAULT'";
				EmulStuff = db.MyGetDataExecuteScalar(cmd);
			}
            db.Dispose();
			return EmulStuff;
		}

		private string GetPFKeyDefaults(Database db)
		{
			string PFKeyStuff = "";
			string cmd = "SELECT PFKeyData FROM " + PFKEY_SETTINGS_TBL +
                " WHERE UserID = '" + tbNewZone.Text + "'";
			PFKeyStuff = db.MyGetDataExecuteScalar(cmd);
			if( PFKeyStuff == null ) // then use the default zone
			{
				cmd = "SELECT PFKeyData FROM " + PFKEY_SETTINGS_TBL +
                    " WHERE UserID = 'DEFAULT'";
				PFKeyStuff = db.MyGetDataExecuteScalar(cmd);
			}
            db.Dispose();
			return PFKeyStuff;
		}

		private string GetQIKKeyDefaults(Database db)
		{
			string QIKKeyStuff = "";
			string cmd = "SELECT QIKKeyData FROM " + QKEY_SETTINGS_TBL +
                " WHERE UserID = '" + tbNewZone.Text + "'";
			QIKKeyStuff = db.MyGetDataExecuteScalar(cmd);
			if( QIKKeyStuff == null ) // then use the default
			{
				cmd = "SELECT QIKKeyData FROM " + QKEY_SETTINGS_TBL +
                    " WHERE UserID = 'DEFAULT'";
				QIKKeyStuff = db.MyGetDataExecuteScalar(cmd);
			}
            db.Dispose();
			return QIKKeyStuff;
		}

		private bool CreateQIKKeyDefaults(Database db)
		{
			string QKeys = GetQIKKeyDefaults(db);

			string querycmd = "SELECT * FROM " + QKEY_SETTINGS_TBL +
                " WHERE UserID = '" + WSNameToCreate.Text.Trim() + "'";
			string insertcommand = "INSERT INTO " + QKEY_SETTINGS_TBL + 
				"(UserID,QIKKeyData)" +
				" VALUES('" + WSNameToCreate.Text.Trim() + "','" + QKeys.Trim() + "')";
			//string insertcommand = "INSERT INTO " + QKEY_SETTINGS_TBL + " VALUES('" +
			//	WSNameToCreate.Text.Trim() + "','" + QKeys.Trim() + "',newid())";

			return db.CreateTableIfNotExist(querycmd, insertcommand, QKEY_SETTINGS_TBL);
		}

		private bool CreatePFKeyDefaults(Database db)
		{
			string PFKeyData = GetPFKeyDefaults(db);
			if (PFKeyData == null)
				PFKeyData = "";

			string querycmd = "SELECT * FROM " + PFKEY_SETTINGS_TBL +
                " WHERE UserID = '" + WSNameToCreate.Text.Trim() + "'";

			string insertcommand = "INSERT INTO " + PFKEY_SETTINGS_TBL + 
				"(UserID,PFKeyData)" +
				" VALUES('" + WSNameToCreate.Text.Trim() + "','" + PFKeyData.Trim() + "')";
			//			string insertcommand = "INSERT INTO " + PFKEY_SETTINGS_TBL + " VALUES('" +
			//				WSNameToCreate.Text.Trim() + "','" + PFKeyData.Trim() + "',newid())";

			return db.CreateTableIfNotExist(querycmd, insertcommand, PFKEY_SETTINGS_TBL);
		}

		private bool CreateEmulSettings(Database db)
		{
			string EmulData = GetEmulSettings(db);

			string querycmd = "SELECT * FROM " + EMUL_SETTINGS_TBL +
                " WHERE UserID = '" + tbNewZone.Text.Trim() + "'";
			string insertcommand = "INSERT INTO " + EMUL_SETTINGS_TBL + 
				"(EmulParams,UserID)" +
				" VALUES('" + EmulData.Trim() + "','" + tbNewZone.Text.Trim() + "')";
			//string insertcommand = "INSERT INTO " + EMUL_SETTINGS_TBL + " VALUES('" +
			//	EmulData.Trim() + "','" + WSNameToCreate.Text.Trim() + "','0', newid())";

			return db.CreateTableIfNotExist(querycmd, insertcommand, EMUL_SETTINGS_TBL);
		}

		private void ZoneRadioToggled( bool defaultZone )
		{
			lbAirportZone.Enabled = !defaultZone;
			lbAirportZone.Visible = !defaultZone;
			lblNewZone.Enabled = !defaultZone;
			tbNewZone.Enabled = !defaultZone;
			lblSelectZone.Enabled = !defaultZone;
			tbNewZone.Text = WSNameToCreate.Text;
			rbDefaultAZ.Checked = defaultZone;
			rbAirportZone.Checked = !defaultZone;
		}

		protected void rbDefaultAZ_CheckedChanged(object sender, System.EventArgs e)
		{
			ZoneRadioToggled(true);
		}

		protected void rbAirportZone_CheckedChanged(object sender, System.EventArgs e)
		{
			ZoneRadioToggled(false);
		}

		private void LoadAirportZoneList()
		{
			DataSet ds;
			String szCmd = "SELECT DISTINCT AirportZone FROM " + WSSelect.MASTER_NODE_TABLE;
			Common.Database database = new ClientDeviceMgr.Common.Database();
			ds = database.MyFillDataSet(szCmd,WSSelect.MASTER_NODE_TABLE);
			if( ds != null )
			{
				lbAirportZone.Items.Clear();
				DataView SupportView = ds.Tables[0].DefaultView;
				SupportView.Sort = COLUMN_AIRPORT_ZONE;
				lbAirportZone.DataSource = (ICollection)SupportView;
				lbAirportZone.DataTextField = COLUMN_AIRPORT_ZONE;
				lbAirportZone.DataValueField = COLUMN_AIRPORT_ZONE;
                try { lbAirportZone.SelectedValue = "DEFAULT"; } catch (ArgumentOutOfRangeException) { }
				lbAirportZone.DataBind();
                ds.Dispose();
			}
		}

		protected void lbAirportZone_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				tbNewZone.Text = lbAirportZone.SelectedItem.Text;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void logAudit(string cmd, int complete)
		{
			// action log for future auditing
			Common.Database db = new Database();
			string logcmd = "INSERT INTO AuditLogtbl(UserName,UserID,commandStr,WebForm," +
				"UserIP,HostName,Completion) VALUES('" + (string)Session["UsrName"] +"','" +
				WSNameToCreate.Text.Trim().ToUpper() +"','" + cmd + "','" +WebForm + "','" + UserIP + 
				"','" + HostName +	"','" + complete +"')";
			int k = db.MyUpdateDataExecuteNonQuery(logcmd);
			db.Dispose();
			return;
		}
	}
}
