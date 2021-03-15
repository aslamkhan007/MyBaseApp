<%@ Page Language="C#" AutoEventWireup="true" CodeFile="excessbudgetmail.aspx.cs" Inherits="OPS_MailContentPages_excessbudgetmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <!-- CSS goes in the document HEAD or added to your external stylesheet -->
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
    .style7
    {
        width: 169px;
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
            Request for sanctioning of excess budget amount has been forwarded for approval.If 
            any Query Contact the concerned.</p>
        <p>
            &nbsp;Details are shown below :</p>
        <table style="width:37%;"  class="gridtable">
             
            <tr>
                
                <th class="style7">
                    BudgetID</th>
                <td>
                    <asp:Label ID="lbbudgetid" runat="server"></asp:Label>
                </td>
            </tr>
              <tr>
                
                <th class="style7">
                    Indent No</th>
                <td>
                    <asp:Label ID="lbIndentNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                
                <th class="style7">
                    Request Submitted By</th>
                <td>
                    <asp:Label ID="lbempname" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
              
                <th class="style7">
                    Pending At</th>
                <td>
                    <asp:Label ID="lbpending" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
              
                <th class="style7">
                    Department</th>
                <td>
                    <asp:Label ID="lbdept" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
              
                <th class="style7">
                    Hod</th>
                <td>
                    <asp:Label ID="lbHod" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
             
                <th class="style7">
                    Budget Amount 
                    (Rs)</th>
                <td>
                    <asp:Label ID="lbbudgetamt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                
                <th class="style7">
                    Balance Amount (Rs)</th>
                <td>
                    <asp:Label ID="lbbalamt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
               
                <th class="style7">
                    Indent Amount (Rs)</th>
                <td>
                    &nbsp;<asp:Label ID="lbindentamt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
               
                <th class="style7">
                    Excess Amount (Rs)</th>
                <td>
                    <asp:Label ID="lbexcessamt" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
            <p></p>
      <p>
          <b>Details are shown below :</b>
      </p>
                <asp:GridView ID="GridView1" runat="server" CssClass="gridtable">
                </asp:GridView>
        <p>
                This is a system generated mail and sent through OPS online mail management 
                system. Please donot reply.<br/>
                Thank You
      </p>
      <p>
     
      </p>    
    </div>
    </form>
</body>
</html>

