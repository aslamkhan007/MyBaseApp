<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Standard_Vs_Actual_PlanForProcessing.aspx.vb" Inherits="OPS_Standard_Vs_Actual_PlanForProcessing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Label2" runat="server" Text="Planned&nbsp; Vs Actual Schedule "></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                Date From
            </td>
            <td class="NormalText" style="width: 152px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" TargetControlID="txtDateFrom">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txtDateFrom"
                            Display="Dynamic" InvalidValueMessage="Invalid" IsValidEmpty="False" EmptyValueMessage="*"
                            TooltipMessage="MM/DD/YYYY" Width="114px">
                        </cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MEE6" runat="server" Mask="99/99/9999" MaskType="Date"
                            TargetControlID="txtDateFrom">
                        </cc1:MaskedEditExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ChkIgnoreDates" 
                            EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 127px">
                Date To
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" TargetControlID="txtDateTo">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MEE6"
                            ControlToValidate="txtDateTo" Display="Dynamic" InvalidValueMessage="Invalid"
                            IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px">
                        </cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txtDateTo">
                        </cc1:MaskedEditExtender>
                        <asp:CheckBox ID="ChkIgnoreDates" runat="server" Checked="True" TextAlign="Left"
                            AutoPostBack="True" Text="Include Dates" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ChkIgnoreDates" 
                            EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                Sales Team
            </td>
            <td class="NormalText" style="width: 152px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesTeam" runat="server" AutoPostBack="True" CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 127px">
                Sales Person
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                Customer
            </td>
            <td class="NormalText" style="width: 152px">
                <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" CssClass="textbox"
                    Width="200px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="OPS_Customer"
                    CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                    TargetControlID="txtCustomer">
                </cc1:AutoCompleteExtender>
                <div id="divwidth" style="display: none;">
                </div>
            </td>
            <td class="NormalText" style="width: 127px">
                Order No
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox" EnableViewState="False"></asp:TextBox>
                        <%--<cc1:PopupControlExtender ID="PopupControlExtender2" runat="server" PopupControlID="pnlSaleOrder"
                            TargetControlID="txtOrderNo" Position="Bottom">
                        </cc1:PopupControlExtender>--%>
                        <cc1:AutoCompleteExtender ID="ACE4" runat="server" CompletionInterval="100" CompletionListCssClass="autocomplete_ListItem"
                            CompletionSetCount="100" ContextKey="" FirstRowSelected="True" MinimumPrefixLength="4"
                            ServiceMethod="GetOrders" ServicePath="~/WebService.asmx" TargetControlID="txtOrderNo">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                    <Triggers>
                        <%--   <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="rblSaleOrder" EventName="SelectedIndexChanged" />--%>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                <asp:Label ID="Label1" runat="server" Text="Process"></asp:Label>
            </td>
            <td class="NormalText" style="width: 152px">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlProcess" runat="server" CssClass="combobox">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Dyeing</asp:ListItem>
                            <asp:ListItem>Finish</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="ddlProcess" Display="Dynamic" ErrorMessage="*" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 127px">
                Plant</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="ddlPlant" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                &nbsp;</td>
            <td class="NormalText" style="width: 152px">
                &nbsp;</td>
            <td class="NormalText" style="width: 127px">
                &nbsp;</td>
            <td>
                <asp:LinkButton ID="CmdXl" runat="server" CssClass="buttonXL" Width="64px"></asp:LinkButton>
            </td>
        </tr>
        </table>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" align="center">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="ImageProg" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td colspan="3">
                <asp:Panel ID="Panel1" runat="server" Height="400px" Width="100%" ScrollBars="None">
                 <div  id = "AdjResultsDiv" style=" width: 100%; height:398px;"> 
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" Width="100%" 
                                EnableModelValidation="True">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <SelectedRowStyle CssClass="GridRowGreen" />
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="GridRowBlue" colspan="3">
                Order Processing Info
                <asp:Image ID="ImgUnFreezed" runat="server" ImageUrl="~/Image/plus.png" Style="margin-right: 5px;" />
                                <cc1:CollapsiblePanelExtender ID="cpe" runat="Server" AutoCollapse="False" AutoExpand="True"
                                    CollapseControlID="ImgUnFreezed" Collapsed="True" CollapsedImage="~/Image/plus.png"
                                    CollapsedSize="0" ExpandControlID="ImgUnFreezed" ExpandDirection="Vertical" ExpandedImage="~/Image/minus.png"
                                    ImageControlID="ImgUnFreezed" ScrollContents="false" TargetControlID="pnlOrderProcessingInfo" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnlOrderProcessingInfo" runat="server" 
                    ScrollBars="None" Width="100%">
                    <table style="width:100%;" class="tableback">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel17" runat="server" RenderMode="block">
                                    <ContentTemplate>
                                        <asp:DataList ID="DataList1" runat="server" CellPadding="0" 
                                            RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <ItemTemplate>
                                                <table style="width:100%;" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="HoverMenu">
                                                            &nbsp; SalePerson</td>
                                                        <td class="HeaderStyle" colspan="3">
                                                            <asp:Label ID="lblSalePerson" runat="server" ForeColor="White" 
                                                                Text='<%# Eval("SaleP") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="HoverMenu">
                                                            &nbsp; Customer</td>
                                                        <td class="HeaderStyle" colspan="3">
                                                            <asp:Label ID="Customer" runat="server" ForeColor="White" 
                                                                Text='<%# Eval("Cust_name") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="HoverMenu">
                                                            &nbsp; Address</td>
                                                        <td class="HeaderStyle" colspan="3">
                                                            <asp:Label ID="lblAddress1" runat="server" ForeColor="White" 
                                                        Text='<%# Eval("address_1") + " " + Eval("address_2")  + " " +Eval("Address_3") + " " +Eval("city") + " " +Eval("Country") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="HoverMenu">
                                                            &nbsp;Greigh&nbsp; Availbility</td>
                                                        <td class="HeaderStyle">
                                                            <asp:Label ID="Label8" runat="server" ForeColor="White" 
                                                                Text='<%# Eval("Grey_avail") %>'></asp:Label>
                                                        </td>
                                                        <td class="HoverMenu">
                                                            &nbsp; Finish</td>
                                                        <td class="HeaderStyle">
                                                            <asp:Label ID="Label9" runat="server" ForeColor="White" 
                                                                Text='<%# Eval("Finish") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="HoverMenu">
                                                            &nbsp; Inspection&nbsp;&nbsp;&nbsp; Std.</td>
                                                        <td class="HeaderStyle">
                                                            <asp:Label ID="Label10" runat="server" ForeColor="White" 
                                                                Text='<%# Eval("Inspec_Status") %>'></asp:Label>
                                                        </td>
                                                        <td class="HoverMenu">
                                                            Packing</td>
                                                        <td class="HeaderStyle">
                                                            <asp:Label ID="Label11" runat="server" ForeColor="White" 
                                                                Text='<%# Eval("Packing") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                 &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="textcells_s" colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
                                    <ContentTemplate>
                                        <asp:GridView ID="GrdOrderinfo" runat="server" Height="120px" Width="91%">
                                            <HeaderStyle CssClass="GridHeader" />
                                            <RowStyle CssClass="GridItem" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                     <%--   <tr>
                            <td colspan="4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>--%>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="textcells_s">
               
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <asp:Panel ID="pnlSaleOrder" runat="server" CssClass="panelbg" Width="200px" Style="display: none;"
                ScrollBars="Vertical">
                <asp:RadioButtonList ID="rblSaleOrder" CssClass="textbox" runat="server" OnSelectedIndexChanged="rblSaleOrder_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:RadioButtonList>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
