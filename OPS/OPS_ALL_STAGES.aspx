<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="OPS_ALL_STAGES.aspx.vb" Inherits="OPS_OPS_ALL_STAGES" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="cc2" %>
<%@ Register Assembly="System.Web.DataVisualization" Namespace="System.Web.UI.DataVisualization.Charting"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt" class="tableheader" colspan="4">
                Process Stage
            </td>
            <td style="font-weight: bold; font-size: 10pt" class="tableheader">
                &nbsp;
            </td>
        </tr>

        <tr>
            <td class="labelcells" style="height: 25px; width: 96px;">
                Plant</td>
            <td class="NormalText" valign="top" style="width: 227px; height: 25px;">
                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="ddlPlant" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>ALL</asp:ListItem>
                            <asp:ListItem>TAFFETA</asp:ListItem>
                            <asp:ListItem>COTTON</asp:ListItem>
                        </asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
            <td class="labelcells" style="height: 25px">
                Process</td>
            <td class="NormalText" valign="top" style="height: 25px; width: 325px;">
               <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                           <ContentTemplate>
                        <cc2:DropDownCheckBoxes ID="ddlMapProcess" runat="server" AutoPostBack="true">
                            <Style2 DropDownBoxBoxWidth="150" SelectBoxWidth="160" />
                            <Texts SelectBoxCaption="Please Choose Process" SelectAllNode="SELECT ALL" />
                             
                            <Texts SelectAllNode="SELECT ALL" />
                        </cc2:DropDownCheckBoxes>
                    </ContentTemplate>
                </asp:UpdatePanel>
               
               
               
               </td>
            <td class="NormalText" valign="top" style="height: 25px">
                &nbsp;</td>
        </tr>

        <tr>
            <td class="labelcells" style="height: 25px; width: 96px;">
                Process
                Stage</td>
            <td class="NormalText" valign="top" style="width: 227px; height: 25px;">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <cc2:DropDownCheckBoxes ID="ddlProcess" runat="server" AutoPostBack="true" 
                            CssClass="chkbox" style="top: 0px; left: 1px">
                            <Style2 DropDownBoxBoxWidth="250" SelectBoxWidth="250" />
                            <Texts SelectBoxCaption="Please Choose Process Stage" SelectAllNode="SELECT ALL" />
                        </cc2:DropDownCheckBoxes>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="height: 25px">
                Category
            </td>
            <td class="NormalText" valign="top" style="height: 25px; width: 325px;">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <cc2:DropDownCheckBoxes ID="ddlCategory" runat="server" Style="top: 0px; left: -450px">
                            <Style2 DropDownBoxBoxWidth="250" SelectBoxWidth="250" />
                            <Texts SelectAllNode="SELECT ALL" />
                        </cc2:DropDownCheckBoxes>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlProcess" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" valign="top" style="height: 25px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 96px">
                Finacial Year
            </td>
            <td class="NormalText" valign="top" style="width: 227px">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <cc2:DropDownCheckBoxes ID="ddlFinYear" runat="server" Style="top: 0px; left: -450px">
                            <Style2 DropDownBoxBoxWidth="150" SelectBoxWidth="160" />
                            <Texts SelectAllNode="SELECT ALL" />
                        </cc2:DropDownCheckBoxes>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlProcess" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Columns
            </td>
            <td class="NormalText" valign="top" style="width: 325px">
                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                    <ContentTemplate>
                        <cc2:DropDownCheckBoxes ID="ddlPeriod" runat="server" AutoPostBack="true">
                            <Style2 DropDownBoxBoxWidth="150" SelectBoxWidth="160" />
                            <Items>
                                <asp:ListItem Enabled="False" Selected="True" Text="PROCESS STAGE" Value="PROCESS STAGE" />
                                <asp:ListItem Selected="True" Text="FINANCIAL YEAR" Value="FINANCIAL YEAR" />
                                <asp:ListItem Selected="True" Text="CATEGORY" Value="CATEGORY" />
                                <asp:ListItem Selected="True" Text="UOM" Value="UOM" />
                              
                                <asp:ListItem Selected="True" Text="APR" Value="APR" />
                                <asp:ListItem Selected="True" Text="MAY" Value="MAY" />
                                <asp:ListItem Selected="True" Text="JUN" Value="JUN" />
                                <asp:ListItem Selected="True" Text="JUL" Value="JUL" />
                                <asp:ListItem Selected="True" Text="AUG" Value="AUG" />
                                <asp:ListItem Selected="True" Text="SEP" Value="SEP" />
                                <asp:ListItem Selected="True" Text="OCT" Value="OCT" />
                                <asp:ListItem Selected="True" Text="NOV" Value="NOV" />
                                <asp:ListItem Selected="True" Text="DEC" Value="DEC" />
                                  <asp:ListItem Selected="True" Text="JAN" Value="JAN" />
                                <asp:ListItem Selected="True" Text="FEB" Value="FEB" />
                                <asp:ListItem Selected="True" Text="MAR" Value="MAR" />
                                <asp:ListItem Selected="True" Text="Q1" Value="Q1" />
                                <asp:ListItem Selected="True" Text="Q2" Value="Q2" />
                                <asp:ListItem Selected="True" Text="Q3" Value="Q3" />
                                <asp:ListItem Selected="True" Text="Q4" Value="Q4" />
                                <asp:ListItem Selected="True" Text="YEAR" Value="YEAR" />
                            </Items>
                            <Texts SelectAllNode="SELECT ALL" />
                        </cc2:DropDownCheckBoxes>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" valign="top">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 96px">
                Order By
            </td>
            <td class="NormalText" valign="top" style="width: 227px">
                <asp:UpdatePanel ID="UpdatePanel23" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <cc2:DropDownCheckBoxes ID="ddlOrderBy" runat="server" Style="top: 0px; left: 0px">
                            <Style2 SelectBoxWidth="160" DropDownBoxBoxWidth="150" />
                            <Texts SelectAllNode="SELECT ALL" />
                        </cc2:DropDownCheckBoxes>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlPeriod" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Group By
            </td>
            <td class="NormalText" valign="top" style="width: 325px">
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                    <ContentTemplate>
                        <cc2:DropDownCheckBoxes ID="ddlGroupBy" runat="server" Style="top: 3px; left: 494px">
                            <Style2 SelectBoxWidth="160" DropDownBoxBoxWidth="150" />
                            <Texts SelectAllNode="SELECT ALL" />
                        </cc2:DropDownCheckBoxes>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlPeriod" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" valign="top">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="tableheader" colspan="4" style="color: #008080">
                <asp:Image ID="ImageQuery" runat="server" ImageUrl="Image/plus.png" Style="margin-right: 5px;" />
                Query Option
            </td>
            <td class="NormalText" valign="top">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderWidth="1px">
                    <table style="width: 100%;" class="tableback">
                        <tr>
                            <td style="width: 93px; text-align: left" class="labelcells">
                                Short Name
                            </td>
                            <td style="width: 124px">
                                <asp:TextBox ID="txtShort" runat="server" CssClass="textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtShort"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td class="labelcells" style="width: 113px">
                                Long Name
                            </td>
                            <td class="NormalText" style="width: 342px" valign="top">
                                <asp:TextBox ID="txtLong" runat="server" CssClass="textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLong"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="labelcells" style="width: 93px">
                                Your Choice
                            </td>
                            <td style="width: 124px">
                                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlChoice" runat="server" Height="20px" Width="263px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="labelcells">
                                Default
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="cbDefalut" runat="server" Text="Yes" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 93px">
                                <cc1:CollapsiblePanelExtender ID="cpe" runat="Server" AutoCollapse="False" AutoExpand="True"
                                    CollapseControlID="ImageQuery" Collapsed="False" CollapsedImage="Image/plus.png"
                                    CollapsedSize="0" ExpandControlID="ImageQuery" ExpandDirection="Vertical" ExpandedImage="Image/minus.png"
                                    ImageControlID="ImageQuery" ScrollContents="false" TargetControlID="Panel1" />
                            </td>
                            <td style="width: 124px">
                                &nbsp;
                            </td>
                            <td style="width: 113px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td class="NormalText" valign="top">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="tableheader" style="color: #FF0000;" colspan="4">
                <asp:Image ID="ImageGraph" runat="server" ImageUrl="Image/plus.png" Style="margin-right: 5px;" />
                Graph Option
            </td>
            <td class="NormalText" valign="top">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="pnlGraph" runat="server" BorderStyle="Solid" BorderWidth="1px">
                    <table style="width: 100%;" class="tableback">
                        <tr>
                            <td style="width: 93px; text-align: left" class="labelcells">
                                X Axis&#39;s
                            </td>
                            <td style="width: 124px">
                                <asp:DropDownList ID="ddlXaxis" runat="server" Height="20px" Width="218px">
                                    <asp:ListItem>ProcStage</asp:ListItem>
                                    <asp:ListItem>FinYear</asp:ListItem>
                                    <asp:ListItem>Category</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="labelcells" style="width: 113px">
                                &nbsp; X Axis&#39;s
                            </td>
                            <td class="NormalText" style="width: 342px" valign="top">
                                &nbsp;
                                <asp:DropDownList ID="ddlChartType" runat="server" Height="20px" Width="218px">
                                     <asp:ListItem>Area</asp:ListItem>
 
                 <asp:ListItem>Bar</asp:ListItem>
 
                 <asp:ListItem>BoxPlot</asp:ListItem>
 
                 <asp:ListItem>Bubble</asp:ListItem>
 
                 <asp:ListItem>Candlestick</asp:ListItem>
 
                 <asp:ListItem>Column</asp:ListItem>
 
                 <asp:ListItem>Doughnut</asp:ListItem>
 
                 <asp:ListItem>ErrorBar</asp:ListItem>
 
                 <asp:ListItem>FastLine</asp:ListItem>
 
                 <asp:ListItem>Funnel</asp:ListItem>
 
                 <asp:ListItem>Kagi</asp:ListItem>
 
                 <asp:ListItem>Line</asp:ListItem>
   
                 <asp:ListItem>Pie</asp:ListItem>
     
                 <asp:ListItem>Point</asp:ListItem>
      
                 <asp:ListItem>PointAndFigure</asp:ListItem>
 
                 <asp:ListItem>Polar</asp:ListItem>
 
                 <asp:ListItem>Pyramid</asp:ListItem>
 
                 <asp:ListItem>RangeBar</asp:ListItem>
   
                 <asp:ListItem>RangeColumn</asp:ListItem>
 
                 <asp:ListItem>Spline</asp:ListItem>
 
                 <asp:ListItem>Pyramid</asp:ListItem>
 
                 <asp:ListItem>RangeColumn</asp:ListItem>
   
                 <asp:ListItem>Spline</asp:ListItem>
 
                 <asp:ListItem>StackedArea</asp:ListItem>
    
                 <asp:ListItem>StackedBar</asp:ListItem>
   
                 <asp:ListItem>StepLine</asp:ListItem>
     
                 <asp:ListItem>Stock</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="labelcells" style="width: 93px">
                                &nbsp;
                            </td>
                            <td style="width: 124px">
                                &nbsp;
                            </td>
                            <td class="labelcells">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 93px">
                                <cc1:CollapsiblePanelExtender ID="cpe0" runat="Server" AutoCollapse="False" AutoExpand="True"
                                    CollapseControlID="ImageGraph" Collapsed="False" CollapsedImage="Image/plus.png"
                                    CollapsedSize="0" ExpandControlID="ImageGraph" ExpandDirection="Vertical" ExpandedImage="Image/minus.png"
                                    ImageControlID="ImageGraph" ScrollContents="false" TargetControlID="pnlGraph" />
                            </td>
                            <td style="width: 124px">
                                &nbsp;
                            </td>
                            <td style="width: 113px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td class="NormalText" valign="top">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" Height="22px" Width="84px"
                    CausesValidation="False">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" Height="22px" Width="83px"
                    CausesValidation="False">To Excel</asp:LinkButton>
                <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" Height="22px" Width="83px">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkSaveQuery" runat="server" CssClass="buttonc" Height="22px"
                    Width="83px" CausesValidation="False">Run Query</asp:LinkButton>
                <asp:LinkButton ID="lnkChart" runat="server" CssClass="buttonc" Height="22px" Width="83px"
                    CausesValidation="False">Graph</asp:LinkButton>
            </td>
            <td style="text-align: center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="pnlGrid" runat="server" Height="350px" Width="1000px" ScrollBars="Both">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="grdStage" runat="server" AllowPaging="True" CssClass="GridViewStyle"
                                GridLines="None" PageSize="50" ShowFooter="True" Width="100%">
                                <RowStyle CssClass="RowStyle" />
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <EditRowStyle CssClass="EditRowStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="labelcells">
                <asp:Chart ID="Chart1" runat="server" Height="400PX" Width="1000px" Palette="BrightPastel"
                    ImageType="Png" BorderDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom"
                    BorderWidth="2" BackColor="#D3DFF0" BorderColor="26, 59, 105" ImageLocation="chart_0_0.png"
                    ImageStorageMode="UseImageLocation">
                    <Legends>
                        <asp:Legend IsTextAutoFit="True" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"
                            Docking="Top" TableStyle="Wide">
                        </asp:Legend>
                    </Legends>
                    <BorderSkin SkinStyle="Emboss"></BorderSkin>
                    <Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisY LineColor="64, 64, 64, 64">
                                <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                            </AxisY>
                            <AxisX IsMarginVisible="False" LineColor="64, 64, 64, 64" LabelAutoFitStyle="LabelsAngleStep90"
                                Interval="1">
                                <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
            <td class="NormalText" style="width: 312px">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <asp:Panel ID="pnlSaleOrder" runat="server" Width="150px" Style="display: none; background: white;"
                ScrollBars="Vertical">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True">
                    <asp:ListItem>PROCESS STAGE</asp:ListItem>
                    <asp:ListItem>CATEGORY</asp:ListItem>
                    <asp:ListItem>FINANCIAL YEAR</asp:ListItem>
                    <asp:ListItem>UOM</asp:ListItem>
                    <asp:ListItem>TDY</asp:ListItem>
                    <asp:ListItem>JAN</asp:ListItem>
                    <asp:ListItem>FEB</asp:ListItem>
                    <asp:ListItem>MAR</asp:ListItem>
                    <asp:ListItem>APR</asp:ListItem>
                    <asp:ListItem>MAY</asp:ListItem>
                    <asp:ListItem>JUN</asp:ListItem>
                    <asp:ListItem>JUL</asp:ListItem>
                    <asp:ListItem>AUG</asp:ListItem>
                    <asp:ListItem>SEP</asp:ListItem>
                    <asp:ListItem>OCT</asp:ListItem>
                    <asp:ListItem>NOV</asp:ListItem>
                    <asp:ListItem>DEC</asp:ListItem>
                    <asp:ListItem>Q1</asp:ListItem>
                    <asp:ListItem>Q2</asp:ListItem>
                    <asp:ListItem>Q3</asp:ListItem>
                    <asp:ListItem>Q4</asp:ListItem>
                    <asp:ListItem>YEAR</asp:ListItem>
                </asp:CheckBoxList>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <asp:Panel ID="pnlOrderBy" runat="server" Width="150px" Style="display: none; background: white;"
                ScrollBars="Vertical">
                <asp:CheckBoxList ID="cblOrderBy" runat="server" AutoPostBack="True">
                    <asp:ListItem>PROCESS STAGE</asp:ListItem>
                    <asp:ListItem>CATEGORY</asp:ListItem>
                    <asp:ListItem>FINANCIAL YEAR</asp:ListItem>
                    <asp:ListItem>UOM</asp:ListItem>
                    <asp:ListItem>JAN</asp:ListItem>
                    <asp:ListItem>FEB</asp:ListItem>
                    <asp:ListItem>MAR</asp:ListItem>
                    <asp:ListItem>APR</asp:ListItem>
                    <asp:ListItem>MAY</asp:ListItem>
                    <asp:ListItem>JUN</asp:ListItem>
                    <asp:ListItem>JUL</asp:ListItem>
                    <asp:ListItem>AUG</asp:ListItem>
                    <asp:ListItem>SEP</asp:ListItem>
                    <asp:ListItem>OCT</asp:ListItem>
                    <asp:ListItem>NOV</asp:ListItem>
                    <asp:ListItem>DEC</asp:ListItem>
                    <asp:ListItem>Q1</asp:ListItem>
                    <asp:ListItem>Q2</asp:ListItem>
                    <asp:ListItem>Q3</asp:ListItem>
                    <asp:ListItem>Q4</asp:ListItem>
                    <asp:ListItem>YEAR</asp:ListItem>
                </asp:CheckBoxList>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <asp:Panel ID="pnlGroupBy" runat="server" Width="150px" Style="display: none; background: white;"
                ScrollBars="Vertical">
                <asp:CheckBoxList ID="cblGroupBy" runat="server" AutoPostBack="True">
                </asp:CheckBoxList>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <asp:Panel ID="PanelFinYear" runat="server" CssClass="panelbg" Width="130px" Style="display: none;
                background: white;" ScrollBars="Vertical">
                <asp:CheckBoxList ID="cblFinYear" runat="server" AutoPostBack="True">
                </asp:CheckBoxList>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
