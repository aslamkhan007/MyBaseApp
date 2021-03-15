<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="Sale_Order_Detail.aspx.cs" Inherits="OPS_Sale_Order_Detail" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Sale Order Detail</td>
        </tr>
        <tr>
            <td class="labelcells">
                Start Date
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpStartDate" runat="server" Skin="WebBlue">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="WebBlue" runat="server">
                    </Calendar>
                    <DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td class="labelcells">
                End Date</td>
            <td>
                <telerik:RadDatePicker ID="rdpEndDate" runat="server" Skin="WebBlue">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="WebBlue" runat="server">
                    </Calendar>
                    <DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Sale Person
            </td>
            <td>
                <telerik:RadComboBox ID="ddlSalePerson" runat="server" Skin="Default">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="All" 
                            Value="All" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="cmdFetch" runat="server" CssClass="buttonc" OnClick="cmdFetch_Click">Fetch</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="cmdExcel" runat="server" CssClass="buttonc" 
                    OnClick="lnkExcel_Click">Excel</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="labelcells">
                &nbsp;<asp:Label ID="lblTotalOrders" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" CellSpacing="0"
                    GridLines="None" Width="900px">
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
</asp:Content>
