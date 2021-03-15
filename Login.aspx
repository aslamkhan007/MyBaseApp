<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script type="text/javascript">

        function clickButton(e, buttonid) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(buttonid);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();

                    return false;
                }
            }
        }
 
    </script>

    <title></title>
    <link rel="stylesheet" type="text/css" href="stylesheets/stylesheet.css" />
    <link rel="stylesheet" type="text/css" href="stylesheets/formatingsheet.css" />
    <style type="text/css">
        .style1
        {
            width: 118px;
        }
        .style5
        {
            width: 59px;
        }
        .style6
        {
            width: 104px;
            height: 26px;
        }
        .style7
        {
            width: 118px;
            height: 26px;
        }
        .style8
        {
            width: 59px;
            height: 26px;
        }
        .style11
        {
            width: 59px;
            height: 11px;
        }
        .style12
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: White;
            height: 11px;
            display: block;
        }
        .style13
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: Black;
            height: 19px;
            display: block;
            width: 104px;
        }
        .style14
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: White;
            height: 28px;
            display: block;
        }
        .style15
        {
            width: 18px;
            height: 26px;
        }
        .style16
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: Black;
            height: 19px;
            display: block;
            width: 18px;
        }
        .style17
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: White;
            height: 28px;
            display: block;
            width: 18px;
        }
        .style18
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: White;
            height: 11px;
            display: block;
            width: 18px;
        }
        .style19
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: White;
            height: 9px;
            display: block;
            width: 18px;
        }
        .style20
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: White;
            height: 9px;
            display: block;
        }
        .style21
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: White;
            height: 14px;
            display: block;
            width: 18px;
        }
        .style22
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: White;
            height: 14px;
            display: block;
        }
        .style27
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: Black;
            height: 18px;
            display: block;
            width: 18px;
        }
        .style28
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: Black;
            height: 18px;
            display: block;
            width: 104px;
        }
        .style29
        {
            width: 118px;
            height: 18px;
        }
        .style30
        {
            width: 59px;
            height: 18px;
        }
        .style31
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: Black;
            height: 17px;
            display: block;
            width: 18px;
        }
        .style32
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: Black;
            height: 17px;
            display: block;
            width: 104px;
        }
        .style33
        {
            width: 118px;
            height: 17px;
        }
        .style34
        {
            width: 59px;
            height: 17px;
        }
        .style35
        {
            width: 118px;
            height: 19px;
        }
        .style36
        {
            width: 59px;
            height: 19px;
        }
        .errormsg
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            color: red;
        }
    </style>
</head>
<body style="margin: 0px">
    <form id="form1" runat="server">
    <div id="Top" style="background-position: center bottom; width: 100%; height: 70px;
        background-image: url('Image/Plain_Header.png'); background-repeat: no-repeat;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <div id="parent" style="width: 100%; height: 100%; vertical-align: middle; text-align: center;
        background-image: url('Image/Login_back.png'); background-repeat: no-repeat;
        background-position: center center;">
        <div id="left" style="width: 720px; height: 298px; text-align: right; vertical-align: middle;
            font-size: xx-small;">
            <br />
            <br />
            <br />
            <table style="width: 40%; text-align: left; background-repeat: no-repeat;" class="NormalText"
                dir="ltr">
                <tr>
                    <td class="style15">
                        &nbsp;
                    </td>
                    <td class="style6">
                        &nbsp;
                    </td>
                    <td class="style7">
                    </td>
                    <td class="style8">
                    </td>
                </tr>
                <tr>
                    <td class="style27">
                        &nbsp;
                    </td>
                    <td class="style28">
                        <asp:Label ID="Label1" runat="server" Text="Salary Code"></asp:Label>
                    </td>
                    <td class="style29">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox" MaxLength="10"></asp:TextBox>
                    </td>
                    <td class="style30">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style27">
                        &nbsp;
                    </td>
                    <td class="style28">
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td class="style29">
                        <asp:TextBox ID="txtPassword" runat="server" Height="14px" CssClass="textbox" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="style30">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style31">
                    </td>
                    <td class="style32">
                        <asp:Label ID="Label3" runat="server" Text="Company"></asp:Label>
                    </td>
                    <td class="style33">
                        <asp:DropDownList ID="ddlCompany" runat="server" Width="100%" CssClass="combobox">
                        </asp:DropDownList>
                    </td>
                    <td class="style34">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style16">
                    </td>
                    <td class="style13">
                        <asp:Label ID="Label4" runat="server" Text="Location"></asp:Label>
                    </td>
                    <td class="style35">
                        <asp:DropDownList ID="ddlLocation" runat="server" Width="100%" CssClass="combobox">
                        </asp:DropDownList>
                    </td>
                    <td class="style36">
                    </td>
                </tr>
                <tr>
                    <td class="style17">
                        &nbsp;
                    </td>
                    <td class="style14">
                        &nbsp;
                    </td>
                    <td class="style1">
                        <asp:LinkButton ID="lnkLogin" runat="server" CssClass="buttonc">Sign In</asp:LinkButton>
                    </td>
                    <td class="style5">
                    </td>
                </tr>
                <tr>
                    <td class="style18">
                    </td>
                    <td class="style12" colspan="2">
                        <asp:LinkButton ID="lnkForgotPassword" runat="server" ToolTip="Click here to get your forgotten password in your mailbox"
                            CausesValidation="False" Visible="False">Forgot Password?</asp:LinkButton>
                    </td>
                    <td class="style11">
                    </td>
                </tr>
                <tr>
                    <td class="style19">
                    </td>
                    <td class="style20" colspan="2">
                        <asp:LinkButton ID="lnkSignUp" runat="server" PostBackUrl="~/RegisterUser.aspx" 
                            CausesValidation="False" Visible="False">New User? Sign Up</asp:LinkButton>
                    </td>
                    <td class="style20">
                    </td>
                </tr>
                <tr>
                    <td class="style19">
                        &nbsp;
                    </td>
                    <td class="style20" colspan="2">
                        <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/Default.aspx" 
                            CausesValidation="False">HOME</asp:LinkButton>
                    </td>
                    <td class="style20">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style19">
                        &nbsp;
                    </td>
                    <td class="style20" colspan="2">
                        &nbsp;</td>
                    <td class="style20">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style21">
                    </td>
                    <td class="style22" colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Label ID="lblError" runat="server" CssClass="errormsg"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lnkLogin" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td class="style22">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <%--<div id="right" style="background-position: center; background-repeat: no-repeat; width: 450px; height: 300px;
            display: inline-block; background-image: url('Image/Login_Right.png');">
        </div>--%>
    </div>
    <div id="Div1" 
        style="width: 100%; height: 70px; background-position: center top;
        background-repeat: no-repeat; text-align: left; background-image: url('Image/Plain_Footer.png');" 
        class="NormalText">
        <br />
        Note: Please Contact IT Dept in case you forgot your Password.</div>
    </form>
</body>
</html>
