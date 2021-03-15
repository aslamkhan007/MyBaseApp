<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Overtime_Authorize.aspx.cs" Inherits="Payroll_Jct_Payroll_Overtime_Authorize" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td class="tableheader" style="text-align: left">
                <asp:Label ID="Label5" runat="server" Text="My Action Area" Width="328px"></asp:Label>
            </td>
            <td class="tableheader" style="text-align: left">
                <asp:Label ID="Label7" runat="server" Text="Status:"></asp:Label>
            </td>
            <td class="tableheader" style="text-align: left">
                <asp:DropDownList ID="DrpLvStatus" runat="server" AutoPostBack="True" Width="104px"
                    CssClass="combobox" OnSelectedIndexChanged="DrpLvStatus_SelectedIndexChanged">
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Authorized</asp:ListItem>
                    <asp:ListItem>Cancelled</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="buttonbackbar" style="text-align: left">
                <asp:Label ID="Label1" runat="server" Text="Overtime Authorization" Width="202px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <ew:CollapsablePanel ID="PnlExtTasks" CssClass="panelcells" runat="server" Height="150px"
                            ScrollBars="Vertical" Width="100%" CollapseImageUrl="Image/UPARROW.JPG" CollapserAlign="Left"
                            ExpandImageUrl="Image/DNARROW.JPG">
                            <asp:GridView ID="GridExtTask" runat="server" CssClass="GridViewStyle" GridLines="None"
                                Width="100%">
                                <RowStyle CssClass="RowStyle" />
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <EditRowStyle CssClass="EditRowStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Check">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ChkOrderSelAll" runat="server" AutoPostBack="True" OnCheckedChanged="ChkOrderSelAll_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkCheck" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ew:CollapsablePanel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 115px">
            </td>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkConfirmAll" runat="server" CssClass="buttonc" OnClick="lnkConfirmAll_Click">Authorize</asp:LinkButton>
                        <asp:LinkButton ID="LnkCancel" runat="server" CssClass="buttonc" OnClick="LnkCancel_Click">Cancel</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" OnClick="lnkReset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="10">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
</asp:Content>
