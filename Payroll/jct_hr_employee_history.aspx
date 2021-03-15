<%@ Page Title="" Language="VB" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="false" CodeFile="jct_hr_employee_history.aspx.vb" Inherits="Payroll_jct_hr_employee_history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Employee History
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label18" runat="server" CssClass="labelcells" 
                    Text="EmployeeCode"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtempcode" runat="server" CssClass="textbox" MaxLength="7" 
                    Width="80px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label19" runat="server" CssClass="labelcells" Text="Period"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="txtperiod" runat="server" 
                    CssClass="combobox" Width="90px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="buttonbackbar">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" class="buttonbackbar">
             <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                        <asp:LinkButton ID="lnk_fetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnk_excel" runat="server" CssClass="buttonc">XL</asp:LinkButton>
                    <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="buttonbackbar">
               
                        <asp:GridView ID="GridView2" runat="server" Width="100%">
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
               
            </td>
        </tr>
    </table>
</asp:Content>

