<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PunchRecordDetail.aspx.cs" Inherits="EmpGateway_PunchRecordDetail" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style2
        {
        }
        .style3
        {
        }
        .style4
        {
            width: 138px;
        }
        .style5
        {
            width: 100px;
        }
    </style>

  

</head>
<body>
    <form id="form1" runat="server">
    <div>
      <script type="text/javascript">
          function CloseAndRebind(args) {
              GetRadWindow().BrowserWindow.refreshGrid(args);
              GetRadWindow().close();
          }

          function GetRadWindow() {
              var oWindow = null;
              if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
              else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

              return oWindow;
          }

          function CloseWindow() {
              GetRadWindow().close();
          }

        </script>
        <asp:ScriptManager ID="ScriptManager2" runat="server" />
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Vista" DecoratedControls="All" />
        

        <table style="width:100%;">
            <tr>
                <td class="style4">
                    Punch Record For -</td>
                <td class="style5">
                    <asp:Label ID="lblDate" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDescription" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            </table>
        <table style="width:100%;">
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    I Punch 
                    :</td>
                <td class="style2">
                    <asp:Label ID="lblIPunch" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    II Punch :</td>
                <td class="style2">
                    <asp:Label ID="lblIIPunch" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    III Punch :</td>
                <td class="style2">
                    <asp:Label ID="lblIIIPunch" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    IV Punch :</td>
                <td class="style2">
                    <asp:Label ID="lblIVPunch" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
