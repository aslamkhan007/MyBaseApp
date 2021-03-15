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
            <td class="tableheader" colspan="4">
                Document Send
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 155px">
                <asp:Label ID="lblInvoiceFrm" runat="server" Text="Invoice From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 166px">
                <telerik:RadDatePicker ID="radDtPckrStartFrom" runat="server" Culture="en-US" ShowPopupOnFocus="True"
                    Width="100px">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40px" Width="100px">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td class="NormalText" style="width: 133px">
                <asp:Label ID="lblInvoiceTo" runat="server" Text="Invoice To"></asp:Label>
            </td>
            <td class="NormalText">
                <telerik:RadDatePicker ID="radDtEndDate" runat="server" Culture="en-US" ShowPopupOnFocus="True"
                    Width="100px"  >
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40px" Width="100px" >
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
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
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
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
                        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" GroupPanelPosition="Top"
                            ResolvedRenderMode="Classic" Skin="Metro" EnableViewState="False"
                            GridLines="None" OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged" AllowPaging="true"
                            CellSpacing="0" onpageindexchanged="RadGrid1_PageIndexChanged" 
                            onneeddatasource="RadGrid1_NeedDataSource">
                            <%-- <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" GroupPanelPosition="Top"
                                ResolvedRenderMode="Classic" Skin="WebBlue" AllowPaging="True" EnablePostBackOnRowClick="false"  
                                GridLines="None">--%>
                            <ClientSettings EnableRowHoverStyle="true" Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="false"  >
                               <%-- <Selecting AllowRowSelect="True" />--%>
                                <Scrolling AllowScroll="True" ScrollHeight="360px" UseStaticHeaders="True"></Scrolling>
                            </ClientSettings>
                            <%-- <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateHierarchy="False">
                            <ClientSettings>
                                <Scrolling AllowScroll="true" UseStaticHeaders="true" SaveScrollPosition="true" />
                            </ClientSettings>--%>
                            <MasterTableView>
                                <Columns>
                                  <telerik:GridButtonColumn Text="Select" CommandName="Select" />
                              
                                    <telerik:GridTemplateColumn UniqueName="chkbox" HeaderText="Action">
                                        <ItemTemplate>
                                            <telerik:RadComboBox ID="radddlAction" runat="server">
                                                <Items>
                                                    <telerik:RadComboBoxItem Value="Sanction by ED, payment will be received" Text="Sanction by ED, payment will be received" />
                                                    <telerik:RadComboBoxItem Value="Sanction by VP(Mkt), payment will be received" Text="Sanction by VP(Mkt), payment will be received" />
                                                    <telerik:RadComboBoxItem Value="PDC received" Text="PDC received" />
                                                    <telerik:RadComboBoxItem Value="Payment received" Text="Payment received" />
                                                    <telerik:RadComboBoxItem Value="Against LC" Text="Against LC" />
                                                    <telerik:RadComboBoxItem Value="Other" Text="Other" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="CheckBoxCol" HeaderText="Document Send">
                                        <%--   <ItemTemplate>
                                            <%#Eval("Status") %>
                                        </ItemTemplate>--%>
                                        <ItemTemplate>
                                            <telerik:RadComboBox ID="radddlsend" runat="server">
                                                <Items>
                                                    <telerik:RadComboBoxItem Value="Direct to Party" Text="Direct to Party" />
                                                    <telerik:RadComboBoxItem Value="To Agent" Text="To Agent" />
                                                    <telerik:RadComboBoxItem Value="Sale Office Regional" Text="Sale Office Regional" />
                                                    <telerik:RadComboBoxItem Value="RO Bangalore" Text="RO Bangalore" />
                                                    <telerik:RadComboBoxItem Value="RO Mumbai" Text="RO Mumbai" />
                                                    <telerik:RadComboBoxItem Value="RO Delhi" Text="RO Delhi" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="InvoiceNo" HeaderText="Invoice No">
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
                                    <telerik:GridBoundColumn DataField="CustomerName" HeaderText="Customer">
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
                        <asp:AsyncPostBackTrigger ControlID="RadButton1" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <%--  <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="radbtnFetch">
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
    <table  class="tableback">
     <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="lebelcells_s">
                <asp:Label ID="lblDetail" runat="server" Text="Detail" Font-Bold="True" Font-Size="10pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False" GroupPanelPosition="Top"
                            ResolvedRenderMode="Classic" Skin="WebBlue" EnableViewState="False"
                            GridLines="None" CellSpacing="0" Height="100px" >
                            <ClientSettings >
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" ScrollHeight="360px" UseStaticHeaders="True"></Scrolling>
                                
                            </ClientSettings>
                            
                            <MasterTableView>
                                <Columns>
                               
                                 <telerik:GridBoundColumn DataField="Action" HeaderText="Action">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Send" HeaderText="Send">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="InvoiceNo" HeaderText="Invoice No">
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
                        </telerik:RadGrid>
                   
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="RadGrid1" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="RadButton1" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
       
    </table>
<table>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <telerik:RadButton ID="RadButton1" runat="server" Text="Apply" onclick="RadButton1_Click"
                            >
                        </telerik:RadButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <telerik:RadButton ID="RadButtonApply" runat="server" Visible="false" Text="Apply"
                            OnClick="RadButtonApply_Click">
                        </telerik:RadButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
