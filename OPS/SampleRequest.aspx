<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="SampleRequest.aspx.vb" Inherits="OPS_SampleRequest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                Request Sample</td>
        </tr>
        </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td>
                
                Sample Type</td>
            <td>
                
                <asp:DropDownList ID="ddlSampleType" runat="server" Width="150px">
                    <asp:ListItem>Seasonal</asp:ListItem>
                    <asp:ListItem>Promotional</asp:ListItem>
                </asp:DropDownList>
                
            </td>
            <td>
                </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td>
                
                Sale Person</td>
            <td>
                
                <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox">
                </asp:DropDownList>
                
            </td>
            <td>
                Customer</td>
            <td>
                      <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" 
                            CssClass="textbox"  Width="200px" ToolTip="Please give Customer Code or Select Customer from the List " ></asp:TextBox>
  
                    <div id="divwidth" style="display:none;">   
                        <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" 
                            ServiceMethod="OPS_Customer"   CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList"
                            TargetControlID="txtCustomer">
                        </cc1:AutoCompleteExtender>
                        </div>
            </td>
        </tr>
        <tr>
            <td>
                
                Customer Address</td>
            <td>
                
                <asp:DropDownList ID="ddlAddress" runat="server" CssClass="combobox" 
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>
                FOC</td>
            <td>
                
                <asp:DropDownList ID="ddlFOC" runat="server" Width="50px">
                    <asp:ListItem>Y</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                
                &nbsp;</td>
            <td colspan="3">
                
                <asp:GridView ID="grdAddressDetail" runat="server" Width="100%">
                    <AlternatingRowStyle CssClass="GridAI" />     
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                
                Sale Type</td>
            <td>
                
                <asp:DropDownList ID="ddlSaleType" runat="server" CssClass="combobox" 
                    Width="100px">
                    <asp:ListItem>Domestic</asp:ListItem>
                    <asp:ListItem>Export</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                Remarks(If Any)</td>
            <td>
                
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                
                Season</td>
            <td>
                
                <asp:DropDownList ID="ddlSeason" runat="server" CssClass="combobox" 
                    Width="100px">
                    <asp:ListItem>Summer</asp:ListItem>
                    <asp:ListItem>Winter</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                RequiredDate</td>
            <td>
                
               <asp:TextBox ID="txtEff_From" runat="server" CssClass="textbox" MaxLength="15" TabIndex="28"
                    ValidationGroup="ValidGrpSaveDetail" Width="65px"></asp:TextBox>
                <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txtEff_From"
                    ValidationGroup="ValidGrpSaveDetail" Display="Dynamic" InvalidValueMessage="Invalid"
                    IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px">

                </cc1:MaskedEditValidator>
                <cc1:CalendarExtender ID="CalEfffr" runat="server" Animated="False" Format="MM/dd/yyyy"
                    TargetControlID="txtEff_From">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MEE6" runat="server" Mask="99/99/9999" MaskType="Date"
                    TargetControlID="txtEff_From">
                </cc1:MaskedEditExtender></td>
        </tr>
        <tr>
            <td>
                
                &nbsp;</td>
            <td colspan="3">
                
                <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="False" 
                    EnableModelValidation="True" ShowFooter="True">
                <AlternatingRowStyle CssClass="GridAI" />     
                        <Columns>
                            <asp:TemplateField>
                                <FooterTemplate>
                                    <asp:ImageButton ID="imgAddRow" runat="server" CommandName="Add" 
                                        ImageUrl="~/Image/Icons/Action/iPhoneAdd.png" OnClick="imgAddRow_Click" 
                                        ToolTip="Click to Add More Rows" ValidationGroup="a" Width="24px" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                        CommandName="Delete" ImageUrl="~/OPS/Image/iPhone_Delete_icon.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SrNo" HeaderText="SrNo" />
                            <asp:TemplateField HeaderText="Sort">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSort" runat="server" CssClass="textbox" MaxLength="7" 
                                        Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Shade">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtShade" runat="server" CssClass="textbox" MaxLength="30" 
                                        Width="120px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQty" runat="server" CssClass="textbox" MaxLength="5" 
                                        Width="40px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtQty_FilteredTextBoxExtender" runat="server" 
                                        Enabled="True" FilterType="Numbers" TargetControlID="txtQty" 
                                        ValidChars="0123456789">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ApproxValue">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtValue" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtValue_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtValue" 
                                        ValidChars="0123456789">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                    </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                
                <asp:LinkButton ID="CmdApply" runat="server" CssClass="buttonc">Apply</asp:LinkButton>
&nbsp;<asp:LinkButton ID="cmdReset" runat="server" BorderStyle="None" CssClass="buttonc">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                
                <asp:Label ID="Label1" runat="server" 
                    Text="**Note :- System will Maintain minimum and Maximum Qty of Stock"></asp:Label>
            </td>
            <td>
                
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                
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

