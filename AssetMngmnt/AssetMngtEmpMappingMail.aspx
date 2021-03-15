<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssetMngtEmpMappingMail.aspx.cs" Inherits="AssetMngmnt_AssetMngtEmpMappingMail" %>

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
           Employee Location Mapping 
                / Unmapping Detail :</p>

        <table style="width:37%;"  class="gridtable">
         <tr>
                
            <th class="style7">
                SrNo:</th>
            <td>
                    <asp:Label ID="lblsrno" runat="server"></asp:Label>
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
                Employee 
                <asp:Label ID="lblmapunmap" runat="server"></asp:Label>
            &nbsp;:</th>
            <td>
                <asp:Label ID="lblemployeename" runat="server"></asp:Label>
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
                Employee Code :</th>
            <td>
                <asp:Label ID="lblemployeeCode" runat="server"></asp:Label>
            </td>
        </tr>


          <tr>
                
            <th class="style7">
               Generated  By :</th>
            <td>
                <asp:Label ID="lblGeneratedby" runat="server"></asp:Label>
            </td>
        </tr>


            </table>
    
  
  <p>&nbsp;Mapping&nbsp; Detail :</p>
  
  <%--<table style="width:37%;"  class="gridtable">
         <tr>
                
            <th class="style7">
                Total Employees</th>
                
            <th class="style7">
                Mapped Employees</th>
            <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
            <td>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
        </tr>
          
            </table>--%>

      <%--      <table style="width:37%;"  class="gridtable">
         <tr>
                
            <th class="style7">
                :</th>
                
            <th class="style7">
                &nbsp;</th>
            <td>
                    <asp:Label ID="Label3" runat="server"></asp:Label>
            </td>
            <td>
                    <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
        </tr>
          
            </table>--%>
            <asp:GridView ID="grdDetail" runat="server"     CssClass="gridtable"       
           Width="100%">
      </asp:GridView>
                <p>
                This is a system generated mail and sent through OPS online mail management 
                system. Please donot reply.<br/>
                Thank You
      </p>
    </div>
     </form>
</body>

