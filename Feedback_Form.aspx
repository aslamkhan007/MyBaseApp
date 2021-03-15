<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Feedback_Form.aspx.vb" Inherits="Login" %>

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
            width: 150px;
        }
        .style13
        {
            font-family: Tahoma;
            font-size: 8pt;
            font-weight: bold;
            text-align: left;
            color: Black;
            display: block;
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
        .style33
        {
            width: 150px;
            height: 17px;
        }
        .style34
        {
            height: 17px;
        }
        .style36
        {
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
        background-image: url('Image/Headers/Feedback_Header.png'); background-repeat: no-repeat;
        background-position: center center;">
        <div id="left" style="width: 720px; height: 298px; text-align: right; vertical-align: middle;
            font-size: xx-small;">
            <br />
            <table style="width: 310px; text-align: left; background-repeat: no-repeat;" class="NormalText"
                dir="ltr">
                <tr>
                    <td colspan="4" style="font-family: 'Trebuchet MS'; font-size: 10pt">
                        Feedback<br />
                    </td>
                </tr>
                <tr>
                    <td class="style31">
                        &nbsp;</td>
                    <td class="labelcells">
                        &nbsp;</td>
                    <td class="style33">
                        &nbsp;</td>
                    <td class="style34">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style31">
                        &nbsp;</td>
                    <td class="labelcells">
                        User Code</td>
                    <td class="style33">
                        <asp:TextBox ID="TxtCode" runat="server" CssClass="textbox" TabIndex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="TxtCode" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td class="style34">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style31">
                    </td>
                    <td class="labelcells">
                        <asp:Label ID="Label3" runat="server" Text="Comments"></asp:Label>
                    </td>
                    <td class="style33">
                        &nbsp;</td>
                    <td class="style34">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style16">
                    </td>
                    <td class="style13" colspan="2" rowspan="5">
                        <asp:TextBox ID="txtComments" runat="server" Height="88px" 
                            TextMode="MultiLine" Width="98%" BackColor="Transparent" 
                            CssClass="textbox" TabIndex="2" MaxLength="8000"></asp:TextBox>
                    </td>
                    <td class="style36">
                    </td>
                </tr>
                <tr>
                    <td class="style16">
                        &nbsp;</td>
                    <td class="style36">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style16">
                        &nbsp;</td>
                    <td class="style36">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtComments" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style16">
                        &nbsp;</td>
                    <td class="style36">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style16">
                        &nbsp;</td>
                    <td class="style36">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style17">
                        &nbsp;
                    </td>
                    <td class="style14">
                        &nbsp;</td>
                    <td class="style1">
                        <asp:LinkButton ID="lnkLogin" runat="server" CssClass="buttonc">Submit</asp:LinkButton>
                    </td>
                    <td>
                    </td>
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
                <tr>
                    <td class="style21">
                        &nbsp;</td>
                    <td class="style22" colspan="2">
                        <asp:LinkButton ID="LnkBack" runat="server" CausesValidation="false" 
                            PostBackUrl="default.aspx">Back</asp:LinkButton>
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
        </div>
    </form>
</body>
</html>
