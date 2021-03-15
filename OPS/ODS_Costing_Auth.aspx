<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="ODS_Costing_Auth.aspx.vb" Inherits="OPS_ODS_Costing_Auth" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Authorize ODS Request
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2" RepeatDirection="Horizontal"
                    ToolTip="Click any Area to see the detials of it." Width="100%">
                    <ItemTemplate>
                        <table cellpadding="1" cellspacing="0" style="width: 100%;">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                        <tr>
                                            <td align="center" class="HighlightBox">
                                                <asp:Label ID="lblCount" runat="server" Text='<%# Eval("Count") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--<td style="background-color: #B2B2B2; vertical-align: top; text-align: center; font-weight: bold;
                                                font-size: 10pt; text-transform: capitalize; color: Blue; font-family: 'Trebuchet MS' , Tahoma;
                                                ">
                                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("AreaName") %>'></asp:Label>
                                            </td>--%>
                                            <td align="center" class="GridRowRed">
                                                <asp:LinkButton ID="cmdArea" runat="server" CommandName="Select" ForeColor="White"
                                                    Text='<%# Eval("AreaName") %>'></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="Jct_Ops_Pending_Authorization_Count_Fetch_ODS" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="UserCode" SessionField="Empcode" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel2" runat="server" Height="300px" ScrollBars="Both" 
                    Width="95%">
                    <asp:GridView ID="grdPendingRequest" runat="server" 
    Width="100%" AutoGenerateSelectButton="True">
                        <SelectedRowStyle CssClass="GridRowGreen" />
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                        <AlternatingRowStyle CssClass="GridAI" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="200px" Width="100%" ScrollBars="Both">
                    <asp:GridView ID="grdRequestDetail" runat="server" Width="100%" AutoGenerateColumns="False"
                        EnableModelValidation="True">
                        <SelectedRowStyle CssClass="GridRowGreen" />
                        <Columns>
                            <asp:BoundField DataField="CurrentOrder" HeaderText="Current Order" />
                            <asp:BoundField DataField="CurrentOrderLine" HeaderText="LineItem" />
                            <asp:BoundField DataField="Item_no" HeaderText="Sort" />
                            <asp:BoundField DataField="OrderVar" HeaderText="OrderVar" />
                            <asp:BoundField DataField="Bale_No" HeaderText="BaleNo" />
                            <asp:BoundField DataField="Varaint" HeaderText="Varaint" />
                            <asp:BoundField DataField="QtyBooked" HeaderText="QtyBooked" />
                            <asp:BoundField DataField="ItemBookedAt" HeaderText="BookedAt" />
                            <asp:BoundField DataField="DNV" HeaderText="DNV" />
                            <asp:BoundField DataField="SellingPrice" HeaderText="SellingPrice" />
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                        <AlternatingRowStyle CssClass="GridAI" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GrdAvgCost" runat="server" Width="100%" AutoGenerateColumns="False"
                    EnableModelValidation="True">
                    <SelectedRowStyle CssClass="GridRowGreen" />
                    <Columns>
                        <asp:BoundField DataField="Item_no" HeaderText="SortNo" />
                        <asp:BoundField DataField="Varaint" HeaderText="Variant" />
                        <asp:BoundField DataField="OldDnv" HeaderText="AvgOldDNV" />
                        <asp:BoundField DataField="OldSP" HeaderText="AvgOldSP" />
                        <asp:TemplateField HeaderText="ProposedDNV">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtProposedDNV" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtProposedDNV" runat="server" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ProposedSP">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtProposedSP" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtProposedSP" runat="server" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                    <AlternatingRowStyle CssClass="GridAI" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Action"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlAction" runat="server" CssClass="combobox">
                    <asp:ListItem>Authorize</asp:ListItem>
                    <asp:ListItem>Cancel</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Remarks
            </td>
            <td>
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="218px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="cmdAction" runat="server" BorderStyle="None" CssClass="buttonc">Apply</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server">LinkButton</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
