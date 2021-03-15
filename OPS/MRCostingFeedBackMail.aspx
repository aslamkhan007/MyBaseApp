<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MRCostingFeedBackMail.aspx.cs" Inherits="OPS_MRCostingFeedBackMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
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
           Costing Feedback 
            &nbsp;has been generated .</p>
        
        <p>
            For SanctionNote ID  :&nbsp;
           <b><asp:Label ID="lblSanctionNoteId" runat="server" Text="Label"></asp:Label> </b> 
            &nbsp;</p>
      
    
  
  <p></p>
  <b>Folding Observation Detail : </b> 
 


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
 <p></p>
  <b>Costing FeedBack: </b> 

               <table style="width:100%;">
            <tr>
                <td class="style1">
                <asp:GridView ID="GridView2" runat="server"   CssClass="gridtable">
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



                <p>
                This is a System generated Mail and sent through OPS Online Mail Management 
                system. 
                <br/><br/>
                Please Donot Reply.<br/>
                Thank You
      </p>
    </div>
     </form>
</body>
</html>