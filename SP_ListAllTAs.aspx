<%@ Page language="c#" Codebehind="SP_ListAllTAs.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.SP_ListAllTAs" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>List all Workstation/LNIATA Page</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="ChechAllTAs" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE --><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
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
            <asp:datagrid id="dgAllTAs" style="Z-INDEX: 101; LEFT: 224px; POSITION: absolute; TOP: 104px"
				runat="server" AllowPaging="True" PageSize="20" OnPageIndexChanged="PageIndexChanged" BorderStyle="Groove" BorderWidth="3px"
				BorderColor="Gray" onselectedindexchanged="dgAllTAs_SelectedIndexChanged">
				<HeaderStyle Font-Bold="True"></HeaderStyle>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
            <asp:label id="lblTitle" style="Z-INDEX: 102; LEFT: 224px; POSITION: absolute; TOP: 72px" runat="server"
				BackColor="Transparent" Font-Bold="True" ForeColor="Navy">All Fixed TAs configured</asp:label>
		</form>
	</body>
</HTML>
