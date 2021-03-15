<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Quotation_Panel.aspx.vb" Inherits="OPS_Quotation_Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Quotation Panel</td>
        </tr>
        <tr>
            <td style="font-size: 10pt; text-align: center;" colspan="4">
                <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" 
                    ImageUrl="~/OPS/Image/Tab_My_Quotations.png" />
                <asp:ImageButton ID="ImageButton2" runat="server" 
                    ImageUrl="~/OPS/Image/STab_Team_Quotations.png" 
                    PostBackUrl="~/OPS/Team_Quotation_Panel.aspx" />
            </td>
        </tr>
        <tr>
            <td style="font-size: 10pt">
                Open Quotations</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
             <asp:Panel ID="Panel1" runat="server" Width="98%" Height="200px" ScrollBars="both">
                <asp:GridView ID="grdOpenQuotes" runat="server" Width="100%" 
                    AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
                    EnableModelValidation="True" EmptyDataText="No Open Quotation is found.">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="cmdAuthorise" runat="server" CausesValidation="False" 
                                    onclientclick="javascript:return confirm('Are you sure want to authorise?');" 
                                    Text="Authorise" CommandArgument='<%# Eval("Quotation No") %>' 
                                    oncommand="cmdAuthorise_Command" CommandName="Authorise"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataTextField="Quotation No" HeaderText="Quotation No" 
                            NavigateUrl="~/OPS/Quotation_Main.aspx" 
                            DataNavigateUrlFields="Quotation No" 
                            DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}" />
                        <asp:BoundField DataField="Customer" HeaderText="Customer" 
                            SortExpression="Customer" />
                        <asp:BoundField DataField="Item Type" HeaderText="Item Type" 
                            SortExpression="Item Type" />
                        <asp:BoundField DataField="Item Code" HeaderText="Item Code" 
                            SortExpression="Item Code" />
                        <asp:BoundField DataField="Dated" HeaderText="Dated" ReadOnly="True" 
                            SortExpression="Dated" />
                        <asp:BoundField DataField="Shades" HeaderText="Shades" ReadOnly="True" 
                            SortExpression="Shades" />
                        <asp:BoundField DataField="Total Quantity" HeaderText="Total Quantity" 
                            ReadOnly="True" SortExpression="Total Quantity" />
                        <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM" />
                        <asp:BoundField DataField="DnV Cost AWtd." HeaderText="DnV Cost AWtd." 
                            ReadOnly="True" SortExpression="DnV Cost AWtd." />
                        <asp:BoundField DataField="Sale Price" HeaderText="Sale Price" 
                            SortExpression="Sale Price" />
                        <asp:BoundField DataField="Margin %" HeaderText="Margin %" 
                            SortExpression="Margin %" />
                        <asp:BoundField DataField="Net Margin %" HeaderText="Net Margin %" 
                            SortExpression="Net Margin %" />
                        <asp:BoundField DataField="Pay Time" HeaderText="Pay Time" 
                            SortExpression="Pay Time" />
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" Wrap="False" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_ops_get_my_quotations" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfdSalesPerson" Name="saleperson" 
                            PropertyName="Value" Type="String" />
                        <asp:Parameter Name="status" Type="String" DefaultValue="QuotOpen" />
                    </SelectParameters>
                </asp:SqlDataSource>
                 </asp:Panel>
                <asp:HiddenField ID="hfdSalesPerson" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 17px" class="errormsg">
                 
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
<asp:Label ID="lblMessage" runat="server"></asp:Label>
               </ContentTemplate>
                </asp:UpdatePanel>
                </td>
        </tr>
        <tr>
            <td colspan="4" style="font-size: 10pt">
                Quotations Pending for Authorisation by HOD</td>
        </tr>
        <tr>
            <td colspan="4">
             <asp:Panel ID="Panel2" runat="server" Width="98%" Height="200px" ScrollBars="both">
                <asp:GridView ID="grdPendingAuthQuotes" runat="server" Width="100%" 
                    AutoGenerateColumns="False" DataSourceID="SqlDataSource2" 
                    EnableModelValidation="True" EmptyDataText="No Open Quotation is found.">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False" Visible="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="cmdAuthorise0" runat="server" CausesValidation="False" 
                                    onclientclick="javascript:return confirm('Are you sure want to authorise?');" 
                                    Text="Authorise" CommandArgument='<%# Eval("Quotation No") %>' 
                                    oncommand="cmdAuthorise_Command" CommandName="Authorise"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataTextField="Quotation No" HeaderText="Quotation No" 
                            NavigateUrl="~/OPS/Quotation_Main.aspx" 
                            DataNavigateUrlFields="Quotation No" 
                            DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}" />
                        <asp:BoundField DataField="Customer" HeaderText="Customer" 
                            SortExpression="Customer" />
                        <asp:BoundField DataField="Item Type" HeaderText="Item Type" 
                            SortExpression="Item Type" />
                        <asp:BoundField DataField="Item Code" HeaderText="Item Code" 
                            SortExpression="Item Code" />
                        <asp:BoundField DataField="Dated" HeaderText="Dated" ReadOnly="True" 
                            SortExpression="Dated" />
                        <asp:BoundField DataField="Shades" HeaderText="Shades" ReadOnly="True" 
                            SortExpression="Shades" />
                        <asp:BoundField DataField="Total Quantity" HeaderText="Total Quantity" 
                            ReadOnly="True" SortExpression="Total Quantity" />
                        <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM" />
                        <asp:BoundField DataField="DnV Cost AWtd." HeaderText="DnV Cost AWtd." 
                            ReadOnly="True" SortExpression="DnV Cost AWtd." />
                        <asp:BoundField DataField="Sale Price" HeaderText="Sale Price" 
                            SortExpression="Sale Price" />
                        <asp:BoundField DataField="Margin %" HeaderText="Margin %" 
                            SortExpression="Margin %" />
                        <asp:BoundField DataField="Net Margin %" HeaderText="Net Margin %" 
                            SortExpression="Net Margin %" />
                        <asp:BoundField DataField="Pay Time" HeaderText="Pay Time" 
                            SortExpression="Pay Time" />
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" Wrap="False" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_ops_get_my_quotations" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfdSalesPerson" Name="saleperson" 
                            PropertyName="Value" Type="String" />
                        <asp:Parameter Name="status" Type="String" DefaultValue="QuotAuthLM" />
                    </SelectParameters>
                </asp:SqlDataSource>
                 </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="font-size: 10pt">
                Authorised Quotations</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView3" runat="server" Width="100%" 
                    DataSourceID="SqlDataSource3" EnableModelValidation="True" 
                    EmptyDataText="No Authorised Quotation Found.">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_ops_get_my_quotations" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfdSalesPerson" Name="saleperson" 
                            PropertyName="Value" Type="String" />
                        <asp:Parameter Name="status" Type="String" DefaultValue="QuotAuth" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        </table>
</asp:Content>

