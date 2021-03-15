<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Payroll_Manualentry_Attandence.aspx.cs" Inherits="Payroll_Payroll_Manualentry_Attandence" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="4">
                Manual Entry / Updation
            </td>
        </tr>
             <tr>
            <td class="labelcells">
                Attendence Type
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlReporttype" runat="server" CssClass="combobox" 
                     onselectedindexchanged="ddlReporttype_SelectedIndexChanged"
                    >
                    <asp:ListItem>Salary</asp:ListItem>
                    <asp:ListItem>Seprate Voucher</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                From Date
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtfromdate" runat="server" CssClass="textbox" Width="70px" AutoPostBack="True"
                    OnTextChanged="txtfromdate_TextChanged"></asp:TextBox>
                <cc1:CalendarExtender ID="txtfromdate_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtfromdate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfromdate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                ToDate
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
                Card No
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtCardNo" runat="server" AutoPostBack="True" CssClass="textbox"
                    MaxLength="100" OnTextChanged="txtCardNo_TextChanged" Width="45px"></asp:TextBox>
               <%-- <cc1:FilteredTextBoxExtender ID="txtCardNo_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtCardNo" ValidChars="1234567890">
                </cc1:FilteredTextBoxExtender>--%>
                <asp:RequiredFieldValidator ID="Reqcardno" runat="server" ControlToValidate="txtCardNo"
                    Display="Dynamic" ErrorMessage="Card No ?" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                <%-- <asp:DropDownList ID="ddldesignation" runat="server" AutoPostBack="True" 
                    CssClass="combobox" DataSourceID="SqlDesignation" 
                    DataTextField="Desg_Long_Description" DataValueField="Designation_code">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDesignation" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT Designation_code,Desg_Long_Description FROM   JCT_payroll_designation_master WHERE  STATUS='A'">
                </asp:SqlDataSource>--%>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Department
            </td>
            <td class="NormalText">
                <asp:Label ID="lbldepartment" runat="server" CssClass="labelcells"></asp:Label>
                <%-- <asp:DropDownList ID="ddldepartment" runat="server" AutoPostBack="True" 
                    CssClass="combobox" DataSourceID="Sqldapartment" 
                    DataTextField="Department_Short_Description" DataValueField="Department_code" 
                    onselectedindexchanged="ddldepartment_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:SqlDataSource ID="Sqldapartment" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT Department_code,Department_Short_Description FROM   JCT_payroll_department_master WHERE  STATUS='A'">
                </asp:SqlDataSource>--%>
            </td>
            <td class="labelcells">
                Designation
            </td>
            <td class="NormalText">
                <%-- <asp:DropDownList ID="ddlsubdepartment" runat="server" CssClass="combobox" 
                    AutoPostBack="True">
                </asp:DropDownList>--%>
                <asp:Label ID="lblDesignation" runat="server" CssClass="labelcells"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Present Days
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtPresentDays" runat="server" CssClass="textbox" MaxLength="100"
                    Width="45px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtPresentDays_FilteredTextBoxExtender0" runat="server"
                    Enabled="True" TargetControlID="txtPresentDays" ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
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
                Privilege Leave (PL)
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtPL" runat="server" CssClass="textbox" MaxLength="100" Width="45px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtPL_FilteredTextBoxExtender" runat="server" Enabled="True"
                    TargetControlID="txtPL" ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 16px">
                Casual Leave (CL)
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtCL" runat="server" CssClass="textbox" MaxLength="100" Width="45px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtCL_FilteredTextBoxExtender" runat="server" Enabled="True"
                    TargetControlID="txtCL" ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="labelcells" style="height: 16px">
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Sick Leave (SL)
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtSL" runat="server" CssClass="textbox" MaxLength="100" Width="45px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtSL_FilteredTextBoxExtender" runat="server" Enabled="True"
                    TargetControlID="txtSL" ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
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
                Without Pay(LWP)
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtWithoutPay" runat="server" CssClass="textbox" MaxLength="100"
                    Width="45px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtWithoutPay_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtWithoutPay" ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Absent
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtAbsent" runat="server" CssClass="textbox" MaxLength="100" Width="45px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtAbsent_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtAbsent" ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
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
                Holidays
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtHolidays" runat="server" CssClass="textbox" MaxLength="100" Width="45px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtHolidays_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtHolidays" ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
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
                WorkFromHome
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtworkfromhome" runat="server" CssClass="textbox" MaxLength="100" Width="45px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxadasExtender1" runat="server"
                    Enabled="True" TargetControlID="txtworkfromhome" ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
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
                Pay Days
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtPayDays" runat="server" CssClass="textbox" MaxLength="100" Width="45px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtPayDays_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtPayDays" ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPayDays"
                    Display="Dynamic" ErrorMessage="?" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkSave_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <%--<asp:LinkButton ID="lnkfreeeze" runat="server" CssClass="buttonc" 
                        onclick="lnkfreeeze_Click">Freeze</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <%--              <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" 
                            Width="950px">        
                <asp:GridView ID="grdDetail" runat="server" EmptyDataText="no record found" 
                      onrowdatabound="grdDetail_RowDataBound" >
                    <AlternatingRowStyle CssClass="GridAI" />
                    <Columns>
                        <asp:TemplateField HeaderText="SelectAll">
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkall" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="chkall_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" runat="server" AutoPostBack="True" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="Griditem" />
                </asp:GridView>
                    </asp:Panel>--%>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
