<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Society.aspx.vb" Inherits="Society" title="Society" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr class="tableheader">
            <td colspan="2" >
                <asp:Label ID="Label1" runat="server" BackColor="Transparent" Text="Society"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" rowspan="2" class="labelcells" >
                <asp:DetailsView ID="DetailsView1" runat="server" GridLines="None" Height="40px"
                    Width="100%" BorderColor="DimGray" BorderStyle="Solid" BorderWidth="2px" CellPadding="3">
                    <RowStyle CssClass="GridItem"/>
                    <PagerStyle CssClass="GridHeader"/>
                    <FieldHeaderStyle CssClass="DetailField"/>
                    <AlternatingRowStyle CssClass="GridAI" />
                </asp:DetailsView>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

