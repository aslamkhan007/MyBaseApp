<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master" AutoEventWireup="true" CodeFile="AssetCategory.aspx.cs" Inherits="AssetMngmnt_AssetCategory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <table class="mytable">
        <tr>
            <td colspan="2" class="tableheader">
                <asp:Label ID="Label18" runat="server" Text="Asset Category Master"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 96px">
                Asset Category</td>
            <td class="NormalText">
                <asp:TextBox ID="txtasset" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtasset" ErrorMessage="**"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 96px">
                Description</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdesc" runat="server" CssClass="textbox" Height="50px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdesc" ErrorMessage="**"></asp:RequiredFieldValidator>
            </td>
            
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="lnksave_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    onclick="lnkupdate_Click">Update</asp:LinkButton>

                            <cc1:ConfirmButtonExtender
                                ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkdel" ConfirmText="Are u sure To Delete ?" >
                            </cc1:ConfirmButtonExtender>

                <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" 
                    onclick="lnkdel_Click">Delete</asp:LinkButton>
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
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

