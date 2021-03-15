<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="StockMaster.aspx.cs" Inherits="OPS_StockMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 173px">
                <asp:Label ID="Label16" runat="server" Text="Select Stock"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlStock" runat="server" AutoPostBack="True" 
                    CssClass="combobox">
                    <asp:ListItem>Reed</asp:ListItem>
                    <asp:ListItem>Cam</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 173px">
                <asp:Label ID="Label17" runat="server" Text="Select Shed"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlShed" runat="server" AutoPostBack="True" 
                    CssClass="combobox">
                         <asp:ListItem>Select</asp:ListItem>
                                                   <asp:ListItem Value="R">Rapier</asp:ListItem>
                                                   <asp:ListItem Value="A">Airjet</asp:ListItem>
                                                   <asp:ListItem Value="W">Waterjet</asp:ListItem>
                                                   <asp:ListItem Value="SA">Sulzer A</asp:ListItem>
                                                   <asp:ListItem Value="SB">Sulzer B</asp:ListItem>
                                                   <asp:ListItem Value="SC">Sulzer C</asp:ListItem>
                                                   <asp:ListItem Value="SD">Sulzer D</asp:ListItem>
                                                   <asp:ListItem Value="SE">Sulzer E</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 173px">
                <asp:Label ID="Label18" runat="server" Text="Reed Count"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtReedCount" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 173px">
                <asp:Label ID="Label19" runat="server" Text="Reed Size"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtReedSize" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 173px">
                <asp:Label ID="Label20" runat="server" Text="Weave"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtWeave" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 173px">
                <asp:Label ID="Label21" runat="server" Text="Stock Available"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtStock" runat="server" Columns="7" CssClass="textbox" 
                    MaxLength="7"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 173px">
                <asp:Label ID="Label22" runat="server" Text="Stock To Be Use per Loom"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtStockTobeUse" runat="server" Columns="7" CssClass="textbox" 
                    MaxLength="7"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                    onclick="lnkSave_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                    onclick="lnkReset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" colspan="2">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:GridView ID="grdStock" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="SqlDataSource1" EnableModelValidation="True" 
                        onpageindexchanging="grdStock_PageIndexChanging" PageSize="40" Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            <asp:BoundField DataField="SrNo" HeaderText="SrNo" InsertVisible="False" 
                                ReadOnly="True" SortExpression="SrNo" />
                            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                            <asp:BoundField DataField="Shed" HeaderText="Shed" SortExpression="Shed" />
                            <asp:BoundField DataField="Weave" HeaderText="Weave" SortExpression="Weave" />
                            <asp:BoundField DataField="Reed_count" HeaderText="Reed_count" 
                                SortExpression="Reed_count" />
                            <asp:BoundField DataField="SIZE" HeaderText="SIZE" SortExpression="SIZE" />
                            <asp:BoundField DataField="STOCK" HeaderText="STOCK" SortExpression="STOCK" />
                            <asp:BoundField DataField="Stock_ToBe_Use" HeaderText="Stock_ToBe_Use" 
                                SortExpression="Stock_ToBe_Use" />
                        </Columns>
                        <HeaderStyle CssClass="gridheader" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                        DeleteCommand="Update  [jct_ops_weaving_reed_tappered_stock] WHERE [SrNo] = @SrNo and Status='A'" 
                        InsertCommand="INSERT INTO [jct_ops_weaving_reed_tappered_stock] ([Type], [Shed], [Weave], [Reed_count], [SIZE], [STOCK], [Stock_ToBe_Use]) VALUES (@Type, @Shed, @Weave, @Reed_count, @SIZE, @STOCK, @Stock_ToBe_Use)" 
                        SelectCommand="SELECT [SrNo], [Type], [Shed], [Weave], [Reed_count], [SIZE], [STOCK], [Stock_ToBe_Use] FROM [jct_ops_weaving_reed_tappered_stock] WHERE ([Type] = @Type) and Status='A' ORDER BY [Shed], [Reed_count]" 
                        UpdateCommand="UPDATE [jct_ops_weaving_reed_tappered_stock] SET [Type] = @Type, [Shed] = @Shed, [Weave] = @Weave, [Reed_count] = @Reed_count, [SIZE] = @SIZE, [STOCK] = @STOCK, [Stock_ToBe_Use] = @Stock_ToBe_Use WHERE [SrNo] = @SrNo">
                        <DeleteParameters>
                            <asp:Parameter Name="SrNo" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Type" Type="String" />
                            <asp:Parameter Name="Shed" Type="String" />
                            <asp:Parameter Name="Weave" Type="String" />
                            <asp:Parameter Name="Reed_count" Type="Double" />
                            <asp:Parameter Name="SIZE" Type="Double" />
                            <asp:Parameter Name="STOCK" Type="Double" />
                            <asp:Parameter Name="Stock_ToBe_Use" Type="Double" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlStock" Name="Type" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Type" Type="String" />
                            <asp:Parameter Name="Shed" Type="String" />
                            <asp:Parameter Name="Weave" Type="String" />
                            <asp:Parameter Name="Reed_count" Type="Double" />
                            <asp:Parameter Name="SIZE" Type="Double" />
                            <asp:Parameter Name="STOCK" Type="Double" />
                            <asp:Parameter Name="Stock_ToBe_Use" Type="Double" />
                            <asp:Parameter Name="SrNo" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 143px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

