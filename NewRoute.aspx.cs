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

namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for NewRoute.
	/// </summary>
	public partial class NewRoute : Web.PageBase
	{
		protected String WSName = null;
		protected String RouteName = null;
		protected String Group = null;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            Group = LoginIfNotLoggedIn();
            WSName = SelectWorkstationIfNoneSelected();

            txtboxNewRoute.Attributes["onKeyUp"]="LimitToUppercase(NewRouteForm.txtboxNewRoute)";
			if (!IsPostBack)
			{
                if (Group != "ADMIN")
				{
					WelcomeMsg.Text = "Only an administrator can create a new route.";
					WelcomeMsg.ForeColor = System.Drawing.Color.Red;
					btnCreate.Visible = false;
					txtboxNewRoute.ReadOnly = true;
					return;
				}

				WelcomeMsg.Text = "Enter the RouteName you wish to create for workstation " +
					WSName.Trim() + ".";
				WelcomeMsg.ForeColor = System.Drawing.Color.Navy;

				ProtocolDropDownList.DataSource = CreateDataSource();
				ProtocolDropDownList.DataTextField = "Protocol";
				ProtocolDropDownList.DataValueField = "Protocol";
				ProtocolDropDownList.DataBind();
			}

            txtboxNewRoute.Focus();
		}

		private ICollection CreateDataSource()
		{
            DataTable dt = new DataTable();
			DataRow dr;

			dt.Columns.Add(new DataColumn("Protocol", typeof(string)));

            dr = dt.NewRow();
			dr[0] = "HSSP";

			dt.Rows.Add(dr);
			dr = dt.NewRow();
			dr[0] = "OFEP";
			dt.Rows.Add(dr);
			DataView dv = new DataView(dt);
			return dv;

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
            string NewRoute = txtboxNewRoute.Text.Trim().ToUpper();
			string Protocol = ProtocolDropDownList.SelectedValue;
			
			//OK let's redirect our response over to the HSSPRoute.aspx so that the
			//route can be created...
			string URL = ProtocolDropDownList.SelectedValue;
			URL += "Route.aspx?ROUTENAME=" + NewRoute;
			Response.Redirect(URL, true);
		}
	}
}
