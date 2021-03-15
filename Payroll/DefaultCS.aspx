<%@ Page Language="c#" CodeFile="DefaultCS.aspx.cs" Inherits="Telerik.Web.Examples.HtmlChart.Functionality.DrillDownChart.DefaultCS" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<%@ Register TagPrefix="qsf" Namespace="Telerik.QuickStart" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns='http://www.w3.org/1999/xhtml'>
<head id="Head1" runat="server">
    <title>Telerik ASP.NET Example</title>
    <script src="js/scripts.js" type="text/javascript"></script>
   <%-- <script src="scripts.js" type="text/javascript"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />
    <div class="demo-container size-wide">
        <telerik:RadHtmlChart ID="RadHtmlChart1" runat="server" DataSourceID="SqlDataSource1"
            OnClientSeriesClicked="OnClientSeriesClicked" Skin="Black">
            <ChartTitle Text="Revenue">
            </ChartTitle>
            <PlotArea>
                <Series>
                    <telerik:ColumnSeries DataFieldY="Rev" Name="Plant">
                        <%--<TooltipsAppearance Color="White" />--%>
                    </telerik:ColumnSeries>
                </Series>
                <XAxis DataLabelsField="Plant">
                </XAxis>
            </PlotArea>
        </telerik:RadHtmlChart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev%>"
            SelectCommand="SELECT Sum(PayAmount) as Rev, Plant  FROM jct_payroll_pay_salary   GROUP BY Plant">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev%>"
            SelectCommand="SELECT Sum(PayAmount) as Rev, Location  FROM jct_payroll_pay_salary WHERE Plant = @Plant  GROUP BY Location">
            <SelectParameters>
                <asp:Parameter Name="Plant"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev%>"
            SelectCommand="SELECT Sum(PayAmount) as Rev, Deptcode  FROM jct_payroll_pay_salary WHERE Plant = @Plant AND Location = @Location   GROUP BY Deptcode">
            <SelectParameters>
                <asp:Parameter Name="Plant"></asp:Parameter>
                <asp:Parameter Name="Location"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadHtmlChart1" LoadingPanelID="LoadingPanel1">
                        </telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="Refresh">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadHtmlChart1" LoadingPanelID="LoadingPanel1">
                        </telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="LoadingPanel1" Height="77px" Width="113px" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function getAjaxManager() {
                    return $find("<%=RadAjaxManager1.ClientID%>");
                }
            </script>
        </telerik:RadCodeBlock>
    </div>

    

  <%--  <ConfiguratorPanel runat="server" ID="ConfiguratorPanel1">
        <Views>
            <View>
                <ConfiguratorColumn ID="ConfiguratorColumn1" runat="server" Size="Medium">
                    <Button runat="server" ID="Refresh" Text="Restore Years Revenue Chart"
                        OnClick="Refresh_Click">
                    </Button>
                </ConfiguratorColumn>
            </View>
        </Views>
    </ConfiguratorPanel>--%>

    
    <%--<qsf:ConfiguratorPanel runat="server" ID="ConfiguratorPanel1">
        <Views>
            <qsf:View>
                <qsf:ConfiguratorColumn ID="ConfiguratorColumn1" runat="server" Size="Medium">
                    <qsf:Button runat="server" ID="Refresh" Text="Restore Years Revenue Chart"
                        OnClick="Refresh_Click">
                    </qsf:Button>
                </qsf:ConfiguratorColumn>
            </qsf:View>
        </Views>
    </qsf:ConfiguratorPanel>--%>

     
    </form>
</body>
</html>
