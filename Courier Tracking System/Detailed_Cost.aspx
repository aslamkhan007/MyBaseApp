<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Detailed_Cost.aspx.cs" EnableEventValidation="false" Inherits="Courier_Tracking_System_Detailed_Cost" %>

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
                Text="To Excel" Visible="False" />
            <asp:Button ID="btnBack" runat="server" Text="Back" onclick="btnBack_Click" />
            <asp:HiddenField ID="flag" runat="server" Value="0" />
            <asp:HiddenField ID="Date" runat="server" />
            <br />
            <asp:GridView ID="GridView1" runat="server" 
                AllowPaging="True" CssClass="GridViewStyle" ShowFooter="True" 
                onpageindexchanging="GridView1_PageIndexChanging" 
                onrowdatabound="GridView1_RowDataBound1" Width="100%" 
                EnableModelValidation="True" PageSize="100" DataKeyNames="Date" 
                onrowcommand="GridView1_RowCommand">
                <AlternatingRowStyle CssClass="AlternateRowStyle" />
                <Columns>
                    <asp:TemplateField HeaderText="Detail">
                    <ItemTemplate>
                      <asp:Button ID="btnSelect" runat="server" Text="Select" CommandName = "Select" />
                    </ItemTemplate>
                    </asp:TemplateField>
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
    <asp:Button ID="btnExcel1" runat="server" onclick="btnExcel1_Click" 
        Text="to Excel" Visible="False" />
    <asp:Button ID="btnBack1" runat="server" onclick="btnBack1_Click" Text="Back" />
    </form>
</body>
</html>
