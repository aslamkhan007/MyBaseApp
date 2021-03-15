<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Sticker.aspx.vb" Inherits="Sticker" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" type="text/css" href="../stylesheets/stylesheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/formatingsheet.css" />
    <style type="text/css">



.ButtonBack
{
    /*background: url(../Image/GlossyBlackButtonsm.png);
    color: #FFFFFF;
    border-style : none;
    font-family : Tahoma;
    font-size: 8pt;
    font-weight : bold;     
    height : 28px;   
    width : 124px     
    */
        border-style: none;
            border-color: inherit;
            border-width: medium;
background-image : url('Image/GlossyNormalButton.png');
            font-family : Tahoma;
            font-size : 8pt;
            font-weight : bold;
            text-align : center;
    
            color : White;
            display:inline-block;
            width : 84px;
            height: 22px;   
    
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
      
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
         
    </div>
    <table style="width:100%;">
        <tr>
            <td align="center" style="background-image: url('Image/GlassBarNormal.PNG')" 
                width="100%">
                            <asp:Button ID="cmdGetReport" runat="server" CssClass="ButtonBack" 
                    BackColor="ControlDarkDark"  Font-Names="Tahoma"
                                Text="Get Stickers" />
                            &nbsp;<asp:Button ID="Close" runat="server" CssClass="ButtonBack" 
                    BackColor="ControlDarkDark"  Font-Names="Tahoma"
                                Text="Close" PostBackUrl="~/Emp_Home.aspx" />
            </td>
        </tr>
        <tr>
            <td>
       
        <cr:crystalreportviewer id="CrystalReportViewer2" runat="server" autodatabind="true" 
                    BestFitPage="False" DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                    EnableParameterPrompt="False"></cr:crystalreportviewer>
        <cr:crystalreportsource id="CrystalReportSource2" runat="server"></cr:crystalreportsource>
                     
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
