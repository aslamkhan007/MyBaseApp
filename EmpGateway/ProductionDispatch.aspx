<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"    CodeFile="ProductionDispatch.aspx.vb" Inherits="ProductionDispatch"     Title="Packing Update Status Report" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" %> 
 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    <%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%--<%@ Register assembly="XGridView" namespace="CustomControls" tagprefix="cc2" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
    <script src="../Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
            
        });

     $("#GridView1 tr").click(function (event) {
         $('#<%=GridView1.ClientID%>').gridviewScroll({
             width: 1024,
             height: 500,
             freezesize: 2
         });
        });



        function gridviewScroll() {
            $('#<%=GridView1.ClientID%>').gridviewScroll({
                width: 1024,
                height: 500,
                freezesize: 2
            });

            

        }

    


    </script>--%>
    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="5">
                Production & Dispatch Reports
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td style="height: 11px; text-align: center;">
                <table  style="width:100%;">
                    <tr  >
                        <td style="text-align: right">
                        <asp:Button ID="BtnFetch" runat="server" BackColor="Black" 
                            CausesValidation="False" CssClass="ButtonBack" Text="Fetch" />
                        </td>
                        <td  style="text-align: left; width: 64px">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="BtnRefresh" runat="server" BackColor="Black" 
                            CausesValidation="False" CssClass="ButtonBack" Text="Refresh" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
                        <td   style="text-align: left">
                <asp:Button ID="BtnExcel" runat="server" BackColor="Black" CausesValidation="False"
                    CssClass="ButtonBack" Text="Excel" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 11px; text-align: left; color: #FF3300;">
                * Value for GINS,TINS has not included</td>
        </tr>
        <tr>
            <td style="height: 11px; text-align: center;">
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
    <table style="width: 100%" >
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" GridLines="BOTH" PageSize="150000" Width="100%" EnableCellClick="true"      >
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
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    BestFitPage="False" DisplayGroupTree="False" EnableDatabaseLogonPrompt="False"
                    EnableParameterPrompt="False" 
                    ToolbarImagesFolderUrl="aspnet_client/system_web/2_0_50727/CrystalReportWebFormViewer3/Images/toolbar/" 
                    ReportSourceID="CrystalReportSource1"  />
                </td>
        </tr>
        <tr>
            <td>
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="rptLeave.rpt">
                    </Report>
                </CR:CrystalReportSource>
                </td>
        </tr>
    </table>
</asp:Content>
