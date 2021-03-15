<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="QuotationPlanningReport.aspx.cs" Inherits="OPS_QuotationPlanningReport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader">
                
                <asp:Label ID="Label16" runat="server" Text="Quotation Authorized by Planning"></asp:Label>

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="JCT_OPS_QUOTATION_PLANNING_REPORT_PARTICULARS" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="QUOTATIONNO" SessionField="QuotationNo" 
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" style="width: 178px">
                <asp:Label ID="Label17" runat="server" Text="Advised Dispatch Date From"></asp:Label>
                
            </td>
            <td class="NormalText" style="width: 152px">
                <telerik:RadDatePicker ID="txtDateFrom" Runat="server" ShowPopupOnFocus="True" 
                    Skin="Default" Culture="en-US" Width="100px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="Windows7"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40px" Width="100px"  ></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
                
            </td>
            <td class="NormalText" style="width: 161px">
                <asp:Label ID="Label18" runat="server" Text="Advised Dispatch Date To"></asp:Label>
                
            </td>
            <td class="NormalText">
                <telerik:RadDatePicker ID="txtDateTo" Runat="server" Culture="en-US" 
                    ShowPopupOnFocus="True" Width="100px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%" Width="100px"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
                
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 178px">
                Quotation Date From</td>
            <td class="NormalText" style="width: 152px">
                <telerik:RadDatePicker ID="txtQuotDateFrom" Runat="server" Culture="en-US" 
                    ShowPopupOnFocus="True" Width="100px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%" Width="100px"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
                
            </td>
            <td class="NormalText" style="width: 161px">
                Quotation Date To</td>
            <td class="NormalText">
                <telerik:RadDatePicker ID="txtQuotDateTo" Runat="server" Culture="en-US" 
                    ShowPopupOnFocus="True" Width="100px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="Web20"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%" Width="100px"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
                
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 178px">
                Quotation No</td>
            <td class="NormalText" style="width: 152px">
                <asp:TextBox ID="txtQuotationNo" runat="server" CssClass="textbox"></asp:TextBox>
                
            </td>
            <td class="NormalText" style="width: 161px">
                Order No</td>
            <td class="NormalText">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 178px">
                Plant</td>
            <td class="NormalText" style="width: 152px">
                <telerik:RadDropDownList ID="radDDLPlant" runat="server" Skin="Default" 
                    Width="126px">
                    <Items>
                        <telerik:DropDownListItem runat="server" Selected="True" />
                        <telerik:DropDownListItem runat="server" Text="COTTON" />
                        <telerik:DropDownListItem runat="server" Text="TAFFETA" />
                    </Items>
                </telerik:RadDropDownList>
                
            </td>
            <td class="NormalText" style="width: 161px">
                Sort No</td>
            <td class="NormalText">
                <asp:TextBox ID="txtSortNo" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
                
                <cc1:FilteredTextBoxExtender ID="txtSortNo_FilteredTextBoxExtender" 
                    runat="server" TargetControlID="txtSortNo" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <telerik:RadButton ID="radFetch" runat="server" onclick="radFetch_Click" 
                            Text="Fetch" ValidationGroup="A">
                        </telerik:RadButton>
                        <telerik:RadButton ID="radReset" runat="server" onclick="radReset_Click" 
                            Text="Reset">
                        </telerik:RadButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <telerik:RadButton ID="radExcel" runat="server" onclick="radExcel_Click" 
                                Text="Excel">
                </telerik:RadButton>
                
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel2" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                
            </td>
        </tr>
        <tr>
            <td class="NormalText">
             
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" Visible="false" runat="server" Width="1000px" ScrollBars="Horizontal">
                           
                           
                            <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" 
                                GridLines="None" Width="1000px">
                                <mastertableview autogeneratecolumns="False" datakeynames="QuotationNo" 
                                    >
                                    <commanditemsettings exporttopdftext="Export to PDF" />
                                    <detailtables>
                                        <telerik:GridTableView runat="server" DataKeyNames="QuotationNo" 
                                            DataSourceID="SqlDataSource2">
                                            <parenttablerelation>
                                                <telerik:GridRelationFields DetailKeyField="QuotationNo" 
                                                    MasterKeyField="QuotationNo" />
                                            </parenttablerelation>
                                            <commanditemsettings exporttopdftext="Export to PDF" />
                                            <commanditemsettings exporttopdftext="Export to PDF" />
                                            <rowindicatorcolumn filtercontrolalttext="Filter RowIndicator column" 
                                                visible="True">
                                                <HeaderStyle Width="20px" />
                                            </rowindicatorcolumn>
                                            <expandcollapsecolumn filtercontrolalttext="Filter ExpandColumn column" 
                                                visible="True">
                                                <HeaderStyle Width="20px" />
                                            </expandcollapsecolumn>
                                            <editformsettings>
                                                <editcolumn filtercontrolalttext="Filter EditCommandColumn column">
                                                </editcolumn>
                                            </editformsettings>
                                            <PagerStyle PageSizeControlType="RadComboBox" />
                                        </telerik:GridTableView>
                                    </detailtables>
                                    <commanditemsettings exporttopdftext="Export to PDF" />
                                    <commanditemsettings exporttopdftext="Export to PDF" />
                                    <rowindicatorcolumn filtercontrolalttext="Filter RowIndicator column" 
                                        visible="True">
                                        <HeaderStyle Width="20px" />
                                    </rowindicatorcolumn>
                                    <expandcollapsecolumn filtercontrolalttext="Filter ExpandColumn column" 
                                        visible="True">
                                        <HeaderStyle Width="20px" />
                                    </expandcollapsecolumn>
                                    <Columns>
                                    <telerik:GridBoundColumn DataField="Plant" 
                                            FilterControlAltText="Filter QuotationNo column" HeaderText="Plant" 
                                            SortExpression="Plant" UniqueName="Plant">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Customer_Name" 
                                            FilterControlAltText="Filter Customer_Name column" HeaderText="Customer_Name" 
                                            SortExpression="Customer_Name" UniqueName="Customer_Name">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="QuotationNo" 
                                            FilterControlAltText="Filter QuotationNo column" HeaderText="QuotationNo" 
                                            SortExpression="QuotationNo" UniqueName="QuotationNo">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="QuotDate" 
                                            FilterControlAltText="Filter QuotationNo column" HeaderText="QuotationDt" 
                                            SortExpression="QuotDate" UniqueName="QuotDate">
                                        </telerik:GridBoundColumn>

                                          <telerik:GridBoundColumn DataField="OrderNo" 
                                            FilterControlAltText="Filter QuotationNo column" HeaderText="OrderNo" 
                                            SortExpression="OrderNo" UniqueName="OrderNo">
                                        </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="OrderDt" 
                                            FilterControlAltText="Filter QuotationNo column" HeaderText="OrderDt" 
                                            SortExpression="OrderDt" UniqueName="OrderDt">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="Shade" 
                                            FilterControlAltText="Filter Shade column" HeaderText="Shade" 
                                            SortExpression="Shade" UniqueName="Shade">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Item_Type" 
                                            FilterControlAltText="Filter Item_Type column" HeaderText="Item_Type" 
                                            SortExpression="Item_Type" UniqueName="Item_Type">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Item_Code" 
                                            FilterControlAltText="Filter Item_Code column" HeaderText="Item_Code" 
                                            SortExpression="Item_Code" UniqueName="Item_Code">
                                        </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="Blend" 
                                            FilterControlAltText="Filter Blend column" HeaderText="Blend" 
                                            SortExpression="Blend" UniqueName="Blend">
                                        </telerik:GridBoundColumn>
                                          <telerik:GridBoundColumn DataField="Epi" 
                                            FilterControlAltText="Filter Epi column" HeaderText="Epi" 
                                            SortExpression="Epi" UniqueName="Epi">
                                        </telerik:GridBoundColumn>
                                          <telerik:GridBoundColumn DataField="Ppi" 
                                            FilterControlAltText="Filter Ppi column" HeaderText="Ppi" 
                                            SortExpression="Ppi" UniqueName="Ppi">
                                        </telerik:GridBoundColumn>
                                          <telerik:GridBoundColumn DataField="gsm" 
                                            FilterControlAltText="Filter gsm column" HeaderText="GSM" 
                                            SortExpression="gsm" UniqueName="gsm">
                                        </telerik:GridBoundColumn>
                                          <telerik:GridBoundColumn DataField="Weave" 
                                            FilterControlAltText="Filter Weave column" HeaderText="Weave" 
                                            SortExpression="Weave" UniqueName="Weave">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Width" 
                                            FilterControlAltText="Filter Width column" HeaderText="Width" 
                                            SortExpression="Width" UniqueName="Width">
                                        </telerik:GridBoundColumn>

                                        
                                        <telerik:GridBoundColumn DataField="Warp" 
                                            FilterControlAltText="Filter Warp column" HeaderText="Warp" 
                                            SortExpression="Warp" UniqueName="Warp">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Weft" 
                                            FilterControlAltText="Filter Weft column" HeaderText="Weft" 
                                            SortExpression="Weft" UniqueName="Weft">
                                        </telerik:GridBoundColumn>
                             

                                             <telerik:GridBoundColumn DataField="Flag" 
                                            FilterControlAltText="Filter Item_Code column" HeaderText="Flag" 
                                            SortExpression="Flag" UniqueName="Flag">
                                        </telerik:GridBoundColumn>

                                          <telerik:GridBoundColumn DataField="Organic/Blend" 
                                            FilterControlAltText="Filter Item_Code column" HeaderText="Organic/Blend" 
                                            SortExpression="Organic/Blend" UniqueName="Organic/Blend">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="Quantity" DataType="System.Decimal" 
                                            FilterControlAltText="Filter Quantity column" HeaderText="Quantity" 
                                            SortExpression="Quantity" UniqueName="Quantity">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Uom" 
                                            FilterControlAltText="Filter Uom column" HeaderText="Uom" SortExpression="Uom" 
                                            UniqueName="Uom">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="DNV_Cost" DataType="System.Decimal" 
                                            FilterControlAltText="Filter DNV_Cost column" HeaderText="DNV_Cost" 
                                            SortExpression="DNV_Cost" UniqueName="DNV_Cost">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Mkt_DispatchDt" 
                                            FilterControlAltText="Filter Mkt_DispatchDt column" HeaderText="Mkt_DispatchDt" 
                                            ReadOnly="True" SortExpression="Mkt_DispatchDt" UniqueName="Mkt_DispatchDt">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ApprovedDeliveryDt" 
                                            FilterControlAltText="Filter ApprovedDeliveryDt column" 
                                            HeaderText="ApprovedDeliveryDt" ReadOnly="True" 
                                            SortExpression="ApprovedDeliveryDt" UniqueName="ApprovedDeliveryDt">
                                        </telerik:GridBoundColumn>


                                        <telerik:GridBoundColumn DataField="Approval_Status" 
                                            FilterControlAltText="Filter Approval_Status column" 
                                            HeaderText="Approval_Status" SortExpression="Approval_Status" 
                                            UniqueName="Approval_Status">
                                        </telerik:GridBoundColumn>



                                        <telerik:GridBoundColumn DataField="ActionDt" 
                                            FilterControlAltText="Filter QuotationNo column" HeaderText="ActionDt" 
                                            SortExpression="ActionDt" UniqueName="ActionDt">
                                        </telerik:GridBoundColumn>



                                        <telerik:GridBoundColumn DataField="ApprovedBy" 
                                            FilterControlAltText="Filter ApprovedBy column" HeaderText="ApprovedBy" 
                                            SortExpression="ApprovedBy" UniqueName="ApprovedBy">
                                        </telerik:GridBoundColumn>

                                          <telerik:GridBoundColumn DataField="LastApprovedDt" 
                                            FilterControlAltText="Filter LastApprovedDt column" HeaderText="LastApprovedDt" 
                                            SortExpression="LastApprovedDt" UniqueName="LastApprovedDt">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="LastAuthBy" 
                                            FilterControlAltText="Filter LastAuthBy column" HeaderText="LastAuthBy" 
                                            SortExpression="LastAuthBy" UniqueName="LastAuthBy">
                                        </telerik:GridBoundColumn>

                                           <telerik:GridBoundColumn DataField="HODStatus" 
                                            FilterControlAltText="Filter HODStatus column" HeaderText="HODStatus" 
                                            SortExpression="HODStatus" UniqueName="HODStatus">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="Sales_Person_Name" 
                                            FilterControlAltText="Filter Sales_Person_Name column" 
                                            HeaderText="Sales_Person_Name" SortExpression="Sales_Person_Name" 
                                            UniqueName="Sales_Person_Name">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <editformsettings>
                                        <editcolumn filtercontrolalttext="Filter EditCommandColumn column">
                                        </editcolumn>
                                    </editformsettings>
                                    <PagerStyle PageSizeControlType="RadComboBox" />
                                </mastertableview>
                                <PagerStyle PageSizeControlType="RadComboBox" />
                                <filtermenu enableimagesprites="False">
                                </filtermenu>
                            </telerik:RadGrid>
                        </asp:Panel>
                            
                      
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="radFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                
            </td>
        </tr>
    </table>
</asp:Content>

