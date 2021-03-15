<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="JCT_Payroll_PF_OpeningBalance.aspx.cs" Inherits="Payroll_JCT_Payroll_PF_OpeningBalance" %>

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
                PF Opening Balance:
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
                    ServiceMethod="LocationWIse_Employee_Left" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee">
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
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" OnClick="lnkadd_Click"
                    ValidationGroup="A">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" OnClick="LinkButton1_Click">Report</asp:LinkButton>
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
                            <asp:TemplateField HeaderText="Nominee">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNominee" runat="server" Text='<%# Eval("Nominee") %>' CssClass="textbox"
                                        MaxLength="30" Width="80"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>



                             <asp:TemplateField HeaderText="DtPfjoin">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDtPfjoin" runat="server" Text='<%# Eval("DtPfjoin") %>' CssClass="textbox"
                                        MaxLength="8" Width="80"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender145465" Enabled="True" TargetControlID="txtDtPfjoin"
                                        runat="server">
                                    </cc1:CalendarExtender>
                                    <cc1:MaskedEditExtender ID="MEE145654" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="txtDtPfjoin">
                                    </cc1:MaskedEditExtender>
                                </ItemTemplate>
                            </asp:TemplateField>




                            <asp:TemplateField HeaderText="DtFmlyPen">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDtFmlyPen" runat="server" Text='<%# Eval("DtFmlyPen") %>' CssClass="textbox"
                                        MaxLength="8" Width="80"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" TargetControlID="txtDtFmlyPen"
                                        runat="server">
                                    </cc1:CalendarExtender>
                                    <cc1:MaskedEditExtender ID="MEE1" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="txtDtFmlyPen">
                                    </cc1:MaskedEditExtender>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="DtPfTaken">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDtPfTaken" Text='<%# Eval("DtPfTaken") %>' runat="server" CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender11" Enabled="True" TargetControlID="txtDtPfTaken"
                                        runat="server">
                                    </cc1:CalendarExtender>
                                    <cc1:MaskedEditExtender ID="MEE10" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="txtDtPfTaken">
                                    </cc1:MaskedEditExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PFOwn">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOwnPFAmt" Text='<%# Eval("OwnPFAmt") %>' runat="server" CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FHandicapDependent" runat="server" Enabled="True"
                                        TargetControlID="txtOwnPFAmt" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PFEmp.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEmpPFAmt" Text='<%# Eval("EmpPFAmt") %>' runat="server" CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FPublicProvidentFund" runat="server" Enabled="True"
                                        TargetControlID="txtEmpPFAmt" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IntOwn">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOwnIntAmt" runat="server" Text='<%# Eval("OwnIntAmt") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FLifeInsuranceCorporation" runat="server" Enabled="True"
                                        TargetControlID="txtOwnIntAmt" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IntEmp.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEMPIntAmt" runat="server" CssClass="textbox" Text='<%# Eval("EMPIntAmt") %>'
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FNationalSavingCertificate8" runat="server" Enabled="True"
                                        TargetControlID="txtEMPIntAmt" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VPFAmt">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtVPFAmt" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("VPFAmt") %>'></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FHouseingLoanPayment" runat="server" Enabled="True"
                                        TargetControlID="txtVPFAmt" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VPFInt">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtVPFInt" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("VPFInt") %>'></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FINFRA" runat="server" Enabled="True" TargetControlID="txtVPFInt"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FPFAmt">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFPFAmt" runat="server" CssClass="textbox" Width="80" Text='<%# Eval("FPFAmt") %>'></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="UNITLN" runat="server" Enabled="True" TargetControlID="txtFPFAmt"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CLOwnAmt">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCLSOwnPFAmt" runat="server" Text='<%# Eval("CLSOwnPFAmt") %>'
                                        CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FMedical_Insurance" runat="server" Enabled="True"
                                        TargetControlID="txtCLSOwnPFAmt" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CLEmpAmt">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCLSEmpPFAmt" runat="server" Text='<%# Eval("CLSEmpPFAmt") %>'
                                        CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FSENIOR" runat="server" Enabled="True" TargetControlID="txtCLSEmpPFAmt"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CLOwnIntAmt">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCLSOwnIntAmt" runat="server" Text='<%# Eval("CLSOwnIntAmt") %>'
                                        CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FNPS" runat="server" Enabled="True" TargetControlID="txtCLSOwnIntAmt"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CLEmpIntAmt">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCLSEMPIntAmt" runat="server" Text='<%# Eval("CLSEMPIntAmt") %>'
                                        CssClass="textbox" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FPrimeMinisterFund" runat="server" Enabled="True"
                                        TargetControlID="txtCLSEMPIntAmt" ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CLVpfAmt">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCLSVPFAmt" runat="server" Text='<%# Eval("CLSVPFAmt") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FHigherEduction" runat="server" Enabled="True" TargetControlID="txtCLSVPFAmt"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CLVpfInt">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCLSVPFInt" runat="server" Text='<%# Eval("CLSVPFInt") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FSchoolFees" runat="server" Enabled="True" TargetControlID="txtCLSVPFInt"
                                        ValidChars="0123456789.">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CLFpfAmt">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCLSFPFAmt" runat="server" Text='<%# Eval("CLSFPFAmt") %>' CssClass="textbox"
                                        Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FOtherIncome" runat="server" Enabled="True" TargetControlID="txtCLSFPFAmt"
                                        ValidChars="0123456789.">
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
