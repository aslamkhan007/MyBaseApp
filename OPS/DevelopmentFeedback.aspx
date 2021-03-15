<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="DevelopmentFeedback.aspx.cs" Inherits="OPS_DevelopmentFeedback" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
        <style type="text/css">
            .orderText
            {
                font: normal 12px Arial,Verdana;
                margin-top: 6px;
            }
        </style>
    </telerik:RadCodeBlock>

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowEditForm(id, rowIndex,lnk) {
                var grid = $find("<%= RadGrid1.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("EditDevelopmentFeedbackForm.aspx?link="+ lnk +"&RequestID=" + id, "UserListDialog");
                return false;
            }
            function ShowInsertForm() {
                window.radopen("EditDevelopmentFeedbackForm.aspx", "UserListDialog");
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
            function RowDblClick(sender, eventArgs) {
                window.radopen("EditDevelopmentFeedbackForm.aspx?link=" + lnk + "&RequestID=" + eventArgs.getDataKeyValue("RequestID"), "UserListDialog");
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
            <td class="tableheader">
                <asp:Label ID="Label16" runat="server" Text="Development Feedback"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
       
    <telerik:RadGrid OnItemCreated="RadGrid1_ItemCreated" ID="RadGrid1" runat="server"
        AllowPaging="True" Width="97%" onneeddatasource="RadGrid1_NeedDataSource" AllowFilteringByColumn="true"
                    AllowSorting="True" CellSpacing="0" GridLines="None"  
                    onprerender="RadGrid1_PreRender" onitemdatabound="RadGrid1_ItemDataBound">
        <PagerStyle Mode="NumericPages"></PagerStyle>
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="RequestID" ClientDataKeyNames="RequestID"
            Width="100%" CommandItemDisplay="Top" PageSize="5">
<CommandItemSettings ExportToPdfText="Export to PDF" AddNewRecordText="" RefreshText="" 
                ShowAddNewRecordButton="False" ShowRefreshButton="False"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>
            
                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column"  AllowFiltering="false"
                    UniqueName="TemplateColumn" DataField="img">
                    <ItemTemplate>
                    <asp:Image ID="img_Ok" runat="server" ImageUrl='<%# Eval("img") %>'  /> 
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
             
                <telerik:GridBoundColumn DataField="RequestID"  HeaderText="RequestID" ReadOnly="True"   FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="EqualTo"
                    FilterDelay="2000" ShowFilterIcon="true"
                    SortExpression="RequestID" UniqueName="RequestID">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="RequestedBy" HeaderText="RequestedBy" SortExpression="RequestedBy"
                    UniqueName="RequestedBy" FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="EqualTo"
                    FilterDelay="2000" ShowFilterIcon="true" >
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DESCRIPTION" HeaderText="DESCRIPTION" SortExpression="DESCRIPTION"  ShowFilterIcon="false" AllowFiltering="false"
                    UniqueName="DESCRIPTION">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Devlopment" HeaderText="Development" SortExpression="Devlopment"  ShowFilterIcon="false" AllowFiltering="false"
                    UniqueName="Devlopment">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="SortNo" HeaderText="SortNo" SortExpression="SortNo" FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="EqualTo"
                    FilterDelay="2000" ShowFilterIcon="true"
                    UniqueName="SortNo">
                </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="Req_Mtrs" HeaderText="Req_Mtrs" SortExpression="Req_Mtrs" ShowFilterIcon="false" AllowFiltering="false"
                    UniqueName="Req_Mtrs">
                </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="Finish" HeaderText="Finish" SortExpression="Finish"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="EqualTo"
                    FilterDelay="2000" ShowFilterIcon="true"
                    UniqueName="Finish">
                </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="no_of_shades" HeaderText="no_of_shades" SortExpression="no_of_shades"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="EqualTo"
                    FilterDelay="2000" ShowFilterIcon="true"
                    UniqueName="no_of_shades">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Segment" HeaderText="Segment" SortExpression="Segment"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="EqualTo"
                    FilterDelay="2000" ShowFilterIcon="true"
                    UniqueName="Segment">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn UniqueName="TemplateEditColumn"  AllowFiltering="false">
                    <ItemTemplate>
                        <asp:HyperLink ID="EditLink" runat="server" Text="Feedback"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="TemplateEditColumn"  AllowFiltering="false">
                    <ItemTemplate>
                        <asp:HyperLink ID="EditTaskStatus" runat="server" Text="Task Status" Visible="false"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
           
<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
           
            <CommandItemTemplate>
                <asp:CheckBox ID="chb_AllRequest" runat="server" AutoPostBack="True" 
                    oncheckedchanged="chb_AllRequest_CheckedChanged" Text="Show All Requests" />
            </CommandItemTemplate>
           
        </MasterTableView>
        <ClientSettings>
            <Selecting AllowRowSelect="true"></Selecting>
            <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
        </ClientSettings>

<FilterMenu EnableImageSprites="False"></FilterMenu>
    </telerik:RadGrid>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="UserListDialog" runat="server" Title="Development Request Feedback" Height="400px"
                Width="500px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
             
 
             </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

