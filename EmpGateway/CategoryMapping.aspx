<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="CategoryMapping.aspx.vb" Inherits="CategoryMapping" title="Category Designation Mapping" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label5" runat="server" Text="Category-Designation Mapping"
                    Width="328px"></asp:Label></td>
        </tr>
        <tr>
            <td class="labelcells"><span style="font-size: 8pt; font-family: Tahoma"><strong>
                <asp:Label ID="Label16" runat="server" Text="Select Designation"></asp:Label>
                </strong></span></td>
            <td style="width: 14%" class="labelcells">
            </td>
            <td class="labelcells">
                <asp:Label ID="Label17" runat="server" Text="Select Category"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:DropDownList ID="DrpDesig" runat="server" Width="161px" 
                    CssClass="combobox">
                    <asp:ListItem>Clerks</asp:ListItem>
                    <asp:ListItem>Asst. Officer</asp:ListItem>
                    <asp:ListItem>Officer</asp:ListItem>
                    <asp:ListItem>Asst. Manager</asp:ListItem>
                    <asp:ListItem>Deputy Manager</asp:ListItem>
                    <asp:ListItem>Manager</asp:ListItem>
                    <asp:ListItem>Asst. General Manager</asp:ListItem>
                    <asp:ListItem>Deputy General Manager</asp:ListItem>
                    <asp:ListItem>HOD</asp:ListItem>
                </asp:DropDownList></td>
            <td>
                <asp:Button ID="cmdMap" runat="server" Text="Map" CssClass="ButtonBack" /></td>
            <td class="labelcells">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" Width="202px">
                </asp:CheckBoxList></td>
        </tr>
    </table>
</asp:Content>

