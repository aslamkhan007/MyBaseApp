<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="CostingPPL_ProductionPlan.aspx.cs" Inherits="OPS_CostingPPL_ProductionPlan" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Production Plan PPL"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 101px">
                <asp:Label ID="Label17" runat="server" Text="Select Plant"></asp:Label>
            </td>
            <td class="NormalText" style="width: 210px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Selected="True">Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
            <td class="NormalText" style="width: 68px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 101px">
                <asp:Label ID="Label18" runat="server" Text="Loom Plan"></asp:Label>
            </td>
            <td class="NormalText" style="width: 210px">
               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:CheckBoxList ID="chbPlan" runat="server" AutoPostBack="True" 
                            DataSourceID="SqlDataSource1" DataTextField="DESCRIPTION" 
                            DataValueField="PLANID" RepeatColumns="2" RepeatDirection="Horizontal">
                        </asp:CheckBoxList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="SELECT DISTINCT UPPER(A.[DESCRIPTION]) as Description, A.[PLANID] FROM [JCT_OPS_PLANNING_GENERATE_PLANID] A INNER JOIN JCT_OPS_CostingPPL_Data B ON A.PLANID=B.PLANID WHERE  ((A.[STATUS] = @STATUS) AND (A.[Plant] = @Plant))">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                                <asp:ControlParameter ControlID="ddlPlant" Name="Plant" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
            <td class="NormalText" style="width: 68px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 101px">
                <asp:Label ID="Label19" runat="server" Text="Customer"></asp:Label>
            </td>
            <td class="NormalText" style="width: 210px">
                   <div id="div2" style="display: none;">
                        </div>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" 
                            CssClass="textbox" ontextchanged="txtCustomer_TextChanged" Width="200px"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                            CompletionListElementID="div2" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                            MinimumPrefixLength="1" ServiceMethod="OPS_Customer" 
                            ServicePath="~/WebService.asmx" TargetControlID="txtCustomer">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 68px">
                <asp:Label ID="Label20" runat="server" Text="OrderNo"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 101px">
                <asp:Label ID="Label21" runat="server" Text="WeavingSort"></asp:Label>
            </td>
            <td class="NormalText" style="width: 210px">
                <asp:TextBox ID="txtWeavingSort" runat="server" CssClass="textbox" Columns="10" 
                    MaxLength="10"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 68px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" 
                            onclick="lnkExcel_Click">Excel</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="lnkExcel" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
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
            <td class="NormalText" colspan="4">
             <asp:Panel ID="pnlGrid" runat="server" Width="1000px" ScrollBars="Horizontal" Wrap="true">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="grdPPL" runat="server"
                            AllowPaging="True"  CellSpacing="0" GridLines="None" 
                            onitemcommand="grdPPL_ItemCommand" >
                            <ClientSettings AllowDragToGroup="True">
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                            </ClientSettings>
                            <MasterTableView>
                                <CommandItemSettings exporttoexcelimageurl="~/Image/excelsmall.jpg" 
                                    ExportToPdfText="Export to PDF" showaddnewrecordbutton="False" 
                                    showexporttoexcelbutton="True" showrefreshbutton="False" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn created="True" 
                                    FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                                <PagerStyle PageSizeControlType="RadComboBox" />
                            </MasterTableView>
                            <PagerStyle PageSizeControlType="RadComboBox" />
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
                  </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 101px">
                &nbsp;</td>
            <td class="NormalText" style="width: 210px">
                &nbsp;</td>
            <td class="NormalText" style="width: 68px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

