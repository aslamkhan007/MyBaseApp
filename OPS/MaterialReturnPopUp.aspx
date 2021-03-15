<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaterialReturnPopUp.aspx.cs" Inherits="OPS_MaterialReturnPopUp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

 
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Material Return Detail</title>
    
      
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <telerik:RadButton ID="radImport" runat="server" onclick="radImport_Click" 
            Skin="Hay" Text="Import">
        </telerik:RadButton>
        <cc1:ConfirmButtonExtender ID="radImport_ConfirmButtonExtender" runat="server" 
            ConfirmText="Are you sure you want to import this Material Return ?" 
            TargetControlID="radImport">
        </cc1:ConfirmButtonExtender>
        <br />
        <asp:Panel ID="Panel1" runat="server" CssClass="panelbg">
            <asp:Label ID="lblContent" runat="server"></asp:Label>
        </asp:Panel>

    </div>
    </form>
</body>
</html>
