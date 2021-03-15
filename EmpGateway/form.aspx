<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="form.aspx.vb" Inherits="Default6" title="Form & Processes" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 79px">
        <tr>
            <td colspan="5" class="tableheader">
                <asp:Label ID="Label1" runat="server" Text="Forms"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" colspan="5" style="height: 29px;">
                <table style="width: 100%;">
                    <tr>
                        <td valign="top">
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                                ForeColor="#404040" Text="Department" Width="72px"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="DDL1" runat="server" AutoPostBack="True"
                    ForeColor="#404040" Width="300px" Font-Names="Tahoma" Font-Size="8pt" Font-Bold="True">
                </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="Label3" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                                Font-Size="8pt" ForeColor="#404040" Height="17px" Text="Type" Width="31px"></asp:Label></td>
                        <td valign="middle">
                            <asp:RadioButtonList
                    ID="RadioButtonList1" runat="server" Font-Names="Tahoma" Font-Size="8pt"
                    RepeatDirection="Horizontal" Width="228px" AutoPostBack="True" BorderStyle="Solid" TextAlign="Left" Font-Bold="True" ForeColor="#404040" BorderColor="Silver" BorderWidth="1px">
                    <asp:ListItem Value="0">Internal</asp:ListItem>
                    <asp:ListItem Value="1">External</asp:ListItem>
                </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td align="left"
                            valign="top" class="labelcells">
                            <asp:Label ID="Label4" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma"
                                Font-Size="8pt" ForeColor="#404040" Height="17px" Text="List of Forms" Width="88px"></asp:Label></td>
                        <td valign="middle" >
                            <asp:Panel ID="BothBox" runat="server" BorderStyle="None" Height="90%" HorizontalAlign="Justify"
                                Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ScrollBars="Vertical">
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                </td>
        </tr>
    </table>
</asp:Content>
