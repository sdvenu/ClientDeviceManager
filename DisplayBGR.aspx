<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Page language="c#" Codebehind="DisplayBGR.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.DisplayBGR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Display BGRConfiguration screen</title>
		<meta HTTP-EQUIV="content-type" CONTENT="text/html; charset=utf-8">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<link REL="Stylesheet" HREF="css/ClientDeviceMgr.css" TYPE="text/css">
	</HEAD>
	<body>
		<form id="BGRConfigForm" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 208px; WIDTH: 664px; POSITION: absolute; TOP: 128px; HEIGHT: 220px"
				cellSpacing="0" cellPadding="0" width="664" border="0">
				<TR>
					<TD style="WIDTH: 217px">
						<asp:Label id="Label1" runat="server" Font-Bold="True" ForeColor="Navy" Width="184px" Font-Size="Smaller">Number of BGR Devices:</asp:Label></TD>
					<TD style="WIDTH: 82px">
						<asp:TextBox id="txtboxNumBGRs" runat="server" Width="72px" MaxLength="2" ToolTip="The value entered here should represent the number of BGR devices attached to this workstation."
							Enabled="False">1</asp:TextBox></TD>
					<TD style="WIDTH: 182px">
						<asp:Label id="Label3" runat="server" Font-Bold="True" ForeColor="Navy" Font-Size="Smaller">Airline ID</asp:Label></TD>
					<TD>
						<asp:TextBox id="tbAirlineId" runat="server" Width="32px" AutoPostBack="True" Enabled="False" ontextchanged="tbAirlineId_TextChanged">AA</asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 217px">
						<asp:Label id="Label2" runat="server" Font-Bold="True" ForeColor="Navy" Width="176px" Font-Size="Smaller">Default Host System:</asp:Label></TD>
					<TD style="WIDTH: 82px">
						<asp:TextBox id="txtboxHostSys" runat="server" Width="72px" MaxLength="8" ToolTip="This is the default system in the host the application will work from. (i.e. RES or DECS)"
							Enabled="False">RES</asp:TextBox></TD>
					<TD style="WIDTH: 182px">
						<asp:CheckBox id="cbTesting" runat="server" Font-Bold="True" ForeColor="Navy" Text="Testing" Font-Size="Smaller"
							Enabled="False"></asp:CheckBox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 217px; HEIGHT: 20px">
						<asp:CheckBox id="ckboxLogging" runat="server" Font-Bold="True" ForeColor="Navy" ToolTip="If this is enabled then the BGR Application screen logger will activate when the BGR Application launches. This should not be activated by default and should only be used for debugging or troubleshooting purposes."
							Text="Application Logger Active" Font-Size="Smaller" Enabled="False"></asp:CheckBox></TD>
					<TD style="WIDTH: 82px; HEIGHT: 20px"></TD>
					<TD style="WIDTH: 182px; HEIGHT: 20px">
						<asp:CheckBox id="cbDebugWindow" runat="server" Font-Bold="True" ForeColor="Navy" Text="Debug Window"
							Font-Size="Smaller" Enabled="False"></asp:CheckBox></TD>
					<TD style="HEIGHT: 20px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 217px">
						<asp:CheckBox id="ckboxHostVal" runat="server" Font-Bold="True" ForeColor="Navy" ToolTip="This forces the application to await the repsonse from the host before completing the transaction. This will hurt performance and should be used with caution."
							Text="Host Validation Mode" Font-Size="Smaller" Enabled="False"></asp:CheckBox></TD>
					<TD style="WIDTH: 82px"></TD>
					<TD style="WIDTH: 182px">
						<asp:Label id="Label4" runat="server" Font-Bold="True" ForeColor="Navy" Font-Size="Smaller">Host Receive Timeout</asp:Label></TD>
					<TD>
						<asp:TextBox id="tbHostReceiveTimeout" runat="server" Width="56px" MaxLength="6" Enabled="False">60</asp:TextBox>
						<asp:Label id="Label13" runat="server">sec</asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 217px">
						<asp:CheckBox id="ckboxNOLED" runat="server" Font-Bold="True" ForeColor="Navy" ToolTip="This should only be checked when the device does not have an LED display to render information messages to the agent."
							Text="No LED display on the BGR device" Font-Size="Smaller" Enabled="False"></asp:CheckBox></TD>
					<TD style="WIDTH: 82px"></TD>
					<TD style="WIDTH: 182px">
						<asp:Label id="Label5" runat="server" Font-Bold="True" ForeColor="Navy" Font-Size="Smaller">Host Update Interval</asp:Label></TD>
					<TD>
						<asp:TextBox id="tbHostUpdateInterval" runat="server" Width="56px" MaxLength="6" Enabled="False">12000</asp:TextBox>
						<asp:Label id="Label14" runat="server">msec</asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 217px; HEIGHT: 25px">
						<asp:CheckBox id="ckboxSCEdit" runat="server" Font-Bold="True" ForeColor="Navy" Text="Enable SC Edit Check"
							Font-Size="Smaller" Checked="True" Enabled="False"></asp:CheckBox></TD>
					<TD style="WIDTH: 82px; HEIGHT: 25px"></TD>
					<TD style="WIDTH: 182px; HEIGHT: 25px">
						<asp:Label id="Label6" runat="server" Font-Bold="True" ForeColor="Navy" Font-Size="Smaller">Inactivity Interval</asp:Label></TD>
					<TD style="HEIGHT: 25px">
						<asp:TextBox id="tbInactivityInterval" runat="server" Width="32px" MaxLength="2" Enabled="False">15</asp:TextBox>
						<asp:Label id="Label15" runat="server">msec</asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 217px">
						<asp:CheckBox id="ckboxProfileChk" runat="server" Font-Bold="True" ForeColor="Navy" Text="Enable SP Profile Check"
							Font-Size="Smaller" Checked="True" Enabled="False"></asp:CheckBox></TD>
					<TD style="WIDTH: 82px"></TD>
					<TD style="WIDTH: 182px">
						<asp:Label id="Label7" runat="server" Font-Bold="True" ForeColor="Navy" Font-Size="Smaller">Max Log Data Size</asp:Label></TD>
					<TD>
						<asp:TextBox id="tbMaxLogDataSize" runat="server" Width="32px" MaxLength="3" Enabled="False">10</asp:TextBox>
						<asp:Label id="Label12" runat="server">M bytes</asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 217px">
						<asp:CheckBox id="ckboxAddCollect" runat="server" Font-Bold="True" ForeColor="Navy" Text="Enable Add Collect"
							Font-Size="Smaller" Checked="True" Enabled="False"></asp:CheckBox></TD>
					<TD style="WIDTH: 82px"></TD>
					<TD style="WIDTH: 182px">
						<asp:Label id="Label8" runat="server" Font-Bold="True" ForeColor="Navy" Font-Size="Smaller">BGR1 COM port</asp:Label></TD>
					<TD>
						<asp:TextBox id="tbBGR1PortName" runat="server" Width="48px" MaxLength="4" Enabled="False">COM1</asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 217px">
						<asp:CheckBox id="cbRemote" runat="server" Font-Bold="True" ForeColor="Navy" Text="Remote Instance"
							Font-Size="Smaller" Enabled="False"></asp:CheckBox></TD>
					<TD style="WIDTH: 82px"></TD>
					<TD style="WIDTH: 182px">
						<asp:Label id="Label9" runat="server" Font-Bold="True" ForeColor="Navy" Font-Size="Smaller">BGR2 COM port</asp:Label></TD>
					<TD>
						<asp:TextBox id="tbBGR2PortName" runat="server" Width="48px" MaxLength="4" Enabled="False"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 217px"></TD>
					<TD style="WIDTH: 82px"></TD>
					<TD style="WIDTH: 182px">
						<asp:Label id="Label10" runat="server" Font-Bold="True" ForeColor="Navy" Font-Size="Smaller">BGR3 COM port</asp:Label></TD>
					<TD>
						<asp:TextBox id="tbBGR3PortName" runat="server" Width="48px" MaxLength="4" Enabled="False"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 217px"></TD>
					<TD style="WIDTH: 82px"></TD>
					<TD style="WIDTH: 182px">
						<asp:Label id="Label11" runat="server" Font-Bold="True" ForeColor="Navy" Font-Size="Smaller">BGR4 COM port</asp:Label></TD>
					<TD>
						<asp:TextBox id="tbBGR4PortName" runat="server" Width="48px" MaxLength="4" Enabled="False"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 217px"></TD>
					<TD style="WIDTH: 82px">
						<asp:Button id="btnOK" runat="server" Width="64px" Text="OK" Visible="False" Enabled="False" onclick="btnOK_Click"></asp:Button></TD>
					<TD style="WIDTH: 182px">
						<asp:Button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:Button></TD>
					<TD></TD>
				</TR>
			</TABLE>
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
			<asp:Label id="WelcomeMsg" style="Z-INDEX: 101; LEFT: 272px; POSITION: absolute; TOP: 80px"
				runat="server" Width="360px" Height="32px" ForeColor="Navy" Font-Bold="True"></asp:Label>
		</form>
	</body>
</HTML>
