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
	/// Summary description for DisableWS.
	/// </summary>
	public partial class DisableWS : Web.PageBase
	{

		public const String MASTER_NODE_TABLE = "MasterNodeTable";
		public const String WSNAME_FIELD = "WSName";
		private string Group = null;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            Group = LoginIfNotLoggedIn();

			if (!IsPostBack)
			{
				// Put user code to initialize the page here

				if (Group == "USER")
				{
					lblMessage.Text = "Select the workstation to disable.";
					//set the Tooltip text...
					lblMessage.ToolTip = "You must select a workstation before " +
						"changing the associated Enable/Disable state.";
				}
				else
				{
					lblMessage.Text = "Select the workstation to disable.";
					//set the Tooltip text...
					lblMessage.ToolTip = "You must select a workstation before performing state changes.";
				}
				AutoPanel.Visible = false;
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

		private bool DisableWSFromDB(string name)
		{
			bool bRet = false;
			
			Common.Database db = new Database();
			string cmd = null;
			if (btnAuto.Text=="Enable")
			{
				cmd = "UPDATE " + MASTER_NODE_TABLE + " set Enable=1 " + " WHERE WSName = '" +
					name.Trim() + "'";
			}
             
			if (btnAuto.Text=="Disable")
			{
				cmd = "UPDATE " + MASTER_NODE_TABLE + " set Enable=0 " + " WHERE WSName = '" +
					name.Trim() + "'";
			}
			int i = db.MyUpdateDataExecuteNonQuery(cmd);
			if (i>0)
				bRet = true;

			return bRet;
		}


		protected void btnAuto_Click(object sender, System.EventArgs e)
		{
			string s = lbxWSNames.SelectedValue.Trim();
            if (string.IsNullOrEmpty(s))
			{
				lblMessage.Text = "You must select a workstation name from the list " +
					"to proceed with the configuration process.";
				lblMessage.ForeColor = System.Drawing.Color.Red;
				return;
			}
			if (DisableWSFromDB(s))
			{
				lblMessage.Text = s.Trim() + " was successfully " + btnAuto.Text + "d in the database.";
				lblMessage.ForeColor = System.Drawing.Color.Navy;
				if (btnAuto.Text=="Disable")
					FillOutAutoPanel();
				else
					FillOutDisablePanel();
			}
			else
			{
				lblMessage.Text = "An error occured attempting to change " + s.Trim() +
					" in the database. Please notify your database administrator.";
				lblMessage.ForeColor = System.Drawing.Color.Red;
			}
		}


		protected void AutoSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			if (AutoSelection.Checked == false)
			{
				pnlStatus.Visible = false;
				AutoPanel.Visible = false;
			}
			else
			{
				pnlStatus.Visible = false;
				AutoPanel.Visible = true;
				AutoPanel.Style["left"] = "220px";
				AutoPanel.Style["Top"] = "262px";
				FillOutAutoPanel();
				if (Group=="ADMIN")
					btnAuto.Text="Disable";
				else 
					btnAuto.Visible=false;
			}

		}

		protected void DisableSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			if (DisableSelection.Checked == false)
			{
				pnlStatus.Visible = false;
				AutoPanel.Visible = false;
			}
			else
			{
				pnlStatus.Visible = false;
				AutoPanel.Visible = true;
				AutoPanel.Style["left"] = "220px";
				AutoPanel.Style["Top"] = "262px";
				FillOutDisablePanel();
				if (Group=="ADMIN")
					btnAuto.Text="Enable";
				else
					btnAuto.Visible=false;
			}	
		}
		private void FillOutAutoPanel()
		{
			lblAutoLabel.Text="All workstations current configured in the database:";
			lblAutoLabel.ForeColor=System.Drawing.Color.Navy;
			Common.Database db = new Database();
			string cmd = "SELECT * FROM MasterNodeTable WHERE Enable = 1";
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


		private void FillOutDisablePanel()
		{
			lblAutoLabel.Text="All workstations disabled in the database:";
			lblAutoLabel.ForeColor=System.Drawing.Color.Red;
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
	}
}
