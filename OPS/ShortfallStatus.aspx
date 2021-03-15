<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="ShortfallStatus.aspx.cs" Inherits="OPS_ShortfallStatus" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Shortfall Status"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 89px">
                <asp:Label ID="Label17" runat="server" Text="Date From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 128px">
                <asp:TextBox ID="txtdatefrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdatefrom_CalendarExtender" runat="server" 
                    TargetControlID="txtdatefrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 116px">
                <asp:Label ID="Label18" runat="server" Text="Date From"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtdateto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdateto_CalendarExtender" runat="server" 
                    TargetControlID="txtdateto">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 89px">
                <asp:Label ID="Label19" runat="server" Text="Sort No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 128px">
                <asp:TextBox ID="txtSortNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 116px">
                <asp:Label ID="Label20" runat="server" Text="OrderNo"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 89px">
                <asp:Label ID="Label21" runat="server" Text="Status"></asp:Label>
            </td>
            <td class="NormalText" style="width: 128px">
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="combobox">
                    <asp:ListItem Selected="True" Value="A">Authorized</asp:ListItem>
                    <asp:ListItem Value="P">Pending</asp:ListItem>
                    <asp:ListItem Value="C">Cancel</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 116px">
                <asp:Label ID="Label22" runat="server" Text="Plant"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>COTTON</asp:ListItem>
                    <asp:ListItem>TAFFETA</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" style="width: 165px">
                <asp:Label ID="Label23" runat="server" Text="Include Completed Shortfalls"></asp:Label>
            </td>
            <td class="NormalText" style="width: 116px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:CheckBox ID="chbAll" runat="server" AutoPostBack="True" 
                            oncheckedchanged="chbAll_CheckedChanged" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" 
                            onclick="lnkExcel_Click">Excel</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Vertical">
                            <asp:GridView ID="grdShortfall" runat="server" 
                                EmptyDataText="No Shortfall Present" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="chbAll" EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

