<%@ Page language="c#" Codebehind="OFEPRoute.aspx.cs" AutoEventWireup="True" validateRequest=false Inherits="ClientDeviceMgr.OFEPRoute" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>OFEPRoute Configuration</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="OFEPRouteForm" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE --><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
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
			<asp:panel id="PanelNetwork" style="Z-INDEX: 102; LEFT: 168px; POSITION: absolute; TOP: 24px"
				runat="server" BackColor="Silver" Height="200px" Width="368px">
				<P>&nbsp;</P>
				<P>&nbsp;
					<asp:Label id="Label4" runat="server" Width="320px" Font-Size="Smaller">These are the DNS names for the OFEP Load Balancers. These represent the contact points for sessions with the OFEPS.</asp:Label></P>
				<P>&nbsp;
					<asp:Label id="Label5" runat="server" Width="136px" Font-Size="Smaller">Primary Load Balancer</asp:Label></P>
				<P>
					<asp:TextBox id="txtlb1" runat="server" Width="232px" MaxLength="32"></asp:TextBox></P>
				<P>&nbsp;
					<asp:Label id="Label6" runat="server" Width="144px" Font-Size="Smaller">Secondary Load Balancer</asp:Label></P>
				<P>
					<asp:TextBox id="txtlb2" runat="server" Width="224px" MaxLength="32"></asp:TextBox></P>
				<P>&nbsp;
					<asp:Label id="Label7" runat="server" Width="184px" Font-Size="Smaller">TCP Port of the Load Balancers.</asp:Label></P>
				<P>
					<asp:TextBox id="txtboxTCPPort" runat="server" Width="128px" MaxLength="5"></asp:TextBox></P>
				<P>&nbsp;
					<asp:Button id="pnlNetworkCancel" runat="server" Text="Cancel" onclick="pnlNetworkCancel_Click"></asp:Button>&nbsp;
					<asp:Button id="pnlNetworkBack" runat="server" Text="<<Back" onclick="pnlNetworkBack_Click"></asp:Button>&nbsp;
					<asp:Button id="pnlNetworkNext" runat="server" Text="Next>>" onclick="pnlNetworkNext_Click"></asp:Button></P>
			</asp:panel>
            <asp:panel id="PanelBasic" style="Z-INDEX: 101; LEFT: 144px; POSITION: absolute; TOP: 400px"
				runat="server" BackColor="Silver" Height="224px" Width="328px">
				<P><FONT style="BACKGROUND-COLOR: #ffffff"></FONT>&nbsp;</P>
				<P>&nbsp;
					<asp:Label id="Label1" runat="server" Width="280px" Font-Size="Smaller">Provide the Host LNIATA to use to communicate via OFEP. This is a six byte value. Enter 000000 to use a pool.</asp:Label></P>
				<P>&nbsp;
					<asp:TextBox id="txtboxLNIATA" runat="server" Width="112px" MaxLength="6"></asp:TextBox></P>
				<P>&nbsp;
					<asp:Label id="Label2" runat="server" Width="296px" Font-Size="Smaller">Enter the pool class from which you wish to obtain a pooled TA from the OFEP.</asp:Label></P>
				<P>&nbsp;
					<asp:TextBox id="txtboxClassName" runat="server" Width="112px" MaxLength="20"></asp:TextBox></P>
				<P>&nbsp;
					<asp:Label id="Label3" runat="server" Width="296px" Font-Size="Smaller">This setting allows for enabling the OFEP Keep Alive Packet. It is recommended for printer devices.</asp:Label></P>
				<P>&nbsp;
					<asp:CheckBox id="ckboxKeepAlive" runat="server" Font-Size="Smaller" Text="Enable Keep Alive"></asp:CheckBox></P>
				<P>&nbsp;
					<asp:Button id="btnbaicCancel" runat="server" Text="Cancel" onclick="btnbaicCancel_Click"></asp:Button>&nbsp;&nbsp;
					<asp:Button id="btnbasicNext" runat="server" Text="Next>>" onclick="btnbasicNext_Click"></asp:Button></P>
				<P>&nbsp;</P>
			</asp:panel>
            <asp:panel id="PanelDebug" style="Z-INDEX: 103; LEFT: 496px; POSITION: absolute; TOP: 506px"
				runat="server" BackColor="Silver" Height="260px" Width="300px">
				<P><FONT style="BACKGROUND-COLOR: #ffffff"></FONT>&nbsp;</P>
				<P>&nbsp;
					<asp:Label id="Label8" runat="server" Width="114px" Font-Size="Smaller">Enable Local Tracing.</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label9" runat="server" Width="124px" Height="22px" Font-Size="Smaller">Maximum Log File Size in Kilobytes(KB).</asp:Label></P>
				<P>&nbsp;
					<asp:CheckBox id="ckboxTraceActive" runat="server" Font-Size="Smaller" Text="Tracing Active"></asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:TextBox id="txtboxLogSize" runat="server" Width="90px" MaxLength="15"></asp:TextBox></P>
				<P>&nbsp;</P>
				<P>&nbsp;
					<asp:Label id="Label10" runat="server" Width="274px" Font-Size="Smaller">Specify the location of the log file.</asp:Label></P>
				<P>&nbsp;
					<asp:TextBox id="txtboxLogFilePath" runat="server" Width="600px" MaxLength="255" ToolTip="Enter the fully qualified path to where the logging information is to be output.">C:\ProgramData\CommonHostFiles\OFEP.log</asp:TextBox></P>
				<P>&nbsp;&nbsp;
					<asp:Button id="btnDbgOK" runat="server" Width="58px" Text="OK" onclick="btnDbgOK_Click"></asp:Button>&nbsp;
					<asp:Button id="btnDbgCancel" runat="server" Width="58px" Text="Cancel" onclick="btnDbgCancel_Click"></asp:Button>&nbsp;
					<asp:Button id="btnDbgBack" runat="server" Width="58px" Text="<<Back" onclick="btnDbgBack_Click"></asp:Button></P>
				<P>&nbsp;</P>
			</asp:panel></form>
	</body>
</HTML>
