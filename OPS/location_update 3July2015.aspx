<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="location_update.aspx.cs" Inherits="OPS_location_update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Location Update
            </td>
        </tr>
        <tr>
            <td>
                Plan id</td>
            <td>
                <asp:DropDownList ID="ddlplnlist" runat="server" CssClass="combobox" 
                    onselectedindexchanged="ddlplnlist_SelectedIndexChanged" 
                    AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Order No</td>
            <td>
                <asp:TextBox ID="txtorderNo" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:ImageButton ID="Searchbtn" runat="server" 
                    ImageUrl="~/OPS/Image/searchBlueSmall.PNG" onclick="Searchbtn_Click" 
                    style="height: 16px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtorderNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td colspan="2">
                <asp:GridView ID="grdDetail" runat="server" Width="100%" 
                    EmptyDataText="No Such Record Exists" AutoGenerateSelectButton="True" 
                    onselectedindexchanged="grdDetail_SelectedIndexChanged">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="Griditem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                Current Location</td>
            <td>
                <asp:TextBox ID="txtcurrentloc" runat="server" CssClass="textbox" 
                    ReadOnly="True" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtcurrentloc" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                New location</td>
            <td>
                <asp:DropDownList ID="ddlnewloc" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Cotton</asp:ListItem>
                    <asp:ListItem>Taffeta</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="ddlnewloc" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:HiddenField ID="hdnorder" runat="server" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkappply" runat="server" CssClass="buttonc" 
                    onclick="lnkappply_Click" ValidationGroup="A">Apply</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
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
    </table>
</asp:Content>

