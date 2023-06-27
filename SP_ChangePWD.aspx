<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Page language="c#" Codebehind="SP_ChangePWD.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.SP_ChangePWD" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Change password Screen</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="SPChangePWD" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 280px; POSITION: absolute; TOP: 192px" cellSpacing="0"
				cellPadding="0" width="300" border="0">
				<TR>
					<TD style="HEIGHT: 35px"><asp:label id="lblOldPassword" runat="server" Width="88px">Old Password</asp:label></TD>
					<TD style="HEIGHT: 35px"><asp:textbox id="txbOldPassword" runat="server" MaxLength="32" TextMode="Password"></asp:textbox></TD>
					<TD style="HEIGHT: 35px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 35px"><asp:label id="lblPassword" runat="server">New Password</asp:label></TD>
					<TD style="HEIGHT: 35px">
						<P><asp:textbox id="txbPassword" runat="server" TextMode="Password"></asp:textbox></P>
					</TD>
					<TD style="HEIGHT: 35px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 35px"><asp:label id="lblRTPassword" runat="server">Retype Password</asp:label></TD>
					<TD style="HEIGHT: 35px"><asp:textbox id="txbRTPassword" runat="server" TextMode="Password"></asp:textbox></TD>
					<TD style="HEIGHT: 35px">
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 39px"></TD>
					<TD style="HEIGHT: 39px"><asp:button id="btnResetPwd" runat="server" Text="Submit" onclick="btnResetPwd_Click"></asp:button></TD>
					<TD style="HEIGHT: 39px"></TD>
				</TR>
			</TABLE>
			<MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
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
				Width="368px" Font-Bold="True" ForeColor="#000040" Height="96px"></asp:label>
			<asp:RequiredFieldValidator id="RFVOldPWD" style="Z-INDEX: 103; LEFT: 600px; POSITION: absolute; TOP: 200px"
				runat="server" ErrorMessage="Password cannot be blank" ControlToValidate="txbOldPassword"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RFVPassword" style="Z-INDEX: 104; LEFT: 600px; POSITION: absolute; TOP: 232px"
				runat="server" ErrorMessage="Password cannot be blank" ControlToValidate="txbPassword"></asp:RequiredFieldValidator>
			<asp:CompareValidator id="CVRTPassword" style="Z-INDEX: 105; LEFT: 600px; POSITION: absolute; TOP: 264px"
				runat="server" ErrorMessage="Password mismatch" ControlToValidate="txbRTPassword" ControlToCompare="txbPassword"></asp:CompareValidator></form>
	</body>
</HTML>
