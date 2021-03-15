<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="PackingUpdateStatusReport.aspx.vb" Inherits="PackingUpdateStatusReport"
    Title="Packing Update Status Report" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
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
                Packing Reason Reports
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td class="labelcells" style="width: 176px">
                Report Type
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="txtSalePerson" runat="server" CssClass="combobox" AppendDataBoundItems="True">
                            <asp:ListItem>Status VS SalePerson</asp:ListItem>
                            <asp:ListItem>SalePerson VS Status</asp:ListItem>
                            <asp:ListItem>CustomerName VS SalePerson</asp:ListItem>
                            <asp:ListItem>Status VS Date</asp:ListItem>
                        </asp:DropDownList>
                       <asp:Label ID="lblName" runat="server"></asp:Label>
                       
                        <asp:Label ID="lblTime" runat="server"></asp:Label>
                  
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td style="height: 16px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 11px; text-align: center;" colspan="4">
                <table __designer:mapid="28" style="width:100%;">
                    <tr __designer:mapid="29">
                        <td __designer:mapid="2a" style="text-align: right">
                <asp:Button ID="BtnGet" runat="server" BackColor="Black" CssClass="ButtonBack" Text="View"
                    ValidationGroup="A" />
                        </td>
                        <td __designer:mapid="2b" style="text-align: left; width: 64px">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="BtnRefresh" runat="server" BackColor="Black" 
                            CausesValidation="False" CssClass="ButtonBack" Text="Refresh" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
                        <td __designer:mapid="2c" style="text-align: left">
                <asp:Button ID="BtnExcel" runat="server" BackColor="Black" CausesValidation="False"
                    CssClass="ButtonBack" Text="Excel" />
                <asp:Button ID="BtnExcel1" runat="server" BackColor="Black" CausesValidation="False"
                    CssClass="ButtonBack" Text="Excel Part II" />
                <asp:Button ID="BtnExcel3" runat="server" BackColor="Black" CausesValidation="False"
                    CssClass="ButtonBack" Text="Excel Part III" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 11px; text-align: center;" colspan="4">
                <br />
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
                        <asp:GridView ID="GridView1" runat="server" GridLines="None" PageSize="150000" Width="100%"
                            EnableSortingAndPagingCallbacks="True" AllowSorting="True">
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                            <HeaderStyle CssClass="GridviewScrollHeader" />
                            <RowStyle CssClass="GridviewScrollItem" />
                            <PagerStyle CssClass="GridviewScrollPager" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView2" runat="server" EnableSortingAndPagingCallbacks="True"
                            GridLines="None" PageSize="150000" Width="100%" AllowSorting="True">
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                            <HeaderStyle CssClass="GridviewScrollHeader" />
                            <RowStyle CssClass="GridviewScrollItem" />
                            <PagerStyle CssClass="GridviewScrollPager" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="True" EnableSortingAndPagingCallbacks="True"
                            GridLines="None" PageSize="150000" Width="100%">
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                            <HeaderStyle CssClass="GridviewScrollHeader" />
                            <RowStyle CssClass="GridviewScrollItem" />
                            <PagerStyle CssClass="GridviewScrollPager" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
