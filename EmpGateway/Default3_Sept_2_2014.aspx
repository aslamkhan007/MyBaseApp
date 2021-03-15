<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Default3.aspx.vb" Inherits="Default3" Title="Medical Reimbursement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 490px">
        <tr>
            <td colspan="2" class="tableheader">
                <asp:Label ID="Label1" runat="server" 
                    Text="Medical Reimbursement / Bill Wise Medicine Detail" Width="371px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" rowspan="2" class="panelcells">
                 <asp:GridView ID="GridView1" runat="server" AllowPaging="True"  
                       CssClass="GridViewStyle" GridLines="None"    Width="100%"  Height="100%">
                   <RowStyle CssClass="RowStyle" />

    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
                 <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                     CssClass="GridViewStyle" GridLines="None" Height="100%" ShowFooter="True" 
                     Width="100%">
                     <RowStyle CssClass="RowStyle" />
                     <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                     <PagerStyle CssClass="PagerStyle" />
                     <SelectedRowStyle CssClass="SelectedRowStyle" />
                     <HeaderStyle CssClass="HeaderStyle" />
                     <EditRowStyle CssClass="EditRowStyle" />
                 </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
