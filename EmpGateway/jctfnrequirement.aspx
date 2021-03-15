<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="jctfnrequirement.aspx.vb" Inherits="jctfnrequirement" title="Function Format" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td 
                colspan="3" class="tableheader">
                <asp:Label ID="Label16" runat="server" Text="Function Requirement"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblfnname" runat="server"      
                    Text="Function Name"></asp:Label></td>
            <td class="textcells"  >
                <asp:DropDownList ID="ddlfnname" runat="server"    
                    Width="143px" CssClass="combobox">
                    <asp:ListItem>Diwali</asp:ListItem>
                    <asp:ListItem>New Year</asp:ListItem>
                </asp:DropDownList></td>
            <td class="textcells"  >
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblItemname" runat="server" Text="Item Name"></asp:Label></td>
            <td style="    width: 181px" class="textcells">
                <asp:DropDownList ID="ddlItemname" runat="server" AutoPostBack="True" 
                    Width="144px" CssClass="combobox">
                </asp:DropDownList></td>
            <td class="textcells"  >
                <asp:TextBox ID="txtothers" runat="server"  Visible="False" Width="138px" 
                    CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblUOM" runat="server" Text="UOM"></asp:Label></td>
            <td class="textcells"  >
                <asp:DropDownList ID="ddluom" runat="server" AutoPostBack="True" Width="144px" 
                    CssClass="combobox">
                </asp:DropDownList></td>
            <td class="textcells"  >
                <asp:TextBox ID="Txtuom" runat="server"  Visible="False"  Width="138px" 
                    CssClass="textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblRate" runat="server"      
                    Text="Rate"></asp:Label></td>
            <td class="textcells" >
                <asp:TextBox ID="txtrate" runat="server" Width="139px" CssClass="textbox"></asp:TextBox></td>
            <td class="textcells" >
            </td>
        </tr>
        <tr>
            <td   
                class="labelcells">
                <asp:Label ID="lblseq" runat="server"      
                    Text="Sequence"></asp:Label></td>
            <td class="textcells"  >
                <asp:TextBox ID="txtseq" runat="server" Width="139px" CssClass="textbox"></asp:TextBox></td>
            <td class="textcells"  >
            </td>
        </tr>
        <tr>
            <td style="    height: 27px" 
                class="buttonbackbar" colspan="3">
                <asp:Button ID="btnsubmit" runat="server" CssClass="ButtonBack" Text="Submit" />
            </td>
        </tr>
    </table>
</asp:Content>

