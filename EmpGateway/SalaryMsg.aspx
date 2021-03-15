<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SalaryMsg.aspx.vb" Inherits="SalaryMsg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="background-image: url(Image/SalaryBackGrd.JPG); height: 100%" width="100%">
            <tr>
                <td align="left" style="text-align: center" valign="top">
                    <br />
                    <br />
                    <br />
                    <span style="color: orangered"><strong><span style="display: block; font-size: 19pt;
                        color: red; font-family: Tahoma">&nbsp; &nbsp;&nbsp; <span style="text-decoration: underline">
                            SALARY UPDATE</span></span></strong><br />
                    </span><span style="font-size: 11pt; font-family: Georgia"><span style="color: dimgray;
                        line-height: 100px">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Image
                            ID="Image1" runat="server" Height="119px" ImageUrl="~/Image/Cash_Acceptor_retouched.jpg"
                            Width="158px" />
                        &nbsp; &nbsp;&nbsp;<span style="color: threeddarkshadow"><br />
                            <span style="font-size: 16pt; color: #000000; line-height: 190px"><strong style="color: #000000;
                                line-height: normal">Your Salary For The Month Of </strong></span></span>
                    </span>
                        <asp:Label ID="Label1" runat="server" Font-Size="11pt" ForeColor="Red"></asp:Label><span
                            style="font-size: 14pt; color: black"><strong><span style="font-size: 16pt; color: #000000">
                                is Transferred To Your Account.<br />
                            </span>
                                <br />
                                &nbsp;[ </strong>Salary For Grades (<asp:Label ID="Label2" runat="server" Font-Names="Tahoma"
                                    Font-Size="10pt" ForeColor="Red"></asp:Label>) Has Been Transferred For
                            This Month]<br />
                            <br />
                            <br />
                            <br />
                            <asp:LinkButton ID="Lnk" runat="server" Font-Names="Tahoma" Font-Size="11pt" Width="41px">Close</asp:LinkButton><br />
                            <br />
                            <br />
                        </span></span>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
