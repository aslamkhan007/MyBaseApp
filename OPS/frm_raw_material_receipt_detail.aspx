<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_raw_material_receipt_detail.aspx.vb" Inherits="OPS_frm_raw_material_receipt_detail" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 341px;">
        <tr>
            <td style="height: 35px; " colspan="2">
                <asp:Label ID="Label1" runat="server" 
                    Text="Raw Material Purchase Budget Report"></asp:Label>
            </td>
            <td style="height: 35px; width: 68px">
                <asp:Label ID="Label7" runat="server" CssClass="labelcells" Text="Action" 
                    Visible="False"></asp:Label>
            </td>
            <td style="height: 35px">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" 
    CssClass="combobox" Width="100px" Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 35px">
                &nbsp;</td>
            <td style="height: 35px" align="right">
                <asp:ImageButton ID="imb_close" runat="server" Height="16px" 
                    ImageUrl="~/Image/close24.png" />
            </td>
            <td style="height: 35px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 68px; height: 14px">
                <asp:Label ID="Label9" runat="server" CssClass="labelcells" Text="Plant"></asp:Label>
            </td>
            <td style="height: 14px; ">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_plant" runat="server" CssClass="combobox" 
                            Width="80px">
                            <asp:ListItem>COTTON</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>
                            <asp:ListItem>ALL</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 14px; width: 68px">
                &nbsp;</td>
            <td style="height: 14px">
                
            </td>
            <td style="height: 14px">
                &nbsp;</td>
            <td style="height: 14px">
                &nbsp;</td>
            <td style="height: 14px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 68px; height: 12px">
                <asp:Label ID="Label8" runat="server" CssClass="labelcells" Text="Item Group" 
                    Width="65px"></asp:Label>
            </td>
            <td style="height: 12px">
                
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_itemgroup" runat="server" CssClass="combobox" 
                            Width="330px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
            <td style="height: 12px">
                <asp:Label ID="Label5" runat="server" CssClass="labelcells" Text="Item Code" 
                    Width="60px"></asp:Label>
            </td>
            <td style="height: 12px">
                
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_itemcode" runat="server" CssClass="textbox" Width="100px" 
                            AutoPostBack="True"></asp:TextBox>
                        <div id="divwidth" style="display: none;">
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                        CompletionInterval="10" CompletionListCssClass="AutoExtender"
                        CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                        CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20"
                            MinimumPrefixLength="2" ServiceMethod="GetItemcode" 
                            ServicePath="~/WebService.asmx" TargetControlID="txt_itemcode" >
                        </cc1:AutoCompleteExtender>
                        </div>                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
            <td style="height: 12px">
                <asp:Label ID="Label2" runat="server" CssClass="labelcells" Text="From (M/D/Y)" 
                    Width="80px"></asp:Label>
            </td>
            <td style="height: 12px" width="200">
                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_fromdate" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CE1" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_fromdate">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
            <td style="height: 12px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 68px; height: 12px">
                <asp:Label ID="Label4" runat="server" CssClass="labelcells" Text="Supplier"></asp:Label>
            </td>
            <td style="height: 12px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_supplier" runat="server" Width="330px" 
                            CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 12px">
                <asp:Label ID="Label6" runat="server" CssClass="labelcells" Text="Variant"></asp:Label>
            </td>
            <td style="height: 12px">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_variant" runat="server" CssClass="textbox" Width="100px" 
                            AutoPostBack="True"></asp:TextBox>
                        <div id="divwidth2" style="display: none;">
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                        CompletionInterval="10" CompletionListCssClass="AutoExtender"
                        CompletionListElementID="divwidth"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                        CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20"
                            MinimumPrefixLength="0" ServiceMethod="GetVariant" 
                            ServicePath="~/WebService.asmx" TargetControlID="txt_variant" 
                            ContextKey="" UseContextKey="True">
                        </cc1:AutoCompleteExtender>
                        </div>                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 12px">
                <asp:Label ID="Label3" runat="server" CssClass="labelcells" Text="To (M/D/Y)"></asp:Label>
            </td>
            <td style="height: 12px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_todate" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CE2" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_todate">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 12px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 68px; height: 12px">
                &nbsp;</td>
            <td style="height: 12px">
                &nbsp;</td>
            <td style="height: 12px">
                &nbsp;</td>
            <td style="height: 12px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" Height="12px" 
                            ImageUrl="~/Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                </td>
            <td style="height: 12px">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_fetch" runat="server" Height="16px" 
                            ImageUrl="~/Image/searchBlueSmall.png" ToolTip="Fetch data" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 12px">
                <asp:ImageButton ID="imb_excel" runat="server" Height="16px" 
                    ImageUrl="~/Image/XportXLFinal.png" />
            </td>
            <td style="height: 12px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 5px;" colspan="6">
                <asp:Panel ID="Panel1" runat="server" Width="730px" BorderStyle="Solid" 
                    Height="250px" ScrollBars="None">
                    <div id = "AdjResultsDiv"
                         style=" width: 100%; height:250px; left: -1px; top: 0px;"> 
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" 
                                    Font-Bold="False">
                                    <HeaderStyle CssClass="GridHeader" />
                                <EmptyDataTemplate>
                                    Records not Available
                                </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
                </td>
            <td style="height: 5px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 68px; height: 5px;">
                &nbsp;</td>
            <td style="height: 5px;" colspan="3">
            </td>
            <td style="height: 5px">
                &nbsp;</td>
            <td style="height: 5px">
                &nbsp;</td>
            <td style="height: 5px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 68px; height: 5px;">
                &nbsp;</td>
            <td style="width: 126px; height: 5px;">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                  <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                  </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 68px; height: 5px;">
                &nbsp;</td>
            <td style="height: 5px">
                &nbsp;</td>
            <td style="height: 5px">
                &nbsp;</td>
            <td style="height: 5px">
                &nbsp;</td>
            <td style="height: 5px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 68px">
                &nbsp;</td>
            <td style="width: 126px">
                &nbsp;</td>
            <td style="width: 68px">
                &nbsp;</td>
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

