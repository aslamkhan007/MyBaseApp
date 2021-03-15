<%@ Page Language="C#"  AutoEventWireup="true"  CodeFile="Authorize_Courier_TooTip.aspx.cs" Inherits="Courier_Tracking_System_Authorize_Courier_TooTip"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
        .products td,.products th
        {
            padding:0px;
        }
       .products
        {
            
        }
        .header
        {
            letter-spacing:8px;
            font:bold 16px Arial,Sans-Serif;
            background-color:silver;
        }
        .fieldHeader
        {
            font-weight:bold;
        }
        .alternating
        {
            background-color:#eeeeee;
        }
        .command
        {
            background-color:silver;
        }
        .command a
        {
            color:black;
            background-color:yellow;
            font:14px Arials,Sans-Serif;
            text-decoration:none;
            padding:3px;
            border:solid 1px black;
        }
        .command a:hover
        {
            background-color:yellow;
        }
        .pager td
        {
            padding:2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DetailsView ID="DetailsView1" runat="server" EnableModelValidation="True" 
            Height="200px" Width="400px" AutoGenerateRows="False"  CssClass="products"
        HeaderStyle-CssClass="header"
        FieldHeaderStyle-CssClass="fieldHeader"
        AlternatingRowStyle-CssClass="alternating"
        CommandRowStyle-CssClass="command"
        PagerStyle-CssClass="pager">
            <Fields>
                <asp:TemplateField HeaderText="Subject">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Party Name">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Party_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ZipCode">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("ZipCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="State">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("State") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Attached File">
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Attached_File") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Request Date">
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("Request_Date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Request By">
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("Request_By") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
            <HeaderStyle CssClass="HeaderStyle" />
            <RowStyle CssClass="RowStyle" />
        </asp:DetailsView>
    
    </div>
    </form>
</body>
</html>
