<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JqueryAjaxJsonGridview.aspx.cs" Inherits="Payroll_JqueryAjaxJsonGridview" %>

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
</html>--%>
<%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>--%>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Asp.net Bind Data to Gridview using JQuery or JSON</title>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "JqueryAjaxJsonGridview.aspx/BindDatatables",
            data: "{}",
            dataType: "json",
            success: function (data) {
                for (var i = 0; i < data.d.length; i++) {
                    $("#gvDetails").append("<tr><td>" + data.d[i].UserId + "</td><td>" + data.d[i].UserName + "</td><td>" + data.d[i].Location + "</td></tr>");                    
                }
            },
            error: function (result) {
                alert("Error");
            }
        });
    });
</script>
<style type="text/css">
table,th,td
{
border:1px solid black;
border-collapse:collapse;
}
</style>
</head>
<body>
<form id="form1" runat="server">
<asp:GridView ID="gvDetails" runat="server">
<HeaderStyle BackColor="#DC5807" Font-Bold="true" ForeColor="White" />
</asp:GridView>
</form>
</body>
</html>
