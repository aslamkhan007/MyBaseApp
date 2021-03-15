<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="BeamRewindingReport.aspx.cs" Inherits="OPS_BeamRewindingReport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Beam Rewinding Report"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 108px">
                <asp:Label ID="Label17" runat="server" Text="Entry Date From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 78px">
                <asp:TextBox ID="txtEntryDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEntryDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtEntryDateFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 109px">
                <asp:Label ID="Label18" runat="server" Text="Entry Date To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEntryDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEntryDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtEntryDateTo">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 108px">
                <asp:Label ID="Label19" runat="server" Text="Beam No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 78px">
                <asp:TextBox ID="txtBeamNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 109px">
                <asp:Label ID="Label20" runat="server" Text="Issue No"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtIssueNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 108px">
                <asp:Label ID="Label21" runat="server" Text="Sort No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 78px">
                <asp:TextBox ID="txtSortNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 109px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" 
                            onclick="lnkExcel_Click">Excel</asp:LinkButton>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="lnkExcel" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdBeamRewinding" runat="server" Width="100%">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

