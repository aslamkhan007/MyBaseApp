<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuthorizationRemarks.aspx.cs" Inherits="OPS_AuthorizationRemarks" %>

 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 179px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnClick" runat="server" 
                        Text="Click me to authorize sanction notes" onclick="btnClick_Click" />
                &nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        Text="Mark All Mails Read" />
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="2">
                    <telerik:RadGrid ID="radGridActionList" runat="server" Visible="False" 
                        AllowPaging="True" AllowSorting="True" 
                        onitemdatabound="radGridActionList_ItemDataBound" 
                        onneeddatasource="radGridActionList_NeedDataSource" PageSize="5">
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
