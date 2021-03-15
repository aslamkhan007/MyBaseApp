<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="MontlyCollectionsAdjustments.aspx.vb" Inherits="OPS_MontlyCollectionsAdjustments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Invoice Collections and Adjustments *</td>
        </tr>
        <tr>
            <td class="labelcells">
                From</td>
            <td>
                <asp:DropDownList ID="ddlDateFrom" runat="server" CssClass="combobox">
                    <asp:ListItem Value="2012-04-01">APR 2012</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                To
            </td>
            <td>
                <asp:DropDownList ID="ddlDateTo" runat="server" CssClass="combobox">
                    <asp:ListItem Selected="True" Value="2013-03-31">MAR 2013</asp:ListItem>
                    <asp:ListItem Value="2013-02-28">FEB 2013</asp:ListItem>
                    <asp:ListItem Value="2013-01-31">JAN 2013</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant</td>
            <td>
                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox" Enabled="False">
                    <asp:ListItem Value="C">Cotton</asp:ListItem>
                    <asp:ListItem Value="T">Taffeta</asp:ListItem>
                    <asp:ListItem Value="O" Selected="True">Both</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                * Not for Export Invoices</td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:LinkButton ID="cmdView" runat="server" CssClass="buttonc">View</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grdCollection" runat="server" EmptyDataText="No Records found for the given period."
                            EnableModelValidation="True" AutoGenerateColumns="False" Caption="Collections and Adjustments"
                            CaptionAlign="Left" Font-Bold="True" Font-Size="9pt">
                            <RowStyle CssClass="GridItem" />
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:BoundField DataField="MonthYear" HeaderText="MonthYear" ReadOnly="True" SortExpression="MonthYear" />
                                <asp:BoundField DataField="Invoiced_Amount" HeaderText="Invoiced_Amount" ReadOnly="True"
                                    SortExpression="Invoiced_Amount" />
                                <asp:BoundField DataField="Collection_Amount" HeaderText="Collection_Amount" ReadOnly="True"
                                    SortExpression="Collection_Amount" />
                                <asp:BoundField DataField="Adjustments" HeaderText="Adjustments" ReadOnly="True"
                                    SortExpression="Adjustments" />
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="jct_ops_invoice_collection_adjustments" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlPlant" Name="Plant" PropertyName="SelectedValue"
                                    Type="String" />
                                <asp:ControlParameter ControlID="ddlDateFrom" Name="FromDt" PropertyName="SelectedValue"
                                    Type="DateTime" />
                                <asp:ControlParameter ControlID="ddlDateTo" Name="ToDt" PropertyName="SelectedValue"
                                    Type="DateTime" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmdView" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                Daily Collection</td>
        </tr>
        <tr>
            <td>
                <div id="AdjResultsDiv" style="width: 900px; height: 300px;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="grdDailyCollection" runat="server" CaptionAlign="Left" EmptyDataText="No Records found for the given period."
                                EnableModelValidation="True" Font-Bold="True" Font-Size="9pt">
                                <RowStyle CssClass="GridItem" />
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:jctgenConnectionString %>"
                                SelectCommand="jct_ops_invoice_collection_daily" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlPlant" DefaultValue=" " Name="Plant" PropertyName="SelectedValue"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="ddlDateFrom" DefaultValue="" Name="FromDt" PropertyName="SelectedValue"
                                        Type="DateTime" />
                                    <asp:ControlParameter ControlID="ddlDateTo" Name="ToDt" PropertyName="SelectedValue"
                                        Type="DateTime" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmdView" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                Daily Invoicing
            </td>
        </tr>
        <tr>
            <td>
                <div style="width: 900px; height: 300px; overflow: scroll;" id="AdjResultsDiv1">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="grdDailyInvoicing" runat="server" CaptionAlign="Left" EmptyDataText="No Records found for the given period."
                                EnableModelValidation="True" Font-Bold="True" Font-Size="9pt">
                                <RowStyle CssClass="GridItem" />
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:jctgenConnectionString %>"
                                SelectCommand="jct_ops_invoice_issue_daily" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlPlant" DefaultValue=" " Name="Plant" PropertyName="SelectedValue"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="ddlDateFrom" DefaultValue="" Name="FromDt" PropertyName="SelectedValue"
                                        Type="DateTime" />
                                    <asp:ControlParameter ControlID="ddlDateTo" Name="ToDt" PropertyName="SelectedValue"
                                        Type="DateTime" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmdView" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                Adjustment Detail</td>
        </tr>
        <tr>
            <td>
                <div style="width: 900px; height: 300px; overflow: scroll;" id="AdjResultsDiv2">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="grdAdjustmentDetail" runat="server" CaptionAlign="Left" EmptyDataText="No Records found for the given period."
                                EnableModelValidation="True" Font-Bold="True" Font-Size="9pt" Width="100%">
                                <RowStyle CssClass="GridItem" />
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:jctgenConnectionString %>"
                                SelectCommand="jct_ops_invoice_collection_adjustments_detail" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlPlant" DefaultValue=" " Name="Plant" PropertyName="SelectedValue"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="ddlDateFrom" DefaultValue="" Name="FromDt" PropertyName="SelectedValue"
                                        Type="DateTime" />
                                    <asp:ControlParameter ControlID="ddlDateTo" Name="ToDt" PropertyName="SelectedValue"
                                        Type="DateTime" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmdView" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                Invoice Ageing Against Receipts 
                ( Figures In Lacs)</td>
        </tr>
        <tr>
            <td>
                <div style="width: 900px; height: 500px; overflow: scroll;" id="AdjResultsDiv3">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="grdInvoiceAgeing" runat="server" CaptionAlign="Left" EmptyDataText="No Records found for the given period."
                                EnableModelValidation="True" Font-Bold="True" Font-Size="9pt">
                                <RowStyle CssClass="GridItem" />
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:jctgenConnectionString %>"
                                SelectCommand="jct_ops_invoice_collection_ageing" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlPlant" DefaultValue=" " Name="Plant" PropertyName="SelectedValue"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="ddlDateFrom" DefaultValue="" Name="FromDt" PropertyName="SelectedValue"
                                        Type="DateTime" />
                                    <asp:ControlParameter ControlID="ddlDateTo" Name="ToDt" PropertyName="SelectedValue"
                                        Type="DateTime" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmdView" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        </table>
    <table style="width: 100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt" colspan="4">
                &nbsp;</td>
            </tr>
            <tr>
                <td style="font-weight: bold; font-size: 10pt" colspan="4">
                    Customer Wise Outstanding</td>
        </tr>
        <tr>
            <td style="font-weight: bold; font-size: 10pt" colspan="4">
                &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells" style="width: 150px">
                    Month</td>
            <td>
                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Year</td>
            <td>
                <asp:DropDownList ID="ddlYear" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:LinkButton ID="cmdViewOutstanding" runat="server" CssClass="buttonc">View</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td>
                <div id="AdjResultsDiv4" style="width: 900px; height: 400px; overflow: scroll;">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="grdOutstandingsCustomer" runat="server" CaptionAlign="Left" EmptyDataText="No Records found for the given period."
                                EnableModelValidation="True" Font-Bold="True" Font-Size="9pt" Width="100%" 
                                DataKeyNames="CustNo">
                                <RowStyle CssClass="GridItem" />
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:CommandField SelectText="View Sale Person" ShowSelectButton="True" />
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" ForeColor="White" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                                SelectCommand="jct_ops_customer_wise_outstanding" 
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    
                                    <asp:ControlParameter ControlID="ddlPlant" DefaultValue=" " Name="Plant"
                                        PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="ddlMonth" Name="Month" 
                                        PropertyName="SelectedValue" Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlYear" Name="Year" 
                                        PropertyName="SelectedValue" Type="Int32" />
                                    
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmdViewOutstanding" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grdOutstandingsSP" runat="server" CaptionAlign="Left" 
                            EmptyDataText="No Records found for the given period." 
                            EnableModelValidation="True" Font-Bold="True" Font-Size="9pt" Width="100%">
                            <RowStyle CssClass="GridItem" />
                            <AlternatingRowStyle CssClass="GridAI" />
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="jct_ops_customer_saleperson_wise_outstanding" 
                            SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlPlant" DefaultValue=" " Name="Plant" 
                                    PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddlMonth" DefaultValue="" Name="Month" 
                                    PropertyName="SelectedValue" Type="Int32" />
                                <asp:ControlParameter ControlID="ddlYear" Name="Year" 
                                    PropertyName="SelectedValue" Type="Int32" />
                                <asp:ControlParameter ControlID="grdOutstandingsCustomer" DefaultValue="" 
                                    Name="CustomerCode" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdOutstandingsCustomer" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
