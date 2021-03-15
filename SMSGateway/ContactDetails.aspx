<%@ Page Title="" Language="VB" MasterPageFile="~/SMSGateway/MasterPage.master" AutoEventWireup="false"
    CodeFile="ContactDetails.aspx.vb" Inherits="SMSLive_ContactDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                &nbsp;Contact Details
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label16" runat="server" Text="Contact Type"></asp:Label>
            </td>
            <td class="textcells">
                <asp:DropDownList ID="ddlContactType" runat="server" CssClass="combobox" AutoPostBack="True">
                    <asp:ListItem>Customer</asp:ListItem>
                    <asp:ListItem>Employee</asp:ListItem>
                    <asp:ListItem>Supplier</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label18" runat="server" Text="Contact Code"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtContactCode" runat="server" Columns="7" CssClass="textbox" Enabled="False"></asp:TextBox>
            </td>
            <td class="labelcells">
                <asp:Label ID="Label17" runat="server" Text="Contact Name"></asp:Label>
            </td>
            <td class="textcells" valign="top">
                <asp:TextBox ID="txtContactName" runat="server" Columns="30" CssClass="textbox"></asp:TextBox>
                <asp:LinkButton runat="server" CssClass="search" Height="20px" Width="26px" 
                    ID="cmdSearch"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label31" runat="server" Text="Date of Birth"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox AccessKey="d" ID="TxtDOB" TabIndex="3" runat="server" Width="70px" CssClass="textbox"
                    MaxLength="8"></asp:TextBox>
                <cc1:MaskedEditValidator ID="MaskedEditValidator5" runat="server" Width="114px" ControlToValidate="TxtDOB"
                    Display="Dynamic" ControlExtender="MaskedEditExtender5" TooltipMessage="MM/DD/YYYY"
                    IsValidEmpty="False" EmptyValueMessage="*" InvalidValueMessage="The Date is invalid"></cc1:MaskedEditValidator>
                <cc1:CalendarExtender ID="CalFrom1" runat="server" TargetControlID="TxtDOB" Animated="False"
                    Format="MM/dd/yyyy">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="TxtDOB"
                    MaskType="Date" Mask="99/99/9999">
                </cc1:MaskedEditExtender>
            </td>
            <td class="labelcells">
                <asp:Label ID="Label32" runat="server" Text="Date of Anniversary"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox AccessKey="d" ID="TxtAniv" TabIndex="3" runat="server" Width="70px"
                    CssClass="textbox" MaxLength="8"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtAniv_CalendarExtender" runat="server" TargetControlID="TxtAniv"
                    Animated="False" Format="MM/dd/yyyy">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="TxtAniv_MaskedEditExtender" runat="server" TargetControlID="TxtAniv"
                    MaskType="Date" Mask="99/99/9999">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidator6" runat="server" Width="114px" ControlToValidate="TxtDOB"
                    Display="Dynamic" ControlExtender="MaskedEditExtender5" TooltipMessage="MM/DD/YYYY"
                    IsValidEmpty="False" EmptyValueMessage="*" InvalidValueMessage="The Date is invalid"></cc1:MaskedEditValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4">
                &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="titletext" colspan="4">
                <asp:Label ID="Label20" runat="server">Address Detail</asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 13px">
                <asp:Label ID="Label21" runat="server" Text="Address Line 1"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtAddressLine1" runat="server" Columns="30" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells" style="height: 13px">
                <asp:Label ID="Label22" runat="server" Text="City"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtCity" runat="server" Columns="30" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label23" runat="server" Text="Address Line 2"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtAddressLine2" runat="server" Columns="30" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                <asp:Label ID="Label24" runat="server" Text="State"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtState" runat="server" Columns="30" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label25" runat="server" Text="Address Line 3"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtAddressLine3" runat="server" Columns="30" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                <asp:Label ID="Label26" runat="server" Text="Country"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtCountry" runat="server" Columns="30" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="titletext" colspan="4">
                <asp:Label ID="Label27" runat="server">Messaging Detail</asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label28" runat="server" Text="Mobile Number"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtMobille" runat="server" Columns="30" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells">
                <asp:Label ID="Label29" runat="server" Text="Email Address"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtEmail" runat="server" Columns="30" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label30" runat="server" Text="Messaging Mode(s) Allowed"></asp:Label>
            </td>
            <td class="textcells">
                <asp:CheckBox ID="ChkSms" runat="server" Text="SMS" />
                &nbsp;<asp:CheckBox ID="ChkEmail" runat="server" Text="Email" />
            &nbsp;<asp:CheckBox ID="ChkEmail0" runat="server" Text="Both" />
            </td>
            <td class="textcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;
            </td>
            <td class="textcells">
                &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="NormalText">
                <asp:LinkButton ID="CmdImport" runat="server" CssClass="buttonc" 
                    CausesValidation="False" 
                    onclientclick="javascript: window.open('ImportNewContacts.aspx','Import')">Import New</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="CmdAdd" runat="server" CssClass="buttonc" 
                    CausesValidation="False">Add</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="CmdEdit" runat="server" CssClass="buttonc" 
                    CausesValidation="False">Edit</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="CmdDeactive" runat="server" CssClass="buttonc">Deactive</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="CmdClose" runat="server" CssClass="buttonc" 
                    CausesValidation="False">Close</asp:LinkButton>
                <asp:Button ID="Button3" runat="server" CausesValidation="false" Height="0px" Width="0px" />
            </td>
        </tr>
    </table>
</asp:Content>
