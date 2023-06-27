<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Page language="c#" Codebehind="RenameWS.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.RenameWS" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Rename workstation Page</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="WSSelectName" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<TABLE id="Table1" style="Z-INDEX: 104; LEFT: 220px; POSITION: absolute; TOP: 168px" height="1"
				cellSpacing="0" cellPadding="0" width="300" align="left" border="0">
				<TR>
					<TD vAlign="top">
                        <asp:panel id="ManualPanel" runat="server" Width="400px" Height="1px">
							<P>
								&nbsp;<asp:TextBox id="txtboxWSName" runat="server" ToolTip="Enter the workstation upon which you wish to operate."
									MaxLength="32"></asp:TextBox>
								&nbsp;<asp:Label id="lblManual" runat="server" Width="136px" Font-Size="Smaller" Font-Bold="True"
									ForeColor="Navy" ToolTip="Enter the workstation you wish to configure.">workstation name</asp:Label>
                            </P>
							<P>&nbsp;
								<asp:Button id="btnManual" runat="server" Text="Accept" onclick="btnManual_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Width="248px" ErrorMessage="You must enter a workstation name."
									ControlToValidate="txtboxWSName"></asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp; 
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							</P>
						</asp:panel>
                        <asp:panel id="SwapToPanel" runat="server" Width="432px" Height="92px" Visible="False">
							<P>
								<asp:Label id="lblSwapTo" runat="server" Width="136px" Font-Size="Smaller" Font-Bold="True"
									ForeColor="Navy">New name:</asp:Label>
								<asp:TextBox id="txbNewName" runat="server"></asp:TextBox></P>
							<P>&nbsp;&nbsp;
								<asp:Button id="btnSwap" runat="server" ToolTip="Enter new workstation name" Text="Rename" onclick="btnSwap_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:RequiredFieldValidator id="RFVSwapTo" runat="server" ErrorMessage="You must enter a workstation name."
									ControlToValidate="txbSwapTo" Visible="False"></asp:RequiredFieldValidator><BR>
								&nbsp;&nbsp;&nbsp;
							</P>
						</asp:panel></TD>
				</TR>
				<TR>
					<TD><asp:panel id="AutoPanel" runat="server" Width="392px" Height="284px">
							<P>
								<asp:Label id="lblAutoLabel" runat="server" Width="312px" Font-Size="Smaller" Font-Bold="True"
									ForeColor="Navy">All workstations currently configured in the database:</asp:Label></P>
							<P>&nbsp;
								<asp:ListBox id="lbxWSNames" runat="server" Width="256px" Height="174px" ForeColor="Black"></asp:ListBox>&nbsp;
							</P>
							<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:Button id="btnAuto" runat="server" Text="Accept" onclick="btnAuto_Click"></asp:Button></P>
						</asp:panel></TD>
				</TR>
				<TR>
					<TD><asp:panel id="pnlStatus" runat="server" Width="392px" Height="18px" ForeColor="Black">
							<P>
								<asp:Label id="WSMessage" runat="server" Width="376px" Height="62px" Font-Bold="True" ForeColor="#000040"></asp:Label></P>
							<P>&nbsp;&nbsp;&nbsp;&nbsp;
							</P>
							<P>&nbsp;</P>
						</asp:panel></TD>
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
			<asp:label id="lblMessage" style="Z-INDEX: 101; LEFT: 220px; POSITION: absolute; TOP: 72px"
				runat="server" Width="800px" Height="48px" Font-Size="Larger" Font-Bold="True" ForeColor="Navy"></asp:label>
            <asp:radiobutton id="ManualSelection" style="Z-INDEX: 102; LEFT: 220px; POSITION: absolute; TOP: 136px"
				runat="server" ToolTip="This option allows you to enter the workstation upon which you wish to operate." Text="Manual workstation selection" GroupName="SelectionMode" Checked="True" AutoPostBack="True" oncheckedchanged="ManualSelection_CheckedChanged"></asp:radiobutton>
            <asp:radiobutton id="AutoSelection" style="Z-INDEX: 103; LEFT: 480px; POSITION: absolute; TOP: 136px"
				runat="server" ToolTip="This option allows you to select the workstation name from the master list of all workstations." Text="Auto workstation selection" GroupName="SelectionMode" AutoPostBack="True" oncheckedchanged="AutoSelection_CheckedChanged"></asp:radiobutton></form>
	</body>
</HTML>
