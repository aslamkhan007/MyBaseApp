<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Payroll_Medical_Reimbursement_Authorization.aspx.cs" Inherits="Payroll_Payroll_Medical_Reimbursement_Authorization" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader">
                Medical Reimbursement Authorization :
            </td>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <td class="labelcells">
                YearMonth
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" AutoPostBack="True" CssClass="combobox"
                    OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Location
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True" CssClass="combobox"
                    OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table class="NormalText">
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label2" runat="server" Text="Pending :"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlgrid" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">
        <asp:GridView ID="grdDetail" runat="server" Width="100%" EmptyDataText="No Record Found ..."
            EnableModelValidation="True" AutoGenerateColumns="False">
            <AlternatingRowStyle CssClass="GridAI" />
            <SelectedRowStyle CssClass="SelectedRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <RowStyle CssClass="GridItem" />
            <Columns>
                <asp:TemplateField HeaderText="Authorize">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgSaveRecord" runat="server" ImageUrl="~/Image/Icons/Action/document_save.png"
                            CommandName="Sendmail" Width="20" Height="20" OnClick="ImgSaveRecord_Click" ValidationGroup="A" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Check">
                    <HeaderTemplate>
                        <asp:CheckBox ID="ChkOrderSelAll" runat="server" AutoPostBack="True" OnCheckedChanged="ChkOrderSelAll_CheckedChanged"
                            Visible="False" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkCheck" Visible="False" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="YearMonth" HeaderText="YearMonth" />
                <asp:BoundField DataField="EmployeeCode" HeaderText="EmployeeCode" />
                <asp:BoundField DataField="EmployeeName" HeaderText="EmployeeName" />
                <asp:BoundField DataField="Designation" HeaderText="Designation" />
                <asp:BoundField DataField="Department" HeaderText="Department" />
                <asp:BoundField DataField="BalanceAmount" HeaderText="BalanceAmount" />
                <asp:BoundField DataField="RaisedAmount" HeaderText="RaisedAmount" />
                <asp:TemplateField HeaderText="Authorized Amount">
                    <ItemTemplate>
                        <asp:TextBox ID="txtunmapdate" runat="server" CssClass="textbox" Width="70px" Visible="True"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtBasic_FilteredTextBoxExtender" runat="server"
                            Enabled="True" TargetControlID="txtunmapdate" ValidChars=".0123456789">
                        </cc1:FilteredTextBoxExtender>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="100px" Visible="True"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <table class="mytable">
        <tr>
            <td class="buttonbackbar">
                <%--<asp:LinkButton ID="lnkConfirmAll" runat="server" CssClass="buttonc" OnClick="lnkConfirmAll_Click">Authorize All</asp:LinkButton>--%>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" OnClick="lnkReset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label1" runat="server" Text="Authorized:"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">
        <asp:GridView ID="GridView1" runat="server" Width="100%" EmptyDataText="No Record Found ..."
            EnableModelValidation="True">
            <AlternatingRowStyle CssClass="GridAI" />
            <SelectedRowStyle CssClass="SelectedRowStyle" />
            <HeaderStyle CssClass="GridHeader" />
            <RowStyle CssClass="GridItem" />
        </asp:GridView>
    </asp:Panel>
</asp:Content>
