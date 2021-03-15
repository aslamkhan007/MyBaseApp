<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Office.aspx.vb" Inherits="Office" Title="Office Orders" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td colspan="2" class="tableheader">
                <asp:Label ID="Label1" runat="server" Text="Office Order"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width:100px">
                <asp:Label ID="Label2" runat="server" Text="Department" Width="72px"></asp:Label>
            </td>
            <td class="textcells">
                <asp:DropDownList ID="DDL1" runat="server" AutoPostBack="True" AppendDataBoundItems="True"
                    CssClass="combobox" Width="145px" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width:100px">
                <asp:Label ID="Label4" runat="server" Text="List of Forms" Width="78px"></asp:Label>
            </td>
            <td>
                <asp:Panel ID="BothBox" runat="server" BorderStyle="None" Height="183px"
                    Width="100%" CssClass="textcells" ScrollBars="Vertical">
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
