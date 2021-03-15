<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="Cancel_Courier_Pending_Request.aspx.cs" Inherits="Courier_Tracking_System_Cancel_Courier_Pending_Request" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label18" runat="server" Text="Pending Courier Requests"></asp:Label>
                <asp:ImageButton ID="imb_close" runat="server" Height="20px" ImageAlign="Right" 
                    ImageUrl="~/Image/close24.png" onclick="imb_close_Click" />
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="labelcells" style="height: 16px;">
                <asp:Label ID="lblcourier" runat="server" Text="Courier ID"></asp:Label>
            </td>
                       <td  class="GridItem" colspan="3">
             

                <asp:Label ID="courierid" runat="server" colspan="3"></asp:Label>
              

            </td>
        </tr>
              <tr>
            <td class="labelcells" style="height: 13px">
                <asp:Label ID="lblcouriertype" runat="server" Text="Courier Type"></asp:Label>
            </td>
            <td  class="GridItem" colspan="3">
              

                <asp:Label ID="courierType" runat="server"></asp:Label>
              

            </td>
        </tr>
              <tr>
            <td class="labelcells">
                <asp:Label ID="lblDeliverytype" runat="server" Text="Delivery Type"></asp:Label>
            </td>
            <td  class="GridItem" colspan="3">
              


                <asp:Label ID="Deliverytype" runat="server"></asp:Label>
              


            </td>
        </tr>
              <tr>
            <td class="labelcells">
                <asp:Label ID="lblPartyName" runat="server" Text="Party Name"></asp:Label>
            </td>
           <td  class="GridItem" colspan="3" >
              

                <asp:Label ID="partyname" runat="server"></asp:Label>
              

            </td>
        </tr>
              <tr>
            <td class="labelcells" style="height: 16px;">
                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
            </td>
            <td  class="GridItem" colspan="3">
              

                <asp:Label ID="Address" runat="server"></asp:Label>
              

            </td>
        </tr>
              <tr>
            <td class="labelcells">
                <asp:Label ID="lblRequestBy" runat="server" Text="Request By"></asp:Label>
            </td>
            <td  class="GridItem" colspan="3" >
              

                <asp:Label ID="Requestby" runat="server"></asp:Label>
              

            </td>
        </tr>
              <tr>
            <td class="labelcells">
                Reason For Cancellation</td>
            <td class="NormalText" style="width: 166px; height: 16px;">
              

                 <telerik:RadComboBox ID="ddlCancelReason" Runat="server"  CssClass="combobox"
                    Height="85px" EnableVirtualScrolling="True"   
                     AutoPostBack="True" >
                     <Items>
                         <telerik:RadComboBoxItem runat="server" Text="Duplicate Request" 
                             Value="Duplicate Request" />
                     </Items>
                    </telerik:RadComboBox>


            </td>
            <td class="NormalText" style="width: 78px; height: 16px;">
                &nbsp;</td>
            <td class="NormalText">



                &nbsp;</td>
        </tr>
              <tr>
            <td class="labelcells">
                Original Courier ID</td>
            <td class="NormalText" style="width: 166px; height: 16px;">
              
            <asp:TextBox ID="txtOriginalCourierID" runat="server" Columns="20" CssClass="textbox"   ToolTip="Please enter courier id For Which Duplicate Courier ID Generated . E.g- SAL/10001022/2012"
            MaxLength="20"></asp:TextBox>
                </td>
            <td class="NormalText" style="width: 78px; height: 16px;">
            </td>
            <td class="NormalText">



                &nbsp;</td>
        </tr>
              <tr>
            <td class="labelcells">
                Remarks(In Brief)</td>
            <td class="NormalText" colspan="3">
                    <asp:TextBox ID="txtReasonForCancel"  runat="server" Width="344px"
        CssClass="textbox"  MaxLength="200" 
        ToolTip="Briefly Describe Reason For Cancellation ." Height="40px" 
        TextMode="MultiLine" ValidationGroup="mandatory"></asp:TextBox>
   
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Width="80px"
        ErrorMessage="*" ControlToValidate="txtReasonForCancel" SetFocusOnError="True" 
                        ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 108px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <progresstemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </progresstemplate>
                </asp:UpdateProgress>
            </td>
            <td class="NormalText" style="width: 166px">
                  &nbsp;</td>
            <td class="NormalText" style="width: 78px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        </table>

    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                   <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkCancel" runat="server" CssClass="buttonc" 
                             ValidationGroup="mandatory" onclick="lnkCancel_Click">Cancel</asp:LinkButton>
                        
                        <asp:ImageButton ID="imgPreviewReport" runat="server" BackColor="#990000" 
                            CausesValidation="False" Font-Bold="True" ForeColor="White" Height="16px" 
                            ImageUrl="~/Image/Icons/Action/Search.png" OnClick="imgPreviewReport_Click" 
                            ToolTip="See Cancelled Requests" Width="20px" Visible="False" />
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                   <%--     <asp:GridView ID="GridView1" runat="server" 
                                EmptyDataText="Please Check the Courier ID. No Courier Available for the id entered." 
                                Width="100%" AutoGenerateColumns="False" EnableModelValidation="True" 
                                onrowdatabound="GridView1_RowDataBound" ShowFooter="True" 
                                AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                                   <Columns>
                              
                                   <asp:TemplateField HeaderText="Courier ID">
                                       <ItemTemplate>
                                           <asp:Label ID="lblOrdernoF" runat="server" Text='<%# Eval("Courier ID") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Party Name">
                                       <ItemTemplate>
                                           <asp:Label ID="lblLineItemF" runat="server" Text='<%# Eval("Party Name") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Status">
                                       <ItemTemplate>
                                           <asp:Label ID="lblSortF" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Tracking ID">
                                       <ItemTemplate>
                                           <asp:Label ID="lblVariantF" runat="server" Text='<%# Eval("Tracking ID") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cost">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCost" runat="server" Text='<%# Eval("Cost") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Account No">
                                       <ItemTemplate>
                                           <asp:Label ID="lblAccountNo" runat="server" Text='<%# Eval("AccountNo") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Booking No">
                                       <ItemTemplate>
                                           <asp:Label ID="lblBookingNo" runat="server" Text='<%# Eval("BookingNo") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Courier">
                                       <ItemTemplate>
                                           <asp:Label ID="lblPlantF" runat="server" Text='<%# Eval("Courier") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Delivery">
                                       <ItemTemplate>
                                           <asp:Label ID="lblClothTypeF" runat="server" Text='<%# Eval("Delivery") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DispatchDt">
                                       <ItemTemplate>
                                           <asp:Label ID="lblDispatchDt" runat="server" Text='<%# Eval("DispatchDt") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Authorized Date">
                                       <ItemTemplate>
                                           <asp:Label ID="lblReqdtF" runat="server" Text='<%# Eval("Authorized Date") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Subject">
                                       <ItemTemplate>
                                           <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address">
                                       <ItemTemplate>
                                           <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Request By">
                                       <ItemTemplate>
                                           <asp:Label ID="lblReqBy" runat="server" Text='<%# Eval("Request By") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks">
                                       <ItemTemplate>
                                           <asp:Label ID="lblRemarks1" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Ref No">
                                       <ItemTemplate>
                                           <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("RefNo") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                       
                    </Columns>
                            </asp:GridView>--%>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <%--     <asp:GridView ID="GridView1" runat="server" 
                                EmptyDataText="Please Check the Courier ID. No Courier Available for the id entered." 
                                Width="100%" AutoGenerateColumns="False" EnableModelValidation="True" 
                                onrowdatabound="GridView1_RowDataBound" ShowFooter="True" 
                                AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                                   <Columns>
                              
                                   <asp:TemplateField HeaderText="Courier ID">
                                       <ItemTemplate>
                                           <asp:Label ID="lblOrdernoF" runat="server" Text='<%# Eval("Courier ID") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Party Name">
                                       <ItemTemplate>
                                           <asp:Label ID="lblLineItemF" runat="server" Text='<%# Eval("Party Name") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Status">
                                       <ItemTemplate>
                                           <asp:Label ID="lblSortF" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Tracking ID">
                                       <ItemTemplate>
                                           <asp:Label ID="lblVariantF" runat="server" Text='<%# Eval("Tracking ID") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cost">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCost" runat="server" Text='<%# Eval("Cost") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Account No">
                                       <ItemTemplate>
                                           <asp:Label ID="lblAccountNo" runat="server" Text='<%# Eval("AccountNo") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Booking No">
                                       <ItemTemplate>
                                           <asp:Label ID="lblBookingNo" runat="server" Text='<%# Eval("BookingNo") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Courier">
                                       <ItemTemplate>
                                           <asp:Label ID="lblPlantF" runat="server" Text='<%# Eval("Courier") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Delivery">
                                       <ItemTemplate>
                                           <asp:Label ID="lblClothTypeF" runat="server" Text='<%# Eval("Delivery") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DispatchDt">
                                       <ItemTemplate>
                                           <asp:Label ID="lblDispatchDt" runat="server" Text='<%# Eval("DispatchDt") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Authorized Date">
                                       <ItemTemplate>
                                           <asp:Label ID="lblReqdtF" runat="server" Text='<%# Eval("Authorized Date") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Subject">
                                       <ItemTemplate>
                                           <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address">
                                       <ItemTemplate>
                                           <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Request By">
                                       <ItemTemplate>
                                           <asp:Label ID="lblReqBy" runat="server" Text='<%# Eval("Request By") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks">
                                       <ItemTemplate>
                                           <asp:Label ID="lblRemarks1" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Ref No">
                                       <ItemTemplate>
                                           <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("RefNo") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                       
                    </Columns>
                            </asp:GridView>--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                       <%--     <asp:GridView ID="GridView1" runat="server" 
                                EmptyDataText="Please Check the Courier ID. No Courier Available for the id entered." 
                                Width="100%" AutoGenerateColumns="False" EnableModelValidation="True" 
                                onrowdatabound="GridView1_RowDataBound" ShowFooter="True" 
                                AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                                   <Columns>
                              
                                   <asp:TemplateField HeaderText="Courier ID">
                                       <ItemTemplate>
                                           <asp:Label ID="lblOrdernoF" runat="server" Text='<%# Eval("Courier ID") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Party Name">
                                       <ItemTemplate>
                                           <asp:Label ID="lblLineItemF" runat="server" Text='<%# Eval("Party Name") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Status">
                                       <ItemTemplate>
                                           <asp:Label ID="lblSortF" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Tracking ID">
                                       <ItemTemplate>
                                           <asp:Label ID="lblVariantF" runat="server" Text='<%# Eval("Tracking ID") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cost">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCost" runat="server" Text='<%# Eval("Cost") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Account No">
                                       <ItemTemplate>
                                           <asp:Label ID="lblAccountNo" runat="server" Text='<%# Eval("AccountNo") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Booking No">
                                       <ItemTemplate>
                                           <asp:Label ID="lblBookingNo" runat="server" Text='<%# Eval("BookingNo") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Courier">
                                       <ItemTemplate>
                                           <asp:Label ID="lblPlantF" runat="server" Text='<%# Eval("Courier") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Delivery">
                                       <ItemTemplate>
                                           <asp:Label ID="lblClothTypeF" runat="server" Text='<%# Eval("Delivery") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DispatchDt">
                                       <ItemTemplate>
                                           <asp:Label ID="lblDispatchDt" runat="server" Text='<%# Eval("DispatchDt") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Authorized Date">
                                       <ItemTemplate>
                                           <asp:Label ID="lblReqdtF" runat="server" Text='<%# Eval("Authorized Date") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Subject">
                                       <ItemTemplate>
                                           <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address">
                                       <ItemTemplate>
                                           <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Request By">
                                       <ItemTemplate>
                                           <asp:Label ID="lblReqBy" runat="server" Text='<%# Eval("Request By") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks">
                                       <ItemTemplate>
                                           <asp:Label ID="lblRemarks1" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Ref No">
                                       <ItemTemplate>
                                           <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("RefNo") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                       
                    </Columns>
                            </asp:GridView>--%>

                                                 
                            <asp:GridView ID="grdDetail" runat="server" 
    Width="100%" >
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GirdItem" />
<%--                          <Columns>  
                            <asp:HyperLinkField DataNavigateUrlFields="Courier ID" DataNavigateUrlFormatString="Itemdetail_Furniture.aspx?requestid={0}" Text="Cancel" />
                          </Columns>   --%> 
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

<%--     <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlSaleOffice" CssClass="panelbg" runat="server"  Style="display: none;">
                <asp:RadioButtonList CssClass="combobox" ID="rblSaleOffices" runat="server" RepeatDirection="Vertical"
                    AutoPostBack="True"  OnSelectedIndexChanged="rblSaleOffices_SelectedIndexChanged">
                </asp:RadioButtonList>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="rblSelect" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>--%>
</asp:Content>

