<%@ Page language="c#" Codebehind="NewRoute.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.NewRoute" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Add NewRoute</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="NewRouteForm" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE --><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
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
			<asp:label id="WelcomeMsg" style="Z-INDEX: 101; LEFT: 264px; POSITION: absolute; TOP: 88px"
				runat="server" Font-Bold="True" ForeColor="#000040" Height="40px" Width="249px"></asp:label>
            <asp:label id="Label1" style="Z-INDEX: 102; LEFT: 272px; POSITION: absolute; TOP: 168px" runat="server"
				ForeColor="#000040" Width="152px">RouteName to create</asp:label>
            <asp:textbox id="txtboxNewRoute" style="Z-INDEX: 103; LEFT: 448px; POSITION: absolute; TOP: 168px"
				runat="server" MaxLength="32" ToolTip="Enter the RouteName you wish to create."></asp:textbox>
            <asp:button id="btnCreate" style="Z-INDEX: 104; LEFT: 624px; POSITION: absolute; TOP: 168px"
				runat="server" Text="Create" onclick="btnCreate_Click"></asp:button>
            <asp:requiredfieldvalidator id="RequiredFieldValidator1" style="Z-INDEX: 105; LEFT: 280px; POSITION: absolute; TOP: 216px"
				runat="server" Height="72px" Width="400px" ControlToValidate="txtboxNewRoute" ErrorMessage="You must enter a RouteName before submitting the request to the database."></asp:requiredfieldvalidator>
			<asp:DropDownList id="ProtocolDropDownList" style="Z-INDEX: 106; LEFT: 568px; POSITION: absolute; TOP: 104px"
				runat="server" Width="96px"></asp:DropDownList></form>
	</body>
</HTML>
