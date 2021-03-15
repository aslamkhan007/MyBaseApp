<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Default10.aspx.vb" Inherits="Default10" title="Untitled Page" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader" >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tableheader" >
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="combobox">
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Authorize</asp:ListItem>
                    <asp:ListItem>Cancel</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
    </table>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" Width="669px" HorizontalAlign="Left" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" PageSize="6" GridLines="Vertical">
                    <SelectedRowStyle ForeColor="White" />
                    <HeaderStyle BorderStyle="None" CssClass="GridHeader" />
                    <AlternatingRowStyle BackColor="Silver" BorderStyle="None" CssClass="GridAI" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" HeaderText="Click To Authorize" SelectImageUrl="~/SmallCalendar.gif"
                            ShowSelectButton="True" />
                    </Columns>
                    <RowStyle CssClass="GridItem" />
                    <PagerStyle CssClass="GridHeader" ForeColor="White" HorizontalAlign="Center" />
                </asp:GridView>
</asp:Content>

