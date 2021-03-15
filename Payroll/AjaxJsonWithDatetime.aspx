<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AjaxJsonWithDatetime.aspx.cs" Inherits="Payroll_AjaxJsonWithDatetime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
--%>

<%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>--%>
<script src="../Scripts/jquery.min.js" type="text/javascript"></script>
<script type = "text/javascript">
    function ShowCurrentTime() {
        $.ajax({
            type: "POST",
            url: "AjaxJsonWithDatetime.aspx/GetCurrentTime",
            data: '{name: "' + $("#<%=txtUserName.ClientID%>")[0].value + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                alert(response.d);
            }
        });
    }
    function OnSuccess(response) {
        alert(response.d);
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  <div>
Your Name :
<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
<input id="btnGetTime" type="button" value="Show Current Time"
    onclick = "ShowCurrentTime()" />
</div>

    </form>
</body>
</html>


