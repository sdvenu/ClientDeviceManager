<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Page language="c#" Codebehind="SP_DelUser.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.SP_DelUser"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Delete User Configuration Display</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="DelUserForm" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<asp:Panel id="AutoPanel" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Height="300px" Width="392px" Visible="False">
				<P>&nbsp;</P>
				<P>
					<asp:Label id="lblAutoLabel" runat="server" Width="312px" Font-Size="Smaller" ForeColor="Navy"
						Font-Bold="True">All users currently configured in the database:</asp:Label></P>
				<P>&nbsp;
					<asp:ListBox id="lbxUserNames" runat="server" Width="256px" Height="198px" ForeColor="Black"></asp:ListBox></P>
				<P>&nbsp;
					<asp:Button id="btnAutoDel" runat="server" Text="Delete" onclick="btnAutoDel_Click"></asp:Button>&nbsp;
					<asp:Label id="Label2" runat="server" Width="272px" Height="56px" Font-Size="Smaller" Font-Bold="True"></asp:Label></P>
				<P>&nbsp;</P>
				<P>&nbsp;</P>
				<P>&nbsp;</P>
			</asp:Panel><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
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
			<asp:label id="MainLabel" style="Z-INDEX: 101; LEFT: 272px; POSITION: absolute; TOP: 80px"
				runat="server" Font-Bold="True" ForeColor="#000040" Height="88px" Width="296px">Select the method you wish to use to delete a user from the configuration database.</asp:label>
            <asp:radiobutton id="rbManualDel" style="Z-INDEX: 102; LEFT: 280px; POSITION: absolute; TOP: 208px"
				runat="server" Checked="True" AutoPostBack="True" GroupName="Delete" Font-Size="Smaller" Text="Enter user name to delete:" oncheckedchanged="rbManualDel_CheckedChanged"></asp:radiobutton>
            <asp:radiobutton id="rbDelFromList" style="Z-INDEX: 103; LEFT: 280px; POSITION: absolute; TOP: 248px"
				runat="server" AutoPostBack="True" GroupName="Delete" Font-Size="Smaller" Text="Delete the user from a list of existing users." oncheckedchanged="rbDelFromList_CheckedChanged"></asp:radiobutton>
            <asp:panel id="pnlManual" style="Z-INDEX: 105; LEFT: 296px; POSITION: absolute; TOP: 296px"
				runat="server" Height="96px" Width="344px">
				<P>&nbsp;
					<asp:Label id="Label1" runat="server" Width="112px" Font-Size="Smaller" ForeColor="#000040"
						Font-Bold="True">User Name:</asp:Label>
					<asp:TextBox id="txtboxUserName" runat="server" Width="160px" MaxLength="32"></asp:TextBox></P>
				<P>&nbsp;
					<asp:Button id="btnpnlManDelete" runat="server" Text="Delete" onclick="btnpnlManDelete_Click"></asp:Button>&nbsp;
					<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Width="248px" ErrorMessage="RequiredFieldValidator"
						ControlToValidate="txtboxUserName">You must enter a user name.</asp:RequiredFieldValidator></P>
				<P>
					<asp:Label id="lblStatus" runat="server" Width="320px" Height="16px" Font-Size="Smaller" Font-Bold="True"></asp:Label></P>
				<P>&nbsp;</P>
			</asp:panel></form>
	</body>
</HTML>
