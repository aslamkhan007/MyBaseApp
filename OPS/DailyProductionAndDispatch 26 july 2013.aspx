<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="DailyProductionAndDispatch.aspx.vb" Inherits="DailyProductionAndDispatch"
    Title="Daily Production And Dispatch Report" MaintainScrollPositionOnPostback="true"
    EnableEventValidation="false" %>

 

 <%@ Register assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

 

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script type="text/javascript">
  </script>

     <table style="width: 100%;">
         <tr>
             <td class="tableheader" colspan="3" style="height: 37px">
                 &nbsp;Daily Production And Dispatch Report</td>
         </tr>
         <tr>
             <td colspan="3">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    BestFitPage="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                    ReportSourceID="CrystalReportSource1" HasToggleGroupTreeButton="False"  
                     Height="800px" Width="1200px" />
             </td>
         </tr>
         <tr>
             <td>
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="ProductionAndDispatch.rpt">
                    </Report>
                </CR:CrystalReportSource>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
     </table>

</asp:Content>