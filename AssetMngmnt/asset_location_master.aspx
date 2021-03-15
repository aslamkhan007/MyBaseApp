<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master"  AutoEventWireup="true" CodeFile="asset_location_master.aspx.cs" Inherits="AssetMngmnt_asset_location_master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Location Master</td>
        </tr>
        <tr>
            <td class="NormalText" style="height: 17px">
                <asp:Label ID="dlabel" runat="server" Text="Location" Visible="False"></asp:Label>
            </td>
            <td class="NormalText" style="height: 17px">
                <asp:DropDownList ID="ddlloc" runat="server" CssClass="combobox" 
                    AutoPostBack="True" onselectedindexchanged="ddlloc_SelectedIndexChanged" 
                    Visible="False">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Colony</asp:ListItem>
                    <asp:ListItem>Oustside Colony</asp:ListItem>
                    <asp:ListItem>Company Items</asp:ListItem>
                    <asp:ListItem>Guest House</asp:ListItem>
<asp:ListItem>Mill Premises</asp:ListItem>
<asp:ListItem>Colony Premises</asp:ListItem>

                </asp:DropDownList>
            </td>
            <td class="NormalText" style="height: 17px">
            </td>
            <td class="NormalText" style="height: 17px">
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="lblHousetype" runat="server" Text="Housetype" Visible="False"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlHousetypes" runat="server" CssClass="combobox" 
                    AutoPostBack="True" onselectedindexchanged="ddlloc_SelectedIndexChanged" 
                    Visible="False">
<asp:ListItem>AType</asp:ListItem>
                    <asp:ListItem>BType</asp:ListItem>
                    <asp:ListItem>CType</asp:ListItem>
                    <asp:ListItem>CA</asp:ListItem>

<asp:ListItem>CB</asp:ListItem>
                    <asp:ListItem>DType</asp:ListItem>
                    <asp:ListItem>IHMS</asp:ListItem>
                    <asp:ListItem>IHT</asp:ListItem>
                    <asp:ListItem>IHS</asp:ListItem>
                    <asp:ListItem>IH</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="txtlab" runat="server" Text="Location"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtlcation" runat="server" CssClass="textbox" 
                    TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtlcation" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    <cc1:FilteredTextBoxExtender
                        ID="FilteredTextBoxExtender1" runat="server" 
                    TargetControlID="txtlcation" ValidChars="0123456789">
                    </cc1:FilteredTextBoxExtender>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="LnkSave" runat="server" CssClass="buttonc" 
                    onclick="LnkSave_Click" ValidationGroup="A">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    onclick="lnkupdate_Click" ValidationGroup="A">Update</asp:LinkButton>

                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkdelete"
                    ConfirmText="Are u sure To Delete ?">
                </cc1:ConfirmButtonExtender>

                <asp:LinkButton ID="lnkdelete" runat="server" CssClass="buttonc" 
                    onclick="lnkdelete_Click" ValidationGroup="A">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
          <tr>
            <td class="NormalText" colspan="4" >
                <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" 
                    Width="900px">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    onselectedindexchanged="grdDetail_SelectedIndexChanged" 
    Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GirdItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

