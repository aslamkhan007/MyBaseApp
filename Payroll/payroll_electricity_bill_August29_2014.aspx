<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="payroll_electricity_bill.aspx.cs" Inherits="PayRoll_payroll_electricity_bill" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Electricity bill</td>
        </tr>
        <tr>
            <td class="NormalText">
                House Type</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlhousetype" runat="server" 
                    OnSelectedIndexChanged="ddlhousetype_SelectedIndexChanged" AutoPostBack="True" 
                    CssClass="combobox">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlhousetype" ErrorMessage="*" ValidationGroup="A">
                    </asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                Employee</td>
            <td class="NormalText">
                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" 
                    AutoPostBack="True" ValidationGroup="A"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" 
                    CompletionListCssClass="autocomplete_ListItem1"
                    Enabled="True" ServiceMethod="GetEmployee_sh" ServicePath="~/WebService.asmx" 
                    TargetControlID="txtEmployee" MinimumPrefixLength="1">
                </cc1:AutoCompleteExtender>
                <asp:LinkButton ID="lnkse" runat="server" CssClass="searchbluesmall" 
                    Height="16px" onclick="LinkButton1_Click" Width="16px" ValidationGroup="B">LinkButton</asp:LinkButton>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtEmployee" ValidationGroup="B"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
             <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" 
                    Visible="False" Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" 
                    Width="100%" EnableModelValidation="True" 
                        onrowdatabound="grdDetail_RowDataBound" AutoGenerateColumns="False" 
  >
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chksel" runat="server" 
                                        oncheckedchanged="chksel_CheckedChanged" Text="SelectAll" 
                                        AutoPostBack="True" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="True" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Employee" HeaderText="Employee" />
                            <asp:BoundField DataField="Department" HeaderText="Department" />
                            <asp:BoundField DataField="Designation" HeaderText="Designation" />
                            <asp:BoundField DataField="House_Type" HeaderText="HouseType" />
                              <asp:BoundField DataField="House_no" HeaderText="HouseNo" />
                            <asp:TemplateField HeaderText="Units">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtunits" runat="server" CssClass="textbox" 
                                        AutoPostBack="True" ontextchanged="txtunits_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtunits_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtunits" 
                                        ValidChars=".0123456789">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UnitRate">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtunitrate" runat="server" CssClass="textbox" 
                                        Text='<%# Eval("unitrate") %>' Enabled="False"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtunitrate_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtunitrate" 
                                        ValidChars=".0123456789">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtamount" runat="server" CssClass="textbox" Enabled="False"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:CheckBox ID="chk" runat="server" />
                        </EmptyDataTemplate>
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="lnksave_Click" ValidationGroup="A">Save</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

