<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OPS/MasterPage.master"
    CodeFile="AccountDocumentSend.aspx.cs" Inherits="OPS_AccountDocumentSend" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
    </telerik:RadWindowManager>
    <script type="text/javascript">
        function callBackFn(arg) {

        }
        
        
    </script>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="6">
                Document Send
            </td>
        </tr>
        <tr>
            <td style="width: 155px">
                <asp:Label ID="Label1" runat="server" Text="Select"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="radselect" runat="server" AutoPostBack="true" OnSelectedIndexChanged="radselect_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem Value="InvoiceWise" Text="Invoice Wise" Selected="true" />
                        <telerik:RadComboBoxItem Value="DateWise" Text="Invoice Date Wise" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td style="width: 155px">
                <asp:Label ID="Label2" runat="server" Text="Action"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="radaction" runat="server">
                    <Items>
                        <telerik:RadComboBoxItem Value="Sanction by ED, payment will be received" Text="Sanction by ED, payment will be received" />
                        <telerik:RadComboBoxItem Value="Sanction by VP(Mkt), payment will be received" Text="Sanction by VP(Mkt), payment will be received" />
                        <telerik:RadComboBoxItem Value="PDC received" Text="PDC received" />
                        <telerik:RadComboBoxItem Value="Payment received" Text="Payment received" />
                        <telerik:RadComboBoxItem Value="Against LC" Text="Against LC" />
                        <telerik:RadComboBoxItem Value="Other" Text="Other" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Document Send"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="raddocumentsend" runat="server">
                    <Items>
                        <telerik:RadComboBoxItem Value="Direct to Party" Text="Direct to Party" />
                        <telerik:RadComboBoxItem Value="To Agent" Text="To Agent" />
                        <telerik:RadComboBoxItem Value="Sale Office Regional" Text="Sale Office Regional" />
                        <telerik:RadComboBoxItem Value="RO Bangalore" Text="RO Bangalore" />
                        <telerik:RadComboBoxItem Value="RO Mumbai" Text="RO Mumbai" />
                        <telerik:RadComboBoxItem Value="RO Delhi" Text="RO Delhi" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText" style="width: 155px">
                <asp:Label ID="lblInvoiceFrm" runat="server" Text="From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 166px">
                <telerik:RadDatePicker ID="radDtPckrStartFrom" runat="server" Culture="en-US"
                    ShowPopupOnFocus="True" Width="200px">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40px" Width="100px">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
                <telerik:RadTextBox RenderMode="Lightweight" runat="server" ID="radtxtfrominvoice"
                    Width="200px">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 155px">
                <asp:Label ID="lblInvoiceTo" runat="server" Text="To"></asp:Label>
            </td>
            <td class="NormalText">
                <telerik:RadDatePicker ID="radDtEndDate"  runat="server" Culture="en-US"
                    ShowPopupOnFocus="True" Width="200px">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40px" Width="100px">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
                <telerik:RadTextBox RenderMode="Lightweight" runat="server" ID="radtxttoinvoice"
                    Width="200px">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 155px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 166px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 133px">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <telerik:RadButton ID="radbtnFetch" runat="server" Text="Fetch" OnClick="radbtnFetch_Click">
                        </telerik:RadButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
    </table>
    <%--  <table style="width: 100%;">--%>
    <table>
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <telerik:RadGrid ID="RadGrid1" runat="server" AllowMultiRowSelection="true"  
                            AutoGenerateColumns="False" GroupPanelPosition="Top"
                            ResolvedRenderMode="Classic" Skin="Metro" EnableViewState="False" GridLines="None"
                           AllowPaging="true" CellSpacing="0"
                            OnPageIndexChanged="RadGrid1_PageIndexChanged" 
                            onselectedindexchanged="RadGrid1_SelectedIndexChanged" 
                            onneeddatasource="RadGrid1_NeedDataSource" >
                          
                           <ClientSettings EnableRowHoverStyle="true"  EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="true"></Selecting>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="360px" />
                            </ClientSettings>
                          
                            <MasterTableView>
                                <Columns>
                                  
                                   <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn1">
                                    </telerik:GridClientSelectColumn>
                                    <telerik:GridBoundColumn DataField="InvoiceNo" HeaderText="Invoice No">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="line_no" HeaderText="Line No">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="InvoiceDate" HeaderText="Invoice Date">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="GRFIRSTNO" HeaderText="GR No">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="GRFIRSTDATE" HeaderText="GR Date">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ItemGroup" HeaderText="Group">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Qty" HeaderText="Quantity">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Customer" HeaderText="Customer">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="SalePerson" HeaderText="SalePerson">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="OrderNo" HeaderText="OrderNo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ItemNo" HeaderText="ItemNo">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                            <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                        </telerik:RadGrid>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="radbtnFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="RadButtonApply" EventName="Click" />
                     
                    </Triggers>
                </asp:UpdatePanel>
                  
                
            </td>
        </tr>
    </table>
 
 
    <table>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <telerik:RadButton ID="RadButtonApply" runat="server"  Text="Apply"
                            OnClick="RadButtonApply_Click">
                        </telerik:RadButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
