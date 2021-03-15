<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Transaction_Type_Mapping.aspx.vb" Inherits="Transaction_Type_Mapping"
    Title="Mapping" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 700px">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label5" runat="server" ForeColor="White" Text="Transaction Type Mapping"
                    Width="295px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Area*
            </td>
            <td valign="top" class="textcells">
                <asp:DropDownList ID="ddlArea" runat="server" Font-Names="Tahoma" Font-Size="8pt"
                    ForeColor="#404040" Width="187px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSubArea"
                    ErrorMessage="Sub Area must be Entered" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
            <td class="textcells">
                Sub Area*
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="combobox" Width="187px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlArea"
                    ErrorMessage="Area must be Selected" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Transaction Type*
            </td>
            <td bgcolor="whitesmoke" style="font-family: Times New Roman; height: 1px" valign="top"
                colspan="3">
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="combobox" Width="187px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubArea"
                    ErrorMessage="Sub Area must be Entered" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" background="Image/Gradient2.PNG" class="buttonbackbar" colspan="4">
                <asp:Button ID="cmdSave" runat="server" CssClass="ButtonBack" Text="Save" />
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4" style="height: 5px; text-align: left">
                <asp:Label ID="lblError" runat="server" CssClass="GridItem" Font-Bold="True" Font-Names="Tahoma"
                    Font-Size="8pt" ForeColor="Red" Width="56px"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
