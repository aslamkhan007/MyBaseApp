<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="outsourced_Yarn.aspx.cs" Inherits="OPS_outsourced_Yarn" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td colspan="4" class="tableheader">
                &nbsp;Outsourced
                Yarn Purcahse Request</td>
        </tr>
        <tr>
            <td class="NormalText">
                Plant</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox">
                    <asp:ListItem>Cotton</asp:ListItem>
                    <asp:ListItem>Taffeta</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                Quality</td>
            <td class="NormalText">
                <asp:TextBox ID="txtquality" runat="server" CssClass="textbox"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                UOM</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddluom" runat="server" CssClass="combobox">
                    <asp:ListItem>M.T</asp:ListItem>
                    <asp:ListItem>Kgs</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                Sort No</td>
            <td class="NormalText">
                <asp:TextBox ID="txtSortno" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Required Qty</td>
            <td class="NormalText">
                <asp:TextBox ID="txtreqqty" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Required Date</td>
            <td class="NormalText">
                <asp:TextBox ID="txtreqdt" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="txtreqdt_TextBoxWatermarkExtender" 
                    runat="server" TargetControlID="txtreqdt" WatermarkText="DD/MM/YY">
                </cc1:TextBoxWatermarkExtender>
                <cc1:CalendarExtender ID="txtreqdt_CalendarExtender" runat="server" 
                    TargetControlID="txtreqdt">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Sale Order
                No</td>
            <td class="NormalText">
                <asp:TextBox ID="txtso" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Yarn Required</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlyarn" runat="server" CssClass="combobox">
                    <asp:ListItem>Warp</asp:ListItem>
                    <asp:ListItem>Weft</asp:ListItem>
                    <asp:ListItem>Both</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                End Use</td>
            <td class="NormalText">
                <asp:TextBox ID="txtend" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Remarks</td>
            <td class="NormalText">
                <asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
      
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="900px">
                    <asp:GridView ID="GrdDetail" runat="server" Width="100%" 
                        AutoGenerateSelectButton="True" 
                        onselectedindexchanged="GrdDetail_SelectedIndexChanged">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="Pagestyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="lnksave_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkclear" runat="server" CssClass="buttonc" 
                    onclick="lnkclear_Click">Clear</asp:LinkButton>
                <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" 
                    onclick="lnkdel_Click">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkUpt" runat="server" CssClass="buttonc" 
                    onclick="lnkUpt_Click">Update</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="height: 17px">
            </td>
            <td class="NormalText" style="height: 17px">
            </td>
            <td class="NormalText" style="height: 17px">
            </td>
            <td class="NormalText" style="height: 17px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

