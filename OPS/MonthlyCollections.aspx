<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="MonthlyCollections.aspx.vb" Inherits="OPS_MontlyCollections" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Invoice Collections and Adjustments *</td>
            <td class="tableheader">
                &nbsp;</td>
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
                To</td>
            <td>
                <asp:DropDownList ID="ddlDateTo" runat="server" CssClass="combobox">
                    <asp:ListItem Selected="True" Value="2013-03-31">MAR 2013</asp:ListItem>
                    <asp:ListItem Value="2013-02-28">FEB 2013</asp:ListItem>
                    <asp:ListItem Value="2013-01-31">JAN 2013</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td rowspan="2">
                <asp:LinkButton ID="cmdExportExcel" runat="server" BorderStyle="None" 
                    CssClass="buttonXL"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant</td>
            <td>
                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                    <asp:ListItem Value="C">Cotton</asp:ListItem>
                    <asp:ListItem Value="T">Taffeta</asp:ListItem>
                    <asp:ListItem Value="O">Both</asp:ListItem>
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
                            EnableModelValidation="True" Caption="Collections and Adjustments"
                            CaptionAlign="Left" Font-Bold="True" Font-Size="9pt">
                            <RowStyle CssClass="GridItem" />
                            <AlternatingRowStyle CssClass="GridAI" />
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="jct_ops_invoice_collection_adjustments_new" SelectCommandType="StoredProcedure">
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
                                SelectCommand="jct_ops_invoice_collection_daily_new" SelectCommandType="StoredProcedure">
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
        </table>
    <table style="width: 100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt">
                Customer Wise Collection</td>
        </tr>
        </table>
    <table style="width: 100%;">
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
                <div style="width: 900px; height: 300px; overflow: scroll;" id="AdjResultsDiv1">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="grdCustomerWiseCollection" runat="server" CaptionAlign="Left" 
                                EmptyDataText="No Records found for the given period." 
                                EnableModelValidation="True" Font-Bold="True" Font-Size="9pt" Width="200%">
                                <RowStyle CssClass="GridItem" />
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:jctgenConnectionString %>" 
                                SelectCommand="jct_ops_customer_wise_collection" 
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlPlant" DefaultValue=" " Name="Plant" 
                                        PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="ddlDateFrom" DefaultValue="" Name="FromDt" 
                                        PropertyName="SelectedValue" Type="DateTime" />
                                    <asp:ControlParameter ControlID="ddlDateTo" Name="ToDt" 
                                        PropertyName="SelectedValue" Type="DateTime" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmdView" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <br />
            </td>
        </tr>
        </table>
</asp:Content>
