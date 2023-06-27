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
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text.RegularExpressions;


namespace ClientDeviceMgr
{
	/// <summary>
	/// Summary description for ConfigPFKey.
	/// </summary>
	public partial class DisplayPFKey : Web.PageBase
	{
		private const String PF_KEYS_HEADER = "HEADER";
		private const String PREVIOUS_PF_KEY = "PREVIOUS_PF_KEY";
		private const String USER_ID = "USER_ID";
		public const String PFKEY_TBL = "PFKEYTBL";
		private const String PF_KEYS = "PF_KEYS";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            LoginIfNotLoggedIn();

            String wsName = (String)Session["WSName"];
			// It is OK without workstation selected
			if( wsName == null || wsName.Length == 0 )
			{
				wsName = "";
			}

			//set our label header...
			CategoryDesciptionLabel.Text = wsName.Trim() + " PFKey Information";

			String []myScript = 
			{
				"<script language=\"JavaScript\">",
				"function DoKeyUp()",
				"{",
				"	var len = 0;",
				"	len=Form1.TextBoxCommand.value.length;",
				"	var oldString = Form1.TextBoxCommand.value.toUpperCase();",
				"	var indexCount=0;",
				"	var newString = \"\";",
				"	var newChar = ' ';",

				"	for (indexCount = 0; indexCount <= len - 1; indexCount++)",
				"	{",
				"		newChar = oldString.charAt(indexCount);",
				"		if( newChar == '[' )",
				"		{",
				"			newChar = '¤';",
				"		}",
				"		else if( newChar == '\\\'' )",
				"		{",
				"			newChar = '¥';",
				"		}",
				"		else if( newChar == '\\\\' )",
				"		{",
				"			newChar = '§';",
				"		}",
				"		else if( newChar == ']' )",
				"		{",
				"			newChar = '¶';",
				"		}",
				"		else if( newChar == '`' )",
				"		{",
				"			newChar = '^';",
				"		}",
				"		else if( newChar == ';' )",
				"		{",
				"			newChar = ' ';",
				"		}",
				"		newString=newString+newChar",
				"	}",
				
				"	Form1.TextBoxCommand.value=newString;",
				"}",
				"</script>"
			};
			String scriptString="";
			for( int i = 0; i < myScript.Length; i++ )
			{
				scriptString += myScript[i];
				scriptString += "\n";
			}
			if(!this.ClientScript.IsClientScriptBlockRegistered("clientScript"))
				this.ClientScript.RegisterClientScriptBlock(this.GetType(), "clientScript", scriptString);

			TextBoxCommand.Attributes["onKeyUp"]="DoKeyUp()";
//			TextBoxCommand.Attributes["onTextChanged"]="DoKeyUp()";
			if( Page.IsPostBack == false)
			{
				PopulateUserList();
				DropDownListUser_SelectedIndexChanged(null,null);
				ButtonGetPFKeys_Click(null,null);
			}
		}

