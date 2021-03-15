<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="ODS_Sort_Rate_Master.aspx.vb" Inherits="OPS_ODS_Sort_Rate_Master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Sort Rate Master</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" 
                    DataSourceID="SqlDataSource1" GridLines="None" Skin="WebBlue">
                    <ClientSettings>
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    </ClientSettings>
<MasterTableView datasourceid="SqlDataSource1">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridAttachmentColumn DataSourceID="ITEM" DataTextField="ITEM" 
            FileName="attachment" FilterControlAltText="Filter column column" 
            HeaderText="ITEM" UniqueName="column">
        </telerik:GridAttachmentColumn>
        <telerik:GridAttachmentColumn DataSourceID="Variant" DataTextField="Variant" 
            FileName="attachment" FilterControlAltText="Filter column1 column" 
            HeaderText="Variant" UniqueName="column1">
        </telerik:GridAttachmentColumn>
        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
            HeaderText="New Rate" UniqueName="TemplateColumn">
            <ItemTemplate>
                <telerik:RadTextBox ID="radNewRate" Runat="server" 
                    SelectionOnFocus="CaretToEnd">
                </telerik:RadTextBox>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridAttachmentColumn FileName="attachment" 
            FilterControlAltText="Filter column4 column" HeaderText="Remarks" 
            UniqueName="column4">
        </telerik:GridAttachmentColumn>
        <telerik:GridAttachmentColumn DataSourceID="LastRate" DataTextField="LastRate" 
            FileName="attachment" FilterControlAltText="Filter column2 column" 
            HeaderText="LastRate" UniqueName="column2">
        </telerik:GridAttachmentColumn>
        <telerik:GridAttachmentColumn DataSourceID="LastUpdatedOn" 
            DataTextField="LastUpdatedOn" FileName="attachment" 
            FilterControlAltText="Filter column3 column" HeaderText="LastUpdatedOn" 
            UniqueName="column3">
        </telerik:GridAttachmentColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
</MasterTableView>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
                </telerik:RadGrid>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:productionConnectionString1 %>" 
                    SelectCommand="exec Jct_Ops_ODS_Item_Fetch"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                 &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                 &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                 &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                 &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                Valid From
            </td>
            <td>
                 <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDateFrom"
                    Display="Dynamic" ErrorMessage="**"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                Valid UpTo
            </td>
            <td>
                <asp:TextBox ID="txtdateto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:calendarextender ID="txtdateto_CalendarExtender" runat="server" 
                    TargetControlID="txtdateto">
                </cc1:calendarextender>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="cmdApply" runat="server" BorderStyle="None" 
                            CssClass="buttonc">Apply</asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" BorderStyle="None" 
                            CssClass="buttonc">Clear</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>

