<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Sub_Area_Master.aspx.vb" Inherits="Default6" Title="Sub-Area Master" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td colspan="4" class="tableheader">
                <asp:Label ID="Label5" runat="server" BorderColor="Transparent" Text="Sub Area Master"
                    Width="295px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Area
            </td>
            <td class="textcells">
                <asp:DropDownList ID="ddlArea" runat="server" CssClass="combobox" Width="214px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlArea"
                    ErrorMessage="Area must be Selected" SetFocusOnError="True">*</asp:RequiredFieldValidator><span
                        style="background-color: #f5f5f5"></span>
            </td>
            <td class="labelcells" style="width: 184px">
                Sub Area Name
            </td>
            <td class="textbox" >
                <asp:TextBox ID="txtSubArea" runat="server" Font-Names="Tahoma" MaxLength="100" Width="169px" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubArea"
                    ErrorMessage="Sub Area must be Entered" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4" >
                <asp:Button ID="cmdSave" runat="server" Text="Save" CssClass="ButtonBack" BackColor="Black" />
            </td>
        </tr>
        <tr>
            <td >
            </td>
            <td  style="width: 475px">
                <input id="TxtSrchDate" onfocus="showCalendarControl(this);" type="text" name="todays_date"
                    runat="server" visible="false">
            </td>
            <td  colspan="2" style="text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" colspan="4" style="text-align: left">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    ForeColor="Red" CssClass="GridItem"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" Font-Names="Tahoma"
        Font-Size="8pt" Width="696px" CssClass="ValidationSummary" Height="52px" ShowMessageBox="True" />
</asp:Content>