		private void PopulateUserList()
		{
			try
			{
				Common.Database db = new Common.Database();
				String szCommand = "SELECT USERID FROM " + PFKEY_TBL + " ORDER BY USERID";
				DataSet myDS = db.MyFillDataSet(szCommand, PFKEY_TBL);
                db.Dispose();
				if( myDS != null )
				{
					DropDownListUser.DataSource = myDS;
					DropDownListUser.DataTextField = myDS.Tables[0].Columns[0].ColumnName.ToString();
					DropDownListUser.DataBind();
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			base.Render (writer);
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

		private void GetDataForPFKey( int nPFKey )
		{
			if( nPFKey >= 1 && nPFKey <= 24 )
			{
				PFKey [] pfKeys = (PFKey[])Session[PF_KEYS];
				if( pfKeys == null )
				{
					return;
				}
				int index = nPFKey - 1;
				int previousPFKey = (int) Session[PREVIOUS_PF_KEY];
				if( previousPFKey != index)
				{
					StoreToPFKey( previousPFKey );
				}
				DropDownListPF.SelectedIndex = index;
				TextBoxLabel.Text = pfKeys[index].GetPFKeyLabel();
				TextBoxDescription.Text = pfKeys[index].GetPFKeyDescription();
				TextBoxCommand.Text = pfKeys[index].GetPFKeyCommand();
				Session[PREVIOUS_PF_KEY] = index;
			}
		}

		private void StoreToPFKey( int nPFKey )
		{
			PFKey [] pfKeys = (PFKey[])Session[PF_KEYS];
			if( pfKeys == null )
			{
				return;
			}
			pfKeys[nPFKey].SetPFKeyLabel(TextBoxLabel.Text);
			pfKeys[nPFKey].SetPFKeyDescription(TextBoxDescription.Text);
			pfKeys[nPFKey].SetPFKeyCommand(TextBoxCommand.Text);
		}

		protected void DropDownListPF_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GetDataForPFKey( Convert.ToInt32( DropDownListPF.SelectedValue));
		}

		protected void ButtonUpdate_Click(object sender, System.EventArgs e)
		{
			int currentPFKey = Convert.ToInt32( DropDownListPF.SelectedValue)-1;
			StoreToPFKey( currentPFKey );
			String pfKeyData = CreatePFKeyStringForDatabase();
			String userId = (String)Session[USER_ID];
			if( userId == null || userId.Length == 0 )
				return;
			if( pfKeyData != null && pfKeyData.Length > 0)
			{
				String szCmd = "UPDATE " + PFKEY_TBL + " SET PFKEYDATA = '";
				szCmd += pfKeyData;
				szCmd += "' WHERE USERID='";
				szCmd += userId;
				szCmd += "'";
				Common.Database database = new ClientDeviceMgr.Common.Database();
				database.MyUpdateDataExecuteNonQuery(szCmd);
			}
		}

		protected void ButtonCancel_Click(object sender, System.EventArgs e)
		{
			DropDownListPF_SelectedIndexChanged(null,null);
			ButtonGetPFKeys_Click(null,null);
		}

		private void SavePFKeyToDatabase( int nPFKey, String label, String description, String command)
		{
		}

		private void LoadPFKeyForButton( object sender )
		{
			if( sender.GetType().ToString() == "System.Web.UI.WebControls.Button" )
			{
				try
				{
					String buttonText = ((Button)sender).Text;
					int buttonNo = Convert.ToInt32(buttonText.Substring(3,2));
					GetDataForPFKey( buttonNo );
				}
				catch
				{
				}
			}
		}

		protected void ButtonPF1_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF17_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		private String GetPFKeyFromDatabase(String userId)
		{
			try
			{
				String szCmd = "SELECT PFKEYDATA FROM " + PFKEY_TBL +
                    " WHERE USERID = '"+ userId + "'";
				Common.Database db = new ClientDeviceMgr.Common.Database();
				String data = db.MyGetDataExecuteScalar(szCmd);
                db.Dispose();
				return data;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
			}
			return "";
		}

		private void ExtractPFKeyDataFromString( String pfData )
		{
			String header = "";
			PFKey []pfKeys = new PFKey[24];
			for(int i = 0; i < 24; i++)
			{
				pfKeys[i] = new PFKey();
				pfKeys[i].SetPFKeyIndex(i+1);
			}
			try
			{
				Regex regExp = new Regex("[\n]");
				MatchCollection matchList = regExp.Matches(pfData);
				int currentIndex = 0;
				int nextIndex;
				int pfKeyIndex = 0;
				String pfColumn;
				String columnData;
				String pfIndexString;
				for (int i = 0; i < matchList.Count; i++)
				{
					nextIndex = matchList[i].Index;
					pfColumn = pfData.Substring(currentIndex,nextIndex-currentIndex);
					currentIndex = nextIndex+1;
					if( pfColumn.Length == 0 )
					{
						continue;
					}
					if( i < 3 )
					{
						header += pfColumn;
						header +="\n";
						continue;
					}
					int indexOfEqual = pfColumn.IndexOf("=");
					if( indexOfEqual <= 0 )
						continue;
					columnData = pfColumn.Substring(indexOfEqual+1);
					if( pfColumn.StartsWith("TITLE"))
					{
						try
						{
							if( char.IsDigit(pfColumn[6]) == true )
							{
								pfIndexString = pfColumn.Substring(5,2);
							}
							else
							{
								pfIndexString = pfColumn.Substring(5,1);
							}
							pfKeyIndex = Convert.ToInt32(pfIndexString);
							if( pfKeyIndex > 0 )
								pfKeyIndex--;
							pfKeys[pfKeyIndex].SetPFKeyLabel(columnData);
						}
						catch
						{
						}
					}
					else if( pfColumn.StartsWith("DESC"))
					{
						pfKeys[pfKeyIndex].SetPFKeyDescription(columnData);
					}
					else if( pfColumn.StartsWith("CMD"))
					{
						pfKeys[pfKeyIndex].SetPFKeyCommand(columnData);
					}
					//					Console.WriteLine( pfColumn);
				}
			}
			catch
			{
			}
			Session[PF_KEYS] = pfKeys;
			Session[PF_KEYS_HEADER] = header;
		}

		private void InitPFKeys()
		{
			Session[PF_KEYS] = null;
			Session[PF_KEYS_HEADER] = null;
			TextBoxLabel.Text = null;
			TextBoxDescription.Text = null;
			TextBoxCommand.Text = null;
			Session[PREVIOUS_PF_KEY] = 0;
			LabelUserError.Visible = false;
			DropDownListPF.SelectedIndex = 0;
		}

		private String CreatePFKeyStringForDatabase()
		{
			String data = "";
			String header = (String) Session[PF_KEYS_HEADER];
			if( header == null )
			{
				return "";
			}
			data += header;
			PFKey [] pfKeys = (PFKey[]) Session[PF_KEYS];
			if( pfKeys == null )
			{
				return "";
			}
			for(int i = 0; i < 24; i++)
			{
				data += pfKeys[i].ToString();
			}
			return data;
		}

		protected void ButtonPF2_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF3_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF4_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF5_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF6_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF7_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF8_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF9_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF10_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF11_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF12_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF13_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF14_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF15_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF16_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF18_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF19_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF20_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF21_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF22_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF23_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void ButtonPF24_Click(object sender, System.EventArgs e)
		{
			LoadPFKeyForButton(sender);
		}

		protected void TextBoxUser_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void DropDownListUser_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TextBoxUser.Text = DropDownListUser.SelectedItem.Text;
			InitPFKeys();
			LabelUserError.Visible = false;
		}

		protected void ButtonGetPFKeys_Click(object sender, System.EventArgs e)
		{
			String userId = TextBoxUser.Text.ToString().Trim().ToUpper();
			int itemCount = DropDownListUser.Items.Count;
			String compareId;
			bool found = false;
			InitPFKeys();
			for( int i = 0;  i < itemCount; i++)
			{
				compareId = DropDownListUser.Items[i].Text.Trim();
				if( compareId == userId )
				{
					String pfKeyData = GetPFKeyFromDatabase(userId);
					ExtractPFKeyDataFromString(pfKeyData);
					Session[USER_ID] = userId;
					found = true;
					break;
				}
			}
			if( !found )
			{
				Session[PF_KEYS] = null;
			}
			GetDataForPFKey(1);
			LabelUserError.Visible = !found;
			//set our label header...
			CategoryDesciptionLabel.Text = "User " + userId.Trim() + " PFKey Information";

		}
	}

//	class PFKey
//	{
//		private int nPFKey=0;
//		private String label="";
//		private String description="";
//		private String command="";
//		public void SetPFKeyIndex(int nPFKey)
//		{
//			this.nPFKey = nPFKey;
//		}
//		public void SetPFKeyLabel( String label)
//		{
//			this.label = label;
//		}
//		public void SetPFKeyDescription(String description )
//		{
//			this.description = description;
//		}
//		public void SetPFKeyCommand(String command )
//		{
//			this.command = command;
//		}
//		public String GetPFKeyLabel()
//		{
//			return label;
//		}
//		public String GetPFKeyDescription()
//		{
//			return description;
//		}
//		public String GetPFKeyCommand()
//		{
//			return command;
//		}
//		public override String ToString()
//		{
//			return "TITLE"+nPFKey+"="+label+"\nDESC"+nPFKey+"="+description+"\nCMD"+nPFKey+"="+command+"\n";
//		}
//	};
}
