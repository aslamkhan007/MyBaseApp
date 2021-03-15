<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Payroll_Salary_Earnings_Deductions_Report.aspx.cs" Inherits="Payroll_Payroll_Salary_Earnings_Deductions_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function SetContextKey() {
            $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlLocation.ClientID %>").value);
        }
    </script>
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Earnings Deductions Report:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                YearMonth</td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txttodate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    AutoPostBack="True" onselectedindexchanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Location
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Component Type</td>
            <td class="NormalText">
                <%--<asp:DropDownList ID="ddlParamType" runat="server" CssClass="combobox" 
                    onselectedindexchanged="ddlParamType_SelectedIndexChanged">
                </asp:DropDownList>--%>
                <asp:DropDownList ID="ddlComponentType" runat="server" AutoPostBack="True" CssClass="combobox"
                    ToolTip="Specify The Type of Earnings/Deductions" OnSelectedIndexChanged="ddlComponentType_SelectedIndexChanged">
                    <asp:ListItem>Earning</asp:ListItem>
                    <%--<asp:ListItem>Reimbursement</asp:ListItem>--%>
                    <asp:ListItem>Deduction</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Component Name</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlReportType" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Department
            </td>
            <td class="NormalText">
                <%--      <cc1:FilteredTextBoxExtender ID="Flt1" runat="server" Enabled="True" 
                    FilterType="Numbers" TargetControlID="txtSaviorcardno">
                </cc1:FilteredTextBoxExtender>--%>
                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                EmployeeName
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtSaviorcardno" runat="server" AutoPostBack="true" CssClass="textbox"
                    onkeyup="SetContextKey()" OnTextChanged="txtSaviorcardno_TextChanged" 
                    Width="250px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5"
                    ServiceMethod="LocationWIse_Employee" ServicePath="~/WebService.asmx" TargetControlID="txtSaviorcardno"
                    UseContextKey="True">
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" 
                    OnClick="lnkexcel_Click" Width="32px"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
               
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="tableheader" colspan="4">
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found" EnableModelValidation="True">
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
