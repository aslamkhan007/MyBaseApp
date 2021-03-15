<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="BudgetVSreport.aspx.cs" Inherits="OPS_BudgetVSreport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Budget V/S Indent/Sanction Raised</td>
        </tr>
        <tr>
            <td class="NormalText">
                From Date</td>
            <td class="NormalText">
                <asp:TextBox ID="txtfrmdate" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtfrmdate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtfrmdate">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                To Date</td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txttodate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                BudgetType</td>
            <td class="NormalText">
              <asp:DropDownList ID="ddltype" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Inventory</asp:ListItem>
                    <asp:ListItem>Repair</asp:ListItem>
                </asp:DropDownList></td>
            <td class="NormalText">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonXL" 
                    Height="32px" Width="32px" onclick="LinkButton1_Click"></asp:LinkButton>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="1000px" Height="500px">
                    <asp:GridView ID="grdDetail" runat="server" Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        </table>
</asp:Content>

