<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test2.aspx.cs" Inherits="AssetMngmnt_test2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:Label ID="lblname" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="Txtname" runat="server"></asp:TextBox>
                    <asp:CheckBox ID="Chkname" runat="server" />
                    <asp:HyperLink ID="hpl1" runat="server">HyperLink</asp:HyperLink>
                    <asp:RadioButton ID="rbname" runat="server" Text="CLASS" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="Txtname" ErrorMessage="Please Enter Name "></asp:RegularExpressionValidator>
                    <asp:ImageMap ID="ImageMap1" runat="server">
                    </asp:ImageMap>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem>Class </asp:ListItem>
                        <asp:ListItem>Roll No </asp:ListItem>
                    </asp:DropDownList>
                    <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#000099" 
                        onclick="LinkButton1_Click">LinkButton</asp:LinkButton>
                    <asp:ImageButton ID="ImageButton1" runat="server" />
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
