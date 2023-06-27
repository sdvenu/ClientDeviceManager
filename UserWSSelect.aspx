<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Page language="c#" Codebehind="UserWSSelect.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.UserWSSelect" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Workstation Selection Page</title>
		<meta HTTP-EQUIV="content-type" CONTENT="text/html; charset=utf-8">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<link REL="Stylesheet" HREF="css/ClientDeviceMgr.css" TYPE="text/css">
	</HEAD>
	<body MS_POSITIONING="GridLayout" >
		<form id="WSSelectName" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<TABLE id="Table1" style="Z-INDEX: 104; LEFT: 220px; POSITION: absolute; TOP: 168px" cellSpacing="0"
				cellPadding="0" width="300" align="left" border="0" height="1">
				<TR>
					<TD vAlign="top">
						<asp:Panel id="ManualPanel" runat="server" Width="600px" Height="1px">
							<P>
								&nbsp;<asp:TextBox id="txtboxWSName" runat="server" ToolTip="Enter the workstation upon which you wish to operate."
									MaxLength="32"></asp:TextBox>
								&nbsp;<asp:Label id="lblManual" runat="server" Width="136px" ToolTip="Enter the workstation you wish to configure."
									ForeColor="Navy" Font-Bold="True" Font-Size="small">workstation name</asp:Label>
                            </P>
							<P>&nbsp;
								<asp:Button id="btnManual" runat="server" Text="Accept" onclick="btnManual_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Width="248px" ControlToValidate="txtboxWSName"
									ErrorMessage="You must enter a workstation name."></asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp; 
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							</P>
						</asp:Panel></TD>
				</TR>
				<TR>
					<TD>
						<asp:Panel id="AutoPanel" runat="server" Height="284px" Width="600px" DESIGNTIMEDRAGDROP="24">
							<P>
								<asp:Label id="lblAutoLabel" runat="server" Width="312px" ForeColor="Navy" Font-Bold="True"
									Font-Size="Small">All workstations currently configured in the database:</asp:Label></P>
							<P>&nbsp;
								<asp:ListBox id="lbxWSNames" runat="server" Height="174px" Width="400px" ForeColor="Black" onselectedindexchanged="lbxWSNames_SelectedIndexChanged"></asp:ListBox>&nbsp;
							</P>
							<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:Button id="btnAuto" runat="server" Text="Accept" onclick="btnAuto_Click"></asp:Button></P>
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
			<asp:RadioButton id="DisableSelection" style="Z-INDEX: 105; LEFT: 704px; POSITION: absolute; TOP: 136px"
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
								<td style="PADDING-TOP:5px" align="left">
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
			<asp:RadioButton id="ManualSelection" style="Z-INDEX: 102; LEFT: 220px; POSITION: absolute; TOP: 136px"
				runat="server" Text="Manual workstation selection" ToolTip="This option allows you to enter the workstation upon which you wish to operate."
				GroupName="SelectionMode" Checked="True" AutoPostBack="True" oncheckedchanged="ManualSelection_CheckedChanged"></asp:RadioButton>
			<asp:RadioButton id="AutoSelection" style="Z-INDEX: 103; LEFT: 480px; POSITION: absolute; TOP: 136px"
				runat="server" Text="Auto workstation selection" ToolTip="This option allows you to select the workstation name from the master list of all workstations."
				GroupName="SelectionMode" AutoPostBack="True" oncheckedchanged="AutoSelection_CheckedChanged"></asp:RadioButton>
		</form>
	</body>
</HTML>
