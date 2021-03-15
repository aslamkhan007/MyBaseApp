<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="PlanSummary.aspx.cs" Inherits="OPS_PlanSummary" %>

<%@ Register assembly="System.Web.DataVisualization" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Plan Summary"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 95px">
                <asp:Label ID="Label19" runat="server" Text="Select Plant"></asp:Label>
            </td>
            <td class="NormalText">
               
                <telerik:RadDropDownList runat="server" ID="ddlPlant" 
                    DefaultMessage="--Select--" Width="100px" >
                    <Items>
                    <telerik:DropDownListItem Text="COTTON" />
                    <telerik:DropDownListItem Text="TAFFETA" />
                    </Items>
                </telerik:RadDropDownList>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 95px">
                <asp:Label ID="Label17" runat="server" Text="Weaving Plan"></asp:Label>
            </td>
            <td class="NormalText">

                    <telerik:RadNumericTextBox runat="server" ID="txtWeavingPlan" 
                   
                    MaxLength="5" Culture="en-US" DbValueFactor="1" LabelWidth="64px" 
                    Width="60px"></telerik:RadNumericTextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                    <telerik:RadButton runat="server" ID="btnSummary" Text="Summary" 
                            onclick="btnSummary_Click"></telerik:RadButton>
                    <telerik:RadButton runat="server" ID="btnReset" Text="Reset" 
                            onclick="btnExcel_Click"></telerik:RadButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>

                        <asp:GridView ID="grdPlan" runat="server" AutoGenerateColumns="False" 
                            EnableModelValidation="True" onrowdatabound="grdPlan_RowDataBound" 
                            Width="100%" onselectedindexchanged="grdPlan_SelectedIndexChanged" 
                            onrowcommand="grdPlan_RowCommand">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkActivate" runat="server" CommandName="Activate">Activate</asp:LinkButton>
                                         <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkActivate" ConfirmText="Are your Sure ?"></cc1:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDeactivate" runat="server" CommandName="Deactivate">De-Activate</asp:LinkButton>
                                          <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="lnkDeactivate" ConfirmText="Are your Sure ?"></cc1:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PlanID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlanID" runat="server" Text='<%# Eval("PlanID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StartDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("EndDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Activated">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActivated" runat="server" Text='<%# Eval("Activated") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle CssClass="FooterStyle" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="PagerStyle" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                    <telerik:RadButton runat="server" ID="btnChart" Text="Chart" 
                        onclick="btnChart_Click" Visible="False"></telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
   <telerik:RadHtmlChart runat="server" ID="RadHtmlChart1" Skin="Windows7"  OnClientSeriesClicked="OnClientSeriesClicked"
                    Height="400px" Width="400px">
                    <PlotArea>
                        <Series>
                            <telerik:ColumnSeries Name="Summary" DataFieldY="Value">
                                <TooltipsAppearance DataFormatString="{0}" />
                                <LabelsAppearance Visible="false" />
                            </telerik:ColumnSeries>
                            
                        </Series>
                    <XAxis DataLabelsField="Info" >
                    <TitleAppearance Text="Items" ></TitleAppearance>
                    </XAxis> 
                    <YAxis>
                    <TitleAppearance Text="No. of Items"></TitleAppearance>
                            <LabelsAppearance DataFormatString="{0}"  />
                     </YAxis>
                    </PlotArea>
                    <Legend>
                        <Appearance Visible="false" />
                    </Legend>
                    <ChartTitle Text="Plan Summary">
                    </ChartTitle>
                </telerik:RadHtmlChart>

            <%--    <script type="text/javascript">
                    function OnClientSeriesClicked(sender, args) {
                        var theDataItem = args.get_dataItem();
                        theDataItem.IsExploded = !theDataItem.IsExploded;
                        sender.repaint();
                    }
</script>--%>
<%--
<script type="text/javascript">
    function OnClientSeriesClicked(sender, eventArgs) {
        alert("You clicked on a series item with value '" + eventArgs.get_value() + "' from category '" + eventArgs.get_category() + "'.");
    }
    </script>--%>

            </td>
        </tr>
        <tr>
            <td class="NormalText">
 
                            </td>
        </tr>
        </table>

</asp:Content>

