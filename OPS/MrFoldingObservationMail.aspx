<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MrFoldingObservationMail.aspx.cs" Inherits="OPS_MrFoldingObservationMail" %>

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
            Material 
            Return Folding Observation request 
            &nbsp;has been generated .</p>
        <p class="gridtable">
            Category :&nbsp;
         <b><asp:Label ID="lblRequest" runat="server" Text="Label"></asp:Label></b>   
            </p>
        <p>
            For SanctionNote ID Is :&nbsp;
           <b><asp:Label ID="lblSanctionNoteId" runat="server" Text="Label"></asp:Label> </b> 
            &nbsp;</p>
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
    
  
  <p></p>
  <b><p>Detail::</p> </b> 
 


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
            <tr>
                <%--<td class="style1">
                    Note: In Case of Shared Residence , Each Employee Has To Individually Identify 
                    His/Her Furniture Items in Possession</td>--%>
                <td class="style2">
        

                    &nbsp;</td>

            </tr>
            </table>
<a href='http://testerp/fusionapps/OPS/MRPreview.aspx'> Click here to view details... </a><br />
                <p>
                This is a system generated mail and sent through OPS online mail management 
                system. Please donot reply.<br/>
                Thank You
      </p>
    </div>
     </form>
</body>
