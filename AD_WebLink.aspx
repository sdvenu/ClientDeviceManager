<%@ Page language="c#" Codebehind="AD_WebLink.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.AD_WebLink" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Emulator Settings Configuration Screen</title>
		<meta HTTP-EQUIV="content-type" CONTENT="text/html; charset=utf-8">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<link REL="Stylesheet" HREF="css/ClientDeviceMgr.css" TYPE="text/css">
	</HEAD>
	<body>
		<form id="EmulCfg" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<asp:Label id="lblMessage" style="Z-INDEX: 101; LEFT: 220px; POSITION: absolute; TOP: 52px"
				runat="server" Width="800px" Height="48px" ForeColor="Navy" Font-Bold="True" Font-Size="Larger"></asp:Label>
			<asp:Panel id="AutoPanel" style="Z-INDEX: 105; LEFT: 240px; POSITION: absolute; TOP: 275px"
				runat="server" Width="392px" Height="300px">
				<P>&nbsp;</P>
				<P>
					<asp:Label id="lblAutoLabel" runat="server" Font-Bold="True" ForeColor="Navy"
						Width="312px">All profiles currently configured in the database:</asp:Label></P>
				<P>&nbsp;
					<asp:ListBox id="lbxWSNames" runat="server" ForeColor="Black" Height="198px" Width="256px"></asp:ListBox></P>
				<P>&nbsp;
					<asp:Button id="btnAuto" runat="server" Text="Accept" onclick="btnAuto_Click"></asp:Button></P>
			</asp:Panel>
			<asp:Panel id="ManualPanel" style="Z-INDEX: 104; LEFT: 240px; POSITION: absolute; TOP: 138px"
				runat="server" Width="400px" Height="112px">
				<P>&nbsp;</P>
				<P>
					&nbsp;<asp:TextBox id="txtboxWSName" runat="server" ToolTip="Enter the workstation upon which you wish to operate."
						MaxLength="32"></asp:TextBox>
					&nbsp;<asp:Label id="lblManual" runat="server" Font-Bold="True" ForeColor="Navy"
						Width="136px" ToolTip="Enter the workstation you wish to configure.">profile name</asp:Label>
                </P>
				<P>&nbsp;
					<asp:Button id="btnManual" runat="server" Text="Accept" onclick="btnManual_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Width="248px" ControlToValidate="txtboxWSName"
						ErrorMessage="You must enter a profile name."></asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp; 
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				</P>
			</asp:Panel>
			<asp:RadioButton id="AutoSelection" style="Z-INDEX: 103; LEFT: 448px; POSITION: absolute; TOP: 99px"
				runat="server" Text="Auto profile selection" ToolTip="This option allows you to select the workstation name from the master list of all workstations."
				GroupName="SelectionMode" AutoPostBack="True" oncheckedchanged="AutoSelection_CheckedChanged"></asp:RadioButton>
			<asp:RadioButton id="ManualSelection" style="Z-INDEX: 102; LEFT: 240px; POSITION: absolute; TOP: 99px"
				runat="server" Text="Manual profile selection" ToolTip="This option allows you to enter the workstation upon which you wish to operate."
				GroupName="SelectionMode" Checked="True" AutoPostBack="True" oncheckedchanged="ManualSelection_CheckedChanged"></asp:RadioButton>
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
			<asp:Label id="pnlStatus" style="Z-INDEX: 106; LEFT: 384px; POSITION: absolute; TOP: 896px"
				runat="server" Width="376px" Height="62px" ForeColor="#000040" Font-Bold="True"></asp:Label>
			<asp:Panel id="EmulPanel" style="Z-INDEX: 107; LEFT: 16px; POSITION: absolute; TOP: 976px"
				runat="server" Width="800px" Height="32px">
				<P>
                    <em>HTE Links menu entries. [Web] section URL links look like:</em><br />
					Name of Document = http://department.jetnet.aa.com/section/document.pdf<br />
                    Website Name = https://subsystem.aa.com/site.aspx<br />
                    ; Comment about a link
				</P>
				<P>
					<asp:TextBox id="txtboxEmulSettings" runat="server" Font-Size="Small" Font-Bold="True" Height="400px"
						Width="792px" Wrap="False" TextMode="MultiLine"></asp:TextBox></P>
				<P>&nbsp;
					<asp:Button id="btnApply" runat="server" Width="64px" Text="Apply" onclick="btnApply_Click"></asp:Button>&nbsp;
					<asp:Button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:Button></P>
				<P>&nbsp;</P>
			</asp:Panel>
		</form>
	</body>
</HTML>
