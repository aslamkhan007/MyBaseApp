<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="CurrentProcessPlan.aspx.vb" Inherits="OPS_CurrentProcessPlan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width: 800px;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label1" runat="server" Text="Process Plan Detail"></asp:Label>
            </td>
        </tr>
        <tr>



        <td class="labelcells">
                Customer
            </td>
            <td>
                <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" CssClass="textbox"
                    Width="200px" ToolTip="Please give Customer Code or Select Customer from the List "></asp:TextBox>
                <div id="divwidth" style="display: none;">
                    <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" CompletionInterval="10"
                        CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="OPS_Customer"
                        CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                        TargetControlID="txtCustomer">
                    </cc1:AutoCompleteExtender>
                </div>
            </td>
            <td class="labelcells">
                Sale Person
            </td>
            <td colspan="1">
                <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            
         
        </tr>
        <tr>

           <td>
            Order No
            </td>
            <td>
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox" ></asp:TextBox>
            </td>

            <td>
                Plant
            </td>
            <td style="margin-left: 80px">
                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>BLENDED</asp:ListItem>
                    <asp:ListItem>COTTON</asp:ListItem>
                    <asp:ListItem>POLYESTER</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                DateFrom
            </td>
            <td style="width: 250px">
                <asp:TextBox ID="txtEff_From" runat="server" CssClass="textbox" MaxLength="15" TabIndex="28"
                    ValidationGroup="ValidGrpSaveDetail" Width="65px"></asp:TextBox>
                <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txtEff_From"
                    ValidationGroup="ValidGrpSaveDetail" Display="Dynamic" InvalidValueMessage="Invalid"
                    IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px"></cc1:MaskedEditValidator>
                <cc1:CalendarExtender ID="CalEfffr" runat="server" Animated="False" Format="MM/dd/yyyy"
                    TargetControlID="txtEff_From">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MEE6" runat="server" Mask="99/99/9999" MaskType="Date"
                    TargetControlID="txtEff_From">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                DateTo
            </td>
            <td style="width: 250px">
                <asp:TextBox ID="txtEff_To" runat="server" CssClass="textbox" MaxLength="15" TabIndex="29"
                    ValidationGroup="ValidGrpSaveDetail" Width="65px"></asp:TextBox>
                <cc1:MaskedEditValidator ID="MEV7" runat="server" ControlExtender="MEE7" ControlToValidate="txtEff_To"
                    ValidationGroup="ValidGrpSaveDetail" Display="Dynamic" InvalidValueMessage="Invalid"
                    IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px"></cc1:MaskedEditValidator>
                <cc1:CalendarExtender ID="CalEffTo" runat="server" Animated="False" Format="MM/dd/yyyy"
                    TargetControlID="txtEff_To">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MEE7" runat="server" Mask="99/99/9999" MaskType="Date"
                    TargetControlID="txtEff_To">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label2" runat="server" Text="PlanType"></asp:Label>
            </td>
            <td style="width: 250px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlOPtion" runat="server" CssClass="combobox" 
                        AutoPostBack="True">
                    <asp:ListItem>Fresh</asp:ListItem>
                    <asp:ListItem>Re-Dyeing</asp:ListItem>
                    <asp:ListItem>Shortfall</asp:ListItem>
                    </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td style="width: 250px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:LinkButton ID="CmdFetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
                <asp:LinkButton ID="CmdXl" runat="server" CssClass="buttonXL" Width="64px"></asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" 
                    onclientclick="window.history.go(-1);return false;">&lt;&lt; Back</asp:LinkButton>
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="10">
                    <ProgressTemplate>
                        <asp:Image ID="ImageProg" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" PageSize="50" Width="100%" 
                            EnableModelValidation="True">
                            <AlternatingRowStyle CssClass="GridAI" />
                             <Columns>
                                 <asp:TemplateField>
                                     <ItemTemplate>
                                           <asp:LinkButton ID="CmdRemove" runat="server" 
                                                    CommandArgument='<%# Eval("TransID") %>' CommandName="Remove">Remove</asp:LinkButton>
                                                <cc1:ConfirmButtonExtender ID="CmdRemove_ConfirmButtonExtender" runat="server" 
                                                    ConfirmText="Are you Sure to Delete this Record...." Enabled="True" 
                                                    TargetControlID="CmdRemove">
                                                </cc1:ConfirmButtonExtender>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:BoundField DataField="OrderNo" HeaderText="OrderNo" ReadOnly="True" 
                                     SortExpression="OrderNo" />
                                 <asp:BoundField DataField="LineItem" HeaderText="LineItem" />
                                 <asp:BoundField DataField="Item" HeaderText="Sort" />
                                 <asp:BoundField DataField="Shade" HeaderText="Shade" />
                                 <asp:BoundField DataField="OrderQty" HeaderText="OrderQty" />
                                 <asp:BoundField DataField="ReqDyngQty" HeaderText="ReqDyngQty" />
                                 <asp:BoundField DataField="ReqDyngDate" HeaderText="ReqDyngDt" />
                                 <asp:BoundField DataField="Remarks" HeaderText="ComentsForDyng" />
                                 <asp:BoundField DataField="ReqFinishQty" HeaderText="ReqFinishQty" />
                                 <asp:BoundField DataField="ReqFinishDate" HeaderText="ReqFinishDt" />
                                 <asp:BoundField DataField="FinsihRemarks" HeaderText="ComentsForFinishing" />
                                 <asp:BoundField DataField="TransID" HeaderText="TransID">
                                 <ItemStyle Width="0px" />
                                 </asp:BoundField>
                            </Columns>
                             <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

