<%@ Page Language="C#" AutoEventWireup="true" CodeFile="excessbudgetmail.aspx.cs" Inherits="OPS_MailContentPages_excessbudgetmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 24px;
        }
        .style2
        {
        }
        .style3
        {
        }
        .style5
        {
            width: 329px;
        }
    </style>
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
                    BudgetID</td>
                <td>
                    <asp:Label ID="lbbudgetid" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Request Submitted By</td>
                <td>
                    <asp:Label ID="lbempname" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="border :1">
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Department</td>
                <td>
                    <asp:Label ID="lbdept" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="border :1">
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Hod</td>
                <td>
                    <asp:Label ID="lbHod" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Budget Amount</td>
                <td>
                    <asp:Label ID="lbbudgetamt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="border :1">
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Balance&nbsp; Amount</td>
                <td>
                    <asp:Label ID="lbbalamt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="border :1">
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Indent Amount</td>
                <td>
                    &nbsp;<asp:Label ID="lbindentamt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="border :1">
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Excess Amount</td>
                <td>
                    <asp:Label ID="lbexcessamt" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
        <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3">
                    Details are shown below</td>
            </tr>
        </table>

        <table style="width:100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2" id="grddetail">
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

