<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print_Priority.aspx.cs" Inherits="OPS_Print_Priority" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="application/pdf; charset=Cp1252"/>
    <title></title>
        <link media="all" href="../stylesheets/samples.css" type="text/css" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="../stylesheets/stylesheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/formatingsheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/EmpGatewayStyleSheet.css" />
     <style type="text/css" media="all">
		@page {
			size: A4 portrait; /* can use also 'landscape' for orientation */
			margin-top: 3.0in;
			margin-bottom: 1.0in;
		        }
			@bottom-center {
				content: element(footer);
			}
			
			@top-center {
				content: element(header);
			}
		
			
		#page-header {
			display: block;
			position: running(header);
		}
		
		#page-footer {
			display: block;
			position: running(footer);
		}
		.page-number:before {
			content: counter(page); 
		}
		
		.page-count:before {
			content: counter(pages);  
		}
		.body {
    font-family: "AG Buch Condensed BQ"; /* replace this with your font */
}
	     .style2
         {
             width: 864px;
         }
	     .style3
         {
             width: 188px;
         }
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="style3">
                &nbsp;
                &nbsp;
                &nbsp;
            </td>
            <td>
                &nbsp;
                &nbsp;<table style="border-style: solid; border-width: thin; width: 100%; " >
        <tr>
            <td class="style2">
                Order Priority From
                <asp:Label ID="lblFrom" runat="server"></asp:Label>
&nbsp; To
                <asp:Label ID="lblTo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Producntion for Year Month :
                <asp:Label ID="lblYearMonth" runat="server" Text="201210"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                List of Orders :</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:GridView ID="GridView1" runat="server" Width="100%">
                    <HeaderStyle CssClass="GridHeader" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
        </tr>
    </table>
            </td>
            <td>
                &nbsp;
                &nbsp;
                &nbsp;
            </td>
        </tr>
        </table>
	</form>
</body>
</html>
