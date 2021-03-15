<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="ReceiptEntryScreen.aspx.cs" Inherits="Courier_Tracking_System_ReceiptEntryScreen" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="flashmessage"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="3">
                <asp:Label ID="Label18" runat="server" Text="Entry Screen"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 124px">
                <asp:Label ID="Label25" runat="server" Text="Date"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" Columns="10" 
                    MaxLength="10"></asp:TextBox>

                <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                    Format="MM/dd/yyyy" TargetControlID="txtDate">
                </cc1:CalendarExtender>

            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 124px">
                <asp:Label ID="Label22" runat="server" Text="Courier Service"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCourier" runat="server" CssClass="combobox">
                            <asp:ListItem>Blue Dart</asp:ListItem>
                             <asp:ListItem>Blue Dart Apex</asp:ListItem>
                              <asp:ListItem>BLUE DART COD</asp:ListItem>
                            <asp:ListItem>First Flight</asp:ListItem>
                            <asp:ListItem>DHL</asp:ListItem>
                            <asp:ListItem>Fed Ex</asp:ListItem>
                            <asp:ListItem>OnDot</asp:ListItem>
                            <asp:ListItem>Overnight</asp:ListItem>
                            <asp:ListItem>TrackOn </asp:ListItem>
                            <asp:ListItem>TNT</asp:ListItem>
                            <asp:ListItem>UPS</asp:ListItem>
                            <asp:ListItem>Blue Dart Surface</asp:ListItem>
                            <asp:ListItem>DTDC</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 124px">
                <asp:Label ID="Label20" runat="server" Text="Department"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDept" runat="server" CssClass="combobox">
                           <asp:ListItem>Admin</asp:ListItem>
                            <asp:ListItem>Accounts</asp:ListItem>
                            <asp:ListItem>BnglrOffice</asp:ListItem>
                            <asp:ListItem>DSO</asp:ListItem>
                            <asp:ListItem>Logistics</asp:ListItem>
                            <asp:ListItem>Factory</asp:ListItem>
                            <asp:ListItem>Purchase</asp:ListItem>
                            <asp:ListItem>R&amp;D</asp:ListItem>
                            <asp:ListItem>R/W</asp:ListItem>
                            <asp:ListItem>RSO</asp:ListItem>
                            <asp:ListItem>Sale</asp:ListItem>
                            <asp:ListItem>Sports</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView2" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 124px">
                <asp:Label ID="Label19" runat="server" Text="Reciept No."></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtRecieptNo" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtRecieptNo" ErrorMessage="**Field Required" 
                            ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView2" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="lnkDelete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 124px">
                <asp:Label ID="Label21" runat="server" Text="Amount"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="textbox" MaxLength="8"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtAmount" ErrorMessage="**Field Required" 
                            ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView2" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="lnkDelete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
         <tr>
            <td class="NormalText" style="width: 114px">
                <asp:Label ID="Label1" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdRemarks" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtRemarks" TextMode="MultiLine" runat="server" CssClass="textbox" Height="50px" Width="200px" ></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView2" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="lnkDelete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
      
        </table>
    <table>
        <tr>
            <td class="tableheader">
         <asp:Image ID="imgExpand" runat="server" ImageUrl="~/Image/plus.png" Style="margin-right: 5px;" />
                Change Courier Request Date
                 <cc1:CollapsiblePanelExtender ID="cpe" runat="Server" AutoCollapse="False" AutoExpand="True"
                    CollapseControlID="imgExpand" Collapsed="False" CollapsedImage="~/Image/plus.png"
                    CollapsedSize="0" ExpandControlID="imgExpand" ExpandDirection="Vertical" ExpandedImage="~/Image/minus.png"
                    ImageControlID="imgExpand" ScrollContents="false" TargetControlID="pnlExpand" />

            </td>
          
        </tr>

 
     <tr>
         <td>
       <asp:Panel ID="pnlExpand" Width="100%" runat="server" BorderStyle="Solid" BorderWidth="1px">
           <table>
               <tr>
                   <td class="NormalText">
                       <asp:Label ID="Label26" runat="server" Text="Change Courier Date"></asp:Label>
                   </td>
                   <td class="NormalText" colspan="2">
                       <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                           <ContentTemplate>
                               <asp:TextBox ID="txtCourierID" runat="server" CssClass="textbox" ></asp:TextBox>

                               <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/Image/searchBlueSmall.PNG" OnClick="imgSearch_Click" />
                           </ContentTemplate>
                           <Triggers>
                               <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="SelectedIndexChanged" />
                               <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged" />
                               <asp:AsyncPostBackTrigger ControlID="lnkDelete" EventName="Click" />
                           </Triggers>
                       </asp:UpdatePanel>
                   </td>
               </tr>

       <tr>
            <td class="NormalText" style="width: 123px">
                <asp:Label ID="Label27" runat="server" Text="Request Date"></asp:Label>
            </td>
            <td class="NormalText" style="width: 119px">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtRequestDate" runat="server" CssClass="textbox" MaxLength="8"></asp:TextBox>

                                          <asp:RequiredFieldValidator ID="ReqtxtRequestDate" runat="server" 
                ControlToValidate="txtRequestDate" ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>

                        <cc1:CalendarExtender ID="txtRequestDate_CalendarExtender" runat="server" TargetControlID="txtRequestDate">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="imgSearch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 95px">
                <asp:Label ID="Label28" runat="server" Text="Change Date"></asp:Label>
            </td>
            <td class="NormalText">
                        <asp:TextBox ID="txtChangeRequestDate" runat="server" CssClass="textbox" MaxLength="8"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="ReqtxtChangeRequestDate" runat="server" 
                ControlToValidate="txtChangeRequestDate" ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                        <cc1:CalendarExtender ID="txtChangeRequestDate_CalendarExtender" runat="server" TargetControlID="txtChangeRequestDate">
                </cc1:CalendarExtender>
                <asp:UpdatePanel ID="updSaveData" runat="server">
                    <ContentTemplate>
                <asp:ImageButton ID="imgSaveDate" runat="server" ImageUrl="~/Image/save_icon.PNG" 
                            OnClick="imgSaveDate_Click" style="width: 16px" ValidationGroup="mandatory" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
         </table>
       </asp:Panel>
         </td>
        </tr>
           </table>

    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                            onclick="lnkSave_Click1">Save</asp:LinkButton>
                        <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="buttonc" 
                            onclick="lnkUpdate_Click" Enabled="False">Update</asp:LinkButton>
                        <asp:LinkButton ID="lnkSearch" runat="server" CssClass="buttonc">Search</asp:LinkButton>
                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                            BackgroundCssClass="modalBackground" CancelControlID="lnkClose" 
                            PopupControlID="Panel1" TargetControlID="lnkSearch">
                        </cc1:ModalPopupExtender>
                        <asp:LinkButton ID="lnkShow" runat="server" CssClass="buttonc" 
                            onclick="lnkShow_Click">ShowRecord</asp:LinkButton>
                        <asp:LinkButton ID="lnkDelete" runat="server" CssClass="buttonc" 
                            onclick="lnkDelete_Click">Delete</asp:LinkButton>

                        <cc1:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Are your sure ?" TargetControlID="lnkDelete">
                        </cc1:ConfirmButtonExtender>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                  <uc1:flashmessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                            FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true">
                        </uc1:flashmessage>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel9" DisplayAfter="10">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" CssClass="panelbg" Width="100%">
                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                EnableModelValidation="True" 
                                onselectedindexchanged="GridView2_SelectedIndexChanged" Width="100%" 
                                onpageindexchanging="GridView2_PageIndexChanging">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <FooterStyle CssClass="FooterStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkShow" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView2" EventName="PageIndexChanging" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel1" runat="server" Width="50%" CssClass="panelbg" >
        <table style="width:100%;">
            <tr>
                <td class="tableheader" colspan="2">
                    <asp:Label ID="Label23" runat="server" Text="Search Record"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText">
                    <asp:Label ID="Label24" runat="server" Text="Reciept No"></asp:Label>
                </td>
                <td class="NormalText">
                    <asp:TextBox ID="txtSearchRecieptNo" runat="server" CssClass="textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtSearchRecieptNo" ErrorMessage="**Field Required" 
                        ValidationGroup="B"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="buttonbackbar" colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="lnkSearchRecieptNo" runat="server" CssClass="buttonc" 
                                onclick="lnkSearchRecieptNo_Click" ValidationGroup="B">Search</asp:LinkButton>
                            <asp:LinkButton ID="lnkClose" runat="server" CssClass="buttonc">Close</asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="NormalText" colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridView" 
                        EnableModelValidation="True" Width="100%" 
                            onselectedindexchanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <HeaderStyle CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                    </asp:GridView>   
                      </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lnkSearchRecieptNo" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>

</asp:Panel>
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView1" 
                EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="lnkSearch" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    

</asp:Content>

