<%@ Page Title="" Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Dnv_Summary_Report.aspx.vb" Inherits="SalesAnalysisSystem_Dnv_Summary_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                DnV Summary Report</td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="labelcells" style="height: 13px">
                Start Date
            </td>
            <td style="height: 13px">
                <asp:TextBox ID="txtSdate" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox>
                <cc1:CalendarExtender ID="txtsdate_CalendarExtender" runat="server" TargetControlID="txtsdate">
                </cc1:CalendarExtender>
            </td>
            <td class="labelcells" style="height: 13px">
                End Date
            </td>
            <td style="height: 13px">
                <asp:TextBox ID="txtEdate" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEdate_CalendarExtender" runat="server" TargetControlID="txtEdate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Segment
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSegment" runat="server" CssClass="combobox" DataSourceID="SqlDataSource1"
                            DataTextField="segment" DataValueField="segment">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SOMConnectionString %>"
                            SelectCommand="select distinct segment, count(*) from jct_so_team_catg
where segment is not null
and segment &lt;&gt; 'DISTRIBUTION'
group by segment
order by segment" DataSourceMode="DataReader"></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Item Group
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlItemGroup" runat="server" CssClass="combobox" Visible="False">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                            DataSourceMode="DataReader"></asp:SqlDataSource>
                        <asp:TextBox ID="txtItemGroup" runat="server" CssClass="textbox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Sale Person
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalePerson" runat="server" CssClass="combobox" DataSourceID="SqlDataSource3"
                            DataTextField="group_desc" DataValueField="group_no">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SOMConnectionString %>"
                            SelectCommand="select '' as group_no,'' as group_desc
union
select group_no,group_desc from m_cust_group
where group_type = 'salesp'
and group_no not like 'dummy%'
and status &lt;&gt; 'D'"></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                Category (FR/SP etc.)
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="combobox" DataSourceID="SqlDataSource4"
                            DataTextField="variant" DataValueField="variant" 
                            AppendDataBoundItems="True">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ShpConnectionString %>"
                            SelectCommand="select distinct variant from shp..dms_t_invoice_hdr a join shp..dms_t_invoice_item b on a.invoice_no = b.invoice_no
where a.invoice_dt between @sdate and @edate" DataSourceMode="DataReader">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtSdate" Name="sdate" PropertyName="Text" />
                                <asp:ControlParameter ControlID="txtEdate" Name="edate" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtSdate" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtEdate" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Report Type</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="combobox">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem Value="SQLDataSource5">DnV Detail</asp:ListItem>
                    <asp:ListItem Value="SQLDataSource6">Invoice Wise Contribution</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc">View</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="cmdDownload" runat="server" CssClass="buttonc">Download</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img alt="" src="../Image/loading.gif" style="width: 70px; height: 10px" />
                        Please Wait ...
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td>
                <div id="AdjResultsDiv" style="height: 300px; width: 800px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource5" 
                                Width="500%">
                                <RowStyle CssClass="GridItem" />
                                <HeaderStyle CssClass="GridHeader" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ShpConnectionString %>"
                                SelectCommand="jct_sas_sales_dnv_summary" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtSdate" Name="sdate" PropertyName="Text" Type="DateTime" />
                                    <asp:ControlParameter ControlID="txtEdate" Name="edate" PropertyName="Text" Type="DateTime" />
                                    <asp:ControlParameter ControlID="ddlSegment" Name="segment" PropertyName="SelectedValue"
                                        DefaultValue=" " Type="String" />
                                    <asp:ControlParameter ControlID="txtItemGroup" Name="item_group" PropertyName="Text"
                                         DefaultValue=" " Type="String" />
                                    <asp:ControlParameter ControlID="ddlSalePerson" Name="sale_person" PropertyName="SelectedValue"
                                        DefaultValue=" " Type="String" />
                                    <asp:ControlParameter ControlID="ddlCategory" Name="variant" PropertyName="SelectedValue"
                                        DefaultValue=" " Type="String" />
                                    <asp:Parameter Name="groupby" Type="String" DefaultValue=" " />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ShpConnectionString %>" 
                                SelectCommand="jct_sas_invoice_wise_contribution" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtSdate" Name="sdate" PropertyName="Text" 
                                        Type="DateTime" />
                                    <asp:ControlParameter ControlID="txtEdate" Name="edate" PropertyName="Text" 
                                        Type="DateTime" />
                                    <asp:ControlParameter ControlID="ddlSegment" DefaultValue=" " Name="segment" 
                                        PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="txtItemGroup" DefaultValue=" " 
                                        Name="item_group" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="ddlSalePerson" DefaultValue=" " 
                                        Name="sale_person" PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="ddlCategory" DefaultValue=" " Name="variant" 
                                        PropertyName="SelectedValue" Type="String" />
                                    <asp:Parameter DefaultValue=" " Name="groupby" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <br />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="LinkButton1" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
