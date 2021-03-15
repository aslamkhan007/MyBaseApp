<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Birthday.aspx.vb" Inherits="Birthday"  title="Birthday List" MasterPageFile="MasterPage.master" %>

<asp:Content runat = "server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table style="width: 100%; height: 198px;" cellpadding="2" cellspacing="2">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label16" runat="server" Text="Birthday List"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="NormalText" width="85%">
                <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True"  
                     EmptyDataText="No Birthday Today" GridLines="None"  CssClass="GridViewStyle" Width="100%">
                     <RowStyle CssClass="RowStyle" />           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:DetailsView>
                <asp:Label ID="Label1" runat="server" Font-Names="Trebuchet MS" Font-Size="24pt"
                    ForeColor="DimGray" Height="75px" Text="No Birthday Today" Visible="False" Width="455px"></asp:Label>
                <br />
                <asp:Image ID="Image1" runat="server" ImageUrl="Image/No BirthDay 2.png" Visible="False" /></td>
            <td colspan="1" class="NormalText" width="15%">
                <asp:Image ID="Image2" runat="server" BorderStyle="None" Height="55px"
                    ImageAlign="AbsBottom" ImageUrl="Image/Birthday Crown.PNG" Width="131px" />
                <br />
                <asp:Image ID="PictureBox1" runat="server" BorderStyle="None" Height="200px"
                    ImageAlign="Top" ImageUrl="Image/2.JPG" Width="150px" /></td>
        </tr>
        </table>
</asp:Content>