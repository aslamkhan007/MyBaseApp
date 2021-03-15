<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="ScooterSent.aspx.vb" Inherits="Scooter" Title="Allowance for this month" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 101%">
        <tr>
            <td colspan="2" class="tableheader">
                Conveyance Allowance Updation
            </td>
        </tr>
        <tr><td class="labelcells" style="width:118px">Allowance For Month</td>
            <td style="width: 704px; height: 21px" class="textcells">
                <asp:DropDownList ID="Mon" runat="server" AutoPostBack="True" CssClass="combobox" Width="93px">
                    <asp:ListItem>January</asp:ListItem>
                    <asp:ListItem>February</asp:ListItem>
                    <asp:ListItem>March</asp:ListItem>
                    <asp:ListItem>April</asp:ListItem>
                    <asp:ListItem>May</asp:ListItem>
                    <asp:ListItem>June</asp:ListItem>
                    <asp:ListItem>July</asp:ListItem>
                    <asp:ListItem>August</asp:ListItem>
                    <asp:ListItem>September</asp:ListItem>
                    <asp:ListItem>October</asp:ListItem>
                    <asp:ListItem>November</asp:ListItem>
                    <asp:ListItem>December</asp:ListItem>
                </asp:DropDownList><asp:DropDownList ID="Yr" runat="server" AutoPostBack="True" CssClass="combobox" Width="56px">
                    <asp:ListItem>2008</asp:ListItem>
                    <asp:ListItem>2009</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList></td>
        </tr><tr><td style="width: 118px; height: 21px" class="textcells">
            <asp:CheckBox ID="ChkScooter" runat="server" Text="Scooter" Width="69px" /></td>
            <td style="height: 21px; width: 704px;" class="textcells"><ew:CalendarPopup ID="DateScooter" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="69px">
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr><td style="width: 118px; height: 21px" class="textcells">
                    <asp:CheckBox ID="ChkCar" runat="server" Text="Car" Width="46px" /></td>
            <td style="width: 704px; height: 21px">
                <ew:CalendarPopup ID="DateCar" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="70px">
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr class="buttonbackbar">
            <td style="height: 21px;" colspan="2">
                <asp:Button ID="CmdApply" runat="server" CssClass="ButtonBack" Text="Apply" BackColor="Black"/>
                <asp:Button ID="CmdClear" runat="server" CssClass="ButtonBack" Text="Clear" BackColor="Black"/></td>
        </tr>
    </table>
</asp:Content>

