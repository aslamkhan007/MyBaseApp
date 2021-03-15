<%@ Page Title="" Language="VB" MasterPageFile="~/Ops/MasterPage.master" AutoEventWireup="false" CodeFile="process_rate_master.aspx.vb" Inherits="Costing_process_rate_master" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 291px;">
        <tr>
            <td style="height: 3px; width: 137px;">
                &nbsp;</td>
            <td style="height: 3px; width: 108px;">
                &nbsp;</td>
            <td style="width: 46px; height: 3px">
                &nbsp;</td>
            <td style="height: 3px; width: 110px;">
                &nbsp;</td>
            <td colspan="4">
                &nbsp;</td>
            <td style="height: 3px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 137px;">
                <asp:Label ID="Label1" runat="server" Text="Process Rate Master"></asp:Label>
            </td>
            <td style="width: 108px;">
                </td>
            <td style="width: 46px; ">
                <asp:Label ID="Label2" runat="server" CssClass="labelcells" Text="Action" 
                    Visible="False"></asp:Label>
            </td>
            <td style="width: 110px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" CssClass="combobox" 
                            Width="120px" Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="4">
                <asp:ImageButton ID="imb_close" runat="server" Height="20px" ImageAlign="Right" 
                    ImageUrl="~/Image/close24.png" />
            </td>
            <td>
                </td>
        </tr>
        <tr>
            <td style="height: 3px; width: 137px;">
                <asp:Label ID="Label3" runat="server" CssClass="labelcells" Text="Location"></asp:Label>
            </td>
            <td style="height: 3px; width: 108px;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_location" runat="server" CssClass="combobox" 
                            Width="100px">
                            <asp:ListItem>COTTON</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 46px; height: 3px">
                <asp:Label ID="Label21" runat="server" CssClass="labelcells" Text="Tran. No." 
                    Width="60px"></asp:Label>
            </td>
            <td style="height: 3px; width: 150px;">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_tranno" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                        <asp:ImageButton ID="imb_tran_fetch" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" />
                        <asp:Label ID="Label22" runat="server" CssClass="labelcells" Text="Status"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 3px; width: 47px;" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_status" runat="server" Text="OPEN"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 3px" width="200">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 3px; width: 137px;">
                <asp:Label ID="Label4" runat="server" CssClass="labelcells" 
                    Text="Process Location Code" Width="130px"></asp:Label>
            </td>
            <td style="height: 3px; width: 108px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_process_location_code" runat="server" 
                            CssClass="combobox" Width="100px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 46px; height: 3px">
                <asp:Label ID="Label6" runat="server" CssClass="labelcells" Text="Desc."></asp:Label>
            </td>
            <td style="height: 3px; width: 110px;">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_process_location_desc" runat="server" Text="..." 
                            CssClass="labelcells" Width="300px"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 3px; width: 47px;" colspan="4">
                <asp:Label ID="Label19" runat="server" CssClass="labelcells" 
                    Text="Recovery UOM" Width="100px" Visible="False"></asp:Label>
            </td>
            <td style="height: 3px" width="200">
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_recovery_uom" runat="server" CssClass="combobox" 
                            Width="66px" Visible="False">
                            <asp:ListItem>CANDY</asp:ListItem>
                            <asp:ListItem>KGS</asp:ListItem>
                            <asp:ListItem>MTR</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="height: 3px; width: 137px;">
                <asp:Label ID="Label5" runat="server" CssClass="labelcells" 
                    Text="Process Stage Code"></asp:Label>
            </td>
            <td style="height: 3px; width: 108px;">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_process_stage_code" runat="server" 
                            CssClass="combobox" Width="100px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 46px; height: 3px">
                <asp:Label ID="Label7" runat="server" CssClass="labelcells" Text="Desc."></asp:Label>
            </td>
            <td style="height: 3px; width: 110px;">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_process_stage_desc" runat="server" Text="..." 
                            CssClass="labelcells" Width="300px"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 3px; width: 47px;" colspan="4">
                <asp:Label ID="Label20" runat="server" CssClass="labelcells" 
                    Text="Recovery Method" Visible="False"></asp:Label>
            </td>
            <td style="height: 3px">
                        <asp:DropDownList ID="ddl_recovery_method" runat="server" CssClass="combobox" 
                            Width="66px" Visible="False">
                            <asp:ListItem>VALUE</asp:ListItem>
                            <asp:ListItem>PERCENT</asp:ListItem>
                            <asp:ListItem>SLAB</asp:ListItem>                        
                        </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 3px; width: 137px;">
                <asp:Label ID="Label8" runat="server" CssClass="labelcells" Text="Seq. No."></asp:Label>
            </td>
            <td style="width: 108px">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_seqno" runat="server" Text="..." CssClass="labelcells" 
                            Width="80px"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 46px">
                &nbsp;</td>
            <td style="width: 75px">
                &nbsp;</td>
            <td style="width: 47px" colspan="4">
                &nbsp;</td>
            <td width="200">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 137px;">
                <asp:Label ID="Label12" runat="server" CssClass="labelcells" 
                    Text="Process Rate DNV"></asp:Label>
            </td>
            <td style="width: 108px">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_process_rate_dnv" runat="server" CssClass="textbox" 
                            Width="60px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE1" runat="server" 
                            TargetControlID="txt_process_rate_dnv" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 46px">
                <asp:Label ID="Label16" runat="server" CssClass="labelcells" Text="Process UOM" 
                    Width="80px"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_process_uom" runat="server" CssClass="combobox" 
                            Width="66px">
                            <asp:ListItem>CANDY</asp:ListItem>
                            <asp:ListItem>KGS</asp:ListItem>
                            <asp:ListItem>MTR</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label10" runat="server" CssClass="labelcells" 
                            Text="Eff. From (mm/dd/yyyy)"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 47px" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_efffrom" runat="server" CssClass="textbox" Width="55px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalExt1" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_efffrom">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td width="200">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 137px;">
                <asp:Label ID="Label13" runat="server" CssClass="labelcells" 
                    Text="Process Rate DEP" Width="100px"></asp:Label>
            </td>
            <td style="width: 108px">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_process_rate_dep" runat="server" CssClass="textbox" 
                            Width="60px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE2" runat="server" 
                            TargetControlID="txt_process_rate_dep" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 46px">
                <asp:Label ID="Label17" runat="server" CssClass="labelcells" 
                    Text="Process Method" Width="100px"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_process_method" runat="server" CssClass="combobox" 
                            Width="66px">
                            <asp:ListItem>VALUE</asp:ListItem>
                            <asp:ListItem>PERCENT</asp:ListItem>
                            <asp:ListItem>SLAB</asp:ListItem>                        
                        </asp:DropDownList>
                        <asp:Label ID="Label11" runat="server" CssClass="labelcells" 
                            Text="Eff. To    (mm/dd/yyyy)"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 47px" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_effto" runat="server" CssClass="textbox" Width="55px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalExt2" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_effto">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td width="200">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 10px; width: 137px;">
                <asp:Label ID="Label14" runat="server" CssClass="labelcells" 
                    Text="Process Rate FOH" Width="100px"></asp:Label>
            </td>
            <td style="height: 10px; width: 108px;">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_process_rate_foh" runat="server" CssClass="textbox" 
                            Width="60px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE3" runat="server" 
                            TargetControlID="txt_process_rate_foh" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 46px; height: 13px;">
                <asp:Label ID="Label18" runat="server" CssClass="labelcells" 
                    Text="Recovery Rate"></asp:Label>
            </td>
            <td style="height: 10px; " width="70">
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_recovery_rate" runat="server" CssClass="textbox" 
                            Width="60px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE5" runat="server" 
                            TargetControlID="txt_recovery_rate" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 10px; " colspan="4">
                &nbsp;</td>
            <td style="height: 13px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 10px; width: 137px;">
                <asp:Label ID="Label15" runat="server" CssClass="labelcells" 
                    Text="Process Rate Own" Width="110px"></asp:Label>
            </td>
            <td style="height: 10px; width: 108px;">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_process_rate_own" runat="server" CssClass="textbox" 
                            Width="60px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE4" runat="server" 
                            TargetControlID="txt_process_rate_own" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 13px;">
                <asp:Label ID="Label9" runat="server" CssClass="labelcells" Text="Rate Type" 
                    Width="60px"></asp:Label>
            </td>
            <td style="height: 10px; " width="310">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_ratetype" runat="server" CssClass="combobox" 
                            Width="66px">
                            <asp:ListItem>BOOK</asp:ListItem>
                            <asp:ListItem>MARKET</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 10px; ">
                <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_top" runat="server" Height="12px" 
                            ImageUrl="~/Image/LeftArrow.png" ToolTip="Top Record" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 10px; ">
                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_next" runat="server" Height="12px" 
                            ImageUrl="~/Image/DNARROW.JPG" ToolTip="Next Record" style="width: 12px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 10px; ">
                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_previous" runat="server" Height="12px" 
                            ImageUrl="~/Image/UPARROW.JPG" ToolTip="Previous Record" Width="16px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 10px; ">
                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_last" runat="server" Height="12px" 
                            ImageUrl="~/Image/RightArrow.png" ToolTip="Last Record" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 13px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="9" width="600">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="150px" 
                    ScrollBars="Both" Width="750px">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                             <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="tran_no" HeaderText="Tran. No." />
                                        <asp:BoundField DataField="location" HeaderText="Location" />
                                        <asp:BoundField DataField="rate_type" HeaderText="Rate Type" />
                                        <asp:BoundField DataField="process_location_code" 
                                            HeaderText="Process Location Code" />
                                        <asp:BoundField DataField="process_location_desc" 
                                            HeaderText="Process Location Desc." />
                                        <asp:BoundField DataField="process_stage_code" 
                                            HeaderText="Process Stage Code" />
                                        <asp:BoundField DataField="process_stage_desc" 
                                            HeaderText="Process Stage Desc." />
                                        <asp:BoundField DataField="seq_no" HeaderText="Seq. No." />
                                        <asp:BoundField DataField="process_rate_dnv" HeaderText="Process Rate DNV" />
                                        <asp:BoundField DataField="process_rate_dep" HeaderText="Process Rate DEP" />
                                        <asp:BoundField DataField="process_rate_foh" HeaderText="Process Rate FOH" />
                                        <asp:BoundField DataField="process_rate_own" HeaderText="Process Rate OWN" />
                                        <asp:BoundField DataField="process_uom" HeaderText="Process UOM" />
                                        <asp:BoundField DataField="process_method" HeaderText="Process Method" />
                                        <asp:BoundField DataField="recovery_rate" HeaderText="Recovery Rate" />
                                        <asp:BoundField DataField="recovery_uom" HeaderText="Recovery UOM" />
                                        <asp:BoundField DataField="recovery_method" HeaderText="Recovery Method" />
                                        <asp:BoundField DataField="eff_from" HeaderText="Eff. From" />
                                        <asp:BoundField DataField="eff_to" HeaderText="Eff. To" />
                                        <asp:BoundField DataField="status" HeaderText="Status" />
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                </asp:GridView>
                            </ContentTemplate>
                       </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        </table>
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td align="center">
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
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
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbt_apply" runat="server" CssClass="buttonc" 
                            Visible="False">APPLY</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                 <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

