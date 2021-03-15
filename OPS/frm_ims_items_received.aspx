<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_ims_items_received.aspx.vb" Inherits="OPS_frm_ims_items_received" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 102%; height: 362px;">
        <tr>
            <td style="height: 42px;" colspan="2">
                <asp:Label ID="Label1" runat="server" 
                    Text="Items Received"></asp:Label>
                </td>
            <td style="height: 42px">
                <asp:Label ID="Label3" runat="server" Text="Action" Visible="False"></asp:Label>
                </td>
            <td style="height: 42px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" Width="80px" 
                            CssClass="combobox" Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="height: 42px; width: 106px;">
                &nbsp;</td>
            <td style="height: 42px; width: 599px;">
                &nbsp;</td>
            <td style="height: 42px; width: 46px;">
                <asp:ImageButton ID="imb_close" runat="server" Height="18px" 
                    ImageUrl="~/Image/close24.png" ToolTip="Close" />
                </td>
            <td style="height: 42px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 7px;">
                <asp:Label ID="Label2" runat="server" CssClass="labelcells" Text="Item Group" 
                    Width="65px"></asp:Label>
                </td>
            <td style="height: 7px;" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_itemgroup" runat="server" CssClass="combobox" 
                            Width="300px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="height: 7px; width: 106px;">
                <asp:Label ID="Label4" runat="server" CssClass="labelcells" Text="From (m/d/y)" 
                    Width="80px"></asp:Label>
                </td>
            <td style="height: 7px; width: 599px;">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_fromdate" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_fromdate">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 7px; width: 46px;">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_tran_fetch" runat="server" Height="12px" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" ToolTip="Fetch Data" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 7px">
                </td>
        </tr>
        <tr>
            <td style="height: 2px;">
                <asp:Label ID="Label6" runat="server" CssClass="labelcells" Text="Supplier"></asp:Label>
            </td>
            <td style="height: 2px;" colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddl_supplier" runat="server" CssClass="combobox" 
                                    Width="300px">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
            </td>
            <td class="style3" style="height: 2px; width: 106px;">
                <asp:Label ID="Label5" runat="server" CssClass="labelcells" Text="To (m/d/y)" 
                    Width="65px"></asp:Label>
            </td>
            <td class="style3" style="height: 2px; width: 599px;">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_todate" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_todate">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="style3" style="height: 2px; width: 46px;">
                <asp:ImageButton ID="imb_excel" runat="server" Height="16px" 
                    ImageUrl="~/Image/XportXLFinal.png" ToolTip="Export to excel" />
            </td>
            <td class="style3" style="height: 2px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 2px;">
                <asp:Label ID="Label7" runat="server" CssClass="labelcells" Text="Item Code"></asp:Label>
            </td>
            <td style="height: 2px;">
                 <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                     <ContentTemplate>
                        <asp:TextBox ID="txt_itemcode" runat="server" CssClass="textbox" Width="120px" 
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
            <td class="style3" style="height: 2px">
                <asp:Label ID="Label8" runat="server" CssClass="labelcells" Text="Variant"></asp:Label>
            </td>
            <td class="style3" style="height: 2px">
                 <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                     <ContentTemplate>
                         <asp:TextBox ID="txt_variant" runat="server" CssClass="textbox" Width="120px" 
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
            <td class="style3" style="height: 2px; width: 106px;">
                &nbsp;</td>
            <td class="style3" style="height: 2px; width: 599px;">
                 <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" Height="12px" 
                            ImageUrl="~/Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                </td>
            <td class="style3" style="height: 2px; width: 46px;">
                &nbsp;</td>
            <td class="style3" style="height: 2px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 2px;">
                &nbsp;</td>
            <td style="height: 2px;">
                        &nbsp;</td>
            <td class="style3" style="height: 2px">
                &nbsp;</td>
            <td class="style3" style="height: 2px">
                 &nbsp;</td>
            <td class="style3" style="height: 2px; width: 106px;">
                &nbsp;</td>
            <td class="style3" style="height: 2px; width: 599px;">
                &nbsp;</td>
            <td class="style3" style="height: 2px; width: 46px;">
                &nbsp;</td>
            <td class="style3" style="height: 2px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 2px;" colspan="7">
                        <asp:Panel ID="Panel2" runat="server" Width="700px" Height="190px" 
                            ScrollBars="None" BorderStyle="Solid">
                            <div id="AdjResultsDiv"
                            style=" width: 100%; height:190px; left: -1px; top: 0px;">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GridView1" runat="server" 
                                            Font-Bold="False">
                                            <HeaderStyle CssClass="gridheader" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </asp:Panel>
            </td>
            <td class="style3" style="height: 2px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 2px;">
                &nbsp;</td>
            <td style="height: 2px;">
                <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                 FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
            </td>
            <td class="style3" style="height: 2px">
                &nbsp;</td>
            <td class="style3" style="height: 2px">
                &nbsp;</td>
            <td class="style3" style="height: 2px; width: 106px;">
                &nbsp;</td>
            <td class="style3" style="height: 2px; width: 599px;">
                &nbsp;</td>
            <td class="style3" style="height: 2px; width: 46px;">
                &nbsp;</td>
            <td class="style3" style="height: 2px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                        <asp:Panel ID="Panel1" runat="server" Height="20px" 
                    Width="100px" ScrollBars="Both" Visible="False">
                        <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="2" ImageSet="Simple" NodeIndent="25"
                            ShowLines="True" Font-Bold="False" Width="100%" Height="100%" 
                                Font-Size="Medium">
                            <ParentNodeStyle Font-Bold="False" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#DD5555" Font-Bold="True" />
                            <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px"
                                VerticalPadding="0px" />
                            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="0px"
                                NodeSpacing="0px" VerticalPadding="0px" />
                        </asp:TreeView>
                    </asp:Panel>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 106px">
                &nbsp;</td>
            <td style="width: 599px">
                &nbsp;</td>
            <td style="width: 46px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

