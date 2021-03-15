<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="AssetType.aspx.cs" Inherits="AssetMngmnt_AssetType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td colspan="2" class="tableheader">
                <asp:Label ID="Label18" runat="server" Text="Asset Type Master"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 80px">
                AssetCategory</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlassettype" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="item_name" 
                    DataValueField="asset_id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT  item_name,asset_id FROM dbo.jct_asset_master where status='A' order by item_name">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 80px">
                Asset Name</td>
            <td class="NormalText">
                <asp:TextBox ID="txtasset" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtasset" Display="Dynamic" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 80px">
                Description </td>
            <td class="NormalText">
                <asp:TextBox ID="txtdesc" runat="server" CssClass="textbox" Height="50px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdesc" Display="Dynamic" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="lnksave_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" 
                    onclick="lnkdel_Click">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    onclick="lnkupdate_Click">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                    onclick="lnkReset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="2">
                <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    onselectedindexchanged="grdDetail_SelectedIndexChanged" Width="100%">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GirdItem" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

