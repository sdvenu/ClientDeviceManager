<%@ OutputCache Duration="1" VaryByParam="none" %>
<%@ Control Language="c#" Codebehind="SupportOptions.ascx.cs" Inherits="ClientDeviceMgr.SupportOptions"
    AutoEventWireup="True"
    TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Import Namespace="ClientDeviceMgr"%>
<!-- Navigation Menu -->
<table style="width:180px; padding:0" class="navtext">
	<tr>
		<td style="text-align:center">
			Your Operations
		</td>
	</tr>
	<tr>
		<td style="text-align:left">
			<asp:Image id="LineImage" runat="server"
                EnableViewState="false"
                ImageUrl="~/images/line.gif" />
		</td>
	</tr>
	<tr>
		<td>
			<asp:DataList id="CategoriesList" runat="server"
                DataSource="<%# SubCategoryList %>"
                EnableViewState="false"
                CellPadding="0"
                CellSpacing="0"
                RepeatLayout="Table">
				<ItemTemplate>
					<asp:HyperLink id="ItemLink" runat="server" CssClass="navlink"
                        EnableViewState="false"
                        NavigateURL='<%# DataBinder.Eval(Container.DataItem, "Url") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'>
					</asp:HyperLink>
				</ItemTemplate>
			</asp:DataList>
		</td>
	</tr>
</table>
