<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Loan_Rate_Master.aspx.cs" Inherits="Payroll_Loan_Rate_Master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Loans Rate Master</td>
        </tr>
       
        <tr>
            <td class="labelcells">
                Type Of Loan</td>
            <td class="NormalText">
           <%--    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>--%>
                <asp:DropDownList ID="ddlLoanType" runat="server" CssClass="combobox" DataTextField="Deduction_Long_Description" 
                    DataValueField="Deduction_code"  
                    onselectedindexchanged="ddlLoanType_SelectedIndexChanged" AutoPostBack="True" 
                    >
                </asp:DropDownList>

                   <%--                            </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
       
<%--        <tr>
            <td class="labelcells">
            <asp:Label ID="lblBankName" runat="server" Text="BankName" Visible="False"></asp:Label>
            </td>
            <td class="NormalText">

                <asp:DropDownList ID="ddlBankName" runat="server" CssClass="combobox" 
                    datasourceid="SqlDataSource2" DataTextField="description" 
                    DataValueField="Bank_code" Visible="False">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT Bank_code,description FROM dbo.JCT_payroll_bank_master WHERE status = 'A'">
                </asp:SqlDataSource>

            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>--%>
       
        <tr>
            <td class="labelcells" style="height: 16px">
                Calculation Method</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlCalculationMethod" runat="server" CssClass="combobox" DataTextField="location" 
                    DataValueField="locationCode" AutoPostBack="True" 
                    onselectedindexchanged="ddlCalculationMethod_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="labelcells" style="height: 16px">
                </td>
            <td class="NormalText">
                </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 16px">
                Rate Of Interest</td>
            <td class="NormalText">
                <asp:TextBox ID="txtRate" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtRate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells" style="height: 16px">
                </td>
            <td class="NormalText">
                </td>
        </tr>
        <tr>
            <td class="labelcells">
                Effective From
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txteff_from" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteff_from_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteff_from">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txteff_from" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;Effective To&nbsp;</td>
            <td class="NormalText">
                <asp:TextBox ID="txteff_to" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteff_to_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteff_to">
                </cc1:CalendarExtender>
            </td>
        </tr>
             <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                    onclick="lnkadd_Click" ValidationGroup="A">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    onclick="lnkupdate_Click" ValidationGroup="A">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkdelete" runat="server" CssClass="buttonc" 
                    onclick="lnkdelete_Click" ValidationGroup="A">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
             <tr>
            <td class="NormalText" colspan="4">
               <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" 
                    Visible="False" Width="1000px">
                 
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    Width="100%" 
    onselectedindexchanged="grdDetail_SelectedIndexChanged">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
            
                </asp:Panel>
                      <%--                                   </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
       
       
       
        </tr>
    </table>
</asp:Content>
