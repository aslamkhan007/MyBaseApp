<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OPS/MasterPage.master"
    CodeFile="AccountDocumentsReceived.aspx.cs" Inherits="OPS_AccountDocumentsReceived" %>

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
<%--    <table style="width: 100%;">--%>

    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="7">
                Documents
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
        </tr>
       
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
                        <telerik:RadButton ID="radbtnFetch" runat="server" Text="Fetch">
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
    <table>
       
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <telerik:RadGrid ID="RadGrid1" AllowMultiRowSelection="true" runat="server" AutoGenerateColumns="False"
                            GroupPanelPosition="Top" ResolvedRenderMode="Classic" Skin="Metro" OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged"
                            EnableViewState="False" AllowPaging="True" GridLines="None" 
                            onneeddatasource="RadGrid1_NeedDataSource"  OnPageIndexChanged="RadGrid1_PageIndexChanged" >
                            <ClientSettings EnableRowHoverStyle="true"  EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="true"></Selecting>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="360px" />
                            </ClientSettings>
                            <MasterTableView DataKeyNames="InvoiceNo">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn1">
                                    </telerik:GridClientSelectColumn>
                                    <telerik:GridBoundColumn DataField="InvoiceNo" HeaderText="Invoice No">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Line_no" HeaderText="Line No">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="InvoiceDate" HeaderText="Invoice Date">
                                    </telerik:GridBoundColumn>
                                    
                                     <telerik:GridBoundColumn DataField="ActionPerformed" HeaderText="Action">
                                    </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="DocumentSendTo" HeaderText="Document Send To">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="GRNO" HeaderText="GR No">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="GRDATE" HeaderText="GR Date">
                                    </telerik:GridBoundColumn>
                                   <%-- <telerik:GridBoundColumn DataField="ItemGroup" HeaderText="Group">
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Customer" HeaderText="Customer">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="SalePerson" HeaderText="SalePerson">
                                    </telerik:GridBoundColumn>
                                   <%-- <telerik:GridBoundColumn DataField="OrderNo" HeaderText="OrderNo">
                                    </telerik:GridBoundColumn>--%>
                                  <%--  <telerik:GridBoundColumn DataField="ItemNo" HeaderText="ItemNo">
                                    </telerik:GridBoundColumn>--%>
                                     <telerik:GridBoundColumn DataField="DocumentSendDate" HeaderText="Document Send Date">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                                <PagerStyle PageSizeControlType="RadComboBox" />
                            </MasterTableView>
                            <PagerStyle PageSizeControlType="RadComboBox" />
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                    </ContentTemplate>
                      <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="radbtnFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="RadButtonApply" EventName="Click" />
                     
                    </Triggers>
                </asp:UpdatePanel>
               <%-- <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="RadButtonApply">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
                </telerik:RadAjaxLoadingPanel>--%>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td class="NormalText" style="width: 155px">
                <asp:Label ID="lblinvoiceselected" runat="server" Text=" "></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 155px">
                <asp:Label ID="lblAccept" runat="server" Text="Action Performed"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="radComboAction" runat="server">
                    <Items>
                        <telerik:RadComboBoxItem Value="Received" Text="Received" />
                        <telerik:RadComboBoxItem Value="Not Received" Text="Not Received" />
                    </Items>
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <telerik:RadButton ID="RadButtonApply" runat="server" AutoPostBack="true" Text="Apply"
                         OnClick="RadButtonApply_Click"  >
                        </telerik:RadButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
