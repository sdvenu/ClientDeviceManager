<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConfigSysPtrDrv.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.ConfigSysPtrDrv" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConfigSysPtrDrv</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:button id="buttonSave" style="Z-INDEX: 105; LEFT: 704px; POSITION: absolute; TOP: 480px"
				runat="server" Height="40px" Width="108px" Text="Save" onclick="buttonSave_Click"></asp:button><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
			<TABLE id="Table15" cellSpacing="0" cellPadding="0" width="10%" border="0">
				<TR>
					<TD class="navtable" vAlign="top" width="1%">
						<TABLE id="Table61" cellSpacing="10" cellPadding="0" width="100%" border="0"> <!-- BEGIN DYNAMIC LEFT MODULE LIST -->
							<TR>
								<TD style="PADDING-TOP: 5px" align="left"><MODULE:SUPPORT id="Support1" runat="server"></MODULE:SUPPORT></TD>
							</TR> <!-- END DYNAMIC LEFT MODULE LIST --></TABLE>
					</TD>
				</TR>
			</TABLE>
			<script src="ClientDeviceMgr.js"></script>
			<TABLE id="Table7" style="Z-INDEX: 103; LEFT: 704px; WIDTH: 257px; POSITION: absolute; TOP: 160px; HEIGHT: 272px"
				cellSpacing="1" cellPadding="1" width="257" border="1">
				<TR>
					<TD vAlign="top" align="left">
						<P>&nbsp;</P>
						<TABLE id="Table8" style="WIDTH: 216px; HEIGHT: 87px" cellSpacing="1" cellPadding="1" width="216"
							border="0">
							<TR>
								<TD><asp:label id="Label4" runat="server" Font-Underline="True">Debug Level Settings</asp:label></TD>
							</TR>
							<TR>
								<TD><asp:radiobutton id="rbDebugDisabled" runat="server" Text="Debugging Disabled" AutoPostBack="True"
										Checked="True" oncheckedchanged="rbDebugDisabled_CheckedChanged"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD><asp:radiobutton id="rbLogToFile" runat="server" Text="Logging to file Enabled" AutoPostBack="True" oncheckedchanged="rbLogToFile_CheckedChanged"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD><asp:radiobutton id="rbDebugWindowEnabled" runat="server" Text="Logging to Debug Status Window Enabled"
										AutoPostBack="True" oncheckedchanged="rbDebugWindowEnabled_CheckedChanged"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD><asp:radiobutton id="rbDebugFileAndWindowEnabled" runat="server" Text="Logging to file and Debug Status Window Enabled"
										AutoPostBack="True" oncheckedchanged="rbDebugFileAndWindowEnabled_CheckedChanged"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="Label2" runat="server" Font-Bold="True">Log File Settings</asp:label>
                        <asp:textbox id="textBoxLogFileName" runat="server" Width="247px"></asp:textbox><asp:requiredfieldvalidator id="rfvLogFile" runat="server" ControlToValidate="textBoxLogFileName" ErrorMessage="cannot be blank"></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD>
						<P><asp:label id="Label3" runat="server" Font-Bold="True">Maximum size of Log File in Bytes</asp:label><asp:textbox id="TextBoxMaxLogSize" runat="server" Width="120px" MaxLength="7"></asp:textbox><asp:rangevalidator id="rvMaxLogSize" runat="server" ControlToValidate="TextBoxMaxLogSize" ErrorMessage="100 to 100000000"
								MaximumValue="10000000" MinimumValue="100"></asp:rangevalidator></P>
					</TD>
				</TR>
			</TABLE>
			<asp:label id="Label1" style="Z-INDEX: 102; LEFT: 712px; POSITION: absolute; TOP: 136px" runat="server"
				Font-Bold="True">Debug Info</asp:label>
            <asp:panel id="Panel2" style="Z-INDEX: 101; LEFT: 224px; POSITION: absolute; TOP: 160px" runat="server"
				Height="300px" Width="472px" BorderStyle="Solid" BorderWidth="1px">&nbsp; 
                <TABLE id="Table2" style="WIDTH: 455px; HEIGHT: 47px" cellSpacing="1" cellPadding="1" width="448"
					border="0">
					<TR>
						<TD style="WIDTH: 240px">Device Name</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 240px">
							<asp:TextBox id="txbDeviceName" runat="server" Enabled="False"></asp:TextBox></TD>
						<TD style="WIDTH: 93px">
							<asp:RadioButton id="rbEnabled" runat="server" Text="Enabled" Checked="True" AutoPostBack="True" oncheckedchanged="rbEnabled_CheckedChanged"></asp:RadioButton></TD>
						<TD>
							<asp:RadioButton id="rbDisabled" runat="server" Text="Disabled" AutoPostBack="True" oncheckedchanged="rbDisabled_CheckedChanged"></asp:RadioButton></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 240px"><BR>
							Windows System Printer</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 240px; HEIGHT: 15px">
							<asp:TextBox id="txbSysPtr" runat="server" Width="240px"></asp:TextBox>
					</TR>
					<TR>
						<TD style="WIDTH: 240px">Select page output orientation</TD>
						<TD colSpan="2">
							<asp:RadioButton id="rbPortrait" runat="server" Text="Portrait" Checked="True" GroupName="Orientation"></asp:RadioButton>&nbsp;
							<asp:RadioButton id="rbLandscape" runat="server" Text="Landscape" GroupName="Orientation"></asp:RadioButton></TD>
					</TR>
					<TR>
						<TD><BR>
							<asp:CheckBox id="cbFormFeed" runat="server" Text="Add Form Feed" Checked="False" Enabled="True"></asp:CheckBox></TD>
					</TR>
					<TR>
						<TD><BR>
							<asp:CheckBox id="cbInsertLFAfterCR" runat="server" Text="Insert LF/After CR " Checked="False"
								Enabled="True"></asp:CheckBox></TD>
						</TD></TR>
				</TABLE>
                <TABLE id="TblMargin" style="WIDTH: 455px; HEIGHT: 110px" cellSpacing="1" cellPadding="1"
					width="448" border="0">
					<TR>
						<TD style="WIDTH: 227px; HEIGHT: 42px" colSpan="2">
							<P><BR>
								Margins in inches</P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 44px; HEIGHT: 27px">Top</TD>
						<TD style="WIDTH: 163px; HEIGHT: 27px">
							<asp:TextBox id="txbMarginTop" runat="server" Width="60px"></asp:TextBox>
							<asp:RangeValidator id="rvMarginTop" runat="server" ErrorMessage="0.00 to 2.00 " ControlToValidate="txbMarginTop"
								MinimumValue="0" MaximumValue="2.00"></asp:RangeValidator></TD>
						<TD style="WIDTH: 58px; HEIGHT: 27px">Bottom</TD>
						<TD style="HEIGHT: 27px">
							<asp:TextBox id="txbMarginBottom" runat="server" Width="60px"></asp:TextBox>
							<asp:RangeValidator id="rvMarginBottom" runat="server" ErrorMessage="0.00 to 2.00" ControlToValidate="txbMarginBottom"
								MinimumValue="0" MaximumValue="2.00"></asp:RangeValidator></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 44px">Left</TD>
						<TD style="WIDTH: 163px">
							<asp:TextBox id="txbMarginLeft" runat="server" Width="60px"></asp:TextBox>
							<asp:RangeValidator id="rvMarginLeft" runat="server" ErrorMessage="0.00 to 2.00" ControlToValidate="txbMarginLeft"
								MinimumValue="0" MaximumValue="2.00"></asp:RangeValidator></TD>
						<TD style="WIDTH: 58px">Right</TD>
						<TD>
							<asp:TextBox id="txbMarginRight" runat="server" Width="60px"></asp:TextBox>
							<asp:RangeValidator id="rvMarginRight" runat="server" ErrorMessage="0.00 to 2.00" ControlToValidate="txbMarginRight"
								MinimumValue="0" MaximumValue="2.00"></asp:RangeValidator></TD>
					</TR>
				</TABLE></asp:panel>&nbsp;
			<asp:label id="labelHeader" style="Z-INDEX: 104; LEFT: 227px; POSITION: absolute; TOP: 121px"
				runat="server" Font-Bold="True" Font-Size="Medium">Label</asp:label></form>
	</body>
</HTML>
