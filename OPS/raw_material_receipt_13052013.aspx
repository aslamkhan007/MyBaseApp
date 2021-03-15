<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="raw_material_receipt.aspx.vb" Inherits="OPS_raw_material_receipt" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 335px;">
        <tr>
            <td style="height: 35px; " colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Raw Material Receipt"></asp:Label>
             </td>
            <td style="height: 35px; width: 55px;">
                <asp:Label ID="Label5" runat="server" Text="Action" Visible="False" 
                    CssClass="labelcells"></asp:Label>
            </td>
            <td style="height: 35px" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" CssClass="combobox" 
                            Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 35px">
                <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_supplier_code" runat="server" CssClass="textbox" 
                            Width="70px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="height: 35px" colspan="2">
                <asp:ImageButton ID="imb_close" runat="server" Height="18px" ImageAlign="Right" 
                    ImageUrl="~/Image/close24.png" ToolTip="Close Page" />
            </td>
            <td style="height: 35px">
                </td>
        </tr>
        <tr>
            <td style="width: 71px; height: 5px;">
                <asp:Label ID="Label4" runat="server" Text="Plant" CssClass="labelcells"></asp:Label>
            </td>
            <td style="width: 85px; height: 5px;">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_plant" runat="server" CssClass="combobox" 
                            Width="86px">
                            <asp:ListItem>COTTON</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 5px; width: 55px;">
                <asp:Label ID="Label8" runat="server" CssClass="labelcells" Text="Tran. No."></asp:Label>
                </td>
            <td style="height: 5px" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_tranno" runat="server" CssClass="textbox" 
                            AutoPostBack="True"></asp:TextBox>
                        <asp:ImageButton ID="imb_tran_fetch" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 5px">
                <asp:Label ID="Label9" runat="server" CssClass="labelcells" Text="Status"></asp:Label>
                </td>
            <td style="height: 5px" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_status" runat="server" Text="..." CssClass="labelcells" 
                            Width="80px"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 5px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px; height: 17px;">
                <asp:Label ID="Label3" runat="server" CssClass="labelcells" Text="Group" 
                    Width="65px"></asp:Label>
            </td>
            <td style="height: 17px;" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_itemgroup" runat="server" CssClass="combobox" 
                            Width="270px" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 17px">
                <asp:Label ID="Label33" runat="server" CssClass="labelcells" Text="Group Code"></asp:Label>
            </td>
            <td style="height: 17px">
                <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_groupcode" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 17px">
                &nbsp;</td>
            <td style="height: 17px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" Height="12px" 
                            ImageUrl="~/Image/loading.gif" Width="80px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                &nbsp;</td>
            <td style="height: 17px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px; height: 17px;">
                <asp:Label ID="Label2" runat="server" Text="Supplier" CssClass="labelcells"></asp:Label>
            </td>
            <td style="height: 17px;" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_supplier" runat="server" CssClass="combobox" 
                            Width="270px" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 17px">
                <asp:Label ID="Label29" runat="server" CssClass="labelcells" 
                    Text="Sel.Supplier"></asp:Label>
            </td>
            <td style="height: 17px" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_supplier_code" runat="server" CssClass="combobox" 
                            Width="270px" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:ImageButton ID="imb_remove_supplier_code" runat="server" Height="14px" 
                            ImageUrl="~/Image/Collapse.png" ToolTip="Remove selected supplier" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 17px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px; height: 17px;">
                <asp:Label ID="Label36" runat="server" CssClass="labelcells" Text="Address"></asp:Label>
            </td>
            <td style="height: 17px;" colspan="5">
                <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_address" runat="server" Text="..." CssClass="labelcells"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 17px">
                <asp:Label ID="Label34" runat="server" CssClass="labelcells" Text="City"></asp:Label>
                </td>
            <td style="height: 17px">
                <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_city" runat="server" Text="..." Width="80px" 
                            CssClass="labelcells"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 17px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px; height: 17px;">
                <asp:Label ID="Label13" runat="server" CssClass="labelcells" 
                    Text="Pay Term Code" Width="60px"></asp:Label>
            </td>
            <td style="height: 17px; " colspan="3">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_pay_term_code" runat="server" CssClass="textbox" 
                            Width="80px" AutoPostBack="True"></asp:TextBox>
                        <asp:ImageButton ID="imb_get_new_payterm" runat="server" Height="14px" 
                            ImageUrl="~/Image/Expand.png" ToolTip="Change/Create Payment Term" />
                        <asp:ImageButton ID="imb_set_new_payterm" runat="server" Height="16px" 
                            ImageUrl="~/Image/save_icon.PNG" ToolTip="Save Payment Term" />
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                            CompletionListCssClass="autocomplete_ListItem " FirstRowSelected="True" 
                            MinimumPrefixLength="2" ServiceMethod="GetPaytermcode" 
                            ServicePath="~/WebService.asmx" TargetControlID="txt_pay_term_code">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 17px">
                <asp:Label ID="Label15" runat="server" CssClass="labelcells" 
                    Text="Eff. From (m/d/y)" Width="60px"></asp:Label>
                </td>
            <td style="height: 17px">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_efffrom" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CE3" runat="server" PopupPosition="TopLeft" 
                            TargetControlID="txt_efffrom">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 17px">
                <asp:Label ID="Label16" runat="server" CssClass="labelcells" 
                    Text="Eff. To (m/d/y)" Width="60px"></asp:Label>
            </td>
            <td style="height: 17px">
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_effto" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CE4" runat="server" TargetControlID="txt_effto">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 17px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px; height: 14px;">
                <asp:Label ID="Label14" runat="server" CssClass="labelcells" 
                    Text="Term Desc." Width="65px"></asp:Label>
                </td>
            <td style="height: 14px;" colspan="7">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_pay_term_desc" runat="server" CssClass="textbox" 
                            Width="630px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 14px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px; height: 6px;">
                <asp:Label ID="Label6" runat="server" CssClass="labelcells" Text="Item Code"></asp:Label>
            </td>
            <td style="width: 85px; height: 6px;">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_itemcode" runat="server" CssClass="textbox" Width="80px" 
                            AutoPostBack="True"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                            FirstRowSelected="True" MinimumPrefixLength="2" ServiceMethod="GetItemcode" 
                            ServicePath="~/WebService.asmx" TargetControlID="txt_itemcode" 
                            CompletionListCssClass="autocomplete_ListItem ">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 6px; width: 55px;">
                <asp:Label ID="Label11" runat="server" CssClass="labelcells" Text="Item Desc." 
                    Width="65px"></asp:Label>
                </td>
            <td style="height: 6px" colspan="5">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        
                        <asp:TextBox ID="txt_item_desc" runat="server" CssClass="textbox" Width="435px"></asp:TextBox>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="height: 6px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px; height: 9px;">
                <asp:Label ID="Label7" runat="server" CssClass="labelcells" Text="Variant"></asp:Label>
            </td>
            <td style="width: 85px; height: 9px;">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_variant" runat="server" CssClass="textbox" Width="80px" 
                            AutoPostBack="True"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                            FirstRowSelected="True" MinimumPrefixLength="2" ServiceMethod="GetVariant" 
                            ServicePath="~/WebService.asmx" TargetControlID="txt_variant" 
                            CompletionListCssClass="autocomplete_ListItem " ContextKey="txt_itemcode" 
                            UseContextKey="True">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 9px; width: 55px;">
                <asp:Label ID="Label12" runat="server" CssClass="labelcells" Text="Var. Desc."></asp:Label>
                </td>
            <td style="height: 9px" colspan="5">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        
                        <asp:TextBox ID="txt_variant_desc" runat="server" CssClass="textbox" 
                            Width="435px"></asp:TextBox>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="height: 9px">
                </td>
        </tr>
        <tr>
            <td style="width: 71px; height: 3px;">
                <asp:Label ID="Label17" runat="server" CssClass="labelcells" Text="Qty. "></asp:Label>
            </td>
            <td style="width: 96px; height: 3px;">
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_qty" runat="server" CssClass="textbox" Width="80px" 
                            AutoPostBack="True"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE1" runat="server" 
                            TargetControlID="txt_qty" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 3px; width: 55px;">
                <asp:Label ID="Label22" runat="server" CssClass="labelcells" Text="Last Rate"></asp:Label>
            </td>
            <td style="height: 3px">
                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_last_rate" runat="server" CssClass="textbox" Width="54px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE4" runat="server" 
                            TargetControlID="txt_last_rate" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 3px">
                <asp:Label ID="Label30" runat="server" CssClass="labelcells" Text="Budget Qty." 
                    Width="70px"></asp:Label>
            </td>
            <td style="height: 3px">
                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_budget_qty" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE61" runat="server" 
                            TargetControlID="txt_budget_qty" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 3px">
                <asp:Label ID="Label26" runat="server" CssClass="labelcells" 
                    Text="Budget Value" Width="75px"></asp:Label>
            </td>
            <td style="height: 3px">
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_budget_value" runat="server" CssClass="textbox" 
                            Width="70px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE6" runat="server" 
                            TargetControlID="txt_budget_value" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 3px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px; height: 3px;">
                
                <asp:Label ID="Label37" runat="server" CssClass="labelcells" Text="U.O.M."></asp:Label>
                
            </td>
            <td style="width: 96px; height: 3px;">
                 <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                     <ContentTemplate>
                         <asp:DropDownList ID="ddl_uom" runat="server" CssClass="combobox" Width="86px">
                             <asp:ListItem>KG</asp:ListItem>
                             <asp:ListItem>MTR</asp:ListItem>
                         </asp:DropDownList>
                     </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
            <td style="height: 3px; width: 55px;">
                <asp:Label ID="Label21" runat="server" CssClass="labelcells" 
                    Text="Receive Dt.(m/d/y)" Width="65px"></asp:Label>
            </td>
            <td style="height: 3px">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_receive_date" runat="server" CssClass="textbox" 
                            Width="54px" AutoPostBack="True"></asp:TextBox>
                        <cc1:CalendarExtender ID="CE1" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_receive_date">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 3px">
                <asp:Label ID="Label31" runat="server" CssClass="labelcells" Text="Plan Qty."></asp:Label>
            </td>
            <td style="height: 3px">
                <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_plan_qty" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE71" runat="server" 
                            TargetControlID="txt_plan_qty" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 3px">
                <asp:Label ID="Label27" runat="server" CssClass="labelcells" Text="Plan Value"></asp:Label>
            </td>
            <td style="height: 3px">
                <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_plan_value" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE7" runat="server" 
                            TargetControlID="txt_plan_value" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="height: 3px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px; height: 3px;">
                
                <asp:Label ID="Label20" runat="server" CssClass="labelcells" Text="Rate"></asp:Label>
                
            </td>
            <td style="width: 96px; height: 3px;">
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_rate" runat="server" CssClass="textbox" Width="80px" 
                            AutoPostBack="True"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE3" runat="server" 
                            TargetControlID="txt_rate" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 3px; width: 55px;">
                <asp:Label ID="Label23" runat="server" CssClass="labelcells" Text="Lead Time"></asp:Label>
            </td>
            <td style="height: 3px">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_lead_time" runat="server" CssClass="textbox" Width="54px" 
                            AutoPostBack="True"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE5" runat="server" 
                            TargetControlID="txt_lead_time" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 3px">
                <asp:Label ID="Label32" runat="server" CssClass="labelcells" Text="Actual Qty."></asp:Label>
            </td>
            <td style="height: 3px">
                
                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_actual_qty" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE81" runat="server" 
                            TargetControlID="txt_actual_qty" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
            <td style="height: 3px">
                <asp:Label ID="Label28" runat="server" CssClass="labelcells" 
                    Text="Actual Value" Width="70px"></asp:Label>
                </td>
            <td style="height: 3px">
                <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_actual_value" runat="server" CssClass="textbox" 
                            Width="70px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE8" runat="server" 
                            TargetControlID="txt_actual_value" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 3px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px; height: 2px;">
                
                <asp:Label ID="Label18" runat="server" CssClass="labelcells" Text="Value"></asp:Label>
                
            </td>
            <td style="width: 96px; height: 2px;">
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_value" runat="server" CssClass="textbox" Width="80px" 
                            AutoPostBack="True"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE2" runat="server" 
                            TargetControlID="txt_value" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 2px; width: 65px;">
                
                <asp:Label ID="Label24" runat="server" CssClass="labelcells" 
                    Text="Proc. Dt.(m/d/y)"></asp:Label>
            </td>
            <td style="height: 2px">
                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_procurement_date" runat="server" CssClass="textbox" 
                            Width="54px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CE2" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_procurement_date">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 2px">
                
                <asp:Label ID="Label25" runat="server" CssClass="labelcells" Text="Invoice No."></asp:Label>
            </td>
            <td style="height: 2px">
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_invno" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 2px" colspan="2">
                &nbsp;</td>
            <td style="height: 2px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px">
                <asp:Label ID="Label38" runat="server" CssClass="labelcells" Text="Reqd. Date"></asp:Label>
            </td>
            <td style="width: 96px">
                <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_required_date" runat="server" AutoPostBack="True" 
                            CssClass="textbox" Width="80px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CE5" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_required_date">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 55px">
                <asp:Label ID="Label35" runat="server" CssClass="labelcells" Text="Reason"></asp:Label>
            </td>
            <td colspan="5">
                <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_reason" runat="server" CssClass="textbox" Width="435px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px">
                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbt_apply" runat="server" CssClass="buttonc" 
                            Visible="False" Width="60px">Apply</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="5" align="center">
                 <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                     <ContentTemplate>
                         <asp:LinkButton ID="lbt_view" runat="server" CssClass="buttonc">VIEW</asp:LinkButton>
                         <asp:LinkButton ID="lbt_add" runat="server" CssClass="buttonc">ADD</asp:LinkButton>
                         <asp:LinkButton ID="lbt_modify" runat="server" CssClass="buttonc">MODIFY</asp:LinkButton>
                         <asp:LinkButton ID="lbt_authorize" runat="server" CssClass="buttonc">AUTHORIZE</asp:LinkButton>
                         <asp:LinkButton ID="lbt_delete" runat="server" CssClass="buttonc">DELETE</asp:LinkButton>
                         <asp:LinkButton ID="lbt_close" runat="server" CssClass="buttonc" 
                             Visible="False">CLOSE</asp:LinkButton>
                     </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px">
                &nbsp;</td>
            <td colspan="5">
                <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                 <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                 </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px">
                &nbsp;</td>
            <td style="width: 96px">
                         &nbsp;</td>
            <td style="width: 55px">
                         &nbsp;</td>
            <td colspan="2">
                         &nbsp;</td>
            <td>
                         &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

