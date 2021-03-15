<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Trainee.aspx.vb" Inherits="Trainee" Title="Trainning Program" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td colspan="5" class="tableheader">
                <asp:Label ID="Label1" runat="server" Text="Training" Width="49px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <table style="width: 100%;">
                    <tr>
                        <td class="labelcells" style="width: 62px">
                            <asp:Label ID="Label2" runat="server" Text="Department" Width="72px"></asp:Label>
                        </td>
                        <td class="textcells">
                            <asp:DropDownList ID="DDL1" runat="server" AutoPostBack="True" Width="300px" 
                                AppendDataBoundItems="True" CssClass="combobox">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="labelcells" style="width: 62px">
                            <asp:Label ID="Label3" runat="server" Text="Type" Width="31px"></asp:Label>
                        </td>
                        <td class="textcells">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                Width="297px" AutoPostBack="True" TextAlign="Left">
                                <asp:ListItem Value="0">Internal</asp:ListItem>
                                <asp:ListItem Value="1">External</asp:ListItem>
                                <asp:ListItem Value="2">Both</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="labelcells" style="width: 62px">
                            <asp:Label ID="Label4" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                                Font-Size="8pt" ForeColor="#404040" Height="17px" Text="List of Forms" Width="88px"></asp:Label>
                        </td>
                        <td >
                            <asp:Panel ID="BothBox" runat="server" BorderStyle="None" Height="100px" Width="100%"
                                ScrollBars="Vertical" CssClass="textcells">
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
