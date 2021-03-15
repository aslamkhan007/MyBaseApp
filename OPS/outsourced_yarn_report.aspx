<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="outsourced_yarn_report.aspx.cs" Inherits="OPS_outsourced_yarn_report" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Outsourced Yarn Report</td>
        </tr>
        <tr>
            <td class="NormalText">
                From Date
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtfrmdt" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="txtfrmdt_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txtfrmdt" 
                    WatermarkText="DD/MM/YY">
                </cc1:TextBoxWatermarkExtender>
                <cc1:CalendarExtender ID="txtfrmdt_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtfrmdt">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                To Date</td>
            <td class="NormalText">
                <asp:TextBox ID="txttodt" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="txttodt_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txttodt" 
                    WatermarkText="DD/MM/YY">
                </cc1:TextBoxWatermarkExtender>
                <cc1:CalendarExtender ID="txttodt_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txttodt">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                outsourced</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlout" runat="server" CssClass="combobox" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Fabric</asp:ListItem>
                    <asp:ListItem>Yarn</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                StockName</td>
            <td class="NormalText">
                <asp:TextBox ID="txtstcknm" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Vendor</td>
            <td class="NormalText">
                <asp:TextBox ID="txtvender" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkview" runat="server" CssClass="buttonc">View</asp:LinkButton>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonc">Excel</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

