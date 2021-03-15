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
                <asp:DropDownList ID="ddldept" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                Type
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
                Hod</td>
            <td class="NormalText" style="width: 162px">
                <asp:DropDownList ID="ddlhod" runat="server" CssClass="combobox" 
                    AppendDataBoundItems="True">
                    <asp:ListItem> </asp:ListItem>
                </asp:DropDownList>
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
                <asp:GridView ID="grdDetail" runat="server" Width="100%">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
            </td>
        </tr>
        </table>
</asp:Content>

