<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="StockMaster.aspx.cs" Inherits="OPS_StockMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label23" runat="server" Text="Reed/Cam Stock Master"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 173px">
                <asp:Label ID="Label16" runat="server" Text="Select Stock"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlStock" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                            <asp:ListItem>Reed</asp:ListItem>
                            <asp:ListItem>Cam</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                      <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkFirst" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkLast" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkNext" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkPrevious" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="lnkEdit" EventName="Click" />
                          <asp:AsyncPostBackTrigger ControlID="txtReedCount" EventName="TextChanged" />
                          <asp:AsyncPostBackTrigger ControlID="txtReedSize" EventName="TextChanged" />
                          <asp:AsyncPostBackTrigger ControlID="txtWeave" EventName="TextChanged" />
                    </Triggers>

                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 173px">
                <asp:Label ID="Label17" runat="server" Text="Select Shed"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlShed" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem Value="R">Rapier</asp:ListItem>
                            <asp:ListItem Value="A">Airjet</asp:ListItem>
                            <asp:ListItem Value="W">Waterjet</asp:ListItem>
                            <asp:ListItem Value="S">Sulzer A</asp:ListItem>
                            <asp:ListItem Value="S">Sulzer B</asp:ListItem>
                            <asp:ListItem Value="S">Sulzer C</asp:ListItem>
                            <asp:ListItem Value="S">Sulzer D</asp:ListItem>
                            <asp:ListItem Value="S">Sulzer E</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                      <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkFirst" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkLast" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkNext" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkPrevious" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkEdit" EventName="Click" />
                          <asp:AsyncPostBackTrigger ControlID="txtReedCount" EventName="TextChanged" />
                          <asp:AsyncPostBackTrigger ControlID="txtReedSize" EventName="TextChanged" />
                          <asp:AsyncPostBackTrigger ControlID="txtWeave" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 173px">
                <asp:Label ID="Label18" runat="server" Text="Reed Count"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtReedCount" runat="server" CssClass="textbox" 
                            ontextchanged="txtReedCount_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkFirst" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkLast" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkNext" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkPrevious" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkEdit" EventName="Click" />
                          <asp:AsyncPostBackTrigger ControlID="txtReedCount" EventName="TextChanged" />
                          <asp:AsyncPostBackTrigger ControlID="txtReedSize" EventName="TextChanged" />
                          <asp:AsyncPostBackTrigger ControlID="txtWeave" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 173px">
                <asp:Label ID="Label19" runat="server" Text="Reed Size"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtReedSize" runat="server" CssClass="textbox" 
                            ontextchanged="txtReedSize_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtReedCount" EventName="TextChanged" />
                        
                        <asp:AsyncPostBackTrigger ControlID="ddlStock" 
                            EventName="SelectedIndexChanged" />
                             <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkFirst" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkLast" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkNext" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkPrevious" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkEdit" EventName="Click" />
                          <asp:AsyncPostBackTrigger ControlID="txtReedCount" EventName="TextChanged" />
                          <asp:AsyncPostBackTrigger ControlID="txtReedSize" EventName="TextChanged" />
                          <asp:AsyncPostBackTrigger ControlID="txtWeave" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 173px">
                <asp:Label ID="Label20" runat="server" Text="Weave"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtWeave" runat="server" CssClass="textbox" 
                            ontextchanged="txtWeave_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        
                        <asp:AsyncPostBackTrigger ControlID="ddlStock" 
                            EventName="SelectedIndexChanged" />
                             <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkFirst" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkLast" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkNext" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkPrevious" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                          <asp:AsyncPostBackTrigger ControlID="txtReedCount" EventName="TextChanged" />
                          <asp:AsyncPostBackTrigger ControlID="txtReedSize" EventName="TextChanged" />
                          <asp:AsyncPostBackTrigger ControlID="txtWeave" EventName="TextChanged" />
                                <asp:AsyncPostBackTrigger ControlID="lnkEdit" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 173px">
                <asp:Label ID="Label21" runat="server" Text="Stock Available"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtStock" runat="server" Columns="7" CssClass="textbox" 
                            MaxLength="7"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                     
                        <asp:AsyncPostBackTrigger ControlID="ddlShed" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlStock" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtReedCount" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtReedSize" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtWeave" EventName="TextChanged" />
                         <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkFirst" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkLast" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkNext" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkPrevious" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkEdit" EventName="Click" />

                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 173px">
                <asp:Label ID="Label22" runat="server" Text="Stock To Be Use per Loom"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtStockTobeUse" runat="server" Columns="7" CssClass="textbox" 
                            MaxLength="7"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                       
                        <asp:AsyncPostBackTrigger ControlID="ddlStock" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtReedCount" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtReedSize" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtWeave" EventName="TextChanged" />
                         <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkFirst" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkLast" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkNext" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkPrevious" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkEdit" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                            onclick="lnkSave_Click">Save</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                            onclick="lnkReset_Click">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkEdit" runat="server" CssClass="buttonc" 
                            onclick="lnkEdit_Click">Edit</asp:LinkButton>
                    </ContentTemplate>
                     <Triggers>
                       
                    
                        <asp:AsyncPostBackTrigger ControlID="lnkEdit" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFirst" runat="server" CssClass="buttonc" 
                            onclick="lnkFirst_Click">First</asp:LinkButton>
                        <asp:LinkButton ID="lnkNext" runat="server" CssClass="buttonc" 
                            onclick="lnkNext_Click">Next</asp:LinkButton>
                        <asp:LinkButton ID="lnkPrevious" runat="server" CssClass="buttonc" 
                            onclick="lnkPrevious_Click">Previous</asp:LinkButton>
                        <asp:LinkButton ID="lnkLast" runat="server" CssClass="buttonc" 
                            onclick="lnkLast_Click">Last</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">  
             <asp:UpdatePanel ID="UpdatePanel10" runat="server">
            <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                    <asp:GridView ID="grdStock" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="SqlDataSource1" EnableModelValidation="True" 
                        onpageindexchanging="grdStock_PageIndexChanging" Width="100%" 
                        AllowPaging="True">
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
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                        DeleteCommand="Update  [jct_ops_weaving_reed_tappered_stock] WHERE [SrNo] = @SrNo and Status='A'" 
                        InsertCommand="INSERT INTO [jct_ops_weaving_reed_tappered_stock] ([Type], [Shed], [Weave], [Reed_count], [SIZE], [STOCK], [Stock_ToBe_Use],[Eff_From],[Status]) VALUES (@Type, @Shed, @Weave, @Reed_count, @SIZE, @STOCK, @Stock_ToBe_Use,getdate(),'A')" 
                        SelectCommand="SELECT [SrNo], [Type], [Shed], [Weave], [Reed_count], [SIZE], [STOCK], [Stock_ToBe_Use] FROM [jct_ops_weaving_reed_tappered_stock] WHERE ([Type] = @Type) and Status='A'  ORDER BY [Shed], [Reed_count]" 
                        UpdateCommand="UPDATE [jct_ops_weaving_reed_tappered_stock] SET [Eff_To]=getdate(),Status='D' WHERE [SrNo] = @SrNo and [Type] = @Type and [Shed] = @Shed and [Weave] = @Weave and [Reed_count] = @Reed_count and [SIZE] = @SIZE and [STOCK] = @STOCK and [Stock_ToBe_Use] = @Stock_ToBe_Use ">
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
            </ContentTemplate>
            <Triggers>
            

              <asp:AsyncPostBackTrigger ControlID="ddlStock" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtReedCount" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtReedSize" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtWeave" EventName="TextChanged" />
                         <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkFirst" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkLast" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkNext" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkPrevious" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkEdit" EventName="Click" />
                                    </Triggers>
                </asp:UpdatePanel>
                
            </td>
        </tr>
        <tr>
            <td class="NormalText">
             
            </td>
        </tr>
    </table>
</asp:Content>

