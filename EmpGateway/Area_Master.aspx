<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Area_Master.aspx.vb" Inherits="Default4" title="Area Master" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td colspan="4" class="tableheader">
                <asp:Label ID="Label5" runat="server" Text="Area Master" Width="295px"></asp:Label></td>
        </tr>
        <tr >
            <td class="labelcells" >
                <asp:Label ID="Label16" runat="server" Text="Area*"></asp:Label>
            </td>
            <td class="textcells"
                valign="top">
                <asp:DropDownList ID="ddlArea" runat="server" CssClass="combobox" Width="228px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlArea"
                    ErrorMessage="Area must be Selected" Width="2px" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
            <td class="labelcells" >
                <asp:Label ID="Label17" runat="server" Text="Area Name*" Width="120"></asp:Label>
            </td>
            <td class="textcells"
                valign="top">
                <asp:TextBox ID="txtAreaName" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAreaName"
                    ErrorMessage="Area Name must be Entered" Width="2px" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="4" class="buttonbackbar">
                <asp:Button ID="cmdSave" runat="server" Text="Save" CssClass="ButtonBack" BackColor="Black" /></td>
        </tr>
        <tr>
            <td align="right" colspan="4" style="text-align: left; height: 58px;" 
                >
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    ForeColor="Red" CssClass="GridItem"></asp:Label><br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" Width="100%" ShowMessageBox="True" CssClass="ValidationSummary" />
            </td>
        </tr>
    </table>
</asp:Content>

