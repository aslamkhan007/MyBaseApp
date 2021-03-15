<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="payroll_allownc_subparmrt_master.aspx.cs" Inherits="PayRoll_payroll_subparmrt_master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                SubComponents Master
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Component Type
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlComponentType" runat="server" AutoPostBack="True" CssClass="combobox"
                    ToolTip="Specify The Type of Earnings/Deductions" OnSelectedIndexChanged="ddlComponentType_SelectedIndexChanged">
                    <asp:ListItem>Earning</asp:ListItem>
                    <asp:ListItem>Reimbursement</asp:ListItem>
                    <asp:ListItem>Deduction</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlComponentType"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
            </td>
            <td class="labelcells">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Component Description<br />
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlparamtr" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddlparamtr_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlparamtr"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblCode" runat="server" Text="SrCode" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbcodeid" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 23px" class="labelcells">
                Designation
            </td>
            <td style="height: 23px" class="NormalText">
                <asp:DropDownList ID="ddldesignation" runat="server" AutoPostBack="True" CssClass="combobox"
                    OnSelectedIndexChanged="ddldesignation_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddldesignation"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td style="height: 23px" class="labelcells">
                Unit Of Component
            </td>
            <td style="height: 23px" class="NormalText">
                <asp:DropDownList ID="ddlUOC" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Rupees</asp:ListItem>
                    <asp:ListItem>Percent</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlUOC"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                SubComponent Name
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtsubparamtr" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtsubparamtr"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                SubComponent Description
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtdesc" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdesc"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblDeductionOn" runat="server" Text="Valuation Factor"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldeductionOn" runat="server" CssClass="combobox" AutoPostBack="True"
                    ToolTip="Parameter Specifying the Base of Deduction" AppendDataBoundItems="True">
                    <asp:ListItem Selected="True">StdValue</asp:ListItem>
                    <asp:ListItem>Basic</asp:ListItem>
                    <asp:ListItem>Gross</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddldeductionOn"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Value
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtvalue" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtSanctionAmount_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtvalue" ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtvalue"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="height: 18px" class="labelcells">
                Effective From
            </td>
            <td style="height: 18px" class="NormalText">
                <asp:TextBox ID="txteff_frm" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteff_frm_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txteff_frm">
                </cc1:CalendarExtender>
            </td>
            <td style="height: 18px" class="labelcells">
                Effective To
            </td>
            <td style="height: 18px" class="NormalText">
                <asp:TextBox ID="txteff_to" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteff_to_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txteff_to">
                </cc1:CalendarExtender>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" OnClick="lnkexcel_Click"
                    Width="32px"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="height: 18px" class="labelcells">
                &nbsp;</td>
            <td style="height: 18px" class="NormalText">
                &nbsp;</td>
            <td style="height: 18px" class="labelcells">
                &nbsp;</td>
            <td style="height: 18px" class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" OnClick="lnkupdate_Click"
                    ValidationGroup="A">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" OnClick="lnkdel_Click">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Visible="False"
                    Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" Width="100%"
                        OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
