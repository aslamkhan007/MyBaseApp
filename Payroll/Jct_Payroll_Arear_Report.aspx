﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_Arear_Report.aspx.cs" Inherits="Payroll_Jct_Payroll_Arear_Report" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Arrear Report :
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                YearMonth
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Arrear Type
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldedtype" runat="server" CssClass="combobox"
                    OnSelectedIndexChanged="ddldedtype_SelectedIndexChanged" AppendDataBoundItems="True"
                    DataTextField="Deduction_Short_Description" 
                    DataValueField="Deduction_code">
                    <asp:ListItem Selected="True">Fda</asp:ListItem>
                    <asp:ListItem>PayDays</asp:ListItem>
                    <%--<asp:ListItem>Increment</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Location
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
 <%--       <tr>
            <td class="labelcells">
                Arrear Start Date
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnTextChanged="txtefffrm_TextChanged"></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtefffrm">
                </cc1:CalendarExtender>
            </td>
            <td class="labelcells">
                Arrear End Date
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteffto_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txteffto">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                FDA Amount
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtdedamount" runat="server" CssClass="textbox" Width="80px" MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtdedamount_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtdedamount" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdedamount"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <br />
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
        </tr>
        <tr>
            <td class="labelcells">
                Remarks
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtRemarks" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>--%>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" OnClick="lnkexcel_Click"
                    Width="32px"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Reset</asp:LinkButton>
                    <%--<asp:LinkButton ID="lnkFreeze" runat="server" CssClass="buttonc" 
                        onclick="lnkFreeze_Click" ValidationGroup="A">Freeze</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="1000px">
                            <asp:GridView ID="grdDetail" runat="server" EnableModelValidation="True" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="Griditem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

