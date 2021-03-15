<%@ Page Title="" Language="VB" MasterPageFile="~/Guest_Login_Rquest/GuestMaster.master" AutoEventWireup="false"
 CodeFile="Guest_Internet_Login_Request.aspx.vb" Inherits="Guest_Login_Rquest_Guest_Internet_Login_Request" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%-- <script type="text/javascript">
     function onListPopulated() {

         var completionList = $find("txtEmployee_AutoCompleteExtender").get_completionList();
         completionList.style.width = 'auto';
     }
 </script>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="left1">
                 
    <table style="width: 100%;">

        <tr>
            <td  style="width: 265px">
              <div id="Div10">
                    <h3 align="center">  
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False">Already Registered Click Here..</asp:LinkButton>
                       
                        <cc1:ModalPopupExtender ID="LinkButton1_ModalPopupExtender" runat="server" 
                            TargetControlID="LinkButton1" BackgroundCssClass="modalbackground" 
                            CancelControlID="btnCancel" Drag="True" DropShadow="True" 
                            PopupControlID="Panel4">
                        </cc1:ModalPopupExtender>
                       
                    </h3>
                    </div>
                </td>
            <td   style="width: 115px">
                &nbsp;</td>
            <td  style="width: 66px">
              
                &nbsp;</td>
            <td>
              
                &nbsp;</td>
        </tr>
         </table>

            <table style="width: 100%;">
        <tr>
            <td  style="width: 50px">
                	&nbsp;</td>
            <td  style="width: 161px">
                	<div id="Di3">
                    <h2>  <asp:Label ID="Label1" runat="server" Text="Enter Name"></asp:Label></h2>
                    </div>
              
                
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                 <asp:TextBox ID="txtName" runat="server" CssClass="textbox" Columns="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                </ContentTemplate>
                </asp:UpdatePanel>
               
            </td>
            <td>
              
            </td>
        </tr>
        <tr>
            <td  style="width: 50px">
                 &nbsp;</td>
            <td  style="width: 161px">
                 <div id="Div8">
                    <h2>  <asp:Label ID="Label2" runat="server" Text="E-mail"></asp:Label></h2>
                    </div>
                
            </td>
            <td>
              <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                  <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Columns="30"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                     ControlToValidate="txtEmail" ErrorMessage="Enter valid Email Address" 
                     ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                     ValidationGroup="A"></asp:RegularExpressionValidator>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                     ControlToValidate="txtEmail" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                </ContentTemplate>
                </asp:UpdatePanel>
               
            </td>
            <td>
              
            </td>
        </tr>
        <tr>
            <td  style="width: 50px">
                 &nbsp;</td>
            <td  style="width: 161px">
                 <div id="Div1">
                    <h2>   <asp:Label ID="Label3" runat="server" Text="Mobile No."></asp:Label></h2>
                    </div>
                   
                  
            </td>
            <td>
              <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtCountryCode" runat="server" ToolTip="Enter Country Code" 
                        Width="50px" CssClass="textbox" MaxLength="4"></asp:TextBox>
                 <asp:TextBox ID="txtMobile" runat="server" CssClass="textbox" MaxLength="10" 
                    Columns="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtMobile_FilteredTextBoxExtender" 
                    runat="server" FilterType="Numbers" TargetControlID="txtMobile">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtMobile" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="txtCountryCode" ErrorMessage="Country Code Required " 
                        ValidationGroup="A"></asp:RequiredFieldValidator>
                </ContentTemplate>
                </asp:UpdatePanel>
               
            </td>
          
        </tr>
        <tr>
            <td  style="width: 50px">
                 &nbsp;</td>
            <td  colspan="2">
                   <div id="Div3">
                    <h3>   <asp:Label ID="Label5" runat="server" 
                            Text="For International Guests please check your email for further details."></asp:Label></h3>
                    </div>
            </td>
            <td>
              
                &nbsp;</td>
        </tr>
     
         <tr>
            <td  style="width: 50px">
                 &nbsp;</td>
            <td  style="width: 161px">
                 <div id="Div2">
                    <h2>    <asp:Label ID="Label4" runat="server" Text="Company"></asp:Label> </h2>
                    </div>
                 
              
            </td>
            <td>
              <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>
                  <asp:TextBox ID="txtCompany" runat="server" CssClass="textbox" Columns="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtCompany" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                </ContentTemplate>
                </asp:UpdatePanel>
              
            </td>
            <td>
              
            </td>
        </tr>
         <tr>
            <td  style="width: 50px">
                    &nbsp;</td>
            <td  style="width: 161px">
                    <div id="Div11">
                    <h2>  <asp:Label ID="Label16" runat="server" Text="Visting Employee"></asp:Label> </h2>
                    </div>
               </td>
            <td>
           
         
                        <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" Width="140px"></asp:TextBox>
                        <div id="divwidth" style="display:none;">   
                            <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="5" MinimumPrefixLength="1" 
                            ServiceMethod="GetEmployee_jatin" TargetControlID="txtEmployee" 
                            CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList">
                        </cc1:AutoCompleteExtender></div>  
               </td>
            <td>
              
                &nbsp;</td>
        </tr>
         <tr>
            <td  style="width: 50px">
                 &nbsp;</td>
            <td  style="width: 161px">
                 <div id="Div5">
                    <h2>  <asp:Label ID="Label7" runat="server">Date of Visiting</asp:Label> </h2>
                    </div>
               
            </td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" Columns="10"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                    TargetControlID="txtDate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td>
              
            </td>
        </tr>
         <tr>
            <td  style="width: 50px">
                
                &nbsp;</td>
            <td  style="width: 161px">
                
                <div id="Div6">
                    <h2>   <asp:Label ID="Label8" runat="server" Text="Stay Duration"></asp:Label></h2>
                    </div>
               
            </td>
            <td>
                <asp:TextBox ID="txtStay" runat="server" MaxLength="3" CssClass="textbox" 
                    Columns="5"></asp:TextBox>
                 <asp:Label ID="Label11" runat="server" Text="Days"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtStay" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td>
              
            </td>
        </tr>
         <tr>
            <td  style="width: 50px; height: 16px; vertical-align: top;" >
                &nbsp;</td>
            <td  style="width: 161px; height: 16px; vertical-align: top;" >
                <div id="Div7">
                    <h2>    <asp:Label ID="Label9"  runat="server" Text="Purpose of Visit"></asp:Label> </h2>
                    </div>
                
             
            </td>
            <td>
                <asp:TextBox ID="txtPurpose" runat="server" Height="62px" TextMode="MultiLine" 
                    Width="407px" MaxLength="2000" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="txtPurpose" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td>
              
            </td>
        </tr>
         <tr>
            <td align="center" style="width: 50px">
                
                &nbsp;</td>
            <td colspan="3" align="center">
                
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button ID="Button1" runat="server" CssClass="cssbutton" Text="Submit" 
                            ValidationGroup="A" />
                        <asp:Button ID="Button3" runat="server" CausesValidation="false" 
                            CssClass="cssbutton" Text="Reset" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
             </td>
        </tr>
       
         <tr>
            <td align="center" style="width: 50px">
                &nbsp;</td>
            <td colspan="3" align="center">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel3" runat="server" Visible =false>
                       <asp:Label ID="lblerror" runat="server" 
                    Text="No UserName present ,please contact IT-HelpDesk" Font-Bold="True"></asp:Label>
                <br />
                <br />
                                <asp:Label ID="lblEnquiry" runat="server" 
                                    
                                    
                    
                            Text="For any problem note down your RequestID and forward it to IT-HelpDesk at ext. - 4212 or 9888988740 , 9915846943. Support team will help you to get the internet access. " Font-Bold="True" 
                  ></asp:Label>
                    </asp:Panel>
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="Button3" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
             </td>
        </tr>
         </table>
            <table style="width: 100%;">
                <tr>
                    <td style="background-position: center; height: 20px; background-image: url('Images/Footer_Frame_Large.png');
                                    background-repeat: no-repeat;">
                     </td>
                </tr>
                </table>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 76px">
                            &nbsp;
                        </td>
                        <td>
                           <asp:Panel ID="Panel2" runat="server" Visible="False" Width="400px" 
                    BorderColor="Black" BorderWidth="1px">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 47px">
                                &nbsp;</td>
                            <td colspan="2">
                                <asp:Label ID="Label18" runat="server" Text="Verify Security Code" 
                                    Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 47px">
                                &nbsp;
                            </td>
                            <td style="width: 120px">
                                <asp:Label ID="Label17" runat="server" Text="Enter Code" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCode" runat="server" CssClass="textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                    ControlToValidate="txtCode" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnSubmitCode" runat="server" CssClass="cssbutton" 
                                    Text="Submit" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 47px">
                                &nbsp;
                            </td>
                            <td style="width: 120px">
                                &nbsp;</td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Button3" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 211px">
                                &nbsp;</td>
                            <td colspan="2">
                                <asp:Label ID="Label12" runat="server" Text="Detail for Internet Login :" 
                                    Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 211px">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label15" runat="server" Text="RequestID" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRequestID" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 211px">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="UserName" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblUserName" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 211px">
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label14" runat="server" Text="Password" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPassword" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 211px">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSubmitCode" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Button3" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Width="500px">
                <table style="width: 100%;">
                    <tr>
                        <td class="text" colspan="3">
                            &nbsp;
                            <asp:Label ID="Label19" runat="server" Font-Bold="True" 
                                Text="Search Entering your mobile number"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 96px">
                            &nbsp;
                        </td>
                        <td style="width: 240px">
                            <asp:Label ID="Label20" runat="server" Font-Bold="True" 
                                Text="Enter Mobile Number"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRegMobile" runat="server" Columns="10" CssClass="textbox" 
                                MaxLength="10"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtRegMobile_FilteredTextBoxExtender" 
                                runat="server" FilterType="Numbers" InvalidChars="0123456789" 
                                TargetControlID="txtRegMobile">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 96px">
                            &nbsp;</td>
                        <td style="width: 151px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" CssClass="cssbutton" Text="Search" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="cssbutton" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>  
            </ContentTemplate>
            </asp:UpdatePanel>
          
         </div>
</asp:Content>


