<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="LostCustomerAnalysis.aspx.vb" Inherits="LostCustomerAnalysis" title="Untitled Page" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td colspan="4" style="background-image: url(Image/RedBar25px.PNG); width: 25%; height: 23px" valign="top">
                &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                    Font-Size="10pt" ForeColor="White" Text="Lost Customer Analysis" Width="187px"></asp:Label></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG); width: 23%; height: 21px" valign="top">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Customer Name"></asp:Label></td>
            <td colspan="2" style="height: 21px; background-color: whitesmoke">
                <asp:TextBox ID="txtCust" runat="server" Font-Names="Tahoma" Font-Size="8pt" Width="354px"></asp:TextBox>
                <asp:DropDownList ID="DrpCustomers" runat="server" AutoPostBack="True" Font-Names="Tahoma"
                    Font-Size="8pt" Width="34px" Visible="False">
                </asp:DropDownList></td>
            <td style="width: 25%; background-color: whitesmoke">
                <asp:Label ID="LblCustNo" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG); width: 25%; height: 21px" valign="top">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Select Customer's Status"></asp:Label></td>
            <td style="width: 25%; height: 21px; background-color: whitesmoke">
                <asp:DropDownList ID="DrpStatus" runat="server" AutoPostBack="True" Font-Names="Tahoma"
                    Font-Size="8pt" Width="144px">
                </asp:DropDownList></td>
            <td style="background-color: whitesmoke">
            </td>
            <td style="width: 25%; background-color: whitesmoke">
            </td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG); width: 25%; height: 21px" valign="top">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Reason for loosing"></asp:Label></td>
            <td colspan="2" style="height: 21px; background-color: whitesmoke">
                <asp:DropDownList ID="DrpReason" runat="server" Font-Names="Tahoma" Font-Size="8pt"
                    Width="295px">
                </asp:DropDownList></td>
            <td style="width: 25%; background-color: whitesmoke">
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Tahoma" Font-Size="8pt"
                    NavigateUrl="~/AnalysisMaster.aspx">Define New Reason</asp:HyperLink></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG); width: 25%; height: 21px" valign="top">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Action Plan"></asp:Label></td>
            <td colspan="3" style="height: 21px; background-color: whitesmoke">
                <asp:TextBox ID="txtAction" runat="server" TextMode="MultiLine" Width="524px" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG); width: 25%; height: 21px"
                valign="top">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Analysis History"></asp:Label></td>
            <td colspan="3" style="height: 21px; background-color: whitesmoke">
                <asp:TextBox ID="txtHistory" runat="server" Font-Names="Tahoma" Font-Size="8pt" Rows="5"
                    TextMode="MultiLine" Width="524px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG); width: 25%; height: 21px" valign="top">
            </td>
            <td style="width: 25%; height: 21px; background-color: whitesmoke">
                <asp:Button ID="cmdApply" runat="server" CssClass="ButtonBack" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" Text="Apply" Width="83px" /></td>
            <td style="background-image: url(Image/Gradient2.PNG); background-color: whitesmoke">
                <asp:Button ID="cmdCancel" runat="server" CssClass="ButtonBack" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" Text="Cancel" Width="83px" /></td>
            <td style="width: 25%; background-color: whitesmoke">
            </td>
        </tr>
    </table>
</asp:Content>

