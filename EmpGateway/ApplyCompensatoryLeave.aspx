<%@ Page Title="" Language="C#" MasterPageFile="~/EmpGateway/MasterPage.master" AutoEventWireup="true" CodeFile="ApplyCompensatoryLeave.aspx.cs" Inherits="EmpGateway_ApplyCompensatoryLeave" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td class="tableheader" colspan="4">
                Compensatory Leave Form</td>
        </tr>
        <tr>
            <td class="NormalText">
                Nature</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlnature" runat="server" CssClass="combobox">
                    <asp:ListItem>Earned Compensatory Leave</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
               <asp:Label ID="Leavetype" Text="Leave Type" Visible="false"></asp:Label> </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddltype" runat="server" CssClass="combobox"  Visible="false"
                    AutoPostBack="True" onselectedindexchanged="ddltype_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Full Day</asp:ListItem>
                    <asp:ListItem>Half Day</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Name Of Employee</td>
            <td class="NormalText">
                <asp:TextBox ID="txtemp" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                No Of Days</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdays" runat="server" CssClass="textbox" 
                    ToolTip="1 or 0.5 only" Width="40px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtdays_FilteredTextBoxExtender" 
                    runat="server" TargetControlID="txtdays" ValidChars=".150">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtdays" ErrorMessage="Please enter no.of days" 
                    ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Department</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdept" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            </td>
            <td class="NormalText">
                Date</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdate" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtdate" ErrorMessage="Please select date" 
                    ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Designation</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdesig" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            </td>
            <td class="NormalText">
                Purpose</td>
            <td class="NormalText">
                <asp:TextBox ID="txtpurpose" runat="server" CssClass="textbox"  Height="50px" Width="200px"
                    TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtpurpose" ErrorMessage="Cannot be blank" 
                    ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:LinkButton ID="lnkapply" runat="server" CssClass="buttonc"  ValidationGroup="mandatory"
                    onclick="lnkapply_Click">Apply</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

