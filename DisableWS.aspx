<%@ Page language="c#" Codebehind="DisableWS.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.DisableWS" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Disable/Enable Workstation</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link REL="Stylesheet" HREF="css/ClientDeviceMgr.css" TYPE="text/css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<TABLE id="Table1" style="Z-INDEX: 104; LEFT: 220px; POSITION: absolute; TOP: 168px" cellSpacing="0"
				cellPadding="0" width="300" align="left" border="0" height="1">
				<TR>
					<TD vAlign="top" style="HEIGHT: 39px"></TD>
				</TR>
				<TR>
					<TD>
						<asp:Panel id="AutoPanel" runat="server" Height="284px" Width="392px" DESIGNTIMEDRAGDROP="24">
							<P>
								<asp:Label id="lblAutoLabel" runat="server" Width="312px" ForeColor="Navy" Font-Bold="True">
                                    All workstations currently configured in the database:</asp:Label></P>
							<P>&nbsp;
								<asp:ListBox id="lbxWSNames" runat="server" Height="174px" Width="256px" ForeColor="Black"></asp:ListBox>&nbsp;
							</P>
							<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:Button id="btnAuto" runat="server" Text="Disable/Enable" onclick="btnAuto_Click"></asp:Button></P>
						</asp:Panel></TD>
				</TR>
				<TR>
					<TD>
						<asp:Panel id="pnlStatus" runat="server" ForeColor="Black" Height="18px" Width="392px" DESIGNTIMEDRAGDROP="25">
							<P>
								<asp:Label id="WSMessage" runat="server" Height="62px" Width="376px" ForeColor="#000040" Font-Bold="True"></asp:Label></P>
							<P>&nbsp;</P>
							<P>&nbsp;</P>
						</asp:Panel></TD>
				</TR>
			</TABLE>
			<asp:RadioButton id="DisableSelection" style="Z-INDEX: 105; LEFT: 472px; POSITION: absolute; TOP: 136px"
				runat="server" ToolTip="To select disabled workstation" Text="Disabled workstation selection"
				AutoPostBack="True" GroupName="SelectionMode" oncheckedchanged="DisableSelection_CheckedChanged"></asp:RadioButton>
			<Module:Header id="MainHeader" runat="server"></Module:Header>
			<!-- END PAGE HEADER MODULE -->
			<table border="0" width="10%" cellspacing="0" cellpadding="0">
				<tr>
					<td class="navtable" width="1%" valign="top">
						<table width="100%" border="0" cellspacing="10" cellpadding="0">
							<!-- BEGIN DYNAMIC LEFT MODULE LIST -->
							<tr>
								<td style="PADDING-TOP:5px" align="left" class="navtable">
									<Module:Support id="SupportOpts" runat="server"></Module:Support>
								</td>
							</tr>
							<!-- END DYNAMIC LEFT MODULE LIST -->
						</table>
					</td>
				</tr>
			</table>
			<asp:Label id="lblMessage" style="Z-INDEX: 101; LEFT: 220px; POSITION: absolute; TOP: 72px"
				runat="server" Width="800px" Height="48px" ForeColor="Navy" Font-Bold="True" Font-Size="Larger"></asp:Label>
			<asp:RadioButton id="AutoSelection" style="Z-INDEX: 103; LEFT: 220px; POSITION: absolute; TOP: 136px"
				runat="server" Text="Active workstation selection" ToolTip="This option allows you to select the workstation name from the master list of all workstations."
				GroupName="SelectionMode" AutoPostBack="True" oncheckedchanged="AutoSelection_CheckedChanged"></asp:RadioButton>
		</form>
	</body>
</HTML>
