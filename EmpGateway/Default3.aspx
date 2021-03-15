<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Default3.aspx.vb" Inherits="Default3" Title="Medical Reimbursement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 490px">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label1" runat="server" 
                    Text="Medical Reimbursement / Bill Wise Medicine Detail" Width="371px"></asp:Label>
            </td>
        </tr>
        </table>
    <table style="width: 490px">
        <tr>
            <td class="NormalText" style="width: 103px">
                Year</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True">
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                Month</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="01">January</asp:ListItem>
                    <asp:ListItem Value="02">February</asp:ListItem>
                    <asp:ListItem Value="03">March</asp:ListItem>
                    <asp:ListItem Value="04">April</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">June</asp:ListItem>
                    <asp:ListItem Value="07">July</asp:ListItem>
                    <asp:ListItem Value="08">August</asp:ListItem>
                    <asp:ListItem Value="09">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        </table>
    <table style="width: 490px">
        <tr>
            <td rowspan="2" class="panelcells">
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
                     Width="100%" EmptyDataText="No Record Found ...">
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
