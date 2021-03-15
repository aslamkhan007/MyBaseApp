<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Reimbursement_Entry.aspx.cs" Inherits="Payroll_Jct_Payroll_Reimbursement_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Conveyance And Entertainment Reimbursement :
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                YearMonth
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
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
                FromDate
            </td>
            <td class="NormalText">                
                <asp:TextBox ID="txtfromdate" runat="server" CssClass="textbox" 
                    ></asp:TextBox>
                <cc1:CalendarExtender ID="txtfromdate_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtfromdate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfromdate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                

            </td>
            <td class="NormalText">
                ToDate
            </td>
            <td class="NormalText">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" ></asp:TextBox>
                <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="TextBox1">
                </cc1:CalendarExtender>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1s" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
           
            </td>
        </tr>

        <tr>
            <td class="NormalText">
                Search Emplyoee Name
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnTextChanged="txtEmployee_TextChanged" Width="300px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="LocationWIse_Employee" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee"
                    UseContextKey="True">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="NormalText">
                <asp:Label ID="employeename" runat="server" Text="Employee Name"></asp:Label>
            </td>
            <td class="NormalText">
                &nbsp;<asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Reimbursement Type
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldedtype" runat="server" AutoPostBack="True" CssClass="combobox"
                    OnSelectedIndexChanged="ddldedtype_SelectedIndexChanged" AppendDataBoundItems="True"
                    DataTextField="Deduction_Short_Description" DataValueField="Deduction_code">
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
                <asp:Label ID="Companytext" runat="server" Text="CompanyName"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:Label ID="lblCompanyname" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td class="NormalText" runat="server" text="Desigination">
                <asp:Label ID="dept" runat="server" Text="Department"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:Label ID="lbdept" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="Designation" runat="server" Text="Desigination"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:Label ID="lbdesign" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td class="NormalText" runat="server" text="Desigination">
                <asp:Label ID="Label9" runat="server" Text="Place of Entertainment" Visible="False"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtCity" runat="server" CssClass="textbox" AutoPostBack="True" Width="150px"
                    Visible="False"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtCity_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="autocomplete_ListItem1" Enabled="True" TargetControlID="txtCity"
                    ServiceMethod="GetPayrollCity" ServicePath="~/WebService.asmx" MinimumPrefixLength="3">
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
   
       <%-- <tr>
            <td class="NormalText">
                Number Of Months
            </td>
            <td class="NormalText">
                <asp:Label ID="lblMonths" runat="server"></asp:Label>
                <br />
            </td>
            <td class="NormalText">
                Amount
            </td>
            <td class="NormalText">
                <asp:Label ID="lbldedamount" runat="server"></asp:Label>
            </td>
        </tr>--%>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                  ValidationGroup="A"  OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <%--<asp:LinkButton ID="lnkUpdate" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkUpdate_Click" Visible="False">Update</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EnableModelValidation="True" Width="100%">
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
