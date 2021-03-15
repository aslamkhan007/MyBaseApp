<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="jspdftest1.aspx.cs" Inherits="Payroll_jspdftest1" %>

<!DOCTYPE html>
<html lang="en">
    <head>
        <title>html2canvas example</title>
        <%--<script type="text/javascript" src="js/jquery/jquery-1.7.1.min.js"></script> --%> 
        <script src="../Scripts/jquery-1.7.js" type="text/javascript"></script>  
        <%--<script type="text/javascript" src="js/jspdf.js"></script>  --%>  
        <script src="js/jspdf.js" type="text/javascript"></script>
     <%--   <script type="text/javascript" src="libs/FileSaver.js/FileSaver.js"></script>
        <script type="text/javascript" src="js/jspdf.plugin.standard_fonts_metrics.js"></script>
        <script type="text/javascript" src="js/jspdf.plugin.split_text_to_size.js"></script>
        <script type="text/javascript" src="js/jspdf.plugin.from_html.js"></script>    --%>
        <script src="js/plugins/FileSaver.js" type="text/javascript"></script>
        <script src="js/plugins/standard_fonts_metrics.js" type="text/javascript"></script>
        <script src="js/plugins/split_text_to_size.js" type="text/javascript"></script>
        <script src="js/plugins/cell.js" type="text/javascript"></script>
        <script src="js/plugins/from_html.js" type="text/javascript"></script>



<script type="text/javascript">
    $(document).ready(function () {

        $("#exportpdf").click(function () {
            var pdf = new jsPDF('p', 'pt', 'ledger');
            // source can be HTML-formatted string, or a reference
            // to an actual DOM element from which the text will be scraped.
            source = $('#yourTableIdName')[0];

            // we support special element handlers. Register them with jQuery-style 
            // ID selector for either ID or node name. ("#iAmID", "div", "span" etc.)
            // There is no support for any other type of selectors 
            // (class, of compound) at this time.
            specialElementHandlers = {
                // element with id of "bypass" - jQuery style selector
                '#bypassme': function (element, renderer) {
                    // true = "handled elsewhere, bypass text extraction"
                    return true
                }
            };
            margins = {
                top: 80,
                bottom: 60,
                left: 60,
                width: 522
            };
            // all coords and widths are in jsPDF instance's declared units
            // 'inches' in this case
            pdf.fromHTML(source, // HTML string or DOM elem ref.
            margins.left, // x coord
            margins.top, { // y coord
                'width': margins.width, // max width of content on PDF
                'elementHandlers': specialElementHandlers
            },

            function (dispose) {
                // dispose: object with X, Y of the last line add to the PDF 
                //          this allow the insertion of new lines after html
                pdf.save('fileNameOfGeneretedPdf.pdf');
            }, margins);
        });

    });
</script>



</head>
<body>
<div id="yourTableIdName">
    <table style="width: 1020px;font-size: 12px;" border="1">
        <thead>
            <tr align="left">
                <th>Country</th>
                <th>State</th>
                <th>City</th>
            </tr>
        </thead>


        <tbody>

            <tr align="left">
                <td>India</td>
                <td>Telangana</td>
                <td>Nirmal</td>
            </tr>
<tr align="left">
                <td>India</td>
                <td>Telangana</td>
                <td>Nirmal</td>
            </tr><tr align="left">
                <td>India</td>
                <td>Telangana</td>
                <td>Nirmal</td>
            </tr><tr align="left">
                <td>India</td>
                <td>Telangana</td>
                <td>Nirmal</td>
            </tr><tr align="left">
                <td>India</td>
                <td>Telangana</td>
                <td>Nirmal</td>
            </tr><tr align="left">
                <td>India</td>
                <td>Telangana</td>
                <td>Nirmal</td>
            </tr><tr align="left">
                <td>India</td>
                <td>Telangana</td>
                <td>Nirmal</td>
            </tr>
        </tbody>
    </table></div>

    <input type="button" id="exportpdf" value="Download PDF">


</body>

</html>

