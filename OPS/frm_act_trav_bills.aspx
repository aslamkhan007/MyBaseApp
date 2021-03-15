<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_act_trav_bills.aspx.vb" Inherits="frm_act_trav_bills"Title="Untitled Page" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="System.Web.DataVisualization" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table style="width:100%;" >
        <tr>
            <td class="tableheader" colspan="4" >
                Travelling Bills
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 104px">
                <asp:Label ID="Label2" runat="server" Text="Effective From"></asp:Label>
            </td>
            <td style="width: 202px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                 <asp:TextBox ID="txtEffecFrom" runat="server" CssClass="textbox" Width="62px" 
                        MaxLength="10"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtEffecFrom_FilteredTextBoxExtender" 
                        runat="server" FilterInterval="10" InvalidChars="a-z" 
                        TargetControlID="txtEffecFrom" ValidChars="1,2,3,4,5,6,7,8,9,0,/">
                    </cc1:FilteredTextBoxExtender>
                <cc1:CalendarExtender ID="txtEffecFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecFrom" >
                </cc1:CalendarExtender>
                </ContentTemplate>
                </asp:UpdatePanel>
               
            </td>
            <td class="NormalText" style="width: 117px">
                <asp:Label ID="Label3" runat="server" Text="Effective To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEffecTo" runat="server" CssClass="textbox" 
                            AutoPostBack="True" Width="71px" MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtEffecTo_FilteredTextBoxExtender" 
                            runat="server" InvalidChars="a-z" TargetControlID="txtEffecTo" 
                            ValidChars="1,2,3,4,5,6,7,8,9,0,/">
                        </cc1:FilteredTextBoxExtender>
                        <cc1:CalendarExtender ID="txtEffecTo_CalendarExtender" runat="server" 
                          TargetControlID="txtEffecTo">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 104px">
                <asp:Label ID="label14" runat="server" CssClass=" " Text="Location " 
                    style="text-align: left"></asp:Label>
            </td>
            <td style="width: 202px" >
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddllocation" runat="server" AutoPostBack="True" 
                                    CssClass="combobox" Height="18px" Width="183px">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtEffecTo" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 117px" >
                <asp:Label ID="label15" runat="server" CssClass=" " Text="Cost Center " 
                    style="text-align: left"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlcostcenter" runat="server" AutoPostBack="True" 
                            CssClass="combobox" Width="183px" Height="18px">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddllocation" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
               </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 104px">
                <asp:Label ID="label13" runat="server" CssClass=" " Text="Employee Name "></asp:Label>
            </td>
            <td style="width: 202px" >
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlemployee" runat="server" AutoPostBack="True" 
                                    CssClass="combobox" Height="18px" Width="183px">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlcostcenter" 
                                    EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 117px" >
                &nbsp;</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlcostcenter" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
               </td>
        </tr>
        </table>
    <table style="width:100%;" >
        <tr>
            <td class="buttonbackbar" >
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdFetch" runat="server" CssClass="buttonc" 
                    >Fetch</asp:LinkButton>
                        <asp:LinkButton ID="cmdclose" runat="server" CssClass="buttonc"
                            onclick="cmdclose_Click" >Close</asp:LinkButton>
                        <asp:LinkButton ID="lnkchart" runat="server" CssClass="buttonc">Chart</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:LinkButton ID="cmdexcel1" runat="server" CssClass="buttonc" 
                   >Excel</asp:LinkButton><uc1:FlashMessage id="FMsg" runat="server" EnableTheming="true" EnableViewState="true" FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true"></uc1:FlashMessage>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel5">
                    <ProgressTemplate>
                        Please wait...<asp:Image ID="ProgressBar" runat="server" ForeColor="#3333FF" 
                           ImageUrl="~/Image/loading.gif" />
                        &nbsp;
                        <br />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
              
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                             <asp:Panel ID="Panel2" CssClass="panelbg" runat="server">
                            <asp:GridView ID="grdGrid1" runat="server" OnRowDataBound="grdgrid1_RowDataBound" 
                                     Width="100%" PageSize="5" 
                                     Style="margin-top: 9px" ShowFooter="True">
                                <RowStyle CssClass="GridItem" />
                                <EmptyDataTemplate>
                                    Perticular not prepared for this Shed
                                </EmptyDataTemplate>
                                <SelectedRowStyle CssClass="selectedrow" />
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GridAI" />
                            </asp:GridView> 
                            </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmdFetch" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
               
            </td>
        </tr>
    </table>
    <table class="tableback">
    <tr>
    <td class="NormalText">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlChart"  style="width:100%" runat="server" 
            Visible="False">
            <asp:Chart ID="Chart1" runat="server" Palette="BrightPastel" BackColor="#F3DFC1"
                Width="953px" Height="500px" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                BorderWidth="2" BorderColor="181, 64, 1">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        Text="Column Chart" Name="Title1" ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False"
                        Name="Default">
                    </asp:Legend>
                </Legends>
                <BorderSkin SkinStyle="Emboss"></BorderSkin>
                <Series>
                    <asp:Series XValueType="String" YValueType="Int64" Name="Series1" BorderColor="180, 26, 59, 105" LabelMapAreaAttributes="#VALY"
                        LegendText="#VALX" MapAreaAttributes="#VALX"  ToolTip="#VALX :Rs #VALY" Label="#VALY" LabelToolTip="#VALY">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                        BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                        <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                            WallWidth="0" IsClustered="False" />
                        <AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisY>
                        <AxisX LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" Format="MM-dd" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                        <Area3DStyle Inclination="15" IsRightAngleAxes="False" Perspective="10" Rotation="10"
                            WallWidth="0" />
                        <Area3DStyle Inclination="15" IsRightAngleAxes="False" Perspective="10" Rotation="10"
                            WallWidth="0" />
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </asp:Panel>
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="cmdFetch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="lnkchart" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    </td>
    </tr>
    </table>
    
</asp:Content>


