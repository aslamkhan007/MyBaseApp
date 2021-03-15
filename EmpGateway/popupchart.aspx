<%@ Page Language="VB" AutoEventWireup="false" CodeFile="popupchart.aspx.vb" Inherits="SalesAnalysisSystem_popupchart" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
  <div class="FadingTooltip" id="FADINGTOOLTIP" style="Z-INDEX: 999; VISIBILITY: hidden; POSITION: absolute"></div>
<head>
<link rel="stylesheet" type="text/css" href="../stylesheets/stylesheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/formatingsheet.css" />
  
 <script type ="text/javascript" language = "javascript">
<!--
function printPartOfPage(elementId) {
         var printContent = document.getElementById(elementId);
         var windowUrl = 'about:blank';
         var uniqueName = new Date();
         var windowName = 'Print' + uniqueName.getTime();
         var printWindow = window.open(windowUrl, windowName, 'left=500000,top=500000,width=-12,height=-12');
         printWindow.document.write(printContent.innerHTML);
         printWindow.document.close();
         printWindow.focus();
         printWindow.print();
         printWindow.close();
     }
 
			    var FADINGTOOLTIP
			    var wnd_height, wnd_width;
			    var tooltip_height, tooltip_width;
			    var tooltip_shown = false;
			    var transparency = 100;
			    var timer_id = 1;
			    var tooltiptext;

			    // override events
			    window.onload = WindowLoading;
			    window.onresize = UpdateWindowSize;
			    document.onmousemove = AdjustToolTipPosition;

			    function DisplayTooltip(tooltip_text) {
			        FADINGTOOLTIP.innerHTML = tooltip_text;
			        tooltip_shown = (tooltip_text != "") ? true : false;
			        if (tooltip_text != "") {
			            // Get tooltip window height
			            tooltip_height = (FADINGTOOLTIP.style.pixelHeight) ? FADINGTOOLTIP.style.pixelHeight : FADINGTOOLTIP.offsetHeight;
			            transparency = 0;
			            ToolTipFading();
			        }
			        else {
			            clearTimeout(timer_id);
			            FADINGTOOLTIP.style.visibility = "hidden";
			        }
			    }

			    function AdjustToolTipPosition(e) {
			        if (tooltip_shown) {
			            // Depending on IE/Firefox, find out what object to use to find mouse position
			            var ev;
			            if (e)
			                ev = e;
			            else
			                ev = event;

			            FADINGTOOLTIP.style.visibility = "visible";

			            offset_y = (ev.clientY + tooltip_height - document.body.scrollTop + 30 >= wnd_height) ? -15 - tooltip_height : 20;
			            FADINGTOOLTIP.style.left = Math.min(wnd_width - tooltip_width - 10, Math.max(3, ev.clientX + 6)) + document.body.scrollLeft + 'px';
			            FADINGTOOLTIP.style.top = ev.clientY + offset_y + document.body.scrollTop + 'px';
			        }
			    }

			    function WindowLoading() {
			        FADINGTOOLTIP = document.getElementById('FADINGTOOLTIP');

			        // Get tooltip  window width				
			        tooltip_width = (FADINGTOOLTIP.style.pixelWidth) ? FADINGTOOLTIP.style.pixelWidth : FADINGTOOLTIP.offsetWidth;

			        // Get tooltip window height
			        tooltip_height = (FADINGTOOLTIP.style.pixelHeight) ? FADINGTOOLTIP.style.pixelHeight : FADINGTOOLTIP.offsetHeight;

			        UpdateWindowSize();
			    }

			    function ToolTipFading() {
			        if (transparency <= 100) {
			            FADINGTOOLTIP.style.filter = "alpha(opacity=" + transparency + ")";
			            //FADINGTOOLTIP.style.opacity=transparency/100;
			            transparency += 5;
			            timer_id = setTimeout('ToolTipFading()', 35);
			        }
			    }

			    function UpdateWindowSize() {
			        wnd_height = document.body.clientHeight;
			        wnd_width = document.body.clientWidth;
			    }

		 




