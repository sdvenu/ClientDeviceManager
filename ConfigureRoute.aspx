<%@ Page language="c#" Codebehind="ConfigureRoute.aspx.cs" AutoEventWireup="True" Inherits="ClientDeviceMgr.ConfigureRoute" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConfigureRoute</title>
		<meta HTTP-EQUIV="content-type" CONTENT="text/html; charset=utf-8">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<link REL="Stylesheet" HREF="css/ClientDeviceMgr.css" TYPE="text/css">
	</HEAD>
	<body>
		<form id="RouteConfigForm" method="post" runat="server">
			<!-- BEGIN PAGE HEADER MODULE -->
			<Module:Header id="MainHeader" runat="server"></Module:Header>
			<!-- END PAGE HEADER MODULE -->
			<table border="0" width="100%" cellspacing="0" cellpadding="0">
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
					<td width="99%" valign="top">
						<table border="0" width="100%" cellspacing="10" cellpadding="0">
							<!-- BEGIN DYNAMIC RIGHT MODULE LIST -->
							<tr>
								<td style="PADDING-TOP:5px" align="left">
									<!--BEGIN CATEGORY DETAILS MODULE-->
									<table width="100%" cellpadding="5" cellspacing="0">
										<tr class="rheader">
											<td align="left" height="25" class="rheadercol">
												<asp:Label enableViewState="false" id="CategoryDesciptionLabel" runat="server"></asp:Label>
											</td>
										</tr>
										<!-- SPACER ROW -->
										<tr class="rbody">
											<td align="left" height="25" class="rbodycol">
												Click the route name to edit the route information.
                                                Click [Delete] to delete the route.
											</td>
										</tr>
										<tr class="rbody">
											<td height="25" class="rbodycol">
												<asp:DataList enableViewState="false" id="CategoryList" datasource="<%# RouteList %>" runat="server" CellPadding="0" CellSpacing="0" RepeatLayout="Table" BorderStyle="None" BorderWidth="0px" onselectedindexchanged="CategoryList_SelectedIndexChanged">
													<ItemTemplate>
													</ItemTemplate>
													<ItemTemplate>
														<table width="100%">
															<tr width="100%">
																<td align="center" width="80" rowspan="2">
																	<asp:Image runat="server" ImageURL='<%# DataBinder.Eval(Container.DataItem, "IMAGE") %>' ImageAlign="Middle" ID="Image1">
																	</asp:Image>
																</td>
																<td width="300">
																	<asp:HyperLink id="BookLink" NavigateURL='<%# DataBinder.Eval(Container.DataItem, "Url") %>' Text='<%# DataBinder.Eval(Container.DataItem, "ROUTENAME") %>' ForeColor=#000066 runat="server" />
																	&nbsp;
                                                                    <asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DEVICETYPE") %>' />
																	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																	<asp:HyperLink id="DeleteLink" NavigateURL='<%# DataBinder.Eval(Container.DataItem, "DelUrl") %>' Text='[Delete]' ForeColor=#ff0000 runat="server" />
																</td>
															</tr>
															<tr>
																<td>
																	LNIATA:
																	<asp:Label id=Label2 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LNIATA", "{0:C}") %>' />
																	<br />
																	Pool:
																	<asp:Label id=Label3 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "POOLNAME") %>' />
																</td>
															</tr>
															<tr>
																<td>
																	&nbsp;
																</td>
															</tr>
														</table>
													</ItemTemplate>
												</asp:DataList>
											</td>
										</tr>
									</table>
									<!--END CATEGORY DETAILS MODULE-->
								</td>
							</tr>
							<!-- END DYNAMIC RIGHT MODULE LIST -->
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
