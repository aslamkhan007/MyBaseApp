<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="ArearSent.aspx.vb" Inherits="ArearSent" title="Salary Sent In Account For Month" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label5" runat="server" BorderColor="Transparent" 
                    Text="Arrear Sent To Account"></asp:Label></td>
        </tr>
        <tr style="display:none">
            <td colspan="4" class="labelcells">
                Arrear For Month :</td>
            <td class="textcells">
                <asp:DropDownList ID="DrpMonth" runat="server" AutoPostBack="True" 
                    CssClass="combobox">
                    <asp:ListItem Value="1">Jan</asp:ListItem>
                    <asp:ListItem Value="2">Feb</asp:ListItem>
                    <asp:ListItem Value="3">Mar</asp:ListItem>
                    <asp:ListItem Value="4">Apr</asp:ListItem>
                    <asp:ListItem Value="5">May</asp:ListItem>
                    <asp:ListItem Value="6">Jun</asp:ListItem>
                    <asp:ListItem Value="7">Jul</asp:ListItem>
                    <asp:ListItem Value="8">Aug</asp:ListItem>
                    <asp:ListItem Value="9">Sep</asp:ListItem>
                    <asp:ListItem Value="10">Oct</asp:ListItem>
                    <asp:ListItem Value="11">Nov</asp:ListItem>
                    <asp:ListItem Value="12">Dec</asp:ListItem>
                </asp:DropDownList>&nbsp;
                <asp:Label ID="LblYear" runat="server" CssClass="labelcells" Width="46px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" class="textcells">
                <asp:CheckBox ID="ChkClerks" runat="server" Text="Clerks" /></td>
            <td class="textcells">
                <ew:CalendarPopup ID="DtClerk" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="64px" CssClass="textbox">
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="textcells">
                    <asp:CheckBox ID="chkAssOff" runat="server" Text="Asst. Officer"/>
            </td>
            <td class="textcells">
                <ew:CalendarPopup ID="DtAOff" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="64px" CssClass="textbox">
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="textcells" >
                <asp:CheckBox ID="chkOfficer" runat="server" Text="Officer" />
            </td>
            <td class="textcells">
                <ew:CalendarPopup ID="DtOff" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="64px" CssClass="textbox">
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td class="textcells" colspan="4">
                <asp:CheckBox ID="chkAMgr" runat="server" Text="Asst. Manager" />
            </td>
            <td class="textcells">
                <ew:CalendarPopup ID="DtAMng" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="64px" CssClass="textbox">
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="textcells">
                <asp:CheckBox ID="chkDptMgr" runat="server" Text="Deputy Manager" /></td>
            <td class="textcells">
                <ew:CalendarPopup ID="DtDMgr" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="64px" CssClass="textbox">
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td class="textcells" colspan="4" >
                <asp:CheckBox ID="chkMgr" runat="server" Text="Manager" />
            </td>
            <td class="textcells">
                <ew:CalendarPopup ID="DtMgr" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="64px" CssClass="textbox">
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="textcells">
                <asp:CheckBox ID="chkAGM" runat="server" Text="Asst. General Manager" />
             </td>
            <td class="textcells">
                <ew:CalendarPopup ID="DtAGM" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="64px" CssClass="textbox">
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="textcells">
                <asp:CheckBox ID="chkDGM" runat="server" Text="Deputy General Manager" />
            </td>
            <td class="textcells">
                <ew:CalendarPopup ID="DtDGM" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="64px" CssClass="textbox">
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="textcells">
                <asp:CheckBox ID="chkHOD" runat="server" Text="HOD" />
            </td>
            <td class="textcells">
                <ew:CalendarPopup ID="DtHOD" runat="server" Culture="English (United Kingdom)" Text="..."
                    Width="64px" CssClass="textbox">
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td colspan="5" class="buttonbackbar">
                <asp:Button ID="cmdapply" runat="server" CssClass="ButtonBack" Text="Apply" BackColor="Black"/>
                <asp:Button ID="cmdclear" runat="server" CssClass="ButtonBack" Text="Clear" BackColor="Black"/></td>
        </tr>
    </table>
</asp:Content>

