<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="MasterPage.master" CodeFile="TransportRequisition.aspx.cs" Inherits="TransportRequisition" title="Transport Requisitions" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
    function NumberOnly() {
        var AsciiValue = event.keyCode
        if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
            event.returnValue = true;
        else
            event.returnValue = false;
    }
       
        </script>
 <table width="100%">
      <tr>
            <td colspan="4" class="tableheader">
                <asp:Label ID="Label2" runat="server"  Text="Transport Requistion"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>

        <tr>
            <td class="labelcells" style="width: 145px">
                <asp:Label ID="lblvehicle" runat="server" Text="Vehicle required by" Width="139px"></asp:Label></td>
        
               <td style="height: 26px">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="Txtrequiredby" runat="server" CssClass="textbox" Width="200px" TabIndex="0"></asp:TextBox>
                         <div id="div4" style="display: none;">
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server"
                        CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="GetEmpTransport"
                        CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                        TargetControlID="Txtrequiredby">
                    </cc1:AutoCompleteExtender>
                </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txtrequiredby"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>


            <td class="labelcells" style="width: 26px">
                <asp:Label ID="lblslno" runat="server" Text="Sl.No"></asp:Label>
                </td>
            <td class="textcells" style="width: 200px" >
                <asp:TextBox ID="Txtslno" runat="server" Width="78px" CssClass="textbox" 
                    Enabled="False" ></asp:TextBox> &nbsp;
                     <asp:Button ID="btnfetch" runat="server" Text="Fetch" CssClass="ButtonBack" 
                    Height="21px" Width="84px" BackColor="Black" onclick="btnfetch_Click" 
                    CausesValidation="False" /> &nbsp;<asp:Label ID="Srnomsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
           <%-- 21 May 2015--%>
            <td class="labelcells" style="width: 50px">
                <asp:Label ID="Label6" runat="server" Text="Date"></asp:Label>
                </td>
            <td class="textcells" >
                <asp:TextBox ID="txtTodayDate" runat="server" Width="78px" CssClass="textbox" 
                    Enabled="False"></asp:TextBox>
            </td>
              <%-- 21 May 2015--%>

        </tr>
        
        <tr>
            <td class="labelcells" style="width: 145px" >
                <asp:Label ID="lblplace" runat="server" Text="Place to be visited (State)" ></asp:Label></td>
            <td class="textcells" style="width: 128px" >
                <asp:DropDownList ID="ddlPlace" runat="server" autopostback="true"
                    onselectedindexchanged="ddlPlace_SelectedIndexChanged">
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPlace"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
           </td>
            <td class="labelcells" style="width: 26px">
                <asp:Label ID="Label3" runat="server" Text="City" Font-Bold="True" ></asp:Label></td>
            <td class="textcells" style="width: 130px">
                     <asp:DropDownList ID="ddlCity" runat="server">
                     </asp:DropDownList>
               
            </td>
        </tr>

         <tr>
            <td class="labelcells" style="width: 145px" >
                <asp:Label ID="Label4" runat="server" Text="Railway Station/Airport/Village" Font-Bold="True" ></asp:Label></td>
                 <td class="textcells">
              

                <asp:DropDownList ID="ddlExactLocation" runat="server" CssClass="combobox" AutoPostBack="false"
                            Width="130px" >
                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                            <asp:ListItem Text="Railway Station" Value="Railway Station"></asp:ListItem>
                                <asp:ListItem Text="Airport" Value="Airport"></asp:ListItem>
                                 <asp:ListItem Text="Village" Value="Village"></asp:ListItem>
                               
                                
                            </asp:DropDownList>

            </td>
             <td class="labelcells" style="width: 185px" >
                <asp:Label ID="Label5" runat="server" Text="Other" Font-Bold="True" ></asp:Label></td>
                 <td class="textcells" style="width: 130px">
              

                <asp:TextBox ID="txtOther" Visible="true" runat="server" CssClass="textbox" ></asp:TextBox>

            </td>
             <td class="labelcells" style="width: 101px" >
                 &nbsp;</td>
                 <td class="textcells">
                     &nbsp;</td>
           
        </tr>
        <tr>
            <td class="labelcells" style="width: 145px" >
                <asp:Label ID="lbldtreq" runat="server" Text="Date when required" Font-Bold="True" ></asp:Label></td>
       
             <td class="NormalText" style="width: 152px">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_Date" runat="server" CssClass="textbox" 
                            Width="100px" TabIndex="70"></asp:TextBox>
                        <cc1:CalendarExtender ID="txt_date_CalendarExtender" runat="server" TargetControlID="txt_Date">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="ME1" runat="server" ControlExtender="MEE1"
                            ControlToValidate="txt_Date" Display="Dynamic" InvalidValueMessage="Invalid"
                            IsValidEmpty="true" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" >
                        </cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MEE1" runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txt_Date">
                        </cc1:MaskedEditExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_Date"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </ContentTemplate>
               
                </asp:UpdatePanel>
               
            </td>
            <td style="width: 26px" class="labelcells" >
                <asp:Label ID="Label1" runat="server" Text="Time" ></asp:Label></td>
            <td class="textcells" style="width: 130px" >
                <ew:timepicker id="txtrequiredtime" runat="server" Width="90px" 
                    MinuteInterval="FifteenMinutes" PopupLocation="Bottom"  CssClass="textbox">
                    <ButtonStyle CssClass="ButtonBack" Height="20px" Width="15px" />
                </ew:timepicker>
               
            </td>
        </tr>
       
        <tr>
            <td class="labelcells" style="width: 145px" >
                <asp:Label ID="lblpurpose" runat="server" Text="Purpose of visit" ></asp:Label></td>
            <td class="textcells" style="width: 128px" >
            
              <asp:DropDownList ID="ddlpurpose" runat="server" CssClass="combobox" AutoPostBack="false"
                            Width="130px" >
                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                            <asp:ListItem Text="Official" Value="Official"></asp:ListItem>
                                <asp:ListItem Text="Personal" Value="Personal"></asp:ListItem>
                               
                                
                            </asp:DropDownList>
            </td>
            <td style="width: 26px" class="labelcells" >
                <asp:Label ID="Label16" runat="server" Text="No of Persons Accompanying " 
                    Width="170px"></asp:Label>
            </td>
            <td class="textcells" style="width: 130px" >
                <asp:TextBox ID="txtNo_of_Persons" runat="server" CssClass="textbox" 
                    MaxLength="3" Width="100px"  onkeypress="return NumberOnly()"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNo_of_Persons"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 145px" >
                <asp:Label ID="Label17" runat="server" Text="Vehicle Prefrences"></asp:Label>
            </td>
            <td class="textcells" style="width: 128px" >
                <asp:DropDownList ID="DdlVehicle" runat="server" CssClass="combobox" 
                    Width="140px">
                </asp:DropDownList>
            </td>
            <td class="labelcells" >
                 <asp:Label ID="Label7" runat="server" Text="KM Run"></asp:Label></td>
            <td style="width: 130px" >
                <asp:TextBox ID="txtkms" runat="server" CssClass="textbox" 
                    MaxLength="3" Width="103px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 145px" >
                <asp:Label ID="lbldtreturn" runat="server" Text="Date Of Return" ></asp:Label></td>
            <td class="NormalText" style="width: 152px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtexpected" runat="server" CssClass="textbox" 
                            Width="100px" TabIndex="70"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtexpected">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MEE1"
                            ControlToValidate="txtexpected" Display="Dynamic" InvalidValueMessage="Invalid"
                            IsValidEmpty="true" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" >
                        </cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txtexpected">
                        </cc1:MaskedEditExtender>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtexpected"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator> 
                    </ContentTemplate>
                  
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td >
            </td>
        </tr>
        <tr>
 <td class="labelcells" style="width: 145px" >
                <asp:Label ID="lbltimereturn" runat="server" Text="Time Of Return" Font-Names="Tahoma" Font-Size="8pt" Font-Bold="False" ></asp:Label>
               
