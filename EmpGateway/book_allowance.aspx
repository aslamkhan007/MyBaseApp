<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="book_allowance.aspx.vb" Inherits="book_allowance" title="Book Allowance" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 490px">
        <tr>
            <td colspan="2" class="tableheader">
                <asp:Label ID="Label1" runat="server" Text="Books & Periodicals Allowance" Width="250px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" rowspan="2" class="panelcells">
                <asp:DetailsView ID="DetailsView1" runat="server"  
                      GridLines="None"   Width="100%" CssClass="GridViewStyle">
            <RowStyle CssClass="RowStyle" />           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

     

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>

