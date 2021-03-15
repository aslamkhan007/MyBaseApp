<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ScooterMsg.aspx.vb" Inherits="ScooterMsg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="text-align :center">
    <form id="form1" runat="server">
    <div>
        <table style="background-image: url(Image/SalaryBackGrd.JPG); height: 594px; width: 800px;">
            <tr>
                <td align="left" style="text-align: center; height: 492px;" valign="top">
                    <br />
                    <br />
                    <br />
                    <span style="font-size: 11pt;"><span style="color: Gray ;
                        line-height: 100px">
                        <asp:Image ID="Car" runat="server" Height="123px" Width="133px" /></span><span
                            style="font-size: 14pt; color: black"><span style="font-family: Georgia"><span style="color: #000000"><br />
                            </span><span style="font-size: 20pt; font-family: Monotype Corsiva"></span></span><span style="font-family: Georgia"><strong><span style="font-size: 20pt; font-family: Monotype Corsiva">
                                &nbsp;Your&nbsp; Conveyance Allowance has been transfered to your Bank A/c</span></strong><br />
                                <strong><span style="font-size: 20pt; font-family: Monotype Corsiva">for the month of&nbsp;
                                    <asp:Label ID="AllMonth" runat="server" Width="10px"></asp:Label></span></strong><br />
                            <br />
                            <br />
                            </span>
                            <asp:LinkButton ID="Lnk" runat="server" Font-Names="Tahoma" Font-Size="11pt" Width="41px">Close</asp:LinkButton><br />
                            <br />
                            <br />
                        </span></span>  </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
