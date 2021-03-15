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
                Dispatch Schedule
                <asp:Label ID="lblScheduleStatus" runat="server"></asp:Label>
                <hr /></td>
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
                Customer Approval
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtDispatchDate" SetFocusOnError="True" 
                    ValidationGroup="a" ErrorMessage="Please Specify Scheduled Dispatch Date">*</asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlCustomerApproval" runat="server" CssClass="combobox" 
                    ValidationGroup="a">
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
                    ValidationGroup="c" ErrorMessage="Please Specify Scheduled Dispatch Date" 
                    Enabled="False">*</asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 150px">
                <asp:TextBox ID="txtDispatchDate" runat="server" CssClass="textbox" 
                    ValidationGroup="c"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtDispatchDate_CalendarExtender" runat="server" 
                    TargetControlID="txtDispatchDate">
                </cc1:CalendarExtender>
                &nbsp;</td>
            <td class="labelcells" style="width: 86px">
                <asp:ImageButton ID="ibtAddDispatchItem" runat="server" 
                    ImageUrl="~/Image/Icons/Action/iPhoneAdd.png" ToolTip="Add Item to List" 
                    ValidationGroup="a" style="height: 20px" />
            </td>
            <td class="NormalText" style="width: 99px">
                &nbsp;</td>
            <td class="labelcells" style="width: 145px">
                &nbsp;</td>
            <td class="NormalText">
                To specify whether Customer Approval is required before final dispatch of 
                materials</td>
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
                <asp:LinkButton ID="cmdReset" runat="server" 
                    
                    onclientclick="javascript: return Confirm('Are You Sure you want to reset all dispatch details? This cannot be undone!')" 
                    CausesValidation="False">Clear Dispatch Details</asp:LinkButton>
            </td>
            <td colspan="2">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="labelcells" colspan="2">
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
                <asp:LinkButton ID="cmdRefresh" runat="server" 
                    
                    onclientclick="javascript: return Confirm('Are You Sure you want to refresh all dispatch details from the database? This cannot be undone!')" 
                    CausesValidation="False" Visible="False">Refresh Dispatch Details</asp:LinkButton>
            </td>
            <td colspan="2">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="labelcells" colspan="2">
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
            <td colspan="8">
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
                                            CausesValidation="False" onclick="ImageButton1_Click" />
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
        <tr>
            <td colspan="2" style="font-weight: bold">
                &nbsp;</td>
            <td colspan="2" style="font-weight: bold">
                &nbsp;</td>
            <td colspan="2" style="font-weight: bold">
                &nbsp;</td>
            <td colspan="2" style="font-weight: bold">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="8" style="font-weight: bold">
                <asp:LinkButton ID="cmdPickSchedule" runat="server" CausesValidation="False" 
                    ToolTip="Your Dispatch Dates specified currently will get overwritten">Pick and Save Advised Schedule</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="8" style="font-weight: bold">
                        <asp:GridView ID="grdDispatchDetail0" runat="server" 
                                    EnableModelValidation="True" Width="100%" 
                            AutoGenerateColumns="False" DataSourceID="SqlDataSource3">
                            <RowStyle CssClass="GridItem" />
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:BoundField DataField="Shade" HeaderText="Shade" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                <asp:BoundField DataField="UOM" HeaderText="UOM" />
                                <asp:BoundField DataField="Dispatch_Date" HeaderText="Dispatch_Date" />
                                <asp:BoundField DataField="Advised_Date" HeaderText="Advised_Date" />
                                <asp:BoundField DataField="Approval_Status" HeaderText="Approval_Status" />
                                <asp:BoundField DataField="Approval_Authority" 
                                    HeaderText="Approval_Authority" />
                                <asp:BoundField DataField="Remark" HeaderText="Remark" />
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server"
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>"                     
                    SelectCommand="jct_ops_get_quote_dispatch_sch" 
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
            <td class="labelcells">
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
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
                        <asp:AsyncPostBackTrigger ControlID="cmdPickSchedule" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkForwardToPPC" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:ImageButton ID="ibtSave" runat="server"
                    ImageUrl="~/Image/Icons/Action/document_save.png" ToolTip="Save" 
                    Width="32px" ValidationGroup="b" />
                <asp:ImageButton ID="ibtSave0" runat="server"
                    ImageUrl="~/Image/Icons/Action/back.png" ToolTip="Create and Save Quotation" 
                    Width="32px" onclientclick="window.history.go(-1);return false;" />
             
                  

                </td>
        </tr>
        <tr>
            <td style="font-weight: bold">
                &nbsp;</td>
            <td style="font-weight: bold">
                &nbsp;</td>
            <td style="font-weight: bold">
                &nbsp;</td>
            <td style="font-weight: bold">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-weight: bold" class="labelcells">
                General Remarks</td>
            <td style="font-weight: bold">
                <asp:TextBox ID="txtRemarks" runat="server" Columns="78" CssClass="textbox" 
                    ValidationGroup="Remarks"></asp:TextBox>
             
                  

                </td>
            <td style="font-weight: bold">
                &nbsp;</td>
            <td style="font-weight: bold">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-weight: bold" colspan="4">
                <asp:LinkButton ID="lnkForwardToPPC" runat="server" CausesValidation="False" 
                    ValidationGroup="Remarks">Forward to PPC for Advise / Approval</asp:LinkButton>
             
                  

                </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="lnkDispatchSch" runat="server" CausesValidation="False">Check Dispatch Schedule</asp:LinkButton>
                </ContentTemplate>
                </asp:UpdatePanel>
             <asp:UpdateProgress ID="UpdateProgress4" AssociatedUpdatePanelID="UpdatePanel8" runat="server">
                <ProgressTemplate>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Image/load.gif" />
                </ProgressTemplate>
                </asp:UpdateProgress>
                </td>
        </tr>
    </table>

    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
    <ContentTemplate>
    

    <asp:Panel  runat="server" ID="pnlCharts" Visible="false">


    <table style="width: 100%;" class="sampleTable">
        <tr>
            <td width="500" class="tdchart">
            <div>
               <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                <ProgressTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <asp:Panel ID="Panel2" runat="server" Visible ="true" >
                    <asp:DropDownList ID="ddlYear1" runat="server" AutoPostBack="True" 
                        CssClass="combobox">
                    <asp:ListItem value="00">Choose Year</asp:ListItem>
                            <asp:ListItem Value="2012">2012</asp:ListItem>
                            <asp:ListItem value="2013">2013</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlMonth1" runat="server" CssClass="combobox" 
                        AutoPostBack="True">
                    <asp:ListItem value="00">Choose Month</asp:ListItem>
                            <asp:ListItem Value="01">Jan</asp:ListItem>
                            <asp:ListItem value="02">Feb</asp:ListItem>
                            <asp:ListItem value="03">March </asp:ListItem>
                            <asp:ListItem value="04">April</asp:ListItem>
                            <asp:ListItem value="05">May</asp:ListItem>
                            <asp:ListItem value="06">June</asp:ListItem>
                            <asp:ListItem value="07">July</asp:ListItem>
                            <asp:ListItem value="08">August</asp:ListItem>
                            <asp:ListItem value="09">September</asp:ListItem>
                            <asp:ListItem value="10">October</asp:ListItem>
                            <asp:ListItem value="11">November</asp:ListItem>
                            <asp:ListItem value="12">December</asp:ListItem>
                    </asp:DropDownList>
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
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkDispatchSch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ddlMonth1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlYear1" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                   
                </asp:UpdatePanel>
             

            </div>
     </td>
     <td width="500" class="tdchart">
 <div>
   <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel6" runat="server">
                <ProgressTemplate>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/load.gif" />
                </ProgressTemplate>
                </asp:UpdateProgress>
     <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
     <asp:Panel ID="Panel3" runat="server">
        <asp:DropDownList ID="ddlYear2" runat="server" AutoPostBack="True" 
             CssClass="combobox">
                    <asp:ListItem value="00">Choose Year</asp:ListItem>
                            <asp:ListItem Value="2012">2012</asp:ListItem>
                            <asp:ListItem value="2013">2013</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlMonth2" runat="server" CssClass="combobox" 
             AutoPostBack="True">
                    <asp:ListItem value="00">Choose Month</asp:ListItem>
                            <asp:ListItem Value="01">Jan</asp:ListItem>
                            <asp:ListItem value="02">Feb</asp:ListItem>
                            <asp:ListItem value="03">March </asp:ListItem>
                            <asp:ListItem value="04">April</asp:ListItem>
                            <asp:ListItem value="05">May</asp:ListItem>
                            <asp:ListItem value="06">June</asp:ListItem>
                            <asp:ListItem value="07">July</asp:ListItem>
                            <asp:ListItem value="08">August</asp:ListItem>
                            <asp:ListItem value="09">September</asp:ListItem>
                            <asp:ListItem value="10">October</asp:ListItem>
                            <asp:ListItem value="11">November</asp:ListItem>
                            <asp:ListItem value="12">December</asp:ListItem>
                    </asp:DropDownList>
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
     </ContentTemplate>
       <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkDispatchSch" EventName="Click" />
                             <asp:AsyncPostBackTrigger ControlID="ddlMonth1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlYear1" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
     </asp:UpdatePanel>
 
 </div>
 </td>
 </tr>
 <tr>

 <td width="500" class="tdchart">
                
           <div>
           <asp:UpdateProgress ID="UpdateProgress3" AssociatedUpdatePanelID="UpdatePanel7" runat="server">
                <ProgressTemplate>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Image/load.gif" />
                </ProgressTemplate>
                </asp:UpdateProgress>
     <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
     <asp:Panel ID="Panel4" runat="server">
         <asp:DropDownList ID="ddlYear3" runat="server" AutoPostBack="True" 
             CssClass="combobox">
                    <asp:ListItem value="00">Choose Year</asp:ListItem>
                            <asp:ListItem Value="2012">2012</asp:ListItem>
                            <asp:ListItem value="2013">2013</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlMonth3" runat="server" CssClass="combobox" 
             AutoPostBack="True">
                    <asp:ListItem value="00">Choose Month</asp:ListItem>
                            <asp:ListItem Value="01">Jan</asp:ListItem>
                            <asp:ListItem value="02">Feb</asp:ListItem>
                            <asp:ListItem value="03">March </asp:ListItem>
                            <asp:ListItem value="04">April</asp:ListItem>
                            <asp:ListItem value="05">May</asp:ListItem>
                            <asp:ListItem value="06">June</asp:ListItem>
                            <asp:ListItem value="07">July</asp:ListItem>
                            <asp:ListItem value="08">August</asp:ListItem>
                            <asp:ListItem value="09">September</asp:ListItem>
                            <asp:ListItem value="10">October</asp:ListItem>
                            <asp:ListItem value="11">November</asp:ListItem>
                            <asp:ListItem value="12">December</asp:ListItem>
                    </asp:DropDownList>
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
     </ContentTemplate>
       <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkDispatchSch" EventName="Click" />
                             <asp:AsyncPostBackTrigger ControlID="ddlMonth1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlYear1" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
     </asp:UpdatePanel>

           
           </div>
                
 
            </td>
            <td width="412" class="tdchart"></td>
         
        </tr>
      
    </table>
        </asp:Panel>


     </ContentTemplate>
     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkDispatchSch" EventName="Click" />
                        
                    </Triggers>
    </asp:UpdatePanel>

</asp:Content>

