<%@ Page Language="C#" AutoEventWireup="true" CodeFile="asset_accept_AcceptedMail.aspx.cs" Inherits="AssetMngmnt_asset_accept_AcceptedMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<head id="Head1" runat="server">
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
        </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p>
        Furniture Items Acceptance Request has been generated:</p>
        <b>    <p>
                User Detail: </p> </b>

          <table style="width:100%;">
            <tr>
                <td class="style1">
                <asp:GridView ID="GridView1" runat="server"   CssClass="gridtable">
        </asp:GridView>
                 </td>
                <td class="style2">
        
                </td>

            </tr>
            </table>
    
  
  <b> <p>&nbsp;Total Pending Items : </p> </b>
 


        <table style="width:100%;">
            <tr>
                <td class="style1">
                <asp:GridView ID="grdtotalItems" runat="server"   CssClass="gridtable" 
                        EmptyDataText="No Item Pending..">
        </asp:GridView>
                 </td>
                <td class="style2">
        

                </td>

            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
        

                    &nbsp;</td>

            </tr>

            <tr>
                <td class="style1">
                    <strong>Accepted Items:</strong></td>
                <td class="style2">
        

                    &nbsp;</td>

            </tr>

            <tr>
                <td class="style1">
                <asp:GridView ID="grdAcceptedItems" runat="server"   CssClass="gridtable" 
                        EmptyDataText="No Item Pending..">
        </asp:GridView>
 


                 </td>
                <td class="style2">
        

                    &nbsp;</td>

            </tr>
            <tr>
                <td class="style1">
    
  
 
                 </td>
                <td class="style2">
        

                    &nbsp;</td>

            </tr>
            <tr>
                <td class="style1">
                    Note: In Case of Shared Residence , Each Employee Has To Individually Identify 
                    His/Her Furniture Items in Possession</td>
                <td class="style2">
        

                    &nbsp;</td>

            </tr>
            </table>
                <p>
                This is a system generated mail and sent through OPS online mail management 
                system. Please donot reply.<br/>
                Thank You
      </p>
    </div>
     </form>
</body>
