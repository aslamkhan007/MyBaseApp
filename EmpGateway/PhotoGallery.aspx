<%@ Page EnableViewState="true" Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="PhotoGallery.aspx.vb" Inherits="Default6" title="Photo Galary" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Media-Player-ASP.NET-Control" Namespace="Media_Player_ASP.NET_Control"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="lblheader" runat="server" Width="175px"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" valign="top" class="panelcells">
                &nbsp;<asp:Image ID="PictureBox1" runat="server" BorderStyle="None" Height="300px" Width="400px" />
                <cc1:media_player_control id="MPC1" runat="server" height="1px" width="199px"></cc1:media_player_control>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="width: 711px; height: 1px; text-align: left"
                valign="top">
                <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" CssClass="GridViewStyle" Width="100%" GridLines="None">
                     <RowStyle CssClass="RowStyle" />           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
    <PagerStyle CssClass="PagerStyle" />
  

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:DetailsView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" rowspan="1" style="width: 711px; height: 63px; text-align: left"
                valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="50px" ScrollBars="Vertical" 
                    Width="100%" >
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" rowspan="1" style="width: 711px" valign="top" 
                class="labelcells">
                <asp:LinkButton ID="Back" runat="server" Visible="true" CssClass="labelcells">Back to Main</asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>
