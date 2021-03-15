<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="jct_ops_jobwork_common_Report.aspx.vb" Inherits="OPS_jct_ops_jobwork_common_Report" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="2">
                 &nbsp;JOBWORK 
                 INVOICE
                REPORT:</td>
        </tr>
        <tr>
            <td class="labelcells">            
                <asp:Label ID="lblEinvNo" runat="server" Text="Invoice No"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEinvNo" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>   
                
             <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtEinvNo"   
             ServicePath="~/WebService.asmx"
             ServiceMethod ="jobworkinvoicelist"
             MinimumPrefixLength="1"
             CompletionSetCount="10"
             CompletionInterval="0"
             EnableCaching="true">   
            </cc1:AutoCompleteExtender>          
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:LinkButton ID="lnkBtnView" runat="server" CssClass="buttonc">View
                </asp:LinkButton>           
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                    AutoDataBind="true"  Height="50px" ReportSourceID="CrystalReportSource1" Width="350px" />
                     
                    
            </td>
        </tr>
    </table>
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
    <Report FileName="OPS\jct_ops_jobwork_common_Report.rpt">
     </Report>
    </CR:CrystalReportSource>
</asp:Content>

