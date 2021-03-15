<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="frm_items_movement_before_transaction.aspx.vb" Inherits="OPS_frm_items_movement_before_transaction" title="Untitled Page" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <link rel="stylesheet" type="text/css" href="../stylesheets/stylesheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/formatingsheet.css" />
    <table style="width:100%; height: 67px;">
        <tr>
            <td colspan="6" style="height: 36px">
                <asp:Label ID="Label1" runat="server" Text="Items Movement Before Transactions"></asp:Label>
            </td>
            <td style="height: 36px; width: 127px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 62px; height: 20px;">
                <asp:Label ID="Label3" runat="server" CssClass="labelcells" Text="Gr/Upr No." 
                    Width="100%"></asp:Label>
            </td>
            <td style="width: 168px; height: 20px;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_grupr_no" runat="server" CssClass="textbox" 
                            Width="100px" AutoPostBack="True" TabIndex="10"></asp:TextBox>
                        <asp:ImageButton ID="imb_grupr_no_fetch" runat="server" 
                            ImageUrl="~/Image/searchBlueSmall.png" />
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 50px; height: 20px;">
                <asp:Label ID="Label8" runat="server" Text="Tran. No."></asp:Label>
            </td>
            <td style="width: 168px; height: 20px;">
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_entryno" runat="server" CssClass="textbox"   
                            AutoPostBack="True" TabIndex="40"></asp:TextBox>
                        <asp:ImageButton ID="imb_tranno_fetch" runat="server" 
                            ImageUrl="~/Image/searchBlueSmall.png" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 168px; height: 20px;" colspan="2">
                        
                            <asp:LinkButton ID="lnk_print" runat="server" CssClass="buttonc">Print</asp:LinkButton>
            </td>
            <td style="height: 20px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 19px">
                <asp:Label ID="Label4" runat="server" CssClass="labelcells" Text="Item Code" 
                    Width="100%"></asp:Label>
            </td>
            <td style="height: 19px; width: 168px">
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_itemcode" runat="server" CssClass="textbox" 
                            Width="100px" AutoPostBack="True" TabIndex="20"></asp:TextBox>
                        <asp:ImageButton ID="imb_itemcode_fetch" runat="server" style="width: 14px" 
                            ImageUrl="~/Image/searchBlueSmall.png" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 19px; width: 50px">
                <asp:Label ID="Label7" runat="server" Text="Action" Visible="False"></asp:Label>
            </td>
            <td style="height: 19px; width: 168px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" CssClass="combobox" 
                            Height="20px" Width="129px" Visible="False" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 19px; width: 168px" colspan="2">
                <asp:LinkButton ID="lnk_excel" runat="server" CssClass="buttonc" 
                    Visible="False">Excel</asp:LinkButton>
            </td>
            <td style="height: 19px; width: 127px">
                        &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 6px">
                <asp:Label ID="Label6" runat="server" CssClass="labelcells" Text="Variant" 
                    Width="100%"></asp:Label>
                </td>
            <td style="height: 6px; width: 168px">
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_variant" runat="server" CssClass="textbox" 
                            Width="100px" AutoPostBack="True" TabIndex="30"></asp:TextBox>
                        <asp:ImageButton ID="imb_variant_fetch" runat="server" 
                            ImageUrl="~/Image/searchBlueSmall.png" style="width: 16px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 6px; width: 168px" colspan="3">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" Height="12px" 
                            ImageUrl="~/Image/loading.gif" Width="102px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                </td>
            <td style="height: 6px; width: 168px">
                &nbsp;</td>
            <td style="height: 6px; width: 127px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 6px" colspan="5">
                &nbsp;</td>
            <td style="height: 6px; width: 168px">
                &nbsp;</td>
            <td style="height: 6px; width: 127px">
                &nbsp;</td>
        </tr>
        </table>
    <table style="width:96%; height: 312px;" class="tableback">
        <tr>
            <td colspan="6">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="224px" ScrollBars="None" Width="750px">
                <div  id = "AdjResultsDiv" style=" width: 100%; height:224px;">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                Font-Bold="False" PageSize="5">
                                <RowStyle Font-Names="Tahoma" Font-Size="8pt" />
                                <EmptyDataTemplate>
                                    Records not Available
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:BoundField DataField="grupr_no" HeaderText="Gr/Upr No." />
                                    <asp:BoundField DataField="entry_no" HeaderText="Tran. No." />
                                    <asp:BoundField DataField="item_serial" HeaderText="Gr/Upr Sr." />
                                    <asp:BoundField DataField="itemcode" HeaderText="Item Code" />
                                    <asp:BoundField DataField="variant" HeaderText="Variant" />
                                    <asp:BoundField DataField="description" HeaderText="Desc.">
                                        <ControlStyle Width="1500px" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="short_description" HeaderText="Short Desc.">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="uom" HeaderText="Uom" />
                                    <asp:BoundField DataField="total_qty" HeaderText="Recvd.Qty." 
                                        DataFormatString="{0:N3}" />
                                    <asp:TemplateField HeaderText="Reqd.Qty.">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_move_qty" runat="server" CssClass="textbox" Height="16px" 
                                                Text='<%# Eval("moved_qty") %>' Width="80px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To Warehouse">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_move_warehouse" runat="server" CssClass="textbox" 
                                                Height="16px" ReadOnly="True" Text='<%# Eval("moved_warehouse") %>' 
                                                Width="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To Zone">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_move_zone" runat="server" CssClass="textbox" Height="16px" 
                                                Text='<%# Eval("moved_zone") %>' Width="80px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To Bin">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_move_bin" runat="server" CssClass="textbox" Height="16px" 
                                                Text='<%# Eval("moved_bin") %>' Width="80px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="status" HeaderText="Status" />
                                    <asp:BoundField DataField="temp_bin" HeaderText="Temp Bin." />
                                    <asp:BoundField DataField="grupr_date" DataFormatString="{0:dd/MM/yyyy}" 
                                        HeaderText="Gr/Upr Date" />
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
            <td style="height: 6px" colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 6px" colspan="6">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server" Visible="true">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnk_view" runat="server" CssClass="buttonc">VIEW</asp:LinkButton>
                        <asp:LinkButton ID="lnk_add" runat="server" CssClass="buttonc">ADD</asp:LinkButton>
                        <asp:LinkButton ID="lnk_modify" runat="server" CssClass="buttonc">MODIFY</asp:LinkButton>
                        <asp:LinkButton ID="lnk_delete" runat="server" CssClass="buttonc">DELETE</asp:LinkButton>
                        <asp:LinkButton ID="lnk_authorize" runat="server" CssClass="buttonc">AUTHORIZE</asp:LinkButton>
                        <asp:LinkButton ID="lnk_close" runat="server" CssClass="buttonc">CLOSE</asp:LinkButton>
                        <asp:LinkButton ID="lnk_next" runat="server" CssClass="buttonc">Next</asp:LinkButton>
                        <asp:LinkButton ID="lnk_previous" runat="server" CssClass="buttonc">Previous</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="height: 6px">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnk_apply" runat="server" CssClass="buttonc" 
                            Visible="False">APPLY</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 6px">
                &nbsp;</td>
            <td style="height: 6px">
                &nbsp;</td>
            <td style="height: 6px; width: 168px">
                &nbsp;</td>
            <td style="height: 6px; width: 127px">
                &nbsp;</td>
            <td style="height: 6px; width: 127px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 6px">
                &nbsp;</td>
                
            <td style="height: 6px">
                &nbsp;</td>
                
            <td style="height: 6px">
                &nbsp;</td>
                
            <td style="height: 6px; width: 168px">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                   <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                 </ContentTemplate>
                </asp:UpdatePanel>
             &nbsp;</td>
             
            <td style="height: 6px; width: 127px" colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

