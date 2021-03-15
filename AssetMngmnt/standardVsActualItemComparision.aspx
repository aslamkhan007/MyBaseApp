<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master"
    AutoEventWireup="true" CodeFile="standardVsActualItemComparision.aspx.cs" Inherits="AssetMngmnt_standardVsActualItemComparision" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .blink_me
        {
            color: Red;
        }
                
        .OK
        {
            color: green;
        }
    </style>
    <script type="text/javascript">
        setInterval("$('.blink_me').fadeOut().fadeIn();", 1000);
        setInterval("$('.OK')", 1000);
        function SetContextKey() {
            $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlloc.ClientID %>").value);
        }
    </script>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="6">
                Standard And Actual Item Allocation Comparision:
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">
                Location
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div id="divwidth" style="display: none;">
                        </div>
                        <telerik:RadComboBox ID="ddlloc" runat="server" AutoPostBack="True" CssClass="combobox"
                            EnableVirtualScrolling="true" ExpandDirection="Down" Height="85" OnSelectedIndexChanged="ddlloc_SelectedIndexChanged"
                            Visible="true">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 115px">
                &nbsp;&nbsp;&nbsp;&nbsp; SubLocation
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="ddlSubloc" runat="server" AutoPostBack="True" CssClass="combobox"
                            EnableVirtualScrolling="True" Height="85px" OnSelectedIndexChanged="ddlSubloc_SelectedIndexChanged">
                            <Items>
                                <telerik:RadComboBoxItem runat="server"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">
                <asp:Label ID="lblLocation" runat="server" Text="Employee Name"></asp:Label>
            </td>
            <td class="NormalText" style="width: 122px">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtempcode" runat="server" AutoPostBack="true" CssClass="textbox"
                            onkeyup="SetContextKey()" OnTextChanged="txtempcode_TextChanged"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                            CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="1"
                            ServiceMethod="GetEmployeeDepartment_test_aslam" ServicePath="~/WebService.asmx"
                            TargetControlID="txtempcode" UseContextKey="True">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 115px">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                        &nbsp;&nbsp;&nbsp;
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td class="NormalText" style="width: 122px">
                &nbsp;
            </td>
            <td class="NormalText" style="width: 115px">
                &nbsp;
            </td>
            <td class="NormalText">
                <asp:LinkButton ID="excel" runat="server" CssClass="buttonXL" Height="30px" OnClick="excel_Click"
                    Width="30px" ToolTip="Excel"></asp:LinkButton>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" OnClick="lnkfetch_Click"
                            ValidationGroup="mandatory">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" OnClick="lnkReset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%-- <asp:Panel ID="pnlgrid" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">--%>
            <%--      <asp:Panel ID="pnlgrid"  runat="server"  ScrollBars="Horizontal" >--%>
            <asp:GridView ID="grdDetail" runat="server" Width="100%" EmptyDataText="No Record Found ..."
                EnableModelValidation="True" OnRowDataBound="grdDetail_RowDataBound">
                <AlternatingRowStyle CssClass="GridAI" />
                <SelectedRowStyle CssClass="SelectedRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <RowStyle CssClass="GridItem" />
            </asp:GridView>
            <%--                 </asp:Panel>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
