<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="ParameterDefinitions.aspx.vb" Inherits="OPS_ParameterDefinitions"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Parameter Definition</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Area"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlArea" runat="server" Width="250px" CssClass="combobox">
                </asp:DropDownList>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                ParameterName</td>
            <td>
                <asp:TextBox ID="txtParameterName" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Description</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" 
                    Width="200px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                MultiValues</td>
            <td>
                <asp:DropDownList ID="ddlText_Or_Not" runat="server" AutoPostBack="True">
                    <asp:ListItem>Y</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                ProcedureName</td>
            <td>
                <asp:TextBox ID="txtProcedureName" runat="server" Enabled="False" 
                    CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                        <asp:LinkButton ID="cmdApply" runat="server" 
    BorderStyle="None" CssClass="buttonc">Apply</asp:LinkButton>
                        <asp:LinkButton ID="cmdReset" runat="server" 
    BorderStyle="None" CssClass="buttonc">Reset</asp:LinkButton>
                    </td>
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
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

