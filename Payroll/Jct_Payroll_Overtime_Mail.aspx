<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Jct_Payroll_Overtime_Mail.aspx.cs" Inherits="Payroll_Jct_Payroll_Overtime_Mail" %>

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
    Hi,
    </p>
            <p>
                Dear Users,</p>

<%--          <table style="width:100%;">
            <tr>
                <td class="style1">
                <asp:GridView ID="GridView1" runat="server"   CssClass="gridtable">
        </asp:GridView>
                 </td>
                <td class="style2">
        
                </td>

            </tr>
            </table>--%>
    
  
   <p>Overtime has been authorized for below employees :</p>
 


        <table style="width:100%;">
            <tr>
                <td class="style1">
                <asp:GridView ID="grdItemDetail" runat="server"   CssClass="gridtable">
        </asp:GridView>
                 </td>
                <td class="style2">
        

                </td>

            </tr>
            <tr>
                <td class="style1">
    
  
  <p></p>
                 </td>
                <td class="style2">
        

                    &nbsp;</td>

            </tr>
            </table>
                <p>
                    This is a system generated mail and sent through Payroll online mail management 
                system. Please donot reply.<br/>
                Thank You
      </p>
    </div>
     </form>
</body>
