<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Payment_Terms.aspx.vb" Inherits="OPS_Payment_Terms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td style="font-weight: bold; font-size: 10pt" class="tableheader" colspan="6">
                Quotation
                <asp:Label ID="lblQuotationNo" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                Payment Terms</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    DataSourceMode="DataReader"></asp:SqlDataSource>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Discount</td>
            <td class="NormalText">
                <asp:DropDownList ID="DropDownList6" runat="server" CssClass="combobox">
                    <asp:ListItem Value="2">Advance</asp:ListItem>
                    <asp:ListItem Value="1">Cash</asp:ListItem>
                </asp:DropDownList>
            &nbsp;<asp:ImageButton ID="ibtAddDispatchItem0" runat="server" 
                    ImageUrl="~/Image/Icons/Action/AddItem.png" ToolTip="Add Item to List" 
                    Width="20px" />
            </td>
            <td class="labelcells">
                Discount Type</td>
            <td class="NormalText">
                <asp:Label ID="lblDiscount" runat="server"></asp:Label>
            </td>
            <td class="labelcells">
                Discount/Unit</td>
            <td class="NormalText">
                <asp:Label ID="lblDiscountPUnit" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Agent Name</td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox26" runat="server" Width="197px"></asp:TextBox>
            </td>
            <td class="labelcells">
                Agent Commission</td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox27" runat="server" Width="30px"></asp:TextBox>
                %</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:GridView ID="grdDiscounts" runat="server" 
                                    EnableModelValidation="True" Width="100%">
                    <RowStyle CssClass="GridItem" />
                    <HeaderStyle CssClass="GridHeader" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="6" class="tableback">
                <asp:ImageButton ID="ibtSave" runat="server"
                    ImageUrl="~/Image/Icons/Action/document_save.png" ToolTip="Create and Save Quotation" 
                    Width="48px" />
                <asp:ImageButton ID="ibtSave0" runat="server"
                    ImageUrl="~/Image/Icons/Action/back.png" ToolTip="Create and Save Quotation" 
                    Width="48px" />
            </td>
        </tr>
    </table>
</asp:Content>

