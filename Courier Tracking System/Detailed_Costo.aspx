<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Detailed_Cost.aspx.cs" Inherits="Courier_Tracking_System_Detailed_Cost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detailed Cost</title>
       <link rel="stylesheet" type="text/css" href="../stylesheets/stylesheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/formatingsheet.css" />
    <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="Chromestyle.css" rel="stylesheet" type="text/css" />
     <script src="../Carousel/swfobject.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Width="100%">
            <asp:Button ID="btnExcel" runat="server" onclick="btnExcel_Click" 
                Text="To Excel" />
            <asp:Button ID="btnBack" runat="server" Text="Back" Visible="False" />
            <br />
            <asp:GridView ID="grdDetail" runat="server" 
                AllowPaging="True" CssClass="GridViewStyle" ShowFooter="True" 
                onpageindexchanging="GridView1_PageIndexChanging" 
                onrowdatabound="GridView1_RowDataBound1" Width="100%" 
                EnableModelValidation="True">
                <AlternatingRowStyle CssClass="AlternateRowStyle" />
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="Cost_Center" 
                        DataNavigateUrlFormatString="Detailed_Cost.aspx?Dept={0}" Text="Detail" />
                </Columns>
                <FooterStyle CssClass="Footer Style" />
                <HeaderStyle CssClass="HeaderStyle" />
                <PagerStyle CssClass="PagerStyle" />
                <RowStyle CssClass="RowStyle" />
                <SelectedRowStyle CssClass="SelectedRowStyle" 
                Width="100%" />
            </asp:GridView>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
