<%@ Page Title="" Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="retailpunch_rpt.aspx.vb" Inherits="EmpGateway_retailpunch_rpt" %>
 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="100000000">
                </asp:ScriptManager>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label18" runat="server" Text="Retail Shop Punch Report" Width="300px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 26px">
                <asp:Label ID="Label19" runat="server" CssClass="labelcells" Text="From Date "></asp:Label>
            </td>
            <td style="height: 26px">
                <asp:UpdatePanel ID="From" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox AccessKey="d" ID="TxtEffFrom" TabIndex="3" runat="server" Width="70px"
                            CssClass="textbox" Enabled="True" MaxLength="8" >
                        </asp:TextBox>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" Width="114px" ControlToValidate="TxtEffFrom"
                            Display="Dynamic" ControlExtender="MaskedEditExtender1" TooltipMessage="MM/DD/YYYY"
                            IsValidEmpty="False" EmptyValueMessage="*" InvalidValueMessage="The Date is invalid">
                        </cc1:MaskedEditValidator>
                        <cc1:CalendarExtender ID="CalFrom" runat="server" TargetControlID="TxtEffFrom" Animated="False"
                            Format="MM/dd/yyyy">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TxtEffFrom"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
                &nbsp;
            </td>
            <td style="height: 26px">
                <asp:Label ID="Label20" runat="server" CssClass="labelcells" Text="To Date "></asp:Label>
            </td>
            <td style="height: 26px">
                <asp:UpdatePanel ID="ETo" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtEffTo" TabIndex="4" runat="server" Width="70px" CssClass="textbox"
                            Enabled="True" MaxLength="8" >
                        </asp:TextBox>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlToValidate="TxtEffTo"
                            Display="Dynamic" ControlExtender="MaskedEditExtender2" TooltipMessage="MM/DD/YYYY"
                            IsValidEmpty="False" EmptyValueMessage="*" InvalidValueMessage="The Date is invalid ">
                        </cc1:MaskedEditValidator>
                        <cc1:CalendarExtender ID="CalTo" runat="server" TargetControlID="TxtEffTo" Animated="False"
                            Format="MM/dd/yyyy">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="TxtEffTo"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label21" runat="server" CssClass="labelcells" Text="Retail Type"></asp:Label>
            </td>
            <td class="textcells">
                <asp:DropDownList ID="ddlstype" runat="server" CssClass="combobox" Width="150px">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>CIT</asp:ListItem>
                    <asp:ListItem>KSHO</asp:ListItem>
                    <asp:ListItem>PNB</asp:ListItem>
                    <asp:ListItem>TCY</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label22" runat="server" CssClass="labelcells" Text="CardNo"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtCardNo" runat="server" CssClass="textbox" Width="100px" 
                    ToolTip="'Pl Enter All Or CardNo'"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="buttonbackbar" colspan="3">
                <asp:Button ID="cmdview" runat="server" BackColor="Black" CssClass="ButtonBack" Text="View" />
                <asp:Button ID="cmdXL" runat="server" CssClass="ButtonBack" Text="XL" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CssClass="GridViewStyle"
                    Width="100%" PageSize="5">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="Pagestyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
