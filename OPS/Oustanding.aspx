<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Oustanding.aspx.cs" Inherits="OPS_Oustanding" %>


 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table style="width:100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label16" runat="server" Text="Outstanding"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
   <telerik:RadButton ID="radExcel" runat="server" onclick="radExcel_Click" 
                                Text="Excel">
                            </telerik:RadButton>
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="True" 
                    AllowPaging="True" CellSpacing="0" DataSourceID="SqlDataSource1" 
                    GridLines="None">
                    <ClientSettings>
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    </ClientSettings>
<MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="Sale_Person" 
            FilterControlAltText="Filter Sale_Person column" HeaderText="Sale_Person" 
            SortExpression="Sale_Person" UniqueName="Sale_Person">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Column1" 
            FilterControlAltText="Filter Column1 column" HeaderText="Column1" 
            ReadOnly="True" SortExpression="Column1" UniqueName="Column1">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="0-30" DataType="System.Decimal" 
            FilterControlAltText="Filter 0-30 column" HeaderText="0-30" ReadOnly="True" 
            SortExpression="0-30" UniqueName="0-30">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="31-60" DataType="System.Decimal" 
            FilterControlAltText="Filter 31-60 column" HeaderText="31-60" ReadOnly="True" 
            SortExpression="31-60" UniqueName="31-60">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="61-90" DataType="System.Decimal" 
            FilterControlAltText="Filter 61-90 column" HeaderText="61-90" ReadOnly="True" 
            SortExpression="61-90" UniqueName="61-90">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="91-180" DataType="System.Decimal" 
            FilterControlAltText="Filter 91-180 column" HeaderText="91-180" ReadOnly="True" 
            SortExpression="91-180" UniqueName="91-180">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="181-365" DataType="System.Decimal" 
            FilterControlAltText="Filter 181-365 column" HeaderText="181-365" 
            ReadOnly="True" SortExpression="181-365" UniqueName="181-365">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="&gt;365" DataType="System.Decimal" 
            FilterControlAltText="Filter &gt;365 column" HeaderText="&gt;365" 
            ReadOnly="True" SortExpression="&gt;365" UniqueName="&gt;365">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Total" DataType="System.Decimal" 
            FilterControlAltText="Filter Total column" HeaderText="Total" ReadOnly="True" 
            SortExpression="Total" UniqueName="Total">
        </telerik:GridBoundColumn>
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
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_ops_EIS_outstanding" SelectCommandType="StoredProcedure">
                </asp:SqlDataSource>
            </td>
        </tr>
        </table>


</asp:Content>

