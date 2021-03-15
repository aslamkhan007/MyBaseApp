<%@ Page Title="" Language="VB" MasterPageFile="~/Ops/MasterPage.master" AutoEventWireup="false" CodeFile="count_yarn_mapping_master.aspx.vb" Inherits="Costing_count_yarn_mapping_master" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 345px;">
        <tr>
            <td style="height: 38px; " colspan="3">
                <asp:Label ID="Label1" runat="server" Text="COUNT YARN MAPPING MASTER"></asp:Label>
            </td>
            <td style="height: 38px; width: 50px">
                <asp:Label ID="Label11" runat="server" CssClass="labelcells" Text="Action" 
                    Visible="False"></asp:Label>
            </td>
            <td style="height: 38px">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" CssClass="combobox" 
                            Width="100px" Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 38px">
            </td>
            <td style="height: 38px">
                <asp:ImageButton ID="imb_close" runat="server" Height="20px" 
                    ImageUrl="~/Image/close24.png" />
            </td>
        </tr>
        <tr>
            <td style="width: 53px; height: 12px;">
                
                <asp:Label ID="Label2" runat="server" Text="Yarn Desc." CssClass="labelcells" 
                    Width="80px" Visible="False"></asp:Label>
                
            </td>
            <td style="height: 12px" colspan="2">

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_yarndesc" runat="server" CssClass="textbox" Width="220px" 
                            AutoPostBack="True" Visible="False"></asp:TextBox>
                         <div id="divwidth" style="display: none;">
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                        CompletionInterval="10" CompletionListCssClass="AutoExtender"
                        CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                        CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20"
                            MinimumPrefixLength="2" ServiceMethod="GetItemcode" 
                            ServicePath="~/WebService.asmx" TargetControlID="txt_yarndesc" >
                        </cc1:AutoCompleteExtender>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </td>
            <td style="width: 50px; height: 12px;">
                <asp:Label ID="Label9" runat="server" CssClass="labelcells" Text="Tran. No."></asp:Label>
            </td>
            <td style="height: 12px">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_tranno" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:ImageButton ID="imb_tran_fetch" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 12px">
                &nbsp;</td>
            <td style="height: 12px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 53px; ">
                <asp:Label ID="Label16" runat="server" CssClass="labelcells" Text="Count Code" 
                    Width="70px"></asp:Label>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_count_code" runat="server" CssClass="textbox" 
                            Width="100px"></asp:TextBox>
                        <asp:ImageButton ID="imb_fetch" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 50px; ">
                <asp:Label ID="Label10" runat="server" CssClass="labelcells" Text="Status"></asp:Label>
                </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_status" runat="server" CssClass="labelcells" Text="..." 
                    Width="100px"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 53px; ">
                <asp:Label ID="Label17" runat="server" CssClass="labelcells" Text="Count Desc." 
                    Width="70px"></asp:Label>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_count_desc" runat="server" 
    CssClass="textbox" Width="150px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 50px; ">
                
                <asp:Label ID="Label12" runat="server" CssClass="labelcells" 
                    Text="Eff. From (M/D/Y)" Width="100px"></asp:Label>
                
                </td>
            <td>

                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_efffrom" runat="server" CssClass="textbox" Width="65px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalExt1" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_efffrom">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>

                </td>
            <td>
                
                <asp:Label ID="Label14" runat="server" CssClass="labelcells" Text="Dbase Code Warp" 
                    Width="100px" Visible="False"></asp:Label>
                
                </td>
            <td>

                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_dbase_code_warp" runat="server" CssClass="textbox" 
                            Width="95px" Visible="False"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>

                </td>
        </tr>
        <tr>
            <td style="width: 53px; ">
                <asp:Label ID="Label18" runat="server" CssClass="labelcells" Text="Mxg. Desc." 
                    Width="70px"></asp:Label>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_mixing_desc" runat="server" CssClass="textbox" 
                            Width="150px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 50px; ">
                
                <asp:Label ID="Label13" runat="server" CssClass="labelcells" 
                    Text="Eff. To (M/D/Y)" Width="100px"></asp:Label>
                
                </td>
            <td>

                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_effto" runat="server" CssClass="textbox" Width="65px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalExt2" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_effto">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>

                </td>
            <td>
                
                <asp:Label ID="Label15" runat="server" CssClass="labelcells" 
                    Text="Dbase Code Weft" Width="100px" Visible="False"></asp:Label>
                
            </td>
            <td>

                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_dbase_code_weft" runat="server" CssClass="textbox" 
                            Width="95px" Visible="False"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </td>
        </tr>
        <tr>
            <td style="width: 53px; ">
                <asp:Label ID="Label3" runat="server" Text="Main Fibre Code" 
                    CssClass="labelcells" Width="90px"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Sub Fibre Code" 
                    CssClass="labelcells" Width="90px"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Sub Fibre Desc." 
                    CssClass="labelcells" Width="90px"></asp:Label>
            </td>
            <td style="width: 50px; ">
                
                &nbsp;</td>
            <td>

                <asp:Label ID="Label19" runat="server" CssClass="labelcells" Text="Fibre %age"></asp:Label>

                </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td style="width: 53px; height: 52px;">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="lsb_main_fibre_code" runat="server" CssClass="textbox" 
                            Width="65px" Height="50px"></asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 52px">
                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="lsb_sub_fibre_code" runat="server" CssClass="textbox" 
                            Width="90px" Height="50px"></asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="2" style="height: 52px">
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="lsb_sub_fibre_desc" runat="server" CssClass="textbox" 
                            Width="220px" Height="50px"></asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 52px">

                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="lsb_fibre_percent" runat="server" CssClass="textbox" 
                            Height="50px" Width="80px">
                        </asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </td>
            <td style="height: 52px">

            </td>
            <td style="height: 52px">
                </td>
        </tr>
        <tr>
            <td style="width: 53px; height: 5px;">

            </td>
            <td style="height: 5px" colspan="2">
                
            </td>
            <td style="width: 50px; height: 5px;">
                
                

                </td>
            <td style="height: 5px">

                &nbsp;</td>
            <td style="height: 5px">

            </td>
            <td style="height: 5px">
                </td>
        </tr>
        <tr>
            <td colspan="5">
                
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="130px" 
                    Width="100%">
                    <div ID="AdjResultsDiv" style="width: 100%; height: 130px;">
                        <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    CssClass="labelcells" Font-Bold="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_select_yarn_desc" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="yarn_desc" HeaderText="Yarn Desc." />
                                        <asp:BoundField DataField="count_code" HeaderText="Count Code" />
                                        <asp:BoundField DataField="count_desc" HeaderText="Count Desc." />
                                        <asp:BoundField DataField="mixing_desc" HeaderText="Mxg. Desc." />
                                        <asp:BoundField DataField="eff_from" HeaderText="Eff. From" />
                                        <asp:BoundField DataField="eff_to" HeaderText="Eff. To" />
                                        <asp:BoundField DataField="status" HeaderText="Status" />
                                        <asp:BoundField DataField="tran_no" HeaderText="Tran. No." />
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td style="width: 53px; height: 11px;">
                &nbsp;</td>
            <td style="height: 11px" colspan="2">
                &nbsp;</td>
            <td style="width: 50px; height: 11px;">
                
                &nbsp;</td>
            <td style="height: 11px">

                &nbsp;</td>
            <td style="height: 11px">
                &nbsp;</td>
            <td style="height: 11px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 53px; height: 18px;">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbt_apply" runat="server" CssClass="buttonc" 
                            Visible="False">APPLY</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="4" style="height: 18px">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
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
            <td style="height: 18px">
                </td>
            <td style="height: 18px">
                </td>
        </tr>
        <tr>
            <td style="width: 53px; height: 4px;">
                </td>
            <td style="height: 4px" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                 <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 50px; height: 4px;">
                </td>
            <td style="height: 4px">
                </td>
            <td style="height: 4px">
                </td>
            <td style="height: 4px">
                </td>
        </tr>
        <tr>
            <td style="width: 53px">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td style="width: 50px">
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

