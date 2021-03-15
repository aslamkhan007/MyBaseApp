<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="selling_price_track.aspx.cs" Inherits="OPS_selling_price_track" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="4" class="tableheader">
                Order Production Tracking</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 88px">
                OrderDt From</td>
            <td class="NormalText" style="width: 131px">
                <asp:TextBox ID="txtorderdatefrm" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtorderdatefrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtorderdatefrm">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 90px">
                OrderDt To</td>
            <td class="NormalText">
                <asp:TextBox ID="txtorderdateto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtorderdateto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtorderdateto">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 88px">
                DelDateFrom</td>
            <td class="NormalText" style="width: 131px">
                <asp:TextBox ID="txtdeldatefrm" CssClass="textbox" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdeldatefrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdeldatefrm">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 90px">
                DelDateTo</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdeldateto" CssClass="textbox" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdeldateto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdeldateto">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 88px">
                Sort No</td>
            <td class="NormalText" style="width: 131px">
                <asp:TextBox ID="txtsort" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
            <td colspan="2" class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 88px">
                Order No</td>
            <td class="NormalText" style="width: 131px">
                <asp:TextBox ID="txtorder" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
            <td colspan="2" class="NormalText">
                &nbsp;</td>
        </tr>
        </table>
    <table style="width: 100%">
        <tr>
            <td style="height: 26px" class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="fetch" runat="server" CssClass="buttonc" 
                            onclick="fetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="reset" runat="server" CssClass="buttonc" 
                            onclick="reset_Click">Reset</asp:LinkButton>
                        <asp:LinkButton ID="excel" runat="server" CssClass="buttonc" 
                            onclick="excel_Click">excel</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <table style="width: 100%">
        <tr>
            <td style="height: 26px" class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                </td>
        </tr>
 
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="100%" ScrollBars="Both" Visible="false" 
                            Width="100%">
                            <asp:GridView ID="grdDetail" runat="server" AllowPaging="True" 
                                onpageindexchanging="grdDetail_PageIndexChanging" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="fetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="reset" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

