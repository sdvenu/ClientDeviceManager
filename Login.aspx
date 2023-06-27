<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ClientDevice Manager Login Page</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE --><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
			<!-- END PAGE HEADER MODULE -->
            <asp:label id="lblLoginMsg" style="Z-INDEX: 101; LEFT: 100px; POSITION: absolute; TOP: 88px; width: 800px;"
				runat="server" Height="24px" ForeColor="#330099" Font-Bold="True" Font-Size="24px">
                Network Device Management Main Login
            </asp:label>
            <asp:label id="lblUserId" style="Z-INDEX: 102; LEFT: 200px; POSITION: absolute; TOP: 147px; width: 96px;"
				runat="server" Font-Size="14px">
                UserId
            </asp:label>
            <asp:label id="lblPassword" style="Z-INDEX: 103; LEFT: 200px; POSITION: absolute; TOP: 181px; width: 96px;"
				runat="server" Font-Size="14px">
                Password
            </asp:label>
            <asp:textbox id="txtBoxUserID" style="Z-INDEX: 104; LEFT: 303px; POSITION: absolute; TOP: 144px;"
				runat="server" MaxLength="16" ToolTip="Enter your UserID." />
            <asp:textbox id="txtBoxPassword" style="Z-INDEX: 105; LEFT: 303px; POSITION: absolute; TOP: 178px;"
				runat="server" MaxLength="16" ToolTip="Enter your password." TextMode="Password" />
            <asp:requiredfieldvalidator id="UserIDValidator" style="Z-INDEX: 106; LEFT: 554px; POSITION: absolute; TOP: 149px; width: 300px;"
				runat="server" ControlToValidate="txtBoxUserID" ErrorMessage="You must enter a UserID." />
            <asp:requiredfieldvalidator id="PasswordValidator" style="Z-INDEX: 107; LEFT: 553px; POSITION: absolute; TOP: 178px; width: 300px;"
				runat="server" ControlToValidate="txtBoxPassword" ErrorMessage="You must enter a password." />
            <asp:button id="btnLogin" style="Z-INDEX: 108; LEFT: 303px; POSITION: absolute; TOP: 218px"
				runat="server" Width="96px" Text="Login" onclick="btnLogin_Click" Font-Size="14px" Height="24px" />
            <asp:label id="lblErrorMsg" style="Z-INDEX: 109; LEFT: 207px; POSITION: absolute; TOP: 296px; width: 594px; height: 26px;"
				runat="server" ForeColor="Red" Font-Bold="True" />
		</form>
	</body>
</HTML>
