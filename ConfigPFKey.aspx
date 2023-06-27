<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Page language="c#" Codebehind="ConfigPFKey.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.ConfigPFKey" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConfigPFKey</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE --><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
			<!-- END PAGE HEADER MODULE -->
			<table cellSpacing="0" cellPadding="0" width="10%" border="0">
				<tr>
					<td class="navtable" vAlign="top" width="1%">
						<table cellSpacing="10" cellPadding="0" width="100%" border="0">
							<!-- BEGIN DYNAMIC LEFT MODULE LIST -->
							<tr>
								<td style="PADDING-TOP: 5px" align="left"><MODULE:SUPPORT id="Support1" runat="server"></MODULE:SUPPORT></td>
							</tr>
							<!-- END DYNAMIC LEFT MODULE LIST --></table>
					</td>
				</tr>
			</table>
			<asp:Label id="CategoryDesciptionLabel" style="Z-INDEX: 144; LEFT: 208px; POSITION: absolute; TOP: 56px"
				runat="server" ForeColor="White" BackColor="Navy" Font-Bold="True"></asp:Label>
			<asp:button id="ButtonCancel" style="Z-INDEX: 133; LEFT: 824px; POSITION: absolute; TOP: 448px"
				runat="server" Text="Cancel" Width="72px" Height="32px" onclick="ButtonCancel_Click"></asp:button>

