<%@ Page language="c#" Codebehind="DisplayRoute.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.DisplayRoute" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Display ConfigureRoute</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="css/ClientDeviceMgr.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body>
		<form id="RouteConfigForm" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE --><MODULE:HEADER id="MainHeader" runat="server"></MODULE:HEADER>
			<!-- END PAGE HEADER MODULE -->
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="navtable" vAlign="top" width="1%">
						<table cellSpacing="10" cellPadding="0" width="100%" border="0">
							<!-- BEGIN DYNAMIC LEFT MODULE LIST -->
							<tr>
								<td style="PADDING-TOP: 5px" align="left"><MODULE:SUPPORT id="SupportOpts" runat="server"></MODULE:SUPPORT></td>
							</tr>
							<!-- END DYNAMIC LEFT MODULE LIST --></table>
					</td>
					<td vAlign="top" width="99%">
						<table cellSpacing="10" cellPadding="0" width="100%" border="0">
							<!-- BEGIN DYNAMIC RIGHT MODULE LIST -->
							<tr>
								<td style="PADDING-TOP: 5px" align="left">
									<!--BEGIN CATEGORY DETAILS MODULE-->
									<table cellSpacing="0" cellPadding="5" width="100%">
										<tr class="rheader">
											<td class="rheadercol" align="left" height="25">
                                                <asp:label id="CategoryDesciptionLabel" runat="server" enableViewState="false"></asp:label>
											</td>
										</tr>
										<!-- SPACER ROW -->
										<tr class="rbody">
											<td class="rbodycol" align="left" height="25">
                                                Click the route name to display the route information.
											</td>
										</tr>
										<tr class="rbody">
											<td class="rbodycol" height="25">
                                                <asp:datalist id=CategoryList runat="server" enableViewState="false" BorderWidth="0px" BorderStyle="None" RepeatLayout="Table" CellSpacing="0" CellPadding="0" datasource="<%# RouteList %>" onselectedindexchanged="CategoryList_SelectedIndexChanged">
													<ItemTemplate>
														<TABLE width="100%">
															<TR width="100%">
																<TD align="center" width="80" rowSpan="2">
																	<asp:Image id=Image1 runat="server" ImageAlign="Middle" ImageURL='<%# DataBinder.Eval(Container.DataItem, "IMAGE") %>'>
																	</asp:Image></TD>
																<TD width="300">
																	<asp:HyperLink id=BookLink runat="server" ForeColor="#000066" Text='<%# DataBinder.Eval(Container.DataItem, "ROUTENAME") %>' NavigateURL='<%# DataBinder.Eval(Container.DataItem, "Url") %>'>
																	</asp:HyperLink>
                                                                    &nbsp;
                                                                    <asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DEVICETYPE") %>'>
																	</asp:Label><BR>
																</TD>
																<TD>&nbsp;</TD>
															</TR>
															<TR>
																<TD>LNIATA:
																	<asp:Label id=Label2 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LNIATA", "{0:C}") %>'>
																	</asp:Label><BR>
																	Pool:
																	<asp:Label id=Label3 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "POOLNAME") %>'>
																	</asp:Label></TD>
															</TR>
															<TR>
																<TD>&nbsp;
																</TD>
															</TR>
														</TABLE>
													</ItemTemplate>
												</asp:datalist></td>
										</tr>
									</table>
									<!--END CATEGORY DETAILS MODULE--></td>
							</tr>
							<!-- END DYNAMIC RIGHT MODULE LIST --></table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
