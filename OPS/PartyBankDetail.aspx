<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OPS/MasterPage.master"
    CodeFile="PartyBankDetail.aspx.cs" Inherits="OPS_PartyBankDetail" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script>
    function NumberOnly() {
        var AsciiValue = event.keyCode
        if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127 || AsciiValue == 46 || AsciiValue == 45))
            event.returnValue = true;
        else
            event.returnValue = false;

            
    }
       
        </script>
    <table style="width: 88%; height: 264px;">
        <tr>
            <td style="height: 41px;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Party Bank Detail"></asp:Label>
            </td>
            <td style="height: 41px">
            </td>
            <td style="height: 41px" colspan="5">
            </td>
        </tr>
        <tr>
          <td style="width: 94px; height: 26px;">
                <asp:Label ID="PartyCode" runat="server" Text="Party Code / Party Name" CssClass="labelcells" Width="100px"></asp:Label>
            </td>
            <td style="height: 26px">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtPartyCode" runat="server" CssClass="textbox" Width="300px" TabIndex="0"></asp:TextBox>
                         <div id="div4" style="display: none;">
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server"
                        CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="OPS_customer"
                        CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                        TargetControlID="txtPartyCode">
                    </cc1:AutoCompleteExtender>
                </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPartyCode"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
           
              <td style="width: 31px; height: 13px;">
                &nbsp;
            </td>
            <td style="width: 51px">
                <asp:Label ID="Label15" runat="server" CssClass="labelcells" Text="Receipt Date"></asp:Label>
            </td>
            <td class="NormalText" style="width: 152px">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_receiptDate" runat="server" CssClass="textbox" 
                            Width="100px" TabIndex="70"></asp:TextBox>
                        <cc1:CalendarExtender ID="txt_receiptdate_CalendarExtender" runat="server" TargetControlID="txt_receiptDate">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="ME1" runat="server" ControlExtender="MEE1"
                            ControlToValidate="txt_receiptDate" Display="Dynamic" InvalidValueMessage="Invalid"
                            IsValidEmpty="true" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" >
                        </cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MEE1" runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txt_receiptDate">
                        </cc1:MaskedEditExtender>
                        
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdView" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
           
        </tr>
        <tr>
            <td style="width: 94px; height: 26px;">
                <asp:Label ID="Label3" runat="server" Text="Bank" CssClass="labelcells" Width="100px"></asp:Label>
            </td>
            <td style="height: 26px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtBank" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                         <div id="div1" style="display: none;">
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                        CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="OPS_Bank"
                        CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                        TargetControlID="txtBank">
                    </cc1:AutoCompleteExtender>
                </div>
                        <asp:RequiredFieldValidator ID="BankValidator" runat="server" ControlToValidate="txtBank"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
               <td style="width: 31px; height: 26px;">
                &nbsp;
            </td>
            <td style="width: 51px; height: 26px;">
                <asp:Label ID="Label6" runat="server" Text="Cash Type" Width="100px" CssClass="labelcells"></asp:Label>
            </td>
           <td style="height: 26px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCashtype" runat="server" CssClass="textbox" Text="NA" Width="100px"></asp:TextBox>
                         <div id="div2" style="display: none;">
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                        CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="OPS_Collection"
                        CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                        TargetControlID="txtCashtype">
                    </cc1:AutoCompleteExtender>
                </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCashtype"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 26px">
                &nbsp;
            </td>
            <td colspan="5" style="height: 26px">
                &nbsp;
            </td>
        </tr>
        <tr>

          <td style="width: 94px; height: 13px;">
                <asp:Label ID="Label2" runat="server" CssClass="labelcells" Text="Segment" Width="100px"></asp:Label>
            </td>
            <td style="height: 13px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSegment" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                         <div id="div3" style="display: none;">
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                        CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="OPS_Segment"
                        CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                        TargetControlID="txtSegment">
                    </cc1:AutoCompleteExtender>
                </div>
                        <asp:RequiredFieldValidator ID="SegmentValidator" runat="server" ControlToValidate="txtSegment"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
              <td style="width: 31px; height: 26px;">
                &nbsp;
            </td>
            
            <td style="width: 94px; height: 13px;">
                <asp:Label ID="Label4" runat="server" CssClass="labelcells" Text="Amount" Width="100px"></asp:Label>
            </td>
            <td style="height: 13px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtamount" runat="server" CssClass="textbox" Width="100px"  
                            onkeypress="return NumberOnly()"></asp:TextBox>
                         
                        <asp:RequiredFieldValidator ID="AmountValidator" runat="server" ControlToValidate="txtamount"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>

          
               <td style="width: 31px">
                &nbsp;
            </td>
            <td style="width: 51px">
              <%--  <asp:Label ID="Label4" runat="server" CssClass="labelcells" Text="Entry Date"></asp:Label>--%>
            </td>
           <%-- <td class="NormalText" style="width: 152px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_EntryDate" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_EntryDate">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MEE6"
                            ControlToValidate="txt_EntryDate" Display="Dynamic" InvalidValueMessage="Invalid"
                            IsValidEmpty="true" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px">
                        </cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txt_EntryDate">
                        </cc1:MaskedEditExtender>
                        <asp:RequiredFieldValidator ID="EntryDateValidator" runat="server" ControlToValidate="txt_EntryDate"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                   <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdView" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>--%>
        </tr>
        <tr>
            <%-- <td style="width: 94px">
                <asp:Label ID="Label14" runat="server" CssClass="labelcells" Text="Eff. From(mm/dd/yyyy)"
                    Width="60px" Visible="false"></asp:Label>
            </td>--%>
             <td class="NormalText" style="width: 152px">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_efffrom" runat="server" CssClass="textbox" Width="60px" Visible="false"></asp:TextBox>
                        <cc1:CalendarExtender ID="txt_efffrom_CalendarExtender" runat="server" TargetControlID="txt_efffrom">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txt_efffrom"
                            Display="Dynamic" InvalidValueMessage="Invalid" IsValidEmpty="true" EmptyValueMessage="*" 
                            TooltipMessage="MM/DD/YYYY" Width="114px">
                        </cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MEE6" runat="server" Mask="99/99/9999" MaskType="Date"
                            TargetControlID="txt_efffrom">
                        </cc1:MaskedEditExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdView" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>


        </tr>
        <tr>
            <td colspan="15" style="text-align: center">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                          <asp:Label ID="message" runat="server" CssClass="labelcells" ForeColor="Red" Text=""></asp:Label>
                        <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                              onclick="btnSave_Click">Save</asp:LinkButton>
                        <asp:LinkButton ID="lnkModify" runat="server" CssClass="buttonc" 
                              onclick="lnkModify_Click" >Modify</asp:LinkButton>
                               <asp:LinkButton ID="lnkRefresh" runat="server" CssClass="buttonc" 
                              onclick="lnkRefresh_Click" CausesValidation="False" 
                              >Reset</asp:LinkButton>
                                <asp:LinkButton ID="lnkReport" runat="server" CssClass="buttonc" 
                              onclick="lnkReport_Click" CausesValidation="False" 
                              >Report</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="5">
                &nbsp;
            </td>
        </tr>
        <tr>
        <td height="50px">
        
        </td>
        
        </tr>
         <tr>
      
           <td colspan="20">
           
            <asp:Panel ID="Panel1" runat="server"  Height="261px" 
                    ScrollBars="Both" Width="890px">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                             <ContentTemplate>
                                <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False"  TabIndex="50"
                                     onselectedindexchanged="grdView_SelectedIndexChanged" DataKeyNames="SerialNo"
                                     AutoGenerateSelectButton="True" Height="106px" Width="870px" >
                                 <AlternatingRowStyle CssClass="GridAI" />
                                    <Columns>
                                     <asp:BoundField HeaderText="SrNo" DataField="SerialNo"  Visible="false"/>
                                        <asp:BoundField HeaderText="Customer" DataField="Customer"   />
                                        <asp:BoundField HeaderText="Segment" DataField="Segment" />
                                        <asp:BoundField HeaderText="Bank Code" DataField="BankCode"  />                                        
                                        <asp:BoundField HeaderText="Collection Type" DataField="CollectionType" />
                                        <asp:BoundField HeaderText="Receipt Date" DataField="ReceiptDate" />
                                        <asp:BoundField DataField="EntryDate" HeaderText="Entry Date" />  
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />                                        
                                      <%--  <asp:BoundField HeaderText="Status" DataField="status" />--%>
                                        
                                        
                                       
                                    </Columns>
                                     <FooterStyle CssClass="FooterStyle" />
                                     <HeaderStyle CssClass="GridHeader" />
                                     <PagerStyle CssClass="PagerStyle" />
                                     <RowStyle CssClass="GridItem" />
                                      <SelectedRowStyle CssClass="GridRowGreen" />
                                </asp:GridView>

                                
                            </ContentTemplate>
                             <Triggers>
                                 <asp:AsyncPostBackTrigger ControlID="grdView" 
                                     EventName="SelectedIndexChanged" />
                             </Triggers>
                        </asp:UpdatePanel>
                  </div>
                  </asp:Panel>
               
            </td>
        </tr>
        <tr>
            <td colspan="10">
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                &nbsp;
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                    <ContentTemplate>
                        <uc1:FlashMessage ID="FMsg2" runat="server" EnableTheming="true" EnableViewState="true"
                            FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="5">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
