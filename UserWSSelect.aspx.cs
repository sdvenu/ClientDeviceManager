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
	public partial class UserWSSelect : Web.PageBase
	{

		public const String MASTER_NODE_TABLE = "MasterNodeTable";
		public const String WSNAME_FIELD = "WSName";
		private string Group = null;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Group = LoginIfNotLoggedIn();

			if (!IsPostBack)
			{
				// Put user code to initialize the page here

				if (Group == "USER")
				{
					lblMessage.Text = "Enter the workstation to view.";
					//set the Tooltip text...
					lblMessage.ToolTip = "You must select a workstation name to " +
						"view the configuration information associated with a workstation.";
				}
				else
				{
					lblMessage.Text = "Select the workstation to modify.";
					//set the Tooltip text...
					lblMessage.ToolTip = "You must select a workstation to perform updates or " +
						"view the configuration information associated with a workstation.";
				}

                // Move the panels from the design position to the run position.
                AutoPanel.Style["left"] = "220px";
                AutoPanel.Style["Top"] = "262px";
                ManualPanel.Style["left"] = "220px";
                ManualPanel.Style["Top"] = "262px";
                pnlStatus.Style["left"] = "220px";
                pnlStatus.Style["Top"] = "262px";

                AutoPanel.Visible = false;
				ManualPanel.Visible = true;
				Session["Select"] ="Manual";
				lblManual.Text="workstation Name";
                txtboxWSName.Focus();
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

		protected void ManualSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ManualSelection.Checked == true)
			{
				Session["Select"] ="Manual";
				pnlStatus.Visible = false;
				AutoPanel.Visible = false;
				ManualPanel.Visible = true;
                //ManualPanel.Style["left"] = "220px";
                //ManualPanel.Style["Top"] = "262px";
				lbxWSNames.ClearSelection();
				lblManual.Text="Workstation Name";
				txtboxWSName.Text ="";
				lblMessage.Text = "Enter the workstation name you wish to view.";
				lblMessage.ForeColor=System.Drawing.Color.Navy;
                txtboxWSName.Focus();
			}
            //else
            //{
            //    pnlStatus.Visible = false;
            //    AutoPanel.Visible = true;
            //    ManualPanel.Visible = false;
            //    //AutoPanel.Style["left"] = "220px";
            //    //AutoPanel.Style["Top"] = "262px";
            //}
		}

		protected void AutoSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			if (AutoSelection.Checked == true)
            //{
            //    pnlStatus.Visible = false;
            //    AutoPanel.Visible = false;
            //    ManualPanel.Visible = true;
            //    ManualPanel.Style["left"] = "220px";
            //    ManualPanel.Style["Top"] = "262px";
            //}
            //else
			{
				Session["Select"] = "Auto";
				pnlStatus.Visible = false;
				AutoPanel.Visible = false;
				ManualPanel.Visible = true;
				txtboxWSName.Text ="";
                //AutoPanel.Style["left"] = "220px";
                //AutoPanel.Style["Top"] = "262px";
                lblManual.Text="City code or start of workstation name";
				lblMessage.Text = "Enter the city code or start of a workstation name.";
				lblMessage.ForeColor=System.Drawing.Color.Navy;
                txtboxWSName.Focus();
			}
		}

		protected void btnManual_Click(object sender, System.EventArgs e)
		{
			string Msg = null;

			if ((string)Session["Select"] == "Manual")
			{
				if (!IsWorkstationValid(txtboxWSName.Text.Trim()))
				{
					if (Group == "ADMIN")
					{
						Msg =
                            "You have entered a workstation name that does not exist." +
							" If you wish to create the workstation click the AddWorkstation link"+
							" in the Management Console List";
					}
					else
					{
						Msg =
                            "You have entered a workstation name that does not exist." +
							" Please verify the workstation name you have entered.";
					}
					lblMessage.Text = Msg;
					lblMessage.ForeColor = System.Drawing.Color.Red;
					return;
				}

				//OK let's store off our workstation name...
                lblMessage.Text = "";
				Session["WSName"] = txtboxWSName.Text.Trim();
				AutoPanel.Visible = false;
				ManualPanel.Visible = false;
                //pnlStatus.Style["left"] = "220px";
                //pnlStatus.Style["Top"] = "262px";
				pnlStatus.Visible = true;
				WSMessage.Text =
                    "Your request to set workstation name: " + txtboxWSName.Text.Trim() +
					" was processed. All actions you take will affect this workstation until you return" +
					" to this page and specify a different workstation name.";
			}
			else
			{
				AutoPanel.Visible = true;
				ManualPanel.Visible = false;
                //pnlStatus.Style["left"] = "220px";
                //pnlStatus.Style["Top"] = "262px";
				FillOutAutoPanel();
			}
		}


		protected void btnAuto_Click(object sender, System.EventArgs e)
		{
			string s = lbxWSNames.SelectedValue;
			if (string.IsNullOrEmpty(s))
			{
				lblMessage.Text = "You must select a workstation name from the list " +
					"to proceed with the configuration process.";
				lblMessage.ForeColor = System.Drawing.Color.Red;
				return;
			}
            lblMessage.Text = "";
            Session["WSName"] = s.Trim();
			AutoPanel.Visible = false;
			ManualPanel.Visible = false;
            //pnlStatus.Style["left"] = "220px";
            //pnlStatus.Style["Top"] = "262px";
			pnlStatus.Visible = true;
			WSMessage.Text =
                "Your request to set workstation name: " + s.Trim() +
				" was processed. All actions you take will affect this workstation until you return" +
				" to this page and specify a different workstation name.";
		}

		private void FillOutAutoPanel()
		{
			lblAutoLabel.Text = "All workstations currently configured in the database";
			lblAutoLabel.ForeColor = System.Drawing.Color.Navy;
			Common.Database db = new Database();
			string cmd = "SELECT * FROM MasterNodeTable" +
                " WHERE Enable = 1" +
                " AND WSName Like '" + txtboxWSName.Text.Trim() + "%'"; 
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
			lblAutoLabel.Text = "All disabled workstations in the database";
			lblAutoLabel.ForeColor = System.Drawing.Color.Red;
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

		private bool IsWorkstationValid(string WSName)
		{
			bool bRet = false;
            string workStationName = WSName; // txtboxWSName.Text.Trim();
			try
			{
				Common.Database db = new Database();
				string cmd = "SELECT AirportZone FROM MasterNodeTable" +
                    " WHERE WSName = '" + workStationName + "'";
				string zone = db.MyGetDataExecuteScalar(cmd);
                db.Dispose();
				bRet = !string.IsNullOrEmpty(zone);
			}
			catch(Exception excep)
			{
				Trace.Warn("workstation Not Valid", "Select workstation", excep);
			}
			return bRet;
		}

		protected void lbxWSNames_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}

		protected void DisableSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			if (DisableSelection.Checked == true)
            //{
            //    pnlStatus.Visible = false;
            //    AutoPanel.Visible = false;
            //    ManualPanel.Visible = true;
            //    //ManualPanel.Style["left"] = "220px";
            //    //ManualPanel.Style["Top"] = "262px";
            //}
            //else
			{
				pnlStatus.Visible = false;
				AutoPanel.Visible = true;
				ManualPanel.Visible = false;
                //AutoPanel.Style["left"] = "220px";
                //AutoPanel.Style["Top"] = "262px";
				FillOutDisablePanel();
				lblMessage.Text = "Select the workstation name you wish to view.";
				lblMessage.ForeColor = System.Drawing.Color.Navy;
                lbxWSNames.Focus();
			}		
		}
	}
}
