<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="SurveyChart.aspx.vb" Inherits="SurveyChart" title="Untitled Page" %>

<%@ Register Assembly="WebChart" Namespace="WebChart" TagPrefix="Web" %>

<%@ Register TagPrefix="web" Namespace="WebChart" Assembly="WebChart" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Drawing" %> 
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 100%;">
        <tr>
            <td  class="tableheader" colspan="3">
                <asp:Label ID="Label1" runat="server" Text=" Survey Performance" ></asp:Label>&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="1" style="width: 71px">
            </td>
            <td align="left" colspan="3">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" ForeColor="Black"
                    Text="Survey" Width="656px" Font-Size="8pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="1" style="width: 71px">
            </td>
            <td align="right" colspan="3" valign="top">
                &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="survey_results.aspx" Visible="False" CssClass="labelcells" 
                    Font-Bold="False"><< Back</asp:HyperLink></td>
        </tr>
        <tr>
            <td align="left" colspan="1" style="width: 71px" valign="top">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Text="Select Quest" Width="78px"></asp:Label></td>
                    
            <td align="left" colspan="2" valign="top">
                <asp:DropDownList ID="LstQuest" runat="server" AutoPostBack="True" Width="484px" CssClass="combobox">
                </asp:DropDownList></td>
        </tr><tr><td colspan="1" style="width: 71px; height: 222px"></td><td style="height: 222px;" colspan="2" align="left">
                &nbsp;<web:ChartControl ID="ChartControl1" runat="server"
                    ChartPadding="30" Height="400px" Width="544px" YValuesInterval="2" 
                    GridLines="Both" YCustomEnd="20" YCustomStart="0" XValuesInterval="5" 
                    ChartFormat="Png" HasChartLegend="False" LeftChartPadding="25" 
                    RightChartPadding="10" TopChartPadding="-20" TopPadding="40">
                    <YAxisFont StringFormat="Far,Near,Character,LineLimit" Font="Tahoma, 8pt, style=Bold" />
                    <XTitle StringFormat="Center,Near,Character,LineLimit" ForeColor="White" Font="Tahoma, 8pt, style=Bold" />
                    <PlotBackground Color="#CCCCCC" ForeColor="White" ImageUrl="~/Webcharts/" />
                    <ChartTitle StringFormat="Center,Near,Character,LineLimit" Font="Tahoma, 10pt, style=Bold" Text="Survey Result" />
                    <Border Color="DarkSlateGray" Width="2" />
                    <XAxisFont StringFormat="Center,Near,Character,LineLimit" Font="Tahoma, 8pt, style=Bold" />
                    <Legend Font="Tahoma, 10pt, style=Bold"></Legend>
                    <YTitle StringFormat="Center,Near,Character,DirectionVertical" ForeColor="White" Font="Tahoma, 8pt, style=Bold" />
                    <Background Color="#999999" ImageUrl="\webcharts\"  />
                </web:ChartControl></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 71px">
            </td>
            <td align="right" colspan="2" valign="top">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="survey_results.aspx" 
                    Visible="False" CssClass="labelcells" Font-Bold="False"><< Back</asp:HyperLink></td>
        </tr>
    </table>
</asp:Content>

