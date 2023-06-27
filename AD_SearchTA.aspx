<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Page language="c#" Codebehind="AD_SearchTA.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.AD_SearchTA" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Search workstation/LNIATA Page</title>
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
			<asp:Label id="lblTitle" style="Z-INDEX: 101; LEFT: 240px; POSITION: absolute; TOP: 72px" runat="server"
				ForeColor="Navy" Font-Bold="True" BackColor="Transparent"></asp:Label>
			<asp:Panel id="pnlOutput" style="Z-INDEX: 103; LEFT: 240px; POSITION: absolute; TOP: 120px"
				runat="server" Width="700px" Height="400px" Visible="False">
				<asp:DataGrid id="dgLog" runat="server" PageSize="20" BorderColor="Gray" BorderWidth="3px" BorderStyle="Groove"
					OnPageIndexChanged="PageIndexChanged" AllowPaging="True" PagerStyle-Width="600px" onselectedindexchanged="dgLog_SelectedIndexChanged">
					<HeaderStyle Font-Bold="True"></HeaderStyle>
					<PagerStyle Width="600px" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
			<asp:Panel id="pnlInput" style="Z-INDEX: 104; LEFT: 240px; POSITION: absolute; TOP: 120px"
				runat="server" Width="480px" Height="272px">
				<TABLE id="Table1" style="WIDTH: 456px; HEIGHT: 109px" cellSpacing="0" cellPadding="0"
					width="456" border="0">
					<TR>
						<TD style="WIDTH: 158px">
							<P>&nbsp;</P>
							<P>&nbsp;</P>
						</TD>
						<TD>
							<P>
								<asp:RadioButton id="rbLNIATA" runat="server" Checked="True" GroupName="ByType" AutoPostBack="True"
									Text="By LNIATA" oncheckedchanged="rbLNIATA_CheckedChanged"></asp:RadioButton><BR>
								<asp:RadioButton id="rbType" runat="server" GroupName="ByType" AutoPostBack="True" Text="By route name" oncheckedchanged="rbType_CheckedChanged"></asp:RadioButton></P>
						</TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 158px" align="left">
							<asp:Label id="lblByType" runat="server"></asp:Label></TD>
						<TD>
							<asp:TextBox id="txbSearchBy" runat="server"></asp:TextBox></TD>
						<TD>
							<P>
								<asp:Button id="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click"></asp:Button></P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 158px"></TD>
						<TD>
							<asp:RequiredFieldValidator id="rfvInput" runat="server" ErrorMessage="Cannot be blank" ControlToValidate="txbSearchBy"></asp:RequiredFieldValidator></TD>
						<TD></TD>
					</TR>
				</TABLE>
			</asp:Panel>
		</form>
	</body>
</HTML>
