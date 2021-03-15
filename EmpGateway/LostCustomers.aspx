<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="LostCustomers.aspx.vb" Inherits="LostCustomers" title="Untitled Page" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td colspan="4" style="background-image: url(Image/RedBar25px.PNG); height: 23px;" valign="top">
                &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                    Font-Size="10pt" ForeColor="White" Text="Lost Customers"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold; font-size: 10pt; font-family: 'Trebuchet MS';
                background-color: whitesmoke">
                No Business in Period</td>
            <td style="background-image: url(Image/Gradient2.PNG); width: 17%">
                <asp:Button ID="BtnFetch" runat="server" CssClass="ButtonBack" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" Text="Fetch" Width="96px" /></td>
            <td style="background-color: whitesmoke">
                &nbsp;<asp:Button ID="BtnExcel" runat="server" CssClass="ButtonBack" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" Text="To Excel" Width="96px" /></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG); width: 17%">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Between Date" Width="80px"></asp:Label></td>
            <td style="width: 26%; background-color: whitesmoke">
                <input id="txtfrm" runat="server" style="width: 88px" type="text" onfocus="showCalendarControl(this);" /></td>
            <td style="background-image: url(Image/Gradient2.PNG); width: 17%">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="And Date" Width="80px"></asp:Label></td>
            <td style="background-color: whitesmoke"><input id="txtTo" runat="server" style="width: 88px" type="text" onfocus="showCalendarControl(this);" /></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG)">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Sale Person" Width="80px"></asp:Label></td>
            <td style="width: 26%; background-color: whitesmoke">
                <asp:DropDownList ID="DrpSaleP" runat="server" AutoPostBack="True" Font-Names="Tahoma"
                    Font-Size="8pt" Width="163px">
                </asp:DropDownList></td>
            <td style="background-image: url(Image/Gradient2.PNG)">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Custs From Country" Width="80px"></asp:Label></td>
            <td style="background-color: whitesmoke">
                <asp:DropDownList ID="DrpCountry" runat="server" AutoPostBack="True" Font-Names="Tahoma"
                    Font-Size="8pt" Width="164px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG)">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="State" Width="80px"></asp:Label></td>
            <td style="width: 26%; background-color: whitesmoke">
                <asp:DropDownList ID="DrpState" runat="server" AutoPostBack="True" Font-Names="Tahoma"
                    Font-Size="8pt" Width="166px">
                </asp:DropDownList></td>
            <td style="background-image: url(Image/Gradient2.PNG)">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="City" Width="80px"></asp:Label></td>
            <td style="background-color: whitesmoke">
                <asp:DropDownList ID="DrpCity" runat="server" AutoPostBack="True" Font-Names="Tahoma"
                    Font-Size="8pt" Width="216px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2" style="background-color: whitesmoke">
                <asp:CheckBox ID="ChkLastBusiness" runat="server" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" Text="Last Business In Period" AutoPostBack="True" /></td>
            <td style="background-image: url(Image/Gradient2.PNG)">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Cust Name" Width="80px"></asp:Label></td>
            <td style="background-color: whitesmoke">
                <asp:DropDownList ID="DrpCust" runat="server" AutoPostBack="True" Font-Names="Tahoma"
                    Font-Size="8pt" Width="216px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 10pt; background-image: url(Image/Gradient2.PNG);
                font-family: 'Trebuchet MS'">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Between Date" Width="80px"></asp:Label></td>
            <td style="width: 26%; background-color: whitesmoke"><input id="TxtFromB" runat="server" style="width: 88px" type="text" onfocus="showCalendarControl(this);" /></td>
            <td style="background-image: url(Image/Gradient2.PNG)">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="And Date" Width="80px"></asp:Label></td>
            <td style="background-color: whitesmoke"><input id="txtToB" runat="server" style="width: 88px" type="text" onfocus="showCalendarControl(this);" /></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG)">
            </td>
            <td style="width: 26%; background-color: whitesmoke">
            </td>
            <td style="background-image: url(Image/Gradient2.PNG)">
            </td>
            <td style="background-color: whitesmoke">
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="50px" ScrollBars="Both" Width="710px" style="background-color: whitesmoke">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Tahoma" Font-Size="8pt"
                        ForeColor="Black" GridLines="Horizontal" Width="800px">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

