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
    <table >
        <tr>
            <td class="tableheader" colspan="2">
                Documents
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <telerik:RadGrid ID="RadGrid1" AllowMultiRowSelection="true" runat="server" AutoGenerateColumns="False"
                            GroupPanelPosition="Top" ResolvedRenderMode="Classic" Skin="Metro" OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged"
                            EnableViewState="False" AllowPaging="True" GridLines="None">
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
                                    <telerik:GridBoundColumn DataField="ItemGroup" HeaderText="Group">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Customer" HeaderText="Customer">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="SalePerson" HeaderText="SalePerson">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="OrderNo" HeaderText="OrderNo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ItemNo" HeaderText="ItemNo">
                                    </telerik:GridBoundColumn>
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
                </asp:UpdatePanel>
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="RadButtonApply">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
                </telerik:RadAjaxLoadingPanel>
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
                            OnClick="RadButtonApply_Click">
                        </telerik:RadButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
