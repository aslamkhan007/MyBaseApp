<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cssdel.aspx.cs" Inherits="Payroll_cssdel" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!doctype html>
<html >
   <head>
     
      <title>jQuery UI Tooltip functionality</title>
      <link href = "https://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css"
         rel = "stylesheet">
      <script src = "https://code.jquery.com/jquery-1.10.2.js"></script>
     <script src = "https://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>

      <!-- Javascript -->
      <script>
          $(function () {
              $("#tooltip-3").tooltip({
                  content: "<strong>MyYesTooltip!</strong>",
                  track: true
              })
            ;
          });
      </script>
   </head>
   
   <body>
      <!-- HTML --> 
      <label for = "name">Message:</label>
      <input id = "tooltip-3" title = "tooltip"><br><br><br>
      <form 
<%--   <asp:TextBox ID="txtEmployee" runat="server" AutoPostBack="True" 
                   
                    Width="300px"  ></asp:TextBox>--%>
   </body>
</html>



