<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="QuotationProfitLoss.aspx.cs" Inherits="OPS_QuotationProfitLoss" %>

 
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Quotation Level Profit(%)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 128px">
                <asp:Label ID="Label17" runat="server" Text="QuotationDt From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 109px">
                <telerik:RadDatePicker ID="radQuotDateFrom" Runat="server" Culture="en-US" 
                    ShowPopupOnFocus="True" Width="100px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40px" Width="100px"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td class="NormalText" style="width: 121px">
                <asp:Label ID="Label18" runat="server" Text="QuotationDt To"></asp:Label>
            </td>
            <td class="NormalText">
                <telerik:RadDatePicker ID="radQuotDateTo" Runat="server" Culture="en-US" 
                    ShowPopupOnFocus="True" Width="100px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40px" Width="100px"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 128px">
                <asp:Label ID="Label19" runat="server" Text="Quotation No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 109px">
                <telerik:RadTextBox ID="radQuotationNo" Runat="server" Width="100px">
                </telerik:RadTextBox>
            </td>
            <td class="NormalText" style="width: 121px">
                <asp:Label ID="Label20" runat="server" Text="Quotation Status"></asp:Label>
            </td>
            <td class="NormalText">
                <telerik:RadDropDownList ID="radQuotationStatus" runat="server" 
                    SelectedText=" " Width="100px">
                    <Items>
                        <telerik:DropDownListItem runat="server" Selected="True" Text=" " />
                        <telerik:DropDownListItem runat="server" Text="QuotOpen" Value="QuotOpen" />
                        <telerik:DropDownListItem runat="server" Text="QuotAuth" Value="QuotAuth" />
                        <telerik:DropDownListItem runat="server" Text="QuotAuthLM" Value="QuotAuthLM" />
                    </Items>
                </telerik:RadDropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 128px">
                <asp:Label ID="Label22" runat="server" Text="Sale Team"></asp:Label>
            </td>
            <td class="NormalText" style="width: 109px">
              
               
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                
                  <telerik:RadComboBox ID="radSaleTeam" Runat="server"  AutoPostBack="true" CheckBoxes="True"  EnableCheckAllItemsCheckBox="true"
                    DataSourceID="SqlDataSource4" DataTextField="team_description" 
                    DataValueField="team_code" 
                        onselectedindexchanged="radSaleTeam_SelectedIndexChanged">
                </telerik:RadComboBox>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="Select '' as team_code,'' as team_description Union SELECT team_code,team_description FROM MISERP.SOM.DBO.jct_team_mASter where team_code not in ('Wardrobe','Domestic','Sales Team')  ORDER BY team_code   ">
                </asp:SqlDataSource>

                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 121px">
                <asp:Label ID="Label21" runat="server" Text="Sale Person"></asp:Label>
            </td>
            <td class="NormalText">
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                     <ContentTemplate>
                         <telerik:RadComboBox ID="radSalePerson" Runat="server"  CheckBoxes="True"  EnableCheckAllItemsCheckBox="true"
                    DataSourceID="SqlDataSource3" 
    DataTextField="group_desc" DataValueField="sale_person_code">
                         </telerik:RadComboBox>
                         <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand=" Select '' as sale_person_code,'' as group_desc union
SELECT DISTINCT
        a.sale_person_code ,
        UPPER(b.group_desc) AS group_desc
FROM    MISERP.SOM.DBO.jct_team_saleperson_mapping a
        INNER JOIN miserp.som.dbo.m_cust_group b ON b.group_no = a.sale_person_code
        INNER JOIN dbo.JCT_EmpMast_Base C ON A.sale_person_code=REPLACE(C.empcode,'-','') AND C.Active='Y'
