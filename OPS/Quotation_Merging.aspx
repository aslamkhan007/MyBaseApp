<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Quotation_Merging.aspx.vb" Inherits="OPS_Quotation_Merging" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Merge Quotations</td>
        </tr>
        <tr>
            <td class="labelcells">
                Recent Quotations</td>
            <td>
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" 
                    Width="100%" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Quotation_No" HeaderText="Quotation_No" 
                            SortExpression="Quotation_No" />
                        <asp:BoundField DataField="Customer_Name" HeaderText="Customer_Name" 
                            SortExpression="Customer_Name" />
                        <asp:BoundField DataField="Item_Type" HeaderText="Item_Type" 
                            SortExpression="Item_Type" />
                        <asp:BoundField DataField="Item_Code" HeaderText="Item_Code" 
                            SortExpression="Item_Code" />
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="select top 5 Quotation_No, Customer_Name, Item_Type, Item_Code from jct_ops_quotation_hdr
where sales_person_code = 'j01838'
order by quotation_no desc"></asp:SqlDataSource>
            </td>
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

