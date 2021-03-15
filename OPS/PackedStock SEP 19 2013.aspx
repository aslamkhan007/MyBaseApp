<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"     CodeFile="PackedStock.aspx.vb" Inherits="PackedStock" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="cc2" %>
  <%--  <%@ Register assembly="XGridView" namespace="CustomControls" tagprefix="cc2" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>--%>
   <%-- <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
        });

        $("#<%=grdStage.ClientID%> th").click(function () {
            gridviewScroll();
        });

        function gridviewScroll() {
            $('#<%=grdStage.ClientID%>').gridviewScroll({
                width: 1024,
                height: 500,
                freezesize: 1
            });
        } 





    </script>--%>
    <table style="width: 100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt" class="tableheader" colspan="3">
                Packed Stock</td>
            <td style="font-weight: bold; font-size: 10pt" class="tableheader">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 25px; width: 96px;">
                Process
            </td>
            <td class="NormalText" valign="top" style="width: 227px; height: 25px;">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" BorderStyle="Solid" 
                            BorderWidth="1px" RepeatDirection="Horizontal" Width="900px" 
                            Font-Size="8px">
                            <asp:ListItem>ALL</asp:ListItem>
                            <asp:ListItem>ITEM GROUP WISE</asp:ListItem>
                            <asp:ListItem>ITEM GROUP WISE AGEING</asp:ListItem>
                            <asp:ListItem>CUSTOMER WISE AGEING</asp:ListItem>
                             <asp:ListItem>CUSTOMER WISE AGEING +</asp:ListItem>
                            <asp:ListItem>SALEPERSON WISE AGEING</asp:ListItem>
                            <asp:ListItem>ORDER WISE AGEING</asp:ListItem>
                        </asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" valign="top" style="height: 25px; width: 325px;">
                &nbsp;</td>
            <td class="NormalText" valign="top" style="height: 25px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" Height="22px" Width="84px"
                    CausesValidation="False">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" Height="22px" Width="83px"
                    CausesValidation="False">To Excel</asp:LinkButton>
            </td>
            <td style="text-align: center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
             <%--   <asp:Panel ID="pnlGrid" runat="server" Height="350px" Width="1000px" ScrollBars="Both">--%>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                           <asp:GridView ID="grdStage" runat="server" GridLines="Both" PageSize="3000" Width="100%" EnableCellClick="true"      >
                           
                        </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
               <%-- </asp:Panel>--%>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
 
</asp:Content>
