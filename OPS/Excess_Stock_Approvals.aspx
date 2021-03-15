<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="Excess_Stock_Approvals.aspx.cs" Inherits="OPS_Excess_Stock_Approvals" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../Image/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../Image/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label16" runat="server" Text="Check Status of Excess Stock Requests"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 147px">
                <asp:Label ID="Label17" runat="server" Text="Date From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 124px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDateFrom"
                    Display="Dynamic" ErrorMessage="**"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 100px">
                <asp:Label ID="Label18" runat="server" Text="Date To"></asp:Label>
            </td>
            <td class="NormalText" colspan="2">
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateTo"
                    Display="Dynamic" ErrorMessage="**"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label22" runat="server" Text="Status"></asp:Label>
            </td>
            <td colspan="3">
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="combobox">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem Value="A">Authorized</asp:ListItem>
                    <asp:ListItem Value="P">Pending</asp:ListItem>
                    <asp:ListItem Value="C">Cancelled</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:LinkButton ID="lnkReset0" runat="server" CssClass="buttonPrint" BorderStyle="None"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 147px">
                <asp:Label ID="Label20" runat="server" Text="Request ID"></asp:Label>
            </td>
            <td class="NormalText" style="width: 124px">
                <asp:TextBox ID="txtSanctionID" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 100px">
                <asp:Label ID="Label23" runat="server" Text="Authorized By"></asp:Label>
            </td>
            <td class="NormalText" colspan="2">
                <asp:DropDownList ID="ddlAuthBy" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 110px">
                <asp:Label ID="Label24" runat="server" Text="Request By"></asp:Label>
            </td>
            <td class="NormalText" style="width: 124px">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtRequestBy" runat="server" CssClass="textbox" AutoPostBack="True"
                            OnTextChanged="txtRequestBy_TextChanged"></asp:TextBox>
                        <div id="div2" style="display: none;">
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" CompletionInterval="10"
                                CompletionListCssClass="AutoExtender" CompletionListElementID="div1" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" MinimumPrefixLength="1"
                                ServiceMethod="GetEmployee_OPS" ServicePath="~/WebService.asmx" TargetControlID="txtRequestBy">
                            </cc1:AutoCompleteExtender>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 100px">
                &nbsp;
            </td>
            <td class="NormalText" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="5">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkSummary" runat="server" CssClass="buttonc" Visible="False"
                            OnClick="lnkSummary_Click">Summary</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" OnClick="lnkReset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" OnClick="lnkExcel_Click">Excel</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlMaster" runat="server">
                            <asp:GridView ID="grdMaster" runat="server" EnableModelValidation="True" Width="100%"
                                OnRowDataBound="grdMaster_RowDataBound" OnSelectedIndexChanged="grdMaster_SelectedIndexChanged"
                                EmptyDataText="No Record Present">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img id="imageSanctionID-<%# Eval("SanctionID") %>" alt="Click to show/hide Description"
                                                border="0" src="../Image/plus.png" />
                                            <div id="SanctionID-<%# Eval("SanctionID") %>" style="display: none; position: relative;
                                                left: 25px;">
                                                <asp:GridView ID="nestedGridView" runat="server" Width="100%" AutoGenerateColumns="False">
                                                    <SelectedRowStyle CssClass="GridRowGreen" />
                                                    <%--   <HeaderStyle CssClass="GridHeader" />--%>
                                                    <RowStyle CssClass="GridItem" />
                                                    <%-- <AlternatingRowStyle CssClass="GridAI" />--%>
                                                    <Columns>
                                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSummary" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:DataList ID="DtlListSummary" runat="server" RepeatColumns="4" Width="100%" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <table class="tableback" style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Total Items"></asp:Label>
                                        </td>
                                        <td class="HoverMenu">
                                            <asp:Label ID="lblTotalItems" runat="server" Text='<%# Eval("TotalItems") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Text="Total Qty."></asp:Label>
                                        </td>
                                        <td class="HoverMenu">
                                            <asp:Label ID="lblTotalQty" runat="server" Text='<%# Eval("TotalMeters") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text="Total Fresh Qty"></asp:Label>
                                        </td>
                                        <td class="HoverMenu">
                                            <asp:Label ID="lblQtrAsFresh" runat="server" Text='<%# Eval("TotalFreshMeters") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="T" runat="server" Text="Total NonFresh Qty"></asp:Label>
                                        </td>
                                        <td class="HoverMenu">
                                            <asp:Label ID="lblQtyAsNonFresh" runat="server" Text='<%# Eval("TotalNonFreshMtrs") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text="Total No of Bales"></asp:Label>
                                        </td>
                                        <td class="HoverMenu">
                                            <asp:Label ID="lblTotalNoOfBales" runat="server" Text='<%# Eval("BaleCount") %>'></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:Panel ID="Panel5" runat="server" Height="200px" ScrollBars="Both" Width="100%">
                            <asp:GridView ID="grdRequestDetail" runat="server" AutoGenerateColumns="true" EnableModelValidation="True"
                                Width="100%" ShowFooter="False">
                                <SelectedRowStyle CssClass="GridRowGreen" />
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <%-- <RowStyle CssClass="GridItem" />--%>
                                <%--  <AlternatingRowStyle CssClass="GridAI" />--%>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="GridItem">
                <asp:Label ID="Label25" runat="server" Font-Size="Medium" Text="Head To Head Rate Comparision"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:Panel ID="Panel6" runat="server" Height="200px" ScrollBars="Both" Width="100%">
                            <asp:GridView ID="grdComparision" runat="server" AutoGenerateColumns="true" EnableModelValidation="True"
                                Width="100%" ShowFooter="False">
                                <SelectedRowStyle CssClass="GridRowGreen" />
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <%-- <RowStyle CssClass="GridItem" />--%>
                                <%--  <AlternatingRowStyle CssClass="GridAI" />--%>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
