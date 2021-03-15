<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Task_Type_Master.aspx.vb" Inherits="Task_Type_Master" title="Task Type Master" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 700px">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label5" runat="server" Text="Task Type Master"  Width="295px"></asp:Label></td>
        </tr>
        <tr >
            <td class="labelcells">
                Task Type*
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtTaskType" runat="server" CssClass="textbox" MaxLength="30" Width="169px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubArea"
                    ErrorMessage="Sub Area must be Entered" SetFocusOnError="True">*</asp:RequiredFieldValidator>
               </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:Button ID="cmdSave" runat="server" CssClass="ButtonBack" Text="Save"/>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="labelcells">
                <asp:Label ID="lblError" runat="server" CssClass="GridItem" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Red" Width="56px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

