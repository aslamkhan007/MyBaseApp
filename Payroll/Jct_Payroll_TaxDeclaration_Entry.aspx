<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_TaxDeclaration_Entry.aspx.cs" Inherits="Payroll_Jct_Payroll_TaxDeclaration_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Tax Declaration
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
                Search Emplyoee Name
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="GetEmployee_sh_Common" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee">
                </cc1:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmployee"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" Width="32px"
                    OnClick="lnkexcel_Click"></asp:LinkButton>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" OnClick="lnkadd_Click"
                    ValidationGroup="A">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" 
                    onclick="LinkButton1_Click" >Report</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel4" Width="900px" runat="server" BorderStyle="Solid" Visible="False"
        ScrollBars="Both" Height="70px">
        <table class="mytable">
            <tr>
                <td>
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                        OnRowDataBound="grdDetail_RowDataBound">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                            <asp:BoundField DataField="Empcode" HeaderText="EmployeeCode" SortExpression="Empcode" />
                            <asp:TemplateField HeaderText="HRAffidevit">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAccnum" runat="server" CssClass="textbox" MaxLength="8" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="Flt" runat="server" Enabled="True" TargetControlID="txtAccnum"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HandiEmp">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHandicapEmployee" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FHandicapEmployee" runat="server" Enabled="True"
                                        TargetControlID="txtHandicapEmployee" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HandiDep">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHandicapDependent" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FHandicapDependent" runat="server" Enabled="True"
                                        TargetControlID="txtHandicapDependent" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PublicPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPublicProvidentFund" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FPublicProvidentFund" runat="server" Enabled="True"
                                        TargetControlID="txtPublicProvidentFund" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LIC">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLifeInsuranceCorporation" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FLifeInsuranceCorporation" runat="server" Enabled="True"
                                        TargetControlID="txtLifeInsuranceCorporation" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NSC">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNationalSavingCertificate8" runat="server" CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FNationalSavingCertificate8" runat="server" Enabled="True"
                                        TargetControlID="txtNationalSavingCertificate8" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HouseingLoan">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHouseingLoanPayment" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FHouseingLoanPayment" runat="server" Enabled="True"
                                        TargetControlID="txtHouseingLoanPayment" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="INFRA">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtINFRA" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FINFRA" runat="server" Enabled="True" TargetControlID="txtINFRA"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UNITLN">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtUNITLN" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="UNITLN" runat="server" Enabled="True" TargetControlID="txtUNITLN"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MedIns">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMedical_Insurance" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FMedical_Insurance" runat="server" Enabled="True"
                                        TargetControlID="txtMedical_Insurance" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SENIOR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSENIOR" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FSENIOR" runat="server" Enabled="True" TargetControlID="txtSENIOR"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NPS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNPS" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FNPS" runat="server" Enabled="True" TargetControlID="txtNPS"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PMFund">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrimeMinisterFund" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FPrimeMinisterFund" runat="server" Enabled="True"
                                        TargetControlID="txtPrimeMinisterFund" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HigherEduction">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHigherEduction" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FHigherEduction" runat="server" Enabled="True" TargetControlID="txtHigherEduction"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SchoolFees">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSchoolFees" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FSchoolFees" runat="server" Enabled="True" TargetControlID="txtSchoolFees"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OtherIncome">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOtherIncome" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FOtherIncome" runat="server" Enabled="True" TargetControlID="txtOtherIncome"
                                        ValidChars="-0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="VariablePay">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCashIncentive" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive" runat="server" Enabled="True" TargetControlID="txtCashIncentive"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="LeaveEncash">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtER_LeaveEncashment" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FER_LeaveEncashment" runat="server" Enabled="True"
                                        TargetControlID="txtER_LeaveEncashment" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CarInsurance">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtER_CarInsurance" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FER_CarInsurance" runat="server" Enabled="True"
                                        TargetControlID="txtER_CarInsurance" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bonus">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtER_Bonus" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FER_Bonus" runat="server" Enabled="True" TargetControlID="txtER_Bonus"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LTATaxable">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtER_LTATaxable" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FER_LTATaxable" runat="server" Enabled="True" TargetControlID="txtER_LTATaxable"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LTANonTaxable">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtER_LTANonTaxable" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FER_LTANonTaxable" runat="server" Enabled="True"
                                        TargetControlID="txtER_LTANonTaxable" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EntertainmentAlw">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEntertainmentAllowance" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FEntertainmentAllowance" runat="server" Enabled="True"
                                        TargetControlID="txtEntertainmentAllowance" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LTADATE">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLTADATE" runat="server" CssClass="textbox"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LTAIT">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLTA_IT" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FLTA_IT" runat="server" Enabled="True" TargetControlID="txtLTA_IT"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--       <asp:TemplateField HeaderText="Income">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIncome" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FIncome" runat="server" Enabled="True" TargetControlID="txtIncome"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <%--                            <asp:TemplateField HeaderText="TaxableAmount">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTaxableAmount" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FTaxableAmount" runat="server" Enabled="True" TargetControlID="txtTaxableAmount"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="TaxTotal">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTaxTotal" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FTaxTotal" runat="server" Enabled="True" TargetControlID="txtTaxTotal"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <%--                            <asp:TemplateField HeaderText="Cess">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCess" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCess" runat="server" Enabled="True" TargetControlID="txtCess"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SH_Cess">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSH_Cess" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FSH_Cess" runat="server" Enabled="True" TargetControlID="txtSH_Cess"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Taxded">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTaxded" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FTaxded" runat="server" Enabled="True" TargetControlID="txtTaxded"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IncomeTax">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIncomeTax" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FIncomeTax" runat="server" Enabled="True" TargetControlID="txtIncomeTax"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Taxslab">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTaxslab" runat="server" CssClass="textbox" MaxLength="2" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FTaxslab" runat="server" Enabled="True" TargetControlID="txtTaxslab"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Taxrefund">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTaxrefund" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FTaxrefund" runat="server" Enabled="True" TargetControlID="txtTaxrefund"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Taxinst">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTaxinst" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FTaxinst" runat="server" Enabled="True" TargetControlID="txtTaxinst"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CesInst">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCesInst" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCesInst" runat="server" Enabled="True" TargetControlID="txtCesInst"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SH_CesInst">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSH_CesInst" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FSH_CesInst" runat="server" Enabled="True" TargetControlID="txtSH_CesInst"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rebate_87A">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRebate_87A" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FRebate_87A" runat="server" Enabled="True" TargetControlID="txtRebate_87A"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Amedical">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAmedical" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FAmedical" runat="server" Enabled="True" TargetControlID="txtAmedical"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ALeave">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtALeave" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FALeave" runat="server" Enabled="True" TargetControlID="txtALeave"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agratuity">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAgratuity" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FAgratuity" runat="server" Enabled="True" TargetControlID="txtAgratuity"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AllowSer">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAllowSer" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FAllowSer" runat="server" Enabled="True" TargetControlID="txtAllowSer"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LeaveTax">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLeaveTax" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FLeaveTax" runat="server" Enabled="True" TargetControlID="txtLeaveTax"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="WomenRebate">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtWomenRebate" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FWomenRebate" runat="server" Enabled="True" TargetControlID="txtWomenRebate"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PensionFund">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPensionFund" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FPensionFund" runat="server" Enabled="True" TargetControlID="txtPensionFund"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Mth_Cal">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMth_Cal" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FMth_Cal" runat="server" Enabled="True" TargetControlID="txtMth_Cal"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Aret_Comp">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAret_Comp" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FAret_Comp" runat="server" Enabled="True" TargetControlID="txtAret_Comp"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                            


                            <asp:TemplateField HeaderText="FinalLvEncash">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtER_FinalLvEncash" runat="server" CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FER_FinalLvEncash" runat="server" Enabled="True"
                                        TargetControlID="txtER_FinalLvEncash" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="buttonbackbar" colspan="4">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <table class="mytable">
            <tr>
                <td class="buttonbackbar" colspan="4">
                    <asp:LinkButton ID="lnkapply" runat="server" CssClass="buttonc" ValidationGroup="A"
                        OnClick="lnkapply_Click">Save</asp:LinkButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
