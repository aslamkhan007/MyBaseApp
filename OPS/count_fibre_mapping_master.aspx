<%@ Page Language="VB" MasterPageFile="~/Ops/MasterPage.master" AutoEventWireup="false" CodeFile="count_fibre_mapping_master.aspx.vb" Inherits="Costing_count_fibre_mapping_master" title="Untitled Page" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 107px;">
        <tr>
            <td colspan="5" style="height: 40px">
                <asp:Label ID="Label1" runat="server" Text="COUNT FIBRE MAPPING MASTER" 
                    Height="20px"></asp:Label>
            </td>
            <td style="height: 40px" colspan="2">
                <asp:Label ID="Label2" runat="server" Text="Action" Visible="False" 
                    CssClass="labelcells"></asp:Label>
            </td>
            <td style="height: 40px; " colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" CssClass="combobox" 
                            Width="108px" Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="height: 40px" colspan="3">
                <asp:ImageButton ID="imb_close" runat="server" Height="20px" ImageAlign="Right" 
                    ImageUrl="~/Image/close24.png" />
            </td>
        </tr>
        <tr>
            <td style="width: 179px">
                <asp:Label ID="Label5" runat="server" Text="Count Code" Width="70px" 
                    CssClass="labelcells"></asp:Label>
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_countcode" runat="server" CssClass="textbox" 
                            Width="55px" AutoPostBack="True"></asp:TextBox>
                        <asp:ImageButton ID="imb_fetch" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" style="width: 15px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 83px">
                <asp:Label ID="Label6" runat="server" Text="Count Desc." Width="70px" 
                    CssClass="labelcells"></asp:Label>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_countdesc" runat="server" CssClass="textbox" 
                            Width="150px" Enabled="False"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="2" style="width: 72px">
                <asp:Label ID="Label3" runat="server" Text="Tran. No." Width="50px" 
                    CssClass="labelcells"></asp:Label>
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_tranno" runat="server" CssClass="textbox" Width="87px"></asp:TextBox>
                        <asp:ImageButton ID="imb_tran_fetch" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" style="width: 15px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 179px">
                <asp:Label ID="Label4" runat="server" Text="Location" CssClass="labelcells"></asp:Label>
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_location" runat="server" CssClass="combobox" 
                            Width="81px">
                            <asp:ListItem>COTTON</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 83px">
                <asp:Label ID="Label7" runat="server" Text="Mxg. Desc." CssClass="labelcells"></asp:Label>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_mxgdesc" runat="server" CssClass="textbox" 
                            Width="150px" Enabled="False" Height="16px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="2" style="width: 72px">
                <asp:Label ID="Label10" runat="server" Text="Status" CssClass="labelcells"></asp:Label>
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_status" runat="server" Text="OPEN"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 179px">
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
            <td style="width: 83px">
                <asp:Label ID="Label8" runat="server" Text="Eff From (mm/dd/yyyy)" 
                    CssClass="labelcells"></asp:Label>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <cc1:CalendarExtender ID="CalExt1" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_efffrom">
                        </cc1:CalendarExtender>
                        <asp:TextBox ID="txt_efffrom" runat="server" CssClass="textbox" Width="55px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="2" style="width: 72px">
                <asp:Label ID="Label9" runat="server" Text="Eff. To (mm/dd/yyyy)" 
                    CssClass="labelcells"></asp:Label>
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <cc1:CalendarExtender ID="CalExt2" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_effto">
                        </cc1:CalendarExtender>
                        <asp:TextBox ID="txt_effto" runat="server" CssClass="textbox" 
                            Width="55px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 179px" align="right">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_top" runat="server" 
    ImageUrl="~/Image/LeftArrow.png" ToolTip="First Record" Width="15px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td align="right">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_next" runat="server" 
    ImageUrl="~/Image/DNARROW.JPG" ToolTip="Next Record" Width="15px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td align="right">
                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_previous" runat="server" 
    ImageUrl="~/Image/UPARROW.JPG" ToolTip="Previous Record" Width="15px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td colspan="2" align="center">
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_last" runat="server" 
    ImageUrl="~/Image/RightArrow.png" ToolTip="Last Record" Width="15px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td align="right">
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_insertrow" runat="server" ImageAlign="Left" 
                            ImageUrl="~/Image/Expand.png" ToolTip="Add Row" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td colspan="4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" BorderStyle="Solid" 
                    Width="360px" Height="150px">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    Font-Bold="False" Width="338px">
                                    <Columns>
                                    <asp:TemplateField >
                                    <ItemTemplate>
                                    <asp:ImageButton ID="imb_deleterow" runat="server"  CommandName="Remove"
                                             ImageAlign="Right" ImageUrl="~/Image/Collapse.png" ToolTip="Delete Row" 
                                            Height="10px" />
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MAIN FIBRE CODE">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddl_main_fibre_code" runat="server" CssClass="combobox">
                                                    <asp:ListItem>COT</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("main_fibre_code") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SUB FIBRE CODE">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddl_sub_fibre_code" runat="server" CssClass="combobox" 
                                                    Width="100px">
                                                    <asp:ListItem>COT001</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("sub_fibre_code") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                           <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FIBRE %age">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_fibre_percent" runat="server" CssClass="textbox" 
                                                    Height="18px" Text='<%# Eval("fibre_percent") %>' Width="50px"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                                                    TargetControlID="txt_fibre_percent" ValidChars="0123456789.">
                                                </cc1:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("fibre_percent") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
                </td>
            <td colspan="6">
                <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" Font-Size="Smaller" 
                    Height="150px">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                            <ContentTemplate>
                                <asp:ListBox ID="ListBox1" runat="server" CssClass="textbox" Height="150px" 
                                    Width="100%"></asp:ListBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 179px">
                </td>
            <td colspan="10">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
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
            <td>
                </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 179px">
                &nbsp;</td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbt_apply" runat="server" CssClass="buttonc" 
                            Visible="False">APPLY</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 83px">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2" style="width: 72px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 268435456px">
                &nbsp;</td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 179px">
                &nbsp;</td>
            <td colspan="9" >
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                 <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 268435456px">
                &nbsp;</td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 179px">
                </td>
            <td colspan="3">
                </td>
            <td style="width: 83px">
                </td>
            <td colspan="2">
                </td>
            <td colspan="2" style="width: 72px">
                </td>
            <td>
                </td>
            <td style="width: 268435456px">
                </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

