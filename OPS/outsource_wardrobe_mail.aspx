<%@ Page Language="C#" AutoEventWireup="true" CodeFile="outsource_wardrobe_mail.aspx.cs" Inherits="OPS_MailContentPages_outsource_wardrobe_mail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Hi,</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr style="border :1">
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Outsourced Wardrobe Request ID</td>
                <td>
                    <asp:Label ID="lblRequestID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="border :1">
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Outsourced Request Authorized By</td>
                <td>
                    <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="border :1">
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Request Pending At</td>
                <td>
                    <asp:Label ID="lbpending" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="border :1">
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    Details area shown below :</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3" colspan="2">
                    &nbsp;</td>
            </tr>
        </table>

        <table style="width:100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>

                </td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2" colspan="2">
                    This is a system generated mail and sent through OPS online mail management 
                    system. Please donot reply.</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    Thank you</td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
    </div>
    </form>
</body>
</html>
