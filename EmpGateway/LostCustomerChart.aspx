<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="LostCustomerChart.aspx.vb" Inherits="LostCustomerChart" title="Untitled Page" %>

<%@ Register Assembly="WebChart" Namespace="WebChart" TagPrefix="Web" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table background="Image/BusinessChart.jpg" style="width: 100%; height: 152px">
        <tr>
            <td background="Image/RedBar25px.PNG" colspan="3" style="height: 23px" valign="top">
                &nbsp;<asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                    Font-Size="10pt" ForeColor="White" Text="Lost Customer Analysis Chart" Width="232px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 60px">
            </td>
            <td style="width: 583px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 60px">
            </td>
            <td style="width: 583px">
                <Web:ChartControl ID="ChartControl1" runat="server" ChartFormat="PNG" ChartPadding="30"
                    GridLines="Both" HasChartLegend="False" Height="400px" LeftChartPadding="25"
                    RightChartPadding="10" ShowTitlesOnBackground="False" TopChartPadding="-20" TopPadding="40"
                    Width="544px" XValuesInterval="5" YCustomEnd="20" YCustomStart="0" YValuesInterval="2">
                    <Border Color="DarkSlateGray" Width="2" />
                    <YAxisFont Font="Tahoma, 8pt, style=Bold" StringFormat="Far,Near,Character,LineLimit" />
                    <XTitle Font="Tahoma, 8pt, style=Bold" ForeColor="White" StringFormat="Center,Near,Character,LineLimit" />
                    <PlotBackground Color="#FFF7E7" ForeColor="White" />
                    <XAxisFont Font="Tahoma, 8pt, style=Bold" StringFormat="Center,Near,Character,LineLimit" />
                    <Background Color="SkyBlue" />
                    <ChartTitle Font="Tahoma, 10pt, style=Bold" StringFormat="Center,Near,Character,LineLimit"
                        Text="Lost Customers" />
                    <Legend Font="Tahoma, 10pt, style=Bold"></Legend>
                    <YTitle Font="Tahoma, 8pt, style=Bold" ForeColor="White" StringFormat="Center,Near,Character,DirectionVertical" />
                </Web:ChartControl></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 60px">
            </td>
            <td style="width: 583px">
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

