<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="payroll_variable_deduction.aspx.cs" Inherits="PayRoll_payroll_variable_deduction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Variable Deductions :
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Deduction Type
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldedtype" runat="server" AutoPostBack="True" CssClass="combobox"
                    OnSelectedIndexChanged="ddldedtype_SelectedIndexChanged" AppendDataBoundItems="True"
                    DataTextField="Deduction_Short_Description" DataValueField="Deduction_code">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddldedtype"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Employee
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True" 
                    OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="autocomplete_ListItem1" Enabled="True" TargetControlID="txtEmployee"
                    ServiceMethod="GetEmployee_sh_Common_Active" ServicePath="~/WebService.asmx" MinimumPrefixLength="1">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="Label1" runat="server" Text="Department"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbdept" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td class="NormalText">
                &nbsp;
                <asp:Label ID="Label3" runat="server" Text="Desigination"></asp:Label>
            </td>
            <td class="NormalText">
                &nbsp;
                <asp:Label ID="lbdesign" runat="server" Text="Label" Visible="False" CssClass="labelcells"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Deduction Amount
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtdedamount" runat="server" CssClass="textbox" Visible="False"  
                    Width="80px" ontextchanged="txtdedamount_TextChanged"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtdedamount_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtdedamount" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:DropDownList ID="ddldedamount" runat="server" CssClass="combobox" Visible="False"
                    Width="80">
                </asp:DropDownList>
                <%--
                <asp:TextBox ID="txtallw" runat="server" CssClass="textbox" Visible="False" Width="80"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtallw_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtallw" ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdedamount"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <br />
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Effective From
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnTextChanged="txtefffrm_TextChanged"></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtefffrm">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                Effective To
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteffto_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txteffto">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkUpdate_Click" Visible="False">Update</asp:LinkButton>
                                 <asp:LinkButton ID="LnkAuth" runat="server" CssClass="buttonc" OnClick="LnkAuth_Click"
                    ValidationGroup="A">Freeze</asp:LinkButton>
                
            </td>
        </tr>
    </table>
</asp:Content>
