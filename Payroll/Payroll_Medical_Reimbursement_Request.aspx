<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Payroll_Medical_Reimbursement_Request.aspx.cs" Inherits="Payroll_Payroll_Medical_Reimbursement_Request" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Medical Reimbursement Request:
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                YearMonth
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px" 
                    Enabled="False"></asp:TextBox>
                <%--<asp:ListItem Selected="True"></asp:ListItem>--%>
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
            <td class="labelcells">
                Search Emplyoee Name
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnTextChanged="txtEmployee_TextChanged" Width="200px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10"
                    CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" MinimumPrefixLength="3"
                    ServiceMethod="GetEmployee_sh" ServicePath="~/WebService.asmx" TargetControlID="txtEmployee">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="employeename" runat="server" Text="Employee Name"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="dept" runat="server" Text="Department"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbdept" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Designation" runat="server" Text="Desigination"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbdesign" runat="server"></asp:Label>
            </td>
            <td id="Td1" class="labelcells" runat="server" text="Desigination">
                <asp:Label ID="basic" runat="server" Text="Basic"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblbasic" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdGrdDetail" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdDetail" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                            OnRowCommand="grdDetail_RowCommand" OnRowDataBound="grdDetail_RowDataBound" Width="100%">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Remove" ImageUrl="~/Image/Icons/close.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CashMemoNumber">
                                    <ItemTemplate>
                                        <telerik:RadTextBox ID="txtCashMemoNumber" runat="server" CausesValidation="True"
                                            Culture="en-US" DbValueFactor="1" LabelWidth="32px" MaxLength="10" MaxValue="100"
                                            MinValue="1" ValidationGroup="mandatory" Width="250">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCashMemoNumber"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True"
                                            ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <telerik:RadDatePicker ID="txtAcqDt" runat="server" DateFormat="MM/dd/yyyy" DateInput-CausesValidation="True"
                                            DateInput-EmptyMessage="MM-DD-YY" MinDate="01/01/1940" Width="150">
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ID="ReqtxtAcqDt" runat="server" ControlToValidate="txtAcqDt"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True"
                                            ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <telerik:RadNumericTextBox ID="txtAmount" runat="server" CausesValidation="True"
                                            Culture="en-US" DataType="System.Int32" DbValueFactor="1" EmptyMessage="Invalid Quantity"
                                            InputType="Number" LabelWidth="32px" MaxLength="10" MinValue="1" ValidationGroup="mandatory"
                                            Width="150">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAmount"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True"
                                            ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="PageStyle" />
                            <RowStyle CssClass="Griditem" />
                            <SelectedRowStyle CssClass="GridRowGreen" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkApply" runat="server" CssClass="buttonc" ValidationGroup="A"
                            OnClick="lnkApply_Click">Save</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" OnClick="lnkReset_Click">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkaddrow" runat="server" CssClass="buttonc" OnClick="lnkaddrow_Click">AddRow</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdateRecordgrid" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="1000px">
                            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="True"
                                OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgDelRows" runat="server" CausesValidation="True" ImageUrl="~/Image/Icons/close.png"
                                                CommandName="deleterow" ValidationGroup='<%# "Group_" + Container.DataItemIndex %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="GirdItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
