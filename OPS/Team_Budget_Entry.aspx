<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="Team_Budget_Entry.aspx.vb" Inherits="Team_Budget_Entry" Title="Indicative Planning" %>

<%@ Register Assembly="System.Web.DataVisualization" Namespace="System.Web.UI.DataVisualization.Charting"
    TagPrefix="asp" %>
<%@ Register Src="~/FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label1" runat="server" Text="Indicative Planning Section"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="5">
                </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label6" runat="server" CssClass="NormalText" Text="Action" 
                   ></asp:Label>
            </td>
            <td class="NormalText" >
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" AutoPostBack="True" 
                            CssClass="combobox" >
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
            </td>
            <td colspan="2" class="NormalText">
                <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label7" runat="server" Text="EffecFrom"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEffecFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffecFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                <asp:Label ID="Label8" runat="server" Text="EffecTo"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEffecTo" runat="server" AutoPostBack="True" 
                    CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffecTo_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecTo">
                </cc1:CalendarExtender>
            </td>
            <td  class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" >
                <asp:Label ID="Label3" runat="server" CssClass="NormalText" Text="Team"></asp:Label>
            </td>
            <td  class="NormalText">
                <asp:DropDownList ID="ddl_team" runat="server" CssClass="combobox" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                <asp:Label ID="Label4" runat="server" CssClass="NormalText" Text="Sales Order" 
                    Width="70px"></asp:Label>
            </td>
            <td  class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_orderno" runat="server" 
                            style="margin-left: 0px" Width="146px" CssClass="textbox" 
                            AutoPostBack="True" ToolTip="Enter Order No. or Blank for All orders"></asp:TextBox>
                        <asp:ImageButton ID="imb_fetch" runat="server" 
                            ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png" Height="13px" 
                            ToolTip="Click here to fetch Order" />
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                            CompletionInterval="10" CompletionListCssClass="autocomplete_ListItem " 
                            FirstRowSelected="True" ServiceMethod="GetSono" 
                            ServicePath="~/WebService.asmx" TargetControlID="txt_orderno">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                <asp:LinkButton ID="lnk_excel" runat="server" CssClass="buttonc" 
                    ToolTip="Save in excel" Visible="False">EXCEL</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label2" runat="server" CssClass="NormalText" Text="YearMonth"></asp:Label>
            </td>
            <td  class="NormalText" style="width: 219px">
                <asp:DropDownList ID="ddl_yearmonth" runat="server" CssClass="combobox" 
                    Width="160px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td  class="NormalText">
                &nbsp;</td>
            <td  class="NormalText">
                 <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="10">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server"
                            ImageUrl="~/Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                 </td>
            <td  class="NormalText">
                 &nbsp;</td>
        </tr>
          <tr>
            <td class="NormalText">
                <asp:Label ID="Label9" runat="server" CssClass="NormalText" Text="Plant"></asp:Label>
            </td>
            <td  class="NormalText" style="width: 219px">
                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox" 
                    AutoPostBack="True">
                    <asp:ListItem>Cotton</asp:ListItem>
                    <asp:ListItem>Taffeta</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td  class="NormalText">
                &nbsp;</td>
            <td  class="NormalText">
                 &nbsp;</td>
            <td  class="NormalText">
                 &nbsp;</td>
        </tr>
        </table>
    
    <table style="width:100%;">
        <tr>
            <td colspan="5"  class="NormalText">
                <asp:Panel ID="Panel1" runat="server"  Font-Bold="False" >
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle" AllowPaging="True" ShowFooter="True"
                                    AutoGenerateColumns="False" Font-Names="Tahoma" Font-Size="8pt" 
                                    Width="100%" EnableModelValidation="True" PageSize="20">
                                    <EmptyDataTemplate>
                                        Records not Available
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="order_no" HeaderText="Order No." />
                                        <asp:BoundField DataField="order_dt" HeaderText="Order Dt." />
                                        <asp:BoundField DataField="amend_no" HeaderText="Amd.No." />
                                        <asp:BoundField DataField="item_no" HeaderText="Item" />
                                        <asp:BoundField DataField="order_srl_no" HeaderText="Item No." />
                                        <asp:BoundField DataField="variant" HeaderText="Var." />
                                        <asp:BoundField DataField="blend" HeaderText="Blend" />
                                        <asp:BoundField DataField="req_dt" HeaderText="Req.Dt." />
                                        <asp:BoundField DataField="days" DataFormatString="{0:N0}" HeaderText="Days" />
                                        <asp:BoundField DataField="req_qty" DataFormatString="{0:F3}" 
                                            HeaderText="Order Qty." />
                                        <asp:TemplateField HeaderText="Req.Looms/Shift">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLooms" runat="server" Text='<%# Eval("req_looms") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reason">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlReason" runat="server" CssClass="combobox">
                                                    <asp:ListItem> </asp:ListItem>
                                                    <asp:ListItem>CEO</asp:ListItem>
                                                    <asp:ListItem>V.P. (Mktg)</asp:ListItem>
                                                    <asp:ListItem>V.P. (Taffeta)</asp:ListItem>
                                                    <asp:ListItem>V.P. Production</asp:ListItem>
                                                    <asp:ListItem>G.M. (Mktg)</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Plan QTY.">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_selqty" runat="server" CssClass="textbox" Height="16px" 
                                                    MaxLength="10" Text='<%# Eval("sel_qty") %>'  Width="58px" 
                                                   ></asp:TextBox>
                                                <asp:LinkButton ID="lnk_update" OnClick="lnk_update_Click" runat="server">Update</asp:LinkButton>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                                                    TargetControlID="txt_selqty" ValidChars="0123456789.">
                                                </cc1:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle CssClass="FooterStyle" />
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <RowStyle CssClass="RowStyle" />
                                </asp:GridView>
                                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                    Font-Names="Tahoma" Font-Size="8pt" PageSize="4" Width="100%">
                                    <EmptyDataTemplate>
                                        Records not Available
                                    </EmptyDataTemplate>
                                    <HeaderStyle CssClass="gridheader" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="5" >
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                     <asp:LinkButton ID="lnkfetchOrders" runat="server" CssClass="buttonc">Fetch Orders</asp:LinkButton>
                        <asp:LinkButton ID="lnk_view" runat="server" CssClass="buttonc" Visible="False">VIEW</asp:LinkButton>
                        <asp:LinkButton ID="lnk_add" runat="server" CssClass="buttonc" 
                            ToolTip="Click here to fetch sale order details">ADD</asp:LinkButton>
                        <asp:LinkButton ID="lnk_modify" runat="server" CssClass="buttonc" 
                            Visible="False">MODIFY</asp:LinkButton>
                        <asp:LinkButton ID="lnk_close" runat="server" CssClass="buttonc">DELETE</asp:LinkButton>
                        <asp:LinkButton ID="lnk_authorize" runat="server" CssClass="buttonc" 
                            Visible="False">AUTHORIZE</asp:LinkButton>
                        <asp:LinkButton ID="lnk_exit" runat="server" CssClass="buttonc">CLOSE</asp:LinkButton>
                        <asp:LinkButton ID="lnk_teamlist" runat="server" CssClass="buttonc" 
                            style="height: 22px" 
                            ToolTip="This will show the list of looms alloted and avilable for selected team.">Capacity</asp:LinkButton>
                        <asp:LinkButton ID="lnk_blendlist" runat="server" CssClass="buttonc" 
                            ToolTip="This will show the total meters alloted and avilable for selected team.">BLEND LIST</asp:LinkButton>
                        <asp:LinkButton ID="lnk_list" runat="server" CssClass="buttonc">LIST</asp:LinkButton>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddl_action" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td  class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnk_apply" runat="server" CssClass="buttonc" 
                            Visible="False">Apply</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                   <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                 </ContentTemplate>
                </asp:UpdatePanel>
                </td>
        </tr>
        <tr>
            <td  class="NormalText">
                &nbsp;</td>
            <td  class="NormalText">
                &nbsp;</td>
            <td  class="NormalText">
                &nbsp;</td>
            <td  class="NormalText">
                                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%;" class="sampleTable">
        <tr>
            <td width="412" class="tdchart">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
     <asp:Panel ID="pnlChart" runat="server" Visible ="false">
                            	<asp:CHART id="Chart1" runat="server" Palette="BrightPastel" BackColor="#D3DFF0" Height="296px" Width="412px" BorderDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False" >
								<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Column Chart" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
							</titles>
                            <legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="Area1"  Label="#PERCENT{P1}" XValueType="Double" Name="Series1" 
                                    ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold" 
                                    CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20" 
                                    MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" 
                                    YValueType="Double"   IsValueShownAsLabel="true" 
                                    LabelToolTip="Looms Per day : #VALY" ToolTip="Looms available : #VALY"
                                       LegendText="Looms : #VALY" LegendToolTip="#VALY" YValuesPerPoint="2"
                                        LegendMapAreaAttributes="#PERCENT" LabelMapAreaAttributes="#VALX" 
                                    MapAreaAttributes="#VALX">
								
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="Area1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="Transparent" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2>
										<MajorGrid Enabled="False" />
										<MajorTickMark Enabled="False" />
									    <MajorGrid Enabled="False" />
                                        <MajorTickMark Enabled="False" />
									    <MajorGrid Enabled="False" />
                                        <MajorTickMark Enabled="False" />
									</axisy2>
									<axisx2>
										<MajorGrid Enabled="False" />
										<MajorTickMark Enabled="False" />
									    <MajorGrid Enabled="False" />
                                        <MajorTickMark Enabled="False" />
									    <MajorGrid Enabled="False" />
                                        <MajorTickMark Enabled="False" />
									</axisx2>
									<area3dstyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
										<MajorTickMark Enabled="False" />
									    <MajorGrid Enabled="False" LineColor="64, 64, 64, 64" />
                                        <MajorTickMark Enabled="False" />
									    <MajorGrid Enabled="False" LineColor="64, 64, 64, 64" />
                                        <MajorTickMark Enabled="False" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
										<MajorTickMark Enabled="False" />
									    <MajorGrid Enabled="False" LineColor="64, 64, 64, 64" />
                                        <MajorTickMark Enabled="False" />
									    <MajorGrid Enabled="False" LineColor="64, 64, 64, 64" />
                                        <MajorTickMark Enabled="False" />
									</axisx>
								    <Area3DStyle IsRightAngleAxes="False" PointGapDepth="900" Rotation="162" 
                                        WallWidth="25" />
								    <Area3DStyle IsRightAngleAxes="False" PointGapDepth="900" Rotation="162" 
                                        WallWidth="25" />
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
    </asp:Panel>
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnk_teamlist" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
            </td>
         
        </tr>
      
    </table>


    <table style="width: 100%;" class="sampleTable">
        <tr>
            <td width="412" class="tdchart">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
     <asp:Panel ID="Panel2" runat="server" Visible ="false">
                            	<asp:CHART id="Chart2" runat="server" Palette="BrightPastel" ImageLocation="TempImages/ChartPic_#SEQ(300,3)"
                                    BackColor="#F3DFC1" Width="953px" Height="296px" BorderDashStyle="Solid" 
                                    BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Column Chart" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False" Name="Default"></asp:Legend>
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
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"  />
										<MajorGrid LineColor="64, 64, 64, 64" />
									    <MajorGrid LineColor="64, 64, 64, 64" />
									    <MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" Format="MM-dd" />
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
            <asp:AsyncPostBackTrigger ControlID="lnk_blendlist" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
            </td>
         
        </tr>
      
    </table>
   

</asp:Content>


