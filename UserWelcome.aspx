<%@ Page language="c#" Codebehind="UserWelcome.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.UserWelcome" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Welcome to the EDS Network Administration Web Site</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="WelcomeForm" method="post" runat="server">
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
			<asp:label id="lblWelcomeMsg" style="Z-INDEX: 101; LEFT: 288px; POSITION: absolute; TOP: 104px"
				runat="server" Font-Size="Larger" Font-Bold="True" ForeColor="Navy" Height="56px" Width="296px"></asp:label>
            <asp:label id="lblCurrentTime" style="Z-INDEX: 102; LEFT: 296px; POSITION: absolute; TOP: 216px"
				runat="server" ForeColor="Navy" Height="40px" Width="280px"></asp:label>
		</form>
	</body>
</HTML>
