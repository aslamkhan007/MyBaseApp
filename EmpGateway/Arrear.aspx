<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Arrear.aspx.vb" Inherits="Arrear" title="Arrear" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 490px">
        <tr>
            <td colspan="2" class="tableheader">
                <asp:Label ID="Label1" runat="server" Text="Arrear Detail" Width="250px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" rowspan="2" class="panelcells">
            <asp:Label ID="Label2" runat="server" Text=" (-) Figures has adjusted in your Conveyance Allowance " ForeColor="#FF3300"></asp:Label>
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

