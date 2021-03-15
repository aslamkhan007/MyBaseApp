<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="missingDyeList.aspx.cs" Inherits="OPS_missingDyeList" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%" class="tableheader">
        <tr>
            <td class="tableheader" colspan="4">
                Missing Dye List</td>
        </tr>
        <tr>
            <td style="width: 130px" class="NormalText">
                DateFrom</td>
            <td style="width: 158px">
                <asp:TextBox ID="txtdatefrm" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdatefrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdatefrm">
                </cc1:CalendarExtender>
            &nbsp;&nbsp;
            </td>
            <td style="width: 141px" class="NormalText">
                DateTo</td>
            <td>
                <asp:TextBox ID="txtdateto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdateto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdateto">
                </cc1:CalendarExtender>
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnk_excel" runat="server" CssClass="buttonXL" Height="32px" 
                    onclick="lnk_excel_Click" Width="32px"></asp:LinkButton>
            </td>
        </tr>
    </table>
    <p>
    </p>
    <table style="width: 100%">
        <tr>
            <td class="buttonbackbar">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" Width="90%" Height="400px" 
                    ScrollBars="Both">
                    <asp:GridView ID="grdDetail" runat="server" AllowPaging="True" 
                        onpageindexchanging="grdDetail_PageIndexChanging" PageSize="50" 
                        Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

