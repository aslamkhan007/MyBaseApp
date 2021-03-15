<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="AssortedUnAssortedPivot.aspx.vb" Inherits="AssortedUnAssortedPivot" %>

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
                <telerik:RadPivotGrid ID="RadDispatch" runat="server" AllowPaging="True" AllowSorting="True"
                    PageSize="500" ShowFilterHeaderZone="false" ShowDataHeaderZone="false" ShowRowHeaderZone="false"
                    ShowColumnHeaderZone="false" EnableConfigurationPanel="true" OnNeedDataSource="CallToBind"
                    Width="1024px" Height="600" Skin="Default"  
                    >
                    <Fields>
                        
                    </Fields>
                    <ConfigurationPanelSettings     Position="Left" DefaultDeferedLayoutUpdate="true" />
                    <PagerStyle Mode="Slider" AlwaysVisible="true"></PagerStyle>
                    <ClientSettings>
                        <Scrolling AllowVerticalScroll="True"  />
                    </ClientSettings>
                    <ConfigurationPanelSettings   EnableOlapTreeViewLoadOnDemand="True"></ConfigurationPanelSettings>

                  
                           
                            <DataCellStyle Width="100px" />
                            <ColumnHeaderCellStyle Width="100px" />
                            <RowHeaderCellStyle Width="350px" />


                </telerik:RadPivotGrid>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
