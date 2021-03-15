<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Birthday_Card.aspx.vb" Inherits="Birthday_Card" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Happy Birthday</title>
</head>
<body style ="margin-top : 0; margin-left : 0; margin-bottom : 0">
    <form id="form1" runat="server">
    <div>
        <table style="width: 800px; background-image: url(Image/Birthday_Card2.png); background-repeat: no-repeat; height: 602px;">
            <tr>
                <td style="width: 71px; height: 6px">
                </td>
                <td colspan="1" style="height: 6px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 71px; height: 5px">
                </td>
                <td colspan="1" style="height: 5px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 71px; height: 15px">
                </td>
                <td style="height: 15px; text-align: left" colspan="1">
                    <asp:Label ID="lblTo" runat="server" Font-Names="Pristina" Font-Size="24pt" Height="24px"
                        Text="Dear" Font-Bold="True" Width="532px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 71px; height: 15px">
                </td>
                <td colspan="1" style="height: 15px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 71px; height: 8px">
                </td>
                <td style="text-align: left" colspan="1" rowspan="3" valign="top">
                    <asp:Label ID="lblMsg" runat="server" Font-Names="Pristina" Font-Size="22pt" Height="23px"
                        Text="Today on the JCT Family conveys its heartiest greetings on your birthday. May God bless you & your family with good health, happiness & prosperity."
                        Width="724px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 71px; height: 3px">
                </td>
            </tr>
            <tr>
                <td style="width: 71px; height: 45px">
                </td>
            </tr>
            <tr>
                <td style="width: 71px">
                </td>
                <td style="width: 261px" rowspan="3" valign="top">
                    <asp:Label ID="Label1" runat="server" Font-Names="Pristina" Font-Size="22pt" Height="23px"
                        Text="We are sure that you would continue to contribute your best efforts towards sustaining the growth and competitive edge of our organization."
                        Width="724px"></asp:Label><br />
                </td>
            </tr>
            <tr>
                <td style="width: 71px">
                </td>
            </tr>
            <tr>
                <td style="width: 71px; height: 30px">
                </td>
            </tr>
            <tr>
                <td style="width: 71px">
                </td>
                <td style="width: 261px">
                    <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Pristina" Font-Size="22pt"
                        Height="14px" Text="With Best Wishes,&#13;&#10;" Width="395px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 71px">
                </td>
                <td style="width: 261px">
                    <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Names="Pristina" Font-Size="22pt"
                        Height="14px" Text="For & on behalf of" Width="395px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 71px">
                </td>
                <td style="width: 261px">
                    <asp:Label ID="Lbllocation" runat="server" Font-Bold="False" Font-Names="Pristina" Font-Size="22pt"
                        Height="17px" Text="JCT LTD" Width="395px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 71px">
                </td>
                <td style="width: 261px; text-align: left">
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        ForeColor="DimGray">Close</asp:LinkButton></td>
            </tr>
            <tr>
                <td style="width: 71px">
                </td>
                <td style="width: 261px">
                </td>
            </tr>
            <tr>
                <td style="width: 71px; height: 7px">
                </td>
                <td style="width: 261px; height: 7px">
                </td>
            </tr>
            <tr>
                <td style="width: 71px; height: 7px">
                </td>
                <td style="width: 261px; height: 7px; text-align: center">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
