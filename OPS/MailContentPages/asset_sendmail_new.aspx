<%@ Page Language="C#" AutoEventWireup="true" CodeFile="asset_sendmail_new.aspx.cs" Inherits="OPS_MailContentPages_asset_sendmail_new" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>

    <style type="text/css">
table.gridtable {
	font-family: verdana,arial,sans-serif;
	font-size:11px;
	color:#333333;
	border-width: 1px;
	border-color: #666666;
	border-collapse: collapse;
}
table.gridtable th {
	border-width: 1px;
	padding: 8px;
	border-style: solid;
	border-color: #666666;
	background-color: #dedede;
}
table.gridtable td {
	border-width: 1px;
	padding: 8px;
	border-style: solid;
	border-color: #666666;
	background-color: #ffffff;
}


.Grid {background-color: #fff; margin: 5px 0 10px 0; border: solid 1px #525252; border-collapse:collapse; font-family:Calibri; color: #474747;}
.Grid td {
      padding: 2px;
      border: solid 1px #c1c1c1; }
.Grid th  {
      padding : 4px 2px;
      color: #fff;
      background: #363670 url(Images/grid-header.png) repeat-x top;
      border-left: solid 1px #525252;
      font-size: 0.9em; }
.Grid .alt {
      background: #fcfcfc url(Images/grid-alt.png) repeat-x top; }
.Grid .pgr {background: #363670 url(Images/grid-pgr.png) repeat-x top; }
.Grid .pgr table { margin: 3px 0; }
.Grid .pgr td { border-width: 0; padding: 0 6px; border-left: solid 1px #666; font-weight: bold; color: #fff; line-height: 12px; }  
.Grid .pgr a { color: Gray; text-decoration: none; }
.Grid .pgr a:hover { color: #000; text-decoration: none; }
- See more at: http://www.dotnetfox.com/articles/gridview-custom-css-style-example-in-Asp-Net-1088.aspx#sthash.rBGDHrv3.dpuf


        </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p>
        Hi, Your PC Configurations are as Follows:</p>

        <table style="width:37%;"  class="Grid">
         <tr>
                
            <th class="style7">
                Computer Name:</th>
            <td>
                    <asp:Label ID="lblitemname" runat="server"></asp:Label>
            </td>
        </tr>

          <tr>
                
            <th class="style7">
                Department :</th>
            <td>
            <asp:Label ID="lbldept" runat="server"></asp:Label>
            </td>
        </tr>

          <tr>
                
            <th class="style7">
                    Model No:</th>
            <td>
                <asp:Label ID="lblmodelno" runat="server"></asp:Label>
            </td>
        </tr>

          <tr>
                
            <th class="style7">
                Dated :</th>
            <td>
                <asp:Label ID="lblCurrentDate" runat="server"></asp:Label>
            </td>
        </tr>
         <tr>
                
            <th class="style7">
                Issued To:</th>
            <td>
                <asp:Label ID="lblissuedto" runat="server"></asp:Label>
            </td>
        </tr>


         <%--   <tr>
                <th >
                </th>
                <th  class="style7">
                    Asset Allocation Request Generated </th>
                <td>

                   </td>
            </tr>
            
--%>
            </table >
            <table style="width:100;"  >
    <tr>
                
         
            <td>
                    <asp:Label ID="Label1" runat="server">Hardware Configurations</asp:Label>
            </td>
        </tr>
        <tr>
        <td>
            <asp:GridView ID="grdDetail1" runat="server"  CssClass="Grid" Width="600px"            
                      AlternatingRowStyle-CssClass="alt">

            </asp:GridView>
        </td>
        </tr>
    </table>
<table style="width:100;"  >
    <tr>
                
         
            <td>
                    <asp:Label ID="Label2" runat="server">Software Configurations</asp:Label>
            </td>
        </tr>
        <tr>
        <td>
            <asp:GridView ID="grdDetail2" runat="server" CssClass="Grid" Width="600px"     AlternatingRowStyle-CssClass="alt"  >
            </asp:GridView>
        </td>
        </tr>
    </table>
    <table style="width:100;"  >
    <tr>
                
         
            <td>
                    <asp:Label ID="Label3" runat="server">Printer/Scanner</asp:Label>
            </td>
        </tr>
        <tr>
        <td>
            <asp:GridView ID="grdDetail3" runat="server" CssClass="Grid" Width="600px"     AlternatingRowStyle-CssClass="alt" >
            </asp:GridView>
        </td>
        </tr>
    </table>

    
    
     <a href="http://misdev/fusionapps/EmpGateway/Asset_accept.aspx">Please click here to accept these configurations</a>
         <%-- <a href="http://localhost:4052/FusionApps/AssetMngmnt/Asset_accept.aspx">Please click here to accept these configurations</a>--%>
    </div>
    </form>
</body>
</html>
