<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="payroll_loan_advances.aspx.cs" Inherits="PayRoll_payroll_loan_advances" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
         <tr>
          <td class="tableheader" colspan="4">
                Loans and Advances</td>
        </tr>
        <tr>
            <td class="labelcells">
                Loan Type</td>
            <td class="NormalText">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="ddlLoanType" runat="server" CssClass="combobox"  DataSourceID="SqlLoantype" DataTextField="Deduction_Long_Description"  DataValueField="Deduction_code" 
                    AutoPostBack="True" onselectedindexchanged="ddlLoanType_SelectedIndexChanged" AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>

                <asp:SqlDataSource ID="SqlLoantype" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="select Deduction_code ,Deduction_Long_Description from JCT_payroll_deduction_master where ( Deduction_Long_Description LIKE '%loan' OR Deduction_Long_Description LIKE '%RD') and  status = 'A'">
                </asp:SqlDataSource>
                </ContentTemplate>
                </asp:UpdatePanel>
                <asp:RequiredFieldValidator ID="Reqloantype" runat="server" 
                    ControlToValidate="ddlLoanType" Display="Dynamic" 
                    ErrorMessage="**Please Select Loan Type!!" ForeColor="#CC0000" 
                    ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Employee Name</td>
            <td class="NormalText">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtEmployeeCode" runat="server" CssClass="textbox" 
                  AutoPostBack="True" ontextchanged="txtEmployeeCode_TextChanged" 
                    Width="250px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployeeCode_AutoCompleteExtender" runat="server" 
                    DelimiterCharacters="" CompletionListCssClass="autocomplete_ListItem1" Enabled="True" 
                    TargetControlID="txtEmployeeCode" ServiceMethod="GetEmployee_sh" 
                    ServicePath="~/WebService.asmx" CompletionInterval="100" 
                    MinimumPrefixLength="1" >
                </cc1:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="ReqEmployeecode" runat="server" 
                    ControlToValidate="txtEmployeeCode" Display="Dynamic" 
                    ErrorMessage="**EmployeeName Required!!" ForeColor="#CC0000" 
                    ValidationGroup="A"></asp:RequiredFieldValidator>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
            
        </tr>
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
            <td class="labelcells">
                Loan Sanction Date</td>
            <td class="NormalText">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtloandt" runat="server" CssClass="textbox" Width="78px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtloandt_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtloandt">
                </cc1:CalendarExtender>
                                            
                <cc1:MaskedEditValidator ID="MEV1" runat="server" 
                    ControlExtender="MEE1" ControlToValidate="txtloandt" Display="Dynamic" 
                     ErrorMessage="MEV1" InvalidValueMessage="INVALID DATE"  
                TooltipMessage="MM/DD/YYYY" IsValidEmpty="False" 
                EmptyValueMessage="ENTER DATE!!" ValidationGroup="A"                       
                    ></cc1:MaskedEditValidator>
                    <cc1:MaskedEditExtender ID="MEE1" runat="server" MaskType="Date" 
                    Mask="99/99/9999" TargetControlID="txtloandt" >
                </cc1:MaskedEditExtender>
            </ContentTemplate>
            </asp:UpdatePanel>             
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Loan Amount</td>
            <td class="NormalText">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txttotamt" runat="server" CssClass="textbox" 
                    AutoPostBack="True" ontextchanged="txttotamt_TextChanged"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txttotamt_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txttotamt" 
                    ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
            </ContentTemplate>
            </asp:UpdatePanel> 
                <asp:RequiredFieldValidator ID="ReqLoanAmount" runat="server" 
                    ControlToValidate="txttotamt" Display="Dynamic" 
                    ErrorMessage="**Loan Amount Required!!" ForeColor="#CC0000" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                InstalmentAmount</td>
            <td class="NormalText">
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtinstalmnt" runat="server" CssClass="textbox" 
                    AutoPostBack="True" ontextchanged="txtinstalmnt_TextChanged"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtinstalmnt_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtinstalmnt" 
                    ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
            </ContentTemplate>
            </asp:UpdatePanel> 
                <asp:RequiredFieldValidator ID="ReqInsAmount" runat="server" 
                    ControlToValidate="txtinstalmnt" Display="Dynamic" 
                    ErrorMessage="**Installment Amount Required!!" ForeColor="#CC0000" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Total No.of instalment</td>
            <td class="NormalText">
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtno_of_inst" runat="server" CssClass="textbox" 
                    AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtno_of_inst_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtno_of_inst" 
                    ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>

                              
            </ContentTemplate>
            </asp:UpdatePanel>       

       <%--         <asp:RequiredFieldValidator ID="ReqInstalmentNo" runat="server" 
                    ControlToValidate="txtno_of_inst" Display="Dynamic" 
                    ErrorMessage="**Installment No Required!!" ForeColor="#CC0000" 
                    ValidationGroup="A"></asp:RequiredFieldValidator>--%>

            </td>
        </tr>
        <tr>
            <td class="labelcells">
            Last date for loan Completion</td>
            <td class="NormalText">
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtCompletedate" runat="server" CssClass="textbox" 
                    Width="78px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtCompletedate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtCompletedate">
                </cc1:CalendarExtender>
                <cc1:MaskedEditValidator ID="MEV2" runat="server" ControlExtender="MEE2" 
                    ControlToValidate="txtCompletedate" Display="Dynamic" 
                    EmptyValueMessage="ENTER DATE!!" ErrorMessage="MEV2" 
                    InvalidValueMessage="INVALID DATE" IsValidEmpty="False" 
                    TooltipMessage="MM/DD/YYYY" ValidationGroup="A"></cc1:MaskedEditValidator>
                <cc1:MaskedEditExtender ID="MEE2" runat="server" Mask="99/99/9999" 
                    MaskType="Date" TargetControlID="txtCompletedate">
                </cc1:MaskedEditExtender>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        </table>

    <asp:Panel runat="server" ID="pnl" CssClass="panelbg">
               <asp:Image ID="ImgConsignee" runat="server" CssClass="first" ImageUrl="~/Image/plus.png"               
               Style="margin-right: 5px;" Width="16px"/>                                                   
               Additional Details
                 <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
                   TargetControlID="Panel1" CollapseControlID="ImgConsignee" Collapsed="True" 
                       CollapsedSize="0" ExpandControlID="ImgConsignee" ImageControlID="ImgConsignee"
                        ExpandedImage="~/Image/minus.png" CollapsedImage="~/Image/plus.png" ExpandDirection="Vertical" >
                   </cc1:CollapsiblePanelExtender>
       </asp:Panel>

    <asp:Panel ID="Panel1" runat="server" >
       <table style="width:100%;">
        <tr>
        <td class="labelcells" style="width: 388px">
            No.of instalment Paid</td>
        <td class="NormalText">
        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="txtno_of_ins_paid" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtno_of_ins_paid_FilteredTextBoxExtender" 
                runat="server" Enabled="True" TargetControlID="txtno_of_ins_paid" 
                ValidChars=".1234567890">
            </cc1:FilteredTextBoxExtender>
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        </tr>

        <tr>
        <td class="labelcells" style="width: 388px">
            No.of instalment left</td>
        <td class="NormalText">
        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="txtins_left" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtins_left_FilteredTextBoxExtender" 
                runat="server" Enabled="True" TargetControlID="txtins_left" 
                ValidChars=".1234567890">
            </cc1:FilteredTextBoxExtender>
       </ContentTemplate>
       </asp:UpdatePanel>
        </td>
        </tr>

         <tr>
        <td class="labelcells" style="width: 388px">
            Instalment Amount Paid</td>
        <td class="NormalText">
        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="txtins_amt_paid" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtins_amt_paid_FilteredTextBoxExtender" 
                runat="server" Enabled="True" TargetControlID="txtins_amt_paid" 
                ValidChars=".1234567890">
            </cc1:FilteredTextBoxExtender>
       </ContentTemplate>
       </asp:UpdatePanel>
        </td>
        </tr>

        <tr>
        <td class="labelcells" style="width: 388px">
            Amount Due</td>
        <td class="NormalText">
        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="txtamtdue" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtamtdue_FilteredTextBoxExtender" runat="server" 
                Enabled="True" TargetControlID="txtamtdue" ValidChars=".1234567890">
            </cc1:FilteredTextBoxExtender>
       </ContentTemplate>
       </asp:UpdatePanel>
        </td>
        </tr>

         <tr>
        <td class="labelcells" style="width: 388px">
            Interest</td>
        <td class="NormalText">
        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="txtInterest" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtintrest_FilteredTextBoxExtender" 
                runat="server" Enabled="True" TargetControlID="txtInterest" 
                ValidChars=".1234567890">
            </cc1:FilteredTextBoxExtender>
       </ContentTemplate>
       </asp:UpdatePanel>
        </td>
        </tr>

         </table>
    </asp:Panel>

    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
            <ContentTemplate>
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="lnksave_Click" ValidationGroup="A">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkupd" runat="server" CssClass="buttonc" 
                    ValidationGroup="A" onclick="lnkupd_Click" Enabled="False">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
           </ContentTemplate>
           </asp:UpdatePanel>
            </td>
        </tr>
    </table>

</asp:Content>

