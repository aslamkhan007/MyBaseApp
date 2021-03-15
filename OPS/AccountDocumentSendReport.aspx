<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OPS/MasterPage.master"
    CodeFile="AccountDocumentSendReport.aspx.cs" Inherits="OPS_AccountDocumentSendReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label18" runat="server" Text="Account Document Send Report"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText" style="width: 155px">
                <asp:Label ID="lblInvoiceFrm" runat="server" Text="From"></asp:Label>
            </td>
            <td class="NormalText">
                <telerik:RadDatePicker ID="radDtPckrStartFrom" runat="server" Culture="en-US" ShowPopupOnFocus="True"
                    Width="200px" DateInput-DateFormat="MM/dd/yyyy">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40px" Width="100px">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 155px">
                <asp:Label ID="lblInvoiceTo" runat="server" Text="To"></asp:Label>
            </td>
            <td class="NormalText">
                <telerik:RadDatePicker ID="radDtEndDate" runat="server" Culture="en-US" ShowPopupOnFocus="True"
                    Width="200px" DateInput-DateFormat="MM/dd/yyyy">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40px" Width="100px">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image12" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
               <%-- <telerik:radbutton id="radbtnFetch" runat="server" text="Fetch" onclick="radbtnFetch_Click">
                        </telerik:radbutton>--%>
                
                 <telerik:RadButton ID="RadButton2" runat="server" Text="Fetch" 
                    onclick="RadButton2_Click" >
                </telerik:RadButton>
                       

                <telerik:RadButton ID="RadButton1" runat="server" Text="Export to Excel" OnClick="RadButton1_Click">
                </telerik:RadButton>
               <%-- <asp:LinkButton ID="radbtnFetch" runat="server" CssClass="buttonc" Height="22px"
                    Width="84px" CausesValidation="False">Fetch</asp:LinkButton>--%>

               <%-- <asp:LinkButton ID="RadButton1" runat="server" CssClass="buttonc" Height="22px" Width="84px"
                    CausesValidation="False">Export to Excel</asp:LinkButton>--%>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td class="NormalText">
              <%--  <telerik:RadGrid ID="RadGrid1" runat="server" Width="1024px" AllowFilteringByColumn="false"
                    OnNeedDataSource="RadGrid1_NeedDataSource" PageSize="100" AllowPaging="true"
                    Skin="Office2007" ActiveItemStyle-HorizontalAlign="Left" AllowSorting="True"
                    Font-Size="Small" ExportSettings-ExportOnlyData="True">
                    <ClientSettings>
                        <Resizing AllowColumnResize="true" ShowRowIndicatorColumn="true" />
                    </ClientSettings>
                </telerik:RadGrid>--%>
                 <telerik:RadGrid ID="RadGrid1" runat="server" Width="70%" GroupPanelPosition="Top" 
                            ResolvedRenderMode="Classic" Skin="Windows7" EnableViewState="False" GridLines="None"
                            AllowPaging="true" CellSpacing="0" 
                            OnNeedDataSource="RadGrid1_NeedDataSource" onitemcommand="RadGrid1_ItemCommand">
                            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="360px" />
                            </ClientSettings>
                            <MasterTableView AutoGenerateColumns="true"  CommandItemDisplay="Top">
                                <CommandItemSettings ShowExportToExcelButton="true" ShowAddNewRecordButton="false"
                                    ShowRefreshButton="false"></CommandItemSettings>
                                <%--<Columns>
                                    <telerik:GridBoundColumn DataField="InvoiceNo" HeaderText="InvoiceNo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Line_no" HeaderText="Line_no">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="InvoiceDate" HeaderText="InvoiceDate">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="GrNo" HeaderText="GrNo">
                                    </telerik:GridBoundColumn>
                                </Columns>--%>
                            </MasterTableView>
                            <ExportSettings SuppressColumnDataFormatStrings="false">
                                <Excel Format="Biff"></Excel>
                            </ExportSettings>
                            <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                        </telerik:RadGrid>
                <%--<Triggers>
                        <asp:AsyncPostBackTrigger ControlID="radbtnFetch" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="RadButton1" EventName="Click" />
                    </Triggers>--%>
            </td>
        </tr>
    </table>
</asp:Content>
