<%@ Page language="c#" Codebehind="DeleteRoute.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.DeleteRoute" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DeleteRoute</title>
		<meta HTTP-EQUIV="content-type" CONTENT="text/html; charset=utf-8">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<link REL="Stylesheet" HREF="css/ClientDeviceMgr.css" TYPE="text/css">
	</HEAD>
	<body>
		<form id="DeleteRouteForm" method="post" runat="server">
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
			<asp:Label id="MainLabel" style="Z-INDEX: 101; LEFT: 256px; POSITION: absolute; TOP: 112px"
				runat="server" Width="409px" Height="72px" ForeColor="#000040" Font-Bold="True"></asp:Label>
			<asp:Button id="btnYes" style="Z-INDEX: 102; LEFT: 264px; POSITION: absolute; TOP: 192px" runat="server"
				Width="80px" Text="Yes" onclick="btnYes_Click"></asp:Button>
			<asp:Button id="btnNo" style="Z-INDEX: 103; LEFT: 360px; POSITION: absolute; TOP: 192px" runat="server"
				Width="72px" Text="Cancel" onclick="btnNo_Click"></asp:Button>
		</form>
		</TR></TBODY></TABLE>
	</body>
</HTML>