<asp:button id="ButtonPF1" style="Z-INDEX: 100; LEFT: 208px; POSITION: absolute; TOP: 160px" runat="server" Text="PF 01" onclick="ButtonPF1_Click"></asp:button>
<asp:button id="ButtonPF2" style="Z-INDEX: 100; LEFT: 264px; POSITION: absolute; TOP: 160px" runat="server" Text="PF 02" onclick="ButtonPF2_Click"></asp:button>
<asp:button id="ButtonPF3" style="Z-INDEX: 100; LEFT: 320px; POSITION: absolute; TOP: 160px" runat="server" Text="PF 03" onclick="ButtonPF3_Click"></asp:button>
<asp:button id="ButtonPF4" style="Z-INDEX: 100; LEFT: 376px; POSITION: absolute; TOP: 160px" runat="server" Text="PF 04" onclick="ButtonPF4_Click"></asp:button>
<asp:button id="ButtonPF5" style="Z-INDEX: 100; LEFT: 456px; POSITION: absolute; TOP: 160px" runat="server" Text="PF 05" onclick="ButtonPF5_Click"></asp:button>
<asp:button id="ButtonPF6" style="Z-INDEX: 100; LEFT: 512px; POSITION: absolute; TOP: 160px" runat="server" Text="PF 06" onclick="ButtonPF6_Click"></asp:button>
<asp:button id="ButtonPF7" style="Z-INDEX: 100; LEFT: 568px; POSITION: absolute; TOP: 160px" runat="server" Text="PF 07" onclick="ButtonPF7_Click"></asp:button>
<asp:button id="ButtonPF8" style="Z-INDEX: 100; LEFT: 624px; POSITION: absolute; TOP: 160px" runat="server" Text="PF 08" onclick="ButtonPF8_Click"></asp:button>
<asp:button id="ButtonPF9" style="Z-INDEX: 100; LEFT: 712px; POSITION: absolute; TOP: 160px" runat="server" Text="PF 09" onclick="ButtonPF9_Click"></asp:button>
<asp:button id="ButtonPF10" style="Z-INDEX: 100; LEFT: 768px; POSITION: absolute; TOP: 160px" runat="server" Text="PF 10" onclick="ButtonPF10_Click"></asp:button>
<asp:button id="ButtonPF11" style="Z-INDEX: 100; LEFT: 824px; POSITION: absolute; TOP: 160px" runat="server" Text="PF 11" onclick="ButtonPF11_Click"></asp:button>
<asp:button id="ButtonPF12" style="Z-INDEX: 100; LEFT: 880px; POSITION: absolute; TOP: 160px" runat="server" Text="PF 12" onclick="ButtonPF12_Click"></asp:button>
<asp:button id="ButtonPF13" style="Z-INDEX: 100; LEFT: 208px; POSITION: absolute; TOP: 200px" runat="server" Text="PF 13" onclick="ButtonPF13_Click"></asp:button>
<asp:button id="ButtonPF14" style="Z-INDEX: 100; LEFT: 264px; POSITION: absolute; TOP: 200px" runat="server" Text="PF 14" onclick="ButtonPF14_Click"></asp:button>
<asp:button id="ButtonPF15" style="Z-INDEX: 100; LEFT: 320px; POSITION: absolute; TOP: 200px" runat="server" Text="PF 15" onclick="ButtonPF15_Click"></asp:button>
<asp:button id="ButtonPF16" style="Z-INDEX: 100; LEFT: 376px; POSITION: absolute; TOP: 200px" runat="server" Text="PF 16" onclick="ButtonPF16_Click"></asp:button>
<asp:button id="ButtonPF17" style="Z-INDEX: 100; LEFT: 456px; POSITION: absolute; TOP: 200px" runat="server" Text="PF 17" onclick="ButtonPF17_Click"></asp:button>
<asp:button id="ButtonPF18" style="Z-INDEX: 100; LEFT: 512px; POSITION: absolute; TOP: 200px" runat="server" Text="PF 18" onclick="ButtonPF18_Click"></asp:button>
<asp:button id="ButtonPF19" style="Z-INDEX: 100; LEFT: 568px; POSITION: absolute; TOP: 200px" runat="server" Text="PF 19" onclick="ButtonPF19_Click"></asp:button>
<asp:button id="ButtonPF20" style="Z-INDEX: 100; LEFT: 624px; POSITION: absolute; TOP: 200px" runat="server" Text="PF 20" onclick="ButtonPF20_Click"></asp:button>
<asp:button id="ButtonPF21" style="Z-INDEX: 100; LEFT: 712px; POSITION: absolute; TOP: 200px" runat="server" Text="PF 21" onclick="ButtonPF21_Click"></asp:button>
<asp:button id="ButtonPF22" style="Z-INDEX: 100; LEFT: 768px; POSITION: absolute; TOP: 200px" runat="server" Text="PF 22" onclick="ButtonPF22_Click"></asp:button>
<asp:button id="ButtonPF23" style="Z-INDEX: 100; LEFT: 824px; POSITION: absolute; TOP: 200px" runat="server" Text="PF 23" onclick="ButtonPF23_Click"></asp:button>
<asp:button id="ButtonPF24" style="Z-INDEX: 100; LEFT: 880px; POSITION: absolute; TOP: 200px" runat="server" Text="PF 24" onclick="ButtonPF24_Click"></asp:button>

            <asp:dropdownlist id="DropDownListPF" style="Z-INDEX: 124; LEFT: 216px; POSITION: absolute; TOP: 280px"
				runat="server" Width="56px" AutoPostBack="True" onselectedindexchanged="DropDownListPF_SelectedIndexChanged">
				<asp:ListItem Value="1">1</asp:ListItem>
				<asp:ListItem Value="2">2</asp:ListItem>
				<asp:ListItem Value="3">3</asp:ListItem>
				<asp:ListItem Value="4">4</asp:ListItem>
				<asp:ListItem Value="5">5</asp:ListItem>
				<asp:ListItem Value="6">6</asp:ListItem>
				<asp:ListItem Value="7">7</asp:ListItem>
				<asp:ListItem Value="8">8</asp:ListItem>
				<asp:ListItem Value="9">9</asp:ListItem>
				<asp:ListItem Value="10">10</asp:ListItem>
				<asp:ListItem Value="11">11</asp:ListItem>
				<asp:ListItem Value="12">12</asp:ListItem>
				<asp:ListItem Value="13">13</asp:ListItem>
				<asp:ListItem Value="14">14</asp:ListItem>
				<asp:ListItem Value="15">15</asp:ListItem>
				<asp:ListItem Value="16">16</asp:ListItem>
				<asp:ListItem Value="17">17</asp:ListItem>
				<asp:ListItem Value="18">18</asp:ListItem>
				<asp:ListItem Value="19">19</asp:ListItem>
				<asp:ListItem Value="20">20</asp:ListItem>
				<asp:ListItem Value="21">21</asp:ListItem>
				<asp:ListItem Value="22">22</asp:ListItem>
				<asp:ListItem Value="23">23</asp:ListItem>
				<asp:ListItem Value="24">24</asp:ListItem>
			</asp:dropdownlist>
            <asp:label id="Label1" style="Z-INDEX: 125; LEFT: 216px; POSITION: absolute; TOP: 256px" runat="server">PF Key</asp:label>
            <asp:textbox id="TextBoxLabel" style="Z-INDEX: 126; LEFT: 304px; POSITION: absolute; TOP: 280px"
				runat="server" Width="72px"></asp:textbox>
            <asp:label id="Label2" style="Z-INDEX: 127; LEFT: 304px; POSITION: absolute; TOP: 256px" runat="server">Label</asp:label>
            <asp:textbox id="TextBoxDescription" style="Z-INDEX: 128; LEFT: 408px; POSITION: absolute; TOP: 280px"
				runat="server" Width="526px" Height="24px"></asp:textbox>
            <asp:label id="Label3" style="Z-INDEX: 129; LEFT: 408px; POSITION: absolute; TOP: 256px" runat="server">Description</asp:label>
            <asp:label id="Label4" style="Z-INDEX: 130; LEFT: 216px; POSITION: absolute; TOP: 320px" runat="server">Command (input modification here)</asp:label>
            <asp:textbox id="TextBoxCommand" style="Z-INDEX: 131; LEFT: 216px; POSITION: absolute; TOP: 344px"
				runat="server" Width="719px" Height="24px" MaxLength="1000"></asp:textbox>
            <asp:button id="ButtonUpdate" style="Z-INDEX: 132; LEFT: 696px; POSITION: absolute; TOP: 448px"
				runat="server" Text="Update" Width="72px" Height="32px" onclick="ButtonUpdate_Click"></asp:button>
			<HR style="Z-INDEX: 135; LEFT: 224px; WIDTH: 75.98%; POSITION: absolute; TOP: 240px; HEIGHT: 1px"
				width="75.98%" SIZE="1">
			<asp:dropdownlist id="DropDownListUser" style="Z-INDEX: 136; LEFT: 296px; POSITION: absolute; TOP: 88px; WIDTH: 264px;"
				runat="server" AutoPostBack="True" onselectedindexchanged="DropDownListUser_SelectedIndexChanged"></asp:dropdownlist>
            <asp:label id="Label5" style="Z-INDEX: 137; LEFT: 208px; POSITION: absolute; TOP: 91px;" runat="server">Select User</asp:label>
            <asp:label id="Label6" style="Z-INDEX: 138; LEFT: 568px; POSITION: absolute; TOP: 91px;" runat="server">Enter User</asp:label>
            <asp:textbox id="TextBoxUser" style="Z-INDEX: 139; LEFT: 646px; POSITION: absolute; TOP: 86px"
				runat="server" Width="160px" ontextchanged="TextBoxUser_TextChanged"></asp:textbox>
            <asp:button id="ButtonGetPFKeys" style="Z-INDEX: 140; LEFT: 816px; POSITION: absolute; TOP: 86px"
				runat="server" Text="Get PF Keys" onclick="ButtonGetPFKeys_Click"></asp:button>
            <asp:label id="LabelUserError" style="Z-INDEX: 141; LEFT: 400px; POSITION: absolute; TOP: 120px"
				runat="server" Visible="False" ForeColor="Red">Invalid User; reenter or choose from the list</asp:label>
			<asp:TextBox id="TextBoxNewCmd" style="Z-INDEX: 142; LEFT: 216px; POSITION: absolute; TOP: 408px"
				runat="server" Width="719px" Height="24px" MaxLength="1000" ReadOnly="True" BackColor="#E0E0E0"></asp:TextBox>
			<asp:Label id="Label7" style="Z-INDEX: 143; LEFT: 216px; POSITION: absolute; TOP: 384px" runat="server">Native Command</asp:Label></FORM>
	</body>
</HTML>