// -->
</script>
        <style type="text/css">
            .FadingTooltip { BORDER-RIGHT: darkgray 1px outset; BORDER-TOP: darkgray 1px outset; FONT-SIZE: 12pt; BORDER-LEFT: darkgray 1px outset; WIDTH: auto; COLOR: black; BORDER-BOTTOM: darkgray 1px outset; HEIGHT: auto; BACKGROUND-COLOR: lemonchiffon; MARGIN: 3px 3px 3px 3px; padding: 3px 3px 3px 3px; borderBottomWidth: 3px 3px 3px 3px }
            .style1
            {
                height: 105px;
            }
            .style2
            {
                font-family: Tahoma;
                font-size: 8pt; /*background-image: url("../Image/Gradient2.PNG");*/;
                background-color: Transparent;
                margin-top: auto;
                vertical-align: top;
                background-repeat: repeat-y;
                width: 121px;
            }
            .style3
            {
                width: 154px;
            }
            .style4
            {
                width: 102px;
            }
            .style5
            {
                font-family: Tahoma;
                font-size: 8pt; /*background-image: url("../Image/Gradient2.PNG");*/;
                background-color: Transparent;
                margin-top: auto;
                vertical-align: top;
                background-repeat: repeat-y;
                width: 75px;
            }
            .style6
            {
                font-family: Tahoma;
                font-size: 8pt;
                background-color: Transparent;
                margin-top: auto;
                vertical-align: top;
                height: 13px;
                width: 108px;
            }
            .style7
            {
                width: 108px;
            }
            .style8
            {
                width: 144px;
            }
            .style9
            {
                font-family: Tahoma;
                font-size: 8pt; /*background-image: url("../Image/Gradient2.PNG");*/;
                background-color: Transparent;
                margin-top: auto;
                vertical-align: top;
                background-repeat: repeat-y;
                width: 144px;
            }
            .style11
            {
                font-family: Tahoma;
                font-size: 8pt;
                background-color: Transparent;
                margin-top: auto;
                vertical-align: top;
                height: 13px;
            }
            #table1
            {
                width: 58%;
            }
        </style>
        
			
        
        
        
        
        
        
        
        
</head>
<body class="textcells">
        <form id="form1" runat="server">
        <div id="print_area">
         <table runat="server" id="table1">
        <tr>
            <td class="style15" align="center">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Verdana" 
                    Font-Size="12pt" Text="JCT00LTD"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td class="style15" align="center">
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Verdana" 
                    Font-Size="12pt" Text="JCT LIMITED, PHAGWARA"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td class="style15" align="center">
                <asp:Label ID="heading" runat="server" Font-Bold="True" Font-Names="verdana" 
                    Font-Size="12pt"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td class="style15" align="center">
                <asp:Label ID="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" 
                    Text="Dated:"></asp:Label>
&nbsp;<asp:Label ID="lbldate" runat="server" Font-Names="Verdana" Font-Size="8pt" Text="Label" 
                    Width="98px"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td class="style1" align="center">
                        <table style="width:47%;" class="textcells">
                    <tr>
                        <td align="left" class="style2">
                            <asp:Label ID="Param1Heading" runat="server" Font-Bold="True" Font-Names="verdana" 
                                Font-Size="8pt" Width="84px"></asp:Label>
                        </td>
                        <td class="style4" align="left">
                            <asp:Label ID="Param1Value" runat="server" Font-Bold="False" 
                                Font-Names="verdana" Font-Size="8pt"></asp:Label>
                        </td>
                        <td align="left" class="style5">
                            <asp:Label ID="Param2Heading" runat="server" Font-Bold="True" Font-Names="verdana" 
                                Font-Size="8pt" Width="75px"></asp:Label>
                        </td>
                        <td class="style7" align="left">
                            <asp:Label ID="Param2Value" runat="server" Font-Bold="False" 
                                Font-Names="verdana" Font-Size="8pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Param3Heading" runat="server" Font-Bold="True" Font-Names="verdana" 
                                Font-Size="8pt" Width="130px"></asp:Label>
                        </td>
                        <td class="style4" align="left">
                            <asp:Label ID="Param3Value" runat="server" Font-Bold="False" 
                                Font-Names="verdana" Font-Size="8pt"></asp:Label>
                        </td>
                        <td class="style5" align="left">
                            <asp:Label ID="Param4Heading" runat="server" Font-Bold="True" Font-Names="verdana" 
                                Font-Size="8pt" Width="130px"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:Label ID="Param4Value" runat="server" Font-Bold="False" 
                                Font-Names="verdana" Font-Size="8pt"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
              <td style="font-weight: 700" class="style16">
                 <asp:chart id="Chart1" runat="server" Height="700px" Width="1150px"   
                Palette="BrightPastel"   imagetype="Png" BorderDashStyle="Solid"  
                BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" 
                backcolor="#D3DFF0" BorderColor="26, 59, 105" 
                ImageLocation="chart_0_0.png" ImageStorageMode="UseImageLocation"                >
                    <legends>
                            <asp:Legend IsTextAutoFit="True" Name="Default" BackColor="Transparent" 
                                Font="Trebuchet MS, 8.25pt, style=Bold" LegendStyle="Row" Docking="Top"></asp:Legend>
                   </legends>
                <borderskin skinstyle="Emboss"></borderskin>

                <series>
                                                      
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    <AxisY LineColor="64, 64, 64, 64">
                                                                  <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                                      </AxisY>
                                                      <AxisX IsMarginVisible="False" LineColor="64, 64, 64, 64" 
                            LabelAutoFitStyle="LabelsAngleStep90" Interval="1"                           >
                                                      
                                                            <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                                      </AxisX>
                    </asp:ChartArea>
                </chartareas>
            </asp:chart></td> </tr></table></div><img id = "IMG1" src="Image/print_ico.gif" alt = "Print Chart" onclick="JavaScript:printPartOfPage('print_area');"  />

 
</form>
