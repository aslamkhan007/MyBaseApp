<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="payroll_emp_earnings.aspx.cs" Inherits="PayRoll_payroll_emp_earnings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="2">
                Employee Earnings
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:ImageButton ID="ImageOfficial" runat="server" ImageUrl="~/Image/Official_Info.png"
                    OnClick="ImageOfficial_Click" ValidationGroup="A" />
                <asp:ImageButton ID="ImagePersonal" runat="server" ImageUrl="~/Image/Personal_Info.png"
                    OnClick="ImagePersonal_Click" ValidationGroup="A" />
                <asp:ImageButton ID="ImageEarnings" runat="server" ImageUrl="~/Image/Earnings_Info_Red.png"
                    OnClick="ImageEarnings_Click" ValidationGroup="A" />
                <asp:ImageButton ID="ImageDeductions" runat="server" ImageUrl="~/Image/Deductions_Info.png"
                    OnClick="ImageDeductions_Click" ValidationGroup="A" />
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" style="font-size: 16px;" colspan="2">
                DESIGNATION:
                <asp:DropDownList ID="ddldesigin" runat="server" AutoPostBack="True" CssClass="combobox"
                    OnSelectedIndexChanged="ddldesigin_SelectedIndexChanged1">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table class="mytable">
        <%--   <tr>
            <td style="width: 210px" class="labelcells">
                BASIC PAY
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtbasic" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtbasic_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtbasic" ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="Reqbasic" runat="server" ControlToValidate="txtbasic"
                    ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>--%>
        <%--        <tr>
            <td style="width: 210px" class="labelcells">
                STANDARD SPECIAL ALLOWANCE
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtscooterallowance" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtscooterallowance_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtscooterallowance" ValidChars=".1234567890-">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="Reqscooterallowance" runat="server" ControlToValidate="txtscooterallowance"
                    ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells" style="width: 59px">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>--%>
    </table>
    <table class="mytable">
        <tr>
            <td colspan="2">
                <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound">
                    <ItemTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td width="200px" class="labelcells">
                                    <asp:Label ID="lballw" runat="server" Text='<%# Eval("allowances") %>' CssClass="labelcells"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbprmID" runat="server" Text='<%# Eval("Sr_no") %>' Visible="False"></asp:Label>
                                </td>
                                <td width="200px" class="NormalText">
                                    <asp:TextBox ID="txtallw" runat="server" CssClass="textbox" Visible="False" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtallw_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtallw" ValidChars=".1234567890-">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="Reqallw" runat="server" ControlToValidate="txtallw"
                                        ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:DropDownList ID="ddlallw" runat="server" CssClass="combobox" Visible="False"
                                        Width="80">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <td class="buttonbackbar">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="B">Save</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server"  Visible =false >
        <table class="mytable">
            <tr>
                <td class="NormalText" colspan="4">            
                        <asp:GridView ID="GridExtTask" runat="server" CssClass="table" Width="1000px" 
                            Height="25%" Caption="Wrong Mapped Records">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerStyle CssClass="PageStyle" />
                            <RowStyle CssClass="GridItem" />
                            <Columns>
                            </Columns>
                            <EmptyDataTemplate>
                                <h4>
                                    No Record To Show</h4>
                            </EmptyDataTemplate>
                        </asp:GridView>
                 
                </td>
            </tr>
             <tr>
                <td class="buttonbackbar" >
                    <asp:LinkButton ID="lnkapply" runat="server" CssClass="buttonc" OnClick="lnkapply_Click">Delete</asp:LinkButton>
                </td>
            </tr>
           
        </table>
    </asp:Panel>
</asp:Content>
