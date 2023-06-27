<%@ Page Language="C#" CodeBehind="AD_BatchOperations.aspx.cs" Inherits="ClientDeviceMgr.AD_BatchOperations"
    AutoEventWireup="true"
    EnableEventValidation="false"
%>
<%@ Register TagPrefix="Module" TagName="Support" Src="Headers/SupportOptions.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="Headers/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Perform operations on multiple Workstations</title>
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
		<form id="AD_BatchOperations" method="post" runat="server">
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
                    <tr>
                        <td>
                            <span style="color:navy; font-size:larger; font-weight:700">
                                Batch Operations
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMessage" runat="server" />
                            <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="True" ForeColor="Red" />
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table style="width:100%">
                    <tr>
                        <td style="border:1px solid black; vertical-align:top; width:47%">
                            &nbsp;Set HOSTINFO.TXT for the listed Workstations.
                            <asp:ImageButton runat="server"
                                OnClientClick="if (!ConfirmBatchOperation()) return false;"
                                OnClick="AssignHostInfo"
                                CssClass="center"
                                ImageUrl="~/images/edit.png"
                                ToolTip="Change each Workstation to use the selected HOSTINFO definition." />
                            <br />
                            &nbsp;
                            <asp:ImageButton runat="server"
                                OnClick="DisplayWorkstationsWithHostInfo"
                                CssClass="center"
                                ImageUrl="~/images/search.png"
                                ToolTip="What HOSTINFO is assigned to each workstation?" />
                            <span title="Workstations ignoring HOSTINFO are found only if Ignore has been explicitly set.">
                                &nbsp;Display Workstations that have the selection.
                            </span>
                            <br />
                            &nbsp;
                            <asp:DropDownList ID="ctlUseHostInfo" runat="server"
                                ToolTip="Select a HOSTINFO definition."
                                Width="75%" />
                            HOSTINFO
                        </td>
                        <td style="border:1px solid black; vertical-align:top; width:53%" rowspan="3">
                            &nbsp;Migrate the DEFAULTHOST of the listed Workstations.
                            <asp:ImageButton runat="server"
                                OnClientClick="if (!ConfirmBatchOperation()) return false;"
                                OnClick="AssignMigrationsWithHostInfo"
                                CssClass="center"
                                ImageUrl="~/images/edit.png"
                                ToolTip="Change the DEFAULTHOST of each Workstation." />
                            <br />
                            &nbsp;
                            <asp:ImageButton runat="server"
                                OnClick="DisplayMigrationTable"
                                CssClass="center"
                                ImageUrl="~/images/search.png"
                                ToolTip="What migrations may occur?" />
                            <span>
                                &nbsp;Display the DEFAULTHOST from/to migration table.
                            </span>
                            <br />
                            &nbsp;
                            <asp:ImageButton runat="server"
                                OnClick="DisplayMigrationsWithHostInfo"
                                CssClass="center"
                                ImageUrl="~/images/search.png"
                                ToolTip="What migrations will occur?" />
                            <span>
                                &nbsp;Display the DEFAULTHOST changes for the Workstations.
                            </span>
                            <br /><br />
                            &nbsp;From:
                            <asp:DropDownList ID="ctlFromHostInfo" runat="server"
                                ToolTip="From DEFAULTHOSTs matching in this list"
                                Width="40%" />
                            &nbsp;To:
                            <asp:DropDownList ID="ctlToHostInfo" runat="server"
                                ToolTip="To DEFAULTHOSTs matching in this list"
                                Width="40%" />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;<asp:CheckBox ID="cbForTerminals" runat="server"
                                Checked="true"
                                ToolTip="Do you want to change the DEFAULTHOST of terminal sessions?"
                                Text="for Terminal Routes?" />
                            &nbsp;<asp:CheckBox ID="cbForPrinters" runat="server"
                                Checked="false"
                                ToolTip="Do you want to change the DEFAULTHOST of printer sessions?"
                                Text="for Printer Routes?" />
                        </td>
                    </tr>
                    <tr>
                        <td style="border:1px solid black; vertical-align:top; width:47%">
                            &nbsp;Set the selected Zone for the listed Workstations.
                            <asp:ImageButton runat="server"
                                OnClientClick="if (!ConfirmBatchOperation()) return false;"
                                OnClick="AssignZone"
                                CssClass="center"
                                ImageUrl="~/images/edit.png"
                                ToolTip="Change each Workstation to use the selected Zone profile." />
                            <br />
                            &nbsp;
                            <asp:ImageButton runat="server"
                                OnClick="DisplayWorkstationsWithZone"
                                CssClass="center"
                                ImageUrl="~/images/search.png"
                                ToolTip="What Zone does each Workstation have?" />
                            &nbsp;Display Workstations that have with the selection.
                            <br />
                            &nbsp;
                            <asp:DropDownList ID="ctlUseZone" runat="server"
                                style="width:75%"
                                ToolTip="Select a Zone profile to assign." />
                            Zone
                        </td>
                    </tr>
                    <tr>
                        <td style="border:1px solid black; vertical-align:top; width:47%">
                            &nbsp;Display assignments for each listed workstation.
                            <asp:ImageButton runat="server"
                                OnClick="DisplayWorkstationsAssignments"
                                CssClass="center"
                                ImageUrl="~/images/search.png"
                                ToolTip="What HOSTINFO and Zone does each Workstation have?" />
                        </td>
                    </tr>
                </table>
                <table style="border:1px solid black; width:100%">
                    <tr>
                        <td>
                            &nbsp;Enter the Workstations to which to Assign a selection
                            or to see a Display matching a selection.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="ctlSlate" runat="server"
                                TextMode="MultiLine"
                                Rows="32"
                                Width="100%"
                                Wrap="false" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
		</form>
	</body>
</HTML>
