<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_FullAndFinal_Entry.aspx.cs" Inherits="Payroll_Jct_Payroll_FullAndFinal_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Full And Final Details:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Employee Code
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" 
                    AutoPostBack="True" ontextchanged="txtEmployee_TextChanged1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmployee"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>

          
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Total Days
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txttodays" runat="server" CssClass="textbox" MaxLength="5"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttodays"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>

                <cc1:FilteredTextBoxExtender ID="txtunits_FilteredTextBoxExtendeasasr" runat="server"
                                        Enabled="True" TargetControlID="txttodays" ValidChars="0123456789" >
                                    </cc1:FilteredTextBoxExtender>

            </td>
            <td class="labelcells">
                Pay Days
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtPaydays" runat="server" CssClass="textbox" MaxLength="5"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPaydays"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>

            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtendeasasr1" runat="server"
                Enabled="True" TargetControlID="txtPaydays" ValidChars="0123456789." >
            </cc1:FilteredTextBoxExtender>
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
            <td class="buttonbackbar" colspan="4" >
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" OnClick="lnkadd_Click"
                    ValidationGroup="A">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" visible ="false" Enabled = "false" OnClick="lnkdel_Click">Delete</asp:LinkButton>


            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel4" Width="900px" runat="server" BorderStyle="Solid" Visible="False"
        ScrollBars="Both" Height="140px">
        <table class="mytable">
            <tr>
                <td  colspan="4">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                        OnRowDataBound="grdDetail_RowDataBound" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                          
                            <asp:BoundField DataField="Earnings" HeaderText="Earnings" SortExpression="Earnings" />
                            <asp:BoundField DataField="AdditonalAllowance" HeaderText="AdditonalAllowance" SortExpression="AdditonalAllowance" />
                            <asp:BoundField DataField="AdditonalAllowancePaid" HeaderText="AdditonalAllowancePaid"
                                SortExpression="AdditonalAllowancePaid" />
                            <asp:BoundField DataField="Adhoc" HeaderText="Adhoc" SortExpression="Adhoc" />
                            <asp:BoundField DataField="AdhocPaid" HeaderText="AdhocPaid" SortExpression="AdhocPaid" />
                            <asp:BoundField DataField="Basic" HeaderText="Basic" SortExpression="Basic" />
                            <asp:BoundField DataField="BasicPaid" HeaderText="BasicPaid" SortExpression="BasicPaid" />
                            <asp:BoundField DataField="FDA" HeaderText="FDA" SortExpression="FDA" />
                            <asp:BoundField DataField="FDAPaid" HeaderText="FDAPaid" SortExpression="FDAPaid" />
                            <asp:BoundField DataField="VDA" HeaderText="VDA" SortExpression="VDA" />
                            <asp:BoundField DataField="VDAPaid" HeaderText="VDAPaid" SortExpression="VDAPaid" />
                            <asp:BoundField DataField="ColonyAllowance" HeaderText="ColonyAllowance" SortExpression="ColonyAllowance" />
                            <asp:BoundField DataField="ColonyAllowancePaid" HeaderText="ColonyAllowancePaid"
                                SortExpression="ColonyAllowancePaid" />
                            <asp:BoundField DataField="HRA" HeaderText="HRA" SortExpression="HRA" />
                            <asp:BoundField DataField="HRAPaid" HeaderText="HRAPaid" SortExpression="HRAPaid" />
                            <asp:BoundField DataField="PersonalAllowance" HeaderText="PersonalAllowance" SortExpression="PersonalAllowance" />
                            <asp:BoundField DataField="PersonalAllowancePaid" HeaderText="PersonalAllowancePaid"
                                SortExpression="PersonalAllowancePaid" />
                            <asp:BoundField DataField="SPECIALALLOWANCE" HeaderText="SPECIALALLOWANCE" SortExpression="SPECIALALLOWANCE" />
                            <asp:BoundField DataField="SPECIALALLOWANCEPaid" HeaderText="SPECIALALLOWANCEPaid"
                                SortExpression="SPECIALALLOWANCEPaid" />
                            <asp:BoundField DataField="UniformAllowance" HeaderText="UniformAllowance" SortExpression="UniformAllowance" />
                            <asp:BoundField DataField="UniformAllowancePaid" HeaderText="UniformAllowancePaid"
                                SortExpression="UniformAllowancePaid" />
                            <asp:BoundField DataField="TelephoneAllowance" HeaderText="TelephoneAllowance" SortExpression="TelephoneAllowance" />
                            <asp:BoundField DataField="TelephoneAllowancePaid" HeaderText="TelephoneAllowancePaid"
                                SortExpression="TelephoneAllowancePaid" />
                            <asp:BoundField DataField="TPTAllowance" HeaderText="TPTAllowance" SortExpression="TPTAllowance" />
                            <asp:BoundField DataField="TPTAllowancePaid" HeaderText="TPTAllowancePaid" SortExpression="TPTAllowancePaid" />
                            <asp:BoundField DataField="FurnitureAllowance" HeaderText="FurnitureAllowance" SortExpression="FurnitureAllowance" />
                            <asp:BoundField DataField="FurnitureAllowancePaid" HeaderText="FurnitureAllowancePaid"
                                SortExpression="FurnitureAllowancePaid" />
                            <asp:BoundField DataField="Education Allowance" HeaderText="Education Allowance"
                                SortExpression="Education Allowance" />
                            <asp:BoundField DataField="Education Allowance Paid" HeaderText="Education Allowance Paid"
                                SortExpression="Education Allowance Paid" />
                            <asp:BoundField DataField="Reimbursements" HeaderText="Reimbursements" SortExpression="Reimbursements" />
                            <asp:BoundField DataField="Car Allowance" HeaderText="Car Allowance" SortExpression="Car Allowance" />
                            <asp:BoundField DataField="Car Allowance Paid" HeaderText="Car Allowance Paid" SortExpression="Car Allowance Paid" />
                            <asp:BoundField DataField="DriverSalary" HeaderText="DriverSalary" SortExpression="DriverSalary" />
                            <asp:BoundField DataField="DriverSalaryPaid" HeaderText="DriverSalaryPaid" SortExpression="DriverSalaryPaid" />
                            <asp:BoundField DataField="EntertainmentAllowance" HeaderText="EntertainmentAllowance"
                                SortExpression="EntertainmentAllowance" />
                            <asp:BoundField DataField="EntertainmentAllowancePaid" HeaderText="EntertainmentAllowancePaid"
                                SortExpression="EntertainmentAllowancePaid" />
                            <asp:BoundField DataField="LTA" HeaderText="LTA" SortExpression="LTA" />
                            <asp:BoundField DataField="LTAPaid" HeaderText="LTAPaid" SortExpression="LTAPaid" />
                            <asp:BoundField DataField="Scooter allowance" HeaderText="Scooter allowance" SortExpression="Scooter allowance" />
                            <asp:BoundField DataField="Scooter allowance Paid" HeaderText="Scooter allowance Paid"
                                SortExpression="Scooter allowance Paid" />
                            <asp:BoundField DataField="TelephoneReimburs" HeaderText="TelephoneReimburs" SortExpression="TelephoneReimburs" />
                            <asp:BoundField DataField="TelephoneReimburspaid" HeaderText="TelephoneReimburspaid"
                                SortExpression="TelephoneReimburspaid" />
                            <asp:BoundField DataField="Deductions" HeaderText="Deductions" SortExpression="Deductions" />
                            <asp:BoundField DataField="PF" HeaderText="PF" SortExpression="PF" />
                            <asp:BoundField DataField="PFPaid" HeaderText="PFPaid" SortExpression="PFPaid" />
                            <asp:BoundField DataField="ESi" HeaderText="ESi" SortExpression="ESi" />
                            <asp:BoundField DataField="EsiPaid" HeaderText="EsiPaid" SortExpression="EsiPaid" />
                            <asp:BoundField DataField="GrossSalary" HeaderText="GrossSalary" SortExpression="GrossSalary" />
                            <asp:BoundField DataField="GrossSalaryPaid" HeaderText="GrossSalaryPaid" SortExpression="GrossSalaryPaid" />
                            <asp:BoundField DataField="TotalDeductions" HeaderText="TotalDeductions" SortExpression="TotalDeductions" />
                            <asp:BoundField DataField="TotalDeductionsPaid" HeaderText="TotalDeductionsPaid"
                                SortExpression="TotalDeductionsPaid" />
                            <asp:BoundField DataField="NetSalary" HeaderText="NetSalary" SortExpression="NetSalary" />
                            <asp:BoundField DataField="NetSalaryPaid" HeaderText="NetSalaryPaid" SortExpression="NetSalaryPaid" />
                            <asp:BoundField DataField="Gratiuity" HeaderText="Gratiuity" SortExpression="Gratiuity" />
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" Visible="False">
        <table class="mytable">
            <tr>
                <td class="labelcells">
                    PF
                </td>
                <td class="labelcells">
                    <asp:Label ID="lblpfd" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    ESI
                </td>
                <td class="labelcells">
                    <asp:Label ID="lblesid" runat="server"></asp:Label>
                </td>
                <tr>
                    <td class="labelcells">
                        Net Salary
                    </td>
                    <td class="labelcells">
                        <asp:Label ID="lblNetSalary" runat="server"></asp:Label>
                    </td>
                    <td class="labelcells">
                        Gratiuity
                    </td>
                    <td class="labelcells">
                        <asp:Label ID="lblGratiuity" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="labelcells">
                        LeaveNo
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtLeaveNo" runat="server" CssClass="textbox" Width="80px" AutoPostBack="true"
                            OnTextChanged="txtLeaveNo_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLeaveNo"
                            ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>

                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderasas1" runat="server"
                                        Enabled="True" TargetControlID="txtLeaveNo" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>

                    </td>
                    <td class="labelcells">
                        LeaveAmount
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtLeaveAmount" runat="server" CssClass="textbox" Width="80px" Enabled="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLeaveAmount"
                            ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    </td>
                </tr>
