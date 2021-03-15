<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="CODCashCollection.aspx.cs" Inherits="Courier_Tracking_System_CODCashCollection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

        <script type="text/javascript">

            function PopUp() {

                var from = document.getElementById('<%=radDateFrom.ClientID %>').value;

                var to = document.getElementById('<%=radDateTo.ClientID %>').value;

                var awbno = document.getElementById('<%=radAwbNo.ClientID %>').value;

                window.radopen("CourierCODPreviewMail.aspx?from=" + from + "&to=" + to + " &awbno="+ awbno, "UserListDialog");
                return false;
            }

        
            function ShowInsertForm(id, rowIndex) {

                var grid = $find("<%= radgrdCheckDetail.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("AddCheckDetails.aspx?AWBNo=" + id, "UserListDialog");
                return false;
            }
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
           
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>



    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="COD Cash Collection"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 120px">
                <asp:Label ID="Label19" runat="server" Text="Date From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 149px">
                <telerik:RadDatePicker ID="radDateFrom" Runat="server" Culture="en-US" 
                    ShowPopupOnFocus="True" Width="100px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="64px" Width="100px"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td class="NormalText" style="width: 63px">
                <asp:Label ID="Label20" runat="server" Text="Date To"></asp:Label>
            </td>
            <td class="NormalText">
                <telerik:RadDatePicker ID="radDateTo" Runat="server" Culture="en-US" 
                    ShowPopupOnFocus="True" Width="100px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="64px" Width="100px"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 120px">
                <asp:Label ID="Label18" runat="server" Text="AWB No."></asp:Label>
            </td>
            <td class="NormalText" style="width: 149px">
                <telerik:RadTextBox ID="radAwbNo" Runat="server" Width="100px">
                </telerik:RadTextBox>
            </td>
            <td class="NormalText" style="width: 63px">
                &nbsp;</td>
            <td class="NormalText">
                <asp:HiddenField ID="hdfCarrierName" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 120px">
                <asp:Label ID="Label22" runat="server" Text="Invoice No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 149px">
                <telerik:RadTextBox ID="radtxtInvoiceNo" Runat="server" Width="150px">
                </telerik:RadTextBox>
            </td>
            <td class="NormalText" style="width: 63px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 120px">
                <asp:Label ID="Label21" runat="server" Text="Carrier"></asp:Label>
            </td>
            <td class="NormalText" style="width: 149px">
                
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                
                  <telerik:RadComboBox ID="RadComboBox1" Runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="crr_name" 
                    DataValueField="crr_no" AutoPostBack="True" 
                        onselectedindexchanged="RadComboBox1_SelectedIndexChanged">
                </telerik:RadComboBox>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand=" Select '' crr_no,'' crr_name union SELECT	crr_no,crr_name FROM miserp.shp.dbo.dms_m_carrier_hdr WHERE status='O'">
                </asp:SqlDataSource>
                 
                
                </ContentTemplate>
                </asp:UpdatePanel>
              
                
            </td>
            <td class="NormalText" style="width: 63px">
                &nbsp;</td>
            <td class="NormalText">
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="JCT_COURIER_COD_INVOICE_DETAILS" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radAwbNo" Name="AWBNO" PropertyName="Text" 
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="JCT_COURIER_COD_CASH_COLLECTION_SELECT" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radAwbNo" Name="AWBNO" PropertyName="Text" 
                            Type="String" />
                        <asp:ControlParameter ControlID="radDateFrom" Name="DATEFROM" 
                            PropertyName="SelectedDate" Type="String" />
                        <asp:ControlParameter ControlID="radDateTo" Name="DATETO" 
                            PropertyName="SelectedDate" Type="String" />
                        <asp:ControlParameter ControlID="RadComboBox1" Name="CARRIER" 
                            PropertyName="SelectedValue" Type="String" />
                      
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <telerik:RadButton ID="radbtnFetch" runat="server" onclick="radbtnFetch_Click" 
                            Text="Fetch">
                        </telerik:RadButton>
                        <telerik:RadButton ID="radbtnSave" runat="server" Text="Save"  SingleClick="true" SingleClickText="Saving..." 
                            onclick="radbtnSave_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="radbtnReset" runat="server" Text="Reset">
                        </telerik:RadButton>
                        <telerik:RadButton ID="radbtnMail" runat="server" onclick="radbtnMail_Click" 
                            Text="Preview Mail">
                        </telerik:RadButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="radgrdCheckDetail" runat="server" CellSpacing="0" GridLines="None" 
                            onitemdatabound="radgrdCheckDetail_ItemDataBound" AllowPaging="True" 
                            onneeddatasource="radgrdCheckDetail_NeedDataSource" 
                            onpageindexchanged="radgrdCheckDetail_PageIndexChanged" 
                            onitemcreated="radgrdCheckDetail_ItemCreated">
                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="AWBNo,AWBNo">
                                <DetailTables>
                                    <telerik:GridTableView runat="server" DataKeyNames="AWBNo" 
                                        DataSourceID="SqlDataSource2">
                                        <ParentTableRelation>
                                            <telerik:GridRelationFields DetailKeyField="AWBNo" MasterKeyField="AWBNo" />
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
                                    <telerik:GridTemplateColumn FilterControlAltText="Filter SelectCheckBox column" 
                                        UniqueName="SelectCheckBox">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbSelect" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10px" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="InvoiceNo" 
                                        FilterControlAltText="Filter InvoiceNo column" HeaderText="InvoiceNo" 
                                        SortExpression="InvoiceNo" UniqueName="InvoiceNo">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="AWBNo" 
                                        FilterControlAltText="Filter AWBNo column" HeaderText="AWBNo" 
                                        SortExpression="AWBNo" UniqueName="AWBNo">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Carrier" 
                                        FilterControlAltText="Filter Carrier column" HeaderText="Carrier" 
                                        UniqueName="Carrier">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Delivery" 
                                        FilterControlAltText="Filter Delivery column" HeaderText="Delivery" 
                                        UniqueName="Delivery">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Date" 
                                        FilterControlAltText="Filter Date column" HeaderText="Date" ReadOnly="True" 
                                        SortExpression="Date" UniqueName="Date">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="ChequeNo" 
                                        FilterControlAltText="Filter ChequeNo column" HeaderText="ChequeNo" 
                                        UniqueName="ChequeNo">
                                        <ItemTemplate>
                                            <telerik:RadTextBox ID="radtxtChequeNo" Runat="server" Width="100px" 
                                                LabelWidth="40px" Text='<%# Eval("ChequeNo") %>'>
                                            </telerik:RadTextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="ChequeAmt" 
                                        FilterControlAltText="Filter ChequeAmt column" HeaderText="ChequeAmt" 
                                        UniqueName="CheckAmt">
                                        <ItemTemplate>
                                            <telerik:RadTextBox ID="radtxtChequeAmount" Runat="server" Width="100px" 
                                                LabelWidth="40px" Text='<%# Eval("ChequeAmt") %>'>
                                            </telerik:RadTextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="ChequeDate" 
                                        FilterControlAltText="Filter ChequeDate column" HeaderText="ChequeDate" 
                                        UniqueName="ChequeDate">
                                        <ItemTemplate>
                                            <telerik:RadDatePicker ID="raddtpckrChequeDate" Runat="server" Culture="en-US" 
                                                ShowPopupOnFocus="True" Width="100px" 
                                                DbSelectedDate='<%# Eval("ChequeDate") %>'>
                                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                </Calendar>
                                                <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" LabelWidth="40px" 
                                                    Width="100px">
                                                </DateInput>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" Visible="False" />
                                            </telerik:RadDatePicker>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="60px" />
                                    </telerik:GridTemplateColumn>
                                  
                                    <telerik:GridTemplateColumn FilterControlAltText="Filter AddMoreCheques column" 
                                        UniqueName="AddMoreCheques">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlkAddMoreCheques" runat="server">Add More Cheques</asp:HyperLink>
                                            
                                           
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                                <PagerStyle PageSizeControlType="RadComboBox" />
                                <CommandItemTemplate>
                                      <a href="#" onclick="return ShowInsertForm();">Add New Record</a>
                                </CommandItemTemplate>
                            </MasterTableView>
                            <PagerStyle PageSizeControlType="RadComboBox" />
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 120px">
                &nbsp;</td>
            <td class="NormalText" style="width: 149px">
                &nbsp;</td>
            <td class="NormalText" style="width: 63px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="UserListDialog" runat="server" Title="Add More Checks" Height="500px"
                Width="500px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

</asp:Content>

