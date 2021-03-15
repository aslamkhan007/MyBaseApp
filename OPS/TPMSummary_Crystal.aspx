<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="TPMSummary_Crystal.aspx.cs" Inherits="OPS_TPMSummary_Crystal" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label16" runat="server" Text="Packing and Dispatch Summary"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkRefresh" runat="server" 
    CssClass="buttonc" onclick="lnkRefresh_Click">Refresh</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
      AutoDataBind="true"
                    BestFitPage="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                    ReportSourceID="CrystalReportSource1" HasToggleGroupTreeButton="False"
                     Height="400px" Width="400px" ToolPanelView="None"  />

    <br />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server" 
        onload="CrystalReportSource1_Load">
          <Report FileName="TpmSummary.rpt">
                    </Report>
    </CR:CrystalReportSource>
   
</scrip t>


</form>

</body>
</html>

