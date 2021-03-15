<%@ Page Title="" Language="VB" MasterPageFile="~/Ops/MasterPage.master" AutoEventWireup="false" CodeFile="count_process_mapping_transaction.aspx.vb" Inherits="Costing_count_process_mapping_transaction" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 111%; height: 342px;">
        <tr>
            <td style="height: 34px;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Count Process Mapping"></asp:Label>
            </td>
            <td style="width: 73px; height: 32px">
                <asp:Label ID="Label14" runat="server" CssClass="labelcells" Text="Action" 
                    Visible="False"></asp:Label>
            </td>
            <td style="height: 32px" width="150">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" CssClass="combobox" 
                            Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="width: 30px; height: 32px">
                &nbsp;</td>
            <td style="height: 32px" colspan="2" align="center">
                <asp:ImageButton ID="imb_close" runat="server" Height="20px" 
                    ImageUrl="~/Image/close24.png" />
            </td>
            <td style="width: 65px; height: 32px">
                </td>
            <td style="height: 32px">
                </td>
        </tr>
        <tr>
            <td style="width: 33px; height: 5px;">
                <asp:Label ID="Label2" runat="server" Text="Plant" CssClass="labelcells"></asp:Label>
            </td>
            <td style="height: 5px" width="80">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_location" runat="server" CssClass="combobox" 
                            Width="85px">
                            <asp:ListItem>COTTON</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 73px; height: 5px">
                <asp:Label ID="Label10" runat="server" CssClass="labelcells" Text="Tran. No."></asp:Label>
            </td>
            <td style="width: 140px; height: 5px">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_tranno" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        <asp:ImageButton ID="imb_tran_fetch" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" ToolTip="Fetch Tran. No." />
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="width: 30px; height: 5px">
                <asp:Label ID="Label11" runat="server" CssClass="labelcells" Text="Status"></asp:Label>
            </td>
            <td style="width: 85px; height: 5px" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_status" runat="server" Text="OPEN"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 65px; height: 5px">
                </td>
            <td style="height: 5px">
                </td>
        </tr>
        <tr>
            <td style="width: 33px; height: 14px;">
                <asp:Label ID="Label3" runat="server" CssClass="labelcells" Text="Count Code" 
                    Width="70px"></asp:Label>
            </td>
            <td style="height: 14px" width="110">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_countcode" runat="server" CssClass="textbox" Width="80px" 
                            AutoPostBack="True"></asp:TextBox>
                        <asp:ImageButton ID="imb_countcode_fetch" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="width: 73px; height: 14px">
                <asp:Label ID="Label4" runat="server" CssClass="labelcells" Text="Count Desc."></asp:Label>
            </td>
            <td style="width: 20px; height: 14px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_count_desc" runat="server" Text="..." CssClass="labelcells" 
                            Width="150px"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 30px; height: 14px">
                <asp:Label ID="Label7" runat="server" CssClass="labelcells" 
                    Text="Count Tran. No." Width="100px"></asp:Label>
                </td>
            <td style="width: 85px; height: 14px" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_countcode_tranno" runat="server" Text="..." 
                            CssClass="labelcells"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="width: 65px; height: 14px">
                </td>
            <td style="height: 14px">
                </td>
        </tr>
        <tr>
            <td style="width: 33px; height: 5px;">
                <asp:Label ID="Label6" runat="server" CssClass="labelcells" Text="Rate Type" 
                    Width="70px"></asp:Label>
            </td>
            <td style="height: 5px" width="80">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_ratetype" runat="server" CssClass="combobox">
                            <asp:ListItem>BOOK</asp:ListItem>
                            <asp:ListItem>MARKET</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 73px; height: 5px">
                <asp:Label ID="Label5" runat="server" CssClass="labelcells" Text="Mxg. Desc." 
                    Width="60px"></asp:Label>
            </td>
            <td style="width: 20px; height: 5px">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_mixing_desc" runat="server" Text="..." CssClass="labelcells" 
                            Width="150px"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 30px; height: 5px">
                <asp:Label ID="Label18" runat="server" CssClass="labelcells" Text="Factor" 
                    Width="50px"></asp:Label>
            </td>
            <td style="width: 85px; height: 5px" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_factor" runat="server" CssClass="textbox" Width="56px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBE1" runat="server" 
                            TargetControlID="txt_factor" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="width: 65px; height: 5px">
                </td>
            <td style="height: 5px">
                </td>
        </tr>
        <tr>
            <td style="width: 33px; height: 11px;">
                <asp:Label ID="Label8" runat="server" CssClass="labelcells" Text="Location"></asp:Label>
            </td>
            <td style="height: 11px" width="80">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_process_location_code" runat="server" 
                            CssClass="combobox" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 73px; height: 11px">
                <asp:Label ID="Label15" runat="server" CssClass="labelcells" 
                    Text="Location Desc." Width="90px"></asp:Label>
            </td>
            <td style="width: 20px; height: 11px">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_process_location_desc" runat="server" Text="..." 
                            CssClass="labelcells" Width="100px"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 30px; height: 11px">
                <asp:Label ID="Label12" runat="server" CssClass="labelcells" 
                    Text="Eff. From (mm/dd/yyyy)" Width="80px"></asp:Label>
            </td>
            <td style="width: 85px; height: 11px" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_efffrom" runat="server" CssClass="textbox" Width="56px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalExt1" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_efffrom">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 65px; height: 11px">
                </td>
            <td style="height: 11px">
                </td>
        </tr>
        <tr>
            <td style="width: 33px; height: 11px;">
                <asp:Label ID="Label9" runat="server" CssClass="labelcells" Text="Stage"></asp:Label>
                </td>
            <td style="height: 11px" width="85">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_process_stage_code" runat="server" 
                            CssClass="combobox" Width="85px" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="width: 73px; height: 11px">
                <asp:Label ID="Label16" runat="server" CssClass="labelcells" Text="Stage Desc." 
                    Width="80px"></asp:Label>
            </td>
            <td style="width: 20px; height: 11px">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_process_stage_desc" runat="server" Text="..." 
                            CssClass="labelcells" Width="100px"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 30px; height: 11px">
                <asp:Label ID="Label13" runat="server" CssClass="labelcells" 
                    Text="Eff. To (mm/dd/yyyy)" Width="80px"></asp:Label>
            </td>
            <td style="width: 85px; height: 11px" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_effto" runat="server" CssClass="textbox" Width="56px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalExt2" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_effto">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 65px; height: 11px">
                </td>
            <td style="height: 11px">
                </td>
        </tr>
        <tr>
            <td colspan="5" >
                
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" 
                    Width="550px" Height="187px">
                    <div id="AdjResultsDiv">
                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    CssClass="labelcells">
                                <EmptyDataTemplate>
                                    Records not Available
                                </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_select_process" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="tran_no" HeaderText="Tran. No." />
                                        <asp:BoundField DataField="process_rate_dnv" HeaderText="Rate DNV" />
                                        <asp:BoundField DataField="process_rate_dep" HeaderText="Rate DEP" />
                                        <asp:BoundField DataField="process_rate_foh" HeaderText="Rate FOH" />
                                        <asp:BoundField DataField="process_rate_own" HeaderText="Rate OWN" />
                                        <asp:BoundField DataField="recovery_rate" HeaderText="Rate Recovery" />
                                        <asp:BoundField DataField="process_uom" HeaderText="U.O.M." />
                                        <asp:BoundField DataField="process_method" HeaderText="Process Method" />
                                        <asp:BoundField DataField="eff_from" HeaderText="Eff. From" />                                        
                                        <asp:BoundField DataField="eff_to" HeaderText="Eff. To" />                                         
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle BackColor="Silver" />
                                </asp:GridView>
                                
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div> 
                </asp:Panel> 
                
            </td>
            <td style="width: 85px" colspan="2">
                <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" Height="187px" 
                    ScrollBars="Both" Width="130px">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                            <ContentTemplate>
                                <asp:CheckBoxList ID="chk_selected_process" runat="server" 
                                    CssClass="labelcells" AutoPostBack="True">
                                </asp:CheckBoxList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
            <td style="width: 65px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 33px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 73px">
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
            <td align="center" width="70">
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_add_process" runat="server" 
                            ImageUrl="~/Image/Expand.png" ToolTip="Add Process" style="width: 9px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="center" width="70">
                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_remove_process" runat="server" 
                            ImageAlign="Middle" ImageUrl="~/Image/Collapse.png" 
                            ToolTip="Remove Process" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 65px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 33px">
                &nbsp;</td>
            <td colspan="6">
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
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
            <td style="width: 65px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 33px">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbt_apply" runat="server" CssClass="buttonc" 
                            Visible="False">APPLY</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 85px" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_seqno" runat="server" Text="..." CssClass="labelcells" 
                            Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="width: 65px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

