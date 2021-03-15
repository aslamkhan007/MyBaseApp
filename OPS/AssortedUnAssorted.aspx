<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="AssortedUnAssorted.aspx.vb" Inherits="AssortedUnAssorted" %>

<%@ Register Assembly="Telerik.Web.UI, Version=2013.1.417.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4"
    Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadButton1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadDispatch" LoadingPanelID="gridLoadingPanel">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadDispatch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadDispatch" LoadingPanelID="gridLoadingPanel">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel runat="server" Skin="Telerik" ID="gridLoadingPanel">
    </telerik:RadAjaxLoadingPanel>
    <%-- <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"> --%>
    <table style="width: 900px;">
        <tr>
            <td style="height: 31px" colspan="6">
                &nbsp; Assorted / UnAssorted<br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 68px">
                Date From
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpFrom" runat="server" Culture="en-US" FocusedDate="2010-01-01"
                    Font-Names="Tahoma" MaxDate="2020-12-31" MinDate="2010-01-01">
                    <Calendar EnableKeyboardNavigation="True" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                </telerik:RadDatePicker>
            </td>
            <td>
                Date To
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpTo" runat="server" Culture="en-US" FocusedDate="2010-01-01"
                    Font-Names="Tahoma" MaxDate="2020-12-31" MinDate="2010-01-01">
                    <Calendar EnableKeyboardNavigation="True" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                </telerik:RadDatePicker>
                <telerik:RadButton ID="RadButton1" runat="server" Skin="Black" Text="Fetch">
                </telerik:RadButton>
            </td>
            <td class="BoundColumn_Date" style="width: 49px">
                &nbsp;</td>
            <td>
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <%--  </telerik:RadAjaxPanel> --%>
    <table style="width: 100%;">
        <tr>
            <td>
                <telerik:RadGrid ID="RadDispatch" runat="server" AllowFilteringByColumn="True" AllowPaging="True"
                    AllowSorting="True" CellSpacing="0" Font-Names="Arial" PageSize="5000"
                    Font-Size="Smaller" OnNeedDataSource="CallToBind" ActiveItemStyle-HorizontalAlign="Left"
                    ExportSettings-ExportOnlyData="True" Width="1024px" 
                    DefaultLoadingPanelID="RadAjaxLoadingPanel1" Skin="Transparent">
                    <ClientSettings>
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    </ClientSettings>
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    </MasterTableView>
                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td>
                <telerik:RadButton ID="RadButton2" runat="server" Skin="Black" Text="Excel">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
</asp:Content>
