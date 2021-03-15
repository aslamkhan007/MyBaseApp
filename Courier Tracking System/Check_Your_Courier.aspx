<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="Check_Your_Courier.aspx.cs" Inherits="Courier_Tracking_System_Check_Your_Courier" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <table style="width:100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label18" runat="server" Text="Check Your Courier Tracking ID"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" style="width: 108px">
                <asp:Label ID="Label20" runat="server" Text="From Date"></asp:Label>
            </td>
            <td class="NormalText" style="width: 166px">
                <asp:TextBox ID="txtFrom" runat="server" CssClass="textbox" Columns="10" 
                    MaxLength="10"></asp:TextBox>
            
                <cc1:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtFrom">
                </cc1:CalendarExtender>

            </td>
            <td class="NormalText" style="width: 78px">
                <asp:Label ID="Label24" runat="server" Text="To Date"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtTo" runat="server" CssClass="textbox" Columns="10" 
                    MaxLength="10"></asp:TextBox>
             
                <cc1:CalendarExtender ID="txtTo_CalendarExtender" runat="server" 
                    TargetControlID="txtTo">
                </cc1:CalendarExtender>

            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 108px">
                <asp:Label ID="Label19" runat="server" Text="Courier ID"></asp:Label>
            </td>
            <td class="NormalText" style="width: 166px">
                <asp:TextBox ID="txtCourierID" runat="server" Columns="20" CssClass="textbox"   ToolTip="Please enter your unique courier id. E.g- SAL/10001022/2012 or just 1022"
                    MaxLength="20"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 78px">
                Courier Type</td>
            <td class="NormalText">
                <asp:DropDownList ID="DdlCouriertype" runat="server" 
                    AppendDataBoundItems="True" CssClass="combobox" DataSourceID="SqlDataSource1" 
                    DataTextField="Courier_Service" DataValueField="Courier_Service">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand=" Select '' as  Courier_Service   Union  SELECT Courier_Service   FROM  jct_Courier_Service_Master where STATUS = 'A' ORDER BY Courier_Service">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 108px">
                <asp:Label ID="Label23" runat="server" Text="Request By"></asp:Label>
            </td>
            <td class="NormalText" style="width: 166px">
                  <div id="div1" style="display:none;">   
                                        </div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtRequestBy" runat="server" AutoPostBack="True" 
                            CssClass="textbox" ontextchanged="txtRequestBy_TextChanged"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                            CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                            CompletionListElementID="div1" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                            MinimumPrefixLength="1" ServiceMethod="Email_IDs" 
                            ServicePath="~/WebService.asmx" TargetControlID="txtRequestBy">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 78px">
                Delivery Type</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlDeliveryType" runat="server" 
                    AppendDataBoundItems="True" CssClass="combobox" DataSourceID="SqlDataSource2" 
                    DataTextField="DeliveryType" DataValueField="DeliveryType">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="select '' as  DeliveryType union  SELECT DeliveryType FROM  jct_courier_Delivery_Type where STATUS = 'A' ORDER BY DeliveryType">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 108px">
                Courier Status</td>
            <td class="NormalText" style="width: 166px">
                  <asp:DropDownList ID="ddlCourierStatus" runat="server" CssClass="combobox">
                      <asp:ListItem Selected="True"></asp:ListItem>
                      <asp:ListItem>Authorized</asp:ListItem>
                      <asp:ListItem>Pending</asp:ListItem>
                  </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 78px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        </table>

    <table style="width: 100%">
        <tr>
            <td class="NormalText" style="color: #008080">
                <asp:Image ID="ImageReceiverDetail" runat="server" ImageUrl="~/Image/plus.png" Style="margin-right: 5px;" />
                Receiver's Detail 
                    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="Server" AutoCollapse="False" AutoExpand="True"
                                    CollapseControlID="ImageReceiverDetail" Collapsed="True" CollapsedImage="~/Image/plus.png"
                                    CollapsedSize="0" ExpandControlID="ImageReceiverDetail" ExpandDirection="Vertical" ExpandedImage="~/Image/minus.png"
                                    ImageControlID="ImageReceiverDetail" ScrollContents="false" TargetControlID="Panel5" />
                (Optional)</td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Panel ID="Panel5" Width="100%" runat="server" BorderStyle="Solid" BorderWidth="1px">
                    <table style="width: 100%;" class="tableback">
                        <tr>
                            <td class="NormalText" style="width: 117px">
                                <asp:Label ID="Label33" runat="server" Text="Party Type"></asp:Label>
                            </td>
                            <td class="NormalText" colspan="3">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="rblSelect" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                            CssClass="labelcells" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                            Font-Underline="False" OnSelectedIndexChanged="rblSelect_SelectedIndexChanged"
                                            Width="500px" CellPadding="0" CellSpacing="0">
                                            <asp:ListItem>Customer</asp:ListItem>
                                            <asp:ListItem>Supplier</asp:ListItem>
                                            <asp:ListItem>HO</asp:ListItem>
                                            <asp:ListItem Value="Hoshiarpur">Hoshiarpur JCT</asp:ListItem>
                                            <asp:ListItem>Sales Office</asp:ListItem>
                                            <asp:ListItem>Other</asp:ListItem>
                                            <asp:ListItem Selected="True">All</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <cc1:PopupControlExtender ID="rblSelect_PopupControlExtender" runat="server" TargetControlID="rblSelect"
                                            PopupControlID="pnlSaleOffice" Position="Right">
                                        </cc1:PopupControlExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText" style="width: 117px">
                                <asp:Label ID="Label54" runat="server" Text="Party Code"></asp:Label>
                            </td>
                            <td class="NormalText" colspan="3">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPartyCode" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" 
                                            ToolTip="Enter party Code or click Search Button to search Party." 
                                            TabIndex="5" ontextchanged="txtPartyCode_TextChanged"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtCustomer" EventName="TextChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="rblSelect" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="rblSaleOffices" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txtSupplierName" EventName="TextChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="txtOtherParty" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                                   
                                    <ProgressTemplate>
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/loadingNew.gif" />
                                    </ProgressTemplate>
                                   
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 117px; vertical-align: top;">
                                <asp:Label ID="Label1" runat="server" Text="Party Name"></asp:Label>
                            </td>
                            <td class="NormalText" style="width: 216px">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCustomer" runat="server" CssClass="textbox" Width="200px" TabIndex="6"
                                            AutoPostBack="True" OnTextChanged="txtCustomer_TextChanged"></asp:TextBox>
                                              <div id="div4" style="display: none;">
                                        <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender0" runat="server" 
                                            CompletionInterval="1"
                                                FirstRowSelected="True" MinimumPrefixLength="1" ServiceMethod="CustomerAddress_CourierSystem"
                                                ServicePath="~/WebService.asmx" TargetControlID="txtCustomer" CompletionListElementID="divwidth1"
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList">
                                        </cc1:AutoCompleteExtender>
                                        </div>
                                        <br />
                                        <asp:TextBox ID="txtSupplierName" runat="server" AutoPostBack="True" CssClass="textbox"
                                            OnTextChanged="txtSupplierName_TextChanged" TabIndex="6" Visible="False" 
                                            Width="200px"></asp:TextBox>
                                              
                                        <div id="divwidth" style="display: none;">
                                            <cc1:AutoCompleteExtender ID="txtSupplierName_AutoCompleteExtender" runat="server"
                                                TargetControlID="txtSupplierName" CompletionInterval="1" FirstRowSelected="True"
                                                MinimumPrefixLength="1" ServiceMethod="SupplierAddress_CourierSystem" ServicePath="~/WebService.asmx"
                                                CompletionListElementID="divwidth" CompletionListCssClass="AutoExtender" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                CompletionListItemCssClass="AutoExtenderList">
                                            </cc1:AutoCompleteExtender>
                                        </div>
                                        <div id="divwidth1" style="display: none;">
                                        </div>
                                        <br />
                                        <asp:TextBox ID="txtOtherParty" runat="server" AutoPostBack="True" CssClass="textbox"   ontextchanged="txtOtherParty_TextChanged"
                                            TabIndex="6" Visible="False" Width="200px"></asp:TextBox>
                                              <div id="div3" style="display: none;">
                                        <cc1:AutoCompleteExtender ID="txtOtherParty_AutoCompleteExtender" runat="server"
                                            TargetControlID="txtOtherParty" CompletionInterval="1" CompletionListCssClass="AutoExtender"
                                            CompletionListElementID="div3" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                            CompletionListItemCssClass="AutoExtenderList" FirstRowSelected="True" MinimumPrefixLength="1"
                                            ServiceMethod="OtherPartyAddress_CourierSystem" ServicePath="~/WebService.asmx">
                                        </cc1:AutoCompleteExtender>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtPartyCode" EventName="TextChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="rblSelect" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="rblSaleOffices" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <a id="addLink" href="javascript:void(0)" onclick="ShowEditBox()" style="display: none;"
                                    title="Add">Add</a>
                            </td>
                            <td class="NormalText" style="width: 113px; vertical-align: top;">
                                &nbsp;</td>
                            <td class="NormalText">
                                &nbsp;</td>
                        </tr>
 
                    </table>
                </asp:Panel>
                                           <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="100">
                                    <progresstemplate>
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Image/loadingNew.gif" />
                                    </progresstemplate>
                                </asp:UpdateProgress>
            </td>
        </tr>
    </table>



    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                   <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkSearch" runat="server" CssClass="buttonc" 
                            onclick="lnkSearch_Click">Search</asp:LinkButton>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                  <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" onclick="lnkExcel_Click">Excel</asp:LinkButton>
                        
                        <asp:HyperLink ID="hlnk" runat="server" 
                            
                    NavigateUrl="~/Courier%20Tracking%20System/Dispatched_Courier.aspx">Couriers Dispatched
                        </asp:HyperLink>
                        
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                     <%--<asp:Panel ID="Panel2" runat="server">--%>                    
                        <asp:Panel ID="Panel1" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">
                            <asp:GridView ID="GridView1" runat="server" 
                                EmptyDataText="Please Check the Courier ID. No Courier Available for the id entered." 
                                Width="100%" AutoGenerateColumns="False" EnableModelValidation="True" 
                                onrowdatabound="GridView1_RowDataBound" ShowFooter="True" 
                               onpageindexchanging="GridView1_PageIndexChanging" >
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
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkSearch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

     <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
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
    </asp:UpdatePanel>

</asp:Content>

