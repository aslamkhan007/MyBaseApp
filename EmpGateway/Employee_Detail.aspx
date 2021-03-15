<%@ Page Title="" Language="VB" MasterPageFile="~/EmpGateway/MasterPage.master" AutoEventWireup="false" CodeFile="Employee_Detail.aspx.vb" Inherits="EmpGateway_Employee_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="3">
                <asp:Label ID="Label16" runat="server" Text="Employee Detail"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 48px">
                <asp:Label ID="Label17" runat="server" Font-Bold="False" 
                    Text="Enter ANY DETAIL LIKE EMPLOYEE CODE, CARDNO , PHONE NUMBER , OFFICE NUMBER ,RESIDENCE NUMBER ETC."></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:TextBox ID="txtCommon" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc">SEARCH</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server">
                    <asp:GridView ID="GridView1" runat="server" style = "width:100%;">
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </asp:Panel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

