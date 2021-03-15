<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Exception_By_PHouse.aspx.vb" Inherits="OPS_Exception_By_PHouse" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Exception For Process Schedule</td>
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
                    </ContentTemplate>
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
                            <asp:ListItem>Dyeing</asp:ListItem>
                            <asp:ListItem>Finish</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 127px">
                &nbsp;
            </td>
            <td>
                &nbsp;
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
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="3">
              <div id="AdjResultsDiv" class="container" style="width: 100%; height: 350px;">
                <asp:Panel ID="Panel1" runat="server" Width="100%" ScrollBars="None" Height="348px">
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
                       <%-- <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        </Triggers>--%>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                Reason</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" class="tableback" colspan="3" style="text-align: center">
                <asp:LinkButton ID="cmdApply" runat="server" BorderStyle="None" 
                    CssClass="buttonc">Apply</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
              
               
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <asp:Panel ID="pnlSaleOrder" runat="server" CssClass="panelbg" Width="200px" Style="display: none;"
                ScrollBars="Vertical">
                <asp:RadioButtonList ID="rblSaleOrder" CssClass="textbox" runat="server" 
                    AutoPostBack="True">
                </asp:RadioButtonList>
            </asp:Panel>
        </ContentTemplate>
       <%-- <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" EventName="SelectedIndexChanged" />
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>
