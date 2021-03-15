<%@ Page Language="C#" AutoEventWireup="true" CodeFile="outsource_vendor_comparison.aspx.cs" Inherits="OPS_MailContentPages_outsource_vendor_comparison" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        .style4
        {
            width: 181px;
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
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr style="border :1">
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Vendors 
                    Freezed for the Outsourced Yarn Request :
                </td>
                <td>
                    <asp:Label ID="lblRequestID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="border :1">
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Vendor Freezed by :</td>
                <td>
                    <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Freezed
                    Vendor Name :
                </td>
                <td>
                    <asp:Label ID="lblVendorName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="border :1">
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                    Request Pending At:</td>
                <td>
                    <asp:Label ID="lblPendingAt" runat="server"></asp:Label>
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
                    Below Shown is the comparison of all vendors :</td>
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
        <asp:GridView ID="GridView1" runat="server" onrowdatabound="GridView1_RowDataBound">
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
