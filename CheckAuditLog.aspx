<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Page language="c#" Codebehind="CheckAuditLog.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.CheckAuditLog" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Check audit log Page</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="ChechAllTAs" method="post" runat="server">
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
			<asp:label id="lblTitle" style="Z-INDEX: 101; LEFT: 232px; POSITION: absolute; TOP: 72px" runat="server"
				BackColor="Transparent" Font-Bold="True" ForeColor="Navy"> Audit log</asp:label>
			<asp:Panel id="Panel1" style="Z-INDEX: 103; LEFT: 224px; POSITION: absolute; TOP: 96px" runat="server"
				Width="660px" Height="400px">
				<asp:DataGrid id="dgLog" runat="server" AllowPaging="True" OnPageIndexChanged="PageIndexChanged"
					BorderStyle="Groove" BorderWidth="3px" BorderColor="Gray" onselectedindexchanged="dgLog_SelectedIndexChanged">
					<HeaderStyle Font-Bold="True"></HeaderStyle>
					<PagerStyle Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel></form>
	</body>
</HTML>
