<%@ Page Title="" Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="DashboardView.aspx.vb" Inherits="OPS_DashboardView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.DataVisualization" Namespace="System.Web.UI.DataVisualization.Charting"
    TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--<script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>


    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll(); 
        });

        $("#<%=GrdDetail.ClientID%> th").click(function () {
            gridviewScroll();
        });

        function gridviewScroll() {
            $('#<%=GrdDetail.ClientID%>').gridviewScroll({
                width: 99%,
                height: 300,
                freezesize: 1
            });
        } 
    

      
       
    </script>--%>
    

    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="7">
                Dashboard View
                &nbsp;
                &nbsp;
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
            <td align="center" colspan="7">
                <asp:RadioButtonList ID="RblOPtions" runat="server" AutoPostBack="True" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">OrverDue Orders</asp:ListItem>
                    <asp:ListItem>Stock Returned</asp:ListItem>
                 <%--   <asp:ListItem>OutStandings</asp:ListItem>--%>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="7">
                <asp:LinkButton ID="CmdFetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
                &nbsp;
                &nbsp;
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="tableback" colspan="7">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="LblDetail" runat="server" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="3" style="width: 600px" class="tdchart" valign="top">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        
                        <asp:Chart ID="Chart1" runat="server" Palette="BrightPastel" BackColor="#D3DFF0"
                            Height="320px" Width="600px" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                            BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False">
                            <Titles>
                                <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                                    Text="Sale Person's Over Due Orders" Name="Title1" ForeColor="26, 59, 105">
                                </asp:Title>
                            </Titles>
                            <Legends>
                                <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                                    IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False"
                                    Name="Default">
                                </asp:Legend>
                            </Legends>
                            <BorderSkin SkinStyle="Emboss"></BorderSkin>
                            <Series>
                                <asp:Series BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent"
                                    ChartArea="ChartArea1" ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold"
                                    CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20"
                                    MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double"
                                    IsValueShownAsLabel="True" Legend="Default" Name="Series1" PostBackValue="#VALX,#VALY"
                                    LabelPostBackValue="#VALY" LabelToolTip="#VALY" ToolTip="#VALY" Label="#VALY"
                                    LegendPostBackValue="#VALX" LegendText="#VALX" LegendToolTip="#VALX">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="Transparent"
                                    ShadowColor="Transparent" BackGradientStyle="TopBottom" Name="ChartArea1">
                                    <AxisY2>
                                        <MajorGrid Enabled="False" />
                                        <MajorTickMark Enabled="False" />
                                        <MajorGrid Enabled="False" />
                                        <MajorTickMark Enabled="False" />
                                        <MajorGrid Enabled="False" />
                                        <MajorTickMark Enabled="False" />
                                    </AxisY2>
                                    <AxisX2>
                                        <MajorGrid Enabled="False" />
                                        <MajorTickMark Enabled="False" />
                                        <MajorGrid Enabled="False" />
                                        <MajorTickMark Enabled="False" />
                                        <MajorGrid Enabled="False" />
                                        <MajorTickMark Enabled="False" />
                                    </AxisX2>
                                    <Area3DStyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25"
                                        IsClustered="False" />
                                    <AxisY LineColor="64, 64, 64, 64">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                        <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                        <MajorTickMark Enabled="False" />
                                        <MajorGrid Enabled="False" LineColor="64, 64, 64, 64" />
                                        <MajorTickMark Enabled="False" />
                                        <MajorGrid Enabled="False" LineColor="64, 64, 64, 64" />
                                        <MajorTickMark Enabled="False" />
                                    </AxisY>
                                    <AxisX LineColor="64, 64, 64, 64">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                        <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                        <MajorTickMark Enabled="False" />
                                        <MajorGrid Enabled="False" LineColor="64, 64, 64, 64" />
                                        <MajorTickMark Enabled="False" />
                                        <MajorGrid Enabled="False" LineColor="64, 64, 64, 64" />
                                        <MajorTickMark Enabled="False" />
                                    </AxisX>
                                    <Area3DStyle IsRightAngleAxes="False" PointGapDepth="900" Rotation="162" WallWidth="25" />
                                    <Area3DStyle IsRightAngleAxes="False" PointGapDepth="900" Rotation="162" WallWidth="25" />
                                </asp:ChartArea>
                            </ChartAreas>
                            <BorderSkin BackColor="Transparent" BorderColor="Transparent" PageColor="Transparent" />
                        </asp:Chart>
                       
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="Chart2" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td valign="top" class="tableback">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Vertical" 
                            Width="99%">
                            <asp:GridView ID="GrdDetail" runat="server" 
                                AutoGenerateColumns="False"  EnableModelValidation="True"
                                 GridLines="None" 
                                Width="98%">
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
                            <%--    <FooterStyle CssClass="SelectedRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />--%>
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                            <HeaderStyle CssClass="GridviewScrollHeader" />
                            <RowStyle CssClass="GridviewScrollItem" />
                            <PagerStyle CssClass="GridviewScrollPager" />

                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CmdFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            
        </tr>
    </table>
        
        <table style="width: 100%;" class="sampleTable">
        <tr>
            <td class="tdchart">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlChart2" runat="server" Visible="false">
                            <asp:Chart ID="Chart2" runat="server" Palette="BrightPastel" BackColor="#D3DFF0"
                                Height="320px" Width="500px" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                                BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False">
                                <Titles>
                                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                                        Text="Customer Wise Sale Person's Over Due Orders" Name="Title1" ForeColor="26, 59, 105">
                                    </asp:Title>
                                </Titles>
                                <Legends>
                                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                                        IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False"
                                        Name="Default">
                                    </asp:Legend>
                                </Legends>
                             	<borderskin SkinStyle="Emboss"></borderskin>
                                <Series>
                                    <asp:Series BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent"
                                        ChartArea="ChartArea1" ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold"
                                        CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20"
                                        MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double"
                                        IsValueShownAsLabel="True" Legend="Default" Name="Series1" PostBackValue="#VALX,#VALY"
                                        LabelPostBackValue="#VALY" LabelToolTip="#VALY" ToolTip="#VALY" Label="#VALY"
                                        LegendPostBackValue="#VALX" LegendText="#VALX" LegendToolTip="#VALX">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="Transparent"
                                        ShadowColor="Transparent" BackGradientStyle="TopBottom" Name="ChartArea1">
                                        <AxisY2>
                                            <MajorGrid Enabled="False" />
                                            <MajorTickMark Enabled="False" />
                                            <MajorGrid Enabled="False" />
                                            <MajorTickMark Enabled="False" />
                                            <MajorGrid Enabled="False" />
                                            <MajorTickMark Enabled="False" />
                                        </AxisY2>
                                        <AxisX2>
                                            <MajorGrid Enabled="False" />
                                            <MajorTickMark Enabled="False" />
                                            <MajorGrid Enabled="False" />
                                            <MajorTickMark Enabled="False" />
                                            <MajorGrid Enabled="False" />
                                            <MajorTickMark Enabled="False" />
                                        </AxisX2>
                                        <Area3DStyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25"
                                            IsClustered="False" />
                                        <AxisY LineColor="64, 64, 64, 64">
                                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                            <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                            <MajorTickMark Enabled="False" />
                                            <MajorGrid Enabled="False" LineColor="64, 64, 64, 64" />
                                            <MajorTickMark Enabled="False" />
                                            <MajorGrid Enabled="False" LineColor="64, 64, 64, 64" />
                                            <MajorTickMark Enabled="False" />
                                        </AxisY>
                                        <AxisX LineColor="64, 64, 64, 64">
                                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                            <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                            <MajorTickMark Enabled="False" />
                                            <MajorGrid Enabled="False" LineColor="64, 64, 64, 64" />
                                            <MajorTickMark Enabled="False" />
                                            <MajorGrid Enabled="False" LineColor="64, 64, 64, 64" />
                                            <MajorTickMark Enabled="False" />
                                        </AxisX>
                                        <Area3DStyle IsRightAngleAxes="False" PointGapDepth="900" Rotation="162" WallWidth="25" />
                                        <Area3DStyle IsRightAngleAxes="False" PointGapDepth="900" Rotation="162" WallWidth="25" />
                                    </asp:ChartArea>
                                </ChartAreas>
                                <BorderSkin BackColor="Transparent" BorderColor="Transparent" PageColor="Transparent" />
                            </asp:Chart>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Chart1" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="Chart2" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td valign="top" >
            <%--    <asp:UpdatePanel ID="UpdatePanel7" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" Height="300px" ScrollBars="Vertical" 
                            Width="98%">
                            <asp:GridView ID="GrdDetail1" runat="server" AlternatingRowStyle-CssClass="AltRowStyle"
                                AutoGenerateColumns="True" CssClass="GridViewStyle" EnableModelValidation="True"
                                FooterStyle-CssClass="SelectedRowStyle" GridLines="None" HeaderStyle-CssClass="HeaderStyle"
                                PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle" Width="100%">
                                <AlternatingRowStyle CssClass="AltRowStyle" />
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
                </asp:UpdatePanel>--%>
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" Height="300px" ScrollBars="both" 
                            Width="90%">
                            <asp:GridView ID="GrdDetail1" runat="server"
                                AutoGenerateColumns="True" EnableModelValidation="True"
                                 GridLines="None" Width="100%">
                                 <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                            <HeaderStyle CssClass="GridviewScrollHeader" />
                            <RowStyle CssClass="GridviewScrollItem" />
                            <PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GrdDetail" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
        <table>
        <tr>
            <td >
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="pnlChart3" runat="server" Visible="false">
                       <asp:CHART id="Chart3" runat="server" Palette="BrightPastel" 
                                    BackColor="#F3DFC1" Width="953px" Height="296px" BorderDashStyle="Solid" 
                                    BackGradientStyle="TopBottom" BorderWidth="2" 
                    BorderColor="181, 64, 1">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" 
                                    ShadowOffset="3" Text="Column Chart" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" 
                                    BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" 
                                    IsTextAutoFit="False" Enabled="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series XValueType="DateTime" Name="Series1" BorderColor="180, 26, 59, 105" 
                                    LabelMapAreaAttributes="#VALY" LegendText="#VALX" 
                                    MapAreaAttributes="#VALX" Label="#VALY" LabelToolTip="#VALY Meters">
								
								</asp:Series>
								<asp:Series XValueType="DateTime" Name="Series2" BorderColor="180, 26, 59, 105" 
                                    LabelMapAreaAttributes="#VALY" LegendMapAreaAttributes="#VALX" 
                                    MapAreaAttributes="#VALX" Label="#VALY" LabelToolTip="#VALY Meters">
								
								</asp:Series>
							    <asp:Series ChartArea="ChartArea1" LabelMapAreaAttributes="#VALY" 
                                    Legend="Default" LegendMapAreaAttributes="#VALX" LegendPostBackValue="#VALX" 
                                    LegendText="#VALX" MapAreaAttributes="#VALX" Name="Series3" Label="#VALY" 
                                    LabelAngle="20" LabelToolTip="#VALY Meters">
                                </asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" 
                                    BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" 
                                    BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" 
                                        IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"  />
										<MajorGrid LineColor="64, 64, 64, 64" />
									    <MajorGrid LineColor="64, 64, 64, 64" />
									    <MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" 
                                            Format="MM-dd" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									    <MajorGrid LineColor="64, 64, 64, 64" />
									    <MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								    <Area3DStyle Inclination="15" IsRightAngleAxes="False" Perspective="10" 
                                        Rotation="10" WallWidth="0" />
								    <Area3DStyle Inclination="15" IsRightAngleAxes="False" Perspective="10" 
                                        Rotation="10" WallWidth="0" />
								</asp:ChartArea>
							</chartareas>
						</asp:CHART> 
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Chart2" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                            	
            </td>
        </tr>
        
    </table>
</asp:Content>
