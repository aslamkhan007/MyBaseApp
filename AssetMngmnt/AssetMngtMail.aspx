<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="AssetMngtMail.aspx.cs" Inherits="AssetMngmnt_AssetMngtMail" %>

<html xmlns="http://www.w3.org/1999/xhtml">
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
           Asset Allocation Request Generated  :</p>

        <table style="width:37%;"  class="gridtable">
         <tr>
                
            <th class="style7">
                Request ID:</th>
            <td>
                    <asp:Label ID="lblRequestId" runat="server"></asp:Label>
            </td>
        </tr>

          <tr>
                
            <th class="style7">
               Location :</th>
            <td>
            <asp:Label ID="lblLocation" runat="server"></asp:Label>
            </td>
        </tr>

          <tr>
                
            <th class="style7">
                    Sublocation</th>
            <td>
                <asp:Label ID="lblsubLocation" runat="server"></asp:Label>
            </td>
        </tr>

          <tr>
                
            <th class="style7">
               Generated  For :</th>
            <td>
                <asp:Label ID="lblGeneratedfor" runat="server"></asp:Label>
            </td>
        </tr>


<%--            <tr>
                <th >
                </th>
                <th  class="style7">
                    Asset Allocation Request Generated </th>
                <td>

                   </td>
            </tr>--%>

          <tr>
                
            <th class="style7">
               Generated  By :</th>
            <td>
                <asp:Label ID="lblGeneratedby" runat="server"></asp:Label>
            </td>
        </tr>


            </table>
    
  
  <p></p>
   <p>Allocated Items are shown below :</p>
 


        <table style="width:100%;">
            <tr>
                <td class="style1">
                <asp:GridView ID="grdItemDetail" runat="server"   CssClass="gridtable">
        </asp:GridView>
                 </td>
                <td class="style2">
        

                </td>

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


