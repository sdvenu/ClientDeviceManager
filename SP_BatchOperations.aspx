<%@ Page Language="C#" CodeBehind="SP_BatchOperations.aspx.cs" Inherits="ClientDeviceMgr.SP_BatchOperations" AutoEventWireup="true" EnableEventValidation="false" %>
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
		<script src="ClientDeviceMgr.js"></script>
	</HEAD>
	<body>
		<form id="BatchOperationsMgmt" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE --><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
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
			<!-- END PAGE HEADER MODULE -->
		    <asp:Panel ID="pnlMain" runat="server"
                style="Z-INDEX: 101; LEFT: 210px; POSITION: absolute; TOP: 48px"
                Width="700px">
                <table style="width:100%">
                    <tr style="width:100%">
                        <td>
                            <span style="color:navy; font-size:larger; font-weight:700">
                                &nbsp;Batch Operations Management
                            </span>
                        </td>
                    </tr>
                    <tr style="width:100%">
                        <td style="width:100%">
                            <table style="width:100%">
                                <tr style="width:100%">
                                    <td style="width:50%">
                                        <asp:Label ID="lblMessage" runat="server" />
                                        <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="True" ForeColor="Red" />
                                    </td>
                                    <td style="text-align:right; width:50%">
                                        <asp:TextBox ID="txtSearch" runat="server"
                                            MaxLength="10"
                                            Width="100px"
                                            ToolTip="Enter the administrator to search for" />
                                        &nbsp;
                                        <asp:Button runat="server"
                                            AccessKey="S"
                                            OnClick="Search"
                                            Text="Search" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table style="width:100%">
                    <tr>
                        <td style="vertical-align:top; width:100%">
                            <table style="width:100%; background-color:#0099FF; color:white; font-weight:700">
                                <tr style="width:100%">
                                    <td style="width:40%">
                                        Administrator
                                    </td>
                                    <td style="width:25%">
                                        Allow Batch Operations?
                                    </td>
                                    <td style="width:35%">
                                        Edit, then Cancel or Update
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView ID="gvAdministrators" runat="server"
                                AllowPaging="True"
                                AutoGenerateColumns="False"
                                CellPadding="2"
                                EmptyDataText="No Administrators have been defined"
                                EnableModelValidation="false"
                                GridLines="None"
                                OnPageIndexChanging="PageIndexChanging"
                                OnRowCancelingEdit="RowCancelingEdit"
                                OnRowEditing="RowEditing"
                                OnRowUpdating="RowUpdating"
                                ShowHeader="false"
                                Width="100%" >
                                <AlternatingRowStyle BackColor="#DDFFFF" />
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <table style="width:100%; color:white">
                                                <tr style="width:100%">
                                                    <td style="width:40%">
                                                        <asp:Label ID="UserID" runat="server"
                                                            Font-Bold="true"
                                                            Text='<%#Eval("UserID")%>' />
                                                    </td>
                                                    <td style="width:25%">
                                                        <asp:CheckBox ID="IsAllowed" runat="server"
                                                            Checked='<%#Bind("IsAllowed")%>'
                                                            Enabled="true" />
                                                    </td>
                                                    <td style="width:35%">
                                                        <asp:ImageButton runat="server"
                                                            CommandName="Cancel"
                                                            ImageUrl="~/images/cancel.png"
                                                            ToolTip="Cancel changing authorization"
                                                            />
                                                        <span style="font-weight:700; padding-right:16px">
                                                            Cancel
                                                        </span>
                                                        <asp:ImageButton runat="server"
                                                            CommandName="Update"
                                                            ImageUrl="~/images/update.png"
                                                            ToolTip="Update authorization" />
                                                        <span style="font-weight:700">
                                                            Update
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <table style="width:100%">
                                                <tr style="width:100%">
                                                    <td style="width:40%">
                                                        <asp:Label runat="server" Text='<%#Eval("UserID")%>' />
                                                    </td>
                                                    <td style="width:25%">
                                                        <asp:CheckBox ID="IsAllowed" runat="server"
                                                            Checked='<%#Eval("IsAllowed")%>'
                                                            Enabled="false" />
                                                    </td>
                                                    <td style="width:35%">
                                                        <asp:ImageButton runat="server"
                                                            CommandName="Edit"
                                                            ImageUrl="~/images/edit.png"
                                                            ToolTip="Edit authorization" />
                                                        Edit
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#00BBFF" />
                                <FooterStyle
                                    BackColor="#0099FF"
                                    Font-Bold="True"
                                    ForeColor="White" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle
                                    BackColor="#0099FF"
                                    CssClass="gridviewpager"
                                    ForeColor="White"
                                    HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#00BBFF" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
		</form>
	</body>
</HTML>
