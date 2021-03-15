<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"   CodeFile="Quotation_Dispatch_Sch.aspx.vb" Inherits="OPS_Quotation_Dispatch_Sch" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="System.Web.DataVisualization" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt" class="tableheader">
                Quotation 
                <asp:Label ID="lblQuotationNo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 10pt; text-align: center;">
                <asp:ImageButton ID="ibtBasicInfo" runat="server" 
                    ImageUrl="~/OPS/Image/STab_BasicInfo.png" CausesValidation="False" />
                <asp:ImageButton ID="ibtShadeQty" runat="server" 
                    ImageUrl="~/OPS/Image/STab_ShadesQuantities.png" 
                    CausesValidation="False" />
                <asp:ImageButton ID="ibtPayTerms" runat="server" 
                    ImageUrl="~/OPS/Image/STab_PaymentTerms.png" CausesValidation="False" />
                <asp:ImageButton ID="ibtDispatchDetail" runat="server" 
                    ImageUrl="~/OPS/Image/Tab_DispatchDetails.png" Enabled="False" />
            </td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td style="font-weight: bold; font-size: 10pt" colspan="6">
                Dispatch Schedule<hr /></td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 9pt; height: 0px; font-family: 'trebuchet MS';" 
                colspan="6">
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                    ValidationGroup="a" />
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 116px">
                Shade
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlDispatchShade" ErrorMessage="Please Provide Shade Name" 
                    SetFocusOnError="True" ValidationGroup="a">*</asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 150px">
                    <div id="divwidth" style="display:none;">   
                        </div>
           
              
                <asp:DropDownList ID="ddlDispatchShade" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource2" DataTextField="Shade" 
                    DataValueField="Shade" AppendDataBoundItems="True" AutoPostBack="True">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;<br />
            </td>
            <td class="labelcells" style="width: 86px">
                Quantity
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtDispatchQuantity" ErrorMessage="Please Specify Quantity" 
                    SetFocusOnError="True" ValidationGroup="a">*</asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 99px">
                <asp:TextBox ID="txtDispatchQuantity" runat="server" CssClass="textbox" 
                    Width="70px"></asp:TextBox>
            </td>
            <td class="labelcells" style="width: 145px">
                Customer Aprroval
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtDispatchDate" SetFocusOnError="True" 
                    ValidationGroup="a" ErrorMessage="Please Specify Scheduled Dispatch Date">*</asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlCustomerApproval" CssClass="combobox" runat="server">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 116px">
                Dispatch Date
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtDispatchDate" SetFocusOnError="True" 
                    ValidationGroup="a" ErrorMessage="Please Specify Scheduled Dispatch Date">*</asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 150px">
                <asp:TextBox ID="txtDispatchDate" runat="server" CssClass="textbox" 
                    ValidationGroup="a"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtDispatchDate_CalendarExtender" runat="server" 
                    TargetControlID="txtDispatchDate">
                </cc1:CalendarExtender>
                &nbsp;<asp:ImageButton ID="ibtAddDispatchItem" runat="server" 
                    ImageUrl="~/Image/Icons/Action/AddItem.png" ToolTip="Add Item to List" 
                    Width="20px" ValidationGroup="a" />
            </td>
            <td class="labelcells" style="width: 86px">
                &nbsp;</td>
            <td class="NormalText" style="width: 99px">
                &nbsp;</td>
            <td class="labelcells" style="width: 145px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>"                     
                    SelectCommand="jct_ops_get_quote_qty" 
                    DataSourceMode="DataReader" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblQuotationNo" Name="Quotation_No" 
                            PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="labelcells">
                Allocated Quantity</td>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblAllocatedQty" runat="server" ForeColor="#006600"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibtAddDispatchItem" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="grdDispatchDetail" 
                            EventName="RowDeleting" />
                        <asp:AsyncPostBackTrigger ControlID="ddlDispatchShade" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="labelcells">
                Unallocated Quantity</td>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblUnallocatedQty" runat="server" ForeColor="#CC0000"></asp:Label>
                    </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibtAddDispatchItem" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="grdDispatchDetail" 
                            EventName="RowDeleting" />
                        <asp:AsyncPostBackTrigger ControlID="ddlDispatchShade" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdDispatchDetail" runat="server" 
                                    EnableModelValidation="True" Width="100%">
                            <RowStyle CssClass="GridItem" />
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" 
                                            ImageUrl="~/OPS/Image/iPhone_Delete_icon.png" CommandName="Delete" 
                                            CausesValidation="False" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibtAddDispatchItem" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Destination Country
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtDestCountry" ErrorMessage="Please Provide Destination Country" 
                    SetFocusOnError="True" ValidationGroup="b">*</asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDestCountry" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                Destination City
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="txtDestCity" ErrorMessage="Please Provide Destination City" 
                    SetFocusOnError="True" ValidationGroup="b">*</asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDestCity" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Mode of Transit
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="ddlTransportMode" 
                    ErrorMessage="Please Select Mode of Transport" ValidationGroup="b">*</asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlTransportMode" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Road</asp:ListItem>
                    <asp:ListItem>Train</asp:ListItem>
                    <asp:ListItem>Air</asp:ListItem>
                    <asp:ListItem>Ship</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                UOM</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlUom" runat="server" CssClass="combobox">
                    <asp:ListItem>Mtrs</asp:ListItem>
                    <asp:ListItem>Yards</asp:ListItem>
                    <asp:ListItem>Kgs</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="labelcells" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Packing Remarks</td>
            <td colspan="3">
                <asp:TextBox ID="txtPackRemarks" runat="server" Columns="78" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="labelcells" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ValidationGroup="b" />
            </td>
        </tr>
        <tr>
            <td colspan="6" class="errormsg">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibtSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td>
                <asp:ImageButton ID="ibtSave" runat="server"
                    ImageUrl="~/Image/Icons/Action/document_save.png" ToolTip="Save" 
                    Width="32px" ValidationGroup="b" />
                <asp:ImageButton ID="ibtSave0" runat="server"
                    ImageUrl="~/Image/Icons/Action/back.png" ToolTip="Create and Save Quotation" 
                    Width="32px" onclientclick="window.history.go(-1);return false;" />
                 <asp:LinkButton ID="lnkDispatchSch" runat="server">Check Dispatch Schedule</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="lnkDispatchSch0" Visible="false" runat="server">Planned Orders Vs Capcity Mapping</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="lnkDispatchSch1" runat="server" Visible="false">Unplanned Vs Capacity Mapping</asp:LinkButton>


                </td>
        </tr>
    </table>

   
    <asp:Panel  runat="server" ID="pnlCharts" Visible="false">


    <table style="width: 100%;" class="sampleTable">
        <tr>
            <td width="500" class="tdchart">
            <div>
            <asp:Panel ID="Panel2" runat="server" Visible ="true" >
                            	<asp:CHART id="Chart2" runat="server" Palette="BrightPastel" 
                                    BackColor="#F3DFC1" Width="400px" Height="296px" BorderDashStyle="Solid" 
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
                                    LabelMapAreaAttributes="#VALY" LegendText="#VALX"  ToolTip="#VALX : #VALY Mtrs/Month"
                                    MapAreaAttributes="#VALX" Label="#VALY" LabelToolTip="#VALY Days">
								</asp:Series>
                            <asp:Series XValueType="String" Name="Series2" BorderColor="180, 26, 59, 105">
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
            </div>
     </td>
     <td width="500" class="tdchart">
 <div>
 <asp:Panel ID="Panel3" runat="server">
                    <asp:CHART ID="Chart3" runat="server" BackColor="#F3DFC1" 
                                    BackGradientStyle="TopBottom" BorderColor="181, 64, 1" BorderDashStyle="Solid" 
                                    BorderWidth="2" Height="296px" Palette="BrightPastel" 
                        Width="400px">
                        <titles>
                            <asp:Title Font="Trebuchet MS, 14.25pt, style=Bold" ForeColor="26, 59, 105" 
                                            Name="Title1" ShadowColor="32, 0, 0, 0" ShadowOffset="3" 
                                            Text="Column Chart">
                            </asp:Title>
                        </titles>
                        <legends>
                            <asp:Legend BackColor="Transparent" Enabled="False" 
                                            Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default" 
                                            TitleFont="Microsoft Sans Serif, 8pt, style=Bold">
                            </asp:Legend>
                        </legends>
                        <borderskin SkinStyle="Emboss" />
                        <series>
                            <asp:Series BorderColor="180, 26, 59, 105" Label="#VALY" 
                                            LabelMapAreaAttributes="#VALY" LabelToolTip="#VALY Days" LegendText="#VALX" 
                                            MapAreaAttributes="#VALX" Name="Series1" ToolTip="#VALX : #VALY Mtrs/Month" 
                                            XValueType="String">
                            </asp:Series>
                            <asp:Series BorderColor="180, 26, 59, 105" Name="Series2" XValueType="String">
                            </asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea BackColor="OldLace" BackGradientStyle="TopBottom" 
                                            BackSecondaryColor="White" BorderColor="64, 64, 64, 64" Name="ChartArea1" 
                                            ShadowColor="Transparent">
                                <area3dstyle Inclination="15" IsClustered="False" IsRightAngleAxes="False" 
                                                Perspective="10" Rotation="10" WallWidth="0" />
                                <axisy LabelAutoFitMaxFontSize="8" LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                </axisy>
                                <axisx LabelAutoFitMaxFontSize="8" LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="MM-dd" 
                                                    IsEndLabelVisible="False" />
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
 </div>
 </td>
 </tr>
 <tr>

 <td width="500" class="tdchart">
                
           <div>
           <asp:Panel ID="Panel4" runat="server">
                    <asp:CHART ID="Chart4" runat="server" BackColor="#F3DFC1" 
                                    BackGradientStyle="TopBottom" BorderColor="181, 64, 1" BorderDashStyle="Solid" 
                                    BorderWidth="2" Height="296px" Palette="BrightPastel" 
                        Width="400px">
                        <titles>
                            <asp:Title Font="Trebuchet MS, 14.25pt, style=Bold" ForeColor="26, 59, 105" 
                                            Name="Title1" ShadowColor="32, 0, 0, 0" ShadowOffset="3" 
                                            Text="Column Chart">
                            </asp:Title>
                        </titles>
                        <legends>
                            <asp:Legend BackColor="Transparent" Enabled="False" 
                                            Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default" 
                                            TitleFont="Microsoft Sans Serif, 8pt, style=Bold">
                            </asp:Legend>
                        </legends>
                        <borderskin SkinStyle="Emboss" />
                        <series>
                            <asp:Series BorderColor="180, 26, 59, 105" Label="#VALY" 
                                            LabelMapAreaAttributes="#VALY" LabelToolTip="#VALY Days" LegendText="#VALX" 
                                            MapAreaAttributes="#VALX" Name="Series1" ToolTip="#VALX : #VALY Mtrs/Month" 
                                            XValueType="String">
                            </asp:Series>
                            <asp:Series BorderColor="180, 26, 59, 105" Name="Series2" XValueType="String">
                            </asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea BackColor="OldLace" BackGradientStyle="TopBottom" 
                                            BackSecondaryColor="White" BorderColor="64, 64, 64, 64" Name="ChartArea1" 
                                            ShadowColor="Transparent">
                                <area3dstyle Inclination="15" IsClustered="False" IsRightAngleAxes="False" 
                                                Perspective="10" Rotation="10" WallWidth="0" />
                                <axisy LabelAutoFitMaxFontSize="8" LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                </axisy>
                                <axisx LabelAutoFitMaxFontSize="8" LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="MM-dd" 
                                                    IsEndLabelVisible="False" />
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
           </div>
                
 
            </td>
            <td width="412" class="tdchart"></td>
         
        </tr>
      
    </table>
        </asp:Panel>

</asp:Content>

