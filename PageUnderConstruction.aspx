<%@ Page language="c#" Codebehind="PageUnderConstruction.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.PageUnderConstruction" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PageUnderConstruction</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<Module:Header id="MainHeader" runat="server"></Module:Header>
			<!-- END PAGE HEADER MODULE -->
			<asp:Label id="lblUnderConstruction" style="Z-INDEX: 101; LEFT: 176px; POSITION: absolute; TOP: 104px"
				runat="server" Width="408px" Height="104px" Font-Bold="True" Font-Size="Larger" ForeColor="Navy">This page in under construction but coming soon.</asp:Label>
			<asp:ImageButton id="btnPrevious" style="Z-INDEX: 102; LEFT: 176px; POSITION: absolute; TOP: 240px"
				runat="server" Width="88px" Height="40px" ToolTip="Return to previous page." ImageUrl="~/images/previous.gif" onclick="btnPrevious_Click"></asp:ImageButton>
		</form>
	</body>
</HTML>
