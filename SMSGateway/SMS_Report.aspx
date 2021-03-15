<%@ Page Title="" Language="VB" MasterPageFile="~/SMSGateway/MasterPage.master" AutoEventWireup="false" CodeFile="SMS_Report.aspx.vb" Inherits="SMSGateway_SMS_Report" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="SMS Report"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 144px">
                <asp:Label ID="Label2" runat="server" Text="Select subject of SMS"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSubject" runat="server" CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 144px">
                <asp:Label ID="Label3" runat="server" Text="Date of SMS Sent"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" 
                            ToolTip="Select  date on which sms has been sent." Enabled="False"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                            TargetControlID="txtDate">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkReport" runat="server" CssClass="buttonc">View Report</asp:LinkButton>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                            AssociatedUpdatePanelID="UpdatePanel4">
                            <ProgressTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/loading.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" colspan="2">
                <asp:Panel ID="pnlGrid" runat="server" CssClass="panelbg">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="grdReport" runat="server"  Width="372px">
                                <FooterStyle CssClass="FooterStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lnkReport" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 144px; height: 16px;">
                </td>
            <td class="NormalText">
                </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 144px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