WHERE   a.status = 'O'
        AND group_type = 'SalesP'
        AND team_code NOT IN ( 'Wardrobe', 'Domestic', 'Sales Team' )
        AND (team_code = @TeamCode OR ''='')
        ORDER BY group_desc">
                             <SelectParameters>
                                 <asp:ControlParameter ControlID="radSaleTeam" 
                            DefaultValue=" " Name="TeamCode" PropertyName="SelectedValue" />
                             </SelectParameters>
                         </asp:SqlDataSource>
                     </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="radSaleTeam" 
                             EventName="SelectedIndexChanged" />
                     </Triggers>
                 </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 128px">
                <asp:Label ID="Label23" runat="server" Text="OrderNo"></asp:Label>
            </td>
            <td class="NormalText" style="width: 109px">
              
               
                <telerik:RadTextBox ID="radtxtOrderNo" Runat="server" Width="100px">
                </telerik:RadTextBox>
            </td>
              <td class="NormalText" style="width: 121px">
                <asp:Label ID="Label24" runat="server" Text="Plant"></asp:Label>
            </td>
            <td class="NormalText">
                <telerik:RadDropDownList ID="radDDLPlant" runat="server" Skin="Default" 
                    Width="126px">
                    <Items>
                        <telerik:DropDownListItem runat="server" Selected="True" />
                        <telerik:DropDownListItem runat="server" Text="COTTON" />
                        <telerik:DropDownListItem runat="server" Text="TAFFETA" />
                    </Items>
                </telerik:RadDropDownList>
                
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" 
                    RenderMode="Inline" >
                    <ContentTemplate>
                        <telerik:RadButton ID="radFetch" runat="server" onclick="radFetch_Click" 
                            Text="Fetch">
                        </telerik:RadButton>
                      
                        <telerik:RadButton ID="radReset" runat="server" Text="Reset">
                        </telerik:RadButton>
                    </ContentTemplate>
                    
                </asp:UpdatePanel>
                  <telerik:RadButton ID="radExcel" runat="server" Text="Excel" 
                    onclick="radExcel_Click1">
                        </telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" 
                            CellSpacing="0" GridLines="None" onitemdatabound="RadGrid1_ItemDataBound" 
                            onneeddatasource="RadGrid1_NeedDataSource" ShowFooter="True" 
                            ShowGroupPanel="True">
                            <GroupingSettings ShowUnGroupButton="True" />
                            <ClientSettings AllowDragToGroup="True">
                            </ClientSettings>
                            <MasterTableView AllowSorting="False" AutoGenerateColumns="False" 
                                DataKeyNames="QuotationNo" DataMember="Master"  ShowFooter="True" ShowGroupFooter="true" >
                                <DetailTables>
                                    <telerik:GridTableView runat="server" AllowSorting="False" 
                                        DataKeyNames="QuotationNo" DataSourceID="SqlDataSource2">
                                        <ParentTableRelation>
                                            <telerik:GridRelationFields DetailKeyField="QuotationNo" 
                                                MasterKeyField="QuotationNo" />
                                        </ParentTableRelation>
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                            Visible="True">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                            Visible="True">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                        <PagerStyle PageSizeControlType="RadComboBox" />
                                    </telerik:GridTableView>
                                </DetailTables>
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                    Visible="True">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                    Visible="True">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn Aggregate="CountDistinct" DataField="Customer" 
                                        FilterControlAltText="Filter Customer column" HeaderText="Customer" 
                                        SortExpression="Customer" UniqueName="Customer">
                                    </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn   DataField="SaleTeam" 
                                        FilterControlAltText="Filter SaleTeam column" HeaderText="SaleTeam" 
                                        SortExpression="SaleTeam" UniqueName="SaleTeam">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn Aggregate="CountDistinct" DataField="SalePerson" 
                                        FilterControlAltText="Filter SalePerson column" HeaderText="SalePerson" 
                                        SortExpression="SalePerson" UniqueName="SalePerson">
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn Aggregate="Count" DataField="QuotationNo" 
                                        FilterControlAltText="Filter QuotationNo column" HeaderText="QuotationNo" 
                                        SortExpression="QuotationNo" UniqueName="QuotationNo">
                                    </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn Aggregate="Count" DataField="OrderNo" 
                                        FilterControlAltText="Filter OrderNo column" HeaderText="OrderNo" 
                                        SortExpression="OrderNo" UniqueName="OrderNo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ItemType" 
                                        FilterControlAltText="Filter ItemType column" HeaderText="ItemType" 
                                        SortExpression="ItemType" UniqueName="ItemType">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ItemCode" 
                                        FilterControlAltText="Filter ItemCode column" HeaderText="ItemCode" 
                                        SortExpression="ItemCode" UniqueName="ItemCode">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Quantity" Aggregate="Sum"
                                        FilterControlAltText="Filter Quantity column" HeaderText="Quantity" 
                                        SortExpression="Quantity" UniqueName="Quantity">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn Aggregate="Avg" DataField="DnvCost" FooterAggregateFormatString="{0:F2}"
                                        DataType="System.Decimal" FilterControlAltText="Filter DnvCost column" 
                                        HeaderText="DnvCost" SortExpression="DnvCost" UniqueName="DnvCost">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn Aggregate="Avg" DataField="SalePrice" FooterAggregateFormatString="{0:F2}"
                                        DataType="System.Decimal" FilterControlAltText="Filter SalePrice column" 
                                        HeaderText="SalePrice" SortExpression="SalePrice" UniqueName="SalePrice">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="MarginPerc" DataType="System.Decimal"  
                                        FilterControlAltText="Filter MarginPerc column" HeaderText="MarginPerc" 
                                        SortExpression="MarginPerc" UniqueName="MarginPerc">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn   DataField="ThereticalMargin" 
                                        DataType="System.Decimal" FilterControlAltText="Filter ThereticalMargin column" 
                                        HeaderText="ThereticalMargin" SortExpression="ThereticalMargin" 
                                        UniqueName="ThereticalMargin">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Status" 
                                        FilterControlAltText="Filter Status column" HeaderText="Status" 
                                        SortExpression="Status" UniqueName="Status">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotationDt" DataType="System.DateTime" 
                                        FilterControlAltText="Filter QuotationDt column" HeaderText="QuotationDt" 
                                        SortExpression="QuotationDt" UniqueName="QuotationDt">
                                    </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="ApprovalDt"  
                                        FilterControlAltText="Filter ApprovalDt column" HeaderText="Approval Dt" 
                                        SortExpression="ApprovalDt" UniqueName="ApprovalDt">
                                    </telerik:GridBoundColumn>

                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                                <PagerStyle PageSizeControlType="RadComboBox" />
                            </MasterTableView>
                            <PagerStyle PageSizeControlType="RadComboBox" />
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="radFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="JCT_OPS_QUOTATION_PPL_REPORT" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radQuotDateFrom" Name="QuotDateFrom" 
                            PropertyName="SelectedDate" Type="DateTime" />
                        <asp:ControlParameter ControlID="radQuotDateTo" Name="QuotDateTo" 
                            PropertyName="SelectedDate" Type="DateTime" />
                        <asp:ControlParameter ControlID="radQuotationNo" Name="QuotationNo" 
                            PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="radQuotationStatus" Name="Status" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="JCT_OPS_QUOTATION_PPL_REPORT_DETAIL" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="QuotationNo" SessionField="QuotationNo" 
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

