<%@ Page EnableViewState="true" Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="NewsDetail.aspx.vb" Inherits="Default6" title="News Detail" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label1" runat="server" Text="News Detail" Width="144px"></asp:Label></td>
        </tr>
        <tr>
            <td  class="labelcells"  >
                <asp:Image ID="Image1" runat="server" Height="300px" Width="400px" /></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 245px; height: 18px; text-align: left; background-image: url(Image/SmallGlassBarNormal.PNG);"  align="left">
                <asp:Label ID="lbldescription" runat="server"  Text="Label" Width="565px" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="1" style=" height: 11px; text-align: left;" valign="middle">
                <asp:Panel ID="Panel1" runat="server" CssClass="panelcells" BorderStyle="None" Height="70px" 
                    Width="100%" HorizontalAlign="Left" ScrollBars="Vertical" BackImageUrl="Image/SmallPanelGradient.PNG">
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="1" style="width: 245px; height: 18px; text-align: left; background-image: url(Image/SmallGlassBarNormal.PNG);"
                valign="middle">
    <asp:LinkButton ID="Back" runat="server" Width="34px"   Font-Names="Tahoma" Font-Size="8pt">Back</asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>


