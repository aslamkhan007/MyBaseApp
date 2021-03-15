<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="materialrequest.aspx.vb" Inherits="OPS_materialrequest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label1" runat="server" 
                    Text="Sales - Material Return"></asp:Label>
            </td>
        </tr>
       
        <tr>
            <td class="NormalText" style="width: 117px">
                Customer</td>
            <td  class="NormalText" style="width: 230px">
                <div id="divwidth" style="display: none;">
                </div>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" 
                            CssClass="textbox" MaxLength="40" 
                            ToolTip="Please give Customer Code or Select Customer from the List" 
                            Width="200px"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                            MinimumPrefixLength="1" ServiceMethod="OPS_Customer" 
                            ServicePath="~/WebService.asmx" TargetControlID="txtCustomer">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td  class="NormalText" style="width: 97px">
                Sale Person
            </td>
            <td style="margin-left: 80px"  class="NormalText">
                <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="ddlSalesPerson" Display="Dynamic" 
                    ErrorMessage="** Filed Required" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td style="margin-left: 80px"  class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 117px">
                <asp:Label ID="Label16" runat="server" Text="Enclosures"></asp:Label>
            </td>
            <td  class="NormalText" style="width: 230px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:CheckBoxList ID="chbEnclosures" runat="server" AutoPostBack="True">
                            <asp:ListItem>Packing List</asp:ListItem>
                            <asp:ListItem>Customer Challan</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:CheckBoxList>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:TextBox ID="txtEnclosures" runat="server" CssClass="textbox" 
                                    Visible="False" Width="200px"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="chbEnclosures" 
                                    EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
            </td>
            <td  class="NormalText" style="width: 97px">
                Instructions</td>
            <td style="margin-left: 80px"  class="NormalText">
                <asp:TextBox ID="txtinstructions" runat="server" 
                    CssClass="textbox" TextMode="MultiLine" Height="40px" Width="200px"></asp:TextBox>
            </td>
            <td style="margin-left: 80px"  class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 117px">
                Description</td>
            <td  class="NormalText" style="width: 230px">
                <asp:TextBox ID="txtDescription" runat="server" 
                    CssClass="textbox" TextMode="MultiLine" Height="40px" Width="200px" 
                    ValidationGroup="A" ToolTip="Include all details like bale No etc"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtDescription" Display="Dynamic" ErrorMessage="**" 
                    ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td  class="NormalText" style="width: 97px">
                <asp:Label ID="Label18" runat="server" Text="Sanction Note ID"></asp:Label>
            </td>
            <td style="margin-left: 80px"  class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSanctionID" runat="server" AutoPostBack="True" 
                            CssClass="textbox" MaxLength="40" ToolTip="Enter Sanction ID "></asp:TextBox>
                     
                        <asp:Image ID="img" runat="server" Visible="False" />
                        (Optional)
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="margin-left: 80px"  class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 117px">
                Select Plant</td>
            <td  class="NormalText" style="width: 230px">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>COTTON</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="ddlPlant" Display="Dynamic" ErrorMessage="***" 
                            ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td  class="NormalText" style="width: 97px">
                <asp:Label ID="Label17" runat="server" Text="Invoice No" Visible="False"></asp:Label>
            </td>
            <td style="margin-left: 80px"  class="NormalText">
                <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="textbox" 
                    ToolTip="Enter invoice no." 
                    MaxLength="40" Visible="False"></asp:TextBox>
                 
            </td>
            <td style="margin-left: 80px"  class="NormalText">
                &nbsp;</td>
        </tr>
         <tr>
            <td class="NormalText" style="width: 117px">
                <asp:Label ID="Label19" runat="server" Text="Invoice Date From" Visible="False"></asp:Label>
             </td>
            <td style="width: 230px">
                <asp:TextBox ID="txtEff_From" runat="server" CssClass="textbox" MaxLength="15" TabIndex="28"
                    ValidationGroup="ValidGrpSaveDetail" Width="65px" Visible="False"></asp:TextBox>
                <cc1:CalendarExtender ID="CalEfffr" runat="server" Animated="False" Format="MM/dd/yyyy"
                    TargetControlID="txtEff_From">
                </cc1:CalendarExtender>
              
            </td>
            <td class="NormalText" style="width: 97px">
                <asp:Label ID="Label20" runat="server" Text="Invoice Date To" Visible="False"></asp:Label>
            &nbsp;</td>
            <td  class="NormalText">
                <asp:TextBox ID="txtEff_To" runat="server" CssClass="textbox" MaxLength="15" 
                    TabIndex="29" ValidationGroup="ValidGrpSaveDetail" Width="65px" 
                    Visible="False"></asp:TextBox>
                <cc1:CalendarExtender ID="CalEffTo" runat="server" Animated="False" 
                    Format="MM/dd/yyyy" TargetControlID="txtEff_To">
                </cc1:CalendarExtender>
             
            </td>
            <td  class="NormalText">
                &nbsp;</td>
        </tr>
        </table>
          <asp:UpdatePanel ID="UpdatePanel7" runat="server" 
        UpdateMode="Conditional">
                <ContentTemplate>
    <table style="width: 100%;">
    <tr>
     <td class="NormalText" style="color: #008080">
                <asp:Image ID="ImageReasons" runat="server" ImageUrl="~/Image/plus.png" Style="margin-right: 5px;" />
                Select appropriate reasons
                 <cc1:CollapsiblePanelExtender ID="cpe" runat="Server" AutoCollapse="False" AutoExpand="True"
                                    CollapseControlID="ImageReasons" Collapsed="False" CollapsedImage="~/Image/plus.png"
                                    CollapsedSize="0" ExpandControlID="ImageReasons" ExpandDirection="Vertical" ExpandedImage="~/Image/minus.png"
                                    ImageControlID="ImageReasons" ScrollContents="false" TargetControlID="pnlReasons" />
            </td>
    </tr>
        <tr>

            <td class="NormalText">
              
                  <asp:Panel ID="pnlReasons" runat="server" Height="200px" ScrollBars="Vertical">
                    <asp:CheckBoxList ID="chbReasons" runat="server" CssClass="combobox" 
                        DataSourceID="SqlDataSource1" DataTextField="REASON" DataValueField="REASON" 
                        RepeatColumns="2" AutoPostBack="True">
                    </asp:CheckBoxList>
                      <asp:TextBox ID="txtOtherReason" runat="server" CssClass="textbox" 
                          Visible="False" Width="200px"></asp:TextBox>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                        
                          SelectCommand="SELECT REASON FROM JCT_OPS_SANCTION_NOTE_MATERIAL_RETURN_REASONS WHERE STATUS='A'  and Plant = @Plant order by Sr_No">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlPlant" DefaultValue="Cotton" Name="Plant" 
                                PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </asp:Panel>
             
              
            </td>
        </tr>
        </table>
           </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlPlant" 
                        EventName="SelectedIndexChanged" />
                </Triggers>
                </asp:UpdatePanel>
    
    <table style="width: 100%;">
        <tr>
             <td valign="top">

             
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" 
                    RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="labelcells">Insert invoice No and details</asp:LinkButton>
                        
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtSanctionID" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                </td>
        </tr>
        <tr>
            <td style="text-align: center" class="buttonbackbar">
                <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                            ValidationGroup="A">Save</asp:LinkButton>
                        <asp:LinkButton ID="cmdTransport" runat="server" CssClass="buttonc">Transport</asp:LinkButton>
                            <asp:LinkButton ID="cmdreset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc">Close
                </asp:LinkButton>
                        
            </td>
        </tr>
        <tr>
            <td style="text-align: center" class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        </table>
    <table style="width: 100%;">
        <tr>
            <td  class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <asp:Panel ID="pnlGridview2" runat="server" CssClass="panelbg" ScrollBars="Auto" 
                    Width="100%">
                    <asp:GridView ID="GridView2" runat="server" EnableModelValidation="True" 
                        Width="100%" AutoGenerateColumns="False">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                          <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Remove" 
                                                ImageUrl="~/Image/Icons/close.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                        
                             <asp:TemplateField HeaderText="Invoice No ">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtInvocieNo" CssClass="textbox" runat="server"  Text='<%# Eval("InvoiceNo") %>' ></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                        ControlToValidate="txtInvocieNo" Display="Dynamic" ErrorMessage="**" 
                                                        ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    <asp:ImageButton ID="imgRefresh" runat="server" 
                                                        ImageUrl="~/Image/refresh-icon.gif" CommandName="Refresh" CausesValidation="False" 
                                                         />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Freight Paid">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlFreight" CssClass="combobox" runat="server">
                                        <asp:ListItem>By Customer</asp:ListItem>
                                        <asp:ListItem>By Mill</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                       
                            <asp:TemplateField HeaderText="Return Qty">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtReturnQty" runat="server"  CssClass="textbox"   
                                        MaxLength="10" AutoPostBack="True" 
                                        ontextchanged="txtReturnQty_TextChanged"></asp:TextBox>
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="txtReturnQty" Display="Dynamic" ErrorMessage="** Required" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bales">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtbales" AutoPostBack="false" runat="server" CssClass="textbox"  Columns="5" MaxLength="3" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                        ControlToValidate="txtbales" Display="Dynamic" ErrorMessage="** Required" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Qty">
                                <ItemTemplate>
                                   <asp:Label ID="lblQty" Text='<%# Eval("Qty") %>' runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Item No">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemNo" Text='<%# Eval("ItemNo") %>' runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Invoice Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvoiceDt" Text='<%# Eval("InvoiceDt") %>' runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Customer">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomer" Text='<%# Eval("Customer") %>' runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Sales Person">
                                <ItemTemplate>
                                    <asp:Label ID="lblSalesPerson" Text='<%# Eval("SalesPerson") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                    <br />
                </asp:Panel>
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                
            </td>
        </tr>
        </table>
    <table style="width: 100%;">
        <tr>
            <td  class="NormalText">
             
               
                &nbsp;</td>
        </tr>
        </table>
</asp:Content>

