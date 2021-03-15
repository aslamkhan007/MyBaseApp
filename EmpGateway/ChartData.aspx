<%@ Page Title="" Language="VB"  AutoEventWireup="false" CodeFile="ChartData.aspx.vb" Inherits="EmpGateway_ChartData" %>

<%@ Register assembly="System.Web.DataVisualization" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

       <form id="form1" runat="server">

       <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lbl_Survey" runat="server" Text="Survey :  "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_Survey1" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width: 345px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lbl_Question" runat="server" Text="Question :  "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_QuestionNumber" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width: 345px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="3">
                    <asp:Chart ID="Chart1" runat="server" BackColor="DarkGray" 
                        BackGradientStyle="TopBottom" Height="550px" Width="800px" 
                        Palette="Chocolate">
                        <series>
                            <asp:Series ChartArea="ChartArea1" Name="Series1" IsValueShownAsLabel="True" 
                                Palette="BrightPastel" YValuesPerPoint="3">
                                <emptypointstyle color="DarkOrange" postbackvalue="#VALX" 
                                    tooltip="Parameter Name" />
                            </asp:Series>
                        </series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:GridView ID="grd_chart" runat="server" Height="300px" Width="400px">
                    </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>
                <td style="width: 345px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td rowspan="2">
                    &nbsp;</td>
                <td rowspan="2" colspan="3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
</form>

    
