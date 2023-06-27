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

namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for WSSelect.
	/// </summary>
	public partial class RenameWS : Web.PageBase
	{
		public const String MASTER_NODE_TABLE = "MasterNodeTable";
		public const String WSNAME_FIELD = "WSName";
		private string Group = null;
		private string UserIP ="";
		private string HostName = "";
		private string WebForm = "RenameWS";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Group = LoginIfNotAdmin();

			if (!IsPostBack)
			{
				// Put user code to initialize the page here

				lblMessage.Text =
                    "Only a disabled workstation can be renamed." +
					"<br>Step 1: Select the workstation you wish to rename.";
				//set the Tooltip text...
				lblMessage.ToolTip = "You must select a workstation to rename.";
				
                // Move the panels from design position to run position.
                AutoPanel.Style["left"] = "220px";
                AutoPanel.Style["Top"] = "262px";
                ManualPanel.Style["left"] = "220px";
                ManualPanel.Style["Top"] = "262px";
                pnlStatus.Style["left"] = "220px";
                pnlStatus.Style["Top"] = "262px";

				AutoPanel.Visible = false;
				ManualPanel.Visible = true;
				SwapToPanel.Visible = false;
			}

            txtboxWSName.Focus();
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

		protected void ManualSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ManualSelection.Checked == true)
			{
				pnlStatus.Visible = false;
				AutoPanel.Visible = false;
				ManualPanel.Visible = true;
				SwapToPanel.Visible=false;
                //ManualPanel.Style["left"] = "220px";
                //ManualPanel.Style["Top"] = "262px";
				lbxWSNames.ClearSelection();
			}
			else
			{
				pnlStatus.Visible = false;
				AutoPanel.Visible = true;
				ManualPanel.Visible = false;
				SwapToPanel.Visible=false;
                //AutoPanel.Style["left"] = "220px";
                //AutoPanel.Style["Top"] = "262px";
				FillOutAutoPanel();
			}
		}

		protected void AutoSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			if (AutoSelection.Checked == false)
			{
				pnlStatus.Visible = false;
				AutoPanel.Visible = false;
				ManualPanel.Visible = true;
				SwapToPanel.Visible=false;
                //ManualPanel.Style["left"] = "220px";
                //ManualPanel.Style["Top"] = "262px";
			}
			else
			{
				pnlStatus.Visible = false;
				AutoPanel.Visible = true;
				ManualPanel.Visible = false;
				SwapToPanel.Visible=false;
                //AutoPanel.Style["left"] = "220px";
                //AutoPanel.Style["Top"] = "262px";
				FillOutAutoPanel();
			}
		}

		protected void btnManual_Click(object sender, System.EventArgs e)
		{
			string Msg = null;

			if (!IsWorkstationValid(txtboxWSName.Text.Trim()))
			{
				Msg = "You have entered a workstation name that either does not exist or is not disabled." ;
				WSMessage.Text = Msg;
				WSMessage.ForeColor = System.Drawing.Color.Red;
				return;
			}

			//OK let's store off our workstation name...
			Session["WSName"] = txtboxWSName.Text.Trim();
			AutoPanel.Visible = false;
			ManualPanel.Visible = false;
			SwapToPanel.Visible=true;
            //pnlStatus.Style["left"] = "220px";
            //pnlStatus.Style["Top"] = "262px";
			pnlStatus.Visible = true;
			lblMessage.Text = "You are requesting to change workstation <b>" + txtboxWSName.Text.Trim() +
				"</b> to a new name." +
				"<br>Step 2: Enter the new name.";
			lblMessage.ForeColor=System.Drawing.Color.Red;
			WSMessage.Text="";
			ManualSelection.Visible=false;
			AutoSelection.Visible=false;
		}

		protected void btnAuto_Click(object sender, System.EventArgs e)
		{
			string s = lbxWSNames.SelectedValue;
			if (string.IsNullOrEmpty(s))
			{
				WSMessage.Text = "You must select a workstation name from the list " +
					"to rename it.";
				WSMessage.ForeColor = System.Drawing.Color.Red;
				return;
			}
			if (!IsWorkstationValid(s))
			{
				return;
			}
			Session["WSName"] = s.Trim();
			//OK let's store off our workstation name...
			AutoPanel.Visible = false;
			ManualPanel.Visible = false;
			SwapToPanel.Visible=true;
            //pnlStatus.Style["left"] = "220px";
            //pnlStatus.Style["Top"] = "262px";
			pnlStatus.Visible = true;
			lblMessage.Text = "You are requesting to set workstation <b>" + Session["WSName"].ToString() +
				"</b> to a new name." +
				"<br>Step 2: Enter the new name.";
			lblMessage.ForeColor=System.Drawing.Color.Red;
			WSMessage.Text="";
			ManualSelection.Visible=false;
			AutoSelection.Visible=false;
		}

		private void FillOutAutoPanel()
		{
			lblAutoLabel.Text="All workstations current disabled in the database:";
			lblAutoLabel.ForeColor=System.Drawing.Color.Navy;
			Common.Database db = new Database();
			string cmd = "SELECT * FROM MasterNodeTable WHERE Enable = 0";
			DataSet myDS = db.MyFillDataSet(cmd, MASTER_NODE_TABLE);
            db.Dispose();
			if (myDS == null)
				return;
			
			DataView SupportView = myDS.Tables[MASTER_NODE_TABLE].DefaultView;
			SupportView.Sort = WSNAME_FIELD;

			lbxWSNames.DataSource = (ICollection)SupportView;
			lbxWSNames.DataTextField = WSNAME_FIELD;
			lbxWSNames.DataValueField = WSNAME_FIELD;
			lbxWSNames.DataBind();
		}

		private bool IsSameZone(string wSName)
		{
			Common.Database db = new Database();
			string cmd = "SELECT AirportZone FROM MasterNodeTable" +
                " WHERE WSName = '" + wSName + "' AND Enable = 0";
			string zone = db.MyGetDataExecuteScalar(cmd);
            db.Dispose();
			return (zone == wSName);
		}

		private bool IsWorkstationValid(string wSName)
		{
			// to verify workstation's exitance and disabled
			Common.Database db = new Database();
			string cmd = "SELECT AirportZone FROM MasterNodeTable" +
                " WHERE WSName = '" + wSName + "' AND Enable = 0";
			string zone = db.MyGetDataExecuteScalar(cmd);
            db.Dispose();
			return !string.IsNullOrEmpty(zone);
		}

		private bool IsWorkstationExist(string WSName)
		{
			// to verify workstation's existance 
			Common.Database db = new Database();
			string cmd = "SELECT AirportZone FROM MasterNodeTable" +
                " WHERE WSName = '" + WSName + "'";
			string zone = db.MyGetDataExecuteScalar(cmd);
            db.Dispose();
			return !string.IsNullOrEmpty(zone);
		}

		protected void btnSwap_Click(object sender, System.EventArgs e)
		{
						
			if (IsWorkstationExist(txbNewName.Text.ToString()))
			{
				WSMessage.Text= txbNewName.Text.ToString()+" exist, try another name.";
				WSMessage.ForeColor=System.Drawing.Color.Red;
				return;
			}
			UserIP = Request.UserHostAddress;
			HostName = Request.UserHostName;
			string actcmd = "Rename workstation: " + (string)Session["WSName"] + 
				" to " + txbNewName.Text.ToUpper();
			if (RenameWSInDB(Session["WSName"].ToString().Trim()))
			{
				lblMessage.Text=Session["WSName"].ToString() + " renamed to " + txbNewName.Text.Trim().ToUpper() +
					" successfully.<br>You must enable " + txbNewName.Text.Trim().ToUpper()+ " before use.";
				lblMessage.ForeColor=System.Drawing.Color.Navy;
				WSMessage.Text="";
				SwapToPanel.Visible=false;
				logAudit(actcmd,1);
				Session["WSName"] = txbNewName.Text.Trim().ToUpper();
			}
			else
			{
				lblMessage.Text=Session["WSName"].ToString() + " renaming to " + txbNewName.Text.Trim() +
					" failed!<br>Contact your database administrator.";
				lblMessage.ForeColor=System.Drawing.Color.Red;
				WSMessage.Text="";
				logAudit(actcmd,0);
			}
			return;
		
		}

		private bool RenameWSInDB(string name)
		{
			bool bRet = false;
			string [] WSNameDatabaseTables = {
                "AEALiteDrvTable",
                "BGRCfgTable",
                "FileDrvTable",
				"HSSPRouteInfo", 
				"MainRouteConfigTable",
				"MasterNodeTable",
				"MasterNodeExtraTable",
				"OFEPRouteInfo",
				"OSGRouteInfo", 
				"PrintDrvTable"
		    };
			string [] UserIDDatabaseTables = {
                "EmulatorCfgSettings",
                "PFKeyTbl",
                "PFKeyTbl2",
                "QIKKeyTbl",
                "QIKKeyTbl2"
            };

			Common.Database db = new Database();
			string cmd = null;
			if (IsSameZone(name))
			{
				// If airport zone is different from workstation name, zone will left unchanged
				// For workstaion has same name as airport zone , rename airport zone first, workstation name 
				// then will rename in the following steps
				cmd = "UPDATE MasterNodeTable SET AirportZone='" + txbNewName.Text.Trim().ToUpper() + 
					"' WHERE WSName ='" + name.Trim() + "'";
				int i = db.MyUpdateDataExecuteNonQuery(cmd);
			}
			int total = 0;
			foreach(string s in WSNameDatabaseTables)
			{
				cmd = "UPDATE " + s.Trim() + " SET WSName='" + txbNewName.Text.Trim().ToUpper() + 
					"' WHERE WSName ='" + name.Trim() + "'";
				int i = db.MyUpdateDataExecuteNonQuery(cmd);
				total += i;
			}
			foreach(string a in UserIDDatabaseTables)
			{
				cmd = "UPDATE " + a.Trim() + " SET UserID='" + txbNewName.Text.Trim().ToUpper() +
					"' WHERE UserID ='" + name.Trim() + "'";
				int i = db.MyUpdateDataExecuteNonQuery(cmd);
				total += i;				
			}
			if (total > 0)
				bRet = true;
			db.Dispose();			
			return bRet;
		}

		private void logAudit(string cmd, int complete)
		{
			// action log for future auditing
			Common.Database db = new Database();
			string logcmd = "INSERT INTO AuditLogtbl(UserName,UserID,commandStr,WebForm," +
				"UserIP,HostName,Completion) VALUES('" + (string)Session["UsrName"] +"','" +
				(string)Session["WSName"] + "','" + cmd + "','" + WebForm + "','" + UserIP + 
				"','" + HostName +	"','" + complete + "')";
			int k = db.MyUpdateDataExecuteNonQuery(logcmd);
			db.Dispose();
			return;
		}


	}
}
