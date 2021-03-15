<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="jctfunction.aspx.vb" Inherits="jctfunction" title="Function Format" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label16" runat="server" Text="Define Function Master"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblfnname" runat="server" Text="Function Name" ></asp:Label></td>
            <td class="textcells" >
                <asp:DropDownList ID="ddlfnname" runat="server"     Width="122px" 
                    CssClass="combobox">
                    <asp:ListItem>New year</asp:ListItem>
                    <asp:ListItem>Diwali</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="labelcells" >
                <asp:Label ID="lblparamtrname" runat="server" Text="Parameter Name" ></asp:Label></td>
            <td class="textcells"  >
                <asp:DropDownList ID="ddlparamtrname" runat="server" Width="122px" 
                    CssClass="combobox"    >
                    <asp:ListItem>To</asp:ListItem>
                    <asp:ListItem>ToOf</asp:ListItem>
                    <asp:ListItem>ToCity</asp:ListItem>
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>Date</asp:ListItem>
                    <asp:ListItem>Venue</asp:ListItem>
                    <asp:ListItem>Time</asp:ListItem>
                    <asp:ListItem>Month</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblparamtrvalue" runat="server" Text="parameter Value" ></asp:Label></td>
            <td class="textcells">
                <asp:TextBox ID="txtparamtrvalue" runat="server" CssClass="textbox" ></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td> 
                <asp:Button ID="btnsub" runat="server" CssClass="ButtonBack" Text="Submit" /></td>
        </tr>
    </table>
</asp:Content>

