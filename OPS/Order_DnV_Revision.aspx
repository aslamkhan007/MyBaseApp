<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master"
    AutoEventWireup="false" CodeFile="Order_DnV_Revision.aspx.vb" Inherits="SalesAnalysisSystem_Dispatch_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label18" runat="server" Text="Order DnV Details"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 109px">
                <asp:Label ID="Label21" runat="server" Text="Item Group"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
                    CssClass="combobox">
                    <asp:ListItem Selected="True" Value=" "> </asp:ListItem>
                       <asp:ListItem Value="INS">INSTITUTIONAL</asp:ListItem>
                       <asp:ListItem Value="HOM">HOME</asp:ListItem>
                    <asp:ListItem Value="COT">Cotton</asp:ListItem>
                    <asp:ListItem Value="SYN">Synthetic</asp:ListItem>
                    <asp:ListItem Value="NOL">Nylon</asp:ListItem>
                    <asp:ListItem Value="POL">Polyster</asp:ListItem>
                    <asp:ListItem Value="GRM">Garment</asp:ListItem>
                    <asp:ListItem Value="YRN">Yarn</asp:ListItem>
                    <asp:ListItem Value="STD">Wardrobe</asp:ListItem>
                    <asp:ListItem Value="SYS">Shirting Suiting</asp:ListItem>
                    <asp:ListItem Value="SYUNIF">Uniform</asp:ListItem>
                   
                </asp:DropDownList>
           
            </td>
            <td class="labelcells">
                Sort No</td>
            <td class="NormalText">
                <asp:TextBox ID="txtSortNo" runat="server" CssClass="textbox"></asp:TextBox>
           
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 109px">
                <asp:Label ID="Label19" runat="server" Text="Order Start Date"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSDate" runat="server" CssClass="textbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtSDate_CalendarExtender" runat="server" TargetControlID="txtSDate">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 109px">
                <asp:Label ID="Label20" runat="server" Text="Order End Date"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEDate" runat="server" CssClass="textbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtEDate_CalendarExtender" runat="server" TargetControlID="txtEDate">
                        </cc1:CalendarExtender>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtSDate"
                            ControlToValidate="txtEDate" ErrorMessage="End date should not be less than Start date."
                            Operator="GreaterThanEqual"></asp:CompareValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <%--</ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkGet" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>--%><asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc"
                    ToolTip="Click to Fetch DnV Detail for Orders">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkGet" runat="server" CssClass="buttonc" 
                    ToolTip="Click here to export the data to Excel sheet." Visible="False">To Excel</asp:LinkButton>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" Visible="False">Reset</asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" CssClass="buttonc">Cancel</asp:LinkButton>
                <%-- <asp:TemplateField HeaderText="Order Date">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblOrder_dt" runat="server" Text='<%# Bind("Order_dt") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder_dt" runat="server" Text='<%# Bind("Order_dt") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../Image/loading.gif" style="width: 70px; height: 10px" /> Please Wait . . .
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="GridHeader" colspan="2">
                Sale Orders
            </td>
        </tr>
        <tr>
            <td class="NormalText tableback" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>                        
                            <asp:GridView ID="grdOrderDetail" runat="server" Width="100%" AutoGenerateColumns="False"
                                DataSourceID="SqlDataSource1" CellPadding="0" 
                                DataKeyNames="Order_no,order_litem_no,Item_no,variant,control_serial_no,date_c_no" 
                                EmptyDataText="No Orders found for given dates." AllowPaging="True" 
                                PageSize="15" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                <RowStyle CssClass="GridItem" />
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:TemplateField HeaderText="Order_no">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblOrderNo" runat="server" Text='<%# Bind("Order_no") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderNo" runat="server" Text='<%# Bind("Order_no") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="Order Date">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblOrder_dt" runat="server" Text='<%# Bind("Order_dt") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder_dt" runat="server" Text='<%# Bind("Order_dt") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Sale Person">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblSale_Person" runat="server" Text='<%# Bind("Sale_Person") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSale_Person" runat="server" Text='<%# Bind("Sale_Person") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item SNo">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblorder_litem_no" runat="server" Text='<%# Bind("order_litem_no") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblorder_litem_no" runat="server" 
                                                Text='<%# Bind("order_litem_no") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item Code">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblItem_no" runat="server" Text='<%# Bind("Item_no") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItem_no" runat="server" Text='<%# Bind("Item_no") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Variant">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblvariant" runat="server" Text='<%# Bind("variant") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblvariant" runat="server" Text='<%# Bind("variant") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sale_Price">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblSalePrice" runat="server" Text='<%# Bind("sales_price")%>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalePrice" runat="server" Text='<%# Bind("sales_price")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DnV Mkt">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbldnv_cost" runat="server" Text='<%# Bind("dnv_cost") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldnv_cost" runat="server" Text='<%# Bind("dnv_cost") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DnV Cst">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtdnv_actual" runat="server" CssClass="textbox" Text='<%# Bind("dnv_actual") %>'
                                                Width="41px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldnv_actual" runat="server" Text='<%# Bind("dnv_actual") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Control No">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblControl_serial_no" runat="server" Text='<%# Bind("Control_serial_no") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblControl_serial_no" runat="server" Text='<%# Bind("Control_serial_no") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date CNo">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbldate_c_no" runat="server" Text='<%# Bind("date_c_no") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate_c_no" runat="server" Text='<%# Bind("date_c_no") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="GridHeader" ForeColor="White" />
                                <HeaderStyle CssClass="GridHeader" />
                            </asp:GridView>
                        
                        <div class="tableback" style="height: 100px">
                            <asp:BulletedList ID="blsActionHistory" runat="server" BulletStyle="Square">
                            </asp:BulletedList>
                            &nbsp;</div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="DropDownList1" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="2">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShpConnectionString %>"
                    SelectCommand="jct_sas_sales_order_detail_dnv_edit_fetch" UpdateCommand="update som..jct_item_dnv_cost
                    set dnv_actual = @dnv_actual
                    where order_no = @order_no
                    and order_srl_no= @order_srl_no
                    and Item_no = @Item_no
                    and variant = @variant
                    and control_serial_no = @control_serial_no
                    and date_c_no = @date_c_no"
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtSDate" Name="sdate" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="txtEDate" Name="edate" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="DropDownList1" Name="item_group"
                            PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="txtSortNo" Name="sort_no" PropertyName="Text" Type="String" DefaultValue =" " />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="order_no" />
                        <asp:Parameter Name="order_srl_no" />
                        <asp:Parameter Name="Item_no" />
                        <asp:Parameter Name="variant" />
                        <asp:Parameter Name="control_serial_no" />
                        <asp:Parameter Name="date_c_no" />
                        <asp:Parameter Name="dnv_actual" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 109px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
