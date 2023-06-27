<%@ Page language="c#" Codebehind="ConfigurePtr.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.ConfigurePtr" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConfigPtr</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<asp:Label id="Label5" style="Z-INDEX: 110; LEFT: 312px; POSITION: absolute; TOP: 304px" runat="server"
				Width="160px" Height="24px" Font-Bold="True" Font-Size="X-Small" ForeColor="#FF8000">Device name and Router name must be the same.</asp:Label><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
			<!-- END PAGE HEADER MODULE -->
			<table cellSpacing="0" cellPadding="0" width="10%" border="0">
				<tr>
					<td class="navtable" vAlign="top" width="1%">
						<table cellSpacing="10" cellPadding="0" width="100%" border="0">
							<!-- BEGIN DYNAMIC LEFT MODULE LIST -->
							<tr>
								<td style="PADDING-TOP: 5px" align="left"><MODULE:SUPPORT id="Support1" runat="server"></MODULE:SUPPORT></td>
							</tr>
							<!-- END DYNAMIC LEFT MODULE LIST --></table>
					</td>
				</tr>
			</table>
			<asp:label id="Label1" style="Z-INDEX: 100; LEFT: 312px; POSITION: absolute; TOP: 144px" runat="server">Select a Print Driver to Configure</asp:label>
            <asp:dropdownlist id="ddlDrivers" style="Z-INDEX: 101; LEFT: 312px; POSITION: absolute; TOP: 176px"
				runat="server" Width="120px" AutoPostBack="True" onselectedindexchanged="ddlDrivers_SelectedIndexChanged"></asp:dropdownlist>
            <asp:label id="Label2" style="Z-INDEX: 102; LEFT: 312px; POSITION: absolute; TOP: 256px" runat="server">New Device Name to Configure</asp:label><asp:textbox id="TextBoxDeviecName" style="Z-INDEX: 103; LEFT: 312px; POSITION: absolute; TOP: 280px"
				runat="server" MaxLength="20" ontextchanged="TextBoxDeviecName_TextChanged"></asp:textbox>
            <asp:button id="buttonNext" style="Z-INDEX: 104; LEFT: 688px; POSITION: absolute; TOP: 352px"
				runat="server" Width="80" Enabled="False" Text="Next >>" Height="24" onclick="buttonNext_Click"></asp:button>
            <asp:label id="Label3" style="Z-INDEX: 105; LEFT: 240px; POSITION: absolute; TOP: 96px" runat="server"
				Font-Size="Medium" Font-Bold="True">Printer Driver Selection</asp:label>
            <asp:label id="Label4" style="Z-INDEX: 106; LEFT: 568px; POSITION: absolute; TOP: 256px" runat="server">Existing device to Configure</asp:label><asp:dropdownlist id="ddlDeviceNames" style="Z-INDEX: 107; LEFT: 568px; POSITION: absolute; TOP: 280px"
				runat="server" AutoPostBack="True" onselectedindexchanged="ddlDeviceNames_SelectedIndexChanged"></asp:dropdownlist>
			<asp:Button id="buttonDelete" style="Z-INDEX: 108; LEFT: 568px; POSITION: absolute; TOP: 352px"
				runat="server" Text="Delete" Enabled="False" onclick="buttonDelete_Click"></asp:Button>
			<asp:Label id="labelStatus" style="Z-INDEX: 109; LEFT: 312px; POSITION: absolute; TOP: 424px"
				runat="server" Font-Bold="True" Font-Size="Small" Visible="False"></asp:Label></form>
	</body>
</HTML>
