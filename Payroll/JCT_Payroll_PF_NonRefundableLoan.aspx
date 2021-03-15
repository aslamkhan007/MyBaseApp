<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="JCT_Payroll_PF_NonRefundableLoan.aspx.cs" Inherits="Payroll_JCT_Payroll_PF_NonRefundableLoan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function SetContextKey() {
            $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlLocation.ClientID %>").value);
        }
    </script>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Non Refundable Loan:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                FIYear
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
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
        <tr>
            <td class="labelcells">
                Search Emplyoee Name
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"
                    onkeyup="SetContextKey()" OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="LocationWIse_Employee" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee">
                </cc1:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmployee"
                    ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <b>EmployeeCode</b>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblEmpname" runat="server"></asp:Label>
            </td>
            <td class="labelcells">
                <b>PreviousEmployeeCode</b>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblDept" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <b>EmployeeName</b>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbldesig" runat="server"></asp:Label>
            </td>
            <td class="labelcells">
                <b>PF No</b>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblGross" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <b>SanctionDate</b>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtefffrm" runat="server" autocomplete="off" Width="100px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtefffrm">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtefffrm"
                    ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                <b>SanctionNo</b>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="SadvRequiredAmt" runat="server" MaxLength="7"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="TxtPri_Mobile_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="SadvRequiredAmt" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="SadvRequiredAmt"
                    ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
         <td class="labelcells">
                <b>OwnLoanAmt</b>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox1" runat="server" MaxLength="7"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                    Enabled="True" TargetControlID="SadvRequiredAmt" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="SadvRequiredAmt"
                    ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
           <td class="labelcells">
                <b>EmpLoanAmt</b>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox2" runat="server" MaxLength="7"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                    Enabled="True" TargetControlID="SadvRequiredAmt" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="SadvRequiredAmt"
                    ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
         <td class="labelcells">
                <b>OwnIntAmt</b>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox3" runat="server" MaxLength="7"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                    Enabled="True" TargetControlID="SadvRequiredAmt" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="SadvRequiredAmt"
                    ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
           <td class="labelcells">
                <b>EmpIntAmt</b>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox4" runat="server" MaxLength="7"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                    Enabled="True" TargetControlID="SadvRequiredAmt" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="SadvRequiredAmt"
                    ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
        </tr>

                 <tr>
         <td class="labelcells">
                <b>VPFAmt</b>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox5" runat="server" MaxLength="7"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                    Enabled="True" TargetControlID="SadvRequiredAmt" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="SadvRequiredAmt"
                    ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
           <td class="labelcells">
                <b>VPFInt</b>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox6" runat="server" MaxLength="7"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                    Enabled="True" TargetControlID="SadvRequiredAmt" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="SadvRequiredAmt"
                    ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" OnClick="lnkadd_Click"
                    ValidationGroup="mandatory">Apply</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" OnClick="LinkButton1_Click">Report</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
