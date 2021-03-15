<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="InvoiceWiseOutStanding.aspx.vb" Inherits="OPS_Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>

    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>


   <%-- <script type="text/javascript">

        $(document).ready(function () {


            $("#GridView1 tr").click(function (event) {
                alert($(this).index());
            });

            $("#GridView1 td").click(function (event) {
                alert($(this).index());
            });

            $("#<%=GridView1.ClientID%> tr:has(td)").hover(function (e) {
                $(this).css("cursor", "pointer");
            });

            $("#<%=GridView1.ClientID%> tr:has(td)").click(function (e) {
                var selTD = $(e.target).closest("td");
                alert(selTD.text());

                $(this).closest('table').find('th').eq($(this).index());

            });
        });

        
    </script>--%>

    <script type="text/javascript">

        $(document).ready(function () {
            gridviewScroll();
        });


        function gridviewScroll() {
            $('#<%=GridView1.ClientID%>').gridviewScroll({
                width: 1024,
                height: 500,
                freezesize:6
            });
        } 

    </script>

    <table style="width: 100%;">
        <tr>
            <td style="width: 343px; height: 37px">
                Invoice Details</td>
            <td style="height: 37px; width: 177px">
                &nbsp;
            </td>
            <td style="height: 37px">
            </td>
        </tr>
        <tr>
            <td style="width: 343px; height: 37px">
                <asp:Button ID="BtnGet" runat="server" BackColor="Black" CssClass="ButtonBack" Text="View"
                    ValidationGroup="A" />
                <asp:Button ID="BtnExcel" runat="server" BackColor="Black" 
                    CssClass="ButtonBack" Text="Excel"
                    ValidationGroup="A" />
                      <asp:Button ID="btnAgeing" runat="server" BackColor="Black" 
                    CssClass="ButtonBack" Text="Ageing"
                    />
            </td>
            <td style="height: 37px; width: 177px">
              <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <img alt="" src="../CostingSystemTest/Image/loading.gif" style="width: 70px; height: 10px" />
                        &nbsp;
                        <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="Please Wait..."></asp:Label>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td style="height: 37px">
                &nbsp;
            </td>
        </tr>
        </table>
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" GridLines="None" PageSize="150000" Width="100%"
                ClientIDMode="Static">
                <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                <HeaderStyle CssClass="GridviewScrollHeader" />
                <RowStyle CssClass="GridviewScrollItem" />
                <PagerStyle CssClass="GridviewScrollPager" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
