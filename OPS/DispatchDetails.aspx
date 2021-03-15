<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DispatchDetails.aspx.cs" Inherits="OPS_DispatchDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dispatch Details</title>

       <link media="all" href="../stylesheets/samples.css" type="text/css" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="../stylesheets/stylesheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/formatingsheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/EmpGatewayStyleSheet.css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       
        <asp:GridView ID="GridView1" runat="server" 
            EmptyDataText="No dispatch data available yet..!!" 
            onrowdatabound="GridView1_RowDataBound" ShowFooter="True">
            <AlternatingRowStyle CssClass="GridAI" />
            <HeaderStyle CssClass="GridHeader" />
            <RowStyle CssClass="GridItem" />
        </asp:GridView>
      
    
    </div>
    </form>
</body>
</html>
