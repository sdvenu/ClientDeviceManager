<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Page language="c#" Codebehind="DisplayEmul.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.DisplayEmul" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Display Emulator Settings Configuration Screen</title>
		<meta HTTP-EQUIV="content-type" CONTENT="text/html; charset=utf-8">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<link REL="Stylesheet" HREF="css/ClientDeviceMgr.css" TYPE="text/css">
	</HEAD>
	<body MS_POSITIONING="GridLayout"">
		<form id="EmulCfg" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<asp:Label id="lblMessage" style="Z-INDEX: 101; LEFT: 240px; POSITION: absolute; TOP: 52px"
				runat="server" Width="800px" Height="48px" ForeColor="Navy" Font-Bold="True" Font-Size="Larger"></asp:Label>
            <asp:Label ID="lblWorkstation" style="Z-INDEX: 101; LEFT: 240px; POSITION: absolute; TOP: 102px"
				runat="server" ForeColor="Navy" Font-Bold="True" Font-Size="Small"></asp:Label>
            <asp:Label ID="lblProfile" style="Z-INDEX: 101; LEFT: 280px; POSITION: absolute; TOP: 128px"
				runat="server" ForeColor="Navy" Font-Bold="True" Font-Size="Small"></asp:Label>
            <asp:Label ID="lblHostInfo" style="Z-INDEX: 101; LEFT: 280px; POSITION: absolute; TOP: 154px"
				runat="server" ForeColor="Navy" Font-Bold="True" Font-Size="Small"></asp:Label>
			<asp:Panel id="AutoPanel" style="Z-INDEX: 106; LEFT: 240px; POSITION: absolute; TOP: 285px"
				runat="server" Width="392px" Height="300px">
				<P>
					<asp:Label id="lblAutoLabel" runat="server" Font-Bold="True" ForeColor="Navy" Width="312px">
                        All profiles currently configured in the database:</asp:Label></P>
				<P>&nbsp;
					<asp:ListBox id="lbxWSNames" runat="server" ForeColor="Black" Height="256px" Width="256px"></asp:ListBox></P>
				<P>&nbsp;
					<asp:Button id="btnAuto" runat="server" Text="Accept" onclick="btnAuto_Click"></asp:Button></P>
			</asp:Panel>
			<asp:Panel id="ManualPanel" style="Z-INDEX: 104; LEFT: 240px; POSITION: absolute; TOP: 285px; margin-top: 0px;"
				runat="server" Width="600px" Height="112px">
				<P>
					&nbsp;<asp:TextBox id="txtProfile" runat="server" ToolTip="Enter the profile you wish to view."
						MaxLength="32" Width="300px"></asp:TextBox>
					&nbsp;<asp:Label id="lblManual" runat="server" Font-Bold="True" ForeColor="Navy" Width="136px"
                        ToolTip="Enter the profile you wish to view.">Profile name</asp:Label>
                </P>
				<P>&nbsp;
					<asp:Button id="btnManual" runat="server" Text="Accept" onclick="btnManual_Click"></asp:Button><br />
					<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                        ErrorMessage="You must enter a profile name."
						ControlToValidate="txtProfile">
					</asp:RequiredFieldValidator>
				</P>
			</asp:Panel>
            <div style="position:absolute; left:240px; top:244px; z-index:102">
			    <asp:RadioButton id="ManualSelection"
				    runat="server" Text="Manual profile selection" ToolTip="Enter a profile upon which to operate."
				    Checked="True"
                    GroupName="SelectionMode" AutoPostBack="True" oncheckedchanged="ManualSelection_CheckedChanged"></asp:RadioButton>
                &nbsp;&nbsp;&nbsp;&nbsp;
			    <asp:RadioButton id="AutoSelection"
				    runat="server" Text="Auto profile selection" ToolTip="Select a profile from the master list of profiles."
				    GroupName="SelectionMode" AutoPostBack="True" oncheckedchanged="AutoSelection_CheckedChanged"></asp:RadioButton>
                &nbsp;&nbsp;&nbsp;&nbsp;
			    <asp:RadioButton id="HostInfoSelection"
				    runat="server" Text="HOSTINFO selection" ToolTip="Select a HOSTINFO from the master list of HOSTINFOs."
				    GroupName="SelectionMode" AutoPostBack="True" oncheckedchanged="HostInfoSelection_CheckedChanged"></asp:RadioButton>
                <asp:DropDownList ID="HostInfoList" runat="server" Width="20em"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="HostInfoSelection_CheckedChanged" />
            </div>
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
			<asp:Label id="pnlStatus" style="Z-INDEX: 106; LEFT: 246px; POSITION: absolute; TOP: 196px"
				runat="server" Width="600px" Height="48px" ForeColor="#000040" Font-Bold="True"></asp:Label>
			<asp:Panel id="EmulPanel" style="Z-INDEX: 106; LEFT: 16px; POSITION: absolute; TOP: 300px"
				runat="server" Width="800px" Height="32px">
                <P>
                    <asp:Label ID="lblSlateTitle" runat="server" Font-Size="Small" Font-Bold="True" /></P>
                <P>
                    <asp:Label ID="lblSlateComment" runat="server" Font-Size="XSmall" Font-Bold="True" /></P>
				<P>&nbsp;
					<asp:TextBox id="txtboxSlate" runat="server" Font-Size="Small" Font-Bold="True" Height="350px"
						Width="792px" Wrap="False" TextMode="MultiLine"></asp:TextBox></P>
				<P>&nbsp;
					<asp:Button id="btnApply" runat="server" Text="Apply" Width="64px"
                        Visible="False"
                        Enabled="False"
                        onclick="btnApply_Click"></asp:Button>&nbsp;
					<asp:Button id="btnCancel" runat="server" Text="Cancel" Width="64px"
                        onclick="btnCancel_Click"></asp:Button></P>
			</asp:Panel>
		</form>
	</body>
</HTML>
