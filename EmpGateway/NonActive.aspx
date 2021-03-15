<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="NonActive.aspx.vb" Inherits="Default6" title="Non-Active Employees" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="2" class="tableheader">
                <asp:Label ID="Label16" runat="server" Text="Non Active Employees"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" width="85%">
                <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" 
                    GridLines="None" HeaderText="" CssClass="GridViewStyle" Width="100%">
                     <RowStyle CssClass="RowStyle" />           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:DetailsView>
            </td>
            <td colspan="1" class="NormalText" width="15%">
                <asp:Image ID="PictureBox1" runat="server" BorderStyle="None" Height="200px" ImageAlign="Middle"
                    ImageUrl="Image/2.JPG" Width="150px" /></td>
        </tr>
        </table>
</asp:Content>