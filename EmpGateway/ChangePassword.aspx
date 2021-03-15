<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="Default6" title="Change Password" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="650">
        <tr>
            <td  colspan="2" class="tableheader">
                <asp:Label ID="Label5" runat="server" BorderColor="Transparent" Font-Bold="True"
                    Font-Names="Trebuchet MS" Font-Size="10pt"  Text="Change Your Password"
                    Width="427px"></asp:Label></td>
        </tr>
        <tr>
            <td class="labelcess">
                <asp:Label ID="Label1" runat="server" Text="Current Password:" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Width="120px" ForeColor="#404040"></asp:Label></td>
            <td width="78%" class="textcells">
                <asp:TextBox ID="txtcurrpwd" runat="server" TextMode="Password" Width="200px" CssClass="TextBack"></asp:TextBox>
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Italic="False" ForeColor="Red"
                    Text="Incorrect Password!!" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="New Password:" Width="120px" ForeColor="#404040"></asp:Label></td>
            <td class="textcells">
                <asp:TextBox ID="txtNewpwd" runat="server" TextMode="Password" Width="200px" CssClass="TextBack"></asp:TextBox>
                <asp:Label ID="lblNew" runat="server" Font-Bold="True" Font-Italic="False" ForeColor="Red"
                    Text="Password Can't Be Blank!!" Font-Names="Tahoma" Font-Size="8pt"></asp:Label></td>
        </tr>
        <tr>
            <td class="labelcess">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Confirm Password:" Width="120px" ForeColor="#404040"></asp:Label></td>
            <td class="textcells">
                <asp:TextBox ID="txtcongpwd" runat="server" TextMode="Password" Width="200px" CssClass="TextBack"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewpwd"
                    ControlToValidate="txtcongpwd" ErrorMessage="Passwords Do Not Match !!" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td >
            </td>
            <td >
                <asp:Button ID="cmdApply" runat="server" Font-Bold="True" Text="Apply"  CssClass="ButtonBack"  BackColor="Black" />&nbsp;
                <asp:Button ID="cmdCancel" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Text="Cancel" Width="64px" CssClass="ButtonBack" /></td>
        </tr>
    </table>
</asp:Content>

