<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_raw_material_cost.aspx.vb" Inherits="frm_raw_material_cost"Title="Untitled Page" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="System.Web.DataVisualization" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<script runat="server">

   
</script>


<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="5" style="height: 37px" >
                Raw Material Cost &nbsp;
            </td>
        </tr>
        <tr>
            <td  class="labelcells">
                <asp:Label ID="label5" runat="server" Text="Yr Month"></asp:Label>
            </td>
            <td>
                        <asp:DropDownList ID="ddlyrmth" runat="server" AutoPostBack="True" 
                    CssClass="combobox" >
                        </asp:DropDownList>
            </td>
            <td  class="labelcells">
                <asp:Label ID="label11" runat="server" Text="Location "></asp:Label>
            </td>
            
            <td style="" class="labelcells">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddllocation" runat="server" AutoPostBack="True" 
                            CssClass="combobox" >
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlyrmth" 
                                    EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
            </td>
            
        </tr>
        <tr>
            <td  class="labelcells">
                <asp:Label ID="label12" runat="server" Text="Sale Team"></asp:Label>
            </td>
            <td >
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlsaleteam" runat="server" AutoPostBack="True" 
                                    CssClass="combobox">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddllocation" 
                                    EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlyrmth" 
                                    EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
            </td>
            <td  class="labelcells">
                 <asp:LinkButton ID="LinkButton1" runat="server" Visible="False">LinkButton</asp:LinkButton></td>
            <td  class="labelcells" >
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="5" >
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdFetch" runat="server" CssClass="buttonc" Height="22px" 
                     Width="84px" TabIndex="50">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc" Height="22px" 
                            onclick="cmdclose_Click" Width="84px" TabIndex="60">Close</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:LinkButton ID="cmdexcel1" runat="server" CssClass="buttonc" 
                    TabIndex="70">Excel</asp:LinkButton>
                    
                    <uc1:FlashMessage id="FMsg" runat="server" EnableTheming="true" EnableViewState="true" FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true"></uc1:FlashMessage>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="5">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel5">
                    <ProgressTemplate>
                        Please wait...<asp:Image ID="ProgressBar" runat="server" ForeColor="#3333FF" 
                             ImageUrl="~/Image/loading.gif"  />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="panelcells" colspan="5">
            <div  id = "AdjResultsDiv" style=" width: 100%; height:300px; top: 0px;"> 
                        
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdGrid1" runat="server"  OnRowDataBound="grdgrid1_RowDataBound"
                                                         Height="15%"  HorizontalAlign="Left" Width="100%" PageSize="5" ShowFooter="True">
                                                                <RowStyle CssClass="RowStyle" />
                                                                <EmptyDataTemplate>
                                                                    No Freeze Orders
                                                                </EmptyDataTemplate>
                                                                <SelectedRowStyle CssClass="selectedrow" />
                                                                <HeaderStyle BorderStyle="None" CssClass="gridheader" />
                                                                <AlternatingRowStyle BorderStyle="None" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                     </div> 
                <br />
            </td>
        </tr>
    </table>

     <table style="width: 100%;" class="sampleTable">
        <tr>
            <td width="412" class="tdchart">
         <asp:Panel ID="Panel2" runat="server" Visible ="false">
            <asp:CHART id="Chart1" runat="server" Palette="BrightPastel" 
                                    BackColor="#F3DFC1" Width="500px" Height="296px" BorderDashStyle="Solid" 
                                    BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Column Chart" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series XValueType="String" Name="Series1" BorderColor="180, 26, 59, 105" 
                                    LabelMapAreaAttributes="#VALY" LegendText="#VALX"  ToolTip="#VALX : #VALY Days"
                                    MapAreaAttributes="#VALX" Label="#VALY" LabelToolTip="#VALY Days">
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
 
            </td>
         
        </tr>
      
    </table>

</asp:Content>


