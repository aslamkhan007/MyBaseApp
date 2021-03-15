<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" Theme="OpsSkinFIle" CodeFile="OrdersPanel_Config.aspx.vb" Inherits="OPS_OrdersPanel_Config" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Order Panel Configuration</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Module"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="True" 
                    Width="210px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Page"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPageName" runat="server" AutoPostBack="True" 
                    Width="210px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Section"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Actual Sequence</td>
            <td>
                <asp:TextBox ID="txtActualSeq" runat="server" MaxLength="2" Width="50px" 
                    Enabled="False" Font-Bold="True"></asp:TextBox>
            </td>
            <td>
                Custom
                <asp:Label ID="Label4" runat="server" Text="Sequence"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCustomSeq" runat="server" MaxLength="2" Width="50px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtCustomSeq_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtCustomSeq" 
                    ValidChars="01234">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Records To Display"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNo_Of_Records" runat="server" MaxLength="2" Width="50px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtNo_Of_Records_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtNo_Of_Records" 
                    ValidChars="01234">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:LinkButton ID="CmdSave" runat="server">Save</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server">Clear</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
</asp:Content>

