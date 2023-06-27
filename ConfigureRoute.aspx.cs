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
using ClientDeviceMgr.SystemFramework;

namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for ConfigureRoute.
	/// </summary>
	public partial class ConfigureRoute : Web.PageBase
	{
		private const String HSSP_ROUTE_TABLE = "HSSPRouteInfo";
		private const String OFEP_ROUTE_TABLE = "OFEPRouteInfo";
		private const String LNIATA_FLD = "LNIATA";
        private const String POOLNAME_FLD = "POOLNAME";
        private const String ROUTE_NAME_FLD = "RouteName";
		private const String DEV_TYPE_FLD = "DEVTYPE";
		private const String HSSP_CONFIG_ROUTE_URL = "HsspRoute.aspx";
		private const String OFEP_CONFIG_ROUTE_URL = "OfepRoute.aspx";
		private const String DELETE_ROUTE_URL = "DeleteRoute.aspx";

		public class DataItem
		{
			private String moduleDevType;       //Device Type for this route...
			private String moduleRouteName;     //RouteName for device
			private String moduleLniata;        //LNIATA for route
            private String modulePoolName;      //PoolName for route
            private String moduleUrl;
			private String moduleDelUrl;
        
			/// <summary>
            /// DataItem holds the information to display.
            /// </summary>
			public DataItem(
                String devType,
                String routeName,
                String LNIATA,
                String PoolName,
                String Url,
				String delUrl)
			{
				moduleDevType = devType;
				moduleRouteName = routeName;
				moduleLniata = LNIATA;
                modulePoolName = PoolName;
                moduleUrl = Url;
				moduleDelUrl = delUrl;
			}

			public String IMAGE
			{
				get
				{
					if( moduleDevType.StartsWith("TERMINAL") )
						return "~/images/terminal.png";
                    else
    					return "~/images/printer.png";
				}
			}

			/// <value>
			///     Property Description is used to get the Description string for a category item.
			/// </value>
			public String ROUTENAME
			{
				get
				{
					return moduleRouteName;
				}
			}

            public String LNIATA
            {
                get
                {
                    return moduleLniata;
                }
            }

            public String POOLNAME
            {
                get
                {
                    return modulePoolName;
                }
            }

            public String DEVICETYPE
			{
				get
				{
					return moduleDevType;
				}
			}

			public String Url
			{
				get
				{
					return moduleUrl;
				}
			}

            public String DelUrl
			{
				get
				{
					return moduleDelUrl;
				}
			}
		} //class ConfigureRoute.DataItem
		
		protected string WSName = null;
		private System.Collections.ArrayList moduleDataList;

		public System.Collections.ArrayList RouteList
		{
			get
			{
				return moduleDataList;
			}
		}
	
		public ConfigureRoute()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
            LoginIfNotLoggedIn();
            WSName = SelectWorkstationIfNoneSelected();

			//set our label header...
			CategoryDesciptionLabel.Text = WSName.Trim() + " Route Information";

			DataSet RouteSet = GetHsspRouteInfo();
			//
			// Ensure that we have the category data
			//           
			ApplicationAssert.CheckCondition(null != RouteSet, "No Route data available", ApplicationAssert.LineNumber);
			//

			//
			// get the default view for the data for HSSP routes...
			//
			DataView RouteView = RouteSet.Tables[HSSP_ROUTE_TABLE].DefaultView;
			//
			moduleDataList = new System.Collections.ArrayList();
			String catUrlBase =  Web.PageBase.UrlBase + "/";
			foreach (DataRowView RouteRow in RouteView)
			{
				moduleDataList.Add(new DataItem(
					Server.HtmlEncode(RouteRow[DEV_TYPE_FLD].ToString()),
					Server.HtmlEncode(RouteRow[ROUTE_NAME_FLD].ToString()),
                    Server.HtmlEncode(RouteRow[LNIATA_FLD].ToString()),
                    Server.HtmlEncode(RouteRow[POOLNAME_FLD].ToString()),
                    catUrlBase + HSSP_CONFIG_ROUTE_URL + "?ROUTENAME=" + 
					    Server.HtmlEncode(RouteRow[ROUTE_NAME_FLD].ToString()),
					catUrlBase + DELETE_ROUTE_URL + "?ROUTENAME=" +
					    Server.HtmlEncode(RouteRow[ROUTE_NAME_FLD].ToString())
                ));
			}

			//
			// get the default view for the data for OFEP routes...
			//
			RouteSet = GetOfepRouteInfo();
			//
			// Ensure that we have the category data
			//           
			ApplicationAssert.CheckCondition(null != RouteSet, "No Route data available", ApplicationAssert.LineNumber);
			//
			//
			// get the default view for the data for HSSP routes...
			//
			RouteView = RouteSet.Tables[OFEP_ROUTE_TABLE].DefaultView;

			foreach (DataRowView RouteRow in RouteView)
			{
				moduleDataList.Add(new DataItem(
					Server.HtmlEncode("UNKNOWN"),
					Server.HtmlEncode(RouteRow[ROUTE_NAME_FLD].ToString()),
                    Server.HtmlEncode(RouteRow[LNIATA_FLD].ToString()),
                    Server.HtmlEncode(RouteRow[POOLNAME_FLD].ToString()),
                    catUrlBase + OFEP_CONFIG_ROUTE_URL + "?ROUTENAME=" + 
    					Server.HtmlEncode(RouteRow[ROUTE_NAME_FLD].ToString()),
					catUrlBase + DELETE_ROUTE_URL + "?ROUTENAME=" +
	    				Server.HtmlEncode(RouteRow[ROUTE_NAME_FLD].ToString())));
			}

			//
			// Finally, do the data binding
			//
			DataBind();
		}

		protected void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP+ Windows Form Designer.
			//
			InitializeComponent();
		}

		private DataSet GetHsspRouteInfo()
		{
			DataSet Set = null;
			//let's get our data...
			Common.Database db = new Database();
			string cmd = "SELECT * FROM " + HSSP_ROUTE_TABLE +
                " WHERE WSName = '" + WSName.Trim() +
                "' ORDER BY DEVTYPE DESC, RouteName DESC";
			Set = db.MyFillDataSet(cmd, HSSP_ROUTE_TABLE);
            db.Dispose();
			return Set;
		}

		private DataSet GetOfepRouteInfo()
		{
			DataSet Set = null;
			//let's get our data...
			Common.Database db = new Database();
			string cmd = "SELECT * FROM " + OFEP_ROUTE_TABLE +
                " WHERE WSName = '" + WSName.Trim() +
                "' ORDER BY RouteName DESC";
			Set = db.MyFillDataSet(cmd, OFEP_ROUTE_TABLE);
            db.Dispose();
			return Set;
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

		protected void CategoryList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
#endregion
