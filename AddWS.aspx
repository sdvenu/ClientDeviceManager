<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Page language="c#" Codebehind="AddWS.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.AddWS" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Add Workstation Configuration Screen</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="AddWSForm" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<TABLE id="Table1" style="Z-INDEX: 107; LEFT: 288px; WIDTH: 248px; POSITION: absolute; TOP: 284px; HEIGHT: 53px"
				cellSpacing="1" cellPadding="1" width="248" border="1">
				<TR>
					<TD style="width:240px;"><asp:radiobutton id="rbDefaultAZ" runat="server" AutoPostBack="True" Checked="True" Text="'Workstation Name' Airport Zone" oncheckedchanged="rbDefaultAZ_CheckedChanged"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD style="width:300px; height:25px;"><asp:radiobutton id="rbAirportZone" runat="server" AutoPostBack="True" Text="Existing Airport Zone" oncheckedchanged="rbAirportZone_CheckedChanged"></asp:radiobutton></TD>
				</TR>
			</TABLE>
			<asp:label id="lblSelectZone" style="Z-INDEX: 110; LEFT: 560px; POSITION: absolute; TOP: 360px"
				runat="server">Select a Zone</asp:label><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
			<!-- END PAGE HEADER MODULE -->
			<table cellSpacing="0" cellPadding="0" width="10%" border="0">
				<tr>
					<td class="navtable" vAlign="top" width="1%">
						<table cellSpacing="10" cellPadding="0" width="100%" border="0">
							<!-- BEGIN DYNAMIC LEFT MODULE LIST -->
							<tr>
								<td style="PADDING-TOP: 5px" align="left"><MODULE:SUPPORT id="SupportOpts" runat="server"></MODULE:SUPPORT></td>
							</tr>
							<!-- END DYNAMIC LEFT MODULE LIST --></table>
					</td>
				</tr>
			</table>
			<script src="ClientDeviceMgr.js"></script>
			<asp:label id="MainMsg" style="Z-INDEX: 101; LEFT: 288px; POSITION: absolute; TOP: 80px" runat="server"
				Font-Bold="True" ForeColor="#000040" Height="96px" Width="368px"></asp:label>
            <asp:label id="lblWSName" style="Z-INDEX: 102; LEFT: 288px; POSITION: absolute; TOP: 203px"
				runat="server" Width="88px">Workstation:</asp:label>
            <asp:textbox id="WSNameToCreate" style="Z-INDEX: 103; LEFT: 400px; POSITION: absolute; TOP: 200px"
				runat="server" MaxLength="32"></asp:textbox>
            <asp:button id="btnCreate" style="Z-INDEX: 104; LEFT: 576px; POSITION: absolute; TOP: 200px"
				runat="server" Text="Create" onclick="btnCreate_Click"></asp:button>
            <asp:label id="Label1" style="Z-INDEX: 105; LEFT: 600px; POSITION: absolute; TOP: 248px" runat="server"
				Font-Bold="True" ForeColor="Red" Height="88px" Width="344px"></asp:label>
            <asp:requiredfieldvalidator id="RequiredFieldValidator1" style="Z-INDEX: 106; LEFT: 664px; POSITION: absolute; TOP: 192px"
				runat="server" Width="272px" ControlToValidate="WSNameToCreate" ErrorMessage="You must enter a computer name in this field. It can not be empty."></asp:requiredfieldvalidator>
            <asp:textbox id="tbNewZone" style="Z-INDEX: 108; LEFT: 288px; POSITION: absolute; TOP: 384px"
				runat="server" MaxLength="32" Enabled="False"></asp:textbox>
            <asp:label id="lblNewZone" style="Z-INDEX: 109; LEFT: 288px; POSITION: absolute; TOP: 360px; right: 827px;"
				runat="server">Zone Name</asp:label>
			<asp:ListBox id="lbAirportZone" style="Z-INDEX: 111; LEFT: 560px; POSITION: absolute; TOP: 384px"
				runat="server" Width="264px" Height="160px" AutoPostBack="True" Enabled="False" onselectedindexchanged="lbAirportZone_SelectedIndexChanged"></asp:ListBox></form>
	</body>
</HTML>
