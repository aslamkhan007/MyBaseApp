<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="InternalPriority.aspx.vb" Inherits="OPS_InternalPriority" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label1" runat="server" 
                    Text="Processing - Internal Order Scheduling"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Planned From</td>
            <td>
                <asp:TextBox ID="txtEff_From" runat="server" CssClass="textbox" MaxLength="15" TabIndex="28"
                    ValidationGroup="ValidGrpSaveDetail" Width="65px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalEfffr" runat="server" Animated="False" Format="MM/dd/yyyy"
                    TargetControlID="txtEff_From">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MEE6" runat="server" Mask="99/99/9999" MaskType="Date"
                    TargetControlID="txtEff_From">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txtEff_From"
                    ValidationGroup="ValidGrpSaveDetail" Display="Dynamic" InvalidValueMessage="Invalid"
                    IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px"></cc1:MaskedEditValidator>
            </td>
            <td class="labelcells">
                PlannedTo
            </td>
            <td>
                <asp:TextBox ID="txtEff_To" runat="server" CssClass="textbox" MaxLength="15" 
                    TabIndex="29" ValidationGroup="ValidGrpSaveDetail" Width="65px"></asp:TextBox>
                <cc1:MaskedEditValidator ID="MEV7" runat="server" ControlExtender="MEE7" 
                    ControlToValidate="txtEff_To" Display="Dynamic" EmptyValueMessage="*" 
                    InvalidValueMessage="Invalid" IsValidEmpty="False" TooltipMessage="MM/DD/YYYY" 
                    ValidationGroup="ValidGrpSaveDetail" Width="114px"></cc1:MaskedEditValidator>
                <cc1:CalendarExtender ID="CalEffTo" runat="server" Animated="False" 
                    Format="MM/dd/yyyy" TargetControlID="txtEff_To">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MEE7" runat="server" Mask="99/99/9999" 
                    MaskType="Date" TargetControlID="txtEff_To">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                &nbsp;</td>
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
            <td>
                Sale Person
            </td>
            <td style="margin-left: 80px">
                <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td style="margin-left: 80px" rowspan="2">
                <asp:LinkButton ID="CmdXl" runat="server" CssClass="buttonXL" Width="64px"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td style="width: 250px">
                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>BLENDED</asp:ListItem>
                    <asp:ListItem>COTTON</asp:ListItem>
                    <asp:ListItem>POLYESTER</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Arrange By"></asp:Label>
            </td>
            <td style="width: 250px">
                
                <asp:DropDownList ID="ddlOrderBy" runat="server">
                    <asp:ListItem>Sort</asp:ListItem>
                    <asp:ListItem>Shade</asp:ListItem>
                    <asp:ListItem>SalePerson</asp:ListItem>
                    <asp:ListItem>Customer</asp:ListItem>
                    <asp:ListItem>Order No</asp:ListItem>
                </asp:DropDownList>
                
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: Left">
                &nbsp;</td>
            <td style="text-align: Left">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="5" style="text-align: center" class="buttonbackbar">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="Panel3" runat="server" CssClass="panelbg" ScrollBars="Auto" 
                    Width="100%">
                    <asp:GridView ID="GridView2" runat="server" EnableModelValidation="True">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                            <asp:TemplateField HeaderText="Priority">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Width="30px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="5" class="buttonbackbar">
                <asp:LinkButton ID="CmdApply" runat="server" BorderStyle="None" 
                    CssClass="buttonc">Apply</asp:LinkButton>
&nbsp;<asp:LinkButton ID="CmdClear" runat="server" BorderStyle="None" CssClass="buttonc">Clear</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
                <td>
                &nbsp;</td>
                <td>
                &nbsp;</td>
                <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

