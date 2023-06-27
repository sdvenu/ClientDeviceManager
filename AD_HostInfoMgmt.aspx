<%@ Page Language="C#" CodeBehind="AD_HostInfoMgmt.aspx.cs" AutoEventWireup="true" Inherits="ClientDeviceMgr.AD_HostInfoMgmt" EnableEventValidation="false" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Assign a HOSTINFO file for the Workstation</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
		<script src="jquery.js" type="text/javascript"></script>
        <script src="ClientDeviceMgrJQuery.js" type="text/javascript"></script>
		<script src="ClientDeviceMgr.js" type="text/javascript"></script>
	</HEAD>
	<body>
		<form id="AD_HostInfoMgmt" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE --><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
			<table border="0" width="10%" cellspacing="0" cellpadding="0">
				<tr>
					<td class="navtable" width="1%" valign="top">
						<table width="100%" border="0" cellspacing="10" cellpadding="0">
							<!-- BEGIN DYNAMIC LEFT MODULE LIST -->
							<tr>
								<td style="PADDING-TOP:5px; width:140px;" align="left">
									<Module:Support id="SupportOpts" runat="server"></Module:Support>
								</td>
							</tr>
							<!-- END DYNAMIC LEFT MODULE LIST -->
						</table>
					</td>
				</tr>
			</table>
			<!-- END PAGE HEADER MODULE -->
		    <asp:Panel ID="pnlMain" runat="server"
                style="Z-INDEX: 101; LEFT: 210px; POSITION: absolute; TOP: 48px"
                Width="830px">
                <table style="width:100%">
                    <tr style="width:100%">
                        <td>
                            <span style="color:navy; font-size:larger; font-weight:700">
                                HOSTINFO Assignment
                            </span>
                        </td>
                    </tr>
                    <tr style="width:100%">
                        <td>
                            <asp:Label ID="lblWSName" runat="server"
                                Font-Bold="true" Font-Size="Medium" />
                            has the
                            <asp:Label ID="lblHostInfoName" runat="server"
                                Font-Bold="true" Font-Size="Medium" />
                            HOSTINFO currently assigned.
                        </td>
                    </tr>
                    <tr style="width:100%">
                        <td style="width:100%">
                            <table style="width:100%">
                                <tr style="width:100%">
                                    <td style="width:99%">
                                        <asp:Label ID="lblMessage" runat="server" />
                                        <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="True" ForeColor="Red" />
                                        &nbsp;
                                    </td>
                                    <td style="text-align:right; width:1%">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="width:100%">
                        <td style="width:100%">
                            <table style="width:100%">
                                <tr style="width:100%">
                                    <td style="border:1px solid black; vertical-align:top; width:40%">
                                        <asp:GridView ID="gvHostInfoNames" runat="server"
                                            AllowPaging="True"
                                            AutoGenerateColumns="False"
                                            CellPadding="2"
                                            EmptyDataText="No HOSTINFO definitions exist."
                                            EnableModelValidation="false"
                                            GridLines="None"
                                            OnPageIndexChanging="OnPageOfNamesChanging"
                                            OnRowDataBound="OnRowDataBound"
                                            OnSelectedIndexChanging="OnSelectedNameIndexChanging"
                                            OnSelectedIndexChanged="OnSelectedNameIndexChanged"
                                            PageSize="100"
                                            ShowHeader="false"
                                            Width="100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <EditItemTemplate>
                                                        <table style="width:100%; color:white">
                                                            <tr style="width:100%">
                                                                <td style="width:5%">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width:95%">
                                                                    <asp:Label runat="server"
                                                                        Font-Bold="true"
                                                                        Text='<%# Container.DataItem %>'
                                                                        ToolTip="Selected HOSTINFO" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <table style="width:100%">
                                                            <tr style="width:100%">
                                                                <td style="width:5%">
                                                                    <asp:LinkButton ID="Select" runat="server"
                                                                        CommandName="Select"
                                                                        Text="">
                                                                        <asp:Image runat="server"
                                                                            ImageUrl="~/images/item.png"
                                                                            Height="16px" />
                                                                    </asp:LinkButton>
                                                                </td>
                                                                <td style="width:95%">
                                                                    <asp:Label runat="server"
                                                                        Text='<%# Container.DataItem %>'
                                                                        ToolTip="Select the HOSTINFO definition to assign" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle
                                                BackColor="#0099FF"
                                                Font-Bold="True"
                                                ForeColor="White" />
                                            <PagerSettings Mode="NextPreviousFirstLast" />
                                            <PagerStyle
                                                BackColor="#0099FF"
                                                CssClass="gridviewpager"
                                                ForeColor="White"
                                                HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EFF3FB" />
                                            <SelectedRowStyle BackColor="#00BBFF" />
                                        </asp:GridView>
                                    </td>
                                    <td style="border:1px solid black; vertical-align:top; width:60%">
                                        &nbsp;<asp:ImageButton runat="server"
                                            OnClick="AssignHostInfo"
                                            CssClass="center"
                                            ImageUrl="~/images/insert.png" />
                                        <span runat="server">
                                            &nbsp;Assign this HOSTINFO definition to the Workstation.
                                        </span>
                                        <hr />
                                        <asp:DetailsView ID="dvHostInfo" runat="server"
                                            AutoGenerateRows="False"
                                            BorderStyle="None"
                                            CellPadding="2"
                                            EnableModelValidation="True"
                                            EditRowStyle-BackColor="#00BBFF"
                                            RowStyle-BackColor="White"
                                            Width="100%"
                                            Height="32em">
                                            <Fields>
                                                <asp:TemplateField ItemStyle-CssClass="noBorder" ShowHeader="False">
                                                    <ControlStyle BorderStyle="None" />
                                                    <ItemTemplate>
                                                        <span class="label word6">
                                                            Name:
                                                        </span>
                                                        <asp:TextBox ID="txtName" runat="server"
                                                            ReadOnly="true"
                                                            Text='<%# Eval("Name") %>'
                                                            Width="80%" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-CssClass="noBorder" ShowHeader="False">
                                                    <ControlStyle BorderStyle="None" />
                                                    <ItemTemplate>
                                                        <span class="label word6">Desc:</span>
                                                        <asp:TextBox ID="txtDescription" runat="server"
                                                            ReadOnly="true"
                                                            Text='<%# Eval("Description") %>'
                                                            Width="80%" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-CssClass="noBorder" ShowHeader="False">
                                                    <ControlStyle
                                                        BorderStyle="None"
                                                        Height="32em"
                                                        Width="100%" />
                                                    <ItemTemplate>
                                                        <span class="label">Contents:</span>
                                                        <asp:TextBox ID="txtContents" runat="server"
                                                            ReadOnly="true"
                                                            BackColor="#F8F8F8"
                                                            Text='<%# Eval("Contents") %>'
                                                            TextMode="MultiLine"
                                                            Font-Names="Lucida Console,SABRE Serif,Courier New"
                                                            Width="100%" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Fields>
                                        </asp:DetailsView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
		</form>
	</body>
</HTML>
