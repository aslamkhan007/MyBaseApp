<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Quotation_Pay_Terms.aspx.vb" Inherits="OPS_Quotation_Pay_Terms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt" class="tableheader">
                Quotation
                <asp:Label ID="lblQuotationNo" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
    <table style="width:100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td style="font-weight: bold; font-size: 10pt; text-align: center;">
                <asp:ImageButton ID="ibtBasicInfo" runat="server" 
                    ImageUrl="~/OPS/Image/STab_BasicInfo.png" CausesValidation="False" />
                <asp:ImageButton ID="ibtShadeQty" runat="server" 
                    ImageUrl="~/OPS/Image/STab_ShadesQuantities.png" 
                    CausesValidation="False" />
                <asp:ImageButton ID="ibtPayTerms" runat="server" 
                    ImageUrl="~/OPS/Image/Tab_PaymentTerms.png" Enabled="False" />
                <asp:ImageButton ID="ibtDispatchDetail" runat="server" 
                    ImageUrl="~/OPS/Image/STab_DispatchDetail.png" CausesValidation="False" />
                &nbsp;</td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt" colspan="4">
                Payment Terms<hr /></td>
        </tr>
        <tr>
            <td class="labelcells">
                Currency</td>
            <td class="NormalText" style="width: 232px">
                <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="combobox" 
                    AutoPostBack="True" 
               
                    DataTextField="Currency_Code" DataValueField="Exchange_Rate">
              
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_ops_get_exchange_rates" SelectCommandType="StoredProcedure">
                </asp:SqlDataSource>
            </td>
            <td class="labelcells">
                Exchange Rate (INR)</td>
            <td class="NormalText" style="vertical-align: top">
                <asp:UpdatePanel ID="UpdatePanel25" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblExchangeRate" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlCurrency" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Pay Mode</td>
            <td class="NormalText" style="width: 232px">
                <asp:DropDownList ID="ddlPayMode" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Cash</asp:ListItem>
                    <asp:ListItem>Cheque</asp:ListItem>
                    <asp:ListItem>LC</asp:ListItem>
                    <asp:ListItem>DD</asp:ListItem>
                    <asp:ListItem>Bank Transfer</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Payment Type</td>
            <td class="NormalText" style="vertical-align: top">
                <asp:DropDownList ID="ddlPayType" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Advance</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="width: 232px">
                &nbsp;</td>
            <td class="labelcells">
                Advance Amount %</td>
            <td class="NormalText" style="vertical-align: top">
                <asp:TextBox ID="txtAdvAmtPerc" runat="server" Columns="5" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td class="labelcells">
                Discount</td>
            <td class="NormalText" style="width: 232px">
                <asp:DropDownList ID="ddlDiscount" runat="server" CssClass="combobox" 
                    AutoPostBack="True" DataSourceID="dsDiscounts" DataTextField="DiscountDesc" 
                    DataValueField="DiscountCode" AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            &nbsp;<asp:ImageButton ID="ibtAddDiscount" runat="server" 
                    ImageUrl="~/Image/Icons/Action/iPhoneAdd.png" ToolTip="Add Item to List" 
                    Width="24px" CausesValidation="False" />
                <asp:SqlDataSource ID="dsDiscounts" runat="server" 
                    DataSourceMode="DataReader" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_ops_discounts" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue=" " Name="disc_code" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="labelcells">
                Discount %</td>
            <td class="NormalText" style="vertical-align: top">
                <asp:UpdatePanel ID="UpdatePanel23" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblDiscountPerc" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlDiscount" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel33" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:SqlDataSource ID="dsQuotDiscounts" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="jct_ops_get_quot_discounts" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblQuotationNo" Name="Quotation_No" 
                                    PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:GridView ID="grdDiscounts" runat="server" BorderColor="Black" 
                            BorderStyle="Solid" EnableModelValidation="True" Width="100%" 
                            CellPadding="0">
                            <RowStyle CssClass="GridItem" />
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" 
                                            CommandName="Delete" ImageUrl="~/OPS/Image/iPhone_Delete_icon.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibtAddDiscount" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                </td>
        </tr>
        <tr>
            <td class="labelcells">
                Total Discount %</td>
            <td class="NormalText" style="width: 232px; font-weight: bold;">
                <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblTotalDiscountPerc" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="vertical-align: top">
                &nbsp;</td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td class="labelcells">
                LC Applicable</td>
            <td class="NormalText" style="width: 232px">
                  
                <asp:CheckBox ID="chkLC" runat="server" AutoPostBack="True" />
            </td>
            <td class="labelcells">
                LC Interest (if any)</td>
            
            <td class="NormalText" style="vertical-align: top">
                <asp:UpdatePanel ID="UpdatePanel36" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblLCInterest" runat="server" Text="0"></asp:Label>
                        %
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="chkLC" EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="width: 232px">
                  
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            
            <td class="NormalText" style="vertical-align: top">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 25px">
                Agent</td>
            <td class="NormalText" style="width: 232px; height: 25px;">
                  
                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtAgent" runat="server" AutoPostBack="True" 
                            CssClass="textbox" Width="197px"></asp:TextBox>
                            <div id="divwidth" style="display:none;">
                        <cc1:autocompleteextender ID="txtCustomer_AutoCompleteExtender" runat="server"
                            CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1"
                            ServiceMethod="OPS_Agents" CompletionListCssClass="AutoExtender"
                            ServicePath="~/WebService.asmx"
                            CompletionListElementID="divwidth"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                            CompletionListItemCssClass="AutoExtenderList"
                            TargetControlID="txtAgent">
                        </cc1:autocompleteextender></div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="height: 25px">
                Agent Commission</td>
            
            <td class="NormalText" style="vertical-align: top; height: 25px;">
                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtAgentCommission" runat="server" 
                    CssClass="textbox" AutoPostBack="True" Columns="5"></asp:TextBox>
                        %
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Agent Name</td>
            <td class="NormalText" style="width: 232px">
                  
                <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblAgentName" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            
            <td class="NormalText" style="vertical-align: top">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="width: 232px">
                  
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            
            <td class="NormalText" style="vertical-align: top">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Freight</td>
            <td class="NormalText" style="width: 232px" valign="top">
                <asp:DropDownList ID="ddlFreight" runat="server" CssClass="combobox" 
                    AutoPostBack="True" DataSourceID="dsFreight" DataTextField="tcd_desc" 
                    DataValueField="tcd_no" AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsFreight" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_ops_get_freight" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue=" " Name="tcd_no" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="labelcells">
                Freight Percentage</td>
            <td class="NormalText" style="vertical-align: top">
                <asp:UpdatePanel ID="UpdatePanel34" runat="server" RenderMode="Inline" 
                    UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtFreight" runat="server" Columns="5" CssClass="textbox" 
                            Enabled="False"></asp:TextBox>
                        %
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlFreight" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="width: 232px" valign="top">
                * Applicable only if to be payed by JCT</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="vertical-align: top">
                &nbsp;</td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td class="labelcells">
                Expected Payment Time</td>
            <td class="NormalText" style="width: 232px" valign="top">
                <asp:TextBox ID="txtPayTime" runat="server" CssClass="textbox" Width="40px"></asp:TextBox>
                Days</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="vertical-align: top">
                </td>
        </tr>
        <tr>
            <td class="labelcells">
                Terms and Conditions</td>
            <td valign="top">
                <asp:DropDownList ID="ddlTermsCond" runat="server" CssClass="combobox" 
                    DataSourceID="dsTermsCond" DataTextField="description" 
                    DataValueField="parameter_code">
                </asp:DropDownList>
                <asp:ImageButton ID="ibtAddTC" runat="server" 
                    ImageUrl="~/Image/Icons/Action/iPhoneAdd.png" ToolTip="Add Item to List" 
                    Width="24px" CausesValidation="False" />
                &nbsp;</td>
            <td valign="top">
                &nbsp;</td>
            <td valign="top">
                <asp:SqlDataSource ID="dsTermsCond" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="select parameter_code, description from jct_ops_multi_master
