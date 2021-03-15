<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourierCODPreviewMail.aspx.cs" Inherits="Courier_Tracking_System_CourierCODPreviewMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Preview Mail Contents</title>
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
        }
        .style3
        {
            width: 22px;
        }
        .style4
        {
        }
    </style>

        <link rel="stylesheet" type="text/css" href="../stylesheets/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/FormatingSheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/EmpGatewayStyleSheet.css" />
</head>
<body>
   
    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <table style="width:100%;">
            <tr>
                <td class="style3">
                    <asp:Label ID="Label1" runat="server" Text="To"></asp:Label>
                </td>
                <td class="style4">
                  
                  <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtTo1" runat="server" AutoPostBack="True" 
                                            ontextchanged="txtTo1_TextChanged" Width="300px"></asp:TextBox>
                                               <div id="div1" style="display:none;">  
                                            
                                        <cc1:AutoCompleteExtender ID="txtTo1_AutoCompleteExtender" runat="server" 
                                            CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                                            CompletionListElementID="div1" 
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                                            MinimumPrefixLength="1" ServiceMethod="Email_IDs" 
                                            ServicePath="~/WebService.asmx" TargetControlID="txtTo1">
                                        </cc1:AutoCompleteExtender>
                                         
                                        </div>
                                           <asp:CheckBoxList ID="chbEmailIDTo" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="chbEmailIDTo_SelectedIndexChanged">
                                        </asp:CheckBoxList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtTo1" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                  
                  </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label2" runat="server" Text="Cc"></asp:Label>
                </td>
                <td class="style4">
                   
                   <asp:UpdatePanel ID="UpdatePanel20" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCC1" runat="server" AutoPostBack="True" 
                                            ontextchanged="txtCC1_TextChanged" Width="300px"></asp:TextBox>
                                             <div id="div2" style="display:none;">   
                                        <cc1:AutoCompleteExtender ID="txtCC1_AutoCompleteExtender" runat="server" 
                                             CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                                            CompletionListElementID="div2" 
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                                            MinimumPrefixLength="1" ServiceMethod="Email_IDs" 
                                            ServicePath="~/WebService.asmx" TargetControlID="txtCC1">
                                        </cc1:AutoCompleteExtender></div>
                                            
                                        <br />
                                        <asp:CheckBoxList ID="chbEmailIDCC" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="chbEmailIDCC_SelectedIndexChanged">
                                        </asp:CheckBoxList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtCC1" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                   
                   </td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lblContent" runat="server"></asp:Label>
                </td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    <telerik:RadButton ID="radbtnSendMail" runat="server"   SingleClick="true" SingleClickText="Sending Mail..."
                        onclick="radbtnSendMail_Click" Text="Send Email">
                    </telerik:RadButton>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <br />

    </div>
    </form>
    
</body>
</html>
