<%@ Page Language="C#" AutoEventWireup="true" CodeFile="a.aspx.cs" Inherits="AssetMngmnt_a" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server">

                <table style="width: 100%;">
            <tr>
                <td>
                    &nbsp;
                    <asp:Label ID="lblname" runat="server" Text="name"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    
                    <asp:TextBox ID="txtname" runat="server" ValidationGroup="A"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="req01" runat="server" 
                        ControlToValidate="txtname" ErrorMessage="gfhggh"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtname0" runat="server" ValidationGroup="A"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="req2" runat="server" 
                                ControlToValidate="txtname" ErrorMessage="gfhggh"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        DataSourceID="SqlDataSource1">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                   
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        onclick="ImageButton1_Click" ValidationGroup="A" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                    <asp:GridView ID="GridView1" runat="server">
                        <RowStyle CssClass="GridAI" />
                    </asp:GridView>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        </asp:Panel>


    </div>
    </form>
</body>
</html>
