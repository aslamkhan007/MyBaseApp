<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditDevelopmentFeedbackForm.aspx.cs" Inherits="OPS_EditDevelopmentFeedbackForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 138px;
        }
        .style2
        {
            width: 119px;
        }
        .style3
        {
            width: 125px;
        }
        .style4
        {
            width: 142px;
        }
        .style5
        {
            width: 68px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
     <script type="text/javascript">
         function CloseAndRebind(args) {
             GetRadWindow().BrowserWindow.refreshGrid(args);
             GetRadWindow().close();
         }

         function GetRadWindow() {
             var oWindow = null;
             if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
             else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

             return oWindow;
         }

         function CloseWindow() {
             GetRadWindow().close();
         }

        </script>
        <asp:ScriptManager ID="ScriptManager2" runat="server" />
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Vista" DecoratedControls="All" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
         <asp:Panel ID="pnllabel" Visible="false" runat="server">

            <table style="width:100%;">
             <tr>
                 <td class="style1">
                     <asp:Label ID="Label1" runat="server" Text="Yarn Availability"></asp:Label>
                 </td>
                 <td class="style2">
                        <asp:DropDownList ID="YarnAvailablityDD" runat="server">
                         <asp:ListItem Value="Y">Yes</asp:ListItem>
                         <asp:ListItem Value="N">No</asp:ListItem>           
                        </asp:DropDownList></td>
                 <td class="style3">
                     <asp:Label ID="Label2" runat="server" Text="Loom Allocation"></asp:Label>
                 </td>
                 <td>
                        <asp:DropDownList ID="LoomAllocationDD" runat="server">
                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                         <asp:ListItem Value="N">No</asp:ListItem>                
                        </asp:DropDownList></td>
             </tr>
             <tr>
                 <td class="style1">
                     <asp:Label ID="Label3" runat="server" Text="Greige"></asp:Label>
                 </td>
                 <td class="style2">
                        <asp:DropDownList ID="GreigeDD" runat="server">
                           <asp:ListItem Value="Y">Yes</asp:ListItem>
                         <asp:ListItem Value="N">No</asp:ListItem>               
                        </asp:DropDownList></td>
                 <td class="style3">
                     <asp:Label ID="Label4" runat="server" Text="SPL"></asp:Label>
                 </td>
                 <td>
                        <asp:DropDownList ID="SPLDD" runat="server">
                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                         <asp:ListItem Value="N">No</asp:ListItem>                
                        </asp:DropDownList></td>
             </tr>
             <tr>
                 <td class="style1">
                     <asp:Label ID="Label5" runat="server" Text="Dyed"></asp:Label>
                 </td>
                 <td class="style2">
                        <asp:DropDownList ID="DyedDD" runat="server">
                           <asp:ListItem Value="Y">Yes</asp:ListItem>
                         <asp:ListItem Value="N">No</asp:ListItem>                   
                        </asp:DropDownList></td>
                 <td class="style3">
                     <asp:Label ID="Label6" runat="server" Text="Prod. Cycle"></asp:Label>
                 </td>
                 <td>
                        <asp:DropDownList ID="ProdCycleDD" runat="server">
                           <asp:ListItem Value="Y">Yes</asp:ListItem>
                         <asp:ListItem Value="N">No</asp:ListItem>                  
                        </asp:DropDownList></td>
             </tr>
             <tr>
                 <td class="style1">
                     <asp:Label ID="Label9" runat="server" Text="QC Reference"></asp:Label>
                 </td>
                 <td class="style2">
                        <asp:DropDownList ID="QCReferenceDD" runat="server" 
                            OnSelectedIndexChanged="QCReferenceDD_SelectedIndexChanged" AutoPostBack="True">
                         <asp:ListItem Value="Y">Yes</asp:ListItem>
                         <asp:ListItem Value="N" Selected="True">No</asp:ListItem>           
                        </asp:DropDownList></td>
                 <td class="style3">
                     <asp:Label ID="Label7" runat="server" Text="Expected Date"></asp:Label>
                 </td>
                 <td>
                  <asp:TextBox ID="txtExpectedDt" runat="server" Width="80px"></asp:TextBox>

                     <cc1:CalendarExtender ID="txtExpectedDt_CalendarExtender" runat="server" 
                         TargetControlID="txtExpectedDt">
                     </cc1:CalendarExtender>

                     <telerik:RadDatePicker ID="txt_ExpectedDate" Runat="server"  Visible="False" ShowPopupOnFocus="True" 
                        Skin="Default" Culture="en-US" Width="100px">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="Windows7"></Calendar>

                        <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40px" Width="100px"  ></DateInput>

                        <DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>

                    </telerik:RadDatePicker>
                </td>
             </tr>
             <tr runat="server" id="tr_QCRemarks"  visible="false">
                 <td class="style1">
                     <asp:Label ID="lbl_QCRemarks" runat="server"  Text="QC Remarks"></asp:Label>
                 </td>
                 <td colspan="3">
                    <telerik:RadTextBox ID="txt_QCRemarks" runat="server"  Height="50px" Width="250px" TextMode="MultiLine"></telerik:RadTextBox></td>
             </tr>
             <tr>
                 <td class="style1">
                     <asp:Label ID="Label11" runat="server" Text="Remarks"></asp:Label>
                 </td>
                 <td colspan="3">
                    <telerik:RadTextBox ID="txt_Remarks" runat="server" Height="100px" Width="300px" 
                         TextMode="MultiLine"></telerik:RadTextBox></td>
             </tr>
             <tr>
                 <td class="style1">
                   <telerik:RadButton ID="btn_Submit" Text="Submit" runat="server" 
                         onclick="btn_Submit_Click" ValidationGroup="Group1"></telerik:RadButton> 
                   <telerik:RadButton ID="btn_Close" Text="Close" runat="server" 
                         onclick="btn_Close_Click"></telerik:RadButton> </td>
                 <td colspan="3">
                     &nbsp;</td>
             </tr>
        </table>

         </asp:Panel>
        
          <asp:Label ID="lbl_Message" runat="server" Visible="False" ForeColor="#CC0000"></asp:Label>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="QCReferenceDD" 
                EventName="SelectedIndexChanged" />
        </Triggers>
        </asp:UpdatePanel>

        <asp:Panel ID="pnlTaskStatus" Visible="false" runat="server">
        <table>
              <tr>
                 <td class="style5">
                     <asp:Label ID="Label8" runat="server" Text="Remarks"></asp:Label>
                 </td>
                 <td>
                    <telerik:RadTextBox ID="radTextboxRemarks" runat="server" Height="50px" Width="250px" 
                         TextMode="MultiLine"></telerik:RadTextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                         ControlToValidate="radTextboxRemarks" ErrorMessage="** Required Field" 
                         ValidationGroup="Group2"></asp:RequiredFieldValidator>
                  </td>
             </tr>
         </table>
            <table>
                <tr>
                    <td class="style4">
                        <telerik:RadButton ID="btnTaskStatusSubmit" runat="server" 
                            onclick="btnTaskStatusSubmit_Click" Text="Submit" ValidationGroup="Group2">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnTaskStatusCancel" runat="server" 
                            onclick="btnTaskStatusCancel_Click" Text="Close">
                        </telerik:RadButton>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
          <asp:Label ID="lbl_StatusMessage" runat="server" Visible="False" ForeColor="#CC0000"></asp:Label>
        </asp:Panel>



    </div>
    </form>
</body>
</html>
