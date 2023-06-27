<%@ Page language="c#" Codebehind="DisplayPtrAEALiteDrv.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.DisplayPtrAEALiteDrv" %>
<%@ Register TagPrefix="uc1" TagName="ComPortCtrl" Src="ComPortCtrl.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title> Display ConfigPtrAEALiteDrv</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<script src="ClientDeviceMgr.js"></script>
			<asp:label id="labelHeader" style="Z-INDEX: 101; LEFT: 210px; POSITION: absolute; TOP: 96px"
				runat="server" Font-Bold="True" Font-Size="Medium">Header</asp:label><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
			<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="10%" border="0">
				<TR>
					<TD class="navtable" vAlign="top" width="1%">
						<TABLE id="Table6" cellSpacing="10" cellPadding="0" width="100%" border="0"> <!-- BEGIN DYNAMIC LEFT MODULE LIST -->
							<TR>
								<TD style="PADDING-TOP: 5px" align="left"><MODULE:SUPPORT id="Support1" runat="server"></MODULE:SUPPORT></TD>
							</TR> <!-- END DYNAMIC LEFT MODULE LIST --></TABLE>
					</TD>
				</TR>
			</TABLE>
			<asp:Label id="CategoryDesciptionLabel" style="Z-INDEX: 108; LEFT: 208px; POSITION: absolute; TOP: 48px"
				runat="server" Font-Bold="True" EnableViewState="False" BackColor="Navy" ForeColor="White"></asp:Label>
			<TABLE id="Table3" style="Z-INDEX: 106; LEFT: 720px; WIDTH: 257px; POSITION: absolute; TOP: 128px; HEIGHT: 272px"
				cellSpacing="1" cellPadding="1" width="257" border="1">
				<TR>
					<TD vAlign="top" align="left">
						<P>&nbsp;</P>
						<TABLE id="Table4" style="WIDTH: 216px; HEIGHT: 87px" cellSpacing="1" cellPadding="1" width="216"
							border="0">
							<TR>
								<TD><asp:label id="Label4" runat="server" Font-Underline="True">Debug Level Settings</asp:label></TD>
							</TR>
							<TR>
								<TD><asp:radiobutton id="rbDebugDisabled" runat="server" AutoPostBack="True" Checked="True" Text="Debugging Disabled"
										Enabled="False" oncheckedchanged="rbDebugDisabled_CheckedChanged"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD><asp:radiobutton id="rbLogToFile" runat="server" AutoPostBack="True" Text="Logging to file Enabled"
										Enabled="False" oncheckedchanged="rbLogToFile_CheckedChanged"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD><asp:radiobutton id="rbDebugWindowEnabled" runat="server" AutoPostBack="True" Text="Logging to Debug Status Window Enabled"
										Enabled="False" oncheckedchanged="rbDebugWindowEnabled_CheckedChanged"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD><asp:radiobutton id="rbDebugFileAndWindowEnabled" runat="server" AutoPostBack="True" Text="Logging to file and Debug Status Window Enabled"
										Enabled="False" oncheckedchanged="rbDebugFileAndWindowEnabled_CheckedChanged"></asp:radiobutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="Label2" runat="server" Font-Bold="True">Log File Settings</asp:label>
                        <asp:textbox id="textBoxLogFileName" runat="server" Width="247px" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label3" runat="server" Font-Bold="True">Maximum size of Log File in Bytes</asp:label><asp:textbox id="textBoxMaxFileSize" runat="server" Width="120px" MaxLength="7" Enabled="False" ontextchanged="textBoxMaxFileSize_TextChanged"></asp:textbox></TD>
				</TR>
			</TABLE>
			<asp:panel id="Panel3" style="Z-INDEX: 104; LEFT: 208px; POSITION: absolute; TOP: 400px" runat="server"
				Width="504px" BorderWidth="1px" Height="120px">
				<P>&nbsp;This is the IO driver used to interface with the communication resources 
					on this workstation.</P>
				<P>
					<asp:DropDownList id="ddlIoDriver" runat="server" Enabled="False">
						<asp:ListItem Value="PORTS.DLL">PORTS.DLL</asp:ListItem>
					</asp:DropDownList></P>
				<P>
					<asp:CheckBox id="cbDopPPCCTC" runat="server" Enabled="False" Text="Remove PC(Pectab Clear) and CT(Change Transaction) data"
						Checked="True"></asp:CheckBox></P>
			</asp:panel>
            <asp:panel id="Panel1" style="Z-INDEX: 102; LEFT: 208px; POSITION: absolute; TOP: 128px" runat="server"
				Width="504px" BorderWidth="1px" Height="48px">
				<P>
					<TABLE id="Table1" style="WIDTH: 440px; HEIGHT: 36px" cellSpacing="1" cellPadding="1" width="440"
						border="0">
						<TR>
							<TD style="WIDTH: 134px; HEIGHT: 17px">Device Name</TD>
							<TD style="HEIGHT: 17px" width="150"></TD>
							<TD style="HEIGHT: 17px"></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 134px">
								<asp:TextBox id="textboxDeviceName" runat="server" Enabled="False"></asp:TextBox></TD>
							<TD width="150">
								<asp:RadioButton id="rbEnabled" runat="server" Enabled="False" Text="Enabled" Checked="True" AutoPostBack="True" oncheckedchanged="rbEnabled_CheckedChanged"></asp:RadioButton></TD>
							<TD>
								<asp:RadioButton id="rbDisabled" runat="server" Enabled="False" Text="Disabled" AutoPostBack="True"
									Width="192px" oncheckedchanged="rbDisabled_CheckedChanged"></asp:RadioButton></TD>
						</TR>
					</TABLE>
				</P>
			</asp:panel>
            <asp:panel id="Panel2" style="Z-INDEX: 103; LEFT: 208px; POSITION: absolute; TOP: 192px" runat="server"
				Width="504px" BorderWidth="1px" Height="200px">
				<TABLE id="Table2" style="WIDTH: 504px; HEIGHT: 96px" cellSpacing="1" cellPadding="1" width="504"
					border="0">
					<TR>
						<TD style="WIDTH: 146px; HEIGHT: 80px" vAlign="top">
							<P>This value represents the number of form feeds sent to the ptr after each msg.</P>
							<P>&nbsp;
								<asp:TextBox id="textboxNoOfFF" runat="server" Enabled="False" Width="40px" MaxLength="1">0</asp:TextBox>&nbsp;&nbsp;</P>
						</TD>
						<TD style="WIDTH: 173px" vAlign="top" rowSpan="1">
							<P>
								<uc1:ComPortCtrl id="ComPortCtrl1" runat="server"></uc1:ComPortCtrl></P>
						</TD>
						<TD style="HEIGHT: 80px" vAlign="top">
							<P>
								<TABLE id="Table7" style="WIDTH: 168px; HEIGHT: 128px" cellSpacing="0" cellPadding="0"
									width="168" border="0">
									<TR>
										<TD style="HEIGHT: 81px" vAlign="top">
											<P>By Checking the insert LF/After CR a Line Feed will be sent to the printer after 
												each Carriage Return.</P>
										</TD>
									</TR>
									<TR>
										<TD>
											<P>
												<asp:CheckBox id="cbInsertLFAfterCR" runat="server" Enabled="False" Text="Insert LF/After CR"
													Checked="True" oncheckedchanged="cbInsertLFAfterCR_CheckedChanged"></asp:CheckBox></P>
										</TD>
									</TR>
									<TR>
										<TD>
											<asp:CheckBox id="cbHostAnswerback" runat="server" Enabled="False" Text="Host Answerback"></asp:CheckBox></TD>
									</TR>
								</TABLE>
							</P>
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
            <asp:button id="buttonSave" style="Z-INDEX: 105; LEFT: 220px; POSITION: absolute; TOP: 528px"
				runat="server" Text="Save" Width="108px" Height="40px" Visible="False" onclick="buttonSave_Click"></asp:button>
            <asp:label id="Label1" style="Z-INDEX: 107; LEFT: 720px; POSITION: absolute; TOP: 104px" runat="server"
				Font-Bold="True">Debug Info</asp:label>
			<P>&nbsp;</P>
		</form>
	</body>
</HTML>
