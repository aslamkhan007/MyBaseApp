<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="OrderPPL.aspx.cs" Inherits="OPS_OrderPPL" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Order PPL"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 88px">
                <asp:Label ID="Label21" runat="server" Text="Plant"></asp:Label>
            </td>
            <td class="NormalText" style="width: 119px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 114px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 88px">
                <asp:Label ID="Label17" runat="server" Text="Select Plan"></asp:Label>
            </td>
            <td class="NormalText" style="width: 119px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlanID" runat="server" AutoPostBack="True" 
                            CssClass="combobox" DataSourceID="SqlDataSource1" DataTextField="DESCRIPTION" 
                            DataValueField="PLANID">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="SELECT [PLANID], [DESCRIPTION] FROM [JCT_OPS_PLANNING_GENERATE_PLANID] WHERE (([Plant] = @Plant) AND ([STATUS] = @STATUS)) order by planid desc  ">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlPlant" Name="Plant" 
                                    PropertyName="SelectedValue" Type="String" />
                                <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlPlant" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 114px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 88px">
                <asp:Label ID="Label18" runat="server" Text="OrderNo"></asp:Label>
            </td>
            <td class="NormalText" style="width: 119px">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 114px">
                <asp:Label ID="Label19" runat="server" Text="Sort No"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtSortNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 88px">
                <asp:Label ID="Label20" runat="server" Text="Customer"></asp:Label>
            </td>
            <td class="NormalText" style="width: 119px">
                 <div id="divwidth" style="display: none;">
                </div>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" 
                            CssClass="textbox" MaxLength="40" 
                            ToolTip="Please give Customer Code or Select Customer from the List" 
                            Width="200px" ontextchanged="txtCustomer_TextChanged"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                            MinimumPrefixLength="1" ServiceMethod="OPS_Customer" 
                            ServicePath="~/WebService.asmx" TargetControlID="txtCustomer">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
                
                </td>
            <td class="NormalText" style="width: 114px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                            onclick="lnkSave_Click">Save</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                            onclick="lnkReset_Click">Reset</asp:LinkButton>
                      
                    </ContentTemplate>
                </asp:UpdatePanel>
               
                  <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" 
                            onclick="lnkExcel_Click">Excel</asp:LinkButton>
                 <asp:LinkButton ID="lnkCalc" runat="server" CssClass="buttonc" 
                            onclick="lnkCalc_Click">Current PPL</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="grdPPL" runat="server" AutoGenerateColumns="False" 
                                EnableModelValidation="True" Width="100%" AllowPaging="False" 
                                onpageindexchanging="grdPPL_PageIndexChanging">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chbSelectAll" runat="server" AutoPostBack="True" 
                                                oncheckedchanged="chbSelectAll_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OrderNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SortNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSortNo" runat="server" Text='<%# Eval("SortNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustomer" runat="server" Text='<%# Eval("Customer") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                
                                    <asp:TemplateField HeaderText="Sale Team">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSaleTeam" runat="server" Text='<%# Eval("SaleTeam") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" runat="server" Text='<%# Eval("OrderQty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="DnV">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDnV" runat="server" CssClass="textbox" Text='<%# Eval("DnV") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fixed overhead">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFixedOverhead" runat="server" CssClass="textbox"  Text='<%# Eval("FixedOverhead") %>'
                                                Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Depreciation">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDepreciation" runat="server" CssClass="textbox"  Text='<%# Eval("Depreciation") %>'
                                                Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RPM">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRPM" runat="server" CssClass="textbox" Text='<%# Eval("RPM") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Efficiency">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtEfficiency" runat="server" CssClass="textbox" Text='<%# Eval("Efficiency") %>' Width="30px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

