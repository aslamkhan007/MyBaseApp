<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_Savior_Punch_Transfer.aspx.cs" Inherits="Payroll_Jct_Payroll_Savior_Punch_Transfer" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="2">
                Punch Transfer:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Date
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtefffrm">
                </cc1:CalendarExtender>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <%-- <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True"
                                Width="100%" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="Griditem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>--%><%-- <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True"
                                Width="100%" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="Griditem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>--%><%-- <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True"
                                Width="100%" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="Griditem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>--%><%-- <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True"
                                Width="100%" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="Griditem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>--%>
        </table>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                            ValidationGroup="A">Apply</asp:LinkButton>
                        <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <%-- <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True"
                                Width="100%" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="Griditem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>--%>
    </table>
</asp:Content>


