<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="DashboardView.aspx.vb" Inherits="OPS_DashboardView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.DataVisualization" Namespace="System.Web.UI.DataVisualization.Charting"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link type="text/css" rel="stylesheet" href="style.css" />
    <link type="text/css" rel="stylesheet" href="Chromestyle.css" />
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Dashboard View--OverDue
            </td>
            <td class="tableheader">
                &nbsp;
            </td>
            <td class="tableheader">
                &nbsp;
            </td>
            <td class="tableheader">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 123px">
                Sales Team
            </td>
            <td class="NormalText" style="width: 200px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesTeam" runat="server" AutoPostBack="True" CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="width: 127px">
                Sales Person
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
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
            <td class="labelcells" style="width: 123px">
                Customer
            </td>
            <td class="NormalText" style="width: 200px">
                <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" CssClass="textbox"
                    Width="200px" ToolTip="Please give Customer Code or Select Customer from the List "></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="OPS_Customer"
                    CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                    TargetControlID="txtCustomer">
                </cc1:AutoCompleteExtender>
                <div id="divwidth" style="display: none;">
                </div>
            </td>
            <td class="labelcells" style="width: 127px">
                Order No
            </td>
            <td>
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox>
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
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="CmdFetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
            </td>
            <td class="buttonbackbar">
                &nbsp;
            </td>
            <td class="buttonbackbar">
                &nbsp;
            </td>
            <td class="buttonbackbar">
                &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td colspan="3" style="width:inherit" class="tableback">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="Label2" runat="server" Text="Sale Person's Over Due Orders"></asp:Label>
                        <br />
                        <asp:Chart ID="Chart1" runat="server" BackColor="211, 223, 240" BackGradientStyle="TopBottom"
                            BackSecondaryColor="" BorderDashStyle="Solid" BorderWidth="2px" CssClass="tableback"
                            Height="400px" ImageLocation="~/evaluators/chart/chart_0_0.png" ImageStorageMode="UseImageLocation"
                            Width="400px" ViewStateContent="All">
                            <Legends>
                                <asp:Legend BackColor="Transparent" Docking="Top" Font="Trebuchet MS, 8.25pt, style=Bold"
                                    IsTextAutoFit="True" LegendStyle="Row" Name="Default">
                                </asp:Legend>
                            </Legends>
                            <BorderSkin BackColor="Transparent" PageColor="Transparent" />
                            <Series>
                                <asp:Series BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent"
                                    ChartArea="ChartArea1" ChartType="Pie" CustomProperties="PieDrawingStyle=SoftEdge"
                                    IsValueShownAsLabel="True" Legend="Default" Name="Series1"  PostBackValue="#VALX,#VALY" 
                                    LabelPostBackValue="#VALY" LabelToolTip="#VALY" ToolTip="#VALY" 
                                    Label="#VALY" LegendPostBackValue="#VALX" LegendText="#VALX" 
                                    LegendToolTip="#VALX"  >
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea BorderColor="Transparent" Name="ChartArea1">
                                    <AxisY IsMarksNextToAxis="true" LineColor="Transparent">
                                    </AxisY>
                                    <AxisX LineColor="Transparent">
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                            <BorderSkin BackColor="Transparent" BorderColor="Transparent" PageColor="Transparent" />
                            <BorderSkin BackColor="Transparent" BorderColor="Transparent" 
                                PageColor="Transparent" />
                        </asp:Chart>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="none" Width="80%">
                            <asp:GridView ID="GrdDetail" runat="server" AlternatingRowStyle-CssClass="AltRowStyle"
                                AutoGenerateColumns="False" CssClass="GridViewStyle" EnableModelValidation="True"
                                FooterStyle-CssClass="SelectedRowStyle" GridLines="None" HeaderStyle-CssClass="HeaderStyle"
                                Height="300px" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle"
                                Width="90%">
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <%--<FooterStyle CssClass="SelectedRowStyle" />--%>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="CmdSelect" runat="server" CommandName="Select">Select</asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SalePerson" HeaderText="SalePerson" />
                                    <asp:BoundField DataField="OrdersOverDue" HeaderText="OrdersOverDue" />
                                </Columns>
                                <FooterStyle CssClass="SelectedRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td valign="top" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" Height="300px" ScrollBars="Vertical" Width="90%">
                            <asp:GridView ID="GrdDetail1" runat="server" AlternatingRowStyle-CssClass="AltRowStyle"
                                AutoGenerateColumns="True" CssClass="GridViewStyle" EnableModelValidation="True"
                                FooterStyle-CssClass="SelectedRowStyle" GridLines="None" HeaderStyle-CssClass="HeaderStyle"
                                Height="300px" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle"
                                Width="100%">
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <%--<FooterStyle CssClass="SelectedRowStyle" />--%>
                                <FooterStyle CssClass="SelectedRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GrdDetail" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline" 
                    UpdateMode="Conditional">
                    <ContentTemplate>
                       <h3> <asp:Label ID="Label1" runat="server" Text="Customer's Contribution" 
                            Width="100%"></asp:Label></h3>
                        <asp:Chart ID="Chart2" runat="server" BackColor="211, 223, 240" BackGradientStyle="TopBottom"
                            BackSecondaryColor="" BorderDashStyle="Solid" BorderWidth="2px" CssClass="tableback"
                            Height="400px" ImageLocation="~/evaluators/chart/1.png" ImageStorageMode="UseImageLocation"
                            Width="400px">
                            <Legends>
                                <asp:Legend BackColor="Transparent" Docking="Top" Font="Trebuchet MS, 8.25pt, style=Bold"
                                    IsTextAutoFit="True" LegendStyle="Row" Name="Default">
                                </asp:Legend>
                            </Legends>
                            <BorderSkin BackColor="Transparent" PageColor="Transparent" />
                            <Series>
                                <asp:Series BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent"
                                    ChartArea="ChartArea1" ChartType="Doughnut" CustomProperties="PieDrawingStyle=SoftEdge"
                                    IsValueShownAsLabel="True" Legend="Default" Name="Series1"  PostBackValue="#VALX,#VALY" 
                                    LabelPostBackValue="#VALY" LabelToolTip="#VALY" ToolTip="#VALY" 
                                    Label="#VALY" LegendPostBackValue="#VALX" LegendText="#VALX" LegendToolTip="#VALX"  >
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea BorderColor="Transparent" Name="ChartArea1">
                                    <AxisY IsMarksNextToAxis="true" LineColor="Transparent">
                                    </AxisY>
                                    <AxisX LineColor="Transparent">
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                            <BorderSkin BackColor="Transparent" BorderColor="Transparent" PageColor="Transparent" />
                        </asp:Chart>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Chart1" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
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
