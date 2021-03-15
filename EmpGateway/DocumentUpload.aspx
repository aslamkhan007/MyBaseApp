<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="DocumentUpload.aspx.vb" Inherits="DocumentUpload" title="Upload Document" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="2" id="100%" >
                <asp:Label ID="Label6" runat="server" Text="Document Upload" Width="108px"></asp:Label></td>
        </tr>
   
        <tr>
            <td colspan="1" class="labelcells">
                <asp:Label ID="lbldoc" runat="server" Text="Document :" Width="112px"></asp:Label></td>
            <td colspan="1" class="textbox">
                <asp:DropDownList ID="ddldoc" runat="server" Width="129px" CssClass="combobox">
                    <asp:ListItem Value="F">Forms</asp:ListItem>
                    <asp:ListItem Value="O">Office Order</asp:ListItem>
                    <asp:ListItem Value="T">Training Material</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="1" class="labelcells">
                <asp:Label ID="Label1" runat="server" Text="Department :" Width="112px"></asp:Label></td>
            <td colspan="3" style="height: 18px; background-color: whitesmoke" 
                class="textcells">
                <asp:DropDownList ID="ddldept" runat="server" Width="286px" CssClass="combobox">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="1" class="labelcells">
                <asp:Label ID="Label2" runat="server" Text="Type :" Width="112px"></asp:Label></td>
            <td colspan="1" class="textcells">
                <asp:RadioButtonList ID="RLtype" runat="server" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Black" Height="25px" RepeatDirection="Horizontal"
                    Width="209px">
                    <asp:ListItem Selected="True" Value="I">Internal</asp:ListItem>
                    <asp:ListItem Value="E">External</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td colspan="1" class="labelcells" style="height: 22px">
                <asp:Label ID="Label3" runat="server" Text="Attach File :" Width="112px"></asp:Label></td>
            <td colspan="1">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="183px" 
                    CssClass="textbox" Height="21px" />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:Button ID="btnsub" runat="server" CssClass="ButtonBack" Text="Submit" BackColor="Black" />
            </td>
        </tr>
    </table>
</asp:Content>

