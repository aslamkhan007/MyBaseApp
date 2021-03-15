<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CrystalPopUp.aspx.vb" Inherits="CrystalPopUp" title="PopUp" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
   <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
        <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true" BestFitPage="False" DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"></cr:crystalreportviewer>
        <cr:crystalreportsource id="CrystalReportSource1" runat="server"></cr:crystalreportsource>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="CrystalReportViewer1" />
            </Triggers>
        </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
