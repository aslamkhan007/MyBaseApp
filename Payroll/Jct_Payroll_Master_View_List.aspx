<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_Master_View_List.aspx.cs" Inherits="Payroll_Jct_Payroll_Master_View_List" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Payroll Master List:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Master Name</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    AutoPostBack="True" onselectedindexchanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <%--        <tr>
            <td class="labelcells">
                Designation
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldesignation" runat="server" CssClass="combobox" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr>--%>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" Width="32px"
                    OnClick="lnkexcel_Click"></asp:LinkButton>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True"
                                Width="100%">
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
        </tr>
    </table>
</asp:Content>

