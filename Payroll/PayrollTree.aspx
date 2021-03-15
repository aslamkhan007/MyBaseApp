<%@ Page Title="" Language="VB" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="false" CodeFile="PayrollTree.aspx.vb" Inherits="Payroll_PayrollTree" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="5" class="tableheader">
                <asp:Label ID="Label5" runat="server" Text="Organizational Chart" Width="136px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="85%" class="panelcells">
                <span>
                    <asp:Panel ID="Panel1" runat="server" Height="400px" ScrollBars="Both" Width="85%"
                        >
                        <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="2" ImageSet="Simple" NodeIndent="25"
                            ShowLines="True" Font-Bold="False">
                            <ParentNodeStyle Font-Bold="False" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#DD5555" Font-Bold="True" />
                            <SelectedNodeStyle Font-Underline="True" ForeColor="#DD5555" HorizontalPadding="0px"
                                VerticalPadding="0px" />
                            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="0px"
                                NodeSpacing="0px" VerticalPadding="0px" />
                        </asp:TreeView>
                    </asp:Panel>
                </span>
            </td>
            <td colspan="4" class="labelcells" width="15%">
                <strong><span>
                    <asp:Image ID="Image1" runat="server" Width="186px" Height="229px" /><br />
                    <table cellpadding="0" cellspacing="0" style="width: 187px">
                        <tr>
                            <td style="background-image: url(Image/RedBar25px.PNG); text-align: center; height: 23px;" 
                                valign="top">
                                <asp:Label ID="Label1" runat="server" Height="1px" Width="185px" Font-Names="Tahoma"
                                    Font-Size="8pt" ForeColor="White"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); height: 22px" 
                                align="center" valign="top">
                                <asp:Label ID="Label2" runat="server" Height="8px" Width="185px" Font-Names="Tahoma"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-image: url(Image/SmallGlassBarNormal.PNG); height: 30px" 
                                align="center" valign="top">
                                <asp:Label ID="Label3" runat="server" Height="1px" Width="185px" Font-Names="Tahoma"
                                    Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </span></strong>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript" src="datetimepicker.js">

        //Date Time Picker script- by TengYong Ng of http://www.rainforestnet.com
        //Script featured on JavaScript Kit (http://www.javascriptkit.com)
        //For this script, visit http://www.javascriptkit.com 



    </script>

</asp:Content>
