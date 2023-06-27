<%@ Page Language="C#" CodeBehind="SP_HostInfoMgmt.aspx.cs" AutoEventWireup="true" Inherits="ClientDeviceMgr.SP_HostInfoMgmt" EnableEventValidation="false" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Manage HOSTINFO files available for all Workstations</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<link href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
		<script src="jquery.js" type="text/javascript"></script>
		<script src="ClientDeviceMgr.js" type="text/javascript"></script>
	</HEAD>
	<body>
		<form id="SP_HostInfoMgmt" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE --><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
			<table border="0" width="10%" cellspacing="0" cellpadding="0">
				<tr>
					<td class="navtable" width="1%" valign="top">
						<table width="100%" border="0" cellspacing="10" cellpadding="0">
							<!-- BEGIN DYNAMIC LEFT MODULE LIST -->
							<tr>
								<td style="PADDING-TOP:5px; width:145px;" align="left">
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
                                &nbsp;HOSTINFO Management
                            </span>
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
                                                                        ToolTip="Selected HOSTINFO template" />
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
                                                                        ToolTip="Select the HOSTINFO template to edit" />
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
                                        <asp:DetailsView ID="dvHostInfo" runat="server"
                                            AutoGenerateRows="False"
                                            BorderStyle="None"
                                            CellPadding="2"
                                            EnableModelValidation="True"
                                            OnItemCreated="OnDetailsCreated"
                                            OnItemDeleting="OnDetailsDeleting"
                                            OnItemInserting="OnDetailsAdding"
                                            OnItemUpdating="OnDetailsUpdating"
                                            OnModeChanging="OnDetailsModeChanging"
                                            EditRowStyle-BackColor="#00BBFF"
                                            RowStyle-BackColor="White"
                                            Width="100%"
                                            Height="32em">
                                            <HeaderTemplate>
                                                <asp:ImageButton runat="server"
                                                    Visible='<%# IsViewing && CurrentHostInfo.IsChangeable %>'
                                                    CommandName="Edit"
                                                    CssClass="center"
                                                    ImageUrl="~/images/edit.png" />
                                                <span runat="server"
                                                    visible='<%# IsViewing && CurrentHostInfo.IsChangeable %>'>
                                                    Edit&nbsp;&nbsp;
                                                </span>
                                                <asp:ImageButton runat="server"
                                                    Visible='<%# IsViewing %>'
                                                    CommandName="New"
                                                    CssClass="center"
                                                    ImageUrl="~/images/insert.png" />
                                                <span runat="server"
                                                    visible='<%# IsViewing %>'>
                                                    New&nbsp;&nbsp;
                                                </span>
                                                <asp:ImageButton runat="server"
                                                    Visible='<%# IsViewing && CurrentHostInfo.IsNameChangeable %>'
                                                    OnClientClick="return confirm('Confirm delete?');"
                                                    CommandName="Delete"
                                                    CssClass="center"
                                                    ImageUrl="~/images/delete.png" />
                                                <span runat="server"
                                                    visible='<%# IsViewing && CurrentHostInfo.IsNameChangeable %>'>
                                                    Delete&nbsp;&nbsp;
                                                </span>
                                                <asp:ImageButton runat="server"
                                                    Visible='<%# !IsViewing %>'
                                                    CommandName="Cancel"
                                                    CssClass="center"
                                                    ImageUrl="~/images/cancel.png" />
                                                <span runat="server"
                                                    visible='<%# !IsViewing %>'>
                                                    Cancel&nbsp;&nbsp;
                                                </span>
                                                <asp:ImageButton runat="server"
                                                    Visible='<%# IsEditing %>'
                                                    CommandName="Update" 
                                                    CssClass="center"
                                                    ImageUrl="~/images/update.png" />
                                                <span runat="server"
                                                    visible='<%# IsEditing %>'>
                                                    Update&nbsp;&nbsp;
                                                </span>
                                                <asp:ImageButton runat="server"
                                                    Visible='<%# IsInserting %>'
                                                    CommandName="Insert"
                                                    CssClass="center"
                                                    ImageUrl="~/images/insert.png" />
                                                <span runat="server"
                                                    visible='<%# IsInserting %>'>
                                                    Add&nbsp;&nbsp;
                                                </span>
                                                <br />
                                            </HeaderTemplate>
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
                                                            Width="78%" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <span class="label word6 selected">
                                                            Rename:
                                                        </span>
                                                        <asp:TextBox ID="txtName" runat="server"
                                                            ReadOnly='<%# !CurrentHostInfo.IsNameChangeable %>'
                                                            Text='<%# Bind("Name") %>'
                                                            MaxLength="32"
                                                            Width="78%" />
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <span class="label word6">
                                                            New:
                                                        </span>
                                                        <asp:TextBox ID="txtName" runat="server"
                                                            Text='<%# Bind("Name") %>'
                                                            MaxLength="32"
                                                            Width="78%" />
                                                    </InsertItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-CssClass="noBorder" ShowHeader="False">
                                                    <ControlStyle BorderStyle="None" />
                                                    <ItemTemplate>
                                                        <span class="label word6">Desc:</span>
                                                        <asp:TextBox ID="txtDescription" runat="server"
                                                            ReadOnly="true"
                                                            Text='<%# Eval("Description") %>'
                                                            Width="78%" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <span class="label word6 selected">&nbsp;&nbsp;as:</span>
                                                        <asp:TextBox ID="txtDescription" runat="server"
                                                            ReadOnly='<%# !CurrentHostInfo.IsDescriptionChangeable %>'
                                                            Text='<%# Bind("Description") %>'
                                                            MaxLength="64"
                                                            Width="78%" />
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <span class="label word6">with:</span>
                                                        <asp:TextBox ID="txtDescription" runat="server"
                                                            Text='<%# Bind("Description") %>'
                                                            MaxLength="64"
                                                            Width="78%" />
                                                    </InsertItemTemplate>
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
                                                    <EditItemTemplate>
                                                        <span class="label selected">with:</span>
                                                        <asp:TextBox ID="txtContents" runat="server"
                                                            ReadOnly='<%# !CurrentHostInfo.IsContentChangeable %>'
                                                            Text='<%# Bind("Contents") %>'
                                                            TextMode="MultiLine"
                                                            Font-Names="Lucida Console,SABRE Serif,Courier New"
                                                            Width="100%" />
                                                    </EditItemTemplate>
                                                    <InsertItemTemplate>
                                                        <span class="label">and:</span>
                                                        <asp:TextBox ID="txtContents" runat="server"
                                                            Text='<%# Bind("Contents") %>'
                                                            TextMode="MultiLine"
                                                            Font-Names="Lucida Console,SABRE Serif,Courier New"
                                                            Width="100%" />
                                                    </InsertItemTemplate>
                                                </asp:TemplateField>
                                            </Fields>
                                        </asp:DetailsView>
                                    </td>
                                </tr>
                                <tr style="width:100%">
                                    <td style="width:50%">
                                        &nbsp;
                                    </td>
                                    <td style="width:100%">
                                        <asp:TextBox ID="txtErrorList" runat="server"
                                            CssClass="errorlist normal"
                                            BorderStyle="None"
                                            TextMode="MultiLine"
                                            ReadOnly="true"
                                            Height="6em"
                                            Width="340px" />
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
