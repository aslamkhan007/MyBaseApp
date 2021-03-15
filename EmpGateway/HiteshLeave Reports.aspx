<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Leave Reports.aspx.vb" Inherits="LeaveReports" title="Leave Reports"  MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="FlashControl" Namespace="Bewise.Web.UI.WebControls" TagPrefix="Bewise" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript" src="datetimepicker.js">

//Date Time Picker script- by TengYong Ng of http://www.rainforestnet.com
//Script featured on JavaScript Kit (http://www.javascriptkit.com)
//For this script, visit http://www.javascriptkit.com 



function TABLE1_onclick() {

}

</script>

    <table rules="none" style="width: 726px; height: 8px" id="TABLE1" >
        <tr>
            <td colspan="4" style="background-image: url(Image/RedBar25px.PNG); height: 23px;
                text-align: left">
                <asp:Label ID="Label5" runat="server" BorderColor="Transparent" Font-Bold="True"
                        Font-Names="Trebuchet MS" Font-Size="10pt" ForeColor="White" Text="Leave Reports"
                        Width="98px"></asp:Label></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG); width: 145px; height: 34px">
                <strong><span style="font-size: 8pt; color: #696969; font-family: Tahoma; width: 145px;">Status</span></strong></td>
            <td colspan="3" style="height: 34px; background-color: whitesmoke">
                <asp:DropDownList ID="Status" runat="server" Font-Bold="False"
                    Font-Names="Tahoma" Font-Size="8pt" Width="117px" AutoPostBack="True">
                    <asp:ListItem>Authorized</asp:ListItem>
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Canceled</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="background-image: url(Image/Gradient2.PNG); width: 145px; height: 16px">
                <strong><span style="font-size: 8pt; color: #696969; font-family: Tahoma">Current Month
                    From </span></strong></td>
            <td style="font-size: 8pt; width: 140px; color: #696969; font-family: Tahoma; height: 16px; background-color: whitesmoke;"
                valign="top">
                <ew:CalendarPopup ID="LeaveDateFrom" runat="server" BackColor="WhiteSmoke" Culture="English (United Kingdom)"
                    Text="..." Width="65px" Font-Names="Tahoma" Font-Size="8pt">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
            </td>
            <td style="background-image: url(Image/Gradient2.PNG); width: 145px; height: 16px">
                <strong><span style="font-size: 8pt; color: #696969; font-family: Tahoma">Current Month
                    To </span></strong></td>
            <td style="width: 114px; height: 16px; background-color: whitesmoke; font-size: 12pt; font-family: Times New Roman;">
                <ew:CalendarPopup ID="LeaveDateTo" runat="server" BackColor="WhiteSmoke" Culture="English (United Kingdom)"
                    Text="..." Width="64px">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr style="font-size: 12pt; font-family: Times New Roman">
            <td style="width: 145px; height: 16px; background-image: url(Image/Gradient2.PNG);">
                <span dir="ltr" style="font-size: 8pt; color: dimgray; font-family: Tahoma"><strong>
                    Auth/Cancel&nbsp; From</strong></span></td>
            <td style="width: 140px; font-size: 8pt; color: #696969; font-family: Tahoma; height: 16px; background-color: whitesmoke;" valign="top"><ew:CalendarPopup ID="LeaveFrom" runat="server" BackColor="WhiteSmoke" Culture="English (United Kingdom)"
                    Text="..." Width="65px" Font-Names="Tahoma" Font-Size="8pt">
                <ClearDateStyle BackColor="#E0E0E0" />
                <DayHeaderStyle BackColor="OrangeRed" />
                <MonthYearSelectedItemStyle BackColor="Silver" />
                <TodayDayStyle BackColor="#FFC0C0" />
                <MonthHeaderStyle BackColor="Gray" />
                <GoToTodayStyle BackColor="#E0E0E0" />
            </ew:CalendarPopup>
            </td>
            <td style="width: 145px; height: 16px; background-image: url(Image/Gradient2.PNG); font-size: 12pt; font-family: Times New Roman;">
                <span style="font-size: 8pt; color: dimgray; font-family: Tahoma"><strong>Auth/Cancel&nbsp;
                    To</strong></span></td>
            <td style="width: 114px; height: 16px; background-color: whitesmoke; font-size: 12pt; font-family: Times New Roman;">
                <ew:CalendarPopup ID="LeaveTo" runat="server" BackColor="WhiteSmoke" Culture="English (United Kingdom)"
                    Text="..." Width="64px">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr style="font-size: 12pt; font-family: Times New Roman">
            <td style="background-image: url(Image/Gradient2.PNG); width: 145px; height: 16px">
                <strong><span style="font-size: 8pt; color: #696969; font-family: Tahoma; width: 145px;">Nature of
                        Leave</span></strong></td>
            <td style="font-size: 8pt; width: 140px; color: #696969; font-family: Tahoma; height: 16px;
                background-color: whitesmoke" valign="top">
                <asp:DropDownList ID="Nature" runat="server" Font-Bold="False"
                    Font-Names="Tahoma" Font-Size="8pt" Width="117px">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>Casual Leave</asp:ListItem>
                    <asp:ListItem>Short Leave</asp:ListItem>
                    <asp:ListItem>Priviledge Leave</asp:ListItem>
                    <asp:ListItem>Sick Leave</asp:ListItem>
                    <asp:ListItem>Compensatry Leave</asp:ListItem>
                    <asp:ListItem>Tour</asp:ListItem>
                    <asp:ListItem>Official Duty</asp:ListItem>
                </asp:DropDownList></td>
            <td style="font-size: 12pt; background-image: url(Image/Gradient2.PNG); width: 145px;
                font-family: Times New Roman; height: 16px">
                <strong><span style="font-size: 8pt; color: #696969; font-family: Tahoma; width: 145px;">Department</span></strong></td>
            <td style="font-size: 12pt; width: 114px; font-family: Times New Roman; height: 16px;
                background-color: whitesmoke">
                <asp:DropDownList ID="Department" runat="server" Font-Bold="False"
                    Font-Names="Tahoma" Font-Size="8pt" Width="280px" DataSourceID="LeaveReportsSource" DataTextField="DEPTNAME" DataValueField="DEPTNAME">
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 12pt; font-family: Times New Roman">
            <td style="background-image: url(Image/Gradient2.PNG); width: 145px; height: 16px">
                <strong><span style="font-size: 8pt; color: #696969; font-family: Tahoma; width: 145px;">Shift</span></strong></td>
            <td style="font-size: 8pt; color: #696969; font-family: Tahoma; height: 16px;
                background-color: whitesmoke" valign="top" colspan="3">
                <asp:DropDownList ID="Shift" runat="server" BackColor="White" Font-Names="Tahoma"
                    Font-Size="8pt" Width="99px">
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 12pt; font-family: Times New Roman">
            <td colspan="4" style="background-image: url(Image/Gradient2.PNG); background-repeat: repeat-y;
                height: 9px" align="center">
                <br />
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" BorderColor="Silver" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ForeColor="#404040"
                    RepeatDirection="Horizontal" Width="340px" CellPadding="0" CellSpacing="0" Height="14px">
                    <asp:ListItem Selected="True" Value="Factory">Factory</asp:ListItem>
                    <asp:ListItem Value="Admin">Admin</asp:ListItem>
                    <asp:ListItem>Short/Offical Duty/Tour Leave</asp:ListItem>
                </asp:RadioButtonList>&nbsp;</td>
        </tr>
        <tr style="font-size: 12pt; font-family: Times New Roman">
            <td colspan="4" style="height: 34px; background-color: whitesmoke; text-align: center;">
                <asp:Button ID="btnviewrep" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Height="26px" Text="View Report" Width="143px" />&nbsp;
                <asp:Button ID="Print" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                    Height="26px" Text="Print" Width="80px" /></td>
        </tr>
        <tr style="font-size: 12pt; font-family: Times New Roman">
           <td colspan="4" style="height: 22px">
               <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                   BestFitPage="False" DisplayGroupTree="False" EnableDatabaseLogonPrompt="False"
                   EnableParameterPrompt="False" HasPrintButton="False" />
               &nbsp;
               <asp:SqlDataSource ID="LeaveReportsSource" runat="server" ConnectionString="Data Source=misdev;Initial Catalog=jctdev;Persist Security Info=True;User ID=itgrp;Password=power"
                   ProviderName="System.Data.SqlClient" SelectCommand="SELECT  'All'  AS  DEPTNAME  UNION SELECT [DEPTNAME] FROM [DEPTMAST] ">
               </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

