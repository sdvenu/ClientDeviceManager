namespace ClientDeviceMgr
{
	using System;
	using System.Data;
	using System.Text;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using ClientDeviceMgr.Common;
	using ClientDeviceMgr.Web;
	using ClientDeviceMgr.Common.Data;
	using ClientDeviceMgr.SystemFramework;

	/// <summary>
	///		Summary description for SupportOptions.
	/// </summary>
	public partial class SupportOptions : ModuleBase
	{
		/// <summary>
		///     This inner class is used to access a single item for the categories list.
		/// </summary>
		public class DataItem
		{
			private String moduleDescription; //Description for the category
			private String moduleUrl;         //URL for obtaining category listing
        
			/// <summary>
			///     Constructor for DataItem:  saves the target and description.
			///     <param name="description">The description for the category item.</param>
			///     <param name="target">The URL to link to for this category item.</param>
			/// </summary>
			public DataItem(String description, String target)
			{
				moduleDescription = description;
				moduleUrl = target;
			}
        
			/// <value>
			///     Property Description is used to get the Description string for a category item.
			/// </value>
			public String Description
			{
				get
				{
					return moduleDescription;
				}
			}
        
			/// <value>
			///     Property URL is used to get the URL string for a category item.
			/// </value>
			public String Url
			{
				get
				{
					return moduleUrl;
				}
			}
		} //class SupportOptions.DataItem
    
		private System.Collections.ArrayList moduleDataList;

		private const String KEY_PREFIX = "Cache:SupportOptions:";

		/// <value>
		///     Property SubCategoryList is used to get the ArrayList control that contains the list of
		///     the top level operations to display.
		/// </value>
		public System.Collections.ArrayList SubCategoryList
		{
			get
			{
				return moduleDataList;
			}
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
            string Group = Session["Group"] as string;
            string Key = KEY_PREFIX + (Group ?? ":Unknown");
			DataSet SupportOptions = Session[Key] as DataSet;

			if (null == SupportOptions)
			{
				// There's no data in the cache so load it
				SupportOptions = GetSupportOptions();

				// Now cache the data
                Session[Key] = SupportOptions;
			}

			// Ensure that we have the category data
			ApplicationAssert.CheckCondition(null != SupportOptions, "No Support data available", ApplicationAssert.LineNumber);

			// Get the default view for the data
			DataView SupportView = SupportOptions.Tables[SupportData.SUPPORT_OPTIONS_TABLE].DefaultView;

			moduleDataList = new System.Collections.ArrayList();
			String catUrlBase = PageBase.UrlBase + "/";
			foreach (DataRowView SupportRow in SupportView)
			{
				moduleDataList.Add(
                    new DataItem(
                        Server.HtmlEncode(SupportRow[SupportData.DESCRIPTION_FIELD].ToString()),
                        catUrlBase + SupportRow[SupportData.WEB_FORM_FIELD].ToString())); 
			}

			// Finally, do the data binding
			DataBind();
		}

		private DataSet GetSupportOptions()
		{
			DataSet Set = null;
			string Rights = (string)Session["Group"];
			if (string.IsNullOrEmpty(Rights))
				return Set;

			//let's get our data...
            Common.Database db = new Database();
			string cmd = "SELECT * FROM SupportOptions" +
                " WHERE Rights = '" + Rights.Trim() +
                "' ORDER BY MenuOrder";
			Set = db.MyFillDataSet(cmd, SupportData.SUPPORT_OPTIONS_TABLE);
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion
	}
}
