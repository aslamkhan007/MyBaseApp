<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="frmInternet_Connection.aspx.vb" Inherits="frmInternet_Connection" title="Internet Connection" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td background="Image/RedBar25px.PNG" colspan="3" style="height: 23px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                    Font-Size="10pt" ForeColor="White" Text="Request For Internet Connection *" Width="216px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" rowspan="2" style="background-image: url(Image/Gradient2.PNG); background-repeat: repeat-y">
                &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Black" Text="Employee  Name & Dept" Width="146px"></asp:Label>
                <asp:TextBox ID="txtEmpName" runat="server" Font-Bold="False" Font-Names="Tahoma"
                    Font-Size="8pt" ReadOnly="True" Width="192px"></asp:TextBox>
                <asp:TextBox ID="txtDeptt" runat="server" Font-Names="Tahoma" Font-Size="8pt" ReadOnly="True"
                    Width="71px"></asp:TextBox></td>
        </tr>
        <tr>
        </tr>
        <tr>
            <td colspan="3" style="width: 160px; height: 18px; background-color: whitesmoke">
                <asp:TextBox ID="txtInfo" runat="server" Height="224px" TextMode="MultiLine" Width="692px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG); width: 40px; background-repeat: repeat-y;
                height: 18px" valign="top">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Height="31px" Text="I am Willing To Get Internet Connection" Width="228px"></asp:Label></td>
            <td colspan="2" style="width: 160px; height: 18px; background-color: whitesmoke"
                valign="top">
                <asp:RadioButtonList ID="cboChoiceList" runat="server" CellPadding="0"
                    CellSpacing="0" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black"
                    RepeatDirection="Horizontal" Width="150px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem Selected="True">No</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG); width: 40px; background-repeat: repeat-y;
                height: 6px" valign="top">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Any Query" Width="69px"></asp:Label></td>
            <td colspan="2" style="width: 26%; height: 6px; background-color: whitesmoke">
                <asp:TextBox ID="txtQuery" runat="server" Font-Names="Tahoma" Font-Size="8pt" Height="20px"
                    MaxLength="1000" TextMode="MultiLine" Width="460px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG); width: 40px; background-repeat: repeat-y;
                height: 6px" valign="top">
            </td>
            <td colspan="2" style="width: 26%; height: 6px; background-color: whitesmoke">
                <asp:Button ID="BtnFetch" runat="server" CssClass="ButtonBack" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" Text="Submit" Width="96px" />
                <asp:Button ID="Button1" runat="server" CssClass="ButtonBack" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" Text="Close" Width="96px" /></td>
        </tr>
        <tr>
            <td colspan="3" style="background-image: url(Image/Gradient2.PNG); background-repeat: repeat-y;
                height: 6px" valign="top">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                    Font-Size="10pt" ForeColor="Red" Text="* Applicable Only for the Colony Residents"
                    Width="308px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

