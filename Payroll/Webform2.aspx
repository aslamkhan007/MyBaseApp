<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Webform2.aspx.cs" Inherits="Payroll_Webform2" %>

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
<!DOCTYPE html>  
    <html xmlns="http://www.w3.org/1999/xhtml">  
        <head id="Head1" runat="server">  
            <title>Showing Data in ASP.NET Grid View Using jQuery, JSON & AJAX Call</title>  
          <%--  <script src="Scripts/jquery-2.2.0.min.js"> --%> 
                </script>  
                <script type="text/javascript">
                    $(document).ready(function () {
                        $("#btnShowData").click(function () {
                            $.ajax
                          ({
                              type: "POST", contentType: "application/json; charset=utf-8", url: "WebForm2.aspx/BindCustomers", data: "{}",
                              dataType: "json", success: function (result) {
                                  for (vari = 0; i < result.d.length; i++) {
                                      $("#gvData").append("<tr><td>" + result.d[i].CustomerID + "</td><td>" + result.d[i].Name + "</td><td>" + result.d[i].Mobile + "</td><td>" + result.d[i].City + "</td></tr>");
                                  }
                              }, error: function (result) {
                                  alert("Error");
                              }
                          });
                        });
                    });   
                </script>  
                        </head>  
  
                        <body>  
                            <table style="background-color: yellow; border: solid 5px red; width: 100%" align="center">  
                                <tr>  
                                    <td style="background-color: orangered; padding: 2px; text-align: center; color: white; font-weight: bold; font-size: 14pt;">Showing Data Using jQuery, JSON & AJAX Call</td>  
                                </tr>  
                                <tr>  
                                    <td>  
                                        <button="btnShowData" runat="server">Get Data</button>  
                                            <br/>  
                                            <br/>  
                                            <form="form1" runat="server" style="background-color:deepskyblue; padding:5px;">  
                                                <asp:GridView="gvData" runat="server" CellPadding="4" ShowHeaderWhenEmpty="true" ForeColor="White" Width="100%">  
                                                    <%--<HeaderStyleBackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
                                                    <RowStyleBackColor="#EFF3FB" />  --%>
                                                </asp:GridView>  
                                           </form>  
                                    </td>  
                                </tr>  
                                </table>  
                        </body>  
  
                        </html> 