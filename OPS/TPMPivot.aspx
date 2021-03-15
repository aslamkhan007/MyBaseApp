<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="TPMPivot.aspx.vb" Inherits="OPS_Pivot" %>

<%@ Register Assembly="Telerik.Web.UI, Version=2013.1.417.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4"
    Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadButton1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadDispatch" LoadingPanelID="gridLoadingPanel">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadDispatch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadDispatch" LoadingPanelID="gridLoadingPanel">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel runat="server" Skin="Telerik" ID="gridLoadingPanel">
    </telerik:RadAjaxLoadingPanel>
    <%-- <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"> --%>
    <table style="width: 100%;">
        <tr>
            <td style="height: 31px" colspan="6">
                &nbsp; Dispatch Detail&nbsp; &nbsp;
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 68px">
                Date From
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpFrom" runat="server" Culture="en-US" FocusedDate="2010-01-01"
                    Font-Names="Tahoma" MaxDate="2020-12-31">
                    <DateInput runat="server" DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                </telerik:RadDatePicker>
            </td>
            <td>
                Date To
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpTo" runat="server" Culture="en-US" FocusedDate="2010-01-01"
                    Font-Names="Tahoma">
                    <DateInput runat="server" DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" DisplayText="9/20/2013"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                </telerik:RadDatePicker>
                <telerik:RadButton ID="RadButton1" runat="server" Skin="Black" Text="Fetch">
                </telerik:RadButton>
            </td>
            <td class="BoundColumn_Date" style="width: 49px">
                &nbsp;
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 16px; width: 68px;">
            </td>
            <td style="height: 16px;">
                &nbsp;
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px; width: 170px;">
            </td>
            <td style="height: 16px; width: 49px;">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td colspan="6">
                &nbsp; &nbsp;
                <telerik:RadPivotGrid ID="RadDispatch" runat="server" AllowPaging="True" AllowSorting="True"
                    PageSize="500" ShowFilterHeaderZone="false" ShowDataHeaderZone="false" ShowRowHeaderZone="false"
                    ShowColumnHeaderZone="false" EnableConfigurationPanel="true" OnNeedDataSource="CallToBind"
                    Width="1200PX" Height="600" Skin="Default"  
                    >
                    <Fields>
                        <telerik:PivotGridRowField DataField="Name">
                        </telerik:PivotGridRowField>
                        <telerik:PivotGridRowField DataField="InvDate">
                        </telerik:PivotGridRowField>
                        <telerik:PivotGridAggregateField DataField="Qty" Aggregate="Sum">
                        </telerik:PivotGridAggregateField>
                        <telerik:PivotGridAggregateField DataField="Value" Aggregate="Sum">
                        </telerik:PivotGridAggregateField>

                        <telerik:PivotGridRowField DataField="ItemGroup"></telerik:PivotGridRowField>
                             <telerik:PivotGridRowField DataField="SalePerson"></telerik:PivotGridRowField>
                              <telerik:PivotGridRowField DataField="OrderNo"></telerik:PivotGridRowField>
                               <telerik:PivotGridRowField DataField="InvoiceNo"></telerik:PivotGridRowField>




                        <telerik:PivotGridReportFilterField DataField="Name"></telerik:PivotGridReportFilterField>
                         <telerik:PivotGridReportFilterField DataField="InvDate"></telerik:PivotGridReportFilterField>
                          <telerik:PivotGridReportFilterField DataField="Qty"></telerik:PivotGridReportFilterField>
                           <telerik:PivotGridReportFilterField DataField="Value"></telerik:PivotGridReportFilterField>
                            <telerik:PivotGridReportFilterField DataField="ItemGroup"></telerik:PivotGridReportFilterField>
                             <telerik:PivotGridReportFilterField DataField="SalePerson"></telerik:PivotGridReportFilterField>
                              <telerik:PivotGridReportFilterField DataField="OrderNo"></telerik:PivotGridReportFilterField>
                               <telerik:PivotGridReportFilterField DataField="InvoiceNo"></telerik:PivotGridReportFilterField>
                    </Fields>
                    <ConfigurationPanelSettings     Position="Left" DefaultDeferedLayoutUpdate="true" />
                    <PagerStyle Mode="Slider" AlwaysVisible="true"></PagerStyle>
                    <ClientSettings>
                        <Scrolling AllowVerticalScroll="True"  />
                    </ClientSettings>
                    <ConfigurationPanelSettings   EnableOlapTreeViewLoadOnDemand="True"></ConfigurationPanelSettings>

                  
                           
                            <DataCellStyle Width="100px" />
                            <ColumnHeaderCellStyle Width="100px" />
                            <RowHeaderCellStyle Width="350px" />


                </telerik:RadPivotGrid>
            </td>
        </tr>
        <tr>
            <td style="width: 68px" class="BoundColumn_long">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td style="width: 170px">
                &nbsp;
            </td>
            <td class="BoundColumn_Date" style="width: 49px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <%--  </telerik:RadAjaxPanel> --%>
    <telerik:RadButton ID="RadButton2" runat="server" Skin="Black" Text="Excel" Visible="false">
    </telerik:RadButton>
</asp:Content>
