<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="outstandingreasons1.aspx.vb" Inherits="OPS_outstandingreasons1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label13" runat="server" Text="Outstanding Reasons"></asp:Label>
                <asp:ImageButton ID="imb_close" runat="server" Height="20px" ImageAlign="Right" 
                    ImageUrl="~/Image/close24.png" />
            &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="InvoiceNo"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="txtinvoice" runat="server" CssClass="textbox" 
                    ToolTip="Please give Invoice No or Select Invoice from the List "></asp:TextBox>

                     <div id="divwidth" style="display:none;">   
                        <cc1:AutoCompleteExtender ID="txtinvoice_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" 
                            ServiceMethod="OPS_outstanding_invoice_rajan"   CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList"
                            TargetControlID="txtinvoice">
                        </cc1:AutoCompleteExtender>
                        </div>

                <asp:ImageButton ID="lnkfetch" runat="server" Height="12px" 
                    ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" />

                <br />
            </td>
            <td style="text-align: left">
                <asp:Label ID="Label12" runat="server" Text="Trans No."></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="txt_tranno" runat="server" CssClass="textbox"></asp:TextBox>
                            <asp:ImageButton ID="imb_tran_fetch" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" />
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                &nbsp;</td>
            <td style="text-align: left">
                &nbsp;</td>
            <td style="text-align: left">
                &nbsp;</td>
            <td style="text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="Label6" runat="server" Text="Invoice Date"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtinvdate" runat="server" CssClass="textbox" Height="17px" 
                            Width="68px" Enabled="False"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="text-align: left">
                <asp:Label ID="Label7" runat="server" Text="Freight Amount"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtfreight" runat="server" CssClass="textbox" Enabled="False" 
                            Height="19px" Width="68px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="Label8" runat="server" Text="Invoice amount "></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtinvamt" runat="server" CssClass="textbox" Enabled="False" 
                            Height="18px" Width="68px"  
                            ></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="text-align: left">
                <asp:Label ID="Label9" runat="server" Text="Outstanding"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtoutstanding" runat="server" CssClass="textbox" 
                            Enabled="False" Height="17px" Width="68px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" class=" " colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center" class=" " colspan="4">
                <asp:LinkButton ID="lnkfetch1" runat="server" CssClass="buttonc" 
                    Visible="False">Fetch</asp:LinkButton>
                <asp:LinkButton ID="Lnkclose" runat="server" CssClass="buttonc" Visible="False">Close </asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:ImageButton ID="imb_insertrow" runat="server" ImageAlign="Left" 
                    ImageUrl="~/Image/Expand.png" ToolTip="Add Row" />
            </td>
            <td style="text-align: left">
                &nbsp;</td>
            <td style="text-align: left">
                &nbsp;</td>
            <td style="text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td class=" " colspan="4" style="text-align: left">
                <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" 
                    AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imb_deleterow" runat="server" CommandName="Remove" 
                                    ImageAlign="Right" ImageUrl="~/Image/Collapse.png" ToolTip="Delete Row" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reason">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlreason" runat="server" CssClass="combobox" 
                                    Width="66px" SelectedValue='<%# eval("Reason") %>'>
                                    <asp:ListItem>CD</asp:ListItem>
                                    <asp:ListItem>CreditNote</asp:ListItem>
                                    <asp:ListItem>RG</asp:ListItem>
                                    <asp:ListItem>Intrest</asp:ListItem>
                                    <asp:ListItem>RateDiff.</asp:ListItem>
                                    <asp:ListItem>ShortRec.</asp:ListItem>
                                    <asp:ListItem>FOC</asp:ListItem>
                                    <asp:ListItem>Frt/Otheretc </asp:ListItem>
                                    <asp:ListItem>Claim</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:TextBox ID="txtdate" runat="server" CssClass="textbox" MaxLength="15" 
                                    Width="66px" Text='<%# eval("Date") %>' ></asp:TextBox>
                                      <cc1:CalendarExtender ID="txtdate_CalenderExtender" runat="server" Animated="False" 
                                    Format="MM/dd/yyyy" TargetControlID="txtdate">
                                </cc1:CalendarExtender>
                               
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate>
                                <asp:TextBox ID="txtamount" runat="server" CssClass="textbox" 
                                    Width="66px" Text='<%# eval("Amount") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dr/Cr">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddldrcr" runat="server" CssClass="combobox" Height="17px" 
                                   Width="39px" SelectedValue='<%# eval("dr/cr") %>'>
                                    <asp:ListItem>Dr</asp:ListItem>
                                    <asp:ListItem>Cr</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks">
                            <ItemTemplate>
                                <asp:TextBox ID="txtremarks" runat="server" Text='<%# Eval("Remarks") %>' 
                                    CssClass="textbox" MaxLength="50" ontextchanged="txtremarks_TextChanged"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="gridheader" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class=" buttonbackbar" colspan="4" style="text-align: center">
                <asp:LinkButton ID="lbt_view" runat="server" CssClass="buttonc" Visible="False">VIEW</asp:LinkButton>
                <asp:LinkButton ID="lbt_add" runat="server" CssClass="buttonc">ADD</asp:LinkButton>
                <asp:LinkButton ID="lbt_modify" runat="server" CssClass="buttonc">MODIFY</asp:LinkButton>
                <asp:LinkButton ID="lbt_authorize" runat="server" CssClass="buttonc">Authorise</asp:LinkButton>
                <asp:LinkButton ID="lbt_delete" runat="server" CssClass="buttonc" 
                    Visible="False">DELETE </asp:LinkButton>
                <asp:LinkButton ID="lbt_close" runat="server" CssClass="buttonc" 
                    Visible="False">CLOSE</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:LinkButton ID="lbt_apply" runat="server" CssClass="buttonc" 
                    Visible="False">APPLY</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: left">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:GridView ID="GridView2" runat="server" EnableModelValidation="True" 
                        Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Save">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnksaveremarks" runat="server" CommandName="SaveRemarks" 
                                         BorderStyle="Ridge">Save</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtremarks" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        </table>
<uc1:FlashMessage runat="server" ID="Fmsg" />
</asp:Content>



