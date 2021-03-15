<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_LostLien.aspx.cs" Inherits="Payroll_Jct_Payroll_LostLien" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="4">
                LostLein/Restore
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Action</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlReporttype" runat="server" CssClass="combobox" 
                    OnSelectedIndexChanged="ddlReporttype_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Selected="True">LostLien</asp:ListItem>
                    <asp:ListItem>Restore</asp:ListItem>                   
                </asp:DropDownList>
            </td>
            <td class="labelcells">
            </td>
            <td class="NormalText">
            </td>
        </tr>
       
        <tr>
            <td class="labelcells">
                Empcode</td>
            <td class="NormalText">
                <asp:TextBox ID="txtCardNo" runat="server" AutoPostBack="True" CssClass="textbox"
                    MaxLength="100" OnTextChanged="txtCardNo_TextChanged" Width="45px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtCardNo_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtCardNo" ValidChars="1234567890">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="Reqcardno" runat="server" ControlToValidate="txtCardNo"
                    Display="Dynamic" ErrorMessage="Empcode ?" ValidationGroup="A"></asp:RequiredFieldValidator>
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
                EmployeeName</td>
            <td class="NormalText">
                <asp:Label ID="lblname" runat="server" CssClass="labelcells"></asp:Label>
            </td>
            <td class="labelcells">
                FatherName</td>
            <td class="NormalText">
                <asp:Label ID="lblDesignation" runat="server" CssClass="labelcells"></asp:Label>
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
                &nbsp;</td>
            <td class="NormalText">
                <%-- <asp:DropDownList ID="ddlsubdepartment" runat="server" CssClass="combobox" 
                    AutoPostBack="True">
                </asp:DropDownList>--%>
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
            <td class="labelcells">
                MarkingDate</td>
            <td class="NormalText">
                <asp:TextBox ID="txtfromdate" runat="server" CssClass="textbox" Width="70px" AutoPostBack="True"
                    ></asp:TextBox>
                <cc1:CalendarExtender ID="txtfromdate_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtfromdate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfromdate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                RestoreDate
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
                Reason</td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="TxtOvertimeReason" runat="server" CssClass="textbox" 
                    MaxLength="40" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="TxtOvertimeReason" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" 
                    TargetControlID="TxtOvertimeReason" WatermarkCssClass="watermark" 
                    WatermarkText="Give the appropriate reason here">
                </cc1:TextBoxWatermarkExtender>
            </td>
        </tr>

        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkSave_Click">Apply</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="lnkreset0" runat="server" CssClass="buttonc" 
                    CausesValidation="False" onclick="lnkreset0_Click"
                    >Report</asp:LinkButton>
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
