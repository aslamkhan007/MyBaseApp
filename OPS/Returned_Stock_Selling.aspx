<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Returned_Stock_Selling.aspx.vb" Inherits="OPS_Returned_Stock_Selling" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Retruned / Re-Invoicing goods Sanction</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel6" runat="server" BorderColor="#837D7C" BorderWidth="1px" Width="100%">
                    <table style="width: 100%;" class="tableback">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblValue1" runat="server">Sort</asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSearchSort" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblValue2" runat="server">Variant</asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSearchVariant" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqdVariant" runat="server" ControlToValidate="txtSearchVariant"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="SearchGroup"></asp:RequiredFieldValidator>
                                        <asp:LinkButton ID="CmdSearchData" runat="server" CssClass="searchbluesmall" Height="17px"
                                            Width="16px" ValidationGroup="SearchGroup"></asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="3">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="ImageProg0" runat="server" ImageUrl="~/Image/Progress02.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:Label ID="lblID" runat="server" Font-Size="Medium"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" width="95%">
                <asp:Panel ID="Panel1" runat="server" Height="300px">
                    <asp:UpdatePanel ID="UpdatePanel16" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="Panel3" runat="server" Height="300px" ScrollBars="Both" Width="99%">
                                <asp:GridView ID="GrdPackedForOrder" runat="server" Width="100%" EnableModelValidation="True"
                                    ShowFooter="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sel">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkOrderItems" runat="server" />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkOrderSelAll" runat="server" AutoPostBack="True" 
                                                    oncheckedchanged="ChkOrderSelAll_CheckedChanged" />
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Bales Packed for&nbsp; Source Order..
                                    </EmptyDataTemplate>
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                                <asp:GridView ID="GrdBasicDetail" runat="server" EnableModelValidation="True" Width="100%">
                                    <AlternatingRowStyle CssClass="GridAI" />

                                    <Columns>
                                       
                                        <asp:TemplateField HeaderText="Sel">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkBasicDetail_SelAll" runat="server" OnCheckedChanged="ChkBasicDetail_SelAll_CheckedChanged"
                                                    AutoPostBack="true" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkBox" runat="server" 
                                                   />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        Not Data Found... !!!
                                    </EmptyDataTemplate>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <RowStyle CssClass="GridItem" />
                                </asp:GridView>
                            </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                           <%-- <asp:AsyncPostBackTrigger ControlID="cmdSearch" EventName="Click" />--%>
                            <asp:AsyncPostBackTrigger ControlID="CmdSearchData" EventName="Click" />
                            <%--<asp:AsyncPostBackTrigger ControlID="CmdRefresh" EventName="Click" />--%>
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                    <ContentTemplate>
                        <%--  <asp:LinkButton ID="CmdAddItem" runat="server" Font-Size="Larger">+</asp:LinkButton>--%>
                        <asp:ImageButton ID="imgAddRow" runat="server"  ImageUrl="~/Image/Icons/Action/iPhoneAdd.png"
                            ToolTip="Click to Add More Rows" ValidationGroup="a" Width="24px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <hr />
        <tr>
            <td colspan="3">
                <asp:Panel ID="Panel4" runat="server" Width="100%">
                    <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdTempValues" runat="server" Width="99%" EnableModelValidation="True"
                                ShowFooter="True" AutoGenerateColumns="true">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkDelete" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <%--<asp:TemplateField HeaderText="SalePrice">
                                    <ItemTemplate> <asp:TextBox ID="txtSP" runat="server" CssClass="textbox" Width="100px"></asp:TextBox> </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField></asp:TemplateField>--%>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                    <ContentTemplate>
                        <%--     <asp:LinkButton ID="cmdDeleteRows" runat="server" CssClass="btncross" Height="21px"
                            ToolTip="Click To Clear All Selected Items" Width="24px"></asp:LinkButton>--%>
                        <asp:ImageButton ID="ImgDelRows" runat="server" CausesValidation="False" CommandName="Delete"
                            ImageUrl="~/OPS/Image/iPhone_Delete_icon.png" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GrdCostDetail" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
                            Width="100%">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:BoundField DataField="Sort" HeaderText="Sort" />
                                <asp:BoundField DataField="Variant" HeaderText="Variant" />
                                <asp:TemplateField HeaderText="SellingPrice">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtProposedSellingPrice" runat="server" CssClass="textbox" Width="55px"
                                            MaxLength="6"></asp:TextBox>
                                        <%--     <cc1:FilteredTextBoxExtender ID="txtProposedSellingPrice_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtProposedSellingPrice" 
                                            ValidChars=".0123456789">
                                         
                                        </cc1:FilteredTextBoxExtender>--%>
                                        <telerik:RadInputManager ID="RadInputManager1" runat="server">
                                            <telerik:NumericTextBoxSetting AllowRounding="False" Culture="en-US" DecimalDigits="2"
                                                DecimalSeparator="." GroupSeparator="," GroupSizes="3" MaxValue="999" MinValue="1"
                                                NegativePattern="-n" PositivePattern="n" SelectionOnFocus="SelectAll" ZeroPattern="n">
                                                <TargetControls>
                                                    <telerik:TargetInput ControlID="RadInputManager1" />
                                                    <telerik:TargetInput ControlID="txtProposedSellingPrice" />
                                                </TargetControls>
                                                <Validation IsRequired="True" />
                                                <Validation IsRequired="True" />
                                            </telerik:NumericTextBoxSetting>
                                        </telerik:RadInputManager>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RateUom">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlRateUom" runat="server">
                                            <asp:ListItem Value="Meter">Meter</asp:ListItem>
                                            <asp:ListItem>Yards</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                Not Data Found... !!!
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Plant</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Subject
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" MaxLength="100" 
                            Width="224px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="ImageProg" runat="server" ImageUrl="~/Image/Progress02.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top">
                Description
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" Height="150px"
                            MaxLength="800" TextMode="MultiLine" ToolTip="Give Detail description of raising this sanction request (upto 800Charcter)."
                            Width="400px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="always">
                    <ContentTemplate>
                        <asp:Panel ID="Pnl_Emplyee_Hierarchy" runat="server" Height="150px" ScrollBars="Vertical">
                            <asp:GridView ID="GrdEmployee" runat="server" Width="99%">
                                <PagerStyle CssClass="PagerStyle" />
                                <AlternatingRowStyle CssClass="GridAI" />
                                <EmptyDataTemplate>
                                    No Data Found...! ! !
                                </EmptyDataTemplate>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
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
            </td>
        </tr>
        <tr>
            <td align="center" class="buttonbackbar" colspan="4" valign="middle">
                <asp:LinkButton ID="cmdApply" runat="server" BorderStyle="None" 
                    CssClass="buttonc">Apply</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="cmdClear" runat="server" BorderStyle="None" 
                    CssClass="buttonc">Clear</asp:LinkButton>
            </td>
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

