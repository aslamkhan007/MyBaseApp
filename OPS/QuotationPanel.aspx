<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="QuotationPanel.aspx.vb" Inherits="OPS_QuotationPanel" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Quotations Panel</td>
        </tr>
        <tr>
            <td class="labelcells">
                Sales Team</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlSalesTeam" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Sales Person</td>
            <td>
                <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Quotation Date From</td>
            <td class="NormalText">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="labelcells">
                Quotation Date To</td>
            <td>
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Customer</td>
            <td class="NormalText">
                <asp:TextBox ID="txtCustomer" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                Order No</td>
            <td>
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" Width="100%">
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_ops_get_quotes" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlSalesPerson" Name="Sale_Person_Code" 
                            PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="txtCustomer" Name="Customer_Code" 
                            PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView2" runat="server" Width="100%">
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

