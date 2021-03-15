﻿<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="budgetentry.aspx.cs" Inherits="OPS_budgetentry" %>

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
                Effective To</td>
            <td class="NormalText">
                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteffto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteffto">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                Effective From</td>
            <td class="NormalText">
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtefffrm">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Department</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldept" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource1" DataTextField="deptname" 
                    DataValueField="deptcode" ontextchanged="ddldept_TextChanged" 
                    AutoPostBack="True" AppendDataBoundItems="True" 
                    onselectedindexchanged="ddldept_SelectedIndexChanged">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="select deptname,deptcode from jctdev..deptmast where company_code = 'JCT00LTD' order by deptname">
                </asp:SqlDataSource>
            </td>
            <td class="NormalText">
                HOD</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlhod" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource2" DataTextField="empname" DataValueField="empcode">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT distinct a.empname,a.empcode  from  dbo.JCT_EmpMast_Base a join  dbo.JCT_Emp_Catg_Desg_Mapping b on  a.catg=b.catg where a.active='Y' and a.company_code='JCT00LTD' and a.catg='SM1' and deptcode=@deptcode">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddldept" Name="deptcode" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
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
                    <asp:ListItem Selected="True">Inventory</asp:ListItem>
                    <asp:ListItem>Repair</asp:ListItem>
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
            <td class="NormalText" colspan="3">
                <asp:CheckBoxList ID="chklist" runat="server">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    onselectedindexchanged="grdDetail_SelectedIndexChanged" Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
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
            </td>
        </tr>
    </table>
</asp:Content>

