<%@ Page Title="" Language="VB" MasterPageFile="~/Ops/MasterPage.master" AutoEventWireup="false" CodeFile="fibre_master.aspx.vb" Inherits="Costing_fibre_master" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 88%; height: 264px;">
        <tr>
            <td style="height: 41px;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="FIBRE MASTER"></asp:Label>
            </td>
            <td style="width: 51px; height: 41px;">
                <asp:Label ID="Label16" runat="server" CssClass="labelcells" Text="Action" 
                    Visible="False"></asp:Label>
                </td>
            <td style="height: 41px">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" CssClass="combobox" 
                            Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="height: 41px">
                </td>
            <td style="height: 41px" colspan="5">
                <asp:ImageButton ID="imb_close" runat="server" Height="20px" ImageAlign="Right" 
                    ImageUrl="~/Image/close24.png" />
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                <asp:Label ID="Label2" runat="server" CssClass="labelcells" Text="Location"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_location" runat="server" CssClass="combobox">
                            <asp:ListItem>COTTON</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 51px">
                <asp:Label ID="Label12" runat="server" CssClass="labelcells" Text="Tran.No."></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_tranno" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                        <asp:ImageButton ID="imb_tran_fetch" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" style="width: 15px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label13" runat="server" CssClass="labelcells" Text="Status"></asp:Label>
            </td>
            <td colspan="5">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_status" runat="server" Text="OPEN"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                <asp:Label ID="Label3" runat="server" Text="Main Fibre Code" 
                    CssClass="labelcells" Width="90px"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_main_fibre_code" runat="server" CssClass="combobox" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 51px">
                <asp:Label ID="Label5" runat="server" Text="Desc." CssClass="labelcells"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_main_fibre_desc" runat="server" CssClass="textbox" 
                            Width="250px" Enabled="False" AutoPostBack="True"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label14" runat="server" CssClass="labelcells" Text="Eff. From(mm/dd/yyyy)" 
                    Width="60px"></asp:Label>
            </td>
            <td colspan="5">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_efffrom" runat="server" CssClass="textbox" Width="53px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalExt1" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_efffrom">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                <asp:Label ID="Label4" runat="server" Text="Sub Fibre Code" 
                    CssClass="labelcells"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_sub_fibre_code" runat="server" CssClass="combobox" 
                            AutoPostBack="True" Width="100px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 51px">
                <asp:Label ID="Label6" runat="server" Text="Desc." CssClass="labelcells"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_sub_fibre_desc" runat="server" CssClass="textbox" 
                            Width="250px" Enabled="False" AutoPostBack="True"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label15" runat="server" CssClass="labelcells" 
                    Text="Eff. To(mm/dd/yyyy)"></asp:Label>
            </td>
            <td colspan="5">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_effto" runat="server" CssClass="textbox" Width="53px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalExt2" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_effto">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                <asp:Label ID="Label7" runat="server" CssClass="labelcells" Text="Fibre Group"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_fibre_group" runat="server" CssClass="combobox" 
                            Width="100px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 51px">
                <asp:Label ID="Label10" runat="server" CssClass="labelcells" Text="U.O.M."></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_uom" runat="server" CssClass="combobox">
                            <asp:ListItem>CANDY</asp:ListItem>
                            <asp:ListItem>KGS</asp:ListItem>
                            <asp:ListItem>MTR</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label9" runat="server" CssClass="labelcells" Text="Rate"></asp:Label>
            </td>
            <td colspan="5">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_rate" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                            TargetControlID="txt_rate" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                <asp:Label ID="Label8" runat="server" CssClass="labelcells" Text="Rate Type"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_rate_type" runat="server" CssClass="combobox">
                            <asp:ListItem>BOOK</asp:ListItem>
                            <asp:ListItem>MARKET</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 51px">
                <asp:Label ID="Label11" runat="server" CssClass="labelcells" Text="Currency"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_currency" runat="server" CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_top" runat="server" Height="15px" 
                            ImageUrl="~/Image/LeftArrow.png" ToolTip="First Record" 
                            style="width: 15px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_next" runat="server" Height="15px" 
                            ImageUrl="~/Image/DNARROW.JPG" ToolTip="Next Record" style="width: 15px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_previous" runat="server" Height="15px" 
                            ImageUrl="~/Image/UPARROW.JPG" ToolTip="Previous Record" 
                            style="width: 15px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_last" runat="server" Height="15px" 
                            ImageUrl="~/Image/RightArrow.png" ToolTip="Last Record" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="10">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="150px" 
                    ScrollBars="Both">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="tran_no" HeaderText="Tran.No." />
                                        <asp:BoundField HeaderText="Location" DataField="location" />
                                        <asp:BoundField HeaderText="Main Fibre Code" DataField="main_fibre_code" />
                                        <asp:BoundField DataField="main_fibre_desc" HeaderText="Main Fibre Desc." />
                                        <asp:BoundField HeaderText="Sub Fibre Code" DataField="sub_fibre_code" />
                                        <asp:BoundField HeaderText="Sub Fibre Desc." DataField="sub_fibre_desc" />
                                        <asp:BoundField HeaderText="Fibre Group" DataField="fibre_group" />
                                        <asp:BoundField HeaderText="Rate Type" DataField="rate_type" />
                                        <asp:BoundField HeaderText="Fibre Rate" DataField="fibre_rate" />
                                        <asp:BoundField HeaderText="Fibre UOM" DataField="fibre_uom" />
                                        <asp:BoundField HeaderText="Currency" DataField="currency_code" />
                                        <asp:BoundField HeaderText="Eff.From(d/m/y)" DataField="eff_from" />
                                        <asp:BoundField HeaderText="Eff.To(d/m/y)" DataField="eff_to" />
                                        <asp:BoundField DataField="status" HeaderText="Status" />
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbt_apply" runat="server" CssClass="buttonc" 
                            Visible="False">APPLY</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
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
            <td colspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 94px">
                &nbsp;</td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                 <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="5">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

