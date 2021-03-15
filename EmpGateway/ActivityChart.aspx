<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="ActivityChart.aspx.vb" Inherits="ActivityChart" title="Untitled Page" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td colspan="6" style="background-image: url(Image/RedBar25px.PNG); height: 23px">
                &nbsp;<strong><span style="font-size: 10pt; color: #ffffff; font-family: Trebuchet MS">Activity</span></strong></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG); width: 16.7%">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Tahoma" Style="font-size: 8pt"
                    Text="From Period"></asp:Label></td>
            <td style="width: 17%; background-color: whitesmoke">
                <ew:CalendarPopup ID="CldFrom" runat="server" DisplayPrevNextYearSelection="True"
                    Style="font-size: 8pt" Width="71px">
                </ew:CalendarPopup>
            </td>
            <td style="background-image: url(Image/Gradient2.PNG); width: 16.7%">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Style="font-size: 8pt"
                    Text="To Period"></asp:Label></td>
            <td style="background-color: whitesmoke">
                <ew:CalendarPopup ID="CldTo" runat="server" DisplayPrevNextYearSelection="True" Width="71px">
                </ew:CalendarPopup>
            </td>
            <td style="background-image: url(Image/Gradient2.PNG); width: 2px">
                <asp:Button ID="cmdFetch" runat="server" Font-Bold="True" Font-Overline="False" Height="24px"
                    Text="Fetch" Width="97px" CssClass="ButtonBack" /></td>
            <td style="background-image: url(Image/Gradient2.PNG); width: 3px">
                <asp:Button ID="cmdExcel" runat="server" Font-Bold="True" Text="To Excel" CssClass="ButtonBack" Width="105px" /></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG)">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Tahoma" Style="font-size: 8pt"
                    Text="Sales Person"></asp:Label></td>
            <td colspan="2" style="width: 17%; background-color: whitesmoke">
                <asp:DropDownList ID="DrpSalePer" runat="server" AutoPostBack="True" Font-Names="Tahoma"
                    Font-Size="8pt" Width="176px">
                </asp:DropDownList></td>
            <td style="background-image: url(Image/Gradient2.PNG); width: 17%">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Tahoma" Style="font-size: 8pt"
                    Text="Customer"></asp:Label></td>
            <td colspan="2" style="background-color: whitesmoke">
                <asp:DropDownList ID="DrpCust" runat="server" Font-Names="Tahoma" Font-Size="8pt"
                    Width="190px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Panel ID="Panel1" runat="server" Height="500px" ScrollBars="Auto" Width="700px">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" Font-Bold="False" Font-Names="Tahoma"
                        Font-Size="8pt" ForeColor="Black" GridLines="Vertical">
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                    </asp:GridView>
                </asp:Panel>
                
            </td>
        </tr>
    </table>
</asp:Content>

