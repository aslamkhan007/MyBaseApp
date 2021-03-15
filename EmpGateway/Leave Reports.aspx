<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Leave Reports.aspx.vb" Inherits="LeaveReports" Title="Leave Reports"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="FlashControl" Namespace="Bewise.Web.UI.WebControls" TagPrefix="Bewise" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="datetimepicker.js">

        //Date Time Picker script- by TengYong Ng of http://www.rainforestnet.com
        //Script featured on JavaScript Kit (http://www.javascriptkit.com)
        //For this script, visit http://www.javascriptkit.com 



      

    </script>

    <table width="100%" >
        <tr>
            <td colspan="4" class="tableheader">
                <asp:Label ID="Label5" runat="server" Text="Leave Reports" Width="98px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Current Month Fr. (Auth)
            </td>
            <td class="textcells">
                <ew:CalendarPopup ID="LeaveDateFrom" CssClass="textbox" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="65px">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
            </td>
            <td class="labelcells">
                Current Month To (Auth.)
            </td>
            <td class="textcells">
                <ew:CalendarPopup ID="LeaveDateTo" CssClass="textbox" runat="server" Culture="English (United Kingdom)"
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
        <tr>
            <td class="labelcells">
                Auth Date from/Pend Fr.
            </td>
            <td class="textcells">
                <ew:CalendarPopup ID="LeaveFrom" runat="server" CssClass="textbox" Culture="English (United Kingdom)"
                    Text="..." Width="65px">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
            </td>
            <td class="labelcells">
                Auth Date To/Pend. To
            </td>
            <td class="textcells">
                <ew:CalendarPopup ID="LeaveTo" CssClass="textbox" runat="server" Culture="English (United Kingdom)"
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
        <tr>
            <td class="labelcells">
                Nature of Leave
            </td>
            <td class="textcells">
                <asp:DropDownList ID="Nature" CssClass="combobox" runat="server" Width="117px">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>Casual Leave</asp:ListItem>
                    <asp:ListItem>Short Leave</asp:ListItem>
                    <asp:ListItem>Priviledge Leave</asp:ListItem>
                    <asp:ListItem>Sick Leave</asp:ListItem>
                    <asp:ListItem>Compensatry Leave</asp:ListItem>
                    <asp:ListItem>Tour</asp:ListItem>
                    <asp:ListItem>Official Duty</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Department
            </td>
            <td class="textcells">
                <asp:DropDownList ID="Department" CssClass="combobox" runat="server" Width="280px"
                    DataSourceID="LeaveReportsSource" DataTextField="DEPTNAME" DataValueField="DEPTNAME">
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Status
            </td>
            <td class="textcells">
                <asp:DropDownList ID="Status" CssClass="combobox" runat="server" Width="117px">
                    <asp:ListItem>Authorized</asp:ListItem>
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Canceled</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Shift
            </td>
            <td class="textcells">
                <asp:DropDownList ID="Shift" CssClass="combobox" runat="server" Width="99px">
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="textcells">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" BorderColor="Silver" Font-Bold="True"
                    Font-Names="Tahoma" Font-Size="8pt" ForeColor="#404040" RepeatDirection="Horizontal"
                    Width="340px" CellPadding="0" CellSpacing="0" Height="14px">
                    <asp:ListItem Selected="True" Value="Factory">Factory</asp:ListItem>
                    <asp:ListItem Value="Admin">Admin</asp:ListItem>
                    <asp:ListItem>Short/Offical Duty/Tour Leave</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="labelcells">
            </td>
        </tr>
        <tr>
            <td colspan="4" class="buttonbackbar">
                <asp:Button ID="Button1" runat="server" Text="View Report" CssClass="ButtonBack" BackColor="Black" />
                <asp:Button ID="Button2" runat="server" Text="Export" CssClass="ButtonBack" BackColor="Black" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    BestFitPage="False" DisplayGroupTree="False" EnableDatabaseLogonPrompt="False"
                    EnableParameterPrompt="False" ToolbarImagesFolderUrl="aspnet_client/system_web/2_0_50727/CrystalReportWebFormViewer3/Images/toolbar/"  />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="rptLeave.rpt">
                    </Report>
                </CR:CrystalReportSource>
                <asp:SqlDataSource ID="LeaveReportsSource" runat="server" ConnectionString="Data Source=misdev;Initial Catalog=jctdev;Persist Security Info=True;User ID=itgrp;Password=power"
                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT  'All'  AS  DEPTNAME  UNION SELECT [DEPTNAME] FROM [DEPTMAST] ">
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
