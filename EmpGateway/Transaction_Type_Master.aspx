<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Transaction_Type_Master.aspx.vb" Inherits="Default4" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 700px">
        <tr>
            <td colspan="4" class="tableheader">
            <asp:Label ID="Label5" runat="server" Text="Transaction Type Master" Width="295px"></asp:Label></td>
        </tr>
        <tr>
            <td class="labelcells">Transaction Type*
            <td
                valign="top" class="textcells">
                <asp:TextBox ID="txtSubArea" runat="server" CssClass="textbox" Font-Names="Tahoma" maxLength="30" Width="169px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubArea"
                    ErrorMessage="Sub Area must be Entered" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
            <td class="textcells" style="width: 436px">Name(Procedure)</td>
            <td>
                <asp:DropDownList ID="ddlArea" runat="server" CssClass="combobox" Width="214px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlArea"
                    ErrorMessage="Area must be Selected" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" background="Image/Gradient2.PNG" class="buttonbackbar" 
                colspan="4">
                <asp:Button ID="cmdSave" runat="server" CssClass="ButtonBack" Text="Save" />
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4" style="text-align: left">
                <asp:Label ID="lblError" runat="server" CssClass="GridItem" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Red" Width="56px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

