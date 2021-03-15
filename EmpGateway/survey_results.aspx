<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="survey_results.aspx.vb" Inherits="survey_results" title="Survey Results"  %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%">
        <tr>
            <td class="tableheader" colspan="3" >
                <asp:Label ID="Label1" runat="server" Text="Survey Results" Width="111px"></asp:Label></td>
        </tr>
        <tr>
            <td class="labelcells" style="width:100px">
                Department</td>
            <td class="textcells" colspan="2">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="241px" 
                    AutoPostBack="True" CssClass="combobox">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="labelcells" >
            </td>
            <td  class="textcells" colspan="2">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" CssClass="combobox" RepeatDirection="Horizontal" Width="251px">
                    <asp:ListItem Value="0">Internal</asp:ListItem>
                    <asp:ListItem Value="1">External</asp:ListItem>
                    <asp:ListItem>Both</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td class="labelcells" style="width:100px">
                <asp:Label ID="Label4" runat="server" Text="Subject" Width="64px"></asp:Label></td>
            <td colspan="2" style="font-family: Tahoma; font-size: 8pt; font-weight: bold; color: #000000" >
                <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left" ScrollBars="Vertical" Width="100%" >
                    <br />
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

