<%@ Page Title="" Language="VB" MasterPageFile="~/EmpGateway/MasterPage_Default.master" AutoEventWireup="false" CodeFile="New_Joinee_Login.aspx.vb" Inherits="EmpGateway_New_Joinee_Login" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td align="left" class="tableheader" colspan="2">
                <asp:Label ID="Label16" runat="server" Text="New Joinee Login"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="Label17" runat="server" Text="Employee Name"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtname" runat="server" Columns="30" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtname" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="Label18" runat="server" Text="Salary Code"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtempcode" runat="server" Columns="7" MaxLength="7"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtempcode" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="Label19" runat="server" Text="Card No"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtcardno" runat="server" Columns="4" MaxLength="4"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtcardno" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="Label20" runat="server" Text="Gender"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlGender" runat="server">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="Label21" runat="server" Text="Joining Date"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtdoj" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdoj_CalendarExtender" runat="server" 
                    Format="MM/dd/yyyy" TargetControlID="txtdoj">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtdoj" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="Label25" runat="server" Text="DOB"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtdob" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdob_CalendarExtender" runat="server" 
                    Format="MM/dd/yyyy" TargetControlID="txtdob">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtdob" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="Label22" runat="server" Text="Father Name"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtfathername" runat="server" Columns="30" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="Label23" runat="server" Text="Department"></asp:Label>
            </td>
            <td align="left">

                        <asp:DropDownList ID="ddlDepartment" runat="server">
                        </asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                <asp:Label ID="Label24" runat="server" Text="Designation"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtdesignation" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" class="buttonbackbar" colspan="2">
                <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="buttonc">Submit</asp:LinkButton>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                    CausesValidation="False">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="width: 134px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 134px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

