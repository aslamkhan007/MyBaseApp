<%@ Page Title="" Language="VB" MasterPageFile="~/Ops/MasterPage.master" AutoEventWireup="false" CodeFile="frm_issued_items_against_mr_order.aspx.vb" Inherits="OPS_frm_issued_items_against_mr_order" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 304px;">
        <tr>
            <td style="height: 35px" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Issue items against sale order"></asp:Label>
            </td>
            <td style="height: 35px">
            </td>
            <td style="height: 35px">
            </td>
            <td style="height: 35px">
                <asp:ImageButton ID="imb_close" runat="server" Height="20px" 
                    ImageUrl="~/Image/close24.png" />
            </td>
        </tr>
        <tr>
            <td style="width: 57px; height: 4px;">
                <asp:Label ID="Label2" runat="server" Text="Date From (mm/dd/yyyy)" 
                    CssClass="labelcells" Width="150px"></asp:Label>
            </td>
            <td style="width: 91px; height: 4px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_datefrom" runat="server" CssClass="textbox" Width="55px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_datefrom">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 4px">
                <asp:Label ID="Label4" runat="server" CssClass="labelcells" Text="Order No." 
                    Width="60px"></asp:Label>
            </td>
            <td style="height: 4px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_orderno" runat="server" CssClass="combobox" 
                            Width="150px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 4px">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imb_fetch" runat="server" Height="20px" 
                    ImageUrl="~/Image/searchBlueSmall.png" 
    ToolTip="Fetch Data" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 57px; height: 3px;">
                <asp:Label ID="Label3" runat="server" Text="Date To (mm/dd/yyyy)" 
                    CssClass="labelcells" Width="150px"></asp:Label>
            </td>
            <td style="width: 91px; height: 3px">
                
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_dateto" runat="server" CssClass="textbox" Width="55px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy" 
                            TargetControlID="txt_dateto">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
            <td style="height: 3px">
                <asp:Label ID="Label5" runat="server" CssClass="labelcells" Text="MR No." 
                    Width="60px"></asp:Label>
            </td>
            <td style="height: 3px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_mrno" runat="server" CssClass="combobox" 
                            Width="150px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 3px">
                <asp:ImageButton ID="imb_excel" runat="server" Height="20px" 
                    ImageUrl="~/Image/XportXLFinal.png" ToolTip="Export to Excel" />
            </td>
        </tr>
        <tr>
            <td style="width: 57px; height: 4px;">
                </td>
            <td style="width: 91px; height: 4px">
                </td>
            <td style="height: 4px">
                &nbsp;</td>
            <td style="height: 4px">
                
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" 
    ImageUrl="~/Image/loading.gif" Height="12px" Width="102px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                
                </td>
            <td style="height: 4px">
                </td>
        </tr>
        <tr>
            <td style="height: 4px;" colspan="5">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="187px" 
                    Width="700px">
                    <div ID="AdjResultsDiv">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    CssClass="labelcells">
                                <EmptyDataTemplate>
                                    Records not Available
                                </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="order_no" HeaderText="Order No." 
                                            SortExpression="order_no" />
                                        <asp:BoundField DataField="issue_date" HeaderText="Issue Date" 
                                            SortExpression="issue_date" />
                                        <asp:BoundField DataField="issue_no" HeaderText="Issue No." 
                                            SortExpression="issue_no" />
                                        <asp:BoundField DataField="mr_no" HeaderText="MR No." SortExpression="mr_no" />
                                        <asp:BoundField DataField="mr_date" HeaderText="MR Date" 
                                            SortExpression="mr_date" />
                                        <asp:BoundField DataField="li_no" HeaderText="Item Serial" 
                                            SortExpression="li_no" />
                                        <asp:BoundField DataField="stock_no" HeaderText="Item Code" 
                                            SortExpression="stock_no" />
                                        <asp:BoundField DataField="variant_no" HeaderText="Variant" 
                                            SortExpression="variant_no" />
                                        <asp:BoundField DataField="description" HeaderText="Item Desc." 
                                            SortExpression="description" />
                                        <asp:BoundField DataField="short_description" HeaderText="Item Short Desc." 
                                            SortExpression="short_description" />
                                        <asp:BoundField DataField="tran_uom" HeaderText="U.O.M." 
                                            SortExpression="tran_uom" />
                                        <asp:BoundField DataField="confirmed_qty_in_stock_uom" 
                                            DataFormatString="{0:N3}" HeaderText="Qty." 
                                            SortExpression="confirmed_qty_in_stock_uom" />
                                        <asp:BoundField DataField="value" DataFormatString="{0:N2}" HeaderText="Value" 
                                            SortExpression="value" />
                                        <asp:BoundField DataField="cc_no" HeaderText="Cost Centre" 
                                            SortExpression="cc_no" />
                                        <asp:BoundField DataField="account_no" HeaderText="Account Head" 
                                            SortExpression="account_no" />
                                        <asp:BoundField DataField="sort_no" HeaderText="Sort No." 
                                            SortExpression="sort_no" />
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
            <td style="width: 57px; height: 4px;">
                &nbsp;</td>
            <td style="width: 91px; height: 4px">
                &nbsp;</td>
            <td style="height: 4px">
                &nbsp;</td>
            <td style="height: 4px">
                &nbsp;</td>
            <td style="height: 4px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 57px; height: 7px;">
                </td>
            <td style="height: 7px" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                 <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                 </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="height: 7px">
                </td>
        </tr>
    </table>
</asp:Content>

