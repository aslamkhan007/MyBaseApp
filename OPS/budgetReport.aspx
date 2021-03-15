<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="budgetReport.aspx.cs" Inherits="OPS_budgetReport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Budget Report</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 111px">
                Effective From
            </td>
            <td class="NormalText" style="width: 162px">
                <asp:TextBox ID="txtefffrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrom_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtefffrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                Effective To</td>
            <td class="NormalText">
                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteffto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteffto">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 111px">
                Department</td>
            <td class="NormalText" style="width: 162px">
                <asp:DropDownList ID="ddldept" runat="server" AppendDataBoundItems="True" 
                    AutoPostBack="True" CssClass="combobox"
                    onselectedindexchanged="ddldept_SelectedIndexChanged" 
                    DataSourceID="SqlDataSource1" DataTextField="subdept_name" 
                    DataValueField="subdept_code">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
              
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="select distinct subdept_name,subdept_code from jctdev..jct_empmast_base where company_code = 'JCT00LTD' and  subdept_name IS NOT  NULL AND active='Y' order by subdept_name">
                </asp:SqlDataSource>
              
            </td>
            <td class="NormalText">
                Type</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddltype" runat="server" CssClass="combobox" 
                    onselectedindexchanged="ddltype_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Inventory</asp:ListItem>
                    <asp:ListItem>Repair</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 111px">
                &nbsp;</td>
            <td class="NormalText" style="width: 162px">
                <asp:DropDownList ID="ddlhod" runat="server" CssClass="combobox" 
                    AppendDataBoundItems="True" DataSourceID="SqlDataSource2" 
                    DataTextField="empname" DataValueField="empcode" Visible="False">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT distinct a.empname,Replace(a.empcode,'-','') as empcode from  dbo.JCT_EmpMast_Base a join  dbo.JCT_Emp_Catg_Desg_Mapping b on  a.catg=b.catg where a.active='Y' and a.company_code='JCT00LTD' and a.catg='SM1'">
                </asp:SqlDataSource>
            </td>
            <td class="NormalText">
                <asp:LinkButton ID="lbexcel" runat="server" CssClass="buttonXL" Height="32px" 
                    onclick="lbexcel_Click" Width="32px"></asp:LinkButton>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                    onclick="lnkReset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Vertical" 
                    Width="800px">
                    <asp:GridView ID="grdDetail" runat="server" Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        </table>
</asp:Content>

