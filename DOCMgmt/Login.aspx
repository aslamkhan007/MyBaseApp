<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Page-Enter" content="progid:DXImageTransform.Microsoft.Fade(Duration=1)"/>
<meta http-equiv="Page-Exit" content="progid:DXImageTransform.Microsoft.Fade(Duration=1)"/>
    <title>Log In to Document Management System</title>
    <link href="StyleSheets/FormatingSheet.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript" > 
 
function clickButton(e, buttonid){ 
      var evt = e ? e : window.event;
      var bt = document.getElementById(buttonid);
      if (bt)
      { 
          if (evt.keyCode == 13 )
          { 
             bt.click(); 
              
                return false; 
          } 
      } 
      
}
 
</script>
<script type="text/javascript">

function checkWindow(){
 if (window.name != "notoolbar") 
 {
 window.opener=null;
 window.open ('',"_top");
 window.open (location.href,"Document Management System","resizable=yes,location=0,scrollbars=yes,status=1");
 window.top.close();
 }
}
 
function DoBlur(fld) 
{
    fld.className='normalfld';
}

function DoFocus(fld)
 {
    fld.className = 'focusfld';
 }    
 
</script>
    <style type="text/css">
        .style1
        {
            height: 23px;
            width: 615px;
        }
        .style2
        {
            height: 87px;
            width: 615px;
        }
        .style3
        {
            height: 21px;
            width: 615px;
        }
        .style4
        {
            text-align: center;
            height: 176px;
        }
    </style>

</head>
<body style="background-attachment: fixed; margin-top : 0 ; background-image : url(Image/gradiant.png); background-repeat: repeat-x" >
    <form id="form1" runat="server">
    <div style="text-align: left">
        <table style="background-image: url('Image/DMSLogin.png'); width: 828px; height: 450px; background-repeat: no-repeat;" 
            align="center">
            <tr>
                <td style="width: 264px; height: 23px;">
                </td>
                <td class="style1">
                </td>
                <td style="width: 421px; height: 23px;">
                </td>
            </tr>
            <tr>
                <td style="width: 264px; height: 87px">
                </td>
                <td class="style2">
                </td>
                <td style="width: 421px; height: 87px; " align="center">
                    <div class="style4">
                    <br />
                    <br style="text-align: center" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
<br />
                    </div>
        <table style="width: 206px; height: 102px; text-align: right;" id="TABLE1" border="0" 
                        cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 91px; height: 6px">
                </td>
                <td style="height: 6px; width: 39px;">
                    <asp:Label ID="lblusername" runat="server" Text="User Name" Width="65px" Font-Bold="False" Font-Names="verdana" Font-Size="8pt" ForeColor="DimGray"></asp:Label></td>
                <td style="height: 6px; width: 94px;">
                    <asp:TextBox ID="txtusername" runat="server" EnableViewState="False" AutoCompleteType="Disabled" Font-Names="verdana" Font-Size="8pt" Width="98px" CssClass="TextBack"></asp:TextBox></td>
                <td style="height: 6px; width: 172px; " class="style4">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="8pt"
                        ForeColor="Red" Height="16px" Visible="False" Width="5px">*</asp:Label></td>
            </tr>
            <tr>
                <td style="width: 91px; height: 10px; text-align: right">
                </td>
                <td style="width: 39px; height: 6px; ">
                    <asp:Label ID="lblpassword" runat="server" Text="Password" Width="64px" Font-Bold="False" Font-Names="verdana" Font-Size="8pt" ForeColor="DimGray"></asp:Label></td>
                <td style="width: 94px; height: 10px; text-align: left;">
                    <asp:TextBox ID="txtpassword" runat="server" onclick="javascript:Button1.click();" EnableViewState="False" AutoCompleteType="Disabled" TextMode="Password" Font-Names="verdana" Font-Size="8pt" Width="98px" CssClass="TextBack"></asp:TextBox></td>
                <td style="width: 172px; height: 10px; " class="style4">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="8pt"
                        ForeColor="Red" Height="16px" Visible="False" Width="5px">*</asp:Label></td>
            </tr>
            <tr>
                <td style="width: 91px; height: 6px">
                </td>
                <td style="width: 39px; height: 6px; ">
                    <asp:Label ID="Label3" runat="server" Text="Company" Width="64px" Font-Bold="False" Font-Names="verdana" Font-Size="8pt" ForeColor="DimGray"></asp:Label></td>
                <td style="width: 94px; height: 6px; " class="style4">
                    <asp:DropDownList ID="ddlCompany" runat="server" BackColor="WhiteSmoke" Font-Bold="False"
                        Font-Names="verdana" Font-Size="8pt" ForeColor="#404040" Width="100px">
                        <asp:ListItem>JCT Limited</asp:ListItem>
                        <asp:ListItem>JCT Fabrics</asp:ListItem>
                        <asp:ListItem>JCT Filament</asp:ListItem>
                        <asp:ListItem>JCT HO</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 172px; height: 6px">
                </td>
            </tr>
    <tr>
        <td style="width: 91px; height: 19px">
        </td>
        <td style="width: 39px; height: 19px; ">
            <asp:Label ID="lblcopmany" runat="server" Font-Bold="False" Font-Names="verdana" Font-Size="8pt"
                ForeColor="DimGray" Text="Location" Width="64px"></asp:Label></td>
        <td style="width: 94px; height: 19px; " class="style4">
            <asp:DropDownList ID="ddlLocation" runat="server" BackColor="WhiteSmoke" Font-Bold="False"
                Font-Names="verdana" Font-Size="8pt" ForeColor="#404040" Width="100px">
                <asp:ListItem>Phagwara</asp:ListItem>
                <asp:ListItem>Hoshiarpur</asp:ListItem>
                <asp:ListItem>Ganga Nagar</asp:ListItem>
                <asp:ListItem>New Delhi</asp:ListItem>
            </asp:DropDownList></td>
        <td style="width: 172px; height: 19px">
        </td>
    </tr>
            <tr>
                <td style="width: 91px; height: 11px">
                </td>
                <td style="width: 39px; height: 6px; ">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td style="width: 94px; height: 11px; text-align: left">
                             <asp:LinkButton ID="Button1" runat="server" Height="22px" Text="Login" Width="84px" 
                        Font-Bold="True" Font-Names="verdana" Font-Size="8pt" CssClass="buttonc" ></asp:LinkButton>  </td>
                <td style="width: 172px; height: 11px">
                </td>
            </tr>
            <tr>
                <td style="width: 91px; height: 14px">
                </td>
                <td style="height: 14px; text-align: center;" colspan="3">
                    <asp:Label ID="Message" runat="server" Font-Names="verdana" Font-Size="8pt" ForeColor="Red"
                        Text=" " Width="180px"></asp:Label></td>
            </tr>
                        
        </table>
                </td>
            </tr>
            <tr>
                <td style="width: 264px; height: 21px;">
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td style="width: 421px; height: 21px;">
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
