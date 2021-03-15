<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="Dcs_Payments.aspx.cs" Inherits="OPS_Dcs_Payments" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel">
    </telerik:RadAjaxLoadingPanel>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="DCS Payment"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 120px">
                <asp:Label ID="Label19" runat="server" Text="Date From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 149px">
                <telerik:RadDatePicker ID="radDateFrom" runat="server" Culture="en-US" ShowPopupOnFocus="True"
                    Width="100px">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="64px" Width="100px">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td class="NormalText" style="width: 63px">
                <asp:Label ID="Label20" runat="server" Text="Date To"></asp:Label>
            </td>
            <td class="NormalText">
                <telerik:RadDatePicker ID="radDateTo" runat="server" Culture="en-US" ShowPopupOnFocus="True"
                    Width="100px">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="64px" Width="100px">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 120px">
                <asp:Label ID="lblGroupCode" runat="server" Text="Group Code"></asp:Label>
            </td>
            <td class="NormalText" style="width: 149px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                      <%--  <div ID="divwidth" style="display:none;">
                        </div>--%>

                        <telerik:RadComboBox ID="ddlGroupCode" Runat="server" AutoPostBack="True" 
                            CssClass="combobox" EnableVirtualScrolling="true" ExpandDirection="Down" 
                            Height="85" Visible="true" 
                            onselectedindexchanged="ddlGroupCode_SelectedIndexChanged">
                                                <Items>       
    <telerik:RadComboBoxItem runat="server"></telerik:RadComboBoxItem>     
                 </Items> 
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 63px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <telerik:RadButton ID="radbtnFetch" runat="server" Text="Fetch" OnClick="radbtnFetch_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="radbtnReset" runat="server" Text="Reset" OnClick="radbtnReset_Click">
                        </telerik:RadButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <telerik:RadButton ID="radbtnExcel" runat="server" OnClick="radbtnExcel_Click" Text="Excel">
                </telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">

    <tr>
            <td class="NormalText" colspan="4">

            </td>
        </tr>

        <tr>
            <td class="NormalText" colspan="4">

                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None"                                                                             
                            >
                      
                            <FilterMenu EnableImageSprites="False" EnableSelection="True">

                             </FilterMenu>
                  
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="radgrdCheckDetail" runat="server" CellSpacing="0" GridLines="None"       AllowPaging="True" 
                          OnPageIndexChanged="radgrdCheckDetail_PageIndexChanged" OnItemCreated="radgrdCheckDetail_ItemCreated"
                            OnNeedDataSource="radgrdCheckDetail_NeedDataSource">
                      <%--      <PagerStyle PageSizeControlType="RadComboBox" />--%>
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 120px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 149px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 63px">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
