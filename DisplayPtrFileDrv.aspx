<%@ Page language="c#" Codebehind="DisplayPtrFileDrv.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.DisplayPtrFileDrv" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Display ConfigPtrFileDrv</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link REL="Stylesheet" HREF="css/ClientDeviceMgr.css" TYPE="text/css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Button id="buttonSave" style="Z-INDEX: 108; LEFT: 704px; POSITION: absolute; TOP: 568px"
				runat="server" Height="40px" Width="108px" Text="Save" Enabled="False" Visible="False" onclick="buttonSave_Click"></asp:Button>
			<MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
			<TABLE id="Table15" cellSpacing="0" cellPadding="0" width="10%" border="0">
				<TR>
					<TD class="navtable" vAlign="top" width="1%">
						<TABLE id="Table61" cellSpacing="10" cellPadding="0" width="100%" border="0"> <!-- BEGIN DYNAMIC LEFT MODULE LIST -->
							<TR>
								<TD style="PADDING-TOP: 5px" align="left">
									<MODULE:SUPPORT id="Support1" runat="server"></MODULE:SUPPORT></TD>
							</TR> <!-- END DYNAMIC LEFT MODULE LIST --></TABLE>
					</TD>
				</TR>
			</TABLE>
			<asp:Label id="CategoryDesciptionLabel" style="Z-INDEX: 109; LEFT: 208px; POSITION: absolute; TOP: 56px"
				runat="server" Font-Bold="True" EnableViewState="False" BackColor="Navy" ForeColor="White"></asp:Label>
			<script src="ClientDeviceMgr.js"></script>
			<asp:Panel id="Panel1" style="Z-INDEX: 101; LEFT: 208px; POSITION: absolute; TOP: 128px" runat="server"
				Width="472px" Height="88px" BorderWidth="1px">
				<P>Select the Device Type that is being configured</P>
				<P>
					<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="0">
						<TR>
							<TD>
								<asp:RadioButton id="rbSingleFile" runat="server" Enabled="False" Text="Single File" Checked="True"
									AutoPostBack="True" oncheckedchanged="rbSingleFile_CheckedChanged"></asp:RadioButton></TD>
							<TD>
								<asp:RadioButton id="rbMultipleFile" runat="server" Enabled="False" Text="Multiple File" AutoPostBack="True" oncheckedchanged="rbMultipleFile_CheckedChanged"></asp:RadioButton></TD>
						</TR>
					</TABLE>
				</P>
			</asp:Panel>
			<TABLE id="Table7" style="Z-INDEX: 106; LEFT: 704px; WIDTH: 257px; POSITION: absolute; TOP: 192px; HEIGHT: 272px"
				cellSpacing="1" cellPadding="1" width="257" border="1">
				<TR>
					<TD vAlign="top" align="left">
						<P>&nbsp;</P>
						<TABLE id="Table8" style="WIDTH: 216px; HEIGHT: 87px" cellSpacing="1" cellPadding="1" width="216"
							border="0">
							<TR>
								<TD>
									<asp:Label id="Label4" runat="server" Font-Underline="True">Debug Level Settings</asp:Label></TD>
							</TR>
							<TR>
								<TD>
									<asp:RadioButton id="rbDebugDisabled" runat="server" AutoPostBack="True" Checked="True" Text="Debugging Disabled" oncheckedchanged="rbDebugDisabled_CheckedChanged"></asp:RadioButton></TD>
							</TR>
							<TR>
								<TD>
									<asp:RadioButton id="rbLogToFile" runat="server" AutoPostBack="True" Text="Logging to file Enabled" oncheckedchanged="rbLogToFile_CheckedChanged"></asp:RadioButton></TD>
							</TR>
							<TR>
								<TD>
									<asp:RadioButton id="rbDebugWindowEnabled" runat="server" AutoPostBack="True" Text="Logging to Debug Status Window Enabled" oncheckedchanged="rbDebugWindowEnabled_CheckedChanged"></asp:RadioButton></TD>
							</TR>
							<TR>
								<TD>
									<asp:RadioButton id="rbDebugFileAndWindowEnabled" runat="server" AutoPostBack="True" Text="Logging to file and Debug Status Window Enabled" oncheckedchanged="rbDebugFileAndWindowEnabled_CheckedChanged"></asp:RadioButton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label2" runat="server" Font-Bold="True">Log File Settings</asp:Label>
						<asp:TextBox id="textBoxLogFileName" runat="server" Width="247px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label3" runat="server" Font-Bold="True">Maximum size of Log File in Bytes</asp:Label>
						<asp:TextBox id="TextBoxMaxLogSize" runat="server" Width="120px" MaxLength="7"></asp:TextBox></TD>
				</TR>
			</TABLE>
			<asp:Label id="Label1" style="Z-INDEX: 105; LEFT: 712px; POSITION: absolute; TOP: 168px" runat="server"
				Font-Bold="True">Debug Info</asp:Label>
			<asp:Panel id="Panel4" style="Z-INDEX: 104; LEFT: 208px; POSITION: absolute; TOP: 480px" runat="server"
				Width="472px" Height="88px" BorderWidth="0px" Font-Bold="True">
				<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD>
							<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="300" border="0">
								<TR>
									<TD><STRONG>Single File</STRONG></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD>Max File Size</TD>
									<TD>
										<asp:TextBox id="textboxMaxFileSize" runat="server" Enabled="False"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>File Extention
									</TD>
									<TD>
										<asp:TextBox id="textboxFileExtention" runat="server" Enabled="False"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>EOM Label</TD>
									<TD>
										<asp:TextBox id="textboxEOMLabel" runat="server" Enabled="False" Width="176px">************EOM*******************</asp:TextBox></TD>
								</TR>
								<TR>
									<TD colSpan="2">
										<asp:CheckBox id="cbAppedData" runat="server" Enabled="False" Text="Append Data to File" Checked="True"></asp:CheckBox></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</TD>
						<TD>
							<TABLE id="Table6" style="WIDTH: 158px; HEIGHT: 113px" cellSpacing="1" cellPadding="1"
								width="158" border="0">
								<TR>
									<TD><STRONG>Multiple File</STRONG></TD>
								</TR>
								<TR>
									<TD>
										<asp:RadioButton id="rbTimeStamp" runat="server" Enabled="False" Text="Time Stamp" AutoPostBack="True" oncheckedchanged="rbTimeStamp_CheckedChanged"></asp:RadioButton></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px">
										<asp:RadioButton id="rbIncrement" runat="server" Enabled="False" Text="Increment" Checked="True"
											AutoPostBack="True" oncheckedchanged="rbIncrement_CheckedChanged"></asp:RadioButton></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px">Max Files to Create</TD>
								</TR>
								<TR>
									<TD>
										<asp:TextBox id="textboxMaxFiles" runat="server" Enabled="False" Width="80px" MaxLength="5"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<asp:Panel id="Panel3" style="Z-INDEX: 103; LEFT: 208px; POSITION: absolute; TOP: 320px" runat="server"
				Width="472px" Height="88px" BorderWidth="1px">
				<P>
					<TABLE id="Table3" style="WIDTH: 464px; HEIGHT: 133px" cellSpacing="1" cellPadding="1"
						width="464" border="0">
						<TR>
							<TD style="WIDTH: 292px">Location where File Output will take place</TD>
							<TD></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 292px">
								<asp:TextBox id="textboxFileLocation" runat="server" Enabled="False" Width="280px"></asp:TextBox></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 292px">Enter the name of output file without specifying extention</TD>
							<TD></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 292px">
								<asp:TextBox id="textboxFileName" runat="server" Enabled="False"></asp:TextBox></TD>
							<TD>
								<asp:CheckBox id="cbInsertLFAfterCr" runat="server" Enabled="False" Text="Insert LF/After CR"
									Checked="True"></asp:CheckBox></TD>
						</TR>
					</TABLE>
				</P>
			</asp:Panel>
			<asp:Panel id="Panel2" style="Z-INDEX: 102; LEFT: 208px; POSITION: absolute; TOP: 224px" runat="server"
				Width="472px" Height="88px" BorderWidth="1px">&nbsp;Device Name 
<TABLE id="Table2" style="WIDTH: 448px; HEIGHT: 47px" cellSpacing="1" cellPadding="1" width="448"
					border="0">
					<TR>
						<TD>
							<asp:TextBox id="textboxDeviceName" runat="server" Enabled="False"></asp:TextBox></TD>
						<TD>
							<asp:RadioButton id="rbEnabled" runat="server" Enabled="False" Text="Enabled" Checked="True" AutoPostBack="True" oncheckedchanged="rbEnabled_CheckedChanged"></asp:RadioButton></TD>
						<TD>
							<asp:RadioButton id="rbDisabled" runat="server" Enabled="False" Text="Disabled" AutoPostBack="True" oncheckedchanged="rbDisabled_CheckedChanged"></asp:RadioButton></TD>
					</TR>
				</TABLE></asp:Panel>&nbsp;
			<asp:Label id="labelHeader" style="Z-INDEX: 107; LEFT: 210px; POSITION: absolute; TOP: 94px"
				runat="server" Font-Bold="True" Font-Size="Medium">Label</asp:Label>
		</form>
	</body>
</HTML>
