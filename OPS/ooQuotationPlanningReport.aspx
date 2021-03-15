<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="QuotationPlanningReport.aspx.cs" Inherits="OPS_QuotationPlanningReport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader">
                
                <asp:Label ID="Label16" runat="server" Text="Quotation Authorized by Planning"></asp:Label>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="JCT_OPS_QUOTATION_PLANNING_REPORT" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtDateFrom" Name="DateFrom" 
                            PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="txtDateTo" Name="DateTo" PropertyName="Text" 
                            Type="String" />
                        <asp:ControlParameter ControlID="txtQuotDateFrom" Name="QuotationDtFrom" 
                            PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="txtQuotDateTo" Name="QuotationDtTo" 
                            PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="txtQuotationNo" Name="QuotationNo" 
                            PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="txtOrderNo" Name="OrderNo" PropertyName="Text" 
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
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
            <td class="NormalText" style="width: 131px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
                
            </td>
            <td class="NormalText" style="width: 184px">
                <asp:Label ID="Label18" runat="server" Text="Advised Dispatch Date To"></asp:Label>
                
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
                
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 178px">
                Quotation Date From</td>
            <td class="NormalText" style="width: 131px">
                <asp:TextBox ID="txtQuotDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtQuotDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtQuotDateFrom">
                </cc1:CalendarExtender>
                
            </td>
            <td class="NormalText" style="width: 184px">
                Quotation Date To</td>
            <td class="NormalText">
                <asp:TextBox ID="txtQuotDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtQuotDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtQuotDateTo">
                </cc1:CalendarExtender>
                
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 178px">
                Quotation No</td>
            <td class="NormalText" style="width: 131px">
                <asp:TextBox ID="txtQuotationNo" runat="server" CssClass="textbox"></asp:TextBox>
                
            </td>
            <td class="NormalText" style="width: 184px">
                Order No</td>
            <td class="NormalText">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
                
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
             
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" Visible="false" runat="server" Width="1000px" ScrollBars="Horizontal">
                           
                           
                            <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="True" 
                                AllowPaging="True" AllowSorting="True" CellSpacing="0" 
                                DataSourceID="SqlDataSource1" GridLines="None">
                                <mastertableview autogeneratecolumns="False" datakeynames="QuotationNo" 
                                    datasourceid="SqlDataSource1">
                                    <commanditemsettings exporttopdftext="Export to PDF" />
                                    <detailtables>
                                        <telerik:GridTableView runat="server" AllowFilteringByColumn="False" 
                                            AllowSorting="False" DataKeyNames="QuotationNo" DataSourceID="SqlDataSource2">
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
                                        <telerik:GridBoundColumn DataField="Customer_Name" 
                                            FilterControlAltText="Filter Customer_Name column" HeaderText="Customer_Name" 
                                            SortExpression="Customer_Name" UniqueName="Customer_Name">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="QuotationNo" 
                                            FilterControlAltText="Filter QuotationNo column" HeaderText="QuotationNo" 
                                            SortExpression="QuotationNo" UniqueName="QuotationNo">
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
                                        <telerik:GridBoundColumn DataField="ApprovedBy" 
                                            FilterControlAltText="Filter ApprovedBy column" HeaderText="ApprovedBy" 
                                            SortExpression="ApprovedBy" UniqueName="ApprovedBy">
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

