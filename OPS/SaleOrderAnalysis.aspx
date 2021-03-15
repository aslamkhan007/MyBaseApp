<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="SaleOrderAnalysis.aspx.vb" Inherits="OPS_SaleOrderAnalysis" %>

<%--<%@ Register Assembly="IdeaSparx.CoolControls.Web" Namespace="IdeaSparx.CoolControls.Web"
    TagPrefix="cc2" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 700px;">
        <tr>
            <td class="tableheader" colspan="3">
                Sale Order Analysis(Delivery Wise)
            </td>
        </tr>
        <tr>
            <td>
                DateFrom
            </td>
            <td width="250">
                <asp:TextBox ID="txtEff_From" runat="server" CssClass="textbox" MaxLength="15" TabIndex="28"
                    ValidationGroup="ValidGrpSaveDetail" Width="65px"></asp:TextBox>
                <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txtEff_From"
                    ValidationGroup="ValidGrpSaveDetail" Display="Dynamic" InvalidValueMessage="Invalid"
                    IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px"></cc1:MaskedEditValidator>
                <cc1:CalendarExtender ID="CalEfffr" runat="server" Animated="False" Format="MM/dd/yyyy"
                    TargetControlID="txtEff_From">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MEE6" runat="server" Mask="99/99/9999" MaskType="Date"
                    TargetControlID="txtEff_From">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                DateTo
            </td>
            <td width="250">
                <asp:TextBox ID="txtEff_To" runat="server" CssClass="textbox" MaxLength="15" TabIndex="29"
                    ValidationGroup="ValidGrpSaveDetail" Width="65px"></asp:TextBox>
                <cc1:MaskedEditValidator ID="MEV7" runat="server" ControlExtender="MEE7" ControlToValidate="txtEff_To"
                    ValidationGroup="ValidGrpSaveDetail" Display="Dynamic" InvalidValueMessage="Invalid"
                    IsValidEmpty="False" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" Width="114px"></cc1:MaskedEditValidator>
                <cc1:CalendarExtender ID="CalEffTo" runat="server" Animated="False" Format="MM/dd/yyyy"
                    TargetControlID="txtEff_To">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MEE7" runat="server" Mask="99/99/9999" MaskType="Date"
                    TargetControlID="txtEff_To">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="CmdFetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="CmdXl" runat="server" CssClass="buttonXL" Width="64px"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.history.go(-1);return false;">&lt;&lt; Back</asp:LinkButton>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="CmdXl" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="5" >
                    <ProgressTemplate>
                        <asp:Image ID="ImageProg" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel2" runat="server" Height="400px" Width="100%" ScrollBars="None">
                    <div id="AdjResultsDiv1" class="container" style="width: 900px; height: 398px;">
                        <asp:UpdatePanel ID="UpdatePanel17" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server">
                                    <HeaderStyle CssClass="GridHeader" />
                                    <RowStyle CssClass="GridItem" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="CmdFetch" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
