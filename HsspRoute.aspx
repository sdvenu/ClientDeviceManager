<%@ Page language="c#" Codebehind="HsspRoute.aspx.cs" AutoEventWireup="True" validateRequest=false Inherits="ClientDeviceMgr.HsspRoute" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HsspRoute Configuration</title>
		<meta HTTP-EQUIV="content-type" CONTENT="text/html; charset=utf-8">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<link REL="Stylesheet" HREF="css/ClientDeviceMgr.css" TYPE="text/css">
		<script src="ClientDeviceMgr.js" type="text/javascript"></script>
	</HEAD>
	<body>
		<form id="HSSPRouteForm" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<Module:Header id="MainHeader" runat="server"></Module:Header>
			<asp:Panel id="pnlGeneral" style="Z-INDEX: 101; LEFT: 320px; POSITION: absolute; TOP: 52px" runat="server"
				Width="400px" BackColor="Silver" BorderColor="White">
				<P>&nbsp;&nbsp;
					Select the device type that is being configured.<br />
					&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton id="rbTerminal" runat="server" Text="Terminal" GroupName="DevType"
                         AutoPostBack="True" oncheckedchanged="rbTerminal_CheckedChanged"></asp:RadioButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:RadioButton id="rbPrinter" runat="server" Text="Printer" GroupName="DevType"
                         AutoPostBack="True" oncheckedchanged="rbPrinter_CheckedChanged"></asp:RadioButton></P>
				<P>
					&nbsp;&nbsp;Provide the Host LNIATA to use to communicate with NOFEP.<br />
                    &nbsp;&nbsp;This is a six byte value. Enter 000000 if using a pool.</P>
				<P>&nbsp;&nbsp;
					<asp:TextBox id="txtboxLNIATA" runat="server"
                        Width="5em" MaxLength="6"
                        Style="vertical-align:middle; text-align:right"
                        OnKeyUp="return LimitToHex(HSSPRouteForm.txtboxLNIATA)"
                        ToolTip="Your LNIATA to communicate with the host."></asp:TextBox>&nbsp;
                    Fixed&nbsp;&nbsp;&nbsp;
					<asp:RadioButton id="rbHostPooling" runat="server"
                        Text="Host Pool" AutoPostBack="True" GroupName="PoolType"
                        oncheckedchanged="rbHostPooling_CheckedChanged"></asp:RadioButton>&nbsp;&nbsp;&nbsp;
					<asp:RadioButton id="rbAgencyPooling" runat="server"
                        Text="Agency Pool" AutoPostBack="True" GroupName="PoolType"
                        oncheckedchanged="rbAgencyPooling_CheckedChanged"></asp:RadioButton></P>

				<table width="100%" style="margin:1em">
					<tr width="100%">
						<td width="50%">
							Base Pseudo City Code<br />
							<asp:TextBox id="txtboxBCC" runat="server"
                                MaxLength="8" Width="9em"
								ToolTip="Enter the Base PCC of the agency."></asp:TextBox>
							<br />&nbsp;
						</td>
						<td width="50%">
							Pool Name<br />
							<asp:TextBox id="txtboxHostPoolName" runat="server"
                                MaxLength="8" Width="9em"
								ToolTip="Enter the Host Pool Name you wish to use."></asp:TextBox>
							<br />&nbsp;
						</td>
					</tr>
					<tr width="100%">
						<td width="50%">
							Branch PCC Code<br />
							<asp:TextBox id="txtboxBranchPCC" runat="server"
                                MaxLength="8" Width="9em"
								ToolTip="Enter your Branch PCC."></asp:TextBox>
							<br />&nbsp;
						</td>
						<td width="50%">
							Profile Key<br />
							<asp:TextBox id="txtboxProfileKey" runat="server"
                                MaxLength="8" Width="9em"
								ToolTip="Enter your Profile Key."></asp:TextBox>
							<br />&nbsp;
						</td>
					</tr>
					<tr width="100%">
						<td width="50%">
							&nbsp;
						</td>
						<td width="50%">
							City Code<br />
							<asp:TextBox id="txtboxCityCode" runat="server"
                                MaxLength="4" Width="5em"
								ToolTip="Enter the home City Code."></asp:TextBox>
							<br />&nbsp;
						</td>
					</tr>
					<tr width="100%">
						<td width="50%">
							&nbsp;
						</td>
						<td width="50%">
							Partition<br />
							<asp:TextBox id="txtboxPartition" runat="server"
                                MaxLength="4" Width="5em"
								ToolTip="Enter the Partition name."></asp:TextBox>
							<br />&nbsp;
						</td>
					</tr>
				</table>

				<P>&nbsp;&nbsp;
					<asp:Button id="pnlGeneral_OK" runat="server" Width="72px" Text="OK" onclick="pnlGeneral_OK_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
					<asp:Button id="pnlGeneral_Cancel" runat="server" Width="72px" Text="Cancel" onclick="pnlGeneral_Cancel_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
					<asp:Button id="pnlGeneral_Back" runat="server" Width="72px" Text="<< Back" Enabled="false"></asp:Button>&nbsp;&nbsp;&nbsp;
					<asp:Button id="pnlGeneral_Next" runat="server" Width="72px" Text="Next >>" onclick="pnlGeneral_Next_Click"></asp:Button></P>
			</asp:Panel>
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
			&nbsp;
			<asp:Panel id="pnlNetwork" style="Z-INDEX: 102; LEFT: 112px; POSITION: absolute; TOP: 556px"
				runat="server" BackColor="Silver" Width="400px">
				<P>&nbsp;
                    <strong><em>Host Information</em></strong></P>
				<P>
					&nbsp;&nbsp;Enter the default host that will service this session.<br />
                    &nbsp;&nbsp;(e.g. AA.ENC.HAVAIL.SABRE.COM)</P>
				<p>&nbsp;&nbsp;
					<asp:TextBox id="txtboxDefaultHost" runat="server"
                        MaxLength="32" Width="250"
                        ToolTip="Enter the default host for this session."></asp:TextBox><br />
					&nbsp;&nbsp;<asp:CheckBox id="ckboxSSL" runat="server"
                        Text="Encrypt this and all host connections?"></asp:CheckBox></p>
				<p>
					&nbsp;&nbsp;<asp:CheckBox id="ckboxLDAP" runat="server"
                        Text="LDAP enabled"></asp:CheckBox><br />
					&nbsp;&nbsp;<asp:CheckBox id="ckboxSegOverride" runat="server"
                        Text="Segment Override Enabled"></asp:CheckBox><br />
					&nbsp;&nbsp;<asp:CheckBox id="ckboxSessionPersistent" runat="server"
                        Text="Session Persistence Enabled"></asp:CheckBox></p>
				<P>&nbsp;
					<asp:Button id="pnlNetwork_OK" runat="server" Width="72px" Text="OK" onclick="pnlNetwork_OK_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
					<asp:Button id="pnlNetwork_Cancel" runat="server" Width="72px" Text="Cancel" onclick="pnlNetwork_Cancel_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
					<asp:Button id="pnlNetwork_Back" runat="server" Width="72px" Text="<< Back" onclick="pnlNetwork_Back_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
					<asp:Button id="pnlNetwork_Next" runat="server" Width="72px" Text="Next >>" onclick="pnlNetwork_Next_Click"></asp:Button></P>
			</asp:Panel>
			<asp:Panel id="pnlDebug" style="Z-INDEX: 103; LEFT: 112px; POSITION: absolute; TOP: 840px"
				runat="server" BackColor="Silver" Width="400px">
				<P>&nbsp;
                    <strong><em>Debugging Information</em></strong></P>
                <P>
					&nbsp;<asp:CheckBox id="ckboxTracing" runat="server"
                        Text="Enable Logging."></asp:CheckBox><br /></P>
				    &nbsp;&nbsp;Maximum Log File size in kilobytes.<br />
				    &nbsp;&nbsp;<asp:TextBox id="txtboxLogFileSize" runat="server"
                        Width="6em" MaxLength="8"
                        Style="vertical-align:middle; text-align:right"
                        OnKeyUp="return LimitToNumeric(HSSPRouteForm.txtboxLogFileSize)"
						ToolTip="Enter the max size of the log file.">1000</asp:TextBox>
				    &nbsp;KB
                    <br /><br />
                    &nbsp;&nbsp;Specify the fully qualified path of the log file.<br />
				    <asp:TextBox id="txtboxLogFilePath" runat="server"
                        Width="100%" MaxLength="256"
						ToolTip="Enter the fully qualified path to where your log file will be created.">
                        C:\ProgramData\CommonHostFiles\HSSP.LOG
				    </asp:TextBox>
				<P>
					&nbsp;<asp:CheckBox id="ckboxOpt7Tracing" runat="server"
                        Text="Enable NOFEP tracing. This also enables local tracing."></asp:CheckBox><br />
					&nbsp;<asp:CheckBox id="ckboxE2ETracing" runat="server"
                        Text="Enable E2E NOFEP performance tracing."></asp:CheckBox></P>
				<P>&nbsp;
					<asp:Button id="pnlDebug_OK" runat="server" Width="72px" Text="OK" onclick="pnlDebug_OK_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
					<asp:Button id="pnlDebug_Cancel" runat="server" Width="72px" Text="Cancel" onclick="pnlDebug_Cancel_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
					<asp:Button id="pnlDebug_Back" runat="server" Width="72px" Text="<< Back" onclick="pnlDebug_Back_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
					<asp:Button id="pnlDebug_Next" runat="server" Width="72px" Text="Next >>" onclick="pnlDebug_Next_Click"></asp:Button></P>
			</asp:Panel>
			<asp:Panel id="pnlEncryption" style="Z-INDEX: 104; LEFT: 112px; POSITION: absolute; TOP: 1134px"
				runat="server" BackColor="Silver" Width="400px">
				<P>&nbsp;
                    <strong><em>Encryption Information</em></strong></P>
				<P>
					&nbsp;<asp:CheckBox id="ckboxSSLLogging" runat="server"
                        Text="Enable SSL Logging."></asp:CheckBox><br /></P>
				    &nbsp;&nbsp;Maximum SSL Log File size in kilobytes.<br />
				    &nbsp;&nbsp;<asp:TextBox id="txtboxSSLMaxLogFileSize" runat="server"
                        Width="6em" MaxLength="8"
                        Style="vertical-align:middle; text-align:right"
                        OnKeyUp="return LimitToNumeric(HSSPRouteForm.txtboxSSLMaxLogFileSize)"
						ToolTip="Enter the maximum size of the SSL log file.">1000</asp:TextBox>
                    &nbsp;KB
				    <br /><br />
                    &nbsp;&nbsp;Specify the fully qualified path of the SSL log file.<br />
				    <asp:TextBox id="txtboxSSLLogFile" runat="server"
                        Width="100%" MaxLength="256"
						ToolTip="Enter the fully qualified path to where your SSL log file will be created.">
                        C:\ProgramData\CommonHostFiles\SSL.LOG
				    </asp:TextBox>
				<P>
				    &nbsp;&nbsp;<strong><em>For Troubleshooting ONLY</em></strong><br /><br />
				    &nbsp;&nbsp;SSL Handshake Timeout
					&nbsp;<asp:TextBox id="txtboxSSLHandshakeTimeout" runat="server"
                        Width="4em" MaxLength="5"
                        Style="vertical-align:middle; text-align:right"
                        OnKeyUp="return LimitToNumeric(HSSPRouteForm.txtboxSSLHandshakeTimeout)"
                        ToolTip="The time waiting on an SSL handshaking before giving up and trying an unencrypted connection"></asp:TextBox>
                    &nbsp;ms
                    <br /></P>
				<P>&nbsp;
					<asp:Button id="pnlEncryption_OK" runat="server" Width="72px" Text="OK" onclick="pnlEncryption_OK_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
					<asp:Button id="pnlEncryption_Cancel" runat="server" Width="72px" Text="Cancel" onclick="pnlEncryption_Cancel_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
					<asp:Button id="pnlEncryption_Back" runat="server" Width="72px" Text="<< Back" onclick="pnlEncryption_Back_Click"></asp:Button>&nbsp;&nbsp;&nbsp;
					<asp:Button id="pnlEncryption_Next" runat="server" Width="72px" Text="Next >>" Enabled="false"></asp:Button></P>
            </asp:Panel>
		</form>
	</body>
</HTML>
