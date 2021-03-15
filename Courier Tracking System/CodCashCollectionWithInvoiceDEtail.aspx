<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master"
    AutoEventWireup="true" CodeFile="CodCashCollectionWithInvoiceDEtail.aspx.cs"
    Inherits="Courier_Tracking_System_CodCashCollectionWithInvoiceDEtail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
    
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

        <script type="text/javascript">

            function PopUp() {

                var from = document.getElementById('<%=radDateFrom.ClientID %>').value;

                var to = document.getElementById('<%=radDateTo.ClientID %>').value;

                var awbno = document.getElementById('<%=radAwbNo.ClientID %>').value;

                window.radopen("CourierCODPreviewMail.aspx?from=" + from + "&to=" + to + " &awbno=" + awbno, "UserListDialog");
                return false;
            }



           
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>





    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Cash Collection Detail(Invoice)
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
                <asp:Label ID="Label18" runat="server" Text="AWB No."></asp:Label>
            </td>
            <td class="NormalText" style="width: 149px">
                <telerik:RadTextBox ID="radAwbNo" runat="server" Width="100px">
                </telerik:RadTextBox>
            </td>
            <td class="NormalText" style="width: 63px">
                &nbsp;
            </td>
            <td class="NormalText">
                <asp:HiddenField ID="hdfCarrierName" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 120px">
                <asp:Label ID="Label22" runat="server" Text="Invoice No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 149px">
                <telerik:RadTextBox ID="radtxtInvoiceNo" runat="server" Width="150px">
                </telerik:RadTextBox>
            </td>
            <td class="NormalText" style="width: 63px">
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
                        <telerik:RadButton ID="radbtnFetch" runat="server" onclick="radbtnFetch_Click" 
                            Text="Fetch">
                        </telerik:RadButton>
                        <telerik:RadButton ID="radbtnReset" runat="server" Text="Reset">
                        </telerik:RadButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <telerik:RadButton ID="radbtnExcel" runat="server" onclick="radbtnExcel_Click" 
                            Text="Excel">
                        </telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td colspan="4">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdDetail" runat="server" Width="100%" AutoGenerateColumns="true">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="PageStyle" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>


            </td>
        </tr>
        <tr>
            <td>

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="UserListDialog" runat="server" Title="Add More Checks" Height="500px"
                Width="500px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
