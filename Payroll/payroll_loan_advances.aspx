<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="payroll_loan_advances.aspx.cs" Inherits="PayRoll_payroll_loan_advances" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <table style="width: 100%;">
    <style type="text/css">
    .abc {
            
          background: grey;                   
        }
    </style>
        <tr>
            <td class="tableheader" colspan="2">
                Loans and Advances
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Loans And Advances
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLoanType" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlLoanType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Employee Name
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEmployeeCode" runat="server" CssClass="textbox" AutoPostBack="True"
                            OnTextChanged="txtEmployeeCode_TextChanged" Width="250px"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="txtEmployeeCode_AutoCompleteExtender" runat="server"
                            DelimiterCharacters="" CompletionListCssClass="autocomplete_ListItem1" Enabled="True"
                            TargetControlID="txtEmployeeCode" ServiceMethod="GetEmployee_sh_Common" ServicePath="~/WebService.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1">
                        </cc1:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="ReqEmployeecode" runat="server" ControlToValidate="txtEmployeeCode"
                            Display="Dynamic" ErrorMessage="**EmployeeName Required!!" ForeColor="#CC0000"
                            ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <%--        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                <asp:DropDownList ID="ddlplant" runat="server" AutoPostBack="True" 
                    CssClass="combobox" Enabled="False">
                </asp:DropDownList>
                 </ContentTemplate>                    
                </asp:UpdatePanel>  
            </td>
        </tr>--%>
        <%--        <tr>
            <td class="labelcells">
                Location</td>
            <td class="NormalText">
                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True" 
                    CssClass="combobox" Enabled="False">
                </asp:DropDownList>
                 </ContentTemplate>                    
                </asp:UpdatePanel> 
            </td>
        </tr>--%>
        <%--        <tr>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:Label ID="lblBank" runat="server" Text="Banks" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlBankLIst" runat="server" CssClass="combobox" AppendDataBoundItems="True"
                            DataTextField="description" DataValueField="Bank_code" Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>--%>
        <%--     <tr>
            <td class="labelcells">
                <asp:Label ID="lblCalculationMethod" runat="server" Text="Calculation Method "></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel17" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCalcuationMethod" runat="server" AppendDataBoundItems="True" 
                            CssClass="combobox" DataTextField="description" 
                            DataValueField="Bank_code" AutoPostBack="True" Enabled="False">
                        </asp:DropDownList>                      
                    </ContentTemplate>                    
                </asp:UpdatePanel>
            </td>
        </tr>

        --%>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label1" runat="server" Text="Department"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbdept" runat="server" Text="Label" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label3" runat="server" Text="Desigination"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbdesign" runat="server" Text="Label" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 16px">
                Loan Sanction Date
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtloandt" runat="server" CssClass="textbox" Width="78px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtloandt_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtloandt">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="MEV1" runat="server" ControlExtender="MEE1" ControlToValidate="txtloandt"
                            Display="Dynamic" ErrorMessage="MEV1" InvalidValueMessage="INVALID DATE" TooltipMessage="MM/DD/YYYY"
                            IsValidEmpty="False" EmptyValueMessage="ENTER DATE!!" ValidationGroup="A"></cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MEE1" runat="server" MaskType="Date" Mask="99/99/9999"
                            TargetControlID="txtloandt">
                        </cc1:MaskedEditExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Sanction No
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSanctionNo" runat="server" CssClass="textbox" Width="78px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqLoanAmount0" runat="server" ControlToValidate="txtSanctionNo"
                            Display="Dynamic" ErrorMessage="**Sanction No Required!!" ForeColor="#CC0000"
                            ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Sanction Amount
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePaneltxtSanctionAmount" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSanctionAmount" runat="server" CssClass="textbox" 
                            ontextchanged="txtSanctionAmount_TextChanged"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtSanctionAmount_FilteredTextBoxExtender" runat="server"
                            Enabled="True" TargetControlID="txtSanctionAmount" ValidChars="1234567890">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="ReqtxtSanctionAmount" runat="server" ControlToValidate="txtSanctionAmount"
                            Display="Dynamic" ErrorMessage="**Sanction Amount No Required!!" ForeColor="#CC0000"
                            ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>

          <tr>
            <td class="labelcells">
                InstalmentAmount
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtinstalmnt" runat="server" CssClass="textbox"
                              ontextchanged="txtinstalmnt_TextChanged"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtinstalmnt_FilteredTextBoxExtender" runat="server"
                            Enabled="True" TargetControlID="txtinstalmnt" ValidChars="1234567890">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:RequiredFieldValidator ID="ReqInsAmount" runat="server" ControlToValidate="txtinstalmnt"
                    Display="Dynamic" ErrorMessage="**Installment Amount Required!!" ForeColor="#CC0000"
                    ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="labelcells">
                Total No.of instalment
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtno_of_inst" runat="server" Enabled="False" CssClass="abc" 
                         ></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtno_of_inst_FilteredTextBoxExtender" runat="server"
                            Enabled="True" TargetControlID="txtno_of_inst" ValidChars="1234567890">
                        </cc1:FilteredTextBoxExtender>
                        <%--<asp:RequiredFieldValidator ID="ReqInsNos" runat="server" ControlToValidate="txtno_of_inst"
                            Display="Dynamic" ErrorMessage="**Installment No Required!!" ForeColor="#CC0000"
                            ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
      
        <tr>
            <td class="labelcells">
                Last date for loan Completion
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCompletedate" runat="server" Enabled="False" CssClass="abc" Width="78px"></asp:TextBox>
                       <%-- <cc1:CalendarExtender ID="txtCompletedate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtCompletedate">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="MEV2" runat="server" ControlExtender="MEE2" ControlToValidate="txtCompletedate"
                            Display="Dynamic" EmptyValueMessage="ENTER DATE!!" ErrorMessage="MEV2" InvalidValueMessage="INVALID DATE"
                            IsValidEmpty="False" TooltipMessage="MM/DD/YYYY" ValidationGroup="A"></cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MEE2" runat="server" Mask="99/99/9999" MaskType="Date"
                            TargetControlID="txtCompletedate">
                        </cc1:MaskedEditExtender>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                            ValidationGroup="A">Save</asp:LinkButton>
                              <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="buttonc" 
                            ValidationGroup="A" onclick="lnkUpdate_Click">Update</asp:LinkButton>
                        <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkModify" runat="server" CssClass="buttonc" OnClick="lnkModify_Click">CloseLoan</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True"
                                Width="100%" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
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