<%-- Start--%>

 <tr>
                    <td class="labelcells">
                        NoticePeriodAdd
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtNoticePeriodAdd" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNoticePeriodAdd"
                            ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>--%>

                             <cc1:FilteredTextBoxExtender ID="asasasasasflt" runat="server"
                                        Enabled="True" TargetControlID="txtNoticePeriodAdd" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>

                    </td>
                    <td class="labelcells">
                        NoticePeriodMinus
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtNoticePeriodMinus" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNoticePeriodMinus"
                            ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>--%>

                              <cc1:FilteredTextBoxExtender ID="FilteredTextBoxEasasqwwasxtender1" runat="server"
                                        Enabled="True" TargetControlID="txtNoticePeriodMinus" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>
                    </td>
                </tr>


                <tr>
                    <td class="labelcells">
                        Provident Fund Payable
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtpfpay" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>                        

                        <cc1:FilteredTextBoxExtender ID="FilteredTex1212dstBoxExtender1" runat="server"
                                        Enabled="True" TargetControlID="txtpfpay" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>

                    </td>
                    <td class="labelcells">
                        Esi Crg Payable
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtesipay" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>  
                        
                           <cc1:FilteredTextBoxExtender ID="FilteredText12we23212BoxExtender1" runat="server"
                                        Enabled="True" TargetControlID="txtesipay" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>
                                              
                    </td>
                </tr>


                <tr>
                    <td class="labelcells">
                       Stationary Crg
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtStationary" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>                        

                         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1001" runat="server"
                                        Enabled="True" TargetControlID="txtStationary" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>

                    </td>
                    <td class="labelcells">
                        TWCC SocietyLoan
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtTWCC" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>                        

                         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1002" runat="server"
                                        Enabled="True" TargetControlID="txtTWCC" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>

                    </td>
                </tr>

                        <tr>
                    <td class="labelcells">
                      Notice Period Wage
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtNoticePd" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>                        

                                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1003" runat="server"
                                        Enabled="True" TargetControlID="txtNoticePd" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>

                    </td>
                    <td class="labelcells">
                        PowerConsumed
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtPowerConsumed" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>                        

                              <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1004" runat="server"
                                        Enabled="True" TargetControlID="txtPowerConsumed" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>

                    </td>
                </tr>

                                       <tr>
                    <td class="labelcells">
                      GMI Recovery
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtGMI" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>                        

                           <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1005" runat="server"
                                        Enabled="True" TargetControlID="txtGMI" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>

                    </td>
                    <td class="labelcells">
                        QuaterMaintenece 
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtQuaterMaintenece" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>                        

                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1006" runat="server"
                                        Enabled="True" TargetControlID="txtQuaterMaintenece" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>

                    </td>
                </tr>

                                           <tr>
                    <td class="labelcells">
                     Advance To StaffSalary
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtAdvanceStaff" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>                        

                           <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1007" runat="server"
                                        Enabled="True" TargetControlID="txtAdvanceStaff" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>

                    </td>
                    <td class="labelcells">
                        StaffAdvanceExpense 
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtStaffAdvanceExpense" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>                        

                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1008" runat="server"
                                        Enabled="True" TargetControlID="txtStaffAdvanceExpense" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>

                    </td>
                </tr>

                    <tr>
                    <td class="labelcells">
                     LTA Staff
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtLtastaff" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>     
                        
                         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2001" runat="server"
                                        Enabled="True" TargetControlID="txtLtastaff" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>
                                           
                    </td>
                    <td class="labelcells">
                        Tds Payable Salary 
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtTDSpay" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>                        

                           <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2002" runat="server"
                                        Enabled="True" TargetControlID="txtTDSpay" ValidChars="0123456789." >
                                    </cc1:FilteredTextBoxExtender>

                    </td>
                </tr>



