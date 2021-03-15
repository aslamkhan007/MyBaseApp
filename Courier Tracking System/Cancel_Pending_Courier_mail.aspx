<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cancel_Pending_Courier_mail.aspx.cs" Inherits="Courier_Tracking_System_Cancel_Pending_Courier_mail" %>

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
 .style7
    {
        width: 200px;
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
                Courier Request Cancel Detail :</p>
  <p>
      <asp:GridView ID="grdDetail" runat="server"     CssClass="gridtable"       
           Width="100%">
      </asp:GridView>
        </p>

                <p>
                This is a system generated mail and sent through OPS online mail management 
                system. Please donot reply.<br/>
                Thank You
      </p>
    </div>
     </form>
</body>
