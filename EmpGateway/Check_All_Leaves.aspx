<%@ Page Title="" Language="VB" MasterPageFile="~/EmpGateway/MasterPage.master" AutoEventWireup="false" CodeFile="Check_All_Leaves.aspx.vb" Inherits="EmpGateway_Check_All_Leaves" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="7">
                <asp:Label ID="Label16" runat="server" 
                    Text="Check Leave Status of all Employees"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td style="width: 21px" class="labelcells">
                &nbsp;</td>
            <td style="width: 94px" class="labelcells">
                &nbsp;</td>
            <td style="width: 94px" class="labelcells">
                &nbsp;</td>
            <td style="width: 94px" class="labelcells">
                <asp:Label ID="Label17" runat="server" Font-Bold="False" Text="Start date"></asp:Label>
            </td>
            <td style="width: 98px" class="textbox">
                <asp:TextBox ID="txtSdate" runat="server" Columns="12" MaxLength="12" 
                    CssClass="textbox"></asp:TextBox>
              
                <cc1:TextBoxWatermarkExtender ID="txtSdate_TextBoxWatermarkExtender" 
                    runat="server" TargetControlID="txtSdate" WatermarkCssClass="watermark" 
                    WatermarkText="mm/dd/yyyy">
                </cc1:TextBoxWatermarkExtender>
              
                <cc1:FilteredTextBoxExtender ID="txtSdate_FilteredTextBoxExtender" 
                    runat="server" TargetControlID="txtSdate" ValidChars="0123456789/">
                </cc1:FilteredTextBoxExtender>
                <cc1:CalendarExtender ID="txtSdate_CalendarExtender" runat="server" 
                    TargetControlID="txtSdate">
                </cc1:CalendarExtender>
            </td>
            <td style="width: 80px" class="labelcells">
                <asp:Label ID="Label18" runat="server" Font-Bold="False" Text="End date"></asp:Label>
            </td>
            <td class="textbox">
                <asp:TextBox ID="txtEdate" runat="server" Columns="12" MaxLength="12" 
                    CssClass="textbox"></asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="txtEdate_TextBoxWatermarkExtender" 
                    runat="server" TargetControlID="txtEdate" WatermarkCssClass="watermark" 
                    WatermarkText="mm/dd/yyyy">
                </cc1:TextBoxWatermarkExtender>
                <cc1:FilteredTextBoxExtender ID="txtEdate_FilteredTextBoxExtender" 
                    runat="server" TargetControlID="txtEdate" ValidChars="0123456789/">
                </cc1:FilteredTextBoxExtender>
                <cc1:CalendarExtender ID="txtEdate_CalendarExtender" runat="server" 
                    TargetControlID="txtEdate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="7">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc">GET</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="buttonc">To Excel</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            CssClass="GridViewStyle" GridLines="None" PageSize="25">
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                            <EditRowStyle CssClass="EditRowStyle" />
                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                            <FooterStyle CssClass="FooterStyle" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerStyle CssClass="PagerStyle" />
                            <RowStyle CssClass="RowStyle" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