where parent_category = 'TermsConditions'"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel38" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grdTermsCond" runat="server" BorderColor="Black" 
                            BorderStyle="Solid" EnableModelValidation="True" Width="100%" 
                            CellPadding="0">
                            <RowStyle CssClass="GridItem" />
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                            CommandName="Delete" ImageUrl="~/OPS/Image/iPhone_Delete_icon.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsQuotTermsCond" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="select parameter_code, description from jct_ops_multi_master
where parent_category = 'TermsConditions'"></asp:SqlDataSource>
                        <asp:GridView ID="grdCosting" runat="server" AutoGenerateColumns="False" 
                            BorderColor="Black" BorderStyle="Solid" DataSourceID="dsCosting" 
                            EnableModelValidation="True" Width="100%">
                            <RowStyle CssClass="GridItem" />
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:BoundField DataField="Shade" HeaderText="Shade" SortExpression="Shade" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                                    SortExpression="Quantity" />
                                <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM" />
                                <asp:BoundField DataField="Shade_Depth" HeaderText="Shade Depth" 
                                    SortExpression="Shade_Depth" />
                                <asp:BoundField DataField="Init_DnV_Cost" HeaderText="Base DnV Cost" 
                                    SortExpression="Init_DnV_Cost" />
                                <asp:BoundField DataField="Shade_Cost" HeaderText="Shade Cost" 
                                    SortExpression="Shade_Cost" />
                                <asp:BoundField DataField="Length_Upcharge_Val" HeaderText="Length Upc Val" 
                                    SortExpression="Length_Upcharge_Val" />
                                <asp:BoundField DataField="Final_DnV_Cost" HeaderText="Final DnV Cost" 
                                    SortExpression="Final_DnV_Cost" />
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsCosting" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="jct_ops_get_quote_qty" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblQuotationNo" DefaultValue="" 
                                    Name="Quotation_No" PropertyName="Text" Type="String" />
                                <asp:Parameter DefaultValue=" " Name="Shade" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibtAddTC" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td class="labelcells">
                DnV Cost</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblDnvCost" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Length Upcharge/Unit</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel30" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:Label ID="lblLengthUpcharge" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Preferred Margin %</td>
            <td>
                <asp:Label ID="lblPrefMargin" runat="server"></asp:Label>
            </td>
            <td class="labelcells">
                Preferred Selling Price</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel31" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:Label ID="lblPrefSellingPrice" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="width: 232px">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="vertical-align: top">
                &nbsp;</td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td class="labelcells">
                Margin %</td>
            <td class="NormalText" style="width: 232px">
                <asp:DropDownList ID="ddlMarginPerc" runat="server" AutoPostBack="True" 
                    CssClass="combobox" Visible="False">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="10">10.00</asp:ListItem>
                    <asp:ListItem Value="15">15.00</asp:ListItem>
                    <asp:ListItem Value="20">20.00</asp:ListItem>
                    <asp:ListItem Value="25">25.00</asp:ListItem>
                </asp:DropDownList>
                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtMarginPerc" runat="server" AutoPostBack="True" 
                            CssClass="textbox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtMarginPerc" ErrorMessage="Please Specify Margin" 
                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Margin/Unit</td>
            <td class="NormalText" style="vertical-align: top">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblMargin" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlMarginPerc" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlDiscount" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtAgentCommission" 
                            EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtMarginPerc" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtSalePrice" EventName="TextChanged" />   
                          <asp:AsyncPostBackTrigger ControlID="ddlCurrency" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Sale Price/Unit</td>
            <td class="NormalText" style="width: 232px">
                <asp:UpdatePanel ID="UpdatePanel24" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblSalePrice" runat="server" Visible="False"></asp:Label>
                        <asp:TextBox ID="txtSalePrice" runat="server" CssClass="textbox" 
                            AutoPostBack="True"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlMarginPerc" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlDiscount" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtAgentCommission" 
                            EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtMarginPerc" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlCurrency" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Net Margin/Unit</td>
            <td class="NormalText" style="vertical-align: top">
                <asp:UpdatePanel ID="UpdatePanel26" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblNetMargin" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlMarginPerc" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlDiscount" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtAgentCommission" 
                            EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtMarginPerc" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtSalePrice" EventName="TextChanged" />
                           <asp:AsyncPostBackTrigger ControlID="ddlCurrency" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Theoretical Margin %</td>
            <td class="NormalText" style="width: 232px">
                <asp:UpdatePanel ID="UpdatePanel22" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblThMargin" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlMarginPerc" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlDiscount" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtAgentCommission" 
                            EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtMarginPerc" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtSalePrice" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" style="vertical-align: top">
                &nbsp;</td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="errormsg">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ibtSave" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibtSave" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td>
                <asp:ImageButton ID="ibtSave" runat="server"
                    ImageUrl="~/Image/Icons/Action/document_save.png" ToolTip="Save" 
                    Width="32px" />
                <asp:ImageButton ID="ibtSave0" runat="server"
                    ImageUrl="~/Image/Icons/Action/back.png" ToolTip="Create and Save Quotation" 
                    Width="32px" onclientclick="window.history.go(-1);return false;" />
            </td>
        </tr>
    </table>

</asp:Content>

