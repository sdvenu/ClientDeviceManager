<%@ Page language="c#" Codebehind="AD_AuditLog.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.AD_AuditLog" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Check audit log Page</title>
		<meta HTTP-EQUIV="content-type" CONTENT="text/html; charset=utf-8">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<link REL="Stylesheet" HREF="css/ClientDeviceMgr.css" TYPE="text/css">
	</HEAD>
	<body>
		<form id="ChechAllTAs" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<Module:Header id="MainHeader" runat="server"></Module:Header>
			<!-- END PAGE HEADER MODULE -->
			<table border="0" width="10%" cellspacing="0" cellpadding="0">
				<tr>
					<td class="navtable" width="1%" valign="top">
						<table width="100%" border="0" cellspacing="10" cellpadding="0">
							<!-- BEGIN DYNAMIC LEFT MODULE LIST -->
							<tr>
								<td style="PADDING-TOP:5px" align="left">
									<Module:Support id="SupportOpts" runat="server"></Module:Support>
								</td>
							</tr>
							<!-- END DYNAMIC LEFT MODULE LIST -->
						</table>
					</td>
				</tr>
			</table>
			<!-- END PAGE HEADER MODULE -->
			<asp:DataGrid id="dgLog" style="Z-INDEX: 101; LEFT: 220px; POSITION: absolute; TOP: 104px" runat="server"
				AllowPaging="True" OnPageIndexChanged="PageIndexChanged" BorderStyle="Groove" BorderWidth="3px"
				BorderColor="Gray" onselectedindexchanged="dgLog_SelectedIndexChanged">
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
			<asp:Label id="lblTitle" style="Z-INDEX: 102; LEFT: 220px; POSITION: absolute; TOP: 72px" runat="server"
				ForeColor="Navy" Font-Bold="True" BackColor="Transparent"> Audit log</asp:Label>
		</form>
	</body>
</HTML>
