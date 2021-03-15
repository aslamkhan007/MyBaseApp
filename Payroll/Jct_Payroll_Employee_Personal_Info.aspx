<%@ Page Title="" Language="VB" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="false" CodeFile="Jct_Payroll_Employee_Personal_Info.aspx.vb" Inherits="Payroll_Jct_Payroll_Employee_Personal_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="2" class="tableheader">
                <asp:Label ID="Label1" runat="server" Text="Employee Personal Info" Width="177px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" rowspan="2" class="labelcells">
                <asp:DetailsView ID="DetailsView1" runat="server" GridLines="None" Height="40px"
                    Width="100%" BorderColor="DimGray" BorderStyle="Solid" BorderWidth="2px" CellPadding="3">
                    <RowStyle CssClass="GridItem" />
                    <PagerStyle CssClass="gridheader" />
                    <FieldHeaderStyle CssClass="DetailField" />
                    <AlternatingRowStyle CssClass="GridAI" />
                </asp:DetailsView>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
