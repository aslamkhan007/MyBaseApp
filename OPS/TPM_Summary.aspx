<%@ Page Title="" Language="C#"   AutoEventWireup="true" CodeFile="TPM_Summary.aspx.cs" Inherits="OPS_TPM_Summary" %>

 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

  

 <html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>

     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=pnlContents.ClientID %>");
             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><title>TPM Summary</title>');
             printWindow.document.write('</head><body >');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('</body></html>');
             printWindow.document.close();
             setTimeout(function () {
                 printWindow.print();
             }, 500);
             return false;
         }
    </script>

</head>
<body>
    <form id="form1" runat="server">
     <asp:Panel id="pnlContents" runat = "server">

           <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
   
    <table style="width:100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label16" runat="server" Text="TPM Summary (as on date)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <telerik:RadButton ID="radbtnExcel"  runat="server" onclick="radbtnExcel_Click"
                    Text="Excel">
                </telerik:RadButton>
           
                <telerik:RadButton ID="radbtnPrint" runat="server" Visible="false" onclick="radbtnPrint_Click" 
                    Text="Print">
                </telerik:RadButton>
 
 

           
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None" 
                    onitemdatabound="RadGrid1_ItemDataBound" ShowFooter="True">
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
</MasterTableView>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>

       </asp:Panel>


          <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick = "return PrintPanel();" />

         </form>
</body>
</html>
 