</td>
            
            <td style="width: 130px">
                <ew:timepicker id="txtreturntime" runat="server" font-names="Tahoma" font-size="Smaller"
                    width="85px"  MinuteInterval="FifteenMinutes" CssClass="textbox"  >
                    <ButtonStyle CssClass="ButtonBack" Height="20px" Width="15px" />
                </ew:timepicker>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 145px" >
                <asp:Label ID="lblreport" runat="server" Text="Where the vehicle should report" ></asp:Label></td>
            <td class="textcells" style="width: 128px" >
                <asp:TextBox ID="txtreport" runat="server" CssClass="textbox" Width="183px" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtreport"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator></td>
           <td class="labelcells" style="width: 145px" >
                <asp:Label ID="Label8" runat="server" Text="Driver Name" ></asp:Label></td>
           

<td style="height: 26px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDriver" runat="server" CssClass="textbox" Width="200px" TabIndex="0"></asp:TextBox>
                         <div id="div1" style="display: none;">
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                        CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="GetDriverName"
                        CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                        TargetControlID="txtDriver">
                    </cc1:AutoCompleteExtender>
                </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDriver"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>


                
        </tr>

        <tr>
            <td class="labelcells" colspan="4" >
                <asp:Panel ID="Panel1" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:Label ID="lblchargeable" runat="server" Text="Chargeable"></asp:Label>
                            </td>
                            <td class="textcells">
                                <asp:RadioButtonList ID="rblcharge" runat="server" Font-Names="Tahoma" 
                                    Font-Size="Smaller" Height="16px" RepeatDirection="Horizontal" Width="145px">
                                    <asp:ListItem Selected="True">Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:Label ID="lblVehicleAlloted" runat="server" Text="Vehicle Alloted"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlVehicleAllocated" runat="server" AutoPostBack="True" 
                                    CssClass="combobox" Width="140px" 
                                    onselectedindexchanged="DdlVehicleAllocated_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="labelcells">
                                <asp:Label ID="lblCarNo" runat="server" Text="Car No."></asp:Label>
                            </td>
                            <td class="textcells">
                                <asp:TextBox ID="txtCarAllocated" runat="server" CssClass="textbox" Enabled="false" ></asp:TextBox>
                            </td>
                            <td class="labelcells">
                                &nbsp;</td>
                            <td class="textcells">
                                &nbsp;</td>
                        </tr>
                       
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 145px" >
            <asp:Label ID="Message" runat="server" Text="" ForeColor="Red"></asp:Label>
             </td>
            <td class="textcells" style="width: 128px" >
                &nbsp;</td>
            <td style="width: 26px" >
                &nbsp;</td>
            <td style="width: 130px" >
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 145px" class="BoundColumn_long" >
            </td>
            <td colspan="2" >
                <asp:Button ID="btnsub" runat="server" Text="Submit" CssClass="ButtonBack" 
                    Height="21px" Width="84px" BackColor="Black" onclick="btnsub_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="ButtonBack" 
                    Height="21px" Width="84px" BackColor="Black" CausesValidation="False" 
                    onclick="btnReset_Click" />
                <asp:Button ID="btnModify" runat="server" Text="Modify" CssClass="ButtonBack" 
                    Height="21px" Width="84px" BackColor="Black" CausesValidation="False" onclick="btnModify_Click"  
                     />
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="ButtonBack" 
                    Height="21px" Width="84px" BackColor="Black" CausesValidation="False" onclick="btnSave_Click"  
                     /></td>
 
            <td style="width: 130px" >
            </td>
        </tr>
    </table>



</asp:Content>