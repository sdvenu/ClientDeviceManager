<%@ Page language="c#" CodeBehind="WSSelect.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.WSSelect" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Workstation Selection Page</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="WSSelectName" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<TABLE id="Table1" style="Z-INDEX: 104; LEFT: 220px; POSITION: absolute; TOP: 168px" height="300px"
				cellSpacing="0" cellPadding="0" width="300" align="left" border="0">
				<TR>
					<TD vAlign="top">
                        <asp:panel id="ManualPanel" runat="server" Height="1px" Width="400px">
							<P>
								&nbsp;<asp:TextBox id="txtboxWSName" runat="server" ToolTip="Enter the workstation upon which you wish to operate."
									MaxLength="32" ontextchanged="txtboxWSName_TextChanged"></asp:TextBox>
								&nbsp;<asp:Label id="lblManual" runat="server" Width="136px" ToolTip="Enter the workstation you wish to configure."
									ForeColor="Navy" Font-Bold="True">workstation name</asp:Label>
                            </P>
							<P>&nbsp;
								<asp:Button id="btnManual" runat="server" Text="Accept" onclick="btnManual_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Width="248px" ControlToValidate="txtboxWSName"
									ErrorMessage="You must enter a workstation name."></asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp; 
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							</P>
						</asp:panel></TD>
				</TR>
				<TR>
					<TD><asp:panel id="AutoPanel" runat="server" Height="284px" Width="392px" DESIGNTIMEDRAGDROP="24">
							<P>
								<asp:Label id="lblAutoLabel" runat="server" Width="312px" ForeColor="Navy" Font-Bold="True">
                                    All workstations currently configured in the database:</asp:Label></P>
							<P>&nbsp;
								<asp:ListBox id="lbxWSNames" runat="server" Height="284px" Width="256px" ForeColor="Black" onselectedindexchanged="lbxWSNames_SelectedIndexChanged"></asp:ListBox>&nbsp;
							</P>
							<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:Button id="btnAuto" runat="server" Text="Accept" onclick="btnAuto_Click"></asp:Button></P>
						</asp:panel></TD>
				</TR>
				<TR>
					<TD><asp:panel id="pnlStatus" runat="server" Height="18px" Width="392px" ForeColor="Black" DESIGNTIMEDRAGDROP="25">
							<P>
								<asp:Label id="WSMessage" runat="server" Height="62px" Width="376px" ForeColor="#000040" Font-Bold="True"></asp:Label></P>
							<P>&nbsp;</P>
							<P>&nbsp;</P>
						</asp:panel></TD>
				</TR>
			</TABLE>
			<asp:radiobutton id="DisableSelection" style="Z-INDEX: 105; LEFT: 705px; POSITION: absolute; TOP: 136px"
				runat="server" ToolTip="To select disabled workstation" Text="Disabled workstation selection"
				GroupName="SelectionMode" AutoPostBack="True" oncheckedchanged="DisableSelection_CheckedChanged"></asp:radiobutton><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
			<!-- END PAGE HEADER MODULE -->
			<table cellSpacing="0" cellPadding="0" width="10%" border="0">
				<tr>
					<td class="navtable" vAlign="top" width="1%">
						<table cellSpacing="10" cellPadding="0" width="100%" border="0">
							<!-- BEGIN DYNAMIC LEFT MODULE LIST -->
							<tr>
								<td style="PADDING-TOP:5px; width:181px;" align="left"><MODULE:SUPPORT id="SupportOpts" runat="server"></MODULE:SUPPORT></td>
							</tr>
							<!-- END DYNAMIC LEFT MODULE LIST --></table>
					</td>
				</tr>
			</table>
			<asp:label id="lblMessage" style="Z-INDEX: 101; LEFT: 220px; POSITION: absolute; TOP: 72px"
				runat="server" Height="48px" Width="800px" ForeColor="Navy" Font-Bold="True" Font-Size="Larger"></asp:label>
            <asp:radiobutton id="ManualSelection" style="Z-INDEX: 102; LEFT: 220px; POSITION: absolute; TOP: 136px"
				runat="server"
                ToolTip="This option allows you to enter the workstation upon which you wish to operate."
                Text="Manual workstation selection"
                GroupName="SelectionMode"
                AutoPostBack="True"
                Checked="True"
                oncheckedchanged="ManualSelection_CheckedChanged">
            </asp:radiobutton>
            <asp:radiobutton id="AutoSelection" style="Z-INDEX: 103; LEFT: 480px; POSITION: absolute; TOP: 136px"
				runat="server"
                ToolTip="This option allows you to select the workstation name from the master list of all workstations."
                Text="Auto workstation selection"
                GroupName="SelectionMode"
                AutoPostBack="True"
                oncheckedchanged="AutoSelection_CheckedChanged">
            </asp:radiobutton>
		</form>
	</body>
</HTML>
