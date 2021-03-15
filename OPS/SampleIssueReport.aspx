<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="SampleIssueReport.aspx.vb" Inherits="SampleIssueReport" Title="Sample Issue Report"
    MaintainScrollPositionOnPostback="true" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="XGridView" Namespace="CustomControls" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
        });

        $("#<%=GridView1.ClientID%> th").click(function () {
            gridviewScroll();
        });

        function gridviewScroll() {
            $('#<%=GridView1.ClientID%>').gridviewScroll({
                width: 1024,
                height: 500,
                freezesize: 1
            });
        } 





    </script>
    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="5">
                DINV Sample Issues Report
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td class="labelcells">
                Date From
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdFrom" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtDateFrom" TabIndex="3" runat="server" Width="70px" CssClass="textbox"
                            Enabled="True" MaxLength="8" AutoPostBack="True"></asp:TextBox>
                        <cc1:MaskedEditValidator ID="MEV2" runat="server" Width="114px" ControlToValidate="TxtDateFrom"
                            Display="Dynamic" ControlExtender="MEE2" TooltipMessage="MM/DD/YYYY" IsValidEmpty="False"
                            EmptyValueMessage="*" InvalidValueMessage="The Date is invalid" ValidationGroup="A"></cc1:MaskedEditValidator>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtDateFrom"
                            Animated="False" Format="MM/dd/yyyy"  PopupPosition="TopLeft">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MEE2" runat="server" TargetControlID="TxtDateFrom" MaskType="Date"
                            Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp; Date To
            </td>
            <td style="height: 1px">
                &nbsp;<asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox" Enabled="True" MaxLength="8"
                            TabIndex="3" Width="70px"></asp:TextBox>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MEE3"
                            ControlToValidate="txtDateTo" Display="Dynamic" EmptyValueMessage="*" InvalidValueMessage="The Date is invalid" 
                            IsValidEmpty="False" TooltipMessage="MM/DD/YYYY" ValidationGroup="A" Width="114px"></cc1:MaskedEditValidator>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False" Format="MM/dd/yyyy" PopupPosition="TopLeft"
                            TargetControlID="txtDateTo">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MEE3" runat="server" Mask="99/99/9999" MaskType="Date" 
                            TargetControlID="txtDateTo">
                        </cc1:MaskedEditExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Series</td>
            <td class="NormalText">
                <asp:TextBox ID="TxtSeries" TabIndex="3" runat="server" Width="150px" CssClass="textbox"
                    Enabled="True" MaxLength="5" AutoPostBack="True"></asp:TextBox>
         
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td style="height: 1px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 11px; text-align: center;" colspan="4">
                <table __designer:mapid="28" style="width: 100%;">
                    <tr __designer:mapid="29">
                        <td __designer:mapid="2a" style="text-align: center">
                            <asp:Button ID="BtnGet" runat="server" BackColor="Black" CssClass="ButtonBack" Text="View"
                                ValidationGroup="A" />
                            <asp:Button ID="BtnExcel" runat="server" BackColor="Black" CausesValidation="False"
                                CssClass="ButtonBack" Text="Excel" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 11px; text-align: center;" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <img alt="" src="../CostingSystemTest/Image/loading.gif" style="width: 70px; height: 10px" />
                        &nbsp;
                        <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="Please Wait..."></asp:Label>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%" class="tableback">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <cc2:XGridView ID="GridView1" runat="server" GridLines="None" PageSize="150000" Width="100%"
                            EnableCellClick="true">
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                            <HeaderStyle CssClass="GridviewScrollHeader" />
                            <RowStyle CssClass="GridviewScrollItem" />
                            <PagerStyle CssClass="GridviewScrollPager" />
                        </cc2:XGridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
