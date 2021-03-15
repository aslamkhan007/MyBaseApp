<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="DailyProductionAndDispatch.aspx.vb" Inherits="DailyProductionAndDispatch"
    Title="Daily Production And Dispatch Report" MaintainScrollPositionOnPostback="true"
    EnableEventValidation="false" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%-- Version=10.2.3600.0--%>
<%--Version=13.0.2000.0--%>


 <%@ Register assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

 

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script type="text/javascript">
  </script>
       <table style="width: 100%;">
         <tr>
             <td class="tableheader" colspan="6" style="height: 37px">
                 &nbsp;Daily Production And Dispatch Report</td>
         </tr>
       
         <tr>
             <td class="labelcells">
                 From</td>
             <td style="width: 222px" >
                <asp:UpdatePanel ID="UpdFrom" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtDateFrom" TabIndex="3" runat="server"  CssClass="textbox"
                            Enabled="True" MaxLength="8" AutoPostBack="True"></asp:TextBox>
                        <cc1:MaskedEditValidator ID="MEV2" runat="server" Width="114px" ControlToValidate="TxtDateFrom"
                            Display="Dynamic" ControlExtender="MEE2" TooltipMessage="MM/DD/YYYY" IsValidEmpty="False"
                            EmptyValueMessage="*" InvalidValueMessage="The Date is invalid" ValidationGroup="A"></cc1:MaskedEditValidator>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtDateFrom"
                            Animated="False" Format="MM/dd/yyyy" PopupPosition="TopLeft">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MEE2" runat="server" TargetControlID="TxtDateFrom" MaskType="Date"
                            Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
             <td class="labelcells">
                 To</td>
            <td style="width: 250px" >
                  <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox" Enabled="True" MaxLength="8"
                            TabIndex="3" Width="70px"></asp:TextBox>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MEE3"
                            ControlToValidate="txtDateTo" Display="Dynamic" EmptyValueMessage="*" InvalidValueMessage="The Date is invalid"
                            IsValidEmpty="False" TooltipMessage="MM/DD/YYYY" ValidationGroup="A" Width="114px"></cc1:MaskedEditValidator>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False" Format="MM/dd/yyyy"
                            PopupPosition="TopLeft" TargetControlID="txtDateTo">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MEE3" runat="server" Mask="99/99/9999" MaskType="Date"
                            TargetControlID="txtDateTo">
                        </cc1:MaskedEditExtender>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
             <td>
              <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                <ContentTemplate>
                            <asp:Button ID="BtnFetch" runat="server" BackColor="Black" CssClass="ButtonBack" Text="Fetch"
                                 />
                                </ContentTemplate>
                                </asp:UpdatePanel>
                        </td>
         </tr>
         <tr>
             <td colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <img alt="" src="../CostingSystemTest/Image/loading.gif" style="width: 70px; height: 10px" />
                        &nbsp;
                        <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="Please Wait..."></asp:Label>
                    </ProgressTemplate>
                </asp:UpdateProgress></td>
              
         </tr>
     </table>
     <table style="width: 100%;">
         
         <tr>
             <td colspan="3">
      
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    BestFitPage="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                    ReportSourceID="CrystalReportSource1" HasToggleGroupTreeButton="False"  
                     Height="800px" Width="900px" ToolPanelView="None" />
                    
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