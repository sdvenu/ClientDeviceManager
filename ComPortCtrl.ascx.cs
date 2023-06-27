namespace ClientDeviceMgr
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for ComPortCtrl.
	/// </summary>
	public partial class ComPortCtrl : System.Web.UI.UserControl  //Web.PageBase
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if( Page.IsPostBack == false )
			{
			}
		}

		public void SetPortData( String port, String baudRate, String dataBits,
			String parity, String stopBit, String flowControl )
		{
			SetControlValue( ddlPort, port );
			SetControlValue( ddlBaudRate, baudRate );
			SetControlValue( ddlDataBits, dataBits );
			SetControlValue( ddlParityBits, parity );
			SetControlValue( ddlStopBits, stopBit );
			SetControlValue( ddlFlowControl, flowControl );
			ddlPort_SelectedIndexChanged(null,null);
		}

		public void SetDefault( String selectedDriver )
		{
			ddlPort.SelectedIndex = 0;
			if( selectedDriver.StartsWith("PrintDrv.dll" ) )
			{
				ddlBaudRate.SelectedIndex = 8;
				ddlDataBits.SelectedIndex = 3;
				ddlParityBits.SelectedIndex = 0;
				ddlStopBits.SelectedIndex = 0;
				ddlFlowControl.SelectedIndex = 1;
			}
			else if( selectedDriver.StartsWith("AEALiteDrv.dll" ) )
			{
				ddlBaudRate.SelectedIndex = 10;
				ddlDataBits.SelectedIndex = 4;
				ddlParityBits.SelectedIndex = 3;
				ddlStopBits.SelectedIndex = 0;
				ddlFlowControl.SelectedIndex = 1;
			}
			else  // it is ATB2
			{
				ddlBaudRate.SelectedIndex = 10;
				ddlDataBits.SelectedIndex = 4;
				ddlParityBits.SelectedIndex = 3;
				ddlStopBits.SelectedIndex = 0;
				ddlFlowControl.SelectedIndex = 1;
			}
			ddlPort_SelectedIndexChanged(null,null);
		}

		public void GetPortData( out String port, out String baudRate, out String dataBits,
			out String parity, out String stopBits, out String flowControl )
		{
			port = GetControlValue(ddlPort);
			baudRate = GetControlValue(ddlBaudRate);
			dataBits = GetControlValue(ddlDataBits);
			parity = GetControlValue(ddlParityBits);
			stopBits = GetControlValue( ddlStopBits);
			flowControl = GetControlValue(ddlFlowControl);
		}

		private void SetControlValue( DropDownList myControl, String data )
		{
			try
			{
				myControl.SelectedIndex = 0;
				for( int i = 0; i < myControl.Items.Count; i++)
				{
					if( myControl.Items[i].Value == data )
					{
						myControl.SelectedIndex = i;
					}
				}
			}
			catch
			{
			}
		}

		private String GetControlValue( DropDownList ddlControl )
		{
			String retValue = "";
			try
			{
				retValue = ddlControl.SelectedValue;
			}
			catch
			{
			}
			return retValue;
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

		protected void ddlPort_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			bool enabled = false;
			if( ddlPort.SelectedItem.Text.StartsWith("LPT1") )
			{
				enabled = false;
			}
			else
			{
				enabled = true;
			}
			ddlBaudRate.Enabled = enabled;
			ddlDataBits.Enabled = enabled;
			ddlParityBits.Enabled = enabled;
			ddlStopBits.Enabled = enabled;
			ddlFlowControl.Enabled = enabled;
		}
	}
}
