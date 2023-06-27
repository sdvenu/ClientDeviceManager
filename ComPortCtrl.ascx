<%@ Control Language="c#" AutoEventWireup="True" Codebehind="ComPortCtrl.ascx.cs" Inherits="ClientDeviceMgr.ComPortCtrl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE id="Table1" style="WIDTH: 184px; HEIGHT: 123px" cellSpacing="1" cellPadding="1"
	width="184" border="0">
	<TR>
		<TD style="WIDTH: 138px" align="center" colSpan="2">
			<asp:Label id="Label5" runat="server">COM Port Settings</asp:Label></TD>
		<TD></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 88px; HEIGHT: 17px">
			<asp:Label id="Label6" runat="server">Port</asp:Label></TD>
		<TD style="HEIGHT: 17px">
			<asp:DropDownList id="ddlPort" runat="server" AutoPostBack="True" onselectedindexchanged="ddlPort_SelectedIndexChanged">
				<asp:ListItem Value="COM1">COM1</asp:ListItem>
				<asp:ListItem Value="COM2">COM2</asp:ListItem>
				<asp:ListItem Value="COM3">COM3</asp:ListItem>
				<asp:ListItem Value="COM4">COM4</asp:ListItem>
                <asp:ListItem Value="COM5">COM5</asp:ListItem>
                <asp:ListItem Value="COM6">COM6</asp:ListItem>
                <asp:ListItem Value="COM7">COM7</asp:ListItem>                
				<asp:ListItem Value="LPT1">LPT1</asp:ListItem>
			</asp:DropDownList></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 88px; HEIGHT: 16px">
			<asp:Label id="Label1" runat="server">Baud Rate</asp:Label></TD>
		<TD style="HEIGHT: 16px">
			<asp:DropDownList id="ddlBaudRate" runat="server">
				<asp:ListItem Value="75">75</asp:ListItem>
				<asp:ListItem Value="110">110</asp:ListItem>
				<asp:ListItem Value="150">150</asp:ListItem>
				<asp:ListItem Value="300">300</asp:ListItem>
				<asp:ListItem Value="600">600</asp:ListItem>
				<asp:ListItem Value="1200">1200</asp:ListItem>
				<asp:ListItem Value="1800">1800</asp:ListItem>
				<asp:ListItem Value="2400">2400</asp:ListItem>
				<asp:ListItem Value="4800">4800</asp:ListItem>
				<asp:ListItem Value="7200">7200</asp:ListItem>
				<asp:ListItem Value="9600">9600</asp:ListItem>
				<asp:ListItem Value="14400">14400</asp:ListItem>
				<asp:ListItem Value="19200">19200</asp:ListItem>
				<asp:ListItem Value="38400">38400</asp:ListItem>
				<asp:ListItem Value="57600">57600</asp:ListItem>
			</asp:DropDownList></TD>
	</TR>
	<TR>
		<TD width="70" style="HEIGHT: 17px">
			<asp:Label id="Label2" runat="server">Data Bits</asp:Label></TD>
		<TD style="HEIGHT: 17px">
			<asp:DropDownList id="ddlDataBits" runat="server">
				<asp:ListItem Value="4">4</asp:ListItem>
				<asp:ListItem Value="5">5</asp:ListItem>
				<asp:ListItem Value="6">6</asp:ListItem>
				<asp:ListItem Value="7">7</asp:ListItem>
				<asp:ListItem Value="8">8</asp:ListItem>
			</asp:DropDownList></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 88px; HEIGHT: 26px" width="88">
			<asp:Label id="Label3" runat="server">Parity</asp:Label></TD>
		<TD style="HEIGHT: 26px">
			<asp:DropDownList id="ddlParityBits" runat="server">
				<asp:ListItem Value="0">Even</asp:ListItem>
				<asp:ListItem Value="1">Odd</asp:ListItem>
				<asp:ListItem Value="2">Mark</asp:ListItem>
				<asp:ListItem Value="3">None</asp:ListItem>
				<asp:ListItem Value="4">Space</asp:ListItem>
			</asp:DropDownList></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 88px; HEIGHT: 1px" width="88">
			<asp:Label id="Label7" runat="server">Stop Bits</asp:Label></TD>
		<TD style="HEIGHT: 1px">
			<asp:DropDownList id="ddlStopBits" runat="server">
				<asp:ListItem Value="1">1</asp:ListItem>
				<asp:ListItem Value="1.5">1.5</asp:ListItem>
				<asp:ListItem Value="2">2</asp:ListItem>
			</asp:DropDownList></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 88px">
			<asp:Label id="Label4" runat="server">Flow Control</asp:Label></TD>
		<TD>
			<asp:DropDownList id="ddlFlowControl" runat="server">
				<asp:ListItem Value="0">None</asp:ListItem>
				<asp:ListItem Value="1">Hardware</asp:ListItem>
				<asp:ListItem Value="2">Xon/Xoff</asp:ListItem>
			</asp:DropDownList></TD>
	</TR>
</TABLE>
