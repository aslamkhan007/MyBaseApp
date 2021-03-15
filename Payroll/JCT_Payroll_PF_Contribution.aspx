<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="JCT_Payroll_PF_Contribution.aspx.cs" Inherits="Payroll_JCT_Payroll_PF_Contribution" %>

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
          PF EPS Correction:
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
                            <asp:BoundField DataField="EmployeeCode" HeaderText="EmployeeCode" SortExpression="EmployeeCode" />

                              <asp:TemplateField HeaderText="SapCode">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSapCode" runat="server" Text='<%# Eval("EmployeeCode") %>' CssClass="textbox"
                                        MaxLength="10" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="Flt1002" runat="server" Enabled="True" TargetControlID="txtSapCode"
                                        ValidChars="0123456789">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="PFNo">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPFNo" runat="server" Text='<%# Eval("PFNo") %>' CssClass="textbox"
                                        MaxLength="10" Width="80"></asp:TextBox>
                                   <%-- <cc1:FilteredTextBoxExtender ID="Flt1003" runat="server" Enabled="True" TargetControlID="txtPFNo"
                                        ValidChars="0123456789">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="FPFNo">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFPFNo" runat="server" Text='<%# Eval("FPFNo") %>' CssClass="textbox"
                                        MaxLength="10" Width="80"></asp:TextBox>
                                    <%--<cc1:FilteredTextBoxExtender ID="Flt1004" runat="server" Enabled="True" TargetControlID="txtFPFNo"
                                        ValidChars="0123456789">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </ItemTemplate>
                            </asp:TemplateField>









                            <asp:TemplateField HeaderText="APRPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAPRPF" runat="server" Text='<%# Eval("APRPF") %>' CssClass="textbox"
                                        MaxLength="8" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="Flt" runat="server" Enabled="True" TargetControlID="txtAPRPF"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="APRVPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAPRVPF" runat="server" Text='<%# Eval("APRVPF") %>' CssClass="textbox"
                                        MaxLength="8" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="Flt100" runat="server" Enabled="True" TargetControlID="txtAPRVPF"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="APRSAL">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAPRSAL" Text='<%# Eval("APRSAL") %>' runat="server" CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FHandicapEmployee" runat="server" Enabled="True"
                                        TargetControlID="txtAPRSAL" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="APRPFR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAPRPFR" Text='<%# Eval("APRPFR") %>' runat="server" CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FHandicapDependent" runat="server" Enabled="True"
                                        TargetControlID="txtAPRPFR" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="APREPS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAPREPS" Text='<%# Eval("APREPS") %>' runat="server" CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FPublicProvidentFund" runat="server" Enabled="True"
                                        TargetControlID="txtAPREPS" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAYPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMAYPF" runat="server" Text='<%# Eval("MAYPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FLifeInsuranceCorporation" runat="server" Enabled="True"
                                        TargetControlID="txtMAYPF" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAYVPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMAYVPF" runat="server" CssClass="textbox" Text='<%# Eval("MAYVPF") %>'
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FNationalSavingCertificate8" runat="server" Enabled="True"
                                        TargetControlID="txtMAYVPF" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAYSAL">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMAYSAL" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("MAYSAL") %>'></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FHouseingLoanPayment" runat="server" Enabled="True"
                                        TargetControlID="txtMAYSAL" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAYPFR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMAYPFR" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("MAYPFR") %>'></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FINFRA" runat="server" Enabled="True" TargetControlID="txtMAYPFR"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAYEPS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMAYEPS" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("MAYEPS") %>'></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="UNITLN" runat="server" Enabled="True" TargetControlID="txtMAYEPS"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JUNPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJUNPF" runat="server" Text='<%# Eval("JUNPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FMedical_Insurance" runat="server" Enabled="True"
                                        TargetControlID="txtJUNPF" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JUNVPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJUNVPF" runat="server" Text='<%# Eval("JUNVPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FSENIOR" runat="server" Enabled="True" TargetControlID="txtJUNVPF"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JUNSAL">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJUNSAL" runat="server" Text='<%# Eval("JUNSAL") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FNPS" runat="server" Enabled="True" TargetControlID="txtJUNSAL"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JUNPFR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJUNPFR" runat="server" Text='<%# Eval("JUNPFR") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FPrimeMinisterFund" runat="server" Enabled="True"
                                        TargetControlID="txtJUNPFR" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JUNEPS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJUNEPS" runat="server" Text='<%# Eval("JUNEPS") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FHigherEduction" runat="server" Enabled="True" TargetControlID="txtJUNEPS"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JULPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJULPF" runat="server" Text='<%# Eval("JULPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FSchoolFees" runat="server" Enabled="True" TargetControlID="txtJULPF"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JULVPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJULVPF" runat="server" Text='<%# Eval("JULVPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FOtherIncome" runat="server" Enabled="True" TargetControlID="txtJULVPF"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JULSAL">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJULSAL" runat="server" Text='<%# Eval("JULSAL") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FER_LeaveEncashment" runat="server" Enabled="True"
                                        TargetControlID="txtJULSAL" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JULPFR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJULPFR" runat="server" Text='<%# Eval("JULPFR") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FER_CarInsurance" runat="server" Enabled="True"
                                        TargetControlID="txtJULPFR" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JULEPS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJULEPS" runat="server" Text='<%# Eval("JULEPS") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FER_Bonus" runat="server" Enabled="True" TargetControlID="txtJULEPS"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AUGPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAUGPF" runat="server" Text='<%# Eval("AUGPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FER_LTATaxable" runat="server" Enabled="True" TargetControlID="txtAUGPF"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AUGVPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAUGVPF" runat="server" Text='<%# Eval("AUGVPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FER_LTANonTaxable" runat="server" Enabled="True"
                                        TargetControlID="txtAUGVPF" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AUGSAL">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAUGSAL" runat="server" Text='<%# Eval("AUGSAL") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FEntertainmentAllowance" runat="server" Enabled="True"
                                        TargetControlID="txtAUGSAL" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AUGPFR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAUGPFR" runat="server" Text='<%# Eval("AUGPFR") %>' CssClass="textbox"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AUGEPS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAUGEPS" runat="server" Text='<%# Eval("AUGEPS") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FLTA_IT" runat="server" Enabled="True" TargetControlID="txtAUGEPS"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SEPPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSEPPF" runat="server" Text='<%# Eval("SEPPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FAmedical" runat="server" Enabled="True" TargetControlID="txtSEPPF"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SEPVPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSEPVPF" runat="server" CssClass="textbox" Text='<%# Eval("SEPVPF") %>'
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FALeave" runat="server" Enabled="True" TargetControlID="txtSEPVPF"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SEPSAL">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSEPSAL" runat="server" Text='<%# Eval("SEPSAL") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FAgratuity" runat="server" Enabled="True" TargetControlID="txtSEPSAL"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SEPPFR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSEPPFR" runat="server" Text='<%# Eval("SEPPFR") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FAllowSer" runat="server" Enabled="True" TargetControlID="txtSEPPFR"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SEPEPS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSEPEPS" runat="server" Text='<%# Eval("SEPEPS") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FLeaveTax" runat="server" Enabled="True" TargetControlID="txtSEPEPS"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OCTPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOCTPF" runat="server" Text='<%# Eval("OCTPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FWomenRebate" runat="server" Enabled="True" TargetControlID="txtOCTPF"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OCTVPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOCTVPF" runat="server" Text='<%# Eval("OCTVPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FPensionFund" runat="server" Enabled="True" TargetControlID="txtOCTVPF"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OCTSAL">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOCTSAL" runat="server" Text='<%# Eval("OCTSAL") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive" runat="server" Enabled="True" TargetControlID="txtOCTSAL"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OCTPFR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOCTPFR" runat="server" Text='<%# Eval("OCTPFR") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FER_FinalLvEncash" runat="server" Enabled="True"
                                        TargetControlID="txtOCTPFR" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OCTEPS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOCTEPS" runat="server" Text='<%# Eval("OCTEPS") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FER_FinalLvEncash1" runat="server" Enabled="True"
                                        TargetControlID="txtOCTEPS" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NOVPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNOVPF" runat="server" Text='<%# Eval("NOVPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive1" runat="server" Enabled="True" TargetControlID="txtNOVPF"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NOVVPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNOVVPF" runat="server" Text='<%# Eval("NOVVPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive2" runat="server" Enabled="True" TargetControlID="txtNOVVPF"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NOVSAL">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNOVSAL" runat="server" Text='<%# Eval("NOVSAL") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive3" runat="server" Enabled="True" TargetControlID="txtNOVSAL"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NOVPFR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNOVPFR" runat="server" Text='<%# Eval("NOVPFR") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive4" runat="server" Enabled="True" TargetControlID="txtNOVPFR"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NOVEPS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNOVEPS" runat="server" Text='<%# Eval("NOVEPS") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive5" runat="server" Enabled="True" TargetControlID="txtNOVEPS"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DECPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDECPF" runat="server" Text='<%# Eval("DECPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive6" runat="server" Enabled="True" TargetControlID="txtDECPF"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DECVPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDECVPF" runat="server" Text='<%# Eval("DECVPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive7" runat="server" Enabled="True" TargetControlID="txtDECVPF"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DECSAL">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDECSAL" runat="server" Text='<%# Eval("DECSAL") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive8" runat="server" Enabled="True" TargetControlID="txtDECSAL"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DECPFR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDECPFR" runat="server" Text='<%# Eval("DECPFR") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive100" runat="server" Enabled="True"
                                        TargetControlID="txtDECPFR" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DECEPS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDECEPS" runat="server" Text='<%# Eval("DECEPS") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive9" runat="server" Enabled="True" TargetControlID="txtDECEPS"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JANPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJANPF" runat="server" Text='<%# Eval("JANPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive10" runat="server" Enabled="True"
                                        TargetControlID="txtJANPF" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JANVPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJANVPF" runat="server" Text='<%# Eval("JANVPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive33" runat="server" Enabled="True"
                                        TargetControlID="txtJANVPF" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JANSAL">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJANSAL" runat="server" Text='<%# Eval("JANSAL") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive11" runat="server" Enabled="True"
                                        TargetControlID="txtJANSAL" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JANPFR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJANPFR" runat="server" Text='<%# Eval("JANPFR") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive12" runat="server" Enabled="True"
                                        TargetControlID="txtJANPFR" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="JANEPS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtJANEPS" runat="server" Text='<%# Eval("JANEPS") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive13" runat="server" Enabled="True"
                                        TargetControlID="txtJANEPS" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FEBPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFEBPF" runat="server" Text='<%# Eval("FEBPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive14" runat="server" Enabled="True"
                                        TargetControlID="txtFEBPF" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FEBVPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFEBVPF" runat="server" Text='<%# Eval("FEBVPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive15" runat="server" Enabled="True"
                                        TargetControlID="txtOCTSAL" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FEBSAL">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFEBSAL" runat="server" Text='<%# Eval("FEBSAL") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive16" runat="server" Enabled="True"
                                        TargetControlID="txtFEBSAL" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FEBPFR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFEBPFR" runat="server" Text='<%# Eval("FEBPFR") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive17" runat="server" Enabled="True"
                                        TargetControlID="txtFEBPFR" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FEBEPS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFEBEPS" runat="server" Text='<%# Eval("FEBEPS") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive18" runat="server" Enabled="True"
                                        TargetControlID="txtFEBEPS" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MARPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMARPF" runat="server" Text='<%# Eval("MARPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive19" runat="server" Enabled="True"
                                        TargetControlID="txtMARPF" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MARVPF">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMARVPF" runat="server" Text='<%# Eval("MARVPF") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive20" runat="server" Enabled="True"
                                        TargetControlID="txtMARVPF" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MARSAL">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMARSAL" runat="server" Text='<%# Eval("MARSAL") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive21" runat="server" Enabled="True"
                                        TargetControlID="txtMARSAL" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MARPFR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMARPFR" runat="server" Text='<%# Eval("MARPFR") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive22" runat="server" Enabled="True"
                                        TargetControlID="txtMARPFR" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAREPS">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMAREPS" runat="server" Text='<%# Eval("MAREPS") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive23" runat="server" Enabled="True"
                                        TargetControlID="txtMAREPS" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PFMAR2">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPFMAR2" runat="server" Text='<%# Eval("PFMAR2") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive25" runat="server" Enabled="True"
                                        TargetControlID="txtPFMAR2" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VPFMAR2">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtVPFMAR2" runat="server" Text='<%# Eval("VPFMAR2") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive26" runat="server" Enabled="True"
                                        TargetControlID="txtVPFMAR2" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MARSAL2">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMARSAL2" runat="server" Text='<%# Eval("MARSAL2") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive27" runat="server" Enabled="True"
                                        TargetControlID="txtMARSAL2" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PFRMAR2">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPFRMAR2" runat="server" Text='<%# Eval("PFRMAR2") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive28" runat="server" Enabled="True"
                                        TargetControlID="txtPFRMAR2" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EPSMAR2">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEPSMAR2" runat="server" Text='<%# Eval("EPSMAR2") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FCashIncentive29" runat="server" Enabled="True"
                                        TargetControlID="txtEPSMAR2" ValidChars="0123456789.">
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
                        OnClick="lnkapply_Click">Update</asp:LinkButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
