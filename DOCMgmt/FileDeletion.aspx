<%@ Page Title="" Language="VB" MasterPageFile="User_Screen.master" AutoEventWireup="false" CodeFile="FileDeletion.aspx.vb" Inherits="DOCMgmt_FileDeletion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label16" runat="server" Text="Delete File"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                File Deleted Successfully</td>
        </tr>
        <tr>
            <td class="buttonbackbar">
                <asp:LinkButton ID="LinkButton4" runat="server" CssClass="buttonc">OK</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

