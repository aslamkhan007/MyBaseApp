<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Payroll_Salary_LeaveEncashment_Print.aspx.cs" Inherits="Payroll_Payroll_Salary_LeaveEncashment_Print" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Leave Encashment Report:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                For The Month(Start)
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtfromdate" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtfromdate_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtfromdate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfromdate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                For The Month(End)
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txttodate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Location
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
   
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="tableheader" colspan="4">
            </td>
        </tr>
    </table>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
        GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CrystalReportSource1"
        ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="payroll_Salary_Sheet_Departmentwise.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>
