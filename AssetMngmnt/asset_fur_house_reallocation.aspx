<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master" AutoEventWireup="true" CodeFile="asset_fur_house_reallocation.aspx.cs" Inherits="AssetMngmnt_asset_fur_house_reallocation" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="2">
                Employee House Reallocation</td>
        </tr>
        <tr>
            <td class="NormalText">
                Emploee code</td>
            <td class="NormalText">
                <asp:TextBox ID="txtempcode" runat="server" CssClass="textbox"></asp:TextBox>
           
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtempcode" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Location</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlloc" runat="server" AppendDataBoundItems="True" 
                    DataSourceID="SqlDataSource1" DataTextField="location" DataValueField="ID" 
                    CssClass="combobox" Enabled="False">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand=" SELECT location,ID FROM dbo.jct_asset_location_master WHERE module_usedby='GEN' AND STATUS='A'">
                </asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="ddlloc" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="2">
              <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="200px">
                <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    Width="100%" onselectedindexchanged="grdDetail_SelectedIndexChanged">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </asp:Panel></td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:LinkButton ID="lnkapply" runat="server" CssClass="buttonc" 
                    onclick="lnkapply_Click">Apply</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="buttonc" 
                    onclick="LinkButton2_Click">Reset</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