<%-- End--%>


               
                <tr>
                    <td class="labelcells">
                        FullAndFinalAmount
                    </td>
                    <td class="labelcells">
                        <asp:Label ID="lblFullAndFinalAmount" runat="server"></asp:Label>
                    </td>
                    <td class="labelcells">
                    </td>
                    <td class="NormalText">
                    </td>
                    <tr>
                        <td class="buttonbackbar" colspan="4">
                            <asp:LinkButton ID="lnkCheck" runat="server" CssClass="buttonc" ValidationGroup="B"
                                Enabled="false" OnClick="lnkCheck_Click">Check</asp:LinkButton>
                            <asp:LinkButton ID="lnkapply" runat="server" CssClass="buttonc" ValidationGroup="B"
                                Enabled="false" OnClick="lnkapply_Click">Update</asp:LinkButton>

                            <asp:LinkButton ID="lnkFreeze" runat="server" CssClass="buttonc" ValidationGroup="B" 
                                Enabled="false" onclick="lnkFreeze_Click" >Freeze</asp:LinkButton>

                            <asp:LinkButton ID="lnkUnfreeze" runat="server" CssClass="buttonc" 
                            Enabled="false" onclick="lnkUnfreeze_Click"  >UnFreeze</asp:LinkButton>

                        </td>
                    </tr>
                </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
    </asp:Panel>
</asp:Content>
