<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="budgetentry.aspx.cs" Inherits="OPS_budgetentry" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="2">
                Budget Entry</td>
            <td class="tableheader">
                <asp:Label ID="lb" runat="server" Text="BudgetID" Visible="False"></asp:Label>
            </td>
            <td class="tableheader">
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
          <td class="NormalText">
                Effective From</td>
            <td class="NormalText">
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtefffrm">
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
            <td class="NormalText">
                Department</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldept" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource1" DataTextField="subdept_name" 
                    DataValueField="subdept_code" ontextchanged="ddldept_TextChanged" 
                    AutoPostBack="True" AppendDataBoundItems="True" 
                    onselectedindexchanged="ddldept_SelectedIndexChanged">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="select distinct subdept_name,subdept_code from jctdev..jct_empmast_base where company_code = 'JCT00LTD' and  subdept_name IS NOT  NULL AND active='Y' order by subdept_name">
                </asp:SqlDataSource>
                <asp:LinkButton ID="lnkCheck" runat="server" onclick="lnkCheck_Click">Check</asp:LinkButton>
            </td>
           <td class="NormalText">
                <asp:Label ID="lblHOD" runat="server" Text="HOD"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlhod" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource2" DataTextField="empname" 
                    DataValueField="empcode" AppendDataBoundItems="True">
                    <asp:ListItem Value="A00047">ARWINDER SINGH</asp:ListItem>
                     <asp:ListItem Value="B00319">Bhagat Ram Saini</asp:ListItem>
                    <asp:ListItem Value="H01526">Husan Lal</asp:ListItem>
                    
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT distinct a.empname,Replace(a.empcode,'-','') as empcode from  dbo.JCT_EmpMast_Base a join  dbo.JCT_Emp_Catg_Desg_Mapping b on  a.catg=b.catg where a.active='Y' and a.company_code='JCT00LTD' and a.catg='SM1'">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Budget Type</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlBudgetType" runat="server" CssClass="combobox" ontextchanged="ddldept_TextChanged" 
                    AutoPostBack="True" AppendDataBoundItems="True" 
                    onselectedindexchanged="ddldept_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Repair</asp:ListItem>
                    <asp:ListItem Selected="True">Inventory</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td class="NormalText">
                Budget Amount</td>
            <td class="NormalText">
                <asp:TextBox ID="txtbdgamt" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtbdgamt_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtbdgamt" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtbdgamt" Display="Dynamic" 
                    ErrorMessage="** Please enter amount" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        
        </tr>
        <tr>
            <td class="NormalText">
                Indenter</td>
            <td class="NormalText">
                <asp:CheckBoxList ID="chklist" runat="server">
                </asp:CheckBoxList>
            </td>
		    <td class="NormalText">
                Groupcode</td>
                <td class="NormalText">
                    <asp:DropDownList ID="ddlgroupcode" runat="server" CssClass="combobox" 
                        DataSourceID="SqlDataSource3" DataTextField="group_description" 
                        DataValueField="group_code">
                       <%-- <asp:ListItem Value="D">Dye</asp:ListItem>
                        <asp:ListItem>Chemical</asp:ListItem>
                        <asp:ListItem Value="SI">StoreItem</asp:ListItem>--%>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:jctdevConnectionString %>" 
                        SelectCommand="Select '' as group_description,'' as group_code union SELECT group_description,group_code FROM miserp.reportdb.dbo.jct_budget_group_master">
                    </asp:SqlDataSource>
             </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True"
                    onselectedindexchanged="grdDetail_SelectedIndexChanged" Width="100%" 
                    AllowPaging="True" onpageindexchanging="grdDetail_PageIndexChanging" 
                    PageSize="20">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                    onclick="lnkadd_Click" ValidationGroup="A">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc"
                    onclick="lnkupdate_Click">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" 
                    onclick="lnkdel_Click">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                    onclick="lnkReset_Click">Reset</asp:LinkButton>

           <%--     <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" 
                    onclick="lnkExcel_Click">Excel</asp:LinkButton>--%>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonc" 
                    onclick="lnkexcel_Click">Excel</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

