<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="outstandingreasons.aspx.vb" Inherits="OPS_outstandingreasons" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label1" runat="server" 
                    Text="Outstanding Reasons"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Sale Person
            </td>
            <td  class="NormalText">
                <div id="divwidth" style="display: none;">
                    <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" CompletionInterval="10"
                        CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="OPS_Customer"
                        CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                        TargetControlID="txtCustomer">
                    </cc1:AutoCompleteExtender>
                </div>
                <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td  class="NormalText">
                Customer
            </td>
            <td style="margin-left: 80px"  class="NormalText">
                <asp:TextBox ID="txtCustomer" runat="server" CssClass="textbox"
                    Width="200px" 
                    ToolTip="Please give Customer Code or Select Customer from the List " 
                    MaxLength="40"></asp:TextBox>
            </td>
            <td style="margin-left: 80px"  class="NormalText">
                <asp:LinkButton ID="CmdXl" runat="server" CssClass="buttonXL" Width="64px"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label18" runat="server" Text="Invoice No"></asp:Label>
            </td>
            <td  class="NormalText">
                <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="textbox" 
                    ToolTip="Enter invoice no." 
                    MaxLength="40"></asp:TextBox>
            </td>
            <td  class="NormalText" style>
                </td>
            <td style="margin-left: 80px; "  class="NormalText">
                </td>
            <td style="margin-left: 80px; "  class="NormalText">
                </td>
        </tr>
        <tr>
            <td class="NormalText">
                Basic Amount</td>
            <td  class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtbasicamt" runat="server" CssClass="textbox" Width="127px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td  class="NormalText">
                Freight Amount</td>
            <td style="margin-left: 80px"  class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtfreight" runat="server" CssClass="textbox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="margin-left: 80px"  class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                Invoice Amount</td>
            <td  class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtinvamt" runat="server" CssClass="textbox" 
                    EnableTheming="False"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td  class="NormalText">
                Outstanding</td>
            <td style="margin-left: 80px"  class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtoutstanding" runat="server" 
    CssClass="textbox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="margin-left: 80px"  class="NormalText">
                &nbsp;</td>
        </tr>
        </table>
    <table style="width: 100%;">
        <tr>
            <td style="text-align: center" class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc">Close
                </asp:LinkButton>
                        <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc">Save</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                        <br />
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
                
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="SqlDataSource1" EnableModelValidation="True" 
                        style="text-align: left; font-size: xx-small">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                            <asp:TemplateField HeaderText="Reasons A/C">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlFreight" runat="server" CssClass="combobox">
                                        <asp:ListItem>Cash</asp:ListItem>
                                        <asp:ListItem>Credit Note</asp:ListItem>
                                        <asp:ListItem>OtherIntrest</asp:ListItem>
                                        <asp:ListItem>RG/FOC</asp:ListItem>
                                        <asp:ListItem>Short Rec.</asp:ListItem>
                                        <asp:ListItem>Rate Diff.</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEff_From" runat="server" CssClass="textbox" MaxLength="15" 
                                        TabIndex="28" ValidationGroup="ValidGrpSaveDetail" Width="65px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalEfffr" runat="server" Animated="False" 
                                        Format="MM/dd/yyyy" TargetControlID="txtEff_From">
                                    </cc1:CalendarExtender>
                                    <cc1:MaskedEditExtender ID="MEE6" runat="server" Mask="99/99/9999" 
                                        MaskType="Date" TargetControlID="txtEff_From">
                                    </cc1:MaskedEditExtender>
                                    <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" 
                                        ControlToValidate="txtEff_From" Display="Dynamic" EmptyValueMessage="*" 
                                        InvalidValueMessage="Invalid" IsValidEmpty="False" TooltipMessage="MM/DD/YYYY" 
                                        ValidationGroup="ValidGrpSaveDetail"></cc1:MaskedEditValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtReturnQty" runat="server" CssClass="textbox" MaxLength="10" 
                                        Width="80px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dr/Cr">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddldrcr" runat="server" CssClass="combobox" 
                                        style="margin-left: 2px">
                                        <asp:ListItem>Debit</asp:ListItem>
                                        <asp:ListItem>Credit</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                        SelectCommand="select '' as Reason, '' as Date, '' as Amount, '' as DrCr union all select '' as Reason, '' as Date, '' as Amount, '' as DrCr">
                    </asp:SqlDataSource>
                
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
                <td  class="NormalText">
                &nbsp;</td>
                <td  class="NormalText">
                &nbsp;</td>
                <td  class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

