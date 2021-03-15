<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jspdfs.aspx.cs" Inherits="Payroll_jspdfs" %>

<script type="text/javascript" src="jquery/jquery-1.7.1.min.js"></script> 
<script type="text/javascript" src="jspdf.js"></script> 

<script type="text/javascript" src="jspdf.plugin.standard_fonts_metrics.js"></script> 

<script type="text/javascript" src="jspdf.plugin.split_text_to_size.js"></script> 

<script type="text/javascript" src="jspdf.plugin.from_html.js"></script>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script>
    function demoFromHTML() {
        var doc = new jsPDF('p', 'in', 'letter');
        var source = $('#testcase').first();
        var specialElementHandlers = {
            '#bypassme': function (element, renderer) {
                return true;
            }
        };

        doc.fromHTML(
source, // HTML string or DOM elem ref.
0.5, // x coord
0.5, // y coord
{
'width': 7.5, // max width of content on PDF
'elementHandlers': specialElementHandlers
});

        doc.output('dataurl');
    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <a href="javascript:demoFromHTML()" class="button">

<div id="testcase">

<h1>
We support special element handlers. Register them with jQuery-style.
</h1>

</div>
    </form>
</body>
</html>
